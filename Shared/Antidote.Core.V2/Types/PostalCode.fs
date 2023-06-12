namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type PostalCode = | PostalCode of string

[<RequireQualifiedAccess>]
module PostalCode =

    let create (text: string) = PostalCode text

    let value (PostalCode postalCode) = postalCode

    let validate (text: string) = result {
        do! Validators.String.isPostalCode text
        return PostalCode text
    }
