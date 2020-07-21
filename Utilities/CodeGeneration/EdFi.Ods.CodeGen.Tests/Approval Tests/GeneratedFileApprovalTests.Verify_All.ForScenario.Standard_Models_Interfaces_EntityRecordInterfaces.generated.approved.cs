using System;


namespace EdFi.Ods.Entities.Common.Records.EdFi
{ 

    /// <summary>
    /// Interface for the edfi.AbsenceEventCategoryDescriptor table of the AbsenceEventCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAbsenceEventCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AbsenceEventCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AcademicHonorCategoryDescriptor table of the AcademicHonorCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAcademicHonorCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AcademicHonorCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AcademicSubjectDescriptor table of the AcademicSubjectDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAcademicSubjectDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AcademicWeek table of the AcademicWeek aggregate in the Ods Database.
    /// </summary>
    public interface IAcademicWeekRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        Guid Id { get; set; }
        int SchoolId { get; set; }
        int TotalInstructionalDays { get; set; }
        string WeekIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AccommodationDescriptor table of the AccommodationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAccommodationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AccommodationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Account table of the Account aggregate in the Ods Database.
    /// </summary>
    public interface IAccountRecord
    {     
        // Properties for all columns in physical table
        string AccountIdentifier { get; set; }
        string AccountName { get; set; }
        int EducationOrganizationId { get; set; }
        int FiscalYear { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AccountabilityRating table of the AccountabilityRating aggregate in the Ods Database.
    /// </summary>
    public interface IAccountabilityRatingRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string Rating { get; set; }
        DateTime? RatingDate { get; set; }
        string RatingOrganization { get; set; }
        string RatingProgram { get; set; }
        string RatingTitle { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AccountAccountCode table of the Account aggregate in the Ods Database.
    /// </summary>
    public interface IAccountAccountCodeRecord
    {     
        // Properties for all columns in physical table
        int AccountClassificationDescriptorId { get; set; }
        string AccountCodeNumber { get; set; }
        string AccountIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int FiscalYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AccountClassificationDescriptor table of the AccountClassificationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAccountClassificationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AccountClassificationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AccountCode table of the AccountCode aggregate in the Ods Database.
    /// </summary>
    public interface IAccountCodeRecord
    {     
        // Properties for all columns in physical table
        int AccountClassificationDescriptorId { get; set; }
        string AccountCodeDescription { get; set; }
        string AccountCodeNumber { get; set; }
        int EducationOrganizationId { get; set; }
        int FiscalYear { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AchievementCategoryDescriptor table of the AchievementCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAchievementCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AchievementCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Actual table of the Actual aggregate in the Ods Database.
    /// </summary>
    public interface IActualRecord
    {     
        // Properties for all columns in physical table
        string AccountIdentifier { get; set; }
        decimal AmountToDate { get; set; }
        DateTime AsOfDate { get; set; }
        int EducationOrganizationId { get; set; }
        int FiscalYear { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AdditionalCreditTypeDescriptor table of the AdditionalCreditTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAdditionalCreditTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AdditionalCreditTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AddressTypeDescriptor table of the AddressTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAddressTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AdministrationEnvironmentDescriptor table of the AdministrationEnvironmentDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAdministrationEnvironmentDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AdministrationEnvironmentDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AdministrativeFundingControlDescriptor table of the AdministrativeFundingControlDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAdministrativeFundingControlDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AdministrativeFundingControlDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Assessment table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentRecord
    {     
        // Properties for all columns in physical table
        bool? AdaptiveAssessment { get; set; }
        int? AssessmentCategoryDescriptorId { get; set; }
        string AssessmentFamily { get; set; }
        string AssessmentForm { get; set; }
        string AssessmentIdentifier { get; set; }
        string AssessmentTitle { get; set; }
        int? AssessmentVersion { get; set; }
        int? EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        decimal? MaxRawScore { get; set; }
        string Namespace { get; set; }
        string Nomenclature { get; set; }
        DateTime? RevisionDate { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentAcademicSubject table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        string AssessmentIdentifier { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentAssessedGradeLevel table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentAssessedGradeLevelRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentCategoryDescriptor table of the AssessmentCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AssessmentCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentContentStandard table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentContentStandardRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        int? MandatingEducationOrganizationId { get; set; }
        string Namespace { get; set; }
        DateTime? PublicationDate { get; set; }
        int? PublicationStatusDescriptorId { get; set; }
        short? PublicationYear { get; set; }
        string Title { get; set; }
        string URI { get; set; }
        string Version { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentContentStandardAuthor table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentContentStandardAuthorRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string Author { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentIdentificationCode table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        int AssessmentIdentificationSystemDescriptorId { get; set; }
        string AssessmentIdentifier { get; set; }
        string AssigningOrganizationIdentificationCode { get; set; }
        string IdentificationCode { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentIdentificationSystemDescriptor table of the AssessmentIdentificationSystemDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentIdentificationSystemDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AssessmentIdentificationSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentItem table of the AssessmentItem aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentItemRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int? AssessmentItemCategoryDescriptorId { get; set; }
        string AssessmentItemURI { get; set; }
        string CorrectResponse { get; set; }
        string ExpectedTimeAssessed { get; set; }
        Guid Id { get; set; }
        string IdentificationCode { get; set; }
        string ItemText { get; set; }
        decimal? MaxRawScore { get; set; }
        string Namespace { get; set; }
        string Nomenclature { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentItemCategoryDescriptor table of the AssessmentItemCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentItemCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AssessmentItemCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentItemLearningStandard table of the AssessmentItem aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentItemLearningStandardRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string IdentificationCode { get; set; }
        string LearningStandardId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentItemPossibleResponse table of the AssessmentItem aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentItemPossibleResponseRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        bool? CorrectResponse { get; set; }
        string IdentificationCode { get; set; }
        string Namespace { get; set; }
        string ResponseDescription { get; set; }
        string ResponseValue { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentItemResultDescriptor table of the AssessmentItemResultDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentItemResultDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AssessmentItemResultDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentLanguage table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentLanguageRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int LanguageDescriptorId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentPerformanceLevel table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string Namespace { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentPeriod table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentPeriodRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentPeriodDescriptorId { get; set; }
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentPeriodDescriptor table of the AssessmentPeriodDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentPeriodDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AssessmentPeriodDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentPlatformType table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentPlatformTypeRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string Namespace { get; set; }
        int PlatformTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentProgram table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentProgramRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        string Namespace { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentReportingMethodDescriptor table of the AssessmentReportingMethodDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentReportingMethodDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AssessmentReportingMethodDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentScore table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentScoreRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string Namespace { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AssessmentSection table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentSectionRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string LocalCourseCode { get; set; }
        string Namespace { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AttemptStatusDescriptor table of the AttemptStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAttemptStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AttemptStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.AttendanceEventCategoryDescriptor table of the AttendanceEventCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAttendanceEventCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AttendanceEventCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.BehaviorDescriptor table of the BehaviorDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IBehaviorDescriptorRecord
    {     
        // Properties for all columns in physical table
        int BehaviorDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.BellSchedule table of the BellSchedule aggregate in the Ods Database.
    /// </summary>
    public interface IBellScheduleRecord
    {     
        // Properties for all columns in physical table
        string AlternateDayName { get; set; }
        string BellScheduleName { get; set; }
        TimeSpan? EndTime { get; set; }
        Guid Id { get; set; }
        int SchoolId { get; set; }
        TimeSpan? StartTime { get; set; }
        int? TotalInstructionalTime { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.BellScheduleClassPeriod table of the BellSchedule aggregate in the Ods Database.
    /// </summary>
    public interface IBellScheduleClassPeriodRecord
    {     
        // Properties for all columns in physical table
        string BellScheduleName { get; set; }
        string ClassPeriodName { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.BellScheduleDate table of the BellSchedule aggregate in the Ods Database.
    /// </summary>
    public interface IBellScheduleDateRecord
    {     
        // Properties for all columns in physical table
        string BellScheduleName { get; set; }
        DateTime Date { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.BellScheduleGradeLevel table of the BellSchedule aggregate in the Ods Database.
    /// </summary>
    public interface IBellScheduleGradeLevelRecord
    {     
        // Properties for all columns in physical table
        string BellScheduleName { get; set; }
        int GradeLevelDescriptorId { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Budget table of the Budget aggregate in the Ods Database.
    /// </summary>
    public interface IBudgetRecord
    {     
        // Properties for all columns in physical table
        string AccountIdentifier { get; set; }
        decimal Amount { get; set; }
        DateTime AsOfDate { get; set; }
        int EducationOrganizationId { get; set; }
        int FiscalYear { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Calendar table of the Calendar aggregate in the Ods Database.
    /// </summary>
    public interface ICalendarRecord
    {     
        // Properties for all columns in physical table
        string CalendarCode { get; set; }
        int CalendarTypeDescriptorId { get; set; }
        Guid Id { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CalendarDate table of the CalendarDate aggregate in the Ods Database.
    /// </summary>
    public interface ICalendarDateRecord
    {     
        // Properties for all columns in physical table
        string CalendarCode { get; set; }
        DateTime Date { get; set; }
        Guid Id { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CalendarDateCalendarEvent table of the CalendarDate aggregate in the Ods Database.
    /// </summary>
    public interface ICalendarDateCalendarEventRecord
    {     
        // Properties for all columns in physical table
        string CalendarCode { get; set; }
        int CalendarEventDescriptorId { get; set; }
        DateTime Date { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CalendarEventDescriptor table of the CalendarEventDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICalendarEventDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CalendarEventDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CalendarGradeLevel table of the Calendar aggregate in the Ods Database.
    /// </summary>
    public interface ICalendarGradeLevelRecord
    {     
        // Properties for all columns in physical table
        string CalendarCode { get; set; }
        int GradeLevelDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CalendarTypeDescriptor table of the CalendarTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICalendarTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CalendarTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CareerPathwayDescriptor table of the CareerPathwayDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICareerPathwayDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CareerPathwayDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CharterApprovalAgencyTypeDescriptor table of the CharterApprovalAgencyTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICharterApprovalAgencyTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CharterApprovalAgencyTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CharterStatusDescriptor table of the CharterStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICharterStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CharterStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CitizenshipStatusDescriptor table of the CitizenshipStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICitizenshipStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CitizenshipStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ClassPeriod table of the ClassPeriod aggregate in the Ods Database.
    /// </summary>
    public interface IClassPeriodRecord
    {     
        // Properties for all columns in physical table
        string ClassPeriodName { get; set; }
        Guid Id { get; set; }
        bool? OfficialAttendancePeriod { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ClassPeriodMeetingTime table of the ClassPeriod aggregate in the Ods Database.
    /// </summary>
    public interface IClassPeriodMeetingTimeRecord
    {     
        // Properties for all columns in physical table
        string ClassPeriodName { get; set; }
        TimeSpan EndTime { get; set; }
        int SchoolId { get; set; }
        TimeSpan StartTime { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ClassroomPositionDescriptor table of the ClassroomPositionDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IClassroomPositionDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ClassroomPositionDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Cohort table of the Cohort aggregate in the Ods Database.
    /// </summary>
    public interface ICohortRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        string CohortDescription { get; set; }
        string CohortIdentifier { get; set; }
        int? CohortScopeDescriptorId { get; set; }
        int CohortTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CohortProgram table of the Cohort aggregate in the Ods Database.
    /// </summary>
    public interface ICohortProgramRecord
    {     
        // Properties for all columns in physical table
        string CohortIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CohortScopeDescriptor table of the CohortScopeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICohortScopeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CohortScopeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CohortTypeDescriptor table of the CohortTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICohortTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CohortTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CohortYearTypeDescriptor table of the CohortYearTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICohortYearTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CohortYearTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CommunityOrganization table of the CommunityOrganization aggregate in the Ods Database.
    /// </summary>
    public interface ICommunityOrganizationRecord
    {     
        // Properties for all columns in physical table
        int CommunityOrganizationId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CommunityProvider table of the CommunityProvider aggregate in the Ods Database.
    /// </summary>
    public interface ICommunityProviderRecord
    {     
        // Properties for all columns in physical table
        int? CommunityOrganizationId { get; set; }
        int CommunityProviderId { get; set; }
        bool? LicenseExemptIndicator { get; set; }
        int ProviderCategoryDescriptorId { get; set; }
        int? ProviderProfitabilityDescriptorId { get; set; }
        int ProviderStatusDescriptorId { get; set; }
        bool? SchoolIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CommunityProviderLicense table of the CommunityProviderLicense aggregate in the Ods Database.
    /// </summary>
    public interface ICommunityProviderLicenseRecord
    {     
        // Properties for all columns in physical table
        int? AuthorizedFacilityCapacity { get; set; }
        int CommunityProviderId { get; set; }
        Guid Id { get; set; }
        DateTime LicenseEffectiveDate { get; set; }
        DateTime? LicenseExpirationDate { get; set; }
        string LicenseIdentifier { get; set; }
        DateTime? LicenseIssueDate { get; set; }
        int? LicenseStatusDescriptorId { get; set; }
        int LicenseTypeDescriptorId { get; set; }
        string LicensingOrganization { get; set; }
        int? OldestAgeAuthorizedToServe { get; set; }
        int? YoungestAgeAuthorizedToServe { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CompetencyLevelDescriptor table of the CompetencyLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICompetencyLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CompetencyLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CompetencyObjective table of the CompetencyObjective aggregate in the Ods Database.
    /// </summary>
    public interface ICompetencyObjectiveRecord
    {     
        // Properties for all columns in physical table
        string CompetencyObjectiveId { get; set; }
        string Description { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string Objective { get; set; }
        int ObjectiveGradeLevelDescriptorId { get; set; }
        string SuccessCriteria { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ContactTypeDescriptor table of the ContactTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IContactTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ContactTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ContentClassDescriptor table of the ContentClassDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IContentClassDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ContentClassDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ContinuationOfServicesReasonDescriptor table of the ContinuationOfServicesReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IContinuationOfServicesReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ContinuationOfServicesReasonDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ContractedStaff table of the ContractedStaff aggregate in the Ods Database.
    /// </summary>
    public interface IContractedStaffRecord
    {     
        // Properties for all columns in physical table
        string AccountIdentifier { get; set; }
        decimal AmountToDate { get; set; }
        DateTime AsOfDate { get; set; }
        int EducationOrganizationId { get; set; }
        int FiscalYear { get; set; }
        Guid Id { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CostRateDescriptor table of the CostRateDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICostRateDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CostRateDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CountryDescriptor table of the CountryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICountryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CountryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Course table of the Course aggregate in the Ods Database.
    /// </summary>
    public interface ICourseRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        int? CareerPathwayDescriptorId { get; set; }
        string CourseCode { get; set; }
        int? CourseDefinedByDescriptorId { get; set; }
        string CourseDescription { get; set; }
        int? CourseGPAApplicabilityDescriptorId { get; set; }
        string CourseTitle { get; set; }
        DateTime? DateCourseAdopted { get; set; }
        int EducationOrganizationId { get; set; }
        bool? HighSchoolCourseRequirement { get; set; }
        Guid Id { get; set; }
        int? MaxCompletionsForCredit { get; set; }
        decimal? MaximumAvailableCreditConversion { get; set; }
        decimal? MaximumAvailableCredits { get; set; }
        int? MaximumAvailableCreditTypeDescriptorId { get; set; }
        decimal? MinimumAvailableCreditConversion { get; set; }
        decimal? MinimumAvailableCredits { get; set; }
        int? MinimumAvailableCreditTypeDescriptorId { get; set; }
        int NumberOfParts { get; set; }
        int? TimeRequiredForCompletion { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseAttemptResultDescriptor table of the CourseAttemptResultDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICourseAttemptResultDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CourseAttemptResultDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseCompetencyLevel table of the Course aggregate in the Ods Database.
    /// </summary>
    public interface ICourseCompetencyLevelRecord
    {     
        // Properties for all columns in physical table
        int CompetencyLevelDescriptorId { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseDefinedByDescriptor table of the CourseDefinedByDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICourseDefinedByDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CourseDefinedByDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseGPAApplicabilityDescriptor table of the CourseGPAApplicabilityDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICourseGPAApplicabilityDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CourseGPAApplicabilityDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseIdentificationCode table of the Course aggregate in the Ods Database.
    /// </summary>
    public interface ICourseIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string AssigningOrganizationIdentificationCode { get; set; }
        string CourseCatalogURL { get; set; }
        string CourseCode { get; set; }
        int CourseIdentificationSystemDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string IdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseIdentificationSystemDescriptor table of the CourseIdentificationSystemDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICourseIdentificationSystemDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CourseIdentificationSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseLearningObjective table of the Course aggregate in the Ods Database.
    /// </summary>
    public interface ICourseLearningObjectiveRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseLearningStandard table of the Course aggregate in the Ods Database.
    /// </summary>
    public interface ICourseLearningStandardRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        string LearningStandardId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseLevelCharacteristic table of the Course aggregate in the Ods Database.
    /// </summary>
    public interface ICourseLevelCharacteristicRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int CourseLevelCharacteristicDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseLevelCharacteristicDescriptor table of the CourseLevelCharacteristicDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICourseLevelCharacteristicDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CourseLevelCharacteristicDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseOfferedGradeLevel table of the Course aggregate in the Ods Database.
    /// </summary>
    public interface ICourseOfferedGradeLevelRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseOffering table of the CourseOffering aggregate in the Ods Database.
    /// </summary>
    public interface ICourseOfferingRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        int? InstructionalTimePlanned { get; set; }
        string LocalCourseCode { get; set; }
        string LocalCourseTitle { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseOfferingCourseLevelCharacteristic table of the CourseOffering aggregate in the Ods Database.
    /// </summary>
    public interface ICourseOfferingCourseLevelCharacteristicRecord
    {     
        // Properties for all columns in physical table
        int CourseLevelCharacteristicDescriptorId { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseOfferingCurriculumUsed table of the CourseOffering aggregate in the Ods Database.
    /// </summary>
    public interface ICourseOfferingCurriculumUsedRecord
    {     
        // Properties for all columns in physical table
        int CurriculumUsedDescriptorId { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseOfferingOfferedGradeLevel table of the CourseOffering aggregate in the Ods Database.
    /// </summary>
    public interface ICourseOfferingOfferedGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseRepeatCodeDescriptor table of the CourseRepeatCodeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICourseRepeatCodeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CourseRepeatCodeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseTranscript table of the CourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface ICourseTranscriptRecord
    {     
        // Properties for all columns in physical table
        string AlternativeCourseCode { get; set; }
        string AlternativeCourseTitle { get; set; }
        string AssigningOrganizationIdentificationCode { get; set; }
        decimal? AttemptedCreditConversion { get; set; }
        decimal? AttemptedCredits { get; set; }
        int? AttemptedCreditTypeDescriptorId { get; set; }
        int CourseAttemptResultDescriptorId { get; set; }
        string CourseCatalogURL { get; set; }
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        int? CourseRepeatCodeDescriptorId { get; set; }
        string CourseTitle { get; set; }
        decimal? EarnedCreditConversion { get; set; }
        decimal EarnedCredits { get; set; }
        int? EarnedCreditTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int? ExternalEducationOrganizationId { get; set; }
        string FinalLetterGradeEarned { get; set; }
        decimal? FinalNumericGradeEarned { get; set; }
        Guid Id { get; set; }
        int? MethodCreditEarnedDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
        int? WhenTakenGradeLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseTranscriptAcademicSubject table of the CourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface ICourseTranscriptAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int CourseAttemptResultDescriptorId { get; set; }
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        int EducationOrganizationId { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseTranscriptAlternativeCourseIdentificationCode table of the CourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface ICourseTranscriptAlternativeCourseIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string AssigningOrganizationIdentificationCode { get; set; }
        int CourseAttemptResultDescriptorId { get; set; }
        string CourseCatalogURL { get; set; }
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        int CourseIdentificationSystemDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string IdentificationCode { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseTranscriptCreditCategory table of the CourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface ICourseTranscriptCreditCategoryRecord
    {     
        // Properties for all columns in physical table
        int CourseAttemptResultDescriptorId { get; set; }
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        int CreditCategoryDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CourseTranscriptEarnedAdditionalCredits table of the CourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface ICourseTranscriptEarnedAdditionalCreditsRecord
    {     
        // Properties for all columns in physical table
        int AdditionalCreditTypeDescriptorId { get; set; }
        int CourseAttemptResultDescriptorId { get; set; }
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        decimal Credits { get; set; }
        int EducationOrganizationId { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Credential table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialRecord
    {     
        // Properties for all columns in physical table
        int CredentialFieldDescriptorId { get; set; }
        string CredentialIdentifier { get; set; }
        int CredentialTypeDescriptorId { get; set; }
        DateTime? EffectiveDate { get; set; }
        DateTime? ExpirationDate { get; set; }
        Guid Id { get; set; }
        DateTime IssuanceDate { get; set; }
        string Namespace { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
        int? TeachingCredentialBasisDescriptorId { get; set; }
        int TeachingCredentialDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CredentialAcademicSubject table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        string CredentialIdentifier { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CredentialEndorsement table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialEndorsementRecord
    {     
        // Properties for all columns in physical table
        string CredentialEndorsementX { get; set; }
        string CredentialIdentifier { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CredentialFieldDescriptor table of the CredentialFieldDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialFieldDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CredentialFieldDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CredentialGradeLevel table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialGradeLevelRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        int GradeLevelDescriptorId { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CredentialTypeDescriptor table of the CredentialTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CredentialTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CreditCategoryDescriptor table of the CreditCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICreditCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CreditCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CreditTypeDescriptor table of the CreditTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICreditTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CreditTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CTEProgramServiceDescriptor table of the CTEProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICTEProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CTEProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.CurriculumUsedDescriptor table of the CurriculumUsedDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICurriculumUsedDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CurriculumUsedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DeliveryMethodDescriptor table of the DeliveryMethodDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDeliveryMethodDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DeliveryMethodDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Descriptor table of the Descriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDescriptorRecord
    {     
        // Properties for all columns in physical table
        string CodeValue { get; set; }
        string Description { get; set; }
        int DescriptorId { get; set; }
        DateTime? EffectiveBeginDate { get; set; }
        DateTime? EffectiveEndDate { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        int? PriorDescriptorId { get; set; }
        string ShortDescription { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DiagnosisDescriptor table of the DiagnosisDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDiagnosisDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DiagnosisDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DiplomaLevelDescriptor table of the DiplomaLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDiplomaLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DiplomaLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DiplomaTypeDescriptor table of the DiplomaTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDiplomaTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DiplomaTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisabilityDescriptor table of the DisabilityDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDisabilityDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisabilityDesignationDescriptor table of the DisabilityDesignationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDisabilityDesignationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDesignationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisabilityDeterminationSourceTypeDescriptor table of the DisabilityDeterminationSourceTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDisabilityDeterminationSourceTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDeterminationSourceTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineAction table of the DisciplineAction aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineActionRecord
    {     
        // Properties for all columns in physical table
        decimal? ActualDisciplineActionLength { get; set; }
        int? AssignmentSchoolId { get; set; }
        string DisciplineActionIdentifier { get; set; }
        decimal? DisciplineActionLength { get; set; }
        int? DisciplineActionLengthDifferenceReasonDescriptorId { get; set; }
        DateTime DisciplineDate { get; set; }
        Guid Id { get; set; }
        bool? IEPPlacementMeetingIndicator { get; set; }
        bool? ReceivedEducationServicesDuringExpulsion { get; set; }
        bool? RelatedToZeroTolerancePolicy { get; set; }
        int ResponsibilitySchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineActionDiscipline table of the DisciplineAction aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineActionDisciplineRecord
    {     
        // Properties for all columns in physical table
        string DisciplineActionIdentifier { get; set; }
        DateTime DisciplineDate { get; set; }
        int DisciplineDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineActionLengthDifferenceReasonDescriptor table of the DisciplineActionLengthDifferenceReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineActionLengthDifferenceReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DisciplineActionLengthDifferenceReasonDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineActionStaff table of the DisciplineAction aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineActionStaffRecord
    {     
        // Properties for all columns in physical table
        string DisciplineActionIdentifier { get; set; }
        DateTime DisciplineDate { get; set; }
        int StaffUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineActionStudentDisciplineIncidentAssociation table of the DisciplineAction aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineActionStudentDisciplineIncidentAssociationRecord
    {     
        // Properties for all columns in physical table
        string DisciplineActionIdentifier { get; set; }
        DateTime DisciplineDate { get; set; }
        string IncidentIdentifier { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineDescriptor table of the DisciplineDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DisciplineDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineIncident table of the DisciplineIncident aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineIncidentRecord
    {     
        // Properties for all columns in physical table
        string CaseNumber { get; set; }
        Guid Id { get; set; }
        decimal? IncidentCost { get; set; }
        DateTime IncidentDate { get; set; }
        string IncidentDescription { get; set; }
        string IncidentIdentifier { get; set; }
        int? IncidentLocationDescriptorId { get; set; }
        TimeSpan? IncidentTime { get; set; }
        bool? ReportedToLawEnforcement { get; set; }
        int? ReporterDescriptionDescriptorId { get; set; }
        string ReporterName { get; set; }
        int SchoolId { get; set; }
        int? StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineIncidentBehavior table of the DisciplineIncident aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineIncidentBehaviorRecord
    {     
        // Properties for all columns in physical table
        int BehaviorDescriptorId { get; set; }
        string BehaviorDetailedDescription { get; set; }
        string IncidentIdentifier { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineIncidentExternalParticipant table of the DisciplineIncident aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineIncidentExternalParticipantRecord
    {     
        // Properties for all columns in physical table
        int DisciplineIncidentParticipationCodeDescriptorId { get; set; }
        string FirstName { get; set; }
        string IncidentIdentifier { get; set; }
        string LastSurname { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineIncidentParticipationCodeDescriptor table of the DisciplineIncidentParticipationCodeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineIncidentParticipationCodeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DisciplineIncidentParticipationCodeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.DisciplineIncidentWeapon table of the DisciplineIncident aggregate in the Ods Database.
    /// </summary>
    public interface IDisciplineIncidentWeaponRecord
    {     
        // Properties for all columns in physical table
        string IncidentIdentifier { get; set; }
        int SchoolId { get; set; }
        int WeaponDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationalEnvironmentDescriptor table of the EducationalEnvironmentDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEducationalEnvironmentDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EducationalEnvironmentDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationContent table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentRecord
    {     
        // Properties for all columns in physical table
        bool? AdditionalAuthorsIndicator { get; set; }
        int? ContentClassDescriptorId { get; set; }
        string ContentIdentifier { get; set; }
        decimal? Cost { get; set; }
        int? CostRateDescriptorId { get; set; }
        string Description { get; set; }
        Guid Id { get; set; }
        int? InteractivityStyleDescriptorId { get; set; }
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
    }

    /// <summary>
    /// Interface for the edfi.EducationContentAppropriateGradeLevel table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentAppropriateGradeLevelRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        int GradeLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationContentAppropriateSex table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentAppropriateSexRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        int SexDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationContentAuthor table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentAuthorRecord
    {     
        // Properties for all columns in physical table
        string Author { get; set; }
        string ContentIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationContentDerivativeSourceEducationContent table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentDerivativeSourceEducationContentRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        string DerivativeSourceContentIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationContentDerivativeSourceLearningResourceMetadataURI table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentDerivativeSourceLearningResourceMetadataURIRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        string DerivativeSourceLearningResourceMetadataURI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationContentDerivativeSourceURI table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentDerivativeSourceURIRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        string DerivativeSourceURI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationContentLanguage table of the EducationContent aggregate in the Ods Database.
    /// </summary>
    public interface IEducationContentLanguageRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        int LanguageDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganization table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string NameOfInstitution { get; set; }
        int? OperationalStatusDescriptorId { get; set; }
        string ShortNameOfInstitution { get; set; }
        string WebSite { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationAddress table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationAddressRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        string Latitude { get; set; }
        int? LocaleDescriptorId { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationAddressPeriod table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        string City { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationCategory table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationCategoryRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationCategoryDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationCategoryDescriptor table of the EducationOrganizationCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationIdentificationCode table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EducationOrganizationIdentificationSystemDescriptorId { get; set; }
        string IdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationIdentificationSystemDescriptor table of the EducationOrganizationIdentificationSystemDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationIdentificationSystemDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationIdentificationSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationIndicator table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationIndicatorRecord
    {     
        // Properties for all columns in physical table
        string DesignatedBy { get; set; }
        int EducationOrganizationId { get; set; }
        int IndicatorDescriptorId { get; set; }
        int? IndicatorGroupDescriptorId { get; set; }
        int? IndicatorLevelDescriptorId { get; set; }
        string IndicatorValue { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationIndicatorPeriod table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationIndicatorPeriodRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        int IndicatorDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationInstitutionTelephone table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationInstitutionTelephoneRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int InstitutionTelephoneNumberTypeDescriptorId { get; set; }
        string TelephoneNumber { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationInternationalAddress table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationInternationalAddressRecord
    {     
        // Properties for all columns in physical table
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string AddressLine4 { get; set; }
        int AddressTypeDescriptorId { get; set; }
        DateTime? BeginDate { get; set; }
        int CountryDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationInterventionPrescriptionAssociation table of the EducationOrganizationInterventionPrescriptionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationInterventionPrescriptionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int InterventionPrescriptionEducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationNetwork table of the EducationOrganizationNetwork aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationNetworkRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationNetworkId { get; set; }
        int NetworkPurposeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationNetworkAssociation table of the EducationOrganizationNetworkAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationNetworkAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        int EducationOrganizationNetworkId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int MemberEducationOrganizationId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationOrganizationPeerAssociation table of the EducationOrganizationPeerAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationPeerAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        int PeerEducationOrganizationId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationPlanDescriptor table of the EducationPlanDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEducationPlanDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EducationPlanDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EducationServiceCenter table of the EducationServiceCenter aggregate in the Ods Database.
    /// </summary>
    public interface IEducationServiceCenterRecord
    {     
        // Properties for all columns in physical table
        int EducationServiceCenterId { get; set; }
        int? StateEducationAgencyId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ElectronicMailTypeDescriptor table of the ElectronicMailTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IElectronicMailTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ElectronicMailTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EmploymentStatusDescriptor table of the EmploymentStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEmploymentStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EmploymentStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EntryGradeLevelReasonDescriptor table of the EntryGradeLevelReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEntryGradeLevelReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EntryGradeLevelReasonDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EntryTypeDescriptor table of the EntryTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEntryTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EntryTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.EventCircumstanceDescriptor table of the EventCircumstanceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEventCircumstanceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EventCircumstanceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ExitWithdrawTypeDescriptor table of the ExitWithdrawTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IExitWithdrawTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ExitWithdrawTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.FeederSchoolAssociation table of the FeederSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IFeederSchoolAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string FeederRelationshipDescription { get; set; }
        int FeederSchoolId { get; set; }
        Guid Id { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GeneralStudentProgramAssociation table of the GeneralStudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IGeneralStudentProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int? ReasonExitedDescriptorId { get; set; }
        bool? ServedOutsideOfRegularSession { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GeneralStudentProgramAssociationParticipationStatus table of the GeneralStudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IGeneralStudentProgramAssociationParticipationStatusRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string DesignatedBy { get; set; }
        int EducationOrganizationId { get; set; }
        int ParticipationStatusDescriptorId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? StatusBeginDate { get; set; }
        DateTime? StatusEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Grade table of the Grade aggregate in the Ods Database.
    /// </summary>
    public interface IGradeRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string DiagnosticStatement { get; set; }
        int GradeTypeDescriptorId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        Guid Id { get; set; }
        string LetterGradeEarned { get; set; }
        string LocalCourseCode { get; set; }
        decimal? NumericGradeEarned { get; set; }
        int? PerformanceBaseConversionDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradebookEntry table of the GradebookEntry aggregate in the Ods Database.
    /// </summary>
    public interface IGradebookEntryRecord
    {     
        // Properties for all columns in physical table
        DateTime DateAssigned { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        string GradebookEntryTitle { get; set; }
        int? GradebookEntryTypeDescriptorId { get; set; }
        int? GradingPeriodDescriptorId { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int? PeriodSequence { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradebookEntryLearningObjective table of the GradebookEntry aggregate in the Ods Database.
    /// </summary>
    public interface IGradebookEntryLearningObjectiveRecord
    {     
        // Properties for all columns in physical table
        DateTime DateAssigned { get; set; }
        string GradebookEntryTitle { get; set; }
        string LearningObjectiveId { get; set; }
        string LocalCourseCode { get; set; }
        string Namespace { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradebookEntryLearningStandard table of the GradebookEntry aggregate in the Ods Database.
    /// </summary>
    public interface IGradebookEntryLearningStandardRecord
    {     
        // Properties for all columns in physical table
        DateTime DateAssigned { get; set; }
        string GradebookEntryTitle { get; set; }
        string LearningStandardId { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradebookEntryTypeDescriptor table of the GradebookEntryTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGradebookEntryTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GradebookEntryTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradeLearningStandardGrade table of the Grade aggregate in the Ods Database.
    /// </summary>
    public interface IGradeLearningStandardGradeRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string DiagnosticStatement { get; set; }
        int GradeTypeDescriptorId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string LearningStandardId { get; set; }
        string LetterGradeEarned { get; set; }
        string LocalCourseCode { get; set; }
        decimal? NumericGradeEarned { get; set; }
        int? PerformanceBaseConversionDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradeLevelDescriptor table of the GradeLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGradeLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradePointAverageTypeDescriptor table of the GradePointAverageTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGradePointAverageTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GradePointAverageTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradeTypeDescriptor table of the GradeTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGradeTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GradeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradingPeriod table of the GradingPeriod aggregate in the Ods Database.
    /// </summary>
    public interface IGradingPeriodRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        Guid Id { get; set; }
        int PeriodSequence { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        int TotalInstructionalDays { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GradingPeriodDescriptor table of the GradingPeriodDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGradingPeriodDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GradingPeriodDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlan table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        Guid Id { get; set; }
        bool? IndividualPlan { get; set; }
        decimal? TotalRequiredCreditConversion { get; set; }
        decimal TotalRequiredCredits { get; set; }
        int? TotalRequiredCreditTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanCreditsByCourse table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanCreditsByCourseRecord
    {     
        // Properties for all columns in physical table
        string CourseSetName { get; set; }
        decimal? CreditConversion { get; set; }
        decimal Credits { get; set; }
        int? CreditTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        int? WhenTakenGradeLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanCreditsByCourseCourse table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanCreditsByCourseCourseRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        string CourseSetName { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanCreditsByCreditCategory table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanCreditsByCreditCategoryRecord
    {     
        // Properties for all columns in physical table
        int CreditCategoryDescriptorId { get; set; }
        decimal? CreditConversion { get; set; }
        decimal Credits { get; set; }
        int? CreditTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanCreditsBySubject table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanCreditsBySubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        decimal? CreditConversion { get; set; }
        decimal Credits { get; set; }
        int? CreditTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanRequiredAssessment table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanRequiredAssessmentRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanRequiredAssessmentPerformanceLevel table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanRequiredAssessmentPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string Namespace { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanRequiredAssessmentScore table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanRequiredAssessmentScoreRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string Namespace { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GraduationPlanTypeDescriptor table of the GraduationPlanTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GraduationPlanTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.GunFreeSchoolsActReportingStatusDescriptor table of the GunFreeSchoolsActReportingStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGunFreeSchoolsActReportingStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GunFreeSchoolsActReportingStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.HomelessPrimaryNighttimeResidenceDescriptor table of the HomelessPrimaryNighttimeResidenceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IHomelessPrimaryNighttimeResidenceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int HomelessPrimaryNighttimeResidenceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.HomelessProgramServiceDescriptor table of the HomelessProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IHomelessProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int HomelessProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.IdentificationDocumentUseDescriptor table of the IdentificationDocumentUseDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IIdentificationDocumentUseDescriptorRecord
    {     
        // Properties for all columns in physical table
        int IdentificationDocumentUseDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.IncidentLocationDescriptor table of the IncidentLocationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IIncidentLocationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int IncidentLocationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.IndicatorDescriptor table of the IndicatorDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IIndicatorDescriptorRecord
    {     
        // Properties for all columns in physical table
        int IndicatorDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.IndicatorGroupDescriptor table of the IndicatorGroupDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IIndicatorGroupDescriptorRecord
    {     
        // Properties for all columns in physical table
        int IndicatorGroupDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.IndicatorLevelDescriptor table of the IndicatorLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IIndicatorLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int IndicatorLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InstitutionTelephoneNumberTypeDescriptor table of the InstitutionTelephoneNumberTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IInstitutionTelephoneNumberTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int InstitutionTelephoneNumberTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InteractivityStyleDescriptor table of the InteractivityStyleDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IInteractivityStyleDescriptorRecord
    {     
        // Properties for all columns in physical table
        int InteractivityStyleDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InternetAccessDescriptor table of the InternetAccessDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IInternetAccessDescriptorRecord
    {     
        // Properties for all columns in physical table
        int InternetAccessDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Intervention table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int DeliveryMethodDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int InterventionClassDescriptorId { get; set; }
        string InterventionIdentificationCode { get; set; }
        int? MaxDosage { get; set; }
        int? MinDosage { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionAppropriateGradeLevel table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionAppropriateGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string InterventionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionAppropriateSex table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionAppropriateSexRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
        int SexDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionClassDescriptor table of the InterventionClassDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionClassDescriptorRecord
    {     
        // Properties for all columns in physical table
        int InterventionClassDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionDiagnosis table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionDiagnosisRecord
    {     
        // Properties for all columns in physical table
        int DiagnosisDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionEducationContent table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionEducationContentRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionEffectivenessRatingDescriptor table of the InterventionEffectivenessRatingDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionEffectivenessRatingDescriptorRecord
    {     
        // Properties for all columns in physical table
        int InterventionEffectivenessRatingDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionInterventionPrescription table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionInterventionPrescriptionRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
        int InterventionPrescriptionEducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionLearningResourceMetadataURI table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionLearningResourceMetadataURIRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
        string LearningResourceMetadataURI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionMeetingTime table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionMeetingTimeRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        TimeSpan EndTime { get; set; }
        string InterventionIdentificationCode { get; set; }
        TimeSpan StartTime { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPopulationServed table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPopulationServedRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
        int PopulationServedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescription table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionRecord
    {     
        // Properties for all columns in physical table
        int DeliveryMethodDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        int InterventionClassDescriptorId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
        int? MaxDosage { get; set; }
        int? MinDosage { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescriptionAppropriateGradeLevel table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionAppropriateGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescriptionAppropriateSex table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionAppropriateSexRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
        int SexDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescriptionDiagnosis table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionDiagnosisRecord
    {     
        // Properties for all columns in physical table
        int DiagnosisDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescriptionEducationContent table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionEducationContentRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescriptionLearningResourceMetadataURI table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionLearningResourceMetadataURIRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
        string LearningResourceMetadataURI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescriptionPopulationServed table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionPopulationServedRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
        int PopulationServedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionPrescriptionURI table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionPrescriptionURIRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
        string URI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStaff table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStaffRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudy table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyRecord
    {     
        // Properties for all columns in physical table
        int DeliveryMethodDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        int InterventionClassDescriptorId { get; set; }
        int InterventionPrescriptionEducationOrganizationId { get; set; }
        string InterventionPrescriptionIdentificationCode { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int Participants { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyAppropriateGradeLevel table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyAppropriateGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyAppropriateSex table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyAppropriateSexRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int SexDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyEducationContent table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyEducationContentRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyInterventionEffectiveness table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyInterventionEffectivenessRecord
    {     
        // Properties for all columns in physical table
        int DiagnosisDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        int? ImprovementIndex { get; set; }
        int InterventionEffectivenessRatingDescriptorId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int PopulationServedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyLearningResourceMetadataURI table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyLearningResourceMetadataURIRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        string LearningResourceMetadataURI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyPopulationServed table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyPopulationServedRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int PopulationServedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyStateAbbreviation table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyStateAbbreviationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionStudyURI table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionStudyURIRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        string URI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.InterventionURI table of the Intervention aggregate in the Ods Database.
    /// </summary>
    public interface IInterventionURIRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string InterventionIdentificationCode { get; set; }
        string URI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LanguageDescriptor table of the LanguageDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILanguageDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LanguageDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LanguageInstructionProgramServiceDescriptor table of the LanguageInstructionProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILanguageInstructionProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LanguageInstructionProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LanguageUseDescriptor table of the LanguageUseDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILanguageUseDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LanguageUseDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningObjective table of the LearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface ILearningObjectiveRecord
    {     
        // Properties for all columns in physical table
        string Description { get; set; }
        Guid Id { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
        string Nomenclature { get; set; }
        string Objective { get; set; }
        string ParentLearningObjectiveId { get; set; }
        string ParentNamespace { get; set; }
        string SuccessCriteria { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningObjectiveAcademicSubject table of the LearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface ILearningObjectiveAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningObjectiveContentStandard table of the LearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface ILearningObjectiveContentStandardRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string LearningObjectiveId { get; set; }
        int? MandatingEducationOrganizationId { get; set; }
        string Namespace { get; set; }
        DateTime? PublicationDate { get; set; }
        int? PublicationStatusDescriptorId { get; set; }
        short? PublicationYear { get; set; }
        string Title { get; set; }
        string URI { get; set; }
        string Version { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningObjectiveContentStandardAuthor table of the LearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface ILearningObjectiveContentStandardAuthorRecord
    {     
        // Properties for all columns in physical table
        string Author { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningObjectiveGradeLevel table of the LearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface ILearningObjectiveGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningObjectiveLearningStandard table of the LearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface ILearningObjectiveLearningStandardRecord
    {     
        // Properties for all columns in physical table
        string LearningObjectiveId { get; set; }
        string LearningStandardId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandard table of the LearningStandard aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardRecord
    {     
        // Properties for all columns in physical table
        string CourseTitle { get; set; }
        string Description { get; set; }
        Guid Id { get; set; }
        int? LearningStandardCategoryDescriptorId { get; set; }
        string LearningStandardId { get; set; }
        string LearningStandardItemCode { get; set; }
        int? LearningStandardScopeDescriptorId { get; set; }
        string Namespace { get; set; }
        string ParentLearningStandardId { get; set; }
        string SuccessCriteria { get; set; }
        string URI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardAcademicSubject table of the LearningStandard aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        string LearningStandardId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardCategoryDescriptor table of the LearningStandardCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LearningStandardCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardContentStandard table of the LearningStandard aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardContentStandardRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string LearningStandardId { get; set; }
        int? MandatingEducationOrganizationId { get; set; }
        DateTime? PublicationDate { get; set; }
        int? PublicationStatusDescriptorId { get; set; }
        short? PublicationYear { get; set; }
        string Title { get; set; }
        string URI { get; set; }
        string Version { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardContentStandardAuthor table of the LearningStandard aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardContentStandardAuthorRecord
    {     
        // Properties for all columns in physical table
        string Author { get; set; }
        string LearningStandardId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardEquivalenceAssociation table of the LearningStandardEquivalenceAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardEquivalenceAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? EffectiveDate { get; set; }
        Guid Id { get; set; }
        string LearningStandardEquivalenceStrengthDescription { get; set; }
        int? LearningStandardEquivalenceStrengthDescriptorId { get; set; }
        string Namespace { get; set; }
        string SourceLearningStandardId { get; set; }
        string TargetLearningStandardId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardEquivalenceStrengthDescriptor table of the LearningStandardEquivalenceStrengthDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardEquivalenceStrengthDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LearningStandardEquivalenceStrengthDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardGradeLevel table of the LearningStandard aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        string LearningStandardId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardIdentificationCode table of the LearningStandard aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string ContentStandardName { get; set; }
        string IdentificationCode { get; set; }
        string LearningStandardId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardPrerequisiteLearningStandard table of the LearningStandard aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardPrerequisiteLearningStandardRecord
    {     
        // Properties for all columns in physical table
        string LearningStandardId { get; set; }
        string PrerequisiteLearningStandardId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LearningStandardScopeDescriptor table of the LearningStandardScopeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILearningStandardScopeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LearningStandardScopeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LevelOfEducationDescriptor table of the LevelOfEducationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILevelOfEducationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LevelOfEducationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LicenseStatusDescriptor table of the LicenseStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILicenseStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LicenseStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LicenseTypeDescriptor table of the LicenseTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILicenseTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LicenseTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LimitedEnglishProficiencyDescriptor table of the LimitedEnglishProficiencyDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILimitedEnglishProficiencyDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LimitedEnglishProficiencyDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LocaleDescriptor table of the LocaleDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILocaleDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LocaleDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LocalEducationAgency table of the LocalEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface ILocalEducationAgencyRecord
    {     
        // Properties for all columns in physical table
        int? CharterStatusDescriptorId { get; set; }
        int? EducationServiceCenterId { get; set; }
        int LocalEducationAgencyCategoryDescriptorId { get; set; }
        int LocalEducationAgencyId { get; set; }
        int? ParentLocalEducationAgencyId { get; set; }
        int? StateEducationAgencyId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LocalEducationAgencyAccountability table of the LocalEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface ILocalEducationAgencyAccountabilityRecord
    {     
        // Properties for all columns in physical table
        int? GunFreeSchoolsActReportingStatusDescriptorId { get; set; }
        int LocalEducationAgencyId { get; set; }
        int? SchoolChoiceImplementStatusDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LocalEducationAgencyCategoryDescriptor table of the LocalEducationAgencyCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILocalEducationAgencyCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LocalEducationAgencyCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.LocalEducationAgencyFederalFunds table of the LocalEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface ILocalEducationAgencyFederalFundsRecord
    {     
        // Properties for all columns in physical table
        int FiscalYear { get; set; }
        decimal? InnovativeDollarsSpent { get; set; }
        decimal? InnovativeDollarsSpentStrategicPriorities { get; set; }
        decimal? InnovativeProgramsFundsReceived { get; set; }
        int LocalEducationAgencyId { get; set; }
        decimal? SchoolImprovementAllocation { get; set; }
        decimal? SchoolImprovementReservedFundsPercentage { get; set; }
        decimal? StateAssessmentAdministrationFunding { get; set; }
        decimal? SupplementalEducationalServicesFundsSpent { get; set; }
        decimal? SupplementalEducationalServicesPerPupilExpenditure { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Location table of the Location aggregate in the Ods Database.
    /// </summary>
    public interface ILocationRecord
    {     
        // Properties for all columns in physical table
        string ClassroomIdentificationCode { get; set; }
        Guid Id { get; set; }
        int? MaximumNumberOfSeats { get; set; }
        int? OptimalNumberOfSeats { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.MagnetSpecialProgramEmphasisSchoolDescriptor table of the MagnetSpecialProgramEmphasisSchoolDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IMagnetSpecialProgramEmphasisSchoolDescriptorRecord
    {     
        // Properties for all columns in physical table
        int MagnetSpecialProgramEmphasisSchoolDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.MediumOfInstructionDescriptor table of the MediumOfInstructionDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IMediumOfInstructionDescriptorRecord
    {     
        // Properties for all columns in physical table
        int MediumOfInstructionDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.MethodCreditEarnedDescriptor table of the MethodCreditEarnedDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IMethodCreditEarnedDescriptorRecord
    {     
        // Properties for all columns in physical table
        int MethodCreditEarnedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.MigrantEducationProgramServiceDescriptor table of the MigrantEducationProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IMigrantEducationProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int MigrantEducationProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.MonitoredDescriptor table of the MonitoredDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IMonitoredDescriptorRecord
    {     
        // Properties for all columns in physical table
        int MonitoredDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.NeglectedOrDelinquentProgramDescriptor table of the NeglectedOrDelinquentProgramDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface INeglectedOrDelinquentProgramDescriptorRecord
    {     
        // Properties for all columns in physical table
        int NeglectedOrDelinquentProgramDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.NeglectedOrDelinquentProgramServiceDescriptor table of the NeglectedOrDelinquentProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface INeglectedOrDelinquentProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int NeglectedOrDelinquentProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.NetworkPurposeDescriptor table of the NetworkPurposeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface INetworkPurposeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int NetworkPurposeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ObjectiveAssessment table of the ObjectiveAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IObjectiveAssessmentRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        string AssessmentIdentifier { get; set; }
        string Description { get; set; }
        Guid Id { get; set; }
        string IdentificationCode { get; set; }
        decimal? MaxRawScore { get; set; }
        string Namespace { get; set; }
        string Nomenclature { get; set; }
        string ParentIdentificationCode { get; set; }
        decimal? PercentOfAssessment { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ObjectiveAssessmentAssessmentItem table of the ObjectiveAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IObjectiveAssessmentAssessmentItemRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string AssessmentItemIdentificationCode { get; set; }
        string IdentificationCode { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ObjectiveAssessmentLearningObjective table of the ObjectiveAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IObjectiveAssessmentLearningObjectiveRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string IdentificationCode { get; set; }
        string LearningObjectiveId { get; set; }
        string LearningObjectiveNamespace { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ObjectiveAssessmentLearningStandard table of the ObjectiveAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IObjectiveAssessmentLearningStandardRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string IdentificationCode { get; set; }
        string LearningStandardId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ObjectiveAssessmentPerformanceLevel table of the ObjectiveAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IObjectiveAssessmentPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string IdentificationCode { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string Namespace { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ObjectiveAssessmentScore table of the ObjectiveAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IObjectiveAssessmentScoreRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string IdentificationCode { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string Namespace { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.OldEthnicityDescriptor table of the OldEthnicityDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IOldEthnicityDescriptorRecord
    {     
        // Properties for all columns in physical table
        int OldEthnicityDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.OpenStaffPosition table of the OpenStaffPosition aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionRecord
    {     
        // Properties for all columns in physical table
        DateTime DatePosted { get; set; }
        DateTime? DatePostingRemoved { get; set; }
        int EducationOrganizationId { get; set; }
        int EmploymentStatusDescriptorId { get; set; }
        Guid Id { get; set; }
        string PositionTitle { get; set; }
        int? PostingResultDescriptorId { get; set; }
        int? ProgramAssignmentDescriptorId { get; set; }
        string RequisitionNumber { get; set; }
        int StaffClassificationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.OpenStaffPositionAcademicSubject table of the OpenStaffPosition aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string RequisitionNumber { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.OpenStaffPositionInstructionalGradeLevel table of the OpenStaffPosition aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionInstructionalGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string RequisitionNumber { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.OperationalStatusDescriptor table of the OperationalStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IOperationalStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int OperationalStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.OtherNameTypeDescriptor table of the OtherNameTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IOtherNameTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int OtherNameTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Parent table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string ParentUniqueId { get; set; }
        int ParentUSI { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        int? SexDescriptorId { get; set; }
        int? SourceSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentAddress table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentAddressRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        string Latitude { get; set; }
        int? LocaleDescriptorId { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        int ParentUSI { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentAddressPeriod table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        string City { get; set; }
        DateTime? EndDate { get; set; }
        int ParentUSI { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentElectronicMail table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentElectronicMailRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        string ElectronicMailAddress { get; set; }
        int ElectronicMailTypeDescriptorId { get; set; }
        int ParentUSI { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentInternationalAddress table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentInternationalAddressRecord
    {     
        // Properties for all columns in physical table
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string AddressLine4 { get; set; }
        int AddressTypeDescriptorId { get; set; }
        DateTime? BeginDate { get; set; }
        int CountryDescriptorId { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        int ParentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentLanguage table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentLanguageRecord
    {     
        // Properties for all columns in physical table
        int LanguageDescriptorId { get; set; }
        int ParentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentLanguageUse table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentLanguageUseRecord
    {     
        // Properties for all columns in physical table
        int LanguageDescriptorId { get; set; }
        int LanguageUseDescriptorId { get; set; }
        int ParentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentOtherName table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentOtherNameRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string MiddleName { get; set; }
        int OtherNameTypeDescriptorId { get; set; }
        int ParentUSI { get; set; }
        string PersonalTitlePrefix { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentPersonalIdentificationDocument table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentPersonalIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int ParentUSI { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParentTelephone table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentTelephoneRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        int ParentUSI { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParticipationDescriptor table of the ParticipationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IParticipationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ParticipationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ParticipationStatusDescriptor table of the ParticipationStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IParticipationStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ParticipationStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Payroll table of the Payroll aggregate in the Ods Database.
    /// </summary>
    public interface IPayrollRecord
    {     
        // Properties for all columns in physical table
        string AccountIdentifier { get; set; }
        decimal AmountToDate { get; set; }
        DateTime AsOfDate { get; set; }
        int EducationOrganizationId { get; set; }
        int FiscalYear { get; set; }
        Guid Id { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PerformanceBaseConversionDescriptor table of the PerformanceBaseConversionDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceBaseConversionDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PerformanceBaseConversionDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PerformanceLevelDescriptor table of the PerformanceLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PerformanceLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Person table of the Person aggregate in the Ods Database.
    /// </summary>
    public interface IPersonRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string PersonId { get; set; }
        int SourceSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PersonalInformationVerificationDescriptor table of the PersonalInformationVerificationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPersonalInformationVerificationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PersonalInformationVerificationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PlatformTypeDescriptor table of the PlatformTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPlatformTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PlatformTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PopulationServedDescriptor table of the PopulationServedDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPopulationServedDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PopulationServedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PostingResultDescriptor table of the PostingResultDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPostingResultDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PostingResultDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PostSecondaryEvent table of the PostSecondaryEvent aggregate in the Ods Database.
    /// </summary>
    public interface IPostSecondaryEventRecord
    {     
        // Properties for all columns in physical table
        DateTime EventDate { get; set; }
        Guid Id { get; set; }
        int PostSecondaryEventCategoryDescriptorId { get; set; }
        int? PostSecondaryInstitutionId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PostSecondaryEventCategoryDescriptor table of the PostSecondaryEventCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPostSecondaryEventCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PostSecondaryEventCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PostSecondaryInstitution table of the PostSecondaryInstitution aggregate in the Ods Database.
    /// </summary>
    public interface IPostSecondaryInstitutionRecord
    {     
        // Properties for all columns in physical table
        int? AdministrativeFundingControlDescriptorId { get; set; }
        int PostSecondaryInstitutionId { get; set; }
        int? PostSecondaryInstitutionLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PostSecondaryInstitutionLevelDescriptor table of the PostSecondaryInstitutionLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPostSecondaryInstitutionLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PostSecondaryInstitutionLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PostSecondaryInstitutionMediumOfInstruction table of the PostSecondaryInstitution aggregate in the Ods Database.
    /// </summary>
    public interface IPostSecondaryInstitutionMediumOfInstructionRecord
    {     
        // Properties for all columns in physical table
        int MediumOfInstructionDescriptorId { get; set; }
        int PostSecondaryInstitutionId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProficiencyDescriptor table of the ProficiencyDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProficiencyDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProficiencyDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Program table of the Program aggregate in the Ods Database.
    /// </summary>
    public interface IProgramRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string ProgramId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramAssignmentDescriptor table of the ProgramAssignmentDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProgramAssignmentDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProgramAssignmentDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramCharacteristic table of the Program aggregate in the Ods Database.
    /// </summary>
    public interface IProgramCharacteristicRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int ProgramCharacteristicDescriptorId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramCharacteristicDescriptor table of the ProgramCharacteristicDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProgramCharacteristicDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProgramCharacteristicDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramLearningObjective table of the Program aggregate in the Ods Database.
    /// </summary>
    public interface IProgramLearningObjectiveRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramLearningStandard table of the Program aggregate in the Ods Database.
    /// </summary>
    public interface IProgramLearningStandardRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string LearningStandardId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramService table of the Program aggregate in the Ods Database.
    /// </summary>
    public interface IProgramServiceRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int ServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramSponsor table of the Program aggregate in the Ods Database.
    /// </summary>
    public interface IProgramSponsorRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramSponsorDescriptorId { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramSponsorDescriptor table of the ProgramSponsorDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProgramSponsorDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProgramSponsorDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgramTypeDescriptor table of the ProgramTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProgramTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgressDescriptor table of the ProgressDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProgressDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProgressDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProgressLevelDescriptor table of the ProgressLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProgressLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProgressLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProviderCategoryDescriptor table of the ProviderCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProviderCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProviderCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProviderProfitabilityDescriptor table of the ProviderProfitabilityDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProviderProfitabilityDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProviderProfitabilityDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ProviderStatusDescriptor table of the ProviderStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProviderStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProviderStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.PublicationStatusDescriptor table of the PublicationStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPublicationStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PublicationStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.QuestionFormDescriptor table of the QuestionFormDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IQuestionFormDescriptorRecord
    {     
        // Properties for all columns in physical table
        int QuestionFormDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RaceDescriptor table of the RaceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRaceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RaceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReasonExitedDescriptor table of the ReasonExitedDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IReasonExitedDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ReasonExitedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReasonNotTestedDescriptor table of the ReasonNotTestedDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IReasonNotTestedDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ReasonNotTestedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RecognitionTypeDescriptor table of the RecognitionTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRecognitionTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RecognitionTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RelationDescriptor table of the RelationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRelationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RelationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RepeatIdentifierDescriptor table of the RepeatIdentifierDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRepeatIdentifierDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RepeatIdentifierDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReportCard table of the ReportCard aggregate in the Ods Database.
    /// </summary>
    public interface IReportCardRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        decimal? GPACumulative { get; set; }
        decimal? GPAGivenGradingPeriod { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        Guid Id { get; set; }
        decimal? NumberOfDaysAbsent { get; set; }
        decimal? NumberOfDaysInAttendance { get; set; }
        int? NumberOfDaysTardy { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReportCardGrade table of the ReportCard aggregate in the Ods Database.
    /// </summary>
    public interface IReportCardGradeRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int GradeTypeDescriptorId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReportCardGradePointAverage table of the ReportCard aggregate in the Ods Database.
    /// </summary>
    public interface IReportCardGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradePointAverageTypeDescriptorId { get; set; }
        decimal GradePointAverageValue { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        bool? IsCumulative { get; set; }
        decimal? MaxGradePointAverageValue { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReportCardStudentCompetencyObjective table of the ReportCard aggregate in the Ods Database.
    /// </summary>
    public interface IReportCardStudentCompetencyObjectiveRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string Objective { get; set; }
        int ObjectiveEducationOrganizationId { get; set; }
        int ObjectiveGradeLevelDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReportCardStudentLearningObjective table of the ReportCard aggregate in the Ods Database.
    /// </summary>
    public interface IReportCardStudentLearningObjectiveRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ReporterDescriptionDescriptor table of the ReporterDescriptionDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IReporterDescriptionDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ReporterDescriptionDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ResidencyStatusDescriptor table of the ResidencyStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IResidencyStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ResidencyStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ResponseIndicatorDescriptor table of the ResponseIndicatorDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IResponseIndicatorDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ResponseIndicatorDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ResponsibilityDescriptor table of the ResponsibilityDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IResponsibilityDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ResponsibilityDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RestraintEvent table of the RestraintEvent aggregate in the Ods Database.
    /// </summary>
    public interface IRestraintEventRecord
    {     
        // Properties for all columns in physical table
        int? EducationalEnvironmentDescriptorId { get; set; }
        DateTime EventDate { get; set; }
        Guid Id { get; set; }
        string RestraintEventIdentifier { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RestraintEventProgram table of the RestraintEvent aggregate in the Ods Database.
    /// </summary>
    public interface IRestraintEventProgramRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        string RestraintEventIdentifier { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RestraintEventReason table of the RestraintEvent aggregate in the Ods Database.
    /// </summary>
    public interface IRestraintEventReasonRecord
    {     
        // Properties for all columns in physical table
        string RestraintEventIdentifier { get; set; }
        int RestraintEventReasonDescriptorId { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RestraintEventReasonDescriptor table of the RestraintEventReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRestraintEventReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RestraintEventReasonDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ResultDatatypeTypeDescriptor table of the ResultDatatypeTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IResultDatatypeTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.RetestIndicatorDescriptor table of the RetestIndicatorDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRetestIndicatorDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RetestIndicatorDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.School table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolRecord
    {     
        // Properties for all columns in physical table
        int? AdministrativeFundingControlDescriptorId { get; set; }
        int? CharterApprovalAgencyTypeDescriptorId { get; set; }
        short? CharterApprovalSchoolYear { get; set; }
        int? CharterStatusDescriptorId { get; set; }
        int? InternetAccessDescriptorId { get; set; }
        int? LocalEducationAgencyId { get; set; }
        int? MagnetSpecialProgramEmphasisSchoolDescriptorId { get; set; }
        int SchoolId { get; set; }
        int? SchoolTypeDescriptorId { get; set; }
        int? TitleIPartASchoolDesignationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SchoolCategory table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolCategoryRecord
    {     
        // Properties for all columns in physical table
        int SchoolCategoryDescriptorId { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SchoolCategoryDescriptor table of the SchoolCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SchoolCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SchoolChoiceImplementStatusDescriptor table of the SchoolChoiceImplementStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolChoiceImplementStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SchoolChoiceImplementStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SchoolFoodServiceProgramServiceDescriptor table of the SchoolFoodServiceProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolFoodServiceProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SchoolFoodServiceProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SchoolGradeLevel table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SchoolTypeDescriptor table of the SchoolTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SchoolTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SchoolYearType table of the SchoolYearType aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolYearTypeRecord
    {     
        // Properties for all columns in physical table
        bool CurrentSchoolYear { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        string SchoolYearDescription { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Section table of the Section aggregate in the Ods Database.
    /// </summary>
    public interface ISectionRecord
    {     
        // Properties for all columns in physical table
        decimal? AvailableCreditConversion { get; set; }
        decimal? AvailableCredits { get; set; }
        int? AvailableCreditTypeDescriptorId { get; set; }
        int? EducationalEnvironmentDescriptorId { get; set; }
        Guid Id { get; set; }
        int? InstructionLanguageDescriptorId { get; set; }
        string LocalCourseCode { get; set; }
        string LocationClassroomIdentificationCode { get; set; }
        int? LocationSchoolId { get; set; }
        int? MediumOfInstructionDescriptorId { get; set; }
        bool? OfficialAttendancePeriod { get; set; }
        int? PopulationServedDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SectionName { get; set; }
        int? SequenceOfCourse { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SectionAttendanceTakenEvent table of the SectionAttendanceTakenEvent aggregate in the Ods Database.
    /// </summary>
    public interface ISectionAttendanceTakenEventRecord
    {     
        // Properties for all columns in physical table
        string CalendarCode { get; set; }
        DateTime Date { get; set; }
        DateTime EventDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SectionCharacteristic table of the Section aggregate in the Ods Database.
    /// </summary>
    public interface ISectionCharacteristicRecord
    {     
        // Properties for all columns in physical table
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        int SectionCharacteristicDescriptorId { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SectionCharacteristicDescriptor table of the SectionCharacteristicDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISectionCharacteristicDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SectionCharacteristicDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SectionClassPeriod table of the Section aggregate in the Ods Database.
    /// </summary>
    public interface ISectionClassPeriodRecord
    {     
        // Properties for all columns in physical table
        string ClassPeriodName { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SectionCourseLevelCharacteristic table of the Section aggregate in the Ods Database.
    /// </summary>
    public interface ISectionCourseLevelCharacteristicRecord
    {     
        // Properties for all columns in physical table
        int CourseLevelCharacteristicDescriptorId { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SectionOfferedGradeLevel table of the Section aggregate in the Ods Database.
    /// </summary>
    public interface ISectionOfferedGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SectionProgram table of the Section aggregate in the Ods Database.
    /// </summary>
    public interface ISectionProgramRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string LocalCourseCode { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SeparationDescriptor table of the SeparationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISeparationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SeparationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SeparationReasonDescriptor table of the SeparationReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISeparationReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SeparationReasonDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.ServiceDescriptor table of the ServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Session table of the Session aggregate in the Ods Database.
    /// </summary>
    public interface ISessionRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        Guid Id { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
        int TermDescriptorId { get; set; }
        int TotalInstructionalDays { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SessionAcademicWeek table of the Session aggregate in the Ods Database.
    /// </summary>
    public interface ISessionAcademicWeekRecord
    {     
        // Properties for all columns in physical table
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
        string WeekIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SessionGradingPeriod table of the Session aggregate in the Ods Database.
    /// </summary>
    public interface ISessionGradingPeriodRecord
    {     
        // Properties for all columns in physical table
        int GradingPeriodDescriptorId { get; set; }
        int PeriodSequence { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SexDescriptor table of the SexDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISexDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SexDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SourceSystemDescriptor table of the SourceSystemDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISourceSystemDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SourceSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SpecialEducationProgramServiceDescriptor table of the SpecialEducationProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISpecialEducationProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SpecialEducationProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SpecialEducationSettingDescriptor table of the SpecialEducationSettingDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISpecialEducationSettingDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SpecialEducationSettingDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Staff table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffRecord
    {     
        // Properties for all columns in physical table
        DateTime? BirthDate { get; set; }
        int? CitizenshipStatusDescriptorId { get; set; }
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        int? HighestCompletedLevelOfEducationDescriptorId { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        int? OldEthnicityDescriptorId { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        int? SexDescriptorId { get; set; }
        int? SourceSystemDescriptorId { get; set; }
        string StaffUniqueId { get; set; }
        int StaffUSI { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffAbsenceEvent table of the StaffAbsenceEvent aggregate in the Ods Database.
    /// </summary>
    public interface IStaffAbsenceEventRecord
    {     
        // Properties for all columns in physical table
        int AbsenceEventCategoryDescriptorId { get; set; }
        string AbsenceEventReason { get; set; }
        DateTime EventDate { get; set; }
        decimal? HoursAbsent { get; set; }
        Guid Id { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffAddress table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffAddressRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        string Latitude { get; set; }
        int? LocaleDescriptorId { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        string PostalCode { get; set; }
        int StaffUSI { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffAddressPeriod table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        string City { get; set; }
        DateTime? EndDate { get; set; }
        string PostalCode { get; set; }
        int StaffUSI { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffClassificationDescriptor table of the StaffClassificationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStaffClassificationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StaffClassificationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffCohortAssociation table of the StaffCohortAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffCohortAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string CohortIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int StaffUSI { get; set; }
        bool? StudentRecordAccess { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffCredential table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffCredentialRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        int StaffUSI { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffDisciplineIncidentAssociation table of the StaffDisciplineIncidentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffDisciplineIncidentAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string IncidentIdentifier { get; set; }
        int SchoolId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode table of the StaffDisciplineIncidentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffDisciplineIncidentAssociationDisciplineIncidentParticipationCodeRecord
    {     
        // Properties for all columns in physical table
        int DisciplineIncidentParticipationCodeDescriptorId { get; set; }
        string IncidentIdentifier { get; set; }
        int SchoolId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffEducationOrganizationAssignmentAssociation table of the StaffEducationOrganizationAssignmentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEducationOrganizationAssignmentAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string CredentialIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int? EmploymentEducationOrganizationId { get; set; }
        DateTime? EmploymentHireDate { get; set; }
        int? EmploymentStatusDescriptorId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int? OrderOfAssignment { get; set; }
        string PositionTitle { get; set; }
        int StaffClassificationDescriptorId { get; set; }
        int StaffUSI { get; set; }
        int? StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffEducationOrganizationContactAssociation table of the StaffEducationOrganizationContactAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociationRecord
    {     
        // Properties for all columns in physical table
        string ContactTitle { get; set; }
        int? ContactTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string ElectronicMailAddress { get; set; }
        Guid Id { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffEducationOrganizationContactAssociationAddress table of the StaffEducationOrganizationContactAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociationAddressRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CongressionalDistrict { get; set; }
        string ContactTitle { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        string Latitude { get; set; }
        int? LocaleDescriptorId { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        string PostalCode { get; set; }
        int StaffUSI { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffEducationOrganizationContactAssociationAddressPeriod table of the StaffEducationOrganizationContactAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociationAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string ContactTitle { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffEducationOrganizationContactAssociationTelephone table of the StaffEducationOrganizationContactAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEducationOrganizationContactAssociationTelephoneRecord
    {     
        // Properties for all columns in physical table
        string ContactTitle { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        int? OrderOfPriority { get; set; }
        int StaffUSI { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffEducationOrganizationEmploymentAssociation table of the StaffEducationOrganizationEmploymentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEducationOrganizationEmploymentAssociationRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        string Department { get; set; }
        int EducationOrganizationId { get; set; }
        int EmploymentStatusDescriptorId { get; set; }
        DateTime? EndDate { get; set; }
        decimal? FullTimeEquivalency { get; set; }
        DateTime HireDate { get; set; }
        decimal? HourlyWage { get; set; }
        Guid Id { get; set; }
        DateTime? OfferDate { get; set; }
        int? SeparationDescriptorId { get; set; }
        int? SeparationReasonDescriptorId { get; set; }
        int StaffUSI { get; set; }
        int? StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffElectronicMail table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffElectronicMailRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        string ElectronicMailAddress { get; set; }
        int ElectronicMailTypeDescriptorId { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffIdentificationCode table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string AssigningOrganizationIdentificationCode { get; set; }
        string IdentificationCode { get; set; }
        int StaffIdentificationSystemDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffIdentificationDocument table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffIdentificationSystemDescriptor table of the StaffIdentificationSystemDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStaffIdentificationSystemDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StaffIdentificationSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffInternationalAddress table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffInternationalAddressRecord
    {     
        // Properties for all columns in physical table
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string AddressLine4 { get; set; }
        int AddressTypeDescriptorId { get; set; }
        DateTime? BeginDate { get; set; }
        int CountryDescriptorId { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffLanguage table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffLanguageRecord
    {     
        // Properties for all columns in physical table
        int LanguageDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffLanguageUse table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffLanguageUseRecord
    {     
        // Properties for all columns in physical table
        int LanguageDescriptorId { get; set; }
        int LanguageUseDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffLeave table of the StaffLeave aggregate in the Ods Database.
    /// </summary>
    public interface IStaffLeaveRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        string Reason { get; set; }
        int StaffLeaveEventCategoryDescriptorId { get; set; }
        int StaffUSI { get; set; }
        bool? SubstituteAssigned { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffLeaveEventCategoryDescriptor table of the StaffLeaveEventCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStaffLeaveEventCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StaffLeaveEventCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffOtherName table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffOtherNameRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string MiddleName { get; set; }
        int OtherNameTypeDescriptorId { get; set; }
        string PersonalTitlePrefix { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffPersonalIdentificationDocument table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffPersonalIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffProgramAssociation table of the StaffProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StaffUSI { get; set; }
        bool? StudentRecordAccess { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffRace table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffRaceRecord
    {     
        // Properties for all columns in physical table
        int RaceDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffRecognition table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffRecognitionRecord
    {     
        // Properties for all columns in physical table
        int? AchievementCategoryDescriptorId { get; set; }
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
        int RecognitionTypeDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffSchoolAssociation table of the StaffSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffSchoolAssociationRecord
    {     
        // Properties for all columns in physical table
        string CalendarCode { get; set; }
        Guid Id { get; set; }
        int ProgramAssignmentDescriptorId { get; set; }
        int SchoolId { get; set; }
        short? SchoolYear { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffSchoolAssociationAcademicSubject table of the StaffSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffSchoolAssociationAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int ProgramAssignmentDescriptorId { get; set; }
        int SchoolId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffSchoolAssociationGradeLevel table of the StaffSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffSchoolAssociationGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        int ProgramAssignmentDescriptorId { get; set; }
        int SchoolId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffSectionAssociation table of the StaffSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        int ClassroomPositionDescriptorId { get; set; }
        DateTime? EndDate { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        decimal? PercentageContribution { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StaffUSI { get; set; }
        bool? TeacherStudentDataLinkExclusion { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffTelephone table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTelephoneRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        int StaffUSI { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffTribalAffiliation table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTribalAffiliationRecord
    {     
        // Properties for all columns in physical table
        int StaffUSI { get; set; }
        int TribalAffiliationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StaffVisa table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffVisaRecord
    {     
        // Properties for all columns in physical table
        int StaffUSI { get; set; }
        int VisaDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StateAbbreviationDescriptor table of the StateAbbreviationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStateAbbreviationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StateEducationAgency table of the StateEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface IStateEducationAgencyRecord
    {     
        // Properties for all columns in physical table
        int StateEducationAgencyId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StateEducationAgencyAccountability table of the StateEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface IStateEducationAgencyAccountabilityRecord
    {     
        // Properties for all columns in physical table
        bool? CTEGraduationRateInclusion { get; set; }
        short SchoolYear { get; set; }
        int StateEducationAgencyId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StateEducationAgencyFederalFunds table of the StateEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface IStateEducationAgencyFederalFundsRecord
    {     
        // Properties for all columns in physical table
        decimal? FederalProgramsFundingAllocation { get; set; }
        int FiscalYear { get; set; }
        int StateEducationAgencyId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Student table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentRecord
    {     
        // Properties for all columns in physical table
        string BirthCity { get; set; }
        int? BirthCountryDescriptorId { get; set; }
        DateTime BirthDate { get; set; }
        string BirthInternationalProvince { get; set; }
        int? BirthSexDescriptorId { get; set; }
        int? BirthStateAbbreviationDescriptorId { get; set; }
        int? CitizenshipStatusDescriptorId { get; set; }
        DateTime? DateEnteredUS { get; set; }
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        bool? MultipleBirthStatus { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        int? SourceSystemDescriptorId { get; set; }
        string StudentUniqueId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAcademicRecord table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAcademicRecordRecord
    {     
        // Properties for all columns in physical table
        decimal? CumulativeAttemptedCreditConversion { get; set; }
        decimal? CumulativeAttemptedCredits { get; set; }
        int? CumulativeAttemptedCreditTypeDescriptorId { get; set; }
        decimal? CumulativeEarnedCreditConversion { get; set; }
        decimal? CumulativeEarnedCredits { get; set; }
        int? CumulativeEarnedCreditTypeDescriptorId { get; set; }
        decimal? CumulativeGradePointAverage { get; set; }
        decimal? CumulativeGradePointsEarned { get; set; }
        int EducationOrganizationId { get; set; }
        string GradeValueQualifier { get; set; }
        Guid Id { get; set; }
        DateTime? ProjectedGraduationDate { get; set; }
        short SchoolYear { get; set; }
        decimal? SessionAttemptedCreditConversion { get; set; }
        decimal? SessionAttemptedCredits { get; set; }
        int? SessionAttemptedCreditTypeDescriptorId { get; set; }
        decimal? SessionEarnedCreditConversion { get; set; }
        decimal? SessionEarnedCredits { get; set; }
        int? SessionEarnedCreditTypeDescriptorId { get; set; }
        decimal? SessionGradePointAverage { get; set; }
        decimal? SessionGradePointsEarned { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAcademicRecordAcademicHonor table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAcademicRecordAcademicHonorRecord
    {     
        // Properties for all columns in physical table
        int AcademicHonorCategoryDescriptorId { get; set; }
        int? AchievementCategoryDescriptorId { get; set; }
        string AchievementCategorySystem { get; set; }
        string AchievementTitle { get; set; }
        string Criteria { get; set; }
        string CriteriaURL { get; set; }
        int EducationOrganizationId { get; set; }
        string EvidenceStatement { get; set; }
        DateTime? HonorAwardDate { get; set; }
        DateTime? HonorAwardExpiresDate { get; set; }
        string HonorDescription { get; set; }
        string ImageURL { get; set; }
        string IssuerName { get; set; }
        string IssuerOriginURL { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAcademicRecordClassRanking table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAcademicRecordClassRankingRecord
    {     
        // Properties for all columns in physical table
        int ClassRank { get; set; }
        DateTime? ClassRankingDate { get; set; }
        int EducationOrganizationId { get; set; }
        int? PercentageRanking { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
        int TotalNumberInClass { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAcademicRecordDiploma table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAcademicRecordDiplomaRecord
    {     
        // Properties for all columns in physical table
        int? AchievementCategoryDescriptorId { get; set; }
        string AchievementCategorySystem { get; set; }
        string AchievementTitle { get; set; }
        string Criteria { get; set; }
        string CriteriaURL { get; set; }
        bool? CTECompleter { get; set; }
        DateTime DiplomaAwardDate { get; set; }
        DateTime? DiplomaAwardExpiresDate { get; set; }
        string DiplomaDescription { get; set; }
        int? DiplomaLevelDescriptorId { get; set; }
        int DiplomaTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string EvidenceStatement { get; set; }
        string ImageURL { get; set; }
        string IssuerName { get; set; }
        string IssuerOriginURL { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAcademicRecordGradePointAverage table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAcademicRecordGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradePointAverageTypeDescriptorId { get; set; }
        decimal GradePointAverageValue { get; set; }
        bool? IsCumulative { get; set; }
        decimal? MaxGradePointAverageValue { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAcademicRecordRecognition table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAcademicRecordRecognitionRecord
    {     
        // Properties for all columns in physical table
        int? AchievementCategoryDescriptorId { get; set; }
        string AchievementCategorySystem { get; set; }
        string AchievementTitle { get; set; }
        string Criteria { get; set; }
        string CriteriaURL { get; set; }
        int EducationOrganizationId { get; set; }
        string EvidenceStatement { get; set; }
        string ImageURL { get; set; }
        string IssuerName { get; set; }
        string IssuerOriginURL { get; set; }
        DateTime? RecognitionAwardDate { get; set; }
        DateTime? RecognitionAwardExpiresDate { get; set; }
        string RecognitionDescription { get; set; }
        int RecognitionTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAcademicRecordReportCard table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAcademicRecordReportCardRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessment table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentRecord
    {     
        // Properties for all columns in physical table
        DateTime AdministrationDate { get; set; }
        DateTime? AdministrationEndDate { get; set; }
        int? AdministrationEnvironmentDescriptorId { get; set; }
        int? AdministrationLanguageDescriptorId { get; set; }
        string AssessmentIdentifier { get; set; }
        int? EventCircumstanceDescriptorId { get; set; }
        string EventDescription { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        int? PlatformTypeDescriptorId { get; set; }
        int? ReasonNotTestedDescriptorId { get; set; }
        int? RetestIndicatorDescriptorId { get; set; }
        short? SchoolYear { get; set; }
        string SerialNumber { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
        int? WhenAssessedGradeLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessmentAccommodation table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentAccommodationRecord
    {     
        // Properties for all columns in physical table
        int AccommodationDescriptorId { get; set; }
        string AssessmentIdentifier { get; set; }
        string Namespace { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessmentItem table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentItemRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentItemResultDescriptorId { get; set; }
        string AssessmentResponse { get; set; }
        string DescriptiveFeedback { get; set; }
        string IdentificationCode { get; set; }
        string Namespace { get; set; }
        decimal? RawScoreResult { get; set; }
        int? ResponseIndicatorDescriptorId { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
        string TimeAssessed { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessmentPerformanceLevel table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string Namespace { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        bool PerformanceLevelMet { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessmentScoreResult table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentScoreResultRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string Namespace { get; set; }
        string Result { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessmentStudentObjectiveAssessment table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentStudentObjectiveAssessmentRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string IdentificationCode { get; set; }
        string Namespace { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentStudentObjectiveAssessmentPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string IdentificationCode { get; set; }
        string Namespace { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        bool PerformanceLevelMet { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAssessmentStudentObjectiveAssessmentScoreResultRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        string IdentificationCode { get; set; }
        string Namespace { get; set; }
        string Result { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
        string StudentAssessmentIdentifier { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCharacteristicDescriptor table of the StudentCharacteristicDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCharacteristicDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StudentCharacteristicDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCohortAssociation table of the StudentCohortAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCohortAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string CohortIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCohortAssociationSection table of the StudentCohortAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCohortAssociationSectionRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string CohortIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCompetencyObjective table of the StudentCompetencyObjective aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCompetencyObjectiveRecord
    {     
        // Properties for all columns in physical table
        int CompetencyLevelDescriptorId { get; set; }
        string DiagnosticStatement { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        Guid Id { get; set; }
        string Objective { get; set; }
        int ObjectiveEducationOrganizationId { get; set; }
        int ObjectiveGradeLevelDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation table of the StudentCompetencyObjective aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCompetencyObjectiveGeneralStudentProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string Objective { get; set; }
        int ObjectiveEducationOrganizationId { get; set; }
        int ObjectiveGradeLevelDescriptorId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCompetencyObjectiveStudentSectionAssociation table of the StudentCompetencyObjective aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCompetencyObjectiveStudentSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string LocalCourseCode { get; set; }
        string Objective { get; set; }
        int ObjectiveEducationOrganizationId { get; set; }
        int ObjectiveGradeLevelDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCTEProgramAssociation table of the StudentCTEProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCTEProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? NonTraditionalGenderStatus { get; set; }
        bool? PrivateCTEProgram { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
        int? TechnicalSkillsAssessmentDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCTEProgramAssociationCTEProgram table of the StudentCTEProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCTEProgramAssociationCTEProgramRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int CareerPathwayDescriptorId { get; set; }
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCTEProgramAssociationCTEProgramService table of the StudentCTEProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCTEProgramAssociationCTEProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string CIPCode { get; set; }
        int CTEProgramServiceDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentCTEProgramAssociationService table of the StudentCTEProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCTEProgramAssociationServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        int ServiceDescriptorId { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentDisciplineIncidentAssociation table of the StudentDisciplineIncidentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentDisciplineIncidentAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string IncidentIdentifier { get; set; }
        int SchoolId { get; set; }
        int StudentParticipationCodeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentDisciplineIncidentAssociationBehavior table of the StudentDisciplineIncidentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentDisciplineIncidentAssociationBehaviorRecord
    {     
        // Properties for all columns in physical table
        int BehaviorDescriptorId { get; set; }
        string BehaviorDetailedDescription { get; set; }
        string IncidentIdentifier { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociation table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        int? LimitedEnglishProficiencyDescriptorId { get; set; }
        string LoginId { get; set; }
        int? OldEthnicityDescriptorId { get; set; }
        string ProfileThumbnail { get; set; }
        int SexDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationAddress table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        string Latitude { get; set; }
        int? LocaleDescriptorId { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationAddressPeriod table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        string City { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationCohortYear table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationCohortYearRecord
    {     
        // Properties for all columns in physical table
        int CohortYearTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationDisability table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationDisabilityRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        int? DisabilityDeterminationSourceTypeDescriptorId { get; set; }
        string DisabilityDiagnosis { get; set; }
        int EducationOrganizationId { get; set; }
        int? OrderOfDisability { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationDisabilityDesignation table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationDisabilityDesignationRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        int DisabilityDesignationDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationElectronicMail table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationElectronicMailRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        string ElectronicMailAddress { get; set; }
        int ElectronicMailTypeDescriptorId { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationInternationalAddress table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationInternationalAddressRecord
    {     
        // Properties for all columns in physical table
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string AddressLine4 { get; set; }
        int AddressTypeDescriptorId { get; set; }
        DateTime? BeginDate { get; set; }
        int CountryDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationLanguage table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationLanguageRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int LanguageDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationLanguageUse table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationLanguageUseRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int LanguageDescriptorId { get; set; }
        int LanguageUseDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationProgramParticipation table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationProgramParticipationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationProgramParticipationProgramCharacteristicRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int ProgramCharacteristicDescriptorId { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationRace table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationRaceRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int RaceDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationStudentCharacteristic table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicRecord
    {     
        // Properties for all columns in physical table
        string DesignatedBy { get; set; }
        int EducationOrganizationId { get; set; }
        int StudentCharacteristicDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationStudentCharacteristicPeriod table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicPeriodRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        int StudentCharacteristicDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationStudentIdentificationCode table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string AssigningOrganizationIdentificationCode { get; set; }
        int EducationOrganizationId { get; set; }
        string IdentificationCode { get; set; }
        int StudentIdentificationSystemDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationStudentIndicator table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentIndicatorRecord
    {     
        // Properties for all columns in physical table
        string DesignatedBy { get; set; }
        int EducationOrganizationId { get; set; }
        string Indicator { get; set; }
        string IndicatorGroup { get; set; }
        string IndicatorName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentIndicatorPeriodRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        string IndicatorName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationTelephone table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationTelephoneRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        int? OrderOfPriority { get; set; }
        int StudentUSI { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationAssociationTribalAffiliation table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationTribalAffiliationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int StudentUSI { get; set; }
        int TribalAffiliationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentEducationOrganizationResponsibilityAssociation table of the StudentEducationOrganizationResponsibilityAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationResponsibilityAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int ResponsibilityDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentGradebookEntry table of the StudentGradebookEntry aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGradebookEntryRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int? CompetencyLevelDescriptorId { get; set; }
        DateTime DateAssigned { get; set; }
        DateTime? DateFulfilled { get; set; }
        string DiagnosticStatement { get; set; }
        string GradebookEntryTitle { get; set; }
        Guid Id { get; set; }
        string LetterGradeEarned { get; set; }
        string LocalCourseCode { get; set; }
        decimal? NumericGradeEarned { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentHomelessProgramAssociation table of the StudentHomelessProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentHomelessProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        bool? AwaitingFosterCare { get; set; }
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int? HomelessPrimaryNighttimeResidenceDescriptorId { get; set; }
        bool? HomelessUnaccompaniedYouth { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentHomelessProgramAssociationHomelessProgramService table of the StudentHomelessProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentHomelessProgramAssociationHomelessProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int HomelessProgramServiceDescriptorId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentIdentificationDocument table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentIdentificationSystemDescriptor table of the StudentIdentificationSystemDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStudentIdentificationSystemDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StudentIdentificationSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentInterventionAssociation table of the StudentInterventionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentInterventionAssociationRecord
    {     
        // Properties for all columns in physical table
        int? CohortEducationOrganizationId { get; set; }
        string CohortIdentifier { get; set; }
        string DiagnosticStatement { get; set; }
        int? Dosage { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string InterventionIdentificationCode { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentInterventionAssociationInterventionEffectiveness table of the StudentInterventionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentInterventionAssociationInterventionEffectivenessRecord
    {     
        // Properties for all columns in physical table
        int DiagnosisDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        int? ImprovementIndex { get; set; }
        int InterventionEffectivenessRatingDescriptorId { get; set; }
        string InterventionIdentificationCode { get; set; }
        int PopulationServedDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentInterventionAttendanceEvent table of the StudentInterventionAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    public interface IStudentInterventionAttendanceEventRecord
    {     
        // Properties for all columns in physical table
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        int? EducationalEnvironmentDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime EventDate { get; set; }
        decimal? EventDuration { get; set; }
        Guid Id { get; set; }
        int? InterventionDuration { get; set; }
        string InterventionIdentificationCode { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentLanguageInstructionProgramAssociation table of the StudentLanguageInstructionProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentLanguageInstructionProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int? Dosage { get; set; }
        int EducationOrganizationId { get; set; }
        bool? EnglishLearnerParticipation { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment table of the StudentLanguageInstructionProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessmentRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int? MonitoredDescriptorId { get; set; }
        int? ParticipationDescriptorId { get; set; }
        int? ProficiencyDescriptorId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int? ProgressDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService table of the StudentLanguageInstructionProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentLanguageInstructionProgramAssociationLanguageInstructionProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int LanguageInstructionProgramServiceDescriptorId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentLearningObjective table of the StudentLearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface IStudentLearningObjectiveRecord
    {     
        // Properties for all columns in physical table
        int CompetencyLevelDescriptorId { get; set; }
        string DiagnosticStatement { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        Guid Id { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentLearningObjectiveGeneralStudentProgramAssociation table of the StudentLearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface IStudentLearningObjectiveGeneralStudentProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string LearningObjectiveId { get; set; }
        string Namespace { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentLearningObjectiveStudentSectionAssociation table of the StudentLearningObjective aggregate in the Ods Database.
    /// </summary>
    public interface IStudentLearningObjectiveStudentSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int GradingPeriodDescriptorId { get; set; }
        int GradingPeriodSchoolId { get; set; }
        short GradingPeriodSchoolYear { get; set; }
        int GradingPeriodSequence { get; set; }
        string LearningObjectiveId { get; set; }
        string LocalCourseCode { get; set; }
        string Namespace { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentMigrantEducationProgramAssociation table of the StudentMigrantEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentMigrantEducationProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int? ContinuationOfServicesReasonDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EligibilityExpirationDate { get; set; }
        DateTime LastQualifyingMove { get; set; }
        bool PriorityForServices { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? QualifyingArrivalDate { get; set; }
        DateTime? StateResidencyDate { get; set; }
        int StudentUSI { get; set; }
        DateTime? USInitialEntry { get; set; }
        DateTime? USInitialSchoolEntry { get; set; }
        DateTime? USMostRecentEntry { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentMigrantEducationProgramAssociationMigrantEducationProgramService table of the StudentMigrantEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentMigrantEducationProgramAssociationMigrantEducationProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int MigrantEducationProgramServiceDescriptorId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentNeglectedOrDelinquentProgramAssociation table of the StudentNeglectedOrDelinquentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentNeglectedOrDelinquentProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int? ELAProgressLevelDescriptorId { get; set; }
        int? MathematicsProgressLevelDescriptorId { get; set; }
        int? NeglectedOrDelinquentProgramDescriptorId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService table of the StudentNeglectedOrDelinquentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int NeglectedOrDelinquentProgramServiceDescriptorId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentOtherName table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentOtherNameRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string MiddleName { get; set; }
        int OtherNameTypeDescriptorId { get; set; }
        string PersonalTitlePrefix { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentParentAssociation table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationRecord
    {     
        // Properties for all columns in physical table
        int? ContactPriority { get; set; }
        string ContactRestrictions { get; set; }
        bool? EmergencyContactStatus { get; set; }
        Guid Id { get; set; }
        bool? LivesWith { get; set; }
        int ParentUSI { get; set; }
        bool? PrimaryContactStatus { get; set; }
        int? RelationDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentParticipationCodeDescriptor table of the StudentParticipationCodeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParticipationCodeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StudentParticipationCodeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentPersonalIdentificationDocument table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentPersonalIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentProgramAssociation table of the StudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentProgramAssociationService table of the StudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentProgramAssociationServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        int ServiceDescriptorId { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentProgramAttendanceEvent table of the StudentProgramAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    public interface IStudentProgramAttendanceEventRecord
    {     
        // Properties for all columns in physical table
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        int? EducationalEnvironmentDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime EventDate { get; set; }
        decimal? EventDuration { get; set; }
        Guid Id { get; set; }
        int? ProgramAttendanceDuration { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSchoolAssociation table of the StudentSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolAssociationRecord
    {     
        // Properties for all columns in physical table
        string CalendarCode { get; set; }
        short? ClassOfSchoolYear { get; set; }
        int? EducationOrganizationId { get; set; }
        bool? EmployedWhileEnrolled { get; set; }
        DateTime EntryDate { get; set; }
        int EntryGradeLevelDescriptorId { get; set; }
        int? EntryGradeLevelReasonDescriptorId { get; set; }
        int? EntryTypeDescriptorId { get; set; }
        DateTime? ExitWithdrawDate { get; set; }
        int? ExitWithdrawTypeDescriptorId { get; set; }
        decimal? FullTimeEquivalency { get; set; }
        int? GraduationPlanTypeDescriptorId { get; set; }
        short? GraduationSchoolYear { get; set; }
        Guid Id { get; set; }
        bool? PrimarySchool { get; set; }
        bool? RepeatGradeIndicator { get; set; }
        int? ResidencyStatusDescriptorId { get; set; }
        bool? SchoolChoiceTransfer { get; set; }
        int SchoolId { get; set; }
        short? SchoolYear { get; set; }
        int StudentUSI { get; set; }
        bool? TermCompletionIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSchoolAssociationAlternativeGraduationPlan table of the StudentSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolAssociationAlternativeGraduationPlanRecord
    {     
        // Properties for all columns in physical table
        int AlternativeEducationOrganizationId { get; set; }
        int AlternativeGraduationPlanTypeDescriptorId { get; set; }
        short AlternativeGraduationSchoolYear { get; set; }
        DateTime EntryDate { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSchoolAssociationEducationPlan table of the StudentSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolAssociationEducationPlanRecord
    {     
        // Properties for all columns in physical table
        int EducationPlanDescriptorId { get; set; }
        DateTime EntryDate { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSchoolAttendanceEvent table of the StudentSchoolAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolAttendanceEventRecord
    {     
        // Properties for all columns in physical table
        TimeSpan? ArrivalTime { get; set; }
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        TimeSpan? DepartureTime { get; set; }
        int? EducationalEnvironmentDescriptorId { get; set; }
        DateTime EventDate { get; set; }
        decimal? EventDuration { get; set; }
        Guid Id { get; set; }
        int? SchoolAttendanceDuration { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSchoolFoodServiceProgramAssociation table of the StudentSchoolFoodServiceProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolFoodServiceProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        bool? DirectCertification { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService table of the StudentSchoolFoodServiceProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int SchoolFoodServiceProgramServiceDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSectionAssociation table of the StudentSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        int? AttemptStatusDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        bool? HomeroomIndicator { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int? RepeatIdentifierDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
        bool? TeacherStudentDataLinkExclusion { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSectionAttendanceEvent table of the StudentSectionAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSectionAttendanceEventRecord
    {     
        // Properties for all columns in physical table
        TimeSpan? ArrivalTime { get; set; }
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        TimeSpan? DepartureTime { get; set; }
        int? EducationalEnvironmentDescriptorId { get; set; }
        DateTime EventDate { get; set; }
        decimal? EventDuration { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        int? SectionAttendanceDuration { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSpecialEducationProgramAssociation table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? IdeaEligibility { get; set; }
        DateTime? IEPBeginDate { get; set; }
        DateTime? IEPEndDate { get; set; }
        DateTime? IEPReviewDate { get; set; }
        DateTime? LastEvaluationDate { get; set; }
        bool? MedicallyFragile { get; set; }
        bool? MultiplyDisabled { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        decimal? SchoolHoursPerWeek { get; set; }
        decimal? SpecialEducationHoursPerWeek { get; set; }
        int? SpecialEducationSettingDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSpecialEducationProgramAssociationDisability table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationDisabilityRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int DisabilityDescriptorId { get; set; }
        int? DisabilityDeterminationSourceTypeDescriptorId { get; set; }
        string DisabilityDiagnosis { get; set; }
        int EducationOrganizationId { get; set; }
        int? OrderOfDisability { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationDisabilityDesignationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int DisabilityDescriptorId { get; set; }
        int DisabilityDesignationDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSpecialEducationProgramAssociationServiceProvider table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationServiceProviderRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryProvider { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StaffUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSpecialEducationProgramAssociationSpecialEducationProgramService table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationSpecialEducationProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int SpecialEducationProgramServiceDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProviderRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryProvider { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int SpecialEducationProgramServiceDescriptorId { get; set; }
        int StaffUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentTitleIPartAProgramAssociation table of the StudentTitleIPartAProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentTitleIPartAProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
        int TitleIPartAParticipantDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentTitleIPartAProgramAssociationService table of the StudentTitleIPartAProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentTitleIPartAProgramAssociationServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        int ServiceDescriptorId { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService table of the StudentTitleIPartAProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentTitleIPartAProgramAssociationTitleIPartAProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
        int TitleIPartAProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.StudentVisa table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentVisaRecord
    {     
        // Properties for all columns in physical table
        int StudentUSI { get; set; }
        int VisaDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.Survey table of the Survey aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyRecord
    {     
        // Properties for all columns in physical table
        int? EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        int? NumberAdministered { get; set; }
        int? SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SessionName { get; set; }
        int? SurveyCategoryDescriptorId { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyTitle { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyCategoryDescriptor table of the SurveyCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SurveyCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyCourseAssociation table of the SurveyCourseAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyCourseAssociationRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyLevelDescriptor table of the SurveyLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SurveyLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyProgramAssociation table of the SurveyProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        string SurveyIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyQuestion table of the SurveyQuestion aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyQuestionRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string Namespace { get; set; }
        string QuestionCode { get; set; }
        int QuestionFormDescriptorId { get; set; }
        string QuestionText { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyQuestionMatrix table of the SurveyQuestion aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyQuestionMatrixRecord
    {     
        // Properties for all columns in physical table
        string MatrixElement { get; set; }
        int? MaxRawScore { get; set; }
        int? MinRawScore { get; set; }
        string Namespace { get; set; }
        string QuestionCode { get; set; }
        string SurveyIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyQuestionResponse table of the SurveyQuestionResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyQuestionResponseRecord
    {     
        // Properties for all columns in physical table
        string Comment { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        bool? NoResponse { get; set; }
        string QuestionCode { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyQuestionResponseChoice table of the SurveyQuestion aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyQuestionResponseChoiceRecord
    {     
        // Properties for all columns in physical table
        string Namespace { get; set; }
        int? NumericValue { get; set; }
        string QuestionCode { get; set; }
        int SortOrder { get; set; }
        string SurveyIdentifier { get; set; }
        string TextValue { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse table of the SurveyQuestionResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyQuestionResponseSurveyQuestionMatrixElementResponseRecord
    {     
        // Properties for all columns in physical table
        string MatrixElement { get; set; }
        int? MaxNumericResponse { get; set; }
        int? MinNumericResponse { get; set; }
        string Namespace { get; set; }
        bool? NoResponse { get; set; }
        int? NumericResponse { get; set; }
        string QuestionCode { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string TextResponse { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyQuestionResponseValue table of the SurveyQuestionResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyQuestionResponseValueRecord
    {     
        // Properties for all columns in physical table
        string Namespace { get; set; }
        int? NumericResponse { get; set; }
        string QuestionCode { get; set; }
        string SurveyIdentifier { get; set; }
        int SurveyQuestionResponseValueIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string TextResponse { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyResponse table of the SurveyResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyResponseRecord
    {     
        // Properties for all columns in physical table
        string ElectronicMailAddress { get; set; }
        string FullName { get; set; }
        Guid Id { get; set; }
        string Location { get; set; }
        string Namespace { get; set; }
        int? ParentUSI { get; set; }
        DateTime ResponseDate { get; set; }
        int? ResponseTime { get; set; }
        int? StaffUSI { get; set; }
        int? StudentUSI { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyResponseEducationOrganizationTargetAssociation table of the SurveyResponseEducationOrganizationTargetAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyResponseEducationOrganizationTargetAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyResponseStaffTargetAssociation table of the SurveyResponseStaffTargetAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyResponseStaffTargetAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string Namespace { get; set; }
        int StaffUSI { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveyResponseSurveyLevel table of the SurveyResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyResponseSurveyLevelRecord
    {     
        // Properties for all columns in physical table
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
        int SurveyLevelDescriptorId { get; set; }
        string SurveyResponseIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveySection table of the SurveySection aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveySectionAssociation table of the SurveySectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        string Namespace { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        string SurveyIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveySectionResponse table of the SurveySectionResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionResponseRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string Namespace { get; set; }
        decimal? SectionRating { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveySectionResponseEducationOrganizationTargetAssociation table of the SurveySectionResponseEducationOrganizationTargetAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionResponseEducationOrganizationTargetAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.SurveySectionResponseStaffTargetAssociation table of the SurveySectionResponseStaffTargetAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionResponseStaffTargetAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string Namespace { get; set; }
        int StaffUSI { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TeachingCredentialBasisDescriptor table of the TeachingCredentialBasisDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITeachingCredentialBasisDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TeachingCredentialBasisDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TeachingCredentialDescriptor table of the TeachingCredentialDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITeachingCredentialDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TeachingCredentialDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TechnicalSkillsAssessmentDescriptor table of the TechnicalSkillsAssessmentDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITechnicalSkillsAssessmentDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TechnicalSkillsAssessmentDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TelephoneNumberTypeDescriptor table of the TelephoneNumberTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITelephoneNumberTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TelephoneNumberTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TermDescriptor table of the TermDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITermDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TitleIPartAParticipantDescriptor table of the TitleIPartAParticipantDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITitleIPartAParticipantDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TitleIPartAParticipantDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TitleIPartAProgramServiceDescriptor table of the TitleIPartAProgramServiceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITitleIPartAProgramServiceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TitleIPartAProgramServiceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TitleIPartASchoolDesignationDescriptor table of the TitleIPartASchoolDesignationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITitleIPartASchoolDesignationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TitleIPartASchoolDesignationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.TribalAffiliationDescriptor table of the TribalAffiliationDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITribalAffiliationDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TribalAffiliationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.VisaDescriptor table of the VisaDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IVisaDescriptorRecord
    {     
        // Properties for all columns in physical table
        int VisaDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the edfi.WeaponDescriptor table of the WeaponDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IWeaponDescriptorRecord
    {     
        // Properties for all columns in physical table
        int WeaponDescriptorId { get; set; }
    }
}

