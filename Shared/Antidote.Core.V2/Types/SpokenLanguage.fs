namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type SpokenLanguage =
    | English
    | Spanish
    | Unspecified
    | French

[<RequireQualifiedAccess>]
module SpokenLanguage =

    let fromIndex (index: int) =
        match index with
        | 0 -> English
        | 1 -> Spanish
        | 2 -> Unspecified
        | 3 -> French
        | _ -> failwith "Invalid value for SpokenLanguage type"

    let toIndex (spokenLanguage: SpokenLanguage) =
        match spokenLanguage with
        | English -> 0
        | Spanish -> 1
        | Unspecified -> 2
        | French -> 3

    let toNameOf (spokenLanguage: SpokenLanguage) =
        match spokenLanguage with
        | English -> nameof(English)
        | Spanish -> nameof(Spanish)
        | Unspecified -> nameof(Unspecified)
        | French -> nameof(French)

    let tryParse (s: string) =
        match System.Int32.TryParse s with
        | true, index ->
            match index with
            | -1 -> Error "This field is required"
            | 0 -> Ok English
            | 1 -> Ok Spanish
            | 2 -> Ok Unspecified
            | 3 -> Ok French
            | _ -> Error "Invalid value for the SpokenLanguage type"
        | false, _ -> Error "SpokenLanguage type must be an integer"
