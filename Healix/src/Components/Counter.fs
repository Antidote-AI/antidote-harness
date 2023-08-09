module Healix.Components.Counter

open Feliz
open Feliz.UseElmish
open Elmish
open Feliz.Bulma


type Msg =
    | Increment
    | Decrement
    | SettoZero
    | Start100
    | UpdateInput of int

type State = {
    Count : int
}

//let init() = { Count = 0 }, Cmd.none
let init() = { Count = 0 }, Cmd.none

let update msg state =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }, Cmd.none
    | Decrement -> { state with Count = state.Count - 1 }, Cmd.none
    | SettoZero -> { state with Count = 0 }, Cmd.none
    | Start100 -> { state with Count = 100 }, Cmd.none
    | UpdateInput newInput -> { state with Count = newInput }, Cmd.none


[<ReactComponent>]
let Counter(props:State) =
    let state, dispatch = React.useElmish(init, update, [| |])

    Html.div [
        prop.children [
            Html.div [
                Html.h1 state.Count
                Html.button [
                    prop.text "Increment"
                    prop.onClick (fun _ -> dispatch Increment)
                ]

                Html.button [
                    prop.text "Decrement"
                    prop.onClick (fun _ -> dispatch Decrement)
                ]
                Html.button [
                    prop.text "Set Zero"
                    prop.onClick (fun _ -> dispatch SettoZero)
                ]
                Html.button [
                    prop.text "Set 100"
                    prop.onClick (fun _ -> dispatch Start100)
                ]
            ]

            Html.div [
                // Html.input [
                //     //prop.value state.Input
                //     prop.type' "number"
                //     prop.onChange (fun evt ->
                //         printfn "evt: %A" evt
                //         dispatch (UpdateInput evt))

                // ]
                Bulma.input.number [
                    prop.onChange (fun evt ->
                        printfn "evt: %A" evt
                        dispatch (UpdateInput evt))

                ]
                // Html.button [
                //     prop.text "Take my num"
                //     prop.onClick (fun evt -> dispatch (UpdateInput evt))
                // ]
            ]
        ]
    ]
