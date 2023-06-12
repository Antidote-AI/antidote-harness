namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2


[<RequireQualifiedAccess>]
type SystemEvent =
    | Timed
    | Assessment
    | Manual

module SystemEvent =
    // type T = private | SystemEvent of SystemEvent

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="index"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (index: int) =
        match index with
        | 0 -> SystemEvent.Timed
        | 1 -> SystemEvent.Assessment
        | 2 -> SystemEvent.Manual
        | _ -> failwith $"Invalid System Event index: $%i{index}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="systemEvent"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (systemEvent: SystemEvent) =
        match systemEvent with
        | SystemEvent.Timed -> 0
        | SystemEvent.Assessment -> 1
        | SystemEvent.Manual -> 2

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="systemEvent"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toString (systemEvent: SystemEvent) =
        match systemEvent with
        | SystemEvent.Timed -> "Timed"
        | SystemEvent.Assessment -> "Assessment"
        | SystemEvent.Manual -> "Manual"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="systemEventString"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let fromString (systemEventString: string) =
        match systemEventString with
        | "Timed" -> SystemEvent.Timed
        | "Assessment" -> SystemEvent.Assessment
        | "Manual" -> SystemEvent.Manual
        | _ -> failwith "Invalid System Event string"

    let validateIndex (systemEventIndex: int) =
        match systemEventIndex with
        | 0
        | 1
        | 2 ->  true
        | _ -> false

    let validateString (systemEventString: string) =
        match systemEventString with
        | "Timed"
        | "Assessment"
        | "Manual" -> true
        | _ -> false

    // let value (SystemEvent status) = toIndex status

    let tryParseIndex (systemEventIndex: int) = result {
        do! Validators.Int.isNonNegative systemEventIndex "System Event index cannot be negative"
        do!
            match validateIndex systemEventIndex with
            | false -> Error $"System Event index {systemEventIndex} was invalid."
            | true -> Ok()
        return fromIndex systemEventIndex
    }

    let tryParseString (systemEventString: string) = result {
        do! Validators.String.nonEmpty systemEventString "System Event cannot be empty"
        do!
            match validateString systemEventString with
            | false -> Error $"System Event string {systemEventString} is invalid."
            | true -> Ok()
        return fromString systemEventString
    }
