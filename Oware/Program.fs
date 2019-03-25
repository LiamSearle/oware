//
//Due Thursday 28 March at 7pm
//
module Oware
//--------------------------------------Types--------------------------
type StartingPosition =
  | North
  | South

type Player = {
  score: int
  suburb: (int*int*int*int*int*int)
  
}

type Turn = 
  | North 
  | South

type Board = {
  playerNorth: Player
  playerSouth: Player
  toWin: int
  PlayerTurn: Turn
}
//--------------------------------------End Types--------------------------
 
(*getSeeds, which accepts a House number and a Board, and returns the number of
seeds in the specified House*)
let getSeeds n board = //Passes tests
  let (a,b,c,d,e,f),(a',b',c',d',e',f') = board.playerNorth.suburb, board.playerSouth.suburb
  match n with 
  |1 -> a
  |2 -> b
  |3 -> c
  |4 -> d
  |5 -> e
  |6 -> f
  |7 -> a'
  |8 -> b'
  |9 -> c'
  |10 -> d'
  |11 -> e'
  |12 -> f'
  |_ -> failwith "invalid House"


//getSeeds, count the seeds and itt. through them to distribute to Houses greater than the orig, can't use foe's House
//
//
//Psuedo Code
//
//get the number of seeds from the given house
//know which players turn it is
//set that house to zero seeds
//add 1 seed to each house after it
//check if the total of the last house sums to 2 or 3
//if it is check the one before it, do this recursivly untill != (2 or 3).
//add the points to the player and remove them from the game
//
// N.B. you CAN'T take seeds from your own side
//
//end psuedo code

let collect (a,b,c,d,e,f,a',b',c',d',e',f') board= //failwith "Not implemented" //method to collect the seeds from a house and give them to a player
  match board.PlayerTurn with 
    | North -> 
    | South ->
  let rec take house = 
    match board.house with 
    |2 | 3 -> take Previoushouse
    |_ -> ()
  ()
()  

let addToSuburb n (a,b,c,d,e,f,a',b',c',d',e',f') =
  match n with 
    |1 -> (a+1,b,c,d,e,f,a',b',c',d',e',f')
    |2 -> (a,b+1,c,d,e,f,a',b',c',d',e',f')
    |3 -> (a,b,c+1,d,e,f,a',b',c',d',e',f')
    |4 -> (a,b,c,d+1,e,f,a',b',c',d',e',f')
    |5 -> (a,b,c,d,e+1,f,a',b',c',d',e',f')
    |6 -> (a,b,c,d,e,f+1,a',b',c',d',e',f')
    //-----------Middle of board-----------
    |7 -> (a,b,c,d,e,f,a'+1,b',c',d',e',f')
    |8 -> (a,b,c,d,e,f,a',b'+1,c',d',e',f')
    |9 -> (a,b,c,d,e,f,a',b',c'+1,d',e',f')
    |10 -> (a,b,c,d,e,f,a',b',c',d'+1,e',f')
    |11 -> (a,b,c,d,e,f,a',b',c',d',e'+1,f')
    |12 -> (a,b,c,d,e,f,a',b',c',d',e',f'+1)
    |_ -> failwith "Invalid House Number"

let setHouseZero board n =
  let (a,b,c,d,e,f),(a',b',c',d',e',f') = board.playerNorth.suburb, board.playerSouth.suburb
  match n with
  |1 -> {board with playerNorth = {board.playerNorth with suburb = (0,b,c,d,e,f)}}
  |2 -> {board with playerNorth = {board.playerNorth with suburb = (a,0,c,d,e,f)}}
  |3 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,0,d,e,f)}}
  |4 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,c,0,e,f)}}
  |5 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,c,d,0,f)}}
  |6 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,c,d,e,0)}}
  //-----------Middle of board-----------
  |7 -> {board with playerNorth = {board.playerNorth with suburb = (0,b',c',d',e',f')}}
  |8 -> {board with playerNorth = {board.playerNorth with suburb = (a',0,c',d',e',f')}}
  |9 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',0,d',e',f')}}
  |10 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',c',0,e',f')}}
  |11 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',c',d',0,f')}}
  |12 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',c',d',e',0)}}
  |_ -> failwith "Invalid House Number"

let useHouse n board = //failwith "Not implemented"

(*
useHouse: accepts a House number and a Board, and makes a move using
that House.
*)
let useHouse n board = //failwith "Not implemented"



(*
start: accepts a StartingPosition and returns an initialized game where the
person in the StartingPosition starts the game
*)
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

(*
Score: accepts a Board and gives back a tuple of (southScore , northScore)
*)
let score board = 
  let playerSouth.score, playerNorth.score = board.playerSouth.score, board.playerNorth.score
  playerSouth.score, playerNorth.score 

(*
gameState: accepts a Board and gives back a string that tells us about the
state of the game. Valid strings are “South’s turn”, “North’s turn”, “Game ended in a
draw”, “South won”, and “North won”.
*)
let gameState board = 
   let a,b = score board
   match x > 24 with 
   |true -> "South won"
   |false -> match y > 24  with 
            |true -> "North won"
            |false -> match x = 24 && y = 24 with 
                      |true ->  "Game ended in a draw"
                      |false ->  match board.PlayerTurn with  
                                |South -> "South's turn"
                                |North -> "North's turn"


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
