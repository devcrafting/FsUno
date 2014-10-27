module Game

type StartAGame =
    { NbPlayers: int }

type GameStarted =
    { GameId: int }

type State =
    { Started: bool }

let InitialState = { Started = false }

let startAGame (command : StartAGame) state =
    if command.NbPlayers < 3 then
        failwith "There should be at least 3 players to be fun."
    [ { GameId = 1} ]