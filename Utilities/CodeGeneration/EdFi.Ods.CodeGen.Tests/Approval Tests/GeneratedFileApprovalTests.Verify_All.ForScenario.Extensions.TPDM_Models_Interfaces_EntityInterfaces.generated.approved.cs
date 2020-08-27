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

        // Non-PK properties
        DateTime? BirthDate { get; set; }
        string CitizenshipStatusDescriptor { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        string GenderDescriptor { get; set; }
        string GenerationCodeSuffix { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        string SexDescriptor { get; set; }
        string SourceSystemDescriptor { get; set; }
        string TeacherCandidateIdentifier { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicantAddress> ApplicantAddresses { get; set; }
        ICollection<IApplicantAid> ApplicantAids { get; set; }
        ICollection<IApplicantBackgroundCheck> ApplicantBackgroundChecks { get; set; }
        ICollection<IApplicantCharacteristic> ApplicantCharacteristics { get; set; }
        ICollection<IApplicantDisability> ApplicantDisabilities { get; set; }
        ICollection<IApplicantElectronicMail> ApplicantElectronicMails { get; set; }
        ICollection<IApplicantIdentificationDocument> ApplicantIdentificationDocuments { get; set; }
        ICollection<IApplicantInternationalAddress> ApplicantInternationalAddresses { get; set; }
        ICollection<IApplicantLanguage> ApplicantLanguages { get; set; }
        ICollection<IApplicantPersonalIdentificationDocument> ApplicantPersonalIdentificationDocuments { get; set; }
        ICollection<IApplicantRace> ApplicantRaces { get; set; }
        ICollection<IApplicantStaffIdentificationCode> ApplicantStaffIdentificationCodes { get; set; }
        ICollection<IApplicantTeacherPreparationProgram> ApplicantTeacherPreparationPrograms { get; set; }
        ICollection<IApplicantTelephone> ApplicantTelephones { get; set; }
        ICollection<IApplicantVisa> ApplicantVisas { get; set; }

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
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
        string HighestCompletedLevelOfEducationDescriptor { get; set; }
        string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        string HighNeedsAcademicSubjectDescriptor { get; set; }
        string HireStatusDescriptor { get; set; }
        string HiringSourceDescriptor { get; set; }
        DateTime? WithdrawDate { get; set; }
        string WithdrawReasonDescriptor { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicationGradePointAverage> ApplicationGradePointAverages { get; set; }
        ICollection<IApplicationOpenStaffPosition> ApplicationOpenStaffPositions { get; set; }
        ICollection<IApplicationScoreResult> ApplicationScoreResults { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ApplicationGradePointAverage model.
    /// </summary>
    public interface IApplicationGradePointAverage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplication Application { get; set; }
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
        DateTime? EndDate { get; set; }
        string FieldworkTypeDescriptor { get; set; }
        decimal? HoursCompleted { get; set; }
        string ProgramGatewayDescriptor { get; set; }

        // One-to-one relationships

        IFieldworkExperienceCoteaching FieldworkExperienceCoteaching { get; set; }

        // Lists
        ICollection<IFieldworkExperienceSchool> FieldworkExperienceSchools { get; set; }

        // Resource reference data
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
    /// Defines available properties and methods for the abstraction of the FieldworkExperienceSchool model.
    /// </summary>
    public interface IFieldworkExperienceSchool : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IFieldworkExperience FieldworkExperience { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
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
        string PersonId { get; set; }
        int? PreScreeningRating { get; set; }
        string ProspectTypeDescriptor { get; set; }
        bool? Referral { get; set; }
        string ReferredBy { get; set; }
        string SexDescriptor { get; set; }
        string SocialMediaNetworkName { get; set; }
        string SocialMediaUserName { get; set; }
        string SourceSystemDescriptor { get; set; }
        string TeacherCandidateIdentifier { get; set; }

        // One-to-one relationships

        IProspectAid ProspectAid { get; set; }

        IProspectCurrentPosition ProspectCurrentPosition { get; set; }

        IProspectQualifications ProspectQualifications { get; set; }

        // Lists
        ICollection<IProspectDisability> ProspectDisabilities { get; set; }
        ICollection<IProspectPersonalIdentificationDocument> ProspectPersonalIdentificationDocuments { get; set; }
        ICollection<IProspectRace> ProspectRaces { get; set; }
        ICollection<IProspectRecruitmentEvent> ProspectRecruitmentEvents { get; set; }
        ICollection<IProspectTelephone> ProspectTelephones { get; set; }
        ICollection<IProspectTouchpoint> ProspectTouchpoints { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffApplicantAssociation model.
    /// </summary>
    public interface IStaffApplicantAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantIdentifier { get; set; }
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
    /// Defines available properties and methods for the abstraction of the SurveyResponseExtension model.
    /// </summary>
    public interface ISurveyResponseExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ISurveyResponse SurveyResponse { get; set; }

        // Non-PK properties
        string ApplicantIdentifier { get; set; }
        string TeacherCandidateIdentifier { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ApplicantResourceId { get; set; }
        string ApplicantDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponseTeacherCandidateTargetAssociation model.
    /// </summary>
    public interface ISurveyResponseTeacherCandidateTargetAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SurveyResponseResourceId { get; set; }
        string SurveyResponseDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
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
    /// Defines available properties and methods for the abstraction of the SurveySectionResponseTeacherCandidateTargetAssociation model.
    /// </summary>
    public interface ISurveySectionResponseTeacherCandidateTargetAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveySectionTitle { get; set; }
        [NaturalKeyMember]
        string TeacherCandidateIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SurveySectionResponseResourceId { get; set; }
        string SurveySectionResponseDiscriminator { get; set; }
        Guid? TeacherCandidateResourceId { get; set; }
        string TeacherCandidateDiscriminator { get; set; }
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
        string PersonId { get; set; }
        string PreviousCareerDescriptor { get; set; }
        string ProfileThumbnail { get; set; }
        bool? ProgramComplete { get; set; }
        string SexDescriptor { get; set; }
        string SourceSystemDescriptor { get; set; }
        string StudentUniqueId { get; set; }
        decimal? TuitionCost { get; set; }

        // One-to-one relationships

        ITeacherCandidateBackgroundCheck TeacherCandidateBackgroundCheck { get; set; }

        // Lists
        ICollection<ITeacherCandidateAddress> TeacherCandidateAddresses { get; set; }
        ICollection<ITeacherCandidateAid> TeacherCandidateAids { get; set; }
        ICollection<ITeacherCandidateCharacteristic> TeacherCandidateCharacteristics { get; set; }
        ICollection<ITeacherCandidateCohortYear> TeacherCandidateCohortYears { get; set; }
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
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
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
        string AccreditationStatusDescriptor { get; set; }
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
