-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'tracked_changes_edfi')
EXEC sys.sp_executesql N'CREATE SCHEMA [tracked_changes_edfi]'
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AcademicWeek]'))
CREATE TABLE [tracked_changes_edfi].[AcademicWeek]
(
       OldSchoolId [INT] NOT NULL,
       OldWeekIdentifier [NVARCHAR](80) NOT NULL,
       NewSchoolId [INT] NULL,
       NewWeekIdentifier [NVARCHAR](80) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_AcademicWeek PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AccountabilityRating]'))
CREATE TABLE [tracked_changes_edfi].[AccountabilityRating]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldRatingTitle [NVARCHAR](60) NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewRatingTitle [NVARCHAR](60) NULL,
       NewSchoolYear [SMALLINT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_AccountabilityRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Assessment]'))
CREATE TABLE [tracked_changes_edfi].[Assessment]
(
       OldAssessmentIdentifier [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       NewAssessmentIdentifier [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Assessment PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AssessmentItem]'))
CREATE TABLE [tracked_changes_edfi].[AssessmentItem]
(
       OldAssessmentIdentifier [NVARCHAR](60) NOT NULL,
       OldIdentificationCode [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       NewAssessmentIdentifier [NVARCHAR](60) NULL,
       NewIdentificationCode [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_AssessmentItem PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AssessmentScoreRangeLearningStandard]'))
CREATE TABLE [tracked_changes_edfi].[AssessmentScoreRangeLearningStandard]
(
       OldAssessmentIdentifier [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldScoreRangeId [NVARCHAR](60) NOT NULL,
       NewAssessmentIdentifier [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewScoreRangeId [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_AssessmentScoreRangeLearningStandard PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[BalanceSheetDimension]'))
CREATE TABLE [tracked_changes_edfi].[BalanceSheetDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_BalanceSheetDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[BellSchedule]'))
CREATE TABLE [tracked_changes_edfi].[BellSchedule]
(
       OldBellScheduleName [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       NewBellScheduleName [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_BellSchedule PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Calendar]'))
CREATE TABLE [tracked_changes_edfi].[Calendar]
(
       OldCalendarCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       NewCalendarCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Calendar PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CalendarDate]'))
CREATE TABLE [tracked_changes_edfi].[CalendarDate]
(
       OldCalendarCode [NVARCHAR](60) NOT NULL,
       OldDate [DATE] NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       NewCalendarCode [NVARCHAR](60) NULL,
       NewDate [DATE] NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_CalendarDate PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ChartOfAccount]'))
CREATE TABLE [tracked_changes_edfi].[ChartOfAccount]
(
       OldAccountIdentifier [NVARCHAR](50) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewAccountIdentifier [NVARCHAR](50) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_ChartOfAccount PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ClassPeriod]'))
CREATE TABLE [tracked_changes_edfi].[ClassPeriod]
(
       OldClassPeriodName [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       NewClassPeriodName [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_ClassPeriod PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Cohort]'))
CREATE TABLE [tracked_changes_edfi].[Cohort]
(
       OldCohortIdentifier [NVARCHAR](20) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       NewCohortIdentifier [NVARCHAR](20) NULL,
       NewEducationOrganizationId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Cohort PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CommunityProviderLicense]'))
CREATE TABLE [tracked_changes_edfi].[CommunityProviderLicense]
(
       OldCommunityProviderId [INT] NOT NULL,
       OldLicenseIdentifier [NVARCHAR](20) NOT NULL,
       OldLicensingOrganization [NVARCHAR](75) NOT NULL,
       NewCommunityProviderId [INT] NULL,
       NewLicenseIdentifier [NVARCHAR](20) NULL,
       NewLicensingOrganization [NVARCHAR](75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_CommunityProviderLicense PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CompetencyObjective]'))
CREATE TABLE [tracked_changes_edfi].[CompetencyObjective]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldObjective [NVARCHAR](60) NOT NULL,
       OldObjectiveGradeLevelDescriptorId [INT] NOT NULL,
       OldObjectiveGradeLevelDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldObjectiveGradeLevelDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewObjective [NVARCHAR](60) NULL,
       NewObjectiveGradeLevelDescriptorId [INT] NULL,
       NewObjectiveGradeLevelDescriptorNamespace [NVARCHAR](255) NULL,
       NewObjectiveGradeLevelDescriptorCodeValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_CompetencyObjective PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Course]'))
CREATE TABLE [tracked_changes_edfi].[Course]
(
       OldCourseCode [NVARCHAR](60) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       NewCourseCode [NVARCHAR](60) NULL,
       NewEducationOrganizationId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Course PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CourseOffering]'))
CREATE TABLE [tracked_changes_edfi].[CourseOffering]
(
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSessionName [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_CourseOffering PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CourseTranscript]'))
CREATE TABLE [tracked_changes_edfi].[CourseTranscript]
(
       OldCourseAttemptResultDescriptorId [INT] NOT NULL,
       OldCourseAttemptResultDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldCourseAttemptResultDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldCourseCode [NVARCHAR](60) NOT NULL,
       OldCourseEducationOrganizationId [INT] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       OldTermDescriptorId [INT] NOT NULL,
       OldTermDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldTermDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       NewCourseAttemptResultDescriptorId [INT] NULL,
       NewCourseAttemptResultDescriptorNamespace [NVARCHAR](255) NULL,
       NewCourseAttemptResultDescriptorCodeValue [NVARCHAR](50) NULL,
       NewCourseCode [NVARCHAR](60) NULL,
       NewCourseEducationOrganizationId [INT] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       NewTermDescriptorId [INT] NULL,
       NewTermDescriptorNamespace [NVARCHAR](255) NULL,
       NewTermDescriptorCodeValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_CourseTranscript PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Credential]'))
CREATE TABLE [tracked_changes_edfi].[Credential]
(
       OldCredentialIdentifier [NVARCHAR](60) NOT NULL,
       OldStateOfIssueStateAbbreviationDescriptorId [INT] NOT NULL,
       OldStateOfIssueStateAbbreviationDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldStateOfIssueStateAbbreviationDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       NewCredentialIdentifier [NVARCHAR](60) NULL,
       NewStateOfIssueStateAbbreviationDescriptorId [INT] NULL,
       NewStateOfIssueStateAbbreviationDescriptorNamespace [NVARCHAR](255) NULL,
       NewStateOfIssueStateAbbreviationDescriptorCodeValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Credential PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Descriptor]'))
CREATE TABLE [tracked_changes_edfi].[Descriptor]
(
       OldDescriptorId [INT] NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldCodeValue [NVARCHAR](50) NOT NULL,
       NewDescriptorId [INT] NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewCodeValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Descriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[DescriptorMapping]'))
CREATE TABLE [tracked_changes_edfi].[DescriptorMapping]
(
       OldMappedNamespace [NVARCHAR](255) NOT NULL,
       OldMappedValue [NVARCHAR](50) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldValue [NVARCHAR](50) NOT NULL,
       NewMappedNamespace [NVARCHAR](255) NULL,
       NewMappedValue [NVARCHAR](50) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_DescriptorMapping PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[DisciplineAction]'))
CREATE TABLE [tracked_changes_edfi].[DisciplineAction]
(
       OldDisciplineActionIdentifier [NVARCHAR](32) NOT NULL,
       OldDisciplineDate [DATE] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       OldResponsibilitySchoolId [INT] NOT NULL,
       NewDisciplineActionIdentifier [NVARCHAR](32) NULL,
       NewDisciplineDate [DATE] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_DisciplineAction PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[DisciplineIncident]'))
CREATE TABLE [tracked_changes_edfi].[DisciplineIncident]
(
       OldIncidentIdentifier [NVARCHAR](20) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       NewIncidentIdentifier [NVARCHAR](20) NULL,
       NewSchoolId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_DisciplineIncident PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationContent]'))
CREATE TABLE [tracked_changes_edfi].[EducationContent]
(
       OldContentIdentifier [NVARCHAR](225) NOT NULL,
       NewContentIdentifier [NVARCHAR](225) NULL,
       Id uniqueidentifier NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_EducationContent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganization]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganization]
(
       OldEducationOrganizationId [INT] NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_EducationOrganization PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganizationInterventionPrescriptionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganizationInterventionPrescriptionAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldInterventionPrescriptionEducationOrganizationId [INT] NOT NULL,
       OldInterventionPrescriptionIdentificationCode [NVARCHAR](60) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewInterventionPrescriptionEducationOrganizationId [INT] NULL,
       NewInterventionPrescriptionIdentificationCode [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_EducationOrganizationInterventionPrescriptionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganizationNetworkAssociation]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganizationNetworkAssociation]
(
       OldEducationOrganizationNetworkId [INT] NOT NULL,
       OldMemberEducationOrganizationId [INT] NOT NULL,
       NewEducationOrganizationNetworkId [INT] NULL,
       NewMemberEducationOrganizationId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_EducationOrganizationNetworkAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganizationPeerAssociation]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganizationPeerAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldPeerEducationOrganizationId [INT] NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewPeerEducationOrganizationId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_EducationOrganizationPeerAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[FeederSchoolAssociation]'))
CREATE TABLE [tracked_changes_edfi].[FeederSchoolAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldFeederSchoolId [INT] NOT NULL,
       OldSchoolId [INT] NOT NULL,
       NewBeginDate [DATE] NULL,
       NewFeederSchoolId [INT] NULL,
       NewSchoolId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_FeederSchoolAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[FunctionDimension]'))
CREATE TABLE [tracked_changes_edfi].[FunctionDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_FunctionDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[FundDimension]'))
CREATE TABLE [tracked_changes_edfi].[FundDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_FundDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GeneralStudentProgramAssociation]'))
CREATE TABLE [tracked_changes_edfi].[GeneralStudentProgramAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldProgramEducationOrganizationId [INT] NOT NULL,
       OldProgramName [NVARCHAR](60) NOT NULL,
       OldProgramTypeDescriptorId [INT] NOT NULL,
       OldProgramTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldProgramTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewProgramEducationOrganizationId [INT] NULL,
       NewProgramName [NVARCHAR](60) NULL,
       NewProgramTypeDescriptorId [INT] NULL,
       NewProgramTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewProgramTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_GeneralStudentProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Grade]'))
CREATE TABLE [tracked_changes_edfi].[Grade]
(
       OldBeginDate [DATE] NOT NULL,
       OldGradeTypeDescriptorId [INT] NOT NULL,
       OldGradeTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGradeTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldGradingPeriodDescriptorId [INT] NOT NULL,
       OldGradingPeriodDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldGradingPeriodSchoolYear [SMALLINT] NOT NULL,
       OldGradingPeriodSequence [INT] NOT NULL,
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSectionIdentifier [NVARCHAR](255) NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewGradeTypeDescriptorId [INT] NULL,
       NewGradeTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewGradeTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       NewGradingPeriodDescriptorId [INT] NULL,
       NewGradingPeriodDescriptorNamespace [NVARCHAR](255) NULL,
       NewGradingPeriodDescriptorCodeValue [NVARCHAR](50) NULL,
       NewGradingPeriodSchoolYear [SMALLINT] NULL,
       NewGradingPeriodSequence [INT] NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSectionIdentifier [NVARCHAR](255) NULL,
       NewSessionName [NVARCHAR](60) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Grade PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GradebookEntry]'))
CREATE TABLE [tracked_changes_edfi].[GradebookEntry]
(
       OldGradebookEntryIdentifier [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       NewGradebookEntryIdentifier [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_GradebookEntry PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GradingPeriod]'))
CREATE TABLE [tracked_changes_edfi].[GradingPeriod]
(
       OldGradingPeriodDescriptorId [INT] NOT NULL,
       OldGradingPeriodDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldPeriodSequence [INT] NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       NewGradingPeriodDescriptorId [INT] NULL,
       NewGradingPeriodDescriptorNamespace [NVARCHAR](255) NULL,
       NewGradingPeriodDescriptorCodeValue [NVARCHAR](50) NULL,
       NewPeriodSequence [INT] NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_GradingPeriod PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GraduationPlan]'))
CREATE TABLE [tracked_changes_edfi].[GraduationPlan]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldGraduationPlanTypeDescriptorId [INT] NOT NULL,
       OldGraduationPlanTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGraduationPlanTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldGraduationSchoolYear [SMALLINT] NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewGraduationPlanTypeDescriptorId [INT] NULL,
       NewGraduationPlanTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewGraduationPlanTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       NewGraduationSchoolYear [SMALLINT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_GraduationPlan PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Intervention]'))
CREATE TABLE [tracked_changes_edfi].[Intervention]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldInterventionIdentificationCode [NVARCHAR](60) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewInterventionIdentificationCode [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Intervention PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[InterventionPrescription]'))
CREATE TABLE [tracked_changes_edfi].[InterventionPrescription]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldInterventionPrescriptionIdentificationCode [NVARCHAR](60) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewInterventionPrescriptionIdentificationCode [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_InterventionPrescription PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[InterventionStudy]'))
CREATE TABLE [tracked_changes_edfi].[InterventionStudy]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldInterventionStudyIdentificationCode [NVARCHAR](60) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewInterventionStudyIdentificationCode [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_InterventionStudy PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LearningObjective]'))
CREATE TABLE [tracked_changes_edfi].[LearningObjective]
(
       OldLearningObjectiveId [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       NewLearningObjectiveId [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LearningObjective PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LearningStandard]'))
CREATE TABLE [tracked_changes_edfi].[LearningStandard]
(
       OldLearningStandardId [NVARCHAR](60) NOT NULL,
       NewLearningStandardId [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LearningStandard PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LearningStandardEquivalenceAssociation]'))
CREATE TABLE [tracked_changes_edfi].[LearningStandardEquivalenceAssociation]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSourceLearningStandardId [NVARCHAR](60) NOT NULL,
       OldTargetLearningStandardId [NVARCHAR](60) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSourceLearningStandardId [NVARCHAR](60) NULL,
       NewTargetLearningStandardId [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LearningStandardEquivalenceAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LocalAccount]'))
CREATE TABLE [tracked_changes_edfi].[LocalAccount]
(
       OldAccountIdentifier [NVARCHAR](50) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewAccountIdentifier [NVARCHAR](50) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LocalAccount PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LocalActual]'))
CREATE TABLE [tracked_changes_edfi].[LocalActual]
(
       OldAccountIdentifier [NVARCHAR](50) NOT NULL,
       OldAsOfDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewAccountIdentifier [NVARCHAR](50) NULL,
       NewAsOfDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LocalActual PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LocalBudget]'))
CREATE TABLE [tracked_changes_edfi].[LocalBudget]
(
       OldAccountIdentifier [NVARCHAR](50) NOT NULL,
       OldAsOfDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewAccountIdentifier [NVARCHAR](50) NULL,
       NewAsOfDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LocalBudget PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LocalContractedStaff]'))
CREATE TABLE [tracked_changes_edfi].[LocalContractedStaff]
(
       OldAccountIdentifier [NVARCHAR](50) NOT NULL,
       OldAsOfDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewAccountIdentifier [NVARCHAR](50) NULL,
       NewAsOfDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewFiscalYear [INT] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LocalContractedStaff PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LocalEncumbrance]'))
CREATE TABLE [tracked_changes_edfi].[LocalEncumbrance]
(
       OldAccountIdentifier [NVARCHAR](50) NOT NULL,
       OldAsOfDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewAccountIdentifier [NVARCHAR](50) NULL,
       NewAsOfDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LocalEncumbrance PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LocalPayroll]'))
CREATE TABLE [tracked_changes_edfi].[LocalPayroll]
(
       OldAccountIdentifier [NVARCHAR](50) NOT NULL,
       OldAsOfDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewAccountIdentifier [NVARCHAR](50) NULL,
       NewAsOfDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewFiscalYear [INT] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_LocalPayroll PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Location]'))
CREATE TABLE [tracked_changes_edfi].[Location]
(
       OldClassroomIdentificationCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       NewClassroomIdentificationCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Location PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ObjectDimension]'))
CREATE TABLE [tracked_changes_edfi].[ObjectDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_ObjectDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ObjectiveAssessment]'))
CREATE TABLE [tracked_changes_edfi].[ObjectiveAssessment]
(
       OldAssessmentIdentifier [NVARCHAR](60) NOT NULL,
       OldIdentificationCode [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       NewAssessmentIdentifier [NVARCHAR](60) NULL,
       NewIdentificationCode [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_ObjectiveAssessment PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[OpenStaffPosition]'))
CREATE TABLE [tracked_changes_edfi].[OpenStaffPosition]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldRequisitionNumber [NVARCHAR](20) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewRequisitionNumber [NVARCHAR](20) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_OpenStaffPosition PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[OperationalUnitDimension]'))
CREATE TABLE [tracked_changes_edfi].[OperationalUnitDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_OperationalUnitDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Parent]'))
CREATE TABLE [tracked_changes_edfi].[Parent]
(
       OldParentUSI [INT] NOT NULL,
       OldParentUniqueId [NVARCHAR](32) NOT NULL,
       NewParentUSI [INT] NULL,
       NewParentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Parent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Person]'))
CREATE TABLE [tracked_changes_edfi].[Person]
(
       OldPersonId [NVARCHAR](32) NOT NULL,
       OldSourceSystemDescriptorId [INT] NOT NULL,
       OldSourceSystemDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldSourceSystemDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       NewPersonId [NVARCHAR](32) NULL,
       NewSourceSystemDescriptorId [INT] NULL,
       NewSourceSystemDescriptorNamespace [NVARCHAR](255) NULL,
       NewSourceSystemDescriptorCodeValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Person PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[PostSecondaryEvent]'))
CREATE TABLE [tracked_changes_edfi].[PostSecondaryEvent]
(
       OldEventDate [DATE] NOT NULL,
       OldPostSecondaryEventCategoryDescriptorId [INT] NOT NULL,
       OldPostSecondaryEventCategoryDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldPostSecondaryEventCategoryDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewEventDate [DATE] NULL,
       NewPostSecondaryEventCategoryDescriptorId [INT] NULL,
       NewPostSecondaryEventCategoryDescriptorNamespace [NVARCHAR](255) NULL,
       NewPostSecondaryEventCategoryDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_PostSecondaryEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Program]'))
CREATE TABLE [tracked_changes_edfi].[Program]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldProgramName [NVARCHAR](60) NOT NULL,
       OldProgramTypeDescriptorId [INT] NOT NULL,
       OldProgramTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldProgramTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewProgramName [NVARCHAR](60) NULL,
       NewProgramTypeDescriptorId [INT] NULL,
       NewProgramTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewProgramTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Program PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ProgramDimension]'))
CREATE TABLE [tracked_changes_edfi].[ProgramDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_ProgramDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ProjectDimension]'))
CREATE TABLE [tracked_changes_edfi].[ProjectDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_ProjectDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ReportCard]'))
CREATE TABLE [tracked_changes_edfi].[ReportCard]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldGradingPeriodDescriptorId [INT] NOT NULL,
       OldGradingPeriodDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldGradingPeriodSchoolId [INT] NOT NULL,
       OldGradingPeriodSchoolYear [SMALLINT] NOT NULL,
       OldGradingPeriodSequence [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewGradingPeriodDescriptorId [INT] NULL,
       NewGradingPeriodDescriptorNamespace [NVARCHAR](255) NULL,
       NewGradingPeriodDescriptorCodeValue [NVARCHAR](50) NULL,
       NewGradingPeriodSchoolId [INT] NULL,
       NewGradingPeriodSchoolYear [SMALLINT] NULL,
       NewGradingPeriodSequence [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_ReportCard PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[RestraintEvent]'))
CREATE TABLE [tracked_changes_edfi].[RestraintEvent]
(
       OldRestraintEventIdentifier [NVARCHAR](20) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewRestraintEventIdentifier [NVARCHAR](20) NULL,
       NewSchoolId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_RestraintEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SchoolYearType]'))
CREATE TABLE [tracked_changes_edfi].[SchoolYearType]
(
       OldSchoolYear [SMALLINT] NOT NULL,
       NewSchoolYear [SMALLINT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SchoolYearType PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Section]'))
CREATE TABLE [tracked_changes_edfi].[Section]
(
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSectionIdentifier [NVARCHAR](255) NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSectionIdentifier [NVARCHAR](255) NULL,
       NewSessionName [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Section PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SectionAttendanceTakenEvent]'))
CREATE TABLE [tracked_changes_edfi].[SectionAttendanceTakenEvent]
(
       OldCalendarCode [NVARCHAR](60) NOT NULL,
       OldDate [DATE] NOT NULL,
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSectionIdentifier [NVARCHAR](255) NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       NewCalendarCode [NVARCHAR](60) NULL,
       NewDate [DATE] NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSectionIdentifier [NVARCHAR](255) NULL,
       NewSessionName [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SectionAttendanceTakenEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Session]'))
CREATE TABLE [tracked_changes_edfi].[Session]
(
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSessionName [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Session PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SourceDimension]'))
CREATE TABLE [tracked_changes_edfi].[SourceDimension]
(
       OldCode [NVARCHAR](16) NOT NULL,
       OldFiscalYear [INT] NOT NULL,
       NewCode [NVARCHAR](16) NULL,
       NewFiscalYear [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SourceDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Staff]'))
CREATE TABLE [tracked_changes_edfi].[Staff]
(
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Staff PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffAbsenceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StaffAbsenceEvent]
(
       OldAbsenceEventCategoryDescriptorId [INT] NOT NULL,
       OldAbsenceEventCategoryDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldAbsenceEventCategoryDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldEventDate [DATE] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewAbsenceEventCategoryDescriptorId [INT] NULL,
       NewAbsenceEventCategoryDescriptorNamespace [NVARCHAR](255) NULL,
       NewAbsenceEventCategoryDescriptorCodeValue [NVARCHAR](50) NULL,
       NewEventDate [DATE] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffAbsenceEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffCohortAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffCohortAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldCohortIdentifier [NVARCHAR](20) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewCohortIdentifier [NVARCHAR](20) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffCohortAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffDisciplineIncidentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffDisciplineIncidentAssociation]
(
       OldIncidentIdentifier [NVARCHAR](20) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewIncidentIdentifier [NVARCHAR](20) NULL,
       NewSchoolId [INT] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffDisciplineIncidentAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffEducationOrganizationAssignmentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffEducationOrganizationAssignmentAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldStaffClassificationDescriptorId [INT] NOT NULL,
       OldStaffClassificationDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldStaffClassificationDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewStaffClassificationDescriptorId [INT] NULL,
       NewStaffClassificationDescriptorNamespace [NVARCHAR](255) NULL,
       NewStaffClassificationDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffEducationOrganizationAssignmentAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffEducationOrganizationContactAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffEducationOrganizationContactAssociation]
(
       OldContactTitle [NVARCHAR](75) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewContactTitle [NVARCHAR](75) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffEducationOrganizationContactAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffEducationOrganizationEmploymentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffEducationOrganizationEmploymentAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldEmploymentStatusDescriptorId [INT] NOT NULL,
       OldEmploymentStatusDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldEmploymentStatusDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldHireDate [DATE] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewEmploymentStatusDescriptorId [INT] NULL,
       NewEmploymentStatusDescriptorNamespace [NVARCHAR](255) NULL,
       NewEmploymentStatusDescriptorCodeValue [NVARCHAR](50) NULL,
       NewHireDate [DATE] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffEducationOrganizationEmploymentAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffLeave]'))
CREATE TABLE [tracked_changes_edfi].[StaffLeave]
(
       OldBeginDate [DATE] NOT NULL,
       OldStaffLeaveEventCategoryDescriptorId [INT] NOT NULL,
       OldStaffLeaveEventCategoryDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldStaffLeaveEventCategoryDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewStaffLeaveEventCategoryDescriptorId [INT] NULL,
       NewStaffLeaveEventCategoryDescriptorNamespace [NVARCHAR](255) NULL,
       NewStaffLeaveEventCategoryDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffLeave PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffProgramAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffProgramAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldProgramEducationOrganizationId [INT] NOT NULL,
       OldProgramName [NVARCHAR](60) NOT NULL,
       OldProgramTypeDescriptorId [INT] NOT NULL,
       OldProgramTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldProgramTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewProgramEducationOrganizationId [INT] NULL,
       NewProgramName [NVARCHAR](60) NULL,
       NewProgramTypeDescriptorId [INT] NULL,
       NewProgramTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewProgramTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffSchoolAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffSchoolAssociation]
(
       OldProgramAssignmentDescriptorId [INT] NOT NULL,
       OldProgramAssignmentDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldProgramAssignmentDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewProgramAssignmentDescriptorId [INT] NULL,
       NewProgramAssignmentDescriptorNamespace [NVARCHAR](255) NULL,
       NewProgramAssignmentDescriptorCodeValue [NVARCHAR](50) NULL,
       NewSchoolId [INT] NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffSchoolAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffSectionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffSectionAssociation]
(
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSectionIdentifier [NVARCHAR](255) NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSectionIdentifier [NVARCHAR](255) NULL,
       NewSessionName [NVARCHAR](60) NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StaffSectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Student]'))
CREATE TABLE [tracked_changes_edfi].[Student]
(
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Student PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentAcademicRecord]'))
CREATE TABLE [tracked_changes_edfi].[StudentAcademicRecord]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       OldTermDescriptorId [INT] NOT NULL,
       OldTermDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldTermDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       NewTermDescriptorId [INT] NULL,
       NewTermDescriptorNamespace [NVARCHAR](255) NULL,
       NewTermDescriptorCodeValue [NVARCHAR](50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentAcademicRecord PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentAssessment]'))
CREATE TABLE [tracked_changes_edfi].[StudentAssessment]
(
       OldAssessmentIdentifier [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldStudentAssessmentIdentifier [NVARCHAR](60) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewAssessmentIdentifier [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewStudentAssessmentIdentifier [NVARCHAR](60) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentAssessment PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentCohortAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentCohortAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldCohortIdentifier [NVARCHAR](20) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewCohortIdentifier [NVARCHAR](20) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentCohortAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentCompetencyObjective]'))
CREATE TABLE [tracked_changes_edfi].[StudentCompetencyObjective]
(
       OldGradingPeriodDescriptorId [INT] NOT NULL,
       OldGradingPeriodDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldGradingPeriodSchoolId [INT] NOT NULL,
       OldGradingPeriodSchoolYear [SMALLINT] NOT NULL,
       OldGradingPeriodSequence [INT] NOT NULL,
       OldObjective [NVARCHAR](60) NOT NULL,
       OldObjectiveEducationOrganizationId [INT] NOT NULL,
       OldObjectiveGradeLevelDescriptorId [INT] NOT NULL,
       OldObjectiveGradeLevelDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldObjectiveGradeLevelDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewGradingPeriodDescriptorId [INT] NULL,
       NewGradingPeriodDescriptorNamespace [NVARCHAR](255) NULL,
       NewGradingPeriodDescriptorCodeValue [NVARCHAR](50) NULL,
       NewGradingPeriodSchoolId [INT] NULL,
       NewGradingPeriodSchoolYear [SMALLINT] NULL,
       NewGradingPeriodSequence [INT] NULL,
       NewObjective [NVARCHAR](60) NULL,
       NewObjectiveEducationOrganizationId [INT] NULL,
       NewObjectiveGradeLevelDescriptorId [INT] NULL,
       NewObjectiveGradeLevelDescriptorNamespace [NVARCHAR](255) NULL,
       NewObjectiveGradeLevelDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentCompetencyObjective PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentDisciplineIncidentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentDisciplineIncidentAssociation]
(
       OldIncidentIdentifier [NVARCHAR](20) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewIncidentIdentifier [NVARCHAR](20) NULL,
       NewSchoolId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentDisciplineIncidentAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentDisciplineIncidentBehaviorAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentDisciplineIncidentBehaviorAssociation]
(
       OldBehaviorDescriptorId [INT] NOT NULL,
       OldBehaviorDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldBehaviorDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldIncidentIdentifier [NVARCHAR](20) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewBehaviorDescriptorId [INT] NULL,
       NewBehaviorDescriptorNamespace [NVARCHAR](255) NULL,
       NewBehaviorDescriptorCodeValue [NVARCHAR](50) NULL,
       NewIncidentIdentifier [NVARCHAR](20) NULL,
       NewSchoolId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentDisciplineIncidentBehaviorAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentDisciplineIncidentNonOffenderAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentDisciplineIncidentNonOffenderAssociation]
(
       OldIncidentIdentifier [NVARCHAR](20) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewIncidentIdentifier [NVARCHAR](20) NULL,
       NewSchoolId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentDisciplineIncidentNonOffenderAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentEducationOrganizationAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentEducationOrganizationAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentEducationOrganizationAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentEducationOrganizationResponsibilityAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentEducationOrganizationResponsibilityAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldResponsibilityDescriptorId [INT] NOT NULL,
       OldResponsibilityDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldResponsibilityDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewEducationOrganizationId [INT] NULL,
       NewResponsibilityDescriptorId [INT] NULL,
       NewResponsibilityDescriptorNamespace [NVARCHAR](255) NULL,
       NewResponsibilityDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentEducationOrganizationResponsibilityAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentGradebookEntry]'))
CREATE TABLE [tracked_changes_edfi].[StudentGradebookEntry]
(
       OldGradebookEntryIdentifier [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewGradebookEntryIdentifier [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentGradebookEntry PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentInterventionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentInterventionAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldInterventionIdentificationCode [NVARCHAR](60) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewInterventionIdentificationCode [NVARCHAR](60) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentInterventionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentInterventionAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentInterventionAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId [INT] NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldEventDate [DATE] NOT NULL,
       OldInterventionIdentificationCode [NVARCHAR](60) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId [INT] NULL,
       NewAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewEventDate [DATE] NULL,
       NewInterventionIdentificationCode [NVARCHAR](60) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentInterventionAttendanceEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentLearningObjective]'))
CREATE TABLE [tracked_changes_edfi].[StudentLearningObjective]
(
       OldGradingPeriodDescriptorId [INT] NOT NULL,
       OldGradingPeriodDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldGradingPeriodSchoolId [INT] NOT NULL,
       OldGradingPeriodSchoolYear [SMALLINT] NOT NULL,
       OldGradingPeriodSequence [INT] NOT NULL,
       OldLearningObjectiveId [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewGradingPeriodDescriptorId [INT] NULL,
       NewGradingPeriodDescriptorNamespace [NVARCHAR](255) NULL,
       NewGradingPeriodDescriptorCodeValue [NVARCHAR](50) NULL,
       NewGradingPeriodSchoolId [INT] NULL,
       NewGradingPeriodSchoolYear [SMALLINT] NULL,
       NewGradingPeriodSequence [INT] NULL,
       NewLearningObjectiveId [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentLearningObjective PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentParentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentParentAssociation]
(
       OldParentUSI [INT] NOT NULL,
       OldParentUniqueId [NVARCHAR](32) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewParentUSI [INT] NULL,
       NewParentUniqueId [NVARCHAR](32) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentParentAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentProgramAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentProgramAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId [INT] NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldEventDate [DATE] NOT NULL,
       OldProgramEducationOrganizationId [INT] NOT NULL,
       OldProgramName [NVARCHAR](60) NOT NULL,
       OldProgramTypeDescriptorId [INT] NOT NULL,
       OldProgramTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldProgramTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId [INT] NULL,
       NewAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewEventDate [DATE] NULL,
       NewProgramEducationOrganizationId [INT] NULL,
       NewProgramName [NVARCHAR](60) NULL,
       NewProgramTypeDescriptorId [INT] NULL,
       NewProgramTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewProgramTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentProgramAttendanceEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSchoolAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentSchoolAssociation]
(
       OldEntryDate [DATE] NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewEntryDate [DATE] NULL,
       NewSchoolId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentSchoolAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSchoolAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentSchoolAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId [INT] NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldEventDate [DATE] NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId [INT] NULL,
       NewAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NULL,
       NewEventDate [DATE] NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSessionName [NVARCHAR](60) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentSchoolAttendanceEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSectionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentSectionAssociation]
(
       OldBeginDate [DATE] NOT NULL,
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSectionIdentifier [NVARCHAR](255) NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewBeginDate [DATE] NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSectionIdentifier [NVARCHAR](255) NULL,
       NewSessionName [NVARCHAR](60) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentSectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSectionAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentSectionAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId [INT] NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldEventDate [DATE] NOT NULL,
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSectionIdentifier [NVARCHAR](255) NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId [INT] NULL,
       NewAttendanceEventCategoryDescriptorNamespace [NVARCHAR](255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue [NVARCHAR](50) NULL,
       NewEventDate [DATE] NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSectionIdentifier [NVARCHAR](255) NULL,
       NewSessionName [NVARCHAR](60) NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentSectionAttendanceEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Survey]'))
CREATE TABLE [tracked_changes_edfi].[Survey]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Survey PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyCourseAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyCourseAssociation]
(
       OldCourseCode [NVARCHAR](60) NOT NULL,
       OldEducationOrganizationId [INT] NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       NewCourseCode [NVARCHAR](60) NULL,
       NewEducationOrganizationId [INT] NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveyCourseAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyProgramAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyProgramAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldProgramName [NVARCHAR](60) NOT NULL,
       OldProgramTypeDescriptorId [INT] NOT NULL,
       OldProgramTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldProgramTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewProgramName [NVARCHAR](60) NULL,
       NewProgramTypeDescriptorId [INT] NULL,
       NewProgramTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewProgramTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveyProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyQuestion]'))
CREATE TABLE [tracked_changes_edfi].[SurveyQuestion]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldQuestionCode [NVARCHAR](60) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewQuestionCode [NVARCHAR](60) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveyQuestion PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyQuestionResponse]'))
CREATE TABLE [tracked_changes_edfi].[SurveyQuestionResponse]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldQuestionCode [NVARCHAR](60) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewQuestionCode [NVARCHAR](60) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveyResponseIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveyQuestionResponse PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyResponse]'))
CREATE TABLE [tracked_changes_edfi].[SurveyResponse]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveyResponseIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveyResponse PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyResponseEducationOrganizationTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyResponseEducationOrganizationTargetAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveyResponseIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveyResponseEducationOrganizationTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyResponseStaffTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyResponseStaffTargetAssociation]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveyResponseIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveyResponseStaffTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySection]'))
CREATE TABLE [tracked_changes_edfi].[SurveySection]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveySectionTitle [NVARCHAR](255) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveySectionTitle [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveySection PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionAssociation]
(
       OldLocalCourseCode [NVARCHAR](60) NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldSchoolYear [SMALLINT] NOT NULL,
       OldSectionIdentifier [NVARCHAR](255) NOT NULL,
       OldSessionName [NVARCHAR](60) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       NewLocalCourseCode [NVARCHAR](60) NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSchoolId [INT] NULL,
       NewSchoolYear [SMALLINT] NULL,
       NewSectionIdentifier [NVARCHAR](255) NULL,
       NewSessionName [NVARCHAR](60) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveySectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionResponse]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionResponse]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveySectionTitle [NVARCHAR](255) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveyResponseIdentifier [NVARCHAR](60) NULL,
       NewSurveySectionTitle [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveySectionResponse PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveySectionTitle [NVARCHAR](255) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveyResponseIdentifier [NVARCHAR](60) NULL,
       NewSurveySectionTitle [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveySectionResponseEducationOrganizationTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionResponseStaffTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionResponseStaffTargetAssociation]
(
       OldNamespace [NVARCHAR](255) NOT NULL,
       OldStaffUSI [INT] NOT NULL,
       OldStaffUniqueId [NVARCHAR](32) NOT NULL,
       OldSurveyIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       OldSurveySectionTitle [NVARCHAR](255) NOT NULL,
       NewNamespace [NVARCHAR](255) NULL,
       NewStaffUSI [INT] NULL,
       NewStaffUniqueId [NVARCHAR](32) NULL,
       NewSurveyIdentifier [NVARCHAR](60) NULL,
       NewSurveyResponseIdentifier [NVARCHAR](60) NULL,
       NewSurveySectionTitle [NVARCHAR](255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SurveySectionResponseStaffTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
