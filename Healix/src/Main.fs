module Healix.Main

open Browser.Dom
open Antidote.Core.V2.Types
open Feliz
open System
open Fable.Core.JsInterop
open Elmish
open Healix.Components.Sample
open Healix.Components.BMICalculator
open Healix.Components.AppointmentViewerList
open Healix.Components.PhysicianOverview
open Healix.Components.Messaging
open Healix.Components.Alert
open Healix.Components.Profile
open Healix.Components.Notifications
open Healix.Components.PatientHome
open Healix.Components.SpinWheel
open Healix.Components.Proposal
open Healix.Components.Table
open Healix.Components.PatientCard
open Healix.Components.Counter
open Healix.Components.MedicationCard
open Healix.Components.LabResults
open Healix.Components.LabDetails

open Fable.Core.JsInterop

emitJsStatement () "import React from \"react\""
importSideEffects "./index.scss"

ReactDOM.render(
    render (),
    document.getElementById("root")
)
