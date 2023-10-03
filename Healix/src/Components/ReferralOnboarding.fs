module Healix.Components.ReferralOnboarding

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


let private classes : CssModules.Components.ReferralOnboarding = import "default" "./ReferralOnboarding.module.scss"


let ReferralOnboarding () =
    Html.div [
        prop.style [
            style.width (length.perc 100);
            style.height (length.vh 100) (* Set root div height to 100vh *)
        ]
        prop.children [
            Bulma.navbarMenu [
                Bulma.navbarStart.div [
                    Bulma.navbarBrand.div [
                        Bulma.navbarItem.a [
                            Html.img [ prop.src ".././Assets/antidote_emblem.png"; prop.height 28; prop.width 112; ]
                        ]
                    ]
                    Bulma.navbarItem.a [
                        prop.style [style.color.black]
                        prop.href "https://www.antidote-ai.com/"
                        prop.onClick (fun _ -> ())
                        prop.text "Website"
                    ]
                    Bulma.navbarItem.a [
                        prop.style [style.color.black]
                        prop.href "https://www.antidote-ai.com/contact-us"
                        prop.onClick (fun _ -> ())
                        prop.text "Contact"
                    ]
                ]
                Bulma.navbarEnd.div [
                    Bulma.navbarItem.div [
                        Bulma.buttons [
                            Bulma.button.a [
                                Bulma.color.isPrimary
                                prop.href "https://healix.antidote-ai.com/signup"
                                prop.onClick (fun _ -> ())
                                prop.children [
                                    Html.strong "Sign up"
                                ]
                            ]
                            Bulma.button.a [
                                prop.style [style.color.black]
                                prop.href "https://healix.antidote-ai.com/login"
                                prop.text "Log In"
                                prop.onClick (fun _ -> ())
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.style [
                    style.height (length.perc 10)
                    style.color.white
                ]
                prop.children [
                    Html.text "Welcome to Healix"
                ]
            ]
            Html.div [
                prop.style [
                    //style.display.flex;
                    style.justifyContent.center;  (* Vertically centers children *)
                    style.alignItems.center
                ]
                prop.children [
                    Html.div [
                        prop.style [
                            style.flexBasis (length.perc 50);
                            style.display.flex;
                            style.justifyContent.center; (* Vertically centers the image *)
                            style.alignItems.center;
                        ]
                        prop.children [
                            Html.img [

                                prop.src ".././Assets/medicalimage.png"
                                prop.style [style.width (length.perc 40); style.height (length.perc 20); style.borderRadius 10]
                                //prop.className classes.profileImage
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [
                            style.display.flex;
                            style.flexDirection.column;
                            style.justifyContent.center;
                            style.alignItems.center;
                            style.flexBasis (length.perc 50);
                            style.fontSize 60;
                        ]
                        prop.children [
                            Html.strong "Refer a patient"
                            Html.div [
                                prop.style [
                                    style.color.lightSlateGray;
                                    style.fontSize 20;
                                    style.marginTop 10;
                                    style.width (length.perc 60);
                                ]
                                prop.children [
                                    Html.text "Quick, secure, and trusted referrals to connect your patients to the behavioral health care they need."
                                ]
                            ]
                            Html.div [
                                prop.style [style.marginTop 10]
                                prop.children [
                                    Bulma.button.button [
                                        button.isRounded
                                        Bulma.color.isPrimary
                                        prop.children [
                                            Html.strong "Generate Referral"
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
