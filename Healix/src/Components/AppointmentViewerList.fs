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
                    prop.classes ["appointmentViewerList__container-image"; "is-flex"; "is-align-items-center"; "is-justify-content-center"; "image"; "is-128x128"]
                    prop.children [
                        Html.img [
                            prop.src ".././Assets/alan-katz.jpg"
                            prop.alt "doctor's profile logo"
                            prop.classes [ classes.DoctorImage; "image"; "is-4by5"; "p-1"; "mt-4"; "p-2"]
                        ]
                    ]
                ]
                Html.div [
                    prop.classes ["appointmentViewerList__container-content"]
                    prop.children [
                        Html.h2 [
                            prop.classes ["appointmentViewerList__name"; "subtitle"; "is-4"; "has-text-weight-bold"; ]
                            prop.text "Dr. Alan Katz"
                        ]
                        Html.p [
                            prop.classes ["appointmentViewerList__messaging"]
                            prop.children [
                                Html.text "Messaging - "
                                Html.span [
                                    Bulma.button.button [
                                        prop.classes ["button"; "is-outlined"; "is-primary"; "is-small"; "mb-2"]
                                        prop.text "Upcoming"
                                    ]
                                ]
                            ]
                        ]
                        Html.p [
                            prop.classes ["appointmentViewerList__availability"]
                            prop.text "Today | 16:00PM"
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
            prop.classes ["appointmentViewerList__container-button"; "m-3"; "is-flex"; "is-justify-content-space-evenly"; "p-4";"has-border-top"; ]
            prop.children [
                Html.button [
                    prop.classes [ "button"; "is-rounded"; "is-primary"; "is-outlined"; "is-size-6"; "px-6"]
                    prop.text "Cancel Appointment"
                ]
                Html.button [
                    prop.classes [ "button"; "is-primary"; "is-rounded"; "is-primary"; "is-size-6";"px-6" ]
                    prop.text "Reschedule"
                ]
            ]
        ]
    ]
    ]
