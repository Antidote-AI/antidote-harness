module Healix.Components.Table


open Feliz.Bulma
open Feliz.UseElmish
open Elmish
open System
open Feliz.Iconify
open type Offline.Exports
open Glutinum.IconifyIcons.Mdi

open Feliz
open Fable.Core.JsInterop
//open Antidote.Core.V2.Utils
//open Antidote.Core.V2.Domain
open FSharp.Data

emitJsStatement () "import React from \"react\""

// type Claims = CsvProvider<".././Csv/claims-test.csv">

// let data = Claims.Load(".././Csv/claims-test.csv").Rows

// type ClaimsData = {
//     Claim_Num : int
//     CLM_LINE_NBR : int
//     SERVICE_CODE : string option
//     REVNU_CD : string option
//     DIAG_CD : string option
//     DRG_CD : string option
//     SETTING : string
//     LINE_SETTING : string
//     GROUP_NUMBER : string
//     GROUP_NAME : string
//     ID_NUMBER : int
//     INMATE_LAST_NAME : string
//     INMATE_FIRST_NAME : string
//     BRTH_DT : DateTime
//     GNDR_CD : string
//     C_FAC_PROF : string
//     PROVIDER_NAME : string
//     NDC : string option
//     DRUG_NAME : string option
//     DATE_INCURRED : DateTime
//     DATE_LAST_SERVICE : DateTime
//     TOTAL_CHARGES : float
//     TOTAL_PAID : float
//     Payment_Year : int
// }

// let toClaimsData (row: CsvFile.Row) : ClaimsData =
//     {
//         Claim_Num = row.Claim_Num
//         CLM_LINE_NBR = row.CLM_LINE_NBR
//         SERVICE_CODE = row.SERVICE_CODE
//         REVNU_CD = row.REVNU_CD
//         DIAG_CD = row.DIAG_CD
//         DRG_CD = row.DRG_CD
//         SETTING = row.SETTING
//         LINE_SETTING = row.LINE_SETTING
//         GROUP_NUMBER = row.GROUP_NUMBER
//         GROUP_NAME = row.GROUP_NAME
//         ID_NUMBER = row.ID_NUMBER
//         INMATE_LAST_NAME = row.INMATE_LAST_NAME
//         INMATE_FIRST_NAME = row.INMATE_FIRST_NAME
//         BRTH_DT = row.BRTH_DT
//         GNDR_CD = row.GNDR_CD
//         C_FAC_PROF = row.C_FAC_PROF
//         PROVIDER_NAME = row.PROVIDER_NAME
//         NDC = row.NDC
//         DRUG_NAME = row.DRUG_NAME
//         DATE_INCURRED = row.DATE_INCURRED
//         DATE_LAST_SERVICE = row.DATE_LAST_SERVICE
//         TOTAL_CHARGES = row.TOTAL_CHARGES
//         TOTAL_PAID = row.TOTAL_PAID
//         Payment_Year = row.Payment_Year
//     }


// type TableRowCellImageProps = {|
//     ImageSrc: string
// |}

// [<ReactComponent>]
// let TableRowCellImage (props: TableRowCellImageProps)  =
//     Html.td [
//         prop.className "is-image-cell"
//         prop.children [
//             Html.div [
//                 prop.className "image"
//                 prop.children [
//                     Html.img [
//                         prop.src props.ImageSrc
//                         prop.className "is-rounded"
//                     ]
//                 ]
//             ]
//         ]
//     ]

// type TableRowCellProgressProps = {|
//     Max: int
//     Value: int
// |}

// [<ReactComponent>]
// let TableRowCellProgress (props: TableRowCellProgressProps) =
//     Html.td [
//         prop.className "is-progress-cell"
//         prop.children [
//             Html.progress [
//                 prop.classes [ "progress"; "is-small"; "is-primary" ]
//                 prop.max props.Max
//                 prop.value props.Value
//                 prop.text (int props.Value)
//             ]
//         ]
//     ]


// type HeaderCell = {
//     Label: string
//     IsCurrentSortAcsending: bool
//     IsCurrentSort: bool
//     IsSortable: bool
//     SortCallback: unit -> unit
// }

// type TextCell = {
//     HeaderCell: HeaderCell
//     Label: string
// }
// type TableRowType<'T> =
//     | HeaderCell of HeaderCell
//     | FooterCell of string
//     | ImageCell of 'T * string
//     | TextCell of 'T * TextCell
//     | Email of 'T * string
//     | DateCell of 'T * DateTime
//     | ProgressCell of 'T * int * int // max, value
//     | ActionsCell of 'T * ReactElement
//     | Custom of 'T * ReactElement

// type TableProps<'T> = {|
//     Data: 'T list
//     OnSelect: 'T -> unit
// |}

// [<ReactComponent>]
// let Table (props: TableProps<ClaimsData>) =
//     Html.table [
//         prop.children [
//             Html.thead [
//                 prop.children [
//                     TableRow {|
//                         Row = [
//                             HeaderCell {|
//                                 Label = "Claim Number"
//                                 IsCurrentSortAcsending = false
//                                 IsCurrentSort = false
//                                 IsSortable = true
//                                 SortCallback = fun _ -> ()
//                             |}
//                             // Add other header cells here...
//                         ]
//                         OnSelect = fun _ -> ()
//                     |}
//                 ]
//             ]
//             Html.tbody [
//                 prop.children (
//                     props.Data
//                     |> List.map (fun claim ->
//                         TableRow {|
//                             Row = [
//                                 TextCell (claim, {|
//                                     HeaderCell = {|
//                                         Label = "Claim Number"
//                                         IsCurrentSortAcsending = false
//                                         IsCurrentSort = false
//                                         IsSortable = true
//                                         SortCallback = fun _ -> ()
//                                     |}
//                                     Label = claim.Claim_Num.ToString()
//                                 |})
//                                 // Add other cells here...
//                             ]
//                             OnSelect = props.OnSelect
//                         |}
//                     )
//                 )
//             ]
//         ]
//     ]


// let claimsData = Claims.Load(".././Csv/claims-test.csv").Rows |> List.map toClaimsData

// // Define a callback function to handle row selection
// let handleRowSelect (selectedClaim: ClaimsData) =
//     printfn "Selected claim: %A" selectedClaim
