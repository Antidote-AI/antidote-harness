namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
module AcsAccessToken =

    type T = private | AcsAccessToken of string

    let create (token: string) = AcsAccessToken token

    let value (AcsAccessToken token) = token

    let tryParse (tokenString: string) = result {
        do! Validators.String.nonEmpty tokenString "Acs Access Token cannot be empty"
        // Can't validate this by length, I got two differing string lengths: 744 & 751
        // do! Validators.String. tokenString 744 "Acs Access Token must be of the proper length"
        return AcsAccessToken tokenString
    }
