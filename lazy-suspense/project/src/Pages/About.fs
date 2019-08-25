module Pages.About

open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop

let private About =
    FunctionComponent.Of (fun () ->
        fragment [] [
            h1 [] [str "About page"]
            p [] [
                str "This sample is about showing "
                a [Href "https://reactjs.org/docs/code-splitting.html"; Target "_blank"] [str "React.Lazy and codesplitting"]
                ]
        ]
    )

exportDefault About