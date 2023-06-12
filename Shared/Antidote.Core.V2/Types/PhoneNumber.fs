namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module PhoneNumber =

    type T = private | PhoneNumber of string

    let create (text: string) = PhoneNumber text

    let toString (PhoneNumber phoneNumber) = phoneNumber

    let tryParse (text: string) = result {
        let phone = Normalizers.String.toPhoneFormat text
        do! Validators.String.nonEmpty text "Phone number cannot be empty"
        do! Validators.String.isValidUSPhoneNumber text

        return PhoneNumber text
    }
