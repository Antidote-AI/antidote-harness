module Healix.Components.Profile

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
//open Feliz.Bulma.DateTimePicker


// open Antidote.Core.V2.Utils.JS

emitJsStatement () "import React from \"react\""


let private classes : CssModules.Components.Profile = import "default" "./Profile.module.scss"

let MenuItem () =
    Html.div [
        //prop.style [style.margin 0; style.borderTop(1, borderStyle.solid, color.whiteSmoke); style.borderBottom(1, borderStyle.solid, color.whiteSmoke) ]
        prop.children [
            Html.aside [
                prop.className "menu"
                prop.children [
                    Html.div [
                        // Adding flex display and spaceBetween
                        prop.style [ style.display.flex; style.justifyContent.spaceBetween; style.color.black; style.marginLeft 5; style.marginTop 11 ]
                        prop.children [
                            Html.div [
                                prop.style [ style.display.flex; style.alignItems.center ]
                                prop.children [
                                    // Puzzle icon
                                    Bulma.icon [
                                        prop.className "fas fa-puzzle-piece"
                                    ]
                                    // General text
                                    Html.p [
                                        prop.style[ style.margin 0;style.marginLeft 4 ]
                                        prop.className "menu-label"
                                        prop.text "General"
                                    ]
                                ]
                            ]
                            // Chevron icon
                            Bulma.icon [
                                Bulma.icon.isRight
                                prop.children [
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




let Profile() =
    Html.section [
        prop.children [
            Html.div [
                prop.className [classes.Container]
                //prop.classes ["appointmentViewerList__container-image"; "is-flex"; "is-align-items-center"; "is-justify-content-center"; "image"; "is-128x128"]
                prop.children [

                    Html.img [
                        prop.src ".././Assets/alan-katz.jpg"
                        prop.alt "doctor's profile logo"
                        prop.classes [ classes.DoctorImage; "image"; "p-1"; "p-2"]
                        prop.style [style.height 120; style.borderRadius 9]
                    ]
                ]
            ]
            Html.div [
                prop.children [
                    Html.h1 [
                        prop.classes ["has-text-weight-bold"; "is-size-3"; "has-text-centered"; "p-2"]
                        prop.text "Name"
                        prop.style [ style.textAlign.center ]
                    ]
                    Html.h2 [
                        prop.classes ["has-text-weight-bold"; "is-size-5"; "has-text-centered"; "p-2"]
                        prop.text "phoneNumber"
                        prop.style [ style.textAlign.center ]
                    ]
                ]
            ]
            MenuItem ()
            MenuItem ()
            MenuItem ()
            MenuItem ()
            MenuItem ()
            MenuItem ()
        ]
    ]
