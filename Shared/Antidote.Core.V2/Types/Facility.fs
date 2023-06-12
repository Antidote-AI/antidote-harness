namespace Antidote.Core.V2.Types

open System
open FsToolkit.ErrorHandling
open Antidote.Core.V2

type Facility =
    | Duval_County
    | Baker_County
    | St_Johns_County
    | Martin_County
    | Collier_County
    | Lee_County
    | Clarke_County
    | Cumberland_County
    | Larimer_County
    | Douglas_County
    | Nueces_County
    | Franklin_County
    | Cache_County
    | Not_Applicable

[<RequireQualifiedAccess>]
module Facility =

    let toString (facility: Facility) =
        match facility with
        | Duval_County -> "Duval County"
        | Baker_County -> "Baker County"
        | St_Johns_County -> "St. John's County"
        | Martin_County -> "Martin County"
        | Collier_County -> "Collier County"
        | Lee_County -> "Lee County"
        | Clarke_County -> "Clarke County"
        | Cumberland_County -> "Cumberland County"
        | Larimer_County -> "Larimer County"
        | Douglas_County -> "Douglas County"
        | Nueces_County -> "Nueces County"
        | Franklin_County -> "Franklin County"
        | Cache_County -> "Cache County"
        | Not_Applicable -> "Not Applicable"

    let tryParse (text: string) =
        match text with
        | "Duval County" -> Ok Duval_County
        | "Baker County" -> Ok Baker_County
        | "St. John's County" -> Ok St_Johns_County
        | "Martin County" -> Ok Martin_County
        | "Collier County" -> Ok Collier_County
        | "Lee County" -> Ok Lee_County
        | "Clarke County" -> Ok Clarke_County
        | "Cumberland County" -> Ok Cumberland_County
        | "Larimer County" -> Ok Larimer_County
        | "Douglas County" -> Ok Douglas_County
        | "Nueces County" -> Ok Nueces_County
        | "Franklin County" -> Ok Franklin_County
        | "Cache County" -> Ok Cache_County
        | "Not Applicable" -> Ok Not_Applicable
        | _ -> Error "provided facility string does not exist in the union"

    let parseExact (text : string) =
        match tryParse text with
        | Ok visitType -> visitType
        | Error errorMessage -> failwith errorMessage
