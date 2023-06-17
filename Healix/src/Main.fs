module Healix.Main

open Browser.Dom
open Antidote.Core.V2.Types
open Feliz
open Healix.Components.Sample
open Healix.Components.BMICalculator
open Healix.Components.AppointmentViewerList
open Healix.Components.PhysicianOverview
open Healix.Components.Alert
open Fable.Core.JsInterop

emitJsStatement () "import React from \"react\""
importSideEffects "./index.scss"

ReactDOM.render(
    // ListItem ()
    Page ()
    , document.getElementById("root")
)
