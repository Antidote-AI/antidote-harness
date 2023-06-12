namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module FirstName =

    type T = private | FirstName of string

    let create (text: string) = FirstName text

    let toString (FirstName firstName) = firstName

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "First name cannot be empty"

        do!
            Validators.String.maxLength
                text
                256
                "First name cannot be longer than 256 characters"

        return FirstName (text.Trim())
    }
