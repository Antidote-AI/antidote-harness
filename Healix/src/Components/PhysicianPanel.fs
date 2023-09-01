module Healix.Components.PhysicianPanel

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


let private classes : CssModules.Components.AppointmentViewerList = import "default" "./AppointmentViewerList.module.scss"

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

// create the list item


[<ReactComponent>]
let PhysicianPanel () =

    let (heartSelected, setHeartSelected) = React.useState(false)

    Html.section [
        prop.classes ["card"; "m-4"]
        prop.children [
            Html.div [
                prop.style [style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                prop.classes ["is-flex"; "is-flex-direction-row"; "is-justify-content-space-between";]
                prop.children [
                    Html.div [
                        prop.children [
                            Html.img [
                                prop.src ".././Assets/alan-katz.jpg"
                                prop.alt "doctor's profile logo"
                                prop.classes [ classes.DoctorImage; "image"; "p-1"; "ml-1"]
                                prop.style [style.borderRadius 10; style.width 60; style.height 70; style.marginTop 5; style.marginBottom 5; style.marginRight 5]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.flexGrow 1; style.display.flex; style.justifyContent.center; style.flexDirection.column]
                        prop.children [
                            Html.div [
                                prop.style [ style.borderBottom(1, borderStyle.solid, "#F0F0F0"); style.width (length.perc 97); style.alignItems.center ]
                                prop.classes ["is-flex"; "is-flex-direction-row"; "is-justify-content-space-between"]
                                prop.children [
                                    Html.h2 [
                                        prop.classes ["has-text-weight-bold"]
                                        prop.text "Dr. Alan Katz"
                                        prop.style [style.fontWeight.bold; style.fontSize 16]
                                    ]
                                    Bulma.icon [
                                        Bulma.icon.isRight
                                        prop.style [style.marginTop 5]
                                        prop.onClick (fun _ -> setHeartSelected (not heartSelected))
                                        prop.children [
                                            if heartSelected then

                                                Icon [
                                                    icon.icon mdi.heart
                                                    icon.color "#1e4d8a"
                                                    icon.width 18
                                                ]
                                            else
                                                Icon [
                                                    icon.icon mdi.heartOutline
                                                    icon.color "#1e4d8a"
                                                    icon.width 18
                                                ]

                                        ]
                                    ]
                                ]
                            ]
                            Html.p [
                                //prop.classes ["ml-1"]
                                prop.style [style.color.dimGray; style.fontSize 13; style.display.flex; style.flexDirection.row]
                                prop.children [
                                    Html.p [
                                        prop.style [style.marginLeft 0;]
                                        prop.text "Psychiatrist"
                                    ]
                                    Html.p [
                                        prop.style [style.marginLeft 5;]
                                        prop.text "|"
                                    ]
                                    Html.p [
                                        prop.style [style.marginLeft 5;]
                                        prop.text "HARC"
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                prop.children [
                                    Html.img [
                                        prop.src ".././Assets/star-yellow.svg"
                                        prop.style [
                                            style.width 15
                                            style.height 15
                                        ]
                                    ]
                                    Html.p [
                                        prop.style [style.color.black; style.fontSize 12; style.marginLeft 3; style.fontWeight.bold]
                                        prop.text "4.9"
                                    ]
                                    Html.p [
                                        prop.style [style.color.gray; style.fontSize 12; style.marginLeft 8]
                                        prop.text "(4,279 reviews)"
                                    ]
                                ]
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
