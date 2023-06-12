namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module Signature =

    type Signature = private | Signature of byte array

    let create (value: byte array) = Signature value

    let value (Signature signature) = signature

    let validate (Signature signature) = result {
        do! Validators.Array.nonEmpty signature "Signature cannot be empty"
        // TODO: Test the maximum length of a signature.

        return Signature signature
    }
