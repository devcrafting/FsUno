module Game

type StartAGame =
    { GameId: int;
    NbPlayers: int }

type Color =
    | Red
    | Blue
    | Green
    | Yellow

type Card =
    { Color: Color;
    Value: int }

type PlayACard =
    { Card: Card }

type GameStarted =
    { GameId: int;
    NbPlayers: int }

type CardPlayed =
    { Card: Card }

type State =
    { Started: bool }

let InitialState = { Started = false }

let startAGame (command : StartAGame) state =
    if state.Started then
        failwith "Game is already started, cannot start again."
    if command.NbPlayers < 3 then
        failwith "There should be at least 3 players to be fun."
    [ { GameStarted.GameId = 1; NbPlayers = command.NbPlayers } ]

let playACard (command : PlayACard) state =
    [ { CardPlayed.Card = command.Card } ]