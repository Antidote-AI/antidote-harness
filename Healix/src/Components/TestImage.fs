module Healix.Components.TestImage

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
open Browser.Dom

open Fable.React
open Fable.React.Props

//let private classes : CssModules.Components.TestImage = import "default" "./TestImage.module.scss"


let mobileBreakpoint = 768
let tabletBreakpoint = 1024

let getImageSrc () =
    let width = window.innerWidth
    if width <= mobileBreakpoint then
       ".././Assets/medicalimage.png"
    elif width <= tabletBreakpoint then
        ".././Assets/heart-rate.svg"
    else
       ".././Assets/medical-history.svg"

let imageComponent () =
    Html.img [
        prop.src (getImageSrc ())
    ]
