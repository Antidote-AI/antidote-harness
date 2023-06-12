namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module MeetingDetails =

    type T = private | MeetingDetails of string

    let create (meetingDetails: string) = MeetingDetails meetingDetails

    let value (MeetingDetails meetingDetails) = meetingDetails

    let tryParse (meetingDetailsString: string) = result {
        do! Validators.String.nonEmpty meetingDetailsString "Meeting details cannot be empty"

        do!
            Validators.String.maxLength
                meetingDetailsString
                256
                "Meeting details cannot be longer than 256 characters"

        return MeetingDetails meetingDetailsString
    }
