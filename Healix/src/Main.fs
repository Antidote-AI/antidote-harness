module Healix.Main

open Browser.Dom
open Antidote.Core.V2.Types
open Feliz
open Healix.Components.Sample
open Healix.Components.BMICalculator
open Healix.Components.AppointmentList
open Healix.Components.Alert
open Fable.Core.JsInterop

emitJsStatement () "import React from \"react\""
importSideEffects "./index.scss"

ReactDOM.render(
    // ListItem ()
    ListItem ()
    , document.getElementById("root")
)
