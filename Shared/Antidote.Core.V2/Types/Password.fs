namespace Antidote.Core.V2.Types

[<RequireQualifiedAccess>]
module Password =

    type T = private | Password of string

    let create (text: string) = Password text

    let toString (Password password) = password

    let tryParse (text: string) =
        if text.Length < 4 then
            Error "The password must have at least 4 characters"
        else
            Ok(Password text)

module PasswordVerify =

    type T = private | PasswordVerify of string

    let create (text: string) = PasswordVerify text

    let toString (PasswordVerify password) = password

    let tryParse (passwordVerify: string) (password: string)=
        if passwordVerify <> password then
            Error "The passwords must match"
        else
            Ok(PasswordVerify passwordVerify)
