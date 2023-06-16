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

    Html.li [
        prop.style [
            style.textAlign.left
            style.display.block
            style.alignContent.center
            //style.backgroundColor "#FFFFFF"
            style.borderRadius 5
            style.margin 10
            //style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")
            style.borderColor.lightGray
            style.borderStyle.solid
            style.borderWidth 1

        ]
        prop.className "card-header-title"
        prop.children [
            Html.div [
                prop.className "media"
                prop.style [ style.overflow.hidden ]
                prop.children [
                    Html.div [
                        prop.className "media-left"
                        prop.children [

                            Html.figure [
                                prop.className "image"
                                prop.style [
                                    style.height 40
                                    style.width 40
                                ]
                                // prop.children [
                                //     UserAvatar props.ListItemTitle None
                                // ]
                            ]
                        ]
                    ]

                    Html.div [
                        prop.className "media-content"
                        //prop.onClick ( fun _ -> props.SelectAppointmentCallBack props.ListItemReferenceId )

                        prop.children [
                            Html.p [
                                prop.style [ style.color "black" ]
                                prop.classes [ "title"; "is-4" ]
                                prop.text "HELLLLOOOO"
                            ]
                            Html.p [
                                prop.style [ style.color "black" ]
                                prop.classes [ "subtitle"; "is-5" ]
                                prop.text "HELLOOOO"
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [ style.borderRadius 100]
                        prop.children [
                            Html.span [
                                //prop.onClick (fun _ -> toastDeleteAppointment () )
                                prop.className "icon"
                                prop.children [
                                    Html.i [
                                        prop.className "fas fa-trash-alt"
                                        prop.style [ style.color "gray" ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]
