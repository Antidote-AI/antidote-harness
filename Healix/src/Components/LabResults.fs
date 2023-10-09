module Healix.Components.LabResults

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


let private classes : CssModules.Components.LabResults = import "default" "./LabResults.module.scss"

[<ReactComponent>]
let LabResults () =
    Bulma.panel [
        Bulma.panelHeading [ prop.text "Lab Results" ]
        Bulma.panelBlock.div [
            Bulma.control.div [
                Bulma.control.hasIconsLeft
                prop.children [
                    Bulma.input.text [ prop.placeholder "Search" ]
                    Bulma.icon [
                        Bulma.icon.isLeft
                        prop.children [ Html.i [ prop.className "fas fa-search" ] ]
                    ]
                ]
            ]
        ]
        Bulma.panelBlock.div [
            prop.className "is-active"
            //prop.style [style.width (length.perc 100)]
            prop.children [
                Html.div [
                   Html.img [
                        prop.alt "Placeholder image"
                        prop.src "/images/flask.svg"
                        prop.style [style.width 60; style.height 60; style.display.flex; style.alignContent.center]
                    ]
                ]
                Html.div [
                    prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
                    prop.children [
                        Html.div [
                            prop.style [style.fontWeight.bold; style.color.black]
                            prop.children [
                                Html.span "Blood Culture"
                            ]
                        ]
                        Html.div [
                            prop.style [style.color.gray; style.fontSize 14]
                            prop.children [
                                Html.span "Aug 23, 2023"
                            ]
                        ]

                    ]
                ]
                //Html.span "Urine Culture"
                Html.div [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
                    prop.children [
                        Html.i [
                            Icon [
                                icon.icon mdi.chevronRight
                                icon.color "grey"
                                icon.width 25
                            ]
                        ]
                    ]
                ]
            ]

        ]
        Bulma.panelBlock.div [
            prop.className "is-active"
            //prop.style [style.width (length.perc 100)]
            prop.children [
                Html.div [
                   Html.img [
                        prop.alt "Placeholder image"
                        prop.src "/images/flask.svg"
                        prop.style [style.width 60; style.height 60; style.display.flex; style.alignContent.center]
                    ]
                ]
                Html.div [
                    prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
                    prop.children [
                        Html.div [
                            prop.style [style.fontWeight.bold; style.color.black]
                            prop.children [
                                Html.span "Blood Culture"
                            ]
                        ]
                        Html.div [
                            prop.style [style.color.gray; style.fontSize 14]
                            prop.children [
                                Html.span "Aug 23, 2023"
                            ]
                        ]

                    ]
                ]
                //Html.span "Urine Culture"
                Html.div [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
                    prop.children [
                        Html.i [
                            Icon [
                                icon.icon mdi.chevronRight
                                icon.color "grey"
                                icon.width 25
                            ]
                        ]
                    ]
                ]
            ]

        ]
        Bulma.panelBlock.div [
            prop.className "is-active"
            //prop.style [style.width (length.perc 100)]
            prop.children [
                Html.div [
                   Html.img [
                        prop.alt "Placeholder image"
                        prop.src "/images/flask.svg"
                        prop.style [style.width 60; style.height 60; style.display.flex; style.alignContent.center]
                    ]
                ]
                Html.div [
                    prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
                    prop.children [
                        Html.div [
                            prop.style [style.fontWeight.bold; style.color.black]
                            prop.children [
                                Html.span "Blood Culture"
                            ]
                        ]
                        Html.div [
                            prop.style [style.color.gray; style.fontSize 14]
                            prop.children [
                                Html.span "Aug 23, 2023"
                            ]
                        ]

                    ]
                ]
                //Html.span "Urine Culture"
                Html.div [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
                    prop.children [
                        Html.i [
                            Icon [
                                icon.icon mdi.chevronRight
                                icon.color "grey"
                                icon.width 25
                            ]
                        ]
                    ]
                ]
            ]

        ]
        Bulma.panelBlock.div [
            prop.className "is-active"
            //prop.style [style.width (length.perc 100)]
            prop.children [
                Html.div [
                   Html.img [
                        prop.alt "Placeholder image"
                        prop.src "/images/flask.svg"
                        prop.style [style.width 60; style.height 60; style.display.flex; style.alignContent.center]
                    ]
                ]
                Html.div [
                    prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
                    prop.children [
                        Html.div [
                            prop.style [style.fontWeight.bold; style.color.black]
                            prop.children [
                                Html.span "Blood Culture"
                            ]
                        ]
                        Html.div [
                            prop.style [style.color.gray; style.fontSize 14]
                            prop.children [
                                Html.span "Aug 23, 2023"
                            ]
                        ]

                    ]
                ]
                //Html.span "Urine Culture"
                Html.div [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
                    prop.children [
                        Html.i [
                            Icon [
                                icon.icon mdi.chevronRight
                                icon.color "grey"
                                icon.width 25
                            ]
                        ]
                    ]
                ]
            ]

        ]

    ]
