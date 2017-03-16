open System
open System.Collections
open Microsoft.FSharp.Collections

let toInt c =
    match c with
    | ' ' -> 0
    | a -> Convert.ToInt32 a - 96

let toChar c =
    match c with
    | 0 -> ' '
    | a -> Convert.ToChar ( a + 96 )

let encodeChar (char:char) (seed:char) =
    toChar (((toInt char)+(toInt seed)) % 27)

let rec encode input seed =
    match input with
    | [] -> []
    | [char] -> [encodeChar char seed]
    | head :: tail -> let newChar = encodeChar head seed
                      newChar :: encode tail newChar

let decodeChar char seed =
    toChar(((toInt char)-(toInt seed) + 27) % 27 )

let rec decode input seed =
    match input with
    | [] -> []
    | [char] -> [decodeChar char seed]
    | head :: tail -> let newChar = decodeChar head seed
                      newChar :: decode tail head

let rec loopInput f =
    let inputString = System.Console.ReadLine().ToLower()
    match inputString with
    | "" -> ()
    | str -> f(Array.toList( str.ToCharArray() ))
             loopInput f

[<EntryPoint>]
let main argv = 
    let operation = match argv with
                    | [||] | [|"encode"|] -> encode
                    | [|"decode"|] -> decode
                    | _ -> failwith "Incorrect parameter: use encode or decode. Default is encode"
    let foo (f:char list) = Console.WriteLine( new string [| for c in (operation f 'm') -> c|])
    loopInput foo
    0 // return an integer exit code
