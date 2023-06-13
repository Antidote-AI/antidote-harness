module Healix.Main

open Browser.Dom
open Antidote.Core.V2.Types
open Feliz
open Healix.Components.Sample
open Healix.Components.AppointmentList

// emitJsStatement () "import React from \"react\""
// importSideEffects "./index.scss"

ReactDOM.render(
    ListItem ()
    , document.getElementById("root")
)
