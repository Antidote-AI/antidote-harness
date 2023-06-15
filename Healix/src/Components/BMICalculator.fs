module Healix.Components.BMICalculator

open System
open Feliz
open Feliz.UseElmish
open Feliz.Bulma
open Fable.Core
open Fable.Core.JsInterop
// open Antidote.Core.V2.Types

open Feliz.Iconify
open type Offline.Exports
open Glutinum.IconifyIcons.Mdi
open Elmish
open Fable.Core.JS
// open Antidote.Core.V2.Utils.JS

emitJsStatement () "import React from \"react\""
let private classes : CssModules.Components.BMICalculator = import "default" "./BMICalculator.module.scss"

[<Measure>] type kg
[<Measure>] type lb
[<Measure>] type oz
[<Measure>] type ft
[<Measure>] type inch
[<Measure>] type m
[<Measure>] type cm

type WeightType =
    | Lbs of (float<lb>) option
    | Kg of (float<kg> * float<oz>) option

type Height =
    | Feet of (int<ft> * int<inch>) option
    | Meters of float<m> option

//Converters
let feetToInches (x: float<ft>) : float<inch> = x * 12.0<inch/ft>
let inchesToFeet (x: float<inch>) : float<ft> = x / 12.0<inch/ft>
let metersToCm (x: float<m>) : float<cm> = x * 100.0<cm/m>
let cmToMeters (x: float<cm>) : float<m> = x / 100.0<cm/m>
let lbsToOz (x: float<lb>) : float<oz> = x * 16.0<oz/lb>
let ozToLbs (x: float<oz>) : float<lb> = x / 16.0<oz/lb>
let kgToLbs (x: float<kg>) : float<lb> = x * 2.20462<lb/kg>
let lbsToKg (x: float<lb>) : float<kg> = x / 2.20462<lb/kg>
let meterToFeet (x: float<m>) : float<ft> = x * 3.28084<ft/m>
let feetToMeter (x: float<ft>) : float<m> = x / 3.28084<ft/m>

let feetInchesToMeters (x: int<ft>, y: int<inch>) : float<m> =
    let totalInches = ((int x) * 12) + (int y) //* 1<inch>
    let totalMeters = (float totalInches) / 39.3701
    totalMeters * 1.0<m>

let metersToFeetInches (x: float<m>) =
    let totalInches = x * 39.3701<inch/m>
    let totalFeet = (totalInches / 12.0<inch/ft>)
    let remainingInches = (float totalInches) - (float ((int totalFeet) *  12))
    (int totalFeet * 1<ft>, int remainingInches * 1<inch>)


type State = {
    Weight: WeightType
    Height: Height
}

type Msg =
    | SetWeight of WeightType
    | SetHeight of Height

    | ChangeWeightType

    | ChangeHeightType
    | SetFeet of string
    | SetInches of string

    | SetKg of string
    | SetLbs of string
    | SetOz of int
    | SetMeters of string
    | SetCm of int

let init() =
    {
        Weight = Lbs None
        Height = Feet None
    }, Cmd.none

let update msg state =
    match msg with
    | ChangeWeightType ->
        console.log $"ChangeWeightType"
        match state.Weight with
        | Lbs lbs ->
            match lbs with
            | Some lbs ->
                let kg = lbsToKg lbs
                let kgRounded = (System.Math.Round((float kg), 2)) * 1.0<kg>
                { state with Weight = Kg (Some (kgRounded, 0.0<oz>)) }, Cmd.none
            | None -> { state with Weight = Kg None }, Cmd.none
        | Kg kg ->
            match kg with
            | Some kg ->
                let lbs = kgToLbs (kg |> fst)
                let lbsRounded = (System.Math.Round((float lbs), 2)) * 1.0<lb>
                { state with Weight = Lbs (Some lbsRounded) }, Cmd.none
            | None -> { state with Weight = Lbs None }, Cmd.none

    | ChangeHeightType ->
        console.log $"ChangeHeightType"
        match state.Height with
        | Feet ftInch ->
            match ftInch with
            | Some ftInch ->
                let meters = feetInchesToMeters ftInch
                let metersRounded = (System.Math.Round((float meters), 2)) * 1.0<m>
                { state with Height = Meters (Some metersRounded) }, Cmd.none
            | None -> { state with Height = Meters None }, Cmd.none
        | Meters meters ->
            match meters with
            | Some meters ->
                let feetInches = metersToFeetInches meters
                { state with Height = Feet (Some feetInches) }, Cmd.none // (Some feetInches) }, Cmd.none
            | None -> { state with Height = Feet None }, Cmd.none



    | SetFeet feet ->
        console.log $"SetFeet {feet}"
        let feet = int feet
        match state.Height with
        | Feet ftInch ->
            match ftInch with
            | Some ftInch ->
                let inches = snd ftInch
                { state with Height = Feet (Some (feet * 1<ft>, inches)) }, Cmd.none
            | None ->
                { state with Height = Feet (Some (feet * 1<ft>, 0 * 1<inch>)) }, Cmd.none
        | _ -> state, Cmd.none

    | SetInches inches ->
        console.log $"SetFeet {inches}"
        let inches = int inches
        match state.Height with
        | Feet ftInch ->
            match ftInch with
            | Some ftInch ->
                let feet = fst ftInch
                { state with Height = Feet (Some (feet, inches * 1<inch>)) }, Cmd.none
            | None ->
                { state with Height = Feet (Some (0 * 1<ft>, inches * 1<inch>)) }, Cmd.none
        | _ -> state, Cmd.none

    | SetMeters meters ->
        console.log $"SetMeters {meters}"
        let meters = float meters
        { state with Height = Meters (Some (meters * 1.0<m>)) }, Cmd.none

    | SetLbs lbs ->
        console.log $"SetLbs {lbs}"
        let lbs = float lbs
        { state with Weight = Lbs (Some (lbs * 1.0<lb>)) }, Cmd.none

    | SetWeight weight -> { state with Weight = weight }, Cmd.none
    | SetHeight height ->
        { state with Height = height }, Cmd.none
    | _ -> state, Cmd.none

type WeightProps = {|
    State: State
    Dispatch: Msg -> unit
|}

[<ReactComponent>]
let WeightComponent(props: WeightProps) =
    Html.div [
        prop.classes [ "field"; "is-horizontal"; "is-full"; classes.heightWeight ]
        prop.children [
            Html.div [
                prop.className "field-label"
                prop.children [
                    Html.label [
                        prop.className "label"
                        prop.text "Weight"
                    ]
                ]
            ]
            Html.div [
                prop.className "field-body"
                prop.children [
                    Html.div [
                        prop.classes [ "field"; "is-expanded"; "pl-3"; "pr-3" ]
                        prop.children [
                            Html.div [
                                prop.classes [ "field"; "has-addons" ]
                                prop.children [
                                    match props.State.Weight with
                                    | Lbs lbs ->
                                        Html.p [
                                            prop.classes [ "control"; "is-expanded" ]
                                            prop.children [
                                                Html.input [
                                                    prop.className "input"
                                                    prop.value (
                                                        match lbs with
                                                        | Some lbs -> string lbs
                                                        | None -> ""
                                                    )
                                                    // prop.type' "weight"
                                                    prop.placeholder "0"
                                                    prop.onChange (SetLbs >> props.Dispatch)
                                                ]
                                            ]
                                        ]
                                    | Kg kg ->
                                        Html.p [
                                            prop.classes [ "control"; "is-expanded" ]
                                            prop.children [
                                                Html.input [
                                                    prop.className "input"
                                                    prop.value (
                                                        match kg with
                                                        | Some x -> string (x |> fst)
                                                        | None -> ""
                                                    )
                                                    // prop.type' "weight"
                                                    prop.placeholder "0"
                                                    prop.onChange (SetKg >> props.Dispatch)
                                                ]
                                            ]
                                        ]

                                    Html.p [
                                        prop.className "control"
                                        prop.children [
                                            Bulma.button.a [
                                                prop.classes [ "is-antidote-orange" ]
                                                prop.onClick (fun _ -> props.Dispatch ChangeWeightType)
                                                prop.children [
                                                    Html.span [
                                                        prop.style [
                                                            style.marginRight 15
                                                        ]
                                                        prop.text (
                                                            match props.State.Weight with
                                                            | Lbs _ -> "LB"
                                                            | Kg _ -> "KG"
                                                        )
                                                    ]
                                                    Icon [
                                                        (match props.State.Weight with
                                                        | Lbs _ -> icon.icon mdi.cached
                                                        | Kg _ -> icon.icon mdi.cached
                                                        )
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.p [
                                prop.className "help"
                                prop.text "Enter only the digits, without spaces or dashes."
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

type HeightProps = {|
    State: State
    Dispatch: Msg -> unit
|}

[<ReactComponent>]
let HeightComponent (props: HeightProps) =
    Html.div [
        prop.classes [ "field"; "is-horizontal"; classes.heightWeight ]
        prop.children [
            Html.div [
                prop.className "field-label"
                prop.children [
                    Html.label [
                        prop.className "label"
                        prop.text "Height"
                    ]
                ]
            ]
            Html.div [
                prop.className ["field-body"; "fieldBody"; "column"; "is-four-fifths"; "pt-0" ]
                prop.children [
                    Html.div [
                        prop.classes [ "field"; "is-expanded"; "field-width";"m-0" ]
                        prop.children [
                            Html.div [
                                prop.classes [ "field"; "has-addons" ]
                                prop.children [
                                    match props.State.Height with
                                    | Feet ftInch ->
                                        Html.p [
                                            prop.classes [ "control"; "is-expanded" ]
                                            prop.children [
                                                Html.input [
                                                    prop.className "input"
                                                    prop.value (
                                                        match ftInch with
                                                        | Some (x, y) -> string x
                                                        | None -> ""
                                                    )
                                                    // prop.type' "weight"
                                                    prop.placeholder "0"
                                                    prop.onChange (SetFeet >> props.Dispatch)
                                                ]
                                            ]
                                        ]
                                        Html.p [
                                            prop.classes [ "control"; "is-expanded" ]
                                            prop.children [
                                                Html.input [
                                                    prop.className "input"
                                                    prop.value (
                                                        match ftInch with
                                                        | Some (x, y) -> string y
                                                        | None -> ""
                                                    )
                                                    // prop.type' "weight"
                                                    prop.placeholder "0"
                                                    prop.onChange (SetInches >> props.Dispatch)

                                                ]
                                            ]
                                        ]

                                    | Meters meters ->
                                        Html.p [
                                            prop.classes [ "control"; "is-expanded" ]
                                            prop.children [
                                                Html.input [
                                                    prop.className "input"
                                                    prop.value (
                                                        match meters with
                                                        | Some x -> string x
                                                        | None -> ""
                                                    )
                                                    // prop.type' "weight"
                                                    prop.placeholder "Meters"
                                                    prop.onChange (SetMeters >> props.Dispatch)
                                                ]
                                            ]
                                        ]

                                    Html.p [
                                        prop.className "control"
                                        prop.children [
                                            Bulma.button.a [
                                                prop.classes [ "is-antidote-orange" ]
                                                prop.onClick (fun _ -> props.Dispatch ChangeHeightType)
                                                prop.children [
                                                    Html.span [
                                                        prop.style [
                                                            style.marginRight 15
                                                        ]
                                                        prop.text (
                                                            match props.State.Height with
                                                            | Feet _ -> "IN"
                                                            | Meters _ -> "CM"
                                                        )
                                                    ]
                                                    Icon [(
                                                        match props.State.Height with
                                                        | Feet _ -> icon.icon mdi.cached
                                                        | Meters _ ->icon.icon mdi.cached
                                                    )]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.p [
                                prop.className "help"
                                prop.text "Enter only the digits, without spaces or dashes."
                            ]
                        ]
                    ]
                    Bulma.columns [
                            Bulma.column [
                                prop.classes ["mt-4"]
                                column.is2 // <-- note context helper here
                                prop.children [
                                Bulma.button.button "Click me"
                                ]
                            ]
                        ]
                ]
            ]
        ]
    ]




[<ReactComponent>]
// let BMICalculator (props : Field.ReactComponentField.ReactComponentFieldProps) =
let BMICalculator () =

    let weightType, setWeightType = React.useState (Lbs None)
    let heightType, setHeightType = React.useState (Feet None)

    let (state:State), dispatch = React.useElmish(init(), update, [||])

    Html.div [
        Html.br []
        Html.br []
        Bulma.title.h1 [
            prop.style [ style.color.black]
            prop.text "BMI Calculator"
        ]
        WeightComponent {| State = state; Dispatch = dispatch |}
        HeightComponent {| State = state; Dispatch = dispatch |}
    ]
