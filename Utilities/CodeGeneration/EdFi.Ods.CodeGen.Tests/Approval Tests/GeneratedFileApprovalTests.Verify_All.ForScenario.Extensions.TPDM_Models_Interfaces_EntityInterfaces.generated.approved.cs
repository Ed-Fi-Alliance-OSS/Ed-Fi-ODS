using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common;
#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.TPDM
{ 

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
    /// Defines available properties and methods for the abstraction of the AnonymizedStudent model.
    /// </summary>
    public interface IAnonymizedStudent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        bool? AtriskIndicator { get; set; }
        bool? ELLEnrollment { get; set; }
        bool? ESLEnrollment { get; set; }
        string GenderDescriptor { get; set; }
        string GradeLevelDescriptor { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        int? Mobility { get; set; }
        bool? Section504Enrollment { get; set; }
        string SexDescriptor { get; set; }
        bool? SPEDEnrollment { get; set; }
        bool? TitleIEnrollment { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IAnonymizedStudentDisability> AnonymizedStudentDisabilities { get; set; }
        ICollection<IAnonymizedStudentLanguage> AnonymizedStudentLanguages { get; set; }
        ICollection<IAnonymizedStudentRace> AnonymizedStudentRaces { get; set; }

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentAcademicRecord model.
    /// </summary>
    public interface IAnonymizedStudentAcademicRecord : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        decimal? CumulativeGradePointAverage { get; set; }
        decimal? GPAMax { get; set; }
        decimal? SessionGradePointAverage { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentResourceId { get; set; }
        string AnonymizedStudentDiscriminator { get; set; }
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentAssessment model.
    /// </summary>
    public interface IAnonymizedStudentAssessment : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AdministrationDate { get; set; }
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        short TakenSchoolYear { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string AssessmentCategoryDescriptor { get; set; }
        string AssessmentTitle { get; set; }
        string GradeLevelDescriptor { get; set; }
        string TermDescriptor { get; set; }

        // One-to-one relationships

        IAnonymizedStudentAssessmentPerformanceLevel AnonymizedStudentAssessmentPerformanceLevel { get; set; }

        IAnonymizedStudentAssessmentScoreResult AnonymizedStudentAssessmentScoreResult { get; set; }

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentResourceId { get; set; }
        string AnonymizedStudentDiscriminator { get; set; }
        Guid? TakenSchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentAssessmentCourseAssociation model.
    /// </summary>
    public interface IAnonymizedStudentAssessmentCourseAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AdministrationDate { get; set; }
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        short TakenSchoolYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentAssessmentResourceId { get; set; }
        string AnonymizedStudentAssessmentDiscriminator { get; set; }
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentAssessmentPerformanceLevel model.
    /// </summary>
    public interface IAnonymizedStudentAssessmentPerformanceLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAnonymizedStudentAssessment AnonymizedStudentAssessment { get; set; }

        // Non-PK properties
        string AssessmentReportingMethodDescriptor { get; set; }
        string PerformanceLevelDescriptor { get; set; }
        bool PerformanceLevelMet { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentAssessmentScoreResult model.
    /// </summary>
    public interface IAnonymizedStudentAssessmentScoreResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAnonymizedStudentAssessment AnonymizedStudentAssessment { get; set; }

        // Non-PK properties
        string AssessmentReportingMethodDescriptor { get; set; }
        string Result { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentAssessmentSectionAssociation model.
    /// </summary>
    public interface IAnonymizedStudentAssessmentSectionAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AdministrationDate { get; set; }
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
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
        short TakenSchoolYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentAssessmentResourceId { get; set; }
        string AnonymizedStudentAssessmentDiscriminator { get; set; }
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentCourseAssociation model.
    /// </summary>
    public interface IAnonymizedStudentCourseAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentResourceId { get; set; }
        string AnonymizedStudentDiscriminator { get; set; }
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentCourseTranscript model.
    /// </summary>
    public interface IAnonymizedStudentCourseTranscript : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string CourseRepeatCodeDescriptor { get; set; }
        string CourseTitle { get; set; }
        string FinalLetterGradeEarned { get; set; }
        decimal? FinalNumericGradeEarned { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentAcademicRecordResourceId { get; set; }
        string AnonymizedStudentAcademicRecordDiscriminator { get; set; }
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentDisability model.
    /// </summary>
    public interface IAnonymizedStudentDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAnonymizedStudent AnonymizedStudent { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IAnonymizedStudentDisabilityDesignation> AnonymizedStudentDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentDisabilityDesignation model.
    /// </summary>
    public interface IAnonymizedStudentDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAnonymizedStudentDisability AnonymizedStudentDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentEducationOrganizationAssociation model.
    /// </summary>
    public interface IAnonymizedStudentEducationOrganizationAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentResourceId { get; set; }
        string AnonymizedStudentDiscriminator { get; set; }
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentLanguage model.
    /// </summary>
    public interface IAnonymizedStudentLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAnonymizedStudent AnonymizedStudent { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IAnonymizedStudentLanguageUse> AnonymizedStudentLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentLanguageUse model.
    /// </summary>
    public interface IAnonymizedStudentLanguageUse : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAnonymizedStudentLanguage AnonymizedStudentLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentRace model.
    /// </summary>
    public interface IAnonymizedStudentRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAnonymizedStudent AnonymizedStudent { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AnonymizedStudentSectionAssociation model.
    /// </summary>
    public interface IAnonymizedStudentSectionAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AnonymizedStudentIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
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

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AnonymizedStudentResourceId { get; set; }
        string AnonymizedStudentDiscriminator { get; set; }
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Applicant model.
    /// </summary>
    public interface IApplicant : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }

        // Non-PK properties
        DateTime? BirthDate { get; set; }
        string CitizenshipStatusDescriptor { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        string GenderDescriptor { get; set; }
        string GenerationCodeSuffix { get; set; }
        string HighestCompletedLevelOfEducationDescriptor { get; set; }
        string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        string SexDescriptor { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicantAddress> ApplicantAddresses { get; set; }
        ICollection<IApplicantAid> ApplicantAids { get; set; }
        ICollection<IApplicantBackgroundCheck> ApplicantBackgroundChecks { get; set; }
        ICollection<IApplicantCharacteristic> ApplicantCharacteristics { get; set; }
        ICollection<IApplicantCredential> ApplicantCredentials { get; set; }
        ICollection<IApplicantDisability> ApplicantDisabilities { get; set; }
        ICollection<IApplicantElectronicMail> ApplicantElectronicMails { get; set; }
        ICollection<IApplicantGradePointAverage> ApplicantGradePointAverages { get; set; }
        ICollection<IApplicantIdentificationDocument> ApplicantIdentificationDocuments { get; set; }
        ICollection<IApplicantInternationalAddress> ApplicantInternationalAddresses { get; set; }
        ICollection<IApplicantLanguage> ApplicantLanguages { get; set; }
        ICollection<IApplicantPersonalIdentificationDocument> ApplicantPersonalIdentificationDocuments { get; set; }
        ICollection<IApplicantRace> ApplicantRaces { get; set; }
        ICollection<IApplicantScoreResult> ApplicantScoreResults { get; set; }
        ICollection<IApplicantStaffIdentificationCode> ApplicantStaffIdentificationCodes { get; set; }
        ICollection<IApplicantTeacherPreparationProgram> ApplicantTeacherPreparationPrograms { get; set; }
        ICollection<IApplicantTelephone> ApplicantTelephones { get; set; }
        ICollection<IApplicantVisa> ApplicantVisas { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantAddress model.
    /// </summary>
    public interface IApplicantAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
        ICollection<IApplicantAddressPeriod> ApplicantAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantAddressPeriod model.
    /// </summary>
    public interface IApplicantAddressPeriod : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantAddress ApplicantAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantAid model.
    /// </summary>
    public interface IApplicantAid : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantBackgroundCheck model.
    /// </summary>
    public interface IApplicantBackgroundCheck : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantCharacteristic model.
    /// </summary>
    public interface IApplicantCharacteristic : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantCredential model.
    /// </summary>
    public interface IApplicantCredential : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
        [NaturalKeyMember]
        string CredentialIdentifier { get; set; }
        [NaturalKeyMember]
        string StateOfIssueStateAbbreviationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CredentialResourceId { get; set; }
        string CredentialDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantDisability model.
    /// </summary>
    public interface IApplicantDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicantDisabilityDesignation> ApplicantDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantDisabilityDesignation model.
    /// </summary>
    public interface IApplicantDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantDisability ApplicantDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantElectronicMail model.
    /// </summary>
    public interface IApplicantElectronicMail : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantGradePointAverage model.
    /// </summary>
    public interface IApplicantGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantIdentificationDocument model.
    /// </summary>
    public interface IApplicantIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantInternationalAddress model.
    /// </summary>
    public interface IApplicantInternationalAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantLanguage model.
    /// </summary>
    public interface IApplicantLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IApplicantLanguageUse> ApplicantLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantLanguageUse model.
    /// </summary>
    public interface IApplicantLanguageUse : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicantLanguage ApplicantLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantPersonalIdentificationDocument model.
    /// </summary>
    public interface IApplicantPersonalIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantProspectAssociation model.
    /// </summary>
    public interface IApplicantProspectAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProspectIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ApplicantResourceId { get; set; }
        string ApplicantDiscriminator { get; set; }
        Guid? ProspectResourceId { get; set; }
        string ProspectDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantRace model.
    /// </summary>
    public interface IApplicantRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantScoreResult model.
    /// </summary>
    public interface IApplicantScoreResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantStaffIdentificationCode model.
    /// </summary>
    public interface IApplicantStaffIdentificationCode : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
        [NaturalKeyMember]
        string StaffIdentificationSystemDescriptor { get; set; }

        // Non-PK properties
        string AssigningOrganizationIdentificationCode { get; set; }
        string IdentificationCode { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantTeacherPreparationProgram model.
    /// </summary>
    public interface IApplicantTeacherPreparationProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
        [NaturalKeyMember]
        string TeacherPreparationProgramName { get; set; }

        // Non-PK properties
        decimal? GPA { get; set; }
        string LevelOfDegreeAwardedDescriptor { get; set; }
        string MajorSpecialization { get; set; }
        string NameOfInstitution { get; set; }
        string TeacherPreparationProgramIdentifier { get; set; }
        string TeacherPreparationProgramTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantTelephone model.
    /// </summary>
    public interface IApplicantTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicantVisa model.
    /// </summary>
    public interface IApplicantVisa : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
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
        string ApplicantIdentifier { get; set; }
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
        DateTime? WithdrawDate { get; set; }
        string WithdrawReasonDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicationOpenStaffPosition> ApplicationOpenStaffPositions { get; set; }
        ICollection<IApplicationTerm> ApplicationTerms { get; set; }

        // Resource reference data
        Guid? ApplicantResourceId { get; set; }
        string ApplicantDiscriminator { get; set; }
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicationEvent model.
    /// </summary>
    public interface IApplicationEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantIdentifier { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicationOpenStaffPosition model.
    /// </summary>
    public interface IApplicationOpenStaffPosition : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplication Application { get; set; }
        [NaturalKeyMember]
        string RequisitionNumber { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? OpenStaffPositionResourceId { get; set; }
        string OpenStaffPositionDiscriminator { get; set; }
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
    /// Defines available properties and methods for the abstraction of the BoardCertificationTypeDescriptor model.
    /// </summary>
    public interface IBoardCertificationTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int BoardCertificationTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
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
    /// Defines available properties and methods for the abstraction of the CommunityOrganizationExtension model.
    /// </summary>
    public interface ICommunityOrganizationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ICommunityOrganization CommunityOrganization { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CommunityProviderExtension model.
    /// </summary>
    public interface ICommunityProviderExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ICommunityProvider CommunityProvider { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CompleterAsStaffAssociation model.
    /// </summary>
    public interface ICompleterAsStaffAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
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
    /// Defines available properties and methods for the abstraction of the CourseCourseTranscriptFacts model.
    /// </summary>
    public interface ICourseCourseTranscriptFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string CourseTitle { get; set; }

        // One-to-one relationships

        ICourseCourseTranscriptFactsAggregatedNumericGradeEarned CourseCourseTranscriptFactsAggregatedNumericGradeEarned { get; set; }

        ICourseCourseTranscriptFactsStudentsEnrolled CourseCourseTranscriptFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<ICourseCourseTranscriptFactsAggregatedFinalLetterGradeEarned> CourseCourseTranscriptFactsAggregatedFinalLetterGradeEarneds { get; set; }

        // Resource reference data
        Guid? CourseStudentAcademicRecordFactsResourceId { get; set; }
        string CourseStudentAcademicRecordFactsDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseCourseTranscriptFactsAggregatedFinalLetterGradeEarned model.
    /// </summary>
    public interface ICourseCourseTranscriptFactsAggregatedFinalLetterGradeEarned : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseCourseTranscriptFacts CourseCourseTranscriptFacts { get; set; }
        [NaturalKeyMember]
        string FinalLetterGrade { get; set; }

        // Non-PK properties
        int? LetterGradeTypeNumber { get; set; }
        decimal? LetterGradeTypePercentage { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseCourseTranscriptFactsAggregatedNumericGradeEarned model.
    /// </summary>
    public interface ICourseCourseTranscriptFactsAggregatedNumericGradeEarned : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseCourseTranscriptFacts CourseCourseTranscriptFacts { get; set; }

        // Non-PK properties
        decimal AverageFinalNumericGradeEarned { get; set; }
        int? NumericGradeNCount { get; set; }
        int? NumericGradeStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseCourseTranscriptFactsStudentsEnrolled model.
    /// </summary>
    public interface ICourseCourseTranscriptFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseCourseTranscriptFacts CourseCourseTranscriptFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAcademicRecordFacts model.
    /// </summary>
    public interface ICourseStudentAcademicRecordFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        decimal? AggregatedGPAMax { get; set; }

        // One-to-one relationships

        ICourseStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage CourseStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage { get; set; }

        ICourseStudentAcademicRecordFactsAggregatedSessionGradePointAverage CourseStudentAcademicRecordFactsAggregatedSessionGradePointAverage { get; set; }

        ICourseStudentAcademicRecordFactsStudentsEnrolled CourseStudentAcademicRecordFactsStudentsEnrolled { get; set; }

        // Lists

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage model.
    /// </summary>
    public interface ICourseStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentAcademicRecordFacts CourseStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAcademicRecordFactsAggregatedSessionGradePointAverage model.
    /// </summary>
    public interface ICourseStudentAcademicRecordFactsAggregatedSessionGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentAcademicRecordFacts CourseStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAcademicRecordFactsStudentsEnrolled model.
    /// </summary>
    public interface ICourseStudentAcademicRecordFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentAcademicRecordFacts CourseStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAssessmentFacts model.
    /// </summary>
    public interface ICourseStudentAssessmentFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short TakenSchoolYear { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        DateTime? AdministrationDate { get; set; }
        string AssessmentCategoryDescriptor { get; set; }
        string AssessmentTitle { get; set; }
        string GradeLevelDescriptor { get; set; }
        string TermDescriptor { get; set; }

        // One-to-one relationships

        ICourseStudentAssessmentFactsAggregatedScoreResult CourseStudentAssessmentFactsAggregatedScoreResult { get; set; }

        ICourseStudentAssessmentFactsStudentsEnrolled CourseStudentAssessmentFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<ICourseStudentAssessmentFactsAggregatedPerformanceLevel> CourseStudentAssessmentFactsAggregatedPerformanceLevels { get; set; }

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? TakenSchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAssessmentFactsAggregatedPerformanceLevel model.
    /// </summary>
    public interface ICourseStudentAssessmentFactsAggregatedPerformanceLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentAssessmentFacts CourseStudentAssessmentFacts { get; set; }
        [NaturalKeyMember]
        string PerformanceLevelDescriptor { get; set; }

        // Non-PK properties
        int? PerformanceLevelMetNumber { get; set; }
        decimal? PerformanceLevelMetPercentage { get; set; }
        int? PerformanceLevelTypeNumber { get; set; }
        decimal? PerformanceLevelTypePercentage { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAssessmentFactsAggregatedScoreResult model.
    /// </summary>
    public interface ICourseStudentAssessmentFactsAggregatedScoreResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentAssessmentFacts CourseStudentAssessmentFacts { get; set; }

        // Non-PK properties
        string AssessmentReportingMethodDescriptor { get; set; }
        string AverageScoreResult { get; set; }
        string AverageScoreResultDatatypeTypeDescriptor { get; set; }
        int? ScoreNCount { get; set; }
        int? ScoreStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentAssessmentFactsStudentsEnrolled model.
    /// </summary>
    public interface ICourseStudentAssessmentFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentAssessmentFacts CourseStudentAssessmentFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFacts model.
    /// </summary>
    public interface ICourseStudentFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }

        // Non-PK properties

        // One-to-one relationships

        ICourseStudentFactsAggregatedDisabilityTotalStudentsDisabled CourseStudentFactsAggregatedDisabilityTotalStudentsDisabled { get; set; }

        ICourseStudentFactsAggregatedELLEnrollment CourseStudentFactsAggregatedELLEnrollment { get; set; }

        ICourseStudentFactsAggregatedESLEnrollment CourseStudentFactsAggregatedESLEnrollment { get; set; }

        ICourseStudentFactsAggregatedSection504Enrollment CourseStudentFactsAggregatedSection504Enrollment { get; set; }

        ICourseStudentFactsAggregatedSPED CourseStudentFactsAggregatedSPED { get; set; }

        ICourseStudentFactsAggregatedTitleIEnrollment CourseStudentFactsAggregatedTitleIEnrollment { get; set; }

        ICourseStudentFactsStudentsEnrolled CourseStudentFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<ICourseStudentFactsAggregatedByDisability> CourseStudentFactsAggregatedByDisabilities { get; set; }
        ICollection<ICourseStudentFactsAggregatedGender> CourseStudentFactsAggregatedGenders { get; set; }
        ICollection<ICourseStudentFactsAggregatedHispanicLatinoEthnicity> CourseStudentFactsAggregatedHispanicLatinoEthnicities { get; set; }
        ICollection<ICourseStudentFactsAggregatedLanguage> CourseStudentFactsAggregatedLanguages { get; set; }
        ICollection<ICourseStudentFactsAggregatedRace> CourseStudentFactsAggregatedRaces { get; set; }
        ICollection<ICourseStudentFactsAggregatedSchoolFoodServiceProgramService> CourseStudentFactsAggregatedSchoolFoodServiceProgramServices { get; set; }
        ICollection<ICourseStudentFactsAggregatedSex> CourseStudentFactsAggregatedSexes { get; set; }

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedByDisability model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedByDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        decimal? Percentage { get; set; }
        int? TypeNumber { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedDisabilityTotalStudentsDisabled model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedDisabilityTotalStudentsDisabled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }

        // Non-PK properties
        int? StudentsDisabledNumber { get; set; }
        decimal? StudentsDisabledPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedELLEnrollment model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedELLEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }

        // Non-PK properties
        int? ELLEnrollmentNumber { get; set; }
        decimal? ELLEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedESLEnrollment model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedESLEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }

        // Non-PK properties
        int? ESLEnrollmentNumber { get; set; }
        decimal? ESLEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedGender model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedGender : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }
        [NaturalKeyMember]
        string GenderDescriptor { get; set; }

        // Non-PK properties
        int? GenderTypeNumber { get; set; }
        decimal? GenderTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedHispanicLatinoEthnicity model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedHispanicLatinoEthnicity : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }
        [NaturalKeyMember]
        bool HispanicLatinoEthnicity { get; set; }

        // Non-PK properties
        int? HispanicLatinoEthnicityNumber { get; set; }
        decimal? HispanicLatinoEthnicityPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedLanguage model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties
        int? LanguageTypeNumber { get; set; }
        decimal? LanguageTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedRace model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties
        int? RaceTypeNumber { get; set; }
        decimal? RaceTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedSchoolFoodServiceProgramService model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSchoolFoodServiceProgramService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }
        [NaturalKeyMember]
        string SchoolFoodServiceProgramServiceDescriptor { get; set; }

        // Non-PK properties
        int? TypeNumber { get; set; }
        int? TypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedSection504Enrollment model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSection504Enrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }

        // Non-PK properties
        int? Number504Enrolled { get; set; }
        decimal? Percentage504Enrolled { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedSex model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSex : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }
        [NaturalKeyMember]
        string SexDescriptor { get; set; }

        // Non-PK properties
        int? SexTypeNumber { get; set; }
        decimal? SexTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedSPED model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSPED : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }

        // Non-PK properties
        int? SPEDEnrollmentNumber { get; set; }
        decimal? SPEDEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsAggregatedTitleIEnrollment model.
    /// </summary>
    public interface ICourseStudentFactsAggregatedTitleIEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }

        // Non-PK properties
        int? TitleIEnrollmentNumber { get; set; }
        decimal? TitleIEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseStudentFactsStudentsEnrolled model.
    /// </summary>
    public interface ICourseStudentFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseStudentFacts CourseStudentFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialBoardCertification model.
    /// </summary>
    public interface ICredentialBoardCertification : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredentialExtension CredentialExtension { get; set; }

        // Non-PK properties
        bool? BoardCertification { get; set; }
        DateTime? BoardCertificationDate { get; set; }
        string BoardCertificationTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialCertificationExam model.
    /// </summary>
    public interface ICredentialCertificationExam : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredentialExtension CredentialExtension { get; set; }
        [NaturalKeyMember]
        string CertificationExamTitle { get; set; }

        // Non-PK properties
        int? AttemptNumber { get; set; }
        DateTime CertificationExamDate { get; set; }
        int? CertificationExamOverallScore { get; set; }
        bool? CertificationExamPassFail { get; set; }
        string CertificationExamStatusDescriptor { get; set; }
        string CertificationExamTypeDescriptor { get; set; }

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
        bool? CurrentCredential { get; set; }
        DateTime? RevocationDate { get; set; }
        string RevocationReason { get; set; }
        DateTime? SuspensionDate { get; set; }
        string SuspensionReason { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        ICredentialBoardCertification CredentialBoardCertification { get; set; }

        ICredentialRecommendation CredentialRecommendation { get; set; }

        ICredentialRecommendingInstitution CredentialRecommendingInstitution { get; set; }

        // Lists
        ICollection<ICredentialCertificationExam> CredentialCertificationExams { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialRecommendation model.
    /// </summary>
    public interface ICredentialRecommendation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredentialExtension CredentialExtension { get; set; }

        // Non-PK properties
        string CredentialFieldDescriptor { get; set; }
        string GradeLevelDescriptor { get; set; }
        string TeachingCredentialDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialRecommendingInstitution model.
    /// </summary>
    public interface ICredentialRecommendingInstitution : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredentialExtension CredentialExtension { get; set; }

        // Non-PK properties
        DateTime? RecommendingDate { get; set; }
        string RecommendingInstitutionCountryDescriptor { get; set; }
        string RecommendingInstitutionStateAbbreviationDescriptor { get; set; }
        string RecommendingInstutionName { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationCourseTranscriptFacts model.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string CourseTitle { get; set; }

        // One-to-one relationships

        IEducationOrganizationCourseTranscriptFactsAggregatedNumericGradeEarned EducationOrganizationCourseTranscriptFactsAggregatedNumericGradeEarned { get; set; }

        IEducationOrganizationCourseTranscriptFactsStudentsEnrolled EducationOrganizationCourseTranscriptFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<IEducationOrganizationCourseTranscriptFactsAggregatedFinalLetterGradeEarned> EducationOrganizationCourseTranscriptFactsAggregatedFinalLetterGradeEarneds { get; set; }

        // Resource reference data
        Guid? EducationOrganizationStudentAcademicRecordFactsResourceId { get; set; }
        string EducationOrganizationStudentAcademicRecordFactsDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationCourseTranscriptFactsAggregatedFinalLetterGradeEarned model.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFactsAggregatedFinalLetterGradeEarned : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationCourseTranscriptFacts EducationOrganizationCourseTranscriptFacts { get; set; }
        [NaturalKeyMember]
        string FinalLetterGrade { get; set; }

        // Non-PK properties
        int? LetterGradeTypeNumber { get; set; }
        decimal? LetterGradeTypePercentage { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationCourseTranscriptFactsAggregatedNumericGradeEarned model.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFactsAggregatedNumericGradeEarned : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationCourseTranscriptFacts EducationOrganizationCourseTranscriptFacts { get; set; }

        // Non-PK properties
        decimal AverageFinalNumericGradeEarned { get; set; }
        int? NumericGradeNCount { get; set; }
        int? NumericGradeStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationCourseTranscriptFactsStudentsEnrolled model.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationCourseTranscriptFacts EducationOrganizationCourseTranscriptFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationFacts model.
    /// </summary>
    public interface IEducationOrganizationFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        decimal? AverageYearsInDistrictEmployed { get; set; }
        decimal? HiringRate { get; set; }
        int? NumberAdministratorsEmployed { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        int? NumberTeachersEmployed { get; set; }
        decimal? PercentStudentsFreeReducedLunch { get; set; }
        decimal? PercentStudentsLimitedEnglishProficiency { get; set; }
        decimal? PercentStudentsSpecialEducation { get; set; }
        decimal? RetentionRate { get; set; }
        decimal? RetirementRate { get; set; }

        // One-to-one relationships

        IEducationOrganizationFactsAggregatedSalary EducationOrganizationFactsAggregatedSalary { get; set; }

        // Lists
        ICollection<IEducationOrganizationFactsVacancies> EducationOrganizationFactsVacancies { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationFactsAggregatedSalary model.
    /// </summary>
    public interface IEducationOrganizationFactsAggregatedSalary : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationFacts EducationOrganizationFacts { get; set; }

        // Non-PK properties
        decimal AverageSalary { get; set; }
        int? CountOfSalariesAveraged { get; set; }
        int? SalaryMaxRange { get; set; }
        int? SalaryMinRange { get; set; }
        int? StandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationFactsVacancies model.
    /// </summary>
    public interface IEducationOrganizationFactsVacancies : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationFacts EducationOrganizationFacts { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties
        int NumberOfVacancies { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEducationOrganizationFactsVacanciesGradeLevel> EducationOrganizationFactsVacanciesGradeLevels { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationFactsVacanciesGradeLevel model.
    /// </summary>
    public interface IEducationOrganizationFactsVacanciesGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationFactsVacancies EducationOrganizationFactsVacancies { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationNetworkExtension model.
    /// </summary>
    public interface IEducationOrganizationNetworkExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IEducationOrganizationNetwork EducationOrganizationNetwork { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAcademicRecordFacts model.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        decimal? AggregatedGPAMax { get; set; }

        // One-to-one relationships

        IEducationOrganizationStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage EducationOrganizationStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage { get; set; }

        IEducationOrganizationStudentAcademicRecordFactsAggregatedSessionGradePointAverage EducationOrganizationStudentAcademicRecordFactsAggregatedSessionGradePointAverage { get; set; }

        IEducationOrganizationStudentAcademicRecordFactsStudentsEnrolled EducationOrganizationStudentAcademicRecordFactsStudentsEnrolled { get; set; }

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage model.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentAcademicRecordFacts EducationOrganizationStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAcademicRecordFactsAggregatedSessionGradePointAverage model.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFactsAggregatedSessionGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentAcademicRecordFacts EducationOrganizationStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAcademicRecordFactsStudentsEnrolled model.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentAcademicRecordFacts EducationOrganizationStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAssessmentFacts model.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short TakenSchoolYear { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        DateTime? AdministrationDate { get; set; }
        string AssessmentCategoryDescriptor { get; set; }
        string AssessmentTitle { get; set; }
        string GradeLevelDescriptor { get; set; }
        string TermDescriptor { get; set; }

        // One-to-one relationships

        IEducationOrganizationStudentAssessmentFactsAggregatedScoreResult EducationOrganizationStudentAssessmentFactsAggregatedScoreResult { get; set; }

        IEducationOrganizationStudentAssessmentFactsStudentsEnrolled EducationOrganizationStudentAssessmentFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<IEducationOrganizationStudentAssessmentFactsAggregatedPerformanceLevel> EducationOrganizationStudentAssessmentFactsAggregatedPerformanceLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? TakenSchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAssessmentFactsAggregatedPerformanceLevel model.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFactsAggregatedPerformanceLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentAssessmentFacts EducationOrganizationStudentAssessmentFacts { get; set; }
        [NaturalKeyMember]
        string PerformanceLevelDescriptor { get; set; }

        // Non-PK properties
        int? PerformanceLevelMetNumber { get; set; }
        decimal? PerformanceLevelMetPercentage { get; set; }
        int? PerformanceLevelTypeNumber { get; set; }
        decimal? PerformanceLevelTypePercentage { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAssessmentFactsAggregatedScoreResult model.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFactsAggregatedScoreResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentAssessmentFacts EducationOrganizationStudentAssessmentFacts { get; set; }

        // Non-PK properties
        string AssessmentReportingMethodDescriptor { get; set; }
        string AverageScoreResult { get; set; }
        string AverageScoreResultDatatypeTypeDescriptor { get; set; }
        int? ScoreNCount { get; set; }
        int? ScoreStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentAssessmentFactsStudentsEnrolled model.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentAssessmentFacts EducationOrganizationStudentAssessmentFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFacts model.
    /// </summary>
    public interface IEducationOrganizationStudentFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }

        // Non-PK properties

        // One-to-one relationships

        IEducationOrganizationStudentFactsAggregatedDisabilityTotalStudentsDisabled EducationOrganizationStudentFactsAggregatedDisabilityTotalStudentsDisabled { get; set; }

        IEducationOrganizationStudentFactsAggregatedELLEnrollment EducationOrganizationStudentFactsAggregatedELLEnrollment { get; set; }

        IEducationOrganizationStudentFactsAggregatedESLEnrollment EducationOrganizationStudentFactsAggregatedESLEnrollment { get; set; }

        IEducationOrganizationStudentFactsAggregatedSection504Enrollment EducationOrganizationStudentFactsAggregatedSection504Enrollment { get; set; }

        IEducationOrganizationStudentFactsAggregatedSPED EducationOrganizationStudentFactsAggregatedSPED { get; set; }

        IEducationOrganizationStudentFactsAggregatedTitleIEnrollment EducationOrganizationStudentFactsAggregatedTitleIEnrollment { get; set; }

        IEducationOrganizationStudentFactsStudentsEnrolled EducationOrganizationStudentFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<IEducationOrganizationStudentFactsAggregatedByDisability> EducationOrganizationStudentFactsAggregatedByDisabilities { get; set; }
        ICollection<IEducationOrganizationStudentFactsAggregatedGender> EducationOrganizationStudentFactsAggregatedGenders { get; set; }
        ICollection<IEducationOrganizationStudentFactsAggregatedHispanicLatinoEthnicity> EducationOrganizationStudentFactsAggregatedHispanicLatinoEthnicities { get; set; }
        ICollection<IEducationOrganizationStudentFactsAggregatedLanguage> EducationOrganizationStudentFactsAggregatedLanguages { get; set; }
        ICollection<IEducationOrganizationStudentFactsAggregatedRace> EducationOrganizationStudentFactsAggregatedRaces { get; set; }
        ICollection<IEducationOrganizationStudentFactsAggregatedSchoolFoodServiceProgramService> EducationOrganizationStudentFactsAggregatedSchoolFoodServiceProgramServices { get; set; }
        ICollection<IEducationOrganizationStudentFactsAggregatedSex> EducationOrganizationStudentFactsAggregatedSexes { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedByDisability model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedByDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        decimal? Percentage { get; set; }
        int? TypeNumber { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedDisabilityTotalStudentsDisabled model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedDisabilityTotalStudentsDisabled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }

        // Non-PK properties
        int? StudentsDisabledNumber { get; set; }
        decimal? StudentsDisabledPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedELLEnrollment model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedELLEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }

        // Non-PK properties
        int? ELLEnrollmentNumber { get; set; }
        decimal? ELLEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedESLEnrollment model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedESLEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }

        // Non-PK properties
        int? ESLEnrollmentNumber { get; set; }
        decimal? ESLEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedGender model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedGender : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }
        [NaturalKeyMember]
        string GenderDescriptor { get; set; }

        // Non-PK properties
        int? GenderTypeNumber { get; set; }
        decimal? GenderTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedHispanicLatinoEthnicity model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedHispanicLatinoEthnicity : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }
        [NaturalKeyMember]
        bool HispanicLatinoEthnicity { get; set; }

        // Non-PK properties
        int? HispanicLatinoEthnicityNumber { get; set; }
        decimal? HispanicLatinoEthnicityPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedLanguage model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties
        int? LanguageTypeNumber { get; set; }
        decimal? LanguageTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedRace model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties
        int? RaceTypeNumber { get; set; }
        decimal? RaceTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedSchoolFoodServiceProgramService model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSchoolFoodServiceProgramService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }
        [NaturalKeyMember]
        string SchoolFoodServiceProgramServiceDescriptor { get; set; }

        // Non-PK properties
        int? TypeNumber { get; set; }
        int? TypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedSection504Enrollment model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSection504Enrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }

        // Non-PK properties
        int? Number504Enrolled { get; set; }
        decimal? Percentage504Enrolled { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedSex model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSex : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }
        [NaturalKeyMember]
        string SexDescriptor { get; set; }

        // Non-PK properties
        int? SexTypeNumber { get; set; }
        decimal? SexTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedSPED model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSPED : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }

        // Non-PK properties
        int? SPEDEnrollmentNumber { get; set; }
        decimal? SPEDEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsAggregatedTitleIEnrollment model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedTitleIEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }

        // Non-PK properties
        int? TitleIEnrollmentNumber { get; set; }
        decimal? TitleIEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationStudentFactsStudentsEnrolled model.
    /// </summary>
    public interface IEducationOrganizationStudentFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationStudentFacts EducationOrganizationStudentFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationServiceCenterExtension model.
    /// </summary>
    public interface IEducationServiceCenterExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IEducationServiceCenter EducationServiceCenter { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EmploymentEvent model.
    /// </summary>
    public interface IEmploymentEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EmploymentEventTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string RequisitionNumber { get; set; }

        // Non-PK properties
        bool? EarlyHire { get; set; }
        DateTime? HireDate { get; set; }
        string InternalExternalHireDescriptor { get; set; }
        bool? MutualConsent { get; set; }
        bool? RestrictedChoice { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? OpenStaffPositionResourceId { get; set; }
        string OpenStaffPositionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EmploymentEventTypeDescriptor model.
    /// </summary>
    public interface IEmploymentEventTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EmploymentEventTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EmploymentSeparationEvent model.
    /// </summary>
    public interface IEmploymentSeparationEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EmploymentSeparationDate { get; set; }
        [NaturalKeyMember]
        string RequisitionNumber { get; set; }

        // Non-PK properties
        DateTime? EmploymentSeparationEnteredDate { get; set; }
        string EmploymentSeparationReasonDescriptor { get; set; }
        string EmploymentSeparationTypeDescriptor { get; set; }
        bool? RemainingInDistrict { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? OpenStaffPositionResourceId { get; set; }
        string OpenStaffPositionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EmploymentSeparationReasonDescriptor model.
    /// </summary>
    public interface IEmploymentSeparationReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EmploymentSeparationReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EmploymentSeparationTypeDescriptor model.
    /// </summary>
    public interface IEmploymentSeparationTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EmploymentSeparationTypeDescriptorId { get; set; }

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
    /// Defines available properties and methods for the abstraction of the GradebookEntryExtension model.
    /// </summary>
    public interface IGradebookEntryExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IGradebookEntry GradebookEntry { get; set; }

        // Non-PK properties
        string ProgramGatewayDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
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
    /// Defines available properties and methods for the abstraction of the InternalExternalHireDescriptor model.
    /// </summary>
    public interface IInternalExternalHireDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InternalExternalHireDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LevelOfDegreeAwardedDescriptor model.
    /// </summary>
    public interface ILevelOfDegreeAwardedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LevelOfDegreeAwardedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LevelTypeDescriptor model.
    /// </summary>
    public interface ILevelTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LevelTypeDescriptorId { get; set; }

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
    /// Defines available properties and methods for the abstraction of the PerformanceMeasure model.
    /// </summary>
    public interface IPerformanceMeasure : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string PerformanceMeasureIdentifier { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        DateTime ActualDateOfPerformanceMeasure { get; set; }
        bool? Announced { get; set; }
        string Comments { get; set; }
        string CoteachingStyleObservedDescriptor { get; set; }
        int? DurationOfPerformanceMeasure { get; set; }
        string PerformanceMeasureInstanceDescriptor { get; set; }
        string PerformanceMeasureTypeDescriptor { get; set; }
        DateTime? ScheduleDateOfPerformanceMeasure { get; set; }
        string TermDescriptor { get; set; }
        TimeSpan? TimeOfPerformanceMeasure { get; set; }

        // One-to-one relationships

        IPerformanceMeasurePersonBeingReviewed PerformanceMeasurePersonBeingReviewed { get; set; }

        // Lists
        ICollection<IPerformanceMeasureGradeLevel> PerformanceMeasureGradeLevels { get; set; }
        ICollection<IPerformanceMeasureProgramGateway> PerformanceMeasureProgramGateways { get; set; }
        ICollection<IPerformanceMeasureReviewer> PerformanceMeasureReviewers { get; set; }
        ICollection<IPerformanceMeasureRubric> PerformanceMeasureRubrics { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureCourseAssociation model.
    /// </summary>
    public interface IPerformanceMeasureCourseAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string PerformanceMeasureIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? PerformanceMeasureResourceId { get; set; }
        string PerformanceMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureFacts model.
    /// </summary>
    public interface IPerformanceMeasureFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        string RubricTitle { get; set; }
        [NaturalKeyMember]
        string RubricTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string PerformanceMeasureTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IPerformanceMeasureFactsGradeLevel> PerformanceMeasureFactsGradeLevels { get; set; }

        // Resource reference data
        Guid? RubricResourceId { get; set; }
        string RubricDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureFactsGradeLevel model.
    /// </summary>
    public interface IPerformanceMeasureFactsGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceMeasureFacts PerformanceMeasureFacts { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureGradeLevel model.
    /// </summary>
    public interface IPerformanceMeasureGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceMeasure PerformanceMeasure { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureInstanceDescriptor model.
    /// </summary>
    public interface IPerformanceMeasureInstanceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PerformanceMeasureInstanceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasurePersonBeingReviewed model.
    /// </summary>
    public interface IPerformanceMeasurePersonBeingReviewed : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceMeasure PerformanceMeasure { get; set; }

        // Non-PK properties
        int? EducationOrganizationId { get; set; }
        string FirstName { get; set; }
        string LastSurname { get; set; }
        string ProspectIdentifier { get; set; }
        string StaffUniqueId { get; set; }
        string TeacherCandidateIdentifier { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProspectResourceId { get; set; }
        string ProspectDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureProgramGateway model.
    /// </summary>
    public interface IPerformanceMeasureProgramGateway : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceMeasure PerformanceMeasure { get; set; }
        [NaturalKeyMember]
        string ProgramGatewayDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureReviewer model.
    /// </summary>
    public interface IPerformanceMeasureReviewer : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceMeasure PerformanceMeasure { get; set; }
        [NaturalKeyMember]
        string FirstName { get; set; }
        [NaturalKeyMember]
        string LastSurname { get; set; }

        // Non-PK properties
        string StaffUniqueId { get; set; }

        // One-to-one relationships

        IPerformanceMeasureReviewerReceivedTraining PerformanceMeasureReviewerReceivedTraining { get; set; }

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureReviewerReceivedTraining model.
    /// </summary>
    public interface IPerformanceMeasureReviewerReceivedTraining : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceMeasureReviewer PerformanceMeasureReviewer { get; set; }

        // Non-PK properties
        int? InterRaterReliabilityScore { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureRubric model.
    /// </summary>
    public interface IPerformanceMeasureRubric : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPerformanceMeasure PerformanceMeasure { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string RubricTitle { get; set; }
        [NaturalKeyMember]
        string RubricTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? RubricResourceId { get; set; }
        string RubricDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceMeasureTypeDescriptor model.
    /// </summary>
    public interface IPerformanceMeasureTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PerformanceMeasureTypeDescriptorId { get; set; }

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
    /// Defines available properties and methods for the abstraction of the Prospect model.
    /// </summary>
    public interface IProspect : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProspectIdentifier { get; set; }

        // Non-PK properties
        bool? Applied { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        string ElectronicMailAddress { get; set; }
        bool? FirstGenerationStudent { get; set; }
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
        string ProspectTypeDescriptor { get; set; }
        bool? Referral { get; set; }
        string ReferredBy { get; set; }
        string SexDescriptor { get; set; }
        string SocialMediaNetworkName { get; set; }
        string SocialMediaUserName { get; set; }
        string TeacherCandidateIdentifier { get; set; }

        // One-to-one relationships

        IProspectAid ProspectAid { get; set; }

        IProspectCurrentPosition ProspectCurrentPosition { get; set; }

        IProspectQualifications ProspectQualifications { get; set; }

        // Lists
        ICollection<IProspectCredential> ProspectCredentials { get; set; }
        ICollection<IProspectDisability> ProspectDisabilities { get; set; }
        ICollection<IProspectPersonalIdentificationDocument> ProspectPersonalIdentificationDocuments { get; set; }
        ICollection<IProspectRace> ProspectRaces { get; set; }
        ICollection<IProspectRecruitmentEvent> ProspectRecruitmentEvents { get; set; }
        ICollection<IProspectTelephone> ProspectTelephones { get; set; }
        ICollection<IProspectTouchpoint> ProspectTouchpoints { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectAid model.
    /// </summary>
    public interface IProspectAid : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }

        // Non-PK properties
        decimal? AidAmount { get; set; }
        string AidConditionDescription { get; set; }
        string AidTypeDescriptor { get; set; }
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        bool? PellGrantRecipient { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectCredential model.
    /// </summary>
    public interface IProspectCredential : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }
        [NaturalKeyMember]
        string CredentialIdentifier { get; set; }
        [NaturalKeyMember]
        string StateOfIssueStateAbbreviationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CredentialResourceId { get; set; }
        string CredentialDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectCurrentPosition model.
    /// </summary>
    public interface IProspectCurrentPosition : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string Location { get; set; }
        string NameOfInstitution { get; set; }
        string PositionTitle { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IProspectCurrentPositionGradeLevel> ProspectCurrentPositionGradeLevels { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectCurrentPositionGradeLevel model.
    /// </summary>
    public interface IProspectCurrentPositionGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspectCurrentPosition ProspectCurrentPosition { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectDisability model.
    /// </summary>
    public interface IProspectDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IProspectDisabilityDesignation> ProspectDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectDisabilityDesignation model.
    /// </summary>
    public interface IProspectDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspectDisability ProspectDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectPersonalIdentificationDocument model.
    /// </summary>
    public interface IProspectPersonalIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ProspectProfessionalDevelopmentEventAttendance model.
    /// </summary>
    public interface IProspectProfessionalDevelopmentEventAttendance : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AttendanceDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProfessionalDevelopmentTitle { get; set; }
        [NaturalKeyMember]
        string ProspectIdentifier { get; set; }

        // Non-PK properties
        string AttendanceEventCategoryDescriptor { get; set; }
        string AttendanceEventReason { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProfessionalDevelopmentEventResourceId { get; set; }
        string ProfessionalDevelopmentEventDiscriminator { get; set; }
        Guid? ProspectResourceId { get; set; }
        string ProspectDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectQualifications model.
    /// </summary>
    public interface IProspectQualifications : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }

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
    /// Defines available properties and methods for the abstraction of the ProspectRace model.
    /// </summary>
    public interface IProspectRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectRecruitmentEvent model.
    /// </summary>
    public interface IProspectRecruitmentEvent : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string EventTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? RecruitmentEventResourceId { get; set; }
        string RecruitmentEventDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProspectTelephone model.
    /// </summary>
    public interface IProspectTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ProspectTouchpoint model.
    /// </summary>
    public interface IProspectTouchpoint : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProspect Prospect { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ProspectTypeDescriptor model.
    /// </summary>
    public interface IProspectTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProspectTypeDescriptorId { get; set; }

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
    /// Defines available properties and methods for the abstraction of the Rubric model.
    /// </summary>
    public interface IRubric : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string RubricTitle { get; set; }
        [NaturalKeyMember]
        string RubricTypeDescriptor { get; set; }

        // Non-PK properties
        int? InterRaterReliabilityScore { get; set; }
        string RubricDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricLevel model.
    /// </summary>
    public interface IRubricLevel : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string RubricLevelCode { get; set; }
        [NaturalKeyMember]
        string RubricTitle { get; set; }
        [NaturalKeyMember]
        string RubricTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        IRubricLevelInformation RubricLevelInformation { get; set; }

        // Lists
        ICollection<IRubricLevelTheme> RubricLevelThemes { get; set; }

        // Resource reference data
        Guid? RubricResourceId { get; set; }
        string RubricDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricLevelInformation model.
    /// </summary>
    public interface IRubricLevelInformation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRubricLevel RubricLevel { get; set; }

        // Non-PK properties
        string LevelDescription { get; set; }
        string LevelTitle { get; set; }
        string LevelTypeDescriptor { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricLevelResponse model.
    /// </summary>
    public interface IRubricLevelResponse : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string PerformanceMeasureIdentifier { get; set; }
        [NaturalKeyMember]
        string RubricLevelCode { get; set; }
        [NaturalKeyMember]
        string RubricTitle { get; set; }
        [NaturalKeyMember]
        string RubricTypeDescriptor { get; set; }

        // Non-PK properties
        bool? AreaOfRefinement { get; set; }
        bool? AreaOfReinforcement { get; set; }
        string Comments { get; set; }
        int NumericResponse { get; set; }
        string TextResponse { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PerformanceMeasureResourceId { get; set; }
        string PerformanceMeasureDiscriminator { get; set; }
        Guid? RubricLevelResourceId { get; set; }
        string RubricLevelDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricLevelResponseFacts model.
    /// </summary>
    public interface IRubricLevelResponseFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
        [NaturalKeyMember]
        string RubricLevelCode { get; set; }
        [NaturalKeyMember]
        string RubricTitle { get; set; }
        [NaturalKeyMember]
        string RubricTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        IRubricLevelResponseFactsAggregatedNumericResponse RubricLevelResponseFactsAggregatedNumericResponse { get; set; }

        // Lists

        // Resource reference data
        Guid? PerformanceMeasureFactsResourceId { get; set; }
        string PerformanceMeasureFactsDiscriminator { get; set; }
        Guid? RubricLevelResourceId { get; set; }
        string RubricLevelDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricLevelResponseFactsAggregatedNumericResponse model.
    /// </summary>
    public interface IRubricLevelResponseFactsAggregatedNumericResponse : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRubricLevelResponseFacts RubricLevelResponseFacts { get; set; }

        // Non-PK properties
        decimal AverageNumericResponse { get; set; }
        int? NumericResponseNCount { get; set; }
        int? NumericResponseStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricLevelTheme model.
    /// </summary>
    public interface IRubricLevelTheme : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRubricLevel RubricLevel { get; set; }
        [NaturalKeyMember]
        string ThemeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricTypeDescriptor model.
    /// </summary>
    public interface IRubricTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RubricTypeDescriptorId { get; set; }

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
        string FederalLocaleCodeDescriptor { get; set; }
        bool? ImprovingSchool { get; set; }
        string SchoolStatusDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolStatusDescriptor model.
    /// </summary>
    public interface ISchoolStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SchoolStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionCourseTranscriptFacts model.
    /// </summary>
    public interface ISectionCourseTranscriptFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        DateTime FactsAsOfDate { get; set; }
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

        // Non-PK properties
        string CourseTitle { get; set; }

        // One-to-one relationships

        ISectionCourseTranscriptFactsAggregatedNumericGradeEarned SectionCourseTranscriptFactsAggregatedNumericGradeEarned { get; set; }

        ISectionCourseTranscriptFactsStudentsEnrolled SectionCourseTranscriptFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<ISectionCourseTranscriptFactsAggregatedFinalLetterGradeEarned> SectionCourseTranscriptFactsAggregatedFinalLetterGradeEarneds { get; set; }

        // Resource reference data
        Guid? SectionStudentAcademicRecordFactsResourceId { get; set; }
        string SectionStudentAcademicRecordFactsDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionCourseTranscriptFactsAggregatedFinalLetterGradeEarned model.
    /// </summary>
    public interface ISectionCourseTranscriptFactsAggregatedFinalLetterGradeEarned : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionCourseTranscriptFacts SectionCourseTranscriptFacts { get; set; }
        [NaturalKeyMember]
        string FinalLetterGrade { get; set; }

        // Non-PK properties
        int? LetterGradeTypeNumber { get; set; }
        decimal? LetterGradeTypePercentage { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionCourseTranscriptFactsAggregatedNumericGradeEarned model.
    /// </summary>
    public interface ISectionCourseTranscriptFactsAggregatedNumericGradeEarned : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionCourseTranscriptFacts SectionCourseTranscriptFacts { get; set; }

        // Non-PK properties
        decimal AverageFinalNumericGradeEarned { get; set; }
        int? NumericGradeNCount { get; set; }
        int? NumericGradeStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionCourseTranscriptFactsStudentsEnrolled model.
    /// </summary>
    public interface ISectionCourseTranscriptFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionCourseTranscriptFacts SectionCourseTranscriptFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAcademicRecordFacts model.
    /// </summary>
    public interface ISectionStudentAcademicRecordFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
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

        // Non-PK properties
        decimal? AggregatedGPAMax { get; set; }

        // One-to-one relationships

        ISectionStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage SectionStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage { get; set; }

        ISectionStudentAcademicRecordFactsAggregatedSessionGradePointAverage SectionStudentAcademicRecordFactsAggregatedSessionGradePointAverage { get; set; }

        ISectionStudentAcademicRecordFactsStudentsEnrolled SectionStudentAcademicRecordFactsStudentsEnrolled { get; set; }

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage model.
    /// </summary>
    public interface ISectionStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentAcademicRecordFacts SectionStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAcademicRecordFactsAggregatedSessionGradePointAverage model.
    /// </summary>
    public interface ISectionStudentAcademicRecordFactsAggregatedSessionGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentAcademicRecordFacts SectionStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAcademicRecordFactsStudentsEnrolled model.
    /// </summary>
    public interface ISectionStudentAcademicRecordFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentAcademicRecordFacts SectionStudentAcademicRecordFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAssessmentFacts model.
    /// </summary>
    public interface ISectionStudentAssessmentFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
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
        short TakenSchoolYear { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        DateTime? AdministrationDate { get; set; }
        string AssessmentCategoryDescriptor { get; set; }
        string AssessmentTitle { get; set; }
        string GradeLevelDescriptor { get; set; }

        // One-to-one relationships

        ISectionStudentAssessmentFactsAggregatedScoreResult SectionStudentAssessmentFactsAggregatedScoreResult { get; set; }

        ISectionStudentAssessmentFactsStudentsEnrolled SectionStudentAssessmentFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<ISectionStudentAssessmentFactsAggregatedPerformanceLevel> SectionStudentAssessmentFactsAggregatedPerformanceLevels { get; set; }

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? TakenSchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAssessmentFactsAggregatedPerformanceLevel model.
    /// </summary>
    public interface ISectionStudentAssessmentFactsAggregatedPerformanceLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentAssessmentFacts SectionStudentAssessmentFacts { get; set; }
        [NaturalKeyMember]
        string PerformanceLevelDescriptor { get; set; }

        // Non-PK properties
        int? PerformanceLevelMetNumber { get; set; }
        decimal? PerformanceLevelMetPercentage { get; set; }
        int? PerformanceLevelTypeNumber { get; set; }
        decimal? PerformanceLevelTypePercentage { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAssessmentFactsAggregatedScoreResult model.
    /// </summary>
    public interface ISectionStudentAssessmentFactsAggregatedScoreResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentAssessmentFacts SectionStudentAssessmentFacts { get; set; }

        // Non-PK properties
        string AssessmentReportingMethodDescriptor { get; set; }
        string AverageScoreResult { get; set; }
        string AverageScoreResultDatatypeTypeDescriptor { get; set; }
        int? ScoreNCount { get; set; }
        int? ScoreStandardDeviation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentAssessmentFactsStudentsEnrolled model.
    /// </summary>
    public interface ISectionStudentAssessmentFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentAssessmentFacts SectionStudentAssessmentFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFacts model.
    /// </summary>
    public interface ISectionStudentFacts : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
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

        // Non-PK properties

        // One-to-one relationships

        ISectionStudentFactsAggregatedDisabilityTotalStudentsDisabled SectionStudentFactsAggregatedDisabilityTotalStudentsDisabled { get; set; }

        ISectionStudentFactsAggregatedELLEnrollment SectionStudentFactsAggregatedELLEnrollment { get; set; }

        ISectionStudentFactsAggregatedESLEnrollment SectionStudentFactsAggregatedESLEnrollment { get; set; }

        ISectionStudentFactsAggregatedSection504Enrollment SectionStudentFactsAggregatedSection504Enrollment { get; set; }

        ISectionStudentFactsAggregatedSPED SectionStudentFactsAggregatedSPED { get; set; }

        ISectionStudentFactsAggregatedTitleIEnrollment SectionStudentFactsAggregatedTitleIEnrollment { get; set; }

        ISectionStudentFactsStudentsEnrolled SectionStudentFactsStudentsEnrolled { get; set; }

        // Lists
        ICollection<ISectionStudentFactsAggregatedByDisability> SectionStudentFactsAggregatedByDisabilities { get; set; }
        ICollection<ISectionStudentFactsAggregatedGender> SectionStudentFactsAggregatedGenders { get; set; }
        ICollection<ISectionStudentFactsAggregatedHispanicLatinoEthnicity> SectionStudentFactsAggregatedHispanicLatinoEthnicities { get; set; }
        ICollection<ISectionStudentFactsAggregatedLanguage> SectionStudentFactsAggregatedLanguages { get; set; }
        ICollection<ISectionStudentFactsAggregatedRace> SectionStudentFactsAggregatedRaces { get; set; }
        ICollection<ISectionStudentFactsAggregatedSchoolFoodServiceProgramService> SectionStudentFactsAggregatedSchoolFoodServiceProgramServices { get; set; }
        ICollection<ISectionStudentFactsAggregatedSex> SectionStudentFactsAggregatedSexes { get; set; }

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedByDisability model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedByDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        decimal? Percentage { get; set; }
        int? TypeNumber { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedDisabilityTotalStudentsDisabled model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedDisabilityTotalStudentsDisabled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }

        // Non-PK properties
        int? StudentsDisabledNumber { get; set; }
        decimal? StudentsDisabledPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedELLEnrollment model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedELLEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }

        // Non-PK properties
        int? ELLEnrollmentNumber { get; set; }
        decimal? ELLEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedESLEnrollment model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedESLEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }

        // Non-PK properties
        int? ESLEnrollmentNumber { get; set; }
        decimal? ESLEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedGender model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedGender : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }
        [NaturalKeyMember]
        string GenderDescriptor { get; set; }

        // Non-PK properties
        int? GenderTypeNumber { get; set; }
        decimal? GenderTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedHispanicLatinoEthnicity model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedHispanicLatinoEthnicity : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }
        [NaturalKeyMember]
        bool HispanicLatinoEthnicity { get; set; }

        // Non-PK properties
        int? HispanicLatinoEthnicityNumber { get; set; }
        decimal? HispanicLatinoEthnicityPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedLanguage model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties
        int? LanguageTypeNumber { get; set; }
        decimal? LanguageTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedRace model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties
        int? RaceTypeNumber { get; set; }
        decimal? RaceTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedSchoolFoodServiceProgramService model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSchoolFoodServiceProgramService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }
        [NaturalKeyMember]
        string SchoolFoodServiceProgramServiceDescriptor { get; set; }

        // Non-PK properties
        int? TypeNumber { get; set; }
        int? TypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedSection504Enrollment model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSection504Enrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }

        // Non-PK properties
        int? Number504Enrolled { get; set; }
        decimal? Percentage504Enrolled { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedSex model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSex : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }
        [NaturalKeyMember]
        string SexDescriptor { get; set; }

        // Non-PK properties
        int? SexTypeNumber { get; set; }
        decimal? SexTypePercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedSPED model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSPED : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }

        // Non-PK properties
        int? SPEDEnrollmentNumber { get; set; }
        decimal? SPEDEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsAggregatedTitleIEnrollment model.
    /// </summary>
    public interface ISectionStudentFactsAggregatedTitleIEnrollment : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }

        // Non-PK properties
        int? TitleIEnrollmentNumber { get; set; }
        decimal? TitleIEnrollmentPercentage { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionStudentFactsStudentsEnrolled model.
    /// </summary>
    public interface ISectionStudentFactsStudentsEnrolled : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISectionStudentFacts SectionStudentFacts { get; set; }

        // Non-PK properties
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        string ValueTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffApplicantAssociation model.
    /// </summary>
    public interface IStaffApplicantAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ApplicantResourceId { get; set; }
        string ApplicantDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffBackgroundCheck model.
    /// </summary>
    public interface IStaffBackgroundCheck : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffEvaluation model.
    /// </summary>
    public interface IStaffEvaluation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationTitle { get; set; }

        // Non-PK properties
        decimal MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string StaffEvaluationPeriodDescriptor { get; set; }
        string StaffEvaluationTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffEvaluationStaffRatingLevel> StaffEvaluationStaffRatingLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationComponent model.
    /// </summary>
    public interface IStaffEvaluationComponent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationComponent { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationTitle { get; set; }

        // Non-PK properties
        decimal MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string RubricReference { get; set; }
        string StaffEvaluationTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffEvaluationComponentStaffRatingLevel> StaffEvaluationComponentStaffRatingLevels { get; set; }

        // Resource reference data
        Guid? StaffEvaluationResourceId { get; set; }
        string StaffEvaluationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationComponentRating model.
    /// </summary>
    public interface IStaffEvaluationComponentRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        decimal ComponentRating { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationComponent { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        DateTime StaffEvaluationDate { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string StaffEvaluationRatingLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffEvaluationComponentResourceId { get; set; }
        string StaffEvaluationComponentDiscriminator { get; set; }
        Guid? StaffEvaluationRatingResourceId { get; set; }
        string StaffEvaluationRatingDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationComponentStaffRatingLevel model.
    /// </summary>
    public interface IStaffEvaluationComponentStaffRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEvaluationComponent StaffEvaluationComponent { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationLevel { get; set; }

        // Non-PK properties
        decimal MaxLevel { get; set; }
        decimal? MinLevel { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationElement model.
    /// </summary>
    public interface IStaffEvaluationElement : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationComponent { get; set; }
        [NaturalKeyMember]
        string EvaluationElement { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationTitle { get; set; }

        // Non-PK properties
        decimal MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string RubricReference { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffEvaluationElementStaffRatingLevel> StaffEvaluationElementStaffRatingLevels { get; set; }

        // Resource reference data
        Guid? StaffEvaluationComponentResourceId { get; set; }
        string StaffEvaluationComponentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationElementRating model.
    /// </summary>
    public interface IStaffEvaluationElementRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EvaluationComponent { get; set; }
        [NaturalKeyMember]
        string EvaluationElement { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        DateTime StaffEvaluationDate { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        decimal ElementRating { get; set; }
        string StaffEvaluationRatingLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffEvaluationElementResourceId { get; set; }
        string StaffEvaluationElementDiscriminator { get; set; }
        Guid? StaffEvaluationRatingResourceId { get; set; }
        string StaffEvaluationRatingDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationElementStaffRatingLevel model.
    /// </summary>
    public interface IStaffEvaluationElementStaffRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEvaluationElement StaffEvaluationElement { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationLevel { get; set; }

        // Non-PK properties
        decimal MaxLevel { get; set; }
        decimal? MinLevel { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationPeriodDescriptor model.
    /// </summary>
    public interface IStaffEvaluationPeriodDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StaffEvaluationPeriodDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationRating model.
    /// </summary>
    public interface IStaffEvaluationRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        DateTime StaffEvaluationDate { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationTitle { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string EvaluatedByStaffUniqueId { get; set; }
        decimal Rating { get; set; }
        string StaffEvaluationRatingLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluatedByStaffResourceId { get; set; }
        string EvaluatedByStaffDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? StaffEvaluationResourceId { get; set; }
        string StaffEvaluationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationRatingLevelDescriptor model.
    /// </summary>
    public interface IStaffEvaluationRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StaffEvaluationRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationStaffRatingLevel model.
    /// </summary>
    public interface IStaffEvaluationStaffRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEvaluation StaffEvaluation { get; set; }
        [NaturalKeyMember]
        string StaffEvaluationLevel { get; set; }

        // Non-PK properties
        decimal MaxLevel { get; set; }
        decimal? MinLevel { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEvaluationTypeDescriptor model.
    /// </summary>
    public interface IStaffEvaluationTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StaffEvaluationTypeDescriptorId { get; set; }

        // Non-PK properties

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
        string GenderDescriptor { get; set; }
        DateTime? ProbationCompleteDate { get; set; }
        bool? Tenured { get; set; }
        bool? TenureTrack { get; set; }

        // One-to-one relationships

        IStaffSalary StaffSalary { get; set; }

        IStaffTeacherEducatorResearch StaffTeacherEducatorResearch { get; set; }

        // Lists
        ICollection<IStaffBackgroundCheck> StaffBackgroundChecks { get; set; }
        ICollection<IStaffHighlyQualifiedAcademicSubject> StaffHighlyQualifiedAcademicSubjects { get; set; }
        ICollection<IStaffSeniority> StaffSeniorities { get; set; }
        ICollection<IStaffTeacherPreparationProgram> StaffTeacherPreparationPrograms { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffFieldworkAbsenceEvent model.
    /// </summary>
    public interface IStaffFieldworkAbsenceEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AbsenceEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string AbsenceEventReason { get; set; }
        decimal? HoursAbsent { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffFieldworkExperience model.
    /// </summary>
    public interface IStaffFieldworkExperience : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string FieldworkIdentifier { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string FieldworkTypeDescriptor { get; set; }
        decimal? HoursCompleted { get; set; }
        string ProgramGatewayDescriptor { get; set; }

        // One-to-one relationships

        IStaffFieldworkExperienceCoteaching StaffFieldworkExperienceCoteaching { get; set; }

        // Lists
        ICollection<IStaffFieldworkExperienceSchool> StaffFieldworkExperienceSchools { get; set; }

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffFieldworkExperienceCoteaching model.
    /// </summary>
    public interface IStaffFieldworkExperienceCoteaching : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffFieldworkExperience StaffFieldworkExperience { get; set; }

        // Non-PK properties
        DateTime CoteachingBeginDate { get; set; }
        DateTime? CoteachingEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffFieldworkExperienceSchool model.
    /// </summary>
    public interface IStaffFieldworkExperienceSchool : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffFieldworkExperience StaffFieldworkExperience { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffFieldworkExperienceSectionAssociation model.
    /// </summary>
    public interface IStaffFieldworkExperienceSectionAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
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
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? StaffFieldworkExperienceResourceId { get; set; }
        string StaffFieldworkExperienceDiscriminator { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffProfessionalDevelopmentEventAttendance model.
    /// </summary>
    public interface IStaffProfessionalDevelopmentEventAttendance : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AttendanceDate { get; set; }
        [NaturalKeyMember]
        string ProfessionalDevelopmentTitle { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string AttendanceEventCategoryDescriptor { get; set; }
        string AttendanceEventReason { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProfessionalDevelopmentEventResourceId { get; set; }
        string ProfessionalDevelopmentEventDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffProspectAssociation model.
    /// </summary>
    public interface IStaffProspectAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProspectIdentifier { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProspectResourceId { get; set; }
        string ProspectDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffSalary model.
    /// </summary>
    public interface IStaffSalary : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }

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
    /// Defines available properties and methods for the abstraction of the StaffSeniority model.
    /// </summary>
    public interface IStaffSeniority : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffStudentGrowthMeasure model.
    /// </summary>
    public interface IStaffStudentGrowthMeasure : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }
        decimal? StandardError { get; set; }
        int StudentGrowthActualScore { get; set; }
        DateTime? StudentGrowthMeasureDate { get; set; }
        bool StudentGrowthMet { get; set; }
        int? StudentGrowthNCount { get; set; }
        int? StudentGrowthTargetScore { get; set; }
        string StudentGrowthTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffStudentGrowthMeasureAcademicSubject> StaffStudentGrowthMeasureAcademicSubjects { get; set; }
        ICollection<IStaffStudentGrowthMeasureGradeLevel> StaffStudentGrowthMeasureGradeLevels { get; set; }

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffStudentGrowthMeasureAcademicSubject model.
    /// </summary>
    public interface IStaffStudentGrowthMeasureAcademicSubject : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffStudentGrowthMeasure StaffStudentGrowthMeasure { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffStudentGrowthMeasureCourseAssociation model.
    /// </summary>
    public interface IStaffStudentGrowthMeasureCourseAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? StaffStudentGrowthMeasureResourceId { get; set; }
        string StaffStudentGrowthMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffStudentGrowthMeasureEducationOrganizationAssociation model.
    /// </summary>
    public interface IStaffStudentGrowthMeasureEducationOrganizationAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? StaffStudentGrowthMeasureResourceId { get; set; }
        string StaffStudentGrowthMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffStudentGrowthMeasureGradeLevel model.
    /// </summary>
    public interface IStaffStudentGrowthMeasureGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffStudentGrowthMeasure StaffStudentGrowthMeasure { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffStudentGrowthMeasureSectionAssociation model.
    /// </summary>
    public interface IStaffStudentGrowthMeasureSectionAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
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
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? StaffStudentGrowthMeasureResourceId { get; set; }
        string StaffStudentGrowthMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffTeacherEducatorResearch model.
    /// </summary>
    public interface IStaffTeacherEducatorResearch : ISynchronizable, IMappable, IGetByExample
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
    /// Defines available properties and methods for the abstraction of the StaffTeacherPreparationProgram model.
    /// </summary>
    public interface IStaffTeacherPreparationProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }
        [NaturalKeyMember]
        string TeacherPreparationProgramName { get; set; }

        // Non-PK properties
        decimal? GPA { get; set; }
        string LevelOfDegreeAwardedDescriptor { get; set; }
        string MajorSpecialization { get; set; }
        string NameOfInstitution { get; set; }
        string TeacherPreparationProgramIdentifier { get; set; }
        string TeacherPreparationProgramTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffTeacherPreparationProviderAssociation model.
    /// </summary>
    public interface IStaffTeacherPreparationProviderAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }
        [NaturalKeyMember]
        int TeacherPreparationProviderId { get; set; }

        // Non-PK properties
        string ProgramAssignmentDescriptor { get; set; }
        short SchoolYear { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffTeacherPreparationProviderAssociationAcademicSubject> StaffTeacherPreparationProviderAssociationAcademicSubjects { get; set; }
        ICollection<IStaffTeacherPreparationProviderAssociationGradeLevel> StaffTeacherPreparationProviderAssociationGradeLevels { get; set; }

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? TeacherPreparationProviderResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffTeacherPreparationProviderAssociationAcademicSubject model.
    /// </summary>
    public interface IStaffTeacherPreparationProviderAssociationAcademicSubject : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffTeacherPreparationProviderAssociation StaffTeacherPreparationProviderAssociation { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffTeacherPreparationProviderAssociationGradeLevel model.
    /// </summary>
    public interface IStaffTeacherPreparationProviderAssociationGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffTeacherPreparationProviderAssociation StaffTeacherPreparationProviderAssociation { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffTeacherPreparationProviderProgramAssociation model.
    /// </summary>
    public interface IStaffTeacherPreparationProviderProgramAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
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
        DateTime? EndDate { get; set; }
        bool? StudentRecordAccess { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? TeacherPreparationProviderProgramResourceId { get; set; }
        string TeacherPreparationProviderProgramDiscriminator { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentGrowthTypeDescriptor model.
    /// </summary>
    public interface IStudentGrowthTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StudentGrowthTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TalentManagementGoal model.
    /// </summary>
    public interface ITalentManagementGoal : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string GoalTitle { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        decimal GoalValue { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ITalentManagementGoalEducationOrganization> TalentManagementGoalEducationOrganizations { get; set; }

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TalentManagementGoalEducationOrganization model.
    /// </summary>
    public interface ITalentManagementGoalEducationOrganization : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITalentManagementGoal TalentManagementGoal { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidate model.
    /// </summary>
    public interface ITeacherCandidate : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties
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
        string PreviousCareerDescriptor { get; set; }
        string ProfileThumbnail { get; set; }
        bool? ProgramComplete { get; set; }
        string SexDescriptor { get; set; }
        string StudentUniqueId { get; set; }
        decimal? TuitionCost { get; set; }

        // One-to-one relationships

        ITeacherCandidateBackgroundCheck TeacherCandidateBackgroundCheck { get; set; }

        // Lists
        ICollection<ITeacherCandidateAddress> TeacherCandidateAddresses { get; set; }
        ICollection<ITeacherCandidateAid> TeacherCandidateAids { get; set; }
        ICollection<ITeacherCandidateCharacteristic> TeacherCandidateCharacteristics { get; set; }
        ICollection<ITeacherCandidateCohortYear> TeacherCandidateCohortYears { get; set; }
        ICollection<ITeacherCandidateCredential> TeacherCandidateCredentials { get; set; }
        ICollection<ITeacherCandidateDegreeSpecialization> TeacherCandidateDegreeSpecializations { get; set; }
        ICollection<ITeacherCandidateDisability> TeacherCandidateDisabilities { get; set; }
        ICollection<ITeacherCandidateElectronicMail> TeacherCandidateElectronicMails { get; set; }
        ICollection<ITeacherCandidateIdentificationCode> TeacherCandidateIdentificationCodes { get; set; }
        ICollection<ITeacherCandidateIdentificationDocument> TeacherCandidateIdentificationDocuments { get; set; }
        ICollection<ITeacherCandidateIndicator> TeacherCandidateIndicators { get; set; }
        ICollection<ITeacherCandidateInternationalAddress> TeacherCandidateInternationalAddresses { get; set; }
        ICollection<ITeacherCandidateLanguage> TeacherCandidateLanguages { get; set; }
        ICollection<ITeacherCandidateOtherName> TeacherCandidateOtherNames { get; set; }
        ICollection<ITeacherCandidatePersonalIdentificationDocument> TeacherCandidatePersonalIdentificationDocuments { get; set; }
        ICollection<ITeacherCandidateRace> TeacherCandidateRaces { get; set; }
        ICollection<ITeacherCandidateTelephone> TeacherCandidateTelephones { get; set; }
        ICollection<ITeacherCandidateTPPProgramDegree> TeacherCandidateTPPProgramDegrees { get; set; }
        ICollection<ITeacherCandidateVisa> TeacherCandidateVisas { get; set; }

        // Resource reference data
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAcademicRecord model.
    /// </summary>
    public interface ITeacherCandidateAcademicRecord : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        decimal? ContentGradePointAverage { get; set; }
        decimal? ContentGradePointEarned { get; set; }
        decimal? CumulativeAttemptedCreditConversion { get; set; }
        decimal? CumulativeAttemptedCredits { get; set; }
        string CumulativeAttemptedCreditTypeDescriptor { get; set; }
        decimal? CumulativeEarnedCreditConversion { get; set; }
        decimal? CumulativeEarnedCredits { get; set; }
        string CumulativeEarnedCreditTypeDescriptor { get; set; }
        decimal? CumulativeGradePointAverage { get; set; }
        decimal? CumulativeGradePointsEarned { get; set; }
        string GradeValueQualifier { get; set; }
        string ProgramGatewayDescriptor { get; set; }
        DateTime? ProjectedGraduationDate { get; set; }
        decimal? SessionAttemptedCreditConversion { get; set; }
        decimal? SessionAttemptedCredits { get; set; }
        string SessionAttemptedCreditTypeDescriptor { get; set; }
        decimal? SessionEarnedCreditConversion { get; set; }
        decimal? SessionEarnedCredits { get; set; }
        string SessionEarnedCreditTypeDescriptor { get; set; }
        decimal? SessionGradePointAverage { get; set; }
        decimal? SessionGradePointsEarned { get; set; }
        string TPPDegreeTypeDescriptor { get; set; }

        // One-to-one relationships

        ITeacherCandidateAcademicRecordClassRanking TeacherCandidateAcademicRecordClassRanking { get; set; }

        // Lists
        ICollection<ITeacherCandidateAcademicRecordAcademicHonor> TeacherCandidateAcademicRecordAcademicHonors { get; set; }
        ICollection<ITeacherCandidateAcademicRecordDiploma> TeacherCandidateAcademicRecordDiplomas { get; set; }
        ICollection<ITeacherCandidateAcademicRecordGradePointAverage> TeacherCandidateAcademicRecordGradePointAverages { get; set; }
        ICollection<ITeacherCandidateAcademicRecordRecognition> TeacherCandidateAcademicRecordRecognitions { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAcademicRecordAcademicHonor model.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordAcademicHonor : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateAcademicRecord TeacherCandidateAcademicRecord { get; set; }
        [NaturalKeyMember]
        string AcademicHonorCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        string HonorDescription { get; set; }

        // Non-PK properties
        string AchievementCategoryDescriptor { get; set; }
        string AchievementCategorySystem { get; set; }
        string AchievementTitle { get; set; }
        string Criteria { get; set; }
        string CriteriaURL { get; set; }
        string EvidenceStatement { get; set; }
        DateTime? HonorAwardDate { get; set; }
        DateTime? HonorAwardExpiresDate { get; set; }
        string ImageURL { get; set; }
        string IssuerName { get; set; }
        string IssuerOriginURL { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAcademicRecordClassRanking model.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordClassRanking : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateAcademicRecord TeacherCandidateAcademicRecord { get; set; }

        // Non-PK properties
        int ClassRank { get; set; }
        DateTime? ClassRankingDate { get; set; }
        int? PercentageRanking { get; set; }
        int TotalNumberInClass { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAcademicRecordDiploma model.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordDiploma : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateAcademicRecord TeacherCandidateAcademicRecord { get; set; }
        [NaturalKeyMember]
        DateTime DiplomaAwardDate { get; set; }
        [NaturalKeyMember]
        string DiplomaTypeDescriptor { get; set; }

        // Non-PK properties
        string AchievementCategoryDescriptor { get; set; }
        string AchievementCategorySystem { get; set; }
        string AchievementTitle { get; set; }
        string Criteria { get; set; }
        string CriteriaURL { get; set; }
        bool? CTECompleter { get; set; }
        DateTime? DiplomaAwardExpiresDate { get; set; }
        string DiplomaDescription { get; set; }
        string DiplomaLevelDescriptor { get; set; }
        string EvidenceStatement { get; set; }
        string ImageURL { get; set; }
        string IssuerName { get; set; }
        string IssuerOriginURL { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAcademicRecordGradePointAverage model.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateAcademicRecord TeacherCandidateAcademicRecord { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAcademicRecordRecognition model.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordRecognition : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateAcademicRecord TeacherCandidateAcademicRecord { get; set; }
        [NaturalKeyMember]
        string RecognitionTypeDescriptor { get; set; }

        // Non-PK properties
        string AchievementCategoryDescriptor { get; set; }
        string AchievementCategorySystem { get; set; }
        string AchievementTitle { get; set; }
        string Criteria { get; set; }
        string CriteriaURL { get; set; }
        string EvidenceStatement { get; set; }
        string ImageURL { get; set; }
        string IssuerName { get; set; }
        string IssuerOriginURL { get; set; }
        DateTime? RecognitionAwardDate { get; set; }
        DateTime? RecognitionAwardExpiresDate { get; set; }
        string RecognitionDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAddress model.
    /// </summary>
    public interface ITeacherCandidateAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
        ICollection<ITeacherCandidateAddressPeriod> TeacherCandidateAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAddressPeriod model.
    /// </summary>
    public interface ITeacherCandidateAddressPeriod : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateAddress TeacherCandidateAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateAid model.
    /// </summary>
    public interface ITeacherCandidateAid : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateBackgroundCheck model.
    /// </summary>
    public interface ITeacherCandidateBackgroundCheck : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }

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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateCharacteristic model.
    /// </summary>
    public interface ITeacherCandidateCharacteristic : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateCharacteristicDescriptor model.
    /// </summary>
    public interface ITeacherCandidateCharacteristicDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TeacherCandidateCharacteristicDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateCohortYear model.
    /// </summary>
    public interface ITeacherCandidateCohortYear : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateCourseTranscript model.
    /// </summary>
    public interface ITeacherCandidateCourseTranscript : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseAttemptResultDescriptor { get; set; }
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int CourseEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string AlternativeCourseCode { get; set; }
        string AlternativeCourseTitle { get; set; }
        decimal? AttemptedCreditConversion { get; set; }
        decimal? AttemptedCredits { get; set; }
        string AttemptedCreditTypeDescriptor { get; set; }
        string CourseRepeatCodeDescriptor { get; set; }
        string CourseTitle { get; set; }
        decimal? EarnedCreditConversion { get; set; }
        decimal EarnedCredits { get; set; }
        string EarnedCreditTypeDescriptor { get; set; }
        string FinalLetterGradeEarned { get; set; }
        decimal? FinalNumericGradeEarned { get; set; }
        string MethodCreditEarnedDescriptor { get; set; }
        int? SchoolId { get; set; }
        string WhenTakenGradeLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ITeacherCandidateCourseTranscriptEarnedAdditionalCredits> TeacherCandidateCourseTranscriptEarnedAdditionalCredits { get; set; }

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? SchoolResourceId { get; set; }
        Guid? TeacherCandidateAcademicRecordResourceId { get; set; }
        string TeacherCandidateAcademicRecordDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateCourseTranscriptEarnedAdditionalCredits model.
    /// </summary>
    public interface ITeacherCandidateCourseTranscriptEarnedAdditionalCredits : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateCourseTranscript TeacherCandidateCourseTranscript { get; set; }
        [NaturalKeyMember]
        string AdditionalCreditTypeDescriptor { get; set; }

        // Non-PK properties
        decimal Credits { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateCredential model.
    /// </summary>
    public interface ITeacherCandidateCredential : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string CredentialIdentifier { get; set; }
        [NaturalKeyMember]
        string StateOfIssueStateAbbreviationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CredentialResourceId { get; set; }
        string CredentialDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateDegreeSpecialization model.
    /// </summary>
    public interface ITeacherCandidateDegreeSpecialization : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateDisability model.
    /// </summary>
    public interface ITeacherCandidateDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ITeacherCandidateDisabilityDesignation> TeacherCandidateDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateDisabilityDesignation model.
    /// </summary>
    public interface ITeacherCandidateDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateDisability TeacherCandidateDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateElectronicMail model.
    /// </summary>
    public interface ITeacherCandidateElectronicMail : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateFieldworkAbsenceEvent model.
    /// </summary>
    public interface ITeacherCandidateFieldworkAbsenceEvent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AbsenceEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties
        string AbsenceEventReason { get; set; }
        DateTime EventDate { get; set; }
        decimal? HoursAbsent { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateFieldworkExperience model.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperience : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string FieldworkIdentifier { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string FieldworkTypeDescriptor { get; set; }
        decimal? HoursCompleted { get; set; }
        string ProgramGatewayDescriptor { get; set; }

        // One-to-one relationships

        ITeacherCandidateFieldworkExperienceCoteaching TeacherCandidateFieldworkExperienceCoteaching { get; set; }

        // Lists
        ICollection<ITeacherCandidateFieldworkExperienceSchool> TeacherCandidateFieldworkExperienceSchools { get; set; }

        // Resource reference data
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateFieldworkExperienceCoteaching model.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperienceCoteaching : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateFieldworkExperience TeacherCandidateFieldworkExperience { get; set; }

        // Non-PK properties
        DateTime CoteachingBeginDate { get; set; }
        DateTime? CoteachingEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateFieldworkExperienceSchool model.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperienceSchool : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateFieldworkExperience TeacherCandidateFieldworkExperience { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateFieldworkExperienceSectionAssociation model.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperienceSectionAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
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
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? TeacherCandidateFieldworkExperienceResourceId { get; set; }
        string TeacherCandidateFieldworkExperienceDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateIdentificationCode model.
    /// </summary>
    public interface ITeacherCandidateIdentificationCode : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string AssigningOrganizationIdentificationCode { get; set; }
        [NaturalKeyMember]
        string StudentIdentificationSystemDescriptor { get; set; }

        // Non-PK properties
        string IdentificationCode { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateIdentificationDocument model.
    /// </summary>
    public interface ITeacherCandidateIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateIndicator model.
    /// </summary>
    public interface ITeacherCandidateIndicator : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string IndicatorName { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        DateTime? EndDate { get; set; }
        string Indicator { get; set; }
        string IndicatorGroup { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateInternationalAddress model.
    /// </summary>
    public interface ITeacherCandidateInternationalAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateLanguage model.
    /// </summary>
    public interface ITeacherCandidateLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<ITeacherCandidateLanguageUse> TeacherCandidateLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateLanguageUse model.
    /// </summary>
    public interface ITeacherCandidateLanguageUse : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateLanguage TeacherCandidateLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateOtherName model.
    /// </summary>
    public interface ITeacherCandidateOtherName : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidatePersonalIdentificationDocument model.
    /// </summary>
    public interface ITeacherCandidatePersonalIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateProfessionalDevelopmentEventAttendance model.
    /// </summary>
    public interface ITeacherCandidateProfessionalDevelopmentEventAttendance : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime AttendanceDate { get; set; }
        [NaturalKeyMember]
        string ProfessionalDevelopmentTitle { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties
        string AttendanceEventCategoryDescriptor { get; set; }
        string AttendanceEventReason { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProfessionalDevelopmentEventResourceId { get; set; }
        string ProfessionalDevelopmentEventDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateRace model.
    /// </summary>
    public interface ITeacherCandidateRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateStaffAssociation model.
    /// </summary>
    public interface ITeacherCandidateStaffAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateStudentGrowthMeasure model.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasure : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }
        decimal? StandardError { get; set; }
        int StudentGrowthActualScore { get; set; }
        DateTime? StudentGrowthMeasureDate { get; set; }
        bool StudentGrowthMet { get; set; }
        int? StudentGrowthNCount { get; set; }
        int? StudentGrowthTargetScore { get; set; }
        string StudentGrowthTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ITeacherCandidateStudentGrowthMeasureAcademicSubject> TeacherCandidateStudentGrowthMeasureAcademicSubjects { get; set; }
        ICollection<ITeacherCandidateStudentGrowthMeasureGradeLevel> TeacherCandidateStudentGrowthMeasureGradeLevels { get; set; }

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateStudentGrowthMeasureAcademicSubject model.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureAcademicSubject : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateStudentGrowthMeasure TeacherCandidateStudentGrowthMeasure { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateStudentGrowthMeasureCourseAssociation model.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureCourseAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? TeacherCandidateStudentGrowthMeasureResourceId { get; set; }
        string TeacherCandidateStudentGrowthMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation model.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? TeacherCandidateStudentGrowthMeasureResourceId { get; set; }
        string TeacherCandidateStudentGrowthMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateStudentGrowthMeasureGradeLevel model.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidateStudentGrowthMeasure TeacherCandidateStudentGrowthMeasure { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateStudentGrowthMeasureSectionAssociation model.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureSectionAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime FactAsOfDate { get; set; }
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
        string TeacherCandidateIdentifier { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? TeacherCandidateStudentGrowthMeasureResourceId { get; set; }
        string TeacherCandidateStudentGrowthMeasureDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateTeacherPreparationProviderAssociation model.
    /// </summary>
    public interface ITeacherCandidateTeacherPreparationProviderAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime EntryDate { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }
        [NaturalKeyMember]
        int TeacherPreparationProviderId { get; set; }

        // Non-PK properties
        short? ClassOfSchoolYear { get; set; }
        string EntryTypeDescriptor { get; set; }
        DateTime? ExitWithdrawDate { get; set; }
        string ExitWithdrawTypeDescriptor { get; set; }
        short? SchoolYear { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ClassOfSchoolYearTypeResourceId { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
        Guid? TeacherPreparationProviderResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateTeacherPreparationProviderProgramAssociation model.
    /// </summary>
    public interface ITeacherCandidateTeacherPreparationProviderProgramAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string ReasonExitedDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
        Guid? TeacherPreparationProviderProgramResourceId { get; set; }
        string TeacherPreparationProviderProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateTelephone model.
    /// </summary>
    public interface ITeacherCandidateTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
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
    /// Defines available properties and methods for the abstraction of the TeacherCandidateTPPProgramDegree model.
    /// </summary>
    public interface ITeacherCandidateTPPProgramDegree : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }
        [NaturalKeyMember]
        string TPPDegreeTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherCandidateVisa model.
    /// </summary>
    public interface ITeacherCandidateVisa : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherCandidate TeacherCandidate { get; set; }
        [NaturalKeyMember]
        string VisaDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherPreparationProgramTypeDescriptor model.
    /// </summary>
    public interface ITeacherPreparationProgramTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TeacherPreparationProgramTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherPreparationProvider model.
    /// </summary>
    public interface ITeacherPreparationProvider : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int TeacherPreparationProviderId { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }
        int? SchoolId { get; set; }
        int? UniversityId { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? UniversityResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherPreparationProviderProgram model.
    /// </summary>
    public interface ITeacherPreparationProviderProgram : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties
        string MajorSpecialization { get; set; }
        string MinorSpecialization { get; set; }
        string ProgramId { get; set; }
        string TeacherPreparationProgramTypeDescriptor { get; set; }
        string TPPProgramPathwayDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ITeacherPreparationProviderProgramGradeLevel> TeacherPreparationProviderProgramGradeLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeacherPreparationProviderProgramGradeLevel model.
    /// </summary>
    public interface ITeacherPreparationProviderProgramGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ITeacherPreparationProviderProgram TeacherPreparationProviderProgram { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ThemeDescriptor model.
    /// </summary>
    public interface IThemeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ThemeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TPPDegreeTypeDescriptor model.
    /// </summary>
    public interface ITPPDegreeTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TPPDegreeTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TPPProgramPathwayDescriptor model.
    /// </summary>
    public interface ITPPProgramPathwayDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TPPProgramPathwayDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the University model.
    /// </summary>
    public interface IUniversity : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int UniversityId { get; set; }

        // Non-PK properties
        string FederalLocaleCodeDescriptor { get; set; }
        int? SchoolId { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ValueTypeDescriptor model.
    /// </summary>
    public interface IValueTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ValueTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
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