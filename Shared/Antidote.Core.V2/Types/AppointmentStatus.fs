namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
type AppointmentStatus =
    | Unconfirmed
    | Rescheduled
    | Confirmed
    | Cancelled
    | CheckedIn
    | Completed
    | Left_Message
    | In_Progress
    | CheckedOut

module AppointmentStatus =

    type T = private | AppointmentStatus of AppointmentStatus

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="index"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (index: int) =
        match index with
        | 0 -> AppointmentStatus.Unconfirmed
        | 1 -> AppointmentStatus.Rescheduled
        | 2 -> AppointmentStatus.Confirmed
        | 3 -> AppointmentStatus.Cancelled
        | 4 -> AppointmentStatus.CheckedIn
        | 5 -> AppointmentStatus.Completed
        | 6 -> AppointmentStatus.Left_Message
        | 7 -> AppointmentStatus.In_Progress
        | 8 -> AppointmentStatus.CheckedOut
        | _ -> failwith $"Invalid AppointmentStatus index: $%i{index}"

    let fromString (status: string) =
        match status with
        | "Unconfirmed" -> AppointmentStatus.Unconfirmed
        | "Rescheduled" -> AppointmentStatus.Rescheduled
        | "Confirmed" -> AppointmentStatus.Confirmed
        | "Cancelled" -> AppointmentStatus.Cancelled
        | "Checked In" -> AppointmentStatus.CheckedIn
        | "Completed" -> AppointmentStatus.Completed
        | "Left Message" -> AppointmentStatus.Left_Message
        | "In Progress" -> AppointmentStatus.In_Progress
        | "Checked Out" -> AppointmentStatus.CheckedOut
        | _ -> failwith $"Invalid AppointmentStatus index: $%s{status}"

    let validateIndex (index: int) =
        match index with
        | 0
        | 1
        | 2
        | 3
        | 4
        | 5
        | 6
        | 7
        | 8 ->  true
        | _ -> false

    let validateString (status: string) =
        match status with
        | "Unconfirmed"
        | "Rescheduled"
        | "Confirmed"
        | "Cancelled"
        | "Checked In"
        | "Completed"
        | "Left Message"
        | "In Progress"
        | "Checked Out" ->  true
        | _ -> false

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="status"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (status: AppointmentStatus) =
        match status with
        | AppointmentStatus.Unconfirmed -> 0
        | AppointmentStatus.Rescheduled -> 1
        | AppointmentStatus.Confirmed -> 2
        | AppointmentStatus.Cancelled -> 3
        | AppointmentStatus.CheckedIn -> 4
        | AppointmentStatus.Completed -> 5
        | AppointmentStatus.Left_Message -> 6
        | AppointmentStatus.In_Progress -> 7
        | AppointmentStatus.CheckedOut -> 8

    let createFromString (text: string) = fromString text
    let createFromInt (id: int) = fromIndex id

    let value (AppointmentStatus status) = toIndex status

    let tryParse (index: int) = result {
        do! Validators.Int.isNonNegative index "Appointment Status cannot be negative"
        do!
            match validateIndex index with
            | false -> Error ""
            | true -> Ok()

        return fromIndex index
    }
