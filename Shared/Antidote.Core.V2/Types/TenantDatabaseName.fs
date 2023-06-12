namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type TenantDatabaseName = | TenantDatabaseName of string

[<RequireQualifiedAccess>]
module TenantDatabaseName =

    let create (text: string) = TenantDatabaseName text

    let value (TenantDatabaseName databaseName) = databaseName

    let validate (text: string) = result {
        do! Validators.String.isValidTenantDetail text
        return TenantDatabaseName text
    }
