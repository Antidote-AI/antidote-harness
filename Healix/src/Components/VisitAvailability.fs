module Healix.Components.VisitAvailability

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


let private classes : CssModules.Components.VisitAvailability = import "default" "./VisitAvailability.module.scss"



type AppointmentType =
    | OfficeVisit
    | VideoVisit
    | NoneSelected

type AppointmentDate = {
    Date: System.DateTime
    AvailableTimes: string list
}

let sampleData = [
    { Date = System.DateTime(2023, 9, 15); AvailableTimes = ["9:00 am"; "10:00 am"; "11:30 am"; "9:00 am"; "10:00 am"; "11:30 am"] }
    { Date = System.DateTime(2023, 9, 16); AvailableTimes = ["1:00 pm"; "2:30 pm"; "3:00 pm"] }
]


let renderAppointment (appointment: AppointmentDate) =
    let monthName = match appointment.Date.Month with
                    | 1 -> "Jan"
                    | 2 -> "Feb"
                    | 3 -> "Mar"
                    | 4 -> "Apr"
                    | 5 -> "May"
                    | 6 -> "Jun"
                    | 7 -> "Jul"
                    | 8 -> "Aug"
                    | 9 -> "Sep"
                    | 10 -> "Oct"
                    | 11 -> "Nov"
                    | 12 -> "Dec"
                    | _ -> "Unknown"

    let formattedDate = sprintf "%s %d, %d" monthName appointment.Date.Day appointment.Date.Year

    Html.div [
        prop.children ([
            Html.div [
                prop.style [style.marginTop 15; style.display.flex; style.color.gray]
                prop.children [
                    Html.strong formattedDate
                ]
            ]
        ] @
        [Html.div [
            prop.style [style.display.flex; style.flexDirection.row; style.flexWrap.wrap]
            prop.children
                (appointment.AvailableTimes
                |> List.map (fun time ->
                    Html.div [
                        prop.style [style.fontWeight.bold; style.marginRight 10; style.width 70; style.height 30; style.marginTop 4]  // Fixed width and height for the container
                        prop.children [
                            Bulma.tag [
                                Bulma.color.isPrimary
                                tag.isRounded
                                prop.style [style.display.flex; style.justifyContent.center; style.alignItems.center; style.width (length.px 70); style.height (length.px 30)] // Set fixed width and height for the tag, and center its content
                                prop.text time
                            ]
                        ]
                    ]))
        ]]
        )
    ]




[<ReactComponent>]
let VisitAvailability () =
    Html.section [
        prop.children [
            Html.div [
                prop.style [
                    style.display.flex
                    style.justifyContent.center
                    style.alignItems.center
                ]
                prop.children [
                    Html.div [
                        prop.style [
                            style.width (length.vw 92)
                            style.display.flex
                            style.justifyContent.center
                            style.flexDirection.column
                        ]
                        prop.children [
                            Html.div [
                                prop.style [style.display.flex; style.justifyContent.spaceBetween;style.display.flex;style.marginTop 5; style.borderRadius 12]
                                prop.classes ["has-background-primary-light"]
                                prop.children [
                                    Html.div [
                                        prop.style [style.display.flex]
                                        prop.children [
                                            Html.div [
                                                prop.children [
                                                    Html.img [
                                                        prop.style [style.marginLeft 10; style.width 60; style.height 60; style.custom ("boxShadow", "rgba(0, 0, 0, 0.16) 0px 10px 36px 0px");style.border(2, borderStyle.solid, color.white)]
                                                        prop.src ".././Assets/alan-katz.jpg"
                                                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"; "m-3"]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.center]
                                                prop.children [
                                                    Html.div [
                                                        Html.strong " Alan Katz, MD"
                                                    ]
                                                    Html.div [
                                                        prop.style [style.color.gray; style.fontSize 14]
                                                        prop.children [
                                                            Html.text " Internal Medicine"
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.marginTop 20; style.display.flex]
                                prop.children [
                                    Html.strong "Please choose a day and time below."
                                ]
                            ]
                            Html.div [
                                prop.style [style.marginTop 2; style.display.flex; style.color.gray; style.fontSize 14]
                                prop.children [
                                    Html.text "Tap on any time that day to schedule an appointment."
                                ]
                            ]
                            Html.div [
                                prop.children ( sampleData |> List.map renderAppointment)
                            ]
                        ]
                    ]
                ]
            ]
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
            // Html.div [
            //     prop.children [
            //         Visit ()
            //     ]
            // ]

        ]
    ]
