namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type CountryCode = | CountryCode of string

[<RequireQualifiedAccess>]
module CountryCode =

    let create (text: string) = CountryCode text

    let value (CountryCode countryCode) = countryCode

    let validate (text: string) = result {
        do! Validators.String.isCountryCode text
        return CountryCode text
    }
