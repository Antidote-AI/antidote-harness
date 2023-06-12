namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module StatedPatientName =

    type StatedPatientName = private | StatedPatientName of string

    let create (text: string) = StatedPatientName text

    let value (StatedPatientName statedPatientName) = statedPatientName

    let tryParse (text: string) = result {
        do! Validators.String.nonEmpty text "First name cannot be empty"

        do!
            Validators.String.maxLength
                text
                256
                "Stated patient name cannot be longer than 256 characters"

        return StatedPatientName text
    }
