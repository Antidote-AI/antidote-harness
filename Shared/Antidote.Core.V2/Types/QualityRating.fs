namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module QualityRating =

    type QualityRating = private | QualityRating of int

    let create (rating: int) = QualityRating rating

    let value (QualityRating rating) = rating

    let tryParse (rating: int) = result {
        do! Validators.Int.isInRange rating 0 5 "Rating must be a whole number in range {0 - 5}"
        return QualityRating rating
    }
