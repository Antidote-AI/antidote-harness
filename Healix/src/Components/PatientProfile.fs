module Healix.Components.PatientProfile

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
open Healix.Components.LabResults

emitJsStatement () "import React from \"react\""

let private classes : CssModules.Components.PatientProfile = import "default" "./PatientProfile.module.scss"

type PatientData = {
    FirstName : string
    LastName : string
    Email : string
    Phone : string
    DOB : string
    Gender : string
    Address : string
    HealthPlan : string
    InsurancePlan : string
    GroupID : string
    MemberID : string
}

type EditableNameProps = {
    InitialName: string
}

type EditableNameState = {
    CurrentName: string
    IsEditing: bool
}

[<ReactComponent>]
let PatientProfileCard () =
    Html.div [
        prop.style [ style.display.flex; style.justifyContent.center; style.flexDirection.column; style.width (length.perc 100); style.flexGrow 1; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
        prop.children [
            Html.div [
                prop.className [classes.myDiv]
                prop.children [
                    Html.div [
                        prop.className [classes.responsiveFlexContainer]
                        prop.style [ style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop 10; style.marginBottom 10; style.flexWrap.wrap; style.width (length.perc 100)]
                        prop.children [
                            Html.div [
                                prop.children [
                                    Html.img [
                                        prop.style [style.marginLeft 10; style.width 75; style.height 75; style.custom ("boxShadow", "rgba(0, 0, 0, 0.16) 0px 10px 36px 0px");style.border(3, borderStyle.solid, color.white)]
                                        prop.src ".././Assets/alan-katz.jpg"
                                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.width (length.perc 90)]
                                prop.classes ["appointmentViewerList__container-content"]
                                prop.children [
                                    Html.div [
                                        prop.className [classes.flexToCenter]
                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                        prop.className [classes.flexToCenter]
                                        prop.style [
                                            style.fontFamily "Inter";
                                            style.fontWeight.bold;
                                            style.fontSize 17;
                                            style.color.black;
                                            style.display.flex;
                                            style.justifyContent.flexStart;
                                            style.alignItems.center;
                                        ]
                                        prop.children [
                                            Html.div [
                                                prop.style [
                                                    style.display.flex;
                                                    style.justifyContent.spaceBetween;
                                                    style.alignItems.center;
                                                    style.flexWrap.wrap; (* This ensures wrapping behavior *)
                                                    style.width (length.perc 100)
                                                ]
                                                prop.children [
                                                    Html.div [
                                                        prop.className classes.nameAndTags (* This class will be targeted in the media query for mobile adjustments *)
                                                        prop.style [style.display.flex; style.alignItems.center]
                                                        prop.children [
                                                            // if isEditMode then
                                                            //     Html.span [
                                                            //         "Hello"
                                                            //         // prop.value patientData.FirstName
                                                            //         // prop.style [style.fontFamily "Inter"; style.fontSize 17; style.color.black; style.border(0, borderStyle.none, color.transparent); style.marginRight 5]
                                                            //         // prop.onInput (fun e -> setPatientData {patientData with FirstName = e.target?value})
                                                            //     ]
                                                            // else
                                                            //     Html.span [
                                                            //         prop.text ("Alex" + " " + "Campo")
                                                            //     ]
                                                            Html.span "Hello"

                                                            Html.div [
                                                                prop.style [ style.display.flex; style.flexDirection.row; style.justifyContent.flexEnd; style.alignItems.center; style.marginLeft 5 ]
                                                                prop.className [classes.marginTop; classes.nameAndTags]
                                                                prop.children [
                                                                    Bulma.tag [
                                                                        Bulma.color.isPrimary
                                                                        Bulma.color.isLight
                                                                        prop.classes ["has-text-primary"; "has-text-weight-bold"]
                                                                        prop.className classes.marginBottom
                                                                        prop.style [style.marginRight 10]
                                                                        prop.children [
                                                                            Icon [
                                                                                icon.icon mdi.email
                                                                                icon.width 14
                                                                                icon.height 14
                                                                            ]
                                                                            Html.p [
                                                                                prop.text "alexcampo3695@gmail.com"
                                                                                prop.style [style.marginLeft 5]
                                                                            ]
                                                                        ]
                                                                    ]
                                                                    Bulma.tag [
                                                                        Bulma.color.isPrimary
                                                                        Bulma.color.isLight
                                                                        prop.classes ["has-text-primary"; "has-text-weight-bold"]
                                                                        prop.style [style.marginRight 5]
                                                                        prop.children [
                                                                            Icon [
                                                                                icon.icon mdi.phone
                                                                                icon.width 14
                                                                                icon.height 14
                                                                            ]
                                                                            Html.p [
                                                                                prop.text "305-206-4761"
                                                                                prop.style [style.marginLeft 5]
                                                                            ]
                                                                        ]
                                                                    ]
                                                                ]
                                                            ]
                                                        ]
                                                    ]
                                                    Html.div [
                                                        prop.className [classes.nameAndTags; classes.editButton]
                                                        prop.style [
                                                            style.position.absolute; (* This positions the button *)
                                                            style.top 20;             (* Aligns the button to the top of the container *)
                                                            style.right 10;           (* Aligns the button to the right of the container *)
                                                        ]
                                                        prop.children [
                                                            Bulma.button.button [
                                                                Bulma.color.isPrimary
                                                                Bulma.button.isInverted
                                                                Bulma.button.isSmall
                                                                prop.classes [ "has-text-weight-bold"]
                                                                prop.style [style.marginRight 10; style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                                                prop.children [
                                                                    Icon [
                                                                        icon.icon mdi.squareEditOutline
                                                                        icon.width 20
                                                                        icon.height 20
                                                                        icon.color color.dimGray
                                                                    ]
                                                                    Html.p [
                                                                        prop.text "Edit"
                                                                        prop.style [style.marginLeft 5]
                                                                    ]
                                                                ]
                                                            ]
                                                            Bulma.button.button [
                                                                Bulma.color.isPrimary
                                                                Bulma.button.isInverted
                                                                Bulma.button.isSmall
                                                                prop.classes [ "has-text-weight-bold"]
                                                                prop.style [style.marginRight 10; style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                                                prop.children [
                                                                    Icon [
                                                                        icon.icon mdi.ellipsisHorizontal
                                                                        icon.width 20
                                                                        icon.height 20
                                                                        icon.color color.dimGray
                                                                    ]
                                                                    Html.p [
                                                                        prop.text "Actions"
                                                                        prop.style [style.marginLeft 5]
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
                                        prop.classes [classes.flexToCenter]
                                        prop.style [style.display.flex; style.flexWrap.wrap]
                                        prop.children [
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-calendar"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("03/06/1995")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-user"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("Male")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-globe"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("English")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-location-arrow"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("2020 N bayshore Drive, 1806")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.classes [classes.flexToCenter]
                                        prop.style [style.display.flex; style.flexWrap.wrap]
                                        prop.children [
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-hospital"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("Aetna")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-check"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("Aetna Open ACC Mngd")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex;style.flexWrap.wrap]
                                                prop.children [
                                                    Html.div [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.display.flex]
                                                        prop.children [
                                                            Html.div [
                                                                prop.style [style.fontWeight.bold; style.color.black]
                                                                prop.children [
                                                                    Html.text ("Group ID:")
                                                                ]
                                                            ]
                                                            Html.div [
                                                                prop.style [style.color.dimGray; style.marginLeft 5]
                                                                prop.children [
                                                                    Html.text ("123456789")
                                                                ]
                                                            ]
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex;style.flexWrap.wrap]
                                                prop.children [
                                                    Html.div [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.display.flex]
                                                        prop.children [
                                                            Html.div [
                                                                prop.style [style.fontWeight.bold; style.color.black]
                                                                prop.children [
                                                                    Html.text ("Member ID:")
                                                                ]
                                                            ]
                                                            Html.div [
                                                                prop.style [style.color.dimGray; style.marginLeft 5]
                                                                prop.children [
                                                                    Html.text ("123456789")
                                                                ]
                                                            ]
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]

                                    // Html.div [
                                    //     prop.className [classes.flexToCenter; classes.stack]
                                    //     prop.style [style.display.flex]
                                    //     prop.children [

                                    //         Html.p [
                                    //             prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                    //             prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                    //             prop.children [
                                    //                 Html.i [
                                    //                     prop.classes [ "fas"; "fa-location-arrow"]
                                    //                     prop.style [style.marginRight 5; style.color.black]
                                    //                 ]
                                    //                 Html.text ("2020 N Bayshore Drive, 1806")
                                    //             ]
                                    //         ]
                                    //     ]
                                    // ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

let headers: string list = ["Medication"; "Dosage"; "Frequency"; "Notes"]

let rowData: string list list = [
    ["Paracetamol"; "500mg"; "Every 6 hours"; "Take after meals"];
    ["Ibuprofen"; "200mg"; "Every 8 hours"; "Avoid alcohol"];
    ["Paracetamol"; "500mg"; "Every 6 hours"; "Take after meals"];
    ["Ibuprofen"; "200mg"; "Every 8 hours"; "Avoid alcohol"];
    ["Paracetamol"; "500mg"; "Every 6 hours"; "Take after meals"];
    ["Ibuprofen"; "200mg"; "Every 8 hours"; "Avoid alcohol"];
    ["Paracetamol"; "500mg"; "Every 6 hours"; "Take after meals"];
    ["Ibuprofen"; "200mg"; "Every 8 hours"; "Avoid alcohol"];
    ["Paracetamol"; "500mg"; "Every 6 hours"; "Take after meals"];
    ["Ibuprofen"; "200mg"; "Every 8 hours"; "Avoid alcohol"];
    ["Paracetamol"; "500mg"; "Every 6 hours"; "Take after meals"]
]

let headerAssessment: string list = ["Assessment"; "Date"; "Score"; "Severity"]

let assessmentData: string list list = [
    ["Temperature"; "TMP"; "4"; "High"];
    ["Temperature"; "TMP"; "3"; "Critical"];
    ["Respiration Rate"; "RR"; "10"; "Moderate"];
    ["Blood Pressure"; "BP"; "7"; "Critical"];
    ["Temperature"; "TMP"; "6"; "Low"];
    ["Heart Rate"; "HR"; "8"; "High"];
    ["Temperature"; "TMP"; "9"; "Moderate"];
    ["Respiration Rate"; "RR"; "2"; "Low"];
    ["Oxygen Saturation"; "OS"; "4"; "Critical"];
    ["Heart Rate"; "HR"; "4"; "Moderate"]
]



[<ReactComponent>]
let MedicationCard () =
    Html.div [
        prop.style [style.width (length.perc 45); style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12]
        prop.children [
            Html.div [
                prop.style [style.borderBottom(1, borderStyle.solid, color.lightGray); style.display.flex;style.justifyContent.spaceBetween; style.flexDirection.row; style.display.flex; style.alignItems.center]
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
                        prop.style [ style.color.dimGray; style.margin 10]
                        prop.children [
                            Bulma.button.button [
                                Bulma.button.isRounded
                                Bulma.color.isPrimary
                                Bulma.button.isSmall
                                prop.classes [ "has-text-weight-bold"]
                                //prop.style [ style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                prop.children [
                                    Icon [
                                        icon.icon mdi.plusCircle
                                        icon.width 15
                                        icon.height 15
                                        icon.color color.white
                                    ]
                                    Html.p [
                                        prop.text "Add"
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
                        Html.tr (headers |> List.map (fun header -> Html.th [prop.text header]))
                    ]
                    Html.tbody (
                        rowData |> List.map (fun row ->
                            Html.tr (row |> List.map (fun cell -> Html.td [prop.text cell]))
                        )
                    )
                ]
            ]
        ]
    ]

let AssessmentCard () =
    Html.div [
        prop.style [style.width (length.perc 25); style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12]
        prop.children [
            Html.div [
                prop.style [style.borderBottom(1, borderStyle.solid, color.lightGray); style.display.flex;style.justifyContent.spaceBetween; style.flexDirection.row; style.display.flex; style.alignItems.center]
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
                                                prop.src ".././Assets/compliance.svg"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.marginLeft 5]
                                prop.children [
                                    Html.strong "Assessments"
                                ]
                            ]
                        ]
                    ]

                    Html.div [
                        prop.style [ style.color.dimGray; style.margin 10]
                        prop.children [
                            Bulma.button.button [
                                Bulma.button.isRounded
                                Bulma.color.isPrimary
                                Bulma.button.isSmall
                                prop.classes [ "has-text-weight-bold"]
                                //prop.style [ style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                prop.children [
                                    Icon [
                                        icon.icon mdi.plusCircle
                                        icon.width 15
                                        icon.height 15
                                        icon.color color.white
                                    ]
                                    Html.p [
                                        prop.text "Add"
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
                        Html.tr (headerAssessment |> List.map (fun header -> Html.th [prop.text header]))
                    ]
                    Html.tbody (
                        assessmentData |> List.map (fun row ->
                            Html.tr (row |> List.map (fun cell -> Html.td [prop.text cell]))
                        )
                    )
                ]
            ]
        ]
    ]

[<ReactComponent>]
let MedicalHistory () =
    Html.div [
        prop.style [style.width (length.perc 70); style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12]
        prop.children [
            Html.div [
                prop.style [style.borderBottom(1, borderStyle.solid, color.lightGray); style.display.flex;style.justifyContent.spaceBetween; style.flexDirection.row; style.display.flex; style.alignItems.center]
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
                                                prop.src ".././Assets/medical-history.svg"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.marginLeft 5]
                                prop.children [
                                    Html.strong "Medical History"
                                ]
                            ]
                        ]
                    ]

                    Html.div [
                        prop.style [ style.color.dimGray; style.margin 10]
                        prop.children [
                            Bulma.button.button [
                                Bulma.button.isRounded
                                Bulma.color.isPrimary
                                Bulma.button.isSmall
                                prop.classes [ "has-text-weight-bold"]
                                //prop.style [ style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                prop.children [
                                    Icon [
                                        icon.icon mdi.plusCircle
                                        icon.width 15
                                        icon.height 15
                                        icon.color color.white
                                    ]
                                    Html.p [
                                        prop.text "Add"
                                        prop.style [style.marginLeft 5; style.color.white; style.border(0, borderStyle.none, color.transparent); style.fontWeight.bold]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceAround; style.marginTop 10]
                prop.children [
                    Html.div [
                        prop.style [style.display.flex; style.width (length.perc 45); style.border(1, borderStyle.solid, color.lightGray); style.borderRadius 5]
                        prop.children [
                            Bulma.image [
                                prop.style [ style.margin 10]
                                Bulma.image.is32x32
                                prop.children [
                                    Html.img [
                                        prop.alt "Placeholder image"
                                        prop.src ".././Assets/heart-disease.svg"
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.marginLeft 5; style.display.flex; style.flexDirection.column]
                                prop.children [
                                    Html.span [
                                        prop.text "Chronic Diseases"
                                        prop.style [style.fontFamily "Inter"; style.fontWeight 500 ;style.fontSize 17; style.color.gray; style.border(0, borderStyle.none, color.transparent); style.marginRight 5]

                                    ]
                                    Html.strong [
                                        prop.text "Hello"
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.width (length.perc 45); style.border(1, borderStyle.solid, color.lightGray); style.borderRadius 5]
                        prop.children [
                            Bulma.image [
                                prop.style [style.marginLeft 5]
                                Bulma.image.is24x24
                                prop.children [
                                    Html.img [
                                        prop.alt "Placeholder image"
                                        prop.src ".././Assets/medical-history.svg"
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.marginLeft 5; style.display.flex; style.flexDirection.column]
                                prop.children [
                                    Html.strong [
                                        prop.text "Medical History"
                                        prop.style [style.fontFamily "Inter"; style.fontSize 17; style.color.gray; style.border(0, borderStyle.none, color.transparent); style.marginRight 5]

                                    ]
                                    Html.strong [
                                        prop.text "Hello"
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]

            ]
        ]
    ]

[<ReactComponent>]
let Labs () =
    Html.div [
        prop.style [style.width (length.perc 45); style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12]
        prop.children [
            LabResults ()
        ]
    ]

[<ReactComponent>]
let PatientProfile () =

    let initialPatientData = {
        FirstName = "Alex";
        LastName = "Campo";
        Email = "alexcampo3695@gmail.com";
        Phone = "305-206-4761";
        DOB = "03/06/1995";
        Gender = "Male";
        Address = "2020 N bayshore Drive, 1806";
        HealthPlan = "Aetna";
        InsurancePlan = "Aetna Open ACC Mngd";
        GroupID = "123456789";
        MemberID = "123456789";
    }
    let (patientData, setPatientData) = React.useState initialPatientData
    let (isEditMode, setEditMode) = React.useState false
    let handleEditClick _ =
        setEditMode (not isEditMode)

    Html.div [
        prop.children [
            PatientProfileCard ()
            Html.div [
                prop.style [style.display.flex; style.justifyContent.spaceAround; style.marginTop 20]
                prop.children [
                    MedicationCard ()
                    Labs ()
                ]
            ]
            Html.div [
                prop.style [style.display.flex; style.justifyContent.spaceAround; style.marginTop 20]
                prop.children [
                    AssessmentCard ()
                    MedicalHistory ()
                ]
            ]


        ]
    ]
