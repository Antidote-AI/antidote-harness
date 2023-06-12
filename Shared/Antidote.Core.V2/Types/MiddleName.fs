namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module MiddleName =

    type T = private | MiddleName of string

    let create (text: string) = MiddleName text

    let toString (MiddleName middleName) = middleName

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "Middle name cannot be empty"

        do!
            Validators.String.maxLength
                text
                128
                "Middle name cannot be longer than 128 characters"

        return MiddleName text
    }
