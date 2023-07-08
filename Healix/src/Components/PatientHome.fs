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
    | Diabetes -> ".././Assets/diabetes.svg"
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
    { Type = DiabetesAssessment; Status = NotStarted; PotentialPoints = 50; ActualPoints = 0};
    { Type = HeartAssessment; Status = InProgress; PotentialPoints = 50; ActualPoints = 0};
    { Type = HealixAssessment; Status = Complete; PotentialPoints = 50; ActualPoints = 0}
    // add more assessments as needed
]

let totalActualPoints = myAssessments |> List.sumBy (fun a -> a.ActualPoints)
let totalPotentialPoints = myAssessments |> List.sumBy (fun a -> a.PotentialPoints)

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
                Html.img [
                    //prop.className [classes.picture]
                    prop.style [style.display.flex; style.justifyContent.center; style.alignItems.center; style.alignContent.center; style.marginTop 15]
                    prop.src ".././Assets/no_data.png"
                    prop.alt "messaging icon"
                    //prop.style [style.width 300; style.height 42]
                    prop.classes ["image"; "is-rounded"; "p-3";]
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
                prop.children [
                    Bulma.card [
                        Bulma.cardContent [
                            Html.div [
                                prop.style [style.display.flex; style.justifyContent.spaceBetween]
                                prop.children [
                                    Html.div [
                                        prop.style [style.display.flex; style.alignItems.center]
                                        prop.children [
                                            Html.img [
                                                prop.src (iconToUrl (getIconForAssessment assessment.Type))
                                                prop.alt "assessment icon"
                                                prop.style [style.width 45; style.height 45]
                                                prop.className "image is-rounded p-3 has-background-link-light"
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
                                ]
                            ]
                        ]
                    ]
                ]
            ])))
    ]


let ToDoComponent () =
    Html.div[
        prop.children [
            Html.div [
                prop.children [
                    Html.strong "Upcoming Appointments"
                ]
            ]
            Bulma.card [
                Bulma.cardContent [
                    Html.div [
                        prop.style [style.display.flex; style.justifyContent.spaceBetween]
                        prop.children [
                            Html.div [
                                prop.style [style.display.flex; style.alignItems.center]
                                prop.children [
                                    Html.img [
                                        prop.src ".././Assets/message-rounded-icon-blue.svg"
                                        prop.alt "messaging icon"
                                        prop.style [style.width 42; style.height 42]
                                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"; "p-3";  "has-background-link-light";]
                                    ]
                                    Html.div [
                                        prop.style [style.display.flex; style.justifyContent.flexStart; style.alignItems.center; style.marginLeft 7]
                                        prop.children [
                                            Html.strong "Progress"
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [style.display.flex; style.justifyContent.flexEnd; style.alignItems.center]
                                prop.children [
                                    Html.strong "50 pts"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

[<ReactComponent>]
let PatientHome (props:PatientHomeData) =

    let (currentTab, setTab) = React.useState Tab.Progress

    let tabContent =
        match currentTab with
        | Progress -> progress myAssessments
        | ToDo -> ToDoComponent()
        | Completed -> Html.p [ prop.text "Completed Content" ]
        | Upcoming -> Html.p [ prop.text "Upcoming Content" ]

    Html.section [
        prop.classes ["appointmentViewerList"; "m-4"; "is-flex"; "is-justify-content-space-between"]
        prop.style [ style.display.flex; style.flexDirection.column] // column direction for section
        prop.children [
            // New container to hold existing elements and the "New" tag
            Html.div [
                prop.classes ["card"]
                prop.style [ style.display.flex; style.justifyContent.spaceBetween; style.marginBottom 15] // row direction for this container
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
                                                        prop.src props.Avatar
                                                        //prop.alt "messaging icon"
                                                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["appointmentViewerList__container-content"]
                                                prop.children [
                                                    Html.h2 [
                                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                        prop.text (props.FirstName + " " + props.LastName)
                                                        prop.style [style.fontFamily "Inter"; style.fontWeight.bold; style.fontSize 20;style.marginBottom -10; style.marginLeft 7]
                                                    ]
                                                    Html.div [
                                                        prop.children [
                                                            Html.p [
                                                                prop.classes ["appointmentViewerList__messaging"; "p-2"; "has-text-grey-dark"]
                                                                prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.marginTop -10; style.marginLeft 7]
                                                                prop.children [
                                                                    Html.text (props.DOB + " | " + props.Gender)
                                                                ]
                                                            ]
                                                        ]
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
                                                    let ptsIcon (pts:int) =
                                                        match pts with
                                                        | pts when pts >= 0 && pts <= 100 -> ".././Assets/bronze.svg"
                                                        | pts when pts > 100 && pts <= 200 -> ".././Assets/silver.svg"
                                                        | pts when pts > 200 && pts <= 300 -> ".././Assets/gold.svg"
                                                        | pts when pts > 300 && pts <= 400 -> ".././Assets/diamond.svg"
                                                        | _ -> "" // You may want to handle a case when pts is out of your range, or negative
                                                    Html.img [
                                                        prop.style [style.width 20; style.height 20]
                                                        prop.src (ptsIcon totalActualPoints)
                                                        //prop.alt "messaging icon"
                                                        prop.classes [classes.MessagingIcon;"image"; "is-rounded"]
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
            tabContent
        ]
    ]
