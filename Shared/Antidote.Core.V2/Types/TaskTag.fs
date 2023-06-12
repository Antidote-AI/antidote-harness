namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
type TaskTag =
    | Normal
    | Primary
    | Warning
    | Info
    | Danger
    | Success



module TaskTag =
    // type T = private | TaskTag of TaskTag

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="taskTagIndex"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (taskTagIndex: int) =
        match taskTagIndex with
        | 0 -> TaskTag.Normal
        | 1 -> TaskTag.Primary
        | 2 -> TaskTag.Warning
        | 3 -> TaskTag.Info
        | 4 -> TaskTag.Danger
        | 5 -> TaskTag.Success
        | _ -> failwith $"Invalid TaskTag index: $%i{taskTagIndex}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskTag"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (taskTag: TaskTag) =
        match taskTag with
        | TaskTag.Normal -> 0
        | TaskTag.Primary -> 1
        | TaskTag.Warning -> 2
        | TaskTag.Info -> 3
        | TaskTag.Danger -> 4
        | TaskTag.Success -> 5

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskTag"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toString (taskTag: TaskTag) =
        match taskTag with
        | TaskTag.Normal -> "Normal"
        | TaskTag.Primary -> "Primary"
        | TaskTag.Warning -> "Warning"
        | TaskTag.Info -> "Info"
        | TaskTag.Danger -> "Danger"
        | TaskTag.Success -> "Success"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskTagString"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let fromString (taskTagString: string) =
        match taskTagString with
        | "Normal" -> TaskTag.Normal
        | "Primary" -> TaskTag.Primary
        | "Warning" -> TaskTag.Warning
        | "Info" -> TaskTag.Info
        | "Danger" -> TaskTag.Danger
        | "Success" -> TaskTag.Success
        | _ -> failwith "Invalid Task Tag string"

    let validateIndex (taskTagIndex: int) =
        match taskTagIndex with
        | 0
        | 1
        | 2
        | 3
        | 4
        | 5 ->  true
        | _ -> false

    let validateString (taskTagString: string) =
        match taskTagString with
        | "Normal"
        | "Primary"
        | "Warning"
        | "Info"
        | "Danger"
        | "Success" -> true
        | _ -> false

    // let value (TaskTag status) = toIndex status

    let tryParseIndex (taskTagIndex: int) = result {
        do! Validators.Int.isNonNegative taskTagIndex "Task Tag cannot be negative"
        do!
            match validateIndex taskTagIndex with
            | false -> Error $"Task Tag index {taskTagIndex} was invalid."
            | true -> Ok()
        return fromIndex taskTagIndex
    }

    let tryParseString (taskTagString: string) = result {
        do! Validators.String.nonEmpty taskTagString "Task Tag cannot be empty"
        do!
            match validateString taskTagString with
            | false -> Error $"Task Tag string {taskTagString} is invalid."
            | true -> Ok()
        return fromString taskTagString
    }
