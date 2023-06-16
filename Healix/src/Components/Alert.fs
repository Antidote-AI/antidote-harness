module Healix.Components.Alert

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

let private classes : CssModules.Components.Alert = import "default" "./Alert.module.scss"

[<ReactComponent>]
let Alert () =

    // Html.div [
    //     prop.classes [ "notification"; "is-danger"; "is-light" ]
    //     prop.children [
    //         Html.img [
    //             prop.src "/Assets/Alert2.svg"
    //             prop.style [ style.width 35; style.marginRight 15 ]
    //         ]
    //         Html.text "If the patient answers 'Yes' to any of the following questions about abuse, please report the event to the DCF, with the exception of the last question."
    //     ]
    //     prop.children [
    //         Html.img [
    //             prop.src "/Assets/Alert2.svg"
    //             prop.style [ style.width 35; style.marginRight 15 ]
    //         ]
    //         Html.text "If the patient answers 'Yes' to any of the following questions about abuse, please report the event to the DCF, with the exception of the last question."
    //     ]
    // ]



    Bulma.card [
        prop.className classes.centerWidth
        prop.children [
            Bulma.cardHeader [
                prop.classes [ "is-danger"; "is-light"; "has-background-danger" ]
                prop.children [
                    Html.div [
                        prop.className [classes.align]
                        prop.classes ["align"]
                        prop.style [style.display.flex; style.alignItems.center]
                        prop.children [
                            Html.span [
                                prop.className ["icon"]
                                prop.style [style.marginRight 7]
                                prop.children [
                                    Icon [
                                        icon.icon mdi.alert
                                        icon.width 25
                                        icon.height 25
                                        icon.color "#FFFFFF"
                                    ]
                                ]
                            ]
                            Html.text "Warning"
                        ]
                    ]
                ]
                prop.style [style.display.flex; style.justifyContent.center; style.alignItems.center; style.color "#FFFFFF"; style.fontSize 25; style.fontWeight.bold; style.paddingTop 10]
            ]

            Bulma.cardContent [
                prop.classes [ "is-danger"; "is-light"; "has-background-danger-light" ]
                prop.style [style.display.flex; style.justifyContent.center]
                prop.children [
                    Html.div [
                        prop.className [classes.textContainer]
                        prop.style [style.fontSize 17; style.color "#FF3366"]
                        prop.children [
                            Html.text "If the patient acknowledges any form of abuse in response to the following questions with a 'Yes', except for the last question, please promptly report the incident to the Department of Children and Families (DCF)."
                        ]
                    ]
                ]
            ]
            Bulma.level [
                prop.classes [ "has-background-danger-light" ]
                prop.children [
                    Bulma.levelItem [
                        prop.style [
                            style.marginRight 10
                            style.marginBottom 20
                        ]
                        prop.children [
                            Html.div [
                                prop.className [classes.align]
                                prop.classes ["align"]
                                prop.style [style.display.flex; style.alignItems.center; style.color "#FF3366"]
                                prop.children [
                                    Html.span [
                                        prop.className ["icon"]
                                        prop.style [style.marginRight 7]
                                        prop.children [
                                            Icon [
                                                icon.icon mdi.phone
                                                icon.width 20
                                                icon.height 20
                                                icon.color "#FF3366"
                                            ]
                                        ]
                                    ]
                                    Html.text "(850) 487-1111"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]
