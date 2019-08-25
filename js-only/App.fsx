printfn "Compiled only by JS"

open System

let random = new Random()

let fishEmoji =
    [ "🐟";"🐠";"🐡";"🦈";"🐸";"🐢";"🌊"]

let brick =
    "🔲"

let empty =
    "⏹"
let fishLength = List.length fishEmoji

let dimension = 20
let aquarium dimX dimY =
    let lastX = dimX - 1
    let lastY = dimY - 1

    [ 0 .. lastY ]
    |> List.iter (fun y ->
        [ 0 .. lastX ]
        |> List.map (fun x ->
            match x, y with
            | 0, _ -> brick
            | _, 0  -> brick
            | x, _ when (x = lastX) -> brick
            | _, y when (y = lastY) -> brick
            | _ ->
                if random.Next(0,7) = 0 then
                    List.item (random.Next() % fishLength) fishEmoji
                else
                    empty
        )
        |> String.concat System.String.Empty
        |> printfn "%s"
    )

aquarium 40 20