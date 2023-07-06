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


//let appointment = { Title = "Appointment Cancelled"; Time = "Today | 4:30pm" ; ImgSrc = ".././Assets/message-rounded-icon-blue.svg" }

type Tab =
    | Progress
    | ToDo
    | Completed
    | Upcoming

type TodoStatus =
    | NotStarted
    | InProgress
    | Completed

type Icon =
    | Diabetes
    | Heart
    | Healix
    | Kidney
    | Liver
    | Lungs

let getIcon (status: TodoStatus) =
    match status with
    | Diabetes
    | Heart
    | Healix
    | Kidney
    | Liver
    | Lungs



let progress() =
    Html.section [
        prop.children [
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
                            Html.strong "57 of 500"
                        ]
                    ]
                ]
            ]
            Html.div [
                Bulma.progress [
                    prop.value 15
                    prop.max 100
                    prop.className "is-primary"
                ]
            ]
            Html.div [
                //prop.classes ["card", "plot"]
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
                        ]
                        plot.useResizeHandler true
                        plot.style [
                            style.height (length.perc 100)
                            //style.width (length.perc 100)
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
            Html.strong "Upcoming Appointments"

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
let PatientHome () =

    let (currentTab, setTab) = React.useState Tab.Progress

    let tabContent =
        match currentTab with
        | Progress -> progress()
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
                        prop.classes ["appointmentViewerList__container-content"; "is-flex"; "is-flex-direction-row"; "m-1"; "is-justify-content-space-between"]
                        prop.children [
                            Html.div [
                                prop.style [ style.display.flex; style.justifyContent.spaceBetween; style.alignItems.center]
                                prop.children [
                                    Html.div [
                                        prop.children [
                                            Html.img [
                                                prop.src ".././Assets/alan-katz.jpg"
                                                //prop.alt "messaging icon"
                                                prop.classes [classes.MessagingIcon;"image";"is-64x64"; "is-rounded"]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.classes ["appointmentViewerList__container-content"]
                                        prop.children [
                                            Html.h2 [
                                                prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                                prop.text "Alexander Campo"
                                                prop.style [style.fontFamily "Inter"; style.fontWeight.bold; style.fontSize 20;style.marginBottom -10; style.marginLeft 7]
                                            ]
                                            Html.div [
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"; "has-text-grey-dark"]
                                                        prop.style [style.fontFamily "Inter"; style.color "#504A4B"; style.marginTop -10; style.marginLeft 7]
                                                        prop.children [
                                                            Html.text "03/06/1995 | Male"
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
