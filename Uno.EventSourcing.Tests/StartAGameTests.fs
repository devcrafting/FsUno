module Uno.EventSourcing.Tests.``Start a game``

open NUnit.Framework
open FsUnit

open Game

[<Test>]
let ``with more than 2 players`` () =
    let events = startAGame { NbPlayers = 3 } InitialState 
    events |> should contain { GameId = 1 }
    events |> should haveLength 1