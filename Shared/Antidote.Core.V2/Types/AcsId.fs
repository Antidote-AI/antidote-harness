namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
module AcsId =

    type T = private | AcsId of string

    let create (text: string) = AcsId text

    let value (AcsId password) = password

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "AcsId cannot be empty"

        return AcsId text
    }
