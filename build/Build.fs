open Fake.Core
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open BlackFox.Fake
open CLI
open System
open BlackFox.CommandLine
open System.IO
open System.Data
open Npgsql
open dotenv.net
open System.Text.RegularExpressions

let cwd = Environment.CurrentDirectory

let HEALIX_CHANGELOG_FILE = Path.Combine(cwd, "CHANGELOG_HEALIX.md")
Log.info $"CHANGELOG_HEALIX.md FILE:... {HEALIX_CHANGELOG_FILE}"

let HEALIX_PRELUDE_FILE = cwd </> "Healix/src/Prelude.fs"
Log.info $"Predule.fs FILE:... {HEALIX_PRELUDE_FILE}"

type Application =
    | Harness

module Application =

    let getFolderName (application: Application) =
        match application with
        | Harness -> "Healix"

    let getIosFolderName (application: Application) =
        // match application with
        // | BehavioralBackup -> "webapp-abb"
        // | Healix -> "webapp-hlx"
        "public"

    let getPrefix (application: Application) =
        match application with
        | Harness -> "hrns"

module Changelog =

    let versionRegex = Regex("^## ?\\[?v?([\\w\\d.-]+\\.[\\w\\d.-]+[a-zA-Z0-9])\\]?", RegexOptions.IgnoreCase)

    let getLastVersion (changelogFile: string) =
        File.ReadLines(changelogFile)
            |> Seq.tryPick (fun line ->
                let m = versionRegex.Match(line)
                if m.Success then Some m else None)
            |> function
                | None -> failwith "Couldn't find version in changelog file"
                | Some m ->
                    m.Groups.[1].Value

    let isPreRelease (version : string) =
        let regex = Regex(".*(alpha|beta|rc).*", RegexOptions.IgnoreCase)
        regex.IsMatch(version)

    let getNotes (changelogFile:string) (version : string) =
        File.ReadLines(changelogFile)
        |> Seq.skipWhile(fun line ->
            let m = versionRegex.Match(line)

            if m.Success then
                (m.Groups.[1].Value <> version)
            else
                true
        )
        // Remove the version line
        |> Seq.skip 1
        // Take all until the next version line
        |> Seq.takeWhile (fun line ->
            let m = versionRegex.Match(line)
            not m.Success
        )
module Tasks =

    let listTasks = lazy BuildTask.create "listTasks" [] { BuildTask.listAvailable () }

    let updatePreludeHealixVersion =
        lazy
            BuildTask.create "updatePreludeHealixVersion" [] {
                let newVersion = Changelog.getLastVersion(HEALIX_CHANGELOG_FILE)
                Log.info $"Changelog version: {newVersion}"
                let reg = Regex(@"let \[<Literal>\] APP_VERSION = ""(.*)""")
                let newLines =
                    HEALIX_PRELUDE_FILE
                    |> File.ReadLines
                    |> Seq.map (fun line ->
                        reg.Replace(line, fun m ->
                            let previousVersion = m.Groups.[1].Value
                            if previousVersion = newVersion then
                                failwith "You need to update the version in the CHANGELOG.md before publishing a new version of the REPL"
                            else
                                m.Groups.[0].Value.Replace(m.Groups.[1].Value, newVersion)
                        )
                    )
                    |> Seq.toArray

                File.WriteAllLines(HEALIX_PRELUDE_FILE, newLines)
            }

    /// <summary>
    /// Install the NPM dependencies
    /// Notes: The function is lazy because we need to wait for FAKE context to be available
    /// </summary>
    let npmInstall =
        lazy
            BuildTask.create "npmInstall" [] {
                Log.info "NPM Install Dependencies..."
                run npm "install" cwd
                // Log.info "NPM Patch..."

                // Shell.cp
                //     "./npm_override/AddPeopleButton.js"
                //     "./node_modules/@azure/communication-react/dist/dist-esm/react-composites/src/composites/common/AddPeopleButton.js"
            }

    /// <summary>
    /// Client the artifact in the client directory.
    /// </summary>
    let private clean (application: Application) =
        let clientDir = Application.getFolderName application
        let srcDir = clientDir </> "src"

        [
            srcDir </> "bin"
            srcDir </> "obj"
            clientDir </> "dist"
        ]
        |> Shell.cleanDirs

        !!(Glob.fableJs srcDir)
        ++ (Glob.fableJsMap srcDir)
        ++ (srcDir </> "CssModules.fs")
        ++ "Shared/Antidote.React/CssModules.fs"
        ++ "Shared/Fable.Form.Antidote.View/CssModules.fs"
        |> Seq.iter Shell.rm

    /// <summary>
    /// Generate the nodemon command for watching the CSS modules and regenerating the bindings
    /// </summary>
    let private nodemonFcmCmd = "nodemon -e module.scss --exec \"fcm\""

    /// <summary>
    /// Start all the process needed to run the client.
    ///
    /// - Vite serving the JavaScript files
    /// - Fable for compiling the client code
    /// - CSS module code generation in the different directories
    /// </summary>
    let private watch (application: Application) (env: string) =
        let clientDir = Application.getFolderName application
        let srcDir = clientDir </> "src"

        // All for graceful shutdown on Ctrl+C while the processes are running
        Console.CancelKeyPress.AddHandler(fun _ ea ->
            ea.Cancel <- true
            printfn "Received Ctrl+C, shutting down..."
            Environment.Exit(0)
        )

        // Make sure that the CssModules files are ready when Fable is starting
        // There was some issues of having one of the file not here yet probably
        // because of parallel compilation and delay probably
        run npx "fcm" srcDir

        // let fableCommand = "fable", dotnet $"fable --watch --sourceMaps -c %s{env}" srcDir
        let fableCommand =
            if env = "ANTIDOTE_ENV_LOCAL" then
                "fable", dotnet $"fable --watch --sourceMaps " srcDir
            else
                "fable", dotnet $"fable --watch --sourceMaps -c %s{env}" srcDir

        printfn $"Fable Command: {fableCommand}"

        [
            "vite", npx "vite dev" clientDir
            fableCommand
            // Watch the client CSS module, to regenerate the CssModules binding
            "css-code-gen-client", npx nodemonFcmCmd srcDir
        ]
        |> runParallel

    /// <summary>
    /// Build the project in the provided directory.
    /// </summary>
    let private build (application: Application) =
        let clientDir = Application.getFolderName application
        let srcDir = clientDir </> "src"

        run npx "fcm" srcDir
        run dotnet "fable src" clientDir
        run npx "vite build --emptyOutDir" clientDir

    /// <summary>
    /// Generate the set of tasks for the provided application.
    /// </summary>
    let generateClientTasks (application: Application) =
        let prefix = Application.getPrefix application

        let clean = BuildTask.create $"%s{prefix}Clean" [] { clean application }

        let watchTask parameter =
            //Simple arg parser to find --env
            let rec tryFindEnv (args: string list) =
                match args with
                | [ "--env"; env ] -> Some env
                | _ :: tail -> tryFindEnv tail
                | [] -> None

            let env =
                parameter.Context.Arguments
                |> tryFindEnv
                |> Option.defaultValue "ANTIDOTE_ENV_LOCAL"

            match env with
            | "ANTIDOTE_ENV_PRODUCTION"
            | "ANTIDOTE_ENV_STAGING"
            | "ANTIDOTE_ENV_LOCAL" -> watch application env
            | _ -> failwith $"Unknown environment %s{env}, please use ANTIDOTE_ENV_<ENVIRONMENT>"

        let _watch =
            BuildTask.createFn
                $"%s{prefix}Watch"
                [
                    npmInstall.Value
                    clean
                ]
                watchTask

        let build =
            BuildTask.create $"%s{prefix}Build" [
                npmInstall.Value
                clean
            ] {
                build application
            }

        ()

[<EntryPoint>]
let main args =
    DotEnv.Load(
        DotEnvOptions(
            envFilePaths = [
                ".env.development"
            ]
        )
    )

    BuildTask.setupContextFromArgv args

    Tasks.listTasks.Force() |> ignore
    Tasks.updatePreludeHealixVersion.Force() |> ignore

    // Harness tasks
    Tasks.generateClientTasks Harness

    BuildTask.runOrDefaultWithArguments Tasks.listTasks.Value

    0
