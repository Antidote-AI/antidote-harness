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


let private classes : CssModules.Components.PhysicianPanel = import "default" "./PhysicianPanel.module.scss"

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
        prop.classes ["card"; "m-3"]
        prop.children [
            Html.div [
                prop.classes ["is-flex"; "is-flex-direction-row"; "is-justify-content-space-between"; classes.mobileFlexWrap] // Add mobileFlexWrap class here
                prop.children [
                    Html.div [
                        prop.className [classes.mobileCenterImage]
                        prop.children [
                            Html.img [
                                prop.src ".././Assets/alan-katz.jpg"
                                prop.alt "doctor's profile logo"
                                prop.classes [ classes.DoctorImage; "image"; "p-1"; "ml-1"; classes.imageResizing]
                                prop.style [style.borderRadius 10; style.width 65; style.height 75; style.marginTop 5; style.marginBottom 5; style.marginRight 5]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.flexGrow 1; style.display.flex; style.justifyContent.center; style.flexDirection.column]
                        prop.children [
                            Html.div [
                                prop.style [ style.borderBottom(1, borderStyle.solid, "#F0F0F0"); style.width (length.perc 97); style.alignItems.center; style.justifyContent.spaceBetween ]
                                prop.classes ["is-flex"; "is-flex-direction-row"; classes.mobileCenterItems]
                                prop.children [
                                    Html.h2 [
                                        prop.style [ ]
                                        prop.classes ["has-text-weight-bold"]
                                        prop.text "Dr. Alan Katz"
                                        prop.style [style.fontWeight.bold; style.fontSize 20]
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
                                                    icon.width 22
                                                ]
                                            else
                                                Icon [
                                                    icon.icon mdi.heartOutline
                                                    icon.color "#1e4d8a"
                                                    icon.width 22
                                                ]

                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.className [classes.mobileFlexWrap; classes.centerDiv]
                                prop.style [style.display.flex; style.justifyContent.spaceBetween; style.width (length.perc 97)]
                                prop.children [
                                    Html.div [
                                        prop.children [
                                            Html.p [
                                                prop.className [classes.centerDiv]
                                                prop.style [style.color.dimGray; style.fontSize 16; style.display.flex; style.flexDirection.row]
                                                prop.children [
                                                    Html.p [prop.text "Psychiatrist"]
                                                    Html.p [prop.text "|"]
                                                    Html.p [prop.text "HARC"]
                                                ]
                                            ]
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center]
                                                prop.children [
                                                    Html.img [prop.src ".././Assets/star-yellow.svg"; prop.style [style.width 15; style.height 15]]
                                                    Html.p [prop.style [style.color.black; style.fontSize 16; style.marginLeft 3; style.fontWeight.bold]; prop.text "4.9"]
                                                    Html.p [prop.style [style.color.gray; style.fontSize 16; style.marginLeft 8]; prop.text "(4,279 reviews)"]
                                                ]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.className [classes.mobileFlexWrap; classes.centerDiv; classes.columnStyle]
                                        prop.children [
                                            Html.div [
                                                prop.className [classes.centerDiv]
                                                prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd; style.color.black; style.fontSize 16]
                                                prop.children [
                                                    Icon [icon.icon mdi.location; icon.color "black"; icon.width 18]
                                                    Html.div [
                                                        prop.style [style.marginLeft 3]
                                                        prop.children [
                                                            Html.text "7.2 Miles"
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd; style.color.black; style.fontSize 16]
                                                prop.children [
                                                    Icon [icon.icon mdi.hospitalBuilding; icon.color "black"; icon.width 18]
                                                    Html.div [
                                                        prop.style [style.marginLeft 3]
                                                        prop.children [
                                                            Html.text "2020 N Bayshore Drive 1806 2020 n bayshore 1806"
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
