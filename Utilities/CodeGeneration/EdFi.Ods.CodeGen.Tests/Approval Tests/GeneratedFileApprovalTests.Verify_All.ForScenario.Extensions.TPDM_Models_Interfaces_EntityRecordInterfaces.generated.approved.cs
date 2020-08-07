using System;


namespace EdFi.Ods.Entities.Common.Records.TPDM
{ 

    /// <summary>
    /// Interface for the tpdm.AccreditationStatusDescriptor table of the AccreditationStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAccreditationStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AccreditationStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AidTypeDescriptor table of the AidTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IAidTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int AidTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudent table of the AnonymizedStudent aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        bool? AtriskIndicator { get; set; }
        bool? ELLEnrollment { get; set; }
        bool? ESLEnrollment { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? GenderDescriptorId { get; set; }
        int? GradeLevelDescriptorId { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        int? Mobility { get; set; }
        short SchoolYear { get; set; }
        bool? Section504Enrollment { get; set; }
        int? SexDescriptorId { get; set; }
        bool? SPEDEnrollment { get; set; }
        bool? TitleIEnrollment { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentAcademicRecord table of the AnonymizedStudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentAcademicRecordRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        decimal? CumulativeGradePointAverage { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        decimal? GPAMax { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        decimal? SessionGradePointAverage { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentAssessment table of the AnonymizedStudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentAssessmentRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        DateTime AdministrationDate { get; set; }
        string AnonymizedStudentIdentifier { get; set; }
        int? AssessmentCategoryDescriptorId { get; set; }
        string AssessmentIdentifier { get; set; }
        string AssessmentTitle { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? GradeLevelDescriptorId { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        short TakenSchoolYear { get; set; }
        int? TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentAssessmentCourseAssociation table of the AnonymizedStudentAssessmentCourseAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentAssessmentCourseAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime AdministrationDate { get; set; }
        string AnonymizedStudentIdentifier { get; set; }
        string AssessmentIdentifier { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentAssessmentPerformanceLevel table of the AnonymizedStudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentAssessmentPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        DateTime AdministrationDate { get; set; }
        string AnonymizedStudentIdentifier { get; set; }
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        bool PerformanceLevelMet { get; set; }
        short SchoolYear { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentAssessmentScoreResult table of the AnonymizedStudentAssessment aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentAssessmentScoreResultRecord
    {     
        // Properties for all columns in physical table
        DateTime AdministrationDate { get; set; }
        string AnonymizedStudentIdentifier { get; set; }
        string AssessmentIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        string Result { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentAssessmentSectionAssociation table of the AnonymizedStudentAssessmentSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentAssessmentSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime AdministrationDate { get; set; }
        string AnonymizedStudentIdentifier { get; set; }
        string AssessmentIdentifier { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentCourseAssociation table of the AnonymizedStudentCourseAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentCourseAssociationRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        DateTime BeginDate { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentCourseTranscript table of the AnonymizedStudentCourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentCourseTranscriptRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        string CourseCode { get; set; }
        int? CourseRepeatCodeDescriptorId { get; set; }
        string CourseTitle { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        string FinalLetterGradeEarned { get; set; }
        decimal? FinalNumericGradeEarned { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentDisability table of the AnonymizedStudent aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentDisabilityRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        int DisabilityDescriptorId { get; set; }
        int? DisabilityDeterminationSourceTypeDescriptorId { get; set; }
        string DisabilityDiagnosis { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? OrderOfDisability { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentDisabilityDesignation table of the AnonymizedStudent aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentDisabilityDesignationRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        int DisabilityDescriptorId { get; set; }
        int DisabilityDesignationDescriptorId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentEducationOrganizationAssociation table of the AnonymizedStudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentEducationOrganizationAssociationRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentLanguage table of the AnonymizedStudent aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentLanguageRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int LanguageDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentLanguageUse table of the AnonymizedStudent aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentLanguageUseRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int LanguageDescriptorId { get; set; }
        int LanguageUseDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentRace table of the AnonymizedStudent aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentRaceRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int RaceDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AnonymizedStudentSectionAssociation table of the AnonymizedStudentSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IAnonymizedStudentSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        string AnonymizedStudentIdentifier { get; set; }
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.Applicant table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        DateTime? BirthDate { get; set; }
        int? CitizenshipStatusDescriptorId { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        int? GenderDescriptorId { get; set; }
        string GenerationCodeSuffix { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        int? SexDescriptorId { get; set; }
        int? SourceSystemDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantAddress table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantAddressRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string ApplicantIdentifier { get; set; }
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
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantAddressPeriod table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApplicantIdentifier { get; set; }
        DateTime BeginDate { get; set; }
        string City { get; set; }
        DateTime? EndDate { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantAid table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantAidRecord
    {     
        // Properties for all columns in physical table
        decimal? AidAmount { get; set; }
        string AidConditionDescription { get; set; }
        int AidTypeDescriptorId { get; set; }
        string ApplicantIdentifier { get; set; }
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        bool? PellGrantRecipient { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantBackgroundCheck table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantBackgroundCheckRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        DateTime? BackgroundCheckCompletedDate { get; set; }
        DateTime BackgroundCheckRequestedDate { get; set; }
        int? BackgroundCheckStatusDescriptorId { get; set; }
        int BackgroundCheckTypeDescriptorId { get; set; }
        bool? Fingerprint { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantCharacteristic table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantCharacteristicRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        DateTime? EndDate { get; set; }
        int StudentCharacteristicDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantDisability table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantDisabilityRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int DisabilityDescriptorId { get; set; }
        int? DisabilityDeterminationSourceTypeDescriptorId { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantDisabilityDesignation table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantDisabilityDesignationRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int DisabilityDescriptorId { get; set; }
        int DisabilityDesignationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantElectronicMail table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantElectronicMailRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        string ElectronicMailAddress { get; set; }
        int ElectronicMailTypeDescriptorId { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantIdentificationDocument table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantInternationalAddress table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantInternationalAddressRecord
    {     
        // Properties for all columns in physical table
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string AddressLine4 { get; set; }
        int AddressTypeDescriptorId { get; set; }
        string ApplicantIdentifier { get; set; }
        DateTime? BeginDate { get; set; }
        int CountryDescriptorId { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantLanguage table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantLanguageRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int LanguageDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantLanguageUse table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantLanguageUseRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int LanguageDescriptorId { get; set; }
        int LanguageUseDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantPersonalIdentificationDocument table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantPersonalIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantProspectAssociation table of the ApplicantProspectAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantProspectAssociationRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantRace table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantRaceRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int RaceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantStaffIdentificationCode table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantStaffIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string AssigningOrganizationIdentificationCode { get; set; }
        string IdentificationCode { get; set; }
        int StaffIdentificationSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantTeacherPreparationProgram table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantTeacherPreparationProgramRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        decimal? GPA { get; set; }
        int LevelOfDegreeAwardedDescriptorId { get; set; }
        string MajorSpecialization { get; set; }
        string NameOfInstitution { get; set; }
        string TeacherPreparationProgramIdentifier { get; set; }
        string TeacherPreparationProgramName { get; set; }
        int TeacherPreparationProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantTelephone table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantTelephoneRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantVisa table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantVisaRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int VisaDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.Application table of the Application aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        DateTime? AcceptedDate { get; set; }
        string ApplicantIdentifier { get; set; }
        DateTime ApplicationDate { get; set; }
        string ApplicationIdentifier { get; set; }
        int? ApplicationSourceDescriptorId { get; set; }
        int ApplicationStatusDescriptorId { get; set; }
        bool? CurrentEmployee { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? FirstContactDate { get; set; }
        int? HighestCompletedLevelOfEducationDescriptorId { get; set; }
        int? HighlyQualifiedAcademicSubjectDescriptorId { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        int? HighNeedsAcademicSubjectDescriptorId { get; set; }
        int? HireStatusDescriptorId { get; set; }
        int? HiringSourceDescriptorId { get; set; }
        Guid Id { get; set; }
        DateTime? WithdrawDate { get; set; }
        int? WithdrawReasonDescriptorId { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationEvent table of the ApplicationEvent aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationEventRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        decimal? ApplicationEvaluationScore { get; set; }
        int? ApplicationEventResultDescriptorId { get; set; }
        int ApplicationEventTypeDescriptorId { get; set; }
        string ApplicationIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime EventDate { get; set; }
        DateTime? EventEndDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        int SequenceNumber { get; set; }
        int? TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationEventResultDescriptor table of the ApplicationEventResultDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationEventResultDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ApplicationEventResultDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationEventTypeDescriptor table of the ApplicationEventTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationEventTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ApplicationEventTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationGradePointAverage table of the Application aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string ApplicationIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int GradePointAverageTypeDescriptorId { get; set; }
        decimal GradePointAverageValue { get; set; }
        bool? IsCumulative { get; set; }
        decimal? MaxGradePointAverageValue { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationOpenStaffPosition table of the Application aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationOpenStaffPositionRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string ApplicationIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        string RequisitionNumber { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationScoreResult table of the Application aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationScoreResultRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string ApplicationIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string Result { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationSourceDescriptor table of the ApplicationSourceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationSourceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ApplicationSourceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationStatusDescriptor table of the ApplicationStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ApplicationStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicationTerm table of the Application aggregate in the Ods Database.
    /// </summary>
    public interface IApplicationTermRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string ApplicationIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.AssessmentExtension table of the Assessment aggregate in the Ods Database.
    /// </summary>
    public interface IAssessmentExtensionRecord
    {     
        // Properties for all columns in physical table
        string AssessmentIdentifier { get; set; }
        string Namespace { get; set; }
        int? ProgramGatewayDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.BackgroundCheckStatusDescriptor table of the BackgroundCheckStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IBackgroundCheckStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int BackgroundCheckStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.BackgroundCheckTypeDescriptor table of the BackgroundCheckTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IBackgroundCheckTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int BackgroundCheckTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.Certification table of the Certification aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationRecord
    {     
        // Properties for all columns in physical table
        int? CertificationFieldDescriptorId { get; set; }
        string CertificationIdentifier { get; set; }
        int? CertificationLevelDescriptorId { get; set; }
        int? CertificationStandardDescriptorId { get; set; }
        string CertificationTitle { get; set; }
        int? EducationOrganizationId { get; set; }
        int? EducatorRoleDescriptorId { get; set; }
        DateTime? EffectiveDate { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int? InstructionalSettingDescriptorId { get; set; }
        int? MinimumDegreeDescriptorId { get; set; }
        string Namespace { get; set; }
        int? PopulationServedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationCertificationExam table of the Certification aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationCertificationExamRecord
    {     
        // Properties for all columns in physical table
        string CertificationExamIdentifier { get; set; }
        string CertificationExamNamespace { get; set; }
        string CertificationIdentifier { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationExam table of the CertificationExam aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationExamRecord
    {     
        // Properties for all columns in physical table
        string CertificationExamIdentifier { get; set; }
        string CertificationExamTitle { get; set; }
        int? CertificationExamTypeDescriptorId { get; set; }
        int? EducationOrganizationId { get; set; }
        DateTime? EffectiveDate { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationExamResult table of the CertificationExamResult aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationExamResultRecord
    {     
        // Properties for all columns in physical table
        int? AttemptNumber { get; set; }
        DateTime CertificationExamDate { get; set; }
        string CertificationExamIdentifier { get; set; }
        bool? CertificationExamPassIndicator { get; set; }
        decimal? CertificationExamScore { get; set; }
        int? CertificationExamStatusDescriptorId { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        string PersonId { get; set; }
        int SourceSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationExamStatusDescriptor table of the CertificationExamStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationExamStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CertificationExamStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationExamTypeDescriptor table of the CertificationExamTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationExamTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CertificationExamTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationFieldDescriptor table of the CertificationFieldDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationFieldDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CertificationFieldDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationGradeLevel table of the Certification aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationGradeLevelRecord
    {     
        // Properties for all columns in physical table
        string CertificationIdentifier { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationLevelDescriptor table of the CertificationLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CertificationLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationRoute table of the Certification aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationRouteRecord
    {     
        // Properties for all columns in physical table
        string CertificationIdentifier { get; set; }
        int CertificationRouteDescriptorId { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationRouteDescriptor table of the CertificationRouteDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationRouteDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CertificationRouteDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CertificationStandardDescriptor table of the CertificationStandardDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICertificationStandardDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CertificationStandardDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CompleterAsStaffAssociation table of the CompleterAsStaffAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ICompleterAsStaffAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        int StaffUSI { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CoteachingStyleObservedDescriptor table of the CoteachingStyleObservedDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICoteachingStyleObservedDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CoteachingStyleObservedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialEvent table of the CredentialEvent aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialEventRecord
    {     
        // Properties for all columns in physical table
        DateTime CredentialEventDate { get; set; }
        string CredentialEventReason { get; set; }
        int CredentialEventTypeDescriptorId { get; set; }
        string CredentialIdentifier { get; set; }
        Guid Id { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialEventTypeDescriptor table of the CredentialEventTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialEventTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CredentialEventTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialExtension table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialExtensionRecord
    {     
        // Properties for all columns in physical table
        bool? BoardCertificationIndicator { get; set; }
        string CertificationIdentifier { get; set; }
        int? CertificationRouteDescriptorId { get; set; }
        string CertificationTitle { get; set; }
        string CredentialIdentifier { get; set; }
        DateTime? CredentialStatusDate { get; set; }
        int? CredentialStatusDescriptorId { get; set; }
        string Namespace { get; set; }
        string PersonId { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialStatusDescriptor table of the CredentialStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int CredentialStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialStudentAcademicRecord table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialStudentAcademicRecordRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        short SchoolYear { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.DegreeDescriptor table of the DegreeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IDegreeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int DegreeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducatorRoleDescriptor table of the EducatorRoleDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEducatorRoleDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EducatorRoleDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EmploymentEvent table of the EmploymentEvent aggregate in the Ods Database.
    /// </summary>
    public interface IEmploymentEventRecord
    {     
        // Properties for all columns in physical table
        bool? EarlyHire { get; set; }
        int EducationOrganizationId { get; set; }
        int EmploymentEventTypeDescriptorId { get; set; }
        DateTime? HireDate { get; set; }
        Guid Id { get; set; }
        int? InternalExternalHireDescriptorId { get; set; }
        bool? MutualConsent { get; set; }
        string RequisitionNumber { get; set; }
        bool? RestrictedChoice { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EmploymentEventTypeDescriptor table of the EmploymentEventTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEmploymentEventTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EmploymentEventTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EmploymentSeparationEvent table of the EmploymentSeparationEvent aggregate in the Ods Database.
    /// </summary>
    public interface IEmploymentSeparationEventRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EmploymentSeparationDate { get; set; }
        DateTime? EmploymentSeparationEnteredDate { get; set; }
        int? EmploymentSeparationReasonDescriptorId { get; set; }
        int EmploymentSeparationTypeDescriptorId { get; set; }
        Guid Id { get; set; }
        bool? RemainingInDistrict { get; set; }
        string RequisitionNumber { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EmploymentSeparationReasonDescriptor table of the EmploymentSeparationReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEmploymentSeparationReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EmploymentSeparationReasonDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EmploymentSeparationTypeDescriptor table of the EmploymentSeparationTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEmploymentSeparationTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EmploymentSeparationTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EnglishLanguageExamDescriptor table of the EnglishLanguageExamDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEnglishLanguageExamDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EnglishLanguageExamDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.Evaluation table of the Evaluation aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        int? EvaluationTypeDescriptorId { get; set; }
        Guid Id { get; set; }
        int? InterRaterReliabilityScore { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationElement table of the EvaluationElement aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationElementRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        int? EvaluationTypeDescriptorId { get; set; }
        Guid Id { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int? SortOrder { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationElementRating table of the EvaluationElementRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationElementRatingRecord
    {     
        // Properties for all columns in physical table
        string AreaOfRefinement { get; set; }
        string AreaOfReinforcement { get; set; }
        string Comments { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        int? EvaluationElementRatingLevelDescriptorId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string Feedback { get; set; }
        Guid Id { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationElementRatingLevel table of the EvaluationElement aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationElementRatingLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        int EvaluationRatingLevelDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationElementRatingLevelDescriptor table of the EvaluationElementRatingLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationElementRatingLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EvaluationElementRatingLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationElementRatingResult table of the EvaluationElementRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationElementRatingResultRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        decimal Rating { get; set; }
        string RatingResultTitle { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationObjective table of the EvaluationObjective aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationObjectiveRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        int? EvaluationTypeDescriptorId { get; set; }
        Guid Id { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int? SortOrder { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationObjectiveRating table of the EvaluationObjectiveRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationObjectiveRatingRecord
    {     
        // Properties for all columns in physical table
        string Comments { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        Guid Id { get; set; }
        int? ObjectiveRatingLevelDescriptorId { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationObjectiveRatingLevel table of the EvaluationObjective aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationObjectiveRatingLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        int EvaluationRatingLevelDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationObjectiveRatingResult table of the EvaluationObjectiveRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationObjectiveRatingResultRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        decimal Rating { get; set; }
        string RatingResultTitle { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationPeriodDescriptor table of the EvaluationPeriodDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationPeriodDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EvaluationPeriodDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationRating table of the EvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationRatingRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        int? EvaluationRatingLevelDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        int? SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationRatingLevel table of the Evaluation aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationRatingLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        int EvaluationRatingLevelDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationRatingLevelDescriptor table of the EvaluationRatingLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationRatingLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EvaluationRatingLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationRatingResult table of the EvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationRatingResultRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        decimal Rating { get; set; }
        string RatingResultTitle { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationRatingReviewer table of the EvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationRatingReviewerRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string FirstName { get; set; }
        string LastSurname { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        string ReviewerPersonId { get; set; }
        int? ReviewerSourceSystemDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationRatingReviewerReceivedTraining table of the EvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationRatingReviewerReceivedTrainingRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string FirstName { get; set; }
        int? InterRaterReliabilityScore { get; set; }
        string LastSurname { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EvaluationTypeDescriptor table of the EvaluationTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IEvaluationTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int EvaluationTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.FederalLocaleCodeDescriptor table of the FederalLocaleCodeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IFederalLocaleCodeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int FederalLocaleCodeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.FieldworkExperience table of the FieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface IFieldworkExperienceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int FieldworkTypeDescriptorId { get; set; }
        decimal? HoursCompleted { get; set; }
        Guid Id { get; set; }
        int? ProgramGatewayDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.FieldworkExperienceCoteaching table of the FieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface IFieldworkExperienceCoteachingRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime CoteachingBeginDate { get; set; }
        DateTime? CoteachingEndDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.FieldworkExperienceSchool table of the FieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface IFieldworkExperienceSchoolRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.FieldworkExperienceSectionAssociation table of the FieldworkExperienceSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IFieldworkExperienceSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string FieldworkIdentifier { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.FieldworkTypeDescriptor table of the FieldworkTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IFieldworkTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int FieldworkTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.FundingSourceDescriptor table of the FundingSourceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IFundingSourceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int FundingSourceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.GenderDescriptor table of the GenderDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGenderDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GenderDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.Goal table of the Goal aggregate in the Ods Database.
    /// </summary>
    public interface IGoalRecord
    {     
        // Properties for all columns in physical table
        DateTime AssignmentDate { get; set; }
        string Comments { get; set; }
        DateTime? CompletedDate { get; set; }
        bool? CompletedIndicator { get; set; }
        DateTime? DueDate { get; set; }
        int? EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int? EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string GoalDescription { get; set; }
        string GoalTitle { get; set; }
        int? GoalTypeDescriptorId { get; set; }
        Guid Id { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int? PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        short? SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int? TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.GoalTypeDescriptor table of the GoalTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IGoalTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int GoalTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.GraduationPlanRequiredCertification table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    public interface IGraduationPlanRequiredCertificationRecord
    {     
        // Properties for all columns in physical table
        string CertificationIdentifier { get; set; }
        int? CertificationRouteDescriptorId { get; set; }
        string CertificationTitle { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        string Namespace { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.HireStatusDescriptor table of the HireStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IHireStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int HireStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.HiringSourceDescriptor table of the HiringSourceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IHiringSourceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int HiringSourceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.InstructionalSettingDescriptor table of the InstructionalSettingDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IInstructionalSettingDescriptorRecord
    {     
        // Properties for all columns in physical table
        int InstructionalSettingDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.InternalExternalHireDescriptor table of the InternalExternalHireDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IInternalExternalHireDescriptorRecord
    {     
        // Properties for all columns in physical table
        int InternalExternalHireDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.LevelOfDegreeAwardedDescriptor table of the LevelOfDegreeAwardedDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILevelOfDegreeAwardedDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LevelOfDegreeAwardedDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.LocalEducationAgencyExtension table of the LocalEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface ILocalEducationAgencyExtensionRecord
    {     
        // Properties for all columns in physical table
        int? FederalLocaleCodeDescriptorId { get; set; }
        int LocalEducationAgencyId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ObjectiveRatingLevelDescriptor table of the ObjectiveRatingLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IObjectiveRatingLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ObjectiveRatingLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.OpenStaffPositionEvent table of the OpenStaffPositionEvent aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionEventRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EventDate { get; set; }
        Guid Id { get; set; }
        int? OpenStaffPositionEventStatusDescriptorId { get; set; }
        int OpenStaffPositionEventTypeDescriptorId { get; set; }
        string RequisitionNumber { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.OpenStaffPositionEventStatusDescriptor table of the OpenStaffPositionEventStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionEventStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int OpenStaffPositionEventStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.OpenStaffPositionEventTypeDescriptor table of the OpenStaffPositionEventTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionEventTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int OpenStaffPositionEventTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.OpenStaffPositionExtension table of the OpenStaffPosition aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionExtensionRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        decimal? FullTimeEquivalency { get; set; }
        int? FundingSourceDescriptorId { get; set; }
        bool? HighNeedAcademicSubject { get; set; }
        bool? IsActive { get; set; }
        decimal? MaxSalary { get; set; }
        decimal? MinSalary { get; set; }
        int? OpenStaffPositionReasonDescriptorId { get; set; }
        string PositionControlNumber { get; set; }
        string RequisitionNumber { get; set; }
        short? SchoolYear { get; set; }
        int? TermDescriptorId { get; set; }
        decimal? TotalBudgeted { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.OpenStaffPositionReasonDescriptor table of the OpenStaffPositionReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IOpenStaffPositionReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int OpenStaffPositionReasonDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluation table of the PerformanceEvaluation aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        Guid Id { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationGradeLevel table of the PerformanceEvaluation aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationProgramGateway table of the PerformanceEvaluation aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationProgramGatewayRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        int ProgramGatewayDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationRating table of the PerformanceEvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationRatingRecord
    {     
        // Properties for all columns in physical table
        DateTime ActualDate { get; set; }
        int? ActualDuration { get; set; }
        TimeSpan? ActualTime { get; set; }
        bool? Announced { get; set; }
        string Comments { get; set; }
        int? CoteachingStyleObservedDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        Guid Id { get; set; }
        int? PerformanceEvaluationRatingLevelDescriptorId { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        DateTime? ScheduleDate { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationRatingLevel table of the PerformanceEvaluation aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        int EvaluationRatingLevelDescriptorId { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationRatingLevelDescriptor table of the PerformanceEvaluationRatingLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PerformanceEvaluationRatingLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationRatingResult table of the PerformanceEvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationRatingResultRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        decimal Rating { get; set; }
        string RatingResultTitle { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationRatingReviewer table of the PerformanceEvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewerRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string FirstName { get; set; }
        string LastSurname { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        string ReviewerPersonId { get; set; }
        int? ReviewerSourceSystemDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationRatingReviewerReceivedTraining table of the PerformanceEvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewerReceivedTrainingRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string FirstName { get; set; }
        int? InterRaterReliabilityScore { get; set; }
        string LastSurname { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }
        short SchoolYear { get; set; }
        int SourceSystemDescriptorId { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceEvaluationTypeDescriptor table of the PerformanceEvaluationTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceEvaluationTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PerformanceEvaluationTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PostSecondaryInstitutionExtension table of the PostSecondaryInstitution aggregate in the Ods Database.
    /// </summary>
    public interface IPostSecondaryInstitutionExtensionRecord
    {     
        // Properties for all columns in physical table
        int? FederalLocaleCodeDescriptorId { get; set; }
        int PostSecondaryInstitutionId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PreviousCareerDescriptor table of the PreviousCareerDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPreviousCareerDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PreviousCareerDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProfessionalDevelopmentEvent table of the ProfessionalDevelopmentEvent aggregate in the Ods Database.
    /// </summary>
    public interface IProfessionalDevelopmentEventRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        bool? MultipleSession { get; set; }
        string Namespace { get; set; }
        int ProfessionalDevelopmentOfferedByDescriptorId { get; set; }
        string ProfessionalDevelopmentReason { get; set; }
        string ProfessionalDevelopmentTitle { get; set; }
        bool? Required { get; set; }
        int? TotalHours { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProfessionalDevelopmentEventAttendance table of the ProfessionalDevelopmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    public interface IProfessionalDevelopmentEventAttendanceRecord
    {     
        // Properties for all columns in physical table
        DateTime AttendanceDate { get; set; }
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        string PersonId { get; set; }
        string ProfessionalDevelopmentTitle { get; set; }
        int SourceSystemDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProfessionalDevelopmentOfferedByDescriptor table of the ProfessionalDevelopmentOfferedByDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProfessionalDevelopmentOfferedByDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProfessionalDevelopmentOfferedByDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProgramGatewayDescriptor table of the ProgramGatewayDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProgramGatewayDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProgramGatewayDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.Prospect table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectRecord
    {     
        // Properties for all columns in physical table
        bool? Applied { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        int EducationOrganizationId { get; set; }
        string ElectronicMailAddress { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        int? GenderDescriptorId { get; set; }
        string GenerationCodeSuffix { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        string MaidenName { get; set; }
        bool? Met { get; set; }
        string MiddleName { get; set; }
        string Notes { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        int? PreScreeningRating { get; set; }
        string ProspectIdentifier { get; set; }
        int? ProspectTypeDescriptorId { get; set; }
        bool? Referral { get; set; }
        string ReferredBy { get; set; }
        int? SexDescriptorId { get; set; }
        string SocialMediaNetworkName { get; set; }
        string SocialMediaUserName { get; set; }
        int? SourceSystemDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectAid table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectAidRecord
    {     
        // Properties for all columns in physical table
        decimal? AidAmount { get; set; }
        string AidConditionDescription { get; set; }
        int AidTypeDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        bool? PellGrantRecipient { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectCurrentPosition table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectCurrentPositionRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string Location { get; set; }
        string NameOfInstitution { get; set; }
        string PositionTitle { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectCurrentPositionGradeLevel table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectCurrentPositionGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectDisability table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectDisabilityRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        int? DisabilityDeterminationSourceTypeDescriptorId { get; set; }
        string DisabilityDiagnosis { get; set; }
        int EducationOrganizationId { get; set; }
        int? OrderOfDisability { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectDisabilityDesignation table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectDisabilityDesignationRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        int DisabilityDesignationDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectPersonalIdentificationDocument table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectPersonalIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int EducationOrganizationId { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectQualifications table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectQualificationsRecord
    {     
        // Properties for all columns in physical table
        bool? CapacityToServe { get; set; }
        int EducationOrganizationId { get; set; }
        bool Eligible { get; set; }
        string ProspectIdentifier { get; set; }
        decimal? YearsOfServiceCurrentPlacement { get; set; }
        decimal YearsOfServiceTotal { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectRace table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectRaceRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string ProspectIdentifier { get; set; }
        int RaceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectRecruitmentEvent table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectRecruitmentEventRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EventDate { get; set; }
        string EventTitle { get; set; }
        string ProspectIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectTelephone table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectTelephoneRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        int? OrderOfPriority { get; set; }
        string ProspectIdentifier { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectTouchpoint table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectTouchpointRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string ProspectIdentifier { get; set; }
        string TouchpointContent { get; set; }
        DateTime TouchpointDate { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ProspectTypeDescriptor table of the ProspectTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IProspectTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ProspectTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.QuantitativeMeasure table of the QuantitativeMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IQuantitativeMeasureRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        Guid Id { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        int? QuantitativeMeasureDatatypeDescriptorId { get; set; }
        string QuantitativeMeasureIdentifier { get; set; }
        int? QuantitativeMeasureTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.QuantitativeMeasureDatatypeDescriptor table of the QuantitativeMeasureDatatypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IQuantitativeMeasureDatatypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int QuantitativeMeasureDatatypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.QuantitativeMeasureScore table of the QuantitativeMeasureScore aggregate in the Ods Database.
    /// </summary>
    public interface IQuantitativeMeasureScoreRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        Guid Id { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        string QuantitativeMeasureIdentifier { get; set; }
        short SchoolYear { get; set; }
        decimal ScoreValue { get; set; }
        int SourceSystemDescriptorId { get; set; }
        decimal? StandardError { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.QuantitativeMeasureTypeDescriptor table of the QuantitativeMeasureTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IQuantitativeMeasureTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int QuantitativeMeasureTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RecruitmentEvent table of the RecruitmentEvent aggregate in the Ods Database.
    /// </summary>
    public interface IRecruitmentEventRecord
    {     
        // Properties for all columns in physical table
        DateTime EventDate { get; set; }
        string EventDescription { get; set; }
        string EventLocation { get; set; }
        string EventTitle { get; set; }
        Guid Id { get; set; }
        int RecruitmentEventTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RecruitmentEventTypeDescriptor table of the RecruitmentEventTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRecruitmentEventTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RecruitmentEventTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricDimension table of the RubricDimension aggregate in the Ods Database.
    /// </summary>
    public interface IRubricDimensionRecord
    {     
        // Properties for all columns in physical table
        string CriterionDescription { get; set; }
        int? DimensionOrder { get; set; }
        int EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        Guid Id { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        int RubricRating { get; set; }
        int? RubricRatingLevelDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricRatingLevelDescriptor table of the RubricRatingLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRubricRatingLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RubricRatingLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SalaryTypeDescriptor table of the SalaryTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISalaryTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SalaryTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SchoolExtension table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolExtensionRecord
    {     
        // Properties for all columns in physical table
        int? FederalLocaleCodeDescriptorId { get; set; }
        bool? ImprovingSchool { get; set; }
        int SchoolId { get; set; }
        int? SchoolStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SchoolStatusDescriptor table of the SchoolStatusDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolStatusDescriptorRecord
    {     
        // Properties for all columns in physical table
        int SchoolStatusDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffApplicantAssociation table of the StaffApplicantAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffApplicantAssociationRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        Guid Id { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffBackgroundCheck table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffBackgroundCheckRecord
    {     
        // Properties for all columns in physical table
        DateTime? BackgroundCheckCompletedDate { get; set; }
        DateTime BackgroundCheckRequestedDate { get; set; }
        int? BackgroundCheckStatusDescriptorId { get; set; }
        int BackgroundCheckTypeDescriptorId { get; set; }
        bool? Fingerprint { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEducationOrganizationAssignmentAssociationExtension table of the StaffEducationOrganizationAssignmentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEducationOrganizationAssignmentAssociationExtensionRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int StaffClassificationDescriptorId { get; set; }
        int StaffUSI { get; set; }
        decimal? YearsOfExperienceAtCurrentEducationOrganization { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffExtension table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffExtensionRecord
    {     
        // Properties for all columns in physical table
        int? GenderDescriptorId { get; set; }
        DateTime? ProbationCompleteDate { get; set; }
        int StaffUSI { get; set; }
        bool? Tenured { get; set; }
        bool? TenureTrack { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffHighlyQualifiedAcademicSubject table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffHighlyQualifiedAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffProspectAssociation table of the StaffProspectAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffProspectAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string ProspectIdentifier { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffSalary table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffSalaryRecord
    {     
        // Properties for all columns in physical table
        decimal? SalaryAmount { get; set; }
        int? SalaryMaxRange { get; set; }
        int? SalaryMinRange { get; set; }
        int? SalaryTypeDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffSeniority table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffSeniorityRecord
    {     
        // Properties for all columns in physical table
        int CredentialFieldDescriptorId { get; set; }
        string NameOfInstitution { get; set; }
        int StaffUSI { get; set; }
        decimal YearsExperience { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffStudentGrowthMeasure table of the StaffStudentGrowthMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IStaffStudentGrowthMeasureRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        int StaffUSI { get; set; }
        decimal? StandardError { get; set; }
        int StudentGrowthActualScore { get; set; }
        DateTime? StudentGrowthMeasureDate { get; set; }
        bool StudentGrowthMet { get; set; }
        int? StudentGrowthNCount { get; set; }
        int? StudentGrowthTargetScore { get; set; }
        int? StudentGrowthTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffStudentGrowthMeasureAcademicSubject table of the StaffStudentGrowthMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IStaffStudentGrowthMeasureAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        DateTime FactAsOfDate { get; set; }
        short SchoolYear { get; set; }
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffStudentGrowthMeasureCourseAssociation table of the StaffStudentGrowthMeasureCourseAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffStudentGrowthMeasureCourseAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation table of the StaffStudentGrowthMeasureEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffStudentGrowthMeasureEducationOrganizationAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffStudentGrowthMeasureGradeLevel table of the StaffStudentGrowthMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IStaffStudentGrowthMeasureGradeLevelRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        int GradeLevelDescriptorId { get; set; }
        short SchoolYear { get; set; }
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffStudentGrowthMeasureSectionAssociation table of the StaffStudentGrowthMeasureSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffStudentGrowthMeasureSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        string StaffStudentGrowthMeasureIdentifier { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffTeacherEducatorResearch table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTeacherEducatorResearchRecord
    {     
        // Properties for all columns in physical table
        DateTime ResearchExperienceDate { get; set; }
        string ResearchExperienceDescription { get; set; }
        string ResearchExperienceTitle { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffTeacherPreparationProgram table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTeacherPreparationProgramRecord
    {     
        // Properties for all columns in physical table
        decimal? GPA { get; set; }
        int LevelOfDegreeAwardedDescriptorId { get; set; }
        string MajorSpecialization { get; set; }
        string NameOfInstitution { get; set; }
        int StaffUSI { get; set; }
        string TeacherPreparationProgramIdentifier { get; set; }
        string TeacherPreparationProgramName { get; set; }
        int TeacherPreparationProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffTeacherPreparationProviderAssociation table of the StaffTeacherPreparationProviderAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTeacherPreparationProviderAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        int ProgramAssignmentDescriptorId { get; set; }
        short SchoolYear { get; set; }
        int StaffUSI { get; set; }
        int TeacherPreparationProviderId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject table of the StaffTeacherPreparationProviderAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTeacherPreparationProviderAssociationAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int StaffUSI { get; set; }
        int TeacherPreparationProviderId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffTeacherPreparationProviderAssociationGradeLevel table of the StaffTeacherPreparationProviderAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTeacherPreparationProviderAssociationGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        int StaffUSI { get; set; }
        int TeacherPreparationProviderId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffTeacherPreparationProviderProgramAssociation table of the StaffTeacherPreparationProviderProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffTeacherPreparationProviderProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StaffUSI { get; set; }
        bool? StudentRecordAccess { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StateEducationAgencyExtension table of the StateEducationAgency aggregate in the Ods Database.
    /// </summary>
    public interface IStateEducationAgencyExtensionRecord
    {     
        // Properties for all columns in physical table
        int? FederalLocaleCodeDescriptorId { get; set; }
        int StateEducationAgencyId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StudentGradebookEntryExtension table of the StudentGradebookEntry aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGradebookEntryExtensionRecord
    {     
        // Properties for all columns in physical table
        bool? AssignmentPassed { get; set; }
        DateTime BeginDate { get; set; }
        DateTime DateAssigned { get; set; }
        DateTime? DateCompleted { get; set; }
        string GradebookEntryTitle { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StudentGrowthTypeDescriptor table of the StudentGrowthTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGrowthTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StudentGrowthTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SurveyResponseExtension table of the SurveyResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyResponseExtensionRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SurveyResponseTeacherCandidateTargetAssociation table of the SurveyResponseTeacherCandidateTargetAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveyResponseTeacherCandidateTargetAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SurveySectionAggregateResponse table of the SurveySectionAggregateResponse aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionAggregateResponseRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime EvaluationDate { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        Guid Id { get; set; }
        string Namespace { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int PerformanceEvaluationTypeDescriptorId { get; set; }
        string PersonId { get; set; }
        short SchoolYear { get; set; }
        decimal ScoreValue { get; set; }
        int SourceSystemDescriptorId { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SurveySectionExtension table of the SurveySection aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionExtensionRecord
    {     
        // Properties for all columns in physical table
        int? EducationOrganizationId { get; set; }
        string EvaluationElementTitle { get; set; }
        string EvaluationObjectiveTitle { get; set; }
        int? EvaluationPeriodDescriptorId { get; set; }
        string EvaluationTitle { get; set; }
        string Namespace { get; set; }
        string PerformanceEvaluationTitle { get; set; }
        int? PerformanceEvaluationTypeDescriptorId { get; set; }
        short? SchoolYear { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
        int? TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SurveySectionResponseTeacherCandidateTargetAssociation table of the SurveySectionResponseTeacherCandidateTargetAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ISurveySectionResponseTeacherCandidateTargetAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string Namespace { get; set; }
        string SurveyIdentifier { get; set; }
        string SurveyResponseIdentifier { get; set; }
        string SurveySectionTitle { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidate table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateRecord
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
        string DisplacementStatus { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        int? EnglishLanguageExamDescriptorId { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        int? GenderDescriptorId { get; set; }
        string GenerationCodeSuffix { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        int? LimitedEnglishProficiencyDescriptorId { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        bool? MultipleBirthStatus { get; set; }
        int? OldEthnicityDescriptorId { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        int? PreviousCareerDescriptorId { get; set; }
        string ProfileThumbnail { get; set; }
        bool? ProgramComplete { get; set; }
        int SexDescriptorId { get; set; }
        int? SourceSystemDescriptorId { get; set; }
        int StudentUSI { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        decimal? TuitionCost { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAcademicRecord table of the TeacherCandidateAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordRecord
    {     
        // Properties for all columns in physical table
        decimal? ContentGradePointAverage { get; set; }
        decimal? ContentGradePointEarned { get; set; }
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
        int ProgramGatewayDescriptorId { get; set; }
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
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
        int TPPDegreeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAcademicRecordAcademicHonor table of the TeacherCandidateAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordAcademicHonorRecord
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
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAcademicRecordClassRanking table of the TeacherCandidateAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordClassRankingRecord
    {     
        // Properties for all columns in physical table
        int ClassRank { get; set; }
        DateTime? ClassRankingDate { get; set; }
        int EducationOrganizationId { get; set; }
        int? PercentageRanking { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
        int TotalNumberInClass { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAcademicRecordDiploma table of the TeacherCandidateAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordDiplomaRecord
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
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAcademicRecordGradePointAverage table of the TeacherCandidateAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradePointAverageTypeDescriptorId { get; set; }
        decimal GradePointAverageValue { get; set; }
        bool? IsCumulative { get; set; }
        decimal? MaxGradePointAverageValue { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAcademicRecordRecognition table of the TeacherCandidateAcademicRecord aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAcademicRecordRecognitionRecord
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
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAddress table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAddressRecord
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
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAddressPeriod table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        string City { get; set; }
        DateTime? EndDate { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateAid table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateAidRecord
    {     
        // Properties for all columns in physical table
        decimal? AidAmount { get; set; }
        string AidConditionDescription { get; set; }
        int AidTypeDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        bool? PellGrantRecipient { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateBackgroundCheck table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateBackgroundCheckRecord
    {     
        // Properties for all columns in physical table
        DateTime? BackgroundCheckCompletedDate { get; set; }
        DateTime BackgroundCheckRequestedDate { get; set; }
        int? BackgroundCheckStatusDescriptorId { get; set; }
        int BackgroundCheckTypeDescriptorId { get; set; }
        bool? Fingerprint { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateCharacteristic table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateCharacteristicRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        DateTime? EndDate { get; set; }
        int StudentCharacteristicDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateCharacteristicDescriptor table of the TeacherCandidateCharacteristicDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateCharacteristicDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TeacherCandidateCharacteristicDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateCohortYear table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateCohortYearRecord
    {     
        // Properties for all columns in physical table
        int CohortYearTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateCourseTranscript table of the TeacherCandidateCourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateCourseTranscriptRecord
    {     
        // Properties for all columns in physical table
        string AlternativeCourseCode { get; set; }
        string AlternativeCourseTitle { get; set; }
        decimal? AttemptedCreditConversion { get; set; }
        decimal? AttemptedCredits { get; set; }
        int? AttemptedCreditTypeDescriptorId { get; set; }
        int CourseAttemptResultDescriptorId { get; set; }
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        int? CourseRepeatCodeDescriptorId { get; set; }
        string CourseTitle { get; set; }
        decimal? EarnedCreditConversion { get; set; }
        decimal EarnedCredits { get; set; }
        int? EarnedCreditTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string FinalLetterGradeEarned { get; set; }
        decimal? FinalNumericGradeEarned { get; set; }
        Guid Id { get; set; }
        int? MethodCreditEarnedDescriptorId { get; set; }
        int? SchoolId { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
        int? WhenTakenGradeLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits table of the TeacherCandidateCourseTranscript aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateCourseTranscriptEarnedAdditionalCreditsRecord
    {     
        // Properties for all columns in physical table
        int AdditionalCreditTypeDescriptorId { get; set; }
        int CourseAttemptResultDescriptorId { get; set; }
        string CourseCode { get; set; }
        int CourseEducationOrganizationId { get; set; }
        decimal Credits { get; set; }
        int EducationOrganizationId { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateDegreeSpecialization table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateDegreeSpecializationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string MajorSpecialization { get; set; }
        string MinorSpecialization { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateDisability table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateDisabilityRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        int? DisabilityDeterminationSourceTypeDescriptorId { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateDisabilityDesignation table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateDisabilityDesignationRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        int DisabilityDesignationDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateElectronicMail table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateElectronicMailRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        string ElectronicMailAddress { get; set; }
        int ElectronicMailTypeDescriptorId { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateIdentificationCode table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string AssigningOrganizationIdentificationCode { get; set; }
        string IdentificationCode { get; set; }
        int StudentIdentificationSystemDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateIdentificationDocument table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateIndicator table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateIndicatorRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        string DesignatedBy { get; set; }
        DateTime? EndDate { get; set; }
        string Indicator { get; set; }
        string IndicatorGroup { get; set; }
        string IndicatorName { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateInternationalAddress table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateInternationalAddressRecord
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
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateLanguage table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateLanguageRecord
    {     
        // Properties for all columns in physical table
        int LanguageDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateLanguageUse table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateLanguageUseRecord
    {     
        // Properties for all columns in physical table
        int LanguageDescriptorId { get; set; }
        int LanguageUseDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateOtherName table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateOtherNameRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string MiddleName { get; set; }
        int OtherNameTypeDescriptorId { get; set; }
        string PersonalTitlePrefix { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidatePersonalIdentificationDocument table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidatePersonalIdentificationDocumentRecord
    {     
        // Properties for all columns in physical table
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        int IdentificationDocumentUseDescriptorId { get; set; }
        int? IssuerCountryDescriptorId { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }
        int PersonalInformationVerificationDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateRace table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateRaceRecord
    {     
        // Properties for all columns in physical table
        int RaceDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateStaffAssociation table of the TeacherCandidateStaffAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateStaffAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        int StaffUSI { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateStudentGrowthMeasure table of the TeacherCandidateStudentGrowthMeasure aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        int? ResultDatatypeTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
        decimal? StandardError { get; set; }
        int StudentGrowthActualScore { get; set; }
        DateTime? StudentGrowthMeasureDate { get; set; }
        bool StudentGrowthMet { get; set; }
        int? StudentGrowthNCount { get; set; }
        int? StudentGrowthTargetScore { get; set; }
        int? StudentGrowthTypeDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject table of the TeacherCandidateStudentGrowthMeasure aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        DateTime FactAsOfDate { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation table of the TeacherCandidateStudentGrowthMeasureCourseAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureCourseAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation table of the TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel table of the TeacherCandidateStudentGrowthMeasure aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureGradeLevelRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        int GradeLevelDescriptorId { get; set; }
        short SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation table of the TeacherCandidateStudentGrowthMeasureSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateStudentGrowthMeasureSectionAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateTeacherPreparationProviderAssociation table of the TeacherCandidateTeacherPreparationProviderAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateTeacherPreparationProviderAssociationRecord
    {     
        // Properties for all columns in physical table
        short? ClassOfSchoolYear { get; set; }
        DateTime EntryDate { get; set; }
        int? EntryTypeDescriptorId { get; set; }
        DateTime? ExitWithdrawDate { get; set; }
        int? ExitWithdrawTypeDescriptorId { get; set; }
        Guid Id { get; set; }
        short? SchoolYear { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        int TeacherPreparationProviderId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation table of the TeacherCandidateTeacherPreparationProviderProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateTeacherPreparationProviderProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        Guid Id { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int? ReasonExitedDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateTelephone table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateTelephoneRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateTPPProgramDegree table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateTPPProgramDegreeRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        int TPPDegreeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateVisa table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateVisaRecord
    {     
        // Properties for all columns in physical table
        string TeacherCandidateIdentifier { get; set; }
        int VisaDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherPreparationProgramTypeDescriptor table of the TeacherPreparationProgramTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherPreparationProgramTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TeacherPreparationProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherPreparationProvider table of the TeacherPreparationProvider aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherPreparationProviderRecord
    {     
        // Properties for all columns in physical table
        int? AccreditationStatusDescriptorId { get; set; }
        int? FederalLocaleCodeDescriptorId { get; set; }
        int? SchoolId { get; set; }
        int TeacherPreparationProviderId { get; set; }
        int? UniversityId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherPreparationProviderProgram table of the TeacherPreparationProviderProgram aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherPreparationProviderProgramRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string MajorSpecialization { get; set; }
        string MinorSpecialization { get; set; }
        string ProgramId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int? TeacherPreparationProgramTypeDescriptorId { get; set; }
        int? TPPProgramPathwayDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherPreparationProviderProgramGradeLevel table of the TeacherPreparationProviderProgram aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherPreparationProviderProgramGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TPPDegreeTypeDescriptor table of the TPPDegreeTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITPPDegreeTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TPPDegreeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TPPProgramPathwayDescriptor table of the TPPProgramPathwayDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ITPPProgramPathwayDescriptorRecord
    {     
        // Properties for all columns in physical table
        int TPPProgramPathwayDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.University table of the University aggregate in the Ods Database.
    /// </summary>
    public interface IUniversityRecord
    {     
        // Properties for all columns in physical table
        int? FederalLocaleCodeDescriptorId { get; set; }
        int? SchoolId { get; set; }
        int UniversityId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ValueTypeDescriptor table of the ValueTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IValueTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.WithdrawReasonDescriptor table of the WithdrawReasonDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IWithdrawReasonDescriptorRecord
    {     
        // Properties for all columns in physical table
        int WithdrawReasonDescriptorId { get; set; }
    }
}

