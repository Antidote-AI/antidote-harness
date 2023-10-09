module Healix.Components.EditablePatientProfileCard

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

let private classes : CssModules.Components.EditablePatientProfileCard = import "default" "./EditablePatientProfileCard.module.scss"


[<ReactComponent>]
let EditablePatientProfileCard () =
    let (isEditMode, setEditMode) = React.useState false
    let (newText, setNewText) = React.useState ""
    let (currentText, setCurrentText) = React.useState "Hello"  // New state variable for current text

    let handleKeyDown (event: Browser.Types.KeyboardEvent) =
        if event.key = "Enter" && newText.Length > 0 then
            setCurrentText newText  // Update current text when Enter is pressed
            setNewText ""
            setEditMode false

    let handleInputChange value =
        setNewText value

    let handleEditButtonClick () =
        setEditMode true


    Html.div [
        prop.style [ style.display.flex; style.justifyContent.center; style.flexDirection.column; style.width (length.perc 100); style.flexGrow 1; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
        prop.children [
            Html.div [
                prop.className [classes.myDiv]
                prop.children [
                    Html.div [
                        prop.className [classes.responsiveFlexContainer]
                        prop.style [ style.display.flex; style.flexDirection.row; style.alignItems.center; style.marginTop 10; style.marginBottom 10; style.flexWrap.wrap; style.width (length.perc 100)]
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
                                prop.style [style.width (length.perc 90)]
                                prop.classes ["appointmentViewerList__container-content"]
                                prop.children [
                                    Html.div [
                                        prop.className [classes.flexToCenter]
                                        prop.classes ["appointmentViewerList__name"; "has-text-weight-bold"; "p-2" ]
                                        prop.className [classes.flexToCenter]
                                        prop.style [
                                            style.fontFamily "Inter";
                                            style.fontWeight.bold;
                                            style.fontSize 17;
                                            style.color.black;
                                            style.display.flex;
                                            style.justifyContent.flexStart;
                                            style.alignItems.center;
                                        ]
                                        prop.children [
                                            Html.div [
                                                prop.style [
                                                    style.display.flex;
                                                    style.justifyContent.spaceBetween;
                                                    style.alignItems.center;
                                                    style.flexWrap.wrap; (* This ensures wrapping behavior *)
                                                    style.width (length.perc 100)
                                                ]
                                                prop.children [
                                                    Html.div [
                                                        prop.className classes.nameAndTags (* This class will be targeted in the media query for mobile adjustments *)
                                                        prop.style [style.display.flex; style.alignItems.center]
                                                        prop.children [
                                                            if isEditMode then
                                                                Html.input [
                                                                    prop.value newText  // Use prop.value instead of prop.defaultValue
                                                                    prop.className classes.inputTag
                                                                    prop.autoFocus true
                                                                    prop.onChange (fun event -> handleInputChange event)
                                                                    prop.onKeyDown (fun event -> handleKeyDown event)
                                                                    prop.placeholder currentText
                                                                ]
                                                            else
                                                                Html.span [ prop.text currentText ]

                                                            Html.div [
                                                                prop.style [ style.display.flex; style.flexDirection.row; style.justifyContent.flexEnd; style.alignItems.center; style.marginLeft 5 ]
                                                                prop.className [classes.marginTop; classes.nameAndTags]
                                                                prop.children [
                                                                    Bulma.tag [
                                                                        Bulma.color.isPrimary
                                                                        Bulma.color.isLight
                                                                        prop.classes ["has-text-primary"; "has-text-weight-bold"]
                                                                        prop.className classes.marginBottom
                                                                        prop.style [style.marginRight 10]
                                                                        prop.children [
                                                                            Icon [
                                                                                icon.icon mdi.email
                                                                                icon.width 14
                                                                                icon.height 14
                                                                            ]
                                                                            Html.p [
                                                                                prop.text "alexcampo3695@gmail.com"
                                                                                prop.style [style.marginLeft 5]
                                                                            ]
                                                                        ]
                                                                    ]
                                                                    Bulma.tag [
                                                                        Bulma.color.isPrimary
                                                                        Bulma.color.isLight
                                                                        prop.classes ["has-text-primary"; "has-text-weight-bold"]
                                                                        prop.style [style.marginRight 5]
                                                                        prop.children [
                                                                            Icon [
                                                                                icon.icon mdi.phone
                                                                                icon.width 14
                                                                                icon.height 14
                                                                            ]
                                                                            Html.p [
                                                                                prop.text "305-206-4761"
                                                                                prop.style [style.marginLeft 5]
                                                                            ]
                                                                        ]
                                                                    ]
                                                                ]
                                                            ]
                                                        ]
                                                    ]
                                                    Html.div [
                                                        prop.className [classes.nameAndTags; classes.editButton]
                                                        prop.style [
                                                            style.position.absolute; (* This positions the button *)
                                                            style.top 20;             (* Aligns the button to the top of the container *)
                                                            style.right 10;           (* Aligns the button to the right of the container *)
                                                        ]
                                                        prop.children [
                                                            Bulma.button.button [
                                                                Bulma.color.isPrimary
                                                                Bulma.button.isInverted
                                                                Bulma.button.isSmall
                                                                prop.classes [ "has-text-weight-bold"]
                                                                prop.onClick (fun _ -> handleEditButtonClick ())
                                                                prop.style [style.marginRight 10; style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                                                prop.children [
                                                                    Icon [
                                                                        icon.icon mdi.squareEditOutline
                                                                        icon.width 20
                                                                        icon.height 20
                                                                        icon.color color.dimGray
                                                                    ]
                                                                    Html.p [
                                                                        prop.text "Edit"
                                                                        prop.style [style.marginLeft 5]
                                                                    ]
                                                                ]
                                                            ]
                                                            Bulma.button.button [
                                                                Bulma.color.isPrimary
                                                                Bulma.button.isInverted
                                                                Bulma.button.isSmall
                                                                prop.classes [ "has-text-weight-bold"]
                                                                prop.style [style.marginRight 10; style.border(1, borderStyle.solid, color.dimGray); style.color.black]
                                                                prop.children [
                                                                    Icon [
                                                                        icon.icon mdi.ellipsisHorizontal
                                                                        icon.width 20
                                                                        icon.height 20
                                                                        icon.color color.dimGray
                                                                    ]
                                                                    Html.p [
                                                                        prop.text "Actions"
                                                                        prop.style [style.marginLeft 5]
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
                                        prop.classes [classes.flexToCenter]
                                        prop.style [style.display.flex; style.flexWrap.wrap]
                                        prop.children [
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-calendar"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("03/06/1995")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-user"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("Male")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-globe"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("English")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-location-arrow"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("2020 N bayshore Drive, 1806")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                    Html.div [
                                        prop.classes [classes.flexToCenter]
                                        prop.style [style.display.flex; style.flexWrap.wrap]
                                        prop.children [
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-hospital"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("Aetna")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex; style.flexWrap.wrap]
                                                prop.children [
                                                    Html.p [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.color.dimGray]
                                                        prop.children [
                                                            Html.i [
                                                                prop.classes [ "fas"; "fa-check"]
                                                                prop.style [style.marginRight 5; style.color.black]
                                                            ]
                                                            Html.text ("Aetna Open ACC Mngd")
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex;style.flexWrap.wrap]
                                                prop.children [
                                                    Html.div [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.display.flex]
                                                        prop.children [
                                                            Html.div [
                                                                prop.style [style.fontWeight.bold; style.color.black]
                                                                prop.children [
                                                                    Html.text ("Group ID:")
                                                                ]
                                                            ]
                                                            Html.div [
                                                                prop.style [style.color.dimGray; style.marginLeft 5]
                                                                prop.children [
                                                                    Html.text ("123456789")
                                                                ]
                                                            ]
                                                        ]
                                                    ]
                                                ]
                                            ]
                                            Html.div [
                                                prop.classes ["flexGroup"]
                                                prop.style [style.display.flex;style.flexWrap.wrap]
                                                prop.children [
                                                    Html.div [
                                                        prop.classes ["appointmentViewerList__messaging"; "p-2"]
                                                        prop.style [style.fontFamily "Inter"; style.fontSize 14; style.display.flex]
                                                        prop.children [
                                                            Html.div [
                                                                prop.style [style.fontWeight.bold; style.color.black]
                                                                prop.children [
                                                                    Html.text ("Member ID:")
                                                                ]
                                                            ]
                                                            Html.div [
                                                                prop.style [style.color.dimGray; style.marginLeft 5]
                                                                prop.children [
                                                                    Html.text ("123456789")
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
