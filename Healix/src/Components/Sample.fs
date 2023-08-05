module Healix.Components.Sample

open Antidote.Core.V2.Utils.JS
open Feliz
open Feliz.Bulma
open Fable.Core.JsInterop

// let private classes : CssModules.Components.Sample = import "default" "./Sample.module.scss"

[<ReactComponent>]
let Sample () =

    Html.div [
        prop.children [
            Bulma.box [
                prop.children [
                    Html.div [
                        prop.children [
                            Html.p [
                                prop.style [ style.fontSize 50 ]
                                prop.text "Proposal"
                            ]
                        ]
                    ]
                    // Html.button [
                    //     prop.classes [
                    //         "button"
                    //         "is-fullwidth"
                    //         "is-rounded"
                    //         "is-antidote-orange"
                    //     ]
                    //     prop.onClick (
                    //         fun _ ->
                    //             debuglog "Clicked the sample button"
                    //     )
                    //     prop.children [
                    //         Html.span [
                    //             prop.style [ style.textIndent 3]
                    //             prop.text "Sample Button"
                    //         ]
                    //     ]
                    // ]
                ]
            ]
        ]
    ]
