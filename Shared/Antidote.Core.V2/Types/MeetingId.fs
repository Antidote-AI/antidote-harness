namespace Antidote.Core.V2.Types

open System
open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module MeetingId =

    type T = private | MeetingId of Guid

    let create (meetingId: Guid) = MeetingId meetingId

    let value (MeetingId meetingId) = meetingId

    let tryParse (meetingIdString: string) = result {
        do! Validators.String.nonEmpty meetingIdString "Meeting ID cannot be empty"
        let! meetingId = Validators.Guid.validFormat meetingIdString "Meeting ID wasn't in a valid format"
        return MeetingId meetingId
    }
