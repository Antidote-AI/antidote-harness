namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module LastName =

    type T = private | LastName of string

    let create (text: string) = LastName text

    let toString (LastName lastName) = lastName

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "Last name cannot be empty"

        do!
            Validators.String.maxLength
                text
                256
                "Last name cannot be longer than 256 characters"

        return LastName (text.Trim())
    }
