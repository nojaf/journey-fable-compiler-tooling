#r @"C:\Users\nojaf\.nuget\packages\fable.core\3.0.0\lib\netstandard2.0\Fable.Core.dll"

open Fable.Core.JsInterop

let meh = createObj [ "foo" ==> "bar" ]

let add a b = a + b