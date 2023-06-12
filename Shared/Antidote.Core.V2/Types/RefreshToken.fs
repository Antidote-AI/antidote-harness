namespace Antidote.Core.V2.Types

open System
#if FABLE_COMPILER
open Thoth.Json
#else
open Thoth.Json.Net
#endif

type RefreshToken = private | RefreshToken of string

[<RequireQualifiedAccess>]
module RefreshToken =

    let value (RefreshToken value) = value

    let create value = RefreshToken value

    // The following code is only for the Server
#if !FABLE_COMPILER
    open System.Security.Cryptography
    open System

    let generateToken () =
        64 |> RandomNumberGenerator.GetBytes |> Convert.ToBase64String |> RefreshToken

    let toSha512 (RefreshToken value) =
        let bytes = Convert.FromBase64String value
        let hash = SHA512.Create().ComputeHash bytes
        Convert.ToBase64String hash
#endif
