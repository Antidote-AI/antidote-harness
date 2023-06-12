namespace Antidote.Core.V2.Types

open System
open FsToolkit.ErrorHandling
open Antidote.Core.V2

type VisitType =
    | MAT_Induction
    | MAT_Continuation
    | Somatic
    | Individual_Psychotherapy
    | Family_Counseling
    | NotSelected
    | General_Surgery_Evalutation
    | Cardiology
    | Infectious_Disease
    | Psychiatry
    | Social_Determinants_Of_Health

[<RequireQualifiedAccess>]
module VisitType =

    let toString (visitType: VisitType) =
        match visitType with
        | MAT_Induction -> "MAT Induction"
        | MAT_Continuation -> "MAT Continuation"
        | Somatic -> "Somatic"
        | Individual_Psychotherapy -> "Individual Psychotherapy"
        | Family_Counseling -> "Family Counseling"
        | NotSelected -> "Not Selected"
        | General_Surgery_Evalutation -> "General Surgery Evalutation"
        | Cardiology -> "Cardiology"
        | Infectious_Disease -> "Infectious Disease"
        | Psychiatry -> "Psychiatry"
        | Social_Determinants_Of_Health -> "Social Determinants of Health"

    let tryParse (text: string) =
        match text with
        | "MAT Induction" -> Ok MAT_Induction
        | "MAT Continuation" -> Ok MAT_Continuation
        | "Somatic" -> Ok Somatic
        | "Individual Psychotherapy" -> Ok Individual_Psychotherapy
        | "Family Counseling" -> Ok Family_Counseling
        | "General Surgery Evalutation" -> Ok General_Surgery_Evalutation
        | "Cardiology" -> Ok Cardiology
        | "Infectious Disease" -> Ok Infectious_Disease
        | "Psychiatry" -> Ok Psychiatry
        | "Social Determinants of Health" -> Ok Social_Determinants_Of_Health
        | "Not Selected" -> Ok NotSelected
        | _ -> Error "provided visit type string does not exist in the union"

    let parseExact (text : string) =
        match tryParse text with
        | Ok visitType -> visitType
        | Error errorMessage -> failwith errorMessage
