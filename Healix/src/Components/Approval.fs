module Healix.Components.Approval

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


let private classes : CssModules.Components.Approval = import "default" "./Approval.module.scss"

type Review = {
    User: string
    Date: DateTime
    Rating: float
    Comment: string
    ImgSrc: string
}

let reviewsData =
    [
        { User = "Alex Campo"; Date = DateTime(2023, 7, 1); Rating = 4.0; Comment = "Very attentive and knowledgeable."; ImgSrc = ".././Assets/me.jpeg" }
        { User = "Linda Ferguson"; Date = DateTime(2023, 6, 25); Rating = 5.0; Comment = "Great experience! Highly recommended."; ImgSrc = ".././Assets/user2.jpeg" }
        { User = "John Simmons"; Date = DateTime(2023, 6, 20); Rating = 4.5; Comment = "Prompt service and clear explanations."; ImgSrc = ".././Assets/user3.jpeg" }
        { User = "Mary Patterson"; Date = DateTime(2023, 6, 15); Rating = 3.0; Comment = "Average service. Room for improvement."; ImgSrc = ".././Assets/user4.jpeg" }
        { User = "Robert Adams"; Date = DateTime(2023, 6, 10); Rating = 4.8; Comment = "Exceptional care and treatment."; ImgSrc = ".././Assets/user5.jpeg" }
        { User = "Patricia Clark"; Date = DateTime(2023, 6, 5); Rating = 4.2; Comment = "Good, but the wait time was too long."; ImgSrc = ".././Assets/user6.jpeg" }
        { User = "Michael Thompson"; Date = DateTime(2023, 5, 30); Rating = 5.0; Comment = "Top notch care! Very pleased."; ImgSrc = ".././Assets/user7.jpeg" }
        { User = "Jennifer Martinez"; Date = DateTime(2023, 5, 25); Rating = 4.7; Comment = "Friendly staff and competent doctor."; ImgSrc = ".././Assets/user8.jpeg" }
        { User = "James Lewis"; Date = DateTime(2023, 5, 20); Rating = 3.5; Comment = "Decent. But I've been to better."; ImgSrc = ".././Assets/user9.jpeg" }
        { User = "Lisa Williams"; Date = DateTime(2023, 5, 15); Rating = 4.9; Comment = "Couldn't ask for a better service."; ImgSrc = ".././Assets/user10.jpeg" }
    ]


type Tab =
    | About
    | Schedule
    | Ratings
    | WorkingHours


let truncateAndAddButton (inputStr: string) ( showMoreCallback: unit -> unit) =
    let maxChars = 125
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

type PhysicianIcon = { image: string; number: string; title: string }

[<ReactComponent>]
let PhysicianIcons (props:PhysicianIcon) =
    Html.div [
        prop.className [classes.marginLess]
        prop.children [
            Html.img [
                prop.src props.image
                prop.alt "messaging icon"
                prop.classes [classes.MessagingIcon;"image";"is-48x48"; "m-4"; "p-3";  "has-background-primary-light";]
            ]
            Html.p [
                //prop.className classes.marginLess
                prop.classes ["has-text-primary"; "is-size-6"; "has-text-weight-bold"]
                prop.text props.number
                prop.style [style.color.black; style.marginTop -10]
            ]
            Html.p [
                prop.className "heading"
                prop.text props.title
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
                    Html.text (text)
                    Bulma.button.button [
                        prop.classes ["has-text-weight-bold"]
                        prop.style [style.marginTop 4; style.height 5]
                        Bulma.button.isInverted
                        Bulma.color.isPrimary
                        prop.text "Show Less"
                        prop.onClick (fun _ -> showMoreCallback ())
                    ]
                ]
                ]
            ]

    Html.div [
        prop.className [classes.marginLess]
        prop.style [style.marginTop 15; style.paddingBottom 70]
        prop.children [
            Html.strong [
                prop.classes ["is-size-5"; "has-text-weight-bold"]
                prop.text "About Me"
            ]
            content
        ]
    ]

let reviewBar =
    [5; 4; 3; 2; 1]
        |> List.map (fun rating ->
            let count =
                reviewsData
                |> List.filter (fun r -> r.Rating = float rating)
                |> List.length
            Html.div [
                prop.style [
                    style.display.flex
                    style.flexDirection.row
                    style.width (length.percent 80)
                    style.justifyContent.center
                    style.alignItems.center
                ]
                prop.children [
                    Html.div [
                        prop.style [style.marginRight 5; style.color.gray; style.fontWeight 475; style.fontSize 15]
                        prop.children [
                            Html.text (string rating)
                        ]
                    ]
                    Html.img [
                        prop.src ".././Assets/star-yellow.svg"
                        prop.style [
                            style.width 15
                            style.height 15
                            style.marginRight 5
                        ]
                    ]
                    Bulma.progress [
                        Bulma.progress.isSmall
                        prop.value (float count)
                        prop.max (float (List.length reviewsData))
                        prop.className "is-primary"
                        prop.classes [classes.customProgress]
                        prop.style [
                            style.marginRight 5
                        ]
                    ]
                    Html.text (string count)
                ]
            ]
        )


[<ReactComponent>]
let info () =
    Html.div [
        prop.children [
            Html.div [
                    prop.className [classes.marginLess]
                    prop.style [style.marginTop 15]
                    prop.children [
                        Html.strong [
                            prop.classes ["is-size-5"; "has-text-weight-bold"]
                            prop.text "General Information"
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "Provider Type"
                                Html.text ":   "
                                Html.text "Cardiologist"
                            ]
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "State License"
                                Html.text ":   "
                                Html.text "Florida"
                            ]
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "Email"
                                Html.text ":   "
                                Html.text "alexcampo3695@gmail.com"
                            ]
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "Phone Number"
                                Html.text ":   "
                                Html.text "305-206-4761"
                            ]
                        ]
                    ]
                ]
            Html.div [
                    prop.className [classes.marginLess]
                    prop.style [style.marginTop 15]
                    prop.children [
                        Html.strong [
                            prop.classes ["is-size-5"; "has-text-weight-bold"]
                            prop.text "Personal Identification Numbers"
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "SSN"
                                Html.text ":   "
                                Html.text "123456789"
                            ]
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "NPI Number"
                                Html.text ":   "
                                Html.text "123456789"
                            ]
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "DEA Number"
                                Html.text ":   "
                                Html.text "123456789"
                            ]
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "License State"
                                Html.text ":   "
                                Html.text "305-206-4761"
                            ]
                        ]
                        Html.div [
                            prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.display.flex]
                            prop.children [
                                Html.text "License Number"
                                Html.text ":   "
                                Html.text "12312312"
                            ]
                        ]

                    ]
                ]
            ]
        ]

let patientsIcon = { image = ".././Assets/people.svg"; number = "1,000+"; title = "Patients" }
let yearsExpIcon = { image = ".././Assets/diagram.svg"; number = "10+ Years"; title = "Experience" }
let ratingIcon = { image = ".././Assets/star.svg"; number = "4.8"; title = "Rating" }
let reviewsIcon = { image = ".././Assets/message-rounded-icon-blue.svg"; number = "4,923"; title = "Reviews" }

[<ReactComponent>]
let PhysicianMetrics () =
    Html.div [
        Bulma.level [
            //Bulma.level.isMobile
            Bulma.levelItem [
                prop.classes ["has-text-centered"]
                prop.children [
                    PhysicianIcons (patientsIcon)
                    PhysicianIcons (yearsExpIcon)
                    PhysicianIcons (ratingIcon)
                    PhysicianIcons (reviewsIcon)
                ]
            ]
        ]
    ]


[<ReactComponent>]
let PhysicianOverview () =
    Html.section [
        prop.classes ["appointmentViewerList"; "m-4"]
        prop.children [
            Html.div [
                prop.style [ style.display.flex; style.alignItems.center; style.flexDirection.column; style.width (length.perc 100); style.flexGrow 1]
                prop.children [
                    Html.div [
                        prop.style [ style.display.flex; style.flexDirection.column; style.alignItems.center; style.marginTop 10]
                        prop.children [
                            Html.div [
                                prop.children [
                                    Html.img [
                                        prop.style [style.marginLeft 10; style.width 75; style.height 75; style.custom ("boxShadow", "rgba(0, 0, 0, 0.16) 0px 10px 36px 0px");style.border(3, borderStyle.solid, color.white)]
                                        prop.src ".././Assets/alan-katz.jpg"
                                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.classes ["appointmentViewerList__container-content"]
                                prop.children [
                                    Html.h3 [
                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                        prop.style [
                                            style.fontFamily "Inter";
                                            style.fontWeight.bold;
                                            style.fontSize 17;
                                            style.marginBottom -20;
                                            style.color.black;
                                            //style.textAlign.center;
                                            style.display.flex;
                                            style.justifyContent.center
                                            style.alignItems.center; // This aligns items vertically
                                        ]
                                        prop.children [
                                            Html.span [ // Wrap the name text in a span for flex display
                                                prop.text ("Alex" + " " + "Campo")
                                            ]
                                            Html.img [
                                                prop.src ".././Assets/verified.svg"
                                                prop.alt "verified icon"
                                                prop.classes ["ml-2"]
                                                prop.style [style.width 20; style.height 20]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.children [
                                            Html.p [
                                                prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.gray; style.textAlign.center]
                                                prop.children [
                                                    Html.text ("Patient")
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
    ]

[<ReactComponent>]
let WorkingHoursComp() =
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

let Buttons() =
    Html.div [
        prop.className [classes.elementToPin]
        prop.children [
            Html.div [
                prop.style [style.display.flex; style.flexDirection.row; style.paddingBottom 10; style.paddingTop 10]
                prop.children [
                    Bulma.button.button [
                        prop.classes ["has-text-weight-bold"]
                        Bulma.button.isRounded
                        Bulma.color.isDanger
                        prop.className [classes.buttonStyling]
                        //Bulma.button.isFullwidth
                        // prop.onClick (fun _ ->
                        //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
                        // )
                        prop.text "Deny"
                        prop.style [
                            style.fontSize 17
                            style.display.flex
                            style.justifyContent.center
                            // style.marginTop 30
                            // style.marginBottom 10
                        ]
                    ]
                    Bulma.button.button [
                        prop.classes ["has-text-weight-bold"]
                        Bulma.button.isRounded
                        Bulma.color.isSuccess
                        prop.className [classes.buttonStyling]
                        //Bulma.button.isFullwidth
                        // prop.onClick (fun _ ->
                        //     navigate.Invoke ( Routes.ApplicationRoute.Healix.ToString + Routes.ApplicationRoute.Members.ToString )
                        // )
                        prop.text "Approve"
                        prop.style [
                            style.fontSize 17
                            style.display.flex
                            style.justifyContent.center
                            // style.marginTop 30
                            // style.marginBottom 10
                        ]
                    ]
                ]
            ]
        ]
    ]

[<ReactComponent>]
let TabComponent() =
    let (currentTab, setTab) = React.useState Tab.About

    let tabContent =
        match currentTab with
        | About -> AboutMe
        | WorkingHours -> WorkingHoursComp
        | Ratings -> info
        // | Schedule -> CompletedAssessments myAssessments
        | _ -> (fun _ -> Html.span "Error")

    Html.section [
        prop.children [
            Html.div [
                prop.style [style.marginTop 20]
                prop.children [
                    Bulma.tabs [
                        tabs.isBoxed
                        tabs.isCentered
                        prop.style [style.marginBottom 10]
                        prop.children [
                            Html.ul [
                                Bulma.tab [
                                    Html.a [
                                        prop.text "About"
                                        prop.classes (if currentTab = About then [ "has-text-primary";"has-text-weight-bold";] else ["has-text-gray-dark"])
                                        prop.onClick (fun _ -> setTab About)
                                    ]
                                ]
                                Bulma.tab [
                                    Html.a [
                                        prop.text "Working Hours"
                                        prop.classes (if currentTab = WorkingHours then ["has-text-primary";"has-text-weight-bold"] else ["has-text-gray-dark"])
                                        prop.onClick (fun _ -> setTab WorkingHours)
                                    ]
                                ]
                                Bulma.tab [
                                    Html.a [
                                        prop.text "Info"
                                        prop.classes (if currentTab = Ratings then ["has-text-primary";"has-text-weight-bold"] else ["has-text-gray-dark"])
                                        prop.onClick (fun _ -> setTab Ratings)
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            (tabContent())
        ]
    ]



[<ReactComponent>]
let Approval () =
    Html.div [
        prop.children [
            PhysicianOverview()
            PhysicianMetrics()
            TabComponent()
            // AboutMe()
            // WorkingHoursComp()
            Buttons()
        ]
    ]
