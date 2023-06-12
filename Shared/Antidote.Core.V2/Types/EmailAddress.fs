namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module EmailAddress =

    type T = private | EmailAddress of string

    let create (text: string) = EmailAddress text

    let toString (EmailAddress email) = email

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "Email address cannot be empty"

        do!
            Validators.String.maxLength
                text
                50
                "Email address cannot be longer than 50 characters"

        do!
            Validators.String.contains
                text
                "@"
                "Email address must contain an @"

        return EmailAddress text
    }
