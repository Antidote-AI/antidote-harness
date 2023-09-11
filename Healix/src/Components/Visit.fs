module Healix.Components.Visit

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


let private classes : CssModules.Components.Visit = import "default" "./Visit.module.scss"


//[<ReactComponent>]
// let StarRating() =
//     let (rating, setRating) = React.useState(0)

//     Html.div [
//         prop.style [style.paddingBottom 15; style.borderBottom(1, borderStyle.solid, color.whiteSmoke)]
//         prop.children [
//             for i in 1..5 do
//                 if i <= rating then
//                     Html.i [
//                         prop.onClick (fun _ -> setRating i)

//                         prop.children [
//                             Icon [
//                                 icon.icon mdi.star
//                                 icon.width 40
//                                 icon.height 40
//                                 icon.color "#f4c430"

//                             ]
//                         ]

//                     ]

//                 else
//                     Html.i [
//                         prop.onClick (fun _ -> setRating i)
//                         prop.children [
//                             Icon [
//                                 icon.icon mdi.starOutline
//                                 icon.width 40
//                                 icon.height 40
//                                 icon.color "#f4c430"

//                             ]
//                         ]
//                     ]
//         ]
//     ]

[<ReactComponent>]
let Visit () =

    // let (heartSelected, setHeartSelected) = React.useState(false)
    // let (rating, setRating) = React.useState(fun () -> None)
    let isTypeDropdownActive, setIsTypeDropdownActive = React.useState false

    Html.section [
        prop.children [
            Html.div [
                prop.style [
                    style.display.flex
                    style.justifyContent.center
                    //style.flexDirection.column
                ]
                prop.children [


                    Html.div [
                        prop.style [
                            style.width (length.perc 100)
                            style.display.flex
                            style.justifyContent.center
                            style.flexDirection.column
                        ]
                        prop.children [
                            Html.div [
                                Html.p "Please be aware the self-pay cost for a visit can range from $250.00 to $600.000 depensing on services provided"
                            ]
                            Html.div [
                                Html.p "What type of appointment are you scheduling?"
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.margin 20; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                                prop.children [
                                    Html.img [
                                            prop.classes ["m-3"]
                                            prop.alt "Placeholder image"
                                            prop.src "/images/doctor.svg"
                                            prop.style [style.width 40; style.height 40; style.display.flex; style.alignContent.center]
                                        ]
                                    Html.div [
                                        prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.center; style.width (length.perc 80)]
                                        prop.children [
                                            Html.div [
                                                Html.strong " Schedule New Patient Office Visit"
                                            ]
                                            Html.div [
                                                prop.style [style.color.gray; style.fontSize 14]
                                                prop.children [
                                                    Html.text " Schedule a general visit as a new patient"
                                                ]
                                            ]
                                        ]
                                    ]

                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.margin 20; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                                prop.children [
                                    Html.img [
                                            prop.classes ["m-3"]
                                            prop.alt "Placeholder image"
                                            prop.src "/images/laptop.svg"
                                            prop.style [style.width 40; style.height 40; style.display.flex; style.alignContent.center]
                                        ]
                                    Html.div [
                                        prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.center; style.width (length.perc 80)]
                                        prop.children [
                                            Html.div [
                                                Html.strong " Schedule Video Visit"
                                            ]
                                            Html.div [
                                                prop.style [style.color.gray; style.fontSize 14]
                                                prop.children [
                                                    Html.text " Schedule a general visit as a new patient"
                                                ]
                                            ]
                                        ]
                                    ]

                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.justifyContent.center; style.flexDirection.column; style.width (length.perc 100); style.alignContent.center; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        Html.strong "What is the reason for your visit?"
                                    ]
                                    Html.div [
                                        prop.style [style.display.flex; style.justifyContent.center; style.textAlign.left;style.color.gray]
                                        prop.children [
                                            Html.text "If you are experiencing a medical emergency, any thoughts of suicide, self harm, or harming someone else please call 911 for immediate assistance."
                                        ]
                                    ]
                                    Bulma.fieldBody [
                                        prop.children [
                                            Html.div [
                                                Bulma.dropdown [
                                                    if isTypeDropdownActive then dropdown.isActive
                                                    prop.children [
                                                        Bulma.dropdownTrigger [
                                                            Bulma.button.button [
                                                                button.isFullWidth
                                                                //button.isSmall
                                                                prop.onClick (fun _ -> setIsTypeDropdownActive (not isTypeDropdownActive))
                                                                prop.onBlur (fun _ -> setIsTypeDropdownActive false)
                                                                prop.children [
                                                                    Html.text "Patient"
                                                                    Html.div [
                                                                        prop.children [
                                                                            Bulma.icon [
                                                                                //Bulma.icon.isLeft
                                                                                prop.children [ Html.i [ prop.className "fas fa-chevron-down" ] ]
                                                                            ]
                                                                        ]

                                                                    ]
                                                                ]
                                                            ]
                                                        ]
                                                        Bulma.dropdownMenu [
                                                            Bulma.dropdownContent [
                                                                Bulma.dropdownItem.a "Patient"
                                                                Bulma.dropdownItem.a "Clinician"
                                                                Bulma.dropdownItem.a "Clinician Manager"
                                                                Bulma.dropdownItem.a "Care Coordinator"
                                                                Bulma.dropdownItem.a "Admin"
                                                            ]
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]
