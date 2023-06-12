namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module SeverityLevel =

    type SeverityLevel = private | SeverityLevel of int

    let create (level: int) = SeverityLevel level

    let value (SeverityLevel level) = level

    let tryParse (level: int) = result {
        do! Validators.Int.isNonNegative level "Severity level cannot be negative."
        do! Validators.Int.isInRange level 0 5 "Number is outside of the range of 0 to 5"
        return SeverityLevel level
    }
