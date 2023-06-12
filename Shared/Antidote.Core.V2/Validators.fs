namespace Antidote.Core.V2

open System

module Validators =

    module Int =
        let isLessThan (value: int) (max: int) (message: string) =
            if value > max then
                Error message
            else
                Ok ()

        let isGreaterThan (value: int) (min: int) (message: string) =
            if value < min then
                Error message
            else
                Ok ()

        let isNonNegative (value: int) (message: string) =
            if value < 0 then
                Error message
            else
                Ok ()

        let isInRange (value: int) (min: int) (max: int) (message: string) =
            if value < min || value > max then
                Error message
            else
                Ok ()

    module String =
        open System.Text.RegularExpressions

        let nonEmpty (text: string) (errorMessage: string) =
            if String.IsNullOrEmpty text then
                Error errorMessage
            else
                Ok()

        let isLength (text: string) (length: int) (errorMessage: string) =
            if text.Length = length then Ok() else  Error errorMessage

        let maxLength (text: string) (maxLength: int) (errorMessage: string) =
            if text.Length > maxLength then Error errorMessage else Ok()

        let contains (text: string) (substring: string) (errorMessage: string) =
            if text.Contains substring then Ok() else Error errorMessage

        let startsWith (text: string) (prefix: string) (errorMessage: string) =
            if text.StartsWith prefix then Ok() else Error errorMessage

        let isMultiPart (text: string) (minPartCount: int) =
            let parts = text.Split(" ")

            let hasEmptyPart =
                parts
                |> Array.exists String.IsNullOrWhiteSpace

            if hasEmptyPart then
                Error "Should not contain empty parts"
            else
                if parts.Length < minPartCount then
                    Error "Not enough parts supplied"
                else
                    Ok()

        let isValidTenantDetail (text: string) =
            let isValidFormat =
                Regex.IsMatch(text, "^[a-z0-9-_.]+$")

            if isValidFormat then
                Ok()
            else
                Error "Tenant Detail is not in the correct format"

        let isPostalCode (text: string) =
            let isValidFormat =
                Regex.IsMatch(text, "^[0-9]{5}(?:-[0-9]{4})?$")

            if isValidFormat then
                Ok()
            else
                Error "Postal code is not in the correct format"

        let isCountryCode (text: string) =
            let isValidFormat =
                Regex.IsMatch(text, "^[A-Z]{3}?$")

            if isValidFormat then
                Ok()
            else
                Error "Country code is not in the correct format"

        let isSocialSecurityNumber (text: string) =
            let isValidFormat =
                Regex.IsMatch(text, "^(?!000|666)[0-8][0-9]{2}-(?!00)[0-9]{2}-(?!0000)[0-9]{4}$")

            if isValidFormat then
                Ok()
            else
                Error "Social Security number is not in the correct format"

        let isValidUSPhoneNumber (text: string) =
            let isValidFormat =
                Regex.IsMatch(text, """\(\d{3}\)-\d{3}-\d{4}""")

            if isValidFormat
            then Ok()
            else Error "Phone number is not in the correct format: (000)-000-0000"

        // let isValidUSMobilePhoneNumber (text: string) =
        //     let isValidFormat =
        //         Regex.IsMatch(text, """+1\d{10}""")

        //     if isValidFormat
        //     then Ok()
        //     else Error "Phone number is not in the correct format: (000)-000-0000"

    module DateTime =

        let validFormat (text: string) (errorMessage: string) =
            match DateTime.TryParse text with
            | true, date -> Ok date
            | false, _ -> Error errorMessage

        let greaterThan
            (dateTime: DateTime)
            (minDateTime: DateTime)
            (errorMessage: string)
            =
            if dateTime < minDateTime then Error errorMessage else Ok()

        let dateNotInPast
            (dateTime: DateTime)
            (errorMessage: string)
            =
            if dateTime.Date < DateTime.UtcNow.Date  then Error errorMessage else Ok()

        let lessThan
            (dateTime: DateTime)
            (maxDateTime: DateTime)
            (errorMessage: string)
            =
            if dateTime > maxDateTime then Error errorMessage else Ok()

        let areSameDate
            (dateTime: DateTime)
            (maxDateTime: DateTime)
            (errorMessage: string)
            =
            if dateTime.Date = maxDateTime.Date then Ok() else Error errorMessage

    module DateTimeOffset =

        let validFormat (text: string) (errorMessage: string) =
            match DateTimeOffset.TryParse text with
            | true, date -> Ok date
            | false, _ -> Error errorMessage

        let greaterThan
            (dateTime: DateTimeOffset)
            (minDateTime: DateTimeOffset)
            (errorMessage: string)
            =
            if dateTime < minDateTime then Error errorMessage else Ok()

        let dateNotInPast
            (dateTime: DateTimeOffset)
            (errorMessage: string)
            =
            if dateTime.Date < DateTimeOffset.UtcNow.AddHours(-12).Date then Error errorMessage else Ok()

        let lessThan
            (dateTime: DateTimeOffset)
            (maxDateTime: DateTimeOffset)
            (errorMessage: string)
            =
            if dateTime > maxDateTime then Error errorMessage else Ok()

        let areSameDate
            (dateTime: DateTimeOffset)
            (maxDateTime: DateTimeOffset)
            (errorMessage: string)
            =
            if dateTime.Date = maxDateTime.Date then Ok() else Error errorMessage

    module DateOnly =

        let validFormat (text: string) (errorMessage: string) =
            match DateOnly.TryParse text with
            | true, date -> Ok date
            | false, _ -> Error errorMessage

        let greaterThan
            (date: DateOnly)
            (minDate: DateOnly)
            (errorMessage: string)
            =
            if date < minDate then Error errorMessage else Ok()

        let lessThan
            (date: DateOnly)
            (maxDate: DateOnly)
            (errorMessage: string)
            =
            if date > maxDate then Error errorMessage else Ok()

        let areSameDate
            (date: DateOnly)
            (maxDate: DateOnly)
            (errorMessage: string)
            =
            if date = maxDate then Ok() else Error errorMessage

    module TimeSpan =

        let validFormat (text: string) (errorMessage: string) =
            match TimeSpan.TryParse text with
            | true, ts -> Ok ts
            | false, _ -> Error errorMessage

        let greaterThan
            (time: TimeSpan)
            (minDateTime: TimeSpan)
            (errorMessage: string)
            =
            if time < minDateTime then Error errorMessage else Ok()

        let lessThan
            (time: TimeSpan)
            (maxDateTime: TimeSpan)
            (errorMessage: string)
            =
            if time > maxDateTime then Error errorMessage else Ok()

        let doesNotExceedDay
            (time: TimeSpan)
            (errorMessage: string)
            =
            if time.TotalMinutes > 1440 then Error errorMessage else Ok()

        let hasMinimumClockTime
            (time: TimeSpan)
            (errorMessage: string)
            =
            if time.TotalMinutes < 1 then Error errorMessage else Ok()

    module Guid =

        let validFormat (text: string) (errorMessage: string) =
            match Guid.TryParse text with
            | true, guid -> Ok guid
            | false, _ -> Error errorMessage

        let nonEmpty (text: string) (errorMessage: string) =
            if (Guid.Parse text = Guid.Empty)
            then Error errorMessage
            else Ok ()

    module Array =

        let nonEmpty (array: 'T []) (errorMessage: string) =
            if array.Length = 0 then Error errorMessage else Ok()

        let maxLength (array: 'T []) (maxLength: int) (errorMessage: string) =
            if array.Length > maxLength then Error errorMessage else Ok()
