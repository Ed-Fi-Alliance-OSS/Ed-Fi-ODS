-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [edfi].[AbsenceEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AbsenceEventCategoryDescriptor_Descriptor] FOREIGN KEY ([AbsenceEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AcademicHonorCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AcademicHonorCategoryDescriptor_Descriptor] FOREIGN KEY ([AcademicHonorCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AcademicSubjectDescriptor] WITH CHECK ADD CONSTRAINT [FK_AcademicSubjectDescriptor_Descriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AcademicWeek] WITH CHECK ADD CONSTRAINT [FK_AcademicWeek_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[AccommodationDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccommodationDescriptor_Descriptor] FOREIGN KEY ([AccommodationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AccountabilityRating] WITH CHECK ADD CONSTRAINT [FK_AccountabilityRating_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[AccountabilityRating] WITH CHECK ADD CONSTRAINT [FK_AccountabilityRating_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[AccountTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccountTypeDescriptor_Descriptor] FOREIGN KEY ([AccountTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AchievementCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AchievementCategoryDescriptor_Descriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AdditionalCreditTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AdditionalCreditTypeDescriptor_Descriptor] FOREIGN KEY ([AdditionalCreditTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AddressTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AddressTypeDescriptor_Descriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AdministrationEnvironmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_AdministrationEnvironmentDescriptor_Descriptor] FOREIGN KEY ([AdministrationEnvironmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AdministrativeFundingControlDescriptor] WITH CHECK ADD CONSTRAINT [FK_AdministrativeFundingControlDescriptor_Descriptor] FOREIGN KEY ([AdministrativeFundingControlDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AncestryEthnicOriginDescriptor] WITH CHECK ADD CONSTRAINT [FK_AncestryEthnicOriginDescriptor_Descriptor] FOREIGN KEY ([AncestryEthnicOriginDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Assessment] WITH CHECK ADD CONSTRAINT [FK_Assessment_AssessmentCategoryDescriptor] FOREIGN KEY ([AssessmentCategoryDescriptorId])
REFERENCES [edfi].[AssessmentCategoryDescriptor] ([AssessmentCategoryDescriptorId])
GO

ALTER TABLE [edfi].[Assessment] WITH CHECK ADD CONSTRAINT [FK_Assessment_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[AssessmentAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_AssessmentAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_AssessmentAcademicSubject_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentAssessedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentAssessedGradeLevel_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentAssessedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentAssessedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentCategoryDescriptor_Descriptor] FOREIGN KEY ([AssessmentCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentContentStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandard_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentContentStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandard_EducationOrganization] FOREIGN KEY ([MandatingEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[AssessmentContentStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandard_PublicationStatusDescriptor] FOREIGN KEY ([PublicationStatusDescriptorId])
REFERENCES [edfi].[PublicationStatusDescriptor] ([PublicationStatusDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentContentStandardAuthor] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandardAuthor_AssessmentContentStandard] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[AssessmentContentStandard] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_AssessmentIdentificationCode_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_AssessmentIdentificationCode_AssessmentIdentificationSystemDescriptor] FOREIGN KEY ([AssessmentIdentificationSystemDescriptorId])
REFERENCES [edfi].[AssessmentIdentificationSystemDescriptor] ([AssessmentIdentificationSystemDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([AssessmentIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItem] WITH CHECK ADD CONSTRAINT [FK_AssessmentItem_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

ALTER TABLE [edfi].[AssessmentItem] WITH CHECK ADD CONSTRAINT [FK_AssessmentItem_AssessmentItemCategoryDescriptor] FOREIGN KEY ([AssessmentItemCategoryDescriptorId])
REFERENCES [edfi].[AssessmentItemCategoryDescriptor] ([AssessmentItemCategoryDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentItemCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemCategoryDescriptor_Descriptor] FOREIGN KEY ([AssessmentItemCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItemLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemLearningStandard_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItemLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[AssessmentItemPossibleResponse] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemPossibleResponse_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItemResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemResultDescriptor_Descriptor] FOREIGN KEY ([AssessmentItemResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentLanguage] WITH CHECK ADD CONSTRAINT [FK_AssessmentLanguage_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentLanguage] WITH CHECK ADD CONSTRAINT [FK_AssessmentLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_AssessmentPeriod_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_AssessmentPeriod_AssessmentPeriodDescriptor] FOREIGN KEY ([AssessmentPeriodDescriptorId])
REFERENCES [edfi].[AssessmentPeriodDescriptor] ([AssessmentPeriodDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentPeriodDescriptor_Descriptor] FOREIGN KEY ([AssessmentPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPlatformType] WITH CHECK ADD CONSTRAINT [FK_AssessmentPlatformType_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPlatformType] WITH CHECK ADD CONSTRAINT [FK_AssessmentPlatformType_PlatformTypeDescriptor] FOREIGN KEY ([PlatformTypeDescriptorId])
REFERENCES [edfi].[PlatformTypeDescriptor] ([PlatformTypeDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentProgram] WITH CHECK ADD CONSTRAINT [FK_AssessmentProgram_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentProgram] WITH CHECK ADD CONSTRAINT [FK_AssessmentProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentReportingMethodDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentReportingMethodDescriptor_Descriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentScore] WITH CHECK ADD CONSTRAINT [FK_AssessmentScore_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentScore] WITH CHECK ADD CONSTRAINT [FK_AssessmentScore_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentScore] WITH CHECK ADD CONSTRAINT [FK_AssessmentScore_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandard_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandard_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandard_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandardLearningStandard_AssessmentScoreRangeLearningStandard] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [ScoreRangeId])
REFERENCES [edfi].[AssessmentScoreRangeLearningStandard] ([AssessmentIdentifier], [Namespace], [ScoreRangeId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandardLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[AssessmentSection] WITH CHECK ADD CONSTRAINT [FK_AssessmentSection_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentSection] WITH CHECK ADD CONSTRAINT [FK_AssessmentSection_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[AssignmentLateStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssignmentLateStatusDescriptor_Descriptor] FOREIGN KEY ([AssignmentLateStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AttemptStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AttemptStatusDescriptor_Descriptor] FOREIGN KEY ([AttemptStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AttendanceEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AttendanceEventCategoryDescriptor_Descriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BalanceSheetDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_BalanceSheetDimensionReportingTag_BalanceSheetDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[BalanceSheetDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BalanceSheetDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_BalanceSheetDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[BarrierToInternetAccessInResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_BarrierToInternetAccessInResidenceDescriptor_Descriptor] FOREIGN KEY ([BarrierToInternetAccessInResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BehaviorDescriptor] WITH CHECK ADD CONSTRAINT [FK_BehaviorDescriptor_Descriptor] FOREIGN KEY ([BehaviorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellSchedule] WITH CHECK ADD CONSTRAINT [FK_BellSchedule_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[BellScheduleClassPeriod] WITH CHECK ADD CONSTRAINT [FK_BellScheduleClassPeriod_BellSchedule] FOREIGN KEY ([BellScheduleName], [SchoolId])
REFERENCES [edfi].[BellSchedule] ([BellScheduleName], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellScheduleClassPeriod] WITH CHECK ADD CONSTRAINT [FK_BellScheduleClassPeriod_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[BellScheduleDate] WITH CHECK ADD CONSTRAINT [FK_BellScheduleDate_BellSchedule] FOREIGN KEY ([BellScheduleName], [SchoolId])
REFERENCES [edfi].[BellSchedule] ([BellScheduleName], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellScheduleGradeLevel] WITH CHECK ADD CONSTRAINT [FK_BellScheduleGradeLevel_BellSchedule] FOREIGN KEY ([BellScheduleName], [SchoolId])
REFERENCES [edfi].[BellSchedule] ([BellScheduleName], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellScheduleGradeLevel] WITH CHECK ADD CONSTRAINT [FK_BellScheduleGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[Calendar] WITH CHECK ADD CONSTRAINT [FK_Calendar_CalendarTypeDescriptor] FOREIGN KEY ([CalendarTypeDescriptorId])
REFERENCES [edfi].[CalendarTypeDescriptor] ([CalendarTypeDescriptorId])
GO

ALTER TABLE [edfi].[Calendar] WITH CHECK ADD CONSTRAINT [FK_Calendar_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[Calendar] WITH CHECK ADD CONSTRAINT [FK_Calendar_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[CalendarDate] WITH CHECK ADD CONSTRAINT [FK_CalendarDate_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[CalendarDateCalendarEvent] WITH CHECK ADD CONSTRAINT [FK_CalendarDateCalendarEvent_CalendarDate] FOREIGN KEY ([CalendarCode], [Date], [SchoolId], [SchoolYear])
REFERENCES [edfi].[CalendarDate] ([CalendarCode], [Date], [SchoolId], [SchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CalendarDateCalendarEvent] WITH CHECK ADD CONSTRAINT [FK_CalendarDateCalendarEvent_CalendarEventDescriptor] FOREIGN KEY ([CalendarEventDescriptorId])
REFERENCES [edfi].[CalendarEventDescriptor] ([CalendarEventDescriptorId])
GO

ALTER TABLE [edfi].[CalendarEventDescriptor] WITH CHECK ADD CONSTRAINT [FK_CalendarEventDescriptor_Descriptor] FOREIGN KEY ([CalendarEventDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CalendarGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CalendarGradeLevel_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CalendarGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CalendarGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[CalendarTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CalendarTypeDescriptor_Descriptor] FOREIGN KEY ([CalendarTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CareerPathwayDescriptor] WITH CHECK ADD CONSTRAINT [FK_CareerPathwayDescriptor_Descriptor] FOREIGN KEY ([CareerPathwayDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CharterApprovalAgencyTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CharterApprovalAgencyTypeDescriptor_Descriptor] FOREIGN KEY ([CharterApprovalAgencyTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CharterStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CharterStatusDescriptor_Descriptor] FOREIGN KEY ([CharterStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_AccountTypeDescriptor] FOREIGN KEY ([AccountTypeDescriptorId])
REFERENCES [edfi].[AccountTypeDescriptor] ([AccountTypeDescriptorId])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_BalanceSheetDimension] FOREIGN KEY ([BalanceSheetCode], [FiscalYear])
REFERENCES [edfi].[BalanceSheetDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_FunctionDimension] FOREIGN KEY ([FunctionCode], [FiscalYear])
REFERENCES [edfi].[FunctionDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_FundDimension] FOREIGN KEY ([FundCode], [FiscalYear])
REFERENCES [edfi].[FundDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_ObjectDimension] FOREIGN KEY ([ObjectCode], [FiscalYear])
REFERENCES [edfi].[ObjectDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_OperationalUnitDimension] FOREIGN KEY ([OperationalUnitCode], [FiscalYear])
REFERENCES [edfi].[OperationalUnitDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_ProgramDimension] FOREIGN KEY ([ProgramCode], [FiscalYear])
REFERENCES [edfi].[ProgramDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_ProjectDimension] FOREIGN KEY ([ProjectCode], [FiscalYear])
REFERENCES [edfi].[ProjectDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_SourceDimension] FOREIGN KEY ([SourceCode], [FiscalYear])
REFERENCES [edfi].[SourceDimension] ([Code], [FiscalYear])
GO

ALTER TABLE [edfi].[ChartOfAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccountReportingTag_ChartOfAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[ChartOfAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ChartOfAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccountReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[CitizenshipStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CitizenshipStatusDescriptor_Descriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ClassPeriod] WITH CHECK ADD CONSTRAINT [FK_ClassPeriod_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[ClassPeriodMeetingTime] WITH CHECK ADD CONSTRAINT [FK_ClassPeriodMeetingTime_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[ClassroomPositionDescriptor] WITH CHECK ADD CONSTRAINT [FK_ClassroomPositionDescriptor_Descriptor] FOREIGN KEY ([ClassroomPositionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_CohortScopeDescriptor] FOREIGN KEY ([CohortScopeDescriptorId])
REFERENCES [edfi].[CohortScopeDescriptor] ([CohortScopeDescriptorId])
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_CohortTypeDescriptor] FOREIGN KEY ([CohortTypeDescriptorId])
REFERENCES [edfi].[CohortTypeDescriptor] ([CohortTypeDescriptorId])
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CohortProgram] WITH CHECK ADD CONSTRAINT [FK_CohortProgram_Cohort] FOREIGN KEY ([CohortIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CohortProgram] WITH CHECK ADD CONSTRAINT [FK_CohortProgram_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[CohortScopeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CohortScopeDescriptor_Descriptor] FOREIGN KEY ([CohortScopeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CohortTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CohortTypeDescriptor_Descriptor] FOREIGN KEY ([CohortTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CohortYearTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CohortYearTypeDescriptor_Descriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CommunityOrganization] WITH CHECK ADD CONSTRAINT [FK_CommunityOrganization_EducationOrganization] FOREIGN KEY ([CommunityOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_CommunityOrganization] FOREIGN KEY ([CommunityOrganizationId])
REFERENCES [edfi].[CommunityOrganization] ([CommunityOrganizationId])
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_EducationOrganization] FOREIGN KEY ([CommunityProviderId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_ProviderCategoryDescriptor] FOREIGN KEY ([ProviderCategoryDescriptorId])
REFERENCES [edfi].[ProviderCategoryDescriptor] ([ProviderCategoryDescriptorId])
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_ProviderProfitabilityDescriptor] FOREIGN KEY ([ProviderProfitabilityDescriptorId])
REFERENCES [edfi].[ProviderProfitabilityDescriptor] ([ProviderProfitabilityDescriptorId])
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_ProviderStatusDescriptor] FOREIGN KEY ([ProviderStatusDescriptorId])
REFERENCES [edfi].[ProviderStatusDescriptor] ([ProviderStatusDescriptorId])
GO

ALTER TABLE [edfi].[CommunityProviderLicense] WITH CHECK ADD CONSTRAINT [FK_CommunityProviderLicense_CommunityProvider] FOREIGN KEY ([CommunityProviderId])
REFERENCES [edfi].[CommunityProvider] ([CommunityProviderId])
GO

ALTER TABLE [edfi].[CommunityProviderLicense] WITH CHECK ADD CONSTRAINT [FK_CommunityProviderLicense_LicenseStatusDescriptor] FOREIGN KEY ([LicenseStatusDescriptorId])
REFERENCES [edfi].[LicenseStatusDescriptor] ([LicenseStatusDescriptorId])
GO

ALTER TABLE [edfi].[CommunityProviderLicense] WITH CHECK ADD CONSTRAINT [FK_CommunityProviderLicense_LicenseTypeDescriptor] FOREIGN KEY ([LicenseTypeDescriptorId])
REFERENCES [edfi].[LicenseTypeDescriptor] ([LicenseTypeDescriptorId])
GO

ALTER TABLE [edfi].[CompetencyLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_CompetencyLevelDescriptor_Descriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_CompetencyObjective_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_CompetencyObjective_GradeLevelDescriptor] FOREIGN KEY ([ObjectiveGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[Contact] WITH CHECK ADD CONSTRAINT [FK_Contact_LevelOfEducationDescriptor] FOREIGN KEY ([HighestCompletedLevelOfEducationDescriptorId])
REFERENCES [edfi].[LevelOfEducationDescriptor] ([LevelOfEducationDescriptorId])
GO

ALTER TABLE [edfi].[Contact] WITH CHECK ADD CONSTRAINT [FK_Contact_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

ALTER TABLE [edfi].[Contact] WITH CHECK ADD CONSTRAINT [FK_Contact_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[ContactAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_ContactAddressPeriod_ContactAddress] FOREIGN KEY ([ContactUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[ContactAddress] ([ContactUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ContactElectronicMail_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ContactElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

ALTER TABLE [edfi].[ContactInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ContactInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[ContactInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ContactInternationalAddress_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ContactInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[ContactLanguage] WITH CHECK ADD CONSTRAINT [FK_ContactLanguage_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactLanguage] WITH CHECK ADD CONSTRAINT [FK_ContactLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

ALTER TABLE [edfi].[ContactLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ContactLanguageUse_ContactLanguage] FOREIGN KEY ([ContactUSI], [LanguageDescriptorId])
REFERENCES [edfi].[ContactLanguage] ([ContactUSI], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ContactLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

ALTER TABLE [edfi].[ContactOtherName] WITH CHECK ADD CONSTRAINT [FK_ContactOtherName_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactOtherName] WITH CHECK ADD CONSTRAINT [FK_ContactOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

ALTER TABLE [edfi].[ContactTelephone] WITH CHECK ADD CONSTRAINT [FK_ContactTelephone_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactTelephone] WITH CHECK ADD CONSTRAINT [FK_ContactTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

ALTER TABLE [edfi].[ContactTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ContactTypeDescriptor_Descriptor] FOREIGN KEY ([ContactTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContentClassDescriptor] WITH CHECK ADD CONSTRAINT [FK_ContentClassDescriptor_Descriptor] FOREIGN KEY ([ContentClassDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContinuationOfServicesReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_ContinuationOfServicesReasonDescriptor_Descriptor] FOREIGN KEY ([ContinuationOfServicesReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CostRateDescriptor] WITH CHECK ADD CONSTRAINT [FK_CostRateDescriptor_Descriptor] FOREIGN KEY ([CostRateDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CountryDescriptor] WITH CHECK ADD CONSTRAINT [FK_CountryDescriptor_Descriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CareerPathwayDescriptor] FOREIGN KEY ([CareerPathwayDescriptorId])
REFERENCES [edfi].[CareerPathwayDescriptor] ([CareerPathwayDescriptorId])
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CourseDefinedByDescriptor] FOREIGN KEY ([CourseDefinedByDescriptorId])
REFERENCES [edfi].[CourseDefinedByDescriptor] ([CourseDefinedByDescriptorId])
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CourseGPAApplicabilityDescriptor] FOREIGN KEY ([CourseGPAApplicabilityDescriptorId])
REFERENCES [edfi].[CourseGPAApplicabilityDescriptor] ([CourseGPAApplicabilityDescriptorId])
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CreditTypeDescriptor] FOREIGN KEY ([MinimumAvailableCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CreditTypeDescriptor1] FOREIGN KEY ([MaximumAvailableCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CourseAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[CourseAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseAcademicSubject_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseAttemptResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseAttemptResultDescriptor_Descriptor] FOREIGN KEY ([CourseAttemptResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseCompetencyLevel] WITH CHECK ADD CONSTRAINT [FK_CourseCompetencyLevel_CompetencyLevelDescriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[CompetencyLevelDescriptor] ([CompetencyLevelDescriptorId])
GO

ALTER TABLE [edfi].[CourseCompetencyLevel] WITH CHECK ADD CONSTRAINT [FK_CourseCompetencyLevel_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseDefinedByDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseDefinedByDescriptor_Descriptor] FOREIGN KEY ([CourseDefinedByDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseGPAApplicabilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseGPAApplicabilityDescriptor_Descriptor] FOREIGN KEY ([CourseGPAApplicabilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseIdentificationCode_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseIdentificationCode_CourseIdentificationSystemDescriptor] FOREIGN KEY ([CourseIdentificationSystemDescriptorId])
REFERENCES [edfi].[CourseIdentificationSystemDescriptor] ([CourseIdentificationSystemDescriptorId])
GO

ALTER TABLE [edfi].[CourseIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([CourseIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseLearningStandard] WITH CHECK ADD CONSTRAINT [FK_CourseLearningStandard_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseLearningStandard] WITH CHECK ADD CONSTRAINT [FK_CourseLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[CourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseLevelCharacteristic_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseLevelCharacteristic_CourseLevelCharacteristicDescriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[CourseLevelCharacteristicDescriptor] ([CourseLevelCharacteristicDescriptorId])
GO

ALTER TABLE [edfi].[CourseLevelCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseLevelCharacteristicDescriptor_Descriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferedGradeLevel_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[CourseOffering] WITH CHECK ADD CONSTRAINT [FK_CourseOffering_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

ALTER TABLE [edfi].[CourseOffering] WITH CHECK ADD CONSTRAINT [FK_CourseOffering_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[CourseOffering] WITH CHECK ADD CONSTRAINT [FK_CourseOffering_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCourseLevelCharacteristic_CourseLevelCharacteristicDescriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[CourseLevelCharacteristicDescriptor] ([CourseLevelCharacteristicDescriptorId])
GO

ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCourseLevelCharacteristic_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCurriculumUsed_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCurriculumUsed_CurriculumUsedDescriptor] FOREIGN KEY ([CurriculumUsedDescriptorId])
REFERENCES [edfi].[CurriculumUsedDescriptor] ([CurriculumUsedDescriptorId])
GO

ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingOfferedGradeLevel_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingOfferedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[CourseRepeatCodeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseRepeatCodeDescriptor_Descriptor] FOREIGN KEY ([CourseRepeatCodeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_Course] FOREIGN KEY ([CourseCode], [CourseEducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CourseAttemptResultDescriptor] FOREIGN KEY ([CourseAttemptResultDescriptorId])
REFERENCES [edfi].[CourseAttemptResultDescriptor] ([CourseAttemptResultDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CourseRepeatCodeDescriptor] FOREIGN KEY ([CourseRepeatCodeDescriptorId])
REFERENCES [edfi].[CourseRepeatCodeDescriptor] ([CourseRepeatCodeDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CreditTypeDescriptor] FOREIGN KEY ([AttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CreditTypeDescriptor1] FOREIGN KEY ([EarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_EducationOrganization] FOREIGN KEY ([ExternalEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_GradeLevelDescriptor] FOREIGN KEY ([WhenTakenGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_MethodCreditEarnedDescriptor] FOREIGN KEY ([MethodCreditEarnedDescriptorId])
REFERENCES [edfi].[MethodCreditEarnedDescriptor] ([MethodCreditEarnedDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscriptAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscriptAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAcademicSubject_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAlternativeCourseIdentificationCode_CourseIdentificationSystemDescriptor] FOREIGN KEY ([CourseIdentificationSystemDescriptorId])
REFERENCES [edfi].[CourseIdentificationSystemDescriptor] ([CourseIdentificationSystemDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAlternativeCourseIdentificationCode_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptCreditCategory] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptCreditCategory_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptCreditCategory] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptCreditCategory_CreditCategoryDescriptor] FOREIGN KEY ([CreditCategoryDescriptorId])
REFERENCES [edfi].[CreditCategoryDescriptor] ([CreditCategoryDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptEarnedAdditionalCredits_AdditionalCreditTypeDescriptor] FOREIGN KEY ([AdditionalCreditTypeDescriptorId])
REFERENCES [edfi].[AdditionalCreditTypeDescriptor] ([AdditionalCreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptEarnedAdditionalCredits_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptPartialCourseTranscriptAwards_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptPartialCourseTranscriptAwards_MethodCreditEarnedDescriptor] FOREIGN KEY ([MethodCreditEarnedDescriptorId])
REFERENCES [edfi].[MethodCreditEarnedDescriptor] ([MethodCreditEarnedDescriptorId])
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_CredentialFieldDescriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[CredentialFieldDescriptor] ([CredentialFieldDescriptorId])
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_CredentialTypeDescriptor] FOREIGN KEY ([CredentialTypeDescriptorId])
REFERENCES [edfi].[CredentialTypeDescriptor] ([CredentialTypeDescriptorId])
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_StateAbbreviationDescriptor] FOREIGN KEY ([StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_TeachingCredentialBasisDescriptor] FOREIGN KEY ([TeachingCredentialBasisDescriptorId])
REFERENCES [edfi].[TeachingCredentialBasisDescriptor] ([TeachingCredentialBasisDescriptorId])
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_TeachingCredentialDescriptor] FOREIGN KEY ([TeachingCredentialDescriptorId])
REFERENCES [edfi].[TeachingCredentialDescriptor] ([TeachingCredentialDescriptorId])
GO

ALTER TABLE [edfi].[CredentialAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CredentialAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[CredentialAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CredentialAcademicSubject_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialEndorsement] WITH CHECK ADD CONSTRAINT [FK_CredentialEndorsement_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialFieldDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialFieldDescriptor_Descriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CredentialGradeLevel_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CredentialGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[CredentialTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialTypeDescriptor_Descriptor] FOREIGN KEY ([CredentialTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CreditCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_CreditCategoryDescriptor_Descriptor] FOREIGN KEY ([CreditCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CreditTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CreditTypeDescriptor_Descriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CTEProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_CTEProgramServiceDescriptor_Descriptor] FOREIGN KEY ([CTEProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CurriculumUsedDescriptor] WITH CHECK ADD CONSTRAINT [FK_CurriculumUsedDescriptor_Descriptor] FOREIGN KEY ([CurriculumUsedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DeliveryMethodDescriptor] WITH CHECK ADD CONSTRAINT [FK_DeliveryMethodDescriptor_Descriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DescriptorMappingModelEntity] WITH CHECK ADD CONSTRAINT [FK_DescriptorMappingModelEntity_DescriptorMapping] FOREIGN KEY ([MappedNamespace], [MappedValue], [Namespace], [Value])
REFERENCES [edfi].[DescriptorMapping] ([MappedNamespace], [MappedValue], [Namespace], [Value])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DescriptorMappingModelEntity] WITH CHECK ADD CONSTRAINT [FK_DescriptorMappingModelEntity_ModelEntityDescriptor] FOREIGN KEY ([ModelEntityDescriptorId])
REFERENCES [edfi].[ModelEntityDescriptor] ([ModelEntityDescriptorId])
GO

ALTER TABLE [edfi].[DiagnosisDescriptor] WITH CHECK ADD CONSTRAINT [FK_DiagnosisDescriptor_Descriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DiplomaLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_DiplomaLevelDescriptor_Descriptor] FOREIGN KEY ([DiplomaLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DiplomaTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DiplomaTypeDescriptor_Descriptor] FOREIGN KEY ([DiplomaTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisabilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisabilityDescriptor_Descriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisabilityDesignationDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisabilityDesignationDescriptor_Descriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisabilityDeterminationSourceTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisabilityDeterminationSourceTypeDescriptor_Descriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_DisciplineActionLengthDifferenceReasonDescriptor] FOREIGN KEY ([DisciplineActionLengthDifferenceReasonDescriptorId])
REFERENCES [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] ([DisciplineActionLengthDifferenceReasonDescriptorId])
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_School] FOREIGN KEY ([AssignmentSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_School1] FOREIGN KEY ([ResponsibilitySchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[DisciplineActionDiscipline] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionDiscipline_DisciplineAction] FOREIGN KEY ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
REFERENCES [edfi].[DisciplineAction] ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionDiscipline] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionDiscipline_DisciplineDescriptor] FOREIGN KEY ([DisciplineDescriptorId])
REFERENCES [edfi].[DisciplineDescriptor] ([DisciplineDescriptorId])
GO

ALTER TABLE [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionLengthDifferenceReasonDescriptor_Descriptor] FOREIGN KEY ([DisciplineActionLengthDifferenceReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionStaff] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStaff_DisciplineAction] FOREIGN KEY ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
REFERENCES [edfi].[DisciplineAction] ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionStaff] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStaff_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStudentDisciplineIncidentBehaviorAssociation_DisciplineAction] FOREIGN KEY ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
REFERENCES [edfi].[DisciplineAction] ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStudentDisciplineIncidentBehaviorAssociation_StudentDisciplineIncidentBehaviorAssociation] FOREIGN KEY ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
GO

ALTER TABLE [edfi].[DisciplineDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisciplineDescriptor_Descriptor] FOREIGN KEY ([DisciplineDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncident] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncident_IncidentLocationDescriptor] FOREIGN KEY ([IncidentLocationDescriptorId])
REFERENCES [edfi].[IncidentLocationDescriptor] ([IncidentLocationDescriptorId])
GO

ALTER TABLE [edfi].[DisciplineIncident] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncident_ReporterDescriptionDescriptor] FOREIGN KEY ([ReporterDescriptionDescriptorId])
REFERENCES [edfi].[ReporterDescriptionDescriptor] ([ReporterDescriptionDescriptorId])
GO

ALTER TABLE [edfi].[DisciplineIncident] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncident_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[DisciplineIncidentBehavior] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentBehavior_BehaviorDescriptor] FOREIGN KEY ([BehaviorDescriptorId])
REFERENCES [edfi].[BehaviorDescriptor] ([BehaviorDescriptorId])
GO

ALTER TABLE [edfi].[DisciplineIncidentBehavior] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentBehavior_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentExternalParticipant] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentExternalParticipant_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentExternalParticipant] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentExternalParticipant_DisciplineIncidentParticipationCodeDescriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

ALTER TABLE [edfi].[DisciplineIncidentParticipationCodeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentParticipationCodeDescriptor_Descriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentWeapon] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentWeapon_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentWeapon] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentWeapon_WeaponDescriptor] FOREIGN KEY ([WeaponDescriptorId])
REFERENCES [edfi].[WeaponDescriptor] ([WeaponDescriptorId])
GO

ALTER TABLE [edfi].[EducationalEnvironmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationalEnvironmentDescriptor_Descriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_ContentClassDescriptor] FOREIGN KEY ([ContentClassDescriptorId])
REFERENCES [edfi].[ContentClassDescriptor] ([ContentClassDescriptorId])
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_CostRateDescriptor] FOREIGN KEY ([CostRateDescriptorId])
REFERENCES [edfi].[CostRateDescriptor] ([CostRateDescriptorId])
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_InteractivityStyleDescriptor] FOREIGN KEY ([InteractivityStyleDescriptorId])
REFERENCES [edfi].[InteractivityStyleDescriptor] ([InteractivityStyleDescriptorId])
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[EducationContentAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateGradeLevel_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[EducationContentAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateSex_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[EducationContentAuthor] WITH CHECK ADD CONSTRAINT [FK_EducationContentAuthor_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceEducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceEducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceEducationContent_EducationContent1] FOREIGN KEY ([DerivativeSourceContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceLearningResourceMetadataURI_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceURI] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceURI_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentLanguage] WITH CHECK ADD CONSTRAINT [FK_EducationContentLanguage_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentLanguage] WITH CHECK ADD CONSTRAINT [FK_EducationContentLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganization] WITH CHECK ADD CONSTRAINT [FK_EducationOrganization_OperationalStatusDescriptor] FOREIGN KEY ([OperationalStatusDescriptorId])
REFERENCES [edfi].[OperationalStatusDescriptor] ([OperationalStatusDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddressPeriod_EducationOrganizationAddress] FOREIGN KEY ([EducationOrganizationId], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[EducationOrganizationAddress] ([EducationOrganizationId], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationAssociationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAssociationTypeDescriptor_Descriptor] FOREIGN KEY ([EducationOrganizationAssociationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationCategory] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationCategory_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationCategory] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationCategory_EducationOrganizationCategoryDescriptor] FOREIGN KEY ([EducationOrganizationCategoryDescriptorId])
REFERENCES [edfi].[EducationOrganizationCategoryDescriptor] ([EducationOrganizationCategoryDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationCategoryDescriptor_Descriptor] FOREIGN KEY ([EducationOrganizationCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIdentificationCode_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIdentificationCode_EducationOrganizationIdentificationSystemDescriptor] FOREIGN KEY ([EducationOrganizationIdentificationSystemDescriptorId])
REFERENCES [edfi].[EducationOrganizationIdentificationSystemDescriptor] ([EducationOrganizationIdentificationSystemDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([EducationOrganizationIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_IndicatorDescriptor] FOREIGN KEY ([IndicatorDescriptorId])
REFERENCES [edfi].[IndicatorDescriptor] ([IndicatorDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_IndicatorGroupDescriptor] FOREIGN KEY ([IndicatorGroupDescriptorId])
REFERENCES [edfi].[IndicatorGroupDescriptor] ([IndicatorGroupDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_IndicatorLevelDescriptor] FOREIGN KEY ([IndicatorLevelDescriptorId])
REFERENCES [edfi].[IndicatorLevelDescriptor] ([IndicatorLevelDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationIndicatorPeriod] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicatorPeriod_EducationOrganizationIndicator] FOREIGN KEY ([EducationOrganizationId], [IndicatorDescriptorId])
REFERENCES [edfi].[EducationOrganizationIndicator] ([EducationOrganizationId], [IndicatorDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationInstitutionTelephone] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInstitutionTelephone_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationInstitutionTelephone] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInstitutionTelephone_InstitutionTelephoneNumberTypeDescriptor] FOREIGN KEY ([InstitutionTelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[InstitutionTelephoneNumberTypeDescriptor] ([InstitutionTelephoneNumberTypeDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInternationalAddress_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInterventionPrescriptionAssociation_InterventionPrescription] FOREIGN KEY ([InterventionPrescriptionEducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
GO

ALTER TABLE [edfi].[EducationOrganizationNetwork] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetwork_EducationOrganization] FOREIGN KEY ([EducationOrganizationNetworkId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationNetwork] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetwork_NetworkPurposeDescriptor] FOREIGN KEY ([NetworkPurposeDescriptorId])
REFERENCES [edfi].[NetworkPurposeDescriptor] ([NetworkPurposeDescriptorId])
GO

ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetworkAssociation_EducationOrganization] FOREIGN KEY ([MemberEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetworkAssociation_EducationOrganizationNetwork] FOREIGN KEY ([EducationOrganizationNetworkId])
REFERENCES [edfi].[EducationOrganizationNetwork] ([EducationOrganizationNetworkId])
GO

ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationPeerAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationPeerAssociation_EducationOrganization1] FOREIGN KEY ([PeerEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducationPlanDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationPlanDescriptor_Descriptor] FOREIGN KEY ([EducationPlanDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationServiceCenter] WITH CHECK ADD CONSTRAINT [FK_EducationServiceCenter_EducationOrganization] FOREIGN KEY ([EducationServiceCenterId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationServiceCenter] WITH CHECK ADD CONSTRAINT [FK_EducationServiceCenter_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
GO

ALTER TABLE [edfi].[ElectronicMailTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ElectronicMailTypeDescriptor_Descriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EligibilityDelayReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_EligibilityDelayReasonDescriptor_Descriptor] FOREIGN KEY ([EligibilityDelayReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EligibilityEvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EligibilityEvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([EligibilityEvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EmploymentStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_EmploymentStatusDescriptor_Descriptor] FOREIGN KEY ([EmploymentStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EnrollmentTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EnrollmentTypeDescriptor_Descriptor] FOREIGN KEY ([EnrollmentTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EntryGradeLevelReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_EntryGradeLevelReasonDescriptor_Descriptor] FOREIGN KEY ([EntryGradeLevelReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EntryTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EntryTypeDescriptor_Descriptor] FOREIGN KEY ([EntryTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationDelayReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationDelayReasonDescriptor_Descriptor] FOREIGN KEY ([EvaluationDelayReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRubricDimension] WITH CHECK ADD CONSTRAINT [FK_EvaluationRubricDimension_ProgramEvaluationElement] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[EvaluationRubricDimension] WITH CHECK ADD CONSTRAINT [FK_EvaluationRubricDimension_RatingLevelDescriptor] FOREIGN KEY ([EvaluationRubricRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

ALTER TABLE [edfi].[EventCircumstanceDescriptor] WITH CHECK ADD CONSTRAINT [FK_EventCircumstanceDescriptor_Descriptor] FOREIGN KEY ([EventCircumstanceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ExitWithdrawTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ExitWithdrawTypeDescriptor_Descriptor] FOREIGN KEY ([ExitWithdrawTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FeederSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_FeederSchoolAssociation_School] FOREIGN KEY ([FeederSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[FeederSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_FeederSchoolAssociation_School1] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[FinancialCollectionDescriptor] WITH CHECK ADD CONSTRAINT [FK_FinancialCollectionDescriptor_Descriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FunctionDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FunctionDimensionReportingTag_FunctionDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[FunctionDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FunctionDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FunctionDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[FundDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FundDimensionReportingTag_FundDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[FundDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FundDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FundDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_ReasonExitedDescriptor] FOREIGN KEY ([ReasonExitedDescriptorId])
REFERENCES [edfi].[ReasonExitedDescriptor] ([ReasonExitedDescriptorId])
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociationProgramParticipationStatus_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociationProgramParticipationStatus_ParticipationStatusDescriptor] FOREIGN KEY ([ParticipationStatusDescriptorId])
REFERENCES [edfi].[ParticipationStatusDescriptor] ([ParticipationStatusDescriptorId])
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_GradeTypeDescriptor] FOREIGN KEY ([GradeTypeDescriptorId])
REFERENCES [edfi].[GradeTypeDescriptor] ([GradeTypeDescriptorId])
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodSequence], [SchoolId], [GradingPeriodSchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [PeriodSequence], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_PerformanceBaseConversionDescriptor] FOREIGN KEY ([PerformanceBaseConversionDescriptorId])
REFERENCES [edfi].[PerformanceBaseConversionDescriptor] ([PerformanceBaseConversionDescriptorId])
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_StudentSectionAssociation] FOREIGN KEY ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAssociation] ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[GradebookEntry] WITH CHECK ADD CONSTRAINT [FK_GradebookEntry_GradebookEntryTypeDescriptor] FOREIGN KEY ([GradebookEntryTypeDescriptorId])
REFERENCES [edfi].[GradebookEntryTypeDescriptor] ([GradebookEntryTypeDescriptorId])
GO

ALTER TABLE [edfi].[GradebookEntry] WITH CHECK ADD CONSTRAINT [FK_GradebookEntry_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [PeriodSequence], [SchoolId], [SchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [PeriodSequence], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[GradebookEntry] WITH CHECK ADD CONSTRAINT [FK_GradebookEntry_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[GradebookEntryLearningStandard] WITH CHECK ADD CONSTRAINT [FK_GradebookEntryLearningStandard_GradebookEntry] FOREIGN KEY ([GradebookEntryIdentifier], [Namespace])
REFERENCES [edfi].[GradebookEntry] ([GradebookEntryIdentifier], [Namespace])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[GradebookEntryLearningStandard] WITH CHECK ADD CONSTRAINT [FK_GradebookEntryLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[GradebookEntryTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradebookEntryTypeDescriptor_Descriptor] FOREIGN KEY ([GradebookEntryTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradeLearningStandardGrade] WITH CHECK ADD CONSTRAINT [FK_GradeLearningStandardGrade_Grade] FOREIGN KEY ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[Grade] ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[GradeLearningStandardGrade] WITH CHECK ADD CONSTRAINT [FK_GradeLearningStandardGrade_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[GradeLearningStandardGrade] WITH CHECK ADD CONSTRAINT [FK_GradeLearningStandardGrade_PerformanceBaseConversionDescriptor] FOREIGN KEY ([PerformanceBaseConversionDescriptorId])
REFERENCES [edfi].[PerformanceBaseConversionDescriptor] ([PerformanceBaseConversionDescriptorId])
GO

ALTER TABLE [edfi].[GradeLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradeLevelDescriptor_Descriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradePointAverageTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradePointAverageTypeDescriptor_Descriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradeTypeDescriptor_Descriptor] FOREIGN KEY ([GradeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradingPeriod] WITH CHECK ADD CONSTRAINT [FK_GradingPeriod_GradingPeriodDescriptor] FOREIGN KEY ([GradingPeriodDescriptorId])
REFERENCES [edfi].[GradingPeriodDescriptor] ([GradingPeriodDescriptorId])
GO

ALTER TABLE [edfi].[GradingPeriod] WITH CHECK ADD CONSTRAINT [FK_GradingPeriod_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[GradingPeriod] WITH CHECK ADD CONSTRAINT [FK_GradingPeriod_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[GradingPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradingPeriodDescriptor_Descriptor] FOREIGN KEY ([GradingPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_CreditTypeDescriptor] FOREIGN KEY ([TotalRequiredCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_GraduationPlanTypeDescriptor] FOREIGN KEY ([GraduationPlanTypeDescriptorId])
REFERENCES [edfi].[GraduationPlanTypeDescriptor] ([GraduationPlanTypeDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_SchoolYearType] FOREIGN KEY ([GraduationSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourse_CreditTypeDescriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourse_GradeLevelDescriptor] FOREIGN KEY ([WhenTakenGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourse_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourseCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourseCourse_Course] FOREIGN KEY ([CourseCode], [CourseEducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourseCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourseCourse_GraduationPlanCreditsByCourse] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [CourseSetName])
REFERENCES [edfi].[GraduationPlanCreditsByCourse] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [CourseSetName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCreditCategory_CreditCategoryDescriptor] FOREIGN KEY ([CreditCategoryDescriptorId])
REFERENCES [edfi].[CreditCategoryDescriptor] ([CreditCategoryDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCreditCategory_CreditTypeDescriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCreditCategory_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsBySubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsBySubject_CreditTypeDescriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsBySubject_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessment] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessment_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessment] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessment_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_GraduationPlanRequiredAssessment] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[GraduationPlanRequiredAssessment] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentScore_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentScore_GraduationPlanRequiredAssessment] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[GraduationPlanRequiredAssessment] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentScore_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[GraduationPlanTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanTypeDescriptor_Descriptor] FOREIGN KEY ([GraduationPlanTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GunFreeSchoolsActReportingStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_GunFreeSchoolsActReportingStatusDescriptor_Descriptor] FOREIGN KEY ([GunFreeSchoolsActReportingStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_HomelessPrimaryNighttimeResidenceDescriptor_Descriptor] FOREIGN KEY ([HomelessPrimaryNighttimeResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[HomelessProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_HomelessProgramServiceDescriptor_Descriptor] FOREIGN KEY ([HomelessProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IDEAPartDescriptor] WITH CHECK ADD CONSTRAINT [FK_IDEAPartDescriptor_Descriptor] FOREIGN KEY ([IDEAPartDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IdentificationDocumentUseDescriptor] WITH CHECK ADD CONSTRAINT [FK_IdentificationDocumentUseDescriptor_Descriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IncidentLocationDescriptor] WITH CHECK ADD CONSTRAINT [FK_IncidentLocationDescriptor_Descriptor] FOREIGN KEY ([IncidentLocationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IndicatorDescriptor] WITH CHECK ADD CONSTRAINT [FK_IndicatorDescriptor_Descriptor] FOREIGN KEY ([IndicatorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IndicatorGroupDescriptor] WITH CHECK ADD CONSTRAINT [FK_IndicatorGroupDescriptor_Descriptor] FOREIGN KEY ([IndicatorGroupDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IndicatorLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_IndicatorLevelDescriptor_Descriptor] FOREIGN KEY ([IndicatorLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InstitutionTelephoneNumberTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_InstitutionTelephoneNumberTypeDescriptor_Descriptor] FOREIGN KEY ([InstitutionTelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InteractivityStyleDescriptor] WITH CHECK ADD CONSTRAINT [FK_InteractivityStyleDescriptor_Descriptor] FOREIGN KEY ([InteractivityStyleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InternetAccessDescriptor] WITH CHECK ADD CONSTRAINT [FK_InternetAccessDescriptor_Descriptor] FOREIGN KEY ([InternetAccessDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InternetAccessTypeInResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_InternetAccessTypeInResidenceDescriptor_Descriptor] FOREIGN KEY ([InternetAccessTypeInResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InternetPerformanceInResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_InternetPerformanceInResidenceDescriptor_Descriptor] FOREIGN KEY ([InternetPerformanceInResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Intervention] WITH CHECK ADD CONSTRAINT [FK_Intervention_DeliveryMethodDescriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[DeliveryMethodDescriptor] ([DeliveryMethodDescriptorId])
GO

ALTER TABLE [edfi].[Intervention] WITH CHECK ADD CONSTRAINT [FK_Intervention_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Intervention] WITH CHECK ADD CONSTRAINT [FK_Intervention_InterventionClassDescriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[InterventionClassDescriptor] ([InterventionClassDescriptorId])
GO

ALTER TABLE [edfi].[InterventionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[InterventionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateGradeLevel_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateSex_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[InterventionClassDescriptor] WITH CHECK ADD CONSTRAINT [FK_InterventionClassDescriptor_Descriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionDiagnosis_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

ALTER TABLE [edfi].[InterventionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionDiagnosis_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

ALTER TABLE [edfi].[InterventionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionEducationContent_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionEffectivenessRatingDescriptor] WITH CHECK ADD CONSTRAINT [FK_InterventionEffectivenessRatingDescriptor_Descriptor] FOREIGN KEY ([InterventionEffectivenessRatingDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionInterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionInterventionPrescription_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionInterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionInterventionPrescription_InterventionPrescription] FOREIGN KEY ([InterventionPrescriptionEducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
GO

ALTER TABLE [edfi].[InterventionLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_InterventionLearningResourceMetadataURI_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionMeetingTime] WITH CHECK ADD CONSTRAINT [FK_InterventionMeetingTime_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPopulationServed_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPopulationServed_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

ALTER TABLE [edfi].[InterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescription_DeliveryMethodDescriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[DeliveryMethodDescriptor] ([DeliveryMethodDescriptorId])
GO

ALTER TABLE [edfi].[InterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescription_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[InterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescription_InterventionClassDescriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[InterventionClassDescriptor] ([InterventionClassDescriptorId])
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateGradeLevel_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateSex_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[InterventionPrescriptionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionDiagnosis_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

ALTER TABLE [edfi].[InterventionPrescriptionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionDiagnosis_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

ALTER TABLE [edfi].[InterventionPrescriptionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionEducationContent_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionLearningResourceMetadataURI_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionPopulationServed_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionPopulationServed_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

ALTER TABLE [edfi].[InterventionPrescriptionURI] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionURI_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStaff] WITH CHECK ADD CONSTRAINT [FK_InterventionStaff_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStaff] WITH CHECK ADD CONSTRAINT [FK_InterventionStaff_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_DeliveryMethodDescriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[DeliveryMethodDescriptor] ([DeliveryMethodDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_InterventionClassDescriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[InterventionClassDescriptor] ([InterventionClassDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_InterventionPrescription] FOREIGN KEY ([InterventionPrescriptionEducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateGradeLevel_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateSex_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

ALTER TABLE [edfi].[InterventionStudyEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyEducationContent_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_InterventionEffectivenessRatingDescriptor] FOREIGN KEY ([InterventionEffectivenessRatingDescriptorId])
REFERENCES [edfi].[InterventionEffectivenessRatingDescriptor] ([InterventionEffectivenessRatingDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyLearningResourceMetadataURI_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyPopulationServed_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyPopulationServed_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyStateAbbreviation] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyStateAbbreviation_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyStateAbbreviation] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyStateAbbreviation_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[InterventionStudyURI] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyURI_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionURI] WITH CHECK ADD CONSTRAINT [FK_InterventionURI_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LanguageDescriptor] WITH CHECK ADD CONSTRAINT [FK_LanguageDescriptor_Descriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LanguageInstructionProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_LanguageInstructionProgramServiceDescriptor_Descriptor] FOREIGN KEY ([LanguageInstructionProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LanguageUseDescriptor] WITH CHECK ADD CONSTRAINT [FK_LanguageUseDescriptor_Descriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandard_LearningStandard] FOREIGN KEY ([ParentLearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[LearningStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandard_LearningStandardCategoryDescriptor] FOREIGN KEY ([LearningStandardCategoryDescriptorId])
REFERENCES [edfi].[LearningStandardCategoryDescriptor] ([LearningStandardCategoryDescriptorId])
GO

ALTER TABLE [edfi].[LearningStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandard_LearningStandardScopeDescriptor] FOREIGN KEY ([LearningStandardScopeDescriptorId])
REFERENCES [edfi].[LearningStandardScopeDescriptor] ([LearningStandardScopeDescriptorId])
GO

ALTER TABLE [edfi].[LearningStandardAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_LearningStandardAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[LearningStandardAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_LearningStandardAcademicSubject_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardCategoryDescriptor_Descriptor] FOREIGN KEY ([LearningStandardCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardContentStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandard_EducationOrganization] FOREIGN KEY ([MandatingEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[LearningStandardContentStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardContentStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandard_PublicationStatusDescriptor] FOREIGN KEY ([PublicationStatusDescriptorId])
REFERENCES [edfi].[PublicationStatusDescriptor] ([PublicationStatusDescriptorId])
GO

ALTER TABLE [edfi].[LearningStandardContentStandardAuthor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandardAuthor_LearningStandardContentStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandardContentStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceAssociation_LearningStandard] FOREIGN KEY ([SourceLearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceAssociation_LearningStandard1] FOREIGN KEY ([TargetLearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceAssociation_LearningStandardEquivalenceStrengthDescriptor] FOREIGN KEY ([LearningStandardEquivalenceStrengthDescriptorId])
REFERENCES [edfi].[LearningStandardEquivalenceStrengthDescriptor] ([LearningStandardEquivalenceStrengthDescriptorId])
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceStrengthDescriptor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceStrengthDescriptor_Descriptor] FOREIGN KEY ([LearningStandardEquivalenceStrengthDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardGradeLevel] WITH CHECK ADD CONSTRAINT [FK_LearningStandardGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[LearningStandardGradeLevel] WITH CHECK ADD CONSTRAINT [FK_LearningStandardGradeLevel_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_LearningStandardIdentificationCode_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardScopeDescriptor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardScopeDescriptor_Descriptor] FOREIGN KEY ([LearningStandardScopeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LevelOfEducationDescriptor] WITH CHECK ADD CONSTRAINT [FK_LevelOfEducationDescriptor_Descriptor] FOREIGN KEY ([LevelOfEducationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LicenseStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_LicenseStatusDescriptor_Descriptor] FOREIGN KEY ([LicenseStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LicenseTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_LicenseTypeDescriptor_Descriptor] FOREIGN KEY ([LicenseTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LimitedEnglishProficiencyDescriptor] WITH CHECK ADD CONSTRAINT [FK_LimitedEnglishProficiencyDescriptor_Descriptor] FOREIGN KEY ([LimitedEnglishProficiencyDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalAccount] WITH CHECK ADD CONSTRAINT [FK_LocalAccount_ChartOfAccount] FOREIGN KEY ([ChartOfAccountIdentifier], [ChartOfAccountEducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[ChartOfAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

ALTER TABLE [edfi].[LocalAccount] WITH CHECK ADD CONSTRAINT [FK_LocalAccount_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[LocalAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_LocalAccountReportingTag_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_LocalAccountReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[LocalActual] WITH CHECK ADD CONSTRAINT [FK_LocalActual_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

ALTER TABLE [edfi].[LocalActual] WITH CHECK ADD CONSTRAINT [FK_LocalActual_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

ALTER TABLE [edfi].[LocalBudget] WITH CHECK ADD CONSTRAINT [FK_LocalBudget_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

ALTER TABLE [edfi].[LocalBudget] WITH CHECK ADD CONSTRAINT [FK_LocalBudget_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

ALTER TABLE [edfi].[LocalContractedStaff] WITH CHECK ADD CONSTRAINT [FK_LocalContractedStaff_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

ALTER TABLE [edfi].[LocalContractedStaff] WITH CHECK ADD CONSTRAINT [FK_LocalContractedStaff_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

ALTER TABLE [edfi].[LocalContractedStaff] WITH CHECK ADD CONSTRAINT [FK_LocalContractedStaff_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[LocaleDescriptor] WITH CHECK ADD CONSTRAINT [FK_LocaleDescriptor_Descriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_CharterStatusDescriptor] FOREIGN KEY ([CharterStatusDescriptorId])
REFERENCES [edfi].[CharterStatusDescriptor] ([CharterStatusDescriptorId])
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_EducationOrganization] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_EducationServiceCenter] FOREIGN KEY ([EducationServiceCenterId])
REFERENCES [edfi].[EducationServiceCenter] ([EducationServiceCenterId])
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_LocalEducationAgency] FOREIGN KEY ([ParentLocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_LocalEducationAgencyCategoryDescriptor] FOREIGN KEY ([LocalEducationAgencyCategoryDescriptorId])
REFERENCES [edfi].[LocalEducationAgencyCategoryDescriptor] ([LocalEducationAgencyCategoryDescriptorId])
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_GunFreeSchoolsActReportingStatusDescriptor] FOREIGN KEY ([GunFreeSchoolsActReportingStatusDescriptorId])
REFERENCES [edfi].[GunFreeSchoolsActReportingStatusDescriptor] ([GunFreeSchoolsActReportingStatusDescriptorId])
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_LocalEducationAgency] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_SchoolChoiceImplementStatusDescriptor] FOREIGN KEY ([SchoolChoiceImplementStatusDescriptorId])
REFERENCES [edfi].[SchoolChoiceImplementStatusDescriptor] ([SchoolChoiceImplementStatusDescriptorId])
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[LocalEducationAgencyCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyCategoryDescriptor_Descriptor] FOREIGN KEY ([LocalEducationAgencyCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgencyFederalFunds] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyFederalFunds_LocalEducationAgency] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEncumbrance] WITH CHECK ADD CONSTRAINT [FK_LocalEncumbrance_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

ALTER TABLE [edfi].[LocalEncumbrance] WITH CHECK ADD CONSTRAINT [FK_LocalEncumbrance_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

ALTER TABLE [edfi].[LocalPayroll] WITH CHECK ADD CONSTRAINT [FK_LocalPayroll_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

ALTER TABLE [edfi].[LocalPayroll] WITH CHECK ADD CONSTRAINT [FK_LocalPayroll_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

ALTER TABLE [edfi].[LocalPayroll] WITH CHECK ADD CONSTRAINT [FK_LocalPayroll_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[Location] WITH CHECK ADD CONSTRAINT [FK_Location_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] WITH CHECK ADD CONSTRAINT [FK_MagnetSpecialProgramEmphasisSchoolDescriptor_Descriptor] FOREIGN KEY ([MagnetSpecialProgramEmphasisSchoolDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MediumOfInstructionDescriptor] WITH CHECK ADD CONSTRAINT [FK_MediumOfInstructionDescriptor_Descriptor] FOREIGN KEY ([MediumOfInstructionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MethodCreditEarnedDescriptor] WITH CHECK ADD CONSTRAINT [FK_MethodCreditEarnedDescriptor_Descriptor] FOREIGN KEY ([MethodCreditEarnedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MigrantEducationProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_MigrantEducationProgramServiceDescriptor_Descriptor] FOREIGN KEY ([MigrantEducationProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ModelEntityDescriptor] WITH CHECK ADD CONSTRAINT [FK_ModelEntityDescriptor_Descriptor] FOREIGN KEY ([ModelEntityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MonitoredDescriptor] WITH CHECK ADD CONSTRAINT [FK_MonitoredDescriptor_Descriptor] FOREIGN KEY ([MonitoredDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramDescriptor] WITH CHECK ADD CONSTRAINT [FK_NeglectedOrDelinquentProgramDescriptor_Descriptor] FOREIGN KEY ([NeglectedOrDelinquentProgramDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_NeglectedOrDelinquentProgramServiceDescriptor_Descriptor] FOREIGN KEY ([NeglectedOrDelinquentProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[NetworkPurposeDescriptor] WITH CHECK ADD CONSTRAINT [FK_NetworkPurposeDescriptor_Descriptor] FOREIGN KEY ([NetworkPurposeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ObjectDimensionReportingTag_ObjectDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[ObjectDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ObjectDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[ObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessment_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[ObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessment_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

ALTER TABLE [edfi].[ObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessment_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [ParentIdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

ALTER TABLE [edfi].[ObjectiveAssessmentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentAssessmentItem_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [AssessmentItemIdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

ALTER TABLE [edfi].[ObjectiveAssessmentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentAssessmentItem_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[ObjectiveAssessmentLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentLearningStandard_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[ObjectiveAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentScore_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[ObjectiveAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentScore_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentScore_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_EmploymentStatusDescriptor] FOREIGN KEY ([EmploymentStatusDescriptorId])
REFERENCES [edfi].[EmploymentStatusDescriptor] ([EmploymentStatusDescriptorId])
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_PostingResultDescriptor] FOREIGN KEY ([PostingResultDescriptorId])
REFERENCES [edfi].[PostingResultDescriptor] ([PostingResultDescriptorId])
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_ProgramAssignmentDescriptor] FOREIGN KEY ([ProgramAssignmentDescriptorId])
REFERENCES [edfi].[ProgramAssignmentDescriptor] ([ProgramAssignmentDescriptorId])
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_StaffClassificationDescriptor] FOREIGN KEY ([StaffClassificationDescriptorId])
REFERENCES [edfi].[StaffClassificationDescriptor] ([StaffClassificationDescriptorId])
GO

ALTER TABLE [edfi].[OpenStaffPositionAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[OpenStaffPositionAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionAcademicSubject_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionInstructionalGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionInstructionalGradeLevel_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OperationalStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_OperationalStatusDescriptor_Descriptor] FOREIGN KEY ([OperationalStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OperationalUnitDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_OperationalUnitDimensionReportingTag_OperationalUnitDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[OperationalUnitDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OperationalUnitDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_OperationalUnitDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[OrganizationDepartment] WITH CHECK ADD CONSTRAINT [FK_OrganizationDepartment_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[OrganizationDepartment] WITH CHECK ADD CONSTRAINT [FK_OrganizationDepartment_EducationOrganization] FOREIGN KEY ([OrganizationDepartmentId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OrganizationDepartment] WITH CHECK ADD CONSTRAINT [FK_OrganizationDepartment_EducationOrganization1] FOREIGN KEY ([ParentEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[OtherNameTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_OtherNameTypeDescriptor_Descriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ParticipationDescriptor] WITH CHECK ADD CONSTRAINT [FK_ParticipationDescriptor_Descriptor] FOREIGN KEY ([ParticipationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ParticipationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ParticipationStatusDescriptor_Descriptor] FOREIGN KEY ([ParticipationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceBaseConversionDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceBaseConversionDescriptor_Descriptor] FOREIGN KEY ([PerformanceBaseConversionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceLevelDescriptor_Descriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Person] WITH CHECK ADD CONSTRAINT [FK_Person_SourceSystemDescriptor] FOREIGN KEY ([SourceSystemDescriptorId])
REFERENCES [edfi].[SourceSystemDescriptor] ([SourceSystemDescriptorId])
GO

ALTER TABLE [edfi].[PersonalInformationVerificationDescriptor] WITH CHECK ADD CONSTRAINT [FK_PersonalInformationVerificationDescriptor_Descriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PlatformTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_PlatformTypeDescriptor_Descriptor] FOREIGN KEY ([PlatformTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PopulationServedDescriptor] WITH CHECK ADD CONSTRAINT [FK_PopulationServedDescriptor_Descriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostingResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_PostingResultDescriptor_Descriptor] FOREIGN KEY ([PostingResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryEvent] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEvent_PostSecondaryEventCategoryDescriptor] FOREIGN KEY ([PostSecondaryEventCategoryDescriptorId])
REFERENCES [edfi].[PostSecondaryEventCategoryDescriptor] ([PostSecondaryEventCategoryDescriptorId])
GO

ALTER TABLE [edfi].[PostSecondaryEvent] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEvent_PostSecondaryInstitution] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionId])
GO

ALTER TABLE [edfi].[PostSecondaryEvent] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[PostSecondaryEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEventCategoryDescriptor_Descriptor] FOREIGN KEY ([PostSecondaryEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitution_AdministrativeFundingControlDescriptor] FOREIGN KEY ([AdministrativeFundingControlDescriptorId])
REFERENCES [edfi].[AdministrativeFundingControlDescriptor] ([AdministrativeFundingControlDescriptorId])
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitution_EducationOrganization] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitution_PostSecondaryInstitutionLevelDescriptor] FOREIGN KEY ([PostSecondaryInstitutionLevelDescriptorId])
REFERENCES [edfi].[PostSecondaryInstitutionLevelDescriptor] ([PostSecondaryInstitutionLevelDescriptorId])
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionLevelDescriptor_Descriptor] FOREIGN KEY ([PostSecondaryInstitutionLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionMediumOfInstruction] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionMediumOfInstruction_MediumOfInstructionDescriptor] FOREIGN KEY ([MediumOfInstructionDescriptorId])
REFERENCES [edfi].[MediumOfInstructionDescriptor] ([MediumOfInstructionDescriptorId])
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionMediumOfInstruction] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionMediumOfInstruction_PostSecondaryInstitution] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAccessDescriptor] WITH CHECK ADD CONSTRAINT [FK_PrimaryLearningDeviceAccessDescriptor_Descriptor] FOREIGN KEY ([PrimaryLearningDeviceAccessDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] WITH CHECK ADD CONSTRAINT [FK_PrimaryLearningDeviceAwayFromSchoolDescriptor_Descriptor] FOREIGN KEY ([PrimaryLearningDeviceAwayFromSchoolDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceProviderDescriptor] WITH CHECK ADD CONSTRAINT [FK_PrimaryLearningDeviceProviderDescriptor_Descriptor] FOREIGN KEY ([PrimaryLearningDeviceProviderDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProficiencyDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProficiencyDescriptor_Descriptor] FOREIGN KEY ([ProficiencyDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Program] WITH CHECK ADD CONSTRAINT [FK_Program_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Program] WITH CHECK ADD CONSTRAINT [FK_Program_ProgramTypeDescriptor] FOREIGN KEY ([ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramTypeDescriptor] ([ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[ProgramAssignmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramAssignmentDescriptor_Descriptor] FOREIGN KEY ([ProgramAssignmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ProgramCharacteristic_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ProgramCharacteristic_ProgramCharacteristicDescriptor] FOREIGN KEY ([ProgramCharacteristicDescriptorId])
REFERENCES [edfi].[ProgramCharacteristicDescriptor] ([ProgramCharacteristicDescriptorId])
GO

ALTER TABLE [edfi].[ProgramCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramCharacteristicDescriptor_Descriptor] FOREIGN KEY ([ProgramCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProgramDimensionReportingTag_ProgramDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[ProgramDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProgramDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluation_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluation_ProgramEvaluationPeriodDescriptor] FOREIGN KEY ([ProgramEvaluationPeriodDescriptorId])
REFERENCES [edfi].[ProgramEvaluationPeriodDescriptor] ([ProgramEvaluationPeriodDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluation_ProgramEvaluationTypeDescriptor] FOREIGN KEY ([ProgramEvaluationTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationTypeDescriptor] ([ProgramEvaluationTypeDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElement_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElement_ProgramEvaluationObjective] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationObjective] ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluationElementRatingLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElementRatingLevel_ProgramEvaluationElement] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationElementRatingLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElementRatingLevel_RatingLevelDescriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationObjective_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluationObjectiveRatingLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationObjectiveRatingLevel_ProgramEvaluationObjective] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationObjective] ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationObjectiveRatingLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationObjectiveRatingLevel_RatingLevelDescriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluationPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationPeriodDescriptor_Descriptor] FOREIGN KEY ([ProgramEvaluationPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationRatingLevel_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationRatingLevel_RatingLevelDescriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

ALTER TABLE [edfi].[ProgramEvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([ProgramEvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ProgramLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [edfi].[ProgramLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ProgramLearningStandard_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramSponsor] WITH CHECK ADD CONSTRAINT [FK_ProgramSponsor_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramSponsor] WITH CHECK ADD CONSTRAINT [FK_ProgramSponsor_ProgramSponsorDescriptor] FOREIGN KEY ([ProgramSponsorDescriptorId])
REFERENCES [edfi].[ProgramSponsorDescriptor] ([ProgramSponsorDescriptorId])
GO

ALTER TABLE [edfi].[ProgramSponsorDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramSponsorDescriptor_Descriptor] FOREIGN KEY ([ProgramSponsorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramTypeDescriptor_Descriptor] FOREIGN KEY ([ProgramTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgressDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgressDescriptor_Descriptor] FOREIGN KEY ([ProgressDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgressLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgressLevelDescriptor_Descriptor] FOREIGN KEY ([ProgressLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProjectDimensionReportingTag_ProjectDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[ProjectDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProjectDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[ProviderCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProviderCategoryDescriptor_Descriptor] FOREIGN KEY ([ProviderCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProviderProfitabilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProviderProfitabilityDescriptor_Descriptor] FOREIGN KEY ([ProviderProfitabilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProviderStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProviderStatusDescriptor_Descriptor] FOREIGN KEY ([ProviderStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PublicationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_PublicationStatusDescriptor_Descriptor] FOREIGN KEY ([PublicationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[QuestionFormDescriptor] WITH CHECK ADD CONSTRAINT [FK_QuestionFormDescriptor_Descriptor] FOREIGN KEY ([QuestionFormDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RaceDescriptor] WITH CHECK ADD CONSTRAINT [FK_RaceDescriptor_Descriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_RatingLevelDescriptor_Descriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReasonExitedDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReasonExitedDescriptor_Descriptor] FOREIGN KEY ([ReasonExitedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReasonNotTestedDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReasonNotTestedDescriptor_Descriptor] FOREIGN KEY ([ReasonNotTestedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecognitionTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_RecognitionTypeDescriptor_Descriptor] FOREIGN KEY ([RecognitionTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RelationDescriptor] WITH CHECK ADD CONSTRAINT [FK_RelationDescriptor_Descriptor] FOREIGN KEY ([RelationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RepeatIdentifierDescriptor] WITH CHECK ADD CONSTRAINT [FK_RepeatIdentifierDescriptor_Descriptor] FOREIGN KEY ([RepeatIdentifierDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCard] WITH CHECK ADD CONSTRAINT [FK_ReportCard_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[ReportCard] WITH CHECK ADD CONSTRAINT [FK_ReportCard_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [PeriodSequence], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[ReportCard] WITH CHECK ADD CONSTRAINT [FK_ReportCard_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[ReportCardGrade] WITH CHECK ADD CONSTRAINT [FK_ReportCardGrade_Grade] FOREIGN KEY ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[Grade] ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[ReportCardGrade] WITH CHECK ADD CONSTRAINT [FK_ReportCardGrade_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCardGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ReportCardGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

ALTER TABLE [edfi].[ReportCardGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ReportCardGradePointAverage_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCardStudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_ReportCardStudentCompetencyObjective_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCardStudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_ReportCardStudentCompetencyObjective_StudentCompetencyObjective] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCompetencyObjective] ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
GO

ALTER TABLE [edfi].[ReporterDescriptionDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReporterDescriptionDescriptor_Descriptor] FOREIGN KEY ([ReporterDescriptionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportingTagDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReportingTagDescriptor_Descriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResidencyStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResidencyStatusDescriptor_Descriptor] FOREIGN KEY ([ResidencyStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResponseIndicatorDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResponseIndicatorDescriptor_Descriptor] FOREIGN KEY ([ResponseIndicatorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResponsibilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResponsibilityDescriptor_Descriptor] FOREIGN KEY ([ResponsibilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RestraintEvent] WITH CHECK ADD CONSTRAINT [FK_RestraintEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

ALTER TABLE [edfi].[RestraintEvent] WITH CHECK ADD CONSTRAINT [FK_RestraintEvent_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[RestraintEvent] WITH CHECK ADD CONSTRAINT [FK_RestraintEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[RestraintEventProgram] WITH CHECK ADD CONSTRAINT [FK_RestraintEventProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[RestraintEventProgram] WITH CHECK ADD CONSTRAINT [FK_RestraintEventProgram_RestraintEvent] FOREIGN KEY ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[RestraintEvent] ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RestraintEventReason] WITH CHECK ADD CONSTRAINT [FK_RestraintEventReason_RestraintEvent] FOREIGN KEY ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[RestraintEvent] ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RestraintEventReason] WITH CHECK ADD CONSTRAINT [FK_RestraintEventReason_RestraintEventReasonDescriptor] FOREIGN KEY ([RestraintEventReasonDescriptorId])
REFERENCES [edfi].[RestraintEventReasonDescriptor] ([RestraintEventReasonDescriptorId])
GO

ALTER TABLE [edfi].[RestraintEventReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_RestraintEventReasonDescriptor_Descriptor] FOREIGN KEY ([RestraintEventReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResultDatatypeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResultDatatypeTypeDescriptor_Descriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RetestIndicatorDescriptor] WITH CHECK ADD CONSTRAINT [FK_RetestIndicatorDescriptor_Descriptor] FOREIGN KEY ([RetestIndicatorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_AdministrativeFundingControlDescriptor] FOREIGN KEY ([AdministrativeFundingControlDescriptorId])
REFERENCES [edfi].[AdministrativeFundingControlDescriptor] ([AdministrativeFundingControlDescriptorId])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_CharterApprovalAgencyTypeDescriptor] FOREIGN KEY ([CharterApprovalAgencyTypeDescriptorId])
REFERENCES [edfi].[CharterApprovalAgencyTypeDescriptor] ([CharterApprovalAgencyTypeDescriptorId])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_CharterStatusDescriptor] FOREIGN KEY ([CharterStatusDescriptorId])
REFERENCES [edfi].[CharterStatusDescriptor] ([CharterStatusDescriptorId])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_EducationOrganization] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_InternetAccessDescriptor] FOREIGN KEY ([InternetAccessDescriptorId])
REFERENCES [edfi].[InternetAccessDescriptor] ([InternetAccessDescriptorId])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_LocalEducationAgency] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_MagnetSpecialProgramEmphasisSchoolDescriptor] FOREIGN KEY ([MagnetSpecialProgramEmphasisSchoolDescriptorId])
REFERENCES [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] ([MagnetSpecialProgramEmphasisSchoolDescriptorId])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_SchoolTypeDescriptor] FOREIGN KEY ([SchoolTypeDescriptorId])
REFERENCES [edfi].[SchoolTypeDescriptor] ([SchoolTypeDescriptorId])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_SchoolYearType] FOREIGN KEY ([CharterApprovalSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_TitleIPartASchoolDesignationDescriptor] FOREIGN KEY ([TitleIPartASchoolDesignationDescriptorId])
REFERENCES [edfi].[TitleIPartASchoolDesignationDescriptor] ([TitleIPartASchoolDesignationDescriptorId])
GO

ALTER TABLE [edfi].[SchoolCategory] WITH CHECK ADD CONSTRAINT [FK_SchoolCategory_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolCategory] WITH CHECK ADD CONSTRAINT [FK_SchoolCategory_SchoolCategoryDescriptor] FOREIGN KEY ([SchoolCategoryDescriptorId])
REFERENCES [edfi].[SchoolCategoryDescriptor] ([SchoolCategoryDescriptorId])
GO

ALTER TABLE [edfi].[SchoolCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolCategoryDescriptor_Descriptor] FOREIGN KEY ([SchoolCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolChoiceBasisDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolChoiceBasisDescriptor_Descriptor] FOREIGN KEY ([SchoolChoiceBasisDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolChoiceImplementStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolChoiceImplementStatusDescriptor_Descriptor] FOREIGN KEY ([SchoolChoiceImplementStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolFoodServiceProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolFoodServiceProgramServiceDescriptor_Descriptor] FOREIGN KEY ([SchoolFoodServiceProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SchoolGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[SchoolGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SchoolGradeLevel_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolTypeDescriptor_Descriptor] FOREIGN KEY ([SchoolTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_CreditTypeDescriptor] FOREIGN KEY ([AvailableCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_LanguageDescriptor] FOREIGN KEY ([InstructionLanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_Location] FOREIGN KEY ([LocationClassroomIdentificationCode], [LocationSchoolId])
REFERENCES [edfi].[Location] ([ClassroomIdentificationCode], [SchoolId])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_MediumOfInstructionDescriptor] FOREIGN KEY ([MediumOfInstructionDescriptorId])
REFERENCES [edfi].[MediumOfInstructionDescriptor] ([MediumOfInstructionDescriptorId])
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_School] FOREIGN KEY ([LocationSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] WITH CHECK ADD CONSTRAINT [FK_SectionAttendanceTakenEvent_CalendarDate] FOREIGN KEY ([CalendarCode], [Date], [SchoolId], [SchoolYear])
REFERENCES [edfi].[CalendarDate] ([CalendarCode], [Date], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] WITH CHECK ADD CONSTRAINT [FK_SectionAttendanceTakenEvent_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] WITH CHECK ADD CONSTRAINT [FK_SectionAttendanceTakenEvent_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[SectionCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCharacteristic_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCharacteristic_SectionCharacteristicDescriptor] FOREIGN KEY ([SectionCharacteristicDescriptorId])
REFERENCES [edfi].[SectionCharacteristicDescriptor] ([SectionCharacteristicDescriptorId])
GO

ALTER TABLE [edfi].[SectionCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_SectionCharacteristicDescriptor_Descriptor] FOREIGN KEY ([SectionCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SectionClassPeriod] WITH CHECK ADD CONSTRAINT [FK_SectionClassPeriod_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionClassPeriod] WITH CHECK ADD CONSTRAINT [FK_SectionClassPeriod_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCourseLevelCharacteristic_CourseLevelCharacteristicDescriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[CourseLevelCharacteristicDescriptor] ([CourseLevelCharacteristicDescriptorId])
GO

ALTER TABLE [edfi].[SectionCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCourseLevelCharacteristic_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SectionOfferedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[SectionOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SectionOfferedGradeLevel_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionProgram] WITH CHECK ADD CONSTRAINT [FK_SectionProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[SectionProgram] WITH CHECK ADD CONSTRAINT [FK_SectionProgram_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SeparationDescriptor] WITH CHECK ADD CONSTRAINT [FK_SeparationDescriptor_Descriptor] FOREIGN KEY ([SeparationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SeparationReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_SeparationReasonDescriptor_Descriptor] FOREIGN KEY ([SeparationReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_ServiceDescriptor_Descriptor] FOREIGN KEY ([ServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Session] WITH CHECK ADD CONSTRAINT [FK_Session_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[Session] WITH CHECK ADD CONSTRAINT [FK_Session_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[Session] WITH CHECK ADD CONSTRAINT [FK_Session_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

ALTER TABLE [edfi].[SessionAcademicWeek] WITH CHECK ADD CONSTRAINT [FK_SessionAcademicWeek_AcademicWeek] FOREIGN KEY ([SchoolId], [WeekIdentifier])
REFERENCES [edfi].[AcademicWeek] ([SchoolId], [WeekIdentifier])
GO

ALTER TABLE [edfi].[SessionAcademicWeek] WITH CHECK ADD CONSTRAINT [FK_SessionAcademicWeek_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SessionGradingPeriod] WITH CHECK ADD CONSTRAINT [FK_SessionGradingPeriod_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [PeriodSequence], [SchoolId], [SchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [PeriodSequence], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[SessionGradingPeriod] WITH CHECK ADD CONSTRAINT [FK_SessionGradingPeriod_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SexDescriptor] WITH CHECK ADD CONSTRAINT [FK_SexDescriptor_Descriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SourceDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_SourceDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

ALTER TABLE [edfi].[SourceDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_SourceDimensionReportingTag_SourceDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[SourceDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SourceSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_SourceSystemDescriptor_Descriptor] FOREIGN KEY ([SourceSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SpecialEducationProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_SpecialEducationProgramServiceDescriptor_Descriptor] FOREIGN KEY ([SpecialEducationProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SpecialEducationSettingDescriptor] WITH CHECK ADD CONSTRAINT [FK_SpecialEducationSettingDescriptor_Descriptor] FOREIGN KEY ([SpecialEducationSettingDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

ALTER TABLE [edfi].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_LevelOfEducationDescriptor] FOREIGN KEY ([HighestCompletedLevelOfEducationDescriptorId])
REFERENCES [edfi].[LevelOfEducationDescriptor] ([LevelOfEducationDescriptorId])
GO

ALTER TABLE [edfi].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

ALTER TABLE [edfi].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[StaffAbsenceEvent] WITH CHECK ADD CONSTRAINT [FK_StaffAbsenceEvent_AbsenceEventCategoryDescriptor] FOREIGN KEY ([AbsenceEventCategoryDescriptorId])
REFERENCES [edfi].[AbsenceEventCategoryDescriptor] ([AbsenceEventCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StaffAbsenceEvent] WITH CHECK ADD CONSTRAINT [FK_StaffAbsenceEvent_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffAddress] WITH CHECK ADD CONSTRAINT [FK_StaffAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffAddress] WITH CHECK ADD CONSTRAINT [FK_StaffAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

ALTER TABLE [edfi].[StaffAddress] WITH CHECK ADD CONSTRAINT [FK_StaffAddress_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffAddress] WITH CHECK ADD CONSTRAINT [FK_StaffAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[StaffAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_StaffAddressPeriod_StaffAddress] FOREIGN KEY ([StaffUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[StaffAddress] ([StaffUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StaffAncestryEthnicOrigin_AncestryEthnicOriginDescriptor] FOREIGN KEY ([AncestryEthnicOriginDescriptorId])
REFERENCES [edfi].[AncestryEthnicOriginDescriptor] ([AncestryEthnicOriginDescriptorId])
GO

ALTER TABLE [edfi].[StaffAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StaffAncestryEthnicOrigin_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffClassificationDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffClassificationDescriptor_Descriptor] FOREIGN KEY ([StaffClassificationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffCohortAssociation_Cohort] FOREIGN KEY ([CohortIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffCohortAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffCredential] WITH CHECK ADD CONSTRAINT [FK_StaffCredential_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[StaffCredential] WITH CHECK ADD CONSTRAINT [FK_StaffCredential_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociation_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_StaffDisciplineIncidentAssociation] FOREIGN KEY ([IncidentIdentifier], [SchoolId], [StaffUSI])
REFERENCES [edfi].[StaffDisciplineIncidentAssociation] ([IncidentIdentifier], [SchoolId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_StaffClassificationDescriptor] FOREIGN KEY ([StaffClassificationDescriptorId])
REFERENCES [edfi].[StaffClassificationDescriptor] ([StaffClassificationDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EmploymentEducationOrganizationId], [EmploymentStatusDescriptorId], [EmploymentHireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociation_ContactTypeDescriptor] FOREIGN KEY ([ContactTypeDescriptorId])
REFERENCES [edfi].[ContactTypeDescriptor] ([ContactTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociationAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociationAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociationAddress_StaffEducationOrganizationContactAssociation] FOREIGN KEY ([ContactTitle], [EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationContactAssociation] ([ContactTitle], [EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociationAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociationAddressPeriod_StaffEducationOrganizationContactAssociationAddress] FOREIGN KEY ([ContactTitle], [EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationContactAssociationAddress] ([ContactTitle], [EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationTelephone] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociationTelephone_StaffEducationOrganizationContactAssociation] FOREIGN KEY ([ContactTitle], [EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationContactAssociation] ([ContactTitle], [EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationTelephone] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationContactAssociationTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_EmploymentStatusDescriptor] FOREIGN KEY ([EmploymentStatusDescriptorId])
REFERENCES [edfi].[EmploymentStatusDescriptor] ([EmploymentStatusDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_SeparationDescriptor] FOREIGN KEY ([SeparationDescriptorId])
REFERENCES [edfi].[SeparationDescriptor] ([SeparationDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_SeparationReasonDescriptor] FOREIGN KEY ([SeparationReasonDescriptorId])
REFERENCES [edfi].[SeparationReasonDescriptor] ([SeparationReasonDescriptorId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StaffElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StaffElectronicMail_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationCode_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationCode_StaffIdentificationSystemDescriptor] FOREIGN KEY ([StaffIdentificationSystemDescriptorId])
REFERENCES [edfi].[StaffIdentificationSystemDescriptor] ([StaffIdentificationSystemDescriptorId])
GO

ALTER TABLE [edfi].[StaffIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[StaffIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

ALTER TABLE [edfi].[StaffIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

ALTER TABLE [edfi].[StaffIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationDocument_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([StaffIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StaffInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StaffInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[StaffInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StaffInternationalAddress_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffLanguage] WITH CHECK ADD CONSTRAINT [FK_StaffLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

ALTER TABLE [edfi].[StaffLanguage] WITH CHECK ADD CONSTRAINT [FK_StaffLanguage_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StaffLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

ALTER TABLE [edfi].[StaffLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StaffLanguageUse_StaffLanguage] FOREIGN KEY ([StaffUSI], [LanguageDescriptorId])
REFERENCES [edfi].[StaffLanguage] ([StaffUSI], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffLeave] WITH CHECK ADD CONSTRAINT [FK_StaffLeave_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffLeave] WITH CHECK ADD CONSTRAINT [FK_StaffLeave_StaffLeaveEventCategoryDescriptor] FOREIGN KEY ([StaffLeaveEventCategoryDescriptorId])
REFERENCES [edfi].[StaffLeaveEventCategoryDescriptor] ([StaffLeaveEventCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StaffLeaveEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffLeaveEventCategoryDescriptor_Descriptor] FOREIGN KEY ([StaffLeaveEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffOtherName] WITH CHECK ADD CONSTRAINT [FK_StaffOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffOtherName] WITH CHECK ADD CONSTRAINT [FK_StaffOtherName_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffProgramAssociation_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffProgramAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffRace] WITH CHECK ADD CONSTRAINT [FK_StaffRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

ALTER TABLE [edfi].[StaffRace] WITH CHECK ADD CONSTRAINT [FK_StaffRace_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffRecognition] WITH CHECK ADD CONSTRAINT [FK_StaffRecognition_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StaffRecognition] WITH CHECK ADD CONSTRAINT [FK_StaffRecognition_RecognitionTypeDescriptor] FOREIGN KEY ([RecognitionTypeDescriptorId])
REFERENCES [edfi].[RecognitionTypeDescriptor] ([RecognitionTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffRecognition] WITH CHECK ADD CONSTRAINT [FK_StaffRecognition_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_ProgramAssignmentDescriptor] FOREIGN KEY ([ProgramAssignmentDescriptorId])
REFERENCES [edfi].[ProgramAssignmentDescriptor] ([ProgramAssignmentDescriptorId])
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffSchoolAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

ALTER TABLE [edfi].[StaffSchoolAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationAcademicSubject_StaffSchoolAssociation] FOREIGN KEY ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
REFERENCES [edfi].[StaffSchoolAssociation] ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffSchoolAssociationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[StaffSchoolAssociationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationGradeLevel_StaffSchoolAssociation] FOREIGN KEY ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
REFERENCES [edfi].[StaffSchoolAssociation] ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSectionAssociation_ClassroomPositionDescriptor] FOREIGN KEY ([ClassroomPositionDescriptorId])
REFERENCES [edfi].[ClassroomPositionDescriptor] ([ClassroomPositionDescriptorId])
GO

ALTER TABLE [edfi].[StaffSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StaffSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSectionAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffTelephone] WITH CHECK ADD CONSTRAINT [FK_StaffTelephone_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffTelephone] WITH CHECK ADD CONSTRAINT [FK_StaffTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

ALTER TABLE [edfi].[StaffTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StaffTribalAffiliation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StaffTribalAffiliation_TribalAffiliationDescriptor] FOREIGN KEY ([TribalAffiliationDescriptorId])
REFERENCES [edfi].[TribalAffiliationDescriptor] ([TribalAffiliationDescriptorId])
GO

ALTER TABLE [edfi].[StaffVisa] WITH CHECK ADD CONSTRAINT [FK_StaffVisa_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffVisa] WITH CHECK ADD CONSTRAINT [FK_StaffVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

ALTER TABLE [edfi].[StateAbbreviationDescriptor] WITH CHECK ADD CONSTRAINT [FK_StateAbbreviationDescriptor_Descriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StateEducationAgency] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgency_EducationOrganization] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StateEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyAccountability_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StateEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyAccountability_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StateEducationAgencyFederalFunds] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyFederalFunds_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_CountryDescriptor] FOREIGN KEY ([BirthCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_SexDescriptor] FOREIGN KEY ([BirthSexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_StateAbbreviationDescriptor] FOREIGN KEY ([BirthStateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor] FOREIGN KEY ([CumulativeEarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor1] FOREIGN KEY ([CumulativeAttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor2] FOREIGN KEY ([SessionEarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor3] FOREIGN KEY ([SessionAttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordAcademicHonor_AcademicHonorCategoryDescriptor] FOREIGN KEY ([AcademicHonorCategoryDescriptorId])
REFERENCES [edfi].[AcademicHonorCategoryDescriptor] ([AcademicHonorCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordAcademicHonor_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordAcademicHonor_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordClassRanking] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordClassRanking_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_DiplomaLevelDescriptor] FOREIGN KEY ([DiplomaLevelDescriptorId])
REFERENCES [edfi].[DiplomaLevelDescriptor] ([DiplomaLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_DiplomaTypeDescriptor] FOREIGN KEY ([DiplomaTypeDescriptorId])
REFERENCES [edfi].[DiplomaTypeDescriptor] ([DiplomaTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordGradePointAverage_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordRecognition_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordRecognition_RecognitionTypeDescriptor] FOREIGN KEY ([RecognitionTypeDescriptorId])
REFERENCES [edfi].[RecognitionTypeDescriptor] ([RecognitionTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordRecognition_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordReportCard] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordReportCard_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
GO

ALTER TABLE [edfi].[StudentAcademicRecordReportCard] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordReportCard_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_AdministrationEnvironmentDescriptor] FOREIGN KEY ([AdministrationEnvironmentDescriptorId])
REFERENCES [edfi].[AdministrationEnvironmentDescriptor] ([AdministrationEnvironmentDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_EventCircumstanceDescriptor] FOREIGN KEY ([EventCircumstanceDescriptorId])
REFERENCES [edfi].[EventCircumstanceDescriptor] ([EventCircumstanceDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_GradeLevelDescriptor] FOREIGN KEY ([WhenAssessedGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_LanguageDescriptor] FOREIGN KEY ([AdministrationLanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_PlatformTypeDescriptor] FOREIGN KEY ([PlatformTypeDescriptorId])
REFERENCES [edfi].[PlatformTypeDescriptor] ([PlatformTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_ReasonNotTestedDescriptor] FOREIGN KEY ([ReasonNotTestedDescriptorId])
REFERENCES [edfi].[ReasonNotTestedDescriptor] ([ReasonNotTestedDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_RetestIndicatorDescriptor] FOREIGN KEY ([RetestIndicatorDescriptorId])
REFERENCES [edfi].[RetestIndicatorDescriptor] ([RetestIndicatorDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_School] FOREIGN KEY ([ReportedSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentAccommodation_AccommodationDescriptor] FOREIGN KEY ([AccommodationDescriptorId])
REFERENCES [edfi].[AccommodationDescriptor] ([AccommodationDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentAccommodation_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationAssociationTypeDescriptor] FOREIGN KEY ([EducationOrganizationAssociationTypeDescriptorId])
REFERENCES [edfi].[EducationOrganizationAssociationTypeDescriptor] ([EducationOrganizationAssociationTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_AssessmentItemResultDescriptor] FOREIGN KEY ([AssessmentItemResultDescriptorId])
REFERENCES [edfi].[AssessmentItemResultDescriptor] ([AssessmentItemResultDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_ResponseIndicatorDescriptor] FOREIGN KEY ([ResponseIndicatorDescriptorId])
REFERENCES [edfi].[ResponseIndicatorDescriptor] ([ResponseIndicatorDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPerformanceLevel_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPeriod_AssessmentPeriodDescriptor] FOREIGN KEY ([AssessmentPeriodDescriptorId])
REFERENCES [edfi].[AssessmentPeriodDescriptor] ([AssessmentPeriodDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPeriod_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentScoreResult_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentScoreResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentScoreResult_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessment_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessment_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_StudentAssessmentStudentObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
REFERENCES [edfi].[StudentAssessmentStudentObjectiveAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_StudentAssessmentStudentObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
REFERENCES [edfi].[StudentAssessmentStudentObjectiveAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_StudentCharacteristicDescriptor_Descriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociation_Cohort] FOREIGN KEY ([CohortIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentCohortAssociationSection] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociationSection_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentCohortAssociationSection] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociationSection_StudentCohortAssociation] FOREIGN KEY ([BeginDate], [CohortIdentifier], [EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentCohortAssociation] ([BeginDate], [CohortIdentifier], [EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_CompetencyLevelDescriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[CompetencyLevelDescriptor] ([CompetencyLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_CompetencyObjective] FOREIGN KEY ([ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId])
REFERENCES [edfi].[CompetencyObjective] ([EducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [PeriodSequence], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveGeneralStudentProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveGeneralStudentProgramAssociation_StudentCompetencyObjective] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCompetencyObjective] ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveStudentSectionAssociation_StudentCompetencyObjective] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCompetencyObjective] ([GradingPeriodDescriptorId], [GradingPeriodSequence], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveStudentSectionAssociation_StudentSectionAssociation] FOREIGN KEY ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAssociation] ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentContactAssociation_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
GO

ALTER TABLE [edfi].[StudentContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentContactAssociation_RelationDescriptor] FOREIGN KEY ([RelationDescriptorId])
REFERENCES [edfi].[RelationDescriptor] ([RelationDescriptorId])
GO

ALTER TABLE [edfi].[StudentContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentContactAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociation_TechnicalSkillsAssessmentDescriptor] FOREIGN KEY ([TechnicalSkillsAssessmentDescriptorId])
REFERENCES [edfi].[TechnicalSkillsAssessmentDescriptor] ([TechnicalSkillsAssessmentDescriptorId])
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociationCTEProgramService_CTEProgramServiceDescriptor] FOREIGN KEY ([CTEProgramServiceDescriptorId])
REFERENCES [edfi].[CTEProgramServiceDescriptor] ([CTEProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociationCTEProgramService_StudentCTEProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCTEProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociation_BehaviorDescriptor] FOREIGN KEY ([BehaviorDescriptorId])
REFERENCES [edfi].[BehaviorDescriptor] ([BehaviorDescriptorId])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociation_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_StudentDisciplineIncidentBehaviorAssociation] FOREIGN KEY ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociation_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescrip] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_StudentDisciplineIncidentNonOffenderAssoci] FOREIGN KEY ([IncidentIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ([IncidentIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_BarrierToInternetAccessInResidenceDescriptor] FOREIGN KEY ([BarrierToInternetAccessInResidenceDescriptorId])
REFERENCES [edfi].[BarrierToInternetAccessInResidenceDescriptor] ([BarrierToInternetAccessInResidenceDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_InternetAccessTypeInResidenceDescriptor] FOREIGN KEY ([InternetAccessTypeInResidenceDescriptorId])
REFERENCES [edfi].[InternetAccessTypeInResidenceDescriptor] ([InternetAccessTypeInResidenceDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_InternetPerformanceInResidenceDescriptor] FOREIGN KEY ([InternetPerformanceInResidenceDescriptorId])
REFERENCES [edfi].[InternetPerformanceInResidenceDescriptor] ([InternetPerformanceInResidenceDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_LimitedEnglishProficiencyDescriptor] FOREIGN KEY ([LimitedEnglishProficiencyDescriptorId])
REFERENCES [edfi].[LimitedEnglishProficiencyDescriptor] ([LimitedEnglishProficiencyDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceAccessDescriptor] FOREIGN KEY ([PrimaryLearningDeviceAccessDescriptorId])
REFERENCES [edfi].[PrimaryLearningDeviceAccessDescriptor] ([PrimaryLearningDeviceAccessDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceAwayFromSchoolDescriptor] FOREIGN KEY ([PrimaryLearningDeviceAwayFromSchoolDescriptorId])
REFERENCES [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] ([PrimaryLearningDeviceAwayFromSchoolDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceProviderDescriptor] FOREIGN KEY ([PrimaryLearningDeviceProviderDescriptorId])
REFERENCES [edfi].[PrimaryLearningDeviceProviderDescriptor] ([PrimaryLearningDeviceProviderDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddress] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddress_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddressPeriod_StudentEducationOrganizationAssociationAddress] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[StudentEducationOrganizationAssociationAddress] ([EducationOrganizationId], [StudentUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAncestryEthnicOrigin_AncestryEthnicOriginDescriptor] FOREIGN KEY ([AncestryEthnicOriginDescriptorId])
REFERENCES [edfi].[AncestryEthnicOriginDescriptor] ([AncestryEthnicOriginDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAncestryEthnicOrigin_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_CohortYearTypeDescriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[CohortYearTypeDescriptor] ([CohortYearTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisability_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisabilityDesignation_StudentEducationOrganizationAssociationDisability] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [DisabilityDescriptorId])
REFERENCES [edfi].[StudentEducationOrganizationAssociationDisability] ([EducationOrganizationId], [StudentUSI], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationElectronicMail_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationInternationalAddress_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguage] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguage] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationLanguage_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationLanguageUse_StudentEducationOrganizationAssociationLanguage] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [LanguageDescriptorId])
REFERENCES [edfi].[StudentEducationOrganizationAssociationLanguage] ([EducationOrganizationId], [StudentUSI], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationRace] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationRace] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationRace_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentCharacteristic_StudentCharacteristicDescriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentCharacteristicDescriptor] ([StudentCharacteristicDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentCharacteristic_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristicPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentCharacteristicPeriod_StudentEducationOrganizationAssociationStudentCharacterist] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] ([EducationOrganizationId], [StudentUSI], [StudentCharacteristicDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentIdentificationCode_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentIdentificationCode_StudentIdentificationSystemDescriptor] FOREIGN KEY ([StudentIdentificationSystemDescriptorId])
REFERENCES [edfi].[StudentIdentificationSystemDescriptor] ([StudentIdentificationSystemDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicator] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentIndicator_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentIndicatorPeriod_StudentEducationOrganizationAssociationStudentIndicator] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [IndicatorName])
REFERENCES [edfi].[StudentEducationOrganizationAssociationStudentIndicator] ([EducationOrganizationId], [StudentUSI], [IndicatorName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTelephone] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationTelephone_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTelephone] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationTribalAffiliation_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationTribalAffiliation_TribalAffiliationDescriptor] FOREIGN KEY ([TribalAffiliationDescriptorId])
REFERENCES [edfi].[TribalAffiliationDescriptor] ([TribalAffiliationDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationResponsibilityAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationResponsibilityAssociation_ResponsibilityDescriptor] FOREIGN KEY ([ResponsibilityDescriptorId])
REFERENCES [edfi].[ResponsibilityDescriptor] ([ResponsibilityDescriptorId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationResponsibilityAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_AssignmentLateStatusDescriptor] FOREIGN KEY ([AssignmentLateStatusDescriptorId])
REFERENCES [edfi].[AssignmentLateStatusDescriptor] ([AssignmentLateStatusDescriptorId])
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_CompetencyLevelDescriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[CompetencyLevelDescriptor] ([CompetencyLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_GradebookEntry] FOREIGN KEY ([GradebookEntryIdentifier], [Namespace])
REFERENCES [edfi].[GradebookEntry] ([GradebookEntryIdentifier], [Namespace])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_SubmissionStatusDescriptor] FOREIGN KEY ([SubmissionStatusDescriptorId])
REFERENCES [edfi].[SubmissionStatusDescriptor] ([SubmissionStatusDescriptorId])
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociation_HomelessPrimaryNighttimeResidenceDescriptor] FOREIGN KEY ([HomelessPrimaryNighttimeResidenceDescriptorId])
REFERENCES [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] ([HomelessPrimaryNighttimeResidenceDescriptorId])
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociationHomelessProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociationHomelessProgramService_HomelessProgramServiceDescriptor] FOREIGN KEY ([HomelessProgramServiceDescriptorId])
REFERENCES [edfi].[HomelessProgramServiceDescriptor] ([HomelessProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociationHomelessProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociationHomelessProgramService_StudentHomelessProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentHomelessProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[StudentIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

ALTER TABLE [edfi].[StudentIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

ALTER TABLE [edfi].[StudentIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationDocument_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([StudentIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociation_Cohort] FOREIGN KEY ([CohortIdentifier], [CohortEducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociation_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_InterventionEffectivenessRatingDescriptor] FOREIGN KEY ([InterventionEffectivenessRatingDescriptorId])
REFERENCES [edfi].[InterventionEffectivenessRatingDescriptor] ([InterventionEffectivenessRatingDescriptorId])
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_StudentInterventionAssociation] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode], [StudentUSI])
REFERENCES [edfi].[StudentInterventionAssociation] ([EducationOrganizationId], [InterventionIdentificationCode], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_MonitoredDescriptor] FOREIGN KEY ([MonitoredDescriptorId])
REFERENCES [edfi].[MonitoredDescriptor] ([MonitoredDescriptorId])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ParticipationDescriptor] FOREIGN KEY ([ParticipationDescriptorId])
REFERENCES [edfi].[ParticipationDescriptor] ([ParticipationDescriptorId])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ProficiencyDescriptor] FOREIGN KEY ([ProficiencyDescriptorId])
REFERENCES [edfi].[ProficiencyDescriptor] ([ProficiencyDescriptorId])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ProgressDescriptor] FOREIGN KEY ([ProgressDescriptorId])
REFERENCES [edfi].[ProgressDescriptor] ([ProgressDescriptorId])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_StudentLanguageInstructionProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentLanguageInstructionProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_LanguageInstructionProgramServiceDescriptor] FOREIGN KEY ([LanguageInstructionProgramServiceDescriptorId])
REFERENCES [edfi].[LanguageInstructionProgramServiceDescriptor] ([LanguageInstructionProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_StudentLanguageInstructionProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentLanguageInstructionProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociation_ContinuationOfServicesReasonDescriptor] FOREIGN KEY ([ContinuationOfServicesReasonDescriptorId])
REFERENCES [edfi].[ContinuationOfServicesReasonDescriptor] ([ContinuationOfServicesReasonDescriptorId])
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociationMigrantEducationProgramService_MigrantEducationProgramServiceDescriptor] FOREIGN KEY ([MigrantEducationProgramServiceDescriptorId])
REFERENCES [edfi].[MigrantEducationProgramServiceDescriptor] ([MigrantEducationProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociationMigrantEducationProgramService_StudentMigrantEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentMigrantEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_NeglectedOrDelinquentProgramDescriptor] FOREIGN KEY ([NeglectedOrDelinquentProgramDescriptorId])
REFERENCES [edfi].[NeglectedOrDelinquentProgramDescriptor] ([NeglectedOrDelinquentProgramDescriptorId])
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_ProgressLevelDescriptor] FOREIGN KEY ([ELAProgressLevelDescriptorId])
REFERENCES [edfi].[ProgressLevelDescriptor] ([ProgressLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_ProgressLevelDescriptor1] FOREIGN KEY ([MathematicsProgressLevelDescriptorId])
REFERENCES [edfi].[ProgressLevelDescriptor] ([ProgressLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_NeglectedOrDelinquentProgramServiceDescript] FOREIGN KEY ([NeglectedOrDelinquentProgramServiceDescriptorId])
REFERENCES [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] ([NeglectedOrDelinquentProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_StudentNeglectedOrDelinquentProgramAssociat] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentNeglectedOrDelinquentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentOtherName] WITH CHECK ADD CONSTRAINT [FK_StudentOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentOtherName] WITH CHECK ADD CONSTRAINT [FK_StudentOtherName_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentParticipationCodeDescriptor] WITH CHECK ADD CONSTRAINT [FK_StudentParticipationCodeDescriptor_Descriptor] FOREIGN KEY ([StudentParticipationCodeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramAssociationService] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAssociationService_ServiceDescriptor] FOREIGN KEY ([ServiceDescriptorId])
REFERENCES [edfi].[ServiceDescriptor] ([ServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramAssociationService] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAssociationService_StudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_RatingLevelDescriptor] FOREIGN KEY ([SummaryEvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_Staff] FOREIGN KEY ([StaffEvaluatorStaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentProgramEvaluationExternalEvaluator] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationExternalEvaluator_StudentProgramEvaluation] FOREIGN KEY ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramEvaluation] ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationElement_ProgramEvaluationElement] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationElement_RatingLevelDescriptor] FOREIGN KEY ([EvaluationElementRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationElement_StudentProgramEvaluation] FOREIGN KEY ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramEvaluation] ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationObjective_ProgramEvaluationObjective] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationObjective] ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationObjective_RatingLevelDescriptor] FOREIGN KEY ([EvaluationObjectiveRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationObjective_StudentProgramEvaluation] FOREIGN KEY ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramEvaluation] ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_EnrollmentTypeDescriptor] FOREIGN KEY ([EnrollmentTypeDescriptorId])
REFERENCES [edfi].[EnrollmentTypeDescriptor] ([EnrollmentTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_EntryGradeLevelReasonDescriptor] FOREIGN KEY ([EntryGradeLevelReasonDescriptorId])
REFERENCES [edfi].[EntryGradeLevelReasonDescriptor] ([EntryGradeLevelReasonDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_EntryTypeDescriptor] FOREIGN KEY ([EntryTypeDescriptorId])
REFERENCES [edfi].[EntryTypeDescriptor] ([EntryTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_ExitWithdrawTypeDescriptor] FOREIGN KEY ([ExitWithdrawTypeDescriptorId])
REFERENCES [edfi].[ExitWithdrawTypeDescriptor] ([ExitWithdrawTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_GradeLevelDescriptor] FOREIGN KEY ([EntryGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_GradeLevelDescriptor1] FOREIGN KEY ([NextYearGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_ResidencyStatusDescriptor] FOREIGN KEY ([ResidencyStatusDescriptorId])
REFERENCES [edfi].[ResidencyStatusDescriptor] ([ResidencyStatusDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_School1] FOREIGN KEY ([NextYearSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_SchoolChoiceBasisDescriptor] FOREIGN KEY ([SchoolChoiceBasisDescriptorId])
REFERENCES [edfi].[SchoolChoiceBasisDescriptor] ([SchoolChoiceBasisDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_SchoolYearType1] FOREIGN KEY ([ClassOfSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationAlternativeGraduationPlan_GraduationPlan] FOREIGN KEY ([AlternativeEducationOrganizationId], [AlternativeGraduationPlanTypeDescriptorId], [AlternativeGraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
GO

ALTER TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationAlternativeGraduationPlan_StudentSchoolAssociation] FOREIGN KEY ([EntryDate], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolAssociation] ([EntryDate], [SchoolId], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolAssociationEducationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationEducationPlan_EducationPlanDescriptor] FOREIGN KEY ([EducationPlanDescriptorId])
REFERENCES [edfi].[EducationPlanDescriptor] ([EducationPlanDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociationEducationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationEducationPlan_StudentSchoolAssociation] FOREIGN KEY ([EntryDate], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolAssociation] ([EntryDate], [SchoolId], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolFoodServiceProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_SchoolFoodServiceProgramServiceDescriptor] FOREIGN KEY ([SchoolFoodServiceProgramServiceDescriptorId])
REFERENCES [edfi].[SchoolFoodServiceProgramServiceDescriptor] ([SchoolFoodServiceProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_StudentSchoolFoodServiceProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolFoodServiceProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_AttemptStatusDescriptor] FOREIGN KEY ([AttemptStatusDescriptorId])
REFERENCES [edfi].[AttemptStatusDescriptor] ([AttemptStatusDescriptorId])
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_RepeatIdentifierDescriptor] FOREIGN KEY ([RepeatIdentifierDescriptorId])
REFERENCES [edfi].[RepeatIdentifierDescriptor] ([RepeatIdentifierDescriptorId])
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEventClassPeriod_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEventClassPeriod_StudentSectionAttendanceEvent] FOREIGN KEY ([AttendanceEventCategoryDescriptorId], [EventDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAttendanceEvent] ([AttendanceEventCategoryDescriptorId], [EventDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociation_SpecialEducationSettingDescriptor] FOREIGN KEY ([SpecialEducationSettingDescriptorId])
REFERENCES [edfi].[SpecialEducationSettingDescriptor] ([SpecialEducationSettingDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisability_StudentSpecialEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisabilityDesignation_StudentSpecialEducationProgramAssociationDisability] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [DisabilityDescriptorId])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociationDisability] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationServiceProvider_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationServiceProvider_StudentSpecialEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramService_SpecialEducationProgramServiceDescriptor] FOREIGN KEY ([SpecialEducationProgramServiceDescriptorId])
REFERENCES [edfi].[SpecialEducationProgramServiceDescriptor] ([SpecialEducationProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramService_StudentSpecialEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_StudentSpecialEducationProgramAssociationSpec] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [SpecialEducationProgramServiceDescriptorId])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [SpecialEducationProgramServiceDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EligibilityDelayReasonDescriptor] FOREIGN KEY ([EligibilityDelayReasonDescriptorId])
REFERENCES [edfi].[EligibilityDelayReasonDescriptor] ([EligibilityDelayReasonDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EligibilityEvaluationTypeDescriptor] FOREIGN KEY ([EligibilityEvaluationTypeDescriptorId])
REFERENCES [edfi].[EligibilityEvaluationTypeDescriptor] ([EligibilityEvaluationTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EvaluationDelayReasonDescriptor] FOREIGN KEY ([EvaluationDelayReasonDescriptorId])
REFERENCES [edfi].[EvaluationDelayReasonDescriptor] ([EvaluationDelayReasonDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_IDEAPartDescriptor] FOREIGN KEY ([IDEAPartDescriptorId])
REFERENCES [edfi].[IDEAPartDescriptor] ([IDEAPartDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociation_TitleIPartAParticipantDescriptor] FOREIGN KEY ([TitleIPartAParticipantDescriptorId])
REFERENCES [edfi].[TitleIPartAParticipantDescriptor] ([TitleIPartAParticipantDescriptorId])
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociationTitleIPartAProgramService_StudentTitleIPartAProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentTitleIPartAProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociationTitleIPartAProgramService_TitleIPartAProgramServiceDescriptor] FOREIGN KEY ([TitleIPartAProgramServiceDescriptorId])
REFERENCES [edfi].[TitleIPartAProgramServiceDescriptor] ([TitleIPartAProgramServiceDescriptorId])
GO

ALTER TABLE [edfi].[StudentVisa] WITH CHECK ADD CONSTRAINT [FK_StudentVisa_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentVisa] WITH CHECK ADD CONSTRAINT [FK_StudentVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

ALTER TABLE [edfi].[SubmissionStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_SubmissionStatusDescriptor_Descriptor] FOREIGN KEY ([SubmissionStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_SurveyCategoryDescriptor] FOREIGN KEY ([SurveyCategoryDescriptorId])
REFERENCES [edfi].[SurveyCategoryDescriptor] ([SurveyCategoryDescriptorId])
GO

ALTER TABLE [edfi].[SurveyCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_SurveyCategoryDescriptor_Descriptor] FOREIGN KEY ([SurveyCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyCourseAssociation_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

ALTER TABLE [edfi].[SurveyCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyCourseAssociation_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

ALTER TABLE [edfi].[SurveyLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_SurveyLevelDescriptor_Descriptor] FOREIGN KEY ([SurveyLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyProgramAssociation_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

ALTER TABLE [edfi].[SurveyProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyProgramAssociation_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

ALTER TABLE [edfi].[SurveyQuestion] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestion_QuestionFormDescriptor] FOREIGN KEY ([QuestionFormDescriptorId])
REFERENCES [edfi].[QuestionFormDescriptor] ([QuestionFormDescriptorId])
GO

ALTER TABLE [edfi].[SurveyQuestion] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestion_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

ALTER TABLE [edfi].[SurveyQuestion] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestion_SurveySection] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySection] ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
GO

ALTER TABLE [edfi].[SurveyQuestionMatrix] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionMatrix_SurveyQuestion] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier])
REFERENCES [edfi].[SurveyQuestion] ([Namespace], [QuestionCode], [SurveyIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyQuestionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponse_SurveyQuestion] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier])
REFERENCES [edfi].[SurveyQuestion] ([Namespace], [QuestionCode], [SurveyIdentifier])
GO

ALTER TABLE [edfi].[SurveyQuestionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponse_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

ALTER TABLE [edfi].[SurveyQuestionResponseChoice] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponseChoice_SurveyQuestion] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier])
REFERENCES [edfi].[SurveyQuestion] ([Namespace], [QuestionCode], [SurveyIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponseSurveyQuestionMatrixElementResponse_SurveyQuestionResponse] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyQuestionResponse] ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyQuestionResponseValue] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponseValue_SurveyQuestionResponse] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyQuestionResponse] ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseEducationOrganizationTargetAssociation_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseStaffTargetAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseStaffTargetAssociation_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

ALTER TABLE [edfi].[SurveyResponseSurveyLevel] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseSurveyLevel_SurveyLevelDescriptor] FOREIGN KEY ([SurveyLevelDescriptorId])
REFERENCES [edfi].[SurveyLevelDescriptor] ([SurveyLevelDescriptorId])
GO

ALTER TABLE [edfi].[SurveyResponseSurveyLevel] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseSurveyLevel_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveySection] WITH CHECK ADD CONSTRAINT [FK_SurveySection_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

ALTER TABLE [edfi].[SurveySectionAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SurveySectionAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAssociation_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

ALTER TABLE [edfi].[SurveySectionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponse_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

ALTER TABLE [edfi].[SurveySectionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponse_SurveySection] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySection] ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
GO

ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseEducationOrganizationTargetAssociation_SurveySectionResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySectionResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
GO

ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseStaffTargetAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseStaffTargetAssociation_SurveySectionResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySectionResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
GO

ALTER TABLE [edfi].[TeachingCredentialBasisDescriptor] WITH CHECK ADD CONSTRAINT [FK_TeachingCredentialBasisDescriptor_Descriptor] FOREIGN KEY ([TeachingCredentialBasisDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TeachingCredentialDescriptor] WITH CHECK ADD CONSTRAINT [FK_TeachingCredentialDescriptor_Descriptor] FOREIGN KEY ([TeachingCredentialDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TechnicalSkillsAssessmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_TechnicalSkillsAssessmentDescriptor_Descriptor] FOREIGN KEY ([TechnicalSkillsAssessmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TelephoneNumberTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_TelephoneNumberTypeDescriptor_Descriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TermDescriptor] WITH CHECK ADD CONSTRAINT [FK_TermDescriptor_Descriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TitleIPartAParticipantDescriptor] WITH CHECK ADD CONSTRAINT [FK_TitleIPartAParticipantDescriptor_Descriptor] FOREIGN KEY ([TitleIPartAParticipantDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TitleIPartAProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_TitleIPartAProgramServiceDescriptor_Descriptor] FOREIGN KEY ([TitleIPartAProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TitleIPartASchoolDesignationDescriptor] WITH CHECK ADD CONSTRAINT [FK_TitleIPartASchoolDesignationDescriptor_Descriptor] FOREIGN KEY ([TitleIPartASchoolDesignationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TribalAffiliationDescriptor] WITH CHECK ADD CONSTRAINT [FK_TribalAffiliationDescriptor_Descriptor] FOREIGN KEY ([TribalAffiliationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[VisaDescriptor] WITH CHECK ADD CONSTRAINT [FK_VisaDescriptor_Descriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[WeaponDescriptor] WITH CHECK ADD CONSTRAINT [FK_WeaponDescriptor_Descriptor] FOREIGN KEY ([WeaponDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

