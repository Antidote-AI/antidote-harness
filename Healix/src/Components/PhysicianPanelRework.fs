module Healix.Components.PhysicianPanelRework

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


let private classes : CssModules.Components.PhysicianPanelRework = import "default" "./PhysicianPanelRework.module.scss"


[<ReactComponent>]
let PhysicianCard () =
    Bulma.card [
        prop.style [ style.borderRadius 12; style.marginTop 10 ]
        prop.children [
            Bulma.cardContent [
                Bulma.media [
                    prop.style [ style.alignItems.center]
                    prop.children [
                        Bulma.mediaLeft [
                            Bulma.cardImage [
                                Bulma.image [
                                    Bulma.image.is64x64
                                    prop.children [
                                        Html.img [
                                            prop.alt "Placeholder image"
                                            prop.src ".././Assets/alan-katz.jpg"
                                            prop.style [style.width 54; style.height 64]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                        Bulma.mediaContent [
                            prop.style [ style.display.flex; style.flexDirection.column]
                            prop.children [
                                Bulma.title.p [
                                    Bulma.title.is4
                                    prop.style [style.color "#1e4d8a"]
                                    prop.text "Alan Katz"
                                ]
                                Bulma.subtitle.p [
                                    Bulma.title.is6
                                    prop.style [style.color.dimGray]
                                    prop.text "Primary Care"
                                ]
                            ]
                        ]
                        Bulma.mediaRight [
                            Bulma.cardImage [
                                Bulma.image [
                                    Bulma.image.is16x16
                                    prop.children [
                                        Html.i [
                                            Html.i [
                                                prop.style [ style.color "#1e4d8a"]
                                                prop.classes [ "fas"; "fa-chevron-right"]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
                Bulma.mediaContent [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop -10]
                    prop.children [
                        Html.img [prop.src ".././Assets/star-yellow.svg"; prop.style [style.width 15; style.height 15]]
                        Html.p [prop.style [style.color.black; style.fontSize 16; style.marginLeft 3; style.fontWeight.bold]; prop.text "4.9"]
                        Html.p [prop.style [style.color.gray; style.fontSize 16; style.marginLeft 8]; prop.text "(4,279 reviews)"]
                    ]
                ]
                Html.div [
                    prop.style [style.display.flex; style.flexDirection.row]
                    prop.children [
                        Html.p [
                            Bulma.title.is6
                            prop.text ("First Available:" + " " + "Octover 12, 2023")
                            prop.style [style.fontWeight 600; style.color.black; style.marginTop 5; style.color.dimGray]
                        ]
                        Bulma.icon [
                            prop.style [style.marginLeft 5]
                            prop.children [
                                Icon [
                                    icon.icon mdi.location
                                    icon.width 20
                                    icon.height 20
                                    icon.color "black"

                                ]
                            ]
                        ]
                        Bulma.icon [
                            prop.style [style.marginLeft 5]
                            prop.children [
                                Icon [
                                    icon.icon mdi.videoCall
                                    icon.width 25
                                    icon.height 25
                                    icon.color "black"

                                ]
                            ]
                        ]
                    ]
                ]
                Bulma.mediaContent [
                    Bulma.subtitle.p [
                        Bulma.title.is6
                        prop.text "4.14 Miles"
                        prop.style [style.fontWeight 600; style.color.black; style.marginTop 5]
                    ]
                ]
                Bulma.mediaContent [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop 5]
                    prop.children [
                        Bulma.icon [
                            prop.style [style.marginRight 5]
                            prop.children [
                                Icon [
                                    icon.icon mdi.location
                                    icon.width 20
                                    icon.height 20
                                    icon.color "black"

                                ]
                            ]
                        ]
                        Html.div [
                            prop.style [style.display.flex; style.flexDirection.column]
                            prop.children [
                                Html.p [
                                    prop.text "BH Primary Care Doral"
                                    prop.style [style.fontWeight 400; style.color.dimGray]
                                ]
                                Html.p [
                                    Bulma.title.is6
                                    prop.text "8400 Northwest 53rd Street Doral, FL 33166"
                                    prop.style [style.fontWeight 400; style.color.dimGray]
                                ]
                            ]
                        ]
                    ]
                ]
                Bulma.mediaContent [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop 5]
                    prop.children [
                        Bulma.icon [
                            prop.style [style.marginRight 5]
                            prop.children [
                                Icon [
                                    icon.icon mdi.phoneDial
                                    icon.width 20
                                    icon.height 20
                                    icon.color "black"

                                ]
                            ]
                        ]
                        Html.div [
                            prop.style [style.display.flex; style.flexDirection.column]
                            prop.children [
                                Html.p [
                                    prop.text "305-206-4761"
                                    prop.style [style.fontWeight 400; style.color.dimGray]
                                ]
                            ]
                        ]
                    ]
                ]
                Bulma.mediaContent [
                    prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop 10]
                    prop.children [
                        Bulma.button.button [
                            button.isRounded
                            button.isFullWidth
                            prop.classes ["has-background-primary"; "has-text-white"]
                            prop.style [style.fontWeight 600]
                            prop.children [
                                Bulma.icon [
                                    prop.style [style.marginRight 5]
                                    prop.children [
                                        Icon [
                                            icon.icon mdi.calendarAccountOutline
                                            icon.width 20
                                            icon.height 20
                                            icon.color "white"

                                        ]
                                    ]
                                ]
                                Html.text "Book Appointment"
                            ]

                        ]
                    ]
                ]
            ]
        ]
    ]



// Bulma.image [
//     Bulma.image.is4by3
//     prop.children [
//         Html.img [
//             prop.src ".././Assets/alan-katz.jpg"
//             prop.alt "doctor's profile logo"
//             prop.classes [ "image"; "p-1"; "ml-1"]
//             prop.style [style.borderRadius 10; style.width 65; style.height 75]
//         ]
//     ]
// ]


[<ReactComponent>]
let PhysicianPanelRework () =

    Html.section [
        prop.style [style.display.flex; style.justifyContent.center; style.backgroundColor.white; style.width (length.perc 100); style.marginTop 10]
        //prop.classes [ classes.margin ]
        prop.children [
            Bulma.columns [
                prop.style [style.width (length.perc 100)]
                //prop.classes [ classes.margin ]
                prop.children [
                    Bulma.column [
                        Bulma.column.is4
                        prop.children [
                            PhysicianCard ()
                            PhysicianCard ()
                            PhysicianCard ()

                        ]

                    ]
                    Bulma.column [
                        Bulma.column.is4
                        prop.children [
                            PhysicianCard ()
                            PhysicianCard ()
                            PhysicianCard ()
                        ]

                    ]
                    Bulma.column [
                        Bulma.column.is4
                        prop.children [
                            PhysicianCard ()
                            PhysicianCard ()
                            PhysicianCard ()
                        ]

                    ]
                ]
            ]
        ]
    ]








//working buttons:

// Html.div [
//     prop.classes ["is-flex"; "is-flex-grow-1"]
//     prop.children [
//         Html.button [
//             prop.classes [ "button"; "is-rounded"; "is-primary"; "is-outlined"; "is-size-6"; "px-6"; "is-fullwidth"]
//             prop.className [classes.buttonContainer;classes.buttonContainer2]
//             prop.text "Cancel Appointment"
//         ]
//     ]
// ]
// Html.div [
//     prop.classes ["is-flex"; "is-flex-grow-1"]
//     prop.children [
//         Html.button [
//             prop.classes [ "button"; "is-primary"; "is-rounded"; "is-primary"; "is-size-6"; "px-6"; "is-fullwidth"]
//             prop.className [classes.buttonContainer;classes.buttonContainer2]
//             prop.text "Reschedule"
//         ]
//     ]
// ]
