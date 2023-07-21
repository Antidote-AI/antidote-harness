module Healix.Components.PatientCard

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


let private classes : CssModules.Components.PatientCard = import "default" "./PatientCard.module.scss"



[<ReactComponent>]
let PatientCard () =
    Html.section [
        prop.style [ style.display.flex; style.justifyContent.center]
        prop.classes ["appointmentViewerList"; "m-4"]
        prop.children [
            Html.div [
                prop.style [ style.display.flex; style.justifyContent.center; style.flexDirection.column; style.width (length.perc 95); style.flexGrow 1; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.position.relative]
                prop.children [
                    Html.div [
                        prop.className [classes.myDiv]
                        prop.children [
                            Html.div [
                                prop.style [ style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop 10; style.marginBottom 10]
                                prop.children [
                                    Html.div [
                                        prop.children [
                                            Html.img [
                                                prop.style [style.marginLeft 10; style.width 75; style.height 75; style.custom ("boxShadow", "rgba(0, 0, 0, 0.16) 0px 10px 36px 0px");style.border(3, borderStyle.solid, color.white)]
                                                prop.src ".././Assets/alan-katz.jpg"
                                                prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.classes ["appointmentViewerList__container-content"]
                                        prop.children [
                                            Html.h3 [
                                                prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                prop.style [
                                                    style.fontFamily "Inter";
                                                    style.fontWeight.bold;
                                                    style.fontSize 17;
                                                    style.marginBottom -20;
                                                    style.color.black;
                                                    style.display.flex;
                                                    style.justifyContent.center;
                                                    style.alignItems.center;
                                                ]
                                                prop.children [
                                                    Html.span [
                                                        prop.text ("Alex" + " " + "Campo")
                                                    ]
                                                    Bulma.tag [
                                                        Bulma.color.isSuccess
                                                        Bulma.color.isLight
                                                        prop.text "Low Risk"
                                                        prop.style [style.marginLeft 5]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.gray]
                                                        prop.children [
                                                            Html.text ("Patient" + " • " + "Age 76"+ " • " + "Age 76" )
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]

                            Html.div [
                                prop.style [ style.display.flex; style.flexDirection.row; style.justifyContent.flexEnd; style.alignItems.center ]
                                prop.className [classes.marginTop]
                                prop.children [
                                    Bulma.tag [
                                        Bulma.color.isPrimary
                                        Bulma.color.isLight
                                        prop.classes ["has-text-primary"; "has-text-weight-bold"]
                                        prop.style [style.marginRight 10]
                                        prop.children [
                                            Icon [
                                                icon.icon mdi.email
                                                icon.width 14
                                                icon.height 14
                                            ]
                                            Html.p [
                                                prop.text "alexcampo3695@gmail.com"
                                                prop.style [style.marginLeft 5]
                                            ]
                                        ]
                                    ]
                                    Bulma.tag [
                                        Bulma.color.isPrimary
                                        Bulma.color.isLight
                                        prop.classes ["has-text-primary"; "has-text-weight-bold"]
                                        prop.style [style.marginRight 5]
                                        prop.children [
                                            Icon [
                                                icon.icon mdi.phone
                                                icon.width 14
                                                icon.height 14
                                            ]
                                            Html.p [
                                                prop.text "305-206-4761"
                                                prop.style [style.marginLeft 5]
                                            ]
                                        ]
                                    ]
                                    // Html.button [
                                    //     prop.style [
                                    //         style.backgroundColor "#ff3860"
                                    //         style.height 24
                                    //         style.width 24
                                    //         style.display.flex
                                    //         style.alignItems.center
                                    //         style.justifyContent.center
                                    //     ]
                                    //     prop.children [
                                    //         Html.div [
                                    //             prop.style [
                                    //                 style.display.flex
                                    //                 style.justifyContent.center
                                    //                 style.alignItems.center
                                    //             ]
                                    //             prop.children [
                                    //                 Html.img [
                                    //                     prop.src ".././Assets/ellipsis.svg"
                                    //                     prop.style [
                                    //                         style.width 30
                                    //                         style.height 30
                                    //                     ]
                                    //                 ]
                                    //             ]
                                    //         ]
                                    //     ]
                                    // ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]
