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
  toWin: int //player wins with 25 seeds.       Should we keep this here?
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
    let player1 = {player.score = 0; side = StartingPosition.North; isTurn = true; victory = false }
    let player2 = {player.score = 0; side = StartingPosition.South; isTurn = false; victory = false }

    let house1 = {house.number = 1; numSeeds = 4}
    let house2 = {house.number = 2; numSeeds = 4}
    let house3 = {house.number = 3; numSeeds = 4}
    let house4 = {house.number = 4; numSeeds = 4}
    let house5 = {house.number = 5; numSeeds = 4}
    let house6 = {house.number = 6; numSeeds = 4}
    let house7 = {house.number = 7; numSeeds = 4}
    let house8 = {house.number = 8; numSeeds = 4}
    let house9 = {house.number = 9; numSeeds = 4}
    let house10 = {house.number = 10; numSeeds = 4}
    let house11 = {house.number = 11; numSeeds = 4}
    let house12 = {house.number = 12; numSeeds = 4}
    //let house3 = {house2 with number = 3}
    //let house3 = {house3 with numSeeds = house3.numSeeds+1}
    //let {house.number = 3} = house3
    

    //------------------------------------Game output-------------------------------------------
    printfn "|~~~~~~~|Player 1 score|~~~~~~~~~|"
    printfn "|------------|~~%i~~|-------------|" player1.score
    printfn "|--------------------------------|"
    printfn "|--[%i]--[%i]--[%i]--[%i]--[%i]--[%i]--|" house12.numSeeds house11.numSeeds house10.numSeeds house9.numSeeds house8.numSeeds house7.numSeeds 
    printfn "|--------------------------------|" //start bottom left to move in counter-clockwise direction
    printfn "|--[%i]--[%i]--[%i]--[%i]--[%i]--[%i]--|" house1.numSeeds house2.numSeeds house3.numSeeds house4.numSeeds house5.numSeeds house6.numSeeds 
    printfn "|--------------------------------|"
    printfn "|------------|~~%i~~|-------------|" player2.score
    printfn "|~~~~~~~|Player 2 score|~~~~~~~~~|" 
    //----------------------------------Game output end----------------------------------------

    0 // return an integer exit code
