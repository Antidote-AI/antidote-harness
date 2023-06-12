namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2


[<RequireQualifiedAccess>]
type TaskStatus =
    | NotStarted
    | InProgress
    | Done

module TaskStatus =

    // type T = private | TaskStatus of TaskStatus

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="taskStatusIndex"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (taskStatusIndex: int) =
        match taskStatusIndex with
        | 0 -> TaskStatus.NotStarted
        | 1 -> TaskStatus.InProgress
        | 2 -> TaskStatus.Done
        | _ -> failwith $"Invalid TaskStatus index: $%i{taskStatusIndex}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskStatus"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (taskStatus: TaskStatus) =
        match taskStatus with
        | TaskStatus.NotStarted -> 0
        | TaskStatus.InProgress -> 1
        | TaskStatus.Done -> 2

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskStatus"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toString (taskStatus: TaskStatus) =
        match taskStatus with
        | TaskStatus.NotStarted -> "Not Started"
        | TaskStatus.InProgress -> "In Progress"
        | TaskStatus.Done -> "Done"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="taskStatusString"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let fromString (taskStatusString: string) =
        match taskStatusString with
        | "Not Started" -> TaskStatus.NotStarted
        | "In Progress" -> TaskStatus.InProgress
        | "Done" -> TaskStatus.Done
        | _ -> failwith "Invalid Task Status string"

    let validateIndex (taskStatusIndex: int) =
        match taskStatusIndex with
        | 0
        | 1
        | 2 ->  true
        | _ -> false

    let validateString (taskStatusString: string) =
        match taskStatusString with
        | "Not Started"
        | "In Progress"
        | "Done" -> true
        | _ -> false

    // let value (TaskStatus status) = toIndex status
    let tryParseIndex (taskStatusIndex: int) = result {
        do! Validators.Int.isNonNegative taskStatusIndex "Task Status cannot be negative"
        do!
            match validateIndex taskStatusIndex with
            | false -> Error $"Task Status index {taskStatusIndex} was invalid."
            | true -> Ok()
        return fromIndex taskStatusIndex
    }

    let tryParseString (taskStatusString: string) = result {
        do! Validators.String.nonEmpty taskStatusString "Task Status cannot be empty"
        do!
            match validateString taskStatusString with
            | false -> Error $"Task Status string {taskStatusString} is invalid."
            | true -> Ok()
        return fromString taskStatusString
    }
