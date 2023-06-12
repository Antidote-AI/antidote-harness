module Base64

#if FABLE_COMPILER
open Browser.Dom
#else
open System
open System.Text
#endif

let decode (text : string) =
    #if FABLE_COMPILER
    window.atob text
    #else
    text
    |> Convert.FromBase64String
    |> Encoding.ASCII.GetString
    #endif

let encode (text : string) =
    #if FABLE_COMPILER
    window.btoa text
    #else
    text
    |> Encoding.UTF8.GetBytes
    |> Convert.ToBase64String
    #endif
