module Healix.Components.PatientHome

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
open Feliz.Plotly
//open Healix.Components.PhysicianOverview


// open Antidote.Core.V2.Utils.JS

emitJsStatement () "import React from \"react\""


let private classes : CssModules.Components.PatientHome = import "default" "./PatientHome.module.scss"



type AssessmentType =
    | DiabetesAssessment
    | HeartAssessment
    | HealixAssessment
    | KidneyAssessment
    | LiverAssessment
    | LungsAssessment

type PatientHomeData =
    {
        FirstName: string
        LastName: string
        DOB: string
        Gender: string
        UpcomingAssessments: AssessmentType list
        CompletedAssessments: AssessmentType list
        Avatar: string
        //UpcomingAppointments: AssessmentType list
    }

let patientData =  { FirstName = "Alex"; LastName = "Campo" ; DOB = "03/06/1995"; Gender = "Male"; UpcomingAssessments = []; CompletedAssessments = []; Avatar = ".././Assets/alan-katz.jpg" }


type Tab =
    | Progress
    | ToDo
    | Completed
    | Upcoming


type Icon =
    | Diabetes
    | Heart
    | Healix
    | Kidney
    | Liver
    | Lungs



let getIconForAssessment (assessment: AssessmentType): Icon =
    match assessment with
    | DiabetesAssessment -> Diabetes
    | HeartAssessment -> Heart
    | HealixAssessment -> Healix
    | KidneyAssessment -> Kidney
    | LiverAssessment -> Liver
    | LungsAssessment -> Lungs

let iconToUrl (icon: Icon): string =
    match icon with
    | Diabetes -> ".././Assets/insulin-pen.svg"
    | Heart -> ".././Assets/heart.svg"
    | Healix -> ".././Assets/helix.svg"
    | Kidney -> ".././Assets/kidney.svg"
    | Liver -> ".././Assets/liver.svg"
    | Lungs -> ".././Assets/lungs.svg"

type AssessmentStatus =
    | NotStarted
    | InProgress
    | Complete

type Assessment =
    {
        Type: AssessmentType
        Status: AssessmentStatus
        PotentialPoints: int
        ActualPoints: int
    }

let updateAssessmentPoints (a: Assessment) =
    match a.Status with
    | NotStarted -> { a with ActualPoints = 0 }
    | InProgress -> { a with ActualPoints = 0 }
    | Complete -> { a with ActualPoints = a.PotentialPoints }


let myAssessments : Assessment list = [
    { Type = DiabetesAssessment; Status = NotStarted; PotentialPoints = 50; ActualPoints = 50};
    { Type = HeartAssessment; Status = NotStarted; PotentialPoints = 50; ActualPoints = 50};
    { Type = LungsAssessment; Status = Complete; PotentialPoints = 50; ActualPoints = 50}
    // add more assessments as needed
]

let totalActualPoints = myAssessments |> List.sumBy (fun a -> a.ActualPoints)
let totalPotentialPoints = myAssessments |> List.sumBy (fun a -> a.PotentialPoints)


[<ReactComponent>]
let ToDoComponent (myAssessments: Assessment list) =
    let toDoAssessments =
        myAssessments
        |> List.filter (fun assessment -> assessment.Status = NotStarted)

    let assessmnetsElements =
        toDoAssessments
        |> List.map (fun assessment ->
            Html.div [
                prop.style [style.marginBottom 7]
                prop.children [
                    Bulma.card [
                        prop.children [
                            Bulma.cardContent [
                                Html.div [
                                    prop.style [style.display.flex; style.justifyContent.spaceBetween; style.height 15]
                                    prop.children [
                                        Html.div [
                                            prop.style [style.display.flex; style.alignItems.center]
                                            prop.children [
                                                Html.img [
                                                    prop.src (iconToUrl (getIconForAssessment assessment.Type))
                                                    prop.alt "assessment icon"
                                                    prop.style [style.width 25; style.height 25; style.marginRight 10]
                                                ]
                                                Html.div [
                                                    prop.style [style.display.flex; style.justifyContent.flexStart; style.alignItems.center; style.marginLeft 7]
                                                    prop.children [
                                                        Html.strong (sprintf "%A" assessment.Type)
                                                    ]
                                                ]
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center]
                                            prop.children [
                                                Html.strong (sprintf "%d pts" assessment.ActualPoints)
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center]
                                            prop.children [
                                                Html.i [ prop.classes [ "fas"; "fa-chevron-right"] ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ])
    Html.div [ prop.children assessmnetsElements ]


[<ReactComponent>]
let progress(myAssessments: Assessment list) =
    Html.section [
        prop.children ([
            Html.div [
                prop.style [style.display.flex; style.justifyContent.spaceBetween; style.marginTop 2; style.marginBottom 7]
                prop.children [
                    Html.div [
                        prop.children [
                            Html.strong "Progress"
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.justifyContent.flexEnd]
                        prop.children [
                            Html.strong ((sprintf "%d" totalActualPoints) + " of " + (sprintf "%d" totalPotentialPoints))
                        ]
                    ]
                ]
            ]
            Html.div [
                Bulma.progress [
                    prop.value totalActualPoints
                    prop.max totalPotentialPoints
                    prop.className "is-primary"
                ]
            ]
            match totalActualPoints > 0 with
            | true ->
                Html.div [
                    prop.className [classes.plot]
                    prop.style [style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px"); style.marginTop 15]
                    prop.children [
                        Plotly.plot [
                            plot.traces [
                                traces.scatter [
                                    scatter.x [ "Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "July" ]
                                    scatter.y [ 3; 2; 3; 5; 7; 3; 6]
                                    scatter.mode.lines
                                    scatter.fill.tozeroy
                                    scatter.line [
                                        line.shape.spline
                                    ]
                                ]
                            ]
                            plot.layout [
                                layout.title [
                                    title.text "Progress over time"
                                    title.font [
                                        font.family "Arial, sans-serif"
                                        font.size 18
                                        font.color "black"
                                    ]
                                ]
                                layout.autosize true
                                layout.showlegend false
                                layout.height 350
                                layout.width 480
                                //style.width (length.perc 100)
                            ]
                            plot.useResizeHandler true
                            plot.style [
                                style.display.flex
                                style.justifyContent.center
                                style.alignItems.center
                                style.alignContent.center
                            ]
                            plot.config [
                                config.autosizable true
                                config.displaylogo false
                                config.doubleClick.resetAndAutosize
                                config.modeBarButtonsToRemove [
                                    modeBarButtons.autoScale2d
                                    modeBarButtons.hoverCompareCartesian
                                    modeBarButtons.hoverClosestCartesian
                                    modeBarButtons.toggleSpikelines
                                    modeBarButtons.zoomIn2d
                                    modeBarButtons.zoomOut2d
                                    modeBarButtons.lasso2d
                                    modeBarButtons.zoom2d
                                    modeBarButtons.pan2d
                                    modeBarButtons.resetScale2d
                                    modeBarButtons.select2d
                                    modeBarButtons.toImage
                                ]
                                config.responsive true
                                config.scrollZoom.false'
                            ]
                        ]
                    ]
                ]
            | false ->
                Html.div [
                    prop.style [style.marginTop 25; style.marginBottom 25]
                    prop.children [
                        Bulma.image [
                            prop.style [
                                style.paddingTop 5
                                style.maxWidth 350
                                style.margin.auto
                                style.paddingBottom 10
                            ]
                            Html.img [ prop.src ".././Assets/nodata2.png" ]
                            |> prop.children
                        ]
                        Html.div [
                            prop.style [style.display.flex; style.justifyContent.center; style.fontSize 20]
                            prop.children [
                                Html.strong "No progress to display"
                            ]
                        ]
                        Html.div [
                            prop.className [classes.textContainer]
                            prop.style [style.display.flex; style.justifyContent.center; style.color.dimGray]
                            prop.children [
                                Html.p "Please complete assessments below to accumulate points."
                            ]
                        ]
                    ]
                ]

            Html.div [
                prop.style [style.marginTop 15; style.marginBottom 5]
                prop.children [
                    Html.strong "Upcoming Appointments"
                ]
            ]
        ]
        @ (myAssessments |> List.map (fun assessment ->
            Html.div [
                prop.style [style.marginBottom 7]
                prop.children [
                    Bulma.card [
                        prop.children [
                            Bulma.cardContent [
                                Html.div [
                                    prop.style [style.display.flex; style.justifyContent.spaceBetween; style.height 15]
                                    prop.children [
                                        Html.div [
                                            prop.style [style.display.flex; style.alignItems.center]
                                            prop.children [
                                                Html.img [
                                                    //prop.classes [classes.MessagingIcon; "is-rounded";  "has-background-white-bis"]
                                                    prop.src (iconToUrl (getIconForAssessment assessment.Type))
                                                    prop.alt "assessment icon"
                                                    prop.style [style.width 25; style.height 25; style.marginRight 10]

                                                ]
                                                Html.div [
                                                    prop.style [style.display.flex; style.justifyContent.flexStart; style.alignItems.center; style.marginLeft 7]
                                                    prop.children [
                                                        Html.strong (sprintf "%A" assessment.Type)
                                                    ]
                                                ]
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center]
                                            prop.children [
                                                Html.strong (sprintf "%d pts" assessment.ActualPoints)
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center]
                                            prop.children [
                                                Html.i [ prop.classes [ "fas"; "fa-chevron-right"] ]
                                            ]
                                        ]

                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ])))
    ]




[<ReactComponent>]
let upcomingAptsComponent() =
    Html.div [
        prop.children [
            Html.div [
                prop.style [style.marginTop 15; style.marginBottom 5]
                prop.children [
                    Html.strong "Upcoming Appointments"
                ]
            ]
            Html.div [
                prop.classes ["card"]
                prop.style [ style.display.flex; style.flexDirection.column; style.marginBottom 15] // row direction for this container
                prop.children [
                    Html.div [
                        prop.style [style.width (length.perc 100)]
                        prop.classes ["appointmentViewerList__container-content"; "is-flex"; "is-flex-direction-row"; "m-1"; "is-justify-content-space-between"]
                        prop.children [
                            Html.div [
                                prop.style [ style.display.flex; style.alignItems.center; style.justifyContent.spaceBetween; style.width (length.perc 100); style.flexGrow 1 ]
                                // added justifyContent.spaceBetween and style.width.pct 100 to stretch the container
                                prop.children [
                                    Html.div [
                                        prop.style [ style.display.flex; style.alignItems.center]
                                        prop.children [
                                            Html.div [
                                                prop.children [
                                                    Html.img [
                                                        prop.style [style.marginLeft 10; style.width 48; style.height 48]
                                                        prop.src ".././Assets/me.jpeg"
                                                        //prop.alt "messaging icon"
                                                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["appointmentViewerList__container-content"]
                                                prop.children [
                                                    Html.h3 [
                                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                        prop.text ("Alex" + " " + "Campo")
                                                        prop.style [style.fontFamily "Inter"; style.fontWeight.bold; style.fontSize 17;style.marginBottom -20; style.marginLeft 7; style.color.black]
                                                    ]
                                                    Html.div [
                                                        prop.children [
                                                            Html.p [
                                                                prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                                prop.style [style.fontFamily "Inter"; style.marginLeft 7; style.fontSize 14; style.color.gray]
                                                                prop.children [
                                                                    Html.text ("Family Medicine")
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
                                        prop.children [
                                            Html.div [
                                                prop.classes ["appointmentViewerList__container-content"]
                                                prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center; style.paddingRight 10]
                                                prop.children [
                                                    Html.div [
                                                        prop.classes [classes.MessagingIcon; "image"; "is-rounded"; "p-3";  "has-background-link-light"]
                                                        prop.children [
                                                            Html.img [
                                                                prop.src ".././Assets/message-rounded-icon-blue.svg"
                                                                prop.alt "messaging icon"
                                                                prop.style [style.width 17; style.height 17]
                                                                //rop.classes [classes.MessagingIcon;"image"; "is-rounded"; "p-3";  "has-background-link-light"]
                                                            ]
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["appointmentViewerList__container-content"]
                                                prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center; style.paddingRight 10]
                                                prop.children [
                                                    Html.div [
                                                        prop.classes [classes.MessagingIcon; "image"; "is-rounded"; "p-3";  "has-background-link-light"]
                                                        prop.children [
                                                            Html.img [
                                                                prop.src ".././Assets/video-call.svg"
                                                                prop.alt "messaging icon"
                                                                prop.style [style.width 17; style.height 17]
                                                                //rop.classes [classes.MessagingIcon;"image"; "is-rounded"; "p-3";  "has-background-link-light"]
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
                    Html.div [
                        prop.style [ style.borderTop(1, borderStyle.solid, color.whiteSmoke); style.borderTopColor color.whiteSmoke;style.display.flex;
                                    style.flexDirection.row; style.flexWrap.wrap; style.justifyContent.spaceBetween; style.gap 10]
                        prop.classes ["appointmentViewerList__container-button"; "is-flex"; "is-justify-content-space-evenly";"has-border-top"; ]
                        prop.children [
                            Html.div [
                                prop.style [style.display.flex; style.alignItems.center; style.marginTop 7; style.marginBottom 7] // Added alignItems.center to align items vertically
                                prop.children [
                                    Html.img [prop.src ".././Assets/calendar.svg"; prop.style [style.width 15; style.height 15; style.marginRight 5]]
                                    Html.div [
                                        prop.style [style.fontSize 14; style.fontFamily "Inter"; style.color.black]
                                        prop.children [
                                            Html.text "Sun - Oct 20, 11:00 AM - 12:00 PM"
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
let CompletedAssessments (myAssessments: Assessment list)=
    let completedAssessments =
        myAssessments
        |> List.filter (fun assessment -> assessment.Status = Complete)
    let assessmentsElements =
        completedAssessments
        |> List.map (fun assessment ->
            Html.div [
                prop.style [style.marginBottom 7]
                prop.children [
                    Bulma.card [
                        prop.classes ["has-background-success-light"]
                        prop.children [
                            Bulma.cardContent [
                                Html.div [
                                    prop.style [style.display.flex; style.justifyContent.spaceBetween; style.height 15]
                                    prop.children [
                                        Html.div [
                                            prop.style [style.display.flex; style.alignItems.center]
                                            prop.children [
                                                Html.img [
                                                    prop.src (iconToUrl (getIconForAssessment assessment.Type))
                                                    prop.alt "assessment icon"
                                                    prop.style [style.width 25; style.height 25; style.marginRight 10]
                                                ]
                                                Html.div [
                                                    prop.style [style.display.flex; style.justifyContent.flexStart; style.alignItems.center; style.marginLeft 7]
                                                    prop.children [
                                                        Html.strong (sprintf "%A" assessment.Type)
                                                    ]
                                                ]
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center]
                                            prop.children [
                                                Html.strong (sprintf "%d pts" assessment.ActualPoints)
                                            ]
                                        ]
                                        Html.div [
                                            prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center]
                                            prop.children [
                                                Html.img [
                                                    prop.src ".././Assets/check.svg"
                                                    prop.style [style.height 20; style.width 20]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ])
    Html.div [ prop.children assessmentsElements ]


[<ReactComponent>]
let PatientHome (props:PatientHomeData) =

    let (currentTab, setTab) = React.useState Tab.Progress

    let tabContent =
        match currentTab with
        | Progress -> progress myAssessments
        | ToDo -> ToDoComponent myAssessments
        | Completed -> CompletedAssessments myAssessments
        | Upcoming -> upcomingAptsComponent()

    Html.section [
        prop.classes ["appointmentViewerList"; "m-4"; "is-flex"; "is-justify-content-space-between"]
        prop.style [ style.display.flex; style.flexDirection.column;] // column direction for section
        prop.children [
            // New container to hold existing elements and the "New" tag
            Html.div [
                prop.style [ style.flexDirection.column]
                prop.className [classes.marginLess]
                prop.classes ["appointmentViewerList__container-content"; "is-flex"; "m-1"; "is-justify-content-space-between"]
                prop.children [
                    Html.div [
                        prop.style [ style.display.flex; style.alignItems.center; style.flexDirection.column; style.justifyContent.center; style.width (length.perc 100); style.flexGrow 1]
                        prop.children [
                            Html.div [
                                prop.style [ style.display.flex; style.flexDirection.column; style.alignItems.center; style.marginTop 10]
                                prop.children [
                                    Html.div [
                                        prop.children [
                                            Html.img [
                                                prop.style [style.marginLeft 10; style.width 75; style.height 75]
                                                prop.src ".././Assets/me.jpeg"
                                                prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.classes ["appointmentViewerList__container-content"]
                                        prop.children [
                                            Html.h3 [
                                                prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                prop.text ("Alex" + " " + "Campo")
                                                prop.style [style.fontFamily "Inter"; style.fontWeight.bold; style.fontSize 17;style.marginBottom -20; style.color.black; style.textAlign.center]
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

                    Html.div [
                        prop.style [ style.display.flex; style.alignItems.center; style.justifyContent.center; style.width (length.perc 100); style.flexGrow 1]
                        // added justifyContent.spaceBetween and style.width.pct 100 to stretch the container
                        prop.children [
                            Html.div [
                                prop.style [ style.display.flex; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        Bulma.level [
                                            //Bulma.level.isMobile
                                            Bulma.levelItem [
                                                prop.classes ["has-text-centered"]
                                                prop.style [style.borderRight(1, borderStyle.solid, color.whiteSmoke); style.borderRightColor color.whiteSmoke; style.width (length.perc 100); style.flexGrow 1]
                                                prop.children [
                                                    Html.div [
                                                        prop.children [
                                                            Html.img [
                                                                prop.style [style.marginLeft 10; style.width 40; style.height 40]
                                                                prop.src ".././Assets/competition.svg"
                                                                //prop.alt "messaging icon"
                                                                //prop.classes [classes.MessagingIcon;"image"]
                                                            ]
                                                        ]
                                                    ]
                                                    Html.div [
                                                        prop.classes ["appointmentViewerList__container-content"]
                                                        prop.children [
                                                            Html.h3 [
                                                                prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                                prop.text "17th"
                                                                prop.style [style.fontFamily "Inter"; style.fontWeight.bold; style.fontSize 17;style.marginBottom -20; style.marginLeft 7; style.color.black]
                                                            ]
                                                            Html.div [
                                                                prop.children [
                                                                    Html.p [
                                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                                        prop.style [style.fontFamily "Inter"; style.marginLeft 7; style.fontSize 14; style.color.gray]
                                                                        prop.children [
                                                                            Html.text ("Percentile")
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
                                    Html.div [
                                        Bulma.level [
                                            //Bulma.level.isMobile
                                            Bulma.levelItem [
                                                prop.classes ["has-text-centered"]
                                                prop.style [style.marginLeft 5]
                                                prop.children [
                                                    Html.div [
                                                        prop.children [
                                                            let ptsIcon (pts:int) =
                                                                match pts with
                                                                | pts when pts >= 0 && pts <= 100 -> ".././Assets/bronze.svg"
                                                                | pts when pts > 100 && pts <= 200 -> ".././Assets/silver.svg"
                                                                | pts when pts > 200 && pts <= 300 -> ".././Assets/gold.svg"
                                                                | pts when pts > 300 && pts <= 400 -> ".././Assets/diamond.svg"
                                                                | _ -> "" // You may want to handle a case when pts is out of your range, or negative
                                                            Html.img [
                                                                prop.style [style.width 40; style.height 40]
                                                                prop.src (ptsIcon totalActualPoints)
                                                                //prop.alt "messaging icon"
                                                                prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                                                            ]
                                                        ]
                                                    ]
                                                    Html.div [
                                                        prop.classes ["appointmentViewerList__container-content"]
                                                        prop.children [
                                                            Html.h3 [
                                                                prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                                prop.text "Bronze"
                                                                prop.style [style.fontFamily "Inter"; style.fontWeight.bold; style.fontSize 17;style.marginBottom -20; style.marginLeft 7; style.color.black]
                                                            ]
                                                            Html.div [
                                                                prop.children [
                                                                    Html.p [
                                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                                        prop.style [style.fontFamily "Inter"; style.marginLeft 7; style.fontSize 14; style.color.gray]
                                                                        prop.children [
                                                                            Html.text ("Status")
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
                        ]
                    ]
                ]
            ]


            // Line and text at the bottom of the section
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
                                        prop.text "Progress"
                                        prop.className [classes.tab]
                                        prop.classes (if currentTab = Progress then [ "has-background-primary";"has-text-white";"has-text-weight-bold" ] else ["has-text-gray-dark"])
                                        prop.onClick (fun _ -> setTab Progress)
                                    ]
                                ]
                                Bulma.tab [
                                    Html.a [
                                        prop.text "To Do"
                                        prop.className [classes.tab]
                                        prop.classes (if currentTab = ToDo then [ "has-background-primary";"has-text-white";"has-text-weight-bold" ] else ["has-text-gray-dark"])
                                        prop.onClick (fun _ -> setTab ToDo)
                                    ]
                                ]
                                Bulma.tab [
                                    Html.a [
                                        prop.text "Completed"
                                        prop.className [classes.tab]
                                        prop.classes (if currentTab = Completed then [ "has-background-primary";"has-text-white";"has-text-weight-bold" ] else ["has-text-gray-dark"])
                                        prop.onClick (fun _ -> setTab Completed)
                                    ]
                                ]
                                Bulma.tab [
                                    Html.a [
                                        prop.text "Upcoming"
                                        prop.className [classes.tab]
                                        prop.classes (if currentTab = Upcoming then [ "has-background-primary";"has-text-white";"has-text-weight-bold" ] else ["has-text-gray-dark"])
                                        prop.onClick (fun _ -> setTab Upcoming)
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            tabContent
        ]
    ]
