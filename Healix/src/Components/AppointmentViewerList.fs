module Healix.Components.AppointmentList

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
let ListItem () =
    // let toastDeleteAppointment () =
    //     toast(
    //         Html.div [
    //             Html.span "Are you sure you want to permanently delete this appointment?"
    //             Html.br []
    //             Html.br []
    //             Bulma.buttons [
    //                 Bulma.button.button [
    //                     button.isSmall
    //                     color.isInfo
    //                     prop.text "Cancel"
    //                     prop.onClick (
    //                         fun _ ->
    //                         debuglog "Cancel Delete Appointment Clicked"
    //                     )
    //                 ]
    //                 Bulma.button.button [
    //                     button.isSmall
    //                     color.isDanger
    //                     prop.text "Delete"
    //                     prop.onClick (
    //                         fun _ ->
    //                             updateAppointment props.ListItemAppointment props.RefreshCallback
    //                     )
    //                 ]
    //             ]
    //         ], jsOptions<ToastOptions>( fun o ->
    //             o.`` type`` <- Some TypeOptions.Warning
    //             o.autoClose <- false
    //         )

    //     ) |> ignore


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

// let dayGridItem (date: DateTime) =
//     Html.div [
//         prop.style [style.alignContent.center; style.fontSize 15; ]
//         prop.onClick ( fun _ -> JS.scrollElementByIdIntoView (date.ToShortDateString()) )
//         prop.children [
//             Html.h1 [
//                 prop.style [ style.margin 10 ]
//                 prop.text (int date.DayOfWeek |> toDayAbbreviation)
//             ]
//             Html.h1 [
//                 prop.style [ style.margin 10 ]
//                 prop.text date.Day
//             ]
//         ]
//     ]



// [<ReactComponent>]
// let AppointmentViewerList(props: AppointmentViewerListProps) =
//     Html.ul [
//         props.AppointmentList
//         |> groupAppointmentList props.SortDescending props.SelectAppointment props.RefreshCallback
//     ]
