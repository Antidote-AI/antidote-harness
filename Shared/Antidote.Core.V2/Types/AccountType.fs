namespace Antidote.Core.V2.Types

open Antidote.Core.V2
open FsToolkit.ErrorHandling

[<RequireQualifiedAccess>]
module AccountType =

    [<RequireQualifiedAccess>]
    type AccountType =
        | Patient
        | Clinician
        | PoliceOfficer
        | ClinicianManager
        | CareCoordinator
        | Admin
        | Maintenance

    let fromIndex (index: int) =
        match index with
        | 0 -> AccountType.Patient
        | 1 -> AccountType.Clinician
        | 2 -> AccountType.PoliceOfficer
        | 3 -> AccountType.ClinicianManager
        | 4 -> AccountType.CareCoordinator
        | 5 -> AccountType.Admin
        | 6 -> AccountType.Maintenance
        | _ -> failwith "Invalid value for AccountType type"

    let validate (index: int) =
        match index with
        | 0
        | 1
        | 2
        | 3
        | 4
        | 5
        | 6 -> Ok ()
        | _ -> Error "Invalid value for AccountType index"

    let toIndex (accountType: AccountType) =
        match accountType with
        | AccountType.Patient -> 0
        | AccountType.Clinician -> 1
        | AccountType.PoliceOfficer -> 2
        | AccountType.ClinicianManager -> 3
        | AccountType.CareCoordinator -> 4
        | AccountType.Admin -> 5
        | AccountType.Maintenance -> 6

    let tryParse (accountTypeInt: int) =
        result
            {
                do! Validators.Int.isNonNegative accountTypeInt "AccountType cannot be negative"
                do! validate accountTypeInt
                return (fromIndex accountTypeInt)
            }
