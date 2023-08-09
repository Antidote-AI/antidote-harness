module Healix.Components.MedicationCard

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


let private classes : CssModules.Components.MedicationCard = import "default" "./MedicationCard.module.scss"

[<ReactComponent>]
let MedicationCard () =
    let (isOpen, setIsOpen) = React.useState false
    Bulma.section [
        Bulma.card [
            Bulma.cardContent [
                Bulma.media [
                    Bulma.mediaLeft [
                        Bulma.cardImage [
                            Bulma.image [
                                Bulma.image.is24x24
                                prop.style [style.marginTop 6]
                                prop.children [
                                    Html.img [
                                        prop.alt "Placeholder image"
                                        prop.src "/images/medication.svg"
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Bulma.mediaContent [
                        Bulma.title.p [
                            Bulma.title.is4
                            prop.style [style.color.black]
                            prop.text "Metformin 200mg tablet"
                        ]
                        Bulma.subtitle.p [
                            Bulma.title.is6
                            prop.style [style.color.gray]
                            prop.text "Commonly known as: Vantin"
                        ]
                        Bulma.subtitle.p [
                            Bulma.title.is6
                            prop.style [style.color.black; style.marginTop -20; style.fontSize 16]
                            prop.text "Take 1 tablet by mouth 2 times daily for 30 days."
                        ]
                    ]
                    Bulma.mediaContent [
                        Bulma.cardImage [
                            Bulma.image [
                                Bulma.image.is16x16
                                prop.style [style.marginRight 5; style.marginTop 5]
                                prop.children [
                                    Html.img [
                                        prop.alt "Placeholder image"
                                        prop.src "/images/info-blue.svg"
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]

            ]
            Html.div [
                prop.style [
                    style.borderTop(1, borderStyle.solid, color.whiteSmoke)
                ]
                prop.onClick (fun _ -> setIsOpen (not isOpen))
                prop.children [
                    if not isOpen then
                        Html.div [
                            Bulma.image.is24x24
                            prop.classes ["pl-5"; "p-2"]
                            prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; ]
                            prop.children [
                                Html.img [
                                    prop.alt "Placeholder image"
                                    prop.src "/images/info.svg"
                                    prop.style [style.width 16; style.height 16;style.display.flex; style.alignContent.center]
                                ]
                                Html.div [
                                    prop.classes ["pl-2"]
                                    prop.style [style.color.black; style.width (length.perc 100)]
                                    prop.children [
                                        Html.text "Show Details"
                                    ]
                                ]
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
                    else
                        Html.div [
                            Bulma.image.is24x24
                            prop.classes ["pl-5"; "p-2"]
                            prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; ]
                            prop.children [
                                Html.img [
                                    prop.alt "Placeholder image"
                                    prop.src "/images/info.svg"
                                    prop.style [style.width 16; style.height 16;style.display.flex; style.alignContent.center]
                                ]
                                Html.div [
                                    prop.classes ["pl-2"]
                                    prop.style [style.color.black; style.width (length.perc 100)]
                                    prop.children [
                                        Html.text "Show Details"
                                    ]
                                ]
                                Html.div [
                                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
                                    prop.children [
                                        Html.i [
                                            Icon [
                                                icon.icon mdi.chevronDown
                                                icon.color "grey"
                                                icon.width 25
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                        Html.div [
                            prop.style [
                                style.color.black;
                                style.display.flex;
                                style.flexDirection.row;
                                style.justifyContent.spaceEvenly; // This line achieves the desired behavior
                            ]
                            prop.children [
                                Html.div [
                                    prop.classes ["ml-2"]
                                    prop.children [
                                        Html.div [
                                            prop.style [style.fontSize 14; style.fontWeight.bold]
                                            prop.children [
                                                Html.text "Prescription Details"
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.fontSize 14; style.marginTop 3; style.color.gray]
                                            prop.children [
                                                Html.text "Prescribed Aug 3, 2023"
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.fontSize 14; style.marginTop 3; style.color.gray]
                                            prop.children [
                                                Html.text ("Prescriber: " + "Palmerola, Ricardo Campo")
                                            ]
                                        ]

                                    ]
                                ]
                                Html.div [
                                    prop.classes ["mr-2"]
                                    prop.children [
                                        Html.div [
                                            prop.style [style.fontSize 14; style.fontWeight.bold]
                                            prop.children [
                                                Html.text "Refill Details"
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.fontSize 14; style.marginTop 3; style.color.gray]
                                            prop.children [
                                                Html.text "Quantity 60 tablets"
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.fontSize 14; style.marginTop 3; style.color.gray]
                                            prop.children [
                                                Html.text "Day supply 30"
                                            ]
                                        ]

                                    ]
                                ]
                            ]
                        ]


                ]
            ]
            Html.div [
                prop.style [
                    style.borderTop(1, borderStyle.solid, color.whiteSmoke)
                ]
                prop.children [
                    Html.div [
                        Bulma.image.is24x24
                        prop.classes ["pl-5"; "p-2"]
                        prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; ]
                        prop.children [
                            Html.img [
                                prop.alt "Placeholder image"
                                prop.src "/images/medication-refill.svg"
                                prop.style [style.width 20; style.height 20; style.display.flex; style.alignContent.center]
                            ]
                            Html.div [
                                prop.classes ["pl-2"]
                                prop.style [style.color.black; style.width (length.perc 100)]
                                prop.children [
                                    Html.text "Refill Medications"
                                ]
                            ]
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
            ]
            Html.div [
                prop.style [
                    style.borderTop(1, borderStyle.solid, color.whiteSmoke)
                ]
                prop.children [
                    Html.div [
                        Bulma.image.is24x24
                        prop.classes ["pl-5"; "p-2"]
                        prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; ]
                        prop.children [
                            Html.img [
                                prop.alt "Placeholder image"
                                prop.src "/images/trash-thin.svg"
                                prop.style [style.width 16; style.height 16;style.display.flex; style.alignContent.center]
                            ]
                            Html.div [
                                prop.classes ["pl-2"]
                                prop.style [style.color.black; style.width (length.perc 100)]
                                prop.children [
                                    Html.text "Delete"
                                ]
                            ]
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
                            //prop.classes ["has-text-weight-bold"]
                            prop.children [
                                Html.text "Refill Medications"
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]
