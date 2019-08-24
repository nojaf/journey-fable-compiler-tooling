#load "../.paket/load/main.group.fsx"

open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props

type ReduceFn<'state,'msg> = ('state -> 'msg -> 'state)
type Dispatch<'msg> ='msg -> unit
let useReducer<'state,'msg> (reducer: ReduceFn<'state,'msg>) (initialState:'state) : ('state * Dispatch<'msg>)  = import "useReducer" "react"

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
            let (state, dispatch) = useReducer update init
            div [] [
                h1 [] [str "Pika pika"]
                div [ ClassName "card" ] [
                    div [ClassName "card-body"] [
                        h2 [ ClassName "card-title" ] [
                            str "Current state:"
                        ]
                        h2 [ClassName "text-center"] [
                            strong [] [ofInt state]
                        ]
                        button [ClassName "btn btn-primary mr-2"; OnClick (fun _ -> dispatch Increase)] [str "Increase"]
                        button [ClassName "btn btn-secondary"; OnClick (fun _ -> dispatch Decrease)] [str "Decrease"]
                    ]
                ]
            ]
         )
        , "App"
        , equalsButFunctions)

mountById "app" (App())