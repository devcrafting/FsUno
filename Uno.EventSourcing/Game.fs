module Game

type StartAGame =
    { NbPlayers: int }

type GameStarted =
    { GameId: int }

type State =
    { Started: bool }

let InitialState = { Started = false }

let startAGame (command : StartAGame) state =
    [ { GameId = 1} ]