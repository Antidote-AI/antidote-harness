namespace Antidote.Core.V2.Types.EncounterForm

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
type Answer =
    | Yes
    | No
    | InsufficientData

[<RequireQualifiedAccess>]
module Answer =

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="index"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (index: int) =
        match index with
        | 0 -> Answer.Yes
        | 1 -> Answer.No
        | 2 -> Answer.InsufficientData
        | _ -> failwith $"Invalid Answer index: $%i{index}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="status"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (status: Answer) =
        match status with
        | Answer.Yes -> 0
        | Answer.No -> 1
        | Answer.InsufficientData -> 2
