namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module UserSpecialities =

    type T = private | UserSpecialities of string

    let create (text: string) = UserSpecialities text

    let toString (UserSpecialities specialities) = specialities

    let tryParse (text: string) = result {
        do!
            Validators.String.maxLength
                text
                2048
                "Specialities cannot be longer than 2048 characters"

        return UserSpecialities text
    }

    let fromString (value : string) =
        value.Split(",")
        |> Seq.toList
