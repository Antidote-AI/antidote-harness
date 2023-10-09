module Healix.Components.EditableTag

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

let private classes : CssModules.Components.EditableTag = import "default" "./EditableTag.module.scss"



[<ReactComponent>]
let EditableTag () =
    let (tags, setTags) = React.useState List.empty  // Initial state is an empty array
    let (isEditing, setEditing) = React.useState false
    let (isDeletable, setDeletable) = React.useState false
    let (newTagText, setNewTagText) = React.useState ""

    let handleKeyDown (event: Browser.Types.KeyboardEvent) =
        if event.key = "Enter" && newTagText.Length > 0 then
            setTags (newTagText :: tags)  // Add the new tag to the array
            setNewTagText ""  // Clear the new tag text
            setEditing false  // Exit editing mode

    let handleInputChange value =
        setNewTagText value

    let handleTagButtonClick () =
        setEditing true

    let handleEditButtonClick () =
        setDeletable true

    let handleDeleteTag tagText =
        setTags (tags |> List.filter (fun tag -> tag <> tagText))

    Html.div [
        prop.style [style.display.flex; style.alignItems.center]
        prop.children [
            Bulma.icon [
                Bulma.icon.isSmall
                prop.style [style.marginRight 5]
                prop.onClick (fun _ -> handleTagButtonClick ())
                prop.children [
                    Icon [
                        icon.icon mdi.addCircle
                        icon.color "#2868bd"
                        icon.width 18
                    ]
                ]
            ]
            Html.div [
                prop.style [style.margin 30; style.color.gray]
                prop.onClick (fun _ -> handleEditButtonClick ())
                prop.children [
                    Html.span "Edit"
                ]
            ]
            if isEditing then
                Html.input [
                    prop.style [
                        style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px");
                        style.width (length.perc 5)
                        style.borderRadius 12
                        style.fontSize 12
                    ]
                    prop.defaultValue newTagText
                    prop.className classes.inputTag
                    prop.autoFocus true
                    prop.onChange handleInputChange
                    prop.onKeyDown (fun event -> handleKeyDown event)
                ]
            Html.div [
                prop.children (
                    tags
                    |> List.map (fun tagText ->
                        Html.div [  // Wrap each tag in a div
                            prop.style [style.display.flex; style.alignItems.center]
                            prop.children [
                                Bulma.tag [
                                    Bulma.color.isWhite
                                    Bulma.tag.isRounded

                                    prop.style [style.marginRight 3; style.custom("boxShadow", "rgba(0, 0, 0, 0.16) 0px 1px 4px")]
                                    prop.children [
                                        if isDeletable then
                                            Html.div [
                                                prop.text tagText
                                            ]
                                            Bulma.icon [  // Add a delete icon to each tag
                                                Bulma.icon.isSmall
                                                prop.onClick (fun _ -> handleDeleteTag tagText)  // Wire up the delete handler
                                                prop.children [
                                                    Icon [
                                                        icon.icon mdi.closeCircle
                                                        icon.color "red"
                                                        icon.width 18
                                                    ]
                                                ]
                                            ]
                                            else
                                                Html.div [
                                                    prop.text tagText
                                            ]
                                    ]
                                ]

                            ]
                        ])
                )
            ]
        ]
    ]
