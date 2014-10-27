module Uno.EventSourcing.Tests.``Start a game``

open NUnit.Framework
open FsUnit

type StartAGame =
    { NbPlayers: int }

type GameStarted =
    { GameId: int }

type State =
    { Started: bool }

let InitialState = { Started = false }

let startAGame (command : StartAGame) state =
    [ { GameId = 1} ]

[<Test>]
let ``with more than 2 players`` () =
    let events = startAGame { NbPlayers = 3 } InitialState 
    events |> should contain { GameId = 1 }
    events |> should haveLength 1