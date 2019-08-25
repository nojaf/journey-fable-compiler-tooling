module Pages.Home

open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop

let private Home =
    FunctionComponent.Of (fun () ->
        fragment [] [
            h1 [] [str "Home page"]
            p [] [ str "Try navigating to the other pages and notice new chunks being downloaded on demand as you navigate." ]
        ]
    )

exportDefault Home