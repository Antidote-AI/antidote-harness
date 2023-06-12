namespace Antidote.Core.V2.Types

open FsToolkit.ErrorHandling
open Antidote.Core.V2

module ResourceType =

    type ResourceType =
        | App
        | App_Route
        | Api
        | Api_Route

    let fromString resourceTypeString =
        match resourceTypeString with
        | "App" -> ResourceType.App
        | "App_Route" -> ResourceType.App_Route
        | "Api" -> ResourceType.Api
        | "Api_Route" -> ResourceType.Api_Route
        | _ -> failwith "Not a valid resource type identifier."

[<RequireQualifiedAccess>]
module Capability =

    module ApiCapability =

        // module_capability
        type ApiCapability =
            // APPOINTMENT
            | Appointment_ScheduleAvailability
            | Appointment_GetProviderAvailability
            | Appointment_GetAvailableAppointmentsByDateAndProviderUserId
            | Appointment_ScheduleAppointmentWithProvider
            | Appointment_GetAppointmentsForUserId
            | Appointment_ImportExternalAppointment
            | Appointment_UpdateExternalAppointmentWithRegisteredUser
            | Appointment_GetExternalAppointmentsForAccountId
            // Auth
            | Auth_RegisterPatient
            | Auth_Login
            | Auth_RegisterPatientWithToken
            | Auth_RefreshToken
            | Auth_SignOut
            | Auth_ResetPassword
            // AzureCommunications
            | AzureCommunications_CreateToken
            | AzureCommunications_DeliverNotification
            // CallQueue
            | CallQueue_JoinCallQueue
            | CallQueue_LeaveCallQueue
            // Clinician
            | Clinician_Create
            | Clinician_GetClinicians
            // ClinicianManager
            | ClinicianManager_Create
            // Communication
            | Communication_SendEmail
            | Communication_SendCampaign
            //
            // TODO:
            // | Communication_SendSms
            //
            // Dashboard
            | Dashboard_GetValues
            // DeepLink
            | DeepLink_Create
            | DeepLink_Read
            | DeepLink_Consume
            // Form
            | Form_ReadFormSpec
            | Form_ReadAllFormSpecs
            | Form_SaveFormValues
            | Form_ReadFormValues
            | Form_DynamicFormReview
            // Patient
            | Patient_Create
            | Patient_GetPatients
            // PatientInteraction
            | PatientInteraction_CaptureConsentForm
            | PatientInteraction_CaptureEncounterForm
            | PatientInteraction_UpdateIndividualDetails
            | PatientInteraction_CreatePatientRegistrationToken
            | PatientInteraction_LogCallOutcome
            | PatientInteraction_CaptureGeneralAssessmentForm
            | PatientInteraction_GetGeneralAssessmentForms
            // Unauthenticated
            | Unauthenticated_UnauthenticatedRead
            | Unauthenticated_UnauthenticatedReadFormSpec
            | Unauthenticated_UnauthenticatedSaveFormValues
            // User
            | User_GetUserAccount
            | User_UpdatePassword
            // Validate
            | Validate_Verify

        let fromString apiCapability =
            match apiCapability with
            // APPOINTMENT
            | "Appointment_ScheduleAvailability" -> Appointment_ScheduleAvailability
            | "Appointment_GetProviderAvailability" -> Appointment_GetProviderAvailability
            | "Appointment_GetAvailableAppointmentsByDateAndProviderUserId" -> Appointment_GetAvailableAppointmentsByDateAndProviderUserId
            | "Appointment_ScheduleAppointmentWithProvider" -> Appointment_ScheduleAppointmentWithProvider
            | "Appointment_GetAppointmentsForUserId" -> Appointment_GetAppointmentsForUserId
            | "Appointment_ImportExternalAppointment" -> Appointment_ImportExternalAppointment
            | "Appointment_UpdateExternalAppointmentWithRegisteredUser" -> Appointment_UpdateExternalAppointmentWithRegisteredUser
            | "Appointment_GetExternalAppointmentsForAccountId" -> Appointment_GetExternalAppointmentsForAccountId
            // Auth
            | "Auth_RegisterPatient" -> Auth_RegisterPatient
            | "Auth_Login" -> Auth_Login
            | "Auth_RegisterPatientWithToken" -> Auth_RegisterPatientWithToken
            | "Auth_RefreshToken" -> Auth_RefreshToken
            | "Auth_SignOut" -> Auth_SignOut
            | "Auth_ResetPassword" -> Auth_ResetPassword
            // AzureCommunications
            | "AzureCommunications_CreateToken" -> AzureCommunications_CreateToken
            | "AzureCommunications_DeliverNotification" -> AzureCommunications_DeliverNotification
            // CallQueue
            | "CallQueue_JoinCallQueue" -> CallQueue_JoinCallQueue
            | "CallQueue_LeaveCallQueue" -> CallQueue_LeaveCallQueue
            // Clinician
            | "Clinician_Create" -> Clinician_Create
            | "Clinician_GetClinicians" -> Clinician_GetClinicians
            // ClinicianManager
            | "ClinicianManager_Create" -> ClinicianManager_Create
            // Communication
            | "Communication_SendEmail" -> Communication_SendEmail
            | "Communication_SendCampaign" -> Communication_SendCampaign
            //
            // TODO:
            // | Communication_SendSms
            //
            // Dashboard
            | "Dashboard_GetValues" -> Dashboard_GetValues
            // DeepLink
            | "DeepLink_Create" -> DeepLink_Create
            | "DeepLink_Read" -> DeepLink_Read
            | "DeepLink_Consume" -> DeepLink_Consume
            // Form
            | "Form_ReadFormSpec" -> Form_ReadFormSpec
            | "Form_ReadAllFormSpecs" -> Form_ReadAllFormSpecs
            | "Form_SaveFormValues" -> Form_SaveFormValues
            | "Form_ReadFormValues" -> Form_ReadFormValues
            | "Form_DynamicFormReview" -> Form_DynamicFormReview
            // Patient
            | "Patient_Create" -> Patient_Create
            | "Patient_GetPatients" -> Patient_GetPatients
            // PatientInteraction
            | "PatientInteraction_CaptureConsentForm" -> PatientInteraction_CaptureConsentForm
            | "PatientInteraction_CaptureEncounterForm" -> PatientInteraction_CaptureEncounterForm
            | "PatientInteraction_UpdateIndividualDetails" -> PatientInteraction_UpdateIndividualDetails
            | "PatientInteraction_CreatePatientRegistrationToken" -> PatientInteraction_CreatePatientRegistrationToken
            | "PatientInteraction_LogCallOutcome" -> PatientInteraction_LogCallOutcome
            | "PatientInteraction_CaptureGeneralAssessmentForm" -> PatientInteraction_CaptureGeneralAssessmentForm
            | "PatientInteraction_GetGeneralAssessmentForms" -> PatientInteraction_GetGeneralAssessmentForms
            // Unauthenticated
            | "Unauthenticated_UnauthenticatedRead" -> Unauthenticated_UnauthenticatedRead
            | "Unauthenticated_UnauthenticatedReadFormSpec" -> Unauthenticated_UnauthenticatedReadFormSpec
            | "Unauthenticated_UnauthenticatedSaveFormValues" -> Unauthenticated_UnauthenticatedSaveFormValues
            // User
            | "User_GetUserAccount" -> User_GetUserAccount
            | "User_UpdatePassword" -> User_UpdatePassword
            // Validate
            | "Validate_Verify" -> Validate_Verify
            | _ -> failwith "Invalid Api Capability"

    module ApiRouteCapability =

        type ApiRouteCapability =
            | Appointment
            | Auth
            | AzureCommunications
            | CallQueue
            | Clinician
            | ClinicianManager
            | Communication
            | Dashboard
            | DeepLink
            | Form
            | Patient
            | PatientInteraction
            | Unauthenticated
            | User
            | Validate

        let fromString apiRouteCapability =
            match apiRouteCapability with
            | "Appointment" -> Appointment
            | "Auth" -> Auth
            | "AzureCommunications" -> AzureCommunications
            | "CallQueue" -> CallQueue
            | "Clinician"-> Clinician
            | "ClinicianManager" -> ClinicianManager
            | "Communication" -> Communication
            | "Dashboard" -> Dashboard
            | "DeepLink" -> DeepLink
            | "Form" -> Form
            | "Patient" -> Patient
            | "PatientInteraction" -> PatientInteraction
            | "Unauthenticated" -> Unauthenticated
            | "User" -> User
            | "Validate" -> Validate
            | _ -> failwith "Invalid Api Route Capability"


    module AppCapability =

        type AppCapability =
            // Navigation Menu items
            | NavigationMenu_UpdateStatus
            | NavigationMenu_Home
            | NavigationMenu_Availability
            | NavigationMenu_Tasks
            | NavigationMenu_VisitHistory
            | NavigationMenu_ArmorClinicalPathway
            | NavigationMenu_Dashboard
            | NavigationMenu_Admin
            | NavigationMenu_Members
            | NavigationMenu_Campaign
            | NavigationMenu_DeleteAccount
            | NavigationMenu_ChangePassword
            | NavigationMenu_About
            | NavigationMenu_SignOut
            // Component Features
            // Home
            | Home_TasksComponent
            | Home_TeleHealthAppointments
            | Home_OfficeAppointments
            // Availability
            | Availability_ViewClinicianAvailability
            | Availability_ScheduleClinicianAvailability
            // Members
            | Members_CreateNewPatient
            | Members_ViewPatientMemberDetails
            | Members_ViewPatientMembers
            | Members_ViewClinicianMemberDetails
            | Members_ViewClinicianMembers
            | Members_ViewClinicianManagerMemberDetails
            | Members_ViewClinicianManagerMembers
            | Members_DigitizeAssessment
            | Members_PhoneAssessment
            | Members_InPersonAssessment
            | Members_ScheduleMemberForOfficeAppointment
            | Members_ScheduleMemberForTelehealthAppointment
            // VisitHistory
            | VisitHistory_ViewVisitHistory
            | VisitHistory_ViewResult
            | VisitHistory_ViewClinicalNotes
            | VisitHistory_ViewRecommendedCodes
            | VisitHistory_ViewForm
            | VisitHistory_DownloadResultsPDF
            | VisitHistory_SubmitClinicalReview
            // Campaign
            | Campaign_CreateCampaign
            | Campaign_SendSmsCampaign
            | Campaign_SendEmailCampaign
            // FormSelector (?) - this should be based off a linking table to determine who has access to what values
            // CallingActivity
            | AzureCommunications_CallWithChat
            | AzureCommunications_Chat
            | AzureCommunications_Call
            | AzureCommunications_FormOrchestrator
            // Tasks
            // | ViewTasks
            // | SaveTask
            // | DeleteTask
            // | CompleteTask
            // | CreateTask
            // ArmorClinicalPathway
            // Dashboard

        let fromString appCapability =
            match appCapability with
            // Navigation Menu items
            | "NavigationMenu_UpdateStatus" -> NavigationMenu_UpdateStatus
            | "NavigationMenu_Home" -> NavigationMenu_Home
            | "NavigationMenu_Availability" -> NavigationMenu_Availability
            | "NavigationMenu_Tasks" -> NavigationMenu_Tasks
            | "NavigationMenu_VisitHistory" -> NavigationMenu_VisitHistory
            | "NavigationMenu_ArmorClinicalPathway" -> NavigationMenu_ArmorClinicalPathway
            | "NavigationMenu_Dashboard" -> NavigationMenu_Dashboard
            | "NavigationMenu_Admin" -> NavigationMenu_Admin
            | "NavigationMenu_Members" -> NavigationMenu_Members
            | "NavigationMenu_Campaign" -> NavigationMenu_Campaign
            | "NavigationMenu_DeleteAccount" -> NavigationMenu_DeleteAccount
            | "NavigationMenu_ChangePassword" -> NavigationMenu_ChangePassword
            | "NavigationMenu_About" -> NavigationMenu_About
            | "NavigationMenu_SignOut" -> NavigationMenu_SignOut
            // Component Features
            // Home
            | "Home_TasksComponent" -> Home_TasksComponent
            | "Home_TeleHealthAppointments" -> Home_TeleHealthAppointments
            | "Home_OfficeAppointments" -> Home_OfficeAppointments
            // Availability
            | "Availability_ViewClinicianAvailability" -> Availability_ViewClinicianAvailability
            | "Availability_ScheduleClinicianAvailability" -> Availability_ScheduleClinicianAvailability
            // Members
            | "Members_CreateNewPatient" -> Members_CreateNewPatient
            | "Members_ViewPatientMemberDetails" -> Members_ViewPatientMemberDetails
            | "Members_ViewPatientMembers" -> Members_ViewPatientMembers
            | "Members_ViewClinicianMemberDetails" -> Members_ViewClinicianMemberDetails
            | "Members_ViewClinicianMembers" -> Members_ViewClinicianMembers
            | "Members_ViewClinicianManagerMemberDetails" -> Members_ViewClinicianManagerMemberDetails
            | "Members_ViewClinicianManagerMembers" -> Members_ViewClinicianManagerMembers
            | "Members_DigitizeAssessment" -> Members_DigitizeAssessment
            | "Members_PhoneAssessment" -> Members_PhoneAssessment
            | "Members_InPersonAssessment" -> Members_InPersonAssessment
            | "Members_ScheduleMemberForOfficeAppointment" -> Members_ScheduleMemberForOfficeAppointment
            | "Members_ScheduleMemberForTelehealthAppointment" -> Members_ScheduleMemberForTelehealthAppointment
            // VisitHistory
            | "VisitHistory_ViewVisitHistory" -> VisitHistory_ViewVisitHistory
            | "VisitHistory_ViewResult" -> VisitHistory_ViewResult
            | "VisitHistory_ViewClinicalNotes" -> VisitHistory_ViewClinicalNotes
            | "VisitHistory_ViewRecommendedCodes" -> VisitHistory_ViewRecommendedCodes
            | "VisitHistory_ViewForm" -> VisitHistory_ViewForm
            | "VisitHistory_DownloadResultsPDF" -> VisitHistory_DownloadResultsPDF
            | "VisitHistory_SubmitClinicalReview" -> VisitHistory_SubmitClinicalReview
            // Campaign
            | "Campaign_CreateCampaign" -> Campaign_CreateCampaign
            | "Campaign_SendSmsCampaign" -> Campaign_SendSmsCampaign
            | "Campaign_SendEmailCampaign" -> Campaign_SendEmailCampaign
            // FormSelector (?) - this should be based off a linking table to determine who has access to what values
            // CallingActivity
            | "AzureCommunications_CallWithChat" -> AzureCommunications_CallWithChat
            | "AzureCommunications_Chat" -> AzureCommunications_Chat
            | "AzureCommunications_Call" -> AzureCommunications_Call
            | "AzureCommunications_FormOrchestrator" -> AzureCommunications_FormOrchestrator
            // Tasks
            // | ViewTasks
            // | SaveTask
            // | DeleteTask
            // | CompleteTask
            // | CreateTask
            // ArmorClinicalPathway
            // Dashboard
            | _ -> failwith "Invalid App Capability"

    module AppRouteCapability =

        type AppRouteCapability =
            | Dashboard
            | Members
            | Tasks
            | ClinicalPathway
            | Availability
            | AcsCall // call activity?

        let fromString appRouteCapability =
            match appRouteCapability with
            | "Dashboard" -> Dashboard
            | "Members" -> Members
            | "Tasks" -> Tasks
            | "ClinicalPathway" -> ClinicalPathway
            | "Availability" -> Availability
            | "AcsCall" -> AcsCall
            | _ -> failwith "Invalid App Route Capability"

    type ResourceCapability =
        | Api of ApiCapability.ApiCapability
        | Api_Route of ApiRouteCapability.ApiRouteCapability
        | App of AppCapability.AppCapability
        | App_Route of AppRouteCapability.AppRouteCapability

    let create (resourceType: string) (capability: string) =
        match ResourceType.fromString resourceType with
        | ResourceType.App ->
            AppCapability.fromString capability
            |> ResourceCapability.App
        | ResourceType.App_Route ->
            AppRouteCapability.fromString capability
            |> ResourceCapability.App_Route
        | ResourceType.Api ->
            ApiCapability.fromString capability
            |> ResourceCapability.Api
        | ResourceType.Api_Route ->
            ApiRouteCapability.fromString capability
            |> ResourceCapability.Api_Route
