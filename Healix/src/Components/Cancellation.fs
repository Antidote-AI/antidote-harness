module Healix.Components.Cancellation

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


let private classes : CssModules.Components.Cancellation = import "default" "./Cancellation.module.scss"

// type ListItemProps = {|
//     ListItemIcon: string
//     ListItemTitle: string
//     ListItemSubTitle: string
//     ListItemDate: DateTime
//     ListItemReferenceId: string
//     ListItemAppointmentType: AppointmentType
//     ListItemAppointment: Appointment
//     SelectAppointmentCallBack: string -> unit
//     RefreshCallback: unit -> unit
// |}

// type AppointmentViewerListProps = {|
//     AppointmentList: Antidote.Core.V2.Types.Appointments
//     SelectAppointment: string -> unit
//     SortDescending: bool
//     RefreshCallback: unit -> unit
// |}

[<ReactComponent>]
let StarRating() =
    let (rating, setRating) = React.useState(0)

    Html.div [
        prop.style [style.paddingBottom 15; style.borderBottom(1, borderStyle.solid, color.whiteSmoke)]
        prop.children [
            for i in 1..5 do
                if i <= rating then
                    Html.i [
                        prop.onClick (fun _ -> setRating i)

                        prop.children [
                            Icon [
                                icon.icon mdi.star
                                icon.width 40
                                icon.height 40
                                icon.color "#f4c430"

                            ]
                        ]

                    ]

                else
                    Html.i [
                        prop.onClick (fun _ -> setRating i)
                        prop.children [
                            Icon [
                                icon.icon mdi.starOutline
                                icon.width 40
                                icon.height 40
                                icon.color "#f4c430"

                            ]
                        ]
                    ]
        ]
    ]

[<ReactComponent>]
let Cancellation () =

    let (heartSelected, setHeartSelected) = React.useState(false)
    let (rating, setRating) = React.useState(fun () -> None)

    Html.section [
        //prop.classes ["card"; "m-4"]
        prop.children [

            Html.div [
                //prop.className "container"
                prop.style [style.display.flex; style.flexDirection.column; style.marginLeft 40; style.margin 10]
                prop.children [
                    Bulma.title [
                        title.is6
                        prop.text "Reason for schedule change"
                        prop.style [style.color.black; style.marginBottom 0]
                    ]
                    Html.form [
                        prop.style [style.margin 5]
                        prop.children [
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                    // prop.isChecked true
                                ]
                                Html.span "I want to change to another doctor"
                            ]
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                ]
                                Html.span "I'm scared I cannot afford the visit"
                            ]
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                ]
                                Html.span "I no longer want a consultation anymore"
                            ]
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                ]
                                Html.span "I found suitable medication"
                            ]
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                ]
                                Html.span "I plan to seek treament elsewhere"
                            ]
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                ]
                                Html.span "I just want to cancel"
                            ]
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                ]
                                Html.span "I prefer not to say"
                            ]
                            Html.label [
                                Html.input [
                                    prop.type' "radio"
                                    prop.name "radio"
                                ]
                                Html.span "Other"
                            ]
                            Bulma.textarea [
                                prop.classes ["textarea"]
                                prop.style [style.width 300; style.height 100; style.margin 5]
                                prop.placeholder "Please provide other details here..."
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.style [ style.display.flex; style.justifyContent.center]
                prop.children [
                    Bulma.button.button [
                        Bulma.button.isRounded
                        Bulma.color.isPrimary
                        // Bulma.button.isFullWidth
                        // prop.onClick (fun _ ->
                        //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
                        // )
                        //prop.style[ ]
                        prop.text "Submit"
                        prop.style [
                            style.width (length.perc 90)
                            style.fontSize 17
                        ]
                    ]
                ]
            ]
        ]
    ]








//working buttons:

// Html.div [
//     prop.classes ["is-flex"; "is-flex-grow-1"]
//     prop.children [
//         Html.button [
//             prop.classes [ "button"; "is-rounded"; "is-primary"; "is-outlined"; "is-size-6"; "px-6"; "is-fullwidth"]
//             prop.className [classes.buttonContainer;classes.buttonContainer2]
//             prop.text "Cancel Appointment"
//         ]
//     ]
// ]
// Html.div [
//     prop.classes ["is-flex"; "is-flex-grow-1"]
//     prop.children [
//         Html.button [
//             prop.classes [ "button"; "is-primary"; "is-rounded"; "is-primary"; "is-size-6"; "px-6"; "is-fullwidth"]
//             prop.className [classes.buttonContainer;classes.buttonContainer2]
//             prop.text "Reschedule"
//         ]
//     ]
// ]
