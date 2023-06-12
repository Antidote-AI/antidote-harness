namespace Antidote.Core.V2

open System

module Normalizers =

    module String =
        open System.Text.RegularExpressions

        let toNumberFormat (number:string) =
            let pattern = "[^\\d]"
            let normalizedNewValue = System.Text.RegularExpressions.Regex.Replace(number, pattern, "")
            normalizedNewValue


        let toPhoneFormat (phoneNumber:string) =
            let pattern = "[^\\d]"
            let normalizedNewValue = System.Text.RegularExpressions.Regex.Replace(phoneNumber, pattern, "")

            match normalizedNewValue with
            | a when a.Length < 4 -> a
            | a when a.Length < 7 ->
                sprintf
                    "(%s)-%s"
                    a.[0..2] a.[3..5]
            | a ->
                sprintf
                    "(%s)-%s-%s"
                    a.[0..2] a.[3..5] a.[6..9]

        // TODO: need to handle other country codes by taking coutrycode DU and adding proper prefix...async
        // NOTE LIMITATIONS ON TEXTING w/ OTHER COUNTRIES (Canada has a note on the Azure page...)
        // let toInternationalPhoneFormat (phoneNumber:string) =
        //     let pattern = "[^\\d]"
        //     let phoneOnly = phoneNumber.Replace("+1", "")
        //     let normalizedNewValue = System.Text.RegularExpressions.Regex.Replace(phoneOnly, pattern, "")

        //     match normalizedNewValue with
        //     | a when a.Length <= 10 -> "+1" + a
        //     | a ->
        //         sprintf
        //             "+1%s"
        //             a.[0..9]
