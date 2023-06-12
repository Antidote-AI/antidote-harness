namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type TenantServerName = | TenantServerName of string

[<RequireQualifiedAccess>]
module TenantServerName =

    let create (text: string) = TenantServerName text

    let value (TenantServerName tenantServerName) = tenantServerName

    let validate (text: string) = result {
        do! Validators.String.isValidTenantDetail text
        return TenantServerName text
    }
