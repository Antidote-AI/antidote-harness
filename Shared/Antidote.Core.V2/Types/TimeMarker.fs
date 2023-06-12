namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling
open System

[<RequireQualifiedAccess>]
module TimeMarker =

    type T = private | TimeMarker of TimeSpan

    let create (timeMark: TimeSpan) = TimeMarker timeMark

    let value (TimeMarker timeMarker) = timeMarker

    let tryParse (timeSpan: TimeSpan) = result {
        do! Validators.TimeSpan.doesNotExceedDay timeSpan "Amount of minutes exceeds 24 hour period"

        do!
            Validators.TimeSpan.hasMinimumClockTime
                timeSpan
                "Availability schueduling requires at least one minute of time to be assigned"

        return TimeMarker timeSpan
    }
