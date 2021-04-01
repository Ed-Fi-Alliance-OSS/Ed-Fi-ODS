using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;

#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.TPDM
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AccreditationStatusDescriptor model.
    /// </summary>
    public interface IAccreditationStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AccreditationStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AidTypeDescriptor model.
    /// </summary>
    public interface IAidTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AidTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfile model.
    /// </summary>
    public interface IApplicantProfile : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantProfileIdentifier { get; set; }

        // Non-PK properties
        DateTime? BirthDate { get; set; }
        string CitizenshipStatusDescriptor { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        string GenderDescriptor { get; set; }
        string GenerationCodeSuffix { get; set; }
        string HighestCompletedLevelOfEducationDescriptor { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        string SexDescriptor { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicantProfileAddress> ApplicantProfileAddresses { get; set; }
        ICollection<IApplicantProfileApplicantCharacteristic> ApplicantProfileApplicantCharacteristics { get; set; }
        ICollection<IApplicantProfileBackgroundCheck> ApplicantProfileBackgroundChecks { get; set; }
        ICollection<IApplicantProfileDisability> ApplicantProfileDisabilities { get; set; }
        ICollection<IApplicantProfileEducatorPreparationProgramName> ApplicantProfileEducatorPreparationProgramNames { get; set; }
        ICollection<IApplicantProfileElectronicMail> ApplicantProfileElectronicMails { get; set; }
        ICollection<IApplicantProfileGradePointAverage> ApplicantProfileGradePointAverages { get; set; }
        ICollection<IApplicantProfileHighlyQualifiedAcademicSubject> ApplicantProfileHighlyQualifiedAcademicSubjects { get; set; }
        ICollection<IApplicantProfileIdentificationDocument> ApplicantProfileIdentificationDocuments { get; set; }
        ICollection<IApplicantProfileInternationalAddress> ApplicantProfileInternationalAddresses { get; set; }
        ICollection<IApplicantProfileLanguage> ApplicantProfileLanguages { get; set; }
        ICollection<IApplicantProfilePersonalIdentificationDocument> ApplicantProfilePersonalIdentificationDocuments { get; set; }
        ICollection<IApplicantProfileRace> ApplicantProfileRaces { get; set; }
        ICollection<IApplicantProfileTelephone> ApplicantProfileTelephones { get; set; }
        ICollection<IApplicantProfileVisa> ApplicantProfileVisas { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileAddress model.
    /// </summary>
    public interface IApplicantProfileAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string AddressTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string City { get; set; }
        [NaturalKeyMember]
        string PostalCode { get; set; }
        [NaturalKeyMember]
        string StateAbbreviationDescriptor { get; set; }
        [NaturalKeyMember]
        string StreetNumberName { get; set; }

        // Non-PK properties
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        string Latitude { get; set; }
        string LocaleDescriptor { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicantProfileAddressPeriod> ApplicantProfileAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileAddressPeriod model.
    /// </summary>
    public interface IApplicantProfileAddressPeriod : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfileAddress ApplicantProfileAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileApplicantCharacteristic model.
    /// </summary>
    public interface IApplicantProfileApplicantCharacteristic : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string StudentCharacteristicDescriptor { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileBackgroundCheck model.
    /// </summary>
    public interface IApplicantProfileBackgroundCheck : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string BackgroundCheckTypeDescriptor { get; set; }

        // Non-PK properties
        DateTime? BackgroundCheckCompletedDate { get; set; }
        DateTime BackgroundCheckRequestedDate { get; set; }
        string BackgroundCheckStatusDescriptor { get; set; }
        bool? Fingerprint { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileDisability model.
    /// </summary>
    public interface IApplicantProfileDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicantProfileDisabilityDesignation> ApplicantProfileDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileDisabilityDesignation model.
    /// </summary>
    public interface IApplicantProfileDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfileDisability ApplicantProfileDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileEducatorPreparationProgramName model.
    /// </summary>
    public interface IApplicantProfileEducatorPreparationProgramName : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string EducatorPreparationProgramName { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileElectronicMail model.
    /// </summary>
    public interface IApplicantProfileElectronicMail : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string ElectronicMailAddress { get; set; }
        [NaturalKeyMember]
        string ElectronicMailTypeDescriptor { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileGradePointAverage model.
    /// </summary>
    public interface IApplicantProfileGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string GradePointAverageTypeDescriptor { get; set; }

        // Non-PK properties
        decimal GradePointAverageValue { get; set; }
        bool? IsCumulative { get; set; }
        decimal? MaxGradePointAverageValue { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileHighlyQualifiedAcademicSubject model.
    /// </summary>
    public interface IApplicantProfileHighlyQualifiedAcademicSubject : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileIdentificationDocument model.
    /// </summary>
    public interface IApplicantProfileIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string IdentificationDocumentUseDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonalInformationVerificationDescriptor { get; set; }

        // Non-PK properties
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        string IssuerCountryDescriptor { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileInternationalAddress model.
    /// </summary>
    public interface IApplicantProfileInternationalAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string AddressTypeDescriptor { get; set; }

        // Non-PK properties
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string AddressLine4 { get; set; }
        DateTime? BeginDate { get; set; }
        string CountryDescriptor { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileLanguage model.
    /// </summary>
    public interface IApplicantProfileLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IApplicantProfileLanguageUse> ApplicantProfileLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileLanguageUse model.
    /// </summary>
    public interface IApplicantProfileLanguageUse : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfileLanguage ApplicantProfileLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfilePersonalIdentificationDocument model.
    /// </summary>
    public interface IApplicantProfilePersonalIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string IdentificationDocumentUseDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonalInformationVerificationDescriptor { get; set; }

        // Non-PK properties
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        string IssuerCountryDescriptor { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileRace model.
    /// </summary>
    public interface IApplicantProfileRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileTelephone model.
    /// </summary>
    public interface IApplicantProfileTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string TelephoneNumber { get; set; }
        [NaturalKeyMember]
        string TelephoneNumberTypeDescriptor { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantProfileVisa model.
    /// </summary>
    public interface IApplicantProfileVisa : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantProfile ApplicantProfile { get; set; }
        [NaturalKeyMember]
        string VisaDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Application model.
    /// </summary>
    public interface IApplication : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantProfileIdentifier { get; set; }
        [NaturalKeyMember]
        string ApplicationIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        DateTime? AcceptedDate { get; set; }
        DateTime ApplicationDate { get; set; }
        string ApplicationSourceDescriptor { get; set; }
        string ApplicationStatusDescriptor { get; set; }
        bool? CurrentEmployee { get; set; }
        DateTime? FirstContactDate { get; set; }
        string HighNeedsAcademicSubjectDescriptor { get; set; }
        string HireStatusDescriptor { get; set; }
        string HiringSourceDescriptor { get; set; }
        string RequisitionNumber { get; set; }
        DateTime? WithdrawDate { get; set; }
        string WithdrawReasonDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicationRecruitmentEventAttendance> ApplicationRecruitmentEventAttendances { get; set; }
        ICollection<IApplicationScoreResult> ApplicationScoreResults { get; set; }
        ICollection<IApplicationTerm> ApplicationTerms { get; set; }

        // Resource reference data
        Guid? ApplicantProfileResourceId { get; set; }
        string ApplicantProfileDiscriminator { get; set; }
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? OpenStaffPositionResourceId { get; set; }
        string OpenStaffPositionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationEvent model.
    /// </summary>
    public interface IApplicationEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantProfileIdentifier { get; set; }
        [NaturalKeyMember]
        string ApplicationEventTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string ApplicationIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        int SequenceNumber { get; set; }

        // Non-PK properties
        decimal? ApplicationEvaluationScore { get; set; }
        string ApplicationEventResultDescriptor { get; set; }
        DateTime? EventEndDate { get; set; }
        short SchoolYear { get; set; }
        string TermDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ApplicationResourceId { get; set; }
        string ApplicationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationEventResultDescriptor model.
    /// </summary>
    public interface IApplicationEventResultDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ApplicationEventResultDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationEventTypeDescriptor model.
    /// </summary>
    public interface IApplicationEventTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ApplicationEventTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationRecruitmentEventAttendance model.
    /// </summary>
    public interface IApplicationRecruitmentEventAttendance : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplication Application { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string EventTitle { get; set; }
        [NaturalKeyMember]
        string RecruitmentEventAttendeeIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? RecruitmentEventAttendanceResourceId { get; set; }
        string RecruitmentEventAttendanceDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationScoreResult model.
    /// </summary>
    public interface IApplicationScoreResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplication Application { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }

        // Non-PK properties
        string Result { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationSourceDescriptor model.
    /// </summary>
    public interface IApplicationSourceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ApplicationSourceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationStatusDescriptor model.
    /// </summary>
    public interface IApplicationStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ApplicationStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationTerm model.
    /// </summary>
    public interface IApplicationTerm : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplication Application { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentExtension model.
    /// </summary>
    public interface IAssessmentExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IAssessment Assessment { get; set; }

        // Non-PK properties
        string ProgramGatewayDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BackgroundCheckStatusDescriptor model.
    /// </summary>
    public interface IBackgroundCheckStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int BackgroundCheckStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BackgroundCheckTypeDescriptor model.
    /// </summary>
    public interface IBackgroundCheckTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int BackgroundCheckTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Candidate model.
    /// </summary>
    public interface ICandidate : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CandidateIdentifier { get; set; }

        // Non-PK properties
        string ApplicantProfileIdentifier { get; set; }
        string ApplicationIdentifier { get; set; }
        string BirthCity { get; set; }
        string BirthCountryDescriptor { get; set; }
        DateTime BirthDate { get; set; }
        string BirthInternationalProvince { get; set; }
        string BirthSexDescriptor { get; set; }
        string BirthStateAbbreviationDescriptor { get; set; }
        string CitizenshipStatusDescriptor { get; set; }
        DateTime? DateEnteredUS { get; set; }
        string DisplacementStatus { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        int? EducationOrganizationId { get; set; }
        string EnglishLanguageExamDescriptor { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        string GenderDescriptor { get; set; }
        string GenerationCodeSuffix { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string LimitedEnglishProficiencyDescriptor { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        bool? MultipleBirthStatus { get; set; }
        string OldEthnicityDescriptor { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        string PreviousCareerDescriptor { get; set; }
        string ProfileThumbnail { get; set; }
        bool? ProgramComplete { get; set; }
        string SexDescriptor { get; set; }
        string SourceSystemDescriptor { get; set; }
        decimal? TuitionCost { get; set; }

        // One-to-one relationships

        ICandidateBackgroundCheck CandidateBackgroundCheck { get; set; }

        // Lists
        ICollection<ICandidateAddress> CandidateAddresses { get; set; }
        ICollection<ICandidateAid> CandidateAids { get; set; }
        ICollection<ICandidateCharacteristic> CandidateCharacteristics { get; set; }
        ICollection<ICandidateCohortYear> CandidateCohortYears { get; set; }
        ICollection<ICandidateDegreeSpecialization> CandidateDegreeSpecializations { get; set; }
        ICollection<ICandidateDisability> CandidateDisabilities { get; set; }
        ICollection<ICandidateElectronicMail> CandidateElectronicMails { get; set; }
        ICollection<ICandidateEPPProgramDegree> CandidateEPPProgramDegrees { get; set; }
        ICollection<ICandidateIdentificationCode> CandidateIdentificationCodes { get; set; }
        ICollection<ICandidateIdentificationDocument> CandidateIdentificationDocuments { get; set; }
        ICollection<ICandidateIndicator> CandidateIndicators { get; set; }
        ICollection<ICandidateInternationalAddress> CandidateInternationalAddresses { get; set; }
        ICollection<ICandidateLanguage> CandidateLanguages { get; set; }
        ICollection<ICandidateOtherName> CandidateOtherNames { get; set; }
        ICollection<ICandidatePersonalIdentificationDocument> CandidatePersonalIdentificationDocuments { get; set; }
        ICollection<ICandidateRace> CandidateRaces { get; set; }
        ICollection<ICandidateTelephone> CandidateTelephones { get; set; }
        ICollection<ICandidateVisa> CandidateVisas { get; set; }

        // Resource reference data
        Guid? ApplicationResourceId { get; set; }
        string ApplicationDiscriminator { get; set; }
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateAddress model.
    /// </summary>
    public interface ICandidateAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string AddressTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string City { get; set; }
        [NaturalKeyMember]
        string PostalCode { get; set; }
        [NaturalKeyMember]
        string StateAbbreviationDescriptor { get; set; }
        [NaturalKeyMember]
        string StreetNumberName { get; set; }

        // Non-PK properties
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        string Latitude { get; set; }
        string LocaleDescriptor { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICandidateAddressPeriod> CandidateAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateAddressPeriod model.
    /// </summary>
    public interface ICandidateAddressPeriod : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidateAddress CandidateAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateAid model.
    /// </summary>
    public interface ICandidateAid : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string AidTypeDescriptor { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        decimal? AidAmount { get; set; }
        string AidConditionDescription { get; set; }
        DateTime? EndDate { get; set; }
        bool? PellGrantRecipient { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateBackgroundCheck model.
    /// </summary>
    public interface ICandidateBackgroundCheck : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }

        // Non-PK properties
        DateTime? BackgroundCheckCompletedDate { get; set; }
        DateTime BackgroundCheckRequestedDate { get; set; }
        string BackgroundCheckStatusDescriptor { get; set; }
        string BackgroundCheckTypeDescriptor { get; set; }
        bool? Fingerprint { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateCharacteristic model.
    /// </summary>
    public interface ICandidateCharacteristic : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string CandidateCharacteristicDescriptor { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateCharacteristicDescriptor model.
    /// </summary>
    public interface ICandidateCharacteristicDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CandidateCharacteristicDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateCohortYear model.
    /// </summary>
    public interface ICandidateCohortYear : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string CohortYearTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateDegreeSpecialization model.
    /// </summary>
    public interface ICandidateDegreeSpecialization : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string MajorSpecialization { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string MinorSpecialization { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateDisability model.
    /// </summary>
    public interface ICandidateDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICandidateDisabilityDesignation> CandidateDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateDisabilityDesignation model.
    /// </summary>
    public interface ICandidateDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidateDisability CandidateDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateEducatorPreparationProgramAssociation model.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string CandidateIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string EPPProgramPathwayDescriptor { get; set; }
        string MajorSpecialization { get; set; }
        string MinorSpecialization { get; set; }
        string ReasonExitedDescriptor { get; set; }

        // One-to-one relationships

        ICandidateEducatorPreparationProgramAssociationCandidateIndicator CandidateEducatorPreparationProgramAssociationCandidateIndicator { get; set; }

        // Lists

        // Resource reference data
        Guid? CandidateResourceId { get; set; }
        string CandidateDiscriminator { get; set; }
        Guid? EducatorPreparationProgramResourceId { get; set; }
        string EducatorPreparationProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateEducatorPreparationProgramAssociationCandidateIndicator model.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociationCandidateIndicator : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidateEducatorPreparationProgramAssociation CandidateEducatorPreparationProgramAssociation { get; set; }

        // Non-PK properties
        string DesignatedBy { get; set; }
        string Indicator { get; set; }
        string IndicatorGroup { get; set; }
        string IndicatorName { get; set; }

        // One-to-one relationships

        ICandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod { get; set; }

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod model.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidateEducatorPreparationProgramAssociationCandidateIndicator CandidateEducatorPreparationProgramAssociationCandidateIndicator { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateElectronicMail model.
    /// </summary>
    public interface ICandidateElectronicMail : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string ElectronicMailAddress { get; set; }
        [NaturalKeyMember]
        string ElectronicMailTypeDescriptor { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateEPPProgramDegree model.
    /// </summary>
    public interface ICandidateEPPProgramDegree : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }
        [NaturalKeyMember]
        string EPPDegreeTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateIdentificationCode model.
    /// </summary>
    public interface ICandidateIdentificationCode : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string AssigningOrganizationIdentificationCode { get; set; }
        [NaturalKeyMember]
        string IdentificationCode { get; set; }
        [NaturalKeyMember]
        string StudentIdentificationSystemDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateIdentificationDocument model.
    /// </summary>
    public interface ICandidateIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string IdentificationDocumentUseDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonalInformationVerificationDescriptor { get; set; }

        // Non-PK properties
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        string IssuerCountryDescriptor { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateIndicator model.
    /// </summary>
    public interface ICandidateIndicator : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string IndicatorName { get; set; }

        // Non-PK properties
        string DesignatedBy { get; set; }
        string Indicator { get; set; }
        string IndicatorGroup { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICandidateIndicatorPeriod> CandidateIndicatorPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateIndicatorPeriod model.
    /// </summary>
    public interface ICandidateIndicatorPeriod : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidateIndicator CandidateIndicator { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateInternationalAddress model.
    /// </summary>
    public interface ICandidateInternationalAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string AddressTypeDescriptor { get; set; }

        // Non-PK properties
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string AddressLine4 { get; set; }
        DateTime? BeginDate { get; set; }
        string CountryDescriptor { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateLanguage model.
    /// </summary>
    public interface ICandidateLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<ICandidateLanguageUse> CandidateLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateLanguageUse model.
    /// </summary>
    public interface ICandidateLanguageUse : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidateLanguage CandidateLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateOtherName model.
    /// </summary>
    public interface ICandidateOtherName : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string OtherNameTypeDescriptor { get; set; }

        // Non-PK properties
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidatePersonalIdentificationDocument model.
    /// </summary>
    public interface ICandidatePersonalIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string IdentificationDocumentUseDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonalInformationVerificationDescriptor { get; set; }

        // Non-PK properties
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        string IssuerCountryDescriptor { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateRace model.
    /// </summary>
    public interface ICandidateRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateRelationshipToStaffAssociation model.
    /// </summary>
    public interface ICandidateRelationshipToStaffAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CandidateIdentifier { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string StaffToCandidateRelationshipDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CandidateResourceId { get; set; }
        string CandidateDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateTelephone model.
    /// </summary>
    public interface ICandidateTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string TelephoneNumber { get; set; }
        [NaturalKeyMember]
        string TelephoneNumberTypeDescriptor { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateVisa model.
    /// </summary>
    public interface ICandidateVisa : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICandidate Candidate { get; set; }
        [NaturalKeyMember]
        string VisaDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Certification model.
    /// </summary>
    public interface ICertification : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CertificationIdentifier { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties
        string CertificationFieldDescriptor { get; set; }
        string CertificationLevelDescriptor { get; set; }
        string CertificationStandardDescriptor { get; set; }
        string CertificationTitle { get; set; }
        int? EducationOrganizationId { get; set; }
        string EducatorRoleDescriptor { get; set; }
        DateTime? EffectiveDate { get; set; }
        DateTime? EndDate { get; set; }
        string InstructionalSettingDescriptor { get; set; }
        string MinimumDegreeDescriptor { get; set; }
        string PopulationServedDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICertificationCertificationExam> CertificationCertificationExams { get; set; }
        ICollection<ICertificationGradeLevel> CertificationGradeLevels { get; set; }
        ICollection<ICertificationRoute> CertificationRoutes { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationCertificationExam model.
    /// </summary>
    public interface ICertificationCertificationExam : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICertification Certification { get; set; }
        [NaturalKeyMember]
        string CertificationExamIdentifier { get; set; }
        [NaturalKeyMember]
        string CertificationExamNamespace { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CertificationExamResourceId { get; set; }
        string CertificationExamDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationExam model.
    /// </summary>
    public interface ICertificationExam : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CertificationExamIdentifier { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties
        string CertificationExamTitle { get; set; }
        string CertificationExamTypeDescriptor { get; set; }
        int? EducationOrganizationId { get; set; }
        DateTime? EffectiveDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationExamResult model.
    /// </summary>
    public interface ICertificationExamResult : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime CertificationExamDate { get; set; }
        [NaturalKeyMember]
        string CertificationExamIdentifier { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }

        // Non-PK properties
        int? AttemptNumber { get; set; }
        bool? CertificationExamPassIndicator { get; set; }
        decimal? CertificationExamScore { get; set; }
        string CertificationExamStatusDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CertificationExamResourceId { get; set; }
        string CertificationExamDiscriminator { get; set; }
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationExamStatusDescriptor model.
    /// </summary>
    public interface ICertificationExamStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CertificationExamStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationExamTypeDescriptor model.
    /// </summary>
    public interface ICertificationExamTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CertificationExamTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationFieldDescriptor model.
    /// </summary>
    public interface ICertificationFieldDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CertificationFieldDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationGradeLevel model.
    /// </summary>
    public interface ICertificationGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICertification Certification { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationLevelDescriptor model.
    /// </summary>
    public interface ICertificationLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CertificationLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationRoute model.
    /// </summary>
    public interface ICertificationRoute : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICertification Certification { get; set; }
        [NaturalKeyMember]
        string CertificationRouteDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationRouteDescriptor model.
    /// </summary>
    public interface ICertificationRouteDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CertificationRouteDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationStandardDescriptor model.
    /// </summary>
    public interface ICertificationStandardDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CertificationStandardDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CoteachingStyleObservedDescriptor model.
    /// </summary>
    public interface ICoteachingStyleObservedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CoteachingStyleObservedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialEvent model.
    /// </summary>
    public interface ICredentialEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime CredentialEventDate { get; set; }
        [NaturalKeyMember]
        string CredentialEventTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string CredentialIdentifier { get; set; }
        [NaturalKeyMember]
        string StateOfIssueStateAbbreviationDescriptor { get; set; }

        // Non-PK properties
        string CredentialEventReason { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CredentialResourceId { get; set; }
        string CredentialDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialEventTypeDescriptor model.
    /// </summary>
    public interface ICredentialEventTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CredentialEventTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialExtension model.
    /// </summary>
    public interface ICredentialExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ICredential Credential { get; set; }

        // Non-PK properties
        bool? BoardCertificationIndicator { get; set; }
        string CertificationIdentifier { get; set; }
        string CertificationRouteDescriptor { get; set; }
        string CertificationTitle { get; set; }
        DateTime? CredentialStatusDate { get; set; }
        string CredentialStatusDescriptor { get; set; }
        string Namespace { get; set; }
        string PersonId { get; set; }
        string SourceSystemDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICredentialStudentAcademicRecord> CredentialStudentAcademicRecords { get; set; }

        // Resource reference data
        Guid? CertificationResourceId { get; set; }
        string CertificationDiscriminator { get; set; }
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialStatusDescriptor model.
    /// </summary>
    public interface ICredentialStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CredentialStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialStudentAcademicRecord model.
    /// </summary>
    public interface ICredentialStudentAcademicRecord : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredentialExtension CredentialExtension { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentAcademicRecordResourceId { get; set; }
        string StudentAcademicRecordDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DegreeDescriptor model.
    /// </summary>
    public interface IDegreeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DegreeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducatorPreparationProgram model.
    /// </summary>
    public interface IEducatorPreparationProgram : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties
        string AccreditationStatusDescriptor { get; set; }
        string EducatorPreparationProgramTypeDescriptor { get; set; }
        string ProgramId { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEducatorPreparationProgramGradeLevel> EducatorPreparationProgramGradeLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducatorPreparationProgramGradeLevel model.
    /// </summary>
    public interface IEducatorPreparationProgramGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducatorPreparationProgram EducatorPreparationProgram { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducatorPreparationProgramTypeDescriptor model.
    /// </summary>
    public interface IEducatorPreparationProgramTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EducatorPreparationProgramTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducatorRoleDescriptor model.
    /// </summary>
    public interface IEducatorRoleDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EducatorRoleDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EnglishLanguageExamDescriptor model.
    /// </summary>
    public interface IEnglishLanguageExamDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EnglishLanguageExamDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EPPDegreeTypeDescriptor model.
    /// </summary>
    public interface IEPPDegreeTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EPPDegreeTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EPPProgramPathwayDescriptor model.
    /// </summary>
    public interface IEPPProgramPathwayDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EPPProgramPathwayDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Evaluation model.
    /// </summary>
    public interface IEvaluation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationTypeDescriptor { get; set; }
        int? InterRaterReliabilityScore { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationRatingLevel> EvaluationRatingLevels { get; set; }

        // Resource reference data
        Guid? PerformanceEvaluationResourceId { get; set; }
        string PerformanceEvaluationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElement model.
    /// </summary>
    public interface IEvaluationElement : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationElementTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationTypeDescriptor { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        int? SortOrder { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationElementRatingLevel> EvaluationElementRatingLevels { get; set; }

        // Resource reference data
        Guid? EvaluationObjectiveResourceId { get; set; }
        string EvaluationObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRating model.
    /// </summary>
    public interface IEvaluationElementRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EvaluationDate { get; set; }
        [NaturalKeyMember]
        string EvaluationElementTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string AreaOfRefinement { get; set; }
        string AreaOfReinforcement { get; set; }
        string Comments { get; set; }
        string EvaluationElementRatingLevelDescriptor { get; set; }
        string Feedback { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationElementRatingResult> EvaluationElementRatingResults { get; set; }

        // Resource reference data
        Guid? EvaluationElementResourceId { get; set; }
        string EvaluationElementDiscriminator { get; set; }
        Guid? EvaluationObjectiveRatingResourceId { get; set; }
        string EvaluationObjectiveRatingDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRatingLevel model.
    /// </summary>
    public interface IEvaluationElementRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluationElement EvaluationElement { get; set; }
        [NaturalKeyMember]
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRatingLevelDescriptor model.
    /// </summary>
    public interface IEvaluationElementRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EvaluationElementRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRatingResult model.
    /// </summary>
    public interface IEvaluationElementRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluationElementRating EvaluationElementRating { get; set; }
        [NaturalKeyMember]
        decimal Rating { get; set; }
        [NaturalKeyMember]
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjective model.
    /// </summary>
    public interface IEvaluationObjective : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationTypeDescriptor { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        int? SortOrder { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationObjectiveRatingLevel> EvaluationObjectiveRatingLevels { get; set; }

        // Resource reference data
        Guid? EvaluationResourceId { get; set; }
        string EvaluationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjectiveRating model.
    /// </summary>
    public interface IEvaluationObjectiveRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EvaluationDate { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string Comments { get; set; }
        string ObjectiveRatingLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationObjectiveRatingResult> EvaluationObjectiveRatingResults { get; set; }

        // Resource reference data
        Guid? EvaluationObjectiveResourceId { get; set; }
        string EvaluationObjectiveDiscriminator { get; set; }
        Guid? EvaluationRatingResourceId { get; set; }
        string EvaluationRatingDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjectiveRatingLevel model.
    /// </summary>
    public interface IEvaluationObjectiveRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluationObjective EvaluationObjective { get; set; }
        [NaturalKeyMember]
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjectiveRatingResult model.
    /// </summary>
    public interface IEvaluationObjectiveRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluationObjectiveRating EvaluationObjectiveRating { get; set; }
        [NaturalKeyMember]
        decimal Rating { get; set; }
        [NaturalKeyMember]
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationPeriodDescriptor model.
    /// </summary>
    public interface IEvaluationPeriodDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EvaluationPeriodDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRating model.
    /// </summary>
    public interface IEvaluationRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EvaluationDate { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationRatingLevelDescriptor { get; set; }
        string LocalCourseCode { get; set; }
        int? SchoolId { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationRatingResult> EvaluationRatingResults { get; set; }
        ICollection<IEvaluationRatingReviewer> EvaluationRatingReviewers { get; set; }

        // Resource reference data
        Guid? EvaluationResourceId { get; set; }
        string EvaluationDiscriminator { get; set; }
        Guid? PerformanceEvaluationRatingResourceId { get; set; }
        string PerformanceEvaluationRatingDiscriminator { get; set; }
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingLevel model.
    /// </summary>
    public interface IEvaluationRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluation Evaluation { get; set; }
        [NaturalKeyMember]
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingLevelDescriptor model.
    /// </summary>
    public interface IEvaluationRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EvaluationRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingResult model.
    /// </summary>
    public interface IEvaluationRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluationRating EvaluationRating { get; set; }
        [NaturalKeyMember]
        decimal Rating { get; set; }
        [NaturalKeyMember]
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingReviewer model.
    /// </summary>
    public interface IEvaluationRatingReviewer : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluationRating EvaluationRating { get; set; }
        [NaturalKeyMember]
        string FirstName { get; set; }
        [NaturalKeyMember]
        string LastSurname { get; set; }

        // Non-PK properties
        string ReviewerPersonId { get; set; }
        string ReviewerSourceSystemDescriptor { get; set; }

        // One-to-one relationships

        IEvaluationRatingReviewerReceivedTraining EvaluationRatingReviewerReceivedTraining { get; set; }

        // Lists

        // Resource reference data
        Guid? ReviewerPersonResourceId { get; set; }
        string ReviewerPersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingReviewerReceivedTraining model.
    /// </summary>
    public interface IEvaluationRatingReviewerReceivedTraining : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEvaluationRatingReviewer EvaluationRatingReviewer { get; set; }

        // Non-PK properties
        int? InterRaterReliabilityScore { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationTypeDescriptor model.
    /// </summary>
    public interface IEvaluationTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EvaluationTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FederalLocaleCodeDescriptor model.
    /// </summary>
    public interface IFederalLocaleCodeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int FederalLocaleCodeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FieldworkExperience model.
    /// </summary>
    public interface IFieldworkExperience : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string FieldworkIdentifier { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        int? EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        string FieldworkTypeDescriptor { get; set; }
        decimal? HoursCompleted { get; set; }
        string ProgramGatewayDescriptor { get; set; }
        string ProgramName { get; set; }
        string ProgramTypeDescriptor { get; set; }
        int? SchoolId { get; set; }

        // One-to-one relationships

        IFieldworkExperienceCoteaching FieldworkExperienceCoteaching { get; set; }

        // Lists

        // Resource reference data
        Guid? EducatorPreparationProgramResourceId { get; set; }
        string EducatorPreparationProgramDiscriminator { get; set; }
        Guid? SchoolResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FieldworkExperienceCoteaching model.
    /// </summary>
    public interface IFieldworkExperienceCoteaching : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IFieldworkExperience FieldworkExperience { get; set; }

        // Non-PK properties
        DateTime CoteachingBeginDate { get; set; }
        DateTime? CoteachingEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FieldworkExperienceSectionAssociation model.
    /// </summary>
    public interface IFieldworkExperienceSectionAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string FieldworkIdentifier { get; set; }
        [NaturalKeyMember]
        string LocalCourseCode { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SectionIdentifier { get; set; }
        [NaturalKeyMember]
        string SessionName { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? FieldworkExperienceResourceId { get; set; }
        string FieldworkExperienceDiscriminator { get; set; }
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FieldworkTypeDescriptor model.
    /// </summary>
    public interface IFieldworkTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int FieldworkTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FundingSourceDescriptor model.
    /// </summary>
    public interface IFundingSourceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int FundingSourceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GenderDescriptor model.
    /// </summary>
    public interface IGenderDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GenderDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Goal model.
    /// </summary>
    public interface IGoal : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AssignmentDate { get; set; }
        [NaturalKeyMember]
        string GoalTitle { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }

        // Non-PK properties
        string Comments { get; set; }
        DateTime? CompletedDate { get; set; }
        bool? CompletedIndicator { get; set; }
        DateTime? DueDate { get; set; }
        int? EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        string EvaluationPeriodDescriptor { get; set; }
        string EvaluationTitle { get; set; }
        string GoalDescription { get; set; }
        string GoalTypeDescriptor { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        string PerformanceEvaluationTypeDescriptor { get; set; }
        short? SchoolYear { get; set; }
        string TermDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluationElementResourceId { get; set; }
        string EvaluationElementDiscriminator { get; set; }
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GoalTypeDescriptor model.
    /// </summary>
    public interface IGoalTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GoalTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanExtension model.
    /// </summary>
    public interface IGraduationPlanExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IGraduationPlan GraduationPlan { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IGraduationPlanRequiredCertification> GraduationPlanRequiredCertifications { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanRequiredCertification model.
    /// </summary>
    public interface IGraduationPlanRequiredCertification : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlanExtension GraduationPlanExtension { get; set; }
        [NaturalKeyMember]
        string CertificationTitle { get; set; }

        // Non-PK properties
        string CertificationIdentifier { get; set; }
        string CertificationRouteDescriptor { get; set; }
        string Namespace { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CertificationResourceId { get; set; }
        string CertificationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the HireStatusDescriptor model.
    /// </summary>
    public interface IHireStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int HireStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the HiringSourceDescriptor model.
    /// </summary>
    public interface IHiringSourceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int HiringSourceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InstructionalSettingDescriptor model.
    /// </summary>
    public interface IInstructionalSettingDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InstructionalSettingDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LengthOfContractDescriptor model.
    /// </summary>
    public interface ILengthOfContractDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LengthOfContractDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LocalEducationAgencyExtension model.
    /// </summary>
    public interface ILocalEducationAgencyExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ILocalEducationAgency LocalEducationAgency { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveRatingLevelDescriptor model.
    /// </summary>
    public interface IObjectiveRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ObjectiveRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPositionEvent model.
    /// </summary>
    public interface IOpenStaffPositionEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string OpenStaffPositionEventTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string RequisitionNumber { get; set; }

        // Non-PK properties
        string OpenStaffPositionEventStatusDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? OpenStaffPositionResourceId { get; set; }
        string OpenStaffPositionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPositionEventStatusDescriptor model.
    /// </summary>
    public interface IOpenStaffPositionEventStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int OpenStaffPositionEventStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPositionEventTypeDescriptor model.
    /// </summary>
    public interface IOpenStaffPositionEventTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int OpenStaffPositionEventTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPositionExtension model.
    /// </summary>
    public interface IOpenStaffPositionExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IOpenStaffPosition OpenStaffPosition { get; set; }

        // Non-PK properties
        decimal? FullTimeEquivalency { get; set; }
        string FundingSourceDescriptor { get; set; }
        bool? HighNeedAcademicSubject { get; set; }
        bool? IsActive { get; set; }
        decimal? MaxSalary { get; set; }
        decimal? MinSalary { get; set; }
        string OpenStaffPositionReasonDescriptor { get; set; }
        string PositionControlNumber { get; set; }
        short? SchoolYear { get; set; }
        string TermDescriptor { get; set; }
        decimal? TotalBudgeted { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPositionReasonDescriptor model.
    /// </summary>
    public interface IOpenStaffPositionReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int OpenStaffPositionReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluation model.
    /// </summary>
    public interface IPerformanceEvaluation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IPerformanceEvaluationGradeLevel> PerformanceEvaluationGradeLevels { get; set; }
        ICollection<IPerformanceEvaluationProgramGateway> PerformanceEvaluationProgramGateways { get; set; }
        ICollection<IPerformanceEvaluationRatingLevel> PerformanceEvaluationRatingLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationGradeLevel model.
    /// </summary>
    public interface IPerformanceEvaluationGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceEvaluation PerformanceEvaluation { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationProgramGateway model.
    /// </summary>
    public interface IPerformanceEvaluationProgramGateway : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceEvaluation PerformanceEvaluation { get; set; }
        [NaturalKeyMember]
        string ProgramGatewayDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRating model.
    /// </summary>
    public interface IPerformanceEvaluationRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        DateTime ActualDate { get; set; }
        int? ActualDuration { get; set; }
        TimeSpan? ActualTime { get; set; }
        bool? Announced { get; set; }
        string Comments { get; set; }
        string CoteachingStyleObservedDescriptor { get; set; }
        string PerformanceEvaluationRatingLevelDescriptor { get; set; }
        DateTime? ScheduleDate { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IPerformanceEvaluationRatingResult> PerformanceEvaluationRatingResults { get; set; }
        ICollection<IPerformanceEvaluationRatingReviewer> PerformanceEvaluationRatingReviewers { get; set; }

        // Resource reference data
        Guid? PerformanceEvaluationResourceId { get; set; }
        string PerformanceEvaluationDiscriminator { get; set; }
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingLevel model.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceEvaluation PerformanceEvaluation { get; set; }
        [NaturalKeyMember]
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingLevelDescriptor model.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PerformanceEvaluationRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingResult model.
    /// </summary>
    public interface IPerformanceEvaluationRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceEvaluationRating PerformanceEvaluationRating { get; set; }
        [NaturalKeyMember]
        decimal Rating { get; set; }
        [NaturalKeyMember]
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingReviewer model.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewer : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceEvaluationRating PerformanceEvaluationRating { get; set; }
        [NaturalKeyMember]
        string FirstName { get; set; }
        [NaturalKeyMember]
        string LastSurname { get; set; }

        // Non-PK properties
        string ReviewerPersonId { get; set; }
        string ReviewerSourceSystemDescriptor { get; set; }

        // One-to-one relationships

        IPerformanceEvaluationRatingReviewerReceivedTraining PerformanceEvaluationRatingReviewerReceivedTraining { get; set; }

        // Lists

        // Resource reference data
        Guid? ReviewerPersonResourceId { get; set; }
        string ReviewerPersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingReviewerReceivedTraining model.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewerReceivedTraining : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceEvaluationRatingReviewer PerformanceEvaluationRatingReviewer { get; set; }

        // Non-PK properties
        int? InterRaterReliabilityScore { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationTypeDescriptor model.
    /// </summary>
    public interface IPerformanceEvaluationTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PerformanceEvaluationTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostSecondaryInstitutionExtension model.
    /// </summary>
    public interface IPostSecondaryInstitutionExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IPostSecondaryInstitution PostSecondaryInstitution { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PreviousCareerDescriptor model.
    /// </summary>
    public interface IPreviousCareerDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PreviousCareerDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProfessionalDevelopmentEvent model.
    /// </summary>
    public interface IProfessionalDevelopmentEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string ProfessionalDevelopmentTitle { get; set; }

        // Non-PK properties
        bool? MultipleSession { get; set; }
        string ProfessionalDevelopmentOfferedByDescriptor { get; set; }
        string ProfessionalDevelopmentReason { get; set; }
        bool? Required { get; set; }
        int? TotalHours { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProfessionalDevelopmentEventAttendance model.
    /// </summary>
    public interface IProfessionalDevelopmentEventAttendance : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AttendanceDate { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        string ProfessionalDevelopmentTitle { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }

        // Non-PK properties
        string AttendanceEventCategoryDescriptor { get; set; }
        string AttendanceEventReason { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
        Guid? ProfessionalDevelopmentEventResourceId { get; set; }
        string ProfessionalDevelopmentEventDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProfessionalDevelopmentOfferedByDescriptor model.
    /// </summary>
    public interface IProfessionalDevelopmentOfferedByDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProfessionalDevelopmentOfferedByDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramGatewayDescriptor model.
    /// </summary>
    public interface IProgramGatewayDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProgramGatewayDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the QuantitativeMeasure model.
    /// </summary>
    public interface IQuantitativeMeasure : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationElementTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string QuantitativeMeasureIdentifier { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string QuantitativeMeasureDatatypeDescriptor { get; set; }
        string QuantitativeMeasureTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluationElementResourceId { get; set; }
        string EvaluationElementDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the QuantitativeMeasureDatatypeDescriptor model.
    /// </summary>
    public interface IQuantitativeMeasureDatatypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int QuantitativeMeasureDatatypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the QuantitativeMeasureScore model.
    /// </summary>
    public interface IQuantitativeMeasureScore : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EvaluationDate { get; set; }
        [NaturalKeyMember]
        string EvaluationElementTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        string QuantitativeMeasureIdentifier { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        decimal ScoreValue { get; set; }
        decimal? StandardError { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluationElementRatingResourceId { get; set; }
        string EvaluationElementRatingDiscriminator { get; set; }
        Guid? QuantitativeMeasureResourceId { get; set; }
        string QuantitativeMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the QuantitativeMeasureTypeDescriptor model.
    /// </summary>
    public interface IQuantitativeMeasureTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int QuantitativeMeasureTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEvent model.
    /// </summary>
    public interface IRecruitmentEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string EventTitle { get; set; }

        // Non-PK properties
        string EventDescription { get; set; }
        string EventLocation { get; set; }
        string RecruitmentEventTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendance model.
    /// </summary>
    public interface IRecruitmentEventAttendance : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string EventTitle { get; set; }
        [NaturalKeyMember]
        string RecruitmentEventAttendeeIdentifier { get; set; }

        // Non-PK properties
        bool? Applied { get; set; }
        string ElectronicMailAddress { get; set; }
        string FirstName { get; set; }
        string GenderDescriptor { get; set; }
        string GenerationCodeSuffix { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string MaidenName { get; set; }
        bool? Met { get; set; }
        string MiddleName { get; set; }
        string Notes { get; set; }
        string PersonalTitlePrefix { get; set; }
        int? PreScreeningRating { get; set; }
        string RecruitmentEventAttendeeTypeDescriptor { get; set; }
        bool? Referral { get; set; }
        string ReferredBy { get; set; }
        string SexDescriptor { get; set; }
        string SocialMediaNetworkName { get; set; }
        string SocialMediaUserName { get; set; }

        // One-to-one relationships

        IRecruitmentEventAttendanceCurrentPosition RecruitmentEventAttendanceCurrentPosition { get; set; }

        IRecruitmentEventAttendanceRecruitmentEventAttendeeQualifications RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications { get; set; }

        // Lists
        ICollection<IRecruitmentEventAttendanceDisability> RecruitmentEventAttendanceDisabilities { get; set; }
        ICollection<IRecruitmentEventAttendancePersonalIdentificationDocument> RecruitmentEventAttendancePersonalIdentificationDocuments { get; set; }
        ICollection<IRecruitmentEventAttendanceRace> RecruitmentEventAttendanceRaces { get; set; }
        ICollection<IRecruitmentEventAttendanceTelephone> RecruitmentEventAttendanceTelephones { get; set; }
        ICollection<IRecruitmentEventAttendanceTouchpoint> RecruitmentEventAttendanceTouchpoints { get; set; }

        // Resource reference data
        Guid? RecruitmentEventResourceId { get; set; }
        string RecruitmentEventDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceCurrentPosition model.
    /// </summary>
    public interface IRecruitmentEventAttendanceCurrentPosition : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendance RecruitmentEventAttendance { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string Location { get; set; }
        string NameOfInstitution { get; set; }
        string PositionTitle { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IRecruitmentEventAttendanceCurrentPositionGradeLevel> RecruitmentEventAttendanceCurrentPositionGradeLevels { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceCurrentPositionGradeLevel model.
    /// </summary>
    public interface IRecruitmentEventAttendanceCurrentPositionGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendanceCurrentPosition RecruitmentEventAttendanceCurrentPosition { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceDisability model.
    /// </summary>
    public interface IRecruitmentEventAttendanceDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendance RecruitmentEventAttendance { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IRecruitmentEventAttendanceDisabilityDesignation> RecruitmentEventAttendanceDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceDisabilityDesignation model.
    /// </summary>
    public interface IRecruitmentEventAttendanceDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendanceDisability RecruitmentEventAttendanceDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendancePersonalIdentificationDocument model.
    /// </summary>
    public interface IRecruitmentEventAttendancePersonalIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendance RecruitmentEventAttendance { get; set; }
        [NaturalKeyMember]
        string IdentificationDocumentUseDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonalInformationVerificationDescriptor { get; set; }

        // Non-PK properties
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        string IssuerCountryDescriptor { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceRace model.
    /// </summary>
    public interface IRecruitmentEventAttendanceRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendance RecruitmentEventAttendance { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications model.
    /// </summary>
    public interface IRecruitmentEventAttendanceRecruitmentEventAttendeeQualifications : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendance RecruitmentEventAttendance { get; set; }

        // Non-PK properties
        bool? CapacityToServe { get; set; }
        bool Eligible { get; set; }
        decimal? YearsOfServiceCurrentPlacement { get; set; }
        decimal YearsOfServiceTotal { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceTelephone model.
    /// </summary>
    public interface IRecruitmentEventAttendanceTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendance RecruitmentEventAttendance { get; set; }
        [NaturalKeyMember]
        string TelephoneNumber { get; set; }
        [NaturalKeyMember]
        string TelephoneNumberTypeDescriptor { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendanceTouchpoint model.
    /// </summary>
    public interface IRecruitmentEventAttendanceTouchpoint : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRecruitmentEventAttendance RecruitmentEventAttendance { get; set; }
        [NaturalKeyMember]
        string TouchpointContent { get; set; }
        [NaturalKeyMember]
        DateTime TouchpointDate { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventAttendeeTypeDescriptor model.
    /// </summary>
    public interface IRecruitmentEventAttendeeTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RecruitmentEventAttendeeTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecruitmentEventTypeDescriptor model.
    /// </summary>
    public interface IRecruitmentEventTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RecruitmentEventTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricDimension model.
    /// </summary>
    public interface IRubricDimension : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationElementTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        int RubricRating { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string CriterionDescription { get; set; }
        int? DimensionOrder { get; set; }
        string RubricRatingLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluationElementResourceId { get; set; }
        string EvaluationElementDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricRatingLevelDescriptor model.
    /// </summary>
    public interface IRubricRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RubricRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SalaryTypeDescriptor model.
    /// </summary>
    public interface ISalaryTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SalaryTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolExtension model.
    /// </summary>
    public interface ISchoolExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ISchool School { get; set; }

        // Non-PK properties
        string AccreditationStatusDescriptor { get; set; }
        string FederalLocaleCodeDescriptor { get; set; }
        bool? ImprovingSchool { get; set; }
        int? PostSecondaryInstitutionId { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PostSecondaryInstitutionResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationAssignmentAssociationExtension model.
    /// </summary>
    public interface IStaffEducationOrganizationAssignmentAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStaffEducationOrganizationAssignmentAssociation StaffEducationOrganizationAssignmentAssociation { get; set; }

        // Non-PK properties
        decimal? YearsOfExperienceAtCurrentEducationOrganization { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationEmploymentAssociationBackgroundCheck model.
    /// </summary>
    public interface IStaffEducationOrganizationEmploymentAssociationBackgroundCheck : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEducationOrganizationEmploymentAssociationExtension StaffEducationOrganizationEmploymentAssociationExtension { get; set; }
        [NaturalKeyMember]
        string BackgroundCheckTypeDescriptor { get; set; }

        // Non-PK properties
        DateTime? BackgroundCheckCompletedDate { get; set; }
        DateTime BackgroundCheckRequestedDate { get; set; }
        string BackgroundCheckStatusDescriptor { get; set; }
        bool? Fingerprint { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationEmploymentAssociationExtension model.
    /// </summary>
    public interface IStaffEducationOrganizationEmploymentAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStaffEducationOrganizationEmploymentAssociation StaffEducationOrganizationEmploymentAssociation { get; set; }

        // Non-PK properties
        string LengthOfContractDescriptor { get; set; }
        DateTime? ProbationCompleteDate { get; set; }
        bool? Tenured { get; set; }
        bool? TenureTrack { get; set; }

        // One-to-one relationships

        IStaffEducationOrganizationEmploymentAssociationSalary StaffEducationOrganizationEmploymentAssociationSalary { get; set; }

        // Lists
        ICollection<IStaffEducationOrganizationEmploymentAssociationBackgroundCheck> StaffEducationOrganizationEmploymentAssociationBackgroundChecks { get; set; }
        ICollection<IStaffEducationOrganizationEmploymentAssociationSeniority> StaffEducationOrganizationEmploymentAssociationSeniorities { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationEmploymentAssociationSalary model.
    /// </summary>
    public interface IStaffEducationOrganizationEmploymentAssociationSalary : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEducationOrganizationEmploymentAssociationExtension StaffEducationOrganizationEmploymentAssociationExtension { get; set; }

        // Non-PK properties
        decimal? SalaryAmount { get; set; }
        int? SalaryMaxRange { get; set; }
        int? SalaryMinRange { get; set; }
        string SalaryTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationEmploymentAssociationSeniority model.
    /// </summary>
    public interface IStaffEducationOrganizationEmploymentAssociationSeniority : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEducationOrganizationEmploymentAssociationExtension StaffEducationOrganizationEmploymentAssociationExtension { get; set; }
        [NaturalKeyMember]
        string CredentialFieldDescriptor { get; set; }
        [NaturalKeyMember]
        string NameOfInstitution { get; set; }

        // Non-PK properties
        decimal YearsExperience { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducatorPreparationProgram model.
    /// </summary>
    public interface IStaffEducatorPreparationProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducatorPreparationProgramResourceId { get; set; }
        string EducatorPreparationProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducatorPreparationProgramAssociation model.
    /// </summary>
    public interface IStaffEducatorPreparationProgramAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime BeginDate { get; set; }
        bool? Completer { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducatorPreparationProgramResourceId { get; set; }
        string EducatorPreparationProgramDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducatorResearch model.
    /// </summary>
    public interface IStaffEducatorResearch : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }

        // Non-PK properties
        DateTime ResearchExperienceDate { get; set; }
        string ResearchExperienceDescription { get; set; }
        string ResearchExperienceTitle { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffExtension model.
    /// </summary>
    public interface IStaffExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStaff Staff { get; set; }

        // Non-PK properties
        int? EducationOrganizationId { get; set; }
        string GenderDescriptor { get; set; }
        string RequisitionNumber { get; set; }

        // One-to-one relationships

        IStaffEducatorResearch StaffEducatorResearch { get; set; }

        // Lists
        ICollection<IStaffEducatorPreparationProgram> StaffEducatorPreparationPrograms { get; set; }
        ICollection<IStaffHighlyQualifiedAcademicSubject> StaffHighlyQualifiedAcademicSubjects { get; set; }

        // Resource reference data
        Guid? OpenStaffPositionResourceId { get; set; }
        string OpenStaffPositionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffHighlyQualifiedAcademicSubject model.
    /// </summary>
    public interface IStaffHighlyQualifiedAcademicSubject : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffToCandidateRelationshipDescriptor model.
    /// </summary>
    public interface IStaffToCandidateRelationshipDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StaffToCandidateRelationshipDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StateEducationAgencyExtension model.
    /// </summary>
    public interface IStateEducationAgencyExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStateEducationAgency StateEducationAgency { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGradebookEntryExtension model.
    /// </summary>
    public interface IStudentGradebookEntryExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentGradebookEntry StudentGradebookEntry { get; set; }

        // Non-PK properties
        bool? AssignmentPassed { get; set; }
        DateTime? DateCompleted { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponseExtension model.
    /// </summary>
    public interface ISurveyResponseExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ISurveyResponse SurveyResponse { get; set; }

        // Non-PK properties
        string PersonId { get; set; }
        string SourceSystemDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponsePersonTargetAssociation model.
    /// </summary>
    public interface ISurveyResponsePersonTargetAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
        Guid? SurveyResponseResourceId { get; set; }
        string SurveyResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionAggregateResponse model.
    /// </summary>
    public interface ISurveySectionAggregateResponse : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EvaluationDate { get; set; }
        [NaturalKeyMember]
        string EvaluationElementTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationObjectiveTitle { get; set; }
        [NaturalKeyMember]
        string EvaluationPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        string EvaluationTitle { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string PerformanceEvaluationTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveySectionTitle { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        decimal ScoreValue { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluationElementRatingResourceId { get; set; }
        string EvaluationElementRatingDiscriminator { get; set; }
        Guid? SurveySectionResourceId { get; set; }
        string SurveySectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionExtension model.
    /// </summary>
    public interface ISurveySectionExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ISurveySection SurveySection { get; set; }

        // Non-PK properties
        int? EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        string EvaluationPeriodDescriptor { get; set; }
        string EvaluationTitle { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        string PerformanceEvaluationTypeDescriptor { get; set; }
        short? SchoolYear { get; set; }
        string TermDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluationElementResourceId { get; set; }
        string EvaluationElementDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionResponsePersonTargetAssociation model.
    /// </summary>
    public interface ISurveySectionResponsePersonTargetAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveySectionTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
        Guid? SurveySectionResponseResourceId { get; set; }
        string SurveySectionResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the WithdrawReasonDescriptor model.
    /// </summary>
    public interface IWithdrawReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int WithdrawReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }
}
