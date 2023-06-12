namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
module PasswordResetToken =

    type T = private | PasswordResetToken of string

    let create (token: string) = PasswordResetToken token

    let value (PasswordResetToken token) = token

    let tryParse (tokenString: string) = result {
        do! Validators.String.nonEmpty tokenString "Password Reset Token cannot be empty"
        do! Validators.String.startsWith tokenString "zWUsvNgpweBaKIqEb~" "Password Reset Token missing hash prefix"
        return PasswordResetToken tokenString
    }
