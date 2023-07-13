module Healix.Components.Messaging

open System
open Feliz
open Feliz.UseElmish
open Feliz.Bulma
open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.Core.JsInterop
open Browser.Types


open Feliz.Iconify
open type Offline.Exports
open Glutinum.IconifyIcons.Mdi
open Elmish
open Fable.Core.JS
open System.Collections.Generic
open Fable.React.Props

// open Antidote.Core.V2.Utils.JS

emitJsStatement () "import React from \"react\""

type Model = { newMessage : string; messages: string list }
type Msg =
    | AddMessage of string
    | UpdateNewMessage of string


[<ReactComponent>]
let MessageApp(model: Model, dispatch) =
    let sendMessage =
        if model.newMessage <> "" then
            dispatch (AddMessage model.newMessage)

    console.log(model.messages)

    Html.div [
        Html.input [
            prop.type'.text
            prop.defaultValue model.newMessage

        ]
        Html.button [
            prop.text "Send"
            prop.onClick (fun _ -> dispatch (AddMessage model.newMessage))
        ]
        Html.ul [
            prop.children (model.messages |> List.map Html.li)
        ]
    ]

// Create initial model
let initialModel = { newMessage = ""; messages = [] }

// Update function to handle dispatch
let update msg model =
    match msg with
    | AddMessage msgText ->
        let updatedModel = { model with newMessage = ""; messages = msgText :: model.messages }
        updatedModel, []
    | UpdateNewMessage newMsg ->
        { model with newMessage = newMsg }, []

let init() = initialModel, []

// Now use the Elmish hook
let mainComponent = React.functionComponent(fun () ->
    let model, dispatch = React.useElmish(init, update)
    MessageApp(model, dispatch))
