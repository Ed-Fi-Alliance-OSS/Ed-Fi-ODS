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
       OldSchoolId int NOT NULL,
       OldWeekIdentifier nvarchar(80) NOT NULL,
       NewSchoolId int NULL,
       NewWeekIdentifier nvarchar(80) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT AcademicWeek_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Account]'))
CREATE TABLE [tracked_changes_edfi].[Account]
(
       OldAccountIdentifier nvarchar(50) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldFiscalYear int NOT NULL,
       NewAccountIdentifier nvarchar(50) NULL,
       NewEducationOrganizationId int NULL,
       NewFiscalYear int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Account_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AccountabilityRating]'))
CREATE TABLE [tracked_changes_edfi].[AccountabilityRating]
(
       OldEducationOrganizationId int NOT NULL,
       OldRatingTitle nvarchar(60) NOT NULL,
       OldSchoolYear smallint NOT NULL,
       NewEducationOrganizationId int NULL,
       NewRatingTitle nvarchar(60) NULL,
       NewSchoolYear smallint NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT AccountabilityRating_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AccountCode]'))
CREATE TABLE [tracked_changes_edfi].[AccountCode]
(
       OldAccountClassificationDescriptorId int NOT NULL,
       OldAccountClassificationDescriptorNamespace nvarchar(255) NOT NULL,
       OldAccountClassificationDescriptorCodeValue nvarchar(50) NOT NULL,
       OldAccountCodeNumber nvarchar(50) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldFiscalYear int NOT NULL,
       NewAccountClassificationDescriptorId int NULL,
       NewAccountClassificationDescriptorNamespace nvarchar(255) NULL,
       NewAccountClassificationDescriptorCodeValue nvarchar(50) NULL,
       NewAccountCodeNumber nvarchar(50) NULL,
       NewEducationOrganizationId int NULL,
       NewFiscalYear int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT AccountCode_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Actual]'))
CREATE TABLE [tracked_changes_edfi].[Actual]
(
       OldAccountIdentifier nvarchar(50) NOT NULL,
       OldAsOfDate date NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldFiscalYear int NOT NULL,
       NewAccountIdentifier nvarchar(50) NULL,
       NewAsOfDate date NULL,
       NewEducationOrganizationId int NULL,
       NewFiscalYear int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Actual_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Assessment]'))
CREATE TABLE [tracked_changes_edfi].[Assessment]
(
       OldAssessmentIdentifier nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       NewAssessmentIdentifier nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Assessment_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AssessmentItem]'))
CREATE TABLE [tracked_changes_edfi].[AssessmentItem]
(
       OldAssessmentIdentifier nvarchar(60) NOT NULL,
       OldIdentificationCode nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       NewAssessmentIdentifier nvarchar(60) NULL,
       NewIdentificationCode nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT AssessmentItem_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[AssessmentScoreRangeLearningStandard]'))
CREATE TABLE [tracked_changes_edfi].[AssessmentScoreRangeLearningStandard]
(
       OldAssessmentIdentifier nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldScoreRangeId nvarchar(60) NOT NULL,
       NewAssessmentIdentifier nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       NewScoreRangeId nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT AssessmentScoreRangeLearningStandard_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[BellSchedule]'))
CREATE TABLE [tracked_changes_edfi].[BellSchedule]
(
       OldBellScheduleName nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       NewBellScheduleName nvarchar(60) NULL,
       NewSchoolId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT BellSchedule_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Budget]'))
CREATE TABLE [tracked_changes_edfi].[Budget]
(
       OldAccountIdentifier nvarchar(50) NOT NULL,
       OldAsOfDate date NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldFiscalYear int NOT NULL,
       NewAccountIdentifier nvarchar(50) NULL,
       NewAsOfDate date NULL,
       NewEducationOrganizationId int NULL,
       NewFiscalYear int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Budget_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Calendar]'))
CREATE TABLE [tracked_changes_edfi].[Calendar]
(
       OldCalendarCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       NewCalendarCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Calendar_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CalendarDate]'))
CREATE TABLE [tracked_changes_edfi].[CalendarDate]
(
       OldCalendarCode nvarchar(60) NOT NULL,
       OldDate date NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       NewCalendarCode nvarchar(60) NULL,
       NewDate date NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT CalendarDate_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ClassPeriod]'))
CREATE TABLE [tracked_changes_edfi].[ClassPeriod]
(
       OldClassPeriodName nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       NewClassPeriodName nvarchar(60) NULL,
       NewSchoolId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT ClassPeriod_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Cohort]'))
CREATE TABLE [tracked_changes_edfi].[Cohort]
(
       OldCohortIdentifier nvarchar(20) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       NewCohortIdentifier nvarchar(20) NULL,
       NewEducationOrganizationId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Cohort_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CommunityProviderLicense]'))
CREATE TABLE [tracked_changes_edfi].[CommunityProviderLicense]
(
       OldCommunityProviderId int NOT NULL,
       OldLicenseIdentifier nvarchar(20) NOT NULL,
       OldLicensingOrganization nvarchar(75) NOT NULL,
       NewCommunityProviderId int NULL,
       NewLicenseIdentifier nvarchar(20) NULL,
       NewLicensingOrganization nvarchar(75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT CommunityProviderLicense_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CompetencyObjective]'))
CREATE TABLE [tracked_changes_edfi].[CompetencyObjective]
(
       OldEducationOrganizationId int NOT NULL,
       OldObjective nvarchar(60) NOT NULL,
       OldObjectiveGradeLevelDescriptorId int NOT NULL,
       OldObjectiveGradeLevelDescriptorNamespace nvarchar(255) NOT NULL,
       OldObjectiveGradeLevelDescriptorCodeValue nvarchar(50) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewObjective nvarchar(60) NULL,
       NewObjectiveGradeLevelDescriptorId int NULL,
       NewObjectiveGradeLevelDescriptorNamespace nvarchar(255) NULL,
       NewObjectiveGradeLevelDescriptorCodeValue nvarchar(50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT CompetencyObjective_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ContractedStaff]'))
CREATE TABLE [tracked_changes_edfi].[ContractedStaff]
(
       OldAccountIdentifier nvarchar(50) NOT NULL,
       OldAsOfDate date NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldFiscalYear int NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewAccountIdentifier nvarchar(50) NULL,
       NewAsOfDate date NULL,
       NewEducationOrganizationId int NULL,
       NewFiscalYear int NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT ContractedStaff_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Course]'))
CREATE TABLE [tracked_changes_edfi].[Course]
(
       OldCourseCode nvarchar(60) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       NewCourseCode nvarchar(60) NULL,
       NewEducationOrganizationId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Course_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CourseOffering]'))
CREATE TABLE [tracked_changes_edfi].[CourseOffering]
(
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSessionName nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT CourseOffering_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[CourseTranscript]'))
CREATE TABLE [tracked_changes_edfi].[CourseTranscript]
(
       OldCourseAttemptResultDescriptorId int NOT NULL,
       OldCourseAttemptResultDescriptorNamespace nvarchar(255) NOT NULL,
       OldCourseAttemptResultDescriptorCodeValue nvarchar(50) NOT NULL,
       OldCourseCode nvarchar(60) NOT NULL,
       OldCourseEducationOrganizationId int NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       OldTermDescriptorId int NOT NULL,
       OldTermDescriptorNamespace nvarchar(255) NOT NULL,
       OldTermDescriptorCodeValue nvarchar(50) NOT NULL,
       NewCourseAttemptResultDescriptorId int NULL,
       NewCourseAttemptResultDescriptorNamespace nvarchar(255) NULL,
       NewCourseAttemptResultDescriptorCodeValue nvarchar(50) NULL,
       NewCourseCode nvarchar(60) NULL,
       NewCourseEducationOrganizationId int NULL,
       NewEducationOrganizationId int NULL,
       NewSchoolYear smallint NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       NewTermDescriptorId int NULL,
       NewTermDescriptorNamespace nvarchar(255) NULL,
       NewTermDescriptorCodeValue nvarchar(50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT CourseTranscript_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Credential]'))
CREATE TABLE [tracked_changes_edfi].[Credential]
(
       OldCredentialIdentifier nvarchar(60) NOT NULL,
       OldStateOfIssueStateAbbreviationDescriptorId int NOT NULL,
       OldStateOfIssueStateAbbreviationDescriptorNamespace nvarchar(255) NOT NULL,
       OldStateOfIssueStateAbbreviationDescriptorCodeValue nvarchar(50) NOT NULL,
       NewCredentialIdentifier nvarchar(60) NULL,
       NewStateOfIssueStateAbbreviationDescriptorId int NULL,
       NewStateOfIssueStateAbbreviationDescriptorNamespace nvarchar(255) NULL,
       NewStateOfIssueStateAbbreviationDescriptorCodeValue nvarchar(50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Credential_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Descriptor]'))
CREATE TABLE [tracked_changes_edfi].[Descriptor]
(
       OldDescriptorId int NOT NULL,
       OldCodeValue nvarchar(50) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       NewDescriptorId int NULL,
       NewCodeValue nvarchar(50) NULL,
       NewNamespace nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Descriptor_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[DisciplineAction]'))
CREATE TABLE [tracked_changes_edfi].[DisciplineAction]
(
       OldDisciplineActionIdentifier nvarchar(20) NOT NULL,
       OldDisciplineDate date NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewDisciplineActionIdentifier nvarchar(20) NULL,
       NewDisciplineDate date NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT DisciplineAction_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[DisciplineIncident]'))
CREATE TABLE [tracked_changes_edfi].[DisciplineIncident]
(
       OldIncidentIdentifier nvarchar(20) NOT NULL,
       OldSchoolId int NOT NULL,
       NewIncidentIdentifier nvarchar(20) NULL,
       NewSchoolId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT DisciplineIncident_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationContent]'))
CREATE TABLE [tracked_changes_edfi].[EducationContent]
(
       OldContentIdentifier nvarchar(225) NOT NULL,
       NewContentIdentifier nvarchar(225) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT EducationContent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganization]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganization]
(
       OldEducationOrganizationId int NOT NULL,
       NewEducationOrganizationId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT EducationOrganization_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganizationInterventionPrescriptionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganizationInterventionPrescriptionAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldInterventionPrescriptionEducationOrganizationId int NOT NULL,
       OldInterventionPrescriptionIdentificationCode nvarchar(60) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewInterventionPrescriptionEducationOrganizationId int NULL,
       NewInterventionPrescriptionIdentificationCode nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT EducationOrganizationInterventionPrescriptionAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganizationNetworkAssociation]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganizationNetworkAssociation]
(
       OldEducationOrganizationNetworkId int NOT NULL,
       OldMemberEducationOrganizationId int NOT NULL,
       NewEducationOrganizationNetworkId int NULL,
       NewMemberEducationOrganizationId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT EducationOrganizationNetworkAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[EducationOrganizationPeerAssociation]'))
CREATE TABLE [tracked_changes_edfi].[EducationOrganizationPeerAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldPeerEducationOrganizationId int NOT NULL,
       NewEducationOrganizationId int NULL,
       NewPeerEducationOrganizationId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT EducationOrganizationPeerAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[FeederSchoolAssociation]'))
CREATE TABLE [tracked_changes_edfi].[FeederSchoolAssociation]
(
       OldBeginDate date NOT NULL,
       OldFeederSchoolId int NOT NULL,
       OldSchoolId int NOT NULL,
       NewBeginDate date NULL,
       NewFeederSchoolId int NULL,
       NewSchoolId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT FeederSchoolAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GeneralStudentProgramAssociation]'))
CREATE TABLE [tracked_changes_edfi].[GeneralStudentProgramAssociation]
(
       OldBeginDate date NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldProgramEducationOrganizationId int NOT NULL,
       OldProgramName nvarchar(60) NOT NULL,
       OldProgramTypeDescriptorId int NOT NULL,
       OldProgramTypeDescriptorNamespace nvarchar(255) NOT NULL,
       OldProgramTypeDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewEducationOrganizationId int NULL,
       NewProgramEducationOrganizationId int NULL,
       NewProgramName nvarchar(60) NULL,
       NewProgramTypeDescriptorId int NULL,
       NewProgramTypeDescriptorNamespace nvarchar(255) NULL,
       NewProgramTypeDescriptorCodeValue nvarchar(50) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT GeneralStudentProgramAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Grade]'))
CREATE TABLE [tracked_changes_edfi].[Grade]
(
       OldBeginDate date NOT NULL,
       OldGradeTypeDescriptorId int NOT NULL,
       OldGradeTypeDescriptorNamespace nvarchar(255) NOT NULL,
       OldGradeTypeDescriptorCodeValue nvarchar(50) NOT NULL,
       OldGradingPeriodDescriptorId int NOT NULL,
       OldGradingPeriodDescriptorNamespace nvarchar(255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue nvarchar(50) NOT NULL,
       OldGradingPeriodSchoolYear smallint NOT NULL,
       OldGradingPeriodSequence int NOT NULL,
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewGradeTypeDescriptorId int NULL,
       NewGradeTypeDescriptorNamespace nvarchar(255) NULL,
       NewGradeTypeDescriptorCodeValue nvarchar(50) NULL,
       NewGradingPeriodDescriptorId int NULL,
       NewGradingPeriodDescriptorNamespace nvarchar(255) NULL,
       NewGradingPeriodDescriptorCodeValue nvarchar(50) NULL,
       NewGradingPeriodSchoolYear smallint NULL,
       NewGradingPeriodSequence int NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Grade_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GradebookEntry]'))
CREATE TABLE [tracked_changes_edfi].[GradebookEntry]
(
       OldDateAssigned date NOT NULL,
       OldGradebookEntryTitle nvarchar(60) NOT NULL,
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       NewDateAssigned date NULL,
       NewGradebookEntryTitle nvarchar(60) NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT GradebookEntry_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GradingPeriod]'))
CREATE TABLE [tracked_changes_edfi].[GradingPeriod]
(
       OldGradingPeriodDescriptorId int NOT NULL,
       OldGradingPeriodDescriptorNamespace nvarchar(255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue nvarchar(50) NOT NULL,
       OldPeriodSequence int NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       NewGradingPeriodDescriptorId int NULL,
       NewGradingPeriodDescriptorNamespace nvarchar(255) NULL,
       NewGradingPeriodDescriptorCodeValue nvarchar(50) NULL,
       NewPeriodSequence int NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT GradingPeriod_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[GraduationPlan]'))
CREATE TABLE [tracked_changes_edfi].[GraduationPlan]
(
       OldEducationOrganizationId int NOT NULL,
       OldGraduationPlanTypeDescriptorId int NOT NULL,
       OldGraduationPlanTypeDescriptorNamespace nvarchar(255) NOT NULL,
       OldGraduationPlanTypeDescriptorCodeValue nvarchar(50) NOT NULL,
       OldGraduationSchoolYear smallint NOT NULL,
       NewEducationOrganizationId int NULL,
       NewGraduationPlanTypeDescriptorId int NULL,
       NewGraduationPlanTypeDescriptorNamespace nvarchar(255) NULL,
       NewGraduationPlanTypeDescriptorCodeValue nvarchar(50) NULL,
       NewGraduationSchoolYear smallint NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT GraduationPlan_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Intervention]'))
CREATE TABLE [tracked_changes_edfi].[Intervention]
(
       OldEducationOrganizationId int NOT NULL,
       OldInterventionIdentificationCode nvarchar(60) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewInterventionIdentificationCode nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Intervention_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[InterventionPrescription]'))
CREATE TABLE [tracked_changes_edfi].[InterventionPrescription]
(
       OldEducationOrganizationId int NOT NULL,
       OldInterventionPrescriptionIdentificationCode nvarchar(60) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewInterventionPrescriptionIdentificationCode nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT InterventionPrescription_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[InterventionStudy]'))
CREATE TABLE [tracked_changes_edfi].[InterventionStudy]
(
       OldEducationOrganizationId int NOT NULL,
       OldInterventionStudyIdentificationCode nvarchar(60) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewInterventionStudyIdentificationCode nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT InterventionStudy_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LearningObjective]'))
CREATE TABLE [tracked_changes_edfi].[LearningObjective]
(
       OldLearningObjectiveId nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       NewLearningObjectiveId nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT LearningObjective_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LearningStandard]'))
CREATE TABLE [tracked_changes_edfi].[LearningStandard]
(
       OldLearningStandardId nvarchar(60) NOT NULL,
       NewLearningStandardId nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT LearningStandard_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[LearningStandardEquivalenceAssociation]'))
CREATE TABLE [tracked_changes_edfi].[LearningStandardEquivalenceAssociation]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldSourceLearningStandardId nvarchar(60) NOT NULL,
       OldTargetLearningStandardId nvarchar(60) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewSourceLearningStandardId nvarchar(60) NULL,
       NewTargetLearningStandardId nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT LearningStandardEquivalenceAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Location]'))
CREATE TABLE [tracked_changes_edfi].[Location]
(
       OldClassroomIdentificationCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       NewClassroomIdentificationCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Location_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ObjectiveAssessment]'))
CREATE TABLE [tracked_changes_edfi].[ObjectiveAssessment]
(
       OldAssessmentIdentifier nvarchar(60) NOT NULL,
       OldIdentificationCode nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       NewAssessmentIdentifier nvarchar(60) NULL,
       NewIdentificationCode nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT ObjectiveAssessment_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[OpenStaffPosition]'))
CREATE TABLE [tracked_changes_edfi].[OpenStaffPosition]
(
       OldEducationOrganizationId int NOT NULL,
       OldRequisitionNumber nvarchar(20) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewRequisitionNumber nvarchar(20) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT OpenStaffPosition_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Parent]'))
CREATE TABLE [tracked_changes_edfi].[Parent]
(
       OldParentUSI int NOT NULL,
       OldParentUniqueId nvarchar(32) NOT NULL,
       NewParentUSI int NULL,
       NewParentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Parent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Payroll]'))
CREATE TABLE [tracked_changes_edfi].[Payroll]
(
       OldAccountIdentifier nvarchar(50) NOT NULL,
       OldAsOfDate date NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldFiscalYear int NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewAccountIdentifier nvarchar(50) NULL,
       NewAsOfDate date NULL,
       NewEducationOrganizationId int NULL,
       NewFiscalYear int NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Payroll_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Person]'))
CREATE TABLE [tracked_changes_edfi].[Person]
(
       OldPersonId nvarchar(32) NOT NULL,
       OldSourceSystemDescriptorId int NOT NULL,
       OldSourceSystemDescriptorNamespace nvarchar(255) NOT NULL,
       OldSourceSystemDescriptorCodeValue nvarchar(50) NOT NULL,
       NewPersonId nvarchar(32) NULL,
       NewSourceSystemDescriptorId int NULL,
       NewSourceSystemDescriptorNamespace nvarchar(255) NULL,
       NewSourceSystemDescriptorCodeValue nvarchar(50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Person_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[PostSecondaryEvent]'))
CREATE TABLE [tracked_changes_edfi].[PostSecondaryEvent]
(
       OldEventDate date NOT NULL,
       OldPostSecondaryEventCategoryDescriptorId int NOT NULL,
       OldPostSecondaryEventCategoryDescriptorNamespace nvarchar(255) NOT NULL,
       OldPostSecondaryEventCategoryDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewEventDate date NULL,
       NewPostSecondaryEventCategoryDescriptorId int NULL,
       NewPostSecondaryEventCategoryDescriptorNamespace nvarchar(255) NULL,
       NewPostSecondaryEventCategoryDescriptorCodeValue nvarchar(50) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PostSecondaryEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Program]'))
CREATE TABLE [tracked_changes_edfi].[Program]
(
       OldEducationOrganizationId int NOT NULL,
       OldProgramName nvarchar(60) NOT NULL,
       OldProgramTypeDescriptorId int NOT NULL,
       OldProgramTypeDescriptorNamespace nvarchar(255) NOT NULL,
       OldProgramTypeDescriptorCodeValue nvarchar(50) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewProgramName nvarchar(60) NULL,
       NewProgramTypeDescriptorId int NULL,
       NewProgramTypeDescriptorNamespace nvarchar(255) NULL,
       NewProgramTypeDescriptorCodeValue nvarchar(50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Program_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[ReportCard]'))
CREATE TABLE [tracked_changes_edfi].[ReportCard]
(
       OldEducationOrganizationId int NOT NULL,
       OldGradingPeriodDescriptorId int NOT NULL,
       OldGradingPeriodDescriptorNamespace nvarchar(255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue nvarchar(50) NOT NULL,
       OldGradingPeriodSchoolId int NOT NULL,
       OldGradingPeriodSchoolYear smallint NOT NULL,
       OldGradingPeriodSequence int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewGradingPeriodDescriptorId int NULL,
       NewGradingPeriodDescriptorNamespace nvarchar(255) NULL,
       NewGradingPeriodDescriptorCodeValue nvarchar(50) NULL,
       NewGradingPeriodSchoolId int NULL,
       NewGradingPeriodSchoolYear smallint NULL,
       NewGradingPeriodSequence int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT ReportCard_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[RestraintEvent]'))
CREATE TABLE [tracked_changes_edfi].[RestraintEvent]
(
       OldRestraintEventIdentifier nvarchar(20) NOT NULL,
       OldSchoolId int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewRestraintEventIdentifier nvarchar(20) NULL,
       NewSchoolId int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT RestraintEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SchoolYearType]'))
CREATE TABLE [tracked_changes_edfi].[SchoolYearType]
(
       OldSchoolYear smallint NOT NULL,
       NewSchoolYear smallint NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SchoolYearType_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Section]'))
CREATE TABLE [tracked_changes_edfi].[Section]
(
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Section_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SectionAttendanceTakenEvent]'))
CREATE TABLE [tracked_changes_edfi].[SectionAttendanceTakenEvent]
(
       OldCalendarCode nvarchar(60) NOT NULL,
       OldDate date NOT NULL,
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       NewCalendarCode nvarchar(60) NULL,
       NewDate date NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SectionAttendanceTakenEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Session]'))
CREATE TABLE [tracked_changes_edfi].[Session]
(
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSessionName nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Session_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Staff]'))
CREATE TABLE [tracked_changes_edfi].[Staff]
(
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Staff_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffAbsenceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StaffAbsenceEvent]
(
       OldAbsenceEventCategoryDescriptorId int NOT NULL,
       OldAbsenceEventCategoryDescriptorNamespace nvarchar(255) NOT NULL,
       OldAbsenceEventCategoryDescriptorCodeValue nvarchar(50) NOT NULL,
       OldEventDate date NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewAbsenceEventCategoryDescriptorId int NULL,
       NewAbsenceEventCategoryDescriptorNamespace nvarchar(255) NULL,
       NewAbsenceEventCategoryDescriptorCodeValue nvarchar(50) NULL,
       NewEventDate date NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffAbsenceEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffCohortAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffCohortAssociation]
(
       OldBeginDate date NOT NULL,
       OldCohortIdentifier nvarchar(20) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewCohortIdentifier nvarchar(20) NULL,
       NewEducationOrganizationId int NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffCohortAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffDisciplineIncidentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffDisciplineIncidentAssociation]
(
       OldIncidentIdentifier nvarchar(20) NOT NULL,
       OldSchoolId int NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewIncidentIdentifier nvarchar(20) NULL,
       NewSchoolId int NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffDisciplineIncidentAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffEducationOrganizationAssignmentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffEducationOrganizationAssignmentAssociation]
(
       OldBeginDate date NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldStaffClassificationDescriptorId int NOT NULL,
       OldStaffClassificationDescriptorNamespace nvarchar(255) NOT NULL,
       OldStaffClassificationDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewEducationOrganizationId int NULL,
       NewStaffClassificationDescriptorId int NULL,
       NewStaffClassificationDescriptorNamespace nvarchar(255) NULL,
       NewStaffClassificationDescriptorCodeValue nvarchar(50) NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffEducationOrganizationAssignmentAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffEducationOrganizationContactAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffEducationOrganizationContactAssociation]
(
       OldContactTitle nvarchar(75) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewContactTitle nvarchar(75) NULL,
       NewEducationOrganizationId int NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffEducationOrganizationContactAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffEducationOrganizationEmploymentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffEducationOrganizationEmploymentAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldEmploymentStatusDescriptorId int NOT NULL,
       OldEmploymentStatusDescriptorNamespace nvarchar(255) NOT NULL,
       OldEmploymentStatusDescriptorCodeValue nvarchar(50) NOT NULL,
       OldHireDate date NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewEmploymentStatusDescriptorId int NULL,
       NewEmploymentStatusDescriptorNamespace nvarchar(255) NULL,
       NewEmploymentStatusDescriptorCodeValue nvarchar(50) NULL,
       NewHireDate date NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffEducationOrganizationEmploymentAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffLeave]'))
CREATE TABLE [tracked_changes_edfi].[StaffLeave]
(
       OldBeginDate date NOT NULL,
       OldStaffLeaveEventCategoryDescriptorId int NOT NULL,
       OldStaffLeaveEventCategoryDescriptorNamespace nvarchar(255) NOT NULL,
       OldStaffLeaveEventCategoryDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewStaffLeaveEventCategoryDescriptorId int NULL,
       NewStaffLeaveEventCategoryDescriptorNamespace nvarchar(255) NULL,
       NewStaffLeaveEventCategoryDescriptorCodeValue nvarchar(50) NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffLeave_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffProgramAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffProgramAssociation]
(
       OldBeginDate date NOT NULL,
       OldProgramEducationOrganizationId int NOT NULL,
       OldProgramName nvarchar(60) NOT NULL,
       OldProgramTypeDescriptorId int NOT NULL,
       OldProgramTypeDescriptorNamespace nvarchar(255) NOT NULL,
       OldProgramTypeDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewProgramEducationOrganizationId int NULL,
       NewProgramName nvarchar(60) NULL,
       NewProgramTypeDescriptorId int NULL,
       NewProgramTypeDescriptorNamespace nvarchar(255) NULL,
       NewProgramTypeDescriptorCodeValue nvarchar(50) NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffProgramAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffSchoolAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffSchoolAssociation]
(
       OldProgramAssignmentDescriptorId int NOT NULL,
       OldProgramAssignmentDescriptorNamespace nvarchar(255) NOT NULL,
       OldProgramAssignmentDescriptorCodeValue nvarchar(50) NOT NULL,
       OldSchoolId int NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewProgramAssignmentDescriptorId int NULL,
       NewProgramAssignmentDescriptorNamespace nvarchar(255) NULL,
       NewProgramAssignmentDescriptorCodeValue nvarchar(50) NULL,
       NewSchoolId int NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffSchoolAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StaffSectionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StaffSectionAssociation]
(
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StaffSectionAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Student]'))
CREATE TABLE [tracked_changes_edfi].[Student]
(
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Student_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentAcademicRecord]'))
CREATE TABLE [tracked_changes_edfi].[StudentAcademicRecord]
(
       OldEducationOrganizationId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       OldTermDescriptorId int NOT NULL,
       OldTermDescriptorNamespace nvarchar(255) NOT NULL,
       OldTermDescriptorCodeValue nvarchar(50) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewSchoolYear smallint NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       NewTermDescriptorId int NULL,
       NewTermDescriptorNamespace nvarchar(255) NULL,
       NewTermDescriptorCodeValue nvarchar(50) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentAcademicRecord_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentAssessment]'))
CREATE TABLE [tracked_changes_edfi].[StudentAssessment]
(
       OldAssessmentIdentifier nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldStudentAssessmentIdentifier nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewAssessmentIdentifier nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       NewStudentAssessmentIdentifier nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentAssessment_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentCohortAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentCohortAssociation]
(
       OldBeginDate date NOT NULL,
       OldCohortIdentifier nvarchar(20) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewCohortIdentifier nvarchar(20) NULL,
       NewEducationOrganizationId int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentCohortAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentCompetencyObjective]'))
CREATE TABLE [tracked_changes_edfi].[StudentCompetencyObjective]
(
       OldGradingPeriodDescriptorId int NOT NULL,
       OldGradingPeriodDescriptorNamespace nvarchar(255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue nvarchar(50) NOT NULL,
       OldGradingPeriodSchoolId int NOT NULL,
       OldGradingPeriodSchoolYear smallint NOT NULL,
       OldGradingPeriodSequence int NOT NULL,
       OldObjective nvarchar(60) NOT NULL,
       OldObjectiveEducationOrganizationId int NOT NULL,
       OldObjectiveGradeLevelDescriptorId int NOT NULL,
       OldObjectiveGradeLevelDescriptorNamespace nvarchar(255) NOT NULL,
       OldObjectiveGradeLevelDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewGradingPeriodDescriptorId int NULL,
       NewGradingPeriodDescriptorNamespace nvarchar(255) NULL,
       NewGradingPeriodDescriptorCodeValue nvarchar(50) NULL,
       NewGradingPeriodSchoolId int NULL,
       NewGradingPeriodSchoolYear smallint NULL,
       NewGradingPeriodSequence int NULL,
       NewObjective nvarchar(60) NULL,
       NewObjectiveEducationOrganizationId int NULL,
       NewObjectiveGradeLevelDescriptorId int NULL,
       NewObjectiveGradeLevelDescriptorNamespace nvarchar(255) NULL,
       NewObjectiveGradeLevelDescriptorCodeValue nvarchar(50) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentCompetencyObjective_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentDisciplineIncidentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentDisciplineIncidentAssociation]
(
       OldIncidentIdentifier nvarchar(20) NOT NULL,
       OldSchoolId int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewIncidentIdentifier nvarchar(20) NULL,
       NewSchoolId int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentDisciplineIncidentAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentDisciplineIncidentBehaviorAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentDisciplineIncidentBehaviorAssociation]
(
       OldBehaviorDescriptorId int NOT NULL,
       OldBehaviorDescriptorNamespace nvarchar(255) NOT NULL,
       OldBehaviorDescriptorCodeValue nvarchar(50) NOT NULL,
       OldIncidentIdentifier nvarchar(20) NOT NULL,
       OldSchoolId int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewBehaviorDescriptorId int NULL,
       NewBehaviorDescriptorNamespace nvarchar(255) NULL,
       NewBehaviorDescriptorCodeValue nvarchar(50) NULL,
       NewIncidentIdentifier nvarchar(20) NULL,
       NewSchoolId int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentDisciplineIncidentBehaviorAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentDisciplineIncidentNonOffenderAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentDisciplineIncidentNonOffenderAssociation]
(
       OldIncidentIdentifier nvarchar(20) NOT NULL,
       OldSchoolId int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewIncidentIdentifier nvarchar(20) NULL,
       NewSchoolId int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentDisciplineIncidentNonOffenderAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentEducationOrganizationAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentEducationOrganizationAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentEducationOrganizationAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentEducationOrganizationResponsibilityAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentEducationOrganizationResponsibilityAssociation]
(
       OldBeginDate date NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldResponsibilityDescriptorId int NOT NULL,
       OldResponsibilityDescriptorNamespace nvarchar(255) NOT NULL,
       OldResponsibilityDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewEducationOrganizationId int NULL,
       NewResponsibilityDescriptorId int NULL,
       NewResponsibilityDescriptorNamespace nvarchar(255) NULL,
       NewResponsibilityDescriptorCodeValue nvarchar(50) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentEducationOrganizationResponsibilityAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentGradebookEntry]'))
CREATE TABLE [tracked_changes_edfi].[StudentGradebookEntry]
(
       OldBeginDate date NOT NULL,
       OldDateAssigned date NOT NULL,
       OldGradebookEntryTitle nvarchar(60) NOT NULL,
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewDateAssigned date NULL,
       NewGradebookEntryTitle nvarchar(60) NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentGradebookEntry_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentInterventionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentInterventionAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldInterventionIdentificationCode nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewInterventionIdentificationCode nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentInterventionAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentInterventionAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentInterventionAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId int NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace nvarchar(255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldEventDate date NOT NULL,
       OldInterventionIdentificationCode nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId int NULL,
       NewAttendanceEventCategoryDescriptorNamespace nvarchar(255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NULL,
       NewEducationOrganizationId int NULL,
       NewEventDate date NULL,
       NewInterventionIdentificationCode nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentInterventionAttendanceEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentLearningObjective]'))
CREATE TABLE [tracked_changes_edfi].[StudentLearningObjective]
(
       OldGradingPeriodDescriptorId int NOT NULL,
       OldGradingPeriodDescriptorNamespace nvarchar(255) NOT NULL,
       OldGradingPeriodDescriptorCodeValue nvarchar(50) NOT NULL,
       OldGradingPeriodSchoolId int NOT NULL,
       OldGradingPeriodSchoolYear smallint NOT NULL,
       OldGradingPeriodSequence int NOT NULL,
       OldLearningObjectiveId nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewGradingPeriodDescriptorId int NULL,
       NewGradingPeriodDescriptorNamespace nvarchar(255) NULL,
       NewGradingPeriodDescriptorCodeValue nvarchar(50) NULL,
       NewGradingPeriodSchoolId int NULL,
       NewGradingPeriodSchoolYear smallint NULL,
       NewGradingPeriodSequence int NULL,
       NewLearningObjectiveId nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentLearningObjective_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentParentAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentParentAssociation]
(
       OldParentUSI int NOT NULL,
       OldParentUniqueId nvarchar(32) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewParentUSI int NULL,
       NewParentUniqueId nvarchar(32) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentParentAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentProgramAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentProgramAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId int NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace nvarchar(255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldEventDate date NOT NULL,
       OldProgramEducationOrganizationId int NOT NULL,
       OldProgramName nvarchar(60) NOT NULL,
       OldProgramTypeDescriptorId int NOT NULL,
       OldProgramTypeDescriptorNamespace nvarchar(255) NOT NULL,
       OldProgramTypeDescriptorCodeValue nvarchar(50) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId int NULL,
       NewAttendanceEventCategoryDescriptorNamespace nvarchar(255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NULL,
       NewEducationOrganizationId int NULL,
       NewEventDate date NULL,
       NewProgramEducationOrganizationId int NULL,
       NewProgramName nvarchar(60) NULL,
       NewProgramTypeDescriptorId int NULL,
       NewProgramTypeDescriptorNamespace nvarchar(255) NULL,
       NewProgramTypeDescriptorCodeValue nvarchar(50) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentProgramAttendanceEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSchoolAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentSchoolAssociation]
(
       OldEntryDate date NOT NULL,
       OldSchoolId int NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewEntryDate date NULL,
       NewSchoolId int NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentSchoolAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSchoolAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentSchoolAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId int NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace nvarchar(255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NOT NULL,
       OldEventDate date NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId int NULL,
       NewAttendanceEventCategoryDescriptorNamespace nvarchar(255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NULL,
       NewEventDate date NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSessionName nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentSchoolAttendanceEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSectionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[StudentSectionAssociation]
(
       OldBeginDate date NOT NULL,
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewBeginDate date NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentSectionAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[StudentSectionAttendanceEvent]'))
CREATE TABLE [tracked_changes_edfi].[StudentSectionAttendanceEvent]
(
       OldAttendanceEventCategoryDescriptorId int NOT NULL,
       OldAttendanceEventCategoryDescriptorNamespace nvarchar(255) NOT NULL,
       OldAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NOT NULL,
       OldEventDate date NOT NULL,
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       OldStudentUSI int NOT NULL,
       OldStudentUniqueId nvarchar(32) NOT NULL,
       NewAttendanceEventCategoryDescriptorId int NULL,
       NewAttendanceEventCategoryDescriptorNamespace nvarchar(255) NULL,
       NewAttendanceEventCategoryDescriptorCodeValue nvarchar(50) NULL,
       NewEventDate date NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       NewStudentUSI int NULL,
       NewStudentUniqueId nvarchar(32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT StudentSectionAttendanceEvent_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[Survey]'))
CREATE TABLE [tracked_changes_edfi].[Survey]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT Survey_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyCourseAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyCourseAssociation]
(
       OldCourseCode nvarchar(60) NOT NULL,
       OldEducationOrganizationId int NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       NewCourseCode nvarchar(60) NULL,
       NewEducationOrganizationId int NULL,
       NewNamespace nvarchar(255) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveyCourseAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyProgramAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyProgramAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldProgramName nvarchar(60) NOT NULL,
       OldProgramTypeDescriptorId int NOT NULL,
       OldProgramTypeDescriptorNamespace nvarchar(255) NOT NULL,
       OldProgramTypeDescriptorCodeValue nvarchar(50) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewNamespace nvarchar(255) NULL,
       NewProgramName nvarchar(60) NULL,
       NewProgramTypeDescriptorId int NULL,
       NewProgramTypeDescriptorNamespace nvarchar(255) NULL,
       NewProgramTypeDescriptorCodeValue nvarchar(50) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveyProgramAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyQuestion]'))
CREATE TABLE [tracked_changes_edfi].[SurveyQuestion]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldQuestionCode nvarchar(60) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewQuestionCode nvarchar(60) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveyQuestion_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyQuestionResponse]'))
CREATE TABLE [tracked_changes_edfi].[SurveyQuestionResponse]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldQuestionCode nvarchar(60) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveyResponseIdentifier nvarchar(60) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewQuestionCode nvarchar(60) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveyResponseIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveyQuestionResponse_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyResponse]'))
CREATE TABLE [tracked_changes_edfi].[SurveyResponse]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveyResponseIdentifier nvarchar(60) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveyResponseIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveyResponse_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyResponseEducationOrganizationTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyResponseEducationOrganizationTargetAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveyResponseIdentifier nvarchar(60) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewNamespace nvarchar(255) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveyResponseIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveyResponseEducationOrganizationTargetAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveyResponseStaffTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveyResponseStaffTargetAssociation]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveyResponseIdentifier nvarchar(60) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveyResponseIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveyResponseStaffTargetAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySection]'))
CREATE TABLE [tracked_changes_edfi].[SurveySection]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveySectionTitle nvarchar(255) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveySectionTitle nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveySection_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionAssociation]
(
       OldLocalCourseCode nvarchar(60) NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldSchoolId int NOT NULL,
       OldSchoolYear smallint NOT NULL,
       OldSectionIdentifier nvarchar(255) NOT NULL,
       OldSessionName nvarchar(60) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       NewLocalCourseCode nvarchar(60) NULL,
       NewNamespace nvarchar(255) NULL,
       NewSchoolId int NULL,
       NewSchoolYear smallint NULL,
       NewSectionIdentifier nvarchar(255) NULL,
       NewSessionName nvarchar(60) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveySectionAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionResponse]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionResponse]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveyResponseIdentifier nvarchar(60) NOT NULL,
       OldSurveySectionTitle nvarchar(255) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveyResponseIdentifier nvarchar(60) NULL,
       NewSurveySectionTitle nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveySectionResponse_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]
(
       OldEducationOrganizationId int NOT NULL,
       OldNamespace nvarchar(255) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveyResponseIdentifier nvarchar(60) NOT NULL,
       OldSurveySectionTitle nvarchar(255) NOT NULL,
       NewEducationOrganizationId int NULL,
       NewNamespace nvarchar(255) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveyResponseIdentifier nvarchar(60) NULL,
       NewSurveySectionTitle nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveySectionResponseEducationOrganizationTargetAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_edfi].[SurveySectionResponseStaffTargetAssociation]'))
CREATE TABLE [tracked_changes_edfi].[SurveySectionResponseStaffTargetAssociation]
(
       OldNamespace nvarchar(255) NOT NULL,
       OldStaffUSI int NOT NULL,
       OldStaffUniqueId nvarchar(32) NOT NULL,
       OldSurveyIdentifier nvarchar(60) NOT NULL,
       OldSurveyResponseIdentifier nvarchar(60) NOT NULL,
       OldSurveySectionTitle nvarchar(255) NOT NULL,
       NewNamespace nvarchar(255) NULL,
       NewStaffUSI int NULL,
       NewStaffUniqueId nvarchar(32) NULL,
       NewSurveyIdentifier nvarchar(60) NULL,
       NewSurveyResponseIdentifier nvarchar(60) NULL,
       NewSurveySectionTitle nvarchar(255) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator nvarchar(128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT SurveySectionResponseStaffTargetAssociation_PK PRIMARY KEY CLUSTERED (ChangeVersion)
)

