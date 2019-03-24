﻿//
//Due Thursday 28 March at 7pm
//
module Oware

//--------------------------------------Types--------------------------
//type House = {
   //number: int
  // numSeeds: int
//}

type StartingPosition =
  | North
  | South

type Player = {
  score: int
  side: StartingPosition
  isTurn: bool
  victory: bool
}

type Board = {
  a: int; b: int; c: int; d: int; e: int; f: int; 
  a': int; b': int; c': int; d': int; e': int; f': int; 
  //North: [a; b; c; d; e; f]
}


type Game = {//has 12 Houses & 2 Players
  gameBoard: Board
  PlayerNorth: Player
  PlayerSouth: Player
  StartingPlayer: StartingPosition 
  toWin: int //Player wins with 25 seeds.       Should we keep this here?
}
//--------------------------------------End Types--------------------------
 

(*getSeeds, which accepts a House number and a Board, and returns the number of
seeds in the specified House*)
//gets seeds at that House
let getSeeds n Board = //failwith "Not implemented"
  let returnVal = function
  |1 -> Board.a
  |2 -> Board.b
  |3 -> Board.c
  |4 -> Board.d
  |5 -> Board.e
  |6 -> Board.f
  |7 -> Board.a'
  |8 -> Board.b'
  |9 -> Board.c'
  |10 -> Board.d'
  |11 -> Board.e'
  |12 -> Board.f'
  |_ -> failwith "invalid House"
  returnVal


(*useHouse, which accepts a House number and a Board, and makes a move using
that House.*)
//getSeeds, count the seeds and itt. through them to distribute to Houses greater than the orig, can't use foe's House
let useHouse n Board = 
    let rec cnt j k = 
        match j = 0 with //doesn't work yet needs to be properly implemented.
        |true -> k
        |_ -> cnt (j-1) (k + 1)
    cnt n 1
//failwith "Not implemented"

(*start, which accepts a StartingPosition and returns an initialized game where the
person in the StartingPosition starts the game*)
let start position = 
  let Game1 = {Board.a = 4; b = 4; c = 4; d = 4; e = 4; f = 4; a' = 4; b' = 4; c' = 4; d' = 4; e' = 4; f' = 4 }//Game.StartingPlayer = start }
  Game1
  

//failwith "Not implemented"

(*score, which accepts a Board and gives back a tuple of (southScore , northScore)*)
let score Board = failwith "Not implemented"

(*gameState, which accepts a Board and gives back a string that tells us about the
state of the game. Valid strings are “South’s turn”, “North’s turn”, “Game ended in a
draw”, “South won”, and “North won”.*)
let gameState Board = failwith "Not implemented"

let outputGame game = //function that takes in a game and prints out the Board and scores
    printfn "|________Player 1 score_________|" 
    printfn "|-----------|~~%i~~|------------|" game.PlayerNorth.score
    printfn "|-------------------------------|"
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" game.gameBoard.a' game.gameBoard.b' game.gameBoard.c' game.gameBoard.d' game.gameBoard.e' game.gameBoard.f' 
    printfn "|-------------------------------|" //start bottom left to move in counter-clockwise direction
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" game.gameBoard.a game.gameBoard.b game.gameBoard.c game.gameBoard.d game.gameBoard.e game.gameBoard.f  
    printfn "|-------------------------------|"
    printfn "|-----------|~~%i~~|------------|" game.PlayerSouth.score
    printfn "|________Player 2 score_________|"
    ()



[<EntryPoint>]
let main _ =
    //---------------------------------This needs to go into a method -------------------------------
    (*let PlayerNorth = {player.score = 0; side = StartingPosition.North; isTurn = true; victory = false }
    let PlayerSouth = {player.score = 0; side = StartingPosition.South; isTurn = false; victory = false }
    *)

    0 // return an integer exit code
