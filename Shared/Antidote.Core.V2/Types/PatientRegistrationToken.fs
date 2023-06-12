namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
module PatientRegistrationToken =
    type PatientRegistrationToken = private | PatientRegistrationToken of string

    let create (token: string) = PatientRegistrationToken token

    let value (PatientRegistrationToken token) = token

    let validate (token: string) = result {
        do! Validators.String.nonEmpty token "Token cannot be empty"
        return PatientRegistrationToken token
    }
