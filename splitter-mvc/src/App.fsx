#load "../.paket/load/main.group.fsx"
#load "../paket-files/fable-compiler/fableconf/src/Types.fs"
#load "../paket-files/fable-compiler/fableconf/src/Speakers.fs"
#load "./Express.fsx"

open Types
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Express
open Speakers
open Node

let reactDomServer : Fable.React.IReactDomServer = importDefault "react-dom/server"

let private sendReact (res: express.Response) view =
    view
    |> reactDomServer.renderToString
    |> res.send
    |> ignore

let speakerOf2019 =
    [ Zaid; Dag; Florian; Vagif
      Georg; Krzysztof; Tomasz
      Steffen; Joerg; Colin; Brett
      François; Alfonso;Julien
      Diego]

let layout page =
    html [ Lang "en" ]
        [ head [ ]
            [ meta [ CharSet "UTF-8" ]
              meta [ Name "viewport"
                     HTMLAttr.Content "width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" ]
              meta [ HTMLAttr.Custom ("httpEquiv", "X-UA-Compatible")
                     HTMLAttr.Content "ie=edge" ]
              title [ ]
                [ str "Fable MVC" ]
              link [ Rel "stylesheet"
                     Href "/bootstrap.min.css" ]
              link [ Rel "stylesheet"
                     Href "/style.css" ]
              style [ ]
                [ str "nav img { max-width: 30px; }" ] ]
          body [ ]
            [ nav [ Class "navbar navbar-expand-lg navbar-dark bg-primary" ]
                [ a [ Class "navbar-brand"
                      Href "#" ]
                    [ span [ Class "mx-2" ]
                        [ str "Fable MVC" ]  ] ]
              div [ Class "container mt-4" ]
                [ div [ Id "app" ]
                    [ page ] ]
            ]
        ]

let private getSpeakerUrl (speaker: Speaker) =
    if speaker.picture.StartsWith("https") then
        speaker.picture
    else
        sprintf "https://fable.io/fableconf/%s" speaker.picture

let indexPage =
    let speakers =
        speakerOf2019
        |> List.mapi (fun index speaker ->
            let mediaClass = if (index % 2) = 1 then "media my-4" else "media"
            let bio =
                match speaker.bio with
                | Some(bio) when (String.length bio > 100) -> sprintf "%s..." (bio.Substring(0, 100))
                | Some bio -> bio
                | None -> "???"

            li [ClassName mediaClass] [
                img [ Src (getSpeakerUrl speaker); ClassName "mr-3"]
                div [ClassName "media-body"] [
                    a [Href (sprintf "/speaker/%s" speaker.shortname)] [
                        h5 [ClassName "mt-0 mb-1"] [str speaker.name]
                    ]
                    str bio
                ]
            ]
        )


    div [] [
        h1 [] [str "FableConf Speakers"]
        ul [ClassName "list-unstyled mt-4"] speakers
    ]
    |> layout

let detailPage shortName =
    let speaker =
        speakerOf2019
        |> List.tryFind (fun speaker -> speaker.shortname = shortName)

    match speaker with
    | Some (speaker) ->
        let link =
            speaker.github
            |> Option.map (fun github ->
                a [ Href (sprintf "https://github.com/%s" github)
                    Class "btn btn-primary"
                    Target "_blank" ]
                    [ str "View on GitHub" ]
            )

        div [ Class "card w-50" ]
            [ img [ Src (getSpeakerUrl speaker)
                    Class "card-img-top"
                    Alt "..." ]
              div [ Class "card-body" ]
                [ h5 [ Class "card-title" ]
                    [ str speaker.name ]
                  p [ Class "card-text" ]
                    [ ofOption(Option.map str speaker.bio) ]
                  ofOption link
                ] ]
    | None ->
        h1 [] [str "404 Speaker not found!"]
    |> fun content ->
        div [] [
            content
            a [Href "/"; ClassName "mt-4 d-block"] [str "go back"]
        ]
    |> layout

let port = 9010
let publicFolder = path.join(__dirname ,"../public")
let app = express.Invoke()

app.``use``(express.``static``.Invoke(publicFolder))
app.get("/", fun _ res -> sendReact res indexPage)
app.get("/speaker/:shortName",
        fun req res ->
            let shortName: string = req.``params``?shortName
            detailPage shortName
            |> sendReact res
    )

app.listen(port, fun _ ->
    printfn "Server started on %i" port
    #if DEBUG
    http
        .get("http://localhost:3000/__browser_sync__?method=reload", fun err ->
            printfn "Reloaded browser-sync"
        )
        .on("error", fun err _ ->
            printfn "Could not reload browser-sync"
        )
        |> ignore
    #endif
)
