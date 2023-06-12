namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module Biography =

    type T = private | Biography of string

    let create (text: string) = Biography text

    let toString (Biography biography) = biography

    let tryParse (text: string) = result {
        do!
            Validators.String.maxLength
                text
                2048
                "Biography cannot be longer than 2048 characters"

        return Biography text
    }
