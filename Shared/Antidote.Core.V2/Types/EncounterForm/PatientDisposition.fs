namespace Antidote.Core.V2.Types.EncounterForm

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
type PatientDisposition =
    | Other
    | MentalHealth
    | SubstanceAbuse
    | Homelessness
    | InsufficientData

[<RequireQualifiedAccess>]
module PatientDisposition =

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="index"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (index: int) =
        match index with
        | 0 -> PatientDisposition.InsufficientData
        | 1 -> PatientDisposition.Other
        | 2 -> PatientDisposition.Homelessness
        | 3 -> PatientDisposition.SubstanceAbuse
        | 4 -> PatientDisposition.MentalHealth
        | _ -> failwith $"Invalid EncounterFormAnswer index: $%i{index}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="status"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (status: PatientDisposition) =
        match status with
        | PatientDisposition.InsufficientData -> 0
        | PatientDisposition.Other -> 1
        | PatientDisposition.Homelessness -> 2
        | PatientDisposition.SubstanceAbuse -> 3
        | PatientDisposition.MentalHealth -> 4
