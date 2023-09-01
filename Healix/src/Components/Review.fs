module Healix.Components.Review

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


let private classes : CssModules.Components.Review = import "default" "./Review.module.scss"

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
        // Render stars
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

[<ReactComponent>]
let Review () =

    let (heartSelected, setHeartSelected) = React.useState(false)
    let (rating, setRating) = React.useState(fun () -> None)

    Html.section [
        //prop.classes ["card"; "m-4"]
        prop.children [
            Bulma.title [
                prop.classes ["has-text-weight-bold"; "is-size-4"]
                prop.style [style.color.black]
                prop.text "Review"
            ]
            Html.div [
                //prop.style [style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                prop.classes ["is-flex"; "is-flex-direction-column"]
                prop.style [style.display.flex; style.alignItems.center; style.justifyContent.center]
                prop.children [
                    Html.div [
                        prop.children [
                            Html.img [
                                prop.src ".././Assets/alan-katz.jpg"
                                prop.alt "doctor's profile logo"
                                prop.classes [ classes.DoctorImage; "image"; "p-1"; "ml-1"]
                                prop.style [style.borderRadius 10; style.width 90; style.height 100; style.marginTop 5; style.marginBottom 5; style.marginRight 5]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.children [
                            Bulma.title [
                                prop.classes ["is-size-6"]
                                prop.style [style.color.black; style.maxWidth 250; style.textAlign.center; style.margin 5]
                                prop.text "How was your experience with Dr. Henry Katz?"
                            ]
                        ]
                    ]
                    StarRating()
                    Html.div [
                        prop.style [style.margin 10; style.maxWidth 600]
                        prop.children [
                            Bulma.title [
                                title.is6
                                prop.style [style.color.black; style.marginBottom 0; style.marginLeft 5]
                                prop.text "Write a review"
                            ]
                            Bulma.textarea [
                                prop.classes ["textarea"]
                                prop.style [style.width 300; style.height 100; style.margin 5]
                                prop.placeholder "Your review here..."
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                //prop.className "container"
                prop.style [style.display.flex; style.flexDirection.column; style.marginLeft 40]
                prop.children [
                    Bulma.title [
                        title.is6
                        prop.text "Would you recommend Dr. Jake Bronson to your friends?"
                        prop.style [style.color.black; style.marginBottom 0]
                    ]
                    Html.form [
                        Html.label [
                            Html.input [
                                prop.type' "radio"
                                prop.name "radio"
                                prop.isChecked true
                            ]
                            Html.span "Yes"
                        ]
                        Html.label [
                            Html.input [
                                prop.type' "radio"
                                prop.name "radio"
                            ]
                            Html.span "No"
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.style [style.display.flex; style.flexDirection.row]
                prop.children [
                    Html.div [
                        prop.style [
                            style.marginRight 10
                        ]
                        prop.children [
                            Bulma.button.button [
                                Bulma.button.isRounded
                                Bulma.button.isInverted
                                Bulma.color.isPrimary
                                //prop.onClick (fun _ -> dispatch LoadAppointments )
                                prop.text "Cancel"
                                prop.style [
                                    style.borderColor "var(--antidote-blue-primary)"
                                    style.width 100
                                    style.fontSize 17
                                    ]
                            ]
                        ]
                    ]
                    Html.div [
                        Bulma.button.button [
                            Bulma.button.isRounded
                            Bulma.color.isPrimary
                            // prop.onClick (fun _ ->
                            //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
                            // )
                            prop.text "Submit"
                            prop.style [
                                style.width 100
                                style.fontSize 17
                            ]
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
