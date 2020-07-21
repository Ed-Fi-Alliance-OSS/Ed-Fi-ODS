using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Common;

#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.EdFi
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AbsenceEventCategoryDescriptor model.
    /// </summary>
    public interface IAbsenceEventCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AbsenceEventCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AcademicHonorCategoryDescriptor model.
    /// </summary>
    public interface IAcademicHonorCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AcademicHonorCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AcademicSubjectDescriptor model.
    /// </summary>
    public interface IAcademicSubjectDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AcademicSubjectDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AcademicWeek model.
    /// </summary>
    public interface IAcademicWeek : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        string WeekIdentifier { get; set; }

        // Non-PK properties
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        int TotalInstructionalDays { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AccommodationDescriptor model.
    /// </summary>
    public interface IAccommodationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AccommodationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Account model.
    /// </summary>
    public interface IAccount : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AccountIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }

        // Non-PK properties
        string AccountName { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IAccountAccountCode> AccountAccountCodes { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AccountabilityRating model.
    /// </summary>
    public interface IAccountabilityRating : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string RatingTitle { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        string Rating { get; set; }
        DateTime? RatingDate { get; set; }
        string RatingOrganization { get; set; }
        string RatingProgram { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AccountAccountCode model.
    /// </summary>
    public interface IAccountAccountCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAccount Account { get; set; }
        [NaturalKeyMember]
        string AccountClassificationDescriptor { get; set; }
        [NaturalKeyMember]
        string AccountCodeNumber { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AccountCodeResourceId { get; set; }
        string AccountCodeDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AccountClassificationDescriptor model.
    /// </summary>
    public interface IAccountClassificationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AccountClassificationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AccountCode model.
    /// </summary>
    public interface IAccountCode : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AccountClassificationDescriptor { get; set; }
        [NaturalKeyMember]
        string AccountCodeNumber { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }

        // Non-PK properties
        string AccountCodeDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AchievementCategoryDescriptor model.
    /// </summary>
    public interface IAchievementCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AchievementCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Actual model.
    /// </summary>
    public interface IActual : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AccountIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime AsOfDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }

        // Non-PK properties
        decimal AmountToDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AccountResourceId { get; set; }
        string AccountDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AdditionalCreditTypeDescriptor model.
    /// </summary>
    public interface IAdditionalCreditTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AdditionalCreditTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AddressTypeDescriptor model.
    /// </summary>
    public interface IAddressTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AddressTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AdministrationEnvironmentDescriptor model.
    /// </summary>
    public interface IAdministrationEnvironmentDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AdministrationEnvironmentDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AdministrativeFundingControlDescriptor model.
    /// </summary>
    public interface IAdministrativeFundingControlDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AdministrativeFundingControlDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Assessment model.
    /// </summary>
    public interface IAssessment : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties
        bool? AdaptiveAssessment { get; set; }
        string AssessmentCategoryDescriptor { get; set; }
        string AssessmentFamily { get; set; }
        string AssessmentForm { get; set; }
        string AssessmentTitle { get; set; }
        int? AssessmentVersion { get; set; }
        int? EducationOrganizationId { get; set; }
        decimal? MaxRawScore { get; set; }
        string Nomenclature { get; set; }
        DateTime? RevisionDate { get; set; }

        // One-to-one relationships

        IAssessmentContentStandard AssessmentContentStandard { get; set; }

        IAssessmentPeriod AssessmentPeriod { get; set; }

        // Lists
        ICollection<IAssessmentAcademicSubject> AssessmentAcademicSubjects { get; set; }
        ICollection<IAssessmentAssessedGradeLevel> AssessmentAssessedGradeLevels { get; set; }
        ICollection<IAssessmentIdentificationCode> AssessmentIdentificationCodes { get; set; }
        ICollection<IAssessmentLanguage> AssessmentLanguages { get; set; }
        ICollection<IAssessmentPerformanceLevel> AssessmentPerformanceLevels { get; set; }
        ICollection<IAssessmentPlatformType> AssessmentPlatformTypes { get; set; }
        ICollection<IAssessmentProgram> AssessmentPrograms { get; set; }
        ICollection<IAssessmentScore> AssessmentScores { get; set; }
        ICollection<IAssessmentSection> AssessmentSections { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentAcademicSubject model.
    /// </summary>
    public interface IAssessmentAcademicSubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentAssessedGradeLevel model.
    /// </summary>
    public interface IAssessmentAssessedGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentCategoryDescriptor model.
    /// </summary>
    public interface IAssessmentCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AssessmentCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentContentStandard model.
    /// </summary>
    public interface IAssessmentContentStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        int? MandatingEducationOrganizationId { get; set; }
        DateTime? PublicationDate { get; set; }
        string PublicationStatusDescriptor { get; set; }
        short? PublicationYear { get; set; }
        string Title { get; set; }
        string URI { get; set; }
        string Version { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IAssessmentContentStandardAuthor> AssessmentContentStandardAuthors { get; set; }

        // Resource reference data
        Guid? MandatingEducationOrganizationResourceId { get; set; }
        string MandatingEducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentContentStandardAuthor model.
    /// </summary>
    public interface IAssessmentContentStandardAuthor : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessmentContentStandard AssessmentContentStandard { get; set; }
        [NaturalKeyMember]
        string Author { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentIdentificationCode model.
    /// </summary>
    public interface IAssessmentIdentificationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
        [NaturalKeyMember]
        string AssessmentIdentificationSystemDescriptor { get; set; }

        // Non-PK properties
        string AssigningOrganizationIdentificationCode { get; set; }
        string IdentificationCode { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentIdentificationSystemDescriptor model.
    /// </summary>
    public interface IAssessmentIdentificationSystemDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AssessmentIdentificationSystemDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentItem model.
    /// </summary>
    public interface IAssessmentItem : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        string IdentificationCode { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties
        string AssessmentItemCategoryDescriptor { get; set; }
        string AssessmentItemURI { get; set; }
        string CorrectResponse { get; set; }
        string ExpectedTimeAssessed { get; set; }
        string ItemText { get; set; }
        decimal? MaxRawScore { get; set; }
        string Nomenclature { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IAssessmentItemLearningStandard> AssessmentItemLearningStandards { get; set; }
        ICollection<IAssessmentItemPossibleResponse> AssessmentItemPossibleResponses { get; set; }

        // Resource reference data
        Guid? AssessmentResourceId { get; set; }
        string AssessmentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentItemCategoryDescriptor model.
    /// </summary>
    public interface IAssessmentItemCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AssessmentItemCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentItemLearningStandard model.
    /// </summary>
    public interface IAssessmentItemLearningStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessmentItem AssessmentItem { get; set; }
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentItemPossibleResponse model.
    /// </summary>
    public interface IAssessmentItemPossibleResponse : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessmentItem AssessmentItem { get; set; }
        [NaturalKeyMember]
        string ResponseValue { get; set; }

        // Non-PK properties
        bool? CorrectResponse { get; set; }
        string ResponseDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentItemResultDescriptor model.
    /// </summary>
    public interface IAssessmentItemResultDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AssessmentItemResultDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentLanguage model.
    /// </summary>
    public interface IAssessmentLanguage : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentPerformanceLevel model.
    /// </summary>
    public interface IAssessmentPerformanceLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }
        [NaturalKeyMember]
        string PerformanceLevelDescriptor { get; set; }

        // Non-PK properties
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentPeriod model.
    /// </summary>
    public interface IAssessmentPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }

        // Non-PK properties
        string AssessmentPeriodDescriptor { get; set; }
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentPeriodDescriptor model.
    /// </summary>
    public interface IAssessmentPeriodDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AssessmentPeriodDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentPlatformType model.
    /// </summary>
    public interface IAssessmentPlatformType : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
        [NaturalKeyMember]
        string PlatformTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentProgram model.
    /// </summary>
    public interface IAssessmentProgram : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
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
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentReportingMethodDescriptor model.
    /// </summary>
    public interface IAssessmentReportingMethodDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AssessmentReportingMethodDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentScore model.
    /// </summary>
    public interface IAssessmentScore : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }

        // Non-PK properties
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AssessmentSection model.
    /// </summary>
    public interface IAssessmentSection : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IAssessment Assessment { get; set; }
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

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AttemptStatusDescriptor model.
    /// </summary>
    public interface IAttemptStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AttemptStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AttendanceEventCategoryDescriptor model.
    /// </summary>
    public interface IAttendanceEventCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int AttendanceEventCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BehaviorDescriptor model.
    /// </summary>
    public interface IBehaviorDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int BehaviorDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BellSchedule model.
    /// </summary>
    public interface IBellSchedule : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string BellScheduleName { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties
        string AlternateDayName { get; set; }
        TimeSpan? EndTime { get; set; }
        TimeSpan? StartTime { get; set; }
        int? TotalInstructionalTime { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IBellScheduleClassPeriod> BellScheduleClassPeriods { get; set; }
        ICollection<IBellScheduleDate> BellScheduleDates { get; set; }
        ICollection<IBellScheduleGradeLevel> BellScheduleGradeLevels { get; set; }

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BellScheduleClassPeriod model.
    /// </summary>
    public interface IBellScheduleClassPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBellSchedule BellSchedule { get; set; }
        [NaturalKeyMember]
        string ClassPeriodName { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ClassPeriodResourceId { get; set; }
        string ClassPeriodDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BellScheduleDate model.
    /// </summary>
    public interface IBellScheduleDate : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBellSchedule BellSchedule { get; set; }
        [NaturalKeyMember]
        DateTime Date { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BellScheduleGradeLevel model.
    /// </summary>
    public interface IBellScheduleGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBellSchedule BellSchedule { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Budget model.
    /// </summary>
    public interface IBudget : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AccountIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime AsOfDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }

        // Non-PK properties
        decimal Amount { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AccountResourceId { get; set; }
        string AccountDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Calendar model.
    /// </summary>
    public interface ICalendar : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CalendarCode { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        string CalendarTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICalendarGradeLevel> CalendarGradeLevels { get; set; }

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CalendarDate model.
    /// </summary>
    public interface ICalendarDate : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CalendarCode { get; set; }
        [NaturalKeyMember]
        DateTime Date { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<ICalendarDateCalendarEvent> CalendarDateCalendarEvents { get; set; }

        // Resource reference data
        Guid? CalendarResourceId { get; set; }
        string CalendarDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CalendarDateCalendarEvent model.
    /// </summary>
    public interface ICalendarDateCalendarEvent : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICalendarDate CalendarDate { get; set; }
        [NaturalKeyMember]
        string CalendarEventDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CalendarEventDescriptor model.
    /// </summary>
    public interface ICalendarEventDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CalendarEventDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CalendarGradeLevel model.
    /// </summary>
    public interface ICalendarGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICalendar Calendar { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CalendarTypeDescriptor model.
    /// </summary>
    public interface ICalendarTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CalendarTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CareerPathwayDescriptor model.
    /// </summary>
    public interface ICareerPathwayDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CareerPathwayDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CharterApprovalAgencyTypeDescriptor model.
    /// </summary>
    public interface ICharterApprovalAgencyTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CharterApprovalAgencyTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CharterStatusDescriptor model.
    /// </summary>
    public interface ICharterStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CharterStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CitizenshipStatusDescriptor model.
    /// </summary>
    public interface ICitizenshipStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CitizenshipStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ClassPeriod model.
    /// </summary>
    public interface IClassPeriod : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ClassPeriodName { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties
        bool? OfficialAttendancePeriod { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IClassPeriodMeetingTime> ClassPeriodMeetingTimes { get; set; }

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ClassPeriodMeetingTime model.
    /// </summary>
    public interface IClassPeriodMeetingTime : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IClassPeriod ClassPeriod { get; set; }
        [NaturalKeyMember]
        TimeSpan EndTime { get; set; }
        [NaturalKeyMember]
        TimeSpan StartTime { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ClassroomPositionDescriptor model.
    /// </summary>
    public interface IClassroomPositionDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ClassroomPositionDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Cohort model.
    /// </summary>
    public interface ICohort : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CohortIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string CohortDescription { get; set; }
        string CohortScopeDescriptor { get; set; }
        string CohortTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICohortProgram> CohortPrograms { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CohortProgram model.
    /// </summary>
    public interface ICohortProgram : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICohort Cohort { get; set; }
        [NaturalKeyMember]
        int ProgramEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CohortScopeDescriptor model.
    /// </summary>
    public interface ICohortScopeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CohortScopeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CohortTypeDescriptor model.
    /// </summary>
    public interface ICohortTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CohortTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CohortYearTypeDescriptor model.
    /// </summary>
    public interface ICohortYearTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CohortYearTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CommunityOrganization model.
    /// </summary>
    public interface ICommunityOrganization : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int CommunityOrganizationId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CommunityProvider model.
    /// </summary>
    public interface ICommunityProvider : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int CommunityProviderId { get; set; }

        // Non-PK properties
        int? CommunityOrganizationId { get; set; }
        bool? LicenseExemptIndicator { get; set; }
        string ProviderCategoryDescriptor { get; set; }
        string ProviderProfitabilityDescriptor { get; set; }
        string ProviderStatusDescriptor { get; set; }
        bool? SchoolIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CommunityOrganizationResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CommunityProviderLicense model.
    /// </summary>
    public interface ICommunityProviderLicense : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int CommunityProviderId { get; set; }
        [NaturalKeyMember]
        string LicenseIdentifier { get; set; }
        [NaturalKeyMember]
        string LicensingOrganization { get; set; }

        // Non-PK properties
        int? AuthorizedFacilityCapacity { get; set; }
        DateTime LicenseEffectiveDate { get; set; }
        DateTime? LicenseExpirationDate { get; set; }
        DateTime? LicenseIssueDate { get; set; }
        string LicenseStatusDescriptor { get; set; }
        string LicenseTypeDescriptor { get; set; }
        int? OldestAgeAuthorizedToServe { get; set; }
        int? YoungestAgeAuthorizedToServe { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CommunityProviderResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CompetencyLevelDescriptor model.
    /// </summary>
    public interface ICompetencyLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CompetencyLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CompetencyObjective model.
    /// </summary>
    public interface ICompetencyObjective : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string Objective { get; set; }
        [NaturalKeyMember]
        string ObjectiveGradeLevelDescriptor { get; set; }

        // Non-PK properties
        string CompetencyObjectiveId { get; set; }
        string Description { get; set; }
        string SuccessCriteria { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactTypeDescriptor model.
    /// </summary>
    public interface IContactTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ContactTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContentClassDescriptor model.
    /// </summary>
    public interface IContentClassDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ContentClassDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContinuationOfServicesReasonDescriptor model.
    /// </summary>
    public interface IContinuationOfServicesReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ContinuationOfServicesReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContractedStaff model.
    /// </summary>
    public interface IContractedStaff : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AccountIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime AsOfDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        decimal AmountToDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AccountResourceId { get; set; }
        string AccountDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CostRateDescriptor model.
    /// </summary>
    public interface ICostRateDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CostRateDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CountryDescriptor model.
    /// </summary>
    public interface ICountryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CountryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Course model.
    /// </summary>
    public interface ICourse : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string CareerPathwayDescriptor { get; set; }
        string CourseDefinedByDescriptor { get; set; }
        string CourseDescription { get; set; }
        string CourseGPAApplicabilityDescriptor { get; set; }
        string CourseTitle { get; set; }
        DateTime? DateCourseAdopted { get; set; }
        bool? HighSchoolCourseRequirement { get; set; }
        int? MaxCompletionsForCredit { get; set; }
        decimal? MaximumAvailableCreditConversion { get; set; }
        decimal? MaximumAvailableCredits { get; set; }
        string MaximumAvailableCreditTypeDescriptor { get; set; }
        decimal? MinimumAvailableCreditConversion { get; set; }
        decimal? MinimumAvailableCredits { get; set; }
        string MinimumAvailableCreditTypeDescriptor { get; set; }
        int NumberOfParts { get; set; }
        int? TimeRequiredForCompletion { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICourseCompetencyLevel> CourseCompetencyLevels { get; set; }
        ICollection<ICourseIdentificationCode> CourseIdentificationCodes { get; set; }
        ICollection<ICourseLearningObjective> CourseLearningObjectives { get; set; }
        ICollection<ICourseLearningStandard> CourseLearningStandards { get; set; }
        ICollection<ICourseLevelCharacteristic> CourseLevelCharacteristics { get; set; }
        ICollection<ICourseOfferedGradeLevel> CourseOfferedGradeLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseAttemptResultDescriptor model.
    /// </summary>
    public interface ICourseAttemptResultDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CourseAttemptResultDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseCompetencyLevel model.
    /// </summary>
    public interface ICourseCompetencyLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourse Course { get; set; }
        [NaturalKeyMember]
        string CompetencyLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseDefinedByDescriptor model.
    /// </summary>
    public interface ICourseDefinedByDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CourseDefinedByDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseGPAApplicabilityDescriptor model.
    /// </summary>
    public interface ICourseGPAApplicabilityDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CourseGPAApplicabilityDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseIdentificationCode model.
    /// </summary>
    public interface ICourseIdentificationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourse Course { get; set; }
        [NaturalKeyMember]
        string CourseIdentificationSystemDescriptor { get; set; }

        // Non-PK properties
        string AssigningOrganizationIdentificationCode { get; set; }
        string CourseCatalogURL { get; set; }
        string IdentificationCode { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseIdentificationSystemDescriptor model.
    /// </summary>
    public interface ICourseIdentificationSystemDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CourseIdentificationSystemDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseLearningObjective model.
    /// </summary>
    public interface ICourseLearningObjective : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourse Course { get; set; }
        [NaturalKeyMember]
        string LearningObjectiveId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningObjectiveResourceId { get; set; }
        string LearningObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseLearningStandard model.
    /// </summary>
    public interface ICourseLearningStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourse Course { get; set; }
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseLevelCharacteristic model.
    /// </summary>
    public interface ICourseLevelCharacteristic : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourse Course { get; set; }
        [NaturalKeyMember]
        string CourseLevelCharacteristicDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseLevelCharacteristicDescriptor model.
    /// </summary>
    public interface ICourseLevelCharacteristicDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CourseLevelCharacteristicDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseOfferedGradeLevel model.
    /// </summary>
    public interface ICourseOfferedGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourse Course { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseOffering model.
    /// </summary>
    public interface ICourseOffering : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string LocalCourseCode { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SessionName { get; set; }

        // Non-PK properties
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        int? InstructionalTimePlanned { get; set; }
        string LocalCourseTitle { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICourseOfferingCourseLevelCharacteristic> CourseOfferingCourseLevelCharacteristics { get; set; }
        ICollection<ICourseOfferingCurriculumUsed> CourseOfferingCurriculumUseds { get; set; }
        ICollection<ICourseOfferingOfferedGradeLevel> CourseOfferingOfferedGradeLevels { get; set; }

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? SchoolResourceId { get; set; }
        Guid? SessionResourceId { get; set; }
        string SessionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseOfferingCourseLevelCharacteristic model.
    /// </summary>
    public interface ICourseOfferingCourseLevelCharacteristic : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseOffering CourseOffering { get; set; }
        [NaturalKeyMember]
        string CourseLevelCharacteristicDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseOfferingCurriculumUsed model.
    /// </summary>
    public interface ICourseOfferingCurriculumUsed : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseOffering CourseOffering { get; set; }
        [NaturalKeyMember]
        string CurriculumUsedDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseOfferingOfferedGradeLevel model.
    /// </summary>
    public interface ICourseOfferingOfferedGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseOffering CourseOffering { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseRepeatCodeDescriptor model.
    /// </summary>
    public interface ICourseRepeatCodeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CourseRepeatCodeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseTranscript model.
    /// </summary>
    public interface ICourseTranscript : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
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
        string StudentUniqueId { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        string AlternativeCourseCode { get; set; }
        string AlternativeCourseTitle { get; set; }
        string AssigningOrganizationIdentificationCode { get; set; }
        decimal? AttemptedCreditConversion { get; set; }
        decimal? AttemptedCredits { get; set; }
        string AttemptedCreditTypeDescriptor { get; set; }
        string CourseCatalogURL { get; set; }
        string CourseRepeatCodeDescriptor { get; set; }
        string CourseTitle { get; set; }
        decimal? EarnedCreditConversion { get; set; }
        decimal EarnedCredits { get; set; }
        string EarnedCreditTypeDescriptor { get; set; }
        int? ExternalEducationOrganizationId { get; set; }
        string FinalLetterGradeEarned { get; set; }
        decimal? FinalNumericGradeEarned { get; set; }
        string MethodCreditEarnedDescriptor { get; set; }
        string WhenTakenGradeLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICourseTranscriptAcademicSubject> CourseTranscriptAcademicSubjects { get; set; }
        ICollection<ICourseTranscriptAlternativeCourseIdentificationCode> CourseTranscriptAlternativeCourseIdentificationCodes { get; set; }
        ICollection<ICourseTranscriptCreditCategory> CourseTranscriptCreditCategories { get; set; }
        ICollection<ICourseTranscriptEarnedAdditionalCredits> CourseTranscriptEarnedAdditionalCredits { get; set; }

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? ExternalEducationOrganizationResourceId { get; set; }
        string ExternalEducationOrganizationDiscriminator { get; set; }
        Guid? StudentAcademicRecordResourceId { get; set; }
        string StudentAcademicRecordDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseTranscriptAcademicSubject model.
    /// </summary>
    public interface ICourseTranscriptAcademicSubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseTranscript CourseTranscript { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseTranscriptAlternativeCourseIdentificationCode model.
    /// </summary>
    public interface ICourseTranscriptAlternativeCourseIdentificationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseTranscript CourseTranscript { get; set; }
        [NaturalKeyMember]
        string CourseIdentificationSystemDescriptor { get; set; }

        // Non-PK properties
        string AssigningOrganizationIdentificationCode { get; set; }
        string CourseCatalogURL { get; set; }
        string IdentificationCode { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseTranscriptCreditCategory model.
    /// </summary>
    public interface ICourseTranscriptCreditCategory : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseTranscript CourseTranscript { get; set; }
        [NaturalKeyMember]
        string CreditCategoryDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CourseTranscriptEarnedAdditionalCredits model.
    /// </summary>
    public interface ICourseTranscriptEarnedAdditionalCredits : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICourseTranscript CourseTranscript { get; set; }
        [NaturalKeyMember]
        string AdditionalCreditTypeDescriptor { get; set; }

        // Non-PK properties
        decimal Credits { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Credential model.
    /// </summary>
    public interface ICredential : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CredentialIdentifier { get; set; }
        [NaturalKeyMember]
        string StateOfIssueStateAbbreviationDescriptor { get; set; }

        // Non-PK properties
        string CredentialFieldDescriptor { get; set; }
        string CredentialTypeDescriptor { get; set; }
        DateTime? EffectiveDate { get; set; }
        DateTime? ExpirationDate { get; set; }
        DateTime IssuanceDate { get; set; }
        string Namespace { get; set; }
        string TeachingCredentialBasisDescriptor { get; set; }
        string TeachingCredentialDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICredentialAcademicSubject> CredentialAcademicSubjects { get; set; }
        ICollection<ICredentialEndorsement> CredentialEndorsements { get; set; }
        ICollection<ICredentialGradeLevel> CredentialGradeLevels { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialAcademicSubject model.
    /// </summary>
    public interface ICredentialAcademicSubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredential Credential { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialEndorsement model.
    /// </summary>
    public interface ICredentialEndorsement : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredential Credential { get; set; }
        [NaturalKeyMember]
        string CredentialEndorsementX { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialFieldDescriptor model.
    /// </summary>
    public interface ICredentialFieldDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CredentialFieldDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialGradeLevel model.
    /// </summary>
    public interface ICredentialGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ICredential Credential { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialTypeDescriptor model.
    /// </summary>
    public interface ICredentialTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CredentialTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CreditCategoryDescriptor model.
    /// </summary>
    public interface ICreditCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CreditCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CreditTypeDescriptor model.
    /// </summary>
    public interface ICreditTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CreditTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CTEProgramServiceDescriptor model.
    /// </summary>
    public interface ICTEProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CTEProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CurriculumUsedDescriptor model.
    /// </summary>
    public interface ICurriculumUsedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int CurriculumUsedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DeliveryMethodDescriptor model.
    /// </summary>
    public interface IDeliveryMethodDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DeliveryMethodDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Descriptor model.
    /// </summary>
    public interface IDescriptor : IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DescriptorId { get; set; }

        // Non-PK properties
        string CodeValue { get; set; }
        string Description { get; set; }
        DateTime? EffectiveBeginDate { get; set; }
        DateTime? EffectiveEndDate { get; set; }
        string Namespace { get; set; }
        int? PriorDescriptorId { get; set; }
        string ShortDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DiagnosisDescriptor model.
    /// </summary>
    public interface IDiagnosisDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DiagnosisDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DiplomaLevelDescriptor model.
    /// </summary>
    public interface IDiplomaLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DiplomaLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DiplomaTypeDescriptor model.
    /// </summary>
    public interface IDiplomaTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DiplomaTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisabilityDescriptor model.
    /// </summary>
    public interface IDisabilityDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DisabilityDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisabilityDesignationDescriptor model.
    /// </summary>
    public interface IDisabilityDesignationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DisabilityDesignationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisabilityDeterminationSourceTypeDescriptor model.
    /// </summary>
    public interface IDisabilityDeterminationSourceTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DisabilityDeterminationSourceTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineAction model.
    /// </summary>
    public interface IDisciplineAction : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string DisciplineActionIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime DisciplineDate { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        decimal? ActualDisciplineActionLength { get; set; }
        int? AssignmentSchoolId { get; set; }
        decimal? DisciplineActionLength { get; set; }
        string DisciplineActionLengthDifferenceReasonDescriptor { get; set; }
        bool? IEPPlacementMeetingIndicator { get; set; }
        bool? ReceivedEducationServicesDuringExpulsion { get; set; }
        bool? RelatedToZeroTolerancePolicy { get; set; }
        int ResponsibilitySchoolId { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IDisciplineActionDiscipline> DisciplineActionDisciplines { get; set; }
        ICollection<IDisciplineActionStaff> DisciplineActionStaffs { get; set; }
        ICollection<IDisciplineActionStudentDisciplineIncidentAssociation> DisciplineActionStudentDisciplineIncidentAssociations { get; set; }

        // Resource reference data
        Guid? AssignmentSchoolResourceId { get; set; }
        Guid? ResponsibilitySchoolResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineActionDiscipline model.
    /// </summary>
    public interface IDisciplineActionDiscipline : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IDisciplineAction DisciplineAction { get; set; }
        [NaturalKeyMember]
        string DisciplineDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineActionLengthDifferenceReasonDescriptor model.
    /// </summary>
    public interface IDisciplineActionLengthDifferenceReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DisciplineActionLengthDifferenceReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineActionStaff model.
    /// </summary>
    public interface IDisciplineActionStaff : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IDisciplineAction DisciplineAction { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineActionStudentDisciplineIncidentAssociation model.
    /// </summary>
    public interface IDisciplineActionStudentDisciplineIncidentAssociation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IDisciplineAction DisciplineAction { get; set; }
        [NaturalKeyMember]
        string IncidentIdentifier { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentDisciplineIncidentAssociationResourceId { get; set; }
        string StudentDisciplineIncidentAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineDescriptor model.
    /// </summary>
    public interface IDisciplineDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DisciplineDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineIncident model.
    /// </summary>
    public interface IDisciplineIncident : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string IncidentIdentifier { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties
        string CaseNumber { get; set; }
        decimal? IncidentCost { get; set; }
        DateTime IncidentDate { get; set; }
        string IncidentDescription { get; set; }
        string IncidentLocationDescriptor { get; set; }
        TimeSpan? IncidentTime { get; set; }
        bool? ReportedToLawEnforcement { get; set; }
        string ReporterDescriptionDescriptor { get; set; }
        string ReporterName { get; set; }
        string StaffUniqueId { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IDisciplineIncidentBehavior> DisciplineIncidentBehaviors { get; set; }
        ICollection<IDisciplineIncidentExternalParticipant> DisciplineIncidentExternalParticipants { get; set; }
        ICollection<IDisciplineIncidentWeapon> DisciplineIncidentWeapons { get; set; }

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineIncidentBehavior model.
    /// </summary>
    public interface IDisciplineIncidentBehavior : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IDisciplineIncident DisciplineIncident { get; set; }
        [NaturalKeyMember]
        string BehaviorDescriptor { get; set; }

        // Non-PK properties
        string BehaviorDetailedDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineIncidentExternalParticipant model.
    /// </summary>
    public interface IDisciplineIncidentExternalParticipant : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IDisciplineIncident DisciplineIncident { get; set; }
        [NaturalKeyMember]
        string DisciplineIncidentParticipationCodeDescriptor { get; set; }
        [NaturalKeyMember]
        string FirstName { get; set; }
        [NaturalKeyMember]
        string LastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineIncidentParticipationCodeDescriptor model.
    /// </summary>
    public interface IDisciplineIncidentParticipationCodeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int DisciplineIncidentParticipationCodeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the DisciplineIncidentWeapon model.
    /// </summary>
    public interface IDisciplineIncidentWeapon : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IDisciplineIncident DisciplineIncident { get; set; }
        [NaturalKeyMember]
        string WeaponDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationalEnvironmentDescriptor model.
    /// </summary>
    public interface IEducationalEnvironmentDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EducationalEnvironmentDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContent model.
    /// </summary>
    public interface IEducationContent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ContentIdentifier { get; set; }

        // Non-PK properties
        bool? AdditionalAuthorsIndicator { get; set; }
        string ContentClassDescriptor { get; set; }
        decimal? Cost { get; set; }
        string CostRateDescriptor { get; set; }
        string Description { get; set; }
        string InteractivityStyleDescriptor { get; set; }
        string LearningResourceMetadataURI { get; set; }
        string LearningStandardId { get; set; }
        string Namespace { get; set; }
        DateTime? PublicationDate { get; set; }
        short? PublicationYear { get; set; }
        string Publisher { get; set; }
        string ShortDescription { get; set; }
        string TimeRequired { get; set; }
        string UseRightsURL { get; set; }
        string Version { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEducationContentAppropriateGradeLevel> EducationContentAppropriateGradeLevels { get; set; }
        ICollection<IEducationContentAppropriateSex> EducationContentAppropriateSexes { get; set; }
        ICollection<IEducationContentAuthor> EducationContentAuthors { get; set; }
        ICollection<IEducationContentDerivativeSourceEducationContent> EducationContentDerivativeSourceEducationContents { get; set; }
        ICollection<IEducationContentDerivativeSourceLearningResourceMetadataURI> EducationContentDerivativeSourceLearningResourceMetadataURIs { get; set; }
        ICollection<IEducationContentDerivativeSourceURI> EducationContentDerivativeSourceURIs { get; set; }
        ICollection<IEducationContentLanguage> EducationContentLanguages { get; set; }

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContentAppropriateGradeLevel model.
    /// </summary>
    public interface IEducationContentAppropriateGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationContent EducationContent { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContentAppropriateSex model.
    /// </summary>
    public interface IEducationContentAppropriateSex : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationContent EducationContent { get; set; }
        [NaturalKeyMember]
        string SexDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContentAuthor model.
    /// </summary>
    public interface IEducationContentAuthor : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationContent EducationContent { get; set; }
        [NaturalKeyMember]
        string Author { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContentDerivativeSourceEducationContent model.
    /// </summary>
    public interface IEducationContentDerivativeSourceEducationContent : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationContent EducationContent { get; set; }
        [NaturalKeyMember]
        string DerivativeSourceContentIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? DerivativeSourceEducationContentResourceId { get; set; }
        string DerivativeSourceEducationContentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContentDerivativeSourceLearningResourceMetadataURI model.
    /// </summary>
    public interface IEducationContentDerivativeSourceLearningResourceMetadataURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationContent EducationContent { get; set; }
        [NaturalKeyMember]
        string DerivativeSourceLearningResourceMetadataURI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContentDerivativeSourceURI model.
    /// </summary>
    public interface IEducationContentDerivativeSourceURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationContent EducationContent { get; set; }
        [NaturalKeyMember]
        string DerivativeSourceURI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationContentLanguage model.
    /// </summary>
    public interface IEducationContentLanguage : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationContent EducationContent { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganization model.
    /// </summary>
    public interface IEducationOrganization : IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }

        // Non-PK properties
        string NameOfInstitution { get; set; }
        string OperationalStatusDescriptor { get; set; }
        string ShortNameOfInstitution { get; set; }
        string WebSite { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEducationOrganizationAddress> EducationOrganizationAddresses { get; set; }
        ICollection<IEducationOrganizationCategory> EducationOrganizationCategories { get; set; }
        ICollection<IEducationOrganizationIdentificationCode> EducationOrganizationIdentificationCodes { get; set; }
        ICollection<IEducationOrganizationIndicator> EducationOrganizationIndicators { get; set; }
        ICollection<IEducationOrganizationInstitutionTelephone> EducationOrganizationInstitutionTelephones { get; set; }
        ICollection<IEducationOrganizationInternationalAddress> EducationOrganizationInternationalAddresses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationAddress model.
    /// </summary>
    public interface IEducationOrganizationAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganization EducationOrganization { get; set; }
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
        ICollection<IEducationOrganizationAddressPeriod> EducationOrganizationAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationAddressPeriod model.
    /// </summary>
    public interface IEducationOrganizationAddressPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationAddress EducationOrganizationAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationCategory model.
    /// </summary>
    public interface IEducationOrganizationCategory : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganization EducationOrganization { get; set; }
        [NaturalKeyMember]
        string EducationOrganizationCategoryDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationCategoryDescriptor model.
    /// </summary>
    public interface IEducationOrganizationCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EducationOrganizationCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationIdentificationCode model.
    /// </summary>
    public interface IEducationOrganizationIdentificationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganization EducationOrganization { get; set; }
        [NaturalKeyMember]
        string EducationOrganizationIdentificationSystemDescriptor { get; set; }

        // Non-PK properties
        string IdentificationCode { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationIdentificationSystemDescriptor model.
    /// </summary>
    public interface IEducationOrganizationIdentificationSystemDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EducationOrganizationIdentificationSystemDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationIndicator model.
    /// </summary>
    public interface IEducationOrganizationIndicator : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganization EducationOrganization { get; set; }
        [NaturalKeyMember]
        string IndicatorDescriptor { get; set; }

        // Non-PK properties
        string DesignatedBy { get; set; }
        string IndicatorGroupDescriptor { get; set; }
        string IndicatorLevelDescriptor { get; set; }
        string IndicatorValue { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEducationOrganizationIndicatorPeriod> EducationOrganizationIndicatorPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationIndicatorPeriod model.
    /// </summary>
    public interface IEducationOrganizationIndicatorPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganizationIndicator EducationOrganizationIndicator { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationInstitutionTelephone model.
    /// </summary>
    public interface IEducationOrganizationInstitutionTelephone : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganization EducationOrganization { get; set; }
        [NaturalKeyMember]
        string InstitutionTelephoneNumberTypeDescriptor { get; set; }

        // Non-PK properties
        string TelephoneNumber { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationInternationalAddress model.
    /// </summary>
    public interface IEducationOrganizationInternationalAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IEducationOrganization EducationOrganization { get; set; }
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
    /// Defines available properties and methods for the abstraction of the EducationOrganizationInterventionPrescriptionAssociation model.
    /// </summary>
    public interface IEducationOrganizationInterventionPrescriptionAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int InterventionPrescriptionEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string InterventionPrescriptionIdentificationCode { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? InterventionPrescriptionResourceId { get; set; }
        string InterventionPrescriptionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationNetwork model.
    /// </summary>
    public interface IEducationOrganizationNetwork : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationNetworkId { get; set; }

        // Non-PK properties
        string NetworkPurposeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationNetworkAssociation model.
    /// </summary>
    public interface IEducationOrganizationNetworkAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationNetworkId { get; set; }
        [NaturalKeyMember]
        int MemberEducationOrganizationId { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationNetworkResourceId { get; set; }
        Guid? MemberEducationOrganizationResourceId { get; set; }
        string MemberEducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationOrganizationPeerAssociation model.
    /// </summary>
    public interface IEducationOrganizationPeerAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int PeerEducationOrganizationId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? PeerEducationOrganizationResourceId { get; set; }
        string PeerEducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationPlanDescriptor model.
    /// </summary>
    public interface IEducationPlanDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EducationPlanDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducationServiceCenter model.
    /// </summary>
    public interface IEducationServiceCenter : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationServiceCenterId { get; set; }

        // Non-PK properties
        int? StateEducationAgencyId { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StateEducationAgencyResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ElectronicMailTypeDescriptor model.
    /// </summary>
    public interface IElectronicMailTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ElectronicMailTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EmploymentStatusDescriptor model.
    /// </summary>
    public interface IEmploymentStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EmploymentStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EntryGradeLevelReasonDescriptor model.
    /// </summary>
    public interface IEntryGradeLevelReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EntryGradeLevelReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EntryTypeDescriptor model.
    /// </summary>
    public interface IEntryTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EntryTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EventCircumstanceDescriptor model.
    /// </summary>
    public interface IEventCircumstanceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int EventCircumstanceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ExitWithdrawTypeDescriptor model.
    /// </summary>
    public interface IExitWithdrawTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ExitWithdrawTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FeederSchoolAssociation model.
    /// </summary>
    public interface IFeederSchoolAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int FeederSchoolId { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string FeederRelationshipDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? FeederSchoolResourceId { get; set; }
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GeneralStudentProgramAssociation model.
    /// </summary>
    public interface IGeneralStudentProgramAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int ProgramEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string ReasonExitedDescriptor { get; set; }
        bool? ServedOutsideOfRegularSession { get; set; }

        // One-to-one relationships

        IGeneralStudentProgramAssociationParticipationStatus GeneralStudentProgramAssociationParticipationStatus { get; set; }

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GeneralStudentProgramAssociationParticipationStatus model.
    /// </summary>
    public interface IGeneralStudentProgramAssociationParticipationStatus : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGeneralStudentProgramAssociation GeneralStudentProgramAssociation { get; set; }

        // Non-PK properties
        string DesignatedBy { get; set; }
        string ParticipationStatusDescriptor { get; set; }
        DateTime? StatusBeginDate { get; set; }
        DateTime? StatusEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Grade model.
    /// </summary>
    public interface IGrade : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string GradeTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string GradingPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        short GradingPeriodSchoolYear { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSequence { get; set; }
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
        string DiagnosticStatement { get; set; }
        string LetterGradeEarned { get; set; }
        decimal? NumericGradeEarned { get; set; }
        string PerformanceBaseConversionDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IGradeLearningStandardGrade> GradeLearningStandardGrades { get; set; }

        // Resource reference data
        Guid? GradingPeriodResourceId { get; set; }
        string GradingPeriodDiscriminator { get; set; }
        Guid? StudentSectionAssociationResourceId { get; set; }
        string StudentSectionAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradebookEntry model.
    /// </summary>
    public interface IGradebookEntry : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime DateAssigned { get; set; }
        [NaturalKeyMember]
        string GradebookEntryTitle { get; set; }
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
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        string GradebookEntryTypeDescriptor { get; set; }
        string GradingPeriodDescriptor { get; set; }
        int? PeriodSequence { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IGradebookEntryLearningObjective> GradebookEntryLearningObjectives { get; set; }
        ICollection<IGradebookEntryLearningStandard> GradebookEntryLearningStandards { get; set; }

        // Resource reference data
        Guid? GradingPeriodResourceId { get; set; }
        string GradingPeriodDiscriminator { get; set; }
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradebookEntryLearningObjective model.
    /// </summary>
    public interface IGradebookEntryLearningObjective : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGradebookEntry GradebookEntry { get; set; }
        [NaturalKeyMember]
        string LearningObjectiveId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningObjectiveResourceId { get; set; }
        string LearningObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradebookEntryLearningStandard model.
    /// </summary>
    public interface IGradebookEntryLearningStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGradebookEntry GradebookEntry { get; set; }
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradebookEntryTypeDescriptor model.
    /// </summary>
    public interface IGradebookEntryTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GradebookEntryTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradeLearningStandardGrade model.
    /// </summary>
    public interface IGradeLearningStandardGrade : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGrade Grade { get; set; }
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties
        string DiagnosticStatement { get; set; }
        string LetterGradeEarned { get; set; }
        decimal? NumericGradeEarned { get; set; }
        string PerformanceBaseConversionDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradeLevelDescriptor model.
    /// </summary>
    public interface IGradeLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GradeLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradePointAverageTypeDescriptor model.
    /// </summary>
    public interface IGradePointAverageTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GradePointAverageTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradeTypeDescriptor model.
    /// </summary>
    public interface IGradeTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GradeTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradingPeriod model.
    /// </summary>
    public interface IGradingPeriod : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string GradingPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        int PeriodSequence { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        int TotalInstructionalDays { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GradingPeriodDescriptor model.
    /// </summary>
    public interface IGradingPeriodDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GradingPeriodDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlan model.
    /// </summary>
    public interface IGraduationPlan : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string GraduationPlanTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short GraduationSchoolYear { get; set; }

        // Non-PK properties
        bool? IndividualPlan { get; set; }
        decimal? TotalRequiredCreditConversion { get; set; }
        decimal TotalRequiredCredits { get; set; }
        string TotalRequiredCreditTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IGraduationPlanCreditsByCourse> GraduationPlanCreditsByCourses { get; set; }
        ICollection<IGraduationPlanCreditsByCreditCategory> GraduationPlanCreditsByCreditCategories { get; set; }
        ICollection<IGraduationPlanCreditsBySubject> GraduationPlanCreditsBySubjects { get; set; }
        ICollection<IGraduationPlanRequiredAssessment> GraduationPlanRequiredAssessments { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? GraduationSchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanCreditsByCourse model.
    /// </summary>
    public interface IGraduationPlanCreditsByCourse : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlan GraduationPlan { get; set; }
        [NaturalKeyMember]
        string CourseSetName { get; set; }

        // Non-PK properties
        decimal? CreditConversion { get; set; }
        decimal Credits { get; set; }
        string CreditTypeDescriptor { get; set; }
        string WhenTakenGradeLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IGraduationPlanCreditsByCourseCourse> GraduationPlanCreditsByCourseCourses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanCreditsByCourseCourse model.
    /// </summary>
    public interface IGraduationPlanCreditsByCourseCourse : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlanCreditsByCourse GraduationPlanCreditsByCourse { get; set; }
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int CourseEducationOrganizationId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanCreditsByCreditCategory model.
    /// </summary>
    public interface IGraduationPlanCreditsByCreditCategory : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlan GraduationPlan { get; set; }
        [NaturalKeyMember]
        string CreditCategoryDescriptor { get; set; }

        // Non-PK properties
        decimal? CreditConversion { get; set; }
        decimal Credits { get; set; }
        string CreditTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanCreditsBySubject model.
    /// </summary>
    public interface IGraduationPlanCreditsBySubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlan GraduationPlan { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties
        decimal? CreditConversion { get; set; }
        decimal Credits { get; set; }
        string CreditTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanRequiredAssessment model.
    /// </summary>
    public interface IGraduationPlanRequiredAssessment : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlan GraduationPlan { get; set; }
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties

        // One-to-one relationships

        IGraduationPlanRequiredAssessmentPerformanceLevel GraduationPlanRequiredAssessmentPerformanceLevel { get; set; }

        // Lists
        ICollection<IGraduationPlanRequiredAssessmentScore> GraduationPlanRequiredAssessmentScores { get; set; }

        // Resource reference data
        Guid? AssessmentResourceId { get; set; }
        string AssessmentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanRequiredAssessmentPerformanceLevel model.
    /// </summary>
    public interface IGraduationPlanRequiredAssessmentPerformanceLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlanRequiredAssessment GraduationPlanRequiredAssessment { get; set; }

        // Non-PK properties
        string AssessmentReportingMethodDescriptor { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string PerformanceLevelDescriptor { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanRequiredAssessmentScore model.
    /// </summary>
    public interface IGraduationPlanRequiredAssessmentScore : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IGraduationPlanRequiredAssessment GraduationPlanRequiredAssessment { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }

        // Non-PK properties
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GraduationPlanTypeDescriptor model.
    /// </summary>
    public interface IGraduationPlanTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GraduationPlanTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GunFreeSchoolsActReportingStatusDescriptor model.
    /// </summary>
    public interface IGunFreeSchoolsActReportingStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int GunFreeSchoolsActReportingStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the HomelessPrimaryNighttimeResidenceDescriptor model.
    /// </summary>
    public interface IHomelessPrimaryNighttimeResidenceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int HomelessPrimaryNighttimeResidenceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the HomelessProgramServiceDescriptor model.
    /// </summary>
    public interface IHomelessProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int HomelessProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the IdentificationDocumentUseDescriptor model.
    /// </summary>
    public interface IIdentificationDocumentUseDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int IdentificationDocumentUseDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the IncidentLocationDescriptor model.
    /// </summary>
    public interface IIncidentLocationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int IncidentLocationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the IndicatorDescriptor model.
    /// </summary>
    public interface IIndicatorDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int IndicatorDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the IndicatorGroupDescriptor model.
    /// </summary>
    public interface IIndicatorGroupDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int IndicatorGroupDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the IndicatorLevelDescriptor model.
    /// </summary>
    public interface IIndicatorLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int IndicatorLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InstitutionTelephoneNumberTypeDescriptor model.
    /// </summary>
    public interface IInstitutionTelephoneNumberTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InstitutionTelephoneNumberTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InteractivityStyleDescriptor model.
    /// </summary>
    public interface IInteractivityStyleDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InteractivityStyleDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InternetAccessDescriptor model.
    /// </summary>
    public interface IInternetAccessDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InternetAccessDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Intervention model.
    /// </summary>
    public interface IIntervention : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string InterventionIdentificationCode { get; set; }

        // Non-PK properties
        DateTime BeginDate { get; set; }
        string DeliveryMethodDescriptor { get; set; }
        DateTime? EndDate { get; set; }
        string InterventionClassDescriptor { get; set; }
        int? MaxDosage { get; set; }
        int? MinDosage { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IInterventionAppropriateGradeLevel> InterventionAppropriateGradeLevels { get; set; }
        ICollection<IInterventionAppropriateSex> InterventionAppropriateSexes { get; set; }
        ICollection<IInterventionDiagnosis> InterventionDiagnoses { get; set; }
        ICollection<IInterventionEducationContent> InterventionEducationContents { get; set; }
        ICollection<IInterventionInterventionPrescription> InterventionInterventionPrescriptions { get; set; }
        ICollection<IInterventionLearningResourceMetadataURI> InterventionLearningResourceMetadataURIs { get; set; }
        ICollection<IInterventionMeetingTime> InterventionMeetingTimes { get; set; }
        ICollection<IInterventionPopulationServed> InterventionPopulationServeds { get; set; }
        ICollection<IInterventionStaff> InterventionStaffs { get; set; }
        ICollection<IInterventionURI> InterventionURIs { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionAppropriateGradeLevel model.
    /// </summary>
    public interface IInterventionAppropriateGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionAppropriateSex model.
    /// </summary>
    public interface IInterventionAppropriateSex : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string SexDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionClassDescriptor model.
    /// </summary>
    public interface IInterventionClassDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InterventionClassDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionDiagnosis model.
    /// </summary>
    public interface IInterventionDiagnosis : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string DiagnosisDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionEducationContent model.
    /// </summary>
    public interface IInterventionEducationContent : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string ContentIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationContentResourceId { get; set; }
        string EducationContentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionEffectivenessRatingDescriptor model.
    /// </summary>
    public interface IInterventionEffectivenessRatingDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InterventionEffectivenessRatingDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionInterventionPrescription model.
    /// </summary>
    public interface IInterventionInterventionPrescription : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        int InterventionPrescriptionEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string InterventionPrescriptionIdentificationCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? InterventionPrescriptionResourceId { get; set; }
        string InterventionPrescriptionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionLearningResourceMetadataURI model.
    /// </summary>
    public interface IInterventionLearningResourceMetadataURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string LearningResourceMetadataURI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionMeetingTime model.
    /// </summary>
    public interface IInterventionMeetingTime : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        TimeSpan EndTime { get; set; }
        [NaturalKeyMember]
        TimeSpan StartTime { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPopulationServed model.
    /// </summary>
    public interface IInterventionPopulationServed : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string PopulationServedDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescription model.
    /// </summary>
    public interface IInterventionPrescription : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string InterventionPrescriptionIdentificationCode { get; set; }

        // Non-PK properties
        string DeliveryMethodDescriptor { get; set; }
        string InterventionClassDescriptor { get; set; }
        int? MaxDosage { get; set; }
        int? MinDosage { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IInterventionPrescriptionAppropriateGradeLevel> InterventionPrescriptionAppropriateGradeLevels { get; set; }
        ICollection<IInterventionPrescriptionAppropriateSex> InterventionPrescriptionAppropriateSexes { get; set; }
        ICollection<IInterventionPrescriptionDiagnosis> InterventionPrescriptionDiagnoses { get; set; }
        ICollection<IInterventionPrescriptionEducationContent> InterventionPrescriptionEducationContents { get; set; }
        ICollection<IInterventionPrescriptionLearningResourceMetadataURI> InterventionPrescriptionLearningResourceMetadataURIs { get; set; }
        ICollection<IInterventionPrescriptionPopulationServed> InterventionPrescriptionPopulationServeds { get; set; }
        ICollection<IInterventionPrescriptionURI> InterventionPrescriptionURIs { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescriptionAppropriateGradeLevel model.
    /// </summary>
    public interface IInterventionPrescriptionAppropriateGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionPrescription InterventionPrescription { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescriptionAppropriateSex model.
    /// </summary>
    public interface IInterventionPrescriptionAppropriateSex : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionPrescription InterventionPrescription { get; set; }
        [NaturalKeyMember]
        string SexDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescriptionDiagnosis model.
    /// </summary>
    public interface IInterventionPrescriptionDiagnosis : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionPrescription InterventionPrescription { get; set; }
        [NaturalKeyMember]
        string DiagnosisDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescriptionEducationContent model.
    /// </summary>
    public interface IInterventionPrescriptionEducationContent : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionPrescription InterventionPrescription { get; set; }
        [NaturalKeyMember]
        string ContentIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationContentResourceId { get; set; }
        string EducationContentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescriptionLearningResourceMetadataURI model.
    /// </summary>
    public interface IInterventionPrescriptionLearningResourceMetadataURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionPrescription InterventionPrescription { get; set; }
        [NaturalKeyMember]
        string LearningResourceMetadataURI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescriptionPopulationServed model.
    /// </summary>
    public interface IInterventionPrescriptionPopulationServed : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionPrescription InterventionPrescription { get; set; }
        [NaturalKeyMember]
        string PopulationServedDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionPrescriptionURI model.
    /// </summary>
    public interface IInterventionPrescriptionURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionPrescription InterventionPrescription { get; set; }
        [NaturalKeyMember]
        string URI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStaff model.
    /// </summary>
    public interface IInterventionStaff : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudy model.
    /// </summary>
    public interface IInterventionStudy : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string InterventionStudyIdentificationCode { get; set; }

        // Non-PK properties
        string DeliveryMethodDescriptor { get; set; }
        string InterventionClassDescriptor { get; set; }
        int InterventionPrescriptionEducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
        int Participants { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IInterventionStudyAppropriateGradeLevel> InterventionStudyAppropriateGradeLevels { get; set; }
        ICollection<IInterventionStudyAppropriateSex> InterventionStudyAppropriateSexes { get; set; }
        ICollection<IInterventionStudyEducationContent> InterventionStudyEducationContents { get; set; }
        ICollection<IInterventionStudyInterventionEffectiveness> InterventionStudyInterventionEffectivenesses { get; set; }
        ICollection<IInterventionStudyLearningResourceMetadataURI> InterventionStudyLearningResourceMetadataURIs { get; set; }
        ICollection<IInterventionStudyPopulationServed> InterventionStudyPopulationServeds { get; set; }
        ICollection<IInterventionStudyStateAbbreviation> InterventionStudyStateAbbreviations { get; set; }
        ICollection<IInterventionStudyURI> InterventionStudyURIs { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? InterventionPrescriptionResourceId { get; set; }
        string InterventionPrescriptionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyAppropriateGradeLevel model.
    /// </summary>
    public interface IInterventionStudyAppropriateGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyAppropriateSex model.
    /// </summary>
    public interface IInterventionStudyAppropriateSex : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string SexDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyEducationContent model.
    /// </summary>
    public interface IInterventionStudyEducationContent : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string ContentIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationContentResourceId { get; set; }
        string EducationContentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyInterventionEffectiveness model.
    /// </summary>
    public interface IInterventionStudyInterventionEffectiveness : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string DiagnosisDescriptor { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }
        [NaturalKeyMember]
        string PopulationServedDescriptor { get; set; }

        // Non-PK properties
        int? ImprovementIndex { get; set; }
        string InterventionEffectivenessRatingDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyLearningResourceMetadataURI model.
    /// </summary>
    public interface IInterventionStudyLearningResourceMetadataURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string LearningResourceMetadataURI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyPopulationServed model.
    /// </summary>
    public interface IInterventionStudyPopulationServed : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string PopulationServedDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyStateAbbreviation model.
    /// </summary>
    public interface IInterventionStudyStateAbbreviation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string StateAbbreviationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionStudyURI model.
    /// </summary>
    public interface IInterventionStudyURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IInterventionStudy InterventionStudy { get; set; }
        [NaturalKeyMember]
        string URI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InterventionURI model.
    /// </summary>
    public interface IInterventionURI : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IIntervention Intervention { get; set; }
        [NaturalKeyMember]
        string URI { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LanguageDescriptor model.
    /// </summary>
    public interface ILanguageDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LanguageDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LanguageInstructionProgramServiceDescriptor model.
    /// </summary>
    public interface ILanguageInstructionProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LanguageInstructionProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LanguageUseDescriptor model.
    /// </summary>
    public interface ILanguageUseDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LanguageUseDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningObjective model.
    /// </summary>
    public interface ILearningObjective : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string LearningObjectiveId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties
        string Description { get; set; }
        string Nomenclature { get; set; }
        string Objective { get; set; }
        string ParentLearningObjectiveId { get; set; }
        string ParentNamespace { get; set; }
        string SuccessCriteria { get; set; }

        // One-to-one relationships

        ILearningObjectiveContentStandard LearningObjectiveContentStandard { get; set; }

        // Lists
        ICollection<ILearningObjectiveAcademicSubject> LearningObjectiveAcademicSubjects { get; set; }
        ICollection<ILearningObjectiveGradeLevel> LearningObjectiveGradeLevels { get; set; }
        ICollection<ILearningObjectiveLearningStandard> LearningObjectiveLearningStandards { get; set; }

        // Resource reference data
        Guid? ParentLearningObjectiveResourceId { get; set; }
        string ParentLearningObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningObjectiveAcademicSubject model.
    /// </summary>
    public interface ILearningObjectiveAcademicSubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningObjective LearningObjective { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningObjectiveContentStandard model.
    /// </summary>
    public interface ILearningObjectiveContentStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningObjective LearningObjective { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        int? MandatingEducationOrganizationId { get; set; }
        DateTime? PublicationDate { get; set; }
        string PublicationStatusDescriptor { get; set; }
        short? PublicationYear { get; set; }
        string Title { get; set; }
        string URI { get; set; }
        string Version { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ILearningObjectiveContentStandardAuthor> LearningObjectiveContentStandardAuthors { get; set; }

        // Resource reference data
        Guid? MandatingEducationOrganizationResourceId { get; set; }
        string MandatingEducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningObjectiveContentStandardAuthor model.
    /// </summary>
    public interface ILearningObjectiveContentStandardAuthor : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningObjectiveContentStandard LearningObjectiveContentStandard { get; set; }
        [NaturalKeyMember]
        string Author { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningObjectiveGradeLevel model.
    /// </summary>
    public interface ILearningObjectiveGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningObjective LearningObjective { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningObjectiveLearningStandard model.
    /// </summary>
    public interface ILearningObjectiveLearningStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningObjective LearningObjective { get; set; }
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandard model.
    /// </summary>
    public interface ILearningStandard : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties
        string CourseTitle { get; set; }
        string Description { get; set; }
        string LearningStandardCategoryDescriptor { get; set; }
        string LearningStandardItemCode { get; set; }
        string LearningStandardScopeDescriptor { get; set; }
        string Namespace { get; set; }
        string ParentLearningStandardId { get; set; }
        string SuccessCriteria { get; set; }
        string URI { get; set; }

        // One-to-one relationships

        ILearningStandardContentStandard LearningStandardContentStandard { get; set; }

        // Lists
        ICollection<ILearningStandardAcademicSubject> LearningStandardAcademicSubjects { get; set; }
        ICollection<ILearningStandardGradeLevel> LearningStandardGradeLevels { get; set; }
        ICollection<ILearningStandardIdentificationCode> LearningStandardIdentificationCodes { get; set; }
        ICollection<ILearningStandardPrerequisiteLearningStandard> LearningStandardPrerequisiteLearningStandards { get; set; }

        // Resource reference data
        Guid? ParentLearningStandardResourceId { get; set; }
        string ParentLearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardAcademicSubject model.
    /// </summary>
    public interface ILearningStandardAcademicSubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningStandard LearningStandard { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardCategoryDescriptor model.
    /// </summary>
    public interface ILearningStandardCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LearningStandardCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardContentStandard model.
    /// </summary>
    public interface ILearningStandardContentStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningStandard LearningStandard { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        int? MandatingEducationOrganizationId { get; set; }
        DateTime? PublicationDate { get; set; }
        string PublicationStatusDescriptor { get; set; }
        short? PublicationYear { get; set; }
        string Title { get; set; }
        string URI { get; set; }
        string Version { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ILearningStandardContentStandardAuthor> LearningStandardContentStandardAuthors { get; set; }

        // Resource reference data
        Guid? MandatingEducationOrganizationResourceId { get; set; }
        string MandatingEducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardContentStandardAuthor model.
    /// </summary>
    public interface ILearningStandardContentStandardAuthor : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningStandardContentStandard LearningStandardContentStandard { get; set; }
        [NaturalKeyMember]
        string Author { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardEquivalenceAssociation model.
    /// </summary>
    public interface ILearningStandardEquivalenceAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SourceLearningStandardId { get; set; }
        [NaturalKeyMember]
        string TargetLearningStandardId { get; set; }

        // Non-PK properties
        DateTime? EffectiveDate { get; set; }
        string LearningStandardEquivalenceStrengthDescription { get; set; }
        string LearningStandardEquivalenceStrengthDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SourceLearningStandardResourceId { get; set; }
        string SourceLearningStandardDiscriminator { get; set; }
        Guid? TargetLearningStandardResourceId { get; set; }
        string TargetLearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardEquivalenceStrengthDescriptor model.
    /// </summary>
    public interface ILearningStandardEquivalenceStrengthDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LearningStandardEquivalenceStrengthDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardGradeLevel model.
    /// </summary>
    public interface ILearningStandardGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningStandard LearningStandard { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardIdentificationCode model.
    /// </summary>
    public interface ILearningStandardIdentificationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningStandard LearningStandard { get; set; }
        [NaturalKeyMember]
        string ContentStandardName { get; set; }
        [NaturalKeyMember]
        string IdentificationCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardPrerequisiteLearningStandard model.
    /// </summary>
    public interface ILearningStandardPrerequisiteLearningStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILearningStandard LearningStandard { get; set; }
        [NaturalKeyMember]
        string PrerequisiteLearningStandardId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PrerequisiteLearningStandardResourceId { get; set; }
        string PrerequisiteLearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LearningStandardScopeDescriptor model.
    /// </summary>
    public interface ILearningStandardScopeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LearningStandardScopeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LevelOfEducationDescriptor model.
    /// </summary>
    public interface ILevelOfEducationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LevelOfEducationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LicenseStatusDescriptor model.
    /// </summary>
    public interface ILicenseStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LicenseStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LicenseTypeDescriptor model.
    /// </summary>
    public interface ILicenseTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LicenseTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LimitedEnglishProficiencyDescriptor model.
    /// </summary>
    public interface ILimitedEnglishProficiencyDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LimitedEnglishProficiencyDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LocaleDescriptor model.
    /// </summary>
    public interface ILocaleDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LocaleDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LocalEducationAgency model.
    /// </summary>
    public interface ILocalEducationAgency : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int LocalEducationAgencyId { get; set; }

        // Non-PK properties
        string CharterStatusDescriptor { get; set; }
        int? EducationServiceCenterId { get; set; }
        string LocalEducationAgencyCategoryDescriptor { get; set; }
        int? ParentLocalEducationAgencyId { get; set; }
        int? StateEducationAgencyId { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ILocalEducationAgencyAccountability> LocalEducationAgencyAccountabilities { get; set; }
        ICollection<ILocalEducationAgencyFederalFunds> LocalEducationAgencyFederalFunds { get; set; }

        // Resource reference data
        Guid? EducationServiceCenterResourceId { get; set; }
        Guid? ParentLocalEducationAgencyResourceId { get; set; }
        Guid? StateEducationAgencyResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LocalEducationAgencyAccountability model.
    /// </summary>
    public interface ILocalEducationAgencyAccountability : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILocalEducationAgency LocalEducationAgency { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        string GunFreeSchoolsActReportingStatusDescriptor { get; set; }
        string SchoolChoiceImplementStatusDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LocalEducationAgencyCategoryDescriptor model.
    /// </summary>
    public interface ILocalEducationAgencyCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int LocalEducationAgencyCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the LocalEducationAgencyFederalFunds model.
    /// </summary>
    public interface ILocalEducationAgencyFederalFunds : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ILocalEducationAgency LocalEducationAgency { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }

        // Non-PK properties
        decimal? InnovativeDollarsSpent { get; set; }
        decimal? InnovativeDollarsSpentStrategicPriorities { get; set; }
        decimal? InnovativeProgramsFundsReceived { get; set; }
        decimal? SchoolImprovementAllocation { get; set; }
        decimal? SchoolImprovementReservedFundsPercentage { get; set; }
        decimal? StateAssessmentAdministrationFunding { get; set; }
        decimal? SupplementalEducationalServicesFundsSpent { get; set; }
        decimal? SupplementalEducationalServicesPerPupilExpenditure { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Location model.
    /// </summary>
    public interface ILocation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ClassroomIdentificationCode { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties
        int? MaximumNumberOfSeats { get; set; }
        int? OptimalNumberOfSeats { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the MagnetSpecialProgramEmphasisSchoolDescriptor model.
    /// </summary>
    public interface IMagnetSpecialProgramEmphasisSchoolDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int MagnetSpecialProgramEmphasisSchoolDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the MediumOfInstructionDescriptor model.
    /// </summary>
    public interface IMediumOfInstructionDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int MediumOfInstructionDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the MethodCreditEarnedDescriptor model.
    /// </summary>
    public interface IMethodCreditEarnedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int MethodCreditEarnedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the MigrantEducationProgramServiceDescriptor model.
    /// </summary>
    public interface IMigrantEducationProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int MigrantEducationProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the MonitoredDescriptor model.
    /// </summary>
    public interface IMonitoredDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int MonitoredDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the NeglectedOrDelinquentProgramDescriptor model.
    /// </summary>
    public interface INeglectedOrDelinquentProgramDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int NeglectedOrDelinquentProgramDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the NeglectedOrDelinquentProgramServiceDescriptor model.
    /// </summary>
    public interface INeglectedOrDelinquentProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int NeglectedOrDelinquentProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the NetworkPurposeDescriptor model.
    /// </summary>
    public interface INetworkPurposeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int NetworkPurposeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveAssessment model.
    /// </summary>
    public interface IObjectiveAssessment : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        string IdentificationCode { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string Description { get; set; }
        decimal? MaxRawScore { get; set; }
        string Nomenclature { get; set; }
        string ParentIdentificationCode { get; set; }
        decimal? PercentOfAssessment { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IObjectiveAssessmentAssessmentItem> ObjectiveAssessmentAssessmentItems { get; set; }
        ICollection<IObjectiveAssessmentLearningObjective> ObjectiveAssessmentLearningObjectives { get; set; }
        ICollection<IObjectiveAssessmentLearningStandard> ObjectiveAssessmentLearningStandards { get; set; }
        ICollection<IObjectiveAssessmentPerformanceLevel> ObjectiveAssessmentPerformanceLevels { get; set; }
        ICollection<IObjectiveAssessmentScore> ObjectiveAssessmentScores { get; set; }

        // Resource reference data
        Guid? AssessmentResourceId { get; set; }
        string AssessmentDiscriminator { get; set; }
        Guid? ParentObjectiveAssessmentResourceId { get; set; }
        string ParentObjectiveAssessmentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveAssessmentAssessmentItem model.
    /// </summary>
    public interface IObjectiveAssessmentAssessmentItem : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IObjectiveAssessment ObjectiveAssessment { get; set; }
        [NaturalKeyMember]
        string AssessmentItemIdentificationCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AssessmentItemResourceId { get; set; }
        string AssessmentItemDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveAssessmentLearningObjective model.
    /// </summary>
    public interface IObjectiveAssessmentLearningObjective : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IObjectiveAssessment ObjectiveAssessment { get; set; }
        [NaturalKeyMember]
        string LearningObjectiveId { get; set; }
        [NaturalKeyMember]
        string LearningObjectiveNamespace { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningObjectiveResourceId { get; set; }
        string LearningObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveAssessmentLearningStandard model.
    /// </summary>
    public interface IObjectiveAssessmentLearningStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IObjectiveAssessment ObjectiveAssessment { get; set; }
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveAssessmentPerformanceLevel model.
    /// </summary>
    public interface IObjectiveAssessmentPerformanceLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IObjectiveAssessment ObjectiveAssessment { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }
        [NaturalKeyMember]
        string PerformanceLevelDescriptor { get; set; }

        // Non-PK properties
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveAssessmentScore model.
    /// </summary>
    public interface IObjectiveAssessmentScore : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IObjectiveAssessment ObjectiveAssessment { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }

        // Non-PK properties
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OldEthnicityDescriptor model.
    /// </summary>
    public interface IOldEthnicityDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int OldEthnicityDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPosition model.
    /// </summary>
    public interface IOpenStaffPosition : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string RequisitionNumber { get; set; }

        // Non-PK properties
        DateTime DatePosted { get; set; }
        DateTime? DatePostingRemoved { get; set; }
        string EmploymentStatusDescriptor { get; set; }
        string PositionTitle { get; set; }
        string PostingResultDescriptor { get; set; }
        string ProgramAssignmentDescriptor { get; set; }
        string StaffClassificationDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IOpenStaffPositionAcademicSubject> OpenStaffPositionAcademicSubjects { get; set; }
        ICollection<IOpenStaffPositionInstructionalGradeLevel> OpenStaffPositionInstructionalGradeLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPositionAcademicSubject model.
    /// </summary>
    public interface IOpenStaffPositionAcademicSubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IOpenStaffPosition OpenStaffPosition { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OpenStaffPositionInstructionalGradeLevel model.
    /// </summary>
    public interface IOpenStaffPositionInstructionalGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IOpenStaffPosition OpenStaffPosition { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OperationalStatusDescriptor model.
    /// </summary>
    public interface IOperationalStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int OperationalStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the OtherNameTypeDescriptor model.
    /// </summary>
    public interface IOtherNameTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int OtherNameTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Parent model.
    /// </summary>
    public interface IParent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IIdentifiablePerson, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][UniqueId]
        string ParentUniqueId { get; set; }

        // Non-PK properties
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        string SexDescriptor { get; set; }
        string SourceSystemDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IParentAddress> ParentAddresses { get; set; }
        ICollection<IParentElectronicMail> ParentElectronicMails { get; set; }
        ICollection<IParentInternationalAddress> ParentInternationalAddresses { get; set; }
        ICollection<IParentLanguage> ParentLanguages { get; set; }
        ICollection<IParentOtherName> ParentOtherNames { get; set; }
        ICollection<IParentPersonalIdentificationDocument> ParentPersonalIdentificationDocuments { get; set; }
        ICollection<IParentTelephone> ParentTelephones { get; set; }

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentAddress model.
    /// </summary>
    public interface IParentAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
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
        ICollection<IParentAddressPeriod> ParentAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentAddressPeriod model.
    /// </summary>
    public interface IParentAddressPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentAddress ParentAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentElectronicMail model.
    /// </summary>
    public interface IParentElectronicMail : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ParentInternationalAddress model.
    /// </summary>
    public interface IParentInternationalAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ParentLanguage model.
    /// </summary>
    public interface IParentLanguage : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IParentLanguageUse> ParentLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentLanguageUse model.
    /// </summary>
    public interface IParentLanguageUse : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentLanguage ParentLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentOtherName model.
    /// </summary>
    public interface IParentOtherName : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ParentPersonalIdentificationDocument model.
    /// </summary>
    public interface IParentPersonalIdentificationDocument : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ParentTelephone model.
    /// </summary>
    public interface IParentTelephone : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ParticipationDescriptor model.
    /// </summary>
    public interface IParticipationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ParticipationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParticipationStatusDescriptor model.
    /// </summary>
    public interface IParticipationStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ParticipationStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Payroll model.
    /// </summary>
    public interface IPayroll : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AccountIdentifier { get; set; }
        [NaturalKeyMember]
        DateTime AsOfDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        decimal AmountToDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AccountResourceId { get; set; }
        string AccountDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceBaseConversionDescriptor model.
    /// </summary>
    public interface IPerformanceBaseConversionDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PerformanceBaseConversionDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceLevelDescriptor model.
    /// </summary>
    public interface IPerformanceLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PerformanceLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Person model.
    /// </summary>
    public interface IPerson : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string PersonId { get; set; }
        [NaturalKeyMember]
        string SourceSystemDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PersonalInformationVerificationDescriptor model.
    /// </summary>
    public interface IPersonalInformationVerificationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PersonalInformationVerificationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PlatformTypeDescriptor model.
    /// </summary>
    public interface IPlatformTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PlatformTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PopulationServedDescriptor model.
    /// </summary>
    public interface IPopulationServedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PopulationServedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostingResultDescriptor model.
    /// </summary>
    public interface IPostingResultDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PostingResultDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostSecondaryEvent model.
    /// </summary>
    public interface IPostSecondaryEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string PostSecondaryEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        int? PostSecondaryInstitutionId { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PostSecondaryInstitutionResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostSecondaryEventCategoryDescriptor model.
    /// </summary>
    public interface IPostSecondaryEventCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PostSecondaryEventCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostSecondaryInstitution model.
    /// </summary>
    public interface IPostSecondaryInstitution : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int PostSecondaryInstitutionId { get; set; }

        // Non-PK properties
        string AdministrativeFundingControlDescriptor { get; set; }
        string PostSecondaryInstitutionLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IPostSecondaryInstitutionMediumOfInstruction> PostSecondaryInstitutionMediumOfInstructions { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostSecondaryInstitutionLevelDescriptor model.
    /// </summary>
    public interface IPostSecondaryInstitutionLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PostSecondaryInstitutionLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostSecondaryInstitutionMediumOfInstruction model.
    /// </summary>
    public interface IPostSecondaryInstitutionMediumOfInstruction : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IPostSecondaryInstitution PostSecondaryInstitution { get; set; }
        [NaturalKeyMember]
        string MediumOfInstructionDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProficiencyDescriptor model.
    /// </summary>
    public interface IProficiencyDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProficiencyDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Program model.
    /// </summary>
    public interface IProgram : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties
        string ProgramId { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IProgramCharacteristic> ProgramCharacteristics { get; set; }
        ICollection<IProgramLearningObjective> ProgramLearningObjectives { get; set; }
        ICollection<IProgramLearningStandard> ProgramLearningStandards { get; set; }
        ICollection<IProgramService> ProgramServices { get; set; }
        ICollection<IProgramSponsor> ProgramSponsors { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramAssignmentDescriptor model.
    /// </summary>
    public interface IProgramAssignmentDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProgramAssignmentDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramCharacteristic model.
    /// </summary>
    public interface IProgramCharacteristic : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProgram Program { get; set; }
        [NaturalKeyMember]
        string ProgramCharacteristicDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramCharacteristicDescriptor model.
    /// </summary>
    public interface IProgramCharacteristicDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProgramCharacteristicDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramLearningObjective model.
    /// </summary>
    public interface IProgramLearningObjective : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProgram Program { get; set; }
        [NaturalKeyMember]
        string LearningObjectiveId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningObjectiveResourceId { get; set; }
        string LearningObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramLearningStandard model.
    /// </summary>
    public interface IProgramLearningStandard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProgram Program { get; set; }
        [NaturalKeyMember]
        string LearningStandardId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? LearningStandardResourceId { get; set; }
        string LearningStandardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramService model.
    /// </summary>
    public interface IProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProgram Program { get; set; }
        [NaturalKeyMember]
        string ServiceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramSponsor model.
    /// </summary>
    public interface IProgramSponsor : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IProgram Program { get; set; }
        [NaturalKeyMember]
        string ProgramSponsorDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramSponsorDescriptor model.
    /// </summary>
    public interface IProgramSponsorDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProgramSponsorDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgramTypeDescriptor model.
    /// </summary>
    public interface IProgramTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProgramTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgressDescriptor model.
    /// </summary>
    public interface IProgressDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProgressDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProgressLevelDescriptor model.
    /// </summary>
    public interface IProgressLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProgressLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProviderCategoryDescriptor model.
    /// </summary>
    public interface IProviderCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProviderCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProviderProfitabilityDescriptor model.
    /// </summary>
    public interface IProviderProfitabilityDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProviderProfitabilityDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ProviderStatusDescriptor model.
    /// </summary>
    public interface IProviderStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ProviderStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PublicationStatusDescriptor model.
    /// </summary>
    public interface IPublicationStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int PublicationStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the QuestionFormDescriptor model.
    /// </summary>
    public interface IQuestionFormDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int QuestionFormDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RaceDescriptor model.
    /// </summary>
    public interface IRaceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RaceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ReasonExitedDescriptor model.
    /// </summary>
    public interface IReasonExitedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ReasonExitedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ReasonNotTestedDescriptor model.
    /// </summary>
    public interface IReasonNotTestedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ReasonNotTestedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RecognitionTypeDescriptor model.
    /// </summary>
    public interface IRecognitionTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RecognitionTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RelationDescriptor model.
    /// </summary>
    public interface IRelationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RelationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RepeatIdentifierDescriptor model.
    /// </summary>
    public interface IRepeatIdentifierDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RepeatIdentifierDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ReportCard model.
    /// </summary>
    public interface IReportCard : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string GradingPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSchoolId { get; set; }
        [NaturalKeyMember]
        short GradingPeriodSchoolYear { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSequence { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        decimal? GPACumulative { get; set; }
        decimal? GPAGivenGradingPeriod { get; set; }
        decimal? NumberOfDaysAbsent { get; set; }
        decimal? NumberOfDaysInAttendance { get; set; }
        int? NumberOfDaysTardy { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IReportCardGradePointAverage> ReportCardGradePointAverages { get; set; }
        ICollection<IReportCardGrade> ReportCardGrades { get; set; }
        ICollection<IReportCardStudentCompetencyObjective> ReportCardStudentCompetencyObjectives { get; set; }
        ICollection<IReportCardStudentLearningObjective> ReportCardStudentLearningObjectives { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? GradingPeriodResourceId { get; set; }
        string GradingPeriodDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ReportCardGrade model.
    /// </summary>
    public interface IReportCardGrade : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IReportCard ReportCard { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string GradeTypeDescriptor { get; set; }
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

        // Lists

        // Resource reference data
        Guid? GradeResourceId { get; set; }
        string GradeDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ReportCardGradePointAverage model.
    /// </summary>
    public interface IReportCardGradePointAverage : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IReportCard ReportCard { get; set; }
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
    /// Defines available properties and methods for the abstraction of the ReportCardStudentCompetencyObjective model.
    /// </summary>
    public interface IReportCardStudentCompetencyObjective : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IReportCard ReportCard { get; set; }
        [NaturalKeyMember]
        string Objective { get; set; }
        [NaturalKeyMember]
        int ObjectiveEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ObjectiveGradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentCompetencyObjectiveResourceId { get; set; }
        string StudentCompetencyObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ReportCardStudentLearningObjective model.
    /// </summary>
    public interface IReportCardStudentLearningObjective : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IReportCard ReportCard { get; set; }
        [NaturalKeyMember]
        string LearningObjectiveId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentLearningObjectiveResourceId { get; set; }
        string StudentLearningObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ReporterDescriptionDescriptor model.
    /// </summary>
    public interface IReporterDescriptionDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ReporterDescriptionDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ResidencyStatusDescriptor model.
    /// </summary>
    public interface IResidencyStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ResidencyStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ResponseIndicatorDescriptor model.
    /// </summary>
    public interface IResponseIndicatorDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ResponseIndicatorDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ResponsibilityDescriptor model.
    /// </summary>
    public interface IResponsibilityDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ResponsibilityDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RestraintEvent model.
    /// </summary>
    public interface IRestraintEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string RestraintEventIdentifier { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string EducationalEnvironmentDescriptor { get; set; }
        DateTime EventDate { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IRestraintEventProgram> RestraintEventPrograms { get; set; }
        ICollection<IRestraintEventReason> RestraintEventReasons { get; set; }

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RestraintEventProgram model.
    /// </summary>
    public interface IRestraintEventProgram : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRestraintEvent RestraintEvent { get; set; }
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
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RestraintEventReason model.
    /// </summary>
    public interface IRestraintEventReason : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IRestraintEvent RestraintEvent { get; set; }
        [NaturalKeyMember]
        string RestraintEventReasonDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RestraintEventReasonDescriptor model.
    /// </summary>
    public interface IRestraintEventReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RestraintEventReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ResultDatatypeTypeDescriptor model.
    /// </summary>
    public interface IResultDatatypeTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ResultDatatypeTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RetestIndicatorDescriptor model.
    /// </summary>
    public interface IRetestIndicatorDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int RetestIndicatorDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the School model.
    /// </summary>
    public interface ISchool : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int SchoolId { get; set; }

        // Non-PK properties
        string AdministrativeFundingControlDescriptor { get; set; }
        string CharterApprovalAgencyTypeDescriptor { get; set; }
        short? CharterApprovalSchoolYear { get; set; }
        string CharterStatusDescriptor { get; set; }
        string InternetAccessDescriptor { get; set; }
        int? LocalEducationAgencyId { get; set; }
        string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        string SchoolTypeDescriptor { get; set; }
        string TitleIPartASchoolDesignationDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ISchoolCategory> SchoolCategories { get; set; }
        ICollection<ISchoolGradeLevel> SchoolGradeLevels { get; set; }

        // Resource reference data
        Guid? CharterApprovalSchoolYearTypeResourceId { get; set; }
        Guid? LocalEducationAgencyResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolCategory model.
    /// </summary>
    public interface ISchoolCategory : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISchool School { get; set; }
        [NaturalKeyMember]
        string SchoolCategoryDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolCategoryDescriptor model.
    /// </summary>
    public interface ISchoolCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SchoolCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolChoiceImplementStatusDescriptor model.
    /// </summary>
    public interface ISchoolChoiceImplementStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SchoolChoiceImplementStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolFoodServiceProgramServiceDescriptor model.
    /// </summary>
    public interface ISchoolFoodServiceProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SchoolFoodServiceProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolGradeLevel model.
    /// </summary>
    public interface ISchoolGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISchool School { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolTypeDescriptor model.
    /// </summary>
    public interface ISchoolTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SchoolTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolYearType model.
    /// </summary>
    public interface ISchoolYearType : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        bool CurrentSchoolYear { get; set; }
        string SchoolYearDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Section model.
    /// </summary>
    public interface ISection : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
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
        decimal? AvailableCreditConversion { get; set; }
        decimal? AvailableCredits { get; set; }
        string AvailableCreditTypeDescriptor { get; set; }
        string EducationalEnvironmentDescriptor { get; set; }
        string InstructionLanguageDescriptor { get; set; }
        string LocationClassroomIdentificationCode { get; set; }
        int? LocationSchoolId { get; set; }
        string MediumOfInstructionDescriptor { get; set; }
        bool? OfficialAttendancePeriod { get; set; }
        string PopulationServedDescriptor { get; set; }
        string SectionName { get; set; }
        int? SequenceOfCourse { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ISectionCharacteristic> SectionCharacteristics { get; set; }
        ICollection<ISectionClassPeriod> SectionClassPeriods { get; set; }
        ICollection<ISectionCourseLevelCharacteristic> SectionCourseLevelCharacteristics { get; set; }
        ICollection<ISectionOfferedGradeLevel> SectionOfferedGradeLevels { get; set; }
        ICollection<ISectionProgram> SectionPrograms { get; set; }

        // Resource reference data
        Guid? CourseOfferingResourceId { get; set; }
        string CourseOfferingDiscriminator { get; set; }
        Guid? LocationResourceId { get; set; }
        string LocationDiscriminator { get; set; }
        Guid? LocationSchoolResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionAttendanceTakenEvent model.
    /// </summary>
    public interface ISectionAttendanceTakenEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CalendarCode { get; set; }
        [NaturalKeyMember]
        DateTime Date { get; set; }
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
        DateTime EventDate { get; set; }
        string StaffUniqueId { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CalendarDateResourceId { get; set; }
        string CalendarDateDiscriminator { get; set; }
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionCharacteristic model.
    /// </summary>
    public interface ISectionCharacteristic : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISection Section { get; set; }
        [NaturalKeyMember]
        string SectionCharacteristicDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionCharacteristicDescriptor model.
    /// </summary>
    public interface ISectionCharacteristicDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SectionCharacteristicDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionClassPeriod model.
    /// </summary>
    public interface ISectionClassPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISection Section { get; set; }
        [NaturalKeyMember]
        string ClassPeriodName { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ClassPeriodResourceId { get; set; }
        string ClassPeriodDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionCourseLevelCharacteristic model.
    /// </summary>
    public interface ISectionCourseLevelCharacteristic : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISection Section { get; set; }
        [NaturalKeyMember]
        string CourseLevelCharacteristicDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionOfferedGradeLevel model.
    /// </summary>
    public interface ISectionOfferedGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISection Section { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SectionProgram model.
    /// </summary>
    public interface ISectionProgram : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISection Section { get; set; }
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
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SeparationDescriptor model.
    /// </summary>
    public interface ISeparationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SeparationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SeparationReasonDescriptor model.
    /// </summary>
    public interface ISeparationReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SeparationReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ServiceDescriptor model.
    /// </summary>
    public interface IServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Session model.
    /// </summary>
    public interface ISession : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SessionName { get; set; }

        // Non-PK properties
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        string TermDescriptor { get; set; }
        int TotalInstructionalDays { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ISessionAcademicWeek> SessionAcademicWeeks { get; set; }
        ICollection<ISessionGradingPeriod> SessionGradingPeriods { get; set; }

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SessionAcademicWeek model.
    /// </summary>
    public interface ISessionAcademicWeek : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISession Session { get; set; }
        [NaturalKeyMember]
        string WeekIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AcademicWeekResourceId { get; set; }
        string AcademicWeekDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SessionGradingPeriod model.
    /// </summary>
    public interface ISessionGradingPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISession Session { get; set; }
        [NaturalKeyMember]
        string GradingPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        int PeriodSequence { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? GradingPeriodResourceId { get; set; }
        string GradingPeriodDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SexDescriptor model.
    /// </summary>
    public interface ISexDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SexDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SourceSystemDescriptor model.
    /// </summary>
    public interface ISourceSystemDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SourceSystemDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SpecialEducationProgramServiceDescriptor model.
    /// </summary>
    public interface ISpecialEducationProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SpecialEducationProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SpecialEducationSettingDescriptor model.
    /// </summary>
    public interface ISpecialEducationSettingDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SpecialEducationSettingDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Staff model.
    /// </summary>
    public interface IStaff : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IIdentifiablePerson, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][UniqueId]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? BirthDate { get; set; }
        string CitizenshipStatusDescriptor { get; set; }
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string HighestCompletedLevelOfEducationDescriptor { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string OldEthnicityDescriptor { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        string SexDescriptor { get; set; }
        string SourceSystemDescriptor { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffAddress> StaffAddresses { get; set; }
        ICollection<IStaffCredential> StaffCredentials { get; set; }
        ICollection<IStaffElectronicMail> StaffElectronicMails { get; set; }
        ICollection<IStaffIdentificationCode> StaffIdentificationCodes { get; set; }
        ICollection<IStaffIdentificationDocument> StaffIdentificationDocuments { get; set; }
        ICollection<IStaffInternationalAddress> StaffInternationalAddresses { get; set; }
        ICollection<IStaffLanguage> StaffLanguages { get; set; }
        ICollection<IStaffOtherName> StaffOtherNames { get; set; }
        ICollection<IStaffPersonalIdentificationDocument> StaffPersonalIdentificationDocuments { get; set; }
        ICollection<IStaffRace> StaffRaces { get; set; }
        ICollection<IStaffRecognition> StaffRecognitions { get; set; }
        ICollection<IStaffTelephone> StaffTelephones { get; set; }
        ICollection<IStaffTribalAffiliation> StaffTribalAffiliations { get; set; }
        ICollection<IStaffVisa> StaffVisas { get; set; }

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffAbsenceEvent model.
    /// </summary>
    public interface IStaffAbsenceEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
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
    /// Defines available properties and methods for the abstraction of the StaffAddress model.
    /// </summary>
    public interface IStaffAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
        ICollection<IStaffAddressPeriod> StaffAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffAddressPeriod model.
    /// </summary>
    public interface IStaffAddressPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffAddress StaffAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffClassificationDescriptor model.
    /// </summary>
    public interface IStaffClassificationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StaffClassificationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffCohortAssociation model.
    /// </summary>
    public interface IStaffCohortAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string CohortIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        bool? StudentRecordAccess { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CohortResourceId { get; set; }
        string CohortDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffCredential model.
    /// </summary>
    public interface IStaffCredential : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffDisciplineIncidentAssociation model.
    /// </summary>
    public interface IStaffDisciplineIncidentAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string IncidentIdentifier { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode> StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCodes { get; set; }

        // Resource reference data
        Guid? DisciplineIncidentResourceId { get; set; }
        string DisciplineIncidentDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode model.
    /// </summary>
    public interface IStaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffDisciplineIncidentAssociation StaffDisciplineIncidentAssociation { get; set; }
        [NaturalKeyMember]
        string DisciplineIncidentParticipationCodeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationAssignmentAssociation model.
    /// </summary>
    public interface IStaffEducationOrganizationAssignmentAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string StaffClassificationDescriptor { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string CredentialIdentifier { get; set; }
        int? EmploymentEducationOrganizationId { get; set; }
        DateTime? EmploymentHireDate { get; set; }
        string EmploymentStatusDescriptor { get; set; }
        DateTime? EndDate { get; set; }
        int? OrderOfAssignment { get; set; }
        string PositionTitle { get; set; }
        string StateOfIssueStateAbbreviationDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CredentialResourceId { get; set; }
        string CredentialDiscriminator { get; set; }
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? EmploymentStaffEducationOrganizationEmploymentAssociationResourceId { get; set; }
        string EmploymentStaffEducationOrganizationEmploymentAssociationDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationContactAssociation model.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ContactTitle { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string ContactTypeDescriptor { get; set; }
        string ElectronicMailAddress { get; set; }

        // One-to-one relationships

        IStaffEducationOrganizationContactAssociationAddress StaffEducationOrganizationContactAssociationAddress { get; set; }

        // Lists
        ICollection<IStaffEducationOrganizationContactAssociationTelephone> StaffEducationOrganizationContactAssociationTelephones { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationContactAssociationAddress model.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociationAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEducationOrganizationContactAssociation StaffEducationOrganizationContactAssociation { get; set; }

        // Non-PK properties
        string AddressTypeDescriptor { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        string Latitude { get; set; }
        string LocaleDescriptor { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        string PostalCode { get; set; }
        string StateAbbreviationDescriptor { get; set; }
        string StreetNumberName { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffEducationOrganizationContactAssociationAddressPeriod> StaffEducationOrganizationContactAssociationAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationContactAssociationAddressPeriod model.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociationAddressPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEducationOrganizationContactAssociationAddress StaffEducationOrganizationContactAssociationAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationContactAssociationTelephone model.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociationTelephone : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffEducationOrganizationContactAssociation StaffEducationOrganizationContactAssociation { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffEducationOrganizationEmploymentAssociation model.
    /// </summary>
    public interface IStaffEducationOrganizationEmploymentAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EmploymentStatusDescriptor { get; set; }
        [NaturalKeyMember]
        DateTime HireDate { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string CredentialIdentifier { get; set; }
        string Department { get; set; }
        DateTime? EndDate { get; set; }
        decimal? FullTimeEquivalency { get; set; }
        decimal? HourlyWage { get; set; }
        DateTime? OfferDate { get; set; }
        string SeparationDescriptor { get; set; }
        string SeparationReasonDescriptor { get; set; }
        string StateOfIssueStateAbbreviationDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CredentialResourceId { get; set; }
        string CredentialDiscriminator { get; set; }
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffElectronicMail model.
    /// </summary>
    public interface IStaffElectronicMail : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffIdentificationCode model.
    /// </summary>
    public interface IStaffIdentificationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffIdentificationDocument model.
    /// </summary>
    public interface IStaffIdentificationDocument : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffIdentificationSystemDescriptor model.
    /// </summary>
    public interface IStaffIdentificationSystemDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StaffIdentificationSystemDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffInternationalAddress model.
    /// </summary>
    public interface IStaffInternationalAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffLanguage model.
    /// </summary>
    public interface IStaffLanguage : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStaffLanguageUse> StaffLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffLanguageUse model.
    /// </summary>
    public interface IStaffLanguageUse : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffLanguage StaffLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffLeave model.
    /// </summary>
    public interface IStaffLeave : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string StaffLeaveEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string Reason { get; set; }
        bool? SubstituteAssigned { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffLeaveEventCategoryDescriptor model.
    /// </summary>
    public interface IStaffLeaveEventCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StaffLeaveEventCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffOtherName model.
    /// </summary>
    public interface IStaffOtherName : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffPersonalIdentificationDocument model.
    /// </summary>
    public interface IStaffPersonalIdentificationDocument : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffProgramAssociation model.
    /// </summary>
    public interface IStaffProgramAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int ProgramEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        bool? StudentRecordAccess { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffRace model.
    /// </summary>
    public interface IStaffRace : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffRecognition model.
    /// </summary>
    public interface IStaffRecognition : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffSchoolAssociation model.
    /// </summary>
    public interface IStaffSchoolAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ProgramAssignmentDescriptor { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        string CalendarCode { get; set; }
        short? SchoolYear { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStaffSchoolAssociationAcademicSubject> StaffSchoolAssociationAcademicSubjects { get; set; }
        ICollection<IStaffSchoolAssociationGradeLevel> StaffSchoolAssociationGradeLevels { get; set; }

        // Resource reference data
        Guid? CalendarResourceId { get; set; }
        string CalendarDiscriminator { get; set; }
        Guid? SchoolResourceId { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffSchoolAssociationAcademicSubject model.
    /// </summary>
    public interface IStaffSchoolAssociationAcademicSubject : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffSchoolAssociation StaffSchoolAssociation { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffSchoolAssociationGradeLevel model.
    /// </summary>
    public interface IStaffSchoolAssociationGradeLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffSchoolAssociation StaffSchoolAssociation { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffSectionAssociation model.
    /// </summary>
    public interface IStaffSectionAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
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
        DateTime? BeginDate { get; set; }
        string ClassroomPositionDescriptor { get; set; }
        DateTime? EndDate { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        decimal? PercentageContribution { get; set; }
        bool? TeacherStudentDataLinkExclusion { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffTelephone model.
    /// </summary>
    public interface IStaffTelephone : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StaffTribalAffiliation model.
    /// </summary>
    public interface IStaffTribalAffiliation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
        [NaturalKeyMember]
        string TribalAffiliationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffVisa model.
    /// </summary>
    public interface IStaffVisa : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
        [NaturalKeyMember]
        string VisaDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StateAbbreviationDescriptor model.
    /// </summary>
    public interface IStateAbbreviationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StateAbbreviationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StateEducationAgency model.
    /// </summary>
    public interface IStateEducationAgency : EdFi.IEducationOrganization, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int StateEducationAgencyId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStateEducationAgencyAccountability> StateEducationAgencyAccountabilities { get; set; }
        ICollection<IStateEducationAgencyFederalFunds> StateEducationAgencyFederalFunds { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StateEducationAgencyAccountability model.
    /// </summary>
    public interface IStateEducationAgencyAccountability : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStateEducationAgency StateEducationAgency { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        bool? CTEGraduationRateInclusion { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StateEducationAgencyFederalFunds model.
    /// </summary>
    public interface IStateEducationAgencyFederalFunds : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStateEducationAgency StateEducationAgency { get; set; }
        [NaturalKeyMember]
        int FiscalYear { get; set; }

        // Non-PK properties
        decimal? FederalProgramsFundingAllocation { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Student model.
    /// </summary>
    public interface IStudent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IIdentifiablePerson, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][UniqueId]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string BirthCity { get; set; }
        string BirthCountryDescriptor { get; set; }
        DateTime BirthDate { get; set; }
        string BirthInternationalProvince { get; set; }
        string BirthSexDescriptor { get; set; }
        string BirthStateAbbreviationDescriptor { get; set; }
        string CitizenshipStatusDescriptor { get; set; }
        DateTime? DateEnteredUS { get; set; }
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        bool? MultipleBirthStatus { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        string SourceSystemDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentIdentificationDocument> StudentIdentificationDocuments { get; set; }
        ICollection<IStudentOtherName> StudentOtherNames { get; set; }
        ICollection<IStudentPersonalIdentificationDocument> StudentPersonalIdentificationDocuments { get; set; }
        ICollection<IStudentVisa> StudentVisas { get; set; }

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecord model.
    /// </summary>
    public interface IStudentAcademicRecord : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties
        decimal? CumulativeAttemptedCreditConversion { get; set; }
        decimal? CumulativeAttemptedCredits { get; set; }
        string CumulativeAttemptedCreditTypeDescriptor { get; set; }
        decimal? CumulativeEarnedCreditConversion { get; set; }
        decimal? CumulativeEarnedCredits { get; set; }
        string CumulativeEarnedCreditTypeDescriptor { get; set; }
        decimal? CumulativeGradePointAverage { get; set; }
        decimal? CumulativeGradePointsEarned { get; set; }
        string GradeValueQualifier { get; set; }
        DateTime? ProjectedGraduationDate { get; set; }
        decimal? SessionAttemptedCreditConversion { get; set; }
        decimal? SessionAttemptedCredits { get; set; }
        string SessionAttemptedCreditTypeDescriptor { get; set; }
        decimal? SessionEarnedCreditConversion { get; set; }
        decimal? SessionEarnedCredits { get; set; }
        string SessionEarnedCreditTypeDescriptor { get; set; }
        decimal? SessionGradePointAverage { get; set; }
        decimal? SessionGradePointsEarned { get; set; }

        // One-to-one relationships

        IStudentAcademicRecordClassRanking StudentAcademicRecordClassRanking { get; set; }

        // Lists
        ICollection<IStudentAcademicRecordAcademicHonor> StudentAcademicRecordAcademicHonors { get; set; }
        ICollection<IStudentAcademicRecordDiploma> StudentAcademicRecordDiplomas { get; set; }
        ICollection<IStudentAcademicRecordGradePointAverage> StudentAcademicRecordGradePointAverages { get; set; }
        ICollection<IStudentAcademicRecordRecognition> StudentAcademicRecordRecognitions { get; set; }
        ICollection<IStudentAcademicRecordReportCard> StudentAcademicRecordReportCards { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordAcademicHonor model.
    /// </summary>
    public interface IStudentAcademicRecordAcademicHonor : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAcademicRecord StudentAcademicRecord { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordClassRanking model.
    /// </summary>
    public interface IStudentAcademicRecordClassRanking : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAcademicRecord StudentAcademicRecord { get; set; }

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
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordDiploma model.
    /// </summary>
    public interface IStudentAcademicRecordDiploma : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAcademicRecord StudentAcademicRecord { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordGradePointAverage model.
    /// </summary>
    public interface IStudentAcademicRecordGradePointAverage : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAcademicRecord StudentAcademicRecord { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordRecognition model.
    /// </summary>
    public interface IStudentAcademicRecordRecognition : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAcademicRecord StudentAcademicRecord { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordReportCard model.
    /// </summary>
    public interface IStudentAcademicRecordReportCard : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAcademicRecord StudentAcademicRecord { get; set; }
        [NaturalKeyMember]
        string GradingPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSchoolId { get; set; }
        [NaturalKeyMember]
        short GradingPeriodSchoolYear { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSequence { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ReportCardResourceId { get; set; }
        string ReportCardDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAssessment model.
    /// </summary>
    public interface IStudentAssessment : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string StudentAssessmentIdentifier { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        DateTime AdministrationDate { get; set; }
        DateTime? AdministrationEndDate { get; set; }
        string AdministrationEnvironmentDescriptor { get; set; }
        string AdministrationLanguageDescriptor { get; set; }
        string EventCircumstanceDescriptor { get; set; }
        string EventDescription { get; set; }
        string PlatformTypeDescriptor { get; set; }
        string ReasonNotTestedDescriptor { get; set; }
        string RetestIndicatorDescriptor { get; set; }
        short? SchoolYear { get; set; }
        string SerialNumber { get; set; }
        string WhenAssessedGradeLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentAssessmentAccommodation> StudentAssessmentAccommodations { get; set; }
        ICollection<IStudentAssessmentItem> StudentAssessmentItems { get; set; }
        ICollection<IStudentAssessmentPerformanceLevel> StudentAssessmentPerformanceLevels { get; set; }
        ICollection<IStudentAssessmentScoreResult> StudentAssessmentScoreResults { get; set; }
        ICollection<IStudentAssessmentStudentObjectiveAssessment> StudentAssessmentStudentObjectiveAssessments { get; set; }

        // Resource reference data
        Guid? AssessmentResourceId { get; set; }
        string AssessmentDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAssessmentAccommodation model.
    /// </summary>
    public interface IStudentAssessmentAccommodation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAssessment StudentAssessment { get; set; }
        [NaturalKeyMember]
        string AccommodationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAssessmentItem model.
    /// </summary>
    public interface IStudentAssessmentItem : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAssessment StudentAssessment { get; set; }
        [NaturalKeyMember]
        string IdentificationCode { get; set; }

        // Non-PK properties
        string AssessmentItemResultDescriptor { get; set; }
        string AssessmentResponse { get; set; }
        string DescriptiveFeedback { get; set; }
        decimal? RawScoreResult { get; set; }
        string ResponseIndicatorDescriptor { get; set; }
        string TimeAssessed { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AssessmentItemResourceId { get; set; }
        string AssessmentItemDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAssessmentPerformanceLevel model.
    /// </summary>
    public interface IStudentAssessmentPerformanceLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAssessment StudentAssessment { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }
        [NaturalKeyMember]
        string PerformanceLevelDescriptor { get; set; }

        // Non-PK properties
        bool PerformanceLevelMet { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAssessmentScoreResult model.
    /// </summary>
    public interface IStudentAssessmentScoreResult : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAssessment StudentAssessment { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentAssessmentStudentObjectiveAssessment model.
    /// </summary>
    public interface IStudentAssessmentStudentObjectiveAssessment : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAssessment StudentAssessment { get; set; }
        [NaturalKeyMember]
        string IdentificationCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStudentAssessmentStudentObjectiveAssessmentPerformanceLevel> StudentAssessmentStudentObjectiveAssessmentPerformanceLevels { get; set; }
        ICollection<IStudentAssessmentStudentObjectiveAssessmentScoreResult> StudentAssessmentStudentObjectiveAssessmentScoreResults { get; set; }

        // Resource reference data
        Guid? ObjectiveAssessmentResourceId { get; set; }
        string ObjectiveAssessmentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAssessmentStudentObjectiveAssessmentPerformanceLevel model.
    /// </summary>
    public interface IStudentAssessmentStudentObjectiveAssessmentPerformanceLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAssessmentStudentObjectiveAssessment StudentAssessmentStudentObjectiveAssessment { get; set; }
        [NaturalKeyMember]
        string AssessmentReportingMethodDescriptor { get; set; }
        [NaturalKeyMember]
        string PerformanceLevelDescriptor { get; set; }

        // Non-PK properties
        bool PerformanceLevelMet { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAssessmentStudentObjectiveAssessmentScoreResult model.
    /// </summary>
    public interface IStudentAssessmentStudentObjectiveAssessmentScoreResult : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentAssessmentStudentObjectiveAssessment StudentAssessmentStudentObjectiveAssessment { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentCharacteristicDescriptor model.
    /// </summary>
    public interface IStudentCharacteristicDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StudentCharacteristicDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCohortAssociation model.
    /// </summary>
    public interface IStudentCohortAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        string CohortIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentCohortAssociationSection> StudentCohortAssociationSections { get; set; }

        // Resource reference data
        Guid? CohortResourceId { get; set; }
        string CohortDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCohortAssociationSection model.
    /// </summary>
    public interface IStudentCohortAssociationSection : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentCohortAssociation StudentCohortAssociation { get; set; }
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

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCompetencyObjective model.
    /// </summary>
    public interface IStudentCompetencyObjective : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string GradingPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSchoolId { get; set; }
        [NaturalKeyMember]
        short GradingPeriodSchoolYear { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSequence { get; set; }
        [NaturalKeyMember]
        string Objective { get; set; }
        [NaturalKeyMember]
        int ObjectiveEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ObjectiveGradeLevelDescriptor { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string CompetencyLevelDescriptor { get; set; }
        string DiagnosticStatement { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentCompetencyObjectiveGeneralStudentProgramAssociation> StudentCompetencyObjectiveGeneralStudentProgramAssociations { get; set; }
        ICollection<IStudentCompetencyObjectiveStudentSectionAssociation> StudentCompetencyObjectiveStudentSectionAssociations { get; set; }

        // Resource reference data
        Guid? GradingPeriodResourceId { get; set; }
        string GradingPeriodDiscriminator { get; set; }
        Guid? ObjectiveCompetencyObjectiveResourceId { get; set; }
        string ObjectiveCompetencyObjectiveDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCompetencyObjectiveGeneralStudentProgramAssociation model.
    /// </summary>
    public interface IStudentCompetencyObjectiveGeneralStudentProgramAssociation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentCompetencyObjective StudentCompetencyObjective { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int ProgramEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? GeneralStudentProgramAssociationResourceId { get; set; }
        string GeneralStudentProgramAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCompetencyObjectiveStudentSectionAssociation model.
    /// </summary>
    public interface IStudentCompetencyObjectiveStudentSectionAssociation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentCompetencyObjective StudentCompetencyObjective { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
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

        // Lists

        // Resource reference data
        Guid? StudentSectionAssociationResourceId { get; set; }
        string StudentSectionAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCTEProgramAssociation model.
    /// </summary>
    public interface IStudentCTEProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        bool? NonTraditionalGenderStatus { get; set; }
        bool? PrivateCTEProgram { get; set; }
        string TechnicalSkillsAssessmentDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentCTEProgramAssociationCTEProgram> StudentCTEProgramAssociationCTEPrograms { get; set; }
        ICollection<IStudentCTEProgramAssociationCTEProgramService> StudentCTEProgramAssociationCTEProgramServices { get; set; }
        ICollection<IStudentCTEProgramAssociationService> StudentCTEProgramAssociationServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCTEProgramAssociationCTEProgram model.
    /// </summary>
    public interface IStudentCTEProgramAssociationCTEProgram : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentCTEProgramAssociation StudentCTEProgramAssociation { get; set; }
        [NaturalKeyMember]
        string CareerPathwayDescriptor { get; set; }

        // Non-PK properties
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCTEProgramAssociationCTEProgramService model.
    /// </summary>
    public interface IStudentCTEProgramAssociationCTEProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentCTEProgramAssociation StudentCTEProgramAssociation { get; set; }
        [NaturalKeyMember]
        string CTEProgramServiceDescriptor { get; set; }

        // Non-PK properties
        string CIPCode { get; set; }
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCTEProgramAssociationService model.
    /// </summary>
    public interface IStudentCTEProgramAssociationService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentCTEProgramAssociation StudentCTEProgramAssociation { get; set; }
        [NaturalKeyMember]
        string ServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentDisciplineIncidentAssociation model.
    /// </summary>
    public interface IStudentDisciplineIncidentAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string IncidentIdentifier { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string StudentParticipationCodeDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentDisciplineIncidentAssociationBehavior> StudentDisciplineIncidentAssociationBehaviors { get; set; }

        // Resource reference data
        Guid? DisciplineIncidentResourceId { get; set; }
        string DisciplineIncidentDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentDisciplineIncidentAssociationBehavior model.
    /// </summary>
    public interface IStudentDisciplineIncidentAssociationBehavior : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentDisciplineIncidentAssociation StudentDisciplineIncidentAssociation { get; set; }
        [NaturalKeyMember]
        string BehaviorDescriptor { get; set; }

        // Non-PK properties
        string BehaviorDetailedDescription { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociation model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        bool? HispanicLatinoEthnicity { get; set; }
        string LimitedEnglishProficiencyDescriptor { get; set; }
        string LoginId { get; set; }
        string OldEthnicityDescriptor { get; set; }
        string ProfileThumbnail { get; set; }
        string SexDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationAddress> StudentEducationOrganizationAssociationAddresses { get; set; }
        ICollection<IStudentEducationOrganizationAssociationCohortYear> StudentEducationOrganizationAssociationCohortYears { get; set; }
        ICollection<IStudentEducationOrganizationAssociationDisability> StudentEducationOrganizationAssociationDisabilities { get; set; }
        ICollection<IStudentEducationOrganizationAssociationElectronicMail> StudentEducationOrganizationAssociationElectronicMails { get; set; }
        ICollection<IStudentEducationOrganizationAssociationInternationalAddress> StudentEducationOrganizationAssociationInternationalAddresses { get; set; }
        ICollection<IStudentEducationOrganizationAssociationLanguage> StudentEducationOrganizationAssociationLanguages { get; set; }
        ICollection<IStudentEducationOrganizationAssociationProgramParticipation> StudentEducationOrganizationAssociationProgramParticipations { get; set; }
        ICollection<IStudentEducationOrganizationAssociationRace> StudentEducationOrganizationAssociationRaces { get; set; }
        ICollection<IStudentEducationOrganizationAssociationStudentCharacteristic> StudentEducationOrganizationAssociationStudentCharacteristics { get; set; }
        ICollection<IStudentEducationOrganizationAssociationStudentIdentificationCode> StudentEducationOrganizationAssociationStudentIdentificationCodes { get; set; }
        ICollection<IStudentEducationOrganizationAssociationStudentIndicator> StudentEducationOrganizationAssociationStudentIndicators { get; set; }
        ICollection<IStudentEducationOrganizationAssociationTelephone> StudentEducationOrganizationAssociationTelephones { get; set; }
        ICollection<IStudentEducationOrganizationAssociationTribalAffiliation> StudentEducationOrganizationAssociationTribalAffiliations { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddress model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
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
        ICollection<IStudentEducationOrganizationAssociationAddressPeriod> StudentEducationOrganizationAssociationAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddressPeriod model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationAddress StudentEducationOrganizationAssociationAddress { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationCohortYear model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationCohortYear : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationDisability model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationDisability : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationDisabilityDesignation> StudentEducationOrganizationAssociationDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationDisabilityDesignation model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationDisabilityDesignation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationDisability StudentEducationOrganizationAssociationDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationElectronicMail model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationElectronicMail : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationInternationalAddress model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationInternationalAddress : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationLanguage model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationLanguage : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
        [NaturalKeyMember]
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationLanguageUse> StudentEducationOrganizationAssociationLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationLanguageUse model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationLanguageUse : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationLanguage StudentEducationOrganizationAssociationLanguage { get; set; }
        [NaturalKeyMember]
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationProgramParticipation model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationProgramParticipation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic> StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristics { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationProgramParticipation StudentEducationOrganizationAssociationProgramParticipation { get; set; }
        [NaturalKeyMember]
        string ProgramCharacteristicDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationRace model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationRace : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
        [NaturalKeyMember]
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentCharacteristic model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristic : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
        [NaturalKeyMember]
        string StudentCharacteristicDescriptor { get; set; }

        // Non-PK properties
        string DesignatedBy { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationStudentCharacteristicPeriod> StudentEducationOrganizationAssociationStudentCharacteristicPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentCharacteristicPeriod model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationStudentCharacteristic StudentEducationOrganizationAssociationStudentCharacteristic { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentIdentificationCode model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentIdentificationCode : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentIndicator model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentIndicator : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
        [NaturalKeyMember]
        string IndicatorName { get; set; }

        // Non-PK properties
        string DesignatedBy { get; set; }
        string Indicator { get; set; }
        string IndicatorGroup { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationStudentIndicatorPeriod> StudentEducationOrganizationAssociationStudentIndicatorPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentIndicatorPeriod model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentIndicatorPeriod : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationStudentIndicator StudentEducationOrganizationAssociationStudentIndicator { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationTelephone model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationTelephone : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationTribalAffiliation model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationTribalAffiliation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }
        [NaturalKeyMember]
        string TribalAffiliationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationResponsibilityAssociation model.
    /// </summary>
    public interface IStudentEducationOrganizationResponsibilityAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ResponsibilityDescriptor { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGradebookEntry model.
    /// </summary>
    public interface IStudentGradebookEntry : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        DateTime DateAssigned { get; set; }
        [NaturalKeyMember]
        string GradebookEntryTitle { get; set; }
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
        string CompetencyLevelDescriptor { get; set; }
        DateTime? DateFulfilled { get; set; }
        string DiagnosticStatement { get; set; }
        string LetterGradeEarned { get; set; }
        decimal? NumericGradeEarned { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? GradebookEntryResourceId { get; set; }
        string GradebookEntryDiscriminator { get; set; }
        Guid? StudentSectionAssociationResourceId { get; set; }
        string StudentSectionAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentHomelessProgramAssociation model.
    /// </summary>
    public interface IStudentHomelessProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        bool? AwaitingFosterCare { get; set; }
        string HomelessPrimaryNighttimeResidenceDescriptor { get; set; }
        bool? HomelessUnaccompaniedYouth { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentHomelessProgramAssociationHomelessProgramService> StudentHomelessProgramAssociationHomelessProgramServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentHomelessProgramAssociationHomelessProgramService model.
    /// </summary>
    public interface IStudentHomelessProgramAssociationHomelessProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentHomelessProgramAssociation StudentHomelessProgramAssociation { get; set; }
        [NaturalKeyMember]
        string HomelessProgramServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentIdentificationDocument model.
    /// </summary>
    public interface IStudentIdentificationDocument : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudent Student { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentIdentificationSystemDescriptor model.
    /// </summary>
    public interface IStudentIdentificationSystemDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StudentIdentificationSystemDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentInterventionAssociation model.
    /// </summary>
    public interface IStudentInterventionAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string InterventionIdentificationCode { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        int? CohortEducationOrganizationId { get; set; }
        string CohortIdentifier { get; set; }
        string DiagnosticStatement { get; set; }
        int? Dosage { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentInterventionAssociationInterventionEffectiveness> StudentInterventionAssociationInterventionEffectivenesses { get; set; }

        // Resource reference data
        Guid? CohortResourceId { get; set; }
        string CohortDiscriminator { get; set; }
        Guid? InterventionResourceId { get; set; }
        string InterventionDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentInterventionAssociationInterventionEffectiveness model.
    /// </summary>
    public interface IStudentInterventionAssociationInterventionEffectiveness : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentInterventionAssociation StudentInterventionAssociation { get; set; }
        [NaturalKeyMember]
        string DiagnosisDescriptor { get; set; }
        [NaturalKeyMember]
        string GradeLevelDescriptor { get; set; }
        [NaturalKeyMember]
        string PopulationServedDescriptor { get; set; }

        // Non-PK properties
        int? ImprovementIndex { get; set; }
        string InterventionEffectivenessRatingDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentInterventionAttendanceEvent model.
    /// </summary>
    public interface IStudentInterventionAttendanceEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AttendanceEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        string InterventionIdentificationCode { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string AttendanceEventReason { get; set; }
        string EducationalEnvironmentDescriptor { get; set; }
        decimal? EventDuration { get; set; }
        int? InterventionDuration { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? InterventionResourceId { get; set; }
        string InterventionDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentLanguageInstructionProgramAssociation model.
    /// </summary>
    public interface IStudentLanguageInstructionProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        int? Dosage { get; set; }
        bool? EnglishLearnerParticipation { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment> StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessments { get; set; }
        ICollection<IStudentLanguageInstructionProgramAssociationLanguageInstructionProgramService> StudentLanguageInstructionProgramAssociationLanguageInstructionProgramServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment model.
    /// </summary>
    public interface IStudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentLanguageInstructionProgramAssociation StudentLanguageInstructionProgramAssociation { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }

        // Non-PK properties
        string MonitoredDescriptor { get; set; }
        string ParticipationDescriptor { get; set; }
        string ProficiencyDescriptor { get; set; }
        string ProgressDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService model.
    /// </summary>
    public interface IStudentLanguageInstructionProgramAssociationLanguageInstructionProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentLanguageInstructionProgramAssociation StudentLanguageInstructionProgramAssociation { get; set; }
        [NaturalKeyMember]
        string LanguageInstructionProgramServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentLearningObjective model.
    /// </summary>
    public interface IStudentLearningObjective : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string GradingPeriodDescriptor { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSchoolId { get; set; }
        [NaturalKeyMember]
        short GradingPeriodSchoolYear { get; set; }
        [NaturalKeyMember]
        int GradingPeriodSequence { get; set; }
        [NaturalKeyMember]
        string LearningObjectiveId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string CompetencyLevelDescriptor { get; set; }
        string DiagnosticStatement { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentLearningObjectiveGeneralStudentProgramAssociation> StudentLearningObjectiveGeneralStudentProgramAssociations { get; set; }
        ICollection<IStudentLearningObjectiveStudentSectionAssociation> StudentLearningObjectiveStudentSectionAssociations { get; set; }

        // Resource reference data
        Guid? GradingPeriodResourceId { get; set; }
        string GradingPeriodDiscriminator { get; set; }
        Guid? LearningObjectiveResourceId { get; set; }
        string LearningObjectiveDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentLearningObjectiveGeneralStudentProgramAssociation model.
    /// </summary>
    public interface IStudentLearningObjectiveGeneralStudentProgramAssociation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentLearningObjective StudentLearningObjective { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int ProgramEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? GeneralStudentProgramAssociationResourceId { get; set; }
        string GeneralStudentProgramAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentLearningObjectiveStudentSectionAssociation model.
    /// </summary>
    public interface IStudentLearningObjectiveStudentSectionAssociation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentLearningObjective StudentLearningObjective { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
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

        // Lists

        // Resource reference data
        Guid? StudentSectionAssociationResourceId { get; set; }
        string StudentSectionAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentMigrantEducationProgramAssociation model.
    /// </summary>
    public interface IStudentMigrantEducationProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        string ContinuationOfServicesReasonDescriptor { get; set; }
        DateTime? EligibilityExpirationDate { get; set; }
        DateTime LastQualifyingMove { get; set; }
        bool PriorityForServices { get; set; }
        DateTime? QualifyingArrivalDate { get; set; }
        DateTime? StateResidencyDate { get; set; }
        DateTime? USInitialEntry { get; set; }
        DateTime? USInitialSchoolEntry { get; set; }
        DateTime? USMostRecentEntry { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentMigrantEducationProgramAssociationMigrantEducationProgramService> StudentMigrantEducationProgramAssociationMigrantEducationProgramServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentMigrantEducationProgramAssociationMigrantEducationProgramService model.
    /// </summary>
    public interface IStudentMigrantEducationProgramAssociationMigrantEducationProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentMigrantEducationProgramAssociation StudentMigrantEducationProgramAssociation { get; set; }
        [NaturalKeyMember]
        string MigrantEducationProgramServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentNeglectedOrDelinquentProgramAssociation model.
    /// </summary>
    public interface IStudentNeglectedOrDelinquentProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        string ELAProgressLevelDescriptor { get; set; }
        string MathematicsProgressLevelDescriptor { get; set; }
        string NeglectedOrDelinquentProgramDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService> StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService model.
    /// </summary>
    public interface IStudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentNeglectedOrDelinquentProgramAssociation StudentNeglectedOrDelinquentProgramAssociation { get; set; }
        [NaturalKeyMember]
        string NeglectedOrDelinquentProgramServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentOtherName model.
    /// </summary>
    public interface IStudentOtherName : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudent Student { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentParentAssociation model.
    /// </summary>
    public interface IStudentParentAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ParentUniqueId { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        int? ContactPriority { get; set; }
        string ContactRestrictions { get; set; }
        bool? EmergencyContactStatus { get; set; }
        bool? LivesWith { get; set; }
        bool? PrimaryContactStatus { get; set; }
        string RelationDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ParentResourceId { get; set; }
        string ParentDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParticipationCodeDescriptor model.
    /// </summary>
    public interface IStudentParticipationCodeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int StudentParticipationCodeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentPersonalIdentificationDocument model.
    /// </summary>
    public interface IStudentPersonalIdentificationDocument : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudent Student { get; set; }
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
    /// Defines available properties and methods for the abstraction of the StudentProgramAssociation model.
    /// </summary>
    public interface IStudentProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStudentProgramAssociationService> StudentProgramAssociationServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentProgramAssociationService model.
    /// </summary>
    public interface IStudentProgramAssociationService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentProgramAssociation StudentProgramAssociation { get; set; }
        [NaturalKeyMember]
        string ServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentProgramAttendanceEvent model.
    /// </summary>
    public interface IStudentProgramAttendanceEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AttendanceEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        int ProgramEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string AttendanceEventReason { get; set; }
        string EducationalEnvironmentDescriptor { get; set; }
        decimal? EventDuration { get; set; }
        int? ProgramAttendanceDuration { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolAssociation model.
    /// </summary>
    public interface IStudentSchoolAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime EntryDate { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        string CalendarCode { get; set; }
        short? ClassOfSchoolYear { get; set; }
        int? EducationOrganizationId { get; set; }
        bool? EmployedWhileEnrolled { get; set; }
        string EntryGradeLevelDescriptor { get; set; }
        string EntryGradeLevelReasonDescriptor { get; set; }
        string EntryTypeDescriptor { get; set; }
        DateTime? ExitWithdrawDate { get; set; }
        string ExitWithdrawTypeDescriptor { get; set; }
        decimal? FullTimeEquivalency { get; set; }
        string GraduationPlanTypeDescriptor { get; set; }
        short? GraduationSchoolYear { get; set; }
        bool? PrimarySchool { get; set; }
        bool? RepeatGradeIndicator { get; set; }
        string ResidencyStatusDescriptor { get; set; }
        bool? SchoolChoiceTransfer { get; set; }
        short? SchoolYear { get; set; }
        bool? TermCompletionIndicator { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentSchoolAssociationAlternativeGraduationPlan> StudentSchoolAssociationAlternativeGraduationPlans { get; set; }
        ICollection<IStudentSchoolAssociationEducationPlan> StudentSchoolAssociationEducationPlans { get; set; }

        // Resource reference data
        Guid? CalendarResourceId { get; set; }
        string CalendarDiscriminator { get; set; }
        Guid? ClassOfSchoolYearTypeResourceId { get; set; }
        Guid? GraduationPlanResourceId { get; set; }
        string GraduationPlanDiscriminator { get; set; }
        Guid? SchoolResourceId { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolAssociationAlternativeGraduationPlan model.
    /// </summary>
    public interface IStudentSchoolAssociationAlternativeGraduationPlan : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSchoolAssociation StudentSchoolAssociation { get; set; }
        [NaturalKeyMember]
        int AlternativeEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string AlternativeGraduationPlanTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short AlternativeGraduationSchoolYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? AlternativeGraduationPlanResourceId { get; set; }
        string AlternativeGraduationPlanDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolAssociationEducationPlan model.
    /// </summary>
    public interface IStudentSchoolAssociationEducationPlan : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSchoolAssociation StudentSchoolAssociation { get; set; }
        [NaturalKeyMember]
        string EducationPlanDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolAttendanceEvent model.
    /// </summary>
    public interface IStudentSchoolAttendanceEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AttendanceEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SessionName { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        TimeSpan? ArrivalTime { get; set; }
        string AttendanceEventReason { get; set; }
        TimeSpan? DepartureTime { get; set; }
        string EducationalEnvironmentDescriptor { get; set; }
        decimal? EventDuration { get; set; }
        int? SchoolAttendanceDuration { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        Guid? SessionResourceId { get; set; }
        string SessionDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolFoodServiceProgramAssociation model.
    /// </summary>
    public interface IStudentSchoolFoodServiceProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        bool? DirectCertification { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService> StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService model.
    /// </summary>
    public interface IStudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSchoolFoodServiceProgramAssociation StudentSchoolFoodServiceProgramAssociation { get; set; }
        [NaturalKeyMember]
        string SchoolFoodServiceProgramServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSectionAssociation model.
    /// </summary>
    public interface IStudentSectionAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
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
        string AttemptStatusDescriptor { get; set; }
        DateTime? EndDate { get; set; }
        bool? HomeroomIndicator { get; set; }
        string RepeatIdentifierDescriptor { get; set; }
        bool? TeacherStudentDataLinkExclusion { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSectionAttendanceEvent model.
    /// </summary>
    public interface IStudentSectionAttendanceEvent : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string AttendanceEventCategoryDescriptor { get; set; }
        [NaturalKeyMember]
        DateTime EventDate { get; set; }
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
        TimeSpan? ArrivalTime { get; set; }
        string AttendanceEventReason { get; set; }
        TimeSpan? DepartureTime { get; set; }
        string EducationalEnvironmentDescriptor { get; set; }
        decimal? EventDuration { get; set; }
        int? SectionAttendanceDuration { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSpecialEducationProgramAssociation model.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        bool? IdeaEligibility { get; set; }
        DateTime? IEPBeginDate { get; set; }
        DateTime? IEPEndDate { get; set; }
        DateTime? IEPReviewDate { get; set; }
        DateTime? LastEvaluationDate { get; set; }
        bool? MedicallyFragile { get; set; }
        bool? MultiplyDisabled { get; set; }
        decimal? SchoolHoursPerWeek { get; set; }
        decimal? SpecialEducationHoursPerWeek { get; set; }
        string SpecialEducationSettingDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentSpecialEducationProgramAssociationDisability> StudentSpecialEducationProgramAssociationDisabilities { get; set; }
        ICollection<IStudentSpecialEducationProgramAssociationServiceProvider> StudentSpecialEducationProgramAssociationServiceProviders { get; set; }
        ICollection<IStudentSpecialEducationProgramAssociationSpecialEducationProgramService> StudentSpecialEducationProgramAssociationSpecialEducationProgramServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSpecialEducationProgramAssociationDisability model.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationDisability : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSpecialEducationProgramAssociation StudentSpecialEducationProgramAssociation { get; set; }
        [NaturalKeyMember]
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentSpecialEducationProgramAssociationDisabilityDesignation> StudentSpecialEducationProgramAssociationDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSpecialEducationProgramAssociationDisabilityDesignation model.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationDisabilityDesignation : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSpecialEducationProgramAssociationDisability StudentSpecialEducationProgramAssociationDisability { get; set; }
        [NaturalKeyMember]
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSpecialEducationProgramAssociationServiceProvider model.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationServiceProvider : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSpecialEducationProgramAssociation StudentSpecialEducationProgramAssociation { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        bool? PrimaryProvider { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSpecialEducationProgramAssociationSpecialEducationProgramService model.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationSpecialEducationProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSpecialEducationProgramAssociation StudentSpecialEducationProgramAssociation { get; set; }
        [NaturalKeyMember]
        string SpecialEducationProgramServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider> StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProviders { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider model.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentSpecialEducationProgramAssociationSpecialEducationProgramService StudentSpecialEducationProgramAssociationSpecialEducationProgramService { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties
        bool? PrimaryProvider { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentTitleIPartAProgramAssociation model.
    /// </summary>
    public interface IStudentTitleIPartAProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        string TitleIPartAParticipantDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentTitleIPartAProgramAssociationService> StudentTitleIPartAProgramAssociationServices { get; set; }
        ICollection<IStudentTitleIPartAProgramAssociationTitleIPartAProgramService> StudentTitleIPartAProgramAssociationTitleIPartAProgramServices { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentTitleIPartAProgramAssociationService model.
    /// </summary>
    public interface IStudentTitleIPartAProgramAssociationService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentTitleIPartAProgramAssociation StudentTitleIPartAProgramAssociation { get; set; }
        [NaturalKeyMember]
        string ServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentTitleIPartAProgramAssociationTitleIPartAProgramService model.
    /// </summary>
    public interface IStudentTitleIPartAProgramAssociationTitleIPartAProgramService : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentTitleIPartAProgramAssociation StudentTitleIPartAProgramAssociation { get; set; }
        [NaturalKeyMember]
        string TitleIPartAProgramServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentVisa model.
    /// </summary>
    public interface IStudentVisa : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudent Student { get; set; }
        [NaturalKeyMember]
        string VisaDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Survey model.
    /// </summary>
    public interface ISurvey : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }

        // Non-PK properties
        int? EducationOrganizationId { get; set; }
        int? NumberAdministered { get; set; }
        int? SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
        string SurveyCategoryDescriptor { get; set; }
        string SurveyTitle { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
        Guid? SessionResourceId { get; set; }
        string SessionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyCategoryDescriptor model.
    /// </summary>
    public interface ISurveyCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SurveyCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyCourseAssociation model.
    /// </summary>
    public interface ISurveyCourseAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string CourseCode { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? CourseResourceId { get; set; }
        string CourseDiscriminator { get; set; }
        Guid? SurveyResourceId { get; set; }
        string SurveyDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyLevelDescriptor model.
    /// </summary>
    public interface ISurveyLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SurveyLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyProgramAssociation model.
    /// </summary>
    public interface ISurveyProgramAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
        Guid? SurveyResourceId { get; set; }
        string SurveyDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyQuestion model.
    /// </summary>
    public interface ISurveyQuestion : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string QuestionCode { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }

        // Non-PK properties
        string QuestionFormDescriptor { get; set; }
        string QuestionText { get; set; }
        string SurveySectionTitle { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ISurveyQuestionMatrix> SurveyQuestionMatrices { get; set; }
        ICollection<ISurveyQuestionResponseChoice> SurveyQuestionResponseChoices { get; set; }

        // Resource reference data
        Guid? SurveyResourceId { get; set; }
        string SurveyDiscriminator { get; set; }
        Guid? SurveySectionResourceId { get; set; }
        string SurveySectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyQuestionMatrix model.
    /// </summary>
    public interface ISurveyQuestionMatrix : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISurveyQuestion SurveyQuestion { get; set; }
        [NaturalKeyMember]
        string MatrixElement { get; set; }

        // Non-PK properties
        int? MaxRawScore { get; set; }
        int? MinRawScore { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyQuestionResponse model.
    /// </summary>
    public interface ISurveyQuestionResponse : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string QuestionCode { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }

        // Non-PK properties
        string Comment { get; set; }
        bool? NoResponse { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ISurveyQuestionResponseSurveyQuestionMatrixElementResponse> SurveyQuestionResponseSurveyQuestionMatrixElementResponses { get; set; }
        ICollection<ISurveyQuestionResponseValue> SurveyQuestionResponseValues { get; set; }

        // Resource reference data
        Guid? SurveyQuestionResourceId { get; set; }
        string SurveyQuestionDiscriminator { get; set; }
        Guid? SurveyResponseResourceId { get; set; }
        string SurveyResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyQuestionResponseChoice model.
    /// </summary>
    public interface ISurveyQuestionResponseChoice : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISurveyQuestion SurveyQuestion { get; set; }
        [NaturalKeyMember]
        int SortOrder { get; set; }

        // Non-PK properties
        int? NumericValue { get; set; }
        string TextValue { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyQuestionResponseSurveyQuestionMatrixElementResponse model.
    /// </summary>
    public interface ISurveyQuestionResponseSurveyQuestionMatrixElementResponse : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISurveyQuestionResponse SurveyQuestionResponse { get; set; }
        [NaturalKeyMember]
        string MatrixElement { get; set; }

        // Non-PK properties
        int? MaxNumericResponse { get; set; }
        int? MinNumericResponse { get; set; }
        bool? NoResponse { get; set; }
        int? NumericResponse { get; set; }
        string TextResponse { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyQuestionResponseValue model.
    /// </summary>
    public interface ISurveyQuestionResponseValue : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISurveyQuestionResponse SurveyQuestionResponse { get; set; }
        [NaturalKeyMember]
        int SurveyQuestionResponseValueIdentifier { get; set; }

        // Non-PK properties
        int? NumericResponse { get; set; }
        string TextResponse { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponse model.
    /// </summary>
    public interface ISurveyResponse : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }

        // Non-PK properties
        string ElectronicMailAddress { get; set; }
        string FullName { get; set; }
        string Location { get; set; }
        string ParentUniqueId { get; set; }
        DateTime ResponseDate { get; set; }
        int? ResponseTime { get; set; }
        string StaffUniqueId { get; set; }
        string StudentUniqueId { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ISurveyResponseSurveyLevel> SurveyResponseSurveyLevels { get; set; }

        // Resource reference data
        Guid? ParentResourceId { get; set; }
        string ParentDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
        Guid? SurveyResourceId { get; set; }
        string SurveyDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponseEducationOrganizationTargetAssociation model.
    /// </summary>
    public interface ISurveyResponseEducationOrganizationTargetAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SurveyResponseResourceId { get; set; }
        string SurveyResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponseStaffTargetAssociation model.
    /// </summary>
    public interface ISurveyResponseStaffTargetAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveyResponseIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? SurveyResponseResourceId { get; set; }
        string SurveyResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponseSurveyLevel model.
    /// </summary>
    public interface ISurveyResponseSurveyLevel : ISynchronizable, IMappable, IHasExtensions, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISurveyResponse SurveyResponse { get; set; }
        [NaturalKeyMember]
        string SurveyLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySection model.
    /// </summary>
    public interface ISurveySection : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }
        [NaturalKeyMember]
        string SurveySectionTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SurveyResourceId { get; set; }
        string SurveyDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionAssociation model.
    /// </summary>
    public interface ISurveySectionAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string LocalCourseCode { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        int SchoolId { get; set; }
        [NaturalKeyMember]
        short SchoolYear { get; set; }
        [NaturalKeyMember]
        string SectionIdentifier { get; set; }
        [NaturalKeyMember]
        string SessionName { get; set; }
        [NaturalKeyMember]
        string SurveyIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
        Guid? SurveyResourceId { get; set; }
        string SurveyDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionResponse model.
    /// </summary>
    public interface ISurveySectionResponse : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
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

        // Non-PK properties
        decimal? SectionRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SurveyResponseResourceId { get; set; }
        string SurveyResponseDiscriminator { get; set; }
        Guid? SurveySectionResourceId { get; set; }
        string SurveySectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionResponseEducationOrganizationTargetAssociation model.
    /// </summary>
    public interface ISurveySectionResponseEducationOrganizationTargetAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string Namespace { get; set; }
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
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SurveySectionResponseResourceId { get; set; }
        string SurveySectionResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionResponseStaffTargetAssociation model.
    /// </summary>
    public interface ISurveySectionResponseStaffTargetAssociation : ISynchronizable, IMappable, IHasExtensions, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string Namespace { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }
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
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? SurveySectionResponseResourceId { get; set; }
        string SurveySectionResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeachingCredentialBasisDescriptor model.
    /// </summary>
    public interface ITeachingCredentialBasisDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TeachingCredentialBasisDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TeachingCredentialDescriptor model.
    /// </summary>
    public interface ITeachingCredentialDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TeachingCredentialDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TechnicalSkillsAssessmentDescriptor model.
    /// </summary>
    public interface ITechnicalSkillsAssessmentDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TechnicalSkillsAssessmentDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TelephoneNumberTypeDescriptor model.
    /// </summary>
    public interface ITelephoneNumberTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TelephoneNumberTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TermDescriptor model.
    /// </summary>
    public interface ITermDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TermDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TitleIPartAParticipantDescriptor model.
    /// </summary>
    public interface ITitleIPartAParticipantDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TitleIPartAParticipantDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TitleIPartAProgramServiceDescriptor model.
    /// </summary>
    public interface ITitleIPartAProgramServiceDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TitleIPartAProgramServiceDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TitleIPartASchoolDesignationDescriptor model.
    /// </summary>
    public interface ITitleIPartASchoolDesignationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TitleIPartASchoolDesignationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the TribalAffiliationDescriptor model.
    /// </summary>
    public interface ITribalAffiliationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int TribalAffiliationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the VisaDescriptor model.
    /// </summary>
    public interface IVisaDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int VisaDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the WeaponDescriptor model.
    /// </summary>
    public interface IWeaponDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int WeaponDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }
}
