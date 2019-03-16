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
  House1: int; House2: int; House3: int; House4: int; House5: int; House6: int; 
  House7: int; House8: int; House9: int; House10: int; House11: int; House12: int; 
}

type Game = {//has 12 Houses & 2 Players
  gameBoard: Board
  Player1: Player
  Player2: Player
  toWin: int //Player wins with 25 seeds.       Should we keep this here?
}
 //--------------------------------------End Types--------------------------
 
let outputGame game = //function that takes in a game and prints out the Board and scores
    printfn "|________Player 1 score_________|" 
    printfn "|-----------|~~%i~~|------------|" game.Player1.score
    printfn "|-------------------------------|"
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" game.gameBoard.House12 game.gameBoard.House11 game.gameBoard.House10 game.gameBoard.House9 game.gameBoard.House8 game.gameBoard.House7 
    printfn "|-------------------------------|" //start bottom left to move in counter-clockwise direction
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" game.gameBoard.House1 game.gameBoard.House2 game.gameBoard.House3 game.gameBoard.House4 game.gameBoard.House5 game.gameBoard.House6  
    printfn "|-------------------------------|"
    printfn "|-----------|~~%i~~|------------|" game.Player2.score
    printfn "|________Player 2 score_________|"
    ()


(*getSeeds, which accepts a House number and a Board, and returns the number of
seeds in the specified House*)
//gets seeds at that House
let getSeeds n Board = failwith "Not implemented"

(*useHouse, which accepts a House number and a Board, and makes a move using
that House.*)
//getSeeds, count the seeds and itt. through them to distribute to Houses greater than the orig, can't use foe's House
let useHouse n Board = 
    let rec cnt j k = 
        match j/10 = 0 with
        |true -> k
        |_ -> cnt (j/10) (k + 1) 
    cnt n 1
//failwith "Not implemented"

(*start, which accepts a StartingPosition and returns an initialized game where the
person in the StartingPosition starts the game*)
let start position  = failwith "Not implemented"

(*score, which accepts a Board and gives back a tuple of (southScore , northScore)*)
let score Board = failwith "Not implemented"

(*gameState, which accepts a Board and gives back a string that tells us about the
state of the game. Valid strings are “South’s turn”, “North’s turn”, “Game ended in a
draw”, “South won”, and “North won”.*)
let gameState Board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    (*let Player1 = {Player.score = 5; side = StartingPosition.North; isTurn = true; victory = false }
    let Player2 = {Player.score = 0; side = StartingPosition.South; isTurn = false; victory = false }

    let House1 = {House.number = 1; numSeeds = 4}
    let House2 = {House.number = 2; numSeeds = 4}

    let House3 = {House2 with number = 3}
    let House3 = {House3 with numSeeds = House3.numSeeds+1}
    
    let {House.number = 3} = House3*)
    

    //------------------------------------Game output-------------------------------------------
    (*
    printfn "|________Player 1 score_________|" 
    printfn "|-----------|~~%i~~|------------|" Player1.score
    printfn "|-------------------------------|"
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" House12.number House11.number House10.number House9.number House8.number House7.number 
    printfn "|-------------------------------|" //start bottom left to move in counter-clockwise direction
    printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" House1.number House2.number House3.number House4.number House5.number House6.number 
    printfn "|-------------------------------|"
    printfn "|-----------|~~%i~~|------------|" Player2.score
    printfn "|________Player 2 score_________|" *)
    //----------------------------------Game output end----------------------------------------

    0 // return an integer exit code
