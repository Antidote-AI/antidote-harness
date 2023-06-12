namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type CallImprovementTypes =
    | AppErrors
    | AudioQuality
    | CallControls
    | CallStability
    | ClinicianAvailability
    | ClinicianQuality
    | LoadingTimes
    | NextSteps
    | QrCodeControls
    | VideoQuality
    | WaitTime

[<RequireQualifiedAccess>]
module CallImprovementTypes =

    let fromIndex (index: int)  =
        match index with
        | 0 -> CallImprovementTypes.AppErrors
        | 1 -> CallImprovementTypes.AudioQuality
        | 2 -> CallImprovementTypes.CallControls
        | 3 -> CallImprovementTypes.CallStability
        | 4 -> CallImprovementTypes.ClinicianAvailability
        | 5 -> CallImprovementTypes.ClinicianQuality
        | 6 -> CallImprovementTypes.LoadingTimes
        | 7 -> CallImprovementTypes.NextSteps
        | 8 -> CallImprovementTypes.QrCodeControls
        | 9 -> CallImprovementTypes.VideoQuality
        | 10 -> CallImprovementTypes.WaitTime
        | _ -> failwith "Invalid CallImprovementTypes index"

    let toIndex (callImprovementType: CallImprovementTypes) =
        match callImprovementType with
        | CallImprovementTypes.AppErrors -> 0
        | CallImprovementTypes.AudioQuality -> 1
        | CallImprovementTypes.CallControls -> 2
        | CallImprovementTypes.CallStability -> 3
        | CallImprovementTypes.ClinicianAvailability -> 4
        | CallImprovementTypes.ClinicianQuality -> 5
        | CallImprovementTypes.LoadingTimes -> 6
        | CallImprovementTypes.NextSteps -> 7
        | CallImprovementTypes.QrCodeControls -> 8
        | CallImprovementTypes.VideoQuality -> 9
        | CallImprovementTypes.WaitTime -> 10

    let fromKey (key: string) =
        match key with
        | "Audio Quality" -> CallImprovementTypes.AudioQuality
        | "Call Stability" -> CallImprovementTypes.CallStability
        | "Call Controls" -> CallImprovementTypes.CallControls
        | "clinician_quality" -> CallImprovementTypes.ClinicianQuality
        | "Clinician Availability" -> CallImprovementTypes.ClinicianAvailability
        | "Loading Times"-> CallImprovementTypes.LoadingTimes
        | "Next Steps" -> CallImprovementTypes.NextSteps
        | "QR Code Controls" -> CallImprovementTypes.QrCodeControls
        | "Video Quality" -> CallImprovementTypes.VideoQuality
        | "Wait Time" -> CallImprovementTypes.WaitTime
        | "App Errors"
        | _ -> CallImprovementTypes.AppErrors

    let toString (callImprovementType: CallImprovementTypes) =
        match callImprovementType with
        | CallImprovementTypes.AppErrors -> "App Errors"
        | CallImprovementTypes.AudioQuality -> "Audio Quality"
        | CallImprovementTypes.CallControls -> "Call Controls"
        | CallImprovementTypes.CallStability -> "Call Stability"
        | CallImprovementTypes.ClinicianAvailability -> "Clinician Availability"
        | CallImprovementTypes.ClinicianQuality -> "Clinician Quality"
        | CallImprovementTypes.LoadingTimes -> "Loading Times"
        | CallImprovementTypes.NextSteps -> "Next Steps"
        | CallImprovementTypes.QrCodeControls -> "QR Code Controls"
        | CallImprovementTypes.VideoQuality -> "Video Quality"
        | CallImprovementTypes.WaitTime -> "Wait Time"
