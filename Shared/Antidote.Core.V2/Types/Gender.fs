namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

// type ClinicanAccountId = ClinicanAccountId of System.Guid

type Gender =
    | Male
    | Female
    | Unspecified

[<RequireQualifiedAccess>]
module Gender =

    let fromIndex (index: int) =
        match index with
        | 0 -> Male
        | 1 -> Female
        | 2 -> Unspecified
        | _ -> failwith "Invalid value for Gender type"

    let toIndex (gender: Gender) =
        match gender with
        | Male -> 0
        | Female -> 1
        | Unspecified -> 2

    let toNameOf (gender: Gender) =
        match gender with
        | Male -> nameof(Male)
        | Female -> nameof(Female)
        | Unspecified -> nameof(Unspecified)

    let tryParse (s: string) =
        match System.Int32.TryParse s with
        | true, index ->
            match index with
            | -1 -> Error "This field is required"
            | 0 -> Ok Male
            | 1 -> Ok Female
            | 2 -> Ok Unspecified
            | _ -> Error "Invalid value for the Gender type"
        | false, _ -> Error "Gender type must be an integer"
