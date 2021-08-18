CREATE TABLE tracked_deletes_edfi.AbsenceEventCategoryDescriptor
(
       AbsenceEventCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AbsenceEventCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AcademicHonorCategoryDescriptor
(
       AcademicHonorCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AcademicHonorCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AcademicSubjectDescriptor
(
       AcademicSubjectDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AcademicSubjectDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AcademicWeek
(
       SchoolId INT NOT NULL,
       WeekIdentifier VARCHAR(80) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AcademicWeek_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AccommodationDescriptor
(
       AccommodationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AccommodationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Account
(
       AccountIdentifier VARCHAR(50) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FiscalYear INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Account_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AccountClassificationDescriptor
(
       AccountClassificationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AccountClassificationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AccountCode
(
       AccountClassificationDescriptorId INT NOT NULL,
       AccountCodeNumber VARCHAR(50) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FiscalYear INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AccountCode_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AccountabilityRating
(
       EducationOrganizationId INT NOT NULL,
       RatingTitle VARCHAR(60) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AccountabilityRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AchievementCategoryDescriptor
(
       AchievementCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AchievementCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Actual
(
       AccountIdentifier VARCHAR(50) NOT NULL,
       AsOfDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FiscalYear INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Actual_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AdditionalCreditTypeDescriptor
(
       AdditionalCreditTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AdditionalCreditTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AddressTypeDescriptor
(
       AddressTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AddressTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AdministrationEnvironmentDescriptor
(
       AdministrationEnvironmentDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AdministrationEnvironmentDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AdministrativeFundingControlDescriptor
(
       AdministrativeFundingControlDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AdministrativeFundingControlDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AncestryEthnicOriginDescriptor
(
       AncestryEthnicOriginDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AncestryEthnicOriginDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Assessment
(
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Assessment_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentCategoryDescriptor
(
       AssessmentCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentIdentificationSystemDescriptor
(
       AssessmentIdentificationSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentIdentificationSystemDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentItem
(
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       IdentificationCode VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentItem_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentItemCategoryDescriptor
(
       AssessmentItemCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentItemCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentItemResultDescriptor
(
       AssessmentItemResultDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentItemResultDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentPeriodDescriptor
(
       AssessmentPeriodDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentPeriodDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentReportingMethodDescriptor
(
       AssessmentReportingMethodDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentReportingMethodDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AssessmentScoreRangeLearningStandard
(
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       ScoreRangeId VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AssessmentScoreRangeLearningStandard_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AttemptStatusDescriptor
(
       AttemptStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AttemptStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.AttendanceEventCategoryDescriptor
(
       AttendanceEventCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AttendanceEventCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.BarrierToInternetAccessInResidenceDescriptor
(
       BarrierToInternetAccessInResidenceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT BarrierToInternetAccessInResidenceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.BehaviorDescriptor
(
       BehaviorDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT BehaviorDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.BellSchedule
(
       BellScheduleName VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT BellSchedule_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Budget
(
       AccountIdentifier VARCHAR(50) NOT NULL,
       AsOfDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FiscalYear INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Budget_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CTEProgramServiceDescriptor
(
       CTEProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CTEProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Calendar
(
       CalendarCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Calendar_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CalendarDate
(
       CalendarCode VARCHAR(60) NOT NULL,
       Date DATE NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CalendarDate_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CalendarEventDescriptor
(
       CalendarEventDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CalendarEventDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CalendarTypeDescriptor
(
       CalendarTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CalendarTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CareerPathwayDescriptor
(
       CareerPathwayDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CareerPathwayDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CharterApprovalAgencyTypeDescriptor
(
       CharterApprovalAgencyTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CharterApprovalAgencyTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CharterStatusDescriptor
(
       CharterStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CharterStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CitizenshipStatusDescriptor
(
       CitizenshipStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CitizenshipStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ClassPeriod
(
       ClassPeriodName VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ClassPeriod_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ClassroomPositionDescriptor
(
       ClassroomPositionDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ClassroomPositionDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Cohort
(
       CohortIdentifier VARCHAR(20) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Cohort_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CohortScopeDescriptor
(
       CohortScopeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CohortScopeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CohortTypeDescriptor
(
       CohortTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CohortTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CohortYearTypeDescriptor
(
       CohortYearTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CohortYearTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CommunityOrganization
(
       CommunityOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CommunityOrganization_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CommunityProvider
(
       CommunityProviderId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CommunityProvider_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CommunityProviderLicense
(
       CommunityProviderId INT NOT NULL,
       LicenseIdentifier VARCHAR(20) NOT NULL,
       LicensingOrganization VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CommunityProviderLicense_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CompetencyLevelDescriptor
(
       CompetencyLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CompetencyLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CompetencyObjective
(
       EducationOrganizationId INT NOT NULL,
       Objective VARCHAR(60) NOT NULL,
       ObjectiveGradeLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CompetencyObjective_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ContactTypeDescriptor
(
       ContactTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ContactTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ContentClassDescriptor
(
       ContentClassDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ContentClassDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ContinuationOfServicesReasonDescriptor
(
       ContinuationOfServicesReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ContinuationOfServicesReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ContractedStaff
(
       AccountIdentifier VARCHAR(50) NOT NULL,
       AsOfDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FiscalYear INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ContractedStaff_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CostRateDescriptor
(
       CostRateDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CostRateDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CountryDescriptor
(
       CountryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CountryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Course
(
       CourseCode VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Course_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseAttemptResultDescriptor
(
       CourseAttemptResultDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseAttemptResultDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseDefinedByDescriptor
(
       CourseDefinedByDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseDefinedByDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseGPAApplicabilityDescriptor
(
       CourseGPAApplicabilityDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseGPAApplicabilityDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseIdentificationSystemDescriptor
(
       CourseIdentificationSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseIdentificationSystemDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseLevelCharacteristicDescriptor
(
       CourseLevelCharacteristicDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseLevelCharacteristicDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseOffering
(
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseOffering_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseRepeatCodeDescriptor
(
       CourseRepeatCodeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseRepeatCodeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CourseTranscript
(
       CourseAttemptResultDescriptorId INT NOT NULL,
       CourseCode VARCHAR(60) NOT NULL,
       CourseEducationOrganizationId INT NOT NULL,
       EducationOrganizationId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       StudentUSI INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CourseTranscript_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Credential
(
       CredentialIdentifier VARCHAR(60) NOT NULL,
       StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Credential_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CredentialFieldDescriptor
(
       CredentialFieldDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CredentialFieldDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CredentialTypeDescriptor
(
       CredentialTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CredentialTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CreditCategoryDescriptor
(
       CreditCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CreditCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CreditTypeDescriptor
(
       CreditTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CreditTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.CurriculumUsedDescriptor
(
       CurriculumUsedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CurriculumUsedDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DeliveryMethodDescriptor
(
       DeliveryMethodDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DeliveryMethodDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Descriptor
(
       DescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Descriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DiagnosisDescriptor
(
       DiagnosisDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DiagnosisDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DiplomaLevelDescriptor
(
       DiplomaLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DiplomaLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DiplomaTypeDescriptor
(
       DiplomaTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DiplomaTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisabilityDescriptor
(
       DisabilityDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisabilityDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisabilityDesignationDescriptor
(
       DisabilityDesignationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisabilityDesignationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisabilityDeterminationSourceTypeDescriptor
(
       DisabilityDeterminationSourceTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisabilityDeterminationSourceTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisciplineAction
(
       DisciplineActionIdentifier VARCHAR(20) NOT NULL,
       DisciplineDate DATE NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisciplineAction_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisciplineActionLengthDifferenceReasonDescriptor
(
       DisciplineActionLengthDifferenceReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisciplineActionLengthDifferenceReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisciplineDescriptor
(
       DisciplineDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisciplineDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisciplineIncident
(
       IncidentIdentifier VARCHAR(20) NOT NULL,
       SchoolId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisciplineIncident_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.DisciplineIncidentParticipationCodeDescriptor
(
       DisciplineIncidentParticipationCodeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DisciplineIncidentParticipationCodeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationContent
(
       ContentIdentifier VARCHAR(225) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationContent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationOrganization
(
       EducationOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationOrganization_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationOrganizationCategoryDescriptor
(
       EducationOrganizationCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationOrganizationCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationOrganizationIdentificationSystemDescriptor
(
       EducationOrganizationIdentificationSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationOrganizationIdentificationSystemDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationOrganizationInterventionPrescriptionAssociation
(
       EducationOrganizationId INT NOT NULL,
       InterventionPrescriptionEducationOrganizationId INT NOT NULL,
       InterventionPrescriptionIdentificationCode VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationOrganizationInterventionPrescriptionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationOrganizationNetwork
(
       EducationOrganizationNetworkId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationOrganizationNetwork_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationOrganizationNetworkAssociation
(
       EducationOrganizationNetworkId INT NOT NULL,
       MemberEducationOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationOrganizationNetworkAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationOrganizationPeerAssociation
(
       EducationOrganizationId INT NOT NULL,
       PeerEducationOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationOrganizationPeerAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationPlanDescriptor
(
       EducationPlanDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationPlanDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationServiceCenter
(
       EducationServiceCenterId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationServiceCenter_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EducationalEnvironmentDescriptor
(
       EducationalEnvironmentDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducationalEnvironmentDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ElectronicMailTypeDescriptor
(
       ElectronicMailTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ElectronicMailTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EmploymentStatusDescriptor
(
       EmploymentStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EmploymentStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EntryGradeLevelReasonDescriptor
(
       EntryGradeLevelReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EntryGradeLevelReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EntryTypeDescriptor
(
       EntryTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EntryTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.EventCircumstanceDescriptor
(
       EventCircumstanceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EventCircumstanceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ExitWithdrawTypeDescriptor
(
       ExitWithdrawTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ExitWithdrawTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.FeederSchoolAssociation
(
       BeginDate DATE NOT NULL,
       FeederSchoolId INT NOT NULL,
       SchoolId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FeederSchoolAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GeneralStudentProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GeneralStudentProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Grade
(
       BeginDate DATE NOT NULL,
       GradeTypeDescriptorId INT NOT NULL,
       GradingPeriodDescriptorId INT NOT NULL,
       GradingPeriodSchoolYear SMALLINT NOT NULL,
       GradingPeriodSequence INT NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Grade_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GradeLevelDescriptor
(
       GradeLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GradeLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GradePointAverageTypeDescriptor
(
       GradePointAverageTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GradePointAverageTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GradeTypeDescriptor
(
       GradeTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GradeTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GradebookEntry
(
       DateAssigned DATE NOT NULL,
       GradebookEntryTitle VARCHAR(60) NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GradebookEntry_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GradebookEntryTypeDescriptor
(
       GradebookEntryTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GradebookEntryTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GradingPeriod
(
       GradingPeriodDescriptorId INT NOT NULL,
       PeriodSequence INT NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GradingPeriod_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GradingPeriodDescriptor
(
       GradingPeriodDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GradingPeriodDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GraduationPlan
(
       EducationOrganizationId INT NOT NULL,
       GraduationPlanTypeDescriptorId INT NOT NULL,
       GraduationSchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GraduationPlan_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GraduationPlanTypeDescriptor
(
       GraduationPlanTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GraduationPlanTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.GunFreeSchoolsActReportingStatusDescriptor
(
       GunFreeSchoolsActReportingStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GunFreeSchoolsActReportingStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.HomelessPrimaryNighttimeResidenceDescriptor
(
       HomelessPrimaryNighttimeResidenceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT HomelessPrimaryNighttimeResidenceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.HomelessProgramServiceDescriptor
(
       HomelessProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT HomelessProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.IdentificationDocumentUseDescriptor
(
       IdentificationDocumentUseDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT IdentificationDocumentUseDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.IncidentLocationDescriptor
(
       IncidentLocationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT IncidentLocationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.IndicatorDescriptor
(
       IndicatorDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT IndicatorDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.IndicatorGroupDescriptor
(
       IndicatorGroupDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT IndicatorGroupDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.IndicatorLevelDescriptor
(
       IndicatorLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT IndicatorLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InstitutionTelephoneNumberTypeDescriptor
(
       InstitutionTelephoneNumberTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InstitutionTelephoneNumberTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InteractivityStyleDescriptor
(
       InteractivityStyleDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InteractivityStyleDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InternetAccessDescriptor
(
       InternetAccessDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InternetAccessDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InternetAccessTypeInResidenceDescriptor
(
       InternetAccessTypeInResidenceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InternetAccessTypeInResidenceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InternetPerformanceInResidenceDescriptor
(
       InternetPerformanceInResidenceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InternetPerformanceInResidenceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Intervention
(
       EducationOrganizationId INT NOT NULL,
       InterventionIdentificationCode VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Intervention_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InterventionClassDescriptor
(
       InterventionClassDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InterventionClassDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InterventionEffectivenessRatingDescriptor
(
       InterventionEffectivenessRatingDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InterventionEffectivenessRatingDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InterventionPrescription
(
       EducationOrganizationId INT NOT NULL,
       InterventionPrescriptionIdentificationCode VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InterventionPrescription_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.InterventionStudy
(
       EducationOrganizationId INT NOT NULL,
       InterventionStudyIdentificationCode VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InterventionStudy_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LanguageDescriptor
(
       LanguageDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LanguageDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LanguageInstructionProgramServiceDescriptor
(
       LanguageInstructionProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LanguageInstructionProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LanguageUseDescriptor
(
       LanguageUseDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LanguageUseDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LearningObjective
(
       LearningObjectiveId VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LearningObjective_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LearningStandard
(
       LearningStandardId VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LearningStandard_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LearningStandardCategoryDescriptor
(
       LearningStandardCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LearningStandardCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LearningStandardEquivalenceAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       SourceLearningStandardId VARCHAR(60) NOT NULL,
       TargetLearningStandardId VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LearningStandardEquivalenceAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LearningStandardEquivalenceStrengthDescriptor
(
       LearningStandardEquivalenceStrengthDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LearningStandardEquivalenceStrengthDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LearningStandardScopeDescriptor
(
       LearningStandardScopeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LearningStandardScopeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LevelOfEducationDescriptor
(
       LevelOfEducationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LevelOfEducationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LicenseStatusDescriptor
(
       LicenseStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LicenseStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LicenseTypeDescriptor
(
       LicenseTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LicenseTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LimitedEnglishProficiencyDescriptor
(
       LimitedEnglishProficiencyDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LimitedEnglishProficiencyDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LocalEducationAgency
(
       LocalEducationAgencyId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LocalEducationAgency_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LocalEducationAgencyCategoryDescriptor
(
       LocalEducationAgencyCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LocalEducationAgencyCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.LocaleDescriptor
(
       LocaleDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LocaleDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Location
(
       ClassroomIdentificationCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Location_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.MagnetSpecialProgramEmphasisSchoolDescriptor
(
       MagnetSpecialProgramEmphasisSchoolDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT MagnetSpecialProgramEmphasisSchoolDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.MediumOfInstructionDescriptor
(
       MediumOfInstructionDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT MediumOfInstructionDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.MethodCreditEarnedDescriptor
(
       MethodCreditEarnedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT MethodCreditEarnedDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.MigrantEducationProgramServiceDescriptor
(
       MigrantEducationProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT MigrantEducationProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.MonitoredDescriptor
(
       MonitoredDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT MonitoredDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.NeglectedOrDelinquentProgramDescriptor
(
       NeglectedOrDelinquentProgramDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT NeglectedOrDelinquentProgramDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.NeglectedOrDelinquentProgramServiceDescriptor
(
       NeglectedOrDelinquentProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT NeglectedOrDelinquentProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.NetworkPurposeDescriptor
(
       NetworkPurposeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT NetworkPurposeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ObjectiveAssessment
(
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       IdentificationCode VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ObjectiveAssessment_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.OldEthnicityDescriptor
(
       OldEthnicityDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OldEthnicityDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.OpenStaffPosition
(
       EducationOrganizationId INT NOT NULL,
       RequisitionNumber VARCHAR(20) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OpenStaffPosition_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.OperationalStatusDescriptor
(
       OperationalStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OperationalStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.OrganizationDepartment
(
       OrganizationDepartmentId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OrganizationDepartment_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.OtherNameTypeDescriptor
(
       OtherNameTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OtherNameTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Parent
(
       ParentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Parent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ParticipationDescriptor
(
       ParticipationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ParticipationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ParticipationStatusDescriptor
(
       ParticipationStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ParticipationStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Payroll
(
       AccountIdentifier VARCHAR(50) NOT NULL,
       AsOfDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FiscalYear INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Payroll_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PerformanceBaseConversionDescriptor
(
       PerformanceBaseConversionDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceBaseConversionDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PerformanceLevelDescriptor
(
       PerformanceLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Person
(
       PersonId VARCHAR(32) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Person_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PersonalInformationVerificationDescriptor
(
       PersonalInformationVerificationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PersonalInformationVerificationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PlatformTypeDescriptor
(
       PlatformTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PlatformTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PopulationServedDescriptor
(
       PopulationServedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PopulationServedDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PostSecondaryEvent
(
       EventDate DATE NOT NULL,
       PostSecondaryEventCategoryDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PostSecondaryEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PostSecondaryEventCategoryDescriptor
(
       PostSecondaryEventCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PostSecondaryEventCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PostSecondaryInstitution
(
       PostSecondaryInstitutionId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PostSecondaryInstitution_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PostSecondaryInstitutionLevelDescriptor
(
       PostSecondaryInstitutionLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PostSecondaryInstitutionLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PostingResultDescriptor
(
       PostingResultDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PostingResultDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PrimaryLearningDeviceAccessDescriptor
(
       PrimaryLearningDeviceAccessDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PrimaryLearningDeviceAccessDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor
(
       PrimaryLearningDeviceAwayFromSchoolDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PrimaryLearningDeviceAwayFromSchoolDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PrimaryLearningDeviceProviderDescriptor
(
       PrimaryLearningDeviceProviderDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PrimaryLearningDeviceProviderDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProficiencyDescriptor
(
       ProficiencyDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProficiencyDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Program
(
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Program_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProgramAssignmentDescriptor
(
       ProgramAssignmentDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProgramAssignmentDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProgramCharacteristicDescriptor
(
       ProgramCharacteristicDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProgramCharacteristicDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProgramSponsorDescriptor
(
       ProgramSponsorDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProgramSponsorDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProgramTypeDescriptor
(
       ProgramTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProgramTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProgressDescriptor
(
       ProgressDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProgressDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProgressLevelDescriptor
(
       ProgressLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProgressLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProviderCategoryDescriptor
(
       ProviderCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProviderCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProviderProfitabilityDescriptor
(
       ProviderProfitabilityDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProviderProfitabilityDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ProviderStatusDescriptor
(
       ProviderStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProviderStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.PublicationStatusDescriptor
(
       PublicationStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PublicationStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.QuestionFormDescriptor
(
       QuestionFormDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT QuestionFormDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.RaceDescriptor
(
       RaceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RaceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ReasonExitedDescriptor
(
       ReasonExitedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ReasonExitedDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ReasonNotTestedDescriptor
(
       ReasonNotTestedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ReasonNotTestedDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.RecognitionTypeDescriptor
(
       RecognitionTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RecognitionTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.RelationDescriptor
(
       RelationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RelationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.RepeatIdentifierDescriptor
(
       RepeatIdentifierDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RepeatIdentifierDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ReportCard
(
       EducationOrganizationId INT NOT NULL,
       GradingPeriodDescriptorId INT NOT NULL,
       GradingPeriodSchoolId INT NOT NULL,
       GradingPeriodSchoolYear SMALLINT NOT NULL,
       GradingPeriodSequence INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ReportCard_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ReporterDescriptionDescriptor
(
       ReporterDescriptionDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ReporterDescriptionDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ResidencyStatusDescriptor
(
       ResidencyStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ResidencyStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ResponseIndicatorDescriptor
(
       ResponseIndicatorDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ResponseIndicatorDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ResponsibilityDescriptor
(
       ResponsibilityDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ResponsibilityDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.RestraintEvent
(
       RestraintEventIdentifier VARCHAR(20) NOT NULL,
       SchoolId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RestraintEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.RestraintEventReasonDescriptor
(
       RestraintEventReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RestraintEventReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ResultDatatypeTypeDescriptor
(
       ResultDatatypeTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ResultDatatypeTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.RetestIndicatorDescriptor
(
       RetestIndicatorDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RetestIndicatorDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.School
(
       SchoolId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT School_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SchoolCategoryDescriptor
(
       SchoolCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SchoolCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SchoolChoiceImplementStatusDescriptor
(
       SchoolChoiceImplementStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SchoolChoiceImplementStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SchoolFoodServiceProgramServiceDescriptor
(
       SchoolFoodServiceProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SchoolFoodServiceProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SchoolTypeDescriptor
(
       SchoolTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SchoolTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Section
(
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Section_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SectionAttendanceTakenEvent
(
       CalendarCode VARCHAR(60) NOT NULL,
       Date DATE NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SectionAttendanceTakenEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SectionCharacteristicDescriptor
(
       SectionCharacteristicDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SectionCharacteristicDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SeparationDescriptor
(
       SeparationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SeparationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SeparationReasonDescriptor
(
       SeparationReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SeparationReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.ServiceDescriptor
(
       ServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Session
(
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Session_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SexDescriptor
(
       SexDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SexDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SourceSystemDescriptor
(
       SourceSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SourceSystemDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SpecialEducationProgramServiceDescriptor
(
       SpecialEducationProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SpecialEducationProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SpecialEducationSettingDescriptor
(
       SpecialEducationSettingDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SpecialEducationSettingDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Staff
(
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Staff_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffAbsenceEvent
(
       AbsenceEventCategoryDescriptorId INT NOT NULL,
       EventDate DATE NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffAbsenceEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffClassificationDescriptor
(
       StaffClassificationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffClassificationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffCohortAssociation
(
       BeginDate DATE NOT NULL,
       CohortIdentifier VARCHAR(20) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffCohortAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffDisciplineIncidentAssociation
(
       IncidentIdentifier VARCHAR(20) NOT NULL,
       SchoolId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffDisciplineIncidentAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffEducationOrganizationAssignmentAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       StaffClassificationDescriptorId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffEducationOrganizationAssignmentAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffEducationOrganizationContactAssociation
(
       ContactTitle VARCHAR(75) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffEducationOrganizationContactAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffEducationOrganizationEmploymentAssociation
(
       EducationOrganizationId INT NOT NULL,
       EmploymentStatusDescriptorId INT NOT NULL,
       HireDate DATE NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffEducationOrganizationEmploymentAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffIdentificationSystemDescriptor
(
       StaffIdentificationSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffIdentificationSystemDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffLeave
(
       BeginDate DATE NOT NULL,
       StaffLeaveEventCategoryDescriptorId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffLeave_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffLeaveEventCategoryDescriptor
(
       StaffLeaveEventCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffLeaveEventCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffProgramAssociation
(
       BeginDate DATE NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffSchoolAssociation
(
       ProgramAssignmentDescriptorId INT NOT NULL,
       SchoolId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffSchoolAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StaffSectionAssociation
(
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffSectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StateAbbreviationDescriptor
(
       StateAbbreviationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StateAbbreviationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StateEducationAgency
(
       StateEducationAgencyId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StateEducationAgency_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Student
(
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Student_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentAcademicRecord
(
       EducationOrganizationId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       StudentUSI INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentAcademicRecord_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentAssessment
(
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       StudentAssessmentIdentifier VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentAssessment_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentCTEProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentCTEProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentCharacteristicDescriptor
(
       StudentCharacteristicDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentCharacteristicDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentCohortAssociation
(
       BeginDate DATE NOT NULL,
       CohortIdentifier VARCHAR(20) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentCohortAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentCompetencyObjective
(
       GradingPeriodDescriptorId INT NOT NULL,
       GradingPeriodSchoolId INT NOT NULL,
       GradingPeriodSchoolYear SMALLINT NOT NULL,
       GradingPeriodSequence INT NOT NULL,
       Objective VARCHAR(60) NOT NULL,
       ObjectiveEducationOrganizationId INT NOT NULL,
       ObjectiveGradeLevelDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentCompetencyObjective_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentDisciplineIncidentAssociation
(
       IncidentIdentifier VARCHAR(20) NOT NULL,
       SchoolId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentDisciplineIncidentAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentDisciplineIncidentBehaviorAssociation
(
       BehaviorDescriptorId INT NOT NULL,
       IncidentIdentifier VARCHAR(20) NOT NULL,
       SchoolId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentDisciplineIncidentBehaviorAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentDisciplineIncidentNonOffenderAssociation
(
       IncidentIdentifier VARCHAR(20) NOT NULL,
       SchoolId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentDisciplineIncidentNonOffenderAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentEducationOrganizationAssociation
(
       EducationOrganizationId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentEducationOrganizationAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentEducationOrganizationResponsibilityAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ResponsibilityDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentEducationOrganizationResponsibilityAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentGradebookEntry
(
       BeginDate DATE NOT NULL,
       DateAssigned DATE NOT NULL,
       GradebookEntryTitle VARCHAR(60) NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentGradebookEntry_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentHomelessProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentHomelessProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentIdentificationSystemDescriptor
(
       StudentIdentificationSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentIdentificationSystemDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentInterventionAssociation
(
       EducationOrganizationId INT NOT NULL,
       InterventionIdentificationCode VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentInterventionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentInterventionAttendanceEvent
(
       AttendanceEventCategoryDescriptorId INT NOT NULL,
       EducationOrganizationId INT NOT NULL,
       EventDate DATE NOT NULL,
       InterventionIdentificationCode VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentInterventionAttendanceEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentLanguageInstructionProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentLanguageInstructionProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentLearningObjective
(
       GradingPeriodDescriptorId INT NOT NULL,
       GradingPeriodSchoolId INT NOT NULL,
       GradingPeriodSchoolYear SMALLINT NOT NULL,
       GradingPeriodSequence INT NOT NULL,
       LearningObjectiveId VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentLearningObjective_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentMigrantEducationProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentMigrantEducationProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentNeglectedOrDelinquentProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentNeglectedOrDelinquentProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentParentAssociation
(
       ParentUSI INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentParentAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentParticipationCodeDescriptor
(
       StudentParticipationCodeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentParticipationCodeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentProgramAttendanceEvent
(
       AttendanceEventCategoryDescriptorId INT NOT NULL,
       EducationOrganizationId INT NOT NULL,
       EventDate DATE NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentProgramAttendanceEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentSchoolAssociation
(
       EntryDate DATE NOT NULL,
       SchoolId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSchoolAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentSchoolAttendanceEvent
(
       AttendanceEventCategoryDescriptorId INT NOT NULL,
       EventDate DATE NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSchoolAttendanceEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentSchoolFoodServiceProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSchoolFoodServiceProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentSectionAssociation
(
       BeginDate DATE NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentSectionAttendanceEvent
(
       AttendanceEventCategoryDescriptorId INT NOT NULL,
       EventDate DATE NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSectionAttendanceEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentSpecialEducationProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSpecialEducationProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.StudentTitleIPartAProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentTitleIPartAProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.Survey
(
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Survey_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyCategoryDescriptor
(
       SurveyCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyCourseAssociation
(
       CourseCode VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyCourseAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyLevelDescriptor
(
       SurveyLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyProgramAssociation
(
       EducationOrganizationId INT NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyQuestion
(
       Namespace VARCHAR(255) NOT NULL,
       QuestionCode VARCHAR(60) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyQuestion_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyQuestionResponse
(
       Namespace VARCHAR(255) NOT NULL,
       QuestionCode VARCHAR(60) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyQuestionResponse_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyResponse
(
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyResponse_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyResponseEducationOrganizationTargetAssociation
(
       EducationOrganizationId INT NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyResponseEducationOrganizationTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveyResponseStaffTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       StaffUSI INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyResponseStaffTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveySection
(
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySection_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveySectionAssociation
(
       LocalCourseCode VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveySectionResponse
(
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionResponse_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveySectionResponseEducationOrganizationTargetAssociation
(
       EducationOrganizationId INT NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionResponseEducationOrganizationTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.SurveySectionResponseStaffTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       StaffUSI INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionResponseStaffTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TeachingCredentialBasisDescriptor
(
       TeachingCredentialBasisDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeachingCredentialBasisDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TeachingCredentialDescriptor
(
       TeachingCredentialDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeachingCredentialDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TechnicalSkillsAssessmentDescriptor
(
       TechnicalSkillsAssessmentDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TechnicalSkillsAssessmentDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TelephoneNumberTypeDescriptor
(
       TelephoneNumberTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TelephoneNumberTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TermDescriptor
(
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TermDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TitleIPartAParticipantDescriptor
(
       TitleIPartAParticipantDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TitleIPartAParticipantDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TitleIPartAProgramServiceDescriptor
(
       TitleIPartAProgramServiceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TitleIPartAProgramServiceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TitleIPartASchoolDesignationDescriptor
(
       TitleIPartASchoolDesignationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TitleIPartASchoolDesignationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.TribalAffiliationDescriptor
(
       TribalAffiliationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TribalAffiliationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.VisaDescriptor
(
       VisaDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT VisaDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_edfi.WeaponDescriptor
(
       WeaponDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT WeaponDescriptor_PK PRIMARY KEY (ChangeVersion)
);

