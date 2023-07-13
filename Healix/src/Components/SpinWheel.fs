module Healix.Components.SpinWheel

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Elmish
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props



let private classes : CssModules.Components.SpinWheel = import "default" "./SpinWheel.module.scss"


let spinWheel() =
    Html.html [
        prop.lang "en"
        prop.children [
            Html.head [
                Html.meta [
                    prop.charset "UTF-8"
                ]
                Html.meta [
                    prop.name "viewport"
                    prop.content "width=device-width, initial-scale=1.0"
                ]
                Html.title "Spin Wheel"
            ]
            Html.body [
                Html.button [
                    prop.className [classes.spin]
                    prop.text "Spin"
                    //prop.onClick (fun _ -> spinContainer())
                ]
                Html.span [
                    prop.className [classes.arrow]
                ]
                Html.div [
                    prop.className [classes.container]
                    prop.children [
                        Html.div [
                            prop.className [classes.one]
                            prop.text "1"
                        ]
                        Html.div [
                            prop.className [classes.two]
                            prop.text "2"
                        ]
                        Html.div [
                            prop.className [classes.three]
                            prop.text "3"
                        ]
                        Html.div [
                            prop.className [classes.four]
                            prop.text "4"
                        ]
                        Html.div [
                            prop.className [classes.five]
                            prop.text "5"
                        ]
                        Html.div [
                            prop.className [classes.six]
                            prop.text "6"
                        ]
                        Html.div [
                            prop.className [classes.seven]
                            prop.text "7"
                        ]
                        Html.div [
                            prop.className [classes.eight]
                            prop.text "8"
                        ]
                    ]
                ]
            ]
        ]
    ]
