namespace Antidote.Core.V2.Types

open System
open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module TenantId  =

    type T = private | TenantId of Guid

    let create (tenantId: Guid) = TenantId tenantId

    let value (TenantId tenantId) = tenantId

    let tryParse (tenantIdString: string) = result {
        do! Validators.String.nonEmpty tenantIdString "TenantId cannot be empty"
        let! tenantId = Validators.Guid.validFormat tenantIdString "TenantId wasn't in a valid format"
        return TenantId tenantId
    }
