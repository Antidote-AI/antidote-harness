module Validation

let listOfFields (currentValues: 'T list) (validateFunc: 'T -> Result<'Values, 'Error>) =
    currentValues
    |> List.mapi (fun rank value -> (rank, validateFunc value))
    |> List.partitionMap (fun (rank, state) ->
        match state with
        | Ok valid -> Choice1Of2 valid
        | Error errored -> Choice2Of2(rank, errored)
    )

module ListOfFields =

    let mapError (invalidValues: list<int * 'FieldError>) (mapper: list<int * 'FieldError> -> 'Error) =
        if invalidValues.Length = 0 then
            Ok()
        else
            invalidValues |> mapper |> Error
