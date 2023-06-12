namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

[<RequireQualifiedAccess>]
module ChatThreadId =

    type T = private | ChatThreadId of string

    let create (threadString: string) = ChatThreadId threadString

    let value (ChatThreadId threadId) = threadId

    let tryParse (chatThreadId: string) = result {
        do! Validators.String.nonEmpty chatThreadId "Chat Thread Id cannot be empty"

        return ChatThreadId chatThreadId
    }
