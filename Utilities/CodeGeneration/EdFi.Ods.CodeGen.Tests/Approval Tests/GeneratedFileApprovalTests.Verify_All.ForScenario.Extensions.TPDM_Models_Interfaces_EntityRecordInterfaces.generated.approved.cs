using System;


namespace EdFi.Ods.Entities.Common.Records.TPDM
{ 

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
        int EducationOrganizationId { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        int? GenderDescriptorId { get; set; }
        string GenerationCodeSuffix { get; set; }
        int? HighestCompletedLevelOfEducationDescriptorId { get; set; }
        int? HighlyQualifiedAcademicSubjectDescriptorId { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        int? SexDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }
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
    /// Interface for the tpdm.ApplicantAddressPeriod table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantAddressPeriodRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApplicantIdentifier { get; set; }
        DateTime BeginDate { get; set; }
        string City { get; set; }
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        int StudentCharacteristicDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantCredential table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantCredentialRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string CredentialIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantElectronicMail table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantElectronicMailRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        string ElectronicMailAddress { get; set; }
        int ElectronicMailTypeDescriptorId { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantGradePointAverage table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        int GradePointAverageTypeDescriptorId { get; set; }
        decimal GradePointAverageValue { get; set; }
        bool? IsCumulative { get; set; }
        decimal? MaxGradePointAverageValue { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
        int LanguageDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantLanguageUse table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantLanguageUseRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
        int RaceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantScoreResult table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantScoreResultRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int AssessmentReportingMethodDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string Result { get; set; }
        int ResultDatatypeTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.ApplicantStaffIdentificationCode table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantStaffIdentificationCodeRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        string AssigningOrganizationIdentificationCode { get; set; }
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int EducationOrganizationId { get; set; }
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
        int? HighNeedsAcademicSubjectDescriptorId { get; set; }
        int? HireStatusDescriptorId { get; set; }
        int? HiringSourceDescriptorId { get; set; }
        Guid Id { get; set; }
        DateTime? WithdrawDate { get; set; }
        int? WithdrawReasonDescriptorId { get; set; }
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
    /// Interface for the tpdm.BoardCertificationTypeDescriptor table of the BoardCertificationTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IBoardCertificationTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int BoardCertificationTypeDescriptorId { get; set; }
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
    /// Interface for the tpdm.CommunityOrganizationExtension table of the CommunityOrganization aggregate in the Ods Database.
    /// </summary>
    public interface ICommunityOrganizationExtensionRecord
    {     
        // Properties for all columns in physical table
        int CommunityOrganizationId { get; set; }
        int? FederalLocaleCodeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CommunityProviderExtension table of the CommunityProvider aggregate in the Ods Database.
    /// </summary>
    public interface ICommunityProviderExtensionRecord
    {     
        // Properties for all columns in physical table
        int CommunityProviderId { get; set; }
        int? FederalLocaleCodeDescriptorId { get; set; }
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
    /// Interface for the tpdm.CourseCourseTranscriptFacts table of the CourseCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseCourseTranscriptFactsRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        string CourseTitle { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseCourseTranscriptFactsAggregatedFinalLetterGradeEarned table of the CourseCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseCourseTranscriptFactsAggregatedFinalLetterGradeEarnedRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        string FinalLetterGrade { get; set; }
        int? LetterGradeTypeNumber { get; set; }
        decimal? LetterGradeTypePercentage { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseCourseTranscriptFactsAggregatedNumericGradeEarned table of the CourseCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseCourseTranscriptFactsAggregatedNumericGradeEarnedRecord
    {     
        // Properties for all columns in physical table
        decimal AverageFinalNumericGradeEarned { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? NumericGradeNCount { get; set; }
        int? NumericGradeStandardDeviation { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseCourseTranscriptFactsStudentsEnrolled table of the CourseCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseCourseTranscriptFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAcademicRecordFacts table of the CourseStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAcademicRecordFactsRecord
    {     
        // Properties for all columns in physical table
        decimal? AggregatedGPAMax { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage table of the CourseStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAcademicRecordFactsAggregatedCumulativeGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAcademicRecordFactsAggregatedSessionGradePointAverage table of the CourseStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAcademicRecordFactsAggregatedSessionGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAcademicRecordFactsStudentsEnrolled table of the CourseStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAcademicRecordFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAssessmentFacts table of the CourseStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAssessmentFactsRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        DateTime? AdministrationDate { get; set; }
        int? AssessmentCategoryDescriptorId { get; set; }
        string AssessmentTitle { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? GradeLevelDescriptorId { get; set; }
        Guid Id { get; set; }
        short TakenSchoolYear { get; set; }
        int? TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAssessmentFactsAggregatedPerformanceLevel table of the CourseStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAssessmentFactsAggregatedPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        int? PerformanceLevelMetNumber { get; set; }
        decimal? PerformanceLevelMetPercentage { get; set; }
        int? PerformanceLevelTypeNumber { get; set; }
        decimal? PerformanceLevelTypePercentage { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAssessmentFactsAggregatedScoreResult table of the CourseStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAssessmentFactsAggregatedScoreResultRecord
    {     
        // Properties for all columns in physical table
        int AssessmentReportingMethodDescriptorId { get; set; }
        string AverageScoreResult { get; set; }
        int AverageScoreResultDatatypeTypeDescriptorId { get; set; }
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? ScoreNCount { get; set; }
        int? ScoreStandardDeviation { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentAssessmentFactsStudentsEnrolled table of the CourseStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentAssessmentFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        short TakenSchoolYear { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFacts table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedByDisability table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedByDisabilityRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int DisabilityDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        decimal? Percentage { get; set; }
        int? TypeNumber { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedDisabilityTotalStudentsDisabled table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedDisabilityTotalStudentsDisabledRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? StudentsDisabledNumber { get; set; }
        decimal? StudentsDisabledPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedELLEnrollment table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedELLEnrollmentRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        int? ELLEnrollmentNumber { get; set; }
        decimal? ELLEnrollmentPercentage { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedESLEnrollment table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedESLEnrollmentRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        int? ESLEnrollmentNumber { get; set; }
        decimal? ESLEnrollmentPercentage { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedGender table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedGenderRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int GenderDescriptorId { get; set; }
        int? GenderTypeNumber { get; set; }
        decimal? GenderTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedHispanicLatinoEthnicity table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedHispanicLatinoEthnicityRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        bool HispanicLatinoEthnicity { get; set; }
        int? HispanicLatinoEthnicityNumber { get; set; }
        decimal? HispanicLatinoEthnicityPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedLanguage table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedLanguageRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int LanguageDescriptorId { get; set; }
        int? LanguageTypeNumber { get; set; }
        decimal? LanguageTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedRace table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedRaceRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int RaceDescriptorId { get; set; }
        int? RaceTypeNumber { get; set; }
        decimal? RaceTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedSchoolFoodServiceProgramService table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSchoolFoodServiceProgramServiceRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int SchoolFoodServiceProgramServiceDescriptorId { get; set; }
        int? TypeNumber { get; set; }
        int? TypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedSection504Enrollment table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSection504EnrollmentRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? Number504Enrolled { get; set; }
        decimal? Percentage504Enrolled { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedSex table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSexRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int SexDescriptorId { get; set; }
        int? SexTypeNumber { get; set; }
        decimal? SexTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedSPED table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedSPEDRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? SPEDEnrollmentNumber { get; set; }
        decimal? SPEDEnrollmentPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsAggregatedTitleIEnrollment table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsAggregatedTitleIEnrollmentRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? TitleIEnrollmentNumber { get; set; }
        decimal? TitleIEnrollmentPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CourseStudentFactsStudentsEnrolled table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ICourseStudentFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialBoardCertification table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialBoardCertificationRecord
    {     
        // Properties for all columns in physical table
        bool? BoardCertification { get; set; }
        DateTime? BoardCertificationDate { get; set; }
        int BoardCertificationTypeDescriptorId { get; set; }
        string CredentialIdentifier { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialCertificationExam table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialCertificationExamRecord
    {     
        // Properties for all columns in physical table
        int? AttemptNumber { get; set; }
        DateTime CertificationExamDate { get; set; }
        int? CertificationExamOverallScore { get; set; }
        bool? CertificationExamPassFail { get; set; }
        int? CertificationExamStatusDescriptorId { get; set; }
        string CertificationExamTitle { get; set; }
        int? CertificationExamTypeDescriptorId { get; set; }
        string CredentialIdentifier { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialExtension table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialExtensionRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        bool? CurrentCredential { get; set; }
        DateTime? RevocationDate { get; set; }
        string RevocationReason { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
        DateTime? SuspensionDate { get; set; }
        string SuspensionReason { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialRecommendation table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialRecommendationRecord
    {     
        // Properties for all columns in physical table
        int? CredentialFieldDescriptorId { get; set; }
        string CredentialIdentifier { get; set; }
        int GradeLevelDescriptorId { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
        int TeachingCredentialDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.CredentialRecommendingInstitution table of the Credential aggregate in the Ods Database.
    /// </summary>
    public interface ICredentialRecommendingInstitutionRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        DateTime? RecommendingDate { get; set; }
        int? RecommendingInstitutionCountryDescriptorId { get; set; }
        int? RecommendingInstitutionStateAbbreviationDescriptorId { get; set; }
        string RecommendingInstutionName { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationCourseTranscriptFacts table of the EducationOrganizationCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFactsRecord
    {     
        // Properties for all columns in physical table
        string CourseTitle { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationCourseTranscriptFactsAggregatedFinalLetterGradeEarned table of the EducationOrganizationCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFactsAggregatedFinalLetterGradeEarnedRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        string FinalLetterGrade { get; set; }
        int? LetterGradeTypeNumber { get; set; }
        decimal? LetterGradeTypePercentage { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationCourseTranscriptFactsAggregatedNumericGradeEarned table of the EducationOrganizationCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFactsAggregatedNumericGradeEarnedRecord
    {     
        // Properties for all columns in physical table
        decimal AverageFinalNumericGradeEarned { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? NumericGradeNCount { get; set; }
        int? NumericGradeStandardDeviation { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationCourseTranscriptFactsStudentsEnrolled table of the EducationOrganizationCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationCourseTranscriptFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationFacts table of the EducationOrganizationFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationFactsRecord
    {     
        // Properties for all columns in physical table
        decimal? AverageYearsInDistrictEmployed { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        decimal? HiringRate { get; set; }
        Guid Id { get; set; }
        int? NumberAdministratorsEmployed { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        int? NumberTeachersEmployed { get; set; }
        decimal? PercentStudentsFreeReducedLunch { get; set; }
        decimal? PercentStudentsLimitedEnglishProficiency { get; set; }
        decimal? PercentStudentsSpecialEducation { get; set; }
        decimal? RetentionRate { get; set; }
        decimal? RetirementRate { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationFactsAggregatedSalary table of the EducationOrganizationFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationFactsAggregatedSalaryRecord
    {     
        // Properties for all columns in physical table
        decimal AverageSalary { get; set; }
        int? CountOfSalariesAveraged { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? SalaryMaxRange { get; set; }
        int? SalaryMinRange { get; set; }
        short SchoolYear { get; set; }
        int? StandardDeviation { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationFactsVacancies table of the EducationOrganizationFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationFactsVacanciesRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int NumberOfVacancies { get; set; }
        short SchoolYear { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationFactsVacanciesGradeLevel table of the EducationOrganizationFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationFactsVacanciesGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int GradeLevelDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationNetworkExtension table of the EducationOrganizationNetwork aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationNetworkExtensionRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationNetworkId { get; set; }
        int? FederalLocaleCodeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAcademicRecordFacts table of the EducationOrganizationStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFactsRecord
    {     
        // Properties for all columns in physical table
        decimal? AggregatedGPAMax { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage table of the EducationOrganizationStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFactsAggregatedCumulativeGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAcademicRecordFactsAggregatedSessionGradePointAverage table of the EducationOrganizationStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFactsAggregatedSessionGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAcademicRecordFactsStudentsEnrolled table of the EducationOrganizationStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAcademicRecordFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        short SchoolYear { get; set; }
        int TermDescriptorId { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAssessmentFacts table of the EducationOrganizationStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFactsRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        DateTime? AdministrationDate { get; set; }
        int? AssessmentCategoryDescriptorId { get; set; }
        string AssessmentTitle { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? GradeLevelDescriptorId { get; set; }
        Guid Id { get; set; }
        short TakenSchoolYear { get; set; }
        int? TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAssessmentFactsAggregatedPerformanceLevel table of the EducationOrganizationStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFactsAggregatedPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        int? PerformanceLevelMetNumber { get; set; }
        decimal? PerformanceLevelMetPercentage { get; set; }
        int? PerformanceLevelTypeNumber { get; set; }
        decimal? PerformanceLevelTypePercentage { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAssessmentFactsAggregatedScoreResult table of the EducationOrganizationStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFactsAggregatedScoreResultRecord
    {     
        // Properties for all columns in physical table
        int AssessmentReportingMethodDescriptorId { get; set; }
        string AverageScoreResult { get; set; }
        int AverageScoreResultDatatypeTypeDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? ScoreNCount { get; set; }
        int? ScoreStandardDeviation { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentAssessmentFactsStudentsEnrolled table of the EducationOrganizationStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentAssessmentFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        short TakenSchoolYear { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFacts table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedByDisability table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedByDisabilityRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        decimal? Percentage { get; set; }
        int? TypeNumber { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedDisabilityTotalStudentsDisabled table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedDisabilityTotalStudentsDisabledRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? StudentsDisabledNumber { get; set; }
        decimal? StudentsDisabledPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedELLEnrollment table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedELLEnrollmentRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int? ELLEnrollmentNumber { get; set; }
        decimal? ELLEnrollmentPercentage { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedESLEnrollment table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedESLEnrollmentRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int? ESLEnrollmentNumber { get; set; }
        decimal? ESLEnrollmentPercentage { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedGender table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedGenderRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int GenderDescriptorId { get; set; }
        int? GenderTypeNumber { get; set; }
        decimal? GenderTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedHispanicLatinoEthnicity table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedHispanicLatinoEthnicityRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        bool HispanicLatinoEthnicity { get; set; }
        int? HispanicLatinoEthnicityNumber { get; set; }
        decimal? HispanicLatinoEthnicityPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedLanguage table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedLanguageRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int LanguageDescriptorId { get; set; }
        int? LanguageTypeNumber { get; set; }
        decimal? LanguageTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedRace table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedRaceRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int RaceDescriptorId { get; set; }
        int? RaceTypeNumber { get; set; }
        decimal? RaceTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedSchoolFoodServiceProgramService table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSchoolFoodServiceProgramServiceRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int SchoolFoodServiceProgramServiceDescriptorId { get; set; }
        int? TypeNumber { get; set; }
        int? TypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedSection504Enrollment table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSection504EnrollmentRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? Number504Enrolled { get; set; }
        decimal? Percentage504Enrolled { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedSex table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSexRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int SexDescriptorId { get; set; }
        int? SexTypeNumber { get; set; }
        decimal? SexTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedSPED table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedSPEDRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? SPEDEnrollmentNumber { get; set; }
        decimal? SPEDEnrollmentPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsAggregatedTitleIEnrollment table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsAggregatedTitleIEnrollmentRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? TitleIEnrollmentNumber { get; set; }
        decimal? TitleIEnrollmentPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationOrganizationStudentFactsStudentsEnrolled table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface IEducationOrganizationStudentFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.EducationServiceCenterExtension table of the EducationServiceCenter aggregate in the Ods Database.
    /// </summary>
    public interface IEducationServiceCenterExtensionRecord
    {     
        // Properties for all columns in physical table
        int EducationServiceCenterId { get; set; }
        int? FederalLocaleCodeDescriptorId { get; set; }
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
    /// Interface for the tpdm.FederalLocaleCodeDescriptor table of the FederalLocaleCodeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IFederalLocaleCodeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int FederalLocaleCodeDescriptorId { get; set; }
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
    /// Interface for the tpdm.GradebookEntryExtension table of the GradebookEntry aggregate in the Ods Database.
    /// </summary>
    public interface IGradebookEntryExtensionRecord
    {     
        // Properties for all columns in physical table
        DateTime DateAssigned { get; set; }
        string GradebookEntryTitle { get; set; }
        string LocalCourseCode { get; set; }
        int? ProgramGatewayDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
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
    /// Interface for the tpdm.LevelTypeDescriptor table of the LevelTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface ILevelTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int LevelTypeDescriptorId { get; set; }
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
    /// Interface for the tpdm.PerformanceMeasure table of the PerformanceMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        DateTime ActualDateOfPerformanceMeasure { get; set; }
        bool? Announced { get; set; }
        string Comments { get; set; }
        int? CoteachingStyleObservedDescriptorId { get; set; }
        int? DurationOfPerformanceMeasure { get; set; }
        Guid Id { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
        int? PerformanceMeasureInstanceDescriptorId { get; set; }
        int PerformanceMeasureTypeDescriptorId { get; set; }
        DateTime? ScheduleDateOfPerformanceMeasure { get; set; }
        int TermDescriptorId { get; set; }
        TimeSpan? TimeOfPerformanceMeasure { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureCourseAssociation table of the PerformanceMeasureCourseAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureCourseAssociationRecord
    {     
        // Properties for all columns in physical table
        string CourseCode { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureFacts table of the PerformanceMeasureFacts aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureFactsRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        int PerformanceMeasureTypeDescriptorId { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureFactsGradeLevel table of the PerformanceMeasureFacts aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureFactsGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int GradeLevelDescriptorId { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureGradeLevel table of the PerformanceMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureGradeLevelRecord
    {     
        // Properties for all columns in physical table
        int GradeLevelDescriptorId { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureInstanceDescriptor table of the PerformanceMeasureInstanceDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureInstanceDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PerformanceMeasureInstanceDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasurePersonBeingReviewed table of the PerformanceMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasurePersonBeingReviewedRecord
    {     
        // Properties for all columns in physical table
        int? EducationOrganizationId { get; set; }
        string FirstName { get; set; }
        string LastSurname { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
        string ProspectIdentifier { get; set; }
        int? StaffUSI { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureProgramGateway table of the PerformanceMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureProgramGatewayRecord
    {     
        // Properties for all columns in physical table
        string PerformanceMeasureIdentifier { get; set; }
        int ProgramGatewayDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureReviewer table of the PerformanceMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureReviewerRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        string LastSurname { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
        int? StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureReviewerReceivedTraining table of the PerformanceMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureReviewerReceivedTrainingRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        int? InterRaterReliabilityScore { get; set; }
        string LastSurname { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureRubric table of the PerformanceMeasure aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureRubricRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.PerformanceMeasureTypeDescriptor table of the PerformanceMeasureTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IPerformanceMeasureTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int PerformanceMeasureTypeDescriptorId { get; set; }
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
        int ProfessionalDevelopmentOfferedByDescriptorId { get; set; }
        string ProfessionalDevelopmentReason { get; set; }
        string ProfessionalDevelopmentTitle { get; set; }
        bool? Required { get; set; }
        int? TotalHours { get; set; }
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
        int? PreScreeningRating { get; set; }
        string ProspectIdentifier { get; set; }
        int? ProspectTypeDescriptorId { get; set; }
        bool? Referral { get; set; }
        string ReferredBy { get; set; }
        int? SexDescriptorId { get; set; }
        string SocialMediaNetworkName { get; set; }
        string SocialMediaUserName { get; set; }
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
    /// Interface for the tpdm.ProspectCredential table of the Prospect aggregate in the Ods Database.
    /// </summary>
    public interface IProspectCredentialRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
        string ProspectIdentifier { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
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
    /// Interface for the tpdm.ProspectProfessionalDevelopmentEventAttendance table of the ProspectProfessionalDevelopmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    public interface IProspectProfessionalDevelopmentEventAttendanceRecord
    {     
        // Properties for all columns in physical table
        DateTime AttendanceDate { get; set; }
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string ProfessionalDevelopmentTitle { get; set; }
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
    /// Interface for the tpdm.Rubric table of the Rubric aggregate in the Ods Database.
    /// </summary>
    public interface IRubricRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        int? InterRaterReliabilityScore { get; set; }
        string RubricDescription { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricLevel table of the RubricLevel aggregate in the Ods Database.
    /// </summary>
    public interface IRubricLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        string RubricLevelCode { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricLevelInformation table of the RubricLevel aggregate in the Ods Database.
    /// </summary>
    public interface IRubricLevelInformationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string LevelDescription { get; set; }
        string LevelTitle { get; set; }
        int LevelTypeDescriptorId { get; set; }
        string MaximumScore { get; set; }
        string MinimumScore { get; set; }
        string RubricLevelCode { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricLevelResponse table of the RubricLevelResponse aggregate in the Ods Database.
    /// </summary>
    public interface IRubricLevelResponseRecord
    {     
        // Properties for all columns in physical table
        bool? AreaOfRefinement { get; set; }
        bool? AreaOfReinforcement { get; set; }
        string Comments { get; set; }
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        int NumericResponse { get; set; }
        string PerformanceMeasureIdentifier { get; set; }
        string RubricLevelCode { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
        string TextResponse { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricLevelResponseFacts table of the RubricLevelResponseFacts aggregate in the Ods Database.
    /// </summary>
    public interface IRubricLevelResponseFactsRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        string RubricLevelCode { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricLevelResponseFactsAggregatedNumericResponse table of the RubricLevelResponseFacts aggregate in the Ods Database.
    /// </summary>
    public interface IRubricLevelResponseFactsAggregatedNumericResponseRecord
    {     
        // Properties for all columns in physical table
        decimal AverageNumericResponse { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime FactsAsOfDate { get; set; }
        int? NumericResponseNCount { get; set; }
        int? NumericResponseStandardDeviation { get; set; }
        string RubricLevelCode { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricLevelTheme table of the RubricLevel aggregate in the Ods Database.
    /// </summary>
    public interface IRubricLevelThemeRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string RubricLevelCode { get; set; }
        string RubricTitle { get; set; }
        int RubricTypeDescriptorId { get; set; }
        int ThemeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.RubricTypeDescriptor table of the RubricTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IRubricTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int RubricTypeDescriptorId { get; set; }
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
    /// Interface for the tpdm.SectionCourseTranscriptFacts table of the SectionCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionCourseTranscriptFactsRecord
    {     
        // Properties for all columns in physical table
        string CourseTitle { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionCourseTranscriptFactsAggregatedFinalLetterGradeEarned table of the SectionCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionCourseTranscriptFactsAggregatedFinalLetterGradeEarnedRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        string FinalLetterGrade { get; set; }
        int? LetterGradeTypeNumber { get; set; }
        decimal? LetterGradeTypePercentage { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionCourseTranscriptFactsAggregatedNumericGradeEarned table of the SectionCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionCourseTranscriptFactsAggregatedNumericGradeEarnedRecord
    {     
        // Properties for all columns in physical table
        decimal AverageFinalNumericGradeEarned { get; set; }
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int? NumericGradeNCount { get; set; }
        int? NumericGradeStandardDeviation { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionCourseTranscriptFactsStudentsEnrolled table of the SectionCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionCourseTranscriptFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        DateTime FactsAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAcademicRecordFacts table of the SectionStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAcademicRecordFactsRecord
    {     
        // Properties for all columns in physical table
        decimal? AggregatedGPAMax { get; set; }
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAcademicRecordFactsAggregatedCumulativeGradePointAverage table of the SectionStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAcademicRecordFactsAggregatedCumulativeGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAcademicRecordFactsAggregatedSessionGradePointAverage table of the SectionStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAcademicRecordFactsAggregatedSessionGradePointAverageRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        decimal GradePointAverage { get; set; }
        int? GradePointNCount { get; set; }
        int? GradePointStandardDeviation { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAcademicRecordFactsStudentsEnrolled table of the SectionStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAcademicRecordFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAssessmentFacts table of the SectionStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAssessmentFactsRecord
    {     
        // Properties for all columns in physical table
        int? AcademicSubjectDescriptorId { get; set; }
        DateTime? AdministrationDate { get; set; }
        int? AssessmentCategoryDescriptorId { get; set; }
        string AssessmentTitle { get; set; }
        DateTime FactAsOfDate { get; set; }
        int? GradeLevelDescriptorId { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAssessmentFactsAggregatedPerformanceLevel table of the SectionStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAssessmentFactsAggregatedPerformanceLevelRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int PerformanceLevelDescriptorId { get; set; }
        int? PerformanceLevelMetNumber { get; set; }
        decimal? PerformanceLevelMetPercentage { get; set; }
        int? PerformanceLevelTypeNumber { get; set; }
        decimal? PerformanceLevelTypePercentage { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAssessmentFactsAggregatedScoreResult table of the SectionStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAssessmentFactsAggregatedScoreResultRecord
    {     
        // Properties for all columns in physical table
        int AssessmentReportingMethodDescriptorId { get; set; }
        string AverageScoreResult { get; set; }
        int AverageScoreResultDatatypeTypeDescriptorId { get; set; }
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        int? ScoreNCount { get; set; }
        int? ScoreStandardDeviation { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        short TakenSchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentAssessmentFactsStudentsEnrolled table of the SectionStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentAssessmentFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        short TakenSchoolYear { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFacts table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        Guid Id { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedByDisability table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedByDisabilityRecord
    {     
        // Properties for all columns in physical table
        int DisabilityDescriptorId { get; set; }
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        decimal? Percentage { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? TypeNumber { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedDisabilityTotalStudentsDisabled table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedDisabilityTotalStudentsDisabledRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? StudentsDisabledNumber { get; set; }
        decimal? StudentsDisabledPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedELLEnrollment table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedELLEnrollmentRecord
    {     
        // Properties for all columns in physical table
        int? ELLEnrollmentNumber { get; set; }
        decimal? ELLEnrollmentPercentage { get; set; }
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedESLEnrollment table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedESLEnrollmentRecord
    {     
        // Properties for all columns in physical table
        int? ESLEnrollmentNumber { get; set; }
        decimal? ESLEnrollmentPercentage { get; set; }
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedGender table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedGenderRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        int GenderDescriptorId { get; set; }
        int? GenderTypeNumber { get; set; }
        decimal? GenderTypePercentage { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedHispanicLatinoEthnicity table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedHispanicLatinoEthnicityRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        bool HispanicLatinoEthnicity { get; set; }
        int? HispanicLatinoEthnicityNumber { get; set; }
        decimal? HispanicLatinoEthnicityPercentage { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedLanguage table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedLanguageRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        int LanguageDescriptorId { get; set; }
        int? LanguageTypeNumber { get; set; }
        decimal? LanguageTypePercentage { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedRace table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedRaceRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int RaceDescriptorId { get; set; }
        int? RaceTypeNumber { get; set; }
        decimal? RaceTypePercentage { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedSchoolFoodServiceProgramService table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSchoolFoodServiceProgramServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolFoodServiceProgramServiceDescriptorId { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? TypeNumber { get; set; }
        int? TypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedSection504Enrollment table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSection504EnrollmentRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int? Number504Enrolled { get; set; }
        decimal? Percentage504Enrolled { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedSex table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSexRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int SexDescriptorId { get; set; }
        int? SexTypeNumber { get; set; }
        decimal? SexTypePercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedSPED table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedSPEDRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? SPEDEnrollmentNumber { get; set; }
        decimal? SPEDEnrollmentPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsAggregatedTitleIEnrollment table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsAggregatedTitleIEnrollmentRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? TitleIEnrollmentNumber { get; set; }
        decimal? TitleIEnrollmentPercentage { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.SectionStudentFactsStudentsEnrolled table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    public interface ISectionStudentFactsStudentsEnrolledRecord
    {     
        // Properties for all columns in physical table
        DateTime FactAsOfDate { get; set; }
        string LocalCourseCode { get; set; }
        int? NumberStudentsEnrolled { get; set; }
        decimal? PercentAtRisk { get; set; }
        decimal? PercentMobility { get; set; }
        int SchoolId { get; set; }
        short SchoolYear { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }
        int? ValueTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffApplicantAssociation table of the StaffApplicantAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffApplicantAssociationRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        int EducationOrganizationId { get; set; }
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
    /// Interface for the tpdm.StaffEvaluation table of the StaffEvaluation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        Guid Id { get; set; }
        decimal MaxRating { get; set; }
        decimal? MinRating { get; set; }
        short SchoolYear { get; set; }
        int? StaffEvaluationPeriodDescriptorId { get; set; }
        string StaffEvaluationTitle { get; set; }
        int? StaffEvaluationTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationComponent table of the StaffEvaluationComponent aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationComponentRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationComponent { get; set; }
        Guid Id { get; set; }
        decimal MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string RubricReference { get; set; }
        short SchoolYear { get; set; }
        string StaffEvaluationTitle { get; set; }
        int? StaffEvaluationTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationComponentRating table of the StaffEvaluationComponentRating aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationComponentRatingRecord
    {     
        // Properties for all columns in physical table
        decimal ComponentRating { get; set; }
        int EducationOrganizationId { get; set; }
        string EvaluationComponent { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        DateTime StaffEvaluationDate { get; set; }
        int? StaffEvaluationRatingLevelDescriptorId { get; set; }
        string StaffEvaluationTitle { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationComponentStaffRatingLevel table of the StaffEvaluationComponent aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationComponentStaffRatingLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationComponent { get; set; }
        decimal MaxLevel { get; set; }
        decimal? MinLevel { get; set; }
        short SchoolYear { get; set; }
        string StaffEvaluationLevel { get; set; }
        string StaffEvaluationTitle { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationElement table of the StaffEvaluationElement aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationElementRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationComponent { get; set; }
        string EvaluationElement { get; set; }
        Guid Id { get; set; }
        decimal MaxRating { get; set; }
        decimal? MinRating { get; set; }
        string RubricReference { get; set; }
        short SchoolYear { get; set; }
        string StaffEvaluationTitle { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationElementRating table of the StaffEvaluationElementRating aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationElementRatingRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        decimal ElementRating { get; set; }
        string EvaluationComponent { get; set; }
        string EvaluationElement { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
        DateTime StaffEvaluationDate { get; set; }
        int? StaffEvaluationRatingLevelDescriptorId { get; set; }
        string StaffEvaluationTitle { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationElementStaffRatingLevel table of the StaffEvaluationElement aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationElementStaffRatingLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string EvaluationComponent { get; set; }
        string EvaluationElement { get; set; }
        decimal MaxLevel { get; set; }
        decimal? MinLevel { get; set; }
        short SchoolYear { get; set; }
        string StaffEvaluationLevel { get; set; }
        string StaffEvaluationTitle { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationPeriodDescriptor table of the StaffEvaluationPeriodDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationPeriodDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StaffEvaluationPeriodDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationRating table of the StaffEvaluationRating aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationRatingRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int? EvaluatedByStaffUSI { get; set; }
        Guid Id { get; set; }
        decimal Rating { get; set; }
        short SchoolYear { get; set; }
        DateTime StaffEvaluationDate { get; set; }
        int? StaffEvaluationRatingLevelDescriptorId { get; set; }
        string StaffEvaluationTitle { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationRatingLevelDescriptor table of the StaffEvaluationRatingLevelDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationRatingLevelDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StaffEvaluationRatingLevelDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationStaffRatingLevel table of the StaffEvaluation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationStaffRatingLevelRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        decimal MaxLevel { get; set; }
        decimal? MinLevel { get; set; }
        short SchoolYear { get; set; }
        string StaffEvaluationLevel { get; set; }
        string StaffEvaluationTitle { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffEvaluationTypeDescriptor table of the StaffEvaluationTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IStaffEvaluationTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int StaffEvaluationTypeDescriptorId { get; set; }
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
    /// Interface for the tpdm.StaffFieldworkAbsenceEvent table of the StaffFieldworkAbsenceEvent aggregate in the Ods Database.
    /// </summary>
    public interface IStaffFieldworkAbsenceEventRecord
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
    /// Interface for the tpdm.StaffFieldworkExperience table of the StaffFieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface IStaffFieldworkExperienceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int FieldworkTypeDescriptorId { get; set; }
        decimal? HoursCompleted { get; set; }
        Guid Id { get; set; }
        int? ProgramGatewayDescriptorId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffFieldworkExperienceCoteaching table of the StaffFieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface IStaffFieldworkExperienceCoteachingRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime CoteachingBeginDate { get; set; }
        DateTime? CoteachingEndDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffFieldworkExperienceSchool table of the StaffFieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface IStaffFieldworkExperienceSchoolRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int SchoolId { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.StaffFieldworkExperienceSectionAssociation table of the StaffFieldworkExperienceSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStaffFieldworkExperienceSectionAssociationRecord
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
        int StaffUSI { get; set; }
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
    /// Interface for the tpdm.StaffProfessionalDevelopmentEventAttendance table of the StaffProfessionalDevelopmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    public interface IStaffProfessionalDevelopmentEventAttendanceRecord
    {     
        // Properties for all columns in physical table
        DateTime AttendanceDate { get; set; }
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        Guid Id { get; set; }
        string ProfessionalDevelopmentTitle { get; set; }
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
    /// Interface for the tpdm.TalentManagementGoal table of the TalentManagementGoal aggregate in the Ods Database.
    /// </summary>
    public interface ITalentManagementGoalRecord
    {     
        // Properties for all columns in physical table
        string GoalTitle { get; set; }
        decimal GoalValue { get; set; }
        Guid Id { get; set; }
        short SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TalentManagementGoalEducationOrganization table of the TalentManagementGoal aggregate in the Ods Database.
    /// </summary>
    public interface ITalentManagementGoalEducationOrganizationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        string GoalTitle { get; set; }
        short SchoolYear { get; set; }
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
        int? PreviousCareerDescriptorId { get; set; }
        string ProfileThumbnail { get; set; }
        bool? ProgramComplete { get; set; }
        int SexDescriptorId { get; set; }
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
    /// Interface for the tpdm.TeacherCandidateCredential table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateCredentialRecord
    {     
        // Properties for all columns in physical table
        string CredentialIdentifier { get; set; }
        int StateOfIssueStateAbbreviationDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
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
    /// Interface for the tpdm.TeacherCandidateFieldworkAbsenceEvent table of the TeacherCandidateFieldworkAbsenceEvent aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateFieldworkAbsenceEventRecord
    {     
        // Properties for all columns in physical table
        int AbsenceEventCategoryDescriptorId { get; set; }
        string AbsenceEventReason { get; set; }
        DateTime EventDate { get; set; }
        decimal? HoursAbsent { get; set; }
        Guid Id { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateFieldworkExperience table of the TeacherCandidateFieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperienceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int FieldworkTypeDescriptorId { get; set; }
        decimal? HoursCompleted { get; set; }
        Guid Id { get; set; }
        int? ProgramGatewayDescriptorId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateFieldworkExperienceCoteaching table of the TeacherCandidateFieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperienceCoteachingRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        DateTime CoteachingBeginDate { get; set; }
        DateTime? CoteachingEndDate { get; set; }
        string FieldworkIdentifier { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateFieldworkExperienceSchool table of the TeacherCandidateFieldworkExperience aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperienceSchoolRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        string FieldworkIdentifier { get; set; }
        int SchoolId { get; set; }
        string TeacherCandidateIdentifier { get; set; }
    }

    /// <summary>
    /// Interface for the tpdm.TeacherCandidateFieldworkExperienceSectionAssociation table of the TeacherCandidateFieldworkExperienceSectionAssociation aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateFieldworkExperienceSectionAssociationRecord
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
    /// Interface for the tpdm.TeacherCandidateProfessionalDevelopmentEventAttendance table of the TeacherCandidateProfessionalDevelopmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    public interface ITeacherCandidateProfessionalDevelopmentEventAttendanceRecord
    {     
        // Properties for all columns in physical table
        DateTime AttendanceDate { get; set; }
        int AttendanceEventCategoryDescriptorId { get; set; }
        string AttendanceEventReason { get; set; }
        Guid Id { get; set; }
        string ProfessionalDevelopmentTitle { get; set; }
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
    /// Interface for the tpdm.ThemeDescriptor table of the ThemeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IThemeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ThemeDescriptorId { get; set; }
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

