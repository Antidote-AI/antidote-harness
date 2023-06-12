namespace Feliz.Bulma

open Feliz
open Feliz.Bulma

[<AutoOpen>]
module Extension =

    type color with
        static member inline isAntidoteBluePrimary = Interop.mkAttr "className" "is-antidote-blue-primary"
        static member inline isAntidoteBluePrimaryInvert = Interop.mkAttr "className" "is-antidote-blue-primary-invert"

        static member inline isAntidoteBlueSecondary = Interop.mkAttr "className" "is-antidote-blue-secondary"
        static member inline isAntidoteBlueSecondaryInvert = Interop.mkAttr "className" "is-antidote-blue-secondary-invert"

        static member inline isAntidotePink = Interop.mkAttr "className" "is-antidote-pink"
        static member inline isAntidotePinkInvert = Interop.mkAttr "className" "is-antidote-pink-invert"

        static member inline isAntidoteOrange = Interop.mkAttr "className" "is-antidote-orange"
        static member inline isAntidoteOrangeInvert = Interop.mkAttr "className" "is-antidote-orange-invert"

        static member inline hasTextAntidoteBluePrimary = Interop.mkAttr "className" "has-text--antidote-blue-primary"
        static member inline hasTextAntidoteBluePrimaryInvert = Interop.mkAttr "className" "has-text--antidote-blue-primary-invert"

        static member inline hasTextAntidoteBlueSecondary = Interop.mkAttr "className" "has-text--antidote-blue-secondary"
        static member inline hasTextAntidoteBlueSecondaryInvert = Interop.mkAttr "className" "has-text--antidote-blue-secondary-invert"

        static member inline hasTextAntidotePink = Interop.mkAttr "className" "has-text--antidote-pink"
        static member inline hasTextAntidotePinkInvert = Interop.mkAttr "className" "has-text--antidote-pink-invert"

        static member inline hasTextAntidoteOrange = Interop.mkAttr "className" "has-text--antidote-orange"
        static member inline hasTextAntidoteOrangeInvert = Interop.mkAttr "className" "has-text--antidote-orange-invert"
