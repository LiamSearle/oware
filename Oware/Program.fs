//
//Due Thursday 28 March at 7pm
//
module Oware

type StartingPosition =
    | South
    | North
  (*North
      ^
      |
      v
    South*)

(*getSeeds, which accepts a house number and a board, and returns the number of
seeds in the specified house*)
let getSeeds n board = failwith "Not implemented"

(*useHouse, which accepts a house number and a board, and makes a move using
that house.*)
let useHouse n board = failwith "Not implemented"

(*start, which accepts a StartingPosition and returns an initialized game where the
person in the StartingPosition starts the game*)
let start position  = {
    let p = (int * int * int * int * int * int * int * int) //(4,4,4,4,4,4,4,4,4,4,4,4)
}
failwith "Not implemented"

(*score, which accepts a board and gives back a tuple of (southScore , northScore)*)
let score board = failwith "Not implemented"

(*gameState, which accepts a board and gives back a string that tells us about the
state of the game. Valid strings are “South’s turn”, “North’s turn”, “Game ended in a
draw”, “South won”, and “North won”.*)
let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
