module App

open Fable.Core.JsInterop
open Browser.Dom
open Fable.Core
open Fable.React
open Fable.React.Props
open HookRouter

type SuspenseProp =
    | Fallback of ReactElement

let suspense props children =
    ofImport "Suspense" "react" (keyValueList CaseRules.LowerFirst props) children

let Loading = FunctionComponent.Of (fun () -> str "Loading...")
let HomePage : obj = ReactBindings.React.``lazy`` (fun () -> importDynamic "./Pages/Home.fs")
let AboutPage : obj = ReactBindings.React.``lazy`` (fun () -> importDynamic "./Pages/About.fs")
let ProductList : obj = ReactBindings.React.``lazy`` (fun () -> importDynamic "./Pages/ProductList.fs")
let ProductDetail : obj = ReactBindings.React.``lazy`` (fun () -> importDynamic "./Pages/ProductDetail.fs")

let routes = 
    createObj [
        "/" ==> fun _ -> ReactBindings.React.createElement(HomePage, null, [])
        "/about" ==> fun _ -> ReactBindings.React.createElement(AboutPage, null, [])
        "/products" ==> fun _ -> ReactBindings.React.createElement(ProductList, null, [])
        "/products/:id" ==> fun (props:Pages.ProductDetail.RouteProps) -> ReactBindings.React.createElement(ProductDetail, props, [])
    ]

let App =
    FunctionComponent.Of (fun () ->
        let routeResults = useRoutes routes
        let path = usePath()
        let navLinkClass (route:string) =
            if (path = "/" && route = "/") || (route <> "/" && path.StartsWith(route)) then
                AProps.ClassName "nav-item nav-link active"
            else
                AProps.ClassName "nav-item nav-link"

        let activePage =
            match routeResults with
            | Some page -> 
                suspense [Fallback (Loading())] [page]
            | None -> 
                h1 [] [str "Page not found 🙈"]

        fragment [] [
            nav [ClassName "navbar navbar-expand-lg navbar-dark bg-dark"] [
                div [ClassName "collapse navbar-collapse"] [
                    div [ClassName "navbar-nav"] [
                        A [AProps.Href "/"; navLinkClass "/" ] [str "Home"]
                        A [AProps.Href "/about"; navLinkClass "/about" ] [str "About"]
                        A [AProps.Href "/products"; navLinkClass "/products" ] [str "Products"]
                    ]
                ]
            ]
            main [ClassName "container"] [activePage]
        ]
    , "App")

ReactDom.render(App (), document.getElementById "app")