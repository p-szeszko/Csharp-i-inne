﻿// Learn more about F# at http://fsharp.org

open System

let Greeting name =
 printfn "Hello %s from F#!" name

[<EntryPoint>]
let main argv =
 Greeting "Przemek"
 0
   
