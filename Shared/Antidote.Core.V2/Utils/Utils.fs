module Antidote.Core.V2.Utils

open System.Threading
open Browser
open System
open System.Collections.Generic
open Fable.I18Next
open Fable.Core.JsInterop



module JS =
    open Fable.Core.JS

    let red = "background:#7e0202;color:white;font-size:12px"
    let note = "background:#2e2e2e;color:greenyellow;font-size:12px"
    let warn = "background:#736105;color:#f4bd1f;font-size:12px"
    let sourceOfLog = "[antidote]"

    let warnlog msg =
        let msg = $"🟡 {sourceOfLog} {msg}"
        console.warn ("%c" + msg, warn)

    let debuglog msg =
        let msg = $"🟢 {sourceOfLog} {msg}"
        console.log ("%c" + msg, note)

    let errorlog msg =
        let msg = $"🔴 {sourceOfLog} {msg}"
        console.error ("%c" + msg, red)

    // Uncomment this for production... because preprocessor conditions are a bit of a pain to commment/uncomment for ios debugging locally
    // let warnlog msg = ()
    // let debuglog msg = ()
    // let errorlog msg = ()


    let scrollElementByIdIntoView (elementId: string) =
        let elem = document.getElementById(elementId)
        if elem = null then () else elem.scrollIntoView()


/// These utils are included by default in every project, as part of the path
/// Be careful with adding to this. Only do so if you have a VERY good reason.
[<AutoOpen>]
module AutoUtils =

    /// Do nothing, for the provided reason
    /// This is helpful for cases where we don't need to handle a value
    let pass reason = ignore reason

    /// type extension for regular arrays
    type 'a ``[]`` with
        /// Retrieves the last item in the array.
        /// Throws an exception if this array is empty.
        member x.Last = x.[x.Length - 1]

    // type extension for ResizeArrays
    type System.Collections.Generic.List<'a> with
        /// Retrieves the last item in the list. O(1). Equivalent to: x.[x.Count - 1]
        member x.Last = x.[x.Count - 1]


    type System.Collections.Generic.IDictionary<'k, 'v> with

        /// Retrieves a value for a key as an option.
        member x.GetOpt(key) =
            match x.TryGetValue(key) with
            | true, v -> Some v
            | _ -> None

    /// raises a not yet implemented exception with the specified message.
    let inline nyi msg = raise <| NotImplementedException(msg)


module Dictionary =

    /// Creates a dictionary of the sequence.
    /// If duplicate keys are encountered, the last value paired with that key is used.
    let ofSeq (sequence:('Key * 'Value) seq) =
        let d = Dictionary<'Key,'Value>()
        for k,v in sequence do
            d.[k] <- v
        d

module Guid =
    let TryParseOption (s:string) =
        match Guid.TryParse s with
        | true, v -> Some v
        | false, _ -> None


module Result =
    let getOrFail (r:Result<'a, 'err>) =
        match r with
        | Ok r -> r
        | Error e -> string e |> failwith


module Security =
    #if !FABLE_COMPILER
    /// Returns a new function that can only be run ONCE.
    /// This is thread safe.
    let runOnceOnly func =
        let mutable fetchCount = 0
        fun fp ->
            if Interlocked.Increment(&fetchCount) > 1 then
                eprintfn "Capabilities were requested more than once."
                eprintfn "You are doing it wrong, and this should never happen."
                raise <| InvalidOperationException("This function can only be run once.")
            func fp
    #endif

    let randomString length =
        let VALID_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"

        [1..length]
        |> Seq.fold (fun acc a ->
            let rnd = System.Random().Next(0, VALID_CHARS.Length)
            acc + string VALID_CHARS.[rnd]
        ) ""


module Transformers =
    module Date =
        let toAge (date: System.DateOnly) =
            // FRAGILE
            let dob : DateTime =  DateTime.Parse (date.ToString())
            // Get the current date
            let today = System.DateTime.Today
            // Subtract the date from the current date
            let diff = today - dob
            // Check if the difference is negative
            if diff < System.TimeSpan.Zero then
                // Throw an exception for invalid date
                failwith ""
            else
                // Convert the difference to years
                diff.Days / 365

// module ElmishUtils =

//     open Elmish

//     module Cmd =
//         let fromAsync (operation: Async<'msg>) : Cmd<'msg> =
//             let delayedCmd (dispatch: 'msg -> unit) : unit =
//                 let delayedDispatch =
//                     async {
//                         let! msg = operation
//                         dispatch msg
//                     }

//                 Async.StartImmediate delayedDispatch

//             Cmd.ofSub delayedCmd

//         type AsyncOperationStatus<'t> =
//             | Started
//             | Finished of 't

//         let withAdditionalCmd cmd (model, cmds) = model, (Cmd.batch [ cmds; cmd ])

//         let withCmd (cmds: Cmd<'a>) model = model, cmds

//         let withoutCmds model = model, Cmd.none
