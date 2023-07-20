-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE edfi.AbsenceEventCategoryDescriptor ADD CONSTRAINT FK_ec167f_Descriptor FOREIGN KEY (AbsenceEventCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AcademicHonorCategoryDescriptor ADD CONSTRAINT FK_9b946b_Descriptor FOREIGN KEY (AcademicHonorCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AcademicSubjectDescriptor ADD CONSTRAINT FK_e4b042_Descriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AcademicWeek ADD CONSTRAINT FK_a97956_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.AccommodationDescriptor ADD CONSTRAINT FK_395139_Descriptor FOREIGN KEY (AccommodationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AccountabilityRating ADD CONSTRAINT FK_2d3c0c_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.AccountabilityRating ADD CONSTRAINT FK_2d3c0c_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.AccountTypeDescriptor ADD CONSTRAINT FK_8f249f_Descriptor FOREIGN KEY (AccountTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AchievementCategoryDescriptor ADD CONSTRAINT FK_c71291_Descriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AdditionalCreditTypeDescriptor ADD CONSTRAINT FK_e069dd_Descriptor FOREIGN KEY (AdditionalCreditTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AddressTypeDescriptor ADD CONSTRAINT FK_1edaa3_Descriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AdministrationEnvironmentDescriptor ADD CONSTRAINT FK_328563_Descriptor FOREIGN KEY (AdministrationEnvironmentDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AdministrativeFundingControlDescriptor ADD CONSTRAINT FK_3a5d1f_Descriptor FOREIGN KEY (AdministrativeFundingControlDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AncestryEthnicOriginDescriptor ADD CONSTRAINT FK_a21217_Descriptor FOREIGN KEY (AncestryEthnicOriginDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Assessment ADD CONSTRAINT FK_7808ee_AssessmentCategoryDescriptor FOREIGN KEY (AssessmentCategoryDescriptorId)
REFERENCES edfi.AssessmentCategoryDescriptor (AssessmentCategoryDescriptorId)
;

ALTER TABLE edfi.Assessment ADD CONSTRAINT FK_7808ee_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.AssessmentAcademicSubject ADD CONSTRAINT FK_400d06_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.AssessmentAcademicSubject ADD CONSTRAINT FK_400d06_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentAssessedGradeLevel ADD CONSTRAINT FK_e83625_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentAssessedGradeLevel ADD CONSTRAINT FK_e83625_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.AssessmentCategoryDescriptor ADD CONSTRAINT FK_20e875_Descriptor FOREIGN KEY (AssessmentCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentContentStandard ADD CONSTRAINT FK_bd89c0_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentContentStandard ADD CONSTRAINT FK_bd89c0_EducationOrganization FOREIGN KEY (MandatingEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.AssessmentContentStandard ADD CONSTRAINT FK_bd89c0_PublicationStatusDescriptor FOREIGN KEY (PublicationStatusDescriptorId)
REFERENCES edfi.PublicationStatusDescriptor (PublicationStatusDescriptorId)
;

ALTER TABLE edfi.AssessmentContentStandardAuthor ADD CONSTRAINT FK_21acd5_AssessmentContentStandard FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.AssessmentContentStandard (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentIdentificationCode ADD CONSTRAINT FK_3af731_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentIdentificationCode ADD CONSTRAINT FK_3af731_AssessmentIdentificationSystemDescriptor FOREIGN KEY (AssessmentIdentificationSystemDescriptorId)
REFERENCES edfi.AssessmentIdentificationSystemDescriptor (AssessmentIdentificationSystemDescriptorId)
;

ALTER TABLE edfi.AssessmentIdentificationSystemDescriptor ADD CONSTRAINT FK_a47976_Descriptor FOREIGN KEY (AssessmentIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentItem ADD CONSTRAINT FK_dc3dcf_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

ALTER TABLE edfi.AssessmentItem ADD CONSTRAINT FK_dc3dcf_AssessmentItemCategoryDescriptor FOREIGN KEY (AssessmentItemCategoryDescriptorId)
REFERENCES edfi.AssessmentItemCategoryDescriptor (AssessmentItemCategoryDescriptorId)
;

ALTER TABLE edfi.AssessmentItemCategoryDescriptor ADD CONSTRAINT FK_a5f1ee_Descriptor FOREIGN KEY (AssessmentItemCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentItemLearningStandard ADD CONSTRAINT FK_151580_AssessmentItem FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentItemLearningStandard ADD CONSTRAINT FK_151580_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.AssessmentItemPossibleResponse ADD CONSTRAINT FK_699b02_AssessmentItem FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentItemResultDescriptor ADD CONSTRAINT FK_47b16e_Descriptor FOREIGN KEY (AssessmentItemResultDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentLanguage ADD CONSTRAINT FK_d90abb_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentLanguage ADD CONSTRAINT FK_d90abb_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.AssessmentPeriod ADD CONSTRAINT FK_3734d1_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentPeriod ADD CONSTRAINT FK_3734d1_AssessmentPeriodDescriptor FOREIGN KEY (AssessmentPeriodDescriptorId)
REFERENCES edfi.AssessmentPeriodDescriptor (AssessmentPeriodDescriptorId)
;

ALTER TABLE edfi.AssessmentPeriodDescriptor ADD CONSTRAINT FK_7e11fe_Descriptor FOREIGN KEY (AssessmentPeriodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentPlatformType ADD CONSTRAINT FK_a3387e_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentPlatformType ADD CONSTRAINT FK_a3387e_PlatformTypeDescriptor FOREIGN KEY (PlatformTypeDescriptorId)
REFERENCES edfi.PlatformTypeDescriptor (PlatformTypeDescriptorId)
;

ALTER TABLE edfi.AssessmentProgram ADD CONSTRAINT FK_58013b_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentProgram ADD CONSTRAINT FK_58013b_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.AssessmentReportingMethodDescriptor ADD CONSTRAINT FK_dbee26_Descriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentScore ADD CONSTRAINT FK_df7331_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentScore ADD CONSTRAINT FK_df7331_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.AssessmentScore ADD CONSTRAINT FK_df7331_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD CONSTRAINT FK_a20588_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD CONSTRAINT FK_a20588_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD CONSTRAINT FK_a20588_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
;

ALTER TABLE edfi.AssessmentScoreRangeLearningStandardLearningStandard ADD CONSTRAINT FK_9960a9_AssessmentScoreRangeLearningStandard FOREIGN KEY (AssessmentIdentifier, Namespace, ScoreRangeId)
REFERENCES edfi.AssessmentScoreRangeLearningStandard (AssessmentIdentifier, Namespace, ScoreRangeId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentScoreRangeLearningStandardLearningStandard ADD CONSTRAINT FK_9960a9_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.AssessmentSection ADD CONSTRAINT FK_22ceba_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentSection ADD CONSTRAINT FK_22ceba_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.AssignmentLateStatusDescriptor ADD CONSTRAINT FK_518b3c_Descriptor FOREIGN KEY (AssignmentLateStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AttemptStatusDescriptor ADD CONSTRAINT FK_5d730c_Descriptor FOREIGN KEY (AttemptStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AttendanceEventCategoryDescriptor ADD CONSTRAINT FK_19349d_Descriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.BalanceSheetDimensionReportingTag ADD CONSTRAINT FK_bcbd82_BalanceSheetDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.BalanceSheetDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.BalanceSheetDimensionReportingTag ADD CONSTRAINT FK_bcbd82_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.BarrierToInternetAccessInResidenceDescriptor ADD CONSTRAINT FK_cce75a_Descriptor FOREIGN KEY (BarrierToInternetAccessInResidenceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.BehaviorDescriptor ADD CONSTRAINT FK_20feca_Descriptor FOREIGN KEY (BehaviorDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.BellSchedule ADD CONSTRAINT FK_9bbaf5_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.BellScheduleClassPeriod ADD CONSTRAINT FK_9e377d_BellSchedule FOREIGN KEY (BellScheduleName, SchoolId)
REFERENCES edfi.BellSchedule (BellScheduleName, SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.BellScheduleClassPeriod ADD CONSTRAINT FK_9e377d_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON UPDATE CASCADE
;

ALTER TABLE edfi.BellScheduleDate ADD CONSTRAINT FK_6e1291_BellSchedule FOREIGN KEY (BellScheduleName, SchoolId)
REFERENCES edfi.BellSchedule (BellScheduleName, SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.BellScheduleGradeLevel ADD CONSTRAINT FK_226b3d_BellSchedule FOREIGN KEY (BellScheduleName, SchoolId)
REFERENCES edfi.BellSchedule (BellScheduleName, SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.BellScheduleGradeLevel ADD CONSTRAINT FK_226b3d_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.Calendar ADD CONSTRAINT FK_d5d0a3_CalendarTypeDescriptor FOREIGN KEY (CalendarTypeDescriptorId)
REFERENCES edfi.CalendarTypeDescriptor (CalendarTypeDescriptorId)
;

ALTER TABLE edfi.Calendar ADD CONSTRAINT FK_d5d0a3_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.Calendar ADD CONSTRAINT FK_d5d0a3_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.CalendarDate ADD CONSTRAINT FK_8a9a67_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
;

ALTER TABLE edfi.CalendarDateCalendarEvent ADD CONSTRAINT FK_0789bb_CalendarDate FOREIGN KEY (CalendarCode, Date, SchoolId, SchoolYear)
REFERENCES edfi.CalendarDate (CalendarCode, Date, SchoolId, SchoolYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.CalendarDateCalendarEvent ADD CONSTRAINT FK_0789bb_CalendarEventDescriptor FOREIGN KEY (CalendarEventDescriptorId)
REFERENCES edfi.CalendarEventDescriptor (CalendarEventDescriptorId)
;

ALTER TABLE edfi.CalendarEventDescriptor ADD CONSTRAINT FK_f598e5_Descriptor FOREIGN KEY (CalendarEventDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CalendarGradeLevel ADD CONSTRAINT FK_07722c_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.CalendarGradeLevel ADD CONSTRAINT FK_07722c_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.CalendarTypeDescriptor ADD CONSTRAINT FK_aed500_Descriptor FOREIGN KEY (CalendarTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CareerPathwayDescriptor ADD CONSTRAINT FK_768c51_Descriptor FOREIGN KEY (CareerPathwayDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CharterApprovalAgencyTypeDescriptor ADD CONSTRAINT FK_9af5be_Descriptor FOREIGN KEY (CharterApprovalAgencyTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CharterStatusDescriptor ADD CONSTRAINT FK_7c48cd_Descriptor FOREIGN KEY (CharterStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_AccountTypeDescriptor FOREIGN KEY (AccountTypeDescriptorId)
REFERENCES edfi.AccountTypeDescriptor (AccountTypeDescriptorId)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_BalanceSheetDimension FOREIGN KEY (BalanceSheetCode, FiscalYear)
REFERENCES edfi.BalanceSheetDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_FunctionDimension FOREIGN KEY (FunctionCode, FiscalYear)
REFERENCES edfi.FunctionDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_FundDimension FOREIGN KEY (FundCode, FiscalYear)
REFERENCES edfi.FundDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_ObjectDimension FOREIGN KEY (ObjectCode, FiscalYear)
REFERENCES edfi.ObjectDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_OperationalUnitDimension FOREIGN KEY (OperationalUnitCode, FiscalYear)
REFERENCES edfi.OperationalUnitDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_ProgramDimension FOREIGN KEY (ProgramCode, FiscalYear)
REFERENCES edfi.ProgramDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_ProjectDimension FOREIGN KEY (ProjectCode, FiscalYear)
REFERENCES edfi.ProjectDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_SourceDimension FOREIGN KEY (SourceCode, FiscalYear)
REFERENCES edfi.SourceDimension (Code, FiscalYear)
;

ALTER TABLE edfi.ChartOfAccountReportingTag ADD CONSTRAINT FK_8422f4_ChartOfAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.ChartOfAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.ChartOfAccountReportingTag ADD CONSTRAINT FK_8422f4_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.CitizenshipStatusDescriptor ADD CONSTRAINT FK_4c97e8_Descriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ClassPeriod ADD CONSTRAINT FK_01fe80_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.ClassPeriodMeetingTime ADD CONSTRAINT FK_435263_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.ClassroomPositionDescriptor ADD CONSTRAINT FK_c2dd12_Descriptor FOREIGN KEY (ClassroomPositionDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_CohortScopeDescriptor FOREIGN KEY (CohortScopeDescriptorId)
REFERENCES edfi.CohortScopeDescriptor (CohortScopeDescriptorId)
;

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_CohortTypeDescriptor FOREIGN KEY (CohortTypeDescriptorId)
REFERENCES edfi.CohortTypeDescriptor (CohortTypeDescriptorId)
;

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.CohortProgram ADD CONSTRAINT FK_59fcb5_Cohort FOREIGN KEY (CohortIdentifier, EducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CohortProgram ADD CONSTRAINT FK_59fcb5_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.CohortScopeDescriptor ADD CONSTRAINT FK_36f154_Descriptor FOREIGN KEY (CohortScopeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CohortTypeDescriptor ADD CONSTRAINT FK_af0263_Descriptor FOREIGN KEY (CohortTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CohortYearTypeDescriptor ADD CONSTRAINT FK_1d837f_Descriptor FOREIGN KEY (CohortYearTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CommunityOrganization ADD CONSTRAINT FK_636fcf_EducationOrganization FOREIGN KEY (CommunityOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_CommunityOrganization FOREIGN KEY (CommunityOrganizationId)
REFERENCES edfi.CommunityOrganization (CommunityOrganizationId)
;

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_EducationOrganization FOREIGN KEY (CommunityProviderId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_ProviderCategoryDescriptor FOREIGN KEY (ProviderCategoryDescriptorId)
REFERENCES edfi.ProviderCategoryDescriptor (ProviderCategoryDescriptorId)
;

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_ProviderProfitabilityDescriptor FOREIGN KEY (ProviderProfitabilityDescriptorId)
REFERENCES edfi.ProviderProfitabilityDescriptor (ProviderProfitabilityDescriptorId)
;

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_ProviderStatusDescriptor FOREIGN KEY (ProviderStatusDescriptorId)
REFERENCES edfi.ProviderStatusDescriptor (ProviderStatusDescriptorId)
;

ALTER TABLE edfi.CommunityProviderLicense ADD CONSTRAINT FK_f092ff_CommunityProvider FOREIGN KEY (CommunityProviderId)
REFERENCES edfi.CommunityProvider (CommunityProviderId)
;

ALTER TABLE edfi.CommunityProviderLicense ADD CONSTRAINT FK_f092ff_LicenseStatusDescriptor FOREIGN KEY (LicenseStatusDescriptorId)
REFERENCES edfi.LicenseStatusDescriptor (LicenseStatusDescriptorId)
;

ALTER TABLE edfi.CommunityProviderLicense ADD CONSTRAINT FK_f092ff_LicenseTypeDescriptor FOREIGN KEY (LicenseTypeDescriptorId)
REFERENCES edfi.LicenseTypeDescriptor (LicenseTypeDescriptorId)
;

ALTER TABLE edfi.CompetencyLevelDescriptor ADD CONSTRAINT FK_b82261_Descriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CompetencyObjective ADD CONSTRAINT FK_5e9932_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.CompetencyObjective ADD CONSTRAINT FK_5e9932_GradeLevelDescriptor FOREIGN KEY (ObjectiveGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.Contact ADD CONSTRAINT FK_2b5c3d_LevelOfEducationDescriptor FOREIGN KEY (HighestCompletedLevelOfEducationDescriptorId)
REFERENCES edfi.LevelOfEducationDescriptor (LevelOfEducationDescriptorId)
;

ALTER TABLE edfi.Contact ADD CONSTRAINT FK_2b5c3d_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

ALTER TABLE edfi.Contact ADD CONSTRAINT FK_2b5c3d_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.ContactAddress ADD CONSTRAINT FK_720058_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.ContactAddress ADD CONSTRAINT FK_720058_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactAddress ADD CONSTRAINT FK_720058_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

ALTER TABLE edfi.ContactAddress ADD CONSTRAINT FK_720058_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.ContactAddressPeriod ADD CONSTRAINT FK_6b884f_ContactAddress FOREIGN KEY (ContactUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.ContactAddress (ContactUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactElectronicMail ADD CONSTRAINT FK_4007e0_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactElectronicMail ADD CONSTRAINT FK_4007e0_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

ALTER TABLE edfi.ContactInternationalAddress ADD CONSTRAINT FK_358692_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.ContactInternationalAddress ADD CONSTRAINT FK_358692_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactInternationalAddress ADD CONSTRAINT FK_358692_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.ContactLanguage ADD CONSTRAINT FK_42109f_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactLanguage ADD CONSTRAINT FK_42109f_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

ALTER TABLE edfi.ContactLanguageUse ADD CONSTRAINT FK_050c1b_ContactLanguage FOREIGN KEY (ContactUSI, LanguageDescriptorId)
REFERENCES edfi.ContactLanguage (ContactUSI, LanguageDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactLanguageUse ADD CONSTRAINT FK_050c1b_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

ALTER TABLE edfi.ContactOtherName ADD CONSTRAINT FK_91b095_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactOtherName ADD CONSTRAINT FK_91b095_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

ALTER TABLE edfi.ContactPersonalIdentificationDocument ADD CONSTRAINT FK_277c31_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactPersonalIdentificationDocument ADD CONSTRAINT FK_277c31_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.ContactPersonalIdentificationDocument ADD CONSTRAINT FK_277c31_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

ALTER TABLE edfi.ContactPersonalIdentificationDocument ADD CONSTRAINT FK_277c31_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

ALTER TABLE edfi.ContactTelephone ADD CONSTRAINT FK_225a51_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContactTelephone ADD CONSTRAINT FK_225a51_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

ALTER TABLE edfi.ContactTypeDescriptor ADD CONSTRAINT FK_47719b_Descriptor FOREIGN KEY (ContactTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContentClassDescriptor ADD CONSTRAINT FK_14a617_Descriptor FOREIGN KEY (ContentClassDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ContinuationOfServicesReasonDescriptor ADD CONSTRAINT FK_10230d_Descriptor FOREIGN KEY (ContinuationOfServicesReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CostRateDescriptor ADD CONSTRAINT FK_b1268b_Descriptor FOREIGN KEY (CostRateDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CountryDescriptor ADD CONSTRAINT FK_6e4222_Descriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CareerPathwayDescriptor FOREIGN KEY (CareerPathwayDescriptorId)
REFERENCES edfi.CareerPathwayDescriptor (CareerPathwayDescriptorId)
;

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CourseDefinedByDescriptor FOREIGN KEY (CourseDefinedByDescriptorId)
REFERENCES edfi.CourseDefinedByDescriptor (CourseDefinedByDescriptorId)
;

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CourseGPAApplicabilityDescriptor FOREIGN KEY (CourseGPAApplicabilityDescriptorId)
REFERENCES edfi.CourseGPAApplicabilityDescriptor (CourseGPAApplicabilityDescriptorId)
;

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CreditTypeDescriptor FOREIGN KEY (MinimumAvailableCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CreditTypeDescriptor1 FOREIGN KEY (MaximumAvailableCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.CourseAcademicSubject ADD CONSTRAINT FK_ee5caf_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.CourseAcademicSubject ADD CONSTRAINT FK_ee5caf_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseAttemptResultDescriptor ADD CONSTRAINT FK_306d96_Descriptor FOREIGN KEY (CourseAttemptResultDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseCompetencyLevel ADD CONSTRAINT FK_581f0f_CompetencyLevelDescriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.CompetencyLevelDescriptor (CompetencyLevelDescriptorId)
;

ALTER TABLE edfi.CourseCompetencyLevel ADD CONSTRAINT FK_581f0f_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseDefinedByDescriptor ADD CONSTRAINT FK_a75b16_Descriptor FOREIGN KEY (CourseDefinedByDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseGPAApplicabilityDescriptor ADD CONSTRAINT FK_c55ecc_Descriptor FOREIGN KEY (CourseGPAApplicabilityDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseIdentificationCode ADD CONSTRAINT FK_18889f_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseIdentificationCode ADD CONSTRAINT FK_18889f_CourseIdentificationSystemDescriptor FOREIGN KEY (CourseIdentificationSystemDescriptorId)
REFERENCES edfi.CourseIdentificationSystemDescriptor (CourseIdentificationSystemDescriptorId)
;

ALTER TABLE edfi.CourseIdentificationSystemDescriptor ADD CONSTRAINT FK_e4ce6a_Descriptor FOREIGN KEY (CourseIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseLearningStandard ADD CONSTRAINT FK_644654_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseLearningStandard ADD CONSTRAINT FK_644654_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.CourseLevelCharacteristic ADD CONSTRAINT FK_c7e725_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseLevelCharacteristic ADD CONSTRAINT FK_c7e725_CourseLevelCharacteristicDescriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.CourseLevelCharacteristicDescriptor (CourseLevelCharacteristicDescriptorId)
;

ALTER TABLE edfi.CourseLevelCharacteristicDescriptor ADD CONSTRAINT FK_000820_Descriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseOfferedGradeLevel ADD CONSTRAINT FK_175995_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseOfferedGradeLevel ADD CONSTRAINT FK_175995_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.CourseOffering ADD CONSTRAINT FK_0325c5_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

ALTER TABLE edfi.CourseOffering ADD CONSTRAINT FK_0325c5_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.CourseOffering ADD CONSTRAINT FK_0325c5_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic ADD CONSTRAINT FK_210b6b_CourseLevelCharacteristicDescriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.CourseLevelCharacteristicDescriptor (CourseLevelCharacteristicDescriptorId)
;

ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic ADD CONSTRAINT FK_210b6b_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.CourseOfferingCurriculumUsed ADD CONSTRAINT FK_31bbf7_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.CourseOfferingCurriculumUsed ADD CONSTRAINT FK_31bbf7_CurriculumUsedDescriptor FOREIGN KEY (CurriculumUsedDescriptorId)
REFERENCES edfi.CurriculumUsedDescriptor (CurriculumUsedDescriptorId)
;

ALTER TABLE edfi.CourseOfferingOfferedGradeLevel ADD CONSTRAINT FK_aaa07e_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.CourseOfferingOfferedGradeLevel ADD CONSTRAINT FK_aaa07e_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.CourseRepeatCodeDescriptor ADD CONSTRAINT FK_bc4d3c_Descriptor FOREIGN KEY (CourseRepeatCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_Course FOREIGN KEY (CourseCode, CourseEducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CourseAttemptResultDescriptor FOREIGN KEY (CourseAttemptResultDescriptorId)
REFERENCES edfi.CourseAttemptResultDescriptor (CourseAttemptResultDescriptorId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CourseRepeatCodeDescriptor FOREIGN KEY (CourseRepeatCodeDescriptorId)
REFERENCES edfi.CourseRepeatCodeDescriptor (CourseRepeatCodeDescriptorId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CreditTypeDescriptor FOREIGN KEY (AttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CreditTypeDescriptor1 FOREIGN KEY (EarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_EducationOrganization FOREIGN KEY (ExternalEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_GradeLevelDescriptor FOREIGN KEY (WhenTakenGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_MethodCreditEarnedDescriptor FOREIGN KEY (MethodCreditEarnedDescriptorId)
REFERENCES edfi.MethodCreditEarnedDescriptor (MethodCreditEarnedDescriptorId)
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
;

ALTER TABLE edfi.CourseTranscriptAcademicSubject ADD CONSTRAINT FK_354642_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.CourseTranscriptAcademicSubject ADD CONSTRAINT FK_354642_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseTranscriptAlternativeCourseIdentificationCode ADD CONSTRAINT FK_6621ee_CourseIdentificationSystemDescriptor FOREIGN KEY (CourseIdentificationSystemDescriptorId)
REFERENCES edfi.CourseIdentificationSystemDescriptor (CourseIdentificationSystemDescriptorId)
;

ALTER TABLE edfi.CourseTranscriptAlternativeCourseIdentificationCode ADD CONSTRAINT FK_6621ee_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseTranscriptCreditCategory ADD CONSTRAINT FK_ab7096_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseTranscriptCreditCategory ADD CONSTRAINT FK_ab7096_CreditCategoryDescriptor FOREIGN KEY (CreditCategoryDescriptorId)
REFERENCES edfi.CreditCategoryDescriptor (CreditCategoryDescriptorId)
;

ALTER TABLE edfi.CourseTranscriptEarnedAdditionalCredits ADD CONSTRAINT FK_b50e36_AdditionalCreditTypeDescriptor FOREIGN KEY (AdditionalCreditTypeDescriptorId)
REFERENCES edfi.AdditionalCreditTypeDescriptor (AdditionalCreditTypeDescriptorId)
;

ALTER TABLE edfi.CourseTranscriptEarnedAdditionalCredits ADD CONSTRAINT FK_b50e36_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseTranscriptPartialCourseTranscriptAwards ADD CONSTRAINT FK_e811ad_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseTranscriptPartialCourseTranscriptAwards ADD CONSTRAINT FK_e811ad_MethodCreditEarnedDescriptor FOREIGN KEY (MethodCreditEarnedDescriptorId)
REFERENCES edfi.MethodCreditEarnedDescriptor (MethodCreditEarnedDescriptorId)
;

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_CredentialFieldDescriptor FOREIGN KEY (CredentialFieldDescriptorId)
REFERENCES edfi.CredentialFieldDescriptor (CredentialFieldDescriptorId)
;

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_CredentialTypeDescriptor FOREIGN KEY (CredentialTypeDescriptorId)
REFERENCES edfi.CredentialTypeDescriptor (CredentialTypeDescriptorId)
;

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_StateAbbreviationDescriptor FOREIGN KEY (StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_TeachingCredentialBasisDescriptor FOREIGN KEY (TeachingCredentialBasisDescriptorId)
REFERENCES edfi.TeachingCredentialBasisDescriptor (TeachingCredentialBasisDescriptorId)
;

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_TeachingCredentialDescriptor FOREIGN KEY (TeachingCredentialDescriptorId)
REFERENCES edfi.TeachingCredentialDescriptor (TeachingCredentialDescriptorId)
;

ALTER TABLE edfi.CredentialAcademicSubject ADD CONSTRAINT FK_1141c9_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.CredentialAcademicSubject ADD CONSTRAINT FK_1141c9_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CredentialEndorsement ADD CONSTRAINT FK_57f7d2_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CredentialFieldDescriptor ADD CONSTRAINT FK_4eab15_Descriptor FOREIGN KEY (CredentialFieldDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CredentialGradeLevel ADD CONSTRAINT FK_f05a16_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CredentialGradeLevel ADD CONSTRAINT FK_f05a16_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.CredentialTypeDescriptor ADD CONSTRAINT FK_5a9f1d_Descriptor FOREIGN KEY (CredentialTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CreditCategoryDescriptor ADD CONSTRAINT FK_2e3556_Descriptor FOREIGN KEY (CreditCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CreditTypeDescriptor ADD CONSTRAINT FK_e31da0_Descriptor FOREIGN KEY (CreditTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CTEProgramServiceDescriptor ADD CONSTRAINT FK_a631b1_Descriptor FOREIGN KEY (CTEProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CurriculumUsedDescriptor ADD CONSTRAINT FK_cec9f6_Descriptor FOREIGN KEY (CurriculumUsedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DeliveryMethodDescriptor ADD CONSTRAINT FK_85b4c1_Descriptor FOREIGN KEY (DeliveryMethodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DescriptorMappingModelEntity ADD CONSTRAINT FK_7433b4_DescriptorMapping FOREIGN KEY (MappedNamespace, MappedValue, Namespace, Value)
REFERENCES edfi.DescriptorMapping (MappedNamespace, MappedValue, Namespace, Value)
ON DELETE CASCADE
;

ALTER TABLE edfi.DescriptorMappingModelEntity ADD CONSTRAINT FK_7433b4_ModelEntityDescriptor FOREIGN KEY (ModelEntityDescriptorId)
REFERENCES edfi.ModelEntityDescriptor (ModelEntityDescriptorId)
;

ALTER TABLE edfi.DiagnosisDescriptor ADD CONSTRAINT FK_843d48_Descriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DiplomaLevelDescriptor ADD CONSTRAINT FK_d5a798_Descriptor FOREIGN KEY (DiplomaLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DiplomaTypeDescriptor ADD CONSTRAINT FK_e9ffa4_Descriptor FOREIGN KEY (DiplomaTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisabilityDescriptor ADD CONSTRAINT FK_f7280b_Descriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisabilityDesignationDescriptor ADD CONSTRAINT FK_8b9171_Descriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisabilityDeterminationSourceTypeDescriptor ADD CONSTRAINT FK_a07cb4_Descriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineAction ADD CONSTRAINT FK_eec7b6_DisciplineActionLengthDifferenceReasonDescriptor FOREIGN KEY (DisciplineActionLengthDifferenceReasonDescriptorId)
REFERENCES edfi.DisciplineActionLengthDifferenceReasonDescriptor (DisciplineActionLengthDifferenceReasonDescriptorId)
;

ALTER TABLE edfi.DisciplineAction ADD CONSTRAINT FK_eec7b6_School FOREIGN KEY (AssignmentSchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.DisciplineAction ADD CONSTRAINT FK_eec7b6_School1 FOREIGN KEY (ResponsibilitySchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.DisciplineAction ADD CONSTRAINT FK_eec7b6_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.DisciplineActionDiscipline ADD CONSTRAINT FK_73601f_DisciplineAction FOREIGN KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
REFERENCES edfi.DisciplineAction (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineActionDiscipline ADD CONSTRAINT FK_73601f_DisciplineDescriptor FOREIGN KEY (DisciplineDescriptorId)
REFERENCES edfi.DisciplineDescriptor (DisciplineDescriptorId)
;

ALTER TABLE edfi.DisciplineActionLengthDifferenceReasonDescriptor ADD CONSTRAINT FK_e1a229_Descriptor FOREIGN KEY (DisciplineActionLengthDifferenceReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineActionStaff ADD CONSTRAINT FK_30e866_DisciplineAction FOREIGN KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
REFERENCES edfi.DisciplineAction (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineActionStaff ADD CONSTRAINT FK_30e866_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_2c4cdb_DisciplineAction FOREIGN KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
REFERENCES edfi.DisciplineAction (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_2c4cdb_StudentDisciplineIncidentBehaviorAssociation FOREIGN KEY (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentBehaviorAssociation (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
;

ALTER TABLE edfi.DisciplineDescriptor ADD CONSTRAINT FK_673b0a_Descriptor FOREIGN KEY (DisciplineDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineIncident ADD CONSTRAINT FK_e45c0b_IncidentLocationDescriptor FOREIGN KEY (IncidentLocationDescriptorId)
REFERENCES edfi.IncidentLocationDescriptor (IncidentLocationDescriptorId)
;

ALTER TABLE edfi.DisciplineIncident ADD CONSTRAINT FK_e45c0b_ReporterDescriptionDescriptor FOREIGN KEY (ReporterDescriptionDescriptorId)
REFERENCES edfi.ReporterDescriptionDescriptor (ReporterDescriptionDescriptorId)
;

ALTER TABLE edfi.DisciplineIncident ADD CONSTRAINT FK_e45c0b_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.DisciplineIncidentBehavior ADD CONSTRAINT FK_cabdcb_BehaviorDescriptor FOREIGN KEY (BehaviorDescriptorId)
REFERENCES edfi.BehaviorDescriptor (BehaviorDescriptorId)
;

ALTER TABLE edfi.DisciplineIncidentBehavior ADD CONSTRAINT FK_cabdcb_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineIncidentExternalParticipant ADD CONSTRAINT FK_0d16f7_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineIncidentExternalParticipant ADD CONSTRAINT FK_0d16f7_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

ALTER TABLE edfi.DisciplineIncidentParticipationCodeDescriptor ADD CONSTRAINT FK_923786_Descriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineIncidentWeapon ADD CONSTRAINT FK_a545e5_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineIncidentWeapon ADD CONSTRAINT FK_a545e5_WeaponDescriptor FOREIGN KEY (WeaponDescriptorId)
REFERENCES edfi.WeaponDescriptor (WeaponDescriptorId)
;

ALTER TABLE edfi.EducationalEnvironmentDescriptor ADD CONSTRAINT FK_0f941f_Descriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_ContentClassDescriptor FOREIGN KEY (ContentClassDescriptorId)
REFERENCES edfi.ContentClassDescriptor (ContentClassDescriptorId)
;

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_CostRateDescriptor FOREIGN KEY (CostRateDescriptorId)
REFERENCES edfi.CostRateDescriptor (CostRateDescriptorId)
;

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_InteractivityStyleDescriptor FOREIGN KEY (InteractivityStyleDescriptorId)
REFERENCES edfi.InteractivityStyleDescriptor (InteractivityStyleDescriptorId)
;

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.EducationContentAppropriateGradeLevel ADD CONSTRAINT FK_0a2145_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContentAppropriateGradeLevel ADD CONSTRAINT FK_0a2145_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.EducationContentAppropriateSex ADD CONSTRAINT FK_9b6ed1_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContentAppropriateSex ADD CONSTRAINT FK_9b6ed1_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.EducationContentAuthor ADD CONSTRAINT FK_f605af_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContentDerivativeSourceEducationContent ADD CONSTRAINT FK_98cd8a_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContentDerivativeSourceEducationContent ADD CONSTRAINT FK_98cd8a_EducationContent1 FOREIGN KEY (DerivativeSourceContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

ALTER TABLE edfi.EducationContentDerivativeSourceLearningResourceMetadataURI ADD CONSTRAINT FK_421bfa_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContentDerivativeSourceURI ADD CONSTRAINT FK_047c7a_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContentLanguage ADD CONSTRAINT FK_d678fa_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContentLanguage ADD CONSTRAINT FK_d678fa_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

ALTER TABLE edfi.EducationOrganization ADD CONSTRAINT FK_4525e6_OperationalStatusDescriptor FOREIGN KEY (OperationalStatusDescriptorId)
REFERENCES edfi.OperationalStatusDescriptor (OperationalStatusDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationAddressPeriod ADD CONSTRAINT FK_d44be7_EducationOrganizationAddress FOREIGN KEY (EducationOrganizationId, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.EducationOrganizationAddress (EducationOrganizationId, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationAssociationTypeDescriptor ADD CONSTRAINT FK_d9f485_Descriptor FOREIGN KEY (EducationOrganizationAssociationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationCategory ADD CONSTRAINT FK_427110_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationCategory ADD CONSTRAINT FK_427110_EducationOrganizationCategoryDescriptor FOREIGN KEY (EducationOrganizationCategoryDescriptorId)
REFERENCES edfi.EducationOrganizationCategoryDescriptor (EducationOrganizationCategoryDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationCategoryDescriptor ADD CONSTRAINT FK_7791ef_Descriptor FOREIGN KEY (EducationOrganizationCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationIdentificationCode ADD CONSTRAINT FK_4a715c_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationIdentificationCode ADD CONSTRAINT FK_4a715c_EducationOrganizationIdentificationSystemDescriptor FOREIGN KEY (EducationOrganizationIdentificationSystemDescriptorId)
REFERENCES edfi.EducationOrganizationIdentificationSystemDescriptor (EducationOrganizationIdentificationSystemDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationIdentificationSystemDescriptor ADD CONSTRAINT FK_cbfd5d_Descriptor FOREIGN KEY (EducationOrganizationIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_IndicatorDescriptor FOREIGN KEY (IndicatorDescriptorId)
REFERENCES edfi.IndicatorDescriptor (IndicatorDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_IndicatorGroupDescriptor FOREIGN KEY (IndicatorGroupDescriptorId)
REFERENCES edfi.IndicatorGroupDescriptor (IndicatorGroupDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_IndicatorLevelDescriptor FOREIGN KEY (IndicatorLevelDescriptorId)
REFERENCES edfi.IndicatorLevelDescriptor (IndicatorLevelDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationIndicatorPeriod ADD CONSTRAINT FK_8486ae_EducationOrganizationIndicator FOREIGN KEY (EducationOrganizationId, IndicatorDescriptorId)
REFERENCES edfi.EducationOrganizationIndicator (EducationOrganizationId, IndicatorDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationInstitutionTelephone ADD CONSTRAINT FK_79895a_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationInstitutionTelephone ADD CONSTRAINT FK_79895a_InstitutionTelephoneNumberTypeDescriptor FOREIGN KEY (InstitutionTelephoneNumberTypeDescriptorId)
REFERENCES edfi.InstitutionTelephoneNumberTypeDescriptor (InstitutionTelephoneNumberTypeDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationInternationalAddress ADD CONSTRAINT FK_0ee746_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationInternationalAddress ADD CONSTRAINT FK_0ee746_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationInternationalAddress ADD CONSTRAINT FK_0ee746_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD CONSTRAINT FK_e670ae_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD CONSTRAINT FK_e670ae_InterventionPrescription FOREIGN KEY (InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
;

ALTER TABLE edfi.EducationOrganizationNetwork ADD CONSTRAINT FK_e88dea_EducationOrganization FOREIGN KEY (EducationOrganizationNetworkId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationNetwork ADD CONSTRAINT FK_e88dea_NetworkPurposeDescriptor FOREIGN KEY (NetworkPurposeDescriptorId)
REFERENCES edfi.NetworkPurposeDescriptor (NetworkPurposeDescriptorId)
;

ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD CONSTRAINT FK_252151_EducationOrganization FOREIGN KEY (MemberEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD CONSTRAINT FK_252151_EducationOrganizationNetwork FOREIGN KEY (EducationOrganizationNetworkId)
REFERENCES edfi.EducationOrganizationNetwork (EducationOrganizationNetworkId)
;

ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD CONSTRAINT FK_74e4e5_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD CONSTRAINT FK_74e4e5_EducationOrganization1 FOREIGN KEY (PeerEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.EducationPlanDescriptor ADD CONSTRAINT FK_bb10e3_Descriptor FOREIGN KEY (EducationPlanDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationServiceCenter ADD CONSTRAINT FK_43bbe1_EducationOrganization FOREIGN KEY (EducationServiceCenterId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationServiceCenter ADD CONSTRAINT FK_43bbe1_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
;

ALTER TABLE edfi.ElectronicMailTypeDescriptor ADD CONSTRAINT FK_15fde6_Descriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EligibilityDelayReasonDescriptor ADD CONSTRAINT FK_be0937_Descriptor FOREIGN KEY (EligibilityDelayReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EligibilityEvaluationTypeDescriptor ADD CONSTRAINT FK_445555_Descriptor FOREIGN KEY (EligibilityEvaluationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EmploymentStatusDescriptor ADD CONSTRAINT FK_5ccb7e_Descriptor FOREIGN KEY (EmploymentStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EnrollmentTypeDescriptor ADD CONSTRAINT FK_d3c777_Descriptor FOREIGN KEY (EnrollmentTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EntryGradeLevelReasonDescriptor ADD CONSTRAINT FK_737b8e_Descriptor FOREIGN KEY (EntryGradeLevelReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EntryTypeDescriptor ADD CONSTRAINT FK_497112_Descriptor FOREIGN KEY (EntryTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EvaluationDelayReasonDescriptor ADD CONSTRAINT FK_db2c46_Descriptor FOREIGN KEY (EvaluationDelayReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EvaluationPeriodDescriptor ADD CONSTRAINT FK_83ff2a_Descriptor FOREIGN KEY (EvaluationPeriodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EvaluationRubricDimension ADD CONSTRAINT FK_1b7ccf_ProgramEvaluationElement FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluationElement (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.EvaluationRubricDimension ADD CONSTRAINT FK_1b7ccf_RatingLevelDescriptor FOREIGN KEY (EvaluationRubricRatingLevelDescriptorId)
REFERENCES edfi.RatingLevelDescriptor (RatingLevelDescriptorId)
;

ALTER TABLE edfi.EvaluationTypeDescriptor ADD CONSTRAINT FK_67cd19_Descriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EventCircumstanceDescriptor ADD CONSTRAINT FK_3a704d_Descriptor FOREIGN KEY (EventCircumstanceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ExitWithdrawTypeDescriptor ADD CONSTRAINT FK_0e8b13_Descriptor FOREIGN KEY (ExitWithdrawTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.FeederSchoolAssociation ADD CONSTRAINT FK_11f7b6_School FOREIGN KEY (FeederSchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.FeederSchoolAssociation ADD CONSTRAINT FK_11f7b6_School1 FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.FinancialCollectionDescriptor ADD CONSTRAINT FK_6dc716_Descriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.FunctionDimensionReportingTag ADD CONSTRAINT FK_8d455d_FunctionDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.FunctionDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.FunctionDimensionReportingTag ADD CONSTRAINT FK_8d455d_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.FundDimensionReportingTag ADD CONSTRAINT FK_7062bd_FundDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.FundDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.FundDimensionReportingTag ADD CONSTRAINT FK_7062bd_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_ReasonExitedDescriptor FOREIGN KEY (ReasonExitedDescriptorId)
REFERENCES edfi.ReasonExitedDescriptor (ReasonExitedDescriptorId)
;

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.GeneralStudentProgramAssociationProgramParticipationStatus ADD CONSTRAINT FK_0855d2_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.GeneralStudentProgramAssociationProgramParticipationStatus ADD CONSTRAINT FK_0855d2_ParticipationStatusDescriptor FOREIGN KEY (ParticipationStatusDescriptorId)
REFERENCES edfi.ParticipationStatusDescriptor (ParticipationStatusDescriptorId)
;

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_GradeTypeDescriptor FOREIGN KEY (GradeTypeDescriptorId)
REFERENCES edfi.GradeTypeDescriptor (GradeTypeDescriptorId)
;

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, SchoolId, GradingPeriodSchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_PerformanceBaseConversionDescriptor FOREIGN KEY (PerformanceBaseConversionDescriptorId)
REFERENCES edfi.PerformanceBaseConversionDescriptor (PerformanceBaseConversionDescriptorId)
;

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_StudentSectionAssociation FOREIGN KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAssociation (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON UPDATE CASCADE
;

ALTER TABLE edfi.GradebookEntry ADD CONSTRAINT FK_466cfa_GradebookEntryTypeDescriptor FOREIGN KEY (GradebookEntryTypeDescriptorId)
REFERENCES edfi.GradebookEntryTypeDescriptor (GradebookEntryTypeDescriptorId)
;

ALTER TABLE edfi.GradebookEntry ADD CONSTRAINT FK_466cfa_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

ALTER TABLE edfi.GradebookEntry ADD CONSTRAINT FK_466cfa_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.GradebookEntryLearningStandard ADD CONSTRAINT FK_c7b5a8_GradebookEntry FOREIGN KEY (GradebookEntryIdentifier, Namespace)
REFERENCES edfi.GradebookEntry (GradebookEntryIdentifier, Namespace)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.GradebookEntryLearningStandard ADD CONSTRAINT FK_c7b5a8_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.GradebookEntryTypeDescriptor ADD CONSTRAINT FK_45eb00_Descriptor FOREIGN KEY (GradebookEntryTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GradeLearningStandardGrade ADD CONSTRAINT FK_92f7f8_Grade FOREIGN KEY (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolYear, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.Grade (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolYear, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.GradeLearningStandardGrade ADD CONSTRAINT FK_92f7f8_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.GradeLearningStandardGrade ADD CONSTRAINT FK_92f7f8_PerformanceBaseConversionDescriptor FOREIGN KEY (PerformanceBaseConversionDescriptorId)
REFERENCES edfi.PerformanceBaseConversionDescriptor (PerformanceBaseConversionDescriptorId)
;

ALTER TABLE edfi.GradeLevelDescriptor ADD CONSTRAINT FK_3c9538_Descriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GradePointAverageTypeDescriptor ADD CONSTRAINT FK_95d02c_Descriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GradeTypeDescriptor ADD CONSTRAINT FK_c8a182_Descriptor FOREIGN KEY (GradeTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GradingPeriod ADD CONSTRAINT FK_5a18f9_GradingPeriodDescriptor FOREIGN KEY (GradingPeriodDescriptorId)
REFERENCES edfi.GradingPeriodDescriptor (GradingPeriodDescriptorId)
;

ALTER TABLE edfi.GradingPeriod ADD CONSTRAINT FK_5a18f9_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.GradingPeriod ADD CONSTRAINT FK_5a18f9_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.GradingPeriodDescriptor ADD CONSTRAINT FK_1f0f64_Descriptor FOREIGN KEY (GradingPeriodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_CreditTypeDescriptor FOREIGN KEY (TotalRequiredCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_GraduationPlanTypeDescriptor FOREIGN KEY (GraduationPlanTypeDescriptorId)
REFERENCES edfi.GraduationPlanTypeDescriptor (GraduationPlanTypeDescriptorId)
;

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_SchoolYearType FOREIGN KEY (GraduationSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.GraduationPlanCreditsByCourse ADD CONSTRAINT FK_44e78d_CreditTypeDescriptor FOREIGN KEY (CreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.GraduationPlanCreditsByCourse ADD CONSTRAINT FK_44e78d_GradeLevelDescriptor FOREIGN KEY (WhenTakenGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.GraduationPlanCreditsByCourse ADD CONSTRAINT FK_44e78d_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanCreditsByCourseCourse ADD CONSTRAINT FK_dafcc7_Course FOREIGN KEY (CourseCode, CourseEducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

ALTER TABLE edfi.GraduationPlanCreditsByCourseCourse ADD CONSTRAINT FK_dafcc7_GraduationPlanCreditsByCourse FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, CourseSetName)
REFERENCES edfi.GraduationPlanCreditsByCourse (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, CourseSetName)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanCreditsByCreditCategory ADD CONSTRAINT FK_ddfc9b_CreditCategoryDescriptor FOREIGN KEY (CreditCategoryDescriptorId)
REFERENCES edfi.CreditCategoryDescriptor (CreditCategoryDescriptorId)
;

ALTER TABLE edfi.GraduationPlanCreditsByCreditCategory ADD CONSTRAINT FK_ddfc9b_CreditTypeDescriptor FOREIGN KEY (CreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.GraduationPlanCreditsByCreditCategory ADD CONSTRAINT FK_ddfc9b_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanCreditsBySubject ADD CONSTRAINT FK_3b5b30_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.GraduationPlanCreditsBySubject ADD CONSTRAINT FK_3b5b30_CreditTypeDescriptor FOREIGN KEY (CreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.GraduationPlanCreditsBySubject ADD CONSTRAINT FK_3b5b30_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanRequiredAssessment ADD CONSTRAINT FK_1a4369_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

ALTER TABLE edfi.GraduationPlanRequiredAssessment ADD CONSTRAINT FK_1a4369_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_GraduationPlanRequiredAssessment FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AssessmentIdentifier, Namespace)
REFERENCES edfi.GraduationPlanRequiredAssessment (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentScore ADD CONSTRAINT FK_db9e7c_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentScore ADD CONSTRAINT FK_db9e7c_GraduationPlanRequiredAssessment FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AssessmentIdentifier, Namespace)
REFERENCES edfi.GraduationPlanRequiredAssessment (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentScore ADD CONSTRAINT FK_db9e7c_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.GraduationPlanTypeDescriptor ADD CONSTRAINT FK_4874e0_Descriptor FOREIGN KEY (GraduationPlanTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GunFreeSchoolsActReportingStatusDescriptor ADD CONSTRAINT FK_086864_Descriptor FOREIGN KEY (GunFreeSchoolsActReportingStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.HomelessPrimaryNighttimeResidenceDescriptor ADD CONSTRAINT FK_41a2b1_Descriptor FOREIGN KEY (HomelessPrimaryNighttimeResidenceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.HomelessProgramServiceDescriptor ADD CONSTRAINT FK_56c464_Descriptor FOREIGN KEY (HomelessProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.IDEAPartDescriptor ADD CONSTRAINT FK_8e5a99_Descriptor FOREIGN KEY (IDEAPartDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.IdentificationDocumentUseDescriptor ADD CONSTRAINT FK_c023c0_Descriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.IncidentLocationDescriptor ADD CONSTRAINT FK_d24f76_Descriptor FOREIGN KEY (IncidentLocationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.IndicatorDescriptor ADD CONSTRAINT FK_ee0bbf_Descriptor FOREIGN KEY (IndicatorDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.IndicatorGroupDescriptor ADD CONSTRAINT FK_e0f6fe_Descriptor FOREIGN KEY (IndicatorGroupDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.IndicatorLevelDescriptor ADD CONSTRAINT FK_05d3f9_Descriptor FOREIGN KEY (IndicatorLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InstitutionTelephoneNumberTypeDescriptor ADD CONSTRAINT FK_d35038_Descriptor FOREIGN KEY (InstitutionTelephoneNumberTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InteractivityStyleDescriptor ADD CONSTRAINT FK_0f0ab7_Descriptor FOREIGN KEY (InteractivityStyleDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InternetAccessDescriptor ADD CONSTRAINT FK_ca0f71_Descriptor FOREIGN KEY (InternetAccessDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InternetAccessTypeInResidenceDescriptor ADD CONSTRAINT FK_8007d5_Descriptor FOREIGN KEY (InternetAccessTypeInResidenceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InternetPerformanceInResidenceDescriptor ADD CONSTRAINT FK_256049_Descriptor FOREIGN KEY (InternetPerformanceInResidenceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Intervention ADD CONSTRAINT FK_0fae05_DeliveryMethodDescriptor FOREIGN KEY (DeliveryMethodDescriptorId)
REFERENCES edfi.DeliveryMethodDescriptor (DeliveryMethodDescriptorId)
;

ALTER TABLE edfi.Intervention ADD CONSTRAINT FK_0fae05_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.Intervention ADD CONSTRAINT FK_0fae05_InterventionClassDescriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.InterventionClassDescriptor (InterventionClassDescriptorId)
;

ALTER TABLE edfi.InterventionAppropriateGradeLevel ADD CONSTRAINT FK_3d5433_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.InterventionAppropriateGradeLevel ADD CONSTRAINT FK_3d5433_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionAppropriateSex ADD CONSTRAINT FK_a8bc47_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionAppropriateSex ADD CONSTRAINT FK_a8bc47_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.InterventionClassDescriptor ADD CONSTRAINT FK_183bc5_Descriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionDiagnosis ADD CONSTRAINT FK_b2e25d_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

ALTER TABLE edfi.InterventionDiagnosis ADD CONSTRAINT FK_b2e25d_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionEducationContent ADD CONSTRAINT FK_3c823d_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

ALTER TABLE edfi.InterventionEducationContent ADD CONSTRAINT FK_3c823d_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionEffectivenessRatingDescriptor ADD CONSTRAINT FK_c0c58a_Descriptor FOREIGN KEY (InterventionEffectivenessRatingDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionInterventionPrescription ADD CONSTRAINT FK_e79fe2_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionInterventionPrescription ADD CONSTRAINT FK_e79fe2_InterventionPrescription FOREIGN KEY (InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
;

ALTER TABLE edfi.InterventionLearningResourceMetadataURI ADD CONSTRAINT FK_c7db20_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionMeetingTime ADD CONSTRAINT FK_a64540_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPopulationServed ADD CONSTRAINT FK_cbeb99_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPopulationServed ADD CONSTRAINT FK_cbeb99_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

ALTER TABLE edfi.InterventionPrescription ADD CONSTRAINT FK_e93bc3_DeliveryMethodDescriptor FOREIGN KEY (DeliveryMethodDescriptorId)
REFERENCES edfi.DeliveryMethodDescriptor (DeliveryMethodDescriptorId)
;

ALTER TABLE edfi.InterventionPrescription ADD CONSTRAINT FK_e93bc3_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.InterventionPrescription ADD CONSTRAINT FK_e93bc3_InterventionClassDescriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.InterventionClassDescriptor (InterventionClassDescriptorId)
;

ALTER TABLE edfi.InterventionPrescriptionAppropriateGradeLevel ADD CONSTRAINT FK_4736c7_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.InterventionPrescriptionAppropriateGradeLevel ADD CONSTRAINT FK_4736c7_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPrescriptionAppropriateSex ADD CONSTRAINT FK_4a3f1c_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPrescriptionAppropriateSex ADD CONSTRAINT FK_4a3f1c_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.InterventionPrescriptionDiagnosis ADD CONSTRAINT FK_9e6edd_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

ALTER TABLE edfi.InterventionPrescriptionDiagnosis ADD CONSTRAINT FK_9e6edd_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPrescriptionEducationContent ADD CONSTRAINT FK_3ab5d4_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

ALTER TABLE edfi.InterventionPrescriptionEducationContent ADD CONSTRAINT FK_3ab5d4_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPrescriptionLearningResourceMetadataURI ADD CONSTRAINT FK_e12298_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPrescriptionPopulationServed ADD CONSTRAINT FK_a984df_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionPrescriptionPopulationServed ADD CONSTRAINT FK_a984df_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

ALTER TABLE edfi.InterventionPrescriptionURI ADD CONSTRAINT FK_4acf8e_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStaff ADD CONSTRAINT FK_6fa51c_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStaff ADD CONSTRAINT FK_6fa51c_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_DeliveryMethodDescriptor FOREIGN KEY (DeliveryMethodDescriptorId)
REFERENCES edfi.DeliveryMethodDescriptor (DeliveryMethodDescriptorId)
;

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_InterventionClassDescriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.InterventionClassDescriptor (InterventionClassDescriptorId)
;

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_InterventionPrescription FOREIGN KEY (InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
;

ALTER TABLE edfi.InterventionStudyAppropriateGradeLevel ADD CONSTRAINT FK_87d32b_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.InterventionStudyAppropriateGradeLevel ADD CONSTRAINT FK_87d32b_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStudyAppropriateSex ADD CONSTRAINT FK_d53ee9_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStudyAppropriateSex ADD CONSTRAINT FK_d53ee9_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.InterventionStudyEducationContent ADD CONSTRAINT FK_014e05_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

ALTER TABLE edfi.InterventionStudyEducationContent ADD CONSTRAINT FK_014e05_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_InterventionEffectivenessRatingDescriptor FOREIGN KEY (InterventionEffectivenessRatingDescriptorId)
REFERENCES edfi.InterventionEffectivenessRatingDescriptor (InterventionEffectivenessRatingDescriptorId)
;

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

ALTER TABLE edfi.InterventionStudyLearningResourceMetadataURI ADD CONSTRAINT FK_1dcb14_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStudyPopulationServed ADD CONSTRAINT FK_c45364_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStudyPopulationServed ADD CONSTRAINT FK_c45364_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

ALTER TABLE edfi.InterventionStudyStateAbbreviation ADD CONSTRAINT FK_8e9d64_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionStudyStateAbbreviation ADD CONSTRAINT FK_8e9d64_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.InterventionStudyURI ADD CONSTRAINT FK_9046e7_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionURI ADD CONSTRAINT FK_35afab_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.LanguageDescriptor ADD CONSTRAINT FK_8625fa_Descriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LanguageInstructionProgramServiceDescriptor ADD CONSTRAINT FK_e3a7b7_Descriptor FOREIGN KEY (LanguageInstructionProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LanguageUseDescriptor ADD CONSTRAINT FK_44c593_Descriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandard ADD CONSTRAINT FK_8ceb4c_LearningStandard FOREIGN KEY (ParentLearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.LearningStandard ADD CONSTRAINT FK_8ceb4c_LearningStandardCategoryDescriptor FOREIGN KEY (LearningStandardCategoryDescriptorId)
REFERENCES edfi.LearningStandardCategoryDescriptor (LearningStandardCategoryDescriptorId)
;

ALTER TABLE edfi.LearningStandard ADD CONSTRAINT FK_8ceb4c_LearningStandardScopeDescriptor FOREIGN KEY (LearningStandardScopeDescriptorId)
REFERENCES edfi.LearningStandardScopeDescriptor (LearningStandardScopeDescriptorId)
;

ALTER TABLE edfi.LearningStandardAcademicSubject ADD CONSTRAINT FK_aaade9_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.LearningStandardAcademicSubject ADD CONSTRAINT FK_aaade9_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardCategoryDescriptor ADD CONSTRAINT FK_814fc1_Descriptor FOREIGN KEY (LearningStandardCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardContentStandard ADD CONSTRAINT FK_70f675_EducationOrganization FOREIGN KEY (MandatingEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.LearningStandardContentStandard ADD CONSTRAINT FK_70f675_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardContentStandard ADD CONSTRAINT FK_70f675_PublicationStatusDescriptor FOREIGN KEY (PublicationStatusDescriptorId)
REFERENCES edfi.PublicationStatusDescriptor (PublicationStatusDescriptorId)
;

ALTER TABLE edfi.LearningStandardContentStandardAuthor ADD CONSTRAINT FK_4c9e40_LearningStandardContentStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandardContentStandard (LearningStandardId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD CONSTRAINT FK_17c02a_LearningStandard FOREIGN KEY (SourceLearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD CONSTRAINT FK_17c02a_LearningStandard1 FOREIGN KEY (TargetLearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD CONSTRAINT FK_17c02a_LearningStandardEquivalenceStrengthDescriptor FOREIGN KEY (LearningStandardEquivalenceStrengthDescriptorId)
REFERENCES edfi.LearningStandardEquivalenceStrengthDescriptor (LearningStandardEquivalenceStrengthDescriptorId)
;

ALTER TABLE edfi.LearningStandardEquivalenceStrengthDescriptor ADD CONSTRAINT FK_166f6a_Descriptor FOREIGN KEY (LearningStandardEquivalenceStrengthDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardGradeLevel ADD CONSTRAINT FK_38677c_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.LearningStandardGradeLevel ADD CONSTRAINT FK_38677c_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardIdentificationCode ADD CONSTRAINT FK_92327a_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardScopeDescriptor ADD CONSTRAINT FK_af50dc_Descriptor FOREIGN KEY (LearningStandardScopeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LevelOfEducationDescriptor ADD CONSTRAINT FK_e37e5f_Descriptor FOREIGN KEY (LevelOfEducationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LicenseStatusDescriptor ADD CONSTRAINT FK_2db9cf_Descriptor FOREIGN KEY (LicenseStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LicenseTypeDescriptor ADD CONSTRAINT FK_159a96_Descriptor FOREIGN KEY (LicenseTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LimitedEnglishProficiencyDescriptor ADD CONSTRAINT FK_c8bcfe_Descriptor FOREIGN KEY (LimitedEnglishProficiencyDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalAccount ADD CONSTRAINT FK_32eddb_ChartOfAccount FOREIGN KEY (ChartOfAccountIdentifier, ChartOfAccountEducationOrganizationId, FiscalYear)
REFERENCES edfi.ChartOfAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

ALTER TABLE edfi.LocalAccount ADD CONSTRAINT FK_32eddb_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.LocalAccountReportingTag ADD CONSTRAINT FK_c38935_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalAccountReportingTag ADD CONSTRAINT FK_c38935_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.LocalActual ADD CONSTRAINT FK_b6310e_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

ALTER TABLE edfi.LocalActual ADD CONSTRAINT FK_b6310e_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

ALTER TABLE edfi.LocalBudget ADD CONSTRAINT FK_000683_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

ALTER TABLE edfi.LocalBudget ADD CONSTRAINT FK_000683_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

ALTER TABLE edfi.LocalContractedStaff ADD CONSTRAINT FK_4d9b4a_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

ALTER TABLE edfi.LocalContractedStaff ADD CONSTRAINT FK_4d9b4a_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

ALTER TABLE edfi.LocalContractedStaff ADD CONSTRAINT FK_4d9b4a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.LocaleDescriptor ADD CONSTRAINT FK_be5f41_Descriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_CharterStatusDescriptor FOREIGN KEY (CharterStatusDescriptorId)
REFERENCES edfi.CharterStatusDescriptor (CharterStatusDescriptorId)
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_EducationOrganization FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_EducationServiceCenter FOREIGN KEY (EducationServiceCenterId)
REFERENCES edfi.EducationServiceCenter (EducationServiceCenterId)
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_LocalEducationAgency FOREIGN KEY (ParentLocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_LocalEducationAgencyCategoryDescriptor FOREIGN KEY (LocalEducationAgencyCategoryDescriptorId)
REFERENCES edfi.LocalEducationAgencyCategoryDescriptor (LocalEducationAgencyCategoryDescriptorId)
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
;

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_GunFreeSchoolsActReportingStatusDescriptor FOREIGN KEY (GunFreeSchoolsActReportingStatusDescriptorId)
REFERENCES edfi.GunFreeSchoolsActReportingStatusDescriptor (GunFreeSchoolsActReportingStatusDescriptorId)
;

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_SchoolChoiceImplementStatusDescriptor FOREIGN KEY (SchoolChoiceImplementStatusDescriptorId)
REFERENCES edfi.SchoolChoiceImplementStatusDescriptor (SchoolChoiceImplementStatusDescriptorId)
;

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.LocalEducationAgencyCategoryDescriptor ADD CONSTRAINT FK_8db9a2_Descriptor FOREIGN KEY (LocalEducationAgencyCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEducationAgencyFederalFunds ADD CONSTRAINT FK_5a8c0e_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEncumbrance ADD CONSTRAINT FK_ea526f_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

ALTER TABLE edfi.LocalEncumbrance ADD CONSTRAINT FK_ea526f_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

ALTER TABLE edfi.LocalPayroll ADD CONSTRAINT FK_46e5c2_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

ALTER TABLE edfi.LocalPayroll ADD CONSTRAINT FK_46e5c2_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

ALTER TABLE edfi.LocalPayroll ADD CONSTRAINT FK_46e5c2_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.Location ADD CONSTRAINT FK_15b619_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.MagnetSpecialProgramEmphasisSchoolDescriptor ADD CONSTRAINT FK_d738d4_Descriptor FOREIGN KEY (MagnetSpecialProgramEmphasisSchoolDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.MediumOfInstructionDescriptor ADD CONSTRAINT FK_7a8947_Descriptor FOREIGN KEY (MediumOfInstructionDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.MethodCreditEarnedDescriptor ADD CONSTRAINT FK_ba36b2_Descriptor FOREIGN KEY (MethodCreditEarnedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.MigrantEducationProgramServiceDescriptor ADD CONSTRAINT FK_4cc191_Descriptor FOREIGN KEY (MigrantEducationProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ModelEntityDescriptor ADD CONSTRAINT FK_88479e_Descriptor FOREIGN KEY (ModelEntityDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.MonitoredDescriptor ADD CONSTRAINT FK_19374b_Descriptor FOREIGN KEY (MonitoredDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.NeglectedOrDelinquentProgramDescriptor ADD CONSTRAINT FK_0b3390_Descriptor FOREIGN KEY (NeglectedOrDelinquentProgramDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.NeglectedOrDelinquentProgramServiceDescriptor ADD CONSTRAINT FK_0bfc01_Descriptor FOREIGN KEY (NeglectedOrDelinquentProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.NetworkPurposeDescriptor ADD CONSTRAINT FK_cf38e3_Descriptor FOREIGN KEY (NetworkPurposeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ObjectDimensionReportingTag ADD CONSTRAINT FK_fda3b7_ObjectDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.ObjectDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.ObjectDimensionReportingTag ADD CONSTRAINT FK_fda3b7_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.ObjectiveAssessment ADD CONSTRAINT FK_269e10_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.ObjectiveAssessment ADD CONSTRAINT FK_269e10_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

ALTER TABLE edfi.ObjectiveAssessment ADD CONSTRAINT FK_269e10_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, ParentIdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
;

ALTER TABLE edfi.ObjectiveAssessmentAssessmentItem ADD CONSTRAINT FK_d98560_AssessmentItem FOREIGN KEY (AssessmentIdentifier, AssessmentItemIdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
;

ALTER TABLE edfi.ObjectiveAssessmentAssessmentItem ADD CONSTRAINT FK_d98560_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.ObjectiveAssessmentLearningStandard ADD CONSTRAINT FK_1ee70e_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.ObjectiveAssessmentLearningStandard ADD CONSTRAINT FK_1ee70e_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.ObjectiveAssessmentScore ADD CONSTRAINT FK_2c91e8_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.ObjectiveAssessmentScore ADD CONSTRAINT FK_2c91e8_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.ObjectiveAssessmentScore ADD CONSTRAINT FK_2c91e8_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_EmploymentStatusDescriptor FOREIGN KEY (EmploymentStatusDescriptorId)
REFERENCES edfi.EmploymentStatusDescriptor (EmploymentStatusDescriptorId)
;

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_PostingResultDescriptor FOREIGN KEY (PostingResultDescriptorId)
REFERENCES edfi.PostingResultDescriptor (PostingResultDescriptorId)
;

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_ProgramAssignmentDescriptor FOREIGN KEY (ProgramAssignmentDescriptorId)
REFERENCES edfi.ProgramAssignmentDescriptor (ProgramAssignmentDescriptorId)
;

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_StaffClassificationDescriptor FOREIGN KEY (StaffClassificationDescriptorId)
REFERENCES edfi.StaffClassificationDescriptor (StaffClassificationDescriptorId)
;

ALTER TABLE edfi.OpenStaffPositionAcademicSubject ADD CONSTRAINT FK_285d36_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.OpenStaffPositionAcademicSubject ADD CONSTRAINT FK_285d36_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
ON DELETE CASCADE
;

ALTER TABLE edfi.OpenStaffPositionInstructionalGradeLevel ADD CONSTRAINT FK_e19c72_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.OpenStaffPositionInstructionalGradeLevel ADD CONSTRAINT FK_e19c72_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
ON DELETE CASCADE
;

ALTER TABLE edfi.OperationalStatusDescriptor ADD CONSTRAINT FK_ce3682_Descriptor FOREIGN KEY (OperationalStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.OperationalUnitDimensionReportingTag ADD CONSTRAINT FK_3b06c7_OperationalUnitDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.OperationalUnitDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.OperationalUnitDimensionReportingTag ADD CONSTRAINT FK_3b06c7_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.OrganizationDepartment ADD CONSTRAINT FK_13b924_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.OrganizationDepartment ADD CONSTRAINT FK_13b924_EducationOrganization FOREIGN KEY (OrganizationDepartmentId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.OrganizationDepartment ADD CONSTRAINT FK_13b924_EducationOrganization1 FOREIGN KEY (ParentEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.OtherNameTypeDescriptor ADD CONSTRAINT FK_f020d2_Descriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ParticipationDescriptor ADD CONSTRAINT FK_e94f88_Descriptor FOREIGN KEY (ParticipationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ParticipationStatusDescriptor ADD CONSTRAINT FK_5f0467_Descriptor FOREIGN KEY (ParticipationStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PerformanceBaseConversionDescriptor ADD CONSTRAINT FK_4fc529_Descriptor FOREIGN KEY (PerformanceBaseConversionDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PerformanceLevelDescriptor ADD CONSTRAINT FK_a54ec7_Descriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Person ADD CONSTRAINT FK_6007db_SourceSystemDescriptor FOREIGN KEY (SourceSystemDescriptorId)
REFERENCES edfi.SourceSystemDescriptor (SourceSystemDescriptorId)
;

ALTER TABLE edfi.PersonalInformationVerificationDescriptor ADD CONSTRAINT FK_e35818_Descriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PlatformTypeDescriptor ADD CONSTRAINT FK_56ac99_Descriptor FOREIGN KEY (PlatformTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PopulationServedDescriptor ADD CONSTRAINT FK_66f4dc_Descriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostingResultDescriptor ADD CONSTRAINT FK_105b75_Descriptor FOREIGN KEY (PostingResultDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostSecondaryEvent ADD CONSTRAINT FK_b8b6d7_PostSecondaryEventCategoryDescriptor FOREIGN KEY (PostSecondaryEventCategoryDescriptorId)
REFERENCES edfi.PostSecondaryEventCategoryDescriptor (PostSecondaryEventCategoryDescriptorId)
;

ALTER TABLE edfi.PostSecondaryEvent ADD CONSTRAINT FK_b8b6d7_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
;

ALTER TABLE edfi.PostSecondaryEvent ADD CONSTRAINT FK_b8b6d7_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.PostSecondaryEventCategoryDescriptor ADD CONSTRAINT FK_6829e4_Descriptor FOREIGN KEY (PostSecondaryEventCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostSecondaryInstitution ADD CONSTRAINT FK_2935bf_AdministrativeFundingControlDescriptor FOREIGN KEY (AdministrativeFundingControlDescriptorId)
REFERENCES edfi.AdministrativeFundingControlDescriptor (AdministrativeFundingControlDescriptorId)
;

ALTER TABLE edfi.PostSecondaryInstitution ADD CONSTRAINT FK_2935bf_EducationOrganization FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostSecondaryInstitution ADD CONSTRAINT FK_2935bf_PostSecondaryInstitutionLevelDescriptor FOREIGN KEY (PostSecondaryInstitutionLevelDescriptorId)
REFERENCES edfi.PostSecondaryInstitutionLevelDescriptor (PostSecondaryInstitutionLevelDescriptorId)
;

ALTER TABLE edfi.PostSecondaryInstitutionLevelDescriptor ADD CONSTRAINT FK_3dd32d_Descriptor FOREIGN KEY (PostSecondaryInstitutionLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostSecondaryInstitutionMediumOfInstruction ADD CONSTRAINT FK_9bd9d6_MediumOfInstructionDescriptor FOREIGN KEY (MediumOfInstructionDescriptorId)
REFERENCES edfi.MediumOfInstructionDescriptor (MediumOfInstructionDescriptorId)
;

ALTER TABLE edfi.PostSecondaryInstitutionMediumOfInstruction ADD CONSTRAINT FK_9bd9d6_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PrimaryLearningDeviceAccessDescriptor ADD CONSTRAINT FK_cbfe5d_Descriptor FOREIGN KEY (PrimaryLearningDeviceAccessDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor ADD CONSTRAINT FK_5ee08d_Descriptor FOREIGN KEY (PrimaryLearningDeviceAwayFromSchoolDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PrimaryLearningDeviceProviderDescriptor ADD CONSTRAINT FK_a1f277_Descriptor FOREIGN KEY (PrimaryLearningDeviceProviderDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProficiencyDescriptor ADD CONSTRAINT FK_14d0fd_Descriptor FOREIGN KEY (ProficiencyDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Program ADD CONSTRAINT FK_90920d_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.Program ADD CONSTRAINT FK_90920d_ProgramTypeDescriptor FOREIGN KEY (ProgramTypeDescriptorId)
REFERENCES edfi.ProgramTypeDescriptor (ProgramTypeDescriptorId)
;

ALTER TABLE edfi.ProgramAssignmentDescriptor ADD CONSTRAINT FK_8f5a42_Descriptor FOREIGN KEY (ProgramAssignmentDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramCharacteristic ADD CONSTRAINT FK_16896e_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramCharacteristic ADD CONSTRAINT FK_16896e_ProgramCharacteristicDescriptor FOREIGN KEY (ProgramCharacteristicDescriptorId)
REFERENCES edfi.ProgramCharacteristicDescriptor (ProgramCharacteristicDescriptorId)
;

ALTER TABLE edfi.ProgramCharacteristicDescriptor ADD CONSTRAINT FK_ba9204_Descriptor FOREIGN KEY (ProgramCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramDimensionReportingTag ADD CONSTRAINT FK_3e04ae_ProgramDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.ProgramDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramDimensionReportingTag ADD CONSTRAINT FK_3e04ae_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluation ADD CONSTRAINT FK_f3a20e_EvaluationPeriodDescriptor FOREIGN KEY (ProgramEvaluationPeriodDescriptorId)
REFERENCES edfi.EvaluationPeriodDescriptor (EvaluationPeriodDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluation ADD CONSTRAINT FK_f3a20e_EvaluationTypeDescriptor FOREIGN KEY (ProgramEvaluationTypeDescriptorId)
REFERENCES edfi.EvaluationTypeDescriptor (EvaluationTypeDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluation ADD CONSTRAINT FK_f3a20e_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluationElement ADD CONSTRAINT FK_784616_ProgramEvaluation FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluation (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluationElement ADD CONSTRAINT FK_784616_ProgramEvaluationObjective FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluationObjective (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluationElementRatingLevel ADD CONSTRAINT FK_3b2082_ProgramEvaluationElement FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluationElement (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramEvaluationElementRatingLevel ADD CONSTRAINT FK_3b2082_RatingLevelDescriptor FOREIGN KEY (RatingLevelDescriptorId)
REFERENCES edfi.RatingLevelDescriptor (RatingLevelDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluationObjective ADD CONSTRAINT FK_a53c6c_ProgramEvaluation FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluation (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluationObjectiveRatingLevel ADD CONSTRAINT FK_ffb8a9_ProgramEvaluationObjective FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluationObjective (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramEvaluationObjectiveRatingLevel ADD CONSTRAINT FK_ffb8a9_RatingLevelDescriptor FOREIGN KEY (RatingLevelDescriptorId)
REFERENCES edfi.RatingLevelDescriptor (RatingLevelDescriptorId)
;

ALTER TABLE edfi.ProgramEvaluationRatingLevel ADD CONSTRAINT FK_e71055_ProgramEvaluation FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluation (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramEvaluationRatingLevel ADD CONSTRAINT FK_e71055_RatingLevelDescriptor FOREIGN KEY (RatingLevelDescriptorId)
REFERENCES edfi.RatingLevelDescriptor (RatingLevelDescriptorId)
;

ALTER TABLE edfi.ProgramLearningStandard ADD CONSTRAINT FK_44f909_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

ALTER TABLE edfi.ProgramLearningStandard ADD CONSTRAINT FK_44f909_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramSponsor ADD CONSTRAINT FK_4c38bb_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramSponsor ADD CONSTRAINT FK_4c38bb_ProgramSponsorDescriptor FOREIGN KEY (ProgramSponsorDescriptorId)
REFERENCES edfi.ProgramSponsorDescriptor (ProgramSponsorDescriptorId)
;

ALTER TABLE edfi.ProgramSponsorDescriptor ADD CONSTRAINT FK_68566b_Descriptor FOREIGN KEY (ProgramSponsorDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramTypeDescriptor ADD CONSTRAINT FK_16eb9d_Descriptor FOREIGN KEY (ProgramTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgressDescriptor ADD CONSTRAINT FK_d0b3fc_Descriptor FOREIGN KEY (ProgressDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgressLevelDescriptor ADD CONSTRAINT FK_7bf630_Descriptor FOREIGN KEY (ProgressLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProjectDimensionReportingTag ADD CONSTRAINT FK_b5314a_ProjectDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.ProjectDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProjectDimensionReportingTag ADD CONSTRAINT FK_b5314a_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.ProviderCategoryDescriptor ADD CONSTRAINT FK_add5c4_Descriptor FOREIGN KEY (ProviderCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProviderProfitabilityDescriptor ADD CONSTRAINT FK_7c3adc_Descriptor FOREIGN KEY (ProviderProfitabilityDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProviderStatusDescriptor ADD CONSTRAINT FK_6328c9_Descriptor FOREIGN KEY (ProviderStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PublicationStatusDescriptor ADD CONSTRAINT FK_9e73cb_Descriptor FOREIGN KEY (PublicationStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.QuestionFormDescriptor ADD CONSTRAINT FK_43a820_Descriptor FOREIGN KEY (QuestionFormDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.RaceDescriptor ADD CONSTRAINT FK_a902cb_Descriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.RatingLevelDescriptor ADD CONSTRAINT FK_e67dd1_Descriptor FOREIGN KEY (RatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ReasonExitedDescriptor ADD CONSTRAINT FK_790724_Descriptor FOREIGN KEY (ReasonExitedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ReasonNotTestedDescriptor ADD CONSTRAINT FK_2ba6d0_Descriptor FOREIGN KEY (ReasonNotTestedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.RecognitionTypeDescriptor ADD CONSTRAINT FK_b549ed_Descriptor FOREIGN KEY (RecognitionTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.RelationDescriptor ADD CONSTRAINT FK_4e9305_Descriptor FOREIGN KEY (RelationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.RepeatIdentifierDescriptor ADD CONSTRAINT FK_d881e7_Descriptor FOREIGN KEY (RepeatIdentifierDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ReportCard ADD CONSTRAINT FK_ec1992_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.ReportCard ADD CONSTRAINT FK_ec1992_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

ALTER TABLE edfi.ReportCard ADD CONSTRAINT FK_ec1992_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.ReportCardGrade ADD CONSTRAINT FK_f203d3_Grade FOREIGN KEY (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolYear, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.Grade (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolYear, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON UPDATE CASCADE
;

ALTER TABLE edfi.ReportCardGrade ADD CONSTRAINT FK_f203d3_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ReportCardGradePointAverage ADD CONSTRAINT FK_8574ad_GradePointAverageTypeDescriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.GradePointAverageTypeDescriptor (GradePointAverageTypeDescriptorId)
;

ALTER TABLE edfi.ReportCardGradePointAverage ADD CONSTRAINT FK_8574ad_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ReportCardStudentCompetencyObjective ADD CONSTRAINT FK_c16d6c_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.ReportCardStudentCompetencyObjective ADD CONSTRAINT FK_c16d6c_StudentCompetencyObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI)
REFERENCES edfi.StudentCompetencyObjective (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI)
;

ALTER TABLE edfi.ReporterDescriptionDescriptor ADD CONSTRAINT FK_62c0d2_Descriptor FOREIGN KEY (ReporterDescriptionDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ReportingTagDescriptor ADD CONSTRAINT FK_b173f4_Descriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ResidencyStatusDescriptor ADD CONSTRAINT FK_c62170_Descriptor FOREIGN KEY (ResidencyStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ResponseIndicatorDescriptor ADD CONSTRAINT FK_be38ef_Descriptor FOREIGN KEY (ResponseIndicatorDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ResponsibilityDescriptor ADD CONSTRAINT FK_0b056e_Descriptor FOREIGN KEY (ResponsibilityDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.RestraintEvent ADD CONSTRAINT FK_3800be_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

ALTER TABLE edfi.RestraintEvent ADD CONSTRAINT FK_3800be_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.RestraintEvent ADD CONSTRAINT FK_3800be_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.RestraintEventProgram ADD CONSTRAINT FK_d3d793_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.RestraintEventProgram ADD CONSTRAINT FK_d3d793_RestraintEvent FOREIGN KEY (RestraintEventIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.RestraintEvent (RestraintEventIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.RestraintEventReason ADD CONSTRAINT FK_e232ae_RestraintEvent FOREIGN KEY (RestraintEventIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.RestraintEvent (RestraintEventIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.RestraintEventReason ADD CONSTRAINT FK_e232ae_RestraintEventReasonDescriptor FOREIGN KEY (RestraintEventReasonDescriptorId)
REFERENCES edfi.RestraintEventReasonDescriptor (RestraintEventReasonDescriptorId)
;

ALTER TABLE edfi.RestraintEventReasonDescriptor ADD CONSTRAINT FK_d6141f_Descriptor FOREIGN KEY (RestraintEventReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ResultDatatypeTypeDescriptor ADD CONSTRAINT FK_9809bc_Descriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.RetestIndicatorDescriptor ADD CONSTRAINT FK_af156c_Descriptor FOREIGN KEY (RetestIndicatorDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_AdministrativeFundingControlDescriptor FOREIGN KEY (AdministrativeFundingControlDescriptorId)
REFERENCES edfi.AdministrativeFundingControlDescriptor (AdministrativeFundingControlDescriptorId)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_CharterApprovalAgencyTypeDescriptor FOREIGN KEY (CharterApprovalAgencyTypeDescriptorId)
REFERENCES edfi.CharterApprovalAgencyTypeDescriptor (CharterApprovalAgencyTypeDescriptorId)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_CharterStatusDescriptor FOREIGN KEY (CharterStatusDescriptorId)
REFERENCES edfi.CharterStatusDescriptor (CharterStatusDescriptorId)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_EducationOrganization FOREIGN KEY (SchoolId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_InternetAccessDescriptor FOREIGN KEY (InternetAccessDescriptorId)
REFERENCES edfi.InternetAccessDescriptor (InternetAccessDescriptorId)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_MagnetSpecialProgramEmphasisSchoolDescriptor FOREIGN KEY (MagnetSpecialProgramEmphasisSchoolDescriptorId)
REFERENCES edfi.MagnetSpecialProgramEmphasisSchoolDescriptor (MagnetSpecialProgramEmphasisSchoolDescriptorId)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_SchoolTypeDescriptor FOREIGN KEY (SchoolTypeDescriptorId)
REFERENCES edfi.SchoolTypeDescriptor (SchoolTypeDescriptorId)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_SchoolYearType FOREIGN KEY (CharterApprovalSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_TitleIPartASchoolDesignationDescriptor FOREIGN KEY (TitleIPartASchoolDesignationDescriptorId)
REFERENCES edfi.TitleIPartASchoolDesignationDescriptor (TitleIPartASchoolDesignationDescriptorId)
;

ALTER TABLE edfi.SchoolCategory ADD CONSTRAINT FK_789691_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SchoolCategory ADD CONSTRAINT FK_789691_SchoolCategoryDescriptor FOREIGN KEY (SchoolCategoryDescriptorId)
REFERENCES edfi.SchoolCategoryDescriptor (SchoolCategoryDescriptorId)
;

ALTER TABLE edfi.SchoolCategoryDescriptor ADD CONSTRAINT FK_2e8c40_Descriptor FOREIGN KEY (SchoolCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SchoolChoiceBasisDescriptor ADD CONSTRAINT FK_ccfb43_Descriptor FOREIGN KEY (SchoolChoiceBasisDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SchoolChoiceImplementStatusDescriptor ADD CONSTRAINT FK_8f4ff8_Descriptor FOREIGN KEY (SchoolChoiceImplementStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SchoolFoodServiceProgramServiceDescriptor ADD CONSTRAINT FK_da19fa_Descriptor FOREIGN KEY (SchoolFoodServiceProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SchoolGradeLevel ADD CONSTRAINT FK_64d8a6_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.SchoolGradeLevel ADD CONSTRAINT FK_64d8a6_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SchoolTypeDescriptor ADD CONSTRAINT FK_ef0964_Descriptor FOREIGN KEY (SchoolTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_CreditTypeDescriptor FOREIGN KEY (AvailableCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_LanguageDescriptor FOREIGN KEY (InstructionLanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_Location FOREIGN KEY (LocationClassroomIdentificationCode, LocationSchoolId)
REFERENCES edfi.Location (ClassroomIdentificationCode, SchoolId)
ON UPDATE CASCADE
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_MediumOfInstructionDescriptor FOREIGN KEY (MediumOfInstructionDescriptorId)
REFERENCES edfi.MediumOfInstructionDescriptor (MediumOfInstructionDescriptorId)
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_School FOREIGN KEY (LocationSchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.SectionAttendanceTakenEvent ADD CONSTRAINT FK_7bbbe7_CalendarDate FOREIGN KEY (CalendarCode, Date, SchoolId, SchoolYear)
REFERENCES edfi.CalendarDate (CalendarCode, Date, SchoolId, SchoolYear)
;

ALTER TABLE edfi.SectionAttendanceTakenEvent ADD CONSTRAINT FK_7bbbe7_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.SectionAttendanceTakenEvent ADD CONSTRAINT FK_7bbbe7_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.SectionCharacteristic ADD CONSTRAINT FK_1587d8_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.SectionCharacteristic ADD CONSTRAINT FK_1587d8_SectionCharacteristicDescriptor FOREIGN KEY (SectionCharacteristicDescriptorId)
REFERENCES edfi.SectionCharacteristicDescriptor (SectionCharacteristicDescriptorId)
;

ALTER TABLE edfi.SectionCharacteristicDescriptor ADD CONSTRAINT FK_9aae24_Descriptor FOREIGN KEY (SectionCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SectionClassPeriod ADD CONSTRAINT FK_465c76_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON UPDATE CASCADE
;

ALTER TABLE edfi.SectionClassPeriod ADD CONSTRAINT FK_465c76_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.SectionCourseLevelCharacteristic ADD CONSTRAINT FK_f221cc_CourseLevelCharacteristicDescriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.CourseLevelCharacteristicDescriptor (CourseLevelCharacteristicDescriptorId)
;

ALTER TABLE edfi.SectionCourseLevelCharacteristic ADD CONSTRAINT FK_f221cc_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.SectionOfferedGradeLevel ADD CONSTRAINT FK_8d3fd8_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.SectionOfferedGradeLevel ADD CONSTRAINT FK_8d3fd8_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.SectionProgram ADD CONSTRAINT FK_309217_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.SectionProgram ADD CONSTRAINT FK_309217_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.SeparationDescriptor ADD CONSTRAINT FK_cd3406_Descriptor FOREIGN KEY (SeparationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SeparationReasonDescriptor ADD CONSTRAINT FK_ac0f04_Descriptor FOREIGN KEY (SeparationReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ServiceDescriptor ADD CONSTRAINT FK_aff2dc_Descriptor FOREIGN KEY (ServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Session ADD CONSTRAINT FK_6959b4_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.Session ADD CONSTRAINT FK_6959b4_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.Session ADD CONSTRAINT FK_6959b4_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

ALTER TABLE edfi.SessionAcademicWeek ADD CONSTRAINT FK_72eb60_AcademicWeek FOREIGN KEY (SchoolId, WeekIdentifier)
REFERENCES edfi.AcademicWeek (SchoolId, WeekIdentifier)
;

ALTER TABLE edfi.SessionAcademicWeek ADD CONSTRAINT FK_72eb60_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.SessionGradingPeriod ADD CONSTRAINT FK_c4b3e0_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

ALTER TABLE edfi.SessionGradingPeriod ADD CONSTRAINT FK_c4b3e0_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.SexDescriptor ADD CONSTRAINT FK_eb9b06_Descriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SourceDimensionReportingTag ADD CONSTRAINT FK_0c6eff_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

ALTER TABLE edfi.SourceDimensionReportingTag ADD CONSTRAINT FK_0c6eff_SourceDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.SourceDimension (Code, FiscalYear)
ON DELETE CASCADE
;

ALTER TABLE edfi.SourceSystemDescriptor ADD CONSTRAINT FK_f71783_Descriptor FOREIGN KEY (SourceSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SpecialEducationProgramServiceDescriptor ADD CONSTRAINT FK_c2348e_Descriptor FOREIGN KEY (SpecialEducationProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SpecialEducationSettingDescriptor ADD CONSTRAINT FK_010235_Descriptor FOREIGN KEY (SpecialEducationSettingDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_CitizenshipStatusDescriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.CitizenshipStatusDescriptor (CitizenshipStatusDescriptorId)
;

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_LevelOfEducationDescriptor FOREIGN KEY (HighestCompletedLevelOfEducationDescriptorId)
REFERENCES edfi.LevelOfEducationDescriptor (LevelOfEducationDescriptorId)
;

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.StaffAbsenceEvent ADD CONSTRAINT FK_b13bbd_AbsenceEventCategoryDescriptor FOREIGN KEY (AbsenceEventCategoryDescriptorId)
REFERENCES edfi.AbsenceEventCategoryDescriptor (AbsenceEventCategoryDescriptorId)
;

ALTER TABLE edfi.StaffAbsenceEvent ADD CONSTRAINT FK_b13bbd_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.StaffAddressPeriod ADD CONSTRAINT FK_b7f969_StaffAddress FOREIGN KEY (StaffUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.StaffAddress (StaffUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffAncestryEthnicOrigin ADD CONSTRAINT FK_a4a6ae_AncestryEthnicOriginDescriptor FOREIGN KEY (AncestryEthnicOriginDescriptorId)
REFERENCES edfi.AncestryEthnicOriginDescriptor (AncestryEthnicOriginDescriptorId)
;

ALTER TABLE edfi.StaffAncestryEthnicOrigin ADD CONSTRAINT FK_a4a6ae_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffClassificationDescriptor ADD CONSTRAINT FK_6ca180_Descriptor FOREIGN KEY (StaffClassificationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffCohortAssociation ADD CONSTRAINT FK_170747_Cohort FOREIGN KEY (CohortIdentifier, EducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
;

ALTER TABLE edfi.StaffCohortAssociation ADD CONSTRAINT FK_170747_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffCredential ADD CONSTRAINT FK_f3917b_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

ALTER TABLE edfi.StaffCredential ADD CONSTRAINT FK_f3917b_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD CONSTRAINT FK_af86db_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
;

ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD CONSTRAINT FK_af86db_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be ADD CONSTRAINT FK_7fa4be_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

ALTER TABLE edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be ADD CONSTRAINT FK_7fa4be_StaffDisciplineIncidentAssociation FOREIGN KEY (IncidentIdentifier, SchoolId, StaffUSI)
REFERENCES edfi.StaffDisciplineIncidentAssociation (IncidentIdentifier, SchoolId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_StaffClassificationDescriptor FOREIGN KEY (StaffClassificationDescriptorId)
REFERENCES edfi.StaffClassificationDescriptor (StaffClassificationDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_StaffEducationOrganizationEmploymentAssociation FOREIGN KEY (EmploymentEducationOrganizationId, EmploymentStatusDescriptorId, EmploymentHireDate, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD CONSTRAINT FK_735dd8_ContactTypeDescriptor FOREIGN KEY (ContactTypeDescriptorId)
REFERENCES edfi.ContactTypeDescriptor (ContactTypeDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD CONSTRAINT FK_735dd8_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD CONSTRAINT FK_735dd8_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_StaffEducationOrganizationContactAssociation FOREIGN KEY (ContactTitle, EducationOrganizationId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationContactAssociation (ContactTitle, EducationOrganizationId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddressPeriod ADD CONSTRAINT FK_afd39a_StaffEducationOrganizationContactAssociationAddress FOREIGN KEY (ContactTitle, EducationOrganizationId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationContactAssociationAddress (ContactTitle, EducationOrganizationId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationTelephone ADD CONSTRAINT FK_742dd2_StaffEducationOrganizationContactAssociation FOREIGN KEY (ContactTitle, EducationOrganizationId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationContactAssociation (ContactTitle, EducationOrganizationId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationTelephone ADD CONSTRAINT FK_742dd2_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_EmploymentStatusDescriptor FOREIGN KEY (EmploymentStatusDescriptorId)
REFERENCES edfi.EmploymentStatusDescriptor (EmploymentStatusDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_SeparationDescriptor FOREIGN KEY (SeparationDescriptorId)
REFERENCES edfi.SeparationDescriptor (SeparationDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_SeparationReasonDescriptor FOREIGN KEY (SeparationReasonDescriptorId)
REFERENCES edfi.SeparationReasonDescriptor (SeparationReasonDescriptorId)
;

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffElectronicMail ADD CONSTRAINT FK_d93663_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

ALTER TABLE edfi.StaffElectronicMail ADD CONSTRAINT FK_d93663_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffIdentificationCode ADD CONSTRAINT FK_7483c6_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffIdentificationCode ADD CONSTRAINT FK_7483c6_StaffIdentificationSystemDescriptor FOREIGN KEY (StaffIdentificationSystemDescriptorId)
REFERENCES edfi.StaffIdentificationSystemDescriptor (StaffIdentificationSystemDescriptorId)
;

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffIdentificationSystemDescriptor ADD CONSTRAINT FK_cb401c_Descriptor FOREIGN KEY (StaffIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffInternationalAddress ADD CONSTRAINT FK_6cd27e_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.StaffInternationalAddress ADD CONSTRAINT FK_6cd27e_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.StaffInternationalAddress ADD CONSTRAINT FK_6cd27e_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffLanguage ADD CONSTRAINT FK_1c8d3f_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

ALTER TABLE edfi.StaffLanguage ADD CONSTRAINT FK_1c8d3f_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffLanguageUse ADD CONSTRAINT FK_b527e7_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

ALTER TABLE edfi.StaffLanguageUse ADD CONSTRAINT FK_b527e7_StaffLanguage FOREIGN KEY (StaffUSI, LanguageDescriptorId)
REFERENCES edfi.StaffLanguage (StaffUSI, LanguageDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffLeave ADD CONSTRAINT FK_debd4f_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffLeave ADD CONSTRAINT FK_debd4f_StaffLeaveEventCategoryDescriptor FOREIGN KEY (StaffLeaveEventCategoryDescriptorId)
REFERENCES edfi.StaffLeaveEventCategoryDescriptor (StaffLeaveEventCategoryDescriptorId)
;

ALTER TABLE edfi.StaffLeaveEventCategoryDescriptor ADD CONSTRAINT FK_963eb5_Descriptor FOREIGN KEY (StaffLeaveEventCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffOtherName ADD CONSTRAINT FK_b0cb9e_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

ALTER TABLE edfi.StaffOtherName ADD CONSTRAINT FK_b0cb9e_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffProgramAssociation ADD CONSTRAINT FK_a9c0d9_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.StaffProgramAssociation ADD CONSTRAINT FK_a9c0d9_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffRace ADD CONSTRAINT FK_696d9a_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

ALTER TABLE edfi.StaffRace ADD CONSTRAINT FK_696d9a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffRecognition ADD CONSTRAINT FK_c60190_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

ALTER TABLE edfi.StaffRecognition ADD CONSTRAINT FK_c60190_RecognitionTypeDescriptor FOREIGN KEY (RecognitionTypeDescriptorId)
REFERENCES edfi.RecognitionTypeDescriptor (RecognitionTypeDescriptorId)
;

ALTER TABLE edfi.StaffRecognition ADD CONSTRAINT FK_c60190_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
;

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_ProgramAssignmentDescriptor FOREIGN KEY (ProgramAssignmentDescriptorId)
REFERENCES edfi.ProgramAssignmentDescriptor (ProgramAssignmentDescriptorId)
;

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffSchoolAssociationAcademicSubject ADD CONSTRAINT FK_d891fb_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

ALTER TABLE edfi.StaffSchoolAssociationAcademicSubject ADD CONSTRAINT FK_d891fb_StaffSchoolAssociation FOREIGN KEY (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
REFERENCES edfi.StaffSchoolAssociation (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffSchoolAssociationGradeLevel ADD CONSTRAINT FK_3db81b_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.StaffSchoolAssociationGradeLevel ADD CONSTRAINT FK_3db81b_StaffSchoolAssociation FOREIGN KEY (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
REFERENCES edfi.StaffSchoolAssociation (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffSectionAssociation ADD CONSTRAINT FK_515cb5_ClassroomPositionDescriptor FOREIGN KEY (ClassroomPositionDescriptorId)
REFERENCES edfi.ClassroomPositionDescriptor (ClassroomPositionDescriptorId)
;

ALTER TABLE edfi.StaffSectionAssociation ADD CONSTRAINT FK_515cb5_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StaffSectionAssociation ADD CONSTRAINT FK_515cb5_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StaffTelephone ADD CONSTRAINT FK_4de15a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffTelephone ADD CONSTRAINT FK_4de15a_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

ALTER TABLE edfi.StaffTribalAffiliation ADD CONSTRAINT FK_e77b10_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffTribalAffiliation ADD CONSTRAINT FK_e77b10_TribalAffiliationDescriptor FOREIGN KEY (TribalAffiliationDescriptorId)
REFERENCES edfi.TribalAffiliationDescriptor (TribalAffiliationDescriptorId)
;

ALTER TABLE edfi.StaffVisa ADD CONSTRAINT FK_e27213_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffVisa ADD CONSTRAINT FK_e27213_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

ALTER TABLE edfi.StateAbbreviationDescriptor ADD CONSTRAINT FK_6ee971_Descriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StateEducationAgency ADD CONSTRAINT FK_340d5d_EducationOrganization FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StateEducationAgencyAccountability ADD CONSTRAINT FK_09668f_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StateEducationAgencyAccountability ADD CONSTRAINT FK_09668f_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StateEducationAgencyFederalFunds ADD CONSTRAINT FK_3c7e00_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_CitizenshipStatusDescriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.CitizenshipStatusDescriptor (CitizenshipStatusDescriptorId)
;

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_CountryDescriptor FOREIGN KEY (BirthCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_SexDescriptor FOREIGN KEY (BirthSexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_StateAbbreviationDescriptor FOREIGN KEY (BirthStateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor FOREIGN KEY (CumulativeEarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor1 FOREIGN KEY (CumulativeAttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor2 FOREIGN KEY (SessionEarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor3 FOREIGN KEY (SessionAttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordAcademicHonor ADD CONSTRAINT FK_2b286a_AcademicHonorCategoryDescriptor FOREIGN KEY (AcademicHonorCategoryDescriptorId)
REFERENCES edfi.AcademicHonorCategoryDescriptor (AcademicHonorCategoryDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordAcademicHonor ADD CONSTRAINT FK_2b286a_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordAcademicHonor ADD CONSTRAINT FK_2b286a_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAcademicRecordClassRanking ADD CONSTRAINT FK_8299aa_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_DiplomaLevelDescriptor FOREIGN KEY (DiplomaLevelDescriptorId)
REFERENCES edfi.DiplomaLevelDescriptor (DiplomaLevelDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_DiplomaTypeDescriptor FOREIGN KEY (DiplomaTypeDescriptorId)
REFERENCES edfi.DiplomaTypeDescriptor (DiplomaTypeDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAcademicRecordGradePointAverage ADD CONSTRAINT FK_af7be7_GradePointAverageTypeDescriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.GradePointAverageTypeDescriptor (GradePointAverageTypeDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordGradePointAverage ADD CONSTRAINT FK_af7be7_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAcademicRecordRecognition ADD CONSTRAINT FK_5e049e_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordRecognition ADD CONSTRAINT FK_5e049e_RecognitionTypeDescriptor FOREIGN KEY (RecognitionTypeDescriptorId)
REFERENCES edfi.RecognitionTypeDescriptor (RecognitionTypeDescriptorId)
;

ALTER TABLE edfi.StudentAcademicRecordRecognition ADD CONSTRAINT FK_5e049e_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAcademicRecordReportCard ADD CONSTRAINT FK_84e5e0_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
;

ALTER TABLE edfi.StudentAcademicRecordReportCard ADD CONSTRAINT FK_84e5e0_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_AdministrationEnvironmentDescriptor FOREIGN KEY (AdministrationEnvironmentDescriptorId)
REFERENCES edfi.AdministrationEnvironmentDescriptor (AdministrationEnvironmentDescriptorId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_EventCircumstanceDescriptor FOREIGN KEY (EventCircumstanceDescriptorId)
REFERENCES edfi.EventCircumstanceDescriptor (EventCircumstanceDescriptorId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_GradeLevelDescriptor FOREIGN KEY (WhenAssessedGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_LanguageDescriptor FOREIGN KEY (AdministrationLanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_PlatformTypeDescriptor FOREIGN KEY (PlatformTypeDescriptorId)
REFERENCES edfi.PlatformTypeDescriptor (PlatformTypeDescriptorId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_ReasonNotTestedDescriptor FOREIGN KEY (ReasonNotTestedDescriptorId)
REFERENCES edfi.ReasonNotTestedDescriptor (ReasonNotTestedDescriptorId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_RetestIndicatorDescriptor FOREIGN KEY (RetestIndicatorDescriptorId)
REFERENCES edfi.RetestIndicatorDescriptor (RetestIndicatorDescriptorId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_School FOREIGN KEY (ReportedSchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentAssessmentAccommodation ADD CONSTRAINT FK_de959d_AccommodationDescriptor FOREIGN KEY (AccommodationDescriptorId)
REFERENCES edfi.AccommodationDescriptor (AccommodationDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentAccommodation ADD CONSTRAINT FK_de959d_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_EducationOrganizationAssociationTypeDescriptor FOREIGN KEY (EducationOrganizationAssociationTypeDescriptorId)
REFERENCES edfi.EducationOrganizationAssociationTypeDescriptor (EducationOrganizationAssociationTypeDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
;

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_AssessmentItem FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
;

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_AssessmentItemResultDescriptor FOREIGN KEY (AssessmentItemResultDescriptorId)
REFERENCES edfi.AssessmentItemResultDescriptor (AssessmentItemResultDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_ResponseIndicatorDescriptor FOREIGN KEY (ResponseIndicatorDescriptorId)
REFERENCES edfi.ResponseIndicatorDescriptor (ResponseIndicatorDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentPerformanceLevel ADD CONSTRAINT FK_c2bd3c_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentPerformanceLevel ADD CONSTRAINT FK_c2bd3c_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentPerformanceLevel ADD CONSTRAINT FK_c2bd3c_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentPeriod ADD CONSTRAINT FK_02ddd8_AssessmentPeriodDescriptor FOREIGN KEY (AssessmentPeriodDescriptorId)
REFERENCES edfi.AssessmentPeriodDescriptor (AssessmentPeriodDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentPeriod ADD CONSTRAINT FK_02ddd8_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentScoreResult ADD CONSTRAINT FK_0fceba_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentScoreResult ADD CONSTRAINT FK_0fceba_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentScoreResult ADD CONSTRAINT FK_0fceba_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessment ADD CONSTRAINT FK_b1c52f_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessment ADD CONSTRAINT FK_b1c52f_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_f32347_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_f32347_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_f32347_StudentAssessmentStudentObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode)
REFERENCES edfi.StudentAssessmentStudentObjectiveAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ADD CONSTRAINT FK_0c9651_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ADD CONSTRAINT FK_0c9651_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ADD CONSTRAINT FK_0c9651_StudentAssessmentStudentObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode)
REFERENCES edfi.StudentAssessmentStudentObjectiveAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCharacteristicDescriptor ADD CONSTRAINT FK_359668_Descriptor FOREIGN KEY (StudentCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCohortAssociation ADD CONSTRAINT FK_369ddc_Cohort FOREIGN KEY (CohortIdentifier, EducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
;

ALTER TABLE edfi.StudentCohortAssociation ADD CONSTRAINT FK_369ddc_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentCohortAssociationSection ADD CONSTRAINT FK_d2362d_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentCohortAssociationSection ADD CONSTRAINT FK_d2362d_StudentCohortAssociation FOREIGN KEY (BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentCohortAssociation (BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_CompetencyLevelDescriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.CompetencyLevelDescriptor (CompetencyLevelDescriptorId)
;

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_CompetencyObjective FOREIGN KEY (ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId)
REFERENCES edfi.CompetencyObjective (EducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId)
;

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation ADD CONSTRAINT FK_005337_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
;

ALTER TABLE edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation ADD CONSTRAINT FK_005337_StudentCompetencyObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI)
REFERENCES edfi.StudentCompetencyObjective (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCompetencyObjectiveStudentSectionAssociation ADD CONSTRAINT FK_ee68ed_StudentCompetencyObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI)
REFERENCES edfi.StudentCompetencyObjective (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCompetencyObjectiveStudentSectionAssociation ADD CONSTRAINT FK_ee68ed_StudentSectionAssociation FOREIGN KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAssociation (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentContactAssociation ADD CONSTRAINT FK_e2733e_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
;

ALTER TABLE edfi.StudentContactAssociation ADD CONSTRAINT FK_e2733e_RelationDescriptor FOREIGN KEY (RelationDescriptorId)
REFERENCES edfi.RelationDescriptor (RelationDescriptorId)
;

ALTER TABLE edfi.StudentContactAssociation ADD CONSTRAINT FK_e2733e_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentCTEProgramAssociation ADD CONSTRAINT FK_000ac5_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCTEProgramAssociation ADD CONSTRAINT FK_000ac5_TechnicalSkillsAssessmentDescriptor FOREIGN KEY (TechnicalSkillsAssessmentDescriptorId)
REFERENCES edfi.TechnicalSkillsAssessmentDescriptor (TechnicalSkillsAssessmentDescriptorId)
;

ALTER TABLE edfi.StudentCTEProgramAssociationCTEProgramService ADD CONSTRAINT FK_1bab8a_CTEProgramServiceDescriptor FOREIGN KEY (CTEProgramServiceDescriptorId)
REFERENCES edfi.CTEProgramServiceDescriptor (CTEProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentCTEProgramAssociationCTEProgramService ADD CONSTRAINT FK_1bab8a_StudentCTEProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentCTEProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_f4934f_BehaviorDescriptor FOREIGN KEY (BehaviorDescriptorId)
REFERENCES edfi.BehaviorDescriptor (BehaviorDescriptorId)
;

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_f4934f_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
;

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_f4934f_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 ADD CONSTRAINT FK_ae6a21_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 ADD CONSTRAINT FK_ae6a21_StudentDisciplineIncidentBehaviorAssociation FOREIGN KEY (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentBehaviorAssociation (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD CONSTRAINT FK_4b43da_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
;

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD CONSTRAINT FK_4b43da_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a ADD CONSTRAINT FK_4c979a_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a ADD CONSTRAINT FK_4c979a_StudentDisciplineIncidentNonOffenderAssociation FOREIGN KEY (IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentNonOffenderAssociation (IncidentIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_BarrierToInternetAccessInResidenceDescriptor FOREIGN KEY (BarrierToInternetAccessInResidenceDescriptorId)
REFERENCES edfi.BarrierToInternetAccessInResidenceDescriptor (BarrierToInternetAccessInResidenceDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_InternetAccessTypeInResidenceDescriptor FOREIGN KEY (InternetAccessTypeInResidenceDescriptorId)
REFERENCES edfi.InternetAccessTypeInResidenceDescriptor (InternetAccessTypeInResidenceDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_InternetPerformanceInResidenceDescriptor FOREIGN KEY (InternetPerformanceInResidenceDescriptorId)
REFERENCES edfi.InternetPerformanceInResidenceDescriptor (InternetPerformanceInResidenceDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_LimitedEnglishProficiencyDescriptor FOREIGN KEY (LimitedEnglishProficiencyDescriptorId)
REFERENCES edfi.LimitedEnglishProficiencyDescriptor (LimitedEnglishProficiencyDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_PrimaryLearningDeviceAccessDescriptor FOREIGN KEY (PrimaryLearningDeviceAccessDescriptorId)
REFERENCES edfi.PrimaryLearningDeviceAccessDescriptor (PrimaryLearningDeviceAccessDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_PrimaryLearningDeviceAwayFromSchoolDescriptor FOREIGN KEY (PrimaryLearningDeviceAwayFromSchoolDescriptorId)
REFERENCES edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor (PrimaryLearningDeviceAwayFromSchoolDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_PrimaryLearningDeviceProviderDescriptor FOREIGN KEY (PrimaryLearningDeviceProviderDescriptorId)
REFERENCES edfi.PrimaryLearningDeviceProviderDescriptor (PrimaryLearningDeviceProviderDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddressPeriod ADD CONSTRAINT FK_9739a2_StudentEducationOrganizationAssociationAddress FOREIGN KEY (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.StudentEducationOrganizationAssociationAddress (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin ADD CONSTRAINT FK_2c2b13_AncestryEthnicOriginDescriptor FOREIGN KEY (AncestryEthnicOriginDescriptorId)
REFERENCES edfi.AncestryEthnicOriginDescriptor (AncestryEthnicOriginDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin ADD CONSTRAINT FK_2c2b13_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_CohortYearTypeDescriptor FOREIGN KEY (CohortYearTypeDescriptorId)
REFERENCES edfi.CohortYearTypeDescriptor (CohortYearTypeDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisability ADD CONSTRAINT FK_4ca65b_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisability ADD CONSTRAINT FK_4ca65b_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisability ADD CONSTRAINT FK_4ca65b_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisabilityDesignation ADD CONSTRAINT FK_5ee8fd_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisabilityDesignation ADD CONSTRAINT FK_5ee8fd_StudentEducationOrganizationAssociationDisability FOREIGN KEY (EducationOrganizationId, StudentUSI, DisabilityDescriptorId)
REFERENCES edfi.StudentEducationOrganizationAssociationDisability (EducationOrganizationId, StudentUSI, DisabilityDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationElectronicMail ADD CONSTRAINT FK_582e49_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationElectronicMail ADD CONSTRAINT FK_582e49_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress ADD CONSTRAINT FK_a82b93_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress ADD CONSTRAINT FK_a82b93_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress ADD CONSTRAINT FK_a82b93_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguage ADD CONSTRAINT FK_2a4725_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguage ADD CONSTRAINT FK_2a4725_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguageUse ADD CONSTRAINT FK_2e333a_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguageUse ADD CONSTRAINT FK_2e333a_StudentEducationOrganizationAssociationLanguage FOREIGN KEY (EducationOrganizationId, StudentUSI, LanguageDescriptorId)
REFERENCES edfi.StudentEducationOrganizationAssociationLanguage (EducationOrganizationId, StudentUSI, LanguageDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationRace ADD CONSTRAINT FK_a6a1f0_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationRace ADD CONSTRAINT FK_a6a1f0_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf ADD CONSTRAINT FK_a18fcf_StudentEducationOrganizationAssociationStudentCharacteristic FOREIGN KEY (EducationOrganizationId, StudentUSI, StudentCharacteristicDescriptorId)
REFERENCES edfi.StudentEducationOrganizationAssociationStudentCharacteristic (EducationOrganizationId, StudentUSI, StudentCharacteristicDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteristic ADD CONSTRAINT FK_b865d7_StudentCharacteristicDescriptor FOREIGN KEY (StudentCharacteristicDescriptorId)
REFERENCES edfi.StudentCharacteristicDescriptor (StudentCharacteristicDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteristic ADD CONSTRAINT FK_b865d7_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 ADD CONSTRAINT FK_c15030_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 ADD CONSTRAINT FK_c15030_StudentIdentificationSystemDescriptor FOREIGN KEY (StudentIdentificationSystemDescriptorId)
REFERENCES edfi.StudentIdentificationSystemDescriptor (StudentIdentificationSystemDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIndicator ADD CONSTRAINT FK_ca697a_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod ADD CONSTRAINT FK_a61b72_StudentEducationOrganizationAssociationStudentIndicator FOREIGN KEY (EducationOrganizationId, StudentUSI, IndicatorName)
REFERENCES edfi.StudentEducationOrganizationAssociationStudentIndicator (EducationOrganizationId, StudentUSI, IndicatorName)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationTelephone ADD CONSTRAINT FK_a2d4a8_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationTelephone ADD CONSTRAINT FK_a2d4a8_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationTribalAffiliation ADD CONSTRAINT FK_0628e0_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentEducationOrganizationAssociationTribalAffiliation ADD CONSTRAINT FK_0628e0_TribalAffiliationDescriptor FOREIGN KEY (TribalAffiliationDescriptorId)
REFERENCES edfi.TribalAffiliationDescriptor (TribalAffiliationDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD CONSTRAINT FK_42aa64_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD CONSTRAINT FK_42aa64_ResponsibilityDescriptor FOREIGN KEY (ResponsibilityDescriptorId)
REFERENCES edfi.ResponsibilityDescriptor (ResponsibilityDescriptorId)
;

ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD CONSTRAINT FK_42aa64_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_AssignmentLateStatusDescriptor FOREIGN KEY (AssignmentLateStatusDescriptorId)
REFERENCES edfi.AssignmentLateStatusDescriptor (AssignmentLateStatusDescriptorId)
;

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_CompetencyLevelDescriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.CompetencyLevelDescriptor (CompetencyLevelDescriptorId)
;

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_GradebookEntry FOREIGN KEY (GradebookEntryIdentifier, Namespace)
REFERENCES edfi.GradebookEntry (GradebookEntryIdentifier, Namespace)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_SubmissionStatusDescriptor FOREIGN KEY (SubmissionStatusDescriptorId)
REFERENCES edfi.SubmissionStatusDescriptor (SubmissionStatusDescriptorId)
;

ALTER TABLE edfi.StudentHomelessProgramAssociation ADD CONSTRAINT FK_a50f80_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentHomelessProgramAssociation ADD CONSTRAINT FK_a50f80_HomelessPrimaryNighttimeResidenceDescriptor FOREIGN KEY (HomelessPrimaryNighttimeResidenceDescriptorId)
REFERENCES edfi.HomelessPrimaryNighttimeResidenceDescriptor (HomelessPrimaryNighttimeResidenceDescriptorId)
;

ALTER TABLE edfi.StudentHomelessProgramAssociationHomelessProgramService ADD CONSTRAINT FK_b31a96_HomelessProgramServiceDescriptor FOREIGN KEY (HomelessProgramServiceDescriptorId)
REFERENCES edfi.HomelessProgramServiceDescriptor (HomelessProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentHomelessProgramAssociationHomelessProgramService ADD CONSTRAINT FK_b31a96_StudentHomelessProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentHomelessProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentIdentificationSystemDescriptor ADD CONSTRAINT FK_a28cb4_Descriptor FOREIGN KEY (StudentIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentInterventionAssociation ADD CONSTRAINT FK_25cb9c_Cohort FOREIGN KEY (CohortIdentifier, CohortEducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
;

ALTER TABLE edfi.StudentInterventionAssociation ADD CONSTRAINT FK_25cb9c_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
;

ALTER TABLE edfi.StudentInterventionAssociation ADD CONSTRAINT FK_25cb9c_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_InterventionEffectivenessRatingDescriptor FOREIGN KEY (InterventionEffectivenessRatingDescriptorId)
REFERENCES edfi.InterventionEffectivenessRatingDescriptor (InterventionEffectivenessRatingDescriptorId)
;

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_StudentInterventionAssociation FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode, StudentUSI)
REFERENCES edfi.StudentInterventionAssociation (EducationOrganizationId, InterventionIdentificationCode, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
;

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociation ADD CONSTRAINT FK_92de5d_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_MonitoredDescriptor FOREIGN KEY (MonitoredDescriptorId)
REFERENCES edfi.MonitoredDescriptor (MonitoredDescriptorId)
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_ParticipationDescriptor FOREIGN KEY (ParticipationDescriptorId)
REFERENCES edfi.ParticipationDescriptor (ParticipationDescriptorId)
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_ProficiencyDescriptor FOREIGN KEY (ProficiencyDescriptorId)
REFERENCES edfi.ProficiencyDescriptor (ProficiencyDescriptorId)
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_ProgressDescriptor FOREIGN KEY (ProgressDescriptorId)
REFERENCES edfi.ProgressDescriptor (ProgressDescriptorId)
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_StudentLanguageInstructionProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentLanguageInstructionProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 ADD CONSTRAINT FK_268e07_LanguageInstructionProgramServiceDescriptor FOREIGN KEY (LanguageInstructionProgramServiceDescriptorId)
REFERENCES edfi.LanguageInstructionProgramServiceDescriptor (LanguageInstructionProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 ADD CONSTRAINT FK_268e07_StudentLanguageInstructionProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentLanguageInstructionProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentMigrantEducationProgramAssociation ADD CONSTRAINT FK_85e741_ContinuationOfServicesReasonDescriptor FOREIGN KEY (ContinuationOfServicesReasonDescriptorId)
REFERENCES edfi.ContinuationOfServicesReasonDescriptor (ContinuationOfServicesReasonDescriptorId)
;

ALTER TABLE edfi.StudentMigrantEducationProgramAssociation ADD CONSTRAINT FK_85e741_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 ADD CONSTRAINT FK_d9dcd7_MigrantEducationProgramServiceDescriptor FOREIGN KEY (MigrantEducationProgramServiceDescriptorId)
REFERENCES edfi.MigrantEducationProgramServiceDescriptor (MigrantEducationProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 ADD CONSTRAINT FK_d9dcd7_StudentMigrantEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentMigrantEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_NeglectedOrDelinquentProgramDescriptor FOREIGN KEY (NeglectedOrDelinquentProgramDescriptorId)
REFERENCES edfi.NeglectedOrDelinquentProgramDescriptor (NeglectedOrDelinquentProgramDescriptorId)
;

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_ProgressLevelDescriptor FOREIGN KEY (ELAProgressLevelDescriptorId)
REFERENCES edfi.ProgressLevelDescriptor (ProgressLevelDescriptorId)
;

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_ProgressLevelDescriptor1 FOREIGN KEY (MathematicsProgressLevelDescriptorId)
REFERENCES edfi.ProgressLevelDescriptor (ProgressLevelDescriptorId)
;

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 ADD CONSTRAINT FK_520251_NeglectedOrDelinquentProgramServiceDescriptor FOREIGN KEY (NeglectedOrDelinquentProgramServiceDescriptorId)
REFERENCES edfi.NeglectedOrDelinquentProgramServiceDescriptor (NeglectedOrDelinquentProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 ADD CONSTRAINT FK_520251_StudentNeglectedOrDelinquentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentNeglectedOrDelinquentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentOtherName ADD CONSTRAINT FK_ae53d1_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

ALTER TABLE edfi.StudentOtherName ADD CONSTRAINT FK_ae53d1_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentParticipationCodeDescriptor ADD CONSTRAINT FK_aa25ae_Descriptor FOREIGN KEY (StudentParticipationCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentProgramAssociation ADD CONSTRAINT FK_729018_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentProgramAssociationService ADD CONSTRAINT FK_69cd6f_ServiceDescriptor FOREIGN KEY (ServiceDescriptorId)
REFERENCES edfi.ServiceDescriptor (ServiceDescriptorId)
;

ALTER TABLE edfi.StudentProgramAssociationService ADD CONSTRAINT FK_69cd6f_StudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentProgramEvaluation ADD CONSTRAINT FK_4b1054_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StudentProgramEvaluation ADD CONSTRAINT FK_4b1054_ProgramEvaluation FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluation (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.StudentProgramEvaluation ADD CONSTRAINT FK_4b1054_RatingLevelDescriptor FOREIGN KEY (SummaryEvaluationRatingLevelDescriptorId)
REFERENCES edfi.RatingLevelDescriptor (RatingLevelDescriptorId)
;

ALTER TABLE edfi.StudentProgramEvaluation ADD CONSTRAINT FK_4b1054_Staff FOREIGN KEY (StaffEvaluatorStaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StudentProgramEvaluation ADD CONSTRAINT FK_4b1054_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentProgramEvaluationExternalEvaluator ADD CONSTRAINT FK_04c7ce_StudentProgramEvaluation FOREIGN KEY (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentProgramEvaluation (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationElement ADD CONSTRAINT FK_24f4bf_ProgramEvaluationElement FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluationElement (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationElement ADD CONSTRAINT FK_24f4bf_RatingLevelDescriptor FOREIGN KEY (EvaluationElementRatingLevelDescriptorId)
REFERENCES edfi.RatingLevelDescriptor (RatingLevelDescriptorId)
;

ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationElement ADD CONSTRAINT FK_24f4bf_StudentProgramEvaluation FOREIGN KEY (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentProgramEvaluation (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationObjective ADD CONSTRAINT FK_d9a90e_ProgramEvaluationObjective FOREIGN KEY (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.ProgramEvaluationObjective (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationObjective ADD CONSTRAINT FK_d9a90e_RatingLevelDescriptor FOREIGN KEY (EvaluationObjectiveRatingLevelDescriptorId)
REFERENCES edfi.RatingLevelDescriptor (RatingLevelDescriptorId)
;

ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationObjective ADD CONSTRAINT FK_d9a90e_StudentProgramEvaluation FOREIGN KEY (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentProgramEvaluation (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_EnrollmentTypeDescriptor FOREIGN KEY (EnrollmentTypeDescriptorId)
REFERENCES edfi.EnrollmentTypeDescriptor (EnrollmentTypeDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_EntryGradeLevelReasonDescriptor FOREIGN KEY (EntryGradeLevelReasonDescriptorId)
REFERENCES edfi.EntryGradeLevelReasonDescriptor (EntryGradeLevelReasonDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_EntryTypeDescriptor FOREIGN KEY (EntryTypeDescriptorId)
REFERENCES edfi.EntryTypeDescriptor (EntryTypeDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_ExitWithdrawTypeDescriptor FOREIGN KEY (ExitWithdrawTypeDescriptorId)
REFERENCES edfi.ExitWithdrawTypeDescriptor (ExitWithdrawTypeDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_GradeLevelDescriptor FOREIGN KEY (EntryGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_GradeLevelDescriptor1 FOREIGN KEY (NextYearGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_ResidencyStatusDescriptor FOREIGN KEY (ResidencyStatusDescriptorId)
REFERENCES edfi.ResidencyStatusDescriptor (ResidencyStatusDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_School1 FOREIGN KEY (NextYearSchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_SchoolChoiceBasisDescriptor FOREIGN KEY (SchoolChoiceBasisDescriptorId)
REFERENCES edfi.SchoolChoiceBasisDescriptor (SchoolChoiceBasisDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_SchoolYearType1 FOREIGN KEY (ClassOfSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentSchoolAssociationAlternativeGraduationPlan ADD CONSTRAINT FK_70e978_GraduationPlan FOREIGN KEY (AlternativeEducationOrganizationId, AlternativeGraduationPlanTypeDescriptorId, AlternativeGraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
;

ALTER TABLE edfi.StudentSchoolAssociationAlternativeGraduationPlan ADD CONSTRAINT FK_70e978_StudentSchoolAssociation FOREIGN KEY (EntryDate, SchoolId, StudentUSI)
REFERENCES edfi.StudentSchoolAssociation (EntryDate, SchoolId, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentSchoolAssociationEducationPlan ADD CONSTRAINT FK_f5b9f6_EducationPlanDescriptor FOREIGN KEY (EducationPlanDescriptorId)
REFERENCES edfi.EducationPlanDescriptor (EducationPlanDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAssociationEducationPlan ADD CONSTRAINT FK_f5b9f6_StudentSchoolAssociation FOREIGN KEY (EntryDate, SchoolId, StudentUSI)
REFERENCES edfi.StudentSchoolAssociation (EntryDate, SchoolId, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentSchoolFoodServiceProgramAssociation ADD CONSTRAINT FK_82e1e5_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb ADD CONSTRAINT FK_85a0eb_SchoolFoodServiceProgramServiceDescriptor FOREIGN KEY (SchoolFoodServiceProgramServiceDescriptorId)
REFERENCES edfi.SchoolFoodServiceProgramServiceDescriptor (SchoolFoodServiceProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb ADD CONSTRAINT FK_85a0eb_StudentSchoolFoodServiceProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSchoolFoodServiceProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_AttemptStatusDescriptor FOREIGN KEY (AttemptStatusDescriptorId)
REFERENCES edfi.AttemptStatusDescriptor (AttemptStatusDescriptorId)
;

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_RepeatIdentifierDescriptor FOREIGN KEY (RepeatIdentifierDescriptorId)
REFERENCES edfi.RepeatIdentifierDescriptor (RepeatIdentifierDescriptorId)
;

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentSectionAttendanceEventClassPeriod ADD CONSTRAINT FK_80c6c1_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentSectionAttendanceEventClassPeriod ADD CONSTRAINT FK_80c6c1_StudentSectionAttendanceEvent FOREIGN KEY (AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAttendanceEvent (AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociation ADD CONSTRAINT FK_f86fd9_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociation ADD CONSTRAINT FK_f86fd9_SpecialEducationSettingDescriptor FOREIGN KEY (SpecialEducationSettingDescriptorId)
REFERENCES edfi.SpecialEducationSettingDescriptor (SpecialEducationSettingDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisability ADD CONSTRAINT FK_32920f_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisability ADD CONSTRAINT FK_32920f_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisability ADD CONSTRAINT FK_32920f_StudentSpecialEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation ADD CONSTRAINT FK_a2fd20_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation ADD CONSTRAINT FK_a2fd20_StudentSpecialEducationProgramAssociationDisability FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, DisabilityDescriptorId)
REFERENCES edfi.StudentSpecialEducationProgramAssociationDisability (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, DisabilityDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationServiceProvider ADD CONSTRAINT FK_fece89_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationServiceProvider ADD CONSTRAINT FK_fece89_StudentSpecialEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 ADD CONSTRAINT FK_a51ff9_SpecialEducationProgramServiceDescriptor FOREIGN KEY (SpecialEducationProgramServiceDescriptorId)
REFERENCES edfi.SpecialEducationProgramServiceDescriptor (SpecialEducationProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 ADD CONSTRAINT FK_a51ff9_StudentSpecialEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c ADD CONSTRAINT FK_bcba5c_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c ADD CONSTRAINT FK_bcba5c_StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, SpecialEducationProgramServiceDescriptorId)
REFERENCES edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, SpecialEducationProgramServiceDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD CONSTRAINT FK_fcb699_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD CONSTRAINT FK_fcb699_EligibilityDelayReasonDescriptor FOREIGN KEY (EligibilityDelayReasonDescriptorId)
REFERENCES edfi.EligibilityDelayReasonDescriptor (EligibilityDelayReasonDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD CONSTRAINT FK_fcb699_EligibilityEvaluationTypeDescriptor FOREIGN KEY (EligibilityEvaluationTypeDescriptorId)
REFERENCES edfi.EligibilityEvaluationTypeDescriptor (EligibilityEvaluationTypeDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD CONSTRAINT FK_fcb699_EvaluationDelayReasonDescriptor FOREIGN KEY (EvaluationDelayReasonDescriptorId)
REFERENCES edfi.EvaluationDelayReasonDescriptor (EvaluationDelayReasonDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD CONSTRAINT FK_fcb699_IDEAPartDescriptor FOREIGN KEY (IDEAPartDescriptorId)
REFERENCES edfi.IDEAPartDescriptor (IDEAPartDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD CONSTRAINT FK_fcb699_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD CONSTRAINT FK_fcb699_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.StudentTitleIPartAProgramAssociation ADD CONSTRAINT FK_27d914_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentTitleIPartAProgramAssociation ADD CONSTRAINT FK_27d914_TitleIPartAParticipantDescriptor FOREIGN KEY (TitleIPartAParticipantDescriptorId)
REFERENCES edfi.TitleIPartAParticipantDescriptor (TitleIPartAParticipantDescriptorId)
;

ALTER TABLE edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService ADD CONSTRAINT FK_8adb29_StudentTitleIPartAProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentTitleIPartAProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService ADD CONSTRAINT FK_8adb29_TitleIPartAProgramServiceDescriptor FOREIGN KEY (TitleIPartAProgramServiceDescriptorId)
REFERENCES edfi.TitleIPartAProgramServiceDescriptor (TitleIPartAProgramServiceDescriptorId)
;

ALTER TABLE edfi.StudentVisa ADD CONSTRAINT FK_aa5751_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentVisa ADD CONSTRAINT FK_aa5751_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

ALTER TABLE edfi.SubmissionStatusDescriptor ADD CONSTRAINT FK_8e9244_Descriptor FOREIGN KEY (SubmissionStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_SurveyCategoryDescriptor FOREIGN KEY (SurveyCategoryDescriptorId)
REFERENCES edfi.SurveyCategoryDescriptor (SurveyCategoryDescriptorId)
;

ALTER TABLE edfi.SurveyCategoryDescriptor ADD CONSTRAINT FK_4e55bd_Descriptor FOREIGN KEY (SurveyCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyCourseAssociation ADD CONSTRAINT FK_9f1246_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

ALTER TABLE edfi.SurveyCourseAssociation ADD CONSTRAINT FK_9f1246_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

ALTER TABLE edfi.SurveyLevelDescriptor ADD CONSTRAINT FK_bce725_Descriptor FOREIGN KEY (SurveyLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyProgramAssociation ADD CONSTRAINT FK_e3e5a4_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

ALTER TABLE edfi.SurveyProgramAssociation ADD CONSTRAINT FK_e3e5a4_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

ALTER TABLE edfi.SurveyQuestion ADD CONSTRAINT FK_1bb88c_QuestionFormDescriptor FOREIGN KEY (QuestionFormDescriptorId)
REFERENCES edfi.QuestionFormDescriptor (QuestionFormDescriptorId)
;

ALTER TABLE edfi.SurveyQuestion ADD CONSTRAINT FK_1bb88c_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

ALTER TABLE edfi.SurveyQuestion ADD CONSTRAINT FK_1bb88c_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
;

ALTER TABLE edfi.SurveyQuestionMatrix ADD CONSTRAINT FK_64d76d_SurveyQuestion FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier)
REFERENCES edfi.SurveyQuestion (Namespace, QuestionCode, SurveyIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyQuestionResponse ADD CONSTRAINT FK_eddd02_SurveyQuestion FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier)
REFERENCES edfi.SurveyQuestion (Namespace, QuestionCode, SurveyIdentifier)
;

ALTER TABLE edfi.SurveyQuestionResponse ADD CONSTRAINT FK_eddd02_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

ALTER TABLE edfi.SurveyQuestionResponseChoice ADD CONSTRAINT FK_1c624b_SurveyQuestion FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier)
REFERENCES edfi.SurveyQuestion (Namespace, QuestionCode, SurveyIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse ADD CONSTRAINT FK_048797_SurveyQuestionResponse FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyQuestionResponse (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyQuestionResponseValue ADD CONSTRAINT FK_d047f5_SurveyQuestionResponse FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyQuestionResponse (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Contact FOREIGN KEY (ContactUSI)
REFERENCES edfi.Contact (ContactUSI)
;

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_b2bd0a_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_b2bd0a_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD CONSTRAINT FK_f9457e_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD CONSTRAINT FK_f9457e_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

ALTER TABLE edfi.SurveyResponseSurveyLevel ADD CONSTRAINT FK_03f044_SurveyLevelDescriptor FOREIGN KEY (SurveyLevelDescriptorId)
REFERENCES edfi.SurveyLevelDescriptor (SurveyLevelDescriptorId)
;

ALTER TABLE edfi.SurveyResponseSurveyLevel ADD CONSTRAINT FK_03f044_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveySection ADD CONSTRAINT FK_e5572a_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

ALTER TABLE edfi.SurveySectionAssociation ADD CONSTRAINT FK_c16804_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

ALTER TABLE edfi.SurveySectionAssociation ADD CONSTRAINT FK_c16804_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

ALTER TABLE edfi.SurveySectionResponse ADD CONSTRAINT FK_2189c3_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

ALTER TABLE edfi.SurveySectionResponse ADD CONSTRAINT FK_2189c3_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
;

ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_730be1_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_730be1_SurveySectionResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySectionResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
;

ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD CONSTRAINT FK_39073d_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD CONSTRAINT FK_39073d_SurveySectionResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySectionResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
;

ALTER TABLE edfi.TeachingCredentialBasisDescriptor ADD CONSTRAINT FK_11e850_Descriptor FOREIGN KEY (TeachingCredentialBasisDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TeachingCredentialDescriptor ADD CONSTRAINT FK_4bb8c5_Descriptor FOREIGN KEY (TeachingCredentialDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TechnicalSkillsAssessmentDescriptor ADD CONSTRAINT FK_92e2f1_Descriptor FOREIGN KEY (TechnicalSkillsAssessmentDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TelephoneNumberTypeDescriptor ADD CONSTRAINT FK_b46168_Descriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TermDescriptor ADD CONSTRAINT FK_f36b04_Descriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TitleIPartAParticipantDescriptor ADD CONSTRAINT FK_1d0172_Descriptor FOREIGN KEY (TitleIPartAParticipantDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TitleIPartAProgramServiceDescriptor ADD CONSTRAINT FK_a62aa8_Descriptor FOREIGN KEY (TitleIPartAProgramServiceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TitleIPartASchoolDesignationDescriptor ADD CONSTRAINT FK_935362_Descriptor FOREIGN KEY (TitleIPartASchoolDesignationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.TribalAffiliationDescriptor ADD CONSTRAINT FK_1cb85d_Descriptor FOREIGN KEY (TribalAffiliationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.VisaDescriptor ADD CONSTRAINT FK_4b609a_Descriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.WeaponDescriptor ADD CONSTRAINT FK_402831_Descriptor FOREIGN KEY (WeaponDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

