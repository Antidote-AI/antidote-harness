#r "nuget: Fun.Build, 0.3.1"
#r "nuget: BlackFox.CommandLine, 1.0.0"
#r "nuget: FsToolkit.ErrorHandling, 4.3.0"
#r "nuget: Npgsql, 7.0.1"
#r "nuget: Fake.IO.FileSystem, 5.23.1"
#r "nuget: dotenv.net, 3.1.2"

open Fun.Build
open BlackFox.CommandLine
open FsToolkit.ErrorHandling
open System.Diagnostics
open System
open Spectre.Console
open Npgsql
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open dotenv.net

[<Literal>]
let DOCKER_IMAGE_NAME = "postgres:14"

[<Literal>]
let DOCKER_INSTANCE_NAME = "antidote-mono-repo-sql-server"

module Glob =

    let fableJs baseDir = baseDir </> "**/*.fs.js"
    let fableJsMap baseDir = baseDir </> "**/*.fs.js.map"
    let js baseDir = baseDir </> "**/*.js"
    let jsMap baseDir = baseDir </> "**/*.js.map"

module Extensions =

    type Process with

        static member StartAsyncCaptureOutput
            (
                startInfo: ProcessStartInfo,
                commandLogString: string,
                logPrefix: string
            ) =
            async {
                use result = Process.Start startInfo
                let standardOutputSb = System.Text.StringBuilder()

                result.OutputDataReceived.Add(fun e ->
                    standardOutputSb.Append e.Data |> ignore
                    Console.WriteLine(logPrefix + "> " + e.Data)
                )

                use! cd =
                    Async.OnCancel(fun _ ->
                        AnsiConsole.Markup $"[yellow]{logPrefix}[/] "

                        AnsiConsole.WriteLine
                            $"{commandLogString} is cancelled or timeout and the process will be killed."

                        result.Kill()
                    )

                result.BeginOutputReadLine()
                result.WaitForExit()

                return {|
                    ExitCode = result.ExitCode
                    StandardOutput = standardOutputSb.ToString()
                |}
            }

    type StageContext with

        member ctx.RunCommandCaptureOutput(commandStr: string, ?step: int) = async {
            let command = ctx.BuildCommand commandStr

            let prefix =
                match step with
                | Some i -> ctx.BuildStepPrefix i
                | None -> ctx.GetNamePath()

            AnsiConsole.Markup $"[green]{prefix}[/] "
            AnsiConsole.MarkupLine $"{commandStr}"

            let! result = Process.StartAsyncCaptureOutput(command, commandStr, prefix)

            if ctx.IsAcceptableExitCode result.ExitCode then
                return Ok result
            else
                return Error "Exit code is not indicating as successful."
        }

        member ctx.RunCommand(commandLine: CmdLine, ?step: int) = async {
            let commandStr = CmdLine.toString commandLine
            let! result = ctx.RunCommand(commandStr, ?step = step)
            return result
        }

        member ctx.AddCommandSensitiveStep(commandStrFn: StageContext -> Async<string>) =
            { ctx with
                Steps =
                    ctx.Steps
                    @ [
                        Step.StepFn(fun (ctx, i) -> async {
                            let! commandStr = commandStrFn ctx
                            return! ctx.RunSensitiveCommand($"{commandStr}", i)
                        }
                        )
                    ]
            }

    type StageBuilder with

        [<CustomOperation("runSensitive")>]
        member _.runSensitive(build: BuildStage, step: StageContext -> Async<string>) =
            BuildStage(fun ctx -> build.Invoke(ctx).AddCommandSensitiveStep(step))

        [<CustomOperation("runSensitive")>]
        member _.runSensitive(build: BuildStage, step: StageContext -> string) =
            BuildStage(fun ctx -> build.Invoke(ctx).AddCommandSensitiveStep(fun ctx -> async { return step ctx }))

        [<CustomOperation("wait")>]
        member inline _.wait([<InlineIfLambda>] build: BuildStage, milliseconds: int) =
            BuildStage(fun ctx ->
                let ctx = build.Invoke ctx
                let noPrefixForStep = ctx.GetNoPrefixForStep()

                { ctx with
                    Steps =
                        ctx.Steps
                        @ [
                            Step.StepFn(fun (ctx, i) ->
                                let prefix = ctx.BuildStepPrefix i

                                if not noPrefixForStep then
                                    AnsiConsole.Markup $"[green]{prefix}[/] "

                                AnsiConsole.MarkupLine $"waiting for {milliseconds} ms..."

                                async {
                                    do! Async.Sleep milliseconds
                                    return Ok()
                                }
                            )
                        ]
                }
            )

open Extensions

module Stages =
    //
    // let setupLocalDatabase
    //     stage "Setup local Database" {
    //
    //     }

    let private createConnectionString (databaseName: string) =
        [
            "User ID", "postgres"
            "Password", "lfxlfxLFX$"
            "Server", "127.0.0.1"
            "Port", "33301"
            "Database", databaseName
        ]
        |> List.map (fun (key, value) -> $"%s{key}=%s{value}")
        |> String.concat ";"

    let initDocker =
        stage "Init docker" {
            workingDir __SOURCE_DIRECTORY__

            run (
                CmdLine.empty
                |> CmdLine.appendRaw "docker"
                |> CmdLine.appendPrefix "pull" DOCKER_IMAGE_NAME
                |> CmdLine.toString
            )

            // If an instance of the docker container already exist destroy it
            run (fun ctx -> asyncResult {
                let! listContainerResult =
                    CmdLine.empty
                    |> CmdLine.appendRaw "docker"
                    |> CmdLine.appendRaw "container"
                    |> CmdLine.appendRaw "ls"
                    |> CmdLine.appendPrefix "--filter" $"name={DOCKER_INSTANCE_NAME}"
                    |> CmdLine.appendRaw "--all"
                    |> CmdLine.toString
                    |> ctx.RunCommandCaptureOutput

                if listContainerResult.StandardOutput.Contains(DOCKER_INSTANCE_NAME) then
                    do!
                        CmdLine.empty
                        |> CmdLine.appendRaw "docker"
                        |> CmdLine.appendRaw "stop"
                        |> CmdLine.appendRaw DOCKER_INSTANCE_NAME
                        |> CmdLine.toString
                        |> ctx.RunCommand

                    do!
                        CmdLine.empty
                        |> CmdLine.appendRaw "docker"
                        |> CmdLine.appendRaw "rm"
                        |> CmdLine.appendRaw DOCKER_INSTANCE_NAME
                        |> CmdLine.toString
                        |> ctx.RunCommand
            }
            )

            run (
                CmdLine.empty
                |> CmdLine.appendRaw "docker"
                |> CmdLine.appendRaw "run"
                |> CmdLine.appendRaw "-e \"POSTGRES_PASSWORD=lfxlfxLFX$\""
                |> CmdLine.appendRaw "-e \"POSTGRES_DB=antidote\""
                |> CmdLine.appendRaw "-p 33301:5432"
                |> CmdLine.appendRaw $"--name %s{DOCKER_INSTANCE_NAME}"
                |> CmdLine.appendRaw $"-d %s{DOCKER_IMAGE_NAME}"
                |> CmdLine.toString
            )

            // Wait for docker to start
            // Not really robust but without that the Database access will fail
            stage "Wait for docker to start" {
                timeout 10 // Docker has 10 seconds to start

                run (fun _ -> async {
                    let testDocker () =
                        use sqlConnection = new NpgsqlConnection(createConnectionString "")
                        sqlConnection.Open()

                        use command = sqlConnection.CreateCommand()
                        command.CommandText <- "SELECT 1"

                        command.ExecuteNonQuery() |> ignore
                        sqlConnection.Close()

                    let rec retry () =
                        async {
                            try
                                testDocker()
                            with
                            | _ ->
                                do! Async.Sleep 1000
                                return! retry ()
                        }

                    do! retry ()
                } )
            }
        }

    let setupLocalDb =
        let cleanUpDatabase (dbName: string) =
            stage $"Clean up database - '%s{dbName}'" {

                run (fun _ ->
                    use sqlConnection = new NpgsqlConnection(createConnectionString "")
                    sqlConnection.Open()

                    use batch = sqlConnection.CreateBatch()
                    batch.BatchCommands.Add(NpgsqlBatchCommand $"DROP DATABASE IF EXISTS %s{dbName}")
                    batch.BatchCommands.Add(NpgsqlBatchCommand $"CREATE DATABASE %s{dbName}")

                    batch.ExecuteNonQuery() |> ignore
                    sqlConnection.Close()
                )

            }

        let createDboSchemaInDatabase (dbName: string) =
            stage $"Create dbo schema in database - '%s{dbName}'" {

                run (fun _ ->
                    use sqlConnection = new NpgsqlConnection(createConnectionString dbName)
                    sqlConnection.Open()

                    use command = sqlConnection.CreateCommand()
                    command.CommandText <- "CREATE SCHEMA dbo"

                    command.ExecuteNonQuery() |> ignore
                    sqlConnection.Close()
                )
            }

        stage "Setup local Database" {
            workingDir __SOURCE_DIRECTORY__

            cleanUpDatabase "antidote"
            cleanUpDatabase "antidote_tenant_catalog"
            createDboSchemaInDatabase "antidote"
            createDboSchemaInDatabase "antidote_tenant_catalog"

            // Remove artefacts from previous runs
            run (fun _ ->
                [
                    "Server/Antidote.Database/Dbos.fs"
                    "Server/Antidote.Database.TenantCatalog/Dbos.fs"
                ]
                |> Seq.iter Shell.rm
            )

            run (
                CmdLine.empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "grate"
                |> CmdLine.appendPrefix "--connectionstring" (createConnectionString "antidote")
                |> CmdLine.appendPrefix "--databasetype" "postgresql"
                |> CmdLine.appendPrefix "--folders" "Server/Antidote.Database/Migrations"
                |> CmdLine.appendPrefix "--env" "TEST"
                |> CmdLine.appendRaw "--noninteractive"
                |> CmdLine.toString
            )

            run (
                CmdLine.empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "grate"
                |> CmdLine.appendPrefix "--connectionstring" (createConnectionString "antidote_tenant_catalog")
                |> CmdLine.appendPrefix "--databasetype" "postgresql"
                |> CmdLine.appendPrefix "--folders" "Server/Antidote.Database.TenantCatalog/Migrations"
                |> CmdLine.appendRaw "--noninteractive"
                |> CmdLine.toString
            )

            echo "Migrating antidote database"

            run (
                CmdLine.empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "sqlhydra-npgsql"
                |> CmdLine.toString
            )

            echo "Migrating antidote_tenant_catalog database"

            run (
                CmdLine.empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "sqlhydra-npgsql"
                |> CmdLine.appendRaw "antidote-tenant-catalog.toml"
                |> CmdLine.toString
            )
        }

    let nodemonFcm (suffix: string) (workingDirectory: string) =
        stage $"CSS code gen - {suffix}" {
            workingDir workingDirectory

            run (
                CmdLine.empty
                |> CmdLine.appendRaw "npx"
                |> CmdLine.appendRaw "nodemon"
                |> CmdLine.appendPrefix "-e" "module.scss"
                |> CmdLine.appendPrefix "--exec" "fcm"
                |> CmdLine.toString
            )
        }

    let fcm (suffix: string) (workingDirectory: string) =
        stage $"CSS code gen - {suffix}" {
            workingDir workingDirectory

            run "npx fcm"
        }

module Folders =

    module Shared =

        [<Literal>]
        let AntidoteReact = "Shared/Antidote.React"

        [<Literal>]
        let FableFormAntidoteView = "Shared/Fable.Form.Antidote.View"

    module Server =

        [<Literal>]
        let AntidoteServer = "Server/Antidote.Server"

        [<Literal>]
        let AntidoteServerSignalR = "Server/Antidote.Server.SignalR"

        [<Literal>]
        let AntidoteServerTests = "Server/Antidote.Server.Tests"

type Application =
    | Healix
    | BehavioralBackup

module Application =

    let getFolderName (application: Application) =
        match application with
        | Healix -> "Healix"
        | BehavioralBackup -> "BehavioralBackup"

    let getIosFolderName (application: Application) =
        match application with
        | Healix -> "webapp-hlx"
        | BehavioralBackup -> "webapp"

    let getName (application: Application) =
        match application with
        | Healix -> "Healix"
        | BehavioralBackup -> "BehavioralBackup"

let createApplicationPipeline (application: Application) =
    let applicationName = Application.getName application
    let clientDir = Application.getFolderName application
    let srcDir = clientDir </> "src"

    pipeline $"{applicationName}.Watch" {
        workingDir __SOURCE_DIRECTORY__
        noPrefixForStep

        Stages.initDocker
        Stages.setupLocalDb

        stage "NPM Install" { run "npm install" }

        stage "Clean artifacts" {
            paralle

            run (fun _ ->
                [
                    srcDir </> "bin"
                    srcDir </> "obj"
                    clientDir </> "dist"
                ]
                |> Shell.cleanDirs
            )

            run (fun _ ->
                !!(Glob.fableJs srcDir)
                ++ (Glob.fableJsMap srcDir)
                ++ (srcDir </> "CssModules.fs")
                ++ "Shared/Antidote.React/CssModules.fs"
                ++ "Shared/Fable.Form.Antidote.View/CssModules.fs"
                |> Seq.iter Shell.rm
            )
        }

        // Ensure that CssModules.fs files are ready when Fable starts
        stage "Pre compile CssModules files" {
            Stages.fcm applicationName srcDir
            Stages.fcm "Antidote.React" Folders.Shared.AntidoteReact
            Stages.fcm "Fable.Form.Antidote.View" Folders.Shared.FableFormAntidoteView
        }

        stage "Watch, compile and serve" {
            paralle

            Stages.nodemonFcm applicationName srcDir
            Stages.nodemonFcm "Antidote.React" Folders.Shared.AntidoteReact
            Stages.nodemonFcm "Fable.Form.Antidote.View" Folders.Shared.FableFormAntidoteView

            stage "Vite" {
                workingDir clientDir
                run "npx vite serve"
            }

            stage "Fable" {
                workingDir srcDir

                run (
                    CmdLine.empty
                    |> CmdLine.appendRaw "dotnet"
                    |> CmdLine.appendRaw "fable"
                    |> CmdLine.appendRaw "--watch"
                    |> CmdLine.appendRaw "--sourceMaps"
                    |> CmdLine.toString
                )
            }

            stage "Server" {
                workingDir Folders.Server.AntidoteServer
                run "dotnet watch run"
            }
        }

        runIfOnlySpecified true
    }

pipeline "Server.Tests" {

    Stages.initDocker
    Stages.setupLocalDb

    stage "Run the tests" {
        workingDir Folders.Server.AntidoteServerTests

        whenNot { cmdArg "--watch" }

        run (
            CmdLine.Empty
            |> CmdLine.appendRaw "dotnet"
            |> CmdLine.appendRaw "run -c TEST"
            |> CmdLine.toString
        )

    }

    stage "Run the tests in watch mode" {
        workingDir Folders.Server.AntidoteServerTests

        whenCmdArg "-w" "--watch" "Re-run the tests on changes"

        run (
            CmdLine.Empty
            |> CmdLine.appendRaw "dotnet"
            |> CmdLine.appendRaw "watch"
            |> CmdLine.appendRaw "run -c TEST"
            |> CmdLine.toString
        )
    }

    runIfOnlySpecified true
}

type Env =
    | Prod
    | Staging

let createServerDeployPipeline (env : Env) =
    let expectedBranch =
        match env with
        | Prod -> "main"
        | Staging ->
            "staging"

    let pipelineName =
        match env with
        | Prod -> "Server.Deploy.Prod"
        | Staging -> "Server.Deploy.Staging"

    let envVariablesPrefix =
        match env with
        | Prod -> "PROD"
        | Staging -> "STAGING"

    // Pipeline to deploy the server
    pipeline pipelineName {

        whenAll {
            envVar $"ANTIDOTE_TENANT_CONNECTION_STRING_{envVariablesPrefix}"
            envVar $"ANTIDOTE_SHARD_CONNECTION_STRING_{envVariablesPrefix}"
            envVar $"ANTIDOTE_MEDIO_SERVER_IP_{envVariablesPrefix}"
            envVar "GITHUB_ACTION"
            branch expectedBranch

            // whenAny {
            //     branch "main"
            //     branch "staging"
            // }
        }

        Stages.initDocker
        Stages.setupLocalDb

        stage "Run the tests" {
            workingDir Folders.Server.AntidoteServerTests

            run (
                CmdLine.Empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "run -c TEST"
                |> CmdLine.toString
            )
        }

        stage "Build server" {
            workingDir Folders.Server.AntidoteServer

            run (
                CmdLine.Empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "publish"
                |> CmdLine.appendPrefix "--configuration" "Release"
                |> CmdLine.appendPrefix "--runtime" "linux-x64"
                |> CmdLine.appendPrefix "--self-contained" "true"
                |> CmdLine.appendRaw "/p:PublishSingleFile=true"
                |> CmdLine.toString
            )
        }

        stage "Migrate shard database" {
            runSensitive (fun ctx ->
                let antidoteShardConnectionString = ctx.GetEnvVar $"ANTIDOTE_SHARD_CONNECTION_STRING_{envVariablesPrefix}"

                CmdLine.empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "grate"
                |> CmdLine.appendPrefix "--connectionstring" antidoteShardConnectionString
                |> CmdLine.appendPrefix "--databasetype" "postgresql"
                |> CmdLine.appendPrefix "--folders" "Server/Antidote.Database/Migrations"
                |> CmdLine.appendRaw "--noninteractive"
                |> CmdLine.toString
            )
        }

        stage "Migrate tenant catalog database" {
            runSensitive (fun ctx ->
                let antidoteTenantConnectionString =
                    ctx.GetEnvVar $"ANTIDOTE_TENANT_CONNECTION_STRING_{envVariablesPrefix}"

                CmdLine.empty
                |> CmdLine.appendRaw "dotnet"
                |> CmdLine.appendRaw "grate"
                |> CmdLine.appendPrefix "--connectionstring" antidoteTenantConnectionString
                |> CmdLine.appendPrefix "--databasetype" "postgresql"
                |> CmdLine.appendPrefix "--folders" "Server/Antidote.Database.TenantCatalog/Migrations"
                |> CmdLine.appendRaw "--noninteractive"
                |> CmdLine.toString
            )
        }

        stage "Deploy on remote server" {

            // Stop the running service
            runSensitive (fun ctx ->
                let medioServerIp = ctx.GetEnvVar $"ANTIDOTE_MEDIO_SERVER_IP_{envVariablesPrefix}"

                CmdLine.Empty
                |> CmdLine.appendRaw "ssh"
                |> CmdLine.appendRaw $"deploy@{medioServerIp}"
                |> CmdLine.appendPrefix "-t" "sudo systemctl stop antidote-server.service"
                |> CmdLine.toString
            )

            // Remove old files
            runSensitive (fun ctx ->
                let medioServerIp = ctx.GetEnvVar $"ANTIDOTE_MEDIO_SERVER_IP_{envVariablesPrefix}"

                CmdLine.Empty
                |> CmdLine.appendRaw "ssh"
                |> CmdLine.appendRaw $"deploy@{medioServerIp}"
                |> CmdLine.appendPrefix "-t" "rm -rf /var/www/medio.antidote.rsvp/server"
                |> CmdLine.toString
            )

            // Recreate the destination folder
            runSensitive (fun ctx ->
                let medioServerIp = ctx.GetEnvVar $"ANTIDOTE_MEDIO_SERVER_IP_{envVariablesPrefix}"

                CmdLine.Empty
                |> CmdLine.appendRaw "ssh"
                |> CmdLine.appendRaw $"deploy@{medioServerIp}"
                |> CmdLine.appendPrefix "-t" "mkdir /var/www/medio.antidote.rsvp/server"
                |> CmdLine.toString
            )

            // Send the new files
            runSensitive (fun ctx ->
                let medioServerIp = ctx.GetEnvVar $"ANTIDOTE_MEDIO_SERVER_IP_{envVariablesPrefix}"

                let scpCommand =
                    CmdLine.Empty
                    |> CmdLine.appendRaw "scp"
                    |> CmdLine.appendRaw "-r"
                    |> CmdLine.appendRaw "Server/Antidote.Server/bin/Release/net6.0/linux-x64/publish/*"
                    |> CmdLine.appendRaw $"deploy@{medioServerIp}:/var/www/medio.antidote.rsvp/server"
                    |> CmdLine.toString

                CmdLine.empty
                |> CmdLine.appendRaw "bash"
                |> CmdLine.appendPrefix "-c" scpCommand
                |> CmdLine.toString
            )

            // Start the service
            runSensitive (fun ctx ->
                let medioServerIp = ctx.GetEnvVar $"ANTIDOTE_MEDIO_SERVER_IP_{envVariablesPrefix}"

                CmdLine.Empty
                |> CmdLine.appendRaw "ssh"
                |> CmdLine.appendRaw $"deploy@{medioServerIp}"
                |> CmdLine.appendPrefix "-t" "sudo systemctl start antidote-server.service"
                |> CmdLine.toString
            )
        }

        runIfOnlySpecified
    }

DotEnv.Load(
    DotEnvOptions(
        envFilePaths = [
            ".env.development"
        ]
    )
)

createApplicationPipeline Healix
createApplicationPipeline BehavioralBackup

createServerDeployPipeline Prod
createServerDeployPipeline Staging

tryPrintPipelineCommandHelp ()
