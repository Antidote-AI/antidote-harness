module Antidote.Prelude

open System
open System.Collections.Generic
open Fable.Core

type Environment =
    | Local
    | Development
    | Staging
    | Production

[<RequireQualifiedAccess>]
module Target =
    let APP_TARGET_ENVIRONMENT = Environment.Production

[<RequireQualifiedAccess>]
module Literals =
    let [<Literal>] APP_VERSION = "1.1.4" // Do not edit manually
