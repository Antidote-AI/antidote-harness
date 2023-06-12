namespace Antidote.Core.V2.Types.EncounterForm

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
type ClinicianRecommendation =
    | PsychiatricAssessment
    | PossibleDetox
    | InPatientCommitment
    | InsufficientData
    | Other

[<RequireQualifiedAccess>]
module ClinicianRecommendation =

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="index"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (index: int) =
        match index with
        | 0 -> ClinicianRecommendation.PossibleDetox
        | 1 -> ClinicianRecommendation.InsufficientData
        | 3 -> ClinicianRecommendation.InPatientCommitment
        | 2 -> ClinicianRecommendation.PsychiatricAssessment
        | 4 -> ClinicianRecommendation.Other
        | _ -> failwith $"Invalid ClinicianRecommendation index: $%i{index}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="status"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (status: ClinicianRecommendation) =
        match status with
        | ClinicianRecommendation.PossibleDetox -> 0
        | ClinicianRecommendation.InsufficientData -> 1
        | ClinicianRecommendation.InPatientCommitment -> 3
        | ClinicianRecommendation.PsychiatricAssessment -> 2
        | ClinicianRecommendation.Other -> 4
