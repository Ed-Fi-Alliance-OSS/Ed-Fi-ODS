-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AcademicWeek]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[AcademicWeek] ADD [ChangeVersion] [BIGINT] CONSTRAINT AcademicWeek_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[AcademicWeek] DROP CONSTRAINT AcademicWeek_DF_ChangeVersion;
ALTER TABLE [edfi].[AcademicWeek] ADD CONSTRAINT AcademicWeek_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AccountabilityRating]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[AccountabilityRating] ADD [ChangeVersion] [BIGINT] CONSTRAINT AccountabilityRating_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[AccountabilityRating] DROP CONSTRAINT AccountabilityRating_DF_ChangeVersion;
ALTER TABLE [edfi].[AccountabilityRating] ADD CONSTRAINT AccountabilityRating_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Assessment]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Assessment] ADD [ChangeVersion] [BIGINT] CONSTRAINT Assessment_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Assessment] DROP CONSTRAINT Assessment_DF_ChangeVersion;
ALTER TABLE [edfi].[Assessment] ADD CONSTRAINT Assessment_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AssessmentItem]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[AssessmentItem] ADD [ChangeVersion] [BIGINT] CONSTRAINT AssessmentItem_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[AssessmentItem] DROP CONSTRAINT AssessmentItem_DF_ChangeVersion;
ALTER TABLE [edfi].[AssessmentItem] ADD CONSTRAINT AssessmentItem_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AssessmentScoreRangeLearningStandard]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD [ChangeVersion] [BIGINT] CONSTRAINT AssessmentScoreRangeLearningStandard_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] DROP CONSTRAINT AssessmentScoreRangeLearningStandard_DF_ChangeVersion;
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD CONSTRAINT AssessmentScoreRangeLearningStandard_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[BalanceSheetDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[BalanceSheetDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT BalanceSheetDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[BalanceSheetDimension] DROP CONSTRAINT BalanceSheetDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[BalanceSheetDimension] ADD CONSTRAINT BalanceSheetDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[BellSchedule]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[BellSchedule] ADD [ChangeVersion] [BIGINT] CONSTRAINT BellSchedule_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[BellSchedule] DROP CONSTRAINT BellSchedule_DF_ChangeVersion;
ALTER TABLE [edfi].[BellSchedule] ADD CONSTRAINT BellSchedule_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Calendar]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Calendar] ADD [ChangeVersion] [BIGINT] CONSTRAINT Calendar_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Calendar] DROP CONSTRAINT Calendar_DF_ChangeVersion;
ALTER TABLE [edfi].[Calendar] ADD CONSTRAINT Calendar_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CalendarDate]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[CalendarDate] ADD [ChangeVersion] [BIGINT] CONSTRAINT CalendarDate_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[CalendarDate] DROP CONSTRAINT CalendarDate_DF_ChangeVersion;
ALTER TABLE [edfi].[CalendarDate] ADD CONSTRAINT CalendarDate_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ChartOfAccount]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[ChartOfAccount] ADD [ChangeVersion] [BIGINT] CONSTRAINT ChartOfAccount_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[ChartOfAccount] DROP CONSTRAINT ChartOfAccount_DF_ChangeVersion;
ALTER TABLE [edfi].[ChartOfAccount] ADD CONSTRAINT ChartOfAccount_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ClassPeriod]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[ClassPeriod] ADD [ChangeVersion] [BIGINT] CONSTRAINT ClassPeriod_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[ClassPeriod] DROP CONSTRAINT ClassPeriod_DF_ChangeVersion;
ALTER TABLE [edfi].[ClassPeriod] ADD CONSTRAINT ClassPeriod_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Cohort]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Cohort] ADD [ChangeVersion] [BIGINT] CONSTRAINT Cohort_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Cohort] DROP CONSTRAINT Cohort_DF_ChangeVersion;
ALTER TABLE [edfi].[Cohort] ADD CONSTRAINT Cohort_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CommunityProviderLicense]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[CommunityProviderLicense] ADD [ChangeVersion] [BIGINT] CONSTRAINT CommunityProviderLicense_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[CommunityProviderLicense] DROP CONSTRAINT CommunityProviderLicense_DF_ChangeVersion;
ALTER TABLE [edfi].[CommunityProviderLicense] ADD CONSTRAINT CommunityProviderLicense_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CompetencyObjective]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[CompetencyObjective] ADD [ChangeVersion] [BIGINT] CONSTRAINT CompetencyObjective_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[CompetencyObjective] DROP CONSTRAINT CompetencyObjective_DF_ChangeVersion;
ALTER TABLE [edfi].[CompetencyObjective] ADD CONSTRAINT CompetencyObjective_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Course]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Course] ADD [ChangeVersion] [BIGINT] CONSTRAINT Course_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Course] DROP CONSTRAINT Course_DF_ChangeVersion;
ALTER TABLE [edfi].[Course] ADD CONSTRAINT Course_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CourseOffering]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[CourseOffering] ADD [ChangeVersion] [BIGINT] CONSTRAINT CourseOffering_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[CourseOffering] DROP CONSTRAINT CourseOffering_DF_ChangeVersion;
ALTER TABLE [edfi].[CourseOffering] ADD CONSTRAINT CourseOffering_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CourseTranscript]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[CourseTranscript] ADD [ChangeVersion] [BIGINT] CONSTRAINT CourseTranscript_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[CourseTranscript] DROP CONSTRAINT CourseTranscript_DF_ChangeVersion;
ALTER TABLE [edfi].[CourseTranscript] ADD CONSTRAINT CourseTranscript_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Credential]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Credential] ADD [ChangeVersion] [BIGINT] CONSTRAINT Credential_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Credential] DROP CONSTRAINT Credential_DF_ChangeVersion;
ALTER TABLE [edfi].[Credential] ADD CONSTRAINT Credential_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Descriptor]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Descriptor] ADD [ChangeVersion] [BIGINT] CONSTRAINT Descriptor_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Descriptor] DROP CONSTRAINT Descriptor_DF_ChangeVersion;
ALTER TABLE [edfi].[Descriptor] ADD CONSTRAINT Descriptor_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[DescriptorMapping]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[DescriptorMapping] ADD [ChangeVersion] [BIGINT] CONSTRAINT DescriptorMapping_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[DescriptorMapping] DROP CONSTRAINT DescriptorMapping_DF_ChangeVersion;
ALTER TABLE [edfi].[DescriptorMapping] ADD CONSTRAINT DescriptorMapping_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[DisciplineAction]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[DisciplineAction] ADD [ChangeVersion] [BIGINT] CONSTRAINT DisciplineAction_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[DisciplineAction] DROP CONSTRAINT DisciplineAction_DF_ChangeVersion;
ALTER TABLE [edfi].[DisciplineAction] ADD CONSTRAINT DisciplineAction_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[DisciplineIncident]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[DisciplineIncident] ADD [ChangeVersion] [BIGINT] CONSTRAINT DisciplineIncident_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[DisciplineIncident] DROP CONSTRAINT DisciplineIncident_DF_ChangeVersion;
ALTER TABLE [edfi].[DisciplineIncident] ADD CONSTRAINT DisciplineIncident_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationContent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[EducationContent] ADD [ChangeVersion] [BIGINT] CONSTRAINT EducationContent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[EducationContent] DROP CONSTRAINT EducationContent_DF_ChangeVersion;
ALTER TABLE [edfi].[EducationContent] ADD CONSTRAINT EducationContent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganization]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[EducationOrganization] ADD [ChangeVersion] [BIGINT] CONSTRAINT EducationOrganization_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[EducationOrganization] DROP CONSTRAINT EducationOrganization_DF_ChangeVersion;
ALTER TABLE [edfi].[EducationOrganization] ADD CONSTRAINT EducationOrganization_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganizationInterventionPrescriptionAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT EducationOrganizationInterventionPrescriptionAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] DROP CONSTRAINT EducationOrganizationInterventionPrescriptionAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD CONSTRAINT EducationOrganizationInterventionPrescriptionAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganizationNetworkAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT EducationOrganizationNetworkAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] DROP CONSTRAINT EducationOrganizationNetworkAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD CONSTRAINT EducationOrganizationNetworkAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganizationPeerAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT EducationOrganizationPeerAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] DROP CONSTRAINT EducationOrganizationPeerAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD CONSTRAINT EducationOrganizationPeerAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[FeederSchoolAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT FeederSchoolAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[FeederSchoolAssociation] DROP CONSTRAINT FeederSchoolAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD CONSTRAINT FeederSchoolAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[FunctionDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[FunctionDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT FunctionDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[FunctionDimension] DROP CONSTRAINT FunctionDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[FunctionDimension] ADD CONSTRAINT FunctionDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[FundDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[FundDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT FundDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[FundDimension] DROP CONSTRAINT FundDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[FundDimension] ADD CONSTRAINT FundDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GeneralStudentProgramAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT GeneralStudentProgramAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] DROP CONSTRAINT GeneralStudentProgramAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD CONSTRAINT GeneralStudentProgramAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Grade]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Grade] ADD [ChangeVersion] [BIGINT] CONSTRAINT Grade_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Grade] DROP CONSTRAINT Grade_DF_ChangeVersion;
ALTER TABLE [edfi].[Grade] ADD CONSTRAINT Grade_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GradebookEntry]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[GradebookEntry] ADD [ChangeVersion] [BIGINT] CONSTRAINT GradebookEntry_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[GradebookEntry] DROP CONSTRAINT GradebookEntry_DF_ChangeVersion;
ALTER TABLE [edfi].[GradebookEntry] ADD CONSTRAINT GradebookEntry_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GradingPeriod]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[GradingPeriod] ADD [ChangeVersion] [BIGINT] CONSTRAINT GradingPeriod_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[GradingPeriod] DROP CONSTRAINT GradingPeriod_DF_ChangeVersion;
ALTER TABLE [edfi].[GradingPeriod] ADD CONSTRAINT GradingPeriod_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GraduationPlan]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[GraduationPlan] ADD [ChangeVersion] [BIGINT] CONSTRAINT GraduationPlan_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[GraduationPlan] DROP CONSTRAINT GraduationPlan_DF_ChangeVersion;
ALTER TABLE [edfi].[GraduationPlan] ADD CONSTRAINT GraduationPlan_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Intervention]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Intervention] ADD [ChangeVersion] [BIGINT] CONSTRAINT Intervention_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Intervention] DROP CONSTRAINT Intervention_DF_ChangeVersion;
ALTER TABLE [edfi].[Intervention] ADD CONSTRAINT Intervention_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[InterventionPrescription]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[InterventionPrescription] ADD [ChangeVersion] [BIGINT] CONSTRAINT InterventionPrescription_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[InterventionPrescription] DROP CONSTRAINT InterventionPrescription_DF_ChangeVersion;
ALTER TABLE [edfi].[InterventionPrescription] ADD CONSTRAINT InterventionPrescription_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[InterventionStudy]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[InterventionStudy] ADD [ChangeVersion] [BIGINT] CONSTRAINT InterventionStudy_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[InterventionStudy] DROP CONSTRAINT InterventionStudy_DF_ChangeVersion;
ALTER TABLE [edfi].[InterventionStudy] ADD CONSTRAINT InterventionStudy_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LearningObjective]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LearningObjective] ADD [ChangeVersion] [BIGINT] CONSTRAINT LearningObjective_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LearningObjective] DROP CONSTRAINT LearningObjective_DF_ChangeVersion;
ALTER TABLE [edfi].[LearningObjective] ADD CONSTRAINT LearningObjective_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LearningStandard]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LearningStandard] ADD [ChangeVersion] [BIGINT] CONSTRAINT LearningStandard_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LearningStandard] DROP CONSTRAINT LearningStandard_DF_ChangeVersion;
ALTER TABLE [edfi].[LearningStandard] ADD CONSTRAINT LearningStandard_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LearningStandardEquivalenceAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT LearningStandardEquivalenceAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] DROP CONSTRAINT LearningStandardEquivalenceAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD CONSTRAINT LearningStandardEquivalenceAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LocalAccount]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LocalAccount] ADD [ChangeVersion] [BIGINT] CONSTRAINT LocalAccount_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LocalAccount] DROP CONSTRAINT LocalAccount_DF_ChangeVersion;
ALTER TABLE [edfi].[LocalAccount] ADD CONSTRAINT LocalAccount_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LocalActual]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LocalActual] ADD [ChangeVersion] [BIGINT] CONSTRAINT LocalActual_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LocalActual] DROP CONSTRAINT LocalActual_DF_ChangeVersion;
ALTER TABLE [edfi].[LocalActual] ADD CONSTRAINT LocalActual_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LocalBudget]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LocalBudget] ADD [ChangeVersion] [BIGINT] CONSTRAINT LocalBudget_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LocalBudget] DROP CONSTRAINT LocalBudget_DF_ChangeVersion;
ALTER TABLE [edfi].[LocalBudget] ADD CONSTRAINT LocalBudget_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LocalContractedStaff]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LocalContractedStaff] ADD [ChangeVersion] [BIGINT] CONSTRAINT LocalContractedStaff_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LocalContractedStaff] DROP CONSTRAINT LocalContractedStaff_DF_ChangeVersion;
ALTER TABLE [edfi].[LocalContractedStaff] ADD CONSTRAINT LocalContractedStaff_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LocalEncumbrance]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LocalEncumbrance] ADD [ChangeVersion] [BIGINT] CONSTRAINT LocalEncumbrance_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LocalEncumbrance] DROP CONSTRAINT LocalEncumbrance_DF_ChangeVersion;
ALTER TABLE [edfi].[LocalEncumbrance] ADD CONSTRAINT LocalEncumbrance_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LocalPayroll]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[LocalPayroll] ADD [ChangeVersion] [BIGINT] CONSTRAINT LocalPayroll_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[LocalPayroll] DROP CONSTRAINT LocalPayroll_DF_ChangeVersion;
ALTER TABLE [edfi].[LocalPayroll] ADD CONSTRAINT LocalPayroll_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Location]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Location] ADD [ChangeVersion] [BIGINT] CONSTRAINT Location_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Location] DROP CONSTRAINT Location_DF_ChangeVersion;
ALTER TABLE [edfi].[Location] ADD CONSTRAINT Location_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ObjectDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[ObjectDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT ObjectDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[ObjectDimension] DROP CONSTRAINT ObjectDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[ObjectDimension] ADD CONSTRAINT ObjectDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ObjectiveAssessment]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[ObjectiveAssessment] ADD [ChangeVersion] [BIGINT] CONSTRAINT ObjectiveAssessment_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[ObjectiveAssessment] DROP CONSTRAINT ObjectiveAssessment_DF_ChangeVersion;
ALTER TABLE [edfi].[ObjectiveAssessment] ADD CONSTRAINT ObjectiveAssessment_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[OpenStaffPosition]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[OpenStaffPosition] ADD [ChangeVersion] [BIGINT] CONSTRAINT OpenStaffPosition_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[OpenStaffPosition] DROP CONSTRAINT OpenStaffPosition_DF_ChangeVersion;
ALTER TABLE [edfi].[OpenStaffPosition] ADD CONSTRAINT OpenStaffPosition_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[OperationalUnitDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[OperationalUnitDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT OperationalUnitDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[OperationalUnitDimension] DROP CONSTRAINT OperationalUnitDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[OperationalUnitDimension] ADD CONSTRAINT OperationalUnitDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Parent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Parent] ADD [ChangeVersion] [BIGINT] CONSTRAINT Parent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Parent] DROP CONSTRAINT Parent_DF_ChangeVersion;
ALTER TABLE [edfi].[Parent] ADD CONSTRAINT Parent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Person]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Person] ADD [ChangeVersion] [BIGINT] CONSTRAINT Person_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Person] DROP CONSTRAINT Person_DF_ChangeVersion;
ALTER TABLE [edfi].[Person] ADD CONSTRAINT Person_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[PostSecondaryEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[PostSecondaryEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT PostSecondaryEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[PostSecondaryEvent] DROP CONSTRAINT PostSecondaryEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[PostSecondaryEvent] ADD CONSTRAINT PostSecondaryEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Program]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Program] ADD [ChangeVersion] [BIGINT] CONSTRAINT Program_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Program] DROP CONSTRAINT Program_DF_ChangeVersion;
ALTER TABLE [edfi].[Program] ADD CONSTRAINT Program_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ProgramDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[ProgramDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT ProgramDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[ProgramDimension] DROP CONSTRAINT ProgramDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[ProgramDimension] ADD CONSTRAINT ProgramDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ProjectDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[ProjectDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT ProjectDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[ProjectDimension] DROP CONSTRAINT ProjectDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[ProjectDimension] ADD CONSTRAINT ProjectDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ReportCard]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[ReportCard] ADD [ChangeVersion] [BIGINT] CONSTRAINT ReportCard_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[ReportCard] DROP CONSTRAINT ReportCard_DF_ChangeVersion;
ALTER TABLE [edfi].[ReportCard] ADD CONSTRAINT ReportCard_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[RestraintEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[RestraintEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT RestraintEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[RestraintEvent] DROP CONSTRAINT RestraintEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[RestraintEvent] ADD CONSTRAINT RestraintEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SchoolYearType]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SchoolYearType] ADD [ChangeVersion] [BIGINT] CONSTRAINT SchoolYearType_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SchoolYearType] DROP CONSTRAINT SchoolYearType_DF_ChangeVersion;
ALTER TABLE [edfi].[SchoolYearType] ADD CONSTRAINT SchoolYearType_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Section]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Section] ADD [ChangeVersion] [BIGINT] CONSTRAINT Section_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Section] DROP CONSTRAINT Section_DF_ChangeVersion;
ALTER TABLE [edfi].[Section] ADD CONSTRAINT Section_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SectionAttendanceTakenEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT SectionAttendanceTakenEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] DROP CONSTRAINT SectionAttendanceTakenEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD CONSTRAINT SectionAttendanceTakenEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Session]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Session] ADD [ChangeVersion] [BIGINT] CONSTRAINT Session_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Session] DROP CONSTRAINT Session_DF_ChangeVersion;
ALTER TABLE [edfi].[Session] ADD CONSTRAINT Session_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SourceDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SourceDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT SourceDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SourceDimension] DROP CONSTRAINT SourceDimension_DF_ChangeVersion;
ALTER TABLE [edfi].[SourceDimension] ADD CONSTRAINT SourceDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Staff]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Staff] ADD [ChangeVersion] [BIGINT] CONSTRAINT Staff_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Staff] DROP CONSTRAINT Staff_DF_ChangeVersion;
ALTER TABLE [edfi].[Staff] ADD CONSTRAINT Staff_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffAbsenceEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffAbsenceEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffAbsenceEvent] DROP CONSTRAINT StaffAbsenceEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD CONSTRAINT StaffAbsenceEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffCohortAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffCohortAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffCohortAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffCohortAssociation] DROP CONSTRAINT StaffCohortAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffCohortAssociation] ADD CONSTRAINT StaffCohortAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffDisciplineIncidentAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffDisciplineIncidentAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] DROP CONSTRAINT StaffDisciplineIncidentAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD CONSTRAINT StaffDisciplineIncidentAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffEducationOrganizationAssignmentAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffEducationOrganizationAssignmentAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] DROP CONSTRAINT StaffEducationOrganizationAssignmentAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD CONSTRAINT StaffEducationOrganizationAssignmentAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffEducationOrganizationContactAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffEducationOrganizationContactAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] DROP CONSTRAINT StaffEducationOrganizationContactAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ADD CONSTRAINT StaffEducationOrganizationContactAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffEducationOrganizationEmploymentAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffEducationOrganizationEmploymentAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] DROP CONSTRAINT StaffEducationOrganizationEmploymentAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD CONSTRAINT StaffEducationOrganizationEmploymentAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffLeave]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffLeave] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffLeave_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffLeave] DROP CONSTRAINT StaffLeave_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffLeave] ADD CONSTRAINT StaffLeave_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffProgramAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffProgramAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffProgramAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffProgramAssociation] DROP CONSTRAINT StaffProgramAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffProgramAssociation] ADD CONSTRAINT StaffProgramAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffSchoolAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffSchoolAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffSchoolAssociation] DROP CONSTRAINT StaffSchoolAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD CONSTRAINT StaffSchoolAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffSectionAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StaffSectionAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StaffSectionAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StaffSectionAssociation] DROP CONSTRAINT StaffSectionAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StaffSectionAssociation] ADD CONSTRAINT StaffSectionAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Student]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Student] ADD [ChangeVersion] [BIGINT] CONSTRAINT Student_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Student] DROP CONSTRAINT Student_DF_ChangeVersion;
ALTER TABLE [edfi].[Student] ADD CONSTRAINT Student_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentAcademicRecord]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentAcademicRecord] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentAcademicRecord_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentAcademicRecord] DROP CONSTRAINT StudentAcademicRecord_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentAcademicRecord] ADD CONSTRAINT StudentAcademicRecord_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentAssessment]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentAssessment] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentAssessment_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentAssessment] DROP CONSTRAINT StudentAssessment_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentAssessment] ADD CONSTRAINT StudentAssessment_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentAssessmentEducationOrganizationAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentAssessmentEducationOrganizationAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] DROP CONSTRAINT StudentAssessmentEducationOrganizationAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD CONSTRAINT StudentAssessmentEducationOrganizationAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentCohortAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentCohortAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentCohortAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentCohortAssociation] DROP CONSTRAINT StudentCohortAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentCohortAssociation] ADD CONSTRAINT StudentCohortAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentCompetencyObjective]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentCompetencyObjective_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentCompetencyObjective] DROP CONSTRAINT StudentCompetencyObjective_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD CONSTRAINT StudentCompetencyObjective_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentDisciplineIncidentAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentDisciplineIncidentAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] DROP CONSTRAINT StudentDisciplineIncidentAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ADD CONSTRAINT StudentDisciplineIncidentAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentDisciplineIncidentBehaviorAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentDisciplineIncidentBehaviorAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] DROP CONSTRAINT StudentDisciplineIncidentBehaviorAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT StudentDisciplineIncidentBehaviorAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentDisciplineIncidentNonOffenderAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentDisciplineIncidentNonOffenderAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] DROP CONSTRAINT StudentDisciplineIncidentNonOffenderAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD CONSTRAINT StudentDisciplineIncidentNonOffenderAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentEducationOrganizationAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentEducationOrganizationAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] DROP CONSTRAINT StudentEducationOrganizationAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD CONSTRAINT StudentEducationOrganizationAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentEducationOrganizationResponsibilityAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentEducationOrganizationResponsibilityAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] DROP CONSTRAINT StudentEducationOrganizationResponsibilityAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD CONSTRAINT StudentEducationOrganizationResponsibilityAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentGradebookEntry]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentGradebookEntry] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentGradebookEntry_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentGradebookEntry] DROP CONSTRAINT StudentGradebookEntry_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentGradebookEntry] ADD CONSTRAINT StudentGradebookEntry_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentInterventionAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentInterventionAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentInterventionAssociation] DROP CONSTRAINT StudentInterventionAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD CONSTRAINT StudentInterventionAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentInterventionAttendanceEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentInterventionAttendanceEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] DROP CONSTRAINT StudentInterventionAttendanceEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD CONSTRAINT StudentInterventionAttendanceEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentLearningObjective]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentLearningObjective] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentLearningObjective_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentLearningObjective] DROP CONSTRAINT StudentLearningObjective_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentLearningObjective] ADD CONSTRAINT StudentLearningObjective_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentParentAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentParentAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentParentAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentParentAssociation] DROP CONSTRAINT StudentParentAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentParentAssociation] ADD CONSTRAINT StudentParentAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentProgramAttendanceEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentProgramAttendanceEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] DROP CONSTRAINT StudentProgramAttendanceEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD CONSTRAINT StudentProgramAttendanceEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSchoolAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentSchoolAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentSchoolAssociation] DROP CONSTRAINT StudentSchoolAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD CONSTRAINT StudentSchoolAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSchoolAttendanceEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentSchoolAttendanceEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] DROP CONSTRAINT StudentSchoolAttendanceEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD CONSTRAINT StudentSchoolAttendanceEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSectionAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentSectionAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentSectionAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentSectionAssociation] DROP CONSTRAINT StudentSectionAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentSectionAssociation] ADD CONSTRAINT StudentSectionAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSectionAttendanceEvent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentSectionAttendanceEvent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] DROP CONSTRAINT StudentSectionAttendanceEvent_DF_ChangeVersion;
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD CONSTRAINT StudentSectionAttendanceEvent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Survey]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[Survey] ADD [ChangeVersion] [BIGINT] CONSTRAINT Survey_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[Survey] DROP CONSTRAINT Survey_DF_ChangeVersion;
ALTER TABLE [edfi].[Survey] ADD CONSTRAINT Survey_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyCourseAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyCourseAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveyCourseAssociation] DROP CONSTRAINT SurveyCourseAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD CONSTRAINT SurveyCourseAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyProgramAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyProgramAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveyProgramAssociation] DROP CONSTRAINT SurveyProgramAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD CONSTRAINT SurveyProgramAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyQuestion]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveyQuestion] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyQuestion_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveyQuestion] DROP CONSTRAINT SurveyQuestion_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveyQuestion] ADD CONSTRAINT SurveyQuestion_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyQuestionResponse]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyQuestionResponse_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveyQuestionResponse] DROP CONSTRAINT SurveyQuestionResponse_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD CONSTRAINT SurveyQuestionResponse_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyResponse]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveyResponse] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyResponse_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveyResponse] DROP CONSTRAINT SurveyResponse_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveyResponse] ADD CONSTRAINT SurveyResponse_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyResponseEducationOrganizationTargetAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyResponseEducationOrganizationTargetAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] DROP CONSTRAINT SurveyResponseEducationOrganizationTargetAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT SurveyResponseEducationOrganizationTargetAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyResponseStaffTargetAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyResponseStaffTargetAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] DROP CONSTRAINT SurveyResponseStaffTargetAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD CONSTRAINT SurveyResponseStaffTargetAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySection]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveySection] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveySection_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveySection] DROP CONSTRAINT SurveySection_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveySection] ADD CONSTRAINT SurveySection_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveySectionAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveySectionAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveySectionAssociation] DROP CONSTRAINT SurveySectionAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveySectionAssociation] ADD CONSTRAINT SurveySectionAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionResponse]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveySectionResponse] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveySectionResponse_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveySectionResponse] DROP CONSTRAINT SurveySectionResponse_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveySectionResponse] ADD CONSTRAINT SurveySectionResponse_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveySectionResponseEducationOrganizationTargetAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] DROP CONSTRAINT SurveySectionResponseEducationOrganizationTargetAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT SurveySectionResponseEducationOrganizationTargetAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionResponseStaffTargetAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveySectionResponseStaffTargetAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] DROP CONSTRAINT SurveySectionResponseStaffTargetAssociation_DF_ChangeVersion;
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD CONSTRAINT SurveySectionResponseStaffTargetAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


