module Healix.Components.MyAccount

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


emitJsStatement () "import React from \"react\""

let private classes : CssModules.Components.MyAccount = import "default" "./MyAccount.module.scss"

type AccountData = {
    FirstName: string
    MiddleName: string
    LastName: string
    PreferedLanguage: string
    DateOfBirth: string
    MobilePhone: string
    HomePhone: string
    Email: string
    MartialStatus: string
    Race: string
    Ethnicity: string
    MailingStreetAddress: string
    MailingAptSuite: string
    State: string
    City: string
    ZipCode: string
}

let sampleAccountData: AccountData = {
    FirstName = "John"
    MiddleName = "A."
    LastName = "Doe"
    PreferedLanguage = "English"
    DateOfBirth = "01/01/1980"
    MobilePhone = "(123) 456-7890"
    HomePhone = "(098) 765-4321"
    Email = "john.doe@example.com"
    MartialStatus = "Single"
    Race = "Caucasian"
    Ethnicity = "Non-Hispanic"
    MailingStreetAddress = "123 Main St."
    MailingAptSuite = "Apt 4B"
    State = "NY"
    City = "New York"
    ZipCode = "10001"
}



[<ReactComponent>]
let MyAccount (props: AccountData) =
    let (isEditMode, setEditMode) = React.useState false
    let (newText, setNewText) = React.useState ""
    let (currentText, setCurrentText) = React.useState ""  // New state variable for current text

    let handleKeyDown (event: Browser.Types.KeyboardEvent) =
        if event.key = "Enter" && newText.Length > 0 then
            setCurrentText newText  // Update current text when Enter is pressed
            setNewText ""
            setEditMode false

    let handleInputChange value =
        setNewText value

    let handleEditButtonClick () =
        setNewText currentText  // Set the newText to currentText
        setEditMode true

    let handleSaveButtonClick () =
        setCurrentText newText  // Update currentText with newText
        setEditMode false      // Exit edit mode


    let data (label:string) (dataValue:string) =
        let (currentText, setCurrentText) = React.useState dataValue

        Html.div [
            prop.style [style.marginTop 15]
            prop.children [
                Html.div [
                    prop.classes [classes.labelStyle]
                    prop.children [
                        Html.span label
                    ]
                ]
                if isEditMode then
                    Bulma.input.text [
                        prop.value dataValue
                        prop.className classes.inputTag
                        prop.style [style.display.flex ; style.width (length.perc 90)]
                        prop.autoFocus true
                        prop.onChange (fun event -> handleInputChange event)
                        prop.onKeyDown (fun event -> handleKeyDown event)
                        prop.placeholder dataValue
                    ]
                else
                    Html.div [
                        prop.classes [classes.dataStyle]
                        prop.children [
                            Html.span dataValue
                        ]
                    ]
            ]
        ]

    Html.section [
        prop.children [
            Html.div [
                Html.div [
                    prop.classes [classes.textSize]
                    prop.children [
                        Bulma.panelHeading [prop.text "My Account"; prop.style [style.backgroundColor.white]]
                    ]
                ]
                Html.div [
                    prop.style [style.paddingBottom 50]
                    prop.children [
                        Html.div [
                            Html.div [
                                prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.flexStart]
                                prop.children [
                                    Html.div [
                                        prop.classes [classes.titleStyle]
                                        prop.style [style.marginTop 10]
                                        prop.children [
                                            Html.text "General Info"
                                        ]
                                    ]
                                    data "First Name" props.FirstName
                                    data "Middle Name" props.MiddleName
                                    data "Last Name" props.LastName
                                    data "Prefered Language" props.PreferedLanguage
                                    data "Date Of Birth" props.DateOfBirth
                                    data "Mobile Phone" props.MobilePhone
                                    data "Home Phone" props.HomePhone
                                    data "Email" props.Email
                                    data "Marital Status" props.MartialStatus
                                    data "Race" props.Race
                                    data "Ethnicity" props.Ethnicity
                                    data "Mailing Street Address" props.MailingStreetAddress
                                    data "Mailing Apt/Suite" props.MailingAptSuite
                                    data "State" props.State
                                    data "City" props.City
                                    data "Zip Code" props.ZipCode
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            Html.div [
                prop.classes [classes.buttonBottom]
                prop.children [
                    if isEditMode then
                        Bulma.button.button [
                            button.isSmall
                            prop.classes ["is-success"; "is-rounded"; classes.buttonStyling]
                            prop.onClick (fun _ -> handleSaveButtonClick ())
                            prop.children [
                                Html.text "Save"
                            ]
                        ]
                    else
                        Bulma.button.button [
                            button.isSmall
                            prop.onClick (fun _ -> handleEditButtonClick ())
                            prop.classes ["is-primary"; "is-rounded"; classes.buttonStyling]
                            prop.children [
                                Html.text "Edit"
                            ]
                        ]
                ]
            ]
        ]
    ]
