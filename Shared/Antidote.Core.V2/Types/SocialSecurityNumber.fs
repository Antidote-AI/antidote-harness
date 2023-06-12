namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module SocialSecurityNumber =

    type T = private | SocialSecurityNumber of string

    let create (ssn: string) = SocialSecurityNumber ssn

    let value (SocialSecurityNumber ssn) = ssn

    let tryParse (ssn: string) = result {
        do! Validators.String.nonEmpty ssn "Social Security number cannot be empty"
        do! Validators.String.isSocialSecurityNumber ssn
        return SocialSecurityNumber ssn
    }
