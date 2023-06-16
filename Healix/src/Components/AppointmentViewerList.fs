module Healix.Components.AppointmentViewerList

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
let AppointmentViewerList () =
    //let toastDeleteAppointment () =
        // toast(
        //     Html.div [
        //         Html.span "Are you sure you want to permanently delete this appointment?"
        //         Html.br []
        //         Html.br []
        //         Bulma.buttons [
        //             Bulma.button.button [
        //                 button.isSmall
        //                 color.isInfo
        //                 prop.text "Cancel"
        //                 prop.onClick (
        //                     fun _ ->
        //                     debuglog "Cancel Delete Appointment Clicked"
        //                 )
        //             ]
        //             Bulma.button.button [
        //                 button.isSmall
        //                 color.isDanger
        //                 prop.text "Delete"
        //                 prop.onClick (
        //                     fun _ ->
        //                         updateAppointment props.ListItemAppointment props.RefreshCallback
        //                 )
        //             ]
        //         ]
        //     ], jsOptions<ToastOptions>( fun o ->
        //         o.`` type`` <- Some TypeOptions.Warning
        //         o.autoClose <- false
        //     )

        // ) |> ignore


    Html.section [
        prop.classes ["appointmentViewerList"; "card"; "m-4"]
        prop.children [
            Html.div [
                prop.classes ["appointmentViewerList__container-content"; "is-flex"; "is-flex-direction-row"; "m-4"; "is-justify-content-space-between";]
                prop.children [
                    Html.div [
                        prop.style [ style.display.flex; style.justifyContent.spaceBetween ] // setting flexbox layout for parent div
                        prop.children [
                            Html.div [
                                prop.style [style.alignItems.center]
                                prop.classes ["appointmentViewerList__container-image"; "is-flex"; "is-align-items-center"; "is-justify-content-center"; "image"; "is-128x128"]
                                prop.children [
                                    Html.img [
                                        prop.src ".././Assets/alan-katz.jpg"
                                        prop.alt "doctor's profile logo"
                                        prop.classes [ classes.DoctorImage; "image"; "p-1"; "p-2"]
                                        prop.style [style.borderRadius 12; style.width 100; style.height 120]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.classes ["appointmentViewerList__container-content"]
                                prop.children [
                                    Html.h2 [
                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                        prop.text "Dr. Alan Katz"
                                        prop.style [style.fontWeight.bold; style.fontSize 20]
                                    ]
                                    Html.p [
                                        prop.classes ["appointmentViewerList__messaging"; "p-2"; "has-text-grey-dark"]
                                        prop.children [
                                            Html.text "Diabetes Questionairre  -  "
                                            Html.span [
                                                Bulma.button.button [
                                                    prop.classes ["button"; "is-outlined"; "is-primary"; "is-small"; "mb-1"]
                                                    prop.text "Upcoming"
                                                    prop.style [style.borderRadius 6; style.alignItems.center; style.height 25; style.marginLeft 3]
                                                ]
                                            ]
                                        ]
                                    ]
                                    Html.p [
                                        prop.classes ["appointmentViewerList__availability"; "p-1"; "has-text-grey-dark"]
                                        prop.text "Today  |  16:00PM"
                                    ]
                                ]
                            ]
                        ]
                    ]

                    Html.div [
                        prop.classes ["appointmentViewerList__container-messaging-icon"; "is-flex"; "is-align-items-center"; "is-justify-content-center"; "is-rounded"; "p-4"]
                        prop.children [
                            // Html.text "{" "} "
                            Html.img [
                                prop.src ".././Assets/message-rounded-icon-blue.svg"
                                prop.alt "messaging icon"
                                prop.classes [classes.MessagingIcon;"image";"is-48x48"; "is-rounded"; "m-4"; "p-3";  "has-background-link-light";]
                            ]
                            // Html.text " Message Button"
                        ]
                    ]
                ]
            ]

            Html.div [
                prop.style [ style.borderTop(1, borderStyle.solid, color.lightGray); style.borderTopColor color.lightGray;style.display.flex; style.flexDirection.row; style.flexWrap.wrap; style.justifyContent.spaceBetween; style.gap 10]
                prop.classes ["appointmentViewerList__container-button"; "m-3"; "is-flex"; "is-justify-content-space-evenly"; "p-4";"has-border-top"; ]
                prop.children [
                    Bulma.button.button [
                        Bulma.button.isRounded
                        Bulma.color.isPrimary
                        Bulma.button.isOutlined
                        //Bulma.button.isFullwidth
                        // prop.onClick (fun _ ->
                        //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
                        // )
                        prop.text "Reschedule"
                        prop.className [classes.width]
                        prop.style [
                            style.marginBottom 15
                            style.fontSize 17
                            //style.marginLeft 5
                        ]
                    ]
                    Bulma.button.button [
                        Bulma.button.isRounded
                        Bulma.color.isPrimary
                        prop.className [classes.width]
                        //Bulma.button.isFullwidth
                        // prop.onClick (fun _ ->
                        //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
                        // )
                        prop.text "Join"
                        prop.style [
                            style.fontSize 17
                            //style.marginRight 5
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
