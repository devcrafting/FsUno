module Uno.EventSourcing.Tests.``Start a game``

open NUnit.Framework
open FsUnit

open Game

[<Test>]
let ``with more than 2 players`` () =
    startAGame { NbPlayers = 3 } InitialState 
        |> should equal [ { GameId = 1 } ]