namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

type ContactType =
    | ContactHomePhone
    | ContactMobilePhone
    | ContactEmailAddress
    | InvalidContactDetails

[<RequireQualifiedAccess>]
module ContactType =

    let fromIndex (index: int) =
        match index with
        | 0 -> InvalidContactDetails
        | 1 -> ContactMobilePhone
        | 2 -> ContactEmailAddress
        | 3 -> ContactHomePhone
        | _ -> failwith "Invalid value for ContactType type"

    let toIndex (contactType: ContactType) =
        match contactType with
        | InvalidContactDetails -> 0
        | ContactMobilePhone -> 1
        | ContactEmailAddress -> 2
        | ContactHomePhone -> 3

    let toNameOf (contactType: ContactType) =
        match contactType with
        | InvalidContactDetails -> nameof(InvalidContactDetails)
        | ContactMobilePhone -> nameof(ContactMobilePhone)
        | ContactEmailAddress -> nameof(ContactEmailAddress)
        | ContactHomePhone -> nameof(ContactHomePhone)

    let tryParse (s: string) =
        match System.Int32.TryParse s with
        | true, index ->
            match index with
            | -1
            | 0 -> Error "This field is required"
            | 1 -> Ok ContactMobilePhone
            | 2 -> Ok ContactEmailAddress
            | 3 -> Ok ContactHomePhone
            | _ -> Error "Invalid value for the ContactType type"
        | false, _ -> Error "ContactType type must be an integer"
