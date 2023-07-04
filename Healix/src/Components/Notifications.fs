module Healix.Components.Notifications

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


let private classes : CssModules.Components.Notifications = import "default" "./Notifications.module.scss"

type NotificationDetail =
    {
        Title: string
        Time: string
        //ImgSrc: string
    }

type NotificationType =
    | Cancelled of NotificationDetail
    | Changed of NotificationDetail
    | Success of NotificationDetail
    | NewServicesAvailable of NotificationDetail

//let appointment = { Title = "Appointment Cancelled"; Time = "Today | 4:30pm" ; ImgSrc = ".././Assets/message-rounded-icon-blue.svg" }



[<ReactComponent>]

let PhysicianOverview (notification:NotificationType) =

    let detail, colorClass, imgSrc =
        match notification with
        | Cancelled detail -> detail, "has-background-danger-light", ".././Assets/closeicon.svg"
        | Changed detail -> detail, "has-background-warning-light", ".././Assets/medicine.svg"
        | Success detail -> detail, "has-background-success-light", ".././Assets/calgreen.svg"
        | NewServicesAvailable detail -> detail, "has-background-primary-light", ".././Assets/calblue.svg"

    Html.section [
        prop.classes ["appointmentViewerList"; "card"; "m-4"; "is-flex"; "is-justify-content-space-between"]
        prop.style [ style.display.flex; style.flexDirection.column] // column direction for section
        prop.children [
            // New container to hold existing elements and the "New" tag
            Html.div [
                prop.style [ style.display.flex; style.justifyContent.spaceBetween ] // row direction for this container
                prop.children [
                    Html.div [
                        prop.classes ["appointmentViewerList__container-content"; "is-flex"; "is-flex-direction-row"; "m-4"; "is-justify-content-space-between"]
                        prop.children [
                            Html.div [
                                prop.style [ style.display.flex; style.justifyContent.spaceBetween; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        prop.children [
                                            Html.img [
                                                prop.src imgSrc
                                                prop.alt "messaging icon"
                                                prop.classes [classes.MessagingIcon;"image";"is-48x48"; "is-rounded"; "m-4"; "p-3"; colorClass]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.classes ["appointmentViewerList__container-content"]
                                        prop.children [
                                            Html.h2 [
                                                prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                prop.text detail.Title
                                                prop.style [style.fontWeight.bold; style.fontSize 20;style.marginBottom -10]
                                            ]
                                            Html.div [
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"; "has-text-grey-dark"]
                                                        prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.marginTop -10]
                                                        prop.children [
                                                            Html.text detail.Time
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
                    // Moved "New" tag to be part of the new container
                    Html.div [
                        prop.style [
                            style.display.flex
                            style.alignItems.center
                            style.justifyContent.center
                            style.marginRight 20
                        ]
                        prop.children [
                            Bulma.tag [
                                prop.classes ["has-background-primary-light"; "has-text-primary"; "has-text-weight-bold"]
                                Bulma.tag.isRounded
                                prop.text "New!"
                            ]
                        ]
                    ]
                ]
            ]
            // Line and text at the bottom of the section
            Html.hr [
                prop.className [classes.lineWidth]
                prop.style [
                    style.margin 0
                    style.marginLeft 10
                    style.height 1
                    style.marginBottom 10
                ]
            ]
            Html.div [
                prop.style [style.marginTop 7; style.marginBottom 7]
                prop.children [
                    Html.p [
                        prop.className classes.lineWidth
                        prop.style [ style.color.gray]
                        prop.text "You have successfully canceled your appointment with Dr. Alan Katz on Decemember 24, 2023 at 4:30pm."
                    ]
                ]
            ]
        ]
    ]

// usage
let newAppointment = Changed { Title = "Appointment Cancelled"; Time = "Today | 4:30pm" }
let newAppointment1 = Success { Title = "Appointment Cancelled"; Time = "Today | 4:30pm" }
let newAppointment2 = NewServicesAvailable { Title = "Appointment Cancelled"; Time = "Today | 4:30pm" }
let newAppointment3 = Cancelled { Title = "Appointment Cancelled"; Time = "Today | 4:30pm" }


[<ReactComponent>]
let Page () =
    Html.div [
        prop.children [
            PhysicianOverview newAppointment
            PhysicianOverview newAppointment1
            PhysicianOverview newAppointment2
            PhysicianOverview newAppointment3
            //PhysicianMetrics()
            //AboutMe()
            //WorkingHours()
            //BookAppointment()
        ]
    ]




// Html.div [
            //     prop.style [ style.borderTop(1, borderStyle.solid, color.lightGray); style.borderTopColor color.lightGray;style.display.flex; style.flexDirection.row; style.flexWrap.wrap; style.justifyContent.spaceBetween; style.gap 10]
            //     prop.classes ["appointmentViewerList__container-button"; "m-3"; "is-flex"; "is-justify-content-space-evenly"; "p-4";"has-border-top"; ]
            //     prop.children [
            //         Bulma.button.button [
            //             Bulma.button.isRounded
            //             Bulma.color.isPrimary
            //             Bulma.button.isOutlined
            //             //Bulma.button.isFullwidth
            //             // prop.onClick (fun _ ->
            //             //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
            //             // )
            //             prop.text "Reschedule"
            //             prop.className [classes.width]
            //             prop.style [
            //                 style.marginBottom 15
            //                 style.fontSize 17
            //                 //style.marginLeft 5
            //             ]
            //         ]
            //         Bulma.button.button [
            //             Bulma.button.isRounded
            //             Bulma.color.isPrimary
            //             prop.className [classes.width]
            //             //Bulma.button.isFullwidth
            //             // prop.onClick (fun _ ->
            //             //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
            //             // )
            //             prop.text "Join"
            //             prop.style [
            //                 style.fontSize 17
            //                 //style.marginRight 5
            //             ]
            //         ]

            //     ]
            // ]
