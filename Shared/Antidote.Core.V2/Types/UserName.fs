namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type UserName = private UserName of string

[<RequireQualifiedAccess>]
module UserName =

    let create (text: string) = UserName text

    let value (UserName userName) = userName

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "User name cannot be empty"

        do!
            Validators.String.maxLength
                text
                256
                "User name cannot be longer than 256 characters"

        return UserName text
    }
