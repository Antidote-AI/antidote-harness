module Healix.Components.PhysicianOverview

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


let private classes : CssModules.Components.PhysicianOverview = import "default" "./PhysicianOverview.module.scss"



[<ReactComponent>]
let PhysicianOverview () =

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
                                        prop.style [style.borderRadius 20; style.width 110; style.height 120]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.classes ["appointmentViewerList__container-content"]
                                prop.children [
                                    Html.h2 [
                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                        prop.text "Dr. Alan Katz"
                                        prop.style [style.fontWeight.bold; style.fontSize 25]
                                    ]
                                    Html.div [  // Wrapping element
                                        //prop.style [ style.borderTop(1, borderStyle.solid, color.lightGray); style.borderTopColor color.lightGray]
                                        prop.children [
                                            Html.p [
                                                prop.classes ["appointmentViewerList__messaging"; "p-2"; "has-text-grey-dark"]
                                                prop.children [
                                                    Html.text "Cardiologist"
                                                ]
                                            ]
                                            Html.p [
                                                prop.classes ["appointmentViewerList__availability"; "p-1"; "has-text-grey-dark"; "p-2"]
                                                prop.text "Universidad del Norte Barranquilla, Colombia"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            Bulma.level [
                //Bulma.level.isMobile
                Bulma.levelItem [
                    prop.classes ["has-text-centered"]
                    prop.children [
                        Html.div [
                            Html.p [
                                prop.className "heading"
                                prop.text "Tweets"
                            ]
                            Html.p [
                                prop.className "title"
                                prop.text "3,456"
                            ]
                        ]
                    ]
                ]
            ]

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
