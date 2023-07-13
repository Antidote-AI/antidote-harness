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

type Review = {
    User: string
    Rating: float
    Comment: string
}

let reviewsData = [
    { User = "Alex"; Rating = 5; Comment = "Great service, really enjoyed my experience!" }
    { User = "Beth"; Rating = 3; Comment = "Average experience, nothing exceptional." }
    { User = "Charlie"; Rating = 5; Comment = "Amazing! Best experience I've ever had." }
    { User = "Diana"; Rating = 2; Comment = "Was not satisfied with the service, needs improvement." }
    { User = "Eric"; Rating = 4; Comment = "Good experience overall, just a few minor issues." }
    { User = "Fiona"; Rating = 4; Comment = "Excellent service, would definitely recommend!" }
    { User = "Greg"; Rating = 3; Comment = "Decent experience, but I've had better." }
    { User = "Hannah"; Rating = 5; Comment = "Nearly perfect! Just a small hiccup with delivery." }
    { User = "Ivan"; Rating = 2; Comment = "The product was fine, but the service was lacking." }
    { User = "Julia"; Rating = 5; Comment = "Couldn't ask for a better experience! Absolutely fantastic." }
    { User = "Alex"; Rating = 5; Comment = "Great service, really enjoyed my experience!" }
    { User = "Beth"; Rating = 3; Comment = "Average experience, nothing exceptional." }
    { User = "Charlie"; Rating = 5; Comment = "Amazing! Best experience I've ever had." }
    { User = "Diana"; Rating = 2; Comment = "Was not satisfied with the service, needs improvement." }
    { User = "Eric"; Rating = 4; Comment = "Good experience overall, just a few minor issues." }
    { User = "Fiona"; Rating = 4; Comment = "Excellent service, would definitely recommend!" }
    { User = "Greg"; Rating = 3; Comment = "Decent experience, but I've had better." }
    { User = "Hannah"; Rating = 5; Comment = "Nearly perfect! Just a small hiccup with delivery." }
    { User = "Ivan"; Rating = 2; Comment = "The product was fine, but the service was lacking." }
    { User = "Julia"; Rating = 5; Comment = "Couldn't ask for a better experience! Absolutely fantastic." }
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
        prop.style [style.marginTop 15]
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
                    style.marginTop 10
                ]
                prop.children [
                    Html.div [
                        prop.style [style.marginRight 5]
                        prop.children [
                            Html.text (string rating)
                        ]
                    ]
                    Html.img [
                        prop.src ".././Assets/star-yellow.svg"
                        prop.style [
                            style.width 20
                            style.height 20
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
let reviews () =
    Html.div [
        prop.className [classes.parentContainer]
        prop.children [
            Html.div [
                //prop.style [style.backgroundColor.green]
                prop.className [classes.widthThirty]
                prop.children [
                    Html.div [
                        //prop.className [classes.widthThirty]
                        prop.classes ["is-flex"; "is-align-items-center"; "is-justify-content-center"; "full-height"]
                        prop.style [style.display.flex; style.justifyContent.center; style.flexDirection.column]
                        prop.children [
                            Html.div [
                                prop.classes ["has-background-primary"]
                                prop.style [
                                    style.display.flex
                                    style.justifyContent.center
                                    style.alignItems.center
                                    style.width 75
                                    style.height 75
                                    //style.backgroundColor "#00d1b2"
                                    style.borderRadius 50
                                    style.color "#ffffff"
                                    style.fontSize 25
                                    style.fontWeight.bold
                                    style.marginTop 15
                                    style.marginBottom 10
                                ]
                                prop.text "4.5" // Your rating here
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.flexDirection.row;style.width 20; style.height 20; style.justifyContent.center]
                                prop.children [
                                    Html.img [prop.src ".././Assets/star-yellow.svg"]
                                    Html.img [prop.src ".././Assets/star-yellow.svg"]
                                    Html.img [prop.src ".././Assets/star-yellow.svg"]
                                    Html.img [prop.src ".././Assets/star-yellow.svg"]
                                    Html.img [prop.src ".././Assets/star-yellow.svg"]
                                ]
                            ]
                            Html.div [
                                prop.children [
                                    Html.p [
                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                        prop.style [style.fontFamily "Inter"; style.fontSize 12; style.color.dimGray; style.fontWeight 550; style.marginTop 5]
                                        prop.children [
                                            Html.text (("126") + " " + ("Reviews"))
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.style [
                    style.display.flex
                    style.justifyContent.center
                    style.alignItems.center
                    style.flexDirection.column
                ]
                prop.className [classes.widthSeventy]
                prop.children reviewBar
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

let BookAppointment() =
    Html.div [
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
    ]

[<ReactComponent>]
let TabComponent() =
    let (currentTab, setTab) = React.useState Tab.About

    let tabContent =
        match currentTab with
        | About -> AboutMe
        | WorkingHours -> WorkingHoursComp
        | Ratings -> reviews
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
                                        prop.text "Reviews"
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
let Page () =
    Html.div [
        prop.children [
            PhysicianOverview()
            PhysicianMetrics()
            TabComponent()
            // AboutMe()
            // WorkingHoursComp()
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
