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
  PlayerTurn: Turn
}
//--------------------------------------End Types--------------------------
 
let checkOwnHouse n side = 
  match side with 
  |North -> match n with 
            |1|2|3|4|5|6 -> false
            |_ -> true
  |South -> match n with 
            |7|8|9|10|11|12 -> false
            |_ -> true    

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

//Adds seeds to the houses, will be made more use of later.
let addToHouse n (a,b,c,d,e,f,a',b',c',d',e',f') =
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

//sets the chosen house to 0 so its seed can be distributed later
let setHouseZero board n =
  let (a,b,c,d,e,f),(a',b',c',d',e',f') = board.playerNorth.suburb, board.playerSouth.suburb
  match n with
  |1 -> {board with playerNorth = {board.playerNorth with suburb = (0,b,c,d,e,f)}}
  |2 -> {board with playerNorth = {board.playerNorth with suburb = (a,0,c,d,e,f)}}
  |3 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,0,d,e,f)}}
  |4 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,c,0,e,f)}}
  |5 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,c,d,0,f)}}
  |6 -> {board with playerNorth = {board.playerNorth with suburb = (a,b,c,d,e,0)}}
  //----------------------------Middle of board----------------------------------------
  |7 -> {board with playerNorth = {board.playerNorth with suburb = (0,b',c',d',e',f')}}
  |8 -> {board with playerNorth = {board.playerNorth with suburb = (a',0,c',d',e',f')}}
  |9 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',0,d',e',f')}}
  |10 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',c',0,e',f')}}
  |11 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',c',d',0,f')}}
  |12 -> {board with playerNorth = {board.playerNorth with suburb = (a',b',c',d',e',0)}}
  |_ -> failwith "Invalid House Number"

//method to collect the seeds from a house and give them to a player if end seeds = 2 | 3
let collect turn board = //failwith "Not implemented" 
 
  // does update for adding points to player & sets house to 0 along with board updates
  let addPoints board amount n position =
    match position with  
    |North -> {board.playerSouth with score = board.playerSouth.score + amount; suburb = (setHouseZero board n).playerSouth.suburb}
    |South -> {board.playerSouth with score = board.playerSouth.score + amount; suburb = (setHouseZero board n).playerSouth.suburb}
  
  //counts seeds on respective sides
  let rec countNorthSeeds n board = 
      match n with 
      |7 -> board //Wrong side? Ignore.
      |_ -> match getSeeds n board, board.playerSouth.score = 24 && board.playerNorth.score = 24 with //check game ended & no. seeds are in house
            |2,false -> countNorthSeeds (n+1) {board with playerSouth = addPoints board 2 n North}
            |3,false -> countNorthSeeds (n+1) {board with playerSouth = addPoints board 3 n North}
            |_,false -> countNorthSeeds (n+1) board
            |_,_ -> board

  let rec countSouthSeeds n board = 
      match n with 
      |12 -> board //Wrong side? Ignore.
      |_ -> match getSeeds n board, board.playerNorth.score = 24 && board.playerSouth.score = 24  with  //check game ended & no. seeds are in house
            |2,false -> countSouthSeeds (n+1) {board with playerNorth = addPoints board 2 n South}
            |3,false-> countSouthSeeds (n+1) {board with playerNorth = addPoints board 3 n South}
            |_,false-> countSouthSeeds (n+1) board
            |_,_ -> board

  match turn with 
  |North ->  countNorthSeeds  1 board
  |South ->  countSouthSeeds  7 board 

let rec moveSeeds n leftOverSeeds startHouse houses = //needs to take in a house to move to next, the seeds that are left to move, the house it starts with and the board itself as one tuple of houses for itterating
  let n = match (n=13) with//loop around to the first house when n moves on from the last house
          |true -> 1
          |_ -> n
  match leftOverSeeds with // if there are still seeds to sew then call the function again
  |0 -> houses
  |_ -> match n = startHouse with //if the house is the startHouse then just increase the house value but down remove a seed or add to the house.
        |false -> moveSeeds (n+1) (leftOverSeeds-1) startHouse (addToHouse n houses)
        |_ -> moveSeeds (n+1) (leftOverSeeds) (startHouse) (houses)
                       
(*
useHouse: accepts a House number and a Board, and makes a move using
that House.
*)
let useHouse n board = //failwith "Not implemented"
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

//-----------------------Pre-Checks-----------------------------------------------------------------------

  match (getSeeds n board) with //check if the player selected a house with no seeds in it
  |0 -> board //if they have do nothing
  |_ -> //otherwise carry on with the function

  match (checkOwnHouse n board) with//check if the player has selected their own house
  |false -> board//if they have then chnage nothing
  |_ -> //else carry on with the function


//-----------------------End Pre-Checks--------------------------------------------------------------------

  let (a,b,c,d,e,f),(a',b',c',d',e',f') = (setHouseZero board n).playerNorth.suburb,(setHouseZero board n).playerSouth.suburb // set the house to zero that the player has chosen
  let seeds = getSeeds n board // get the seeds from the house
  let combinedSuburbs = (a,b,c,d,e,f,a',b',c',d',e',f') //combine the two sides of the board to allow the seeds to be distributed properly.

  let combinedSuburbs = moveSeeds (n+1) seeds n combinedSuburbs//move the seeds around the board and update the board.

  //give the players their points

  //update the game state with all the changes

  //give the game inputs and outputs etc. ie. make it run.


(*
start: accepts a StartingPosition and returns an initialized game where the
person in the StartingPosition starts the game
*)
let start position = 
  match position with  
  |North -> {
    playerNorth = {score = 0; suburb = (4,4,4,4,4,4)}
    playerSouth = {score = 0; suburb = (4,4,4,4,4,4)}
    PlayerTurn = North
    }
  |South -> {
    playerNorth = {score = 0; suburb = (4,4,4,4,4,4)}
    playerSouth = {score = 0; suburb = (4,4,4,4,4,4)}
    PlayerTurn = South
    }
  |_ -> failwith "Error in start"

(*
Score: accepts a Board and gives back a tuple of (southScore , northScore)
*)
let score board = 
  let x,y = board.playerNorth.score, board.playerSouth.score
  y,x

//changes the turn to the other player after a player has had their turn
let changeTurn position = 
    match position with
    | North -> South 
    | South -> North 

(*
gameState: accepts a Board and gives back a string that tells us about the
state of the game. Valid strings are “South’s turn”, “North’s turn”, “Game ended in a
draw”, “South won”, and “North won”.
*)
let gameState board = 
   let a,b = score board
   match a > 24 with 
   |true -> "South won"
   |false -> match b > 24  with 
            |true -> "North won"
            |false -> match a = 24 && b = 24 with 
                      |true ->  "Game ended in a draw"
                      |false ->  match board.PlayerTurn with  
                                |South -> "South's turn"
                                |North -> "North's turn"


let outputGame board = //function that takes in a game and prints out the Board and scores
  let (a,b,c,d,e,f),(a',b',c',d',e',f') = board.playerNorth.suburb, board.playerSouth.suburb
  printfn "|________Player 1 score_________|" 
  printfn "|-----------|~~%i~~|------------|" board.playerNorth.score
  printfn "|-------------------------------|"
  printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" f' e' d' c' b' a' 
  printfn "|-------------------------------|" //start bottom left to move in counter-clockwise direction
  printfn "|-[%i]-[%i]-[%i]-[%i]-[%i]-[%i]-|" a b c d e f 
  printfn "|-------------------------------|"
  printfn "|-----------|~~%i~~|------------|" board.playerSouth.score
  printfn "|________Player 2 score_________|"
  ()



[<EntryPoint>]
let main _ =
    let startgame = start North
    
    printfn "Hello from F#!"
    0 // return an integer exit code