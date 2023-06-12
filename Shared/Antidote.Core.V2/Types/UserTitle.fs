namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module UserTitle =

    type T = private | UserTitle of string

    let tryParse (text: string) = result {
        do!
            Validators.String.maxLength
                text
                50
                "Title cannot be longer than 50 characters"

        return UserTitle text
    }

    let create (text: string) = UserTitle text

    let toString (UserTitle title) = title
