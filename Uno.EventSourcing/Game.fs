module Game

type StartAGame =
    { GameId: int;
    NbPlayers: int }

type GameStarted =
    { GameId: int;
    NbPlayers: int }

type State =
    { Started: bool }

let InitialState = { Started = false }

let startAGame (command : StartAGame) state =
    if command.NbPlayers < 3 then
        failwith "There should be at least 3 players to be fun."
    [ { GameStarted.GameId = 1; NbPlayers = command.NbPlayers } ]