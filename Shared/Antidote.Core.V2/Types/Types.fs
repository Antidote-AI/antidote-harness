namespace Antidote.Core.V2.Types

open System
open System.Collections.Generic
open Feliz.UseDeferred
open FsToolkit.ErrorHandling


[<RequireQualifiedAccess>]
type RegistrationType =
    | Antidote
    | Apple

module RegistrationType =

    let fromIndex (index: int)  =
        match index with
        | 0 -> RegistrationType.Antidote
        | 1 -> RegistrationType.Apple
        | _ -> failwith "Invalid RegistrationType index"

    let toIndex (registrationType: RegistrationType) =
        match registrationType with
        | RegistrationType.Antidote -> 0
        | RegistrationType.Apple -> 1

[<RequireQualifiedAccess>]
type UserNetworkStatus =
    | Offline
    | InCall
    | Online
    | DoNotDisturb

module UserNetworkStatus =

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="index"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (index: int) =
        match index with
        | 0 -> UserNetworkStatus.Offline
        | 1 -> UserNetworkStatus.InCall
        | 2 -> UserNetworkStatus.DoNotDisturb
        | 3 -> UserNetworkStatus.Online
        | _ -> failwith $"Invalid UserNetworkStatus index: $%i{index}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="status"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (status: UserNetworkStatus) =
        match status with
        | UserNetworkStatus.Offline -> 0
        | UserNetworkStatus.InCall -> 1
        | UserNetworkStatus.DoNotDisturb -> 2
        | UserNetworkStatus.Online -> 3

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="status"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toNameOf (status: UserNetworkStatus) =
        match status with
        | UserNetworkStatus.Offline -> nameof UserNetworkStatus.Offline
        | UserNetworkStatus.InCall -> nameof UserNetworkStatus.InCall
        | UserNetworkStatus.DoNotDisturb -> nameof UserNetworkStatus.DoNotDisturb
        | UserNetworkStatus.Online -> nameof UserNetworkStatus.Online

[<RequireQualifiedAccess>]
type UserRole =
    | Provider
    | GlobalAdmin
    | Clinician
    | Patient
    | JailAdministrator
    | Officer
    | None
    | ArmorClinician
    | ClinicOfficeManager

module UserRole =

    /// <summary>
    /// Retrieve the corresponding F# discriminated union value for the given index
    /// </summary>
    /// <param name="index"></param>
    /// <returns>F# value match the provided index</returns>
    let fromIndex (index: int) =
        match index with
        | 0 -> UserRole.Provider
        | 1 -> UserRole.GlobalAdmin
        | 2 -> UserRole.Clinician
        | 3 -> UserRole.Patient
        | 4 -> UserRole.JailAdministrator
        | 5 -> UserRole.Officer
        | 6 -> UserRole.None
        | 7 -> UserRole.ArmorClinician
        | 8 -> UserRole.ClinicOfficeManager
        | _ -> failwith $"Invalid Userrole index: $%i{index}"

    /// <summary>
    /// Retrieve the corresponding index for the given F# discriminated union value
    /// </summary>
    /// <param name="status"></param>
    /// <returns>The index corresponding to the given F# discriminated union value</returns>
    let toIndex (status: UserRole) =
        match status with
        | UserRole.Provider -> 0
        | UserRole.GlobalAdmin -> 1
        | UserRole.Clinician -> 2
        | UserRole.Patient -> 3
        | UserRole.JailAdministrator -> 4
        | UserRole.Officer -> 5
        | UserRole.None -> 6
        | UserRole.ArmorClinician -> 7
        | UserRole.ClinicOfficeManager -> 8

type UserDetails = {
    UserId: AccountId.T
    UserName: string // TODO: Make a type
    AcsId: AcsId.T
    DateOfBirth: DateOfBirth.T
    FirstName: FirstName.T
    LastName: LastName.T
    Title: UserTitle.T
    Biography: Biography.T
    Email: EmailAddress.T
    Phone: PhoneNumber.T
    NetworkStatus: UserNetworkStatus
    Rating: int
    Specialities: string list // TODO: Change type to UserSpeciality.T
    // TODO: Role are not yet available in Server v2
    Roles: string list
    Enabled: bool
    Deleted: bool
}

// TODO: Make this a type
type MedicationValues =
    {
        Name : string
        DosageFormName : string
        NumeratorStrength : string
        DosageUnit : string// -> Make search field
        Route : string //-> Make search field
    }

module MedicationValues =

    type InvalidRequest =
        | InvalidMedicationName of string
        | InvalidDosageFormName of string
        | InvalidNumeratorStrength of string
        | InvalidDosageUnit of string
        | InvalidRoute of string

    let validate medValue =
        result {

            do! Antidote.Core.V2.Validators.String.nonEmpty medValue.Name "Medication Name cannot be empty"

            do! Antidote.Core.V2.Validators.String.nonEmpty medValue.DosageFormName "Dosage Form Name cannot be empty"

            do! Antidote.Core.V2.Validators.String.nonEmpty medValue.NumeratorStrength "Numerator Strength cannot be empty"

            do! Antidote.Core.V2.Validators.String.nonEmpty medValue.DosageUnit "Dosage Unit cannot be empty"

            do! Antidote.Core.V2.Validators.String.nonEmpty medValue.Route "Route cannot be empty"

            return medValue
        }

type AvailabilityInterval = {
    Start: TimeMarker.T
    End: TimeMarker.T
    IsTakingCalls: bool
    IsTakingAppointments: bool
}


module AvailabilityInterval =

    type Values = {
        Start: TimeSpan
        End: TimeSpan
        IsTakingCalls: bool
        IsTakingAppointments: bool
    }

    type InvalidRequest = | InvalidEndTime of string

    // Check that each of the day time slot is valid
    let validate (slot: AvailabilityInterval) : Result<Values, InvalidRequest> =
        let slotStartTime = TimeMarker.value slot.Start
        let slotEndTime = TimeMarker.value slot.End

        result {
            let! _ =
                if slotStartTime >= slotEndTime then
                    InvalidEndTime "End time must be greater than start time" |> Error
                else
                    Ok()

            return {
                Start = slotStartTime
                End = slotEndTime
                IsTakingCalls = slot.IsTakingCalls
                IsTakingAppointments = slot.IsTakingAppointments
            }
        }

type AppointmentInterval = {
    AppointmentStart: TimeMarker.T
    AppointmentEnd: TimeMarker.T
    AppointmentDate: MeetingDate.T
}

// These are tne fable form values on the client, now shared
type FormSlotValues = {
    Start: string
    End: string
    IsTakingCalls: bool
    IsTakingAppointments: bool
}

type FormValues = {
    Sunday: FormSlotValues list
    Monday: FormSlotValues list
    Tuesday: FormSlotValues list
    Wednesday: FormSlotValues list
    Thursday: FormSlotValues list
    Friday: FormSlotValues list
    Saturday: FormSlotValues list
}



type AppointmentFormDetails = {
    FormSpecId: Guid
    FormSpecCode: string
    FormSpecTitle: string
}



type AppointmentDetails = {
    AppointmentEndTime: MeetingDate.T
    AppointmentNotes: MeetingDetails.T
    AppointmentStartTime: MeetingDate.T
    PatientName: FullName.T
    PatientEmail: EmailAddress.T
    PatientPhoneNumber: PhoneNumber.T
    PatientDateOfBirth: DateOfBirth.T
    AppointmentVisitType: VisitType
    AppointmentId: MeetingId.T
    Facility: Facility
    PatientId: AccountId.T
    ProviderId: AccountId.T
    ChatThreadId: ChatThreadId.T
    AppointmentStatus: AppointmentStatus
    AppointmentFormDetails: AppointmentFormDetails option

}

type ExternalAppointmentDetails = {
    ExternalAppointmentId: string
    ClinicianAccountId: AccountId.T
    PatientAccountId: AccountId.T option
    AppointmentStatus: AppointmentStatus
    CheckedIn: bool
    // This should be an enum type that we can store the values,
    //string for now until I have a concrete type
    VisitReason: string
    PatientName: FullName.T
    ExternalMemberId: string
    MobilePhone: PhoneNumber.T option
    HomePhone: PhoneNumber.T option
    AppointmentDate: MeetingDate.T
    PatientDateOfBirth: DateOfBirth.T
    AppointmentDetails: MeetingDetails.T option

    AppointmentFormDetails: AppointmentFormDetails option
}

type AppointmentType =
    | InOffice
    | TeleHealth

[<RequireQualifiedAccess>]
type Appointment =
    | InOfficeAppointment of ExternalAppointmentDetails
    | TeleHealthAppointment of AppointmentDetails

type Appointments =
    | InOfficeAppointments of ExternalAppointmentDetails list
    | TeleHealthAppointments of AppointmentDetails list

type GeneralAssessment =
    {
        Id: Guid option
        AppointmentId: MeetingId.T option
        ChiefComplaint: string
        ClinicianUserId: AccountId.T
        PatientName: string
        Subjective: string
        Objective: string
        Education: string
        Plan: string
        Assessment: string
    }

type ProviderGeneralAssessmentFormWithDetails =
    {
        Id: Guid option
        AppointmentId: MeetingId.T option
        ClinicianUserId: Antidote.Core.V2.Types.AccountId.T
        PatientName: Antidote.Core.V2.Types.FullName.T
        ChiefComplaint: string
        Subjective: string
        Objective: string
        Assessment: string
        Education: string
        Plan: string
        Procedures: list<string>
        Diagnosis: list<string>
        Medications: list<MedicationValues>
        AppointmentDetails: AppointmentDetails option
    }

// HLX - CLEAN THESE INTO APPROPRIATE TYPES

type ScheduleAppointmentDetails =
    {
        SchedulerName: string
        SchedulerEmail: string
        ScheduledVisitType: string
        SchedulerDateOfBirth: DateTime
        SchedulerPhoneNumber: string
        EventDetails: string
        Facility: string
    }

/// A message sent from the server to the client.
[<RequireQualifiedAccess>]
type SRServerMsg =
    | NewUserRegistered of AccountId.T
    | UpdateCallerId of string // AcsUserInfoDto
    | UserStatusUpdated of AccountId.T * UserNetworkStatus
    // | PushedEducationMaterial

/// A message sent from the client to the server.
[<RequireQualifiedAccess>]
type SRClientMsg =
    /// Updates the status of the user (that this connection belongs to) in the network
    | UpdateStatus of UserNetworkStatus
    | ProvideCallerId of string // ProvideCallerIdDto
    // | PushEducationMaterial of string

// type RoleId =
//     | RoleId of int
//     member x.Value = match x with | RoleId token -> token

//     static member TryParse (v:string) =
//         match Int32.TryParse v with
//         | true, v -> Some (RoleId v)
//         | _ -> None

//     static member TryParseResult v =
//         match RoleId.TryParse v with
//         | Some v -> Ok v
//         | None -> Error $"Invalid {typeof<RoleId>.Name} of '{v}'."

// type Role = {
//     Id: RoleId
//     Name: string
//     Descr: string
//     Caps: Cap list
// }

type InitialContext = {
    Route: string
    IsNative: bool
}

type GridCardItem = {
    GridSection: string
    Icon: string
    Value: string
}

type AuthToken =
    | AuthToken of Guid
    member x.Value = match x with | AuthToken token -> token

    static member TryParse (v:string) =
        match Guid.TryParse v with
        | true, v -> Some (AuthToken v)
        | _ -> None


    static member TryParseResult (v:string) =
        match AuthToken.TryParse v with
        | Some v -> Ok v
        | None -> Error $"Invalid {typeof<AuthToken>.Name} of '{v}'."

type ProvisionAcsTokenDeps = {
    ApiAuthToken: AuthToken
    SetAcsTokenCallback: Deferred<AcsAccessToken.T> -> unit
}

type CallButton =
    | Accept
    | HangUp
    | Other

type AppointmentFilter =
    | Future
    | Past


// ABB - TYPES TO BE CREATED

type RiskLevel =
    | Low
    | Moderate
    | High

type CallStatus =
    | Paused
    | Active of TimeSpan
    | Ringing

type PatientDetails = {
    FirstName: string
    LastName: string
    DateOfBirth: DateTime
    PhoneNumber: string
    // FirstName: FirstName.T
    // LastName: LastName.T
    // DateOfBirth: DateOfBirth.T
    // PhoneNumber: PhoneNumber.T
}

type CallQueueItem = {
    Severity: int
    EntryTimeUtc: DateTime
    User: UserDetails
}

type InterventionAnswers = {
    ObservationResponses: IDictionary<string, string>
    DispositionResponse: string
    ReceptivenessResponse: bool
    RecommendationResponse: string
}

type FormSpecDto = {
    Id: Guid
    Code: string
    Version: string
    Title: string
    Abstract: string
    FormSpecJson: string
    Enabled: bool
}

type ClinicianRecommendedCode = {
    ClinicalCode: string
    ClinicalCodeDescription: string
    Timestamp: DateTime
    IsActive: bool
}

module ClinicianRecommendedCode =
    // Todo: move this to types with a DU to describe the codes(?)
    let valuesToClinicianRecommendedCode (code: string, description: string, isActive: bool, timestamp: DateTime) =
        {
            ClinicalCode = code
            ClinicalCodeDescription = description
            Timestamp = timestamp
            IsActive = isActive
        }

type DynamicFormValues = {
    DynamicFormReferenceId: Guid
    PatientAccountId: AccountId.T
    CreatedTimeStamp: DateTime
    FormName: string
    FormDescription: string
    SerializedFormValues: string
    ClinicianNotes: string
    // PATIENT NAME
    PatientName: FullName.T
    ClinicianRecommendedCodes: (ClinicianRecommendedCode Set) option
    FormReferenceId: Guid // JSON Spec Reference ID
    ClinicianReviewed: bool
}

// Clinician type
type Clinic = {
    ClinicId: Guid
    ClinicName: string
    ClinicPhone: PhoneNumber.T
    ClinicFax: PhoneNumber.T
    ClinicAddress: string
}

type ClinicalClinician = {
    FirstName : FirstName.T
    LastName : LastName.T
    EmailAddress: EmailAddress.T
    UserAccountId : AccountId.T
    Biography: string
    // AcsId: AcsId.T // this will be useful if we want to integrate chat between patients and providers
}

type ClinicalOffice = {
    Clinic: Clinic
    Clinicians: ClinicalClinician list
}

// TODO: Need to discuss these types with the team
type ClinicianManagerDetails = {
    AssociatedClinicId : Guid
}

type DoctorAccountDetails = {
    Title: UserTitle.T
    Biography : Biography.T
    // Rating : float // Disabled until ratings are revisited.
    Specialities : UserSpecialities.T
    Clinics: Clinic list
}

type PatientAccountDetails = {
    DateOfBirth : DateOfBirth.T
    ExternalMemberId : string option
    HomePhone : PhoneNumber.T option
    PreferredContact : ContactType
    // Gender : Gender
    PrimaryCarePhysicianId : AccountId.T
    ClinicianFirstName : FirstName.T
    ClinicianLastName : LastName.T
    Clinic : ClinicalOffice
    PlanName : string
    PatientNotes : string
}

type AccountDetails =
    | ClinicianManagerDetails of ClinicianManagerDetails
    | DoctorAccountDetails of DoctorAccountDetails
    | PatientAccountDetails of PatientAccountDetails
    | NoDetails

type Address =
    {
        StreetAddress: string option
        ExtendedAddress1: string option
        ExtendedAddress2: string option
        City: string option
        County: string option
        Zip: string option
        State: string option
        CountryCode: string option
    }

type UserAccount = {
    UserId: AccountId.T
    UserName: string // TODO: Make a type
    AcsId: AcsId.T
    FirstName: FirstName.T
    MiddleName: MiddleName.T option
    LastName: LastName.T
    Email: EmailAddress.T
    Phone: PhoneNumber.T
    Address: Address option
    Gender: Gender
    SpokenLanguage: SpokenLanguage list
    NetworkStatus: UserNetworkStatus
    AdditionalDetails : AccountDetails
    Avatar: ProfileAvatar.T option
    Active: bool
}

type NotificationType =
    | Custom of string
    | AppointmentReminder
    | Register

type DeliveryType =
    | Email of EmailAddress.T
    | SMS of InternationalPhoneNumber.T

type MeetingParticipant = {
    Name: FullName.T
    AcsId: AcsId.T
}

module DefaultRecords =
    let defaultUser : UserAccount =
        {
            UserId = AccountId.create Guid.Empty
            UserName = "Not_Found"
            AcsId = AcsId.create ""
            FirstName = FirstName.create "No"
            MiddleName = Some (MiddleName.create "Details")
            LastName = LastName.create "Found"
            Email = EmailAddress.create "notfound@notfound.com"
            Phone = PhoneNumber.create "00000000000"
            Address = None
            SpokenLanguage = [ SpokenLanguage.English ]
            Gender = Male
            NetworkStatus = UserNetworkStatus.Offline
            AdditionalDetails = AccountDetails.NoDetails
            Avatar = None
            Active = true
        }

type EventScheduleType =
    | Immediate
    | Future
    | NotSelectedYet

type ScheduleEventType =
    | ScheduleInOffice
    | ScheduleTeleHealth
    | NotSelectedYet

// Deprecate this after the appointment
type EventNotificationType =
    | Email
    | SMS
    | NotSelectedYet

type EffectDeliveryType =
    | SMS
    | Email

type CampaignScheduleInterval =
    | Daily
    | Weekly
    | Monthly
    | Annually

type CampaignTemplate =
    {
        // Name: string
        ScheduledStartDate: DateTimeOffset
        ScheduledStartTime: TimeSpan
        ScheduledRepeatInterval: CampaignScheduleInterval
        FormSpecId: Guid
        FormSpecTitle: string
    }

type ImmediateCallProps = {
    PatientAccountId: AccountId.T
    InitiatorAccountId: AccountId.T
    RoomId: Guid
    ChatThreadId: string
    DisplayName: string
    FormSpecId: Guid
    FormSpecTitle: string
    EventId: Guid
}

type ImmediateHandoutProps = {
    PatientAccountId: AccountId.T
    InitiatorAccountId: AccountId.T
    FormSpecId: Guid
    FormSpecTitle: string
    EventId: string
}

type AssessmentType =
    | PaperToDigital
    | OverThePhone
    | InPerson
    | Scheduler
    // | Deliver

type InitialSchedulerValues = {
    InitialScheduleEventType: ScheduleEventType
    InitialEventReason: FormSpecDto
    InitialAssessmentType: AssessmentType
    InitialFormSpecId: Guid
    InitialFormSpecTitle: string
}

type AppointmentScheduleProps = {
    CurrentUser: UserAccount
    SelectedUser: UserAccount
    InitialScheduleProps: InitialSchedulerValues option
}

type ScheduleEventResult =
    | Future
    | ImmediateCall of ImmediateCallProps
    | ImmediateHandoutMode of ImmediateHandoutProps
    | ImmediateForm of ImmediateHandoutProps

type DashboardFormValue = {
    Id: Guid
    DynamicFormSpecId: Guid
    AppointmentId: string
    PatientAccountId: Guid
    ClinicianAccountId: Guid
    CreatedTimeStamp: DateTimeOffset
    FormValuesJson: string
    WarningFlag: bool
    ResultSeverity: string
    ClinicianValidated: bool
}





// TYPES FROM HERE
[<RequireQualifiedAccess>]
type Filter =
    | Today
    | Tomorrow
    | Upcoming
    // | Anytime
    | Completed
    | All

// this needs more details and a record type as it moved to a relational table outside tasks
type Collection =
    | Inbox
    | Today
    | Next
    | Someday
    | Done

type TaskComment =
    {
        CommentorId: AccountId.T
        Comment: string
        CommentDate: DateTimeOffset
    }

type TaskParticipant =
    {
        AccountId: AccountId.T
        ParticipantName: FullName.T
    }


type Task = {
    Id: Guid option
    CreatedById: AccountId.T option
    Title: string
    Description: string
    SystemEvent: SystemEvent
    Status: TaskStatus
    Tags: TaskTag list
    Flags: TaskFlag list
    IsStarred: bool
    // get the offset based on the time stamp sent for created
    CreatedOn: DateTimeOffset
    DueDate: DateTimeOffset
    UpdatedOn: DateTimeOffset
    CompletedDate: DateTimeOffset option
    // NYI
    Collection: string
    Comments: TaskComment list
    Participants: TaskParticipant list
}
