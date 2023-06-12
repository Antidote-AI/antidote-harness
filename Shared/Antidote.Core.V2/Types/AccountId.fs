namespace Antidote.Core.V2.Types

open System
open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
module AccountId =

    type T = private | UserId of Guid

    let create (text: Guid) = UserId text

    let value (UserId password) = password

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "UserId cannot be empty"
        let! guid = Validators.Guid.validFormat text "Invalid Guid format"
        let! valid = Validators.Guid.nonEmpty text "Account Id cannot be empty guid"
        return UserId guid
    }
