module ``Start a game``

open NUnit.Framework
open FsUnit

open Game

let StartAValidGame = { StartAGame.GameId = 1; NbPlayers = 3 }
let StartedGame = { Started = true; LastCardPlayed = None }

[<Test>]
let ``with 3 players`` () =
    startAGame StartAValidGame InitialState 
        |> should equal [ { GameId = 1; NbPlayers = 3 } ]
    apply (GameStarted({ GameId = 1; NbPlayers = 3 })) InitialState
        |> should equal StartedGame

[<Test>]
let ``with less than 3 players`` () =
    (fun () -> startAGame { GameId = 1; NbPlayers = 2 } InitialState |> ignore)
        |> should throw typeof<System.Exception>

[<Test>]
let ``when already started`` () =
    (fun () -> startAGame StartAValidGame StartedGame |> ignore)
        |> should throw typeof<System.Exception>