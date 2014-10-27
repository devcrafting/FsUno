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

type Event =
    | GameStarted of GameStarted
    | CardPlayed of CardPlayed
and GameStarted =
    { GameId: int;
    NbPlayers: int }
and CardPlayed =
    { Card: Card }

type State =
    { Started: bool;
    LastCardPlayed: option<Card> }

let InitialState = { Started = false; LastCardPlayed = None }

let startAGame (command : StartAGame) state =
    if state.Started then
        failwith "Game is already started, cannot start again."
    if command.NbPlayers < 3 then
        failwith "There should be at least 3 players to be fun."
    [ { GameStarted.GameId = 1; NbPlayers = command.NbPlayers } ]

let playACard (command : PlayACard) state =
    let raiseCardPlayed = [ { CardPlayed.Card = command.Card } ]
    match state.LastCardPlayed, command.Card with
        | None, _ -> raiseCardPlayed
        | Some(cardOnTop), cardPlayed when cardOnTop.Color = cardPlayed.Color -> raiseCardPlayed
        | Some(cardOnTop), cardPlayed when cardOnTop.Value = cardPlayed.Value -> raiseCardPlayed
        | _ -> failwith "Card cannot be played, it must be same color or same value"

let apply event state =
    match event with
        | GameStarted(_) -> { state with Started = true }
        | CardPlayed(event) -> { state with LastCardPlayed = Some event.Card }
        | _ -> failwith "Unknown event"