module Healix.Components.PhysicianOverview

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


// open Antidote.Core.V2.Utils.JS

emitJsStatement () "import React from \"react\""


let private classes : CssModules.Components.PhysicianOverview = import "default" "./PhysicianOverview.module.scss"



let maxChars = 175

let truncateAndAddButton (inputStr: string) ( showMoreCallback: unit -> unit) =
    let inputLen = inputStr.Length
    if inputLen > maxChars then
        let truncatedStr = inputStr.Substring(0, maxChars)
        Html.div [
            prop.style [style.fontFamily "Inter"; style.color "#504A4B"]
            prop.children [
                Html.p [
                    Html.text (truncatedStr + "...")
                    Bulma.button.button [
                        prop.classes ["has-text-weight-bold"]
                        prop.style [style.marginTop 4; style.height 5]
                        Bulma.button.isInverted
                        Bulma.color.isPrimary
                        prop.text "Show More"
                        prop.onClick (fun _ -> showMoreCallback ())
                    ]
                ]

            ]
        ]
    else
        Html.div [
            //prop.className [classes.marginLess]
            prop.children [
                Html.p [
                    //prop.className [classes.marginLess]
                    prop.text inputStr
                ]
            ]
        ]


[<ReactComponent>]
let PhysicianIcons () =
    Html.div [
        prop.className [classes.marginLess]
        prop.children [
            Html.img [
                prop.src ".././Assets/message-rounded-icon-blue.svg"
                prop.alt "messaging icon"
                prop.classes [classes.MessagingIcon;"image";"is-48x48"; "is-rounded"; "m-4"; "p-3";  "has-background-primary-light";]
            ]
            Html.p [
                //prop.className classes.marginLess
                prop.classes ["has-text-primary"; "is-size-6"; "has-text-weight-bold"]
                prop.text "3,456"
                prop.style [style.color.black; style.marginTop -10]
            ]
            Html.p [
                prop.className "heading"
                prop.text "Year experience"
            ]
        ]
    ]

[<ReactComponent>]
let AboutMe () =
    let text = "Dr. Alan Katz received his medical degree in 1998 from Universidad Del Norte in Barranquilla, Colombia after which he moved to Florida to complete his residency at Jackson Memorial Hospital in Miami, Florida. Throughout his seventeen years of practicing medicine, Dr. Katz believes that forming a relationship with his patients is key. This bond has allowed him to build a foundation to create and provide a tailor made care plan designed specifically for a patientâ€™s health needs and goals. Specializing in geriatric care, Dr. Katzâ€™s approach to medicine is shown through his genuine concern of each patientâ€™s welfare as he oversees their progression towards accomplishing health goals set forth while treating every individual with respect and compassion. These positive heath and well-being outcomes in his own words are â€What I like most about practicing medicine.â€ In his spare time, Dr. Katz enjoys spending time with family and traveling back to Colombia when he can. When not working in the office, you can find him â€œpatrollingâ€ the fairways on the golf course."
    let (isTruncated, setTruncated) = React.useState(true)
    let showMoreCallback () =
        setTruncated(not isTruncated)
    let content =
        if isTruncated then
            truncateAndAddButton text showMoreCallback
        else
            Html.div [
                prop.children [
                    Html.p [
                        prop.style [style.fontFamily "Inter"; style.color "#504A4B"]
                        prop.children [
                            Html.text text
                        ]
                    ]
                    Bulma.button.button [
                        prop.classes ["has-text-weight-bold"]
                        prop.style [style.marginRight 10;style.marginTop 4; style.height 5; style.borderColor.white]
                        Bulma.button.isInverted
                        Bulma.color.isPrimary
                        prop.text "See less"
                        prop.onClick (fun _ -> showMoreCallback ())
                    ]
                ]
            ]

    Html.div [
        prop.className [classes.marginLess]
        prop.style [style.marginTop 15]
        prop.children [
            Html.strong [
                prop.classes ["is-size-5"; "has-text-weight-bold"]
                prop.text "About Me"
            ]
            content
        ]
    ]

[<ReactComponent>]
let PhysicianMetrics () =
    Html.div [
        Bulma.level [
            //Bulma.level.isMobile
            Bulma.levelItem [
                prop.classes ["has-text-centered"]
                prop.children [
                    PhysicianIcons ()
                    PhysicianIcons ()
                    PhysicianIcons ()
                    PhysicianIcons ()
                ]
            ]
        ]
    ]


[<ReactComponent>]
let PhysicianOverview () =

    Html.section [
        prop.classes ["appointmentViewerList"; "card"; "m-4"]
        prop.children [
            Html.div [
                prop.classes ["appointmentViewerList__container-content"; "is-flex"; "is-flex-direction-row"; "m-4"; "is-justify-content-space-between";]
                prop.children [
                    Html.div [
                        prop.style [ style.display.flex; style.justifyContent.spaceBetween ] // setting flexbox layout for parent div
                        prop.children [
                            Html.div [
                                prop.style [style.alignItems.center]
                                prop.classes ["appointmentViewerList__container-image"; "is-flex"; "is-align-items-center"; "is-justify-content-center"; "image"; "is-128x128"]
                                prop.children [
                                    Html.img [
                                        prop.src ".././Assets/alan-katz.jpg"
                                        prop.alt "doctor's profile logo"
                                        prop.classes [ classes.DoctorImage; "image"; "p-1"; "p-2"]
                                        prop.style [style.borderRadius 20; style.width 110; style.height 120]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.classes ["appointmentViewerList__container-content"]
                                prop.children [
                                    Html.h2 [
                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                        prop.text "Dr. Alan Katz"
                                        prop.style [style.fontWeight.bold; style.fontSize 25]
                                    ]
                                    Html.div [  // Wrapping element
                                        //prop.style [ style.borderTop(1, borderStyle.solid, color.lightGray); style.borderTopColor color.lightGray]
                                        prop.children [
                                            Html.p [
                                                prop.classes ["appointmentViewerList__messaging"; "p-2"; "has-text-grey-dark"]
                                                prop.style [style.fontFamily "Inter"; style.color "#504A4B"]
                                                prop.children [
                                                    Html.text "Cardiologist"
                                                ]
                                            ]
                                            Html.p [
                                                prop.style [style.fontFamily "Inter"; style.color "#504A4B"]
                                                prop.classes ["appointmentViewerList__availability"; "p-1"; "has-text-grey-dark"; "p-2"]
                                                prop.text "Universidad del Norte Barranquilla, Colombia"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

[<ReactComponent>]
let WorkingHours() =
    Html.div [
            prop.className [classes.marginLess]
            prop.style [style.marginTop 15]
            prop.children [
                Html.strong [
                    prop.classes ["is-size-5"; "has-text-weight-bold"]
                    prop.text "Working Hours"
                ]
                Html.div [
                    prop.style [style.fontFamily "Inter"; style.color "#504A4B"]
                    prop.children [
                        Html.text "Monday - Friday, 9:00 AM - 5:00 PM"
                    ]
                ]
            ]
        ]

let BookAppointment() =
    Bulma.level [
        Bulma.button.button [
            prop.classes ["has-text-weight-bold"]
            Bulma.button.isRounded
            Bulma.color.isPrimary
            prop.className [classes.buttonStyling]
            //Bulma.button.isFullwidth
            // prop.onClick (fun _ ->
            //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
            // )
            prop.text "Book Appointment"
            prop.style [
                style.fontSize 17
                style.display.flex
                style.justifyContent.center
                style.marginTop 30
                style.marginBottom 10
            ]
        ]
    ]

[<ReactComponent>]
let Page () =
    Html.div [
        prop.children [
            PhysicianOverview()
            PhysicianMetrics()
            AboutMe()
            WorkingHours()
            BookAppointment()
        ]
    ]



// Html.div [
            //     prop.style [ style.borderTop(1, borderStyle.solid, color.lightGray); style.borderTopColor color.lightGray;style.display.flex; style.flexDirection.row; style.flexWrap.wrap; style.justifyContent.spaceBetween; style.gap 10]
            //     prop.classes ["appointmentViewerList__container-button"; "m-3"; "is-flex"; "is-justify-content-space-evenly"; "p-4";"has-border-top"; ]
            //     prop.children [
            //         Bulma.button.button [
            //             Bulma.button.isRounded
            //             Bulma.color.isPrimary
            //             Bulma.button.isOutlined
            //             //Bulma.button.isFullwidth
            //             // prop.onClick (fun _ ->
            //             //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
            //             // )
            //             prop.text "Reschedule"
            //             prop.className [classes.width]
            //             prop.style [
            //                 style.marginBottom 15
            //                 style.fontSize 17
            //                 //style.marginLeft 5
            //             ]
            //         ]
            //         Bulma.button.button [
            //             Bulma.button.isRounded
            //             Bulma.color.isPrimary
            //             prop.className [classes.width]
            //             //Bulma.button.isFullwidth
            //             // prop.onClick (fun _ ->
            //             //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
            //             // )
            //             prop.text "Join"
            //             prop.style [
            //                 style.fontSize 17
            //                 //style.marginRight 5
            //             ]
            //         ]

            //     ]
            // ]
