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
        labValue = 60.0
        labRange = "4.0 - 6.0"
        labDate = "12/12/2020"
        labUnit = "%"
        labRangeMin = 25
        labRangeMax = 75
    }




let positioning max min value = System.Math.Round(0.25 + ((value - min) / (max - min) * 0.5), 2) * 100.0


[<ReactComponent>]
let normalRangeBar =
    Html.div [
        prop.style [style.width (length.perc 100); style.height 15; style.borderRadius 4; style.marginTop 50; style.marginBottom 50 ]
        prop.className classes.yellow
        //prop.className classes.rangeBar
        prop.children [
            Html.div [
                prop.className classes.rangeIndicator
                prop.style [
                    style.position.absolute
                    style.height 15
                    style.width (length.perc 50)
                    style.left (length.perc 25)
                    //style.backgroundColor.gray; style.marginTop 70; style.height 20
                ]
            ]
        ]
    ]

// style.left (length.perc (int value))


let RangeBarWithArrow (props:LabDetails) =
    let labValueCount x = float (string x |> String.length)
    let print = System.Math.Round(0.25 + ((props.labValue - props.labRangeMin) / (props.labRangeMax - props.labRangeMin) * 0.5), 2) * 100.0
    printfn "Positioning result: %f" print
    Html.div [
        prop.style [style.width (length.perc 100)]
        prop.children [
            Html.div [
                prop.children [
                    Html.div [
                        prop.style [
                            style.position.absolute  // change from relative to absolute
                            style.left (length.perc (int ((positioning props.labRangeMax props.labRangeMin props.labValue))))
                            style.transform.translateX (length.perc -50) // Shift to the left by half of its width
                            style.color.gray
                            style.fontSize 14
                            style.marginTop 7
                        ]
                        prop.children [
                            Bulma.tag [
                                    prop.classes ["has-text-weight-bold"]
                                    prop.style [style.backgroundColor "#1fad50"; style.color.white]
                                    prop.text props.labValue
                                ]
                        ]
                    ]

                    Html.div [
                        prop.style [
                            style.position.absolute  // change from relative to absolute
                            style.left (length.perc (int ((positioning props.labRangeMax props.labRangeMin props.labValue))))
                            style.transform.translateX (length.perc -50) // Shift to the left by half of its width
                            style.color.gray
                            style.fontSize 14
                            style.marginTop 20
                        ]
                        prop.children [
                            Html.i [
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


                ]
            ]
            normalRangeBar
        ]
    ]

[<ReactComponent>]
let LabCard (props:LabDetails) =
    Bulma.section [
        Bulma.card [
            Bulma.cardContent [
                Bulma.media [

                    Bulma.mediaContent [
                        Bulma.title.p [
                            Bulma.title.is6
                            prop.style [style.color.black]
                            prop.text "Specific gravity, UA"
                        ]
                        Bulma.subtitle.p [
                            Bulma.title.is6
                            prop.style [style.color.gray]
                            prop.text "Normal range: 4.0 - 6.0"
                        ]
                    ]
                    // Bulma.mediaRight [
                    //     Html.image [
                    //         prop.src "https://bulma.io/images/placeholders/128x128.png"
                    //     ]
                    // ]
                ]

            ]
            Html.div [
                prop.className classes.centeredContainer
                prop.children [
                    RangeBarWithArrow LabData
                ]
            ]
            Html.div [
                prop.style [ style.display.flex ; style.flexDirection.row]
                prop.children [
                    Html.div [
                        prop.style [ style.display.flex ; style.flexDirection.row]
                        prop.children [
                            Html.div [
                                prop.style [
                                    style.position.absolute  // change from relative to absolute
                                    style.left (length.perc 25) // 25% position
                                    style.transform.translateX (length.perc -50) // Shift to the left by half of its width
                                    style.color.gray
                                    style.fontSize 14
                                    style.marginTop -48
                                ]
                                prop.children [
                                    Html.text (string props.labRangeMin)
                                ]
                            ]
                            Html.div [
                                prop.style [
                                    style.position.absolute  // change from relative to absolute
                                    style.left (length.perc 75)  // 75% position
                                    style.transform.translateX (length.perc -50) // Shift to the left by half of its width
                                    style.color.gray
                                    style.fontSize 14
                                    style.marginTop -48
                                ]
                                prop.children [
                                    Html.text (string props.labRangeMax)
                                ]
                            ]
                        ]
                    ]
                ]
            ]


        ]
        Html.div [
            prop.className classes.centeredDiv

            prop.children [
                Bulma.button.button [
                    button.isRounded
                    Bulma.color.isSuccess
                    prop.children [
                        Bulma.icon [
                            Icon [
                                icon.icon mdi.autorenew
                                icon.color "white"
                                icon.width 20
                            ]
                        ]
                        Html.div [
                            prop.children [
                                Html.text "Refill Medications"
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]








let render () =
    LabCard(LabData)
