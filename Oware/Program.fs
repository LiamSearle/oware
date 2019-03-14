//
//Due Thursday 28 March at 7pm
//
module Oware

 //--------------------------------------Types--------------------------
type house = {
   number: int
   numSeeds: int
}

type StartingPosition =
    | North
    | South

type player = {
  score: int
  side: StartingPosition
  isTurn: bool
  victory: bool
}

type game = {//has 12 houses & 2 players
  board:(house * house * house * house * house * house * house * house * house * house * house * house * house * house)
  players: (player * player)
  //toWin: int <- 25
}
 //--------------------------------------End Types--------------------------
 

(*getSeeds, which accepts a house number and a board, and returns the number of
seeds in the specified house*)
//gets seeds at that house
let getSeeds n board = failwith "Not implemented"

(*useHouse, which accepts a house number and a board, and makes a move using
that house.*)
//getSeeds, count the seeds and itt. through them to distribute to houses greater than the orig, can't use foe's house
let useHouse n board = 
    let rec cnt j k = 
        match j/10 = 0 with
        |true -> k
        |_ -> cnt (j/10) (k + 1) 
    cnt n 1
//failwith "Not implemented"

(*start, which accepts a StartingPosition and returns an initialized game where the
person in the StartingPosition starts the game*)
let start position  = failwith "Not implemented"

(*score, which accepts a board and gives back a tuple of (southScore , northScore)*)
let score board = failwith "Not implemented"

(*gameState, which accepts a board and gives back a string that tells us about the
state of the game. Valid strings are “South’s turn”, “North’s turn”, “Game ended in a
draw”, “South won”, and “North won”.*)
let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    let player1 = {player.score = 5; side = StartingPosition.North; isTurn = true; victory = false }
    let player2 = {player.score = 0; side = StartingPosition.South; isTurn = false; victory = false }

    let house1 = {house.number = 1; numSeeds = 4}
    
    let house2 = {house.number = 2; numSeeds = 4}

    let house3 = {house2 with number = 3}
    let house3 = {house3 with numSeeds = house3.numSeeds+1}
    
    let {house.number = 3} = house3
    
    

    printfn "Hello from F#!"
    printfn "Player 1 score: %i. Player 2 score: %i." player1.score player2.score
    0 // return an integer exit code
