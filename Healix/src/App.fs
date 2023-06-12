module Healix.App

open Antidote.Core.V2.Types
open Feliz.ReactRouterDom
open Fable.Core.JsInterop
open Healix.Components.Sample
open Feliz
open Feliz.Bulma

// Workaround to have React-refresh working
// I need to open an issue on react-refresh to see if they can improve the detection
emitJsStatement () "import React from \"react\""
importSideEffects "./index.scss"

[<ReactComponent>]
let App () =

    let navigate = useNavigate()

    reactRouterDom.routes [

        reactRouterDom.route [
            route.index
            route.element (

            )
        ]

    ]
