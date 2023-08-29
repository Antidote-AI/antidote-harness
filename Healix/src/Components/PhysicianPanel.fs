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
    // Html.section [
    //     prop.classes ["appointmentViewerList"; "card"; "m-4"]
    //     prop.children [
    //         Html.div [
    //             prop.classes ["appointmentViewerList__container-content"; "is-flex"; "is-flex-direction-row"; "m-4"; "is-justify-content-space-between";]
    //             prop.children [
    //                 Html.div [
    //                     prop.style [ style.display.flex; style.justifyContent.spaceBetween ] // setting flexbox layout for parent div
    //                     prop.children [
    //                         Html.div [
    //                             prop.style [style.alignItems.center]
    //                             prop.classes ["appointmentViewerList__container-image"; "is-flex"; "is-align-items-center"; "is-justify-content-center"; "image"; "is-128x128"]
    //                             prop.children [
    //                                 Html.img [
    //                                     prop.src ".././Assets/alan-katz.jpg"
    //                                     prop.alt "doctor's profile logo"
    //                                     prop.classes [ classes.DoctorImage; "image"; "p-2"]
    //                                     prop.style [style.borderRadius 10; style.width 100; style.height 120; style.marginLeft -50]
    //                                 ]
    //                             ]
    //                         ]
    //                         Html.div [
    //                             prop.classes ["appointmentViewerList__container-content"; ]
    //                             prop.style [style.marginLeft -40]
    //                             prop.children [
    //                                 Html.h2 [
    //                                     prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
    //                                     prop.text "Dr. Alan Katz"
    //                                     prop.style [style.fontWeight.bold; style.fontSize 20]
    //                                 ]
    //                                 Html.p [
    //                                     prop.classes ["appointmentViewerList__messaging"; "p-2"]
    //                                     prop.style [style.color.gray]
    //                                     prop.children [
    //                                         Html.text ("Psychiatrist" + "    |    " + "HARC")
    //                                         // Html.span [
    //                                         //     Bulma.button.button [
    //                                         //         prop.classes ["button"; "is-outlined"; "is-primary"; "is-small"; "mb-1"]
    //                                         //         prop.text "Upcoming"
    //                                         //         prop.style [style.borderRadius 6; style.alignItems.center; style.height 25; style.marginLeft 3]
    //                                         //     ]
    //                                         // ]
    //                                     ]
    //                                 ]
    //                                 Html.p [
    //                                     prop.style [style.color.gray]
    //                                     prop.classes ["appointmentViewerList__availability"; "p-2"]
    //                                     prop.text "Today  |  16:00PM"
    //                                 ]
    //                             ]
    //                         ]
    //                     ]
    //                 ]
    //             ]
    //         ]
    //     ]
    // ]

    Bulma.card [
        Bulma.cardImage [
            Bulma.image [
                Bulma.image.is4by3
                prop.children [
                    Html.img [
                        prop.alt "Placeholder image"
                        prop.src "https://bulma.io/images/placeholders/1280x960.png"
                    ]
                ]
            ]
        ]
        Bulma.cardContent [
            Bulma.media [
                Bulma.mediaLeft [
                    Bulma.cardImage [
                        Bulma.image [
                            Bulma.image.is48x48
                            prop.children [
                                Html.img [
                                    prop.alt "Placeholder image"
                                    prop.src "https://bulma.io/images/placeholders/96x96.png"
                                ]
                            ]
                        ]
                    ]
                ]
                Bulma.mediaContent [
                    Bulma.title.p [
                        Bulma.title.is4
                        prop.text "Feliz Bulma"
                        prop.style [style.color.black]
                    ]
                    Bulma.subtitle.p [
                        Bulma.title.is6
                        prop.text "@feliz.bulma"
                    ]
                ]
            ]
            Bulma.content "Lorem ipsum dolor sit ... nec iaculis mauris."
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
