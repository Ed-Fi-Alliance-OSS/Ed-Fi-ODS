-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AcademicWeek') AND name = N'UX_AcademicWeek_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_AcademicWeek_Id ON [edfi].[AcademicWeek]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AccountabilityRating') AND name = N'UX_AccountabilityRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_AccountabilityRating_Id ON [edfi].[AccountabilityRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ApplicantProfile') AND name = N'UX_ApplicantProfile_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ApplicantProfile_Id ON [edfi].[ApplicantProfile]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Application') AND name = N'UX_Application_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Application_Id ON [edfi].[Application]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ApplicationEvent') AND name = N'UX_ApplicationEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ApplicationEvent_Id ON [edfi].[ApplicationEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Assessment') AND name = N'UX_Assessment_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Assessment_Id ON [edfi].[Assessment]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AssessmentAdministration') AND name = N'UX_AssessmentAdministration_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_AssessmentAdministration_Id ON [edfi].[AssessmentAdministration]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AssessmentAdministrationParticipation') AND name = N'UX_AssessmentAdministrationParticipation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_AssessmentAdministrationParticipation_Id ON [edfi].[AssessmentAdministrationParticipation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AssessmentBatteryPart') AND name = N'UX_AssessmentBatteryPart_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_AssessmentBatteryPart_Id ON [edfi].[AssessmentBatteryPart]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AssessmentItem') AND name = N'UX_AssessmentItem_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_AssessmentItem_Id ON [edfi].[AssessmentItem]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AssessmentScoreRangeLearningStandard') AND name = N'UX_AssessmentScoreRangeLearningStandard_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_AssessmentScoreRangeLearningStandard_Id ON [edfi].[AssessmentScoreRangeLearningStandard]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.BalanceSheetDimension') AND name = N'UX_BalanceSheetDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_BalanceSheetDimension_Id ON [edfi].[BalanceSheetDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.BellSchedule') AND name = N'UX_BellSchedule_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_BellSchedule_Id ON [edfi].[BellSchedule]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Calendar') AND name = N'UX_Calendar_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Calendar_Id ON [edfi].[Calendar]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CalendarDate') AND name = N'UX_CalendarDate_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CalendarDate_Id ON [edfi].[CalendarDate]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Candidate') AND name = N'UX_Candidate_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Candidate_Id ON [edfi].[Candidate]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CandidateEducatorPreparationProgramAssociation') AND name = N'UX_CandidateEducatorPreparationProgramAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CandidateEducatorPreparationProgramAssociation_Id ON [edfi].[CandidateEducatorPreparationProgramAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CandidateIdentificationCode') AND name = N'UX_CandidateIdentificationCode_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CandidateIdentificationCode_Id ON [edfi].[CandidateIdentificationCode]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CandidateRelationshipToStaffAssociation') AND name = N'UX_CandidateRelationshipToStaffAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CandidateRelationshipToStaffAssociation_Id ON [edfi].[CandidateRelationshipToStaffAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Certification') AND name = N'UX_Certification_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Certification_Id ON [edfi].[Certification]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CertificationExam') AND name = N'UX_CertificationExam_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CertificationExam_Id ON [edfi].[CertificationExam]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CertificationExamResult') AND name = N'UX_CertificationExamResult_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CertificationExamResult_Id ON [edfi].[CertificationExamResult]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ChartOfAccount') AND name = N'UX_ChartOfAccount_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ChartOfAccount_Id ON [edfi].[ChartOfAccount]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ClassPeriod') AND name = N'UX_ClassPeriod_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ClassPeriod_Id ON [edfi].[ClassPeriod]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Cohort') AND name = N'UX_Cohort_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Cohort_Id ON [edfi].[Cohort]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CommunityProviderLicense') AND name = N'UX_CommunityProviderLicense_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CommunityProviderLicense_Id ON [edfi].[CommunityProviderLicense]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CompetencyObjective') AND name = N'UX_CompetencyObjective_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CompetencyObjective_Id ON [edfi].[CompetencyObjective]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Contact') AND name = N'UX_Contact_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Contact_Id ON [edfi].[Contact]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ContactIdentificationCode') AND name = N'UX_ContactIdentificationCode_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ContactIdentificationCode_Id ON [edfi].[ContactIdentificationCode]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Course') AND name = N'UX_Course_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Course_Id ON [edfi].[Course]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CourseOffering') AND name = N'UX_CourseOffering_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CourseOffering_Id ON [edfi].[CourseOffering]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CourseTranscript') AND name = N'UX_CourseTranscript_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CourseTranscript_Id ON [edfi].[CourseTranscript]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Credential') AND name = N'UX_Credential_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Credential_Id ON [edfi].[Credential]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CredentialEvent') AND name = N'UX_CredentialEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CredentialEvent_Id ON [edfi].[CredentialEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CrisisEvent') AND name = N'UX_CrisisEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CrisisEvent_Id ON [edfi].[CrisisEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Descriptor') AND name = N'UX_Descriptor_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Descriptor_Id ON [edfi].[Descriptor]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.DescriptorMapping') AND name = N'UX_DescriptorMapping_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_DescriptorMapping_Id ON [edfi].[DescriptorMapping]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.DisciplineAction') AND name = N'UX_DisciplineAction_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_DisciplineAction_Id ON [edfi].[DisciplineAction]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.DisciplineIncident') AND name = N'UX_DisciplineIncident_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_DisciplineIncident_Id ON [edfi].[DisciplineIncident]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationContent') AND name = N'UX_EducationContent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducationContent_Id ON [edfi].[EducationContent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganization') AND name = N'UX_EducationOrganization_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducationOrganization_Id ON [edfi].[EducationOrganization]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganizationIdentificationCode') AND name = N'UX_EducationOrganizationIdentificationCode_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducationOrganizationIdentificationCode_Id ON [edfi].[EducationOrganizationIdentificationCode]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganizationInterventionPrescriptionAssociation') AND name = N'UX_EducationOrganizationInterventionPrescriptionAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducationOrganizationInterventionPrescriptionAssociation_Id ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganizationNetworkAssociation') AND name = N'UX_EducationOrganizationNetworkAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducationOrganizationNetworkAssociation_Id ON [edfi].[EducationOrganizationNetworkAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganizationPeerAssociation') AND name = N'UX_EducationOrganizationPeerAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducationOrganizationPeerAssociation_Id ON [edfi].[EducationOrganizationPeerAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducatorPreparationProgram') AND name = N'UX_EducatorPreparationProgram_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducatorPreparationProgram_Id ON [edfi].[EducatorPreparationProgram]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Evaluation') AND name = N'UX_Evaluation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Evaluation_Id ON [edfi].[Evaluation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EvaluationElement') AND name = N'UX_EvaluationElement_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationElement_Id ON [edfi].[EvaluationElement]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EvaluationElementRating') AND name = N'UX_EvaluationElementRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationElementRating_Id ON [edfi].[EvaluationElementRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EvaluationObjective') AND name = N'UX_EvaluationObjective_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationObjective_Id ON [edfi].[EvaluationObjective]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EvaluationObjectiveRating') AND name = N'UX_EvaluationObjectiveRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationObjectiveRating_Id ON [edfi].[EvaluationObjectiveRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EvaluationRating') AND name = N'UX_EvaluationRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationRating_Id ON [edfi].[EvaluationRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EvaluationRubricDimension') AND name = N'UX_EvaluationRubricDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationRubricDimension_Id ON [edfi].[EvaluationRubricDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.FeederSchoolAssociation') AND name = N'UX_FeederSchoolAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FeederSchoolAssociation_Id ON [edfi].[FeederSchoolAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.FieldworkExperience') AND name = N'UX_FieldworkExperience_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FieldworkExperience_Id ON [edfi].[FieldworkExperience]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.FieldworkExperienceSectionAssociation') AND name = N'UX_FieldworkExperienceSectionAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FieldworkExperienceSectionAssociation_Id ON [edfi].[FieldworkExperienceSectionAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.FinancialAid') AND name = N'UX_FinancialAid_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FinancialAid_Id ON [edfi].[FinancialAid]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.FunctionDimension') AND name = N'UX_FunctionDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FunctionDimension_Id ON [edfi].[FunctionDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.FundDimension') AND name = N'UX_FundDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FundDimension_Id ON [edfi].[FundDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GeneralStudentProgramAssociation') AND name = N'UX_GeneralStudentProgramAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_GeneralStudentProgramAssociation_Id ON [edfi].[GeneralStudentProgramAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Goal') AND name = N'UX_Goal_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Goal_Id ON [edfi].[Goal]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Grade') AND name = N'UX_Grade_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Grade_Id ON [edfi].[Grade]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GradebookEntry') AND name = N'UX_GradebookEntry_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_GradebookEntry_Id ON [edfi].[GradebookEntry]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GradingPeriod') AND name = N'UX_GradingPeriod_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_GradingPeriod_Id ON [edfi].[GradingPeriod]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GraduationPlan') AND name = N'UX_GraduationPlan_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_GraduationPlan_Id ON [edfi].[GraduationPlan]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Intervention') AND name = N'UX_Intervention_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Intervention_Id ON [edfi].[Intervention]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.InterventionPrescription') AND name = N'UX_InterventionPrescription_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_InterventionPrescription_Id ON [edfi].[InterventionPrescription]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.InterventionStudy') AND name = N'UX_InterventionStudy_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_InterventionStudy_Id ON [edfi].[InterventionStudy]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LearningStandard') AND name = N'UX_LearningStandard_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LearningStandard_Id ON [edfi].[LearningStandard]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LearningStandardEquivalenceAssociation') AND name = N'UX_LearningStandardEquivalenceAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LearningStandardEquivalenceAssociation_Id ON [edfi].[LearningStandardEquivalenceAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LocalAccount') AND name = N'UX_LocalAccount_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LocalAccount_Id ON [edfi].[LocalAccount]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LocalActual') AND name = N'UX_LocalActual_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LocalActual_Id ON [edfi].[LocalActual]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LocalBudget') AND name = N'UX_LocalBudget_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LocalBudget_Id ON [edfi].[LocalBudget]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LocalContractedStaff') AND name = N'UX_LocalContractedStaff_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LocalContractedStaff_Id ON [edfi].[LocalContractedStaff]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LocalEncumbrance') AND name = N'UX_LocalEncumbrance_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LocalEncumbrance_Id ON [edfi].[LocalEncumbrance]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LocalPayroll') AND name = N'UX_LocalPayroll_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_LocalPayroll_Id ON [edfi].[LocalPayroll]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Location') AND name = N'UX_Location_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Location_Id ON [edfi].[Location]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ObjectDimension') AND name = N'UX_ObjectDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ObjectDimension_Id ON [edfi].[ObjectDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ObjectiveAssessment') AND name = N'UX_ObjectiveAssessment_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ObjectiveAssessment_Id ON [edfi].[ObjectiveAssessment]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.OpenStaffPosition') AND name = N'UX_OpenStaffPosition_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_OpenStaffPosition_Id ON [edfi].[OpenStaffPosition]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.OpenStaffPositionEvent') AND name = N'UX_OpenStaffPositionEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_OpenStaffPositionEvent_Id ON [edfi].[OpenStaffPositionEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.OperationalUnitDimension') AND name = N'UX_OperationalUnitDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_OperationalUnitDimension_Id ON [edfi].[OperationalUnitDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Path') AND name = N'UX_Path_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Path_Id ON [edfi].[Path]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.PathMilestone') AND name = N'UX_PathMilestone_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PathMilestone_Id ON [edfi].[PathMilestone]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.PathPhase') AND name = N'UX_PathPhase_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PathPhase_Id ON [edfi].[PathPhase]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.PerformanceEvaluation') AND name = N'UX_PerformanceEvaluation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PerformanceEvaluation_Id ON [edfi].[PerformanceEvaluation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.PerformanceEvaluationRating') AND name = N'UX_PerformanceEvaluationRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PerformanceEvaluationRating_Id ON [edfi].[PerformanceEvaluationRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Person') AND name = N'UX_Person_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Person_Id ON [edfi].[Person]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.PostSecondaryEvent') AND name = N'UX_PostSecondaryEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PostSecondaryEvent_Id ON [edfi].[PostSecondaryEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ProfessionalDevelopmentEvent') AND name = N'UX_ProfessionalDevelopmentEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProfessionalDevelopmentEvent_Id ON [edfi].[ProfessionalDevelopmentEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ProfessionalDevelopmentEventAttendance') AND name = N'UX_ProfessionalDevelopmentEventAttendance_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProfessionalDevelopmentEventAttendance_Id ON [edfi].[ProfessionalDevelopmentEventAttendance]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Program') AND name = N'UX_Program_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Program_Id ON [edfi].[Program]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ProgramDimension') AND name = N'UX_ProgramDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProgramDimension_Id ON [edfi].[ProgramDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ProgramEvaluation') AND name = N'UX_ProgramEvaluation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProgramEvaluation_Id ON [edfi].[ProgramEvaluation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ProgramEvaluationElement') AND name = N'UX_ProgramEvaluationElement_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProgramEvaluationElement_Id ON [edfi].[ProgramEvaluationElement]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ProgramEvaluationObjective') AND name = N'UX_ProgramEvaluationObjective_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProgramEvaluationObjective_Id ON [edfi].[ProgramEvaluationObjective]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ProjectDimension') AND name = N'UX_ProjectDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProjectDimension_Id ON [edfi].[ProjectDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.QuantitativeMeasure') AND name = N'UX_QuantitativeMeasure_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_QuantitativeMeasure_Id ON [edfi].[QuantitativeMeasure]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.QuantitativeMeasureScore') AND name = N'UX_QuantitativeMeasureScore_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_QuantitativeMeasureScore_Id ON [edfi].[QuantitativeMeasureScore]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.RecruitmentEvent') AND name = N'UX_RecruitmentEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RecruitmentEvent_Id ON [edfi].[RecruitmentEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.RecruitmentEventAttendance') AND name = N'UX_RecruitmentEventAttendance_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RecruitmentEventAttendance_Id ON [edfi].[RecruitmentEventAttendance]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ReportCard') AND name = N'UX_ReportCard_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ReportCard_Id ON [edfi].[ReportCard]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.RestraintEvent') AND name = N'UX_RestraintEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RestraintEvent_Id ON [edfi].[RestraintEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.RubricDimension') AND name = N'UX_RubricDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RubricDimension_Id ON [edfi].[RubricDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SchoolYearType') AND name = N'UX_SchoolYearType_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SchoolYearType_Id ON [edfi].[SchoolYearType]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 100, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Section') AND name = N'UX_Section_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Section_Id ON [edfi].[Section]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SectionAttendanceTakenEvent') AND name = N'UX_SectionAttendanceTakenEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SectionAttendanceTakenEvent_Id ON [edfi].[SectionAttendanceTakenEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Session') AND name = N'UX_Session_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Session_Id ON [edfi].[Session]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SourceDimension') AND name = N'UX_SourceDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SourceDimension_Id ON [edfi].[SourceDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Staff') AND name = N'UX_Staff_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Staff_Id ON [edfi].[Staff]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffAbsenceEvent') AND name = N'UX_StaffAbsenceEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffAbsenceEvent_Id ON [edfi].[StaffAbsenceEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffCohortAssociation') AND name = N'UX_StaffCohortAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffCohortAssociation_Id ON [edfi].[StaffCohortAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffDemographic') AND name = N'UX_StaffDemographic_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffDemographic_Id ON [edfi].[StaffDemographic]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffDirectory') AND name = N'UX_StaffDirectory_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffDirectory_Id ON [edfi].[StaffDirectory]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffDisciplineIncidentAssociation') AND name = N'UX_StaffDisciplineIncidentAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffDisciplineIncidentAssociation_Id ON [edfi].[StaffDisciplineIncidentAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffEducationOrganizationAssignmentAssociation') AND name = N'UX_StaffEducationOrganizationAssignmentAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffEducationOrganizationAssignmentAssociation_Id ON [edfi].[StaffEducationOrganizationAssignmentAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffEducationOrganizationEmploymentAssociation') AND name = N'UX_StaffEducationOrganizationEmploymentAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffEducationOrganizationEmploymentAssociation_Id ON [edfi].[StaffEducationOrganizationEmploymentAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffEducatorPreparationProgramAssociation') AND name = N'UX_StaffEducatorPreparationProgramAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffEducatorPreparationProgramAssociation_Id ON [edfi].[StaffEducatorPreparationProgramAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffIdentificationCode') AND name = N'UX_StaffIdentificationCode_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffIdentificationCode_Id ON [edfi].[StaffIdentificationCode]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffLeave') AND name = N'UX_StaffLeave_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffLeave_Id ON [edfi].[StaffLeave]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffProgramAssociation') AND name = N'UX_StaffProgramAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffProgramAssociation_Id ON [edfi].[StaffProgramAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffSchoolAssociation') AND name = N'UX_StaffSchoolAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffSchoolAssociation_Id ON [edfi].[StaffSchoolAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffSectionAssociation') AND name = N'UX_StaffSectionAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffSectionAssociation_Id ON [edfi].[StaffSectionAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Student') AND name = N'UX_Student_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Student_Id ON [edfi].[Student]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentAcademicRecord') AND name = N'UX_StudentAcademicRecord_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentAcademicRecord_Id ON [edfi].[StudentAcademicRecord]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentAssessment') AND name = N'UX_StudentAssessment_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentAssessment_Id ON [edfi].[StudentAssessment]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentAssessmentEducationOrganizationAssociation') AND name = N'UX_StudentAssessmentEducationOrganizationAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentAssessmentEducationOrganizationAssociation_Id ON [edfi].[StudentAssessmentEducationOrganizationAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentAssessmentRegistration') AND name = N'UX_StudentAssessmentRegistration_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentAssessmentRegistration_Id ON [edfi].[StudentAssessmentRegistration]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentAssessmentRegistrationBatteryPartAssociation') AND name = N'UX_StudentAssessmentRegistrationBatteryPartAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentAssessmentRegistrationBatteryPartAssociation_Id ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentCohortAssociation') AND name = N'UX_StudentCohortAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentCohortAssociation_Id ON [edfi].[StudentCohortAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentCompetencyObjective') AND name = N'UX_StudentCompetencyObjective_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentCompetencyObjective_Id ON [edfi].[StudentCompetencyObjective]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentContactAssociation') AND name = N'UX_StudentContactAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentContactAssociation_Id ON [edfi].[StudentContactAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentDemographic') AND name = N'UX_StudentDemographic_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentDemographic_Id ON [edfi].[StudentDemographic]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentDirectory') AND name = N'UX_StudentDirectory_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentDirectory_Id ON [edfi].[StudentDirectory]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentDisciplineIncidentBehaviorAssociation') AND name = N'UX_StudentDisciplineIncidentBehaviorAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentDisciplineIncidentBehaviorAssociation_Id ON [edfi].[StudentDisciplineIncidentBehaviorAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentDisciplineIncidentNonOffenderAssociation') AND name = N'UX_StudentDisciplineIncidentNonOffenderAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentDisciplineIncidentNonOffenderAssociation_Id ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentEducationOrganizationAssessmentAccommodation') AND name = N'UX_StudentEducationOrganizationAssessmentAccommodation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentEducationOrganizationAssessmentAccommodation_Id ON [edfi].[StudentEducationOrganizationAssessmentAccommodation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentEducationOrganizationAssociation') AND name = N'UX_StudentEducationOrganizationAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentEducationOrganizationAssociation_Id ON [edfi].[StudentEducationOrganizationAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentEducationOrganizationResponsibilityAssociation') AND name = N'UX_StudentEducationOrganizationResponsibilityAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentEducationOrganizationResponsibilityAssociation_Id ON [edfi].[StudentEducationOrganizationResponsibilityAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentGradebookEntry') AND name = N'UX_StudentGradebookEntry_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentGradebookEntry_Id ON [edfi].[StudentGradebookEntry]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentHealth') AND name = N'UX_StudentHealth_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentHealth_Id ON [edfi].[StudentHealth]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentIdentificationCode') AND name = N'UX_StudentIdentificationCode_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentIdentificationCode_Id ON [edfi].[StudentIdentificationCode]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentInterventionAssociation') AND name = N'UX_StudentInterventionAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentInterventionAssociation_Id ON [edfi].[StudentInterventionAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentInterventionAttendanceEvent') AND name = N'UX_StudentInterventionAttendanceEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentInterventionAttendanceEvent_Id ON [edfi].[StudentInterventionAttendanceEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentPath') AND name = N'UX_StudentPath_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentPath_Id ON [edfi].[StudentPath]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentPathMilestoneStatus') AND name = N'UX_StudentPathMilestoneStatus_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentPathMilestoneStatus_Id ON [edfi].[StudentPathMilestoneStatus]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentPathPhaseStatus') AND name = N'UX_StudentPathPhaseStatus_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentPathPhaseStatus_Id ON [edfi].[StudentPathPhaseStatus]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentProgramAttendanceEvent') AND name = N'UX_StudentProgramAttendanceEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentProgramAttendanceEvent_Id ON [edfi].[StudentProgramAttendanceEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentProgramEvaluation') AND name = N'UX_StudentProgramEvaluation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentProgramEvaluation_Id ON [edfi].[StudentProgramEvaluation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSchoolAssociation') AND name = N'UX_StudentSchoolAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentSchoolAssociation_Id ON [edfi].[StudentSchoolAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSchoolAttendanceEvent') AND name = N'UX_StudentSchoolAttendanceEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentSchoolAttendanceEvent_Id ON [edfi].[StudentSchoolAttendanceEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSectionAssociation') AND name = N'UX_StudentSectionAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentSectionAssociation_Id ON [edfi].[StudentSectionAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSectionAttendanceEvent') AND name = N'UX_StudentSectionAttendanceEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentSectionAttendanceEvent_Id ON [edfi].[StudentSectionAttendanceEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSpecialEducationProgramEligibilityAssociation') AND name = N'UX_StudentSpecialEducationProgramEligibilityAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentSpecialEducationProgramEligibilityAssociation_Id ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentTransportation') AND name = N'UX_StudentTransportation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentTransportation_Id ON [edfi].[StudentTransportation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Survey') AND name = N'UX_Survey_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Survey_Id ON [edfi].[Survey]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyCourseAssociation') AND name = N'UX_SurveyCourseAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyCourseAssociation_Id ON [edfi].[SurveyCourseAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyProgramAssociation') AND name = N'UX_SurveyProgramAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyProgramAssociation_Id ON [edfi].[SurveyProgramAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyQuestion') AND name = N'UX_SurveyQuestion_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyQuestion_Id ON [edfi].[SurveyQuestion]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyQuestionResponse') AND name = N'UX_SurveyQuestionResponse_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyQuestionResponse_Id ON [edfi].[SurveyQuestionResponse]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyResponse') AND name = N'UX_SurveyResponse_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyResponse_Id ON [edfi].[SurveyResponse]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyResponseEducationOrganizationTargetAssociation') AND name = N'UX_SurveyResponseEducationOrganizationTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyResponseEducationOrganizationTargetAssociation_Id ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyResponsePersonTargetAssociation') AND name = N'UX_SurveyResponsePersonTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyResponsePersonTargetAssociation_Id ON [edfi].[SurveyResponsePersonTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyResponseStaffTargetAssociation') AND name = N'UX_SurveyResponseStaffTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyResponseStaffTargetAssociation_Id ON [edfi].[SurveyResponseStaffTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySection') AND name = N'UX_SurveySection_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySection_Id ON [edfi].[SurveySection]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionAggregateResponse') AND name = N'UX_SurveySectionAggregateResponse_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionAggregateResponse_Id ON [edfi].[SurveySectionAggregateResponse]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionAssociation') AND name = N'UX_SurveySectionAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionAssociation_Id ON [edfi].[SurveySectionAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionResponse') AND name = N'UX_SurveySectionResponse_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionResponse_Id ON [edfi].[SurveySectionResponse]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionResponseEducationOrganizationTargetAssociation') AND name = N'UX_SurveySectionResponseEducationOrganizationTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionResponseEducationOrganizationTargetAssociation_Id ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionResponsePersonTargetAssociation') AND name = N'UX_SurveySectionResponsePersonTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionResponsePersonTargetAssociation_Id ON [edfi].[SurveySectionResponsePersonTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionResponseStaffTargetAssociation') AND name = N'UX_SurveySectionResponseStaffTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionResponseStaffTargetAssociation_Id ON [edfi].[SurveySectionResponseStaffTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

