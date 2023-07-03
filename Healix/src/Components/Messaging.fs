module Healix.Components.Messaging

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
open System.Collections.Generic


// open Antidote.Core.V2.Utils.JS

emitJsStatement () "import React from \"react\""


// type Props =
//     { InitialValue: int }

// let myComponent (props: Props) =
//     let (count, setCount) = React.useState props.InitialValue

//     Html.div [
//         Html.p (sprintf "Count: %i" count)
//         Html.button [
//             prop.onClick (fun _ -> setCount (count + 1))
//             prop.text "Increment"
//         ]
//         Html.button [
//             prop.onClick (fun _ -> setCount (count - 1))
//             prop.text "Decrement"
//         ]
//     ]

// let MyComponent ()=
//     React.functionComponent myComponent
