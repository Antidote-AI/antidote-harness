module Healix.Components.ConvoCare

open System
open Feliz
open Feliz.UseElmish
open Feliz.Bulma
open Fable.Core
open Fable.Core.JsInterop
// open Antidote.Core.V2.Types

open Feliz.Iconify
open type Offline.Exports
open Glutinum.IconifyIcons.Mdi
open Elmish
open Fable.Core.JS
open Fable.SimpleHttp
open Thoth.Json

open Feliz.Iconify
// Access to the Icon React component for Offline usage
open type Feliz.Iconify.Offline.Exports
// Access to the antDesign list of icon
open Glutinum.IconifyIcons.Mdi
// open Glutinum.IconifyIcons.AntDesign
// open Glutinum.IconifyIcons.Emojione
// open Glutinum.IconifyIcons.EmojioneMonotone
open Feliz.ReactRouterDom
open Elmish
open Feliz.UseElmish
open Feliz.UseDeferred
open Microsoft.CognitiveServices.Speech




let endpoint = "https://api.openai.com/v1/chat/completions"
let apiKey = "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"


// this will be a prop to the component for it to instantiate itself with a system message sent to begin the chat.
type GPTPersona =
    | ClinicianCoPilot
    | RecommendedCodeCoPilot

type GPTRole =
    | System    // - developer instructions for how the system responses
    | User      // - user interfacing directly with gpt
    | Assistant // - server who is replying

// bindings
type Message = {
    role: string
    content: string
    // order ?
    // timestamp ?
}

type Choice = {
    message: Message
    finish_reason: string
    //index: int
}

type ChatGPTResponse = {
    id: string
    created: int
    model: string
    usage: obj
    choices: Choice[]
}

// how to get a set of results for the codes (transform list to set)
type Msg =
    | SetMessage of string
    | SendMessage
    | ResponseReceived of Result<ChatGPTResponse,string>
    | FailedResponse of exn

type GPTProps =
    {|
        GPTPersona: GPTPersona
    |}

type State =
    {
        // set personality with initial message
        GPTPersona: GPTPersona
        ResponseMessages: ChatGPTResponse list
        UserMessages: string list
        CurrentMessage: string
        // Responses: ChatGPTResponse list
        // UserMessages: Message list
    }

let contentBody (messages:string) =
    """{"model": "gpt-3.5-turbo","messages": [""" + messages + """]}"""

let medicalCoPilotSystemMessages =
    // """You are a highly competent doctor that provides information to nurses. Please have all responses include with detailed and technical medical information that a doctor would use. Please only reference from .org and .gov websites. Do not include information that comes from .com websties. Please provide the sources you use."""
    [
        "You are a highly competent doctor medical co-pilot that provides information to other medical staff members."
        "Please have all responses include with detailed and technical medical information that a doctor would use."
        // These seem to break the conversation as the AI platform says it doesn't have access to the internet.
        // "Please only reference from .org and .gov websites. Do not include information that comes from .com websties."
        // "Please provide the sources you use are referencing against."
        "Please cite your sources and only use reputable medical websites."
        "Plese start off with a greeting of 'Welcome to Healix Co-Pilot! How can I assist you today?'"
    ]

// wrap the code result in handlebars
let recommendedCodeCoPilotMessages =
    // """You are a highly competent doctor that synthesizes a medical form and provides me all possible ICD 10 codes that could be related to the answers of each of questions in the form.  Start off the conversation with: 'Please provide me the completed form values so I can start generating the ICD 10 codes.' Please provide me the output in this format: [ “Code”, “Description”; “Code”, “Description”; “Code”, “Description”]."""
    [
        "You are a highly competent doctor that synthesizes a medical form and provides me all possible ICD 10 codes that could be related to the answers of each of questions in the form."
        "Please provide me the output in this format: [ “Code”, “Description”; “Code”, “Description”; “Code”, “Description”]."
        "Start off the conversation with: 'Please provide me the completed form values so I can start generating the ICD 10 codes.'"
    ]

// copy me and paste me when mode set to recommended codes, or uncomment the async in sendmessage to force it to always send this
let testFormValuesString = "Based on the following questionaire, generate ICD 10 codes related to the questions and responses. Are you currently taking any medication(s)? Yes Have you noticed any new or unusual symptoms since starting your medication(s)? Yes If you answered 'Yes' to question 2, please describe the symptom(s) you are experiencing. If you answered no, please write N/A yes How severe are the symptoms you are experiencing? No symptoms are present. How often are you experiencing these symptoms? Never: I am not experiencing symptoms Have you discussed these symptoms with your healthcare provider? No, I have not discussed these symptoms with my healthcare provider."
let wrapContentString str =
    "\"" + str + "\""

let messageBuilder (gptRole: GPTRole) (messageContent: string) =
    match gptRole with
    | System ->     """{"role": "system", "content": """ + (wrapContentString messageContent) + "}"
    | User ->       """{"role": "user", "content": """ + (wrapContentString messageContent) + "}"
    | Assistant ->  """{"role": "assistant", "content": """ + (wrapContentString messageContent) + "}"

let messageMapper (gptRole: GPTRole) (messages: string list) =
    messages
    |> List.map (messageBuilder gptRole)
    |> String.concat ", "
    |> contentBody
let personaRequest (persona: GPTPersona) =
    async {
        let personaMessage =
            match persona with
            | ClinicianCoPilot ->
                messageMapper GPTRole.System medicalCoPilotSystemMessages
            | RecommendedCodeCoPilot ->
                messageMapper GPTRole.System recommendedCodeCoPilotMessages
        let! response =
            // Http.request openAiConnectionString.Value
            Http.request endpoint
            |> Http.method POST
            |> Http.content (
                BodyContent.Text ( personaMessage )
            )
            |> Http.header (Headers.contentType "application/json")
            // |> Http.header (Headers.authorization $"Bearer {openAiKey.Value}" )
            |> Http.header (Headers.authorization $"Bearer {apiKey}" )
            |> Http.send

        return Decode.Auto.fromString<ChatGPTResponse>(response.responseText)
    }

let postRequest (query:string) =
    async {
        let! response =
            // Http.request openAiConnectionString.Value
            Http.request endpoint
            |> Http.method POST
            |> Http.content (
                BodyContent.Text (
                    messageBuilder GPTRole.User query
                    |> contentBody
                )
            )
            |> Http.header (Headers.contentType "application/json")
            |> Http.header (Headers.authorization $"Bearer {apiKey}" )
            |> Http.send

        return Decode.Auto.fromString<ChatGPTResponse>(response.responseText)
    }

let idleMessage = "Waiting for your question"

let init(props: GPTProps) =
    {
        GPTPersona = props.GPTPersona
        ResponseMessages = []
        UserMessages = []
        CurrentMessage = ""
    }, Elmish.Cmd.OfAsync.either personaRequest props.GPTPersona ResponseReceived FailedResponse

let update (msg: Msg) (state: State) =
    match msg with
    | SetMessage message ->
        { state with CurrentMessage = message }
        , Cmd.none

    | SendMessage ->
        { state with
            UserMessages = state.UserMessages @ [ state.CurrentMessage ]
            CurrentMessage = ""
        }
        // send hard code to test form values string
        // , Cmd.OfAsync.either postRequest testFormValuesString ResponseReceived FailedResponse
        , Cmd.OfAsync.either postRequest state.CurrentMessage ResponseReceived FailedResponse

    | ResponseReceived responseResult ->
        match responseResult with
        | Ok response ->
            { state with ResponseMessages = state.ResponseMessages @ [ response ] }, Cmd.none
        | Error error ->
            //debuglog $"Error: {error}"
            state, Cmd.none

    | FailedResponse exn ->
        //debuglog $"Exception: {exn.Message}"
        state, Cmd.none

// Need a deferred somewhere to do the chat loading animation state

// [<ReactComponent>]
// let ChatGPT (props: GPTProps) =
//     let state, dispatch = React.useElmish (init(props), update, [| |])
//     Html.div [
//         Bulma.panelBlock.div [
//             prop.style [style.borderColor "white"]
//             prop.children [
//                 Bulma.control.p [
//                     prop.children [
//                         Bulma.panelBlock.div [
//                             prop.style [style.color.black ; style.fontSize 25; style.borderColor.black; style.height 720]
//                             prop.className "is-flex align-items-center; columns is-centered"
//                                 //prop.style [style.marginauto]
//                             state.ResponseMessages
//                             |> List.map ( fun response ->
//                                 if response.choices.Length = 0
//                                     then Html.span "No response"
//                                 else
//                                     response.choices
//                                     |> Array.map (fun content ->
//                                         Html.span content.message.content
//                                     )
//                                     |>  React.fragment
//                             )
//                             |> prop.children
//                         ]
//                     ]
//                 ]
//             ]
//         ]

//         Bulma.panelBlock.div [
//             Bulma.control.div [
//                 prop.style [ style.borderColor "white" ]
//                 Bulma.control.hasIconsRight
//                 prop.children [
//                     Bulma.icon [
//                         icon.isSmall
//                         icon.isRight
//                         prop.onClick ( fun _ ->
//                             dispatch SendMessage
//                         )
//                         prop.style [ style.margin 5; style.paddingLeft 4 ]
//                         prop.children [
//                             Icon [
//                                 icon.icon mdi.sendOutline
//                                 icon.color "#26619c"
//                                 icon.width 20
//                             ]
//                         ]
//                     ]
//                     Bulma.input.text [
//                         prop.style [ style.color.black; style.fontSize 20; style.borderColor.whiteSmoke ]
//                         prop.placeholder "Ask me anything and press enter when ready"
//                         prop.value state.CurrentMessage
//                         prop.onChange (fun str -> dispatch (SetMessage str) )
//                         prop.onKeyPress (fun ev ->
//                             if ev.key = "Enter" then dispatch SendMessage
//                         )
//                     ]
//                 ]
//             ]
//         ]
//     ]

// let renderChatGpt() =
//     ChatGPT (
//         {| GPTPersona = ClinicianCoPilot |}
//     )

emitJsStatement () "import React from \"react\""

let private classes : CssModules.Components.ConvoCare = import "default" "./ConvoCare.module.scss"

let ConvoCare () =
    Html.div [
        prop.children [
            Html.div [
                prop.style [style.display.flex; style.justifyContent.spaceBetween]
                prop.children [
                    Html.div [
                        prop.classes ["mt-3"; "ml-5"]
                        prop.style [style.fontSize 16]
                        prop.children [
                            Html.text "Edit"
                        ]
                    ]
                    Html.div [
                        prop.classes ["mt-3"]
                        prop.style [style.fontSize 18; style.fontWeight.bold]
                        prop.children [
                            Html.text "Recordings"
                        ]
                    ]
                    Html.div [
                        prop.classes ["mt-3"; "mr-5"]
                        prop.children [
                            Html.i [
                                Icon [
                                    icon.icon mdi.fileDocumentPlusOutline
                                    icon.color "#26619c"
                                    icon.width 25
                                ]
                            ]
                        ]
                    ]
                ]
            ]

            Bulma.section [
                Html.div [
                    prop.style [style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.borderRadius 7]
                    prop.children [
                        Html.div [
                            prop.children [
                                Html.div [
                                    prop.style [style.display.flex; style.flexDirection.row; style.width (length.perc 100)]
                                    prop.children [
                                        Bulma.icon [
                                            icon.isLarge
                                            icon.isRight
                                            prop.style [ style.margin 5; style.paddingLeft 4 ]
                                            prop.children [
                                                Icon [
                                                    icon.icon mdi.playCircleOutline
                                                    icon.color "#26619c"
                                                    icon.width 40
                                                    icon.height 40
                                                ]
                                            ]
                                        ]
                                        Html.div [
                                            prop.classes ["mt-3"]
                                            prop.children [
                                                Html.div [
                                                    prop.style [style.color "#343d46"; style.fontWeight.bold; style.fontSize 13]
                                                    prop.children [
                                                        Html.text "Untitled"
                                                    ]
                                                ]
                                                Html.div [
                                                    prop.style [style.color "#343d46"; style.fontSize 8]
                                                    prop.children [
                                                        Html.text "August 12, 2023 at 10:26pm"
                                                    ]
                                                ]
                                            ]
                                        ]
                                        Html.div [
                                            prop.classes ["mt-3"]
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.flexGrow 1; style.marginRight 10]
                                            prop.children [
                                                Html.div [
                                                    prop.style [style.color "#343d46"; style.fontWeight.bold; style.fontSize 13]
                                                    prop.children [
                                                        Html.text "0:17"
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                        Html.div [
                            prop.style [style.display.flex; style.flexDirection.row]
                            prop.classes ["ml-3"]
                            prop.children [
                                Html.div [
                                    prop.children [
                                        Html.i [
                                            Icon [
                                                icon.icon mdi.contentCopy
                                                icon.color "#343d46"
                                                icon.width 15
                                            ]
                                        ]
                                    ]
                                ]
                                Html.div [
                                    prop.style[style.marginLeft 10; style.marginTop 5]
                                    prop.children [
                                        Html.img [
                                            prop.alt "Placeholder image"
                                            prop.src "/images/paper-plane1.svg"
                                            prop.style [style.width 13; style.height 13; style.display.flex; style.alignContent.center]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.className classes.bottomNavbar
                prop.children [
                    Html.div []
                ]
            ]
        ]
    ]
