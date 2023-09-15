module Healix.Components.Visit

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

emitJsStatement () "import React from \"react\""


let private classes : CssModules.Components.Visit = import "default" "./Visit.module.scss"

type WarningProps = {
    WarningTitle: string
    WarningMessage: string
}

type AppointmentType =
    | OfficeVisit
    | VideoVisit
    | NoneSelected

type BehavioralHealthOptions =
    | AnxietyDisorder
    | ADHD
    | AlcoholSubstanceAbuse
    | AutisticDisorder
    | BariatricConsult
    | BariatricReview
    | BipolarDisorder
    | IntellectualDisability
    | MajorDepressiveDisorder
    | PTSD
    | OCD
    | Schizophrenia
    | Psychosis
    | Other

type DiseaseStates =
    | Alzheimers
    | Bariatrics
    | BehavioralHealth
    | Cardiology
    | CardiothoracicSurgery
    | ColonRectalSurgery
    | Dermatology
    | Endocrinology
    | Gastrenterology
    | GeneralSurgery
    | Genetics
    | GynecologicOncology
    | Gynecology
    | PrimaryCare
    | InfectiousDisease
    | Oncology
    | NuerointerventionalRadiology
    | Neurosurgery
    | Obstetrics
    | OrthopedicSurgery
    | PulmonaryMedicine
    | RadiationOncology
    | SurgicalOncology
    | Urology
    | VascaularSurgery

let diseaseStateToString state =
    match state with
    | Alzheimers                  -> "Alzheimer's"
    | Bariatrics                  -> "Bariatrics"
    | BehavioralHealth            -> "Behavioral Health"
    | Cardiology                  -> "Cardiology"
    | CardiothoracicSurgery       -> "Cardiothoracic Surgery"
    | ColonRectalSurgery          -> "Colon Rectal Surgery"
    | Dermatology                 -> "Dermatology"
    | Endocrinology               -> "Endocrinology"
    | Gastrenterology             -> "Gastrenterology"
    | GeneralSurgery              -> "General Surgery"
    | Genetics                    -> "Genetics"
    | GynecologicOncology         -> "Gynecologic Oncology"
    | Gynecology                  -> "Gynecology"
    | PrimaryCare                 -> "Primary Care"
    | InfectiousDisease           -> "Infectious Disease"
    | Oncology                    -> "Oncology"
    | NuerointerventionalRadiology-> "Neurointerventional Radiology"
    | Neurosurgery                -> "Neurosurgery"
    | Obstetrics                  -> "Obstetrics"
    | OrthopedicSurgery           -> "Orthopedic Surgery"
    | PulmonaryMedicine           -> "Pulmonary Medicine"
    | RadiationOncology           -> "Radiation Oncology"
    | SurgicalOncology            -> "Surgical Oncology"
    | Urology                     -> "Urology"
    | VascaularSurgery            -> "Vascular Surgery"

let behavioralHealthOptionToString option =
    match option with
    | AnxietyDisorder -> "Anxiety Disorder"
    | ADHD -> "ADHD - Attention-Deficit Hyperactivity Disorder"
    | AlcoholSubstanceAbuse -> "Alcohol/Substance Abuse"
    | AutisticDisorder -> "Autistic Disorder"
    | BariatricConsult -> "Bariatric Consult for Clearance"
    | BariatricReview -> "Bariatric Review w/ Psychologist"
    | BipolarDisorder -> "Bipolar Disorder"
    | IntellectualDisability -> "Intellectual disability"
    | MajorDepressiveDisorder -> "Major Depressive Disorder"
    | PTSD -> "PTSD - Post Traumatic Stress Disorder"
    | OCD -> "OCD - Obsessive Compulsive Disorder"
    | Schizophrenia -> "Schizophrenia"
    | Psychosis -> "Psychosis"
    | Other -> "Other"

let allDiseaseStates =
    [
        Alzheimers
        Bariatrics
        BehavioralHealth
        Cardiology
        CardiothoracicSurgery
        ColonRectalSurgery
        Dermatology
        Endocrinology
        Gastrenterology
        GeneralSurgery
        Genetics
        GynecologicOncology
        Gynecology
        PrimaryCare
        InfectiousDisease
        Oncology
        NuerointerventionalRadiology
        Neurosurgery
        Obstetrics
        OrthopedicSurgery
        PulmonaryMedicine
        RadiationOncology
        SurgicalOncology
        Urology
        VascaularSurgery
    ]

let allBehavioralHealthOptions = [
    AnxietyDisorder
    ADHD
    AlcoholSubstanceAbuse
    AutisticDisorder
    BariatricConsult
    BariatricReview
    BipolarDisorder
    IntellectualDisability
    MajorDepressiveDisorder
    PTSD
    OCD
    Schizophrenia
    Psychosis
    Other
]

let warningMessage = [{ WarningTitle = "Warning"; WarningMessage = "Please be aware the self-pay cost for a visit can range from $250.00 to $600.000 depensing on services provided"}]


[<ReactComponent>]
let Visit () =
    let (selectedOption, setSelectedOption) = React.useState<string option>(None)
    let (isDropdownActive, setIsDropdownActive) = React.useState false
    let (selectedAppointment, setSelectedAppointment) = React.useState<AppointmentType option>(None)


    Html.section [
        prop.children [
            Html.div [
                prop.style [
                    style.display.flex
                    style.justifyContent.center
                    style.alignItems.center
                    //style.flexDirection.column
                ]
                prop.children [
                    Html.div [
                        prop.style [
                            style.width (length.vw 98)
                            style.display.flex
                            style.justifyContent.center
                            style.flexDirection.column
                        ]
                        prop.children [
                            Html.div [
                                prop.style [style.marginTop 20; style.display.flex]
                                prop.children [
                                    Html.strong "What type of appointment are you scheduling?"
                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.justifyContent.spaceBetween;style.display.flex;style.marginTop 5; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                                prop.onClick (fun _ -> setSelectedAppointment (Some OfficeVisit))
                                prop.children [
                                    Html.div [
                                        prop.style [style.display.flex]
                                        prop.children [
                                            Html.img [
                                                    prop.classes ["m-3"]
                                                    prop.alt "Placeholder image"
                                                    prop.src "/images/doctor.svg"
                                                    prop.style [style.width 40; style.height 40; style.display.flex; style.alignContent.center]
                                                ]
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.center]
                                                prop.children [
                                                    Html.div [
                                                        Html.strong " Schedule an Office Visit"
                                                    ]
                                                    Html.div [
                                                        prop.style [style.color.gray; style.fontSize 14]
                                                        prop.children [
                                                            Html.text " Schedule an in person office visit"
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                    if selectedAppointment = Some OfficeVisit then
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center; style.marginRight 10]
                                            prop.children [
                                                Html.label [
                                                    Html.input [
                                                        prop.type' "radio"
                                                        prop.name "radio"
                                                        prop.isChecked true
                                                    ]
                                                    //Html.span "I scheduled the wrong time"
                                                ]
                                            ]
                                        ]
                                    else Html.none
                                ]
                            ]

                            Html.div [
                                prop.style [style.display.flex; style.justifyContent.spaceBetween;style.display.flex;style.marginTop 5; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                                prop.onClick (fun _ -> setSelectedAppointment (Some VideoVisit))
                                prop.children [
                                    Html.div [
                                        prop.style [style.display.flex]
                                        prop.children [
                                            Html.img [
                                                    prop.classes ["m-3"]
                                                    prop.alt "Placeholder image"
                                                    prop.src "/images/laptop.svg"
                                                    prop.style [style.width 40; style.height 40; style.display.flex; style.alignContent.center]
                                                ]
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.center]
                                                prop.children [
                                                    Html.div [
                                                        Html.strong " Schedule Video Visit"
                                                    ]
                                                    Html.div [
                                                        prop.style [style.color.gray; style.fontSize 14]
                                                        prop.children [
                                                            Html.text " Schedule a video visit"
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                    if selectedAppointment = Some VideoVisit then
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center; style.marginRight 10]
                                            prop.children [
                                                Html.label [
                                                    Html.input [
                                                        prop.type' "radio"
                                                        prop.name "radio"
                                                        prop.isChecked true
                                                    ]
                                                    //Html.span "I scheduled the wrong time"
                                                ]
                                            ]
                                        ]
                                    else Html.none
                                ]
                            ]

                            Html.div [
                                //prop.style [style.display.flex; style.justifyContent.center; style.flexDirection.column; style.width (length.perc 100); style.alignContent.center; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        prop.style [style.marginTop 20; style.display.flex]
                                        prop.children [
                                            Html.strong "What is the reason for your visit?"
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.justifyContent.center]
                                prop.children [
                                    Bulma.dropdown [
                                        if isDropdownActive then dropdown.isActive
                                        prop.children [
                                            Bulma.dropdownTrigger [
                                                Bulma.button.button [
                                                    button.isFullWidth
                                                    //button.isSmall
                                                    //prop.onClick (fun _ -> setIsTypeDropdownActive (not isTypeDropdownActive))
                                                    prop.onClick (fun _ -> setIsDropdownActive (not isDropdownActive))

                                                    //prop.onBlur (fun _ -> setIsTypeDropdownActive false)
                                                    prop.style [style.width (length.vw 99); style.display.flex; style.justifyContent.spaceBetween; style.borderColor.whiteSmoke]
                                                    prop.children [
                                                        Html.div [
                                                            prop.style [style.display.flex; style.justifyContent.flexStart; style.fontSize 14]
                                                            prop.children [
                                                                Html.text (match selectedOption with
                                                                    | None -> "Select an option"
                                                                    | Some opt -> opt)
                                                            ]
                                                        ]

                                                        Html.div [
                                                            prop.style [style.marginLeft 15]
                                                            prop.children [
                                                                Bulma.icon [
                                                                    //Bulma.icon.isLeft
                                                                    prop.children [
                                                                        Html.i [ prop.className "fas fa-chevron-down" ]
                                                                    ]
                                                                ]
                                                            ]

                                                        ]
                                                    ]
                                                ]
                                            ]
                                            if isDropdownActive then
                                                Bulma.dropdownMenu [
                                                    for option in allBehavioralHealthOptions do
                                                        yield Bulma.dropdownItem.a [
                                                            prop.onClick (fun _ -> setSelectedOption (Some (behavioralHealthOptionToString option)); setIsDropdownActive false)
                                                            prop.text (behavioralHealthOptionToString option)
                                                        ]
                                                ]
                                            else
                                                Html.none
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            if selectedOption.IsSome && (not isDropdownActive) && selectedAppointment.IsSome then
                Html.div [
                    prop.style [style.display.flex; style.justifyContent.center; style.width (length.perc 98)]
                    prop.children [
                        Bulma.textarea [
                            prop.style [style.marginLeft (length.perc 2); style.marginTop 10]
                            prop.placeholder "Describe the reason for visit here..."
                        ]
                    ]
                ]
                Html.div [
                    prop.style[style.display.flex; style.justifyContent.center]
                    prop.children [
                        Bulma.button.button [
                            Bulma.button.isRounded
                            Bulma.color.isPrimary
                            //prop.className [classes.buttonContainer]
                            prop.style [
                                style.width (length.perc 50)
                                style.fontSize 17
                                style.fontWeight.bold
                                style.display.flex
                                style.justifyContent.center
                                style.position.absolute
                                style.bottom 0
                                style.marginBottom 20
                            ]
                            prop.children [
                                Html.text "Next"
                            ]
                        ]
                    ]

                ]
            else
                Html.none
        ]
    ]

[<ReactComponent>]
let steps () =

    let (step, setStep) = React.useState "step1"

    let nextStep() =
        match step with
        | "step1" ->
            // apply logic for transitioning from step1 to step2
            setStep "step2"
        | "step2" ->
            // apply logic for transitioning from step2 to step3
            setStep "step3"
        | "step3" ->
            // apply logic for transitioning from step3 to step4
            setStep "step4"
        | "step4" ->
            // apply logic for completing the steps
            setStep "complete"
        | _ -> ()

    let progressBarColor() =
        match step with
        | "step1" -> "grey"   // Replace with your desired color for step1
        | "step2" -> "#027f00"   // This is the brand primary color
        | "step3" -> "#027f00"   // This is the brand primary color
        | "step4" -> "#027f00"   // This is the brand primary color
        | _ -> "grey"

    Html.div [
        prop.style [style.marginTop 20]
        prop.className "container-fluid"
        prop.children [
            Html.ul [
                prop.classes [classes.multiSteps] //[ "list-unstyled"; "multi-steps" ]
                prop.children [
                    Html.li [
                        prop.className (if step = "step1" then classes.isActive else "")
                        prop.id "step-1"
                        prop.children [
                            Html.text "Start"
                            Html.div [
                                prop.classes [classes.progressBar]
                                prop.style [ style.backgroundColor (progressBarColor()) ]  // Set the background color here
                                prop.children [
                                    Html.div [
                                        prop.className classes.progressBar_bar
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.li [
                        prop.id "step-2"
                        prop.className (if step = "step2" then classes.isActive else "")
                        prop.children [
                            Html.text "First Step"
                            Html.div [
                                prop.classes [classes.progressBar]
                                prop.style [ style.backgroundColor (progressBarColor()) ]  // Set the background color here
                                prop.children [
                                    Html.div [
                                        prop.className classes.progressBar_bar
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.li [
                        prop.id "step-3"
                        prop.className (if step = "step3" then classes.isActive else "")
                        prop.children [
                            Html.text "Middle Stage"
                            Html.div [
                                prop.classes [classes.progressBar]
                                prop.style [ style.backgroundColor (progressBarColor()) ]  // Set the background color here
                                prop.children [
                                    Html.div [
                                        prop.className classes.progressBar_bar
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.li [
                        prop.className (if step = "step4" then classes.isActive else "")
                        prop.id "step-4"
                        prop.text "Finish"
                    ]
                ]
            ]
            // Html.div [
            //     Html.button [
            //         prop.text "Next"
            //         prop.onClick (fun _ -> nextStep())
            //     ]
            // ]
            Html.div [
                prop.children [
                    Visit ()
                ]
            ]

        ]
    ]
