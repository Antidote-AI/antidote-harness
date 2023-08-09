module Healix.Components.LabDetails

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


let private classes : CssModules.Components.LabDetails = import "default" "./LabDetails.module.scss"

[<ReactComponent>]
let normalRangeBar lower upper =
    let percentage p =  int (p * 100.0)
    Html.div [
        prop.style [style.width (length.perc 100); style.height 20; style.backgroundColor.gray  ]
        //prop.className classes.rangeBar
        prop.children [
            Html.div [
                prop.className classes.rangeIndicator
                prop.style [
                    style.position.absolute
                    style.height 20
                    style.width (length.perc (percentage (upper - lower)))//(percentage (upper - lower))
                    style.left (length.perc (percentage lower))
                    //style.right (length.perc (percentage (0.5 * (upper - lower))))
                ]
            ]
        ]
    ]


let render () =
    normalRangeBar 0.3 0.9
