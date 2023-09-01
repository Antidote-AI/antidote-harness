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

let ONE_FOOT_IN_INCHES = 12.0<inch/ft>
let ONE_POUND_IN_OUNCES = 16.0<oz/lb>
let ONE_KILOGRAM_IN_OUNCES = 35.274<oz/kg>
let OUNE_IN_KILOGRAM = 0.02834952<kg/oz>
let ONE_INCH_IN_METERS = 0.0254<m/inch>

type WeightType =
    | Lbs of (float<lb> * float<oz>) option
    | Kg of (float<kg> * float<oz>) option

type Height =
    | Feet of (float<ft> * float<inch>) option
    | Meters of float<m> option

type WeightHeight = WeightHeight of Height * WeightType

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


let kilogramsToPoundsAndOunces (kilograms : float<kg>) : float<lb> * float<oz> =
    let totalWeightInOunces = kilograms / OUNE_IN_KILOGRAM
    let pounds = System.Math.Round (float (totalWeightInOunces / ONE_POUND_IN_OUNCES), 0) * 1.0<lb>
    let ounces = System.Math.Round(float( totalWeightInOunces - pounds * ONE_POUND_IN_OUNCES), 0) * 1.0<oz>
    pounds , ounces

let metersToFeetAndInches (meters : float<m>) : float<ft> * float<inch> =
    let totalLengthInInches = meters / ONE_INCH_IN_METERS
    let roundedFeet = System.Math.Round(float (totalLengthInInches / ONE_FOOT_IN_INCHES), 0) * 1.0<ft>
    let inches = System.Math.Round(float (totalLengthInInches - roundedFeet * ONE_FOOT_IN_INCHES), 0) * 1.0<inch>
    roundedFeet , inches

let poundsToKilograms (pounds : float<lb>) (ounces : float<oz>) : float<kg> =
    let totalWeightInOunces = pounds * ONE_POUND_IN_OUNCES + ounces
    System.Math.Round(float (totalWeightInOunces * OUNE_IN_KILOGRAM), 2) * 1.0<kg>

let feetAndInchesToMeters (feet : float<ft>) (inches : float<inch>) : float<m> =
    let totalLengthInInches = feet * ONE_FOOT_IN_INCHES + inches
    System.Math.Round(float (totalLengthInInches * ONE_INCH_IN_METERS) , 2) * 1.0<m>

let feetInchesToString ((feet : float<ft>), (inches : float<inch>)) =
    sprintf $"{feet} Feet, {inches} Inches"

let poundsOuncesToString ((pounds : float<lb>), (ounces : float<oz>)) =
    sprintf $"{pounds} Pounds, {ounces} Ounces"


let feetInchesToMeters (x: float<ft>, y: float<inch>) : float<m> =
    let totalInches = ((int x) * 12) + (int y) //* 1<inch>
    let totalMeters = (float totalInches) / 39.3701
    totalMeters * 1.0<m>

let metersToFeetInches (x: float<m>) =
    let totalInches = x * 39.3701<inch/m>
    let totalFeet = (totalInches / 12.0<inch/ft>)
    let remainingInches = (float totalInches) - (float ((int totalFeet) *  12))
    (float totalFeet * 1.0<ft>, float remainingInches * 1.0<inch>)

let calculateBmi (weightHeight : WeightHeight) =
    match weightHeight with
    | WeightHeight(Height.Meters(Some meters), WeightType.Kg(Some (kilograms, _))) ->
        kilograms / (meters * meters)
    | WeightHeight(Height.Feet(Some (feet , inches)), WeightType.Lbs(Some (pounds, ounces))) ->
        let mtrs = feetAndInchesToMeters feet inches
        poundsToKilograms pounds ounces / (mtrs * mtrs)
    | WeightHeight(Height.Feet(Some (feet, inches)), WeightType.Kg(Some (kilograms,_))) ->
        let mtrs = feetAndInchesToMeters feet inches
        kilograms / (mtrs * mtrs)
    | WeightHeight(Height.Meters(Some meters), WeightType.Lbs(Some (pounds, ounces))) ->
        poundsToKilograms pounds ounces / (meters * meters)
    | _ -> failwith "Invalid or missing weight or height data"


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
                let kg = lbsToKg (lbs |> fst)
                let kgRounded = (System.Math.Round((float kg), 2)) * 1.0<kg>
                { state with Weight = Kg (Some (kgRounded, 0.0<oz>)) }, Cmd.none
            | None -> { state with Weight = Kg None }, Cmd.none
        | Kg kg ->
            match kg with
            | Some kg ->
                let lbs = kgToLbs (kg |> fst)
                let oz = (kg |> snd)
                let lbsRounded = (System.Math.Round((float lbs), 2)) * 1.0<lb>
                let ozRounded = System.Math.Round((float oz), 2) * 1.0<oz>
                { state with Weight = Lbs (Some (lbsRounded, ozRounded)) }, Cmd.none
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
        let feet = float feet
        match state.Height with
        | Feet ftInch ->
            match ftInch with
            | Some ftInch ->
                let inches = snd ftInch
                { state with Height = Feet (Some (feet * 1.0<ft>, inches)) }, Cmd.none
            | None ->
                { state with Height = Feet (Some (feet * 1.0<ft>, 0.0 * 0.0<inch>)) }, Cmd.none
        | _ -> state, Cmd.none

    | SetInches inches ->
        console.log $"SetFeet {inches}"
        let inches = float inches
        match state.Height with
        | Feet ftInch ->
            match ftInch with
            | Some ftInch ->
                let feet = fst ftInch
                { state with Height = Feet (Some (feet, inches * 1.0<inch>)) }, Cmd.none
            | None ->
                { state with Height = Feet (Some (0.0 * 1.0<ft>, inches * 1.0<inch>)) }, Cmd.none
        | _ -> state, Cmd.none

    | SetMeters meters ->
        console.log $"SetMeters {meters}"
        let meters = float meters
        { state with Height = Meters (Some (meters * 1.0<m>)) }, Cmd.none

    | SetLbs lbs ->
        console.log $"SetLbs {lbs}"
        let lbs = float lbs
        { state with Weight = Lbs (Some (lbs * 1.0<lb>, 0.0<oz> )) }, Cmd.none //idk if this line is correct, it needs revision

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
                prop.classes ["field-body"; "fieldBody"; "column"; "is-four-fifths"; "pt-0";]
                prop.children [
                    Html.div [
                        prop.classes [ "field"; "is-expanded"; "field-width";"m-0" ]
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
                                                    prop.placeholder "156 lbs"
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
                                                prop.classes [ "has-background-primary" ]
                                                prop.onClick (fun _ -> props.Dispatch ChangeWeightType)
                                                prop.children [
                                                    Html.span [
                                                        prop.style [
                                                            style.marginRight 15
                                                            style.color.white
                                                            style.fontWeight.bold

                                                        ]
                                                        prop.text (
                                                            match props.State.Weight with
                                                            | Lbs _ -> "LB"
                                                            | Kg _ -> "KG"
                                                        )
                                                    ]
                                                    Icon [
                                                        icon.color "#FFFFFF"
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
        prop.classes [ "field"; "is-horizontal"; "is-full"; classes.heightWeight ]
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
                prop.className ["field-body"; "fieldBody"; "column"; "is-four-fifths"; "pt-0"; ]
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
                                                    prop.placeholder "5 ft"
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
                                                    prop.placeholder "7 in"
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
                                                prop.classes [ "has-background-primary" ]
                                                prop.onClick (fun _ -> props.Dispatch ChangeHeightType)
                                                prop.children [
                                                    Html.span [
                                                        prop.style [
                                                            style.marginRight 15
                                                            style.color.white
                                                            style.fontWeight.bold
                                                        ]
                                                        prop.text (
                                                            match props.State.Height with
                                                            | Feet _ -> "IN"
                                                            | Meters _ -> "CM"
                                                        )
                                                    ]
                                                    Icon [
                                                        icon.color "#FFFFFF"
                                                        (match props.State.Height with
                                                        | Feet _ ->
                                                            icon.icon mdi.cached
                                                        | Meters _ ->
                                                            icon.icon mdi.cached
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
                    // Bulma.columns [
                    //     Bulma.column [
                    //         prop.classes ["mt-4"]
                    //         column.is2 // <-- note context helper here
                    //         prop.children [
                    //         Bulma.button.button "Click me"
                    //         ]
                    //     ]
                    // ]
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
        // Bulma.title.h1 [
        //     prop.style [ style.color.black]
        //     prop.text "BMI Calculator"
        // ]
        WeightComponent {| State = state; Dispatch = dispatch |}
        HeightComponent {| State = state; Dispatch = dispatch |}
    ]
