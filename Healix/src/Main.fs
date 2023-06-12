module Healix.Main

open Browser.Dom
open Antidote.Core.V2.Types
open Feliz
open Healix.Components.Sample

// emitJsStatement () "import React from \"react\""
// importSideEffects "./index.scss"

ReactDOM.render(
    Sample ()
    , document.getElementById("root")
)
