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

type LabDetails = {
    labName: string
    labValue: float
    labRange: string
    labDate: string
    labUnit: string
    labRangeMin: float
    labRangeMax: float
}

let LabData =
    {
        labName = "Hemoglobin A1c"
        labValue = 3.5
        labRange = "4.0 - 6.0"
        labDate = "12/12/2020"
        labUnit = "%"
        labRangeMin = 2.0
        labRangeMax = 5.0
    }




let positioning max min value = System.Math.Round(0.25 + ((value - min) / (max - min) * 0.5), 2) * 100.0


[<ReactComponent>]
let normalRangeBar =
    Html.div [
        prop.style [style.width (length.perc 100); style.backgroundColor "#FFDD57"; style.height 20 ]
        //prop.className classes.rangeBar
        prop.children [
            Html.div [
                prop.className classes.rangeIndicator
                prop.style [
                    style.position.absolute
                    style.height 20
                    style.width (length.perc 50)
                    style.left (length.perc 25)
                    //style.backgroundColor.gray; style.marginTop 70; style.height 20
                ]
            ]
        ]
    ]

// style.left (length.perc (int value))


let RangeBarWithArrow (props:LabDetails) =
    let labValueCount = float (string props.labValue |> String.length)
    let print = System.Math.Round(0.25 + ((props.labValue - props.labRangeMin) / (props.labRangeMax - props.labRangeMin) * 0.5), 2) * 100.0
    printfn "Positioning result: %f" print
    Html.div [
        prop.style [style.width (length.perc 100)]
        prop.children [
            Html.div [
                prop.style [
                    style.position.relative
                    style.display.flex;
                    style.justifyContent.center
                    style.left (length.perc (int ((positioning props.labRangeMax props.labRangeMin props.labValue))))
                    style.flexDirection.column
                ]
                prop.children [
                    Html.div [
                        //prop.className classes.transform
                        prop.style [
                            style.position.relative;
                            style.justifyContent.center
                            style.left (length.perc (int (-2.0 - labValueCount)))
                            //style.marginBottom -10
                            //style.paddingLeft 5
                        ]
                        prop.children [
                        Bulma.tag [
                                //prop.style [style.minWidth 30; style.transform.translateX (length.perc -50)]
                                prop.classes ["has-text-weight-bold"]
                                Bulma.color.isSuccess
                                prop.text props.labValue
                            ]
                        ]
                    ]

                    Html.i [
                        //prop.className classes.transform
                        prop.style [
                            //style.width 20
                            style.position.relative;
                            style.left (length.perc (int(-5.0)))
                            //style.transform.translateX (length.perc -100)
                            //style.marginBottom -30
                        ]
                        prop.children [
                            Icon [
                                icon.icon mdi.menuDown
                                icon.color "black"
                                icon.width 40
                            ]
                        ]
                    ]
                ]
            ]
            normalRangeBar
            Html.div [
                prop.style [style.textAlign.center]
                prop.children [
                    Html.text "G"
                ]
            ]
        ]
    ]








let render () =
    RangeBarWithArrow LabData
