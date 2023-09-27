module Healix.Components.ePrescribeOrderDetail

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
    rxID: string
    quantity: string
    patient: string
    fills: string
    status: ePrescribeStatus
    prescriber: string
    dateWritten: string
    instructions: string
    pharmacyNotes: string
    FillsRemaining: int
    FillsAllowed: int
    DoNotfillBefore: DateTime
    ExpirationAsWritten: DateTime
    DispenseAsWritten: bool
    ExternalID: string
    PharmacyStatus: string
}

let simulatedData: ePrescribeElement = {
    medication = "Amoxicillin 500mg Capsules";
    rxID = "RX-123456789";
    quantity = "30 capsules";
    patient = "John Doe";
    fills = "0 of 5";
    status = Filled;  (* Assuming you have Filled as one of the variants of ePrescribeStatus *)
    prescriber = "Alice Smith";
    dateWritten = "10/01/2023";
    instructions = "Take 1 capsule by mouth twice a day for 15 days.";
    pharmacyNotes = "No generic substitution.";
    FillsRemaining = 5;
    FillsAllowed = 5;
    DoNotfillBefore = DateTime(2023, 10, 1);
    ExpirationAsWritten = DateTime(2024, 10, 1);
    DispenseAsWritten = true;
    ExternalID = "EID-987654321";
    PharmacyStatus = "Ready"
}



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


let PharmacyStatusTags a =
    match a with
    | "Pending" ->
        Bulma.tag [
            Bulma.tag.isRounded
            Bulma.color.isWarning
            Bulma.color.isLight
            prop.children [
                Bulma.icon [
                    Bulma.icon.isSmall
                    prop.style [style.marginRight 5]
                    prop.children [
                        Icon [
                            icon.icon mdi.clockOutline
                            icon.color "#815903"
                            icon.width 18
                        ]
                    ]
                ]
                Html.div [
                    //prop.classes ["has-text-weight-bold"]
                    prop.children [
                        Html.text "Pending"
                    ]
                ]
            ]
        ]
    | "Filled" ->
        Bulma.tag [
            Bulma.tag.isRounded
            Bulma.color.isSuccess
            Bulma.color.isLight
            prop.children [
                Bulma.icon [
                    Bulma.icon.isSmall
                    prop.style [style.marginRight 5]
                    prop.children [
                        Icon [
                            icon.icon mdi.checkCircleOutline
                            icon.color "#22632d"
                            icon.width 18
                        ]
                    ]
                ]
                Html.div [
                    //prop.classes ["has-text-weight-bold"]
                    //prop.style [style.fontSize 100]
                    prop.children [
                        Html.text "Filled"
                    ]
                ]
            ]
        ]
    | "Ready" ->
        Bulma.tag [
            Bulma.tag.isRounded
            Bulma.color.isPrimary
            Bulma.color.isLight
            prop.children [
                Bulma.icon [
                    Bulma.icon.isSmall
                    prop.style [style.marginRight 5]
                    prop.children [
                        Icon [
                            icon.icon mdi.checkCircleOutline
                            icon.color "#2868bd"
                            icon.width 18
                        ]
                    ]
                ]
                Html.div [
                    prop.children [
                        Html.text "Ready"
                    ]
                ]
            ]
        ]
    | "Denied" ->
        Bulma.tag [
            Bulma.tag.isRounded
            Bulma.color.isDanger
            Bulma.color.isLight
            prop.children [
                Bulma.icon [
                    Bulma.icon.isSmall
                    prop.style [style.marginRight 5]
                    prop.children [
                        Icon [
                            icon.icon mdi.closeOutline
                            icon.color "#be0029"
                            icon.width 18
                        ]
                    ]
                ]
                Html.div [
                    prop.children [
                        Html.text "Denied"
                    ]
                ]
            ]
        ]


[<ReactComponent>]
let ePrescribeOrderDetail (props:ePrescribeElement) =
    Html.section [
        prop.style [style.display.flex; style.justifyContent.center; style.alignItems.center]  (* Added here *)
        prop.children [
            Html.div [
                prop.style [ style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12; style.width (length.perc 90); style.marginTop 20]
                prop.children [
                    Html.div [
                        prop.style [style.borderBottom(1, borderStyle.solid, color.whiteSmoke); style.display.flex; style.flexDirection.row; style.alignItems.center; style.margin 10; style.paddingBottom 10]  (* Added here *)
                        prop.children [
                            Html.div [
                                prop.style [style.display.flex; style.width (length.perc 100); style.justifyContent.spaceBetween; style.alignItems.center]  (* Added here *)
                                prop.children [
                                    Html.div [
                                        prop.style [style.display.flex; style.alignItems.center]  (* Added here *)
                                        prop.children [
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.column; style.alignItems.start; style.fontWeight 550]
                                                prop.children [
                                                    Html.div [
                                                        prop.text simulatedData.medication
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.column; style.alignItems.start; style.marginLeft 10]
                                                prop.children [
                                                    ePrescribeStatusTag props.status
                                                ]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [style.display.flex; style.alignItems.center; style.fontSize 14; style.color.lightSlateGray]  (* Added here *)
                                        prop.children [
                                            Html.text "rx-324234234324"
                                            Bulma.icon [
                                                Bulma.icon.isRight
                                                prop.style [ style.color.lightSlateGray]
                                                prop.children [
                                                    Icon [
                                                        icon.icon mdi.contentCopy
                                                        icon.color "black"
                                                        icon.width 13
                                                    ]
                                                ]

                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex]
                        prop.children [
                            Html.div [
                                prop.style [style.maxWidth (length.perc 33);style.borderRight(1, borderStyle.solid, color.whiteSmoke); style.marginLeft 10; style.paddingRight 10]
                                prop.children [
                                    Html.div [
                                        prop.style [style.color.gray; style.fontSize 14; style.fontWeight 525]
                                        prop.children [
                                            Html.text "Patient"
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                        prop.children [
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.column; style.alignItems.start; style.fontWeight 550]
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
                                                            Html.text (initials props.patient)
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.children [
                                                    Html.div [
                                                        prop.style [style.marginLeft 10; style.fontWeight 525; style.color.darkSlateGray]
                                                        prop.children [
                                                            Html.text (props.patient)
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.maxWidth (length.perc 33);style.borderRight(1, borderStyle.solid, color.whiteSmoke); style.marginLeft 10; style.paddingRight 10]
                                prop.children [
                                    Html.div [
                                        prop.style [style.color.gray; style.fontSize 14; style.fontWeight 525]
                                        prop.children [
                                            Html.text "Date Written"
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                        prop.children [
                                            Html.div [
                                                prop.children [
                                                    Html.div [
                                                        prop.style [ style.fontWeight 525; style.color.darkSlateGray]
                                                        prop.children [
                                                            Html.text (props.dateWritten)
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.maxWidth (length.perc 33); style.marginLeft 10; style.paddingRight 10]
                                prop.children [
                                    Html.div [
                                        prop.style [style.color.gray; style.fontSize 14; style.fontWeight 525]
                                        prop.children [
                                            Html.text "Prescriber"
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                        prop.children [
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.column; style.alignItems.start; style.fontWeight 550]
                                                prop.children [
                                                    Html.div [
                                                        prop.classes ["has-text-white"; "has-text-weight-bold"; "has-text-centered"]
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
                                                            Html.text (initials props.prescriber)
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.children [
                                                    Html.div [
                                                        prop.style [style.marginLeft 10; style.fontWeight 525; style.color.darkSlateGray]
                                                        prop.children [
                                                            Html.text (props.prescriber)
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [
                            style.marginTop 25;
                            style.marginLeft 10;
                            style.display.flex;
                            style.justifyContent.spaceBetween;
                            style.alignItems.center;  (* This is the added style for vertical centering *)
                            style.borderBottom(1, borderStyle.solid, color.whiteSmoke);
                            style.paddingBottom 10
                        ]
                        prop.children [
                            Html.strong "Prescriptions"
                            Bulma.button.button [
                                Bulma.button.isRounded
                                Bulma.color.isPrimary
                                Bulma.button.isSmall
                                prop.classes [ "has-text-weight-bold"]
                                prop.style [style.borderRadius 3; style.marginRight 10; style.width 130]
                                //prop.style [ style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                prop.children [
                                    Icon [
                                        icon.icon mdi.autorenew
                                        icon.width 15
                                        icon.height 15
                                        icon.color color.white
                                    ]
                                    Html.p [
                                        prop.text "Renew"
                                        prop.style [style.marginLeft 5; style.color.white; style.fontWeight.bold]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Instructions"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text props.instructions
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Pharmacy Notes"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text props.pharmacyNotes
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Quantity"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text props.quantity
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Fills Remaining"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text props.FillsRemaining
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Fills Allowed"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text props.FillsAllowed
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Do Not Fill Before"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text (props.DoNotfillBefore.ToString("MM/dd/yyyy"))
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Expiration"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text (props.ExpirationAsWritten.ToString("MM/dd/yyyy"))
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "Expiration"
                                ]
                            ]
                            Html.div [
                                let dispenseAsWrittenText a =
                                    match a with
                                    | true -> "Yes"
                                    | false -> "No"
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text (dispenseAsWrittenText props.DispenseAsWritten)
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceBetween; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.style [style.color.lightSlateGray; style.marginLeft 10; style.fontSize 15; style.width 150]
                                prop.children [
                                    Html.text "External ID"
                                ]
                            ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.fontSize 15; style.flexGrow 1; style.flexShrink 1; style.flexBasis 0]
                                prop.children [
                                    Html.text (props.ExternalID)
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [
                            style.marginTop 25;
                            style.marginLeft 10;
                            style.display.flex;
                            style.justifyContent.spaceBetween;
                            style.alignItems.center;  (* This is the added style for vertical centering *)
                            style.borderBottom(1, borderStyle.solid, color.whiteSmoke);
                            style.paddingBottom 10
                        ]
                        prop.children [
                            Html.div [
                                prop.style [style.display.flex; style.flexDirection.column]
                                prop.children [
                                    Html.strong "Pharmacy Orders"
                                    Html.div [
                                        prop.style [style.fontSize 14]
                                        prop.children [
                                            Html.text ("Below are orders that include fills from this prescription.")
                                        ]
                                    ]
                                ]
                            ]
                            Bulma.button.button [
                                Bulma.button.isRounded
                                Bulma.color.isPrimary
                                Bulma.button.isSmall
                                prop.classes [ "has-text-weight-bold"]
                                prop.style [style.borderRadius 3; style.marginRight 10; style.width 130]
                                //prop.style [ style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                prop.children [
                                    Icon [
                                        icon.icon mdi.plusCircle
                                        icon.width 15
                                        icon.height 15
                                        icon.color color.white
                                    ]
                                    Html.p [
                                        prop.text "Create Order"
                                        prop.style [style.marginLeft 5; style.color.white; style.fontWeight.bold]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.border(1, borderStyle.solid, color.whiteSmoke); style.width (length.perc 98); style.alignItems.center; style.margin.auto;style.marginTop 10; style.borderRadius 7]
                        prop.children [
                            Html.div [
                                prop.style [style.margin 10;style.display.flex; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        prop.style [style.marginRight 5; style.fontWeight 550]
                                        prop.children [
                                            Html.text "Your Linda Pharmacy"
                                        ]
                                    ]
                                    PharmacyStatusTags props.PharmacyStatus
                                ]
                            ]
                            Html.div [
                                prop.style [style.margin 10]
                                prop.children [
                                    Html.div [
                                        prop.style [ style.color.lightSlateGray]
                                        prop.children [
                                            Html.text "123 Main Street, Suite 100, Anytown, USA 12345"
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [ style.color.lightSlateGray]
                                        prop.children [
                                            Html.text ("Created:" + "  " + props.dateWritten)
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [
                            style.marginTop 25;
                            style.marginLeft 10;
                            style.display.flex;
                            style.justifyContent.spaceBetween;
                            style.alignItems.center;  (* This is the added style for vertical centering *)
                            style.borderBottom(1, borderStyle.solid, color.whiteSmoke);
                            style.paddingBottom 10
                        ]
                        prop.children [
                            Html.div [
                                prop.style [style.display.flex; style.flexDirection.column]
                                prop.children [
                                    Html.strong "Actions"
                                    Html.div [
                                        prop.style [style.fontSize 14; style.maxWidth (length.perc 90)]
                                        prop.children [
                                            Html.text ("Canceling a prescription will prevent any team member from adding the prescription fills in a new order.")
                                        ]
                                    ]
                                ]
                            ]
                            Bulma.button.button [
                                Bulma.button.isRounded
                                Bulma.color.isDanger
                                Bulma.button.isOutlined
                                Bulma.button.isSmall
                                //prop.classes [ "has-text-weight-bold"; "has-text-danger"]
                                prop.style [style.borderRadius 3; style.marginRight 10; style.width 130]
                                //prop.style [ style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                prop.children [
                                    Html.p [
                                        prop.text "Cancel Prescription"
                                        prop.style [ style.fontWeight.bold]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]


let renderOrderDetail () =
    ePrescribeOrderDetail simulatedData
