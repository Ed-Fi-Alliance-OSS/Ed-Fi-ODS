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

CREATE INDEX FK_a97956_School
ON edfi.AcademicWeek (SchoolId ASC);

ALTER TABLE edfi.AccommodationDescriptor ADD CONSTRAINT FK_395139_Descriptor FOREIGN KEY (AccommodationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AccountabilityRating ADD CONSTRAINT FK_2d3c0c_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_2d3c0c_EducationOrganization
ON edfi.AccountabilityRating (EducationOrganizationId ASC);

ALTER TABLE edfi.AccountabilityRating ADD CONSTRAINT FK_2d3c0c_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_2d3c0c_SchoolYearType
ON edfi.AccountabilityRating (SchoolYear ASC);

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

CREATE INDEX FK_7808ee_AssessmentCategoryDescriptor
ON edfi.Assessment (AssessmentCategoryDescriptorId ASC);

ALTER TABLE edfi.Assessment ADD CONSTRAINT FK_7808ee_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_7808ee_EducationOrganization
ON edfi.Assessment (EducationOrganizationId ASC);

ALTER TABLE edfi.AssessmentAcademicSubject ADD CONSTRAINT FK_400d06_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_400d06_AcademicSubjectDescriptor
ON edfi.AssessmentAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.AssessmentAcademicSubject ADD CONSTRAINT FK_400d06_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_400d06_Assessment
ON edfi.AssessmentAcademicSubject (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentAssessedGradeLevel ADD CONSTRAINT FK_e83625_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_e83625_Assessment
ON edfi.AssessmentAssessedGradeLevel (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentAssessedGradeLevel ADD CONSTRAINT FK_e83625_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_e83625_GradeLevelDescriptor
ON edfi.AssessmentAssessedGradeLevel (GradeLevelDescriptorId ASC);

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

CREATE INDEX FK_bd89c0_EducationOrganization
ON edfi.AssessmentContentStandard (MandatingEducationOrganizationId ASC);

ALTER TABLE edfi.AssessmentContentStandard ADD CONSTRAINT FK_bd89c0_PublicationStatusDescriptor FOREIGN KEY (PublicationStatusDescriptorId)
REFERENCES edfi.PublicationStatusDescriptor (PublicationStatusDescriptorId)
;

CREATE INDEX FK_bd89c0_PublicationStatusDescriptor
ON edfi.AssessmentContentStandard (PublicationStatusDescriptorId ASC);

ALTER TABLE edfi.AssessmentContentStandardAuthor ADD CONSTRAINT FK_21acd5_AssessmentContentStandard FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.AssessmentContentStandard (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_21acd5_AssessmentContentStandard
ON edfi.AssessmentContentStandardAuthor (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentIdentificationCode ADD CONSTRAINT FK_3af731_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_3af731_Assessment
ON edfi.AssessmentIdentificationCode (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentIdentificationCode ADD CONSTRAINT FK_3af731_AssessmentIdentificationSystemDescriptor FOREIGN KEY (AssessmentIdentificationSystemDescriptorId)
REFERENCES edfi.AssessmentIdentificationSystemDescriptor (AssessmentIdentificationSystemDescriptorId)
;

CREATE INDEX FK_3af731_AssessmentIdentificationSystemDescriptor
ON edfi.AssessmentIdentificationCode (AssessmentIdentificationSystemDescriptorId ASC);

ALTER TABLE edfi.AssessmentIdentificationSystemDescriptor ADD CONSTRAINT FK_a47976_Descriptor FOREIGN KEY (AssessmentIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentItem ADD CONSTRAINT FK_dc3dcf_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

CREATE INDEX FK_dc3dcf_Assessment
ON edfi.AssessmentItem (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentItem ADD CONSTRAINT FK_dc3dcf_AssessmentItemCategoryDescriptor FOREIGN KEY (AssessmentItemCategoryDescriptorId)
REFERENCES edfi.AssessmentItemCategoryDescriptor (AssessmentItemCategoryDescriptorId)
;

CREATE INDEX FK_dc3dcf_AssessmentItemCategoryDescriptor
ON edfi.AssessmentItem (AssessmentItemCategoryDescriptorId ASC);

ALTER TABLE edfi.AssessmentItemCategoryDescriptor ADD CONSTRAINT FK_a5f1ee_Descriptor FOREIGN KEY (AssessmentItemCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentItemLearningStandard ADD CONSTRAINT FK_151580_AssessmentItem FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_151580_AssessmentItem
ON edfi.AssessmentItemLearningStandard (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentItemLearningStandard ADD CONSTRAINT FK_151580_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_151580_LearningStandard
ON edfi.AssessmentItemLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.AssessmentItemPossibleResponse ADD CONSTRAINT FK_699b02_AssessmentItem FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_699b02_AssessmentItem
ON edfi.AssessmentItemPossibleResponse (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentItemResultDescriptor ADD CONSTRAINT FK_47b16e_Descriptor FOREIGN KEY (AssessmentItemResultDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentLanguage ADD CONSTRAINT FK_d90abb_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_d90abb_Assessment
ON edfi.AssessmentLanguage (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentLanguage ADD CONSTRAINT FK_d90abb_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_d90abb_LanguageDescriptor
ON edfi.AssessmentLanguage (LanguageDescriptorId ASC);

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_11bd42_Assessment
ON edfi.AssessmentPerformanceLevel (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_11bd42_AssessmentReportingMethodDescriptor
ON edfi.AssessmentPerformanceLevel (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

CREATE INDEX FK_11bd42_PerformanceLevelDescriptor
ON edfi.AssessmentPerformanceLevel (PerformanceLevelDescriptorId ASC);

ALTER TABLE edfi.AssessmentPerformanceLevel ADD CONSTRAINT FK_11bd42_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_11bd42_ResultDatatypeTypeDescriptor
ON edfi.AssessmentPerformanceLevel (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE edfi.AssessmentPeriod ADD CONSTRAINT FK_3734d1_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_3734d1_Assessment
ON edfi.AssessmentPeriod (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentPeriod ADD CONSTRAINT FK_3734d1_AssessmentPeriodDescriptor FOREIGN KEY (AssessmentPeriodDescriptorId)
REFERENCES edfi.AssessmentPeriodDescriptor (AssessmentPeriodDescriptorId)
;

CREATE INDEX FK_3734d1_AssessmentPeriodDescriptor
ON edfi.AssessmentPeriod (AssessmentPeriodDescriptorId ASC);

ALTER TABLE edfi.AssessmentPeriodDescriptor ADD CONSTRAINT FK_7e11fe_Descriptor FOREIGN KEY (AssessmentPeriodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentPlatformType ADD CONSTRAINT FK_a3387e_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_a3387e_Assessment
ON edfi.AssessmentPlatformType (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentPlatformType ADD CONSTRAINT FK_a3387e_PlatformTypeDescriptor FOREIGN KEY (PlatformTypeDescriptorId)
REFERENCES edfi.PlatformTypeDescriptor (PlatformTypeDescriptorId)
;

CREATE INDEX FK_a3387e_PlatformTypeDescriptor
ON edfi.AssessmentPlatformType (PlatformTypeDescriptorId ASC);

ALTER TABLE edfi.AssessmentProgram ADD CONSTRAINT FK_58013b_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_58013b_Assessment
ON edfi.AssessmentProgram (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentProgram ADD CONSTRAINT FK_58013b_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_58013b_Program
ON edfi.AssessmentProgram (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.AssessmentReportingMethodDescriptor ADD CONSTRAINT FK_dbee26_Descriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.AssessmentScore ADD CONSTRAINT FK_df7331_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_df7331_Assessment
ON edfi.AssessmentScore (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentScore ADD CONSTRAINT FK_df7331_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_df7331_AssessmentReportingMethodDescriptor
ON edfi.AssessmentScore (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.AssessmentScore ADD CONSTRAINT FK_df7331_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_df7331_ResultDatatypeTypeDescriptor
ON edfi.AssessmentScore (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD CONSTRAINT FK_a20588_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

CREATE INDEX FK_a20588_Assessment
ON edfi.AssessmentScoreRangeLearningStandard (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD CONSTRAINT FK_a20588_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_a20588_AssessmentReportingMethodDescriptor
ON edfi.AssessmentScoreRangeLearningStandard (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD CONSTRAINT FK_a20588_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
;

CREATE INDEX FK_a20588_ObjectiveAssessment
ON edfi.AssessmentScoreRangeLearningStandard (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentScoreRangeLearningStandardLearningStandard ADD CONSTRAINT FK_9960a9_AssessmentScoreRangeLearningStandard FOREIGN KEY (AssessmentIdentifier, Namespace, ScoreRangeId)
REFERENCES edfi.AssessmentScoreRangeLearningStandard (AssessmentIdentifier, Namespace, ScoreRangeId)
ON DELETE CASCADE
;

CREATE INDEX FK_9960a9_AssessmentScoreRangeLearningStandard
ON edfi.AssessmentScoreRangeLearningStandardLearningStandard (AssessmentIdentifier ASC, Namespace ASC, ScoreRangeId ASC);

ALTER TABLE edfi.AssessmentScoreRangeLearningStandardLearningStandard ADD CONSTRAINT FK_9960a9_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_9960a9_LearningStandard
ON edfi.AssessmentScoreRangeLearningStandardLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.AssessmentSection ADD CONSTRAINT FK_22ceba_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_22ceba_Assessment
ON edfi.AssessmentSection (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.AssessmentSection ADD CONSTRAINT FK_22ceba_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_22ceba_Section
ON edfi.AssessmentSection (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

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

CREATE INDEX FK_bcbd82_BalanceSheetDimension
ON edfi.BalanceSheetDimensionReportingTag (Code ASC, FiscalYear ASC);

ALTER TABLE edfi.BalanceSheetDimensionReportingTag ADD CONSTRAINT FK_bcbd82_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_bcbd82_ReportingTagDescriptor
ON edfi.BalanceSheetDimensionReportingTag (ReportingTagDescriptorId ASC);

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

CREATE INDEX FK_9bbaf5_School
ON edfi.BellSchedule (SchoolId ASC);

ALTER TABLE edfi.BellScheduleClassPeriod ADD CONSTRAINT FK_9e377d_BellSchedule FOREIGN KEY (BellScheduleName, SchoolId)
REFERENCES edfi.BellSchedule (BellScheduleName, SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_9e377d_BellSchedule
ON edfi.BellScheduleClassPeriod (BellScheduleName ASC, SchoolId ASC);

ALTER TABLE edfi.BellScheduleClassPeriod ADD CONSTRAINT FK_9e377d_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON UPDATE CASCADE
;

CREATE INDEX FK_9e377d_ClassPeriod
ON edfi.BellScheduleClassPeriod (ClassPeriodName ASC, SchoolId ASC);

ALTER TABLE edfi.BellScheduleDate ADD CONSTRAINT FK_6e1291_BellSchedule FOREIGN KEY (BellScheduleName, SchoolId)
REFERENCES edfi.BellSchedule (BellScheduleName, SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_6e1291_BellSchedule
ON edfi.BellScheduleDate (BellScheduleName ASC, SchoolId ASC);

ALTER TABLE edfi.BellScheduleGradeLevel ADD CONSTRAINT FK_226b3d_BellSchedule FOREIGN KEY (BellScheduleName, SchoolId)
REFERENCES edfi.BellSchedule (BellScheduleName, SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_226b3d_BellSchedule
ON edfi.BellScheduleGradeLevel (BellScheduleName ASC, SchoolId ASC);

ALTER TABLE edfi.BellScheduleGradeLevel ADD CONSTRAINT FK_226b3d_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_226b3d_GradeLevelDescriptor
ON edfi.BellScheduleGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.Calendar ADD CONSTRAINT FK_d5d0a3_CalendarTypeDescriptor FOREIGN KEY (CalendarTypeDescriptorId)
REFERENCES edfi.CalendarTypeDescriptor (CalendarTypeDescriptorId)
;

CREATE INDEX FK_d5d0a3_CalendarTypeDescriptor
ON edfi.Calendar (CalendarTypeDescriptorId ASC);

ALTER TABLE edfi.Calendar ADD CONSTRAINT FK_d5d0a3_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_d5d0a3_School
ON edfi.Calendar (SchoolId ASC);

ALTER TABLE edfi.Calendar ADD CONSTRAINT FK_d5d0a3_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_d5d0a3_SchoolYearType
ON edfi.Calendar (SchoolYear ASC);

ALTER TABLE edfi.CalendarDate ADD CONSTRAINT FK_8a9a67_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
;

CREATE INDEX FK_8a9a67_Calendar
ON edfi.CalendarDate (CalendarCode ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.CalendarDateCalendarEvent ADD CONSTRAINT FK_0789bb_CalendarDate FOREIGN KEY (CalendarCode, Date, SchoolId, SchoolYear)
REFERENCES edfi.CalendarDate (CalendarCode, Date, SchoolId, SchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_0789bb_CalendarDate
ON edfi.CalendarDateCalendarEvent (CalendarCode ASC, Date ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.CalendarDateCalendarEvent ADD CONSTRAINT FK_0789bb_CalendarEventDescriptor FOREIGN KEY (CalendarEventDescriptorId)
REFERENCES edfi.CalendarEventDescriptor (CalendarEventDescriptorId)
;

CREATE INDEX FK_0789bb_CalendarEventDescriptor
ON edfi.CalendarDateCalendarEvent (CalendarEventDescriptorId ASC);

ALTER TABLE edfi.CalendarEventDescriptor ADD CONSTRAINT FK_f598e5_Descriptor FOREIGN KEY (CalendarEventDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CalendarGradeLevel ADD CONSTRAINT FK_07722c_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_07722c_Calendar
ON edfi.CalendarGradeLevel (CalendarCode ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.CalendarGradeLevel ADD CONSTRAINT FK_07722c_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_07722c_GradeLevelDescriptor
ON edfi.CalendarGradeLevel (GradeLevelDescriptorId ASC);

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

CREATE INDEX FK_131e2b_AccountTypeDescriptor
ON edfi.ChartOfAccount (AccountTypeDescriptorId ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_BalanceSheetDimension FOREIGN KEY (BalanceSheetCode, FiscalYear)
REFERENCES edfi.BalanceSheetDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_BalanceSheetDimension
ON edfi.ChartOfAccount (BalanceSheetCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_131e2b_EducationOrganization
ON edfi.ChartOfAccount (EducationOrganizationId ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_FunctionDimension FOREIGN KEY (FunctionCode, FiscalYear)
REFERENCES edfi.FunctionDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_FunctionDimension
ON edfi.ChartOfAccount (FunctionCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_FundDimension FOREIGN KEY (FundCode, FiscalYear)
REFERENCES edfi.FundDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_FundDimension
ON edfi.ChartOfAccount (FundCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_ObjectDimension FOREIGN KEY (ObjectCode, FiscalYear)
REFERENCES edfi.ObjectDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_ObjectDimension
ON edfi.ChartOfAccount (ObjectCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_OperationalUnitDimension FOREIGN KEY (OperationalUnitCode, FiscalYear)
REFERENCES edfi.OperationalUnitDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_OperationalUnitDimension
ON edfi.ChartOfAccount (OperationalUnitCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_ProgramDimension FOREIGN KEY (ProgramCode, FiscalYear)
REFERENCES edfi.ProgramDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_ProgramDimension
ON edfi.ChartOfAccount (ProgramCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_ProjectDimension FOREIGN KEY (ProjectCode, FiscalYear)
REFERENCES edfi.ProjectDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_ProjectDimension
ON edfi.ChartOfAccount (ProjectCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccount ADD CONSTRAINT FK_131e2b_SourceDimension FOREIGN KEY (SourceCode, FiscalYear)
REFERENCES edfi.SourceDimension (Code, FiscalYear)
;

CREATE INDEX FK_131e2b_SourceDimension
ON edfi.ChartOfAccount (SourceCode ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccountReportingTag ADD CONSTRAINT FK_8422f4_ChartOfAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.ChartOfAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
ON DELETE CASCADE
;

CREATE INDEX FK_8422f4_ChartOfAccount
ON edfi.ChartOfAccountReportingTag (AccountIdentifier ASC, EducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.ChartOfAccountReportingTag ADD CONSTRAINT FK_8422f4_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_8422f4_ReportingTagDescriptor
ON edfi.ChartOfAccountReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.CitizenshipStatusDescriptor ADD CONSTRAINT FK_4c97e8_Descriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ClassPeriod ADD CONSTRAINT FK_01fe80_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_01fe80_School
ON edfi.ClassPeriod (SchoolId ASC);

ALTER TABLE edfi.ClassPeriodMeetingTime ADD CONSTRAINT FK_435263_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_435263_ClassPeriod
ON edfi.ClassPeriodMeetingTime (ClassPeriodName ASC, SchoolId ASC);

ALTER TABLE edfi.ClassroomPositionDescriptor ADD CONSTRAINT FK_c2dd12_Descriptor FOREIGN KEY (ClassroomPositionDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_19c6d6_AcademicSubjectDescriptor
ON edfi.Cohort (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_CohortScopeDescriptor FOREIGN KEY (CohortScopeDescriptorId)
REFERENCES edfi.CohortScopeDescriptor (CohortScopeDescriptorId)
;

CREATE INDEX FK_19c6d6_CohortScopeDescriptor
ON edfi.Cohort (CohortScopeDescriptorId ASC);

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_CohortTypeDescriptor FOREIGN KEY (CohortTypeDescriptorId)
REFERENCES edfi.CohortTypeDescriptor (CohortTypeDescriptorId)
;

CREATE INDEX FK_19c6d6_CohortTypeDescriptor
ON edfi.Cohort (CohortTypeDescriptorId ASC);

ALTER TABLE edfi.Cohort ADD CONSTRAINT FK_19c6d6_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_19c6d6_EducationOrganization
ON edfi.Cohort (EducationOrganizationId ASC);

ALTER TABLE edfi.CohortProgram ADD CONSTRAINT FK_59fcb5_Cohort FOREIGN KEY (CohortIdentifier, EducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_59fcb5_Cohort
ON edfi.CohortProgram (CohortIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.CohortProgram ADD CONSTRAINT FK_59fcb5_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_59fcb5_Program
ON edfi.CohortProgram (ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

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

CREATE INDEX FK_247572_CommunityOrganization
ON edfi.CommunityProvider (CommunityOrganizationId ASC);

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_EducationOrganization FOREIGN KEY (CommunityProviderId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_ProviderCategoryDescriptor FOREIGN KEY (ProviderCategoryDescriptorId)
REFERENCES edfi.ProviderCategoryDescriptor (ProviderCategoryDescriptorId)
;

CREATE INDEX FK_247572_ProviderCategoryDescriptor
ON edfi.CommunityProvider (ProviderCategoryDescriptorId ASC);

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_ProviderProfitabilityDescriptor FOREIGN KEY (ProviderProfitabilityDescriptorId)
REFERENCES edfi.ProviderProfitabilityDescriptor (ProviderProfitabilityDescriptorId)
;

CREATE INDEX FK_247572_ProviderProfitabilityDescriptor
ON edfi.CommunityProvider (ProviderProfitabilityDescriptorId ASC);

ALTER TABLE edfi.CommunityProvider ADD CONSTRAINT FK_247572_ProviderStatusDescriptor FOREIGN KEY (ProviderStatusDescriptorId)
REFERENCES edfi.ProviderStatusDescriptor (ProviderStatusDescriptorId)
;

CREATE INDEX FK_247572_ProviderStatusDescriptor
ON edfi.CommunityProvider (ProviderStatusDescriptorId ASC);

ALTER TABLE edfi.CommunityProviderLicense ADD CONSTRAINT FK_f092ff_CommunityProvider FOREIGN KEY (CommunityProviderId)
REFERENCES edfi.CommunityProvider (CommunityProviderId)
;

CREATE INDEX FK_f092ff_CommunityProvider
ON edfi.CommunityProviderLicense (CommunityProviderId ASC);

ALTER TABLE edfi.CommunityProviderLicense ADD CONSTRAINT FK_f092ff_LicenseStatusDescriptor FOREIGN KEY (LicenseStatusDescriptorId)
REFERENCES edfi.LicenseStatusDescriptor (LicenseStatusDescriptorId)
;

CREATE INDEX FK_f092ff_LicenseStatusDescriptor
ON edfi.CommunityProviderLicense (LicenseStatusDescriptorId ASC);

ALTER TABLE edfi.CommunityProviderLicense ADD CONSTRAINT FK_f092ff_LicenseTypeDescriptor FOREIGN KEY (LicenseTypeDescriptorId)
REFERENCES edfi.LicenseTypeDescriptor (LicenseTypeDescriptorId)
;

CREATE INDEX FK_f092ff_LicenseTypeDescriptor
ON edfi.CommunityProviderLicense (LicenseTypeDescriptorId ASC);

ALTER TABLE edfi.CompetencyLevelDescriptor ADD CONSTRAINT FK_b82261_Descriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CompetencyObjective ADD CONSTRAINT FK_5e9932_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_5e9932_EducationOrganization
ON edfi.CompetencyObjective (EducationOrganizationId ASC);

ALTER TABLE edfi.CompetencyObjective ADD CONSTRAINT FK_5e9932_GradeLevelDescriptor FOREIGN KEY (ObjectiveGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_5e9932_GradeLevelDescriptor
ON edfi.CompetencyObjective (ObjectiveGradeLevelDescriptorId ASC);

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

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_2096ce_AcademicSubjectDescriptor
ON edfi.Course (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CareerPathwayDescriptor FOREIGN KEY (CareerPathwayDescriptorId)
REFERENCES edfi.CareerPathwayDescriptor (CareerPathwayDescriptorId)
;

CREATE INDEX FK_2096ce_CareerPathwayDescriptor
ON edfi.Course (CareerPathwayDescriptorId ASC);

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CourseDefinedByDescriptor FOREIGN KEY (CourseDefinedByDescriptorId)
REFERENCES edfi.CourseDefinedByDescriptor (CourseDefinedByDescriptorId)
;

CREATE INDEX FK_2096ce_CourseDefinedByDescriptor
ON edfi.Course (CourseDefinedByDescriptorId ASC);

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CourseGPAApplicabilityDescriptor FOREIGN KEY (CourseGPAApplicabilityDescriptorId)
REFERENCES edfi.CourseGPAApplicabilityDescriptor (CourseGPAApplicabilityDescriptorId)
;

CREATE INDEX FK_2096ce_CourseGPAApplicabilityDescriptor
ON edfi.Course (CourseGPAApplicabilityDescriptorId ASC);

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CreditTypeDescriptor FOREIGN KEY (MinimumAvailableCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_2096ce_CreditTypeDescriptor
ON edfi.Course (MinimumAvailableCreditTypeDescriptorId ASC);

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_CreditTypeDescriptor1 FOREIGN KEY (MaximumAvailableCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_2096ce_CreditTypeDescriptor1
ON edfi.Course (MaximumAvailableCreditTypeDescriptorId ASC);

ALTER TABLE edfi.Course ADD CONSTRAINT FK_2096ce_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_2096ce_EducationOrganization
ON edfi.Course (EducationOrganizationId ASC);

ALTER TABLE edfi.CourseAttemptResultDescriptor ADD CONSTRAINT FK_306d96_Descriptor FOREIGN KEY (CourseAttemptResultDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseCompetencyLevel ADD CONSTRAINT FK_581f0f_CompetencyLevelDescriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.CompetencyLevelDescriptor (CompetencyLevelDescriptorId)
;

CREATE INDEX FK_581f0f_CompetencyLevelDescriptor
ON edfi.CourseCompetencyLevel (CompetencyLevelDescriptorId ASC);

ALTER TABLE edfi.CourseCompetencyLevel ADD CONSTRAINT FK_581f0f_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_581f0f_Course
ON edfi.CourseCompetencyLevel (CourseCode ASC, EducationOrganizationId ASC);

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

CREATE INDEX FK_18889f_Course
ON edfi.CourseIdentificationCode (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.CourseIdentificationCode ADD CONSTRAINT FK_18889f_CourseIdentificationSystemDescriptor FOREIGN KEY (CourseIdentificationSystemDescriptorId)
REFERENCES edfi.CourseIdentificationSystemDescriptor (CourseIdentificationSystemDescriptorId)
;

CREATE INDEX FK_18889f_CourseIdentificationSystemDescriptor
ON edfi.CourseIdentificationCode (CourseIdentificationSystemDescriptorId ASC);

ALTER TABLE edfi.CourseIdentificationSystemDescriptor ADD CONSTRAINT FK_e4ce6a_Descriptor FOREIGN KEY (CourseIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseLearningObjective ADD CONSTRAINT FK_c0da6b_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_c0da6b_Course
ON edfi.CourseLearningObjective (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.CourseLearningObjective ADD CONSTRAINT FK_c0da6b_LearningObjective FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
;

CREATE INDEX FK_c0da6b_LearningObjective
ON edfi.CourseLearningObjective (LearningObjectiveId ASC, Namespace ASC);

ALTER TABLE edfi.CourseLearningStandard ADD CONSTRAINT FK_644654_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_644654_Course
ON edfi.CourseLearningStandard (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.CourseLearningStandard ADD CONSTRAINT FK_644654_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_644654_LearningStandard
ON edfi.CourseLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.CourseLevelCharacteristic ADD CONSTRAINT FK_c7e725_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_c7e725_Course
ON edfi.CourseLevelCharacteristic (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.CourseLevelCharacteristic ADD CONSTRAINT FK_c7e725_CourseLevelCharacteristicDescriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.CourseLevelCharacteristicDescriptor (CourseLevelCharacteristicDescriptorId)
;

CREATE INDEX FK_c7e725_CourseLevelCharacteristicDescriptor
ON edfi.CourseLevelCharacteristic (CourseLevelCharacteristicDescriptorId ASC);

ALTER TABLE edfi.CourseLevelCharacteristicDescriptor ADD CONSTRAINT FK_000820_Descriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseOfferedGradeLevel ADD CONSTRAINT FK_175995_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_175995_Course
ON edfi.CourseOfferedGradeLevel (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.CourseOfferedGradeLevel ADD CONSTRAINT FK_175995_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_175995_GradeLevelDescriptor
ON edfi.CourseOfferedGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.CourseOffering ADD CONSTRAINT FK_0325c5_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_0325c5_Course
ON edfi.CourseOffering (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.CourseOffering ADD CONSTRAINT FK_0325c5_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_0325c5_School
ON edfi.CourseOffering (SchoolId ASC);

ALTER TABLE edfi.CourseOffering ADD CONSTRAINT FK_0325c5_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_0325c5_Session
ON edfi.CourseOffering (SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic ADD CONSTRAINT FK_210b6b_CourseLevelCharacteristicDescriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.CourseLevelCharacteristicDescriptor (CourseLevelCharacteristicDescriptorId)
;

CREATE INDEX FK_210b6b_CourseLevelCharacteristicDescriptor
ON edfi.CourseOfferingCourseLevelCharacteristic (CourseLevelCharacteristicDescriptorId ASC);

ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic ADD CONSTRAINT FK_210b6b_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_210b6b_CourseOffering
ON edfi.CourseOfferingCourseLevelCharacteristic (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.CourseOfferingCurriculumUsed ADD CONSTRAINT FK_31bbf7_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_31bbf7_CourseOffering
ON edfi.CourseOfferingCurriculumUsed (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.CourseOfferingCurriculumUsed ADD CONSTRAINT FK_31bbf7_CurriculumUsedDescriptor FOREIGN KEY (CurriculumUsedDescriptorId)
REFERENCES edfi.CurriculumUsedDescriptor (CurriculumUsedDescriptorId)
;

CREATE INDEX FK_31bbf7_CurriculumUsedDescriptor
ON edfi.CourseOfferingCurriculumUsed (CurriculumUsedDescriptorId ASC);

ALTER TABLE edfi.CourseOfferingOfferedGradeLevel ADD CONSTRAINT FK_aaa07e_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_aaa07e_CourseOffering
ON edfi.CourseOfferingOfferedGradeLevel (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.CourseOfferingOfferedGradeLevel ADD CONSTRAINT FK_aaa07e_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_aaa07e_GradeLevelDescriptor
ON edfi.CourseOfferingOfferedGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.CourseRepeatCodeDescriptor ADD CONSTRAINT FK_bc4d3c_Descriptor FOREIGN KEY (CourseRepeatCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_Course FOREIGN KEY (CourseCode, CourseEducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_6acf2b_Course
ON edfi.CourseTranscript (CourseCode ASC, CourseEducationOrganizationId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CourseAttemptResultDescriptor FOREIGN KEY (CourseAttemptResultDescriptorId)
REFERENCES edfi.CourseAttemptResultDescriptor (CourseAttemptResultDescriptorId)
;

CREATE INDEX FK_6acf2b_CourseAttemptResultDescriptor
ON edfi.CourseTranscript (CourseAttemptResultDescriptorId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CourseRepeatCodeDescriptor FOREIGN KEY (CourseRepeatCodeDescriptorId)
REFERENCES edfi.CourseRepeatCodeDescriptor (CourseRepeatCodeDescriptorId)
;

CREATE INDEX FK_6acf2b_CourseRepeatCodeDescriptor
ON edfi.CourseTranscript (CourseRepeatCodeDescriptorId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CreditTypeDescriptor FOREIGN KEY (AttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_6acf2b_CreditTypeDescriptor
ON edfi.CourseTranscript (AttemptedCreditTypeDescriptorId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_CreditTypeDescriptor1 FOREIGN KEY (EarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_6acf2b_CreditTypeDescriptor1
ON edfi.CourseTranscript (EarnedCreditTypeDescriptorId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_EducationOrganization FOREIGN KEY (ExternalEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_6acf2b_EducationOrganization
ON edfi.CourseTranscript (ExternalEducationOrganizationId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_GradeLevelDescriptor FOREIGN KEY (WhenTakenGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_6acf2b_GradeLevelDescriptor
ON edfi.CourseTranscript (WhenTakenGradeLevelDescriptorId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_MethodCreditEarnedDescriptor FOREIGN KEY (MethodCreditEarnedDescriptorId)
REFERENCES edfi.MethodCreditEarnedDescriptor (MethodCreditEarnedDescriptorId)
;

CREATE INDEX FK_6acf2b_MethodCreditEarnedDescriptor
ON edfi.CourseTranscript (MethodCreditEarnedDescriptorId ASC);

ALTER TABLE edfi.CourseTranscript ADD CONSTRAINT FK_6acf2b_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
;

CREATE INDEX FK_6acf2b_StudentAcademicRecord
ON edfi.CourseTranscript (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptAcademicSubject ADD CONSTRAINT FK_354642_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_354642_AcademicSubjectDescriptor
ON edfi.CourseTranscriptAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptAcademicSubject ADD CONSTRAINT FK_354642_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_354642_CourseTranscript
ON edfi.CourseTranscriptAcademicSubject (CourseAttemptResultDescriptorId ASC, CourseCode ASC, CourseEducationOrganizationId ASC, EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptAlternativeCourseIdentificationCode ADD CONSTRAINT FK_6621ee_CourseIdentificationSystemDescriptor FOREIGN KEY (CourseIdentificationSystemDescriptorId)
REFERENCES edfi.CourseIdentificationSystemDescriptor (CourseIdentificationSystemDescriptorId)
;

CREATE INDEX FK_6621ee_CourseIdentificationSystemDescriptor
ON edfi.CourseTranscriptAlternativeCourseIdentificationCode (CourseIdentificationSystemDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptAlternativeCourseIdentificationCode ADD CONSTRAINT FK_6621ee_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_6621ee_CourseTranscript
ON edfi.CourseTranscriptAlternativeCourseIdentificationCode (CourseAttemptResultDescriptorId ASC, CourseCode ASC, CourseEducationOrganizationId ASC, EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptCreditCategory ADD CONSTRAINT FK_ab7096_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_ab7096_CourseTranscript
ON edfi.CourseTranscriptCreditCategory (CourseAttemptResultDescriptorId ASC, CourseCode ASC, CourseEducationOrganizationId ASC, EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptCreditCategory ADD CONSTRAINT FK_ab7096_CreditCategoryDescriptor FOREIGN KEY (CreditCategoryDescriptorId)
REFERENCES edfi.CreditCategoryDescriptor (CreditCategoryDescriptorId)
;

CREATE INDEX FK_ab7096_CreditCategoryDescriptor
ON edfi.CourseTranscriptCreditCategory (CreditCategoryDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptEarnedAdditionalCredits ADD CONSTRAINT FK_b50e36_AdditionalCreditTypeDescriptor FOREIGN KEY (AdditionalCreditTypeDescriptorId)
REFERENCES edfi.AdditionalCreditTypeDescriptor (AdditionalCreditTypeDescriptorId)
;

CREATE INDEX FK_b50e36_AdditionalCreditTypeDescriptor
ON edfi.CourseTranscriptEarnedAdditionalCredits (AdditionalCreditTypeDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptEarnedAdditionalCredits ADD CONSTRAINT FK_b50e36_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_b50e36_CourseTranscript
ON edfi.CourseTranscriptEarnedAdditionalCredits (CourseAttemptResultDescriptorId ASC, CourseCode ASC, CourseEducationOrganizationId ASC, EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptPartialCourseTranscriptAwards ADD CONSTRAINT FK_e811ad_CourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.CourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_e811ad_CourseTranscript
ON edfi.CourseTranscriptPartialCourseTranscriptAwards (CourseAttemptResultDescriptorId ASC, CourseCode ASC, CourseEducationOrganizationId ASC, EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.CourseTranscriptPartialCourseTranscriptAwards ADD CONSTRAINT FK_e811ad_MethodCreditEarnedDescriptor FOREIGN KEY (MethodCreditEarnedDescriptorId)
REFERENCES edfi.MethodCreditEarnedDescriptor (MethodCreditEarnedDescriptorId)
;

CREATE INDEX FK_e811ad_MethodCreditEarnedDescriptor
ON edfi.CourseTranscriptPartialCourseTranscriptAwards (MethodCreditEarnedDescriptorId ASC);

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_CredentialFieldDescriptor FOREIGN KEY (CredentialFieldDescriptorId)
REFERENCES edfi.CredentialFieldDescriptor (CredentialFieldDescriptorId)
;

CREATE INDEX FK_b1c42b_CredentialFieldDescriptor
ON edfi.Credential (CredentialFieldDescriptorId ASC);

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_CredentialTypeDescriptor FOREIGN KEY (CredentialTypeDescriptorId)
REFERENCES edfi.CredentialTypeDescriptor (CredentialTypeDescriptorId)
;

CREATE INDEX FK_b1c42b_CredentialTypeDescriptor
ON edfi.Credential (CredentialTypeDescriptorId ASC);

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_StateAbbreviationDescriptor FOREIGN KEY (StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_b1c42b_StateAbbreviationDescriptor
ON edfi.Credential (StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_TeachingCredentialBasisDescriptor FOREIGN KEY (TeachingCredentialBasisDescriptorId)
REFERENCES edfi.TeachingCredentialBasisDescriptor (TeachingCredentialBasisDescriptorId)
;

CREATE INDEX FK_b1c42b_TeachingCredentialBasisDescriptor
ON edfi.Credential (TeachingCredentialBasisDescriptorId ASC);

ALTER TABLE edfi.Credential ADD CONSTRAINT FK_b1c42b_TeachingCredentialDescriptor FOREIGN KEY (TeachingCredentialDescriptorId)
REFERENCES edfi.TeachingCredentialDescriptor (TeachingCredentialDescriptorId)
;

CREATE INDEX FK_b1c42b_TeachingCredentialDescriptor
ON edfi.Credential (TeachingCredentialDescriptorId ASC);

ALTER TABLE edfi.CredentialAcademicSubject ADD CONSTRAINT FK_1141c9_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_1141c9_AcademicSubjectDescriptor
ON edfi.CredentialAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.CredentialAcademicSubject ADD CONSTRAINT FK_1141c9_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_1141c9_Credential
ON edfi.CredentialAcademicSubject (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.CredentialEndorsement ADD CONSTRAINT FK_57f7d2_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_57f7d2_Credential
ON edfi.CredentialEndorsement (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.CredentialFieldDescriptor ADD CONSTRAINT FK_4eab15_Descriptor FOREIGN KEY (CredentialFieldDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.CredentialGradeLevel ADD CONSTRAINT FK_f05a16_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_f05a16_Credential
ON edfi.CredentialGradeLevel (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.CredentialGradeLevel ADD CONSTRAINT FK_f05a16_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_f05a16_GradeLevelDescriptor
ON edfi.CredentialGradeLevel (GradeLevelDescriptorId ASC);

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

CREATE INDEX FK_7433b4_DescriptorMapping
ON edfi.DescriptorMappingModelEntity (MappedNamespace ASC, MappedValue ASC, Namespace ASC, Value ASC);

ALTER TABLE edfi.DescriptorMappingModelEntity ADD CONSTRAINT FK_7433b4_ModelEntityDescriptor FOREIGN KEY (ModelEntityDescriptorId)
REFERENCES edfi.ModelEntityDescriptor (ModelEntityDescriptorId)
;

CREATE INDEX FK_7433b4_ModelEntityDescriptor
ON edfi.DescriptorMappingModelEntity (ModelEntityDescriptorId ASC);

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

CREATE INDEX FK_eec7b6_DisciplineActionLengthDifferenceReasonDescriptor
ON edfi.DisciplineAction (DisciplineActionLengthDifferenceReasonDescriptorId ASC);

ALTER TABLE edfi.DisciplineAction ADD CONSTRAINT FK_eec7b6_School FOREIGN KEY (ResponsibilitySchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_eec7b6_School
ON edfi.DisciplineAction (ResponsibilitySchoolId ASC);

ALTER TABLE edfi.DisciplineAction ADD CONSTRAINT FK_eec7b6_School1 FOREIGN KEY (AssignmentSchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_eec7b6_School1
ON edfi.DisciplineAction (AssignmentSchoolId ASC);

ALTER TABLE edfi.DisciplineAction ADD CONSTRAINT FK_eec7b6_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_eec7b6_Student
ON edfi.DisciplineAction (StudentUSI ASC);

ALTER TABLE edfi.DisciplineActionDiscipline ADD CONSTRAINT FK_73601f_DisciplineAction FOREIGN KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
REFERENCES edfi.DisciplineAction (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_73601f_DisciplineAction
ON edfi.DisciplineActionDiscipline (DisciplineActionIdentifier ASC, DisciplineDate ASC, StudentUSI ASC);

ALTER TABLE edfi.DisciplineActionDiscipline ADD CONSTRAINT FK_73601f_DisciplineDescriptor FOREIGN KEY (DisciplineDescriptorId)
REFERENCES edfi.DisciplineDescriptor (DisciplineDescriptorId)
;

CREATE INDEX FK_73601f_DisciplineDescriptor
ON edfi.DisciplineActionDiscipline (DisciplineDescriptorId ASC);

ALTER TABLE edfi.DisciplineActionLengthDifferenceReasonDescriptor ADD CONSTRAINT FK_e1a229_Descriptor FOREIGN KEY (DisciplineActionLengthDifferenceReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineActionStaff ADD CONSTRAINT FK_30e866_DisciplineAction FOREIGN KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
REFERENCES edfi.DisciplineAction (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_30e866_DisciplineAction
ON edfi.DisciplineActionStaff (DisciplineActionIdentifier ASC, DisciplineDate ASC, StudentUSI ASC);

ALTER TABLE edfi.DisciplineActionStaff ADD CONSTRAINT FK_30e866_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_30e866_Staff
ON edfi.DisciplineActionStaff (StaffUSI ASC);

ALTER TABLE edfi.DisciplineActionStudentDisciplineIncidentAssociation ADD CONSTRAINT FK_ef0ece_DisciplineAction FOREIGN KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
REFERENCES edfi.DisciplineAction (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_ef0ece_DisciplineAction
ON edfi.DisciplineActionStudentDisciplineIncidentAssociation (DisciplineActionIdentifier ASC, DisciplineDate ASC, StudentUSI ASC);

ALTER TABLE edfi.DisciplineActionStudentDisciplineIncidentAssociation ADD CONSTRAINT FK_ef0ece_StudentDisciplineIncidentAssociation FOREIGN KEY (IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentAssociation (IncidentIdentifier, SchoolId, StudentUSI)
;

CREATE INDEX FK_ef0ece_StudentDisciplineIncidentAssociation
ON edfi.DisciplineActionStudentDisciplineIncidentAssociation (IncidentIdentifier ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_2c4cdb_DisciplineAction FOREIGN KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
REFERENCES edfi.DisciplineAction (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_2c4cdb_DisciplineAction
ON edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation (DisciplineActionIdentifier ASC, DisciplineDate ASC, StudentUSI ASC);

ALTER TABLE edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_2c4cdb_StudentDisciplineIncidentBehaviorAssociation FOREIGN KEY (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentBehaviorAssociation (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
;

CREATE INDEX FK_2c4cdb_StudentDisciplineIncidentBehaviorAssociation
ON edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation (BehaviorDescriptorId ASC, IncidentIdentifier ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.DisciplineDescriptor ADD CONSTRAINT FK_673b0a_Descriptor FOREIGN KEY (DisciplineDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineIncident ADD CONSTRAINT FK_e45c0b_IncidentLocationDescriptor FOREIGN KEY (IncidentLocationDescriptorId)
REFERENCES edfi.IncidentLocationDescriptor (IncidentLocationDescriptorId)
;

CREATE INDEX FK_e45c0b_IncidentLocationDescriptor
ON edfi.DisciplineIncident (IncidentLocationDescriptorId ASC);

ALTER TABLE edfi.DisciplineIncident ADD CONSTRAINT FK_e45c0b_ReporterDescriptionDescriptor FOREIGN KEY (ReporterDescriptionDescriptorId)
REFERENCES edfi.ReporterDescriptionDescriptor (ReporterDescriptionDescriptorId)
;

CREATE INDEX FK_e45c0b_ReporterDescriptionDescriptor
ON edfi.DisciplineIncident (ReporterDescriptionDescriptorId ASC);

ALTER TABLE edfi.DisciplineIncident ADD CONSTRAINT FK_e45c0b_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_e45c0b_School
ON edfi.DisciplineIncident (SchoolId ASC);

ALTER TABLE edfi.DisciplineIncident ADD CONSTRAINT FK_e45c0b_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_e45c0b_Staff
ON edfi.DisciplineIncident (StaffUSI ASC);

ALTER TABLE edfi.DisciplineIncidentBehavior ADD CONSTRAINT FK_cabdcb_BehaviorDescriptor FOREIGN KEY (BehaviorDescriptorId)
REFERENCES edfi.BehaviorDescriptor (BehaviorDescriptorId)
;

CREATE INDEX FK_cabdcb_BehaviorDescriptor
ON edfi.DisciplineIncidentBehavior (BehaviorDescriptorId ASC);

ALTER TABLE edfi.DisciplineIncidentBehavior ADD CONSTRAINT FK_cabdcb_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_cabdcb_DisciplineIncident
ON edfi.DisciplineIncidentBehavior (IncidentIdentifier ASC, SchoolId ASC);

ALTER TABLE edfi.DisciplineIncidentExternalParticipant ADD CONSTRAINT FK_0d16f7_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_0d16f7_DisciplineIncident
ON edfi.DisciplineIncidentExternalParticipant (IncidentIdentifier ASC, SchoolId ASC);

ALTER TABLE edfi.DisciplineIncidentExternalParticipant ADD CONSTRAINT FK_0d16f7_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

CREATE INDEX FK_0d16f7_DisciplineIncidentParticipationCodeDescriptor
ON edfi.DisciplineIncidentExternalParticipant (DisciplineIncidentParticipationCodeDescriptorId ASC);

ALTER TABLE edfi.DisciplineIncidentParticipationCodeDescriptor ADD CONSTRAINT FK_923786_Descriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.DisciplineIncidentWeapon ADD CONSTRAINT FK_a545e5_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_a545e5_DisciplineIncident
ON edfi.DisciplineIncidentWeapon (IncidentIdentifier ASC, SchoolId ASC);

ALTER TABLE edfi.DisciplineIncidentWeapon ADD CONSTRAINT FK_a545e5_WeaponDescriptor FOREIGN KEY (WeaponDescriptorId)
REFERENCES edfi.WeaponDescriptor (WeaponDescriptorId)
;

CREATE INDEX FK_a545e5_WeaponDescriptor
ON edfi.DisciplineIncidentWeapon (WeaponDescriptorId ASC);

ALTER TABLE edfi.EducationalEnvironmentDescriptor ADD CONSTRAINT FK_0f941f_Descriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_ContentClassDescriptor FOREIGN KEY (ContentClassDescriptorId)
REFERENCES edfi.ContentClassDescriptor (ContentClassDescriptorId)
;

CREATE INDEX FK_9965a5_ContentClassDescriptor
ON edfi.EducationContent (ContentClassDescriptorId ASC);

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_CostRateDescriptor FOREIGN KEY (CostRateDescriptorId)
REFERENCES edfi.CostRateDescriptor (CostRateDescriptorId)
;

CREATE INDEX FK_9965a5_CostRateDescriptor
ON edfi.EducationContent (CostRateDescriptorId ASC);

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_InteractivityStyleDescriptor FOREIGN KEY (InteractivityStyleDescriptorId)
REFERENCES edfi.InteractivityStyleDescriptor (InteractivityStyleDescriptorId)
;

CREATE INDEX FK_9965a5_InteractivityStyleDescriptor
ON edfi.EducationContent (InteractivityStyleDescriptorId ASC);

ALTER TABLE edfi.EducationContent ADD CONSTRAINT FK_9965a5_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_9965a5_LearningStandard
ON edfi.EducationContent (LearningStandardId ASC);

ALTER TABLE edfi.EducationContentAppropriateGradeLevel ADD CONSTRAINT FK_0a2145_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_0a2145_EducationContent
ON edfi.EducationContentAppropriateGradeLevel (ContentIdentifier ASC);

ALTER TABLE edfi.EducationContentAppropriateGradeLevel ADD CONSTRAINT FK_0a2145_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_0a2145_GradeLevelDescriptor
ON edfi.EducationContentAppropriateGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.EducationContentAppropriateSex ADD CONSTRAINT FK_9b6ed1_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_9b6ed1_EducationContent
ON edfi.EducationContentAppropriateSex (ContentIdentifier ASC);

ALTER TABLE edfi.EducationContentAppropriateSex ADD CONSTRAINT FK_9b6ed1_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_9b6ed1_SexDescriptor
ON edfi.EducationContentAppropriateSex (SexDescriptorId ASC);

ALTER TABLE edfi.EducationContentAuthor ADD CONSTRAINT FK_f605af_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_f605af_EducationContent
ON edfi.EducationContentAuthor (ContentIdentifier ASC);

ALTER TABLE edfi.EducationContentDerivativeSourceEducationContent ADD CONSTRAINT FK_98cd8a_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_98cd8a_EducationContent
ON edfi.EducationContentDerivativeSourceEducationContent (ContentIdentifier ASC);

ALTER TABLE edfi.EducationContentDerivativeSourceEducationContent ADD CONSTRAINT FK_98cd8a_EducationContent1 FOREIGN KEY (DerivativeSourceContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

CREATE INDEX FK_98cd8a_EducationContent1
ON edfi.EducationContentDerivativeSourceEducationContent (DerivativeSourceContentIdentifier ASC);

ALTER TABLE edfi.EducationContentDerivativeSourceLearningResourceMetadataURI ADD CONSTRAINT FK_421bfa_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_421bfa_EducationContent
ON edfi.EducationContentDerivativeSourceLearningResourceMetadataURI (ContentIdentifier ASC);

ALTER TABLE edfi.EducationContentDerivativeSourceURI ADD CONSTRAINT FK_047c7a_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_047c7a_EducationContent
ON edfi.EducationContentDerivativeSourceURI (ContentIdentifier ASC);

ALTER TABLE edfi.EducationContentLanguage ADD CONSTRAINT FK_d678fa_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_d678fa_EducationContent
ON edfi.EducationContentLanguage (ContentIdentifier ASC);

ALTER TABLE edfi.EducationContentLanguage ADD CONSTRAINT FK_d678fa_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_d678fa_LanguageDescriptor
ON edfi.EducationContentLanguage (LanguageDescriptorId ASC);

ALTER TABLE edfi.EducationOrganization ADD CONSTRAINT FK_4525e6_OperationalStatusDescriptor FOREIGN KEY (OperationalStatusDescriptorId)
REFERENCES edfi.OperationalStatusDescriptor (OperationalStatusDescriptorId)
;

CREATE INDEX FK_4525e6_OperationalStatusDescriptor
ON edfi.EducationOrganization (OperationalStatusDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_4925da_AddressTypeDescriptor
ON edfi.EducationOrganizationAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_4925da_EducationOrganization
ON edfi.EducationOrganizationAddress (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_4925da_LocaleDescriptor
ON edfi.EducationOrganizationAddress (LocaleDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationAddress ADD CONSTRAINT FK_4925da_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_4925da_StateAbbreviationDescriptor
ON edfi.EducationOrganizationAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationAddressPeriod ADD CONSTRAINT FK_d44be7_EducationOrganizationAddress FOREIGN KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.EducationOrganizationAddress (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_d44be7_EducationOrganizationAddress
ON edfi.EducationOrganizationAddressPeriod (AddressTypeDescriptorId ASC, City ASC, EducationOrganizationId ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE edfi.EducationOrganizationAssociationTypeDescriptor ADD CONSTRAINT FK_d9f485_Descriptor FOREIGN KEY (EducationOrganizationAssociationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationCategory ADD CONSTRAINT FK_427110_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_427110_EducationOrganization
ON edfi.EducationOrganizationCategory (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationCategory ADD CONSTRAINT FK_427110_EducationOrganizationCategoryDescriptor FOREIGN KEY (EducationOrganizationCategoryDescriptorId)
REFERENCES edfi.EducationOrganizationCategoryDescriptor (EducationOrganizationCategoryDescriptorId)
;

CREATE INDEX FK_427110_EducationOrganizationCategoryDescriptor
ON edfi.EducationOrganizationCategory (EducationOrganizationCategoryDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationCategoryDescriptor ADD CONSTRAINT FK_7791ef_Descriptor FOREIGN KEY (EducationOrganizationCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationIdentificationCode ADD CONSTRAINT FK_4a715c_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_4a715c_EducationOrganization
ON edfi.EducationOrganizationIdentificationCode (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationIdentificationCode ADD CONSTRAINT FK_4a715c_EducationOrganizationIdentificationSystemDescriptor FOREIGN KEY (EducationOrganizationIdentificationSystemDescriptorId)
REFERENCES edfi.EducationOrganizationIdentificationSystemDescriptor (EducationOrganizationIdentificationSystemDescriptorId)
;

CREATE INDEX FK_4a715c_EducationOrganizationIdentificationSystemDescriptor
ON edfi.EducationOrganizationIdentificationCode (EducationOrganizationIdentificationSystemDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationIdentificationSystemDescriptor ADD CONSTRAINT FK_cbfd5d_Descriptor FOREIGN KEY (EducationOrganizationIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_dde098_EducationOrganization
ON edfi.EducationOrganizationIndicator (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_IndicatorDescriptor FOREIGN KEY (IndicatorDescriptorId)
REFERENCES edfi.IndicatorDescriptor (IndicatorDescriptorId)
;

CREATE INDEX FK_dde098_IndicatorDescriptor
ON edfi.EducationOrganizationIndicator (IndicatorDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_IndicatorGroupDescriptor FOREIGN KEY (IndicatorGroupDescriptorId)
REFERENCES edfi.IndicatorGroupDescriptor (IndicatorGroupDescriptorId)
;

CREATE INDEX FK_dde098_IndicatorGroupDescriptor
ON edfi.EducationOrganizationIndicator (IndicatorGroupDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationIndicator ADD CONSTRAINT FK_dde098_IndicatorLevelDescriptor FOREIGN KEY (IndicatorLevelDescriptorId)
REFERENCES edfi.IndicatorLevelDescriptor (IndicatorLevelDescriptorId)
;

CREATE INDEX FK_dde098_IndicatorLevelDescriptor
ON edfi.EducationOrganizationIndicator (IndicatorLevelDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationIndicatorPeriod ADD CONSTRAINT FK_8486ae_EducationOrganizationIndicator FOREIGN KEY (EducationOrganizationId, IndicatorDescriptorId)
REFERENCES edfi.EducationOrganizationIndicator (EducationOrganizationId, IndicatorDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_8486ae_EducationOrganizationIndicator
ON edfi.EducationOrganizationIndicatorPeriod (EducationOrganizationId ASC, IndicatorDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationInstitutionTelephone ADD CONSTRAINT FK_79895a_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_79895a_EducationOrganization
ON edfi.EducationOrganizationInstitutionTelephone (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationInstitutionTelephone ADD CONSTRAINT FK_79895a_InstitutionTelephoneNumberTypeDescriptor FOREIGN KEY (InstitutionTelephoneNumberTypeDescriptorId)
REFERENCES edfi.InstitutionTelephoneNumberTypeDescriptor (InstitutionTelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_79895a_InstitutionTelephoneNumberTypeDescriptor
ON edfi.EducationOrganizationInstitutionTelephone (InstitutionTelephoneNumberTypeDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationInternationalAddress ADD CONSTRAINT FK_0ee746_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_0ee746_AddressTypeDescriptor
ON edfi.EducationOrganizationInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationInternationalAddress ADD CONSTRAINT FK_0ee746_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_0ee746_CountryDescriptor
ON edfi.EducationOrganizationInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationInternationalAddress ADD CONSTRAINT FK_0ee746_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_0ee746_EducationOrganization
ON edfi.EducationOrganizationInternationalAddress (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD CONSTRAINT FK_e670ae_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_e670ae_EducationOrganization
ON edfi.EducationOrganizationInterventionPrescriptionAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD CONSTRAINT FK_e670ae_InterventionPrescription FOREIGN KEY (InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
;

CREATE INDEX FK_e670ae_InterventionPrescription
ON edfi.EducationOrganizationInterventionPrescriptionAssociation (InterventionPrescriptionEducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.EducationOrganizationNetwork ADD CONSTRAINT FK_e88dea_EducationOrganization FOREIGN KEY (EducationOrganizationNetworkId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.EducationOrganizationNetwork ADD CONSTRAINT FK_e88dea_NetworkPurposeDescriptor FOREIGN KEY (NetworkPurposeDescriptorId)
REFERENCES edfi.NetworkPurposeDescriptor (NetworkPurposeDescriptorId)
;

CREATE INDEX FK_e88dea_NetworkPurposeDescriptor
ON edfi.EducationOrganizationNetwork (NetworkPurposeDescriptorId ASC);

ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD CONSTRAINT FK_252151_EducationOrganization FOREIGN KEY (MemberEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_252151_EducationOrganization
ON edfi.EducationOrganizationNetworkAssociation (MemberEducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD CONSTRAINT FK_252151_EducationOrganizationNetwork FOREIGN KEY (EducationOrganizationNetworkId)
REFERENCES edfi.EducationOrganizationNetwork (EducationOrganizationNetworkId)
;

CREATE INDEX FK_252151_EducationOrganizationNetwork
ON edfi.EducationOrganizationNetworkAssociation (EducationOrganizationNetworkId ASC);

ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD CONSTRAINT FK_74e4e5_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_74e4e5_EducationOrganization
ON edfi.EducationOrganizationPeerAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD CONSTRAINT FK_74e4e5_EducationOrganization1 FOREIGN KEY (PeerEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_74e4e5_EducationOrganization1
ON edfi.EducationOrganizationPeerAssociation (PeerEducationOrganizationId ASC);

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

CREATE INDEX FK_43bbe1_StateEducationAgency
ON edfi.EducationServiceCenter (StateEducationAgencyId ASC);

ALTER TABLE edfi.ElectronicMailTypeDescriptor ADD CONSTRAINT FK_15fde6_Descriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
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

CREATE INDEX FK_11f7b6_School
ON edfi.FeederSchoolAssociation (FeederSchoolId ASC);

ALTER TABLE edfi.FeederSchoolAssociation ADD CONSTRAINT FK_11f7b6_School1 FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_11f7b6_School1
ON edfi.FeederSchoolAssociation (SchoolId ASC);

ALTER TABLE edfi.FinancialCollectionDescriptor ADD CONSTRAINT FK_6dc716_Descriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.FunctionDimensionReportingTag ADD CONSTRAINT FK_8d455d_FunctionDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.FunctionDimension (Code, FiscalYear)
ON DELETE CASCADE
;

CREATE INDEX FK_8d455d_FunctionDimension
ON edfi.FunctionDimensionReportingTag (Code ASC, FiscalYear ASC);

ALTER TABLE edfi.FunctionDimensionReportingTag ADD CONSTRAINT FK_8d455d_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_8d455d_ReportingTagDescriptor
ON edfi.FunctionDimensionReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.FundDimensionReportingTag ADD CONSTRAINT FK_7062bd_FundDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.FundDimension (Code, FiscalYear)
ON DELETE CASCADE
;

CREATE INDEX FK_7062bd_FundDimension
ON edfi.FundDimensionReportingTag (Code ASC, FiscalYear ASC);

ALTER TABLE edfi.FundDimensionReportingTag ADD CONSTRAINT FK_7062bd_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_7062bd_ReportingTagDescriptor
ON edfi.FundDimensionReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_0516f9_EducationOrganization
ON edfi.GeneralStudentProgramAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_0516f9_Program
ON edfi.GeneralStudentProgramAssociation (ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_ReasonExitedDescriptor FOREIGN KEY (ReasonExitedDescriptorId)
REFERENCES edfi.ReasonExitedDescriptor (ReasonExitedDescriptorId)
;

CREATE INDEX FK_0516f9_ReasonExitedDescriptor
ON edfi.GeneralStudentProgramAssociation (ReasonExitedDescriptorId ASC);

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD CONSTRAINT FK_0516f9_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_0516f9_Student
ON edfi.GeneralStudentProgramAssociation (StudentUSI ASC);

ALTER TABLE edfi.GeneralStudentProgramAssociationParticipationStatus ADD CONSTRAINT FK_b3fd05_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.GeneralStudentProgramAssociationParticipationStatus ADD CONSTRAINT FK_b3fd05_ParticipationStatusDescriptor FOREIGN KEY (ParticipationStatusDescriptorId)
REFERENCES edfi.ParticipationStatusDescriptor (ParticipationStatusDescriptorId)
;

CREATE INDEX FK_b3fd05_ParticipationStatusDescriptor
ON edfi.GeneralStudentProgramAssociationParticipationStatus (ParticipationStatusDescriptorId ASC);

ALTER TABLE edfi.GeneralStudentProgramAssociationProgramParticipationStatus ADD CONSTRAINT FK_0855d2_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_0855d2_GeneralStudentProgramAssociation
ON edfi.GeneralStudentProgramAssociationProgramParticipationStatus (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.GeneralStudentProgramAssociationProgramParticipationStatus ADD CONSTRAINT FK_0855d2_ParticipationStatusDescriptor FOREIGN KEY (ParticipationStatusDescriptorId)
REFERENCES edfi.ParticipationStatusDescriptor (ParticipationStatusDescriptorId)
;

CREATE INDEX FK_0855d2_ParticipationStatusDescriptor
ON edfi.GeneralStudentProgramAssociationProgramParticipationStatus (ParticipationStatusDescriptorId ASC);

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_GradeTypeDescriptor FOREIGN KEY (GradeTypeDescriptorId)
REFERENCES edfi.GradeTypeDescriptor (GradeTypeDescriptorId)
;

CREATE INDEX FK_839e20_GradeTypeDescriptor
ON edfi.Grade (GradeTypeDescriptorId ASC);

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, SchoolId, GradingPeriodSchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

CREATE INDEX FK_839e20_GradingPeriod
ON edfi.Grade (GradingPeriodDescriptorId ASC, GradingPeriodSequence ASC, SchoolId ASC, GradingPeriodSchoolYear ASC);

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_PerformanceBaseConversionDescriptor FOREIGN KEY (PerformanceBaseConversionDescriptorId)
REFERENCES edfi.PerformanceBaseConversionDescriptor (PerformanceBaseConversionDescriptorId)
;

CREATE INDEX FK_839e20_PerformanceBaseConversionDescriptor
ON edfi.Grade (PerformanceBaseConversionDescriptorId ASC);

ALTER TABLE edfi.Grade ADD CONSTRAINT FK_839e20_StudentSectionAssociation FOREIGN KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAssociation (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON UPDATE CASCADE
;

CREATE INDEX FK_839e20_StudentSectionAssociation
ON edfi.Grade (BeginDate ASC, LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC, StudentUSI ASC);

ALTER TABLE edfi.GradebookEntry ADD CONSTRAINT FK_466cfa_GradebookEntryTypeDescriptor FOREIGN KEY (GradebookEntryTypeDescriptorId)
REFERENCES edfi.GradebookEntryTypeDescriptor (GradebookEntryTypeDescriptorId)
;

CREATE INDEX FK_466cfa_GradebookEntryTypeDescriptor
ON edfi.GradebookEntry (GradebookEntryTypeDescriptorId ASC);

ALTER TABLE edfi.GradebookEntry ADD CONSTRAINT FK_466cfa_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

CREATE INDEX FK_466cfa_GradingPeriod
ON edfi.GradebookEntry (GradingPeriodDescriptorId ASC, PeriodSequence ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.GradebookEntry ADD CONSTRAINT FK_466cfa_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_466cfa_Section
ON edfi.GradebookEntry (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.GradebookEntryLearningStandard ADD CONSTRAINT FK_c7b5a8_GradebookEntry FOREIGN KEY (GradebookEntryIdentifier, Namespace)
REFERENCES edfi.GradebookEntry (GradebookEntryIdentifier, Namespace)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_c7b5a8_GradebookEntry
ON edfi.GradebookEntryLearningStandard (GradebookEntryIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.GradebookEntryLearningStandard ADD CONSTRAINT FK_c7b5a8_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_c7b5a8_LearningStandard
ON edfi.GradebookEntryLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.GradebookEntryTypeDescriptor ADD CONSTRAINT FK_45eb00_Descriptor FOREIGN KEY (GradebookEntryTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GradeLearningStandardGrade ADD CONSTRAINT FK_92f7f8_Grade FOREIGN KEY (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSchoolYear, GradingPeriodSequence, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.Grade (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSchoolYear, GradingPeriodSequence, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_92f7f8_Grade
ON edfi.GradeLearningStandardGrade (BeginDate ASC, GradeTypeDescriptorId ASC, GradingPeriodDescriptorId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC, StudentUSI ASC);

ALTER TABLE edfi.GradeLearningStandardGrade ADD CONSTRAINT FK_92f7f8_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_92f7f8_LearningStandard
ON edfi.GradeLearningStandardGrade (LearningStandardId ASC);

ALTER TABLE edfi.GradeLearningStandardGrade ADD CONSTRAINT FK_92f7f8_PerformanceBaseConversionDescriptor FOREIGN KEY (PerformanceBaseConversionDescriptorId)
REFERENCES edfi.PerformanceBaseConversionDescriptor (PerformanceBaseConversionDescriptorId)
;

CREATE INDEX FK_92f7f8_PerformanceBaseConversionDescriptor
ON edfi.GradeLearningStandardGrade (PerformanceBaseConversionDescriptorId ASC);

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

CREATE INDEX FK_5a18f9_GradingPeriodDescriptor
ON edfi.GradingPeriod (GradingPeriodDescriptorId ASC);

ALTER TABLE edfi.GradingPeriod ADD CONSTRAINT FK_5a18f9_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_5a18f9_School
ON edfi.GradingPeriod (SchoolId ASC);

ALTER TABLE edfi.GradingPeriod ADD CONSTRAINT FK_5a18f9_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_5a18f9_SchoolYearType
ON edfi.GradingPeriod (SchoolYear ASC);

ALTER TABLE edfi.GradingPeriodDescriptor ADD CONSTRAINT FK_1f0f64_Descriptor FOREIGN KEY (GradingPeriodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_CreditTypeDescriptor FOREIGN KEY (TotalRequiredCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_be1ea4_CreditTypeDescriptor
ON edfi.GraduationPlan (TotalRequiredCreditTypeDescriptorId ASC);

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_be1ea4_EducationOrganization
ON edfi.GraduationPlan (EducationOrganizationId ASC);

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_GraduationPlanTypeDescriptor FOREIGN KEY (GraduationPlanTypeDescriptorId)
REFERENCES edfi.GraduationPlanTypeDescriptor (GraduationPlanTypeDescriptorId)
;

CREATE INDEX FK_be1ea4_GraduationPlanTypeDescriptor
ON edfi.GraduationPlan (GraduationPlanTypeDescriptorId ASC);

ALTER TABLE edfi.GraduationPlan ADD CONSTRAINT FK_be1ea4_SchoolYearType FOREIGN KEY (GraduationSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_be1ea4_SchoolYearType
ON edfi.GraduationPlan (GraduationSchoolYear ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCourse ADD CONSTRAINT FK_44e78d_CreditTypeDescriptor FOREIGN KEY (CreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_44e78d_CreditTypeDescriptor
ON edfi.GraduationPlanCreditsByCourse (CreditTypeDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCourse ADD CONSTRAINT FK_44e78d_GradeLevelDescriptor FOREIGN KEY (WhenTakenGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_44e78d_GradeLevelDescriptor
ON edfi.GraduationPlanCreditsByCourse (WhenTakenGradeLevelDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCourse ADD CONSTRAINT FK_44e78d_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_44e78d_GraduationPlan
ON edfi.GraduationPlanCreditsByCourse (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCourseCourse ADD CONSTRAINT FK_dafcc7_Course FOREIGN KEY (CourseCode, CourseEducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_dafcc7_Course
ON edfi.GraduationPlanCreditsByCourseCourse (CourseCode ASC, CourseEducationOrganizationId ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCourseCourse ADD CONSTRAINT FK_dafcc7_GraduationPlanCreditsByCourse FOREIGN KEY (CourseSetName, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlanCreditsByCourse (CourseSetName, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_dafcc7_GraduationPlanCreditsByCourse
ON edfi.GraduationPlanCreditsByCourseCourse (CourseSetName ASC, EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCreditCategory ADD CONSTRAINT FK_ddfc9b_CreditCategoryDescriptor FOREIGN KEY (CreditCategoryDescriptorId)
REFERENCES edfi.CreditCategoryDescriptor (CreditCategoryDescriptorId)
;

CREATE INDEX FK_ddfc9b_CreditCategoryDescriptor
ON edfi.GraduationPlanCreditsByCreditCategory (CreditCategoryDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCreditCategory ADD CONSTRAINT FK_ddfc9b_CreditTypeDescriptor FOREIGN KEY (CreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_ddfc9b_CreditTypeDescriptor
ON edfi.GraduationPlanCreditsByCreditCategory (CreditTypeDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanCreditsByCreditCategory ADD CONSTRAINT FK_ddfc9b_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_ddfc9b_GraduationPlan
ON edfi.GraduationPlanCreditsByCreditCategory (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE edfi.GraduationPlanCreditsBySubject ADD CONSTRAINT FK_3b5b30_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_3b5b30_AcademicSubjectDescriptor
ON edfi.GraduationPlanCreditsBySubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanCreditsBySubject ADD CONSTRAINT FK_3b5b30_CreditTypeDescriptor FOREIGN KEY (CreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_3b5b30_CreditTypeDescriptor
ON edfi.GraduationPlanCreditsBySubject (CreditTypeDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanCreditsBySubject ADD CONSTRAINT FK_3b5b30_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_3b5b30_GraduationPlan
ON edfi.GraduationPlanCreditsBySubject (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessment ADD CONSTRAINT FK_1a4369_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

CREATE INDEX FK_1a4369_Assessment
ON edfi.GraduationPlanRequiredAssessment (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessment ADD CONSTRAINT FK_1a4369_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_1a4369_GraduationPlan
ON edfi.GraduationPlanRequiredAssessment (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_876ba3_AssessmentReportingMethodDescriptor
ON edfi.GraduationPlanRequiredAssessmentPerformanceLevel (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_GraduationPlanRequiredAssessment FOREIGN KEY (AssessmentIdentifier, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, Namespace)
REFERENCES edfi.GraduationPlanRequiredAssessment (AssessmentIdentifier, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

CREATE INDEX FK_876ba3_PerformanceLevelDescriptor
ON edfi.GraduationPlanRequiredAssessmentPerformanceLevel (PerformanceLevelDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ADD CONSTRAINT FK_876ba3_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_876ba3_ResultDatatypeTypeDescriptor
ON edfi.GraduationPlanRequiredAssessmentPerformanceLevel (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessmentScore ADD CONSTRAINT FK_db9e7c_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_db9e7c_AssessmentReportingMethodDescriptor
ON edfi.GraduationPlanRequiredAssessmentScore (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessmentScore ADD CONSTRAINT FK_db9e7c_GraduationPlanRequiredAssessment FOREIGN KEY (AssessmentIdentifier, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, Namespace)
REFERENCES edfi.GraduationPlanRequiredAssessment (AssessmentIdentifier, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_db9e7c_GraduationPlanRequiredAssessment
ON edfi.GraduationPlanRequiredAssessmentScore (AssessmentIdentifier ASC, EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, Namespace ASC);

ALTER TABLE edfi.GraduationPlanRequiredAssessmentScore ADD CONSTRAINT FK_db9e7c_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_db9e7c_ResultDatatypeTypeDescriptor
ON edfi.GraduationPlanRequiredAssessmentScore (ResultDatatypeTypeDescriptorId ASC);

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

CREATE INDEX FK_0fae05_DeliveryMethodDescriptor
ON edfi.Intervention (DeliveryMethodDescriptorId ASC);

ALTER TABLE edfi.Intervention ADD CONSTRAINT FK_0fae05_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_0fae05_EducationOrganization
ON edfi.Intervention (EducationOrganizationId ASC);

ALTER TABLE edfi.Intervention ADD CONSTRAINT FK_0fae05_InterventionClassDescriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.InterventionClassDescriptor (InterventionClassDescriptorId)
;

CREATE INDEX FK_0fae05_InterventionClassDescriptor
ON edfi.Intervention (InterventionClassDescriptorId ASC);

ALTER TABLE edfi.InterventionAppropriateGradeLevel ADD CONSTRAINT FK_3d5433_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_3d5433_GradeLevelDescriptor
ON edfi.InterventionAppropriateGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.InterventionAppropriateGradeLevel ADD CONSTRAINT FK_3d5433_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_3d5433_Intervention
ON edfi.InterventionAppropriateGradeLevel (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionAppropriateSex ADD CONSTRAINT FK_a8bc47_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_a8bc47_Intervention
ON edfi.InterventionAppropriateSex (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionAppropriateSex ADD CONSTRAINT FK_a8bc47_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_a8bc47_SexDescriptor
ON edfi.InterventionAppropriateSex (SexDescriptorId ASC);

ALTER TABLE edfi.InterventionClassDescriptor ADD CONSTRAINT FK_183bc5_Descriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionDiagnosis ADD CONSTRAINT FK_b2e25d_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

CREATE INDEX FK_b2e25d_DiagnosisDescriptor
ON edfi.InterventionDiagnosis (DiagnosisDescriptorId ASC);

ALTER TABLE edfi.InterventionDiagnosis ADD CONSTRAINT FK_b2e25d_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_b2e25d_Intervention
ON edfi.InterventionDiagnosis (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionEducationContent ADD CONSTRAINT FK_3c823d_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

CREATE INDEX FK_3c823d_EducationContent
ON edfi.InterventionEducationContent (ContentIdentifier ASC);

ALTER TABLE edfi.InterventionEducationContent ADD CONSTRAINT FK_3c823d_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_3c823d_Intervention
ON edfi.InterventionEducationContent (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionEffectivenessRatingDescriptor ADD CONSTRAINT FK_c0c58a_Descriptor FOREIGN KEY (InterventionEffectivenessRatingDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.InterventionInterventionPrescription ADD CONSTRAINT FK_e79fe2_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_e79fe2_Intervention
ON edfi.InterventionInterventionPrescription (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionInterventionPrescription ADD CONSTRAINT FK_e79fe2_InterventionPrescription FOREIGN KEY (InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
;

CREATE INDEX FK_e79fe2_InterventionPrescription
ON edfi.InterventionInterventionPrescription (InterventionPrescriptionEducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionLearningResourceMetadataURI ADD CONSTRAINT FK_c7db20_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_c7db20_Intervention
ON edfi.InterventionLearningResourceMetadataURI (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionMeetingTime ADD CONSTRAINT FK_a64540_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_a64540_Intervention
ON edfi.InterventionMeetingTime (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPopulationServed ADD CONSTRAINT FK_cbeb99_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_cbeb99_Intervention
ON edfi.InterventionPopulationServed (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPopulationServed ADD CONSTRAINT FK_cbeb99_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_cbeb99_PopulationServedDescriptor
ON edfi.InterventionPopulationServed (PopulationServedDescriptorId ASC);

ALTER TABLE edfi.InterventionPrescription ADD CONSTRAINT FK_e93bc3_DeliveryMethodDescriptor FOREIGN KEY (DeliveryMethodDescriptorId)
REFERENCES edfi.DeliveryMethodDescriptor (DeliveryMethodDescriptorId)
;

CREATE INDEX FK_e93bc3_DeliveryMethodDescriptor
ON edfi.InterventionPrescription (DeliveryMethodDescriptorId ASC);

ALTER TABLE edfi.InterventionPrescription ADD CONSTRAINT FK_e93bc3_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_e93bc3_EducationOrganization
ON edfi.InterventionPrescription (EducationOrganizationId ASC);

ALTER TABLE edfi.InterventionPrescription ADD CONSTRAINT FK_e93bc3_InterventionClassDescriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.InterventionClassDescriptor (InterventionClassDescriptorId)
;

CREATE INDEX FK_e93bc3_InterventionClassDescriptor
ON edfi.InterventionPrescription (InterventionClassDescriptorId ASC);

ALTER TABLE edfi.InterventionPrescriptionAppropriateGradeLevel ADD CONSTRAINT FK_4736c7_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_4736c7_GradeLevelDescriptor
ON edfi.InterventionPrescriptionAppropriateGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.InterventionPrescriptionAppropriateGradeLevel ADD CONSTRAINT FK_4736c7_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_4736c7_InterventionPrescription
ON edfi.InterventionPrescriptionAppropriateGradeLevel (EducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPrescriptionAppropriateSex ADD CONSTRAINT FK_4a3f1c_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_4a3f1c_InterventionPrescription
ON edfi.InterventionPrescriptionAppropriateSex (EducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPrescriptionAppropriateSex ADD CONSTRAINT FK_4a3f1c_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_4a3f1c_SexDescriptor
ON edfi.InterventionPrescriptionAppropriateSex (SexDescriptorId ASC);

ALTER TABLE edfi.InterventionPrescriptionDiagnosis ADD CONSTRAINT FK_9e6edd_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

CREATE INDEX FK_9e6edd_DiagnosisDescriptor
ON edfi.InterventionPrescriptionDiagnosis (DiagnosisDescriptorId ASC);

ALTER TABLE edfi.InterventionPrescriptionDiagnosis ADD CONSTRAINT FK_9e6edd_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_9e6edd_InterventionPrescription
ON edfi.InterventionPrescriptionDiagnosis (EducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPrescriptionEducationContent ADD CONSTRAINT FK_3ab5d4_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

CREATE INDEX FK_3ab5d4_EducationContent
ON edfi.InterventionPrescriptionEducationContent (ContentIdentifier ASC);

ALTER TABLE edfi.InterventionPrescriptionEducationContent ADD CONSTRAINT FK_3ab5d4_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_3ab5d4_InterventionPrescription
ON edfi.InterventionPrescriptionEducationContent (EducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPrescriptionLearningResourceMetadataURI ADD CONSTRAINT FK_e12298_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_e12298_InterventionPrescription
ON edfi.InterventionPrescriptionLearningResourceMetadataURI (EducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPrescriptionPopulationServed ADD CONSTRAINT FK_a984df_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_a984df_InterventionPrescription
ON edfi.InterventionPrescriptionPopulationServed (EducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionPrescriptionPopulationServed ADD CONSTRAINT FK_a984df_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_a984df_PopulationServedDescriptor
ON edfi.InterventionPrescriptionPopulationServed (PopulationServedDescriptorId ASC);

ALTER TABLE edfi.InterventionPrescriptionURI ADD CONSTRAINT FK_4acf8e_InterventionPrescription FOREIGN KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_4acf8e_InterventionPrescription
ON edfi.InterventionPrescriptionURI (EducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionStaff ADD CONSTRAINT FK_6fa51c_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_6fa51c_Intervention
ON edfi.InterventionStaff (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.InterventionStaff ADD CONSTRAINT FK_6fa51c_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_6fa51c_Staff
ON edfi.InterventionStaff (StaffUSI ASC);

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_DeliveryMethodDescriptor FOREIGN KEY (DeliveryMethodDescriptorId)
REFERENCES edfi.DeliveryMethodDescriptor (DeliveryMethodDescriptorId)
;

CREATE INDEX FK_d92986_DeliveryMethodDescriptor
ON edfi.InterventionStudy (DeliveryMethodDescriptorId ASC);

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_d92986_EducationOrganization
ON edfi.InterventionStudy (EducationOrganizationId ASC);

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_InterventionClassDescriptor FOREIGN KEY (InterventionClassDescriptorId)
REFERENCES edfi.InterventionClassDescriptor (InterventionClassDescriptorId)
;

CREATE INDEX FK_d92986_InterventionClassDescriptor
ON edfi.InterventionStudy (InterventionClassDescriptorId ASC);

ALTER TABLE edfi.InterventionStudy ADD CONSTRAINT FK_d92986_InterventionPrescription FOREIGN KEY (InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
REFERENCES edfi.InterventionPrescription (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
;

CREATE INDEX FK_d92986_InterventionPrescription
ON edfi.InterventionStudy (InterventionPrescriptionEducationOrganizationId ASC, InterventionPrescriptionIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyAppropriateGradeLevel ADD CONSTRAINT FK_87d32b_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_87d32b_GradeLevelDescriptor
ON edfi.InterventionStudyAppropriateGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyAppropriateGradeLevel ADD CONSTRAINT FK_87d32b_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_87d32b_InterventionStudy
ON edfi.InterventionStudyAppropriateGradeLevel (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyAppropriateSex ADD CONSTRAINT FK_d53ee9_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_d53ee9_InterventionStudy
ON edfi.InterventionStudyAppropriateSex (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyAppropriateSex ADD CONSTRAINT FK_d53ee9_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_d53ee9_SexDescriptor
ON edfi.InterventionStudyAppropriateSex (SexDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyEducationContent ADD CONSTRAINT FK_014e05_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

CREATE INDEX FK_014e05_EducationContent
ON edfi.InterventionStudyEducationContent (ContentIdentifier ASC);

ALTER TABLE edfi.InterventionStudyEducationContent ADD CONSTRAINT FK_014e05_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_014e05_InterventionStudy
ON edfi.InterventionStudyEducationContent (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

CREATE INDEX FK_ef90b6_DiagnosisDescriptor
ON edfi.InterventionStudyInterventionEffectiveness (DiagnosisDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_ef90b6_GradeLevelDescriptor
ON edfi.InterventionStudyInterventionEffectiveness (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_InterventionEffectivenessRatingDescriptor FOREIGN KEY (InterventionEffectivenessRatingDescriptorId)
REFERENCES edfi.InterventionEffectivenessRatingDescriptor (InterventionEffectivenessRatingDescriptorId)
;

CREATE INDEX FK_ef90b6_InterventionEffectivenessRatingDescriptor
ON edfi.InterventionStudyInterventionEffectiveness (InterventionEffectivenessRatingDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_ef90b6_InterventionStudy
ON edfi.InterventionStudyInterventionEffectiveness (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ADD CONSTRAINT FK_ef90b6_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_ef90b6_PopulationServedDescriptor
ON edfi.InterventionStudyInterventionEffectiveness (PopulationServedDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyLearningResourceMetadataURI ADD CONSTRAINT FK_1dcb14_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_1dcb14_InterventionStudy
ON edfi.InterventionStudyLearningResourceMetadataURI (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyPopulationServed ADD CONSTRAINT FK_c45364_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_c45364_InterventionStudy
ON edfi.InterventionStudyPopulationServed (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyPopulationServed ADD CONSTRAINT FK_c45364_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_c45364_PopulationServedDescriptor
ON edfi.InterventionStudyPopulationServed (PopulationServedDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyStateAbbreviation ADD CONSTRAINT FK_8e9d64_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_8e9d64_InterventionStudy
ON edfi.InterventionStudyStateAbbreviation (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionStudyStateAbbreviation ADD CONSTRAINT FK_8e9d64_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_8e9d64_StateAbbreviationDescriptor
ON edfi.InterventionStudyStateAbbreviation (StateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.InterventionStudyURI ADD CONSTRAINT FK_9046e7_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_9046e7_InterventionStudy
ON edfi.InterventionStudyURI (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE edfi.InterventionURI ADD CONSTRAINT FK_35afab_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
ON DELETE CASCADE
;

CREATE INDEX FK_35afab_Intervention
ON edfi.InterventionURI (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

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

ALTER TABLE edfi.LearningObjective ADD CONSTRAINT FK_588d15_LearningObjective FOREIGN KEY (ParentLearningObjectiveId, ParentNamespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
;

CREATE INDEX FK_588d15_LearningObjective
ON edfi.LearningObjective (ParentLearningObjectiveId ASC, ParentNamespace ASC);

ALTER TABLE edfi.LearningObjectiveAcademicSubject ADD CONSTRAINT FK_23fa0f_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_23fa0f_AcademicSubjectDescriptor
ON edfi.LearningObjectiveAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.LearningObjectiveAcademicSubject ADD CONSTRAINT FK_23fa0f_LearningObjective FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_23fa0f_LearningObjective
ON edfi.LearningObjectiveAcademicSubject (LearningObjectiveId ASC, Namespace ASC);

ALTER TABLE edfi.LearningObjectiveContentStandard ADD CONSTRAINT FK_f99184_EducationOrganization FOREIGN KEY (MandatingEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_f99184_EducationOrganization
ON edfi.LearningObjectiveContentStandard (MandatingEducationOrganizationId ASC);

ALTER TABLE edfi.LearningObjectiveContentStandard ADD CONSTRAINT FK_f99184_LearningObjective FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningObjectiveContentStandard ADD CONSTRAINT FK_f99184_PublicationStatusDescriptor FOREIGN KEY (PublicationStatusDescriptorId)
REFERENCES edfi.PublicationStatusDescriptor (PublicationStatusDescriptorId)
;

CREATE INDEX FK_f99184_PublicationStatusDescriptor
ON edfi.LearningObjectiveContentStandard (PublicationStatusDescriptorId ASC);

ALTER TABLE edfi.LearningObjectiveContentStandardAuthor ADD CONSTRAINT FK_a165fa_LearningObjectiveContentStandard FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjectiveContentStandard (LearningObjectiveId, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_a165fa_LearningObjectiveContentStandard
ON edfi.LearningObjectiveContentStandardAuthor (LearningObjectiveId ASC, Namespace ASC);

ALTER TABLE edfi.LearningObjectiveGradeLevel ADD CONSTRAINT FK_a92ef0_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_a92ef0_GradeLevelDescriptor
ON edfi.LearningObjectiveGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.LearningObjectiveGradeLevel ADD CONSTRAINT FK_a92ef0_LearningObjective FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_a92ef0_LearningObjective
ON edfi.LearningObjectiveGradeLevel (LearningObjectiveId ASC, Namespace ASC);

ALTER TABLE edfi.LearningObjectiveLearningStandard ADD CONSTRAINT FK_c99b99_LearningObjective FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_c99b99_LearningObjective
ON edfi.LearningObjectiveLearningStandard (LearningObjectiveId ASC, Namespace ASC);

ALTER TABLE edfi.LearningObjectiveLearningStandard ADD CONSTRAINT FK_c99b99_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_c99b99_LearningStandard
ON edfi.LearningObjectiveLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.LearningStandard ADD CONSTRAINT FK_8ceb4c_LearningStandard FOREIGN KEY (ParentLearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_8ceb4c_LearningStandard
ON edfi.LearningStandard (ParentLearningStandardId ASC);

ALTER TABLE edfi.LearningStandard ADD CONSTRAINT FK_8ceb4c_LearningStandardCategoryDescriptor FOREIGN KEY (LearningStandardCategoryDescriptorId)
REFERENCES edfi.LearningStandardCategoryDescriptor (LearningStandardCategoryDescriptorId)
;

CREATE INDEX FK_8ceb4c_LearningStandardCategoryDescriptor
ON edfi.LearningStandard (LearningStandardCategoryDescriptorId ASC);

ALTER TABLE edfi.LearningStandard ADD CONSTRAINT FK_8ceb4c_LearningStandardScopeDescriptor FOREIGN KEY (LearningStandardScopeDescriptorId)
REFERENCES edfi.LearningStandardScopeDescriptor (LearningStandardScopeDescriptorId)
;

CREATE INDEX FK_8ceb4c_LearningStandardScopeDescriptor
ON edfi.LearningStandard (LearningStandardScopeDescriptorId ASC);

ALTER TABLE edfi.LearningStandardAcademicSubject ADD CONSTRAINT FK_aaade9_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_aaade9_AcademicSubjectDescriptor
ON edfi.LearningStandardAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.LearningStandardAcademicSubject ADD CONSTRAINT FK_aaade9_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

CREATE INDEX FK_aaade9_LearningStandard
ON edfi.LearningStandardAcademicSubject (LearningStandardId ASC);

ALTER TABLE edfi.LearningStandardCategoryDescriptor ADD CONSTRAINT FK_814fc1_Descriptor FOREIGN KEY (LearningStandardCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardContentStandard ADD CONSTRAINT FK_70f675_EducationOrganization FOREIGN KEY (MandatingEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_70f675_EducationOrganization
ON edfi.LearningStandardContentStandard (MandatingEducationOrganizationId ASC);

ALTER TABLE edfi.LearningStandardContentStandard ADD CONSTRAINT FK_70f675_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardContentStandard ADD CONSTRAINT FK_70f675_PublicationStatusDescriptor FOREIGN KEY (PublicationStatusDescriptorId)
REFERENCES edfi.PublicationStatusDescriptor (PublicationStatusDescriptorId)
;

CREATE INDEX FK_70f675_PublicationStatusDescriptor
ON edfi.LearningStandardContentStandard (PublicationStatusDescriptorId ASC);

ALTER TABLE edfi.LearningStandardContentStandardAuthor ADD CONSTRAINT FK_4c9e40_LearningStandardContentStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandardContentStandard (LearningStandardId)
ON DELETE CASCADE
;

CREATE INDEX FK_4c9e40_LearningStandardContentStandard
ON edfi.LearningStandardContentStandardAuthor (LearningStandardId ASC);

ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD CONSTRAINT FK_17c02a_LearningStandard FOREIGN KEY (SourceLearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_17c02a_LearningStandard
ON edfi.LearningStandardEquivalenceAssociation (SourceLearningStandardId ASC);

ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD CONSTRAINT FK_17c02a_LearningStandard1 FOREIGN KEY (TargetLearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_17c02a_LearningStandard1
ON edfi.LearningStandardEquivalenceAssociation (TargetLearningStandardId ASC);

ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD CONSTRAINT FK_17c02a_LearningStandardEquivalenceStrengthDescriptor FOREIGN KEY (LearningStandardEquivalenceStrengthDescriptorId)
REFERENCES edfi.LearningStandardEquivalenceStrengthDescriptor (LearningStandardEquivalenceStrengthDescriptorId)
;

CREATE INDEX FK_17c02a_LearningStandardEquivalenceStrengthDescriptor
ON edfi.LearningStandardEquivalenceAssociation (LearningStandardEquivalenceStrengthDescriptorId ASC);

ALTER TABLE edfi.LearningStandardEquivalenceStrengthDescriptor ADD CONSTRAINT FK_166f6a_Descriptor FOREIGN KEY (LearningStandardEquivalenceStrengthDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LearningStandardGradeLevel ADD CONSTRAINT FK_38677c_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_38677c_GradeLevelDescriptor
ON edfi.LearningStandardGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.LearningStandardGradeLevel ADD CONSTRAINT FK_38677c_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

CREATE INDEX FK_38677c_LearningStandard
ON edfi.LearningStandardGradeLevel (LearningStandardId ASC);

ALTER TABLE edfi.LearningStandardIdentificationCode ADD CONSTRAINT FK_92327a_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

CREATE INDEX FK_92327a_LearningStandard
ON edfi.LearningStandardIdentificationCode (LearningStandardId ASC);

ALTER TABLE edfi.LearningStandardPrerequisiteLearningStandard ADD CONSTRAINT FK_81b800_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
ON DELETE CASCADE
;

CREATE INDEX FK_81b800_LearningStandard
ON edfi.LearningStandardPrerequisiteLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.LearningStandardPrerequisiteLearningStandard ADD CONSTRAINT FK_81b800_LearningStandard1 FOREIGN KEY (PrerequisiteLearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_81b800_LearningStandard1
ON edfi.LearningStandardPrerequisiteLearningStandard (PrerequisiteLearningStandardId ASC);

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

CREATE INDEX FK_32eddb_ChartOfAccount
ON edfi.LocalAccount (ChartOfAccountIdentifier ASC, ChartOfAccountEducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.LocalAccount ADD CONSTRAINT FK_32eddb_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_32eddb_EducationOrganization
ON edfi.LocalAccount (EducationOrganizationId ASC);

ALTER TABLE edfi.LocalAccountReportingTag ADD CONSTRAINT FK_c38935_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
ON DELETE CASCADE
;

CREATE INDEX FK_c38935_LocalAccount
ON edfi.LocalAccountReportingTag (AccountIdentifier ASC, EducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.LocalAccountReportingTag ADD CONSTRAINT FK_c38935_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_c38935_ReportingTagDescriptor
ON edfi.LocalAccountReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.LocalActual ADD CONSTRAINT FK_b6310e_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

CREATE INDEX FK_b6310e_FinancialCollectionDescriptor
ON edfi.LocalActual (FinancialCollectionDescriptorId ASC);

ALTER TABLE edfi.LocalActual ADD CONSTRAINT FK_b6310e_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

CREATE INDEX FK_b6310e_LocalAccount
ON edfi.LocalActual (AccountIdentifier ASC, EducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.LocalBudget ADD CONSTRAINT FK_000683_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

CREATE INDEX FK_000683_FinancialCollectionDescriptor
ON edfi.LocalBudget (FinancialCollectionDescriptorId ASC);

ALTER TABLE edfi.LocalBudget ADD CONSTRAINT FK_000683_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

CREATE INDEX FK_000683_LocalAccount
ON edfi.LocalBudget (AccountIdentifier ASC, EducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.LocalContractedStaff ADD CONSTRAINT FK_4d9b4a_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

CREATE INDEX FK_4d9b4a_FinancialCollectionDescriptor
ON edfi.LocalContractedStaff (FinancialCollectionDescriptorId ASC);

ALTER TABLE edfi.LocalContractedStaff ADD CONSTRAINT FK_4d9b4a_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

CREATE INDEX FK_4d9b4a_LocalAccount
ON edfi.LocalContractedStaff (AccountIdentifier ASC, EducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.LocalContractedStaff ADD CONSTRAINT FK_4d9b4a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_4d9b4a_Staff
ON edfi.LocalContractedStaff (StaffUSI ASC);

ALTER TABLE edfi.LocaleDescriptor ADD CONSTRAINT FK_be5f41_Descriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_CharterStatusDescriptor FOREIGN KEY (CharterStatusDescriptorId)
REFERENCES edfi.CharterStatusDescriptor (CharterStatusDescriptorId)
;

CREATE INDEX FK_25c08c_CharterStatusDescriptor
ON edfi.LocalEducationAgency (CharterStatusDescriptorId ASC);

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_EducationOrganization FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_EducationServiceCenter FOREIGN KEY (EducationServiceCenterId)
REFERENCES edfi.EducationServiceCenter (EducationServiceCenterId)
;

CREATE INDEX FK_25c08c_EducationServiceCenter
ON edfi.LocalEducationAgency (EducationServiceCenterId ASC);

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_LocalEducationAgency FOREIGN KEY (ParentLocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
;

CREATE INDEX FK_25c08c_LocalEducationAgency
ON edfi.LocalEducationAgency (ParentLocalEducationAgencyId ASC);

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_LocalEducationAgencyCategoryDescriptor FOREIGN KEY (LocalEducationAgencyCategoryDescriptorId)
REFERENCES edfi.LocalEducationAgencyCategoryDescriptor (LocalEducationAgencyCategoryDescriptorId)
;

CREATE INDEX FK_25c08c_LocalEducationAgencyCategoryDescriptor
ON edfi.LocalEducationAgency (LocalEducationAgencyCategoryDescriptorId ASC);

ALTER TABLE edfi.LocalEducationAgency ADD CONSTRAINT FK_25c08c_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
;

CREATE INDEX FK_25c08c_StateEducationAgency
ON edfi.LocalEducationAgency (StateEducationAgencyId ASC);

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_GunFreeSchoolsActReportingStatusDescriptor FOREIGN KEY (GunFreeSchoolsActReportingStatusDescriptorId)
REFERENCES edfi.GunFreeSchoolsActReportingStatusDescriptor (GunFreeSchoolsActReportingStatusDescriptorId)
;

CREATE INDEX FK_1ba71e_GunFreeSchoolsActReportingStatusDescriptor
ON edfi.LocalEducationAgencyAccountability (GunFreeSchoolsActReportingStatusDescriptorId ASC);

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
ON DELETE CASCADE
;

CREATE INDEX FK_1ba71e_LocalEducationAgency
ON edfi.LocalEducationAgencyAccountability (LocalEducationAgencyId ASC);

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_SchoolChoiceImplementStatusDescriptor FOREIGN KEY (SchoolChoiceImplementStatusDescriptorId)
REFERENCES edfi.SchoolChoiceImplementStatusDescriptor (SchoolChoiceImplementStatusDescriptorId)
;

CREATE INDEX FK_1ba71e_SchoolChoiceImplementStatusDescriptor
ON edfi.LocalEducationAgencyAccountability (SchoolChoiceImplementStatusDescriptorId ASC);

ALTER TABLE edfi.LocalEducationAgencyAccountability ADD CONSTRAINT FK_1ba71e_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_1ba71e_SchoolYearType
ON edfi.LocalEducationAgencyAccountability (SchoolYear ASC);

ALTER TABLE edfi.LocalEducationAgencyCategoryDescriptor ADD CONSTRAINT FK_8db9a2_Descriptor FOREIGN KEY (LocalEducationAgencyCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.LocalEducationAgencyFederalFunds ADD CONSTRAINT FK_5a8c0e_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
ON DELETE CASCADE
;

CREATE INDEX FK_5a8c0e_LocalEducationAgency
ON edfi.LocalEducationAgencyFederalFunds (LocalEducationAgencyId ASC);

ALTER TABLE edfi.LocalEncumbrance ADD CONSTRAINT FK_ea526f_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

CREATE INDEX FK_ea526f_FinancialCollectionDescriptor
ON edfi.LocalEncumbrance (FinancialCollectionDescriptorId ASC);

ALTER TABLE edfi.LocalEncumbrance ADD CONSTRAINT FK_ea526f_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

CREATE INDEX FK_ea526f_LocalAccount
ON edfi.LocalEncumbrance (AccountIdentifier ASC, EducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.LocalPayroll ADD CONSTRAINT FK_46e5c2_FinancialCollectionDescriptor FOREIGN KEY (FinancialCollectionDescriptorId)
REFERENCES edfi.FinancialCollectionDescriptor (FinancialCollectionDescriptorId)
;

CREATE INDEX FK_46e5c2_FinancialCollectionDescriptor
ON edfi.LocalPayroll (FinancialCollectionDescriptorId ASC);

ALTER TABLE edfi.LocalPayroll ADD CONSTRAINT FK_46e5c2_LocalAccount FOREIGN KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
REFERENCES edfi.LocalAccount (AccountIdentifier, EducationOrganizationId, FiscalYear)
;

CREATE INDEX FK_46e5c2_LocalAccount
ON edfi.LocalPayroll (AccountIdentifier ASC, EducationOrganizationId ASC, FiscalYear ASC);

ALTER TABLE edfi.LocalPayroll ADD CONSTRAINT FK_46e5c2_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_46e5c2_Staff
ON edfi.LocalPayroll (StaffUSI ASC);

ALTER TABLE edfi.Location ADD CONSTRAINT FK_15b619_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_15b619_School
ON edfi.Location (SchoolId ASC);

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

CREATE INDEX FK_fda3b7_ObjectDimension
ON edfi.ObjectDimensionReportingTag (Code ASC, FiscalYear ASC);

ALTER TABLE edfi.ObjectDimensionReportingTag ADD CONSTRAINT FK_fda3b7_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_fda3b7_ReportingTagDescriptor
ON edfi.ObjectDimensionReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.ObjectiveAssessment ADD CONSTRAINT FK_269e10_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_269e10_AcademicSubjectDescriptor
ON edfi.ObjectiveAssessment (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.ObjectiveAssessment ADD CONSTRAINT FK_269e10_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

CREATE INDEX FK_269e10_Assessment
ON edfi.ObjectiveAssessment (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.ObjectiveAssessment ADD CONSTRAINT FK_269e10_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, ParentIdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
;

CREATE INDEX FK_269e10_ObjectiveAssessment
ON edfi.ObjectiveAssessment (AssessmentIdentifier ASC, ParentIdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.ObjectiveAssessmentAssessmentItem ADD CONSTRAINT FK_d98560_AssessmentItem FOREIGN KEY (AssessmentIdentifier, AssessmentItemIdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
;

CREATE INDEX FK_d98560_AssessmentItem
ON edfi.ObjectiveAssessmentAssessmentItem (AssessmentIdentifier ASC, AssessmentItemIdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.ObjectiveAssessmentAssessmentItem ADD CONSTRAINT FK_d98560_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_d98560_ObjectiveAssessment
ON edfi.ObjectiveAssessmentAssessmentItem (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.ObjectiveAssessmentLearningStandard ADD CONSTRAINT FK_1ee70e_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_1ee70e_LearningStandard
ON edfi.ObjectiveAssessmentLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.ObjectiveAssessmentLearningStandard ADD CONSTRAINT FK_1ee70e_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_1ee70e_ObjectiveAssessment
ON edfi.ObjectiveAssessmentLearningStandard (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_1b7007_AssessmentReportingMethodDescriptor
ON edfi.ObjectiveAssessmentPerformanceLevel (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_1b7007_ObjectiveAssessment
ON edfi.ObjectiveAssessmentPerformanceLevel (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

CREATE INDEX FK_1b7007_PerformanceLevelDescriptor
ON edfi.ObjectiveAssessmentPerformanceLevel (PerformanceLevelDescriptorId ASC);

ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_1b7007_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_1b7007_ResultDatatypeTypeDescriptor
ON edfi.ObjectiveAssessmentPerformanceLevel (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE edfi.ObjectiveAssessmentScore ADD CONSTRAINT FK_2c91e8_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_2c91e8_AssessmentReportingMethodDescriptor
ON edfi.ObjectiveAssessmentScore (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.ObjectiveAssessmentScore ADD CONSTRAINT FK_2c91e8_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_2c91e8_ObjectiveAssessment
ON edfi.ObjectiveAssessmentScore (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.ObjectiveAssessmentScore ADD CONSTRAINT FK_2c91e8_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_2c91e8_ResultDatatypeTypeDescriptor
ON edfi.ObjectiveAssessmentScore (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE edfi.OldEthnicityDescriptor ADD CONSTRAINT FK_821652_Descriptor FOREIGN KEY (OldEthnicityDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_3cc1d4_EducationOrganization
ON edfi.OpenStaffPosition (EducationOrganizationId ASC);

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_EmploymentStatusDescriptor FOREIGN KEY (EmploymentStatusDescriptorId)
REFERENCES edfi.EmploymentStatusDescriptor (EmploymentStatusDescriptorId)
;

CREATE INDEX FK_3cc1d4_EmploymentStatusDescriptor
ON edfi.OpenStaffPosition (EmploymentStatusDescriptorId ASC);

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_PostingResultDescriptor FOREIGN KEY (PostingResultDescriptorId)
REFERENCES edfi.PostingResultDescriptor (PostingResultDescriptorId)
;

CREATE INDEX FK_3cc1d4_PostingResultDescriptor
ON edfi.OpenStaffPosition (PostingResultDescriptorId ASC);

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_ProgramAssignmentDescriptor FOREIGN KEY (ProgramAssignmentDescriptorId)
REFERENCES edfi.ProgramAssignmentDescriptor (ProgramAssignmentDescriptorId)
;

CREATE INDEX FK_3cc1d4_ProgramAssignmentDescriptor
ON edfi.OpenStaffPosition (ProgramAssignmentDescriptorId ASC);

ALTER TABLE edfi.OpenStaffPosition ADD CONSTRAINT FK_3cc1d4_StaffClassificationDescriptor FOREIGN KEY (StaffClassificationDescriptorId)
REFERENCES edfi.StaffClassificationDescriptor (StaffClassificationDescriptorId)
;

CREATE INDEX FK_3cc1d4_StaffClassificationDescriptor
ON edfi.OpenStaffPosition (StaffClassificationDescriptorId ASC);

ALTER TABLE edfi.OpenStaffPositionAcademicSubject ADD CONSTRAINT FK_285d36_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_285d36_AcademicSubjectDescriptor
ON edfi.OpenStaffPositionAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.OpenStaffPositionAcademicSubject ADD CONSTRAINT FK_285d36_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
ON DELETE CASCADE
;

CREATE INDEX FK_285d36_OpenStaffPosition
ON edfi.OpenStaffPositionAcademicSubject (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE edfi.OpenStaffPositionInstructionalGradeLevel ADD CONSTRAINT FK_e19c72_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_e19c72_GradeLevelDescriptor
ON edfi.OpenStaffPositionInstructionalGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.OpenStaffPositionInstructionalGradeLevel ADD CONSTRAINT FK_e19c72_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
ON DELETE CASCADE
;

CREATE INDEX FK_e19c72_OpenStaffPosition
ON edfi.OpenStaffPositionInstructionalGradeLevel (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE edfi.OperationalStatusDescriptor ADD CONSTRAINT FK_ce3682_Descriptor FOREIGN KEY (OperationalStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.OperationalUnitDimensionReportingTag ADD CONSTRAINT FK_3b06c7_OperationalUnitDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.OperationalUnitDimension (Code, FiscalYear)
ON DELETE CASCADE
;

CREATE INDEX FK_3b06c7_OperationalUnitDimension
ON edfi.OperationalUnitDimensionReportingTag (Code ASC, FiscalYear ASC);

ALTER TABLE edfi.OperationalUnitDimensionReportingTag ADD CONSTRAINT FK_3b06c7_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_3b06c7_ReportingTagDescriptor
ON edfi.OperationalUnitDimensionReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.OrganizationDepartment ADD CONSTRAINT FK_13b924_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_13b924_AcademicSubjectDescriptor
ON edfi.OrganizationDepartment (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.OrganizationDepartment ADD CONSTRAINT FK_13b924_EducationOrganization FOREIGN KEY (OrganizationDepartmentId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.OrganizationDepartment ADD CONSTRAINT FK_13b924_EducationOrganization1 FOREIGN KEY (ParentEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_13b924_EducationOrganization1
ON edfi.OrganizationDepartment (ParentEducationOrganizationId ASC);

ALTER TABLE edfi.OtherNameTypeDescriptor ADD CONSTRAINT FK_f020d2_Descriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Parent ADD CONSTRAINT FK_5f7953_LevelOfEducationDescriptor FOREIGN KEY (HighestCompletedLevelOfEducationDescriptorId)
REFERENCES edfi.LevelOfEducationDescriptor (LevelOfEducationDescriptorId)
;

CREATE INDEX FK_5f7953_LevelOfEducationDescriptor
ON edfi.Parent (HighestCompletedLevelOfEducationDescriptorId ASC);

ALTER TABLE edfi.Parent ADD CONSTRAINT FK_5f7953_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_5f7953_Person
ON edfi.Parent (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE edfi.Parent ADD CONSTRAINT FK_5f7953_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_5f7953_SexDescriptor
ON edfi.Parent (SexDescriptorId ASC);

ALTER TABLE edfi.ParentAddress ADD CONSTRAINT FK_cc3333_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_cc3333_AddressTypeDescriptor
ON edfi.ParentAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.ParentAddress ADD CONSTRAINT FK_cc3333_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_cc3333_LocaleDescriptor
ON edfi.ParentAddress (LocaleDescriptorId ASC);

ALTER TABLE edfi.ParentAddress ADD CONSTRAINT FK_cc3333_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_cc3333_Parent
ON edfi.ParentAddress (ParentUSI ASC);

ALTER TABLE edfi.ParentAddress ADD CONSTRAINT FK_cc3333_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_cc3333_StateAbbreviationDescriptor
ON edfi.ParentAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.ParentAddressPeriod ADD CONSTRAINT FK_123e27_ParentAddress FOREIGN KEY (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.ParentAddress (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_123e27_ParentAddress
ON edfi.ParentAddressPeriod (AddressTypeDescriptorId ASC, City ASC, ParentUSI ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE edfi.ParentElectronicMail ADD CONSTRAINT FK_85798e_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_85798e_ElectronicMailTypeDescriptor
ON edfi.ParentElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE edfi.ParentElectronicMail ADD CONSTRAINT FK_85798e_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_85798e_Parent
ON edfi.ParentElectronicMail (ParentUSI ASC);

ALTER TABLE edfi.ParentInternationalAddress ADD CONSTRAINT FK_8d650e_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_8d650e_AddressTypeDescriptor
ON edfi.ParentInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.ParentInternationalAddress ADD CONSTRAINT FK_8d650e_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_8d650e_CountryDescriptor
ON edfi.ParentInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE edfi.ParentInternationalAddress ADD CONSTRAINT FK_8d650e_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_8d650e_Parent
ON edfi.ParentInternationalAddress (ParentUSI ASC);

ALTER TABLE edfi.ParentLanguage ADD CONSTRAINT FK_34f9df_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_34f9df_LanguageDescriptor
ON edfi.ParentLanguage (LanguageDescriptorId ASC);

ALTER TABLE edfi.ParentLanguage ADD CONSTRAINT FK_34f9df_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_34f9df_Parent
ON edfi.ParentLanguage (ParentUSI ASC);

ALTER TABLE edfi.ParentLanguageUse ADD CONSTRAINT FK_f67c61_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_f67c61_LanguageUseDescriptor
ON edfi.ParentLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE edfi.ParentLanguageUse ADD CONSTRAINT FK_f67c61_ParentLanguage FOREIGN KEY (LanguageDescriptorId, ParentUSI)
REFERENCES edfi.ParentLanguage (LanguageDescriptorId, ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_f67c61_ParentLanguage
ON edfi.ParentLanguageUse (LanguageDescriptorId ASC, ParentUSI ASC);

ALTER TABLE edfi.ParentOtherName ADD CONSTRAINT FK_0e0a11_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

CREATE INDEX FK_0e0a11_OtherNameTypeDescriptor
ON edfi.ParentOtherName (OtherNameTypeDescriptorId ASC);

ALTER TABLE edfi.ParentOtherName ADD CONSTRAINT FK_0e0a11_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_0e0a11_Parent
ON edfi.ParentOtherName (ParentUSI ASC);

ALTER TABLE edfi.ParentPersonalIdentificationDocument ADD CONSTRAINT FK_b772b6_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_b772b6_CountryDescriptor
ON edfi.ParentPersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE edfi.ParentPersonalIdentificationDocument ADD CONSTRAINT FK_b772b6_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_b772b6_IdentificationDocumentUseDescriptor
ON edfi.ParentPersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE edfi.ParentPersonalIdentificationDocument ADD CONSTRAINT FK_b772b6_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b772b6_Parent
ON edfi.ParentPersonalIdentificationDocument (ParentUSI ASC);

ALTER TABLE edfi.ParentPersonalIdentificationDocument ADD CONSTRAINT FK_b772b6_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_b772b6_PersonalInformationVerificationDescriptor
ON edfi.ParentPersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE edfi.ParentTelephone ADD CONSTRAINT FK_453ba8_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_453ba8_Parent
ON edfi.ParentTelephone (ParentUSI ASC);

ALTER TABLE edfi.ParentTelephone ADD CONSTRAINT FK_453ba8_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_453ba8_TelephoneNumberTypeDescriptor
ON edfi.ParentTelephone (TelephoneNumberTypeDescriptorId ASC);

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

CREATE INDEX FK_6007db_SourceSystemDescriptor
ON edfi.Person (SourceSystemDescriptorId ASC);

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

CREATE INDEX FK_b8b6d7_PostSecondaryEventCategoryDescriptor
ON edfi.PostSecondaryEvent (PostSecondaryEventCategoryDescriptorId ASC);

ALTER TABLE edfi.PostSecondaryEvent ADD CONSTRAINT FK_b8b6d7_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
;

CREATE INDEX FK_b8b6d7_PostSecondaryInstitution
ON edfi.PostSecondaryEvent (PostSecondaryInstitutionId ASC);

ALTER TABLE edfi.PostSecondaryEvent ADD CONSTRAINT FK_b8b6d7_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_b8b6d7_Student
ON edfi.PostSecondaryEvent (StudentUSI ASC);

ALTER TABLE edfi.PostSecondaryEventCategoryDescriptor ADD CONSTRAINT FK_6829e4_Descriptor FOREIGN KEY (PostSecondaryEventCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostSecondaryInstitution ADD CONSTRAINT FK_2935bf_AdministrativeFundingControlDescriptor FOREIGN KEY (AdministrativeFundingControlDescriptorId)
REFERENCES edfi.AdministrativeFundingControlDescriptor (AdministrativeFundingControlDescriptorId)
;

CREATE INDEX FK_2935bf_AdministrativeFundingControlDescriptor
ON edfi.PostSecondaryInstitution (AdministrativeFundingControlDescriptorId ASC);

ALTER TABLE edfi.PostSecondaryInstitution ADD CONSTRAINT FK_2935bf_EducationOrganization FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostSecondaryInstitution ADD CONSTRAINT FK_2935bf_PostSecondaryInstitutionLevelDescriptor FOREIGN KEY (PostSecondaryInstitutionLevelDescriptorId)
REFERENCES edfi.PostSecondaryInstitutionLevelDescriptor (PostSecondaryInstitutionLevelDescriptorId)
;

CREATE INDEX FK_2935bf_PostSecondaryInstitutionLevelDescriptor
ON edfi.PostSecondaryInstitution (PostSecondaryInstitutionLevelDescriptorId ASC);

ALTER TABLE edfi.PostSecondaryInstitutionLevelDescriptor ADD CONSTRAINT FK_3dd32d_Descriptor FOREIGN KEY (PostSecondaryInstitutionLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.PostSecondaryInstitutionMediumOfInstruction ADD CONSTRAINT FK_9bd9d6_MediumOfInstructionDescriptor FOREIGN KEY (MediumOfInstructionDescriptorId)
REFERENCES edfi.MediumOfInstructionDescriptor (MediumOfInstructionDescriptorId)
;

CREATE INDEX FK_9bd9d6_MediumOfInstructionDescriptor
ON edfi.PostSecondaryInstitutionMediumOfInstruction (MediumOfInstructionDescriptorId ASC);

ALTER TABLE edfi.PostSecondaryInstitutionMediumOfInstruction ADD CONSTRAINT FK_9bd9d6_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
ON DELETE CASCADE
;

CREATE INDEX FK_9bd9d6_PostSecondaryInstitution
ON edfi.PostSecondaryInstitutionMediumOfInstruction (PostSecondaryInstitutionId ASC);

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

CREATE INDEX FK_90920d_EducationOrganization
ON edfi.Program (EducationOrganizationId ASC);

ALTER TABLE edfi.Program ADD CONSTRAINT FK_90920d_ProgramTypeDescriptor FOREIGN KEY (ProgramTypeDescriptorId)
REFERENCES edfi.ProgramTypeDescriptor (ProgramTypeDescriptorId)
;

CREATE INDEX FK_90920d_ProgramTypeDescriptor
ON edfi.Program (ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.ProgramAssignmentDescriptor ADD CONSTRAINT FK_8f5a42_Descriptor FOREIGN KEY (ProgramAssignmentDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramCharacteristic ADD CONSTRAINT FK_16896e_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_16896e_Program
ON edfi.ProgramCharacteristic (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.ProgramCharacteristic ADD CONSTRAINT FK_16896e_ProgramCharacteristicDescriptor FOREIGN KEY (ProgramCharacteristicDescriptorId)
REFERENCES edfi.ProgramCharacteristicDescriptor (ProgramCharacteristicDescriptorId)
;

CREATE INDEX FK_16896e_ProgramCharacteristicDescriptor
ON edfi.ProgramCharacteristic (ProgramCharacteristicDescriptorId ASC);

ALTER TABLE edfi.ProgramCharacteristicDescriptor ADD CONSTRAINT FK_ba9204_Descriptor FOREIGN KEY (ProgramCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.ProgramDimensionReportingTag ADD CONSTRAINT FK_3e04ae_ProgramDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.ProgramDimension (Code, FiscalYear)
ON DELETE CASCADE
;

CREATE INDEX FK_3e04ae_ProgramDimension
ON edfi.ProgramDimensionReportingTag (Code ASC, FiscalYear ASC);

ALTER TABLE edfi.ProgramDimensionReportingTag ADD CONSTRAINT FK_3e04ae_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_3e04ae_ReportingTagDescriptor
ON edfi.ProgramDimensionReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.ProgramLearningObjective ADD CONSTRAINT FK_f5911f_LearningObjective FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
;

CREATE INDEX FK_f5911f_LearningObjective
ON edfi.ProgramLearningObjective (LearningObjectiveId ASC, Namespace ASC);

ALTER TABLE edfi.ProgramLearningObjective ADD CONSTRAINT FK_f5911f_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_f5911f_Program
ON edfi.ProgramLearningObjective (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.ProgramLearningStandard ADD CONSTRAINT FK_44f909_LearningStandard FOREIGN KEY (LearningStandardId)
REFERENCES edfi.LearningStandard (LearningStandardId)
;

CREATE INDEX FK_44f909_LearningStandard
ON edfi.ProgramLearningStandard (LearningStandardId ASC);

ALTER TABLE edfi.ProgramLearningStandard ADD CONSTRAINT FK_44f909_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_44f909_Program
ON edfi.ProgramLearningStandard (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.ProgramService ADD CONSTRAINT FK_e943d3_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_e943d3_Program
ON edfi.ProgramService (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.ProgramService ADD CONSTRAINT FK_e943d3_ServiceDescriptor FOREIGN KEY (ServiceDescriptorId)
REFERENCES edfi.ServiceDescriptor (ServiceDescriptorId)
;

CREATE INDEX FK_e943d3_ServiceDescriptor
ON edfi.ProgramService (ServiceDescriptorId ASC);

ALTER TABLE edfi.ProgramSponsor ADD CONSTRAINT FK_4c38bb_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_4c38bb_Program
ON edfi.ProgramSponsor (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.ProgramSponsor ADD CONSTRAINT FK_4c38bb_ProgramSponsorDescriptor FOREIGN KEY (ProgramSponsorDescriptorId)
REFERENCES edfi.ProgramSponsorDescriptor (ProgramSponsorDescriptorId)
;

CREATE INDEX FK_4c38bb_ProgramSponsorDescriptor
ON edfi.ProgramSponsor (ProgramSponsorDescriptorId ASC);

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

CREATE INDEX FK_b5314a_ProjectDimension
ON edfi.ProjectDimensionReportingTag (Code ASC, FiscalYear ASC);

ALTER TABLE edfi.ProjectDimensionReportingTag ADD CONSTRAINT FK_b5314a_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_b5314a_ReportingTagDescriptor
ON edfi.ProjectDimensionReportingTag (ReportingTagDescriptorId ASC);

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

CREATE INDEX FK_ec1992_EducationOrganization
ON edfi.ReportCard (EducationOrganizationId ASC);

ALTER TABLE edfi.ReportCard ADD CONSTRAINT FK_ec1992_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

CREATE INDEX FK_ec1992_GradingPeriod
ON edfi.ReportCard (GradingPeriodDescriptorId ASC, GradingPeriodSequence ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC);

ALTER TABLE edfi.ReportCard ADD CONSTRAINT FK_ec1992_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_ec1992_Student
ON edfi.ReportCard (StudentUSI ASC);

ALTER TABLE edfi.ReportCardGrade ADD CONSTRAINT FK_f203d3_Grade FOREIGN KEY (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSchoolYear, GradingPeriodSequence, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.Grade (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSchoolYear, GradingPeriodSequence, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON UPDATE CASCADE
;

CREATE INDEX FK_f203d3_Grade
ON edfi.ReportCardGrade (BeginDate ASC, GradeTypeDescriptorId ASC, GradingPeriodDescriptorId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC, StudentUSI ASC);

ALTER TABLE edfi.ReportCardGrade ADD CONSTRAINT FK_f203d3_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_f203d3_ReportCard
ON edfi.ReportCardGrade (EducationOrganizationId ASC, GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, StudentUSI ASC);

ALTER TABLE edfi.ReportCardGradePointAverage ADD CONSTRAINT FK_8574ad_GradePointAverageTypeDescriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.GradePointAverageTypeDescriptor (GradePointAverageTypeDescriptorId)
;

CREATE INDEX FK_8574ad_GradePointAverageTypeDescriptor
ON edfi.ReportCardGradePointAverage (GradePointAverageTypeDescriptorId ASC);

ALTER TABLE edfi.ReportCardGradePointAverage ADD CONSTRAINT FK_8574ad_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_8574ad_ReportCard
ON edfi.ReportCardGradePointAverage (EducationOrganizationId ASC, GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, StudentUSI ASC);

ALTER TABLE edfi.ReportCardStudentCompetencyObjective ADD CONSTRAINT FK_c16d6c_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_c16d6c_ReportCard
ON edfi.ReportCardStudentCompetencyObjective (EducationOrganizationId ASC, GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, StudentUSI ASC);

ALTER TABLE edfi.ReportCardStudentCompetencyObjective ADD CONSTRAINT FK_c16d6c_StudentCompetencyObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI)
REFERENCES edfi.StudentCompetencyObjective (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI)
;

CREATE INDEX FK_c16d6c_StudentCompetencyObjective
ON edfi.ReportCardStudentCompetencyObjective (GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, Objective ASC, ObjectiveEducationOrganizationId ASC, ObjectiveGradeLevelDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.ReportCardStudentLearningObjective ADD CONSTRAINT FK_c098ce_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_c098ce_ReportCard
ON edfi.ReportCardStudentLearningObjective (EducationOrganizationId ASC, GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, StudentUSI ASC);

ALTER TABLE edfi.ReportCardStudentLearningObjective ADD CONSTRAINT FK_c098ce_StudentLearningObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI)
REFERENCES edfi.StudentLearningObjective (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI)
;

CREATE INDEX FK_c098ce_StudentLearningObjective
ON edfi.ReportCardStudentLearningObjective (GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, LearningObjectiveId ASC, Namespace ASC, StudentUSI ASC);

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

CREATE INDEX FK_3800be_EducationalEnvironmentDescriptor
ON edfi.RestraintEvent (EducationalEnvironmentDescriptorId ASC);

ALTER TABLE edfi.RestraintEvent ADD CONSTRAINT FK_3800be_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_3800be_School
ON edfi.RestraintEvent (SchoolId ASC);

ALTER TABLE edfi.RestraintEvent ADD CONSTRAINT FK_3800be_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_3800be_Student
ON edfi.RestraintEvent (StudentUSI ASC);

ALTER TABLE edfi.RestraintEventProgram ADD CONSTRAINT FK_d3d793_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_d3d793_Program
ON edfi.RestraintEventProgram (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.RestraintEventProgram ADD CONSTRAINT FK_d3d793_RestraintEvent FOREIGN KEY (RestraintEventIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.RestraintEvent (RestraintEventIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_d3d793_RestraintEvent
ON edfi.RestraintEventProgram (RestraintEventIdentifier ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.RestraintEventReason ADD CONSTRAINT FK_e232ae_RestraintEvent FOREIGN KEY (RestraintEventIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.RestraintEvent (RestraintEventIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_e232ae_RestraintEvent
ON edfi.RestraintEventReason (RestraintEventIdentifier ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.RestraintEventReason ADD CONSTRAINT FK_e232ae_RestraintEventReasonDescriptor FOREIGN KEY (RestraintEventReasonDescriptorId)
REFERENCES edfi.RestraintEventReasonDescriptor (RestraintEventReasonDescriptorId)
;

CREATE INDEX FK_e232ae_RestraintEventReasonDescriptor
ON edfi.RestraintEventReason (RestraintEventReasonDescriptorId ASC);

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

CREATE INDEX FK_6cd2e3_AdministrativeFundingControlDescriptor
ON edfi.School (AdministrativeFundingControlDescriptorId ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_CharterApprovalAgencyTypeDescriptor FOREIGN KEY (CharterApprovalAgencyTypeDescriptorId)
REFERENCES edfi.CharterApprovalAgencyTypeDescriptor (CharterApprovalAgencyTypeDescriptorId)
;

CREATE INDEX FK_6cd2e3_CharterApprovalAgencyTypeDescriptor
ON edfi.School (CharterApprovalAgencyTypeDescriptorId ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_CharterStatusDescriptor FOREIGN KEY (CharterStatusDescriptorId)
REFERENCES edfi.CharterStatusDescriptor (CharterStatusDescriptorId)
;

CREATE INDEX FK_6cd2e3_CharterStatusDescriptor
ON edfi.School (CharterStatusDescriptorId ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_EducationOrganization FOREIGN KEY (SchoolId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_InternetAccessDescriptor FOREIGN KEY (InternetAccessDescriptorId)
REFERENCES edfi.InternetAccessDescriptor (InternetAccessDescriptorId)
;

CREATE INDEX FK_6cd2e3_InternetAccessDescriptor
ON edfi.School (InternetAccessDescriptorId ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
;

CREATE INDEX FK_6cd2e3_LocalEducationAgency
ON edfi.School (LocalEducationAgencyId ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_MagnetSpecialProgramEmphasisSchoolDescriptor FOREIGN KEY (MagnetSpecialProgramEmphasisSchoolDescriptorId)
REFERENCES edfi.MagnetSpecialProgramEmphasisSchoolDescriptor (MagnetSpecialProgramEmphasisSchoolDescriptorId)
;

CREATE INDEX FK_6cd2e3_MagnetSpecialProgramEmphasisSchoolDescriptor
ON edfi.School (MagnetSpecialProgramEmphasisSchoolDescriptorId ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_SchoolTypeDescriptor FOREIGN KEY (SchoolTypeDescriptorId)
REFERENCES edfi.SchoolTypeDescriptor (SchoolTypeDescriptorId)
;

CREATE INDEX FK_6cd2e3_SchoolTypeDescriptor
ON edfi.School (SchoolTypeDescriptorId ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_SchoolYearType FOREIGN KEY (CharterApprovalSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_6cd2e3_SchoolYearType
ON edfi.School (CharterApprovalSchoolYear ASC);

ALTER TABLE edfi.School ADD CONSTRAINT FK_6cd2e3_TitleIPartASchoolDesignationDescriptor FOREIGN KEY (TitleIPartASchoolDesignationDescriptorId)
REFERENCES edfi.TitleIPartASchoolDesignationDescriptor (TitleIPartASchoolDesignationDescriptorId)
;

CREATE INDEX FK_6cd2e3_TitleIPartASchoolDesignationDescriptor
ON edfi.School (TitleIPartASchoolDesignationDescriptorId ASC);

ALTER TABLE edfi.SchoolCategory ADD CONSTRAINT FK_789691_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_789691_School
ON edfi.SchoolCategory (SchoolId ASC);

ALTER TABLE edfi.SchoolCategory ADD CONSTRAINT FK_789691_SchoolCategoryDescriptor FOREIGN KEY (SchoolCategoryDescriptorId)
REFERENCES edfi.SchoolCategoryDescriptor (SchoolCategoryDescriptorId)
;

CREATE INDEX FK_789691_SchoolCategoryDescriptor
ON edfi.SchoolCategory (SchoolCategoryDescriptorId ASC);

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

CREATE INDEX FK_64d8a6_GradeLevelDescriptor
ON edfi.SchoolGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.SchoolGradeLevel ADD CONSTRAINT FK_64d8a6_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_64d8a6_School
ON edfi.SchoolGradeLevel (SchoolId ASC);

ALTER TABLE edfi.SchoolTypeDescriptor ADD CONSTRAINT FK_ef0964_Descriptor FOREIGN KEY (SchoolTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_dfca5d_CourseOffering
ON edfi.Section (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_CreditTypeDescriptor FOREIGN KEY (AvailableCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_dfca5d_CreditTypeDescriptor
ON edfi.Section (AvailableCreditTypeDescriptorId ASC);

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

CREATE INDEX FK_dfca5d_EducationalEnvironmentDescriptor
ON edfi.Section (EducationalEnvironmentDescriptorId ASC);

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_LanguageDescriptor FOREIGN KEY (InstructionLanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_dfca5d_LanguageDescriptor
ON edfi.Section (InstructionLanguageDescriptorId ASC);

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_Location FOREIGN KEY (LocationClassroomIdentificationCode, LocationSchoolId)
REFERENCES edfi.Location (ClassroomIdentificationCode, SchoolId)
ON UPDATE CASCADE
;

CREATE INDEX FK_dfca5d_Location
ON edfi.Section (LocationClassroomIdentificationCode ASC, LocationSchoolId ASC);

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_MediumOfInstructionDescriptor FOREIGN KEY (MediumOfInstructionDescriptorId)
REFERENCES edfi.MediumOfInstructionDescriptor (MediumOfInstructionDescriptorId)
;

CREATE INDEX FK_dfca5d_MediumOfInstructionDescriptor
ON edfi.Section (MediumOfInstructionDescriptorId ASC);

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_dfca5d_PopulationServedDescriptor
ON edfi.Section (PopulationServedDescriptorId ASC);

ALTER TABLE edfi.Section ADD CONSTRAINT FK_dfca5d_School FOREIGN KEY (LocationSchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_dfca5d_School
ON edfi.Section (LocationSchoolId ASC);

ALTER TABLE edfi.SectionAttendanceTakenEvent ADD CONSTRAINT FK_7bbbe7_CalendarDate FOREIGN KEY (CalendarCode, Date, SchoolId, SchoolYear)
REFERENCES edfi.CalendarDate (CalendarCode, Date, SchoolId, SchoolYear)
;

CREATE INDEX FK_7bbbe7_CalendarDate
ON edfi.SectionAttendanceTakenEvent (CalendarCode ASC, Date ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.SectionAttendanceTakenEvent ADD CONSTRAINT FK_7bbbe7_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_7bbbe7_Section
ON edfi.SectionAttendanceTakenEvent (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.SectionAttendanceTakenEvent ADD CONSTRAINT FK_7bbbe7_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_7bbbe7_Staff
ON edfi.SectionAttendanceTakenEvent (StaffUSI ASC);

ALTER TABLE edfi.SectionCharacteristic ADD CONSTRAINT FK_1587d8_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_1587d8_Section
ON edfi.SectionCharacteristic (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.SectionCharacteristic ADD CONSTRAINT FK_1587d8_SectionCharacteristicDescriptor FOREIGN KEY (SectionCharacteristicDescriptorId)
REFERENCES edfi.SectionCharacteristicDescriptor (SectionCharacteristicDescriptorId)
;

CREATE INDEX FK_1587d8_SectionCharacteristicDescriptor
ON edfi.SectionCharacteristic (SectionCharacteristicDescriptorId ASC);

ALTER TABLE edfi.SectionCharacteristicDescriptor ADD CONSTRAINT FK_9aae24_Descriptor FOREIGN KEY (SectionCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SectionClassPeriod ADD CONSTRAINT FK_465c76_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON UPDATE CASCADE
;

CREATE INDEX FK_465c76_ClassPeriod
ON edfi.SectionClassPeriod (ClassPeriodName ASC, SchoolId ASC);

ALTER TABLE edfi.SectionClassPeriod ADD CONSTRAINT FK_465c76_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_465c76_Section
ON edfi.SectionClassPeriod (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.SectionCourseLevelCharacteristic ADD CONSTRAINT FK_f221cc_CourseLevelCharacteristicDescriptor FOREIGN KEY (CourseLevelCharacteristicDescriptorId)
REFERENCES edfi.CourseLevelCharacteristicDescriptor (CourseLevelCharacteristicDescriptorId)
;

CREATE INDEX FK_f221cc_CourseLevelCharacteristicDescriptor
ON edfi.SectionCourseLevelCharacteristic (CourseLevelCharacteristicDescriptorId ASC);

ALTER TABLE edfi.SectionCourseLevelCharacteristic ADD CONSTRAINT FK_f221cc_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_f221cc_Section
ON edfi.SectionCourseLevelCharacteristic (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.SectionOfferedGradeLevel ADD CONSTRAINT FK_8d3fd8_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_8d3fd8_GradeLevelDescriptor
ON edfi.SectionOfferedGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.SectionOfferedGradeLevel ADD CONSTRAINT FK_8d3fd8_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_8d3fd8_Section
ON edfi.SectionOfferedGradeLevel (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.SectionProgram ADD CONSTRAINT FK_309217_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_309217_Program
ON edfi.SectionProgram (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.SectionProgram ADD CONSTRAINT FK_309217_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_309217_Section
ON edfi.SectionProgram (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

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

CREATE INDEX FK_6959b4_School
ON edfi.Session (SchoolId ASC);

ALTER TABLE edfi.Session ADD CONSTRAINT FK_6959b4_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_6959b4_SchoolYearType
ON edfi.Session (SchoolYear ASC);

ALTER TABLE edfi.Session ADD CONSTRAINT FK_6959b4_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_6959b4_TermDescriptor
ON edfi.Session (TermDescriptorId ASC);

ALTER TABLE edfi.SessionAcademicWeek ADD CONSTRAINT FK_72eb60_AcademicWeek FOREIGN KEY (SchoolId, WeekIdentifier)
REFERENCES edfi.AcademicWeek (SchoolId, WeekIdentifier)
;

CREATE INDEX FK_72eb60_AcademicWeek
ON edfi.SessionAcademicWeek (SchoolId ASC, WeekIdentifier ASC);

ALTER TABLE edfi.SessionAcademicWeek ADD CONSTRAINT FK_72eb60_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_72eb60_Session
ON edfi.SessionAcademicWeek (SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.SessionGradingPeriod ADD CONSTRAINT FK_c4b3e0_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

CREATE INDEX FK_c4b3e0_GradingPeriod
ON edfi.SessionGradingPeriod (GradingPeriodDescriptorId ASC, PeriodSequence ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.SessionGradingPeriod ADD CONSTRAINT FK_c4b3e0_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_c4b3e0_Session
ON edfi.SessionGradingPeriod (SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.SexDescriptor ADD CONSTRAINT FK_eb9b06_Descriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SourceDimensionReportingTag ADD CONSTRAINT FK_0c6eff_ReportingTagDescriptor FOREIGN KEY (ReportingTagDescriptorId)
REFERENCES edfi.ReportingTagDescriptor (ReportingTagDescriptorId)
;

CREATE INDEX FK_0c6eff_ReportingTagDescriptor
ON edfi.SourceDimensionReportingTag (ReportingTagDescriptorId ASC);

ALTER TABLE edfi.SourceDimensionReportingTag ADD CONSTRAINT FK_0c6eff_SourceDimension FOREIGN KEY (Code, FiscalYear)
REFERENCES edfi.SourceDimension (Code, FiscalYear)
ON DELETE CASCADE
;

CREATE INDEX FK_0c6eff_SourceDimension
ON edfi.SourceDimensionReportingTag (Code ASC, FiscalYear ASC);

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

CREATE INDEX FK_681927_CitizenshipStatusDescriptor
ON edfi.Staff (CitizenshipStatusDescriptorId ASC);

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_LevelOfEducationDescriptor FOREIGN KEY (HighestCompletedLevelOfEducationDescriptorId)
REFERENCES edfi.LevelOfEducationDescriptor (LevelOfEducationDescriptorId)
;

CREATE INDEX FK_681927_LevelOfEducationDescriptor
ON edfi.Staff (HighestCompletedLevelOfEducationDescriptorId ASC);

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_OldEthnicityDescriptor FOREIGN KEY (OldEthnicityDescriptorId)
REFERENCES edfi.OldEthnicityDescriptor (OldEthnicityDescriptorId)
;

CREATE INDEX FK_681927_OldEthnicityDescriptor
ON edfi.Staff (OldEthnicityDescriptorId ASC);

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_681927_Person
ON edfi.Staff (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE edfi.Staff ADD CONSTRAINT FK_681927_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_681927_SexDescriptor
ON edfi.Staff (SexDescriptorId ASC);

ALTER TABLE edfi.StaffAbsenceEvent ADD CONSTRAINT FK_b13bbd_AbsenceEventCategoryDescriptor FOREIGN KEY (AbsenceEventCategoryDescriptorId)
REFERENCES edfi.AbsenceEventCategoryDescriptor (AbsenceEventCategoryDescriptorId)
;

CREATE INDEX FK_b13bbd_AbsenceEventCategoryDescriptor
ON edfi.StaffAbsenceEvent (AbsenceEventCategoryDescriptorId ASC);

ALTER TABLE edfi.StaffAbsenceEvent ADD CONSTRAINT FK_b13bbd_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_b13bbd_Staff
ON edfi.StaffAbsenceEvent (StaffUSI ASC);

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_c0e4a3_AddressTypeDescriptor
ON edfi.StaffAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_c0e4a3_LocaleDescriptor
ON edfi.StaffAddress (LocaleDescriptorId ASC);

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_c0e4a3_Staff
ON edfi.StaffAddress (StaffUSI ASC);

ALTER TABLE edfi.StaffAddress ADD CONSTRAINT FK_c0e4a3_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_c0e4a3_StateAbbreviationDescriptor
ON edfi.StaffAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.StaffAddressPeriod ADD CONSTRAINT FK_b7f969_StaffAddress FOREIGN KEY (AddressTypeDescriptorId, City, PostalCode, StaffUSI, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.StaffAddress (AddressTypeDescriptorId, City, PostalCode, StaffUSI, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_b7f969_StaffAddress
ON edfi.StaffAddressPeriod (AddressTypeDescriptorId ASC, City ASC, PostalCode ASC, StaffUSI ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE edfi.StaffAncestryEthnicOrigin ADD CONSTRAINT FK_a4a6ae_AncestryEthnicOriginDescriptor FOREIGN KEY (AncestryEthnicOriginDescriptorId)
REFERENCES edfi.AncestryEthnicOriginDescriptor (AncestryEthnicOriginDescriptorId)
;

CREATE INDEX FK_a4a6ae_AncestryEthnicOriginDescriptor
ON edfi.StaffAncestryEthnicOrigin (AncestryEthnicOriginDescriptorId ASC);

ALTER TABLE edfi.StaffAncestryEthnicOrigin ADD CONSTRAINT FK_a4a6ae_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a4a6ae_Staff
ON edfi.StaffAncestryEthnicOrigin (StaffUSI ASC);

ALTER TABLE edfi.StaffClassificationDescriptor ADD CONSTRAINT FK_6ca180_Descriptor FOREIGN KEY (StaffClassificationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffCohortAssociation ADD CONSTRAINT FK_170747_Cohort FOREIGN KEY (CohortIdentifier, EducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
;

CREATE INDEX FK_170747_Cohort
ON edfi.StaffCohortAssociation (CohortIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.StaffCohortAssociation ADD CONSTRAINT FK_170747_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_170747_Staff
ON edfi.StaffCohortAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffCredential ADD CONSTRAINT FK_f3917b_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

CREATE INDEX FK_f3917b_Credential
ON edfi.StaffCredential (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.StaffCredential ADD CONSTRAINT FK_f3917b_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_f3917b_Staff
ON edfi.StaffCredential (StaffUSI ASC);

ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD CONSTRAINT FK_af86db_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
;

CREATE INDEX FK_af86db_DisciplineIncident
ON edfi.StaffDisciplineIncidentAssociation (IncidentIdentifier ASC, SchoolId ASC);

ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD CONSTRAINT FK_af86db_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_af86db_Staff
ON edfi.StaffDisciplineIncidentAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be ADD CONSTRAINT FK_7fa4be_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

CREATE INDEX FK_7fa4be_DisciplineIncidentParticipationCodeDescriptor
ON edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be (DisciplineIncidentParticipationCodeDescriptorId ASC);

ALTER TABLE edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be ADD CONSTRAINT FK_7fa4be_StaffDisciplineIncidentAssociation FOREIGN KEY (IncidentIdentifier, SchoolId, StaffUSI)
REFERENCES edfi.StaffDisciplineIncidentAssociation (IncidentIdentifier, SchoolId, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_7fa4be_StaffDisciplineIncidentAssociation
ON edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be (IncidentIdentifier ASC, SchoolId ASC, StaffUSI ASC);

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

CREATE INDEX FK_b9be24_Credential
ON edfi.StaffEducationOrganizationAssignmentAssociation (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_b9be24_EducationOrganization
ON edfi.StaffEducationOrganizationAssignmentAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_b9be24_Staff
ON edfi.StaffEducationOrganizationAssignmentAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_StaffClassificationDescriptor FOREIGN KEY (StaffClassificationDescriptorId)
REFERENCES edfi.StaffClassificationDescriptor (StaffClassificationDescriptorId)
;

CREATE INDEX FK_b9be24_StaffClassificationDescriptor
ON edfi.StaffEducationOrganizationAssignmentAssociation (StaffClassificationDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD CONSTRAINT FK_b9be24_StaffEducationOrganizationEmploymentAssociation FOREIGN KEY (EmploymentEducationOrganizationId, EmploymentStatusDescriptorId, EmploymentHireDate, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
;

CREATE INDEX FK_b9be24_StaffEducationOrganizationEmploymentAssociation
ON edfi.StaffEducationOrganizationAssignmentAssociation (EmploymentEducationOrganizationId ASC, EmploymentStatusDescriptorId ASC, EmploymentHireDate ASC, StaffUSI ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD CONSTRAINT FK_735dd8_ContactTypeDescriptor FOREIGN KEY (ContactTypeDescriptorId)
REFERENCES edfi.ContactTypeDescriptor (ContactTypeDescriptorId)
;

CREATE INDEX FK_735dd8_ContactTypeDescriptor
ON edfi.StaffEducationOrganizationContactAssociation (ContactTypeDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD CONSTRAINT FK_735dd8_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_735dd8_EducationOrganization
ON edfi.StaffEducationOrganizationContactAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD CONSTRAINT FK_735dd8_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_735dd8_Staff
ON edfi.StaffEducationOrganizationContactAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_893629_AddressTypeDescriptor
ON edfi.StaffEducationOrganizationContactAssociationAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_893629_LocaleDescriptor
ON edfi.StaffEducationOrganizationContactAssociationAddress (LocaleDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_StaffEducationOrganizationContactAssociation FOREIGN KEY (ContactTitle, EducationOrganizationId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationContactAssociation (ContactTitle, EducationOrganizationId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddress ADD CONSTRAINT FK_893629_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_893629_StateAbbreviationDescriptor
ON edfi.StaffEducationOrganizationContactAssociationAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationAddressPeriod ADD CONSTRAINT FK_afd39a_StaffEducationOrganizationContactAssociationAddress FOREIGN KEY (ContactTitle, EducationOrganizationId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationContactAssociationAddress (ContactTitle, EducationOrganizationId, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_afd39a_StaffEducationOrganizationContactAssociationAddress
ON edfi.StaffEducationOrganizationContactAssociationAddressPeriod (ContactTitle ASC, EducationOrganizationId ASC, StaffUSI ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationTelephone ADD CONSTRAINT FK_742dd2_StaffEducationOrganizationContactAssociation FOREIGN KEY (ContactTitle, EducationOrganizationId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationContactAssociation (ContactTitle, EducationOrganizationId, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_742dd2_StaffEducationOrganizationContactAssociation
ON edfi.StaffEducationOrganizationContactAssociationTelephone (ContactTitle ASC, EducationOrganizationId ASC, StaffUSI ASC);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociationTelephone ADD CONSTRAINT FK_742dd2_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_742dd2_TelephoneNumberTypeDescriptor
ON edfi.StaffEducationOrganizationContactAssociationTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

CREATE INDEX FK_4e79b9_Credential
ON edfi.StaffEducationOrganizationEmploymentAssociation (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_4e79b9_EducationOrganization
ON edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_EmploymentStatusDescriptor FOREIGN KEY (EmploymentStatusDescriptorId)
REFERENCES edfi.EmploymentStatusDescriptor (EmploymentStatusDescriptorId)
;

CREATE INDEX FK_4e79b9_EmploymentStatusDescriptor
ON edfi.StaffEducationOrganizationEmploymentAssociation (EmploymentStatusDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_SeparationDescriptor FOREIGN KEY (SeparationDescriptorId)
REFERENCES edfi.SeparationDescriptor (SeparationDescriptorId)
;

CREATE INDEX FK_4e79b9_SeparationDescriptor
ON edfi.StaffEducationOrganizationEmploymentAssociation (SeparationDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_SeparationReasonDescriptor FOREIGN KEY (SeparationReasonDescriptorId)
REFERENCES edfi.SeparationReasonDescriptor (SeparationReasonDescriptorId)
;

CREATE INDEX FK_4e79b9_SeparationReasonDescriptor
ON edfi.StaffEducationOrganizationEmploymentAssociation (SeparationReasonDescriptorId ASC);

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD CONSTRAINT FK_4e79b9_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_4e79b9_Staff
ON edfi.StaffEducationOrganizationEmploymentAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffElectronicMail ADD CONSTRAINT FK_d93663_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_d93663_ElectronicMailTypeDescriptor
ON edfi.StaffElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE edfi.StaffElectronicMail ADD CONSTRAINT FK_d93663_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_d93663_Staff
ON edfi.StaffElectronicMail (StaffUSI ASC);

ALTER TABLE edfi.StaffIdentificationCode ADD CONSTRAINT FK_7483c6_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_7483c6_Staff
ON edfi.StaffIdentificationCode (StaffUSI ASC);

ALTER TABLE edfi.StaffIdentificationCode ADD CONSTRAINT FK_7483c6_StaffIdentificationSystemDescriptor FOREIGN KEY (StaffIdentificationSystemDescriptorId)
REFERENCES edfi.StaffIdentificationSystemDescriptor (StaffIdentificationSystemDescriptorId)
;

CREATE INDEX FK_7483c6_StaffIdentificationSystemDescriptor
ON edfi.StaffIdentificationCode (StaffIdentificationSystemDescriptorId ASC);

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_31779a_CountryDescriptor
ON edfi.StaffIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_31779a_IdentificationDocumentUseDescriptor
ON edfi.StaffIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_31779a_PersonalInformationVerificationDescriptor
ON edfi.StaffIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE edfi.StaffIdentificationDocument ADD CONSTRAINT FK_31779a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_31779a_Staff
ON edfi.StaffIdentificationDocument (StaffUSI ASC);

ALTER TABLE edfi.StaffIdentificationSystemDescriptor ADD CONSTRAINT FK_cb401c_Descriptor FOREIGN KEY (StaffIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffInternationalAddress ADD CONSTRAINT FK_6cd27e_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_6cd27e_AddressTypeDescriptor
ON edfi.StaffInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.StaffInternationalAddress ADD CONSTRAINT FK_6cd27e_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_6cd27e_CountryDescriptor
ON edfi.StaffInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE edfi.StaffInternationalAddress ADD CONSTRAINT FK_6cd27e_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_6cd27e_Staff
ON edfi.StaffInternationalAddress (StaffUSI ASC);

ALTER TABLE edfi.StaffLanguage ADD CONSTRAINT FK_1c8d3f_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_1c8d3f_LanguageDescriptor
ON edfi.StaffLanguage (LanguageDescriptorId ASC);

ALTER TABLE edfi.StaffLanguage ADD CONSTRAINT FK_1c8d3f_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_1c8d3f_Staff
ON edfi.StaffLanguage (StaffUSI ASC);

ALTER TABLE edfi.StaffLanguageUse ADD CONSTRAINT FK_b527e7_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_b527e7_LanguageUseDescriptor
ON edfi.StaffLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE edfi.StaffLanguageUse ADD CONSTRAINT FK_b527e7_StaffLanguage FOREIGN KEY (LanguageDescriptorId, StaffUSI)
REFERENCES edfi.StaffLanguage (LanguageDescriptorId, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b527e7_StaffLanguage
ON edfi.StaffLanguageUse (LanguageDescriptorId ASC, StaffUSI ASC);

ALTER TABLE edfi.StaffLeave ADD CONSTRAINT FK_debd4f_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_debd4f_Staff
ON edfi.StaffLeave (StaffUSI ASC);

ALTER TABLE edfi.StaffLeave ADD CONSTRAINT FK_debd4f_StaffLeaveEventCategoryDescriptor FOREIGN KEY (StaffLeaveEventCategoryDescriptorId)
REFERENCES edfi.StaffLeaveEventCategoryDescriptor (StaffLeaveEventCategoryDescriptorId)
;

CREATE INDEX FK_debd4f_StaffLeaveEventCategoryDescriptor
ON edfi.StaffLeave (StaffLeaveEventCategoryDescriptorId ASC);

ALTER TABLE edfi.StaffLeaveEventCategoryDescriptor ADD CONSTRAINT FK_963eb5_Descriptor FOREIGN KEY (StaffLeaveEventCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StaffOtherName ADD CONSTRAINT FK_b0cb9e_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

CREATE INDEX FK_b0cb9e_OtherNameTypeDescriptor
ON edfi.StaffOtherName (OtherNameTypeDescriptorId ASC);

ALTER TABLE edfi.StaffOtherName ADD CONSTRAINT FK_b0cb9e_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b0cb9e_Staff
ON edfi.StaffOtherName (StaffUSI ASC);

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_4e3afe_CountryDescriptor
ON edfi.StaffPersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_4e3afe_IdentificationDocumentUseDescriptor
ON edfi.StaffPersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_4e3afe_PersonalInformationVerificationDescriptor
ON edfi.StaffPersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE edfi.StaffPersonalIdentificationDocument ADD CONSTRAINT FK_4e3afe_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_4e3afe_Staff
ON edfi.StaffPersonalIdentificationDocument (StaffUSI ASC);

ALTER TABLE edfi.StaffProgramAssociation ADD CONSTRAINT FK_a9c0d9_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_a9c0d9_Program
ON edfi.StaffProgramAssociation (ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.StaffProgramAssociation ADD CONSTRAINT FK_a9c0d9_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_a9c0d9_Staff
ON edfi.StaffProgramAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffRace ADD CONSTRAINT FK_696d9a_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_696d9a_RaceDescriptor
ON edfi.StaffRace (RaceDescriptorId ASC);

ALTER TABLE edfi.StaffRace ADD CONSTRAINT FK_696d9a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_696d9a_Staff
ON edfi.StaffRace (StaffUSI ASC);

ALTER TABLE edfi.StaffRecognition ADD CONSTRAINT FK_c60190_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

CREATE INDEX FK_c60190_AchievementCategoryDescriptor
ON edfi.StaffRecognition (AchievementCategoryDescriptorId ASC);

ALTER TABLE edfi.StaffRecognition ADD CONSTRAINT FK_c60190_RecognitionTypeDescriptor FOREIGN KEY (RecognitionTypeDescriptorId)
REFERENCES edfi.RecognitionTypeDescriptor (RecognitionTypeDescriptorId)
;

CREATE INDEX FK_c60190_RecognitionTypeDescriptor
ON edfi.StaffRecognition (RecognitionTypeDescriptorId ASC);

ALTER TABLE edfi.StaffRecognition ADD CONSTRAINT FK_c60190_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_c60190_Staff
ON edfi.StaffRecognition (StaffUSI ASC);

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
;

CREATE INDEX FK_ce2080_Calendar
ON edfi.StaffSchoolAssociation (CalendarCode ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_ProgramAssignmentDescriptor FOREIGN KEY (ProgramAssignmentDescriptorId)
REFERENCES edfi.ProgramAssignmentDescriptor (ProgramAssignmentDescriptorId)
;

CREATE INDEX FK_ce2080_ProgramAssignmentDescriptor
ON edfi.StaffSchoolAssociation (ProgramAssignmentDescriptorId ASC);

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_ce2080_School
ON edfi.StaffSchoolAssociation (SchoolId ASC);

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_ce2080_SchoolYearType
ON edfi.StaffSchoolAssociation (SchoolYear ASC);

ALTER TABLE edfi.StaffSchoolAssociation ADD CONSTRAINT FK_ce2080_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_ce2080_Staff
ON edfi.StaffSchoolAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffSchoolAssociationAcademicSubject ADD CONSTRAINT FK_d891fb_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_d891fb_AcademicSubjectDescriptor
ON edfi.StaffSchoolAssociationAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE edfi.StaffSchoolAssociationAcademicSubject ADD CONSTRAINT FK_d891fb_StaffSchoolAssociation FOREIGN KEY (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
REFERENCES edfi.StaffSchoolAssociation (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_d891fb_StaffSchoolAssociation
ON edfi.StaffSchoolAssociationAcademicSubject (ProgramAssignmentDescriptorId ASC, SchoolId ASC, StaffUSI ASC);

ALTER TABLE edfi.StaffSchoolAssociationGradeLevel ADD CONSTRAINT FK_3db81b_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_3db81b_GradeLevelDescriptor
ON edfi.StaffSchoolAssociationGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.StaffSchoolAssociationGradeLevel ADD CONSTRAINT FK_3db81b_StaffSchoolAssociation FOREIGN KEY (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
REFERENCES edfi.StaffSchoolAssociation (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_3db81b_StaffSchoolAssociation
ON edfi.StaffSchoolAssociationGradeLevel (ProgramAssignmentDescriptorId ASC, SchoolId ASC, StaffUSI ASC);

ALTER TABLE edfi.StaffSectionAssociation ADD CONSTRAINT FK_515cb5_ClassroomPositionDescriptor FOREIGN KEY (ClassroomPositionDescriptorId)
REFERENCES edfi.ClassroomPositionDescriptor (ClassroomPositionDescriptorId)
;

CREATE INDEX FK_515cb5_ClassroomPositionDescriptor
ON edfi.StaffSectionAssociation (ClassroomPositionDescriptorId ASC);

ALTER TABLE edfi.StaffSectionAssociation ADD CONSTRAINT FK_515cb5_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_515cb5_Section
ON edfi.StaffSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.StaffSectionAssociation ADD CONSTRAINT FK_515cb5_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_515cb5_Staff
ON edfi.StaffSectionAssociation (StaffUSI ASC);

ALTER TABLE edfi.StaffTelephone ADD CONSTRAINT FK_4de15a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_4de15a_Staff
ON edfi.StaffTelephone (StaffUSI ASC);

ALTER TABLE edfi.StaffTelephone ADD CONSTRAINT FK_4de15a_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_4de15a_TelephoneNumberTypeDescriptor
ON edfi.StaffTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE edfi.StaffTribalAffiliation ADD CONSTRAINT FK_e77b10_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_e77b10_Staff
ON edfi.StaffTribalAffiliation (StaffUSI ASC);

ALTER TABLE edfi.StaffTribalAffiliation ADD CONSTRAINT FK_e77b10_TribalAffiliationDescriptor FOREIGN KEY (TribalAffiliationDescriptorId)
REFERENCES edfi.TribalAffiliationDescriptor (TribalAffiliationDescriptorId)
;

CREATE INDEX FK_e77b10_TribalAffiliationDescriptor
ON edfi.StaffTribalAffiliation (TribalAffiliationDescriptorId ASC);

ALTER TABLE edfi.StaffVisa ADD CONSTRAINT FK_e27213_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_e27213_Staff
ON edfi.StaffVisa (StaffUSI ASC);

ALTER TABLE edfi.StaffVisa ADD CONSTRAINT FK_e27213_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

CREATE INDEX FK_e27213_VisaDescriptor
ON edfi.StaffVisa (VisaDescriptorId ASC);

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

CREATE INDEX FK_09668f_SchoolYearType
ON edfi.StateEducationAgencyAccountability (SchoolYear ASC);

ALTER TABLE edfi.StateEducationAgencyAccountability ADD CONSTRAINT FK_09668f_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
ON DELETE CASCADE
;

CREATE INDEX FK_09668f_StateEducationAgency
ON edfi.StateEducationAgencyAccountability (StateEducationAgencyId ASC);

ALTER TABLE edfi.StateEducationAgencyFederalFunds ADD CONSTRAINT FK_3c7e00_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
ON DELETE CASCADE
;

CREATE INDEX FK_3c7e00_StateEducationAgency
ON edfi.StateEducationAgencyFederalFunds (StateEducationAgencyId ASC);

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_CitizenshipStatusDescriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.CitizenshipStatusDescriptor (CitizenshipStatusDescriptorId)
;

CREATE INDEX FK_2a164d_CitizenshipStatusDescriptor
ON edfi.Student (CitizenshipStatusDescriptorId ASC);

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_CountryDescriptor FOREIGN KEY (BirthCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_2a164d_CountryDescriptor
ON edfi.Student (BirthCountryDescriptorId ASC);

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_2a164d_Person
ON edfi.Student (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_SexDescriptor FOREIGN KEY (BirthSexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_2a164d_SexDescriptor
ON edfi.Student (BirthSexDescriptorId ASC);

ALTER TABLE edfi.Student ADD CONSTRAINT FK_2a164d_StateAbbreviationDescriptor FOREIGN KEY (BirthStateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_2a164d_StateAbbreviationDescriptor
ON edfi.Student (BirthStateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor FOREIGN KEY (CumulativeEarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_0ff8d6_CreditTypeDescriptor
ON edfi.StudentAcademicRecord (CumulativeEarnedCreditTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor1 FOREIGN KEY (CumulativeAttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_0ff8d6_CreditTypeDescriptor1
ON edfi.StudentAcademicRecord (CumulativeAttemptedCreditTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor2 FOREIGN KEY (SessionEarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_0ff8d6_CreditTypeDescriptor2
ON edfi.StudentAcademicRecord (SessionEarnedCreditTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_CreditTypeDescriptor3 FOREIGN KEY (SessionAttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_0ff8d6_CreditTypeDescriptor3
ON edfi.StudentAcademicRecord (SessionAttemptedCreditTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_0ff8d6_EducationOrganization
ON edfi.StudentAcademicRecord (EducationOrganizationId ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_0ff8d6_SchoolYearType
ON edfi.StudentAcademicRecord (SchoolYear ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_0ff8d6_Student
ON edfi.StudentAcademicRecord (StudentUSI ASC);

ALTER TABLE edfi.StudentAcademicRecord ADD CONSTRAINT FK_0ff8d6_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_0ff8d6_TermDescriptor
ON edfi.StudentAcademicRecord (TermDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordAcademicHonor ADD CONSTRAINT FK_2b286a_AcademicHonorCategoryDescriptor FOREIGN KEY (AcademicHonorCategoryDescriptorId)
REFERENCES edfi.AcademicHonorCategoryDescriptor (AcademicHonorCategoryDescriptorId)
;

CREATE INDEX FK_2b286a_AcademicHonorCategoryDescriptor
ON edfi.StudentAcademicRecordAcademicHonor (AcademicHonorCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordAcademicHonor ADD CONSTRAINT FK_2b286a_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

CREATE INDEX FK_2b286a_AchievementCategoryDescriptor
ON edfi.StudentAcademicRecordAcademicHonor (AchievementCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordAcademicHonor ADD CONSTRAINT FK_2b286a_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_2b286a_StudentAcademicRecord
ON edfi.StudentAcademicRecordAcademicHonor (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordClassRanking ADD CONSTRAINT FK_8299aa_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

CREATE INDEX FK_a3f725_AchievementCategoryDescriptor
ON edfi.StudentAcademicRecordDiploma (AchievementCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_DiplomaLevelDescriptor FOREIGN KEY (DiplomaLevelDescriptorId)
REFERENCES edfi.DiplomaLevelDescriptor (DiplomaLevelDescriptorId)
;

CREATE INDEX FK_a3f725_DiplomaLevelDescriptor
ON edfi.StudentAcademicRecordDiploma (DiplomaLevelDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_DiplomaTypeDescriptor FOREIGN KEY (DiplomaTypeDescriptorId)
REFERENCES edfi.DiplomaTypeDescriptor (DiplomaTypeDescriptorId)
;

CREATE INDEX FK_a3f725_DiplomaTypeDescriptor
ON edfi.StudentAcademicRecordDiploma (DiplomaTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordDiploma ADD CONSTRAINT FK_a3f725_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_a3f725_StudentAcademicRecord
ON edfi.StudentAcademicRecordDiploma (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordGradePointAverage ADD CONSTRAINT FK_af7be7_GradePointAverageTypeDescriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.GradePointAverageTypeDescriptor (GradePointAverageTypeDescriptorId)
;

CREATE INDEX FK_af7be7_GradePointAverageTypeDescriptor
ON edfi.StudentAcademicRecordGradePointAverage (GradePointAverageTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordGradePointAverage ADD CONSTRAINT FK_af7be7_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_af7be7_StudentAcademicRecord
ON edfi.StudentAcademicRecordGradePointAverage (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordRecognition ADD CONSTRAINT FK_5e049e_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

CREATE INDEX FK_5e049e_AchievementCategoryDescriptor
ON edfi.StudentAcademicRecordRecognition (AchievementCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordRecognition ADD CONSTRAINT FK_5e049e_RecognitionTypeDescriptor FOREIGN KEY (RecognitionTypeDescriptorId)
REFERENCES edfi.RecognitionTypeDescriptor (RecognitionTypeDescriptorId)
;

CREATE INDEX FK_5e049e_RecognitionTypeDescriptor
ON edfi.StudentAcademicRecordRecognition (RecognitionTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordRecognition ADD CONSTRAINT FK_5e049e_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_5e049e_StudentAcademicRecord
ON edfi.StudentAcademicRecordRecognition (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.StudentAcademicRecordReportCard ADD CONSTRAINT FK_84e5e0_ReportCard FOREIGN KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
REFERENCES edfi.ReportCard (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI)
;

CREATE INDEX FK_84e5e0_ReportCard
ON edfi.StudentAcademicRecordReportCard (EducationOrganizationId ASC, GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAcademicRecordReportCard ADD CONSTRAINT FK_84e5e0_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_84e5e0_StudentAcademicRecord
ON edfi.StudentAcademicRecordReportCard (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_AdministrationEnvironmentDescriptor FOREIGN KEY (AdministrationEnvironmentDescriptorId)
REFERENCES edfi.AdministrationEnvironmentDescriptor (AdministrationEnvironmentDescriptorId)
;

CREATE INDEX FK_ee3b2a_AdministrationEnvironmentDescriptor
ON edfi.StudentAssessment (AdministrationEnvironmentDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
;

CREATE INDEX FK_ee3b2a_Assessment
ON edfi.StudentAssessment (AssessmentIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_EventCircumstanceDescriptor FOREIGN KEY (EventCircumstanceDescriptorId)
REFERENCES edfi.EventCircumstanceDescriptor (EventCircumstanceDescriptorId)
;

CREATE INDEX FK_ee3b2a_EventCircumstanceDescriptor
ON edfi.StudentAssessment (EventCircumstanceDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_GradeLevelDescriptor FOREIGN KEY (WhenAssessedGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_ee3b2a_GradeLevelDescriptor
ON edfi.StudentAssessment (WhenAssessedGradeLevelDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_LanguageDescriptor FOREIGN KEY (AdministrationLanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_ee3b2a_LanguageDescriptor
ON edfi.StudentAssessment (AdministrationLanguageDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_PlatformTypeDescriptor FOREIGN KEY (PlatformTypeDescriptorId)
REFERENCES edfi.PlatformTypeDescriptor (PlatformTypeDescriptorId)
;

CREATE INDEX FK_ee3b2a_PlatformTypeDescriptor
ON edfi.StudentAssessment (PlatformTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_ReasonNotTestedDescriptor FOREIGN KEY (ReasonNotTestedDescriptorId)
REFERENCES edfi.ReasonNotTestedDescriptor (ReasonNotTestedDescriptorId)
;

CREATE INDEX FK_ee3b2a_ReasonNotTestedDescriptor
ON edfi.StudentAssessment (ReasonNotTestedDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_RetestIndicatorDescriptor FOREIGN KEY (RetestIndicatorDescriptorId)
REFERENCES edfi.RetestIndicatorDescriptor (RetestIndicatorDescriptorId)
;

CREATE INDEX FK_ee3b2a_RetestIndicatorDescriptor
ON edfi.StudentAssessment (RetestIndicatorDescriptorId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_School FOREIGN KEY (ReportedSchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_ee3b2a_School
ON edfi.StudentAssessment (ReportedSchoolId ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_ee3b2a_SchoolYearType
ON edfi.StudentAssessment (SchoolYear ASC);

ALTER TABLE edfi.StudentAssessment ADD CONSTRAINT FK_ee3b2a_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_ee3b2a_Student
ON edfi.StudentAssessment (StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentAccommodation ADD CONSTRAINT FK_de959d_AccommodationDescriptor FOREIGN KEY (AccommodationDescriptorId)
REFERENCES edfi.AccommodationDescriptor (AccommodationDescriptorId)
;

CREATE INDEX FK_de959d_AccommodationDescriptor
ON edfi.StudentAssessmentAccommodation (AccommodationDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentAccommodation ADD CONSTRAINT FK_de959d_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_de959d_StudentAssessment
ON edfi.StudentAssessmentAccommodation (AssessmentIdentifier ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_afb8b8_EducationOrganization
ON edfi.StudentAssessmentEducationOrganizationAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_EducationOrganizationAssociationTypeDescriptor FOREIGN KEY (EducationOrganizationAssociationTypeDescriptorId)
REFERENCES edfi.EducationOrganizationAssociationTypeDescriptor (EducationOrganizationAssociationTypeDescriptorId)
;

CREATE INDEX FK_afb8b8_EducationOrganizationAssociationTypeDescriptor
ON edfi.StudentAssessmentEducationOrganizationAssociation (EducationOrganizationAssociationTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_afb8b8_SchoolYearType
ON edfi.StudentAssessmentEducationOrganizationAssociation (SchoolYear ASC);

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD CONSTRAINT FK_afb8b8_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
;

CREATE INDEX FK_afb8b8_StudentAssessment
ON edfi.StudentAssessmentEducationOrganizationAssociation (AssessmentIdentifier ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_AssessmentItem FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.AssessmentItem (AssessmentIdentifier, IdentificationCode, Namespace)
;

CREATE INDEX FK_7f600a_AssessmentItem
ON edfi.StudentAssessmentItem (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_AssessmentItemResultDescriptor FOREIGN KEY (AssessmentItemResultDescriptorId)
REFERENCES edfi.AssessmentItemResultDescriptor (AssessmentItemResultDescriptorId)
;

CREATE INDEX FK_7f600a_AssessmentItemResultDescriptor
ON edfi.StudentAssessmentItem (AssessmentItemResultDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_ResponseIndicatorDescriptor FOREIGN KEY (ResponseIndicatorDescriptorId)
REFERENCES edfi.ResponseIndicatorDescriptor (ResponseIndicatorDescriptorId)
;

CREATE INDEX FK_7f600a_ResponseIndicatorDescriptor
ON edfi.StudentAssessmentItem (ResponseIndicatorDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentItem ADD CONSTRAINT FK_7f600a_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_7f600a_StudentAssessment
ON edfi.StudentAssessmentItem (AssessmentIdentifier ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentPerformanceLevel ADD CONSTRAINT FK_c2bd3c_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_c2bd3c_AssessmentReportingMethodDescriptor
ON edfi.StudentAssessmentPerformanceLevel (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentPerformanceLevel ADD CONSTRAINT FK_c2bd3c_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

CREATE INDEX FK_c2bd3c_PerformanceLevelDescriptor
ON edfi.StudentAssessmentPerformanceLevel (PerformanceLevelDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentPerformanceLevel ADD CONSTRAINT FK_c2bd3c_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_c2bd3c_StudentAssessment
ON edfi.StudentAssessmentPerformanceLevel (AssessmentIdentifier ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentPeriod ADD CONSTRAINT FK_02ddd8_AssessmentPeriodDescriptor FOREIGN KEY (AssessmentPeriodDescriptorId)
REFERENCES edfi.AssessmentPeriodDescriptor (AssessmentPeriodDescriptorId)
;

CREATE INDEX FK_02ddd8_AssessmentPeriodDescriptor
ON edfi.StudentAssessmentPeriod (AssessmentPeriodDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentPeriod ADD CONSTRAINT FK_02ddd8_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentAssessmentScoreResult ADD CONSTRAINT FK_0fceba_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_0fceba_AssessmentReportingMethodDescriptor
ON edfi.StudentAssessmentScoreResult (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentScoreResult ADD CONSTRAINT FK_0fceba_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_0fceba_ResultDatatypeTypeDescriptor
ON edfi.StudentAssessmentScoreResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentScoreResult ADD CONSTRAINT FK_0fceba_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_0fceba_StudentAssessment
ON edfi.StudentAssessmentScoreResult (AssessmentIdentifier ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessment ADD CONSTRAINT FK_b1c52f_ObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace)
REFERENCES edfi.ObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace)
;

CREATE INDEX FK_b1c52f_ObjectiveAssessment
ON edfi.StudentAssessmentStudentObjectiveAssessment (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessment ADD CONSTRAINT FK_b1c52f_StudentAssessment FOREIGN KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessment (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b1c52f_StudentAssessment
ON edfi.StudentAssessmentStudentObjectiveAssessment (AssessmentIdentifier ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_f32347_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_f32347_AssessmentReportingMethodDescriptor
ON edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_f32347_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

CREATE INDEX FK_f32347_PerformanceLevelDescriptor
ON edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel (PerformanceLevelDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ADD CONSTRAINT FK_f32347_StudentAssessmentStudentObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessmentStudentObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_f32347_StudentAssessmentStudentObjectiveAssessment
ON edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ADD CONSTRAINT FK_0c9651_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_0c9651_AssessmentReportingMethodDescriptor
ON edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ADD CONSTRAINT FK_0c9651_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_0c9651_ResultDatatypeTypeDescriptor
ON edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ADD CONSTRAINT FK_0c9651_StudentAssessmentStudentObjectiveAssessment FOREIGN KEY (AssessmentIdentifier, IdentificationCode, Namespace, StudentAssessmentIdentifier, StudentUSI)
REFERENCES edfi.StudentAssessmentStudentObjectiveAssessment (AssessmentIdentifier, IdentificationCode, Namespace, StudentAssessmentIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_0c9651_StudentAssessmentStudentObjectiveAssessment
ON edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult (AssessmentIdentifier ASC, IdentificationCode ASC, Namespace ASC, StudentAssessmentIdentifier ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCharacteristicDescriptor ADD CONSTRAINT FK_359668_Descriptor FOREIGN KEY (StudentCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCohortAssociation ADD CONSTRAINT FK_369ddc_Cohort FOREIGN KEY (CohortIdentifier, EducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
;

CREATE INDEX FK_369ddc_Cohort
ON edfi.StudentCohortAssociation (CohortIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.StudentCohortAssociation ADD CONSTRAINT FK_369ddc_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_369ddc_Student
ON edfi.StudentCohortAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentCohortAssociationSection ADD CONSTRAINT FK_d2362d_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_d2362d_Section
ON edfi.StudentCohortAssociationSection (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.StudentCohortAssociationSection ADD CONSTRAINT FK_d2362d_StudentCohortAssociation FOREIGN KEY (BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentCohortAssociation (BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_d2362d_StudentCohortAssociation
ON edfi.StudentCohortAssociationSection (BeginDate ASC, CohortIdentifier ASC, EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_CompetencyLevelDescriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.CompetencyLevelDescriptor (CompetencyLevelDescriptorId)
;

CREATE INDEX FK_395c07_CompetencyLevelDescriptor
ON edfi.StudentCompetencyObjective (CompetencyLevelDescriptorId ASC);

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_CompetencyObjective FOREIGN KEY (ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId)
REFERENCES edfi.CompetencyObjective (EducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId)
;

CREATE INDEX FK_395c07_CompetencyObjective
ON edfi.StudentCompetencyObjective (ObjectiveEducationOrganizationId ASC, Objective ASC, ObjectiveGradeLevelDescriptorId ASC);

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

CREATE INDEX FK_395c07_GradingPeriod
ON edfi.StudentCompetencyObjective (GradingPeriodDescriptorId ASC, GradingPeriodSequence ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC);

ALTER TABLE edfi.StudentCompetencyObjective ADD CONSTRAINT FK_395c07_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_395c07_Student
ON edfi.StudentCompetencyObjective (StudentUSI ASC);

ALTER TABLE edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation ADD CONSTRAINT FK_005337_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
;

CREATE INDEX FK_005337_GeneralStudentProgramAssociation
ON edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation ADD CONSTRAINT FK_005337_StudentCompetencyObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI)
REFERENCES edfi.StudentCompetencyObjective (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_005337_StudentCompetencyObjective
ON edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation (GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, Objective ASC, ObjectiveEducationOrganizationId ASC, ObjectiveGradeLevelDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCompetencyObjectiveStudentSectionAssociation ADD CONSTRAINT FK_ee68ed_StudentCompetencyObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI)
REFERENCES edfi.StudentCompetencyObjective (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_ee68ed_StudentCompetencyObjective
ON edfi.StudentCompetencyObjectiveStudentSectionAssociation (GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, Objective ASC, ObjectiveEducationOrganizationId ASC, ObjectiveGradeLevelDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCompetencyObjectiveStudentSectionAssociation ADD CONSTRAINT FK_ee68ed_StudentSectionAssociation FOREIGN KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAssociation (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON UPDATE CASCADE
;

CREATE INDEX FK_ee68ed_StudentSectionAssociation
ON edfi.StudentCompetencyObjectiveStudentSectionAssociation (BeginDate ASC, LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCTEProgramAssociation ADD CONSTRAINT FK_000ac5_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentCTEProgramAssociation ADD CONSTRAINT FK_000ac5_TechnicalSkillsAssessmentDescriptor FOREIGN KEY (TechnicalSkillsAssessmentDescriptorId)
REFERENCES edfi.TechnicalSkillsAssessmentDescriptor (TechnicalSkillsAssessmentDescriptorId)
;

CREATE INDEX FK_000ac5_TechnicalSkillsAssessmentDescriptor
ON edfi.StudentCTEProgramAssociation (TechnicalSkillsAssessmentDescriptorId ASC);

ALTER TABLE edfi.StudentCTEProgramAssociationCTEProgram ADD CONSTRAINT FK_ee50f2_CareerPathwayDescriptor FOREIGN KEY (CareerPathwayDescriptorId)
REFERENCES edfi.CareerPathwayDescriptor (CareerPathwayDescriptorId)
;

CREATE INDEX FK_ee50f2_CareerPathwayDescriptor
ON edfi.StudentCTEProgramAssociationCTEProgram (CareerPathwayDescriptorId ASC);

ALTER TABLE edfi.StudentCTEProgramAssociationCTEProgram ADD CONSTRAINT FK_ee50f2_StudentCTEProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentCTEProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_ee50f2_StudentCTEProgramAssociation
ON edfi.StudentCTEProgramAssociationCTEProgram (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCTEProgramAssociationCTEProgramService ADD CONSTRAINT FK_1bab8a_CTEProgramServiceDescriptor FOREIGN KEY (CTEProgramServiceDescriptorId)
REFERENCES edfi.CTEProgramServiceDescriptor (CTEProgramServiceDescriptorId)
;

CREATE INDEX FK_1bab8a_CTEProgramServiceDescriptor
ON edfi.StudentCTEProgramAssociationCTEProgramService (CTEProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentCTEProgramAssociationCTEProgramService ADD CONSTRAINT FK_1bab8a_StudentCTEProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentCTEProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_1bab8a_StudentCTEProgramAssociation
ON edfi.StudentCTEProgramAssociationCTEProgramService (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentCTEProgramAssociationService ADD CONSTRAINT FK_eb5c90_ServiceDescriptor FOREIGN KEY (ServiceDescriptorId)
REFERENCES edfi.ServiceDescriptor (ServiceDescriptorId)
;

CREATE INDEX FK_eb5c90_ServiceDescriptor
ON edfi.StudentCTEProgramAssociationService (ServiceDescriptorId ASC);

ALTER TABLE edfi.StudentCTEProgramAssociationService ADD CONSTRAINT FK_eb5c90_StudentCTEProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentCTEProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_eb5c90_StudentCTEProgramAssociation
ON edfi.StudentCTEProgramAssociationService (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentDisciplineIncidentAssociation ADD CONSTRAINT FK_679174_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
;

CREATE INDEX FK_679174_DisciplineIncident
ON edfi.StudentDisciplineIncidentAssociation (IncidentIdentifier ASC, SchoolId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentAssociation ADD CONSTRAINT FK_679174_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_679174_Student
ON edfi.StudentDisciplineIncidentAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentDisciplineIncidentAssociation ADD CONSTRAINT FK_679174_StudentParticipationCodeDescriptor FOREIGN KEY (StudentParticipationCodeDescriptorId)
REFERENCES edfi.StudentParticipationCodeDescriptor (StudentParticipationCodeDescriptorId)
;

CREATE INDEX FK_679174_StudentParticipationCodeDescriptor
ON edfi.StudentDisciplineIncidentAssociation (StudentParticipationCodeDescriptorId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentAssociationBehavior ADD CONSTRAINT FK_b43eed_BehaviorDescriptor FOREIGN KEY (BehaviorDescriptorId)
REFERENCES edfi.BehaviorDescriptor (BehaviorDescriptorId)
;

CREATE INDEX FK_b43eed_BehaviorDescriptor
ON edfi.StudentDisciplineIncidentAssociationBehavior (BehaviorDescriptorId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentAssociationBehavior ADD CONSTRAINT FK_b43eed_StudentDisciplineIncidentAssociation FOREIGN KEY (IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentAssociation (IncidentIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b43eed_StudentDisciplineIncidentAssociation
ON edfi.StudentDisciplineIncidentAssociationBehavior (IncidentIdentifier ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_f4934f_BehaviorDescriptor FOREIGN KEY (BehaviorDescriptorId)
REFERENCES edfi.BehaviorDescriptor (BehaviorDescriptorId)
;

CREATE INDEX FK_f4934f_BehaviorDescriptor
ON edfi.StudentDisciplineIncidentBehaviorAssociation (BehaviorDescriptorId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_f4934f_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
;

CREATE INDEX FK_f4934f_DisciplineIncident
ON edfi.StudentDisciplineIncidentBehaviorAssociation (IncidentIdentifier ASC, SchoolId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD CONSTRAINT FK_f4934f_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_f4934f_Student
ON edfi.StudentDisciplineIncidentBehaviorAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 ADD CONSTRAINT FK_ae6a21_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

CREATE INDEX FK_ae6a21_DisciplineIncidentParticipationCodeDescriptor
ON edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 (DisciplineIncidentParticipationCodeDescriptorId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 ADD CONSTRAINT FK_ae6a21_StudentDisciplineIncidentBehaviorAssociation FOREIGN KEY (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentBehaviorAssociation (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_ae6a21_StudentDisciplineIncidentBehaviorAssociation
ON edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 (BehaviorDescriptorId ASC, IncidentIdentifier ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD CONSTRAINT FK_4b43da_DisciplineIncident FOREIGN KEY (IncidentIdentifier, SchoolId)
REFERENCES edfi.DisciplineIncident (IncidentIdentifier, SchoolId)
;

CREATE INDEX FK_4b43da_DisciplineIncident
ON edfi.StudentDisciplineIncidentNonOffenderAssociation (IncidentIdentifier ASC, SchoolId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD CONSTRAINT FK_4b43da_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_4b43da_Student
ON edfi.StudentDisciplineIncidentNonOffenderAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a ADD CONSTRAINT FK_4c979a_DisciplineIncidentParticipationCodeDescriptor FOREIGN KEY (DisciplineIncidentParticipationCodeDescriptorId)
REFERENCES edfi.DisciplineIncidentParticipationCodeDescriptor (DisciplineIncidentParticipationCodeDescriptorId)
;

CREATE INDEX FK_4c979a_DisciplineIncidentParticipationCodeDescriptor
ON edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a (DisciplineIncidentParticipationCodeDescriptorId ASC);

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a ADD CONSTRAINT FK_4c979a_StudentDisciplineIncidentNonOffenderAssociation FOREIGN KEY (IncidentIdentifier, SchoolId, StudentUSI)
REFERENCES edfi.StudentDisciplineIncidentNonOffenderAssociation (IncidentIdentifier, SchoolId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_4c979a_StudentDisciplineIncidentNonOffenderAssociation
ON edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a (IncidentIdentifier ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_BarrierToInternetAccessInResidenceDescriptor FOREIGN KEY (BarrierToInternetAccessInResidenceDescriptorId)
REFERENCES edfi.BarrierToInternetAccessInResidenceDescriptor (BarrierToInternetAccessInResidenceDescriptorId)
;

CREATE INDEX FK_8e1257_BarrierToInternetAccessInResidenceDescriptor
ON edfi.StudentEducationOrganizationAssociation (BarrierToInternetAccessInResidenceDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_8e1257_EducationOrganization
ON edfi.StudentEducationOrganizationAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_InternetAccessTypeInResidenceDescriptor FOREIGN KEY (InternetAccessTypeInResidenceDescriptorId)
REFERENCES edfi.InternetAccessTypeInResidenceDescriptor (InternetAccessTypeInResidenceDescriptorId)
;

CREATE INDEX FK_8e1257_InternetAccessTypeInResidenceDescriptor
ON edfi.StudentEducationOrganizationAssociation (InternetAccessTypeInResidenceDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_InternetPerformanceInResidenceDescriptor FOREIGN KEY (InternetPerformanceInResidenceDescriptorId)
REFERENCES edfi.InternetPerformanceInResidenceDescriptor (InternetPerformanceInResidenceDescriptorId)
;

CREATE INDEX FK_8e1257_InternetPerformanceInResidenceDescriptor
ON edfi.StudentEducationOrganizationAssociation (InternetPerformanceInResidenceDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_LimitedEnglishProficiencyDescriptor FOREIGN KEY (LimitedEnglishProficiencyDescriptorId)
REFERENCES edfi.LimitedEnglishProficiencyDescriptor (LimitedEnglishProficiencyDescriptorId)
;

CREATE INDEX FK_8e1257_LimitedEnglishProficiencyDescriptor
ON edfi.StudentEducationOrganizationAssociation (LimitedEnglishProficiencyDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_OldEthnicityDescriptor FOREIGN KEY (OldEthnicityDescriptorId)
REFERENCES edfi.OldEthnicityDescriptor (OldEthnicityDescriptorId)
;

CREATE INDEX FK_8e1257_OldEthnicityDescriptor
ON edfi.StudentEducationOrganizationAssociation (OldEthnicityDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_PrimaryLearningDeviceAccessDescriptor FOREIGN KEY (PrimaryLearningDeviceAccessDescriptorId)
REFERENCES edfi.PrimaryLearningDeviceAccessDescriptor (PrimaryLearningDeviceAccessDescriptorId)
;

CREATE INDEX FK_8e1257_PrimaryLearningDeviceAccessDescriptor
ON edfi.StudentEducationOrganizationAssociation (PrimaryLearningDeviceAccessDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_PrimaryLearningDeviceAwayFromSchoolDescriptor FOREIGN KEY (PrimaryLearningDeviceAwayFromSchoolDescriptorId)
REFERENCES edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor (PrimaryLearningDeviceAwayFromSchoolDescriptorId)
;

CREATE INDEX FK_8e1257_PrimaryLearningDeviceAwayFromSchoolDescriptor
ON edfi.StudentEducationOrganizationAssociation (PrimaryLearningDeviceAwayFromSchoolDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_PrimaryLearningDeviceProviderDescriptor FOREIGN KEY (PrimaryLearningDeviceProviderDescriptorId)
REFERENCES edfi.PrimaryLearningDeviceProviderDescriptor (PrimaryLearningDeviceProviderDescriptorId)
;

CREATE INDEX FK_8e1257_PrimaryLearningDeviceProviderDescriptor
ON edfi.StudentEducationOrganizationAssociation (PrimaryLearningDeviceProviderDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_8e1257_SexDescriptor
ON edfi.StudentEducationOrganizationAssociation (SexDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD CONSTRAINT FK_8e1257_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_8e1257_Student
ON edfi.StudentEducationOrganizationAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_f9e163_AddressTypeDescriptor
ON edfi.StudentEducationOrganizationAssociationAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_f9e163_LocaleDescriptor
ON edfi.StudentEducationOrganizationAssociationAddress (LocaleDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_f9e163_StateAbbreviationDescriptor
ON edfi.StudentEducationOrganizationAssociationAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ADD CONSTRAINT FK_f9e163_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_f9e163_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationAddress (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationAddressPeriod ADD CONSTRAINT FK_9739a2_StudentEducationOrganizationAssociationAddress FOREIGN KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationAddress (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_9739a2_StudentEducationOrganizationAssociationAddress
ON edfi.StudentEducationOrganizationAssociationAddressPeriod (AddressTypeDescriptorId ASC, City ASC, EducationOrganizationId ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin ADD CONSTRAINT FK_2c2b13_AncestryEthnicOriginDescriptor FOREIGN KEY (AncestryEthnicOriginDescriptorId)
REFERENCES edfi.AncestryEthnicOriginDescriptor (AncestryEthnicOriginDescriptorId)
;

CREATE INDEX FK_2c2b13_AncestryEthnicOriginDescriptor
ON edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin (AncestryEthnicOriginDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin ADD CONSTRAINT FK_2c2b13_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_2c2b13_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_CohortYearTypeDescriptor FOREIGN KEY (CohortYearTypeDescriptorId)
REFERENCES edfi.CohortYearTypeDescriptor (CohortYearTypeDescriptorId)
;

CREATE INDEX FK_69dd58_CohortYearTypeDescriptor
ON edfi.StudentEducationOrganizationAssociationCohortYear (CohortYearTypeDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_69dd58_SchoolYearType
ON edfi.StudentEducationOrganizationAssociationCohortYear (SchoolYear ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_69dd58_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationCohortYear (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ADD CONSTRAINT FK_69dd58_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_69dd58_TermDescriptor
ON edfi.StudentEducationOrganizationAssociationCohortYear (TermDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisability ADD CONSTRAINT FK_4ca65b_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_4ca65b_DisabilityDescriptor
ON edfi.StudentEducationOrganizationAssociationDisability (DisabilityDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisability ADD CONSTRAINT FK_4ca65b_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_4ca65b_DisabilityDeterminationSourceTypeDescriptor
ON edfi.StudentEducationOrganizationAssociationDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisability ADD CONSTRAINT FK_4ca65b_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_4ca65b_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationDisability (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisabilityDesignation ADD CONSTRAINT FK_5ee8fd_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_5ee8fd_DisabilityDesignationDescriptor
ON edfi.StudentEducationOrganizationAssociationDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationDisabilityDesignation ADD CONSTRAINT FK_5ee8fd_StudentEducationOrganizationAssociationDisability FOREIGN KEY (DisabilityDescriptorId, EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationDisability (DisabilityDescriptorId, EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_5ee8fd_StudentEducationOrganizationAssociationDisability
ON edfi.StudentEducationOrganizationAssociationDisabilityDesignation (DisabilityDescriptorId ASC, EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationElectronicMail ADD CONSTRAINT FK_582e49_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_582e49_ElectronicMailTypeDescriptor
ON edfi.StudentEducationOrganizationAssociationElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationElectronicMail ADD CONSTRAINT FK_582e49_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_582e49_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationElectronicMail (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress ADD CONSTRAINT FK_a82b93_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_a82b93_AddressTypeDescriptor
ON edfi.StudentEducationOrganizationAssociationInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress ADD CONSTRAINT FK_a82b93_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_a82b93_CountryDescriptor
ON edfi.StudentEducationOrganizationAssociationInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress ADD CONSTRAINT FK_a82b93_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a82b93_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationInternationalAddress (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguage ADD CONSTRAINT FK_2a4725_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_2a4725_LanguageDescriptor
ON edfi.StudentEducationOrganizationAssociationLanguage (LanguageDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguage ADD CONSTRAINT FK_2a4725_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_2a4725_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationLanguage (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguageUse ADD CONSTRAINT FK_2e333a_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_2e333a_LanguageUseDescriptor
ON edfi.StudentEducationOrganizationAssociationLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguageUse ADD CONSTRAINT FK_2e333a_StudentEducationOrganizationAssociationLanguage FOREIGN KEY (EducationOrganizationId, LanguageDescriptorId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationLanguage (EducationOrganizationId, LanguageDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_2e333a_StudentEducationOrganizationAssociationLanguage
ON edfi.StudentEducationOrganizationAssociationLanguageUse (EducationOrganizationId ASC, LanguageDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationProgramParticipat_810575 ADD CONSTRAINT FK_810575_ProgramCharacteristicDescriptor FOREIGN KEY (ProgramCharacteristicDescriptorId)
REFERENCES edfi.ProgramCharacteristicDescriptor (ProgramCharacteristicDescriptorId)
;

CREATE INDEX FK_810575_ProgramCharacteristicDescriptor
ON edfi.StudentEducationOrganizationAssociationProgramParticipat_810575 (ProgramCharacteristicDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationProgramParticipat_810575 ADD CONSTRAINT FK_810575_StudentEducationOrganizationAssociationProgramParticipation FOREIGN KEY (EducationOrganizationId, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationProgramParticipation (EducationOrganizationId, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_810575_StudentEducationOrganizationAssociationProgramParticipation
ON edfi.StudentEducationOrganizationAssociationProgramParticipat_810575 (EducationOrganizationId ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationProgramParticipation ADD CONSTRAINT FK_5c2c98_ProgramTypeDescriptor FOREIGN KEY (ProgramTypeDescriptorId)
REFERENCES edfi.ProgramTypeDescriptor (ProgramTypeDescriptorId)
;

CREATE INDEX FK_5c2c98_ProgramTypeDescriptor
ON edfi.StudentEducationOrganizationAssociationProgramParticipation (ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationProgramParticipation ADD CONSTRAINT FK_5c2c98_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_5c2c98_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationProgramParticipation (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationRace ADD CONSTRAINT FK_a6a1f0_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_a6a1f0_RaceDescriptor
ON edfi.StudentEducationOrganizationAssociationRace (RaceDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationRace ADD CONSTRAINT FK_a6a1f0_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a6a1f0_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationRace (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf ADD CONSTRAINT FK_a18fcf_StudentEducationOrganizationAssociationStudentCharacteristic FOREIGN KEY (EducationOrganizationId, StudentCharacteristicDescriptorId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationStudentCharacteristic (EducationOrganizationId, StudentCharacteristicDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a18fcf_StudentEducationOrganizationAssociationStudentCharacteristic
ON edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf (EducationOrganizationId ASC, StudentCharacteristicDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteristic ADD CONSTRAINT FK_b865d7_StudentCharacteristicDescriptor FOREIGN KEY (StudentCharacteristicDescriptorId)
REFERENCES edfi.StudentCharacteristicDescriptor (StudentCharacteristicDescriptorId)
;

CREATE INDEX FK_b865d7_StudentCharacteristicDescriptor
ON edfi.StudentEducationOrganizationAssociationStudentCharacteristic (StudentCharacteristicDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteristic ADD CONSTRAINT FK_b865d7_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b865d7_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationStudentCharacteristic (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 ADD CONSTRAINT FK_c15030_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_c15030_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 ADD CONSTRAINT FK_c15030_StudentIdentificationSystemDescriptor FOREIGN KEY (StudentIdentificationSystemDescriptorId)
REFERENCES edfi.StudentIdentificationSystemDescriptor (StudentIdentificationSystemDescriptorId)
;

CREATE INDEX FK_c15030_StudentIdentificationSystemDescriptor
ON edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 (StudentIdentificationSystemDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIndicator ADD CONSTRAINT FK_ca697a_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_ca697a_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationStudentIndicator (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod ADD CONSTRAINT FK_a61b72_StudentEducationOrganizationAssociationStudentIndicator FOREIGN KEY (EducationOrganizationId, IndicatorName, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationStudentIndicator (EducationOrganizationId, IndicatorName, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a61b72_StudentEducationOrganizationAssociationStudentIndicator
ON edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod (EducationOrganizationId ASC, IndicatorName ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationTelephone ADD CONSTRAINT FK_a2d4a8_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a2d4a8_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationTelephone (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationTelephone ADD CONSTRAINT FK_a2d4a8_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_a2d4a8_TelephoneNumberTypeDescriptor
ON edfi.StudentEducationOrganizationAssociationTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationTribalAffiliation ADD CONSTRAINT FK_0628e0_StudentEducationOrganizationAssociation FOREIGN KEY (EducationOrganizationId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociation (EducationOrganizationId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_0628e0_StudentEducationOrganizationAssociation
ON edfi.StudentEducationOrganizationAssociationTribalAffiliation (EducationOrganizationId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentEducationOrganizationAssociationTribalAffiliation ADD CONSTRAINT FK_0628e0_TribalAffiliationDescriptor FOREIGN KEY (TribalAffiliationDescriptorId)
REFERENCES edfi.TribalAffiliationDescriptor (TribalAffiliationDescriptorId)
;

CREATE INDEX FK_0628e0_TribalAffiliationDescriptor
ON edfi.StudentEducationOrganizationAssociationTribalAffiliation (TribalAffiliationDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD CONSTRAINT FK_42aa64_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_42aa64_EducationOrganization
ON edfi.StudentEducationOrganizationResponsibilityAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD CONSTRAINT FK_42aa64_ResponsibilityDescriptor FOREIGN KEY (ResponsibilityDescriptorId)
REFERENCES edfi.ResponsibilityDescriptor (ResponsibilityDescriptorId)
;

CREATE INDEX FK_42aa64_ResponsibilityDescriptor
ON edfi.StudentEducationOrganizationResponsibilityAssociation (ResponsibilityDescriptorId ASC);

ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD CONSTRAINT FK_42aa64_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_42aa64_Student
ON edfi.StudentEducationOrganizationResponsibilityAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_AssignmentLateStatusDescriptor FOREIGN KEY (AssignmentLateStatusDescriptorId)
REFERENCES edfi.AssignmentLateStatusDescriptor (AssignmentLateStatusDescriptorId)
;

CREATE INDEX FK_c2efaa_AssignmentLateStatusDescriptor
ON edfi.StudentGradebookEntry (AssignmentLateStatusDescriptorId ASC);

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_CompetencyLevelDescriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.CompetencyLevelDescriptor (CompetencyLevelDescriptorId)
;

CREATE INDEX FK_c2efaa_CompetencyLevelDescriptor
ON edfi.StudentGradebookEntry (CompetencyLevelDescriptorId ASC);

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_GradebookEntry FOREIGN KEY (GradebookEntryIdentifier, Namespace)
REFERENCES edfi.GradebookEntry (GradebookEntryIdentifier, Namespace)
ON UPDATE CASCADE
;

CREATE INDEX FK_c2efaa_GradebookEntry
ON edfi.StudentGradebookEntry (GradebookEntryIdentifier ASC, Namespace ASC);

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_c2efaa_Student
ON edfi.StudentGradebookEntry (StudentUSI ASC);

ALTER TABLE edfi.StudentGradebookEntry ADD CONSTRAINT FK_c2efaa_SubmissionStatusDescriptor FOREIGN KEY (SubmissionStatusDescriptorId)
REFERENCES edfi.SubmissionStatusDescriptor (SubmissionStatusDescriptorId)
;

CREATE INDEX FK_c2efaa_SubmissionStatusDescriptor
ON edfi.StudentGradebookEntry (SubmissionStatusDescriptorId ASC);

ALTER TABLE edfi.StudentHomelessProgramAssociation ADD CONSTRAINT FK_a50f80_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentHomelessProgramAssociation ADD CONSTRAINT FK_a50f80_HomelessPrimaryNighttimeResidenceDescriptor FOREIGN KEY (HomelessPrimaryNighttimeResidenceDescriptorId)
REFERENCES edfi.HomelessPrimaryNighttimeResidenceDescriptor (HomelessPrimaryNighttimeResidenceDescriptorId)
;

CREATE INDEX FK_a50f80_HomelessPrimaryNighttimeResidenceDescriptor
ON edfi.StudentHomelessProgramAssociation (HomelessPrimaryNighttimeResidenceDescriptorId ASC);

ALTER TABLE edfi.StudentHomelessProgramAssociationHomelessProgramService ADD CONSTRAINT FK_b31a96_HomelessProgramServiceDescriptor FOREIGN KEY (HomelessProgramServiceDescriptorId)
REFERENCES edfi.HomelessProgramServiceDescriptor (HomelessProgramServiceDescriptorId)
;

CREATE INDEX FK_b31a96_HomelessProgramServiceDescriptor
ON edfi.StudentHomelessProgramAssociationHomelessProgramService (HomelessProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentHomelessProgramAssociationHomelessProgramService ADD CONSTRAINT FK_b31a96_StudentHomelessProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentHomelessProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b31a96_StudentHomelessProgramAssociation
ON edfi.StudentHomelessProgramAssociationHomelessProgramService (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_2d57be_CountryDescriptor
ON edfi.StudentIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_2d57be_IdentificationDocumentUseDescriptor
ON edfi.StudentIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_2d57be_PersonalInformationVerificationDescriptor
ON edfi.StudentIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE edfi.StudentIdentificationDocument ADD CONSTRAINT FK_2d57be_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_2d57be_Student
ON edfi.StudentIdentificationDocument (StudentUSI ASC);

ALTER TABLE edfi.StudentIdentificationSystemDescriptor ADD CONSTRAINT FK_a28cb4_Descriptor FOREIGN KEY (StudentIdentificationSystemDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentInterventionAssociation ADD CONSTRAINT FK_25cb9c_Cohort FOREIGN KEY (CohortIdentifier, CohortEducationOrganizationId)
REFERENCES edfi.Cohort (CohortIdentifier, EducationOrganizationId)
;

CREATE INDEX FK_25cb9c_Cohort
ON edfi.StudentInterventionAssociation (CohortIdentifier ASC, CohortEducationOrganizationId ASC);

ALTER TABLE edfi.StudentInterventionAssociation ADD CONSTRAINT FK_25cb9c_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
;

CREATE INDEX FK_25cb9c_Intervention
ON edfi.StudentInterventionAssociation (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.StudentInterventionAssociation ADD CONSTRAINT FK_25cb9c_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_25cb9c_Student
ON edfi.StudentInterventionAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_DiagnosisDescriptor FOREIGN KEY (DiagnosisDescriptorId)
REFERENCES edfi.DiagnosisDescriptor (DiagnosisDescriptorId)
;

CREATE INDEX FK_29e870_DiagnosisDescriptor
ON edfi.StudentInterventionAssociationInterventionEffectiveness (DiagnosisDescriptorId ASC);

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_29e870_GradeLevelDescriptor
ON edfi.StudentInterventionAssociationInterventionEffectiveness (GradeLevelDescriptorId ASC);

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_InterventionEffectivenessRatingDescriptor FOREIGN KEY (InterventionEffectivenessRatingDescriptorId)
REFERENCES edfi.InterventionEffectivenessRatingDescriptor (InterventionEffectivenessRatingDescriptorId)
;

CREATE INDEX FK_29e870_InterventionEffectivenessRatingDescriptor
ON edfi.StudentInterventionAssociationInterventionEffectiveness (InterventionEffectivenessRatingDescriptorId ASC);

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_29e870_PopulationServedDescriptor
ON edfi.StudentInterventionAssociationInterventionEffectiveness (PopulationServedDescriptorId ASC);

ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ADD CONSTRAINT FK_29e870_StudentInterventionAssociation FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode, StudentUSI)
REFERENCES edfi.StudentInterventionAssociation (EducationOrganizationId, InterventionIdentificationCode, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_29e870_StudentInterventionAssociation
ON edfi.StudentInterventionAssociationInterventionEffectiveness (EducationOrganizationId ASC, InterventionIdentificationCode ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

CREATE INDEX FK_631023_AttendanceEventCategoryDescriptor
ON edfi.StudentInterventionAttendanceEvent (AttendanceEventCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

CREATE INDEX FK_631023_EducationalEnvironmentDescriptor
ON edfi.StudentInterventionAttendanceEvent (EducationalEnvironmentDescriptorId ASC);

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_Intervention FOREIGN KEY (EducationOrganizationId, InterventionIdentificationCode)
REFERENCES edfi.Intervention (EducationOrganizationId, InterventionIdentificationCode)
;

CREATE INDEX FK_631023_Intervention
ON edfi.StudentInterventionAttendanceEvent (EducationOrganizationId ASC, InterventionIdentificationCode ASC);

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD CONSTRAINT FK_631023_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_631023_Student
ON edfi.StudentInterventionAttendanceEvent (StudentUSI ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociation ADD CONSTRAINT FK_92de5d_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_MonitoredDescriptor FOREIGN KEY (MonitoredDescriptorId)
REFERENCES edfi.MonitoredDescriptor (MonitoredDescriptorId)
;

CREATE INDEX FK_1ac620_MonitoredDescriptor
ON edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 (MonitoredDescriptorId ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_ParticipationDescriptor FOREIGN KEY (ParticipationDescriptorId)
REFERENCES edfi.ParticipationDescriptor (ParticipationDescriptorId)
;

CREATE INDEX FK_1ac620_ParticipationDescriptor
ON edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 (ParticipationDescriptorId ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_ProficiencyDescriptor FOREIGN KEY (ProficiencyDescriptorId)
REFERENCES edfi.ProficiencyDescriptor (ProficiencyDescriptorId)
;

CREATE INDEX FK_1ac620_ProficiencyDescriptor
ON edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 (ProficiencyDescriptorId ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_ProgressDescriptor FOREIGN KEY (ProgressDescriptorId)
REFERENCES edfi.ProgressDescriptor (ProgressDescriptorId)
;

CREATE INDEX FK_1ac620_ProgressDescriptor
ON edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 (ProgressDescriptorId ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_1ac620_SchoolYearType
ON edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 (SchoolYear ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ADD CONSTRAINT FK_1ac620_StudentLanguageInstructionProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentLanguageInstructionProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_1ac620_StudentLanguageInstructionProgramAssociation
ON edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 ADD CONSTRAINT FK_268e07_LanguageInstructionProgramServiceDescriptor FOREIGN KEY (LanguageInstructionProgramServiceDescriptorId)
REFERENCES edfi.LanguageInstructionProgramServiceDescriptor (LanguageInstructionProgramServiceDescriptorId)
;

CREATE INDEX FK_268e07_LanguageInstructionProgramServiceDescriptor
ON edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 (LanguageInstructionProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 ADD CONSTRAINT FK_268e07_StudentLanguageInstructionProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentLanguageInstructionProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_268e07_StudentLanguageInstructionProgramAssociation
ON edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentLearningObjective ADD CONSTRAINT FK_baaa9d_CompetencyLevelDescriptor FOREIGN KEY (CompetencyLevelDescriptorId)
REFERENCES edfi.CompetencyLevelDescriptor (CompetencyLevelDescriptorId)
;

CREATE INDEX FK_baaa9d_CompetencyLevelDescriptor
ON edfi.StudentLearningObjective (CompetencyLevelDescriptorId ASC);

ALTER TABLE edfi.StudentLearningObjective ADD CONSTRAINT FK_baaa9d_GradingPeriod FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSequence, GradingPeriodSchoolId, GradingPeriodSchoolYear)
REFERENCES edfi.GradingPeriod (GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear)
;

CREATE INDEX FK_baaa9d_GradingPeriod
ON edfi.StudentLearningObjective (GradingPeriodDescriptorId ASC, GradingPeriodSequence ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC);

ALTER TABLE edfi.StudentLearningObjective ADD CONSTRAINT FK_baaa9d_LearningObjective FOREIGN KEY (LearningObjectiveId, Namespace)
REFERENCES edfi.LearningObjective (LearningObjectiveId, Namespace)
;

CREATE INDEX FK_baaa9d_LearningObjective
ON edfi.StudentLearningObjective (LearningObjectiveId ASC, Namespace ASC);

ALTER TABLE edfi.StudentLearningObjective ADD CONSTRAINT FK_baaa9d_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_baaa9d_Student
ON edfi.StudentLearningObjective (StudentUSI ASC);

ALTER TABLE edfi.StudentLearningObjectiveGeneralStudentProgramAssociation ADD CONSTRAINT FK_1c30e0_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
;

CREATE INDEX FK_1c30e0_GeneralStudentProgramAssociation
ON edfi.StudentLearningObjectiveGeneralStudentProgramAssociation (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentLearningObjectiveGeneralStudentProgramAssociation ADD CONSTRAINT FK_1c30e0_StudentLearningObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI)
REFERENCES edfi.StudentLearningObjective (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_1c30e0_StudentLearningObjective
ON edfi.StudentLearningObjectiveGeneralStudentProgramAssociation (GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, LearningObjectiveId ASC, Namespace ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentLearningObjectiveStudentSectionAssociation ADD CONSTRAINT FK_d2c8a9_StudentLearningObjective FOREIGN KEY (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI)
REFERENCES edfi.StudentLearningObjective (GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_d2c8a9_StudentLearningObjective
ON edfi.StudentLearningObjectiveStudentSectionAssociation (GradingPeriodDescriptorId ASC, GradingPeriodSchoolId ASC, GradingPeriodSchoolYear ASC, GradingPeriodSequence ASC, LearningObjectiveId ASC, Namespace ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentLearningObjectiveStudentSectionAssociation ADD CONSTRAINT FK_d2c8a9_StudentSectionAssociation FOREIGN KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAssociation (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON UPDATE CASCADE
;

CREATE INDEX FK_d2c8a9_StudentSectionAssociation
ON edfi.StudentLearningObjectiveStudentSectionAssociation (BeginDate ASC, LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentMigrantEducationProgramAssociation ADD CONSTRAINT FK_85e741_ContinuationOfServicesReasonDescriptor FOREIGN KEY (ContinuationOfServicesReasonDescriptorId)
REFERENCES edfi.ContinuationOfServicesReasonDescriptor (ContinuationOfServicesReasonDescriptorId)
;

CREATE INDEX FK_85e741_ContinuationOfServicesReasonDescriptor
ON edfi.StudentMigrantEducationProgramAssociation (ContinuationOfServicesReasonDescriptorId ASC);

ALTER TABLE edfi.StudentMigrantEducationProgramAssociation ADD CONSTRAINT FK_85e741_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 ADD CONSTRAINT FK_d9dcd7_MigrantEducationProgramServiceDescriptor FOREIGN KEY (MigrantEducationProgramServiceDescriptorId)
REFERENCES edfi.MigrantEducationProgramServiceDescriptor (MigrantEducationProgramServiceDescriptorId)
;

CREATE INDEX FK_d9dcd7_MigrantEducationProgramServiceDescriptor
ON edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 (MigrantEducationProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 ADD CONSTRAINT FK_d9dcd7_StudentMigrantEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentMigrantEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_d9dcd7_StudentMigrantEducationProgramAssociation
ON edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_NeglectedOrDelinquentProgramDescriptor FOREIGN KEY (NeglectedOrDelinquentProgramDescriptorId)
REFERENCES edfi.NeglectedOrDelinquentProgramDescriptor (NeglectedOrDelinquentProgramDescriptorId)
;

CREATE INDEX FK_678d65_NeglectedOrDelinquentProgramDescriptor
ON edfi.StudentNeglectedOrDelinquentProgramAssociation (NeglectedOrDelinquentProgramDescriptorId ASC);

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_ProgressLevelDescriptor FOREIGN KEY (ELAProgressLevelDescriptorId)
REFERENCES edfi.ProgressLevelDescriptor (ProgressLevelDescriptorId)
;

CREATE INDEX FK_678d65_ProgressLevelDescriptor
ON edfi.StudentNeglectedOrDelinquentProgramAssociation (ELAProgressLevelDescriptorId ASC);

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation ADD CONSTRAINT FK_678d65_ProgressLevelDescriptor1 FOREIGN KEY (MathematicsProgressLevelDescriptorId)
REFERENCES edfi.ProgressLevelDescriptor (ProgressLevelDescriptorId)
;

CREATE INDEX FK_678d65_ProgressLevelDescriptor1
ON edfi.StudentNeglectedOrDelinquentProgramAssociation (MathematicsProgressLevelDescriptorId ASC);

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 ADD CONSTRAINT FK_520251_NeglectedOrDelinquentProgramServiceDescriptor FOREIGN KEY (NeglectedOrDelinquentProgramServiceDescriptorId)
REFERENCES edfi.NeglectedOrDelinquentProgramServiceDescriptor (NeglectedOrDelinquentProgramServiceDescriptorId)
;

CREATE INDEX FK_520251_NeglectedOrDelinquentProgramServiceDescriptor
ON edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 (NeglectedOrDelinquentProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 ADD CONSTRAINT FK_520251_StudentNeglectedOrDelinquentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentNeglectedOrDelinquentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_520251_StudentNeglectedOrDelinquentProgramAssociation
ON edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentOtherName ADD CONSTRAINT FK_ae53d1_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

CREATE INDEX FK_ae53d1_OtherNameTypeDescriptor
ON edfi.StudentOtherName (OtherNameTypeDescriptorId ASC);

ALTER TABLE edfi.StudentOtherName ADD CONSTRAINT FK_ae53d1_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_ae53d1_Student
ON edfi.StudentOtherName (StudentUSI ASC);

ALTER TABLE edfi.StudentParentAssociation ADD CONSTRAINT FK_bf9d92_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
;

CREATE INDEX FK_bf9d92_Parent
ON edfi.StudentParentAssociation (ParentUSI ASC);

ALTER TABLE edfi.StudentParentAssociation ADD CONSTRAINT FK_bf9d92_RelationDescriptor FOREIGN KEY (RelationDescriptorId)
REFERENCES edfi.RelationDescriptor (RelationDescriptorId)
;

CREATE INDEX FK_bf9d92_RelationDescriptor
ON edfi.StudentParentAssociation (RelationDescriptorId ASC);

ALTER TABLE edfi.StudentParentAssociation ADD CONSTRAINT FK_bf9d92_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_bf9d92_Student
ON edfi.StudentParentAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentParticipationCodeDescriptor ADD CONSTRAINT FK_aa25ae_Descriptor FOREIGN KEY (StudentParticipationCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_a741a8_CountryDescriptor
ON edfi.StudentPersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_a741a8_IdentificationDocumentUseDescriptor
ON edfi.StudentPersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_a741a8_PersonalInformationVerificationDescriptor
ON edfi.StudentPersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE edfi.StudentPersonalIdentificationDocument ADD CONSTRAINT FK_a741a8_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a741a8_Student
ON edfi.StudentPersonalIdentificationDocument (StudentUSI ASC);

ALTER TABLE edfi.StudentProgramAssociation ADD CONSTRAINT FK_729018_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentProgramAssociationService ADD CONSTRAINT FK_69cd6f_ServiceDescriptor FOREIGN KEY (ServiceDescriptorId)
REFERENCES edfi.ServiceDescriptor (ServiceDescriptorId)
;

CREATE INDEX FK_69cd6f_ServiceDescriptor
ON edfi.StudentProgramAssociationService (ServiceDescriptorId ASC);

ALTER TABLE edfi.StudentProgramAssociationService ADD CONSTRAINT FK_69cd6f_StudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_69cd6f_StudentProgramAssociation
ON edfi.StudentProgramAssociationService (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

CREATE INDEX FK_317aeb_AttendanceEventCategoryDescriptor
ON edfi.StudentProgramAttendanceEvent (AttendanceEventCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

CREATE INDEX FK_317aeb_EducationalEnvironmentDescriptor
ON edfi.StudentProgramAttendanceEvent (EducationalEnvironmentDescriptorId ASC);

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_317aeb_EducationOrganization
ON edfi.StudentProgramAttendanceEvent (EducationOrganizationId ASC);

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_Program FOREIGN KEY (ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_317aeb_Program
ON edfi.StudentProgramAttendanceEvent (ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD CONSTRAINT FK_317aeb_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_317aeb_Student
ON edfi.StudentProgramAttendanceEvent (StudentUSI ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_Calendar FOREIGN KEY (CalendarCode, SchoolId, SchoolYear)
REFERENCES edfi.Calendar (CalendarCode, SchoolId, SchoolYear)
;

CREATE INDEX FK_857b52_Calendar
ON edfi.StudentSchoolAssociation (CalendarCode ASC, SchoolId ASC, SchoolYear ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_EnrollmentTypeDescriptor FOREIGN KEY (EnrollmentTypeDescriptorId)
REFERENCES edfi.EnrollmentTypeDescriptor (EnrollmentTypeDescriptorId)
;

CREATE INDEX FK_857b52_EnrollmentTypeDescriptor
ON edfi.StudentSchoolAssociation (EnrollmentTypeDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_EntryGradeLevelReasonDescriptor FOREIGN KEY (EntryGradeLevelReasonDescriptorId)
REFERENCES edfi.EntryGradeLevelReasonDescriptor (EntryGradeLevelReasonDescriptorId)
;

CREATE INDEX FK_857b52_EntryGradeLevelReasonDescriptor
ON edfi.StudentSchoolAssociation (EntryGradeLevelReasonDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_EntryTypeDescriptor FOREIGN KEY (EntryTypeDescriptorId)
REFERENCES edfi.EntryTypeDescriptor (EntryTypeDescriptorId)
;

CREATE INDEX FK_857b52_EntryTypeDescriptor
ON edfi.StudentSchoolAssociation (EntryTypeDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_ExitWithdrawTypeDescriptor FOREIGN KEY (ExitWithdrawTypeDescriptorId)
REFERENCES edfi.ExitWithdrawTypeDescriptor (ExitWithdrawTypeDescriptorId)
;

CREATE INDEX FK_857b52_ExitWithdrawTypeDescriptor
ON edfi.StudentSchoolAssociation (ExitWithdrawTypeDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_GradeLevelDescriptor FOREIGN KEY (EntryGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_857b52_GradeLevelDescriptor
ON edfi.StudentSchoolAssociation (EntryGradeLevelDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_GradeLevelDescriptor1 FOREIGN KEY (NextYearGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_857b52_GradeLevelDescriptor1
ON edfi.StudentSchoolAssociation (NextYearGradeLevelDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
;

CREATE INDEX FK_857b52_GraduationPlan
ON edfi.StudentSchoolAssociation (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_ResidencyStatusDescriptor FOREIGN KEY (ResidencyStatusDescriptorId)
REFERENCES edfi.ResidencyStatusDescriptor (ResidencyStatusDescriptorId)
;

CREATE INDEX FK_857b52_ResidencyStatusDescriptor
ON edfi.StudentSchoolAssociation (ResidencyStatusDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_857b52_School
ON edfi.StudentSchoolAssociation (SchoolId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_School1 FOREIGN KEY (NextYearSchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_857b52_School1
ON edfi.StudentSchoolAssociation (NextYearSchoolId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_SchoolChoiceBasisDescriptor FOREIGN KEY (SchoolChoiceBasisDescriptorId)
REFERENCES edfi.SchoolChoiceBasisDescriptor (SchoolChoiceBasisDescriptorId)
;

CREATE INDEX FK_857b52_SchoolChoiceBasisDescriptor
ON edfi.StudentSchoolAssociation (SchoolChoiceBasisDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_857b52_SchoolYearType
ON edfi.StudentSchoolAssociation (SchoolYear ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_SchoolYearType1 FOREIGN KEY (ClassOfSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_857b52_SchoolYearType1
ON edfi.StudentSchoolAssociation (ClassOfSchoolYear ASC);

ALTER TABLE edfi.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_857b52_Student
ON edfi.StudentSchoolAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentSchoolAssociationAlternativeGraduationPlan ADD CONSTRAINT FK_70e978_GraduationPlan FOREIGN KEY (AlternativeEducationOrganizationId, AlternativeGraduationPlanTypeDescriptorId, AlternativeGraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
;

CREATE INDEX FK_70e978_GraduationPlan
ON edfi.StudentSchoolAssociationAlternativeGraduationPlan (AlternativeEducationOrganizationId ASC, AlternativeGraduationPlanTypeDescriptorId ASC, AlternativeGraduationSchoolYear ASC);

ALTER TABLE edfi.StudentSchoolAssociationAlternativeGraduationPlan ADD CONSTRAINT FK_70e978_StudentSchoolAssociation FOREIGN KEY (EntryDate, SchoolId, StudentUSI)
REFERENCES edfi.StudentSchoolAssociation (EntryDate, SchoolId, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_70e978_StudentSchoolAssociation
ON edfi.StudentSchoolAssociationAlternativeGraduationPlan (EntryDate ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSchoolAssociationEducationPlan ADD CONSTRAINT FK_f5b9f6_EducationPlanDescriptor FOREIGN KEY (EducationPlanDescriptorId)
REFERENCES edfi.EducationPlanDescriptor (EducationPlanDescriptorId)
;

CREATE INDEX FK_f5b9f6_EducationPlanDescriptor
ON edfi.StudentSchoolAssociationEducationPlan (EducationPlanDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAssociationEducationPlan ADD CONSTRAINT FK_f5b9f6_StudentSchoolAssociation FOREIGN KEY (EntryDate, SchoolId, StudentUSI)
REFERENCES edfi.StudentSchoolAssociation (EntryDate, SchoolId, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_f5b9f6_StudentSchoolAssociation
ON edfi.StudentSchoolAssociationEducationPlan (EntryDate ASC, SchoolId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

CREATE INDEX FK_78fd7f_AttendanceEventCategoryDescriptor
ON edfi.StudentSchoolAttendanceEvent (AttendanceEventCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

CREATE INDEX FK_78fd7f_EducationalEnvironmentDescriptor
ON edfi.StudentSchoolAttendanceEvent (EducationalEnvironmentDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_78fd7f_School
ON edfi.StudentSchoolAttendanceEvent (SchoolId ASC);

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_78fd7f_Session
ON edfi.StudentSchoolAttendanceEvent (SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD CONSTRAINT FK_78fd7f_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_78fd7f_Student
ON edfi.StudentSchoolAttendanceEvent (StudentUSI ASC);

ALTER TABLE edfi.StudentSchoolFoodServiceProgramAssociation ADD CONSTRAINT FK_82e1e5_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb ADD CONSTRAINT FK_85a0eb_SchoolFoodServiceProgramServiceDescriptor FOREIGN KEY (SchoolFoodServiceProgramServiceDescriptorId)
REFERENCES edfi.SchoolFoodServiceProgramServiceDescriptor (SchoolFoodServiceProgramServiceDescriptorId)
;

CREATE INDEX FK_85a0eb_SchoolFoodServiceProgramServiceDescriptor
ON edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb (SchoolFoodServiceProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb ADD CONSTRAINT FK_85a0eb_StudentSchoolFoodServiceProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSchoolFoodServiceProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_85a0eb_StudentSchoolFoodServiceProgramAssociation
ON edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_AttemptStatusDescriptor FOREIGN KEY (AttemptStatusDescriptorId)
REFERENCES edfi.AttemptStatusDescriptor (AttemptStatusDescriptorId)
;

CREATE INDEX FK_39aa3c_AttemptStatusDescriptor
ON edfi.StudentSectionAssociation (AttemptStatusDescriptorId ASC);

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_RepeatIdentifierDescriptor FOREIGN KEY (RepeatIdentifierDescriptorId)
REFERENCES edfi.RepeatIdentifierDescriptor (RepeatIdentifierDescriptorId)
;

CREATE INDEX FK_39aa3c_RepeatIdentifierDescriptor
ON edfi.StudentSectionAssociation (RepeatIdentifierDescriptorId ASC);

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_39aa3c_Section
ON edfi.StudentSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.StudentSectionAssociation ADD CONSTRAINT FK_39aa3c_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_39aa3c_Student
ON edfi.StudentSectionAssociation (StudentUSI ASC);

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

CREATE INDEX FK_61b087_AttendanceEventCategoryDescriptor
ON edfi.StudentSectionAttendanceEvent (AttendanceEventCategoryDescriptorId ASC);

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_EducationalEnvironmentDescriptor FOREIGN KEY (EducationalEnvironmentDescriptorId)
REFERENCES edfi.EducationalEnvironmentDescriptor (EducationalEnvironmentDescriptorId)
;

CREATE INDEX FK_61b087_EducationalEnvironmentDescriptor
ON edfi.StudentSectionAttendanceEvent (EducationalEnvironmentDescriptorId ASC);

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_61b087_Section
ON edfi.StudentSectionAttendanceEvent (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD CONSTRAINT FK_61b087_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_61b087_Student
ON edfi.StudentSectionAttendanceEvent (StudentUSI ASC);

ALTER TABLE edfi.StudentSectionAttendanceEventClassPeriod ADD CONSTRAINT FK_80c6c1_ClassPeriod FOREIGN KEY (ClassPeriodName, SchoolId)
REFERENCES edfi.ClassPeriod (ClassPeriodName, SchoolId)
ON UPDATE CASCADE
;

CREATE INDEX FK_80c6c1_ClassPeriod
ON edfi.StudentSectionAttendanceEventClassPeriod (ClassPeriodName ASC, SchoolId ASC);

ALTER TABLE edfi.StudentSectionAttendanceEventClassPeriod ADD CONSTRAINT FK_80c6c1_StudentSectionAttendanceEvent FOREIGN KEY (AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAttendanceEvent (AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_80c6c1_StudentSectionAttendanceEvent
ON edfi.StudentSectionAttendanceEventClassPeriod (AttendanceEventCategoryDescriptorId ASC, EventDate ASC, LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociation ADD CONSTRAINT FK_f86fd9_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentSpecialEducationProgramAssociation ADD CONSTRAINT FK_f86fd9_SpecialEducationSettingDescriptor FOREIGN KEY (SpecialEducationSettingDescriptorId)
REFERENCES edfi.SpecialEducationSettingDescriptor (SpecialEducationSettingDescriptorId)
;

CREATE INDEX FK_f86fd9_SpecialEducationSettingDescriptor
ON edfi.StudentSpecialEducationProgramAssociation (SpecialEducationSettingDescriptorId ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisability ADD CONSTRAINT FK_32920f_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_32920f_DisabilityDescriptor
ON edfi.StudentSpecialEducationProgramAssociationDisability (DisabilityDescriptorId ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisability ADD CONSTRAINT FK_32920f_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_32920f_DisabilityDeterminationSourceTypeDescriptor
ON edfi.StudentSpecialEducationProgramAssociationDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisability ADD CONSTRAINT FK_32920f_StudentSpecialEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_32920f_StudentSpecialEducationProgramAssociation
ON edfi.StudentSpecialEducationProgramAssociationDisability (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation ADD CONSTRAINT FK_a2fd20_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_a2fd20_DisabilityDesignationDescriptor
ON edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation ADD CONSTRAINT FK_a2fd20_StudentSpecialEducationProgramAssociationDisability FOREIGN KEY (BeginDate, DisabilityDescriptorId, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociationDisability (BeginDate, DisabilityDescriptorId, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a2fd20_StudentSpecialEducationProgramAssociationDisability
ON edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation (BeginDate ASC, DisabilityDescriptorId ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationServiceProvider ADD CONSTRAINT FK_fece89_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_fece89_Staff
ON edfi.StudentSpecialEducationProgramAssociationServiceProvider (StaffUSI ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationServiceProvider ADD CONSTRAINT FK_fece89_StudentSpecialEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_fece89_StudentSpecialEducationProgramAssociation
ON edfi.StudentSpecialEducationProgramAssociationServiceProvider (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 ADD CONSTRAINT FK_a51ff9_SpecialEducationProgramServiceDescriptor FOREIGN KEY (SpecialEducationProgramServiceDescriptorId)
REFERENCES edfi.SpecialEducationProgramServiceDescriptor (SpecialEducationProgramServiceDescriptorId)
;

CREATE INDEX FK_a51ff9_SpecialEducationProgramServiceDescriptor
ON edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 (SpecialEducationProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 ADD CONSTRAINT FK_a51ff9_StudentSpecialEducationProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a51ff9_StudentSpecialEducationProgramAssociation
ON edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c ADD CONSTRAINT FK_bcba5c_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_bcba5c_Staff
ON edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c (StaffUSI ASC);

ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c ADD CONSTRAINT FK_bcba5c_StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, SpecialEducationProgramServiceDescriptorId, StudentUSI)
REFERENCES edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, SpecialEducationProgramServiceDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_bcba5c_StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9
ON edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, SpecialEducationProgramServiceDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentTitleIPartAProgramAssociation ADD CONSTRAINT FK_27d914_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE edfi.StudentTitleIPartAProgramAssociation ADD CONSTRAINT FK_27d914_TitleIPartAParticipantDescriptor FOREIGN KEY (TitleIPartAParticipantDescriptorId)
REFERENCES edfi.TitleIPartAParticipantDescriptor (TitleIPartAParticipantDescriptorId)
;

CREATE INDEX FK_27d914_TitleIPartAParticipantDescriptor
ON edfi.StudentTitleIPartAProgramAssociation (TitleIPartAParticipantDescriptorId ASC);

ALTER TABLE edfi.StudentTitleIPartAProgramAssociationService ADD CONSTRAINT FK_7d2fb4_ServiceDescriptor FOREIGN KEY (ServiceDescriptorId)
REFERENCES edfi.ServiceDescriptor (ServiceDescriptorId)
;

CREATE INDEX FK_7d2fb4_ServiceDescriptor
ON edfi.StudentTitleIPartAProgramAssociationService (ServiceDescriptorId ASC);

ALTER TABLE edfi.StudentTitleIPartAProgramAssociationService ADD CONSTRAINT FK_7d2fb4_StudentTitleIPartAProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentTitleIPartAProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_7d2fb4_StudentTitleIPartAProgramAssociation
ON edfi.StudentTitleIPartAProgramAssociationService (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService ADD CONSTRAINT FK_8adb29_StudentTitleIPartAProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentTitleIPartAProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_8adb29_StudentTitleIPartAProgramAssociation
ON edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService ADD CONSTRAINT FK_8adb29_TitleIPartAProgramServiceDescriptor FOREIGN KEY (TitleIPartAProgramServiceDescriptorId)
REFERENCES edfi.TitleIPartAProgramServiceDescriptor (TitleIPartAProgramServiceDescriptorId)
;

CREATE INDEX FK_8adb29_TitleIPartAProgramServiceDescriptor
ON edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService (TitleIPartAProgramServiceDescriptorId ASC);

ALTER TABLE edfi.StudentVisa ADD CONSTRAINT FK_aa5751_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_aa5751_Student
ON edfi.StudentVisa (StudentUSI ASC);

ALTER TABLE edfi.StudentVisa ADD CONSTRAINT FK_aa5751_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

CREATE INDEX FK_aa5751_VisaDescriptor
ON edfi.StudentVisa (VisaDescriptorId ASC);

ALTER TABLE edfi.SubmissionStatusDescriptor ADD CONSTRAINT FK_8e9244_Descriptor FOREIGN KEY (SubmissionStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_211bb3_EducationOrganization
ON edfi.Survey (EducationOrganizationId ASC);

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_211bb3_SchoolYearType
ON edfi.Survey (SchoolYear ASC);

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName)
REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_211bb3_Session
ON edfi.Survey (SchoolId ASC, SchoolYear ASC, SessionName ASC);

ALTER TABLE edfi.Survey ADD CONSTRAINT FK_211bb3_SurveyCategoryDescriptor FOREIGN KEY (SurveyCategoryDescriptorId)
REFERENCES edfi.SurveyCategoryDescriptor (SurveyCategoryDescriptorId)
;

CREATE INDEX FK_211bb3_SurveyCategoryDescriptor
ON edfi.Survey (SurveyCategoryDescriptorId ASC);

ALTER TABLE edfi.SurveyCategoryDescriptor ADD CONSTRAINT FK_4e55bd_Descriptor FOREIGN KEY (SurveyCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyCourseAssociation ADD CONSTRAINT FK_9f1246_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_9f1246_Course
ON edfi.SurveyCourseAssociation (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE edfi.SurveyCourseAssociation ADD CONSTRAINT FK_9f1246_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

CREATE INDEX FK_9f1246_Survey
ON edfi.SurveyCourseAssociation (Namespace ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveyLevelDescriptor ADD CONSTRAINT FK_bce725_Descriptor FOREIGN KEY (SurveyLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE edfi.SurveyProgramAssociation ADD CONSTRAINT FK_e3e5a4_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_e3e5a4_Program
ON edfi.SurveyProgramAssociation (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE edfi.SurveyProgramAssociation ADD CONSTRAINT FK_e3e5a4_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

CREATE INDEX FK_e3e5a4_Survey
ON edfi.SurveyProgramAssociation (Namespace ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveyQuestion ADD CONSTRAINT FK_1bb88c_QuestionFormDescriptor FOREIGN KEY (QuestionFormDescriptorId)
REFERENCES edfi.QuestionFormDescriptor (QuestionFormDescriptorId)
;

CREATE INDEX FK_1bb88c_QuestionFormDescriptor
ON edfi.SurveyQuestion (QuestionFormDescriptorId ASC);

ALTER TABLE edfi.SurveyQuestion ADD CONSTRAINT FK_1bb88c_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

CREATE INDEX FK_1bb88c_Survey
ON edfi.SurveyQuestion (Namespace ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveyQuestion ADD CONSTRAINT FK_1bb88c_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_1bb88c_SurveySection
ON edfi.SurveyQuestion (Namespace ASC, SurveyIdentifier ASC, SurveySectionTitle ASC);

ALTER TABLE edfi.SurveyQuestionMatrix ADD CONSTRAINT FK_64d76d_SurveyQuestion FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier)
REFERENCES edfi.SurveyQuestion (Namespace, QuestionCode, SurveyIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_64d76d_SurveyQuestion
ON edfi.SurveyQuestionMatrix (Namespace ASC, QuestionCode ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveyQuestionResponse ADD CONSTRAINT FK_eddd02_SurveyQuestion FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier)
REFERENCES edfi.SurveyQuestion (Namespace, QuestionCode, SurveyIdentifier)
;

CREATE INDEX FK_eddd02_SurveyQuestion
ON edfi.SurveyQuestionResponse (Namespace ASC, QuestionCode ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveyQuestionResponse ADD CONSTRAINT FK_eddd02_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

CREATE INDEX FK_eddd02_SurveyResponse
ON edfi.SurveyQuestionResponse (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE edfi.SurveyQuestionResponseChoice ADD CONSTRAINT FK_1c624b_SurveyQuestion FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier)
REFERENCES edfi.SurveyQuestion (Namespace, QuestionCode, SurveyIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_1c624b_SurveyQuestion
ON edfi.SurveyQuestionResponseChoice (Namespace ASC, QuestionCode ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse ADD CONSTRAINT FK_048797_SurveyQuestionResponse FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyQuestionResponse (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_048797_SurveyQuestionResponse
ON edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse (Namespace ASC, QuestionCode ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE edfi.SurveyQuestionResponseValue ADD CONSTRAINT FK_d047f5_SurveyQuestionResponse FOREIGN KEY (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyQuestionResponse (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_d047f5_SurveyQuestionResponse
ON edfi.SurveyQuestionResponseValue (Namespace ASC, QuestionCode ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
;

CREATE INDEX FK_8d6383_Parent
ON edfi.SurveyResponse (ParentUSI ASC);

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_8d6383_Staff
ON edfi.SurveyResponse (StaffUSI ASC);

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_8d6383_Student
ON edfi.SurveyResponse (StudentUSI ASC);

ALTER TABLE edfi.SurveyResponse ADD CONSTRAINT FK_8d6383_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

CREATE INDEX FK_8d6383_Survey
ON edfi.SurveyResponse (Namespace ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_b2bd0a_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_b2bd0a_EducationOrganization
ON edfi.SurveyResponseEducationOrganizationTargetAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_b2bd0a_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

CREATE INDEX FK_b2bd0a_SurveyResponse
ON edfi.SurveyResponseEducationOrganizationTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD CONSTRAINT FK_f9457e_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_f9457e_Staff
ON edfi.SurveyResponseStaffTargetAssociation (StaffUSI ASC);

ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD CONSTRAINT FK_f9457e_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

CREATE INDEX FK_f9457e_SurveyResponse
ON edfi.SurveyResponseStaffTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE edfi.SurveyResponseSurveyLevel ADD CONSTRAINT FK_03f044_SurveyLevelDescriptor FOREIGN KEY (SurveyLevelDescriptorId)
REFERENCES edfi.SurveyLevelDescriptor (SurveyLevelDescriptorId)
;

CREATE INDEX FK_03f044_SurveyLevelDescriptor
ON edfi.SurveyResponseSurveyLevel (SurveyLevelDescriptorId ASC);

ALTER TABLE edfi.SurveyResponseSurveyLevel ADD CONSTRAINT FK_03f044_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_03f044_SurveyResponse
ON edfi.SurveyResponseSurveyLevel (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE edfi.SurveySection ADD CONSTRAINT FK_e5572a_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

CREATE INDEX FK_e5572a_Survey
ON edfi.SurveySection (Namespace ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveySectionAssociation ADD CONSTRAINT FK_c16804_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_c16804_Section
ON edfi.SurveySectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE edfi.SurveySectionAssociation ADD CONSTRAINT FK_c16804_Survey FOREIGN KEY (Namespace, SurveyIdentifier)
REFERENCES edfi.Survey (Namespace, SurveyIdentifier)
;

CREATE INDEX FK_c16804_Survey
ON edfi.SurveySectionAssociation (Namespace ASC, SurveyIdentifier ASC);

ALTER TABLE edfi.SurveySectionResponse ADD CONSTRAINT FK_2189c3_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

CREATE INDEX FK_2189c3_SurveyResponse
ON edfi.SurveySectionResponse (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE edfi.SurveySectionResponse ADD CONSTRAINT FK_2189c3_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_2189c3_SurveySection
ON edfi.SurveySectionResponse (Namespace ASC, SurveyIdentifier ASC, SurveySectionTitle ASC);

ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_730be1_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_730be1_EducationOrganization
ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation (EducationOrganizationId ASC);

ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD CONSTRAINT FK_730be1_SurveySectionResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySectionResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_730be1_SurveySectionResponse
ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC, SurveySectionTitle ASC);

ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD CONSTRAINT FK_39073d_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_39073d_Staff
ON edfi.SurveySectionResponseStaffTargetAssociation (StaffUSI ASC);

ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD CONSTRAINT FK_39073d_SurveySectionResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySectionResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_39073d_SurveySectionResponse
ON edfi.SurveySectionResponseStaffTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC, SurveySectionTitle ASC);

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

