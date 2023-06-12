namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module InternationalPhoneNumber =

    type T = private | InternationalPhoneNumber of string

    let create (text: string) = InternationalPhoneNumber text

    let value (InternationalPhoneNumber phoneNumber) = phoneNumber

    // let fromValidPhoneNumber phoneNumber =
    //     phoneNumber
    //     |> Types.PhoneNumber.toString
    //     |> Normalizers.String.toInternationalPhoneFormat
    //     |> InternationalPhoneNumber

    let tryParse (text: string) = result {

        do! Validators.String.nonEmpty text "International Phone number cannot be empty"
        do! Validators.String.startsWith text "+1" "USA International Phone number must begin with +1"
        // do! Validators.String.isValidUSMobilePhoneNumber text

        return InternationalPhoneNumber text

    }
