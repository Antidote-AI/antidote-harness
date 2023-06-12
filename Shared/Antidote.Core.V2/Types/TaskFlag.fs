namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2


[<RequireQualifiedAccess>]
type TaskFlag =
    | Important
    | MyDay


module TaskFlag =
    // type T = private | TaskFlag of TaskFlag

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="taskFlagIndex"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (taskFlagIndex: int) =
        match taskFlagIndex with
        | 0 -> TaskFlag.Important
        | 1 -> TaskFlag.MyDay
        | _ -> failwith $"Invalid TaskFlag index: $%i{taskFlagIndex}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskFlag"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (taskFlag: TaskFlag) =
        match taskFlag with
        | TaskFlag.Important -> 0
        | TaskFlag.MyDay -> 1

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskFlag"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toString (taskFlag: TaskFlag) =
        match taskFlag with
        | TaskFlag.Important -> "Important"
        | TaskFlag.MyDay -> "My Day"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskFlagString"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let fromString (taskFlagString: string) =
        match taskFlagString with
        | "Important" -> TaskFlag.Important
        | "My Day" -> TaskFlag.MyDay
        | _ -> failwith "Invalid Task Flag string"

    let validateIndex (taskFlagIndex: int) =
        match taskFlagIndex with
        | 0
        | 1 ->  true
        | _ -> false

    let validateString (taskFlagString: string) =
        match taskFlagString with
        | "Important"
        | "My Day" -> true
        | _ -> false

    // let value (TaskTag status) = toIndex status

    let tryParseIndex (taskFlagIndex: int) = result {
        do! Validators.Int.isNonNegative taskFlagIndex "Task Flag cannot be negative"
        do!
            match validateIndex taskFlagIndex with
            | false -> Error $"Task Flag index {taskFlagIndex} was invalid."
            | true -> Ok()
        return fromIndex taskFlagIndex
    }

    let tryParseString (taskFlagString: string) = result {
        do! Validators.String.nonEmpty taskFlagString "Task Flag cannot be empty"
        do!
            match validateString taskFlagString with
            | false -> Error $"Task Flag string {taskFlagString} is invalid."
            | true -> Ok()
        return fromString taskFlagString
    }
