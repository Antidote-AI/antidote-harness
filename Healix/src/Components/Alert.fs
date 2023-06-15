module Healix.Components.Alert

open Antidote.Core.V2.Utils.JS
open Feliz
open Feliz.Bulma
open Fable.Core.JsInterop

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
                prop.classes [ "is-danger"; "is-light"; "has-background-danger-light" ]
                prop.children [
                    Html.div [
                        prop.className [classes.align]
                        prop.classes ["align"]
                        prop.children [
                            Html.img [
                                prop.src "/Assets/Alert2.svg"
                                prop.style [ style.width 25; style.marginRight 15; style.alignItems.center; style.paddingTop 10]
                            ]
                            Html.text "Warning"
                        ]
                    ]
                ]
                prop.style [style.display.flex; style.justifyContent.center; style.alignItems.center; style.color.red; style.fontSize 25; style.fontWeight.bold; style.paddingTop 10]
            ]

            Bulma.cardContent [
                prop.classes [ "notification"; "is-danger"; "is-light"; "has-background-danger-light" ]
                prop.style [style.display.flex; style.justifyContent.center]
                prop.children [
                    Html.div [
                        prop.className [classes.textContainer]
                        prop.style [style.fontSize 17]
                        prop.children [
                            Html.text "If the patient acknowledges any form of abuse in response to the following questions with a 'Yes', except for the last one, please promptly report the incident to the Department of Children and Families (DCF)."
                        ]
                    ]
                ]
            ]
        ]
    ]
