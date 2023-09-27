module Healix.Components.ePrescribeOrderTable

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


let private classes : CssModules.Components.ePrescribeOrderTable = import "default" "./ePrescribeOrderTable.module.scss"
let headers: string list = ["Medication"; "Quantity"; "Patient";"Fills"; "Status"; "Prescriber"; "Date Written"]


type ePrescribeStatus =
    | Filled
    | Depleted
    | Pending
    | Other

type ePrescribeElement = {
    medication: string
    quantity: string
    patient: string
    fills: string
    status: ePrescribeStatus
    prescriber: string
    dateWritten: string
}

let rowData: ePrescribeElement list = [
    {
        medication = "ibuprofen lysine 10 MG/ML in 2 ML Injection";
        quantity = "1 ct / 2 day";
        patient = "Patient Antidote";
        fills = "0 of 4";
        status = Pending;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "Abilify Asimtufii 720 MG in 2.4 ML Extended Release Prefilled Syringe";
        quantity = "4 ct / 4 day";
        patient = "Alex Campo";
        fills = "0 of 5";
        status = Depleted;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "Bayer Aspirin (Acetylsalicylic Acid 325 mg/1) Oral tablet, coated";
        quantity = "3 ct / 3 day";
        patient = "Luis Ortiz";
        fills = "0 of 4";
        status = Depleted;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "ibuprofen lysine 10 MG/ML in 2 ML Injection";
        quantity = "1 ct / 2 day";
        patient = "Patient Antidote";
        fills = "0 of 4";
        status = Pending;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "Abilify Asimtufii 720 MG in 2.4 ML Extended Release Prefilled Syringe";
        quantity = "4 ct / 4 day";
        patient = "Alex Campo";
        fills = "0 of 5";
        status = Depleted;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "Bayer Aspirin (Acetylsalicylic Acid 325 mg/1) Oral tablet, coated";
        quantity = "3 ct / 3 day";
        patient = "Luis Ortiz";
        fills = "0 of 4";
        status = Depleted;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "ibuprofen lysine 10 MG/ML in 2 ML Injection";
        quantity = "1 ct / 2 day";
        patient = "Patient Antidote";
        fills = "0 of 4";
        status = Pending;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "Abilify Asimtufii 720 MG in 2.4 ML Extended Release Prefilled Syringe";
        quantity = "4 ct / 4 day";
        patient = "Alex Campo";
        fills = "0 of 5";
        status = Depleted;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    };
    {
        medication = "Bayer Aspirin (Acetylsalicylic Acid 325 mg/1) Oral tablet, coated";
        quantity = "3 ct / 3 day";
        patient = "Luis Ortiz";
        fills = "0 of 4";
        status = Depleted;
        prescriber = "Luis Ortiz";
        dateWritten = "9/25/2023"
    }

]



let ePrescribeStatusTag (status: ePrescribeStatus) =
    match status with
    | Filled ->
        Bulma.tag [
            prop.classes ["has-text-weight-semibold"]
            tag.isRounded
            Bulma.color.isLight
            Bulma.color.isSuccess
            prop.text "Filled"
        ]
    | Depleted ->
        Bulma.tag [
            prop.style [style.fontWeight 600]
            tag.isRounded
            Bulma.color.isLight
            Bulma.color.isDanger
            prop.text "Depleted"
        ]
    | Pending ->
        Bulma.tag [
            prop.style [style.fontWeight 600]
            tag.isRounded
            Bulma.color.isLight
            Bulma.color.isWarning
            prop.text "Pending"
        ]
    | Other ->
        Bulma.tag [
            prop.style [style.fontWeight 600]
            tag.isRounded
            Bulma.color.isLight
            Bulma.color.isPrimary
            prop.text "description"
        ]

let initials (name: string) =
    let parts = name.Split(' ')
    match parts with
    | [| first; last |] -> string(first.[0]) + string(last.[0])
    | _ -> "" // Handle other cases as necessary


[<ReactComponent>]
let ePrescribeOrderTable (props:ePrescribeElement list) =
    Html.section [
        prop.style [style.display.flex; style.justifyContent.center]
        prop.children [
            Html.div [
                prop.style [ style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12; style.width (length.perc 90); style.marginTop 20]
                prop.children [
                    Html.div [
                        prop.style [style.borderBottom(1, borderStyle.solid, color.lightGray); style.display.flex;style.justifyContent.spaceBetween; style.flexDirection.row; style.alignItems.center]
                        prop.children [
                            Html.div [
                                prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        prop.children [
                                            Bulma.image [
                                                prop.style [style.marginLeft 5]
                                                Bulma.image.is24x24
                                                prop.children [
                                                    Html.img [
                                                        prop.alt "Placeholder image"
                                                        prop.src "/images/medication.svg"
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [style.marginLeft 5]
                                        prop.children [
                                            Html.strong "Medications"
                                        ]
                                    ]
                                ]
                            ]

                            Html.div [
                                prop.style [ style.margin 10; style.display.flex; style.flexDirection.row; style.alignItems.center]
                                prop.children [
                                    Bulma.control.div [
                                        Bulma.control.hasIconsLeft
                                        prop.style [style.marginRight 10]
                                        prop.children [
                                            Bulma.input.text [
                                                prop.style [style.borderRadius 3; style.height 32]
                                                prop.placeholder "Search"
                                            ]
                                            Bulma.icon [
                                                Bulma.icon.isLeft
                                                prop.children [
                                                    Html.i [
                                                        prop.className "fas fa-search"
                                                        prop.style [style.display.flex; style.justifyContent.center; style.alignItems.center; style.marginBottom 5]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                    Bulma.button.button [
                                        Bulma.button.isRounded
                                        Bulma.color.isSuccess
                                        Bulma.button.isSmall
                                        prop.classes [ "has-text-weight-bold"]
                                        prop.style [style.borderRadius 3]
                                        //prop.style [ style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                        prop.children [
                                            Icon [
                                                icon.icon mdi.plusCircle
                                                icon.width 15
                                                icon.height 15
                                                icon.color color.white
                                            ]
                                            Html.p [
                                                prop.text "New Prescription"
                                                prop.style [style.marginLeft 5; style.color.white; style.border(0, borderStyle.none, color.transparent); style.fontWeight.bold]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Bulma.table [
                        table.isStriped
                        table.isFullWidth
                        table.isNarrow
                        table.isHoverable
                        prop.children [
                            Html.thead [
                                Html.tr (
                                    headers |> List.map (
                                        fun header ->
                                            Html.th [
                                                prop.text header
                                                prop.style [style.fontSize 12;style.fontWeight 500]
                                            ]
                                    )
                                )
                            ]
                            Html.tbody (
                                props |> List.map (fun row ->
                                    Html.tr [
                                        Html.td [
                                            prop.style [style.fontWeight 500]
                                            prop.text row.medication
                                        ]
                                        Html.td [prop.text row.quantity]
                                        Html.td [
                                            prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                            prop.children [
                                                Html.div [
                                                    prop.classes ["has-background-primary"; "has-text-white"; "has-text-weight-bold"; "has-text-centered"]
                                                    prop.style [
                                                        style.display.flex;
                                                        style.justifyContent.center;
                                                        style.alignItems.center;
                                                        style.backgroundColor.blue;
                                                        style.color.white;
                                                        style.borderRadius 20;
                                                        style.height 30;
                                                        style.width 30
                                                        style.fontSize 13
                                                    ]
                                                    prop.children [
                                                        Html.text (initials row.patient)
                                                    ]
                                                ]
                                                Html.div [
                                                    prop.style [style.marginLeft 10; style.fontWeight 525; style.color.darkSlateGray]
                                                    prop.children [
                                                        Html.text row.patient
                                                    ]
                                                ]
                                            ]
                                        ]
                                        Html.td [prop.text row.fills]
                                        Html.td [prop.children [ePrescribeStatusTag row.status]]
                                        Html.td [
                                            prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                            prop.children [
                                                Html.div [
                                                    prop.classes [ "has-text-white"; "has-text-weight-bold"; "has-text-centered"]
                                                    prop.style [
                                                        style.display.flex;
                                                        style.justifyContent.center;
                                                        style.alignItems.center;
                                                        style.backgroundColor.darkOrange;
                                                        style.color.white;
                                                        style.borderRadius 20;
                                                        style.height 30;
                                                        style.width 30
                                                        style.fontSize 13

                                                    ]
                                                    prop.children [
                                                        Html.text (initials row.prescriber)
                                                    ]
                                                ]
                                                Html.div [
                                                    prop.style [style.marginLeft 10; style.fontWeight 525; style.color.darkSlateGray]
                                                    prop.children [
                                                        Html.text row.prescriber
                                                    ]
                                                ]
                                            ]
                                        ]
                                        Html.td [prop.text row.dateWritten]
                                    ]
                                )
                            )
                        ]
                    ]
                ]
            ]
        ]
    ]

let renderPage () =
    ePrescribeOrderTable rowData
