namespace Antidote.Core.V2.Types

open System
open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module MeetingDate =

    type T = private | MeetingDate of DateTimeOffset

    let create (meetingDate: DateTimeOffset) = MeetingDate meetingDate
    let value (MeetingDate meetingDate) = meetingDate

    let tryParse (meetingDateString: string) = result {
        do! Validators.String.nonEmpty meetingDateString "Meeting date cannot be empty"
        let! date = Validators.DateTimeOffset.validFormat meetingDateString "Invalid date format"
        do! Validators.DateTimeOffset.dateNotInPast
                (date)
                "Appointment must be in the future"

        return MeetingDate (DateTimeOffset.Parse (meetingDateString))
    }

    let validate (MeetingDate meetingDate) =
        tryParse (meetingDate.ToString("O"))
