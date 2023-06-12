namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module ProfileAvatar =

    type T = private | ProfileAvatar of string

    let create (text: string) = ProfileAvatar text

    let toString (ProfileAvatar avatar) = avatar

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "Profile avatar cannot be empty"

        do!
            Validators.String.maxLength
                text
                127
                "Profile avatar cannot be longer than 127 characters"

        return ProfileAvatar text
    }
