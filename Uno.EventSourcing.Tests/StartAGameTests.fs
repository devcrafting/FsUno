module Uno.EventSourcing.Tests.``Start a game``

open NUnit.Framework
open FsUnit

open Game

[<Test>]
let ``with 3 players`` () =
    startAGame { NbPlayers = 3 } InitialState 
        |> should equal [ { GameId = 1 } ]

[<Test>]
let ``with less than 3 players`` () =
    (fun () -> startAGame { NbPlayers = 2 } InitialState |> ignore)
        |> should throw typeof<System.Exception>