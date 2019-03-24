//
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
  PlayerNorth: Player
  PlayerSouth: Player
  toWin: int
}

//--------------------------------------End Types--------------------------
 

(*getSeeds, which accepts a House number and a Board, and returns the number of
seeds in the specified House*)
let getSeeds n board = //Passes tests
  match n with 
  |1 -> board.a
  |2 -> board.b
  |3 -> board.c
  |4 -> board.d
  |5 -> board.e
  |6 -> board.f
  |7 -> board.a'
  |8 -> board.b'
  |9 -> board.c'
  |10 -> board.d'
  |11 -> board.e'
  |12 -> board.f'
  |_ -> failwith "invalid House"


(*useHouse, which accepts a House number and a Board, and makes a move using
that House.*)
//getSeeds, count the seeds and itt. through them to distribute to Houses greater than the orig, can't use foe's House
//
//
//Psuedo Code
//
//get the number of seeds from the given house
//know which players turn it is
//add 1 seed to each house after it
//check if the total of the last house sums to 2 or 3
//if it is check the one before it, do this recursivly untill != (2 or 3).
//add the points to the player and remove them from the game
//
// N.B. you CAN'T take seeds from your own side
//
//end psuedo code

let useHouse n board = failwith "Not implemented"
(*
  let numS = getSeeds n in 
    let rec cnt j k = 
        match numS = 0 with //doesn't work yet needs to be properly implemented.
        |true -> k
        |_ -> cnt (j-1) (k + 1)
    cnt n 1
*)

(*start, which accepts a StartingPosition and returns an initialized game where the
person in the StartingPosition starts the game*)
let start position = 
  match position with  
  |North -> {
    a = 4; b = 4; c = 4; d = 4; e = 4; f = 4; a' = 4; b' = 4; c' = 4; d' = 4; e' = 4; f' = 4;
    PlayerNorth = {score = 0; side = North; isTurn = true; victory = false}
    PlayerSouth = {score = 0; side = South; isTurn = false; victory = false}
    toWin = 25
    }
  |South -> {
    a = 4; b = 4; c = 4; d = 4; e = 4; f = 4; a' = 4; b' = 4; c' = 4; d' = 4; e' = 4; f' = 4;
    PlayerNorth = {score = 0; side = North; isTurn = false; victory = false}
    PlayerSouth = {score = 0; side = South; isTurn = true; victory = false}
    toWin = 25
    }
  |_ -> failwith "Error in start"
 
 
 (* let Game1 = {
    gameBoard = {a = 4; b = 4; c = 4; d = 4; e = 4; f = 4; a' = 4; b' = 4; c' = 4; d' = 4; e' = 4; f' = 4;}
    PlayerNorth = {score = 0; side = North; isTurn = false; victory = false}
    PlayerSouth = {score = 0; side = South; isTurn = false; victory = false}
    toWin = 25
    }//Game.StartingPlayer = start }
    match position with
    |South -> (PlayerSouth with isTurn = true)
    |North -> (PlayerSouth with isTurn = true)
    |_ -> failwith "Error in player turn"
  Game1*)
  

//failwith "Not implemented"

(*score, which accepts a Board and gives back a tuple of (southScore , northScore)*)
let score board = failwith "Not implemented"


(*gameState, which accepts a Board and gives back a string that tells us about the
state of the game. Valid strings are “South’s turn”, “North’s turn”, “Game ended in a
draw”, “South won”, and “North won”.*)
let gameState board = failwith "Not implemented"

let outputGame game = //function that takes in a game and prints out the Board and scores
    printfn "|________Player 1 score_________|" 
    printfn "|-----------|~~%i~~|------------|" game.PlayerNorth.score
    printfn "|-------------------------------|"
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" game.a' game.b' game.c' game.d' game.e' game.f' 
    printfn "|-------------------------------|" //start bottom left to move in counter-clockwise direction
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" game.a game.b game.c game.d game.e game.f  
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
