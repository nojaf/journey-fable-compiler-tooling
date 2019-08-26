#load "../.paket/load/main.group.fsx"

open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props

type Msg =
    | Increase
    | Decrease
let App =
    FunctionComponent.Of (
        (fun () ->
            let init = 0
            let update state msg =
                match msg with
                | Increase -> state + 1
                | Decrease -> state - 1
            let state = Hooks.useReducer(update, init)
            div [] [
                h1 [] [str "Pika pika"]
                div [ ClassName "card" ] [
                    div [ClassName "card-body"] [
                        h2 [ ClassName "card-title" ] [
                            str "Current state:"
                        ]
                        h2 [ClassName "text-center"] [
                            strong [] [ofInt state.current]
                        ]
                        button [ClassName "btn btn-primary mr-2"; OnClick (fun _ -> state.update Increase)] [str "Increase"]
                        button [ClassName "btn btn-secondary"; OnClick (fun _ -> state.update Decrease)] [str "Decrease"]
                    ]
                ]
            ]
         )
        , "App"
        , equalsButFunctions)

mountById "app" (App())