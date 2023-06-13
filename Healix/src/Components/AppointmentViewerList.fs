module Healix.Components.AppointmentList

open Feliz
open Feliz.Bulma
open Fable.Remoting.Client
open System
//open FullCalendar
open Antidote.Core.V2
open Antidote.Core.V2.Types
open Antidote.Core.V2.Utils
//open Feliz.ReactRouterDom
//open Antidote.React.Components
//open Antidote.React.Contexts.AcsComponentProvider
//open Antidote.React.Contexts.UserProvider
//open Antidote.React.Components.UserAvatar
//open Antidote.i18n.Util
open Fable.Core.JsInterop
open Antidote.Core.V2.Utils.JS
//open type Feliz.Toastify.Exports
//open Feliz.Toastify
emitJsStatement () "import React from \"react\""

let private classes : CssModules.Components.AppointmentViewerList = import "default" "./AppointmentViewerList.module.scss"

type ListItemProps = {|
    ListItemIcon: string
    ListItemTitle: string
    ListItemSubTitle: string
    ListItemDate: DateTime
    ListItemReferenceId: string
    ListItemAppointmentType: AppointmentType
    ListItemAppointment: Appointment
    SelectAppointmentCallBack: string -> unit
    RefreshCallback: unit -> unit
|}

type AppointmentViewerListProps = {|
    AppointmentList: Antidote.Core.V2.Types.Appointments
    SelectAppointment: string -> unit
    SortDescending: bool
    RefreshCallback: unit -> unit
|}

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
    Bulma.cardFooter [
        Bulma.cardFooterItem.a [
            prop.text "Save"
        ]
        Bulma.cardFooterItem.a [
            prop.text "Edit"
        ]
        Bulma.cardFooterItem.a [
            prop.text "Delete"
        ]
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
