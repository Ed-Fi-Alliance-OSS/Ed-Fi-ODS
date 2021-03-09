-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ApplicantProfile') AND name = N'UX_ApplicantProfile_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ApplicantProfile_Id ON [tpdm].[ApplicantProfile]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Application') AND name = N'UX_Application_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Application_Id ON [tpdm].[Application]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ApplicationEvent') AND name = N'UX_ApplicationEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ApplicationEvent_Id ON [tpdm].[ApplicationEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Candidate') AND name = N'UX_Candidate_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Candidate_Id ON [tpdm].[Candidate]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CandidateEducatorPreparationProgramAssociation') AND name = N'UX_CandidateEducatorPreparationProgramAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CandidateEducatorPreparationProgramAssociation_Id ON [tpdm].[CandidateEducatorPreparationProgramAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CandidateRelationshipToStaffAssociation') AND name = N'UX_CandidateRelationshipToStaffAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CandidateRelationshipToStaffAssociation_Id ON [tpdm].[CandidateRelationshipToStaffAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Certification') AND name = N'UX_Certification_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Certification_Id ON [tpdm].[Certification]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CertificationExam') AND name = N'UX_CertificationExam_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CertificationExam_Id ON [tpdm].[CertificationExam]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CertificationExamResult') AND name = N'UX_CertificationExamResult_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CertificationExamResult_Id ON [tpdm].[CertificationExamResult]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CredentialEvent') AND name = N'UX_CredentialEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_CredentialEvent_Id ON [tpdm].[CredentialEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EducatorPreparationProgram') AND name = N'UX_EducatorPreparationProgram_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EducatorPreparationProgram_Id ON [tpdm].[EducatorPreparationProgram]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Evaluation') AND name = N'UX_Evaluation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Evaluation_Id ON [tpdm].[Evaluation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationElement') AND name = N'UX_EvaluationElement_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationElement_Id ON [tpdm].[EvaluationElement]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationElementRating') AND name = N'UX_EvaluationElementRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationElementRating_Id ON [tpdm].[EvaluationElementRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationObjective') AND name = N'UX_EvaluationObjective_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationObjective_Id ON [tpdm].[EvaluationObjective]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationObjectiveRating') AND name = N'UX_EvaluationObjectiveRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationObjectiveRating_Id ON [tpdm].[EvaluationObjectiveRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationRating') AND name = N'UX_EvaluationRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_EvaluationRating_Id ON [tpdm].[EvaluationRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FieldworkExperience') AND name = N'UX_FieldworkExperience_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FieldworkExperience_Id ON [tpdm].[FieldworkExperience]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FieldworkExperienceSectionAssociation') AND name = N'UX_FieldworkExperienceSectionAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FieldworkExperienceSectionAssociation_Id ON [tpdm].[FieldworkExperienceSectionAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Goal') AND name = N'UX_Goal_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Goal_Id ON [tpdm].[Goal]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.OpenStaffPositionEvent') AND name = N'UX_OpenStaffPositionEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_OpenStaffPositionEvent_Id ON [tpdm].[OpenStaffPositionEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.PerformanceEvaluation') AND name = N'UX_PerformanceEvaluation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PerformanceEvaluation_Id ON [tpdm].[PerformanceEvaluation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.PerformanceEvaluationRating') AND name = N'UX_PerformanceEvaluationRating_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PerformanceEvaluationRating_Id ON [tpdm].[PerformanceEvaluationRating]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ProfessionalDevelopmentEvent') AND name = N'UX_ProfessionalDevelopmentEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProfessionalDevelopmentEvent_Id ON [tpdm].[ProfessionalDevelopmentEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ProfessionalDevelopmentEventAttendance') AND name = N'UX_ProfessionalDevelopmentEventAttendance_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_ProfessionalDevelopmentEventAttendance_Id ON [tpdm].[ProfessionalDevelopmentEventAttendance]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.QuantitativeMeasure') AND name = N'UX_QuantitativeMeasure_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_QuantitativeMeasure_Id ON [tpdm].[QuantitativeMeasure]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.QuantitativeMeasureScore') AND name = N'UX_QuantitativeMeasureScore_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_QuantitativeMeasureScore_Id ON [tpdm].[QuantitativeMeasureScore]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RecruitmentEvent') AND name = N'UX_RecruitmentEvent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RecruitmentEvent_Id ON [tpdm].[RecruitmentEvent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RecruitmentEventAttendance') AND name = N'UX_RecruitmentEventAttendance_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RecruitmentEventAttendance_Id ON [tpdm].[RecruitmentEventAttendance]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RubricDimension') AND name = N'UX_RubricDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RubricDimension_Id ON [tpdm].[RubricDimension]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffEducatorPreparationProgramAssociation') AND name = N'UX_StaffEducatorPreparationProgramAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StaffEducatorPreparationProgramAssociation_Id ON [tpdm].[StaffEducatorPreparationProgramAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveyResponsePersonTargetAssociation') AND name = N'UX_SurveyResponsePersonTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveyResponsePersonTargetAssociation_Id ON [tpdm].[SurveyResponsePersonTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionAggregateResponse') AND name = N'UX_SurveySectionAggregateResponse_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionAggregateResponse_Id ON [tpdm].[SurveySectionAggregateResponse]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionResponsePersonTargetAssociation') AND name = N'UX_SurveySectionResponsePersonTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionResponsePersonTargetAssociation_Id ON [tpdm].[SurveySectionResponsePersonTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

