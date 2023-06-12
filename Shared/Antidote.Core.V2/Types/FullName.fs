namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module FullName =

    type T = private | FullName of string

    let create (fullName: string) = FullName fullName

    let createFromParts (firstName: FirstName.T) (lastName: LastName.T) = FullName ((FirstName.toString firstName) + " " + (LastName.toString lastName))

    let value (FullName fullName) = fullName

    let valueAsFirstAndLastString (FullName fullName) =
        fullName.Split(" ")
        |> fun nameParts ->
            if nameParts.Length <= 1
            then nameParts[0], ""
            else if nameParts.Length = 2
            then nameParts[0], nameParts[1]
            else if nameParts.Length = 3
            then nameParts[0] + " " +  nameParts[1], nameParts[2]
            else fullName, "" // TODO: this needs to be handled better.


    let tryParse (fullNameString: string) = result {
        do! Validators.String.nonEmpty fullNameString "Full name cannot be empty"
        do! Validators.String.isMultiPart fullNameString 2

        do!
            Validators.String.maxLength
                fullNameString
                256
                "Full name cannot be longer than 256 characters"

        return FullName fullNameString
    }
