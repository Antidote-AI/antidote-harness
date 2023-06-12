namespace Antidote.Core.V2.Types

open System
#if FABLE_COMPILER
open Thoth.Json
#else
open Thoth.Json.Net
#endif

type AccessToken = private | AccessToken of string

type AccessTokenPayload =
    {
        AccountId : Guid
        TenantId : Guid
        Capabilities : Capability.ResourceCapability list
        Permission : string // depricate once caps are fully implemented with roles
        IssuedAt : DateTimeOffset
        ExpirationTime : DateTimeOffset
    }

type AccessTokenProps =
    {
        AccountId : Guid
        TenantId : Guid
        Permission : string
        Capabilities : Capability.ResourceCapability list
    }

[<RequireQualifiedAccess>]
module AccessToken =

    #if !FABLE_COMPILER
    let create (props : AccessTokenProps)  =
        let algorithm = Jose.JwsAlgorithm.HS256
        // TODO: Use configuration
        let key = "super_secure_key"

        let issuedAt = DateTimeOffset.Now
        let expirationTime = issuedAt.AddMinutes(10.0)
        // let expirationTime = issuedAt.AddSeconds(5.0)

        let payload = {
            AccountId = props.AccountId
            TenantId = props.TenantId
            Permission = props.Permission
            Capabilities = props.Capabilities
            ExpirationTime = expirationTime
            IssuedAt = issuedAt
        }

        let payloadText = Encode.Auto.toString(0, payload)

        let token = Jose.JWT.Encode(payloadText, System.Text.Encoding.ASCII.GetBytes(key), algorithm)
        AccessToken token

    let decode (token : string) =
        let algorithm = Jose.JwsAlgorithm.HS256
        let key = "super_secure_key"

        let payloadText = Jose.JWT.Decode(token, System.Text.Encoding.ASCII.GetBytes(key), algorithm)
        payloadText
        |> Decode.Auto.unsafeFromString<AccessTokenPayload>
    #endif

    let value (AccessToken value) = value

    let getPayload (AccessToken value) : AccessTokenPayload =
        value.Split('.').[1]
        |> Base64.decode
        |> Decode.Auto.unsafeFromString<AccessTokenPayload>

    // Client Side Helpers

    let getClientTokenPermission (token: AccessToken option) : string  =
        match token with
        | Some accessToken ->
            getPayload accessToken
            |> fun x -> x.Permission
        | _ -> "none"

    let getClientTokenTenantId (token: AccessToken option) : Guid =
        match token with
        | Some accessToken ->
            getPayload accessToken
            |> fun x -> x.TenantId
        | _ -> Guid.Empty

    let clientTokenHasRequestedPermission (requestedPermission: string) (userPermission: string) =
        requestedPermission = userPermission

    let clientTokenHasValidTenantId (tenantId: Guid) =
        tenantId <> Guid.Empty
