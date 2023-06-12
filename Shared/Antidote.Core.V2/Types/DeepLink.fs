namespace Antidote.Core.V2.Types

open System
open FsToolkit.ErrorHandling
open Antidote.Core.V2

type TeleHealthAppointmentLink =
    {
        DisplayName: string // FullName.T
        AcsId: string // AcsId.T
        AcsToken: string // AcsAccessToken.T
        RoomId: string // Guid
        ChatThreadId: string
    }

type SelfReportedFormLink = {
    PatientId: AccountId.T
    ProviderId: AccountId.T
    AppointmentReferenceId: string
    FormSpecId: Guid
}

type DeepLinkType =
    | SelfReportedFormLink of SelfReportedFormLink
    | TeleHealthAppointmentLink of TeleHealthAppointmentLink
