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
open Healix.Components.EditableTag
open Healix.Components.EditablePatientProfileCard

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

type MedicalHistoryData = {
    Title: string
    ImgSrc: string
    Width: int
    //Height: int
}

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
    ["Heart Rate"; "HR"; "4"; "Moderate"];
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
        prop.style [style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12]
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
        prop.style [style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12; style.height 400;  style.overflowY.auto]
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



let MedicalHistoryComponent (props:MedicalHistoryData) =
    let (tags, setTags) = React.useState List.empty  // Initial state is an empty array
    let (isEditing, setEditing) = React.useState false
    let (isDeletable, setDeletable) = React.useState false
    let (newTagText, setNewTagText) = React.useState ""

    let handleKeyDown (event: Browser.Types.KeyboardEvent) =
        if event.key = "Enter" && newTagText.Length > 0 then
            setTags (newTagText :: tags)  // Add the new tag to the array
            setNewTagText ""  // Clear the new tag text
            setEditing false  // Exit editing mode

    let handleInputChange value =
        setNewTagText value

    let handleTagButtonClick () =
        setEditing true

    let handleEditButtonClick () =
        setDeletable true

    let handleDeleteTag tagText =
        setTags (tags |> List.filter (fun tag -> tag <> tagText))

    Html.div [
        prop.style [style.display.flex; style.width (length.perc props.Width); style.border(1, borderStyle.solid, color.whiteSmoke); style.borderRadius 5]
        prop.children [
            Bulma.image [
                prop.style [ style.margin 10]
                Bulma.image.is32x32
                prop.children [
                    Html.img [
                        prop.alt "Placeholder image"
                        prop.src props.ImgSrc
                    ]
                ]
            ]
            Html.div [
                prop.style [style.display.flex; style.flexDirection.column; style.width (length.perc 100)]
                prop.children [
                    Html.div [
                        prop.style [style.display.flex; style.alignItems.center; style.justifyContent.spaceBetween; style.width (length.perc 100); style.marginTop 5]
                        prop.children [
                            Html.span [
                                prop.text (props.Title)
                                prop.style [style.fontFamily "Inter"; style.fontWeight 400; style.fontSize 13; style.color.black; style.border(0, borderStyle.none, color.transparent); style.marginRight 5]

                            ]
                            Html.div [
                                prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                prop.children [
                                    Bulma.icon [
                                        Bulma.icon.isSmall
                                        prop.style [style.marginRight 5; style.display.flex; style.alignItems.center]
                                        prop.onClick (fun _ -> handleTagButtonClick ())
                                        prop.children [
                                            Icon [
                                                icon.icon mdi.addCircle
                                                icon.color "#2868bd"
                                                icon.width 18
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [style.color.gray; style.fontSize 13; style.marginRight 10]
                                        prop.onClick (fun _ -> handleEditButtonClick ())
                                        prop.children [
                                            Html.text "Edit"
                                        ]
                                    ]

                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex;style.alignItems.center]
                        prop.children [
                            if isEditing then
                                Html.input [
                                    prop.style [
                                        style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px");
                                        style.width (length.perc 30)
                                        style.borderRadius 12
                                        style.fontSize 12
                                    ]
                                    prop.defaultValue newTagText
                                    prop.className classes.inputTag
                                    prop.autoFocus true
                                    prop.onChange handleInputChange
                                    prop.onKeyDown (fun event -> handleKeyDown event)
                                ]
                            Html.div [
                                prop.style [style.fontWeight.bold; style.alignItems.center]
                                prop.children (
                                    tags
                                    |> List.map (fun tagText ->
                                        Bulma.tag [
                                            Bulma.color.isWhite
                                            Bulma.tag.isRounded
                                            prop.text tagText
                                            prop.style [style.marginRight 3; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.color.black]
                                            prop.children [
                                                if isDeletable then
                                                    Html.div [
                                                        prop.style [style.marginRight 3]
                                                        prop.text tagText
                                                    ]
                                                    Bulma.icon [  // Add a delete icon to each tag
                                                        Bulma.icon.isSmall
                                                        prop.onClick (fun _ -> handleDeleteTag tagText)  // Wire up the delete handler
                                                        prop.children [
                                                            Icon [
                                                                icon.icon mdi.closeCircle
                                                                icon.color "#FF3860"
                                                                icon.width 15
                                                            ]
                                                        ]
                                                    ]
                                                    else
                                                        Html.div [
                                                            prop.text tagText
                                                    ]
                                            ]
                                        ])
                                )
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]






[<ReactComponent>]
let MedicalHistory () =
    Html.div [
        prop.style [ style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12]
        prop.children [
            Html.div [
                prop.style [style.borderBottom(1, borderStyle.solid, color.lightGray); style.display.flex;style.justifyContent.spaceBetween; style.flexDirection.row; style.display.flex; style.alignItems.center]
                prop.children [
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop 10]
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
                                Bulma.color.isWhite
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
                prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceAround; style.marginTop 10; style.minHeight (length.perc 20)]
                prop.children [
                    MedicalHistoryComponent (
                        {
                            Title = "Chronic Diseases";
                            ImgSrc = ".././Assets/heart-rate.svg"
                            Width = 45
                        }
                    )
                    MedicalHistoryComponent (
                        {
                            Title = "Family History";
                            ImgSrc = ".././Assets/family.svg"
                            Width = 45
                        }
                    )
                ]
            ]
            Html.div [
                prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceAround; style.marginTop 10; style.minHeight (length.perc 20)]
                prop.children [
                    MedicalHistoryComponent (
                        {
                            Title = "Allergies";
                            ImgSrc = ".././Assets/allergies.svg"
                            Width = 45
                        }
                    )
                    MedicalHistoryComponent (
                        {
                            Title = "Health Barriers";
                            ImgSrc = ".././Assets/shield.svg"
                            Width = 45
                        }
                    )
                ]
            ]
            Html.div [
                prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceAround; style.marginTop 10; style.minHeight (length.perc 35)]
                prop.children [
                    MedicalHistoryComponent (
                        {
                            Title = "Tasks";
                            ImgSrc = ".././Assets/allergies.svg"
                            Width = 95
                        }
                    )
                ]
            ]
        ]
    ]

[<ReactComponent>]
let Labs () =
    Html.div [
        prop.style [ style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 12]
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


    Html.div [
        prop.children [
            EditablePatientProfileCard ()
            Html.div [
                prop.style [style.display.flex; style.justifyContent.spaceAround; style.marginTop 20; style.flexWrap.wrap]
                prop.children [
                    Html.div [
                        prop.children [
                            MedicationCard ()
                        ]
                    ]
                    Html.div [
                        prop.style [style.flexWrap.wrap]
                        prop.children [
                            LabResults ()
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.style [style.display.flex; style.justifyContent.spaceAround; style.marginTop 20; style.marginBottom 20; style.flexWrap.wrap]
                prop.children [
                    Html.div [
                        prop.children [
                            AssessmentCard ()
                        ]
                    ]
                    Html.div [
                        prop.style [style.flexWrap.wrap]
                        prop.children [
                            MedicalHistory ()
                        ]
                    ]
                ]
            ]
        ]
    ]
