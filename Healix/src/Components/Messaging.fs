module Healix.Components.Messaging

open System
open Feliz
open Feliz.UseElmish
open Feliz.Bulma
open Fable.Core
open Fable.Core.JsInterop
open Elmish
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



open Feliz
open Elmish

type Message = {
    Content: string
    Timestamp: DateTime
}

type Model = {
    Messages: Message list
    CurrentMessage: string
}

type Msg =
    | UpdateCurrentMessage of string
    | AddMessage

let initModel = {
    Messages = []
    CurrentMessage = ""
}

// let init () : Model * Cmd<Msg> = initModel, Cmd.none

// let update msg model =
//     match msg with
//     | UpdateCurrentMessage content ->
//         { model with CurrentMessage = content }, Cmd.none
//     | AddMessage ->
//         let newMessage = { Content = model.CurrentMessage; Timestamp = DateTime.UtcNow }
//         { model with Messages = newMessage :: model.Messages; CurrentMessage = "" }, Cmd.none

// let view (model: Model) (dispatch: Msg -> unit): ReactElement =
//     Html.div [
//         Html.ul [
//             for msg in model.Messages ->
//                 Html.li [ Html.text msg.Content ]
//         ]
//         Html.input [
//             prop.value model.CurrentMessage
//             prop.onChange (fun (ev: Browser.Types.Event) ->
//                 let inputElement = ev.target :?> Browser.Types.HTMLInputElement
//                 dispatch (UpdateCurrentMessage inputElement.value))
//         ]
//         Html.button [
//             prop.onClick (fun _ -> dispatch AddMessage)
//             prop.text "Send"
//         ]
//     ]
