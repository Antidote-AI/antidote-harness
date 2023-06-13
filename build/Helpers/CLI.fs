module CLI

open Fake.Core
open BlackFox

let createProcess exe arg dir =
    CreateProcess.fromRawCommandLine exe arg
    |> CreateProcess.withWorkingDirectory dir
    |> CreateProcess.ensureExitCode

let run proc arg dir =
    proc arg dir
    |> Proc.run
    |> ignore

let runParallel processes =
    processes
    |> Proc.Parallel.run
    |> ignore

let runOrDefault defTarget args =
    try
        match args with
        | [| target |] -> Target.runOrDefault target
        | _ -> Target.runOrDefault defTarget
        0
    with e ->
        printfn "%A" e
        1

let tool (tool : string) =
    match PathEnvironment.findExecutable tool false with
    | None ->
        failwith $"%s{tool} was not found in path. Please install it and make sure it's available from your path."
    | Some npm ->
        createProcess npm

let npm = tool "npm"

let dotnet = tool "dotnet"

let npx = tool "npx"

let node = tool "node"

let git = tool "git"

// let docker = tool "docker"

let ssh = tool "ssh"

let scp = tool "scp"

let bash = tool "bash"
