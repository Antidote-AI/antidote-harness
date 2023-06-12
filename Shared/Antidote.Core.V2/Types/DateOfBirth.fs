namespace Antidote.Core.V2.Types

open System
open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module DateOfBirth =

    type T = private | DateOfBirth of DateOnly

    let create (text: DateOnly) = DateOfBirth text

    let value (DateOfBirth dateOfBirth) = dateOfBirth

    let validate (date: DateOnly) = result {
        do!
            Validators.DateOnly.lessThan
                date
                (DateOnly.FromDateTime(DateTime.UtcNow))
                "Date of birth cannot be in the future"

        // Fails if below this date as it isn't supported by SQL DATETIME
        do!
            Validators.DateOnly.greaterThan
                date
                (DateOnly.FromDateTime(DateTime(1753, 1, 1)))
                "Date of birth cannot be that far in the past"
    }

    // let tryParse (text: string) = result {
    //     do! Validators.String.nonEmpty text "Date of birth cannot be empty"
    //     let! date = Validators.DateOnly.validFormat text "Invalid date format"
    //
    //     do! validate date
    //
    //     return DateOfBirth date
    // }

    let toString (DateOfBirth dateOfBirth) =
        let day = dateOfBirth.Day.ToString("D2")
        let month = dateOfBirth.Month.ToString("D2")
        $"{dateOfBirth.Year}-{month}-{day}"
