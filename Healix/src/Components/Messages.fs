module Healix.Components.Messages

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

type MessageData = {
    Name: string
    Date: string
    Message: string
}

let data = {
    Name = "Dr. John Doe"
    Date = "Aug 23, 2023"
    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus, nec rutrum justo nibh eu lectus."
}


let private classes : CssModules.Components.Messages = import "default" "./Messages.module.scss"

[<ReactComponent>]
// let Messages (props:MessageData) =
//     Bulma.panel [
//         Bulma.panelHeading [ prop.text "Messages" ]
//         Bulma.panelBlock.div [
//             Bulma.control.div [
//                 Bulma.control.hasIconsLeft
//                 prop.children [
//                     Bulma.input.text [ prop.placeholder "Search" ]
//                     Bulma.icon [
//                         Bulma.icon.isLeft
//                         prop.children [ Html.i [ prop.className "fas fa-search" ] ]
//                     ]
//                 ]
//             ]
//         ]
//         // Bulma.panelTabs [
//         //     Html.a [
//         //         prop.className "is-active"
//         //         prop.text "All"
//         //     ]
//         //     Html.a [ prop.text "Public" ]
//         //     Html.a [ prop.text "Private" ]
//         //     Html.a [ prop.text "Sources" ]
//         //     Html.a [ prop.text "Forks" ]
//         // ]
//         Bulma.panelBlock.div [
//             prop.className "is-active"
//             //prop.style [style.width (length.perc 100)]
//             prop.children [
//                 // Html.div [
//                 //    Html.img [
//                 //         prop.alt "Placeholder image"
//                 //         prop.src "/images/flask.svg"
//                 //         prop.style [style.width 60; style.height 60; style.display.flex; style.alignContent.center]
//                 //     ]
//                 // ]
            //     Html.div [
            //         prop.children [
            //             Html.img [
            //                 prop.style [style.width 120; style.height 60]
            //                 prop.src ".././Assets/me.jpeg"
            //                 //prop.alt "messaging icon"
            //                 prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
            //             ]
            //         ]
            //     ]
            //     let truncatedStr = props.Message.Substring(0, 75)
            //     Html.div [
            //         prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
            //         prop.children [
            //             Html.div [
            //                 prop.style [style.fontWeight.bold; style.color.black]
            //                 prop.children [
            //                     Html.span props.Name
            //                 ]
            //             ]
            //             Html.div [
            //                 prop.style [style.color.gray; style.fontSize 14]
            //                 prop.children [
            //                     Html.span (truncatedStr + "...")
            //                 ]
            //             ]

            //         ]
            //     ]
            //     //Html.span "Urine Culture"
            //     // Html.div [
            //     //     prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
            //     //     prop.children [
            //     //         Html.i [
            //     //             Icon [
            //     //                 icon.icon mdi.chevronRight
            //     //                 icon.color "grey"
            //     //                 icon.width 25
            //     //             ]
            //     //         ]
            //     //     ]
            //     // ]
            //     Html.div [
            //         prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
            //         prop.children [
            //             Html.div [
            //                 prop.style [style.backgroundColor "#006ee6"; style.color.white; style.height 20; style.width 20; style.display.flex; style.alignItems.center; style.justifyContent.center; style.fontWeight.bold; style.fontSize 12]
            //                 prop.classes [classes.MessagingIcon]
            //                 prop.children [
            //                     Html.text "2"
            //                 ]
            //             ]
            //         ]
            //     ]
            // ]

//         ]
//         Bulma.panelBlock.div [
//             prop.className "is-active"
//             //prop.style [style.width (length.perc 100)]
//             prop.children [
//                 Html.div [
//                    Html.img [
//                         prop.alt "Placeholder image"
//                         prop.src "/images/flask.svg"
//                         prop.style [style.width 60; style.height 60; style.display.flex; style.alignContent.center]
//                     ]
//                 ]
//                 Html.div [
//                     prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
//                     prop.children [
//                         Html.div [
//                             prop.style [style.fontWeight.bold; style.color.black]
//                             prop.children [
//                                 Html.span "Blood Culture"
//                             ]
//                         ]
//                         Html.div [
//                             prop.style [style.color.gray; style.fontSize 14]
//                             prop.children [
//                                 Html.span "Aug 23, 2023"
//                             ]
//                         ]

//                     ]
//                 ]
//                 //Html.span "Urine Culture"
//                 Html.div [
//                     prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
//                     prop.children [
//                         Html.i [
//                             Icon [
//                                 icon.icon mdi.chevronRight
//                                 icon.color "grey"
//                                 icon.width 25
//                             ]
//                         ]
//                     ]
//                 ]
//             ]

//         ]
//         Bulma.panelBlock.div [
//             prop.className "is-active"
//             //prop.style [style.width (length.perc 100)]
//             prop.children [
//                 Html.div [
//                    Html.img [
//                         prop.alt "Placeholder image"
//                         prop.src "/images/flask.svg"
//                         prop.style [style.width 60; style.height 60; style.display.flex; style.alignContent.center]
//                     ]
//                 ]
//                 Html.div [
//                     prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
//                     prop.children [
//                         Html.div [
//                             prop.style [style.fontWeight.bold; style.color.black]
//                             prop.children [
//                                 Html.span "Blood Culture"
//                             ]
//                         ]
//                         Html.div [
//                             prop.style [style.color.gray; style.fontSize 14]
//                             prop.children [
//                                 Html.span "Aug 23, 2023"
//                             ]
//                         ]

//                     ]
//                 ]
//                 //Html.span "Urine Culture"
//                 Html.div [
//                     prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
//                     prop.children [
//                         Html.i [
//                             Icon [
//                                 icon.icon mdi.chevronRight
//                                 icon.color "grey"
//                                 icon.width 25
//                             ]
//                         ]
//                     ]
//                 ]
//             ]

//         ]
//     ]

let Messages (props:MessageData) =
    Html.div [
        prop.style [style.display.flex; style.flexDirection.row]
        prop.children [
            Html.div [
                prop.children [
                    Html.img [
                        prop.style [style.width 120; style.height 60]
                        prop.src ".././Assets/me.jpeg"
                        //prop.alt "messaging icon"
                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                    ]
                ]
            ]
            let truncatedStr = props.Message.Substring(0, 15)
            Html.div [
                prop.style [style.color.black; style.width (length.perc 100); style.paddingLeft 7]
                prop.children [
                    Html.div [
                        prop.style [style.fontWeight.bold; style.color.black]
                        prop.children [
                            Html.span props.Name
                        ]
                    ]
                    Html.div [
                        prop.style [style.color.gray; style.fontSize 14]
                        prop.children [
                            Html.span (truncatedStr + "...")
                        ]
                    ]

                ]
            ]
            //Html.span "Urine Culture"
            // Html.div [
            //     prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
            //     prop.children [
            //         Html.i [
            //             Icon [
            //                 icon.icon mdi.chevronRight
            //                 icon.color "grey"
            //                 icon.width 25
            //             ]
            //         ]
            //     ]
            // ]
            Html.div [
                prop.style [style.display.flex; style.flexDirection.row; style.alignItems.center; style.justifyContent.flexEnd;style.width (length.perc 100)]
                prop.children [
                    Html.div [
                        prop.style [style.backgroundColor "#006ee6"; style.color.white; style.height 20; style.width 20; style.display.flex; style.alignItems.center; style.justifyContent.center; style.fontWeight.bold; style.fontSize 12]
                        prop.classes [classes.MessagingIcon]
                        prop.children [
                            Html.text "2"
                        ]
                    ]
                ]
            ]
        ]
    ]
