namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type TenantName = | TenantName of string

[<RequireQualifiedAccess>]
module TenantName =

    let create (text: string) = TenantName text

    let value (TenantName tenantName) = tenantName

    let validate (text: string) = result {
        do! Validators.String.isValidTenantDetail text
        return TenantName text
    }
