module ``Play a card``

open NUnit.Framework
open FsUnit

open Game

let StartedGame = { Started = true }
let RedOneCard = { Color = Red; Value = 1 }

[<Test>]
let ``as the first player`` () =
    playACard { Card = RedOneCard } StartedGame
        |> should equal [ { Card = RedOneCard } ]