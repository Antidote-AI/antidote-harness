module Elmish

open Elmish

module Cmd =

    module OfFunc =

        let exec
            (task: 'a -> _)
            (arg: 'a) : Cmd<'msg> =

            let bind _dispatch =
                try
                    task arg
                with x ->
                    ()

            [ bind ]
