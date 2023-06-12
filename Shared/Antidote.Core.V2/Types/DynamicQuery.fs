module Antidote.Core.V2.DynamicQuery

open System

type Field =
    | Fullname
    | FirstName
    | LastName
    | EmailAddress
    | PhoneNumber
    | All
    // WIP
    // | AccountId
    // | TenantId
    member x.toPredicate =
        match x with
        | All -> "all", "LOWER(\"FirstName\" || '~' || \"LastName\" || '~' || \"Email\" || '~' || \"MobilePhone\") LIKE '%{{all}}%'"
        | Fullname -> "fullname", "LOWER(\"FirstName\" || \"LastName\") LIKE '%{{fullname}}%'"
        | FirstName -> "firstname", "LOWER(\"FirstName\") LIKE '%{{firstname}}%'"
        | LastName -> "lastname", "LOWER(\"LastName\") LIKE '%{{lastname}}%'"
        | EmailAddress -> "email", "LOWER(\"Email\") LIKE '%{{email}}%'"
        | PhoneNumber -> "phonenumber", " LOWER(\"MobilePhone\") LIKE '{{phonenumber}}%'"
        // WIP
        // | EmailAddress -> "email", "\"Email\" LIKE '%{{email}}%'"
        // | PhoneNumber -> "phonenumber", " \"MobilePhone\" LIKE '{{phonenumber}}%'"

type FieldFilter = Field * string

type FilterOperation =
    | And of FieldFilter list
    | Or of FieldFilter list
    member x.toString =
        match x with
        | And _ -> "AND"
        | Or _ -> "OR"

type ConditionOperation =
    | And of Condition
    | Or of Condition
    member x.toString =
        match x with
        | And _ -> "AND"
        | Or _ -> "OR"

and Condition =
    {
        FilterOperation: FilterOperation
        ConditionOperation: ConditionOperation option
    }

let rec generateWhereClause (condition: Condition) =
    let filterOperationString =
        match condition.FilterOperation with
        | FilterOperation.And filters ->
            filters
            |> List.map ( fun (field, value) ->
                let fieldname, pred = field.toPredicate
                pred.Replace("{{" + fieldname + "}}", value.ToLower())
            ) |> String.concat " AND "
        | FilterOperation.Or filters ->
            filters
            |> List.map ( fun (field, value) ->
                let fieldname, pred = field.toPredicate
                pred.Replace("{{" + fieldname + "}}", value.ToLower())
            ) |> String.concat " OR "

    printfn $"filterOperationString: {filterOperationString}"
    match condition.ConditionOperation with
    | Some innerCondition ->
        match innerCondition with
        | And cc ->
            let innerConditionString = generateWhereClause cc
            $"({filterOperationString}) {innerCondition.toString} ({innerConditionString})"
        | Or cc ->
            let innerConditionString = generateWhereClause cc
            $"({filterOperationString}) {innerCondition.toString} ({innerConditionString})"
    | None -> filterOperationString

let testCondition1 =
    {
        FilterOperation =
            FilterOperation.And
                [
                    FieldFilter (Field.FirstName, "patient")
                ]
        ConditionOperation = None
    }

let testNameQuery =
    generateWhereClause testCondition1
