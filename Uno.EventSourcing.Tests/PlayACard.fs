module ``Play a card``

open NUnit.Framework
open FsUnit

open Game

let StartedGame = { Started = true; LastCardPlayed = None }
let RedOneCard = { Color = Red; Value = 1 }

[<Test>]
let ``as the first player`` () =
    playACard { Card = RedOneCard } StartedGame
        |> should equal [ { Card = RedOneCard } ]
    apply (CardPlayed({ Card = RedOneCard })) StartedGame
        |> should equal { StartedGame with LastCardPlayed = Some RedOneCard }

[<TestFixture>]
type ``given a card was already played``() =

    let GreenTwoCard = { Color = Green; Value = 2 }
    let RedTwoCard = { Color = Red; Value = 2 }
    let RedOneOnTopOfPile = apply (CardPlayed({ Card = RedOneCard })) StartedGame 
    
    [<Test>]
    member x.``with different color and value compared to the card on top of the pile`` () =
        (fun () -> playACard { Card = GreenTwoCard } RedOneOnTopOfPile |> ignore)
            |> should throw typeof<System.Exception>

    [<Test>]
    member x.``with same color as the card on top of the pile`` () =
        playACard { Card = RedTwoCard } RedOneOnTopOfPile
            |> should equal [ { Card = RedTwoCard } ]
