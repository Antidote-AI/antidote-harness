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
// open Antidote.Core.V2.Utils.JS

emitJsStatement () "import React from \"react\""


let private classes : CssModules.Components.Visit = import "default" "./Visit.module.scss"

type WarningProps = {
    WarningTitle: string
    WarningMessage: string
}

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

let WarningCard(props:WarningProps) =
    Bulma.card [
        prop.className classes.centerWidth
        prop.children [
            Bulma.cardHeader [
                prop.classes [ "is-danger"; "is-light"; "has-background-danger" ]
                prop.children [
                    Html.div [
                        prop.className [classes.align]
                        prop.classes ["align"]
                        prop.style [style.display.flex; style.alignItems.center]
                        prop.children [
                            Html.span [
                                prop.className ["icon"]
                                prop.style [style.marginRight 7]
                                prop.children [
                                    Icon [
                                        icon.icon mdi.alert
                                        icon.width 25
                                        icon.height 25
                                        icon.color "#FFFFFF"
                                    ]
                                ]
                            ]
                            Html.text props.WarningTitle
                        ]
                    ]
                ]
                prop.style [style.display.flex; style.justifyContent.center; style.alignItems.center; style.color "#FFFFFF"; style.fontSize 25; style.fontWeight.bold; style.paddingTop 10]
            ]

            Bulma.cardContent [
                prop.classes [ "is-danger"; "is-light"; "has-background-danger-light" ]
                prop.style [style.display.flex; style.justifyContent.center]
                prop.children [
                    Html.div [
                        prop.className [classes.textContainer]
                        prop.style [style.fontSize 17; style.color "#FF3366"]
                        prop.children [
                            Html.text props.WarningMessage
                        ]
                    ]
                ]
            ]
            Bulma.level [
                prop.classes [ "has-background-danger-light" ]
                prop.children [
                    Bulma.levelItem [
                        prop.style [
                            style.marginRight 10
                            style.marginBottom 20
                        ]
                        prop.children [
                            Html.div [
                                prop.className [classes.align]
                                prop.classes ["align"]
                                prop.style [style.display.flex; style.alignItems.center; style.color "#FF3366"; style.fontWeight.bold]
                                prop.children [
                                    Html.span [
                                        prop.style [style.display.flex; style.alignItems.center]
                                        prop.className ["icon"]
                                        prop.style [style.marginRight 7]
                                        prop.children [
                                            Icon [
                                                icon.icon mdi.phone
                                                icon.width 20
                                                icon.height 20
                                                icon.color "#FF3366"
                                            ]
                                        ]
                                    ]
                                    Html.text "(850) 487-1111"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]




[<ReactComponent>]
let Visit () =
    let (selectedOption, setSelectedOption) = React.useState<string option>(None)
    let (isDropdownActive, setIsDropdownActive) = React.useState false

    Html.section [
        prop.children [
            Html.div [
                prop.style [style.display.flex; style.flexDirection.row]
                prop.children [
                    Html.div [
                        prop.classes ["has-background-primary-light"]
                        prop.children [
                            Html.img [
                                prop.src ".././Assets/medicalbag.svg"
                                prop.alt "doctor's profile logo"
                                prop.classes [ classes.DoctorImage; "image"; "p-1"; "ml-1"]
                                prop.style [style.width 40; style.height 40; style.width (length.vw 25); style.display.flex; style.justifyContent.center]
                            ]
                        ]
                    ]
                    Html.div [
                        //prop.classes ["has-background-primary-light"]
                        prop.children [
                            Html.img [
                                prop.src ".././Assets/clinic.svg"
                                prop.alt "doctor's profile logo"
                                prop.classes [ classes.DoctorImage; "image"; "p-1"; "ml-1"]
                                prop.style [style.width 40; style.height 40; style.width (length.vw 25); style.display.flex; style.justifyContent.center; style.opacity 0.2]
                            ]
                        ]
                    ]
                    Html.div [
                        //prop.classes ["has-background-primary-light"]
                        prop.children [
                            Html.img [
                                prop.src ".././Assets/clock1.svg"
                                prop.alt "doctor's profile logo"
                                prop.classes [ classes.DoctorImage; "image"; "p-1"; "ml-1"]
                                prop.style [style.width 40; style.height 40; style.width (length.vw 25); style.display.flex; style.justifyContent.center; style.opacity 0.2]
                            ]
                        ]
                    ]
                    Html.div [
                        //prop.classes ["has-background-primary-light"]
                        prop.children [
                            Html.img [
                                prop.src ".././Assets/january.svg"
                                prop.alt "doctor's profile logo"
                                prop.classes [ classes.DoctorImage; "image"; "p-1"; "ml-1"]
                                prop.style [style.width 40; style.height 40; style.width (length.vw 25); style.display.flex; style.justifyContent.center; style.opacity 0.2]
                            ]
                        ]
                    ]
                ]

            ]
            Html.div [
                prop.style [
                    style.display.flex
                    style.justifyContent.center
                    //style.flexDirection.column
                ]
                prop.children [
                    Html.div [
                        prop.style [
                            style.width (length.perc 100)
                            style.display.flex
                            style.justifyContent.center
                            style.flexDirection.column
                        ]
                        prop.children [
                            Html.div [
                                prop.style [style.marginTop 20; style.display.flex; style.marginLeft (length.perc 1)]
                                prop.children [
                                    Html.strong "What type of appointment are you scheduling?"
                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.margin 10; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                                prop.children [
                                    Html.img [
                                            prop.classes ["m-3"]
                                            prop.alt "Placeholder image"
                                            prop.src "/images/doctor.svg"
                                            prop.style [style.width 40; style.height 40; style.display.flex; style.alignContent.center]
                                        ]
                                    Html.div [
                                        prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.center; style.width (length.perc 80)]
                                        prop.children [
                                            Html.div [
                                                Html.strong " Schedule New Patient Office Visit"
                                            ]
                                            Html.div [
                                                prop.style [style.color.gray; style.fontSize 14]
                                                prop.children [
                                                    Html.text " Schedule a general visit as a new patient"
                                                ]
                                            ]
                                        ]
                                    ]

                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.margin 10; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                                prop.children [
                                    Html.img [
                                            prop.classes ["m-3"]
                                            prop.alt "Placeholder image"
                                            prop.src "/images/laptop.svg"
                                            prop.style [style.width 40; style.height 40; style.display.flex; style.alignContent.center]
                                        ]
                                    Html.div [
                                        prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.center; style.width (length.vw 99)]
                                        prop.children [
                                            Html.div [
                                                Html.strong " Schedule Video Visit"
                                            ]
                                            Html.div [
                                                prop.style [style.color.gray; style.fontSize 14]
                                                prop.children [
                                                    Html.text " Schedule a general visit as a new patient"
                                                ]
                                            ]
                                        ]
                                    ]

                                ]
                            ]
                            Html.div [
                                //prop.style [style.display.flex; style.justifyContent.center; style.flexDirection.column; style.width (length.perc 100); style.alignContent.center; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        prop.style [style.marginTop 20; style.display.flex; style.marginLeft (length.perc 1)]
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
                            // Html.div [
                            //     Html.p "Please be aware the self-pay cost for a visit can range from $250.00 to $600.000 depending on services provided"
                            // ]
                            // Html.div [
                            //     prop.style [style.display.flex; style.justifyContent.center; style.textAlign.left;style.color.gray]
                            //     prop.children [
                            //         Html.text "If you are experiencing a medical emergency, any thoughts of suicide, self harm, or harming someone else please call 911 for immediate assistance."
                            //     ]
                            // ]
                            if selectedOption.IsSome && (not isDropdownActive) then
                                Html.div [
                                    prop.style [style.maxWidth (length.perc 99); style.display.flex; style.alignItems.center]
                                    prop.children [
                                        // Bulma.title [
                                        //     title.is6
                                        //     prop.style [style.color.black; style.marginBottom 0; style.marginLeft 5]
                                        //     prop.text "Write a review"
                                        // ]
                                        Bulma.textarea [
                                            prop.classes ["textarea"]
                                            prop.style [ style.height 100]
                                            prop.placeholder "Describe the reason for visit here..."
                                        ]
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
