-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ApplicantProfile') AND name = N'UX_ApplicantProfile_ChangeVersion')
    CREATE INDEX [UX_ApplicantProfile_ChangeVersion] ON [tpdm].[ApplicantProfile] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Application') AND name = N'UX_Application_ChangeVersion')
    CREATE INDEX [UX_Application_ChangeVersion] ON [tpdm].[Application] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ApplicationEvent') AND name = N'UX_ApplicationEvent_ChangeVersion')
    CREATE INDEX [UX_ApplicationEvent_ChangeVersion] ON [tpdm].[ApplicationEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Candidate') AND name = N'UX_Candidate_ChangeVersion')
    CREATE INDEX [UX_Candidate_ChangeVersion] ON [tpdm].[Candidate] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CandidateEducatorPreparationProgramAssociation') AND name = N'UX_CandidateEducatorPreparationProgramAssociation_ChangeVersion')
    CREATE INDEX [UX_CandidateEducatorPreparationProgramAssociation_ChangeVersion] ON [tpdm].[CandidateEducatorPreparationProgramAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CandidateRelationshipToStaffAssociation') AND name = N'UX_CandidateRelationshipToStaffAssociation_ChangeVersion')
    CREATE INDEX [UX_CandidateRelationshipToStaffAssociation_ChangeVersion] ON [tpdm].[CandidateRelationshipToStaffAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Certification') AND name = N'UX_Certification_ChangeVersion')
    CREATE INDEX [UX_Certification_ChangeVersion] ON [tpdm].[Certification] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CertificationExam') AND name = N'UX_CertificationExam_ChangeVersion')
    CREATE INDEX [UX_CertificationExam_ChangeVersion] ON [tpdm].[CertificationExam] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CertificationExamResult') AND name = N'UX_CertificationExamResult_ChangeVersion')
    CREATE INDEX [UX_CertificationExamResult_ChangeVersion] ON [tpdm].[CertificationExamResult] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CredentialEvent') AND name = N'UX_CredentialEvent_ChangeVersion')
    CREATE INDEX [UX_CredentialEvent_ChangeVersion] ON [tpdm].[CredentialEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EducatorPreparationProgram') AND name = N'UX_EducatorPreparationProgram_ChangeVersion')
    CREATE INDEX [UX_EducatorPreparationProgram_ChangeVersion] ON [tpdm].[EducatorPreparationProgram] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Evaluation') AND name = N'UX_Evaluation_ChangeVersion')
    CREATE INDEX [UX_Evaluation_ChangeVersion] ON [tpdm].[Evaluation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationElement') AND name = N'UX_EvaluationElement_ChangeVersion')
    CREATE INDEX [UX_EvaluationElement_ChangeVersion] ON [tpdm].[EvaluationElement] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationElementRating') AND name = N'UX_EvaluationElementRating_ChangeVersion')
    CREATE INDEX [UX_EvaluationElementRating_ChangeVersion] ON [tpdm].[EvaluationElementRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationObjective') AND name = N'UX_EvaluationObjective_ChangeVersion')
    CREATE INDEX [UX_EvaluationObjective_ChangeVersion] ON [tpdm].[EvaluationObjective] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationObjectiveRating') AND name = N'UX_EvaluationObjectiveRating_ChangeVersion')
    CREATE INDEX [UX_EvaluationObjectiveRating_ChangeVersion] ON [tpdm].[EvaluationObjectiveRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationRating') AND name = N'UX_EvaluationRating_ChangeVersion')
    CREATE INDEX [UX_EvaluationRating_ChangeVersion] ON [tpdm].[EvaluationRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FieldworkExperience') AND name = N'UX_FieldworkExperience_ChangeVersion')
    CREATE INDEX [UX_FieldworkExperience_ChangeVersion] ON [tpdm].[FieldworkExperience] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FieldworkExperienceSectionAssociation') AND name = N'UX_FieldworkExperienceSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_FieldworkExperienceSectionAssociation_ChangeVersion] ON [tpdm].[FieldworkExperienceSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Goal') AND name = N'UX_Goal_ChangeVersion')
    CREATE INDEX [UX_Goal_ChangeVersion] ON [tpdm].[Goal] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.OpenStaffPositionEvent') AND name = N'UX_OpenStaffPositionEvent_ChangeVersion')
    CREATE INDEX [UX_OpenStaffPositionEvent_ChangeVersion] ON [tpdm].[OpenStaffPositionEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.PerformanceEvaluation') AND name = N'UX_PerformanceEvaluation_ChangeVersion')
    CREATE INDEX [UX_PerformanceEvaluation_ChangeVersion] ON [tpdm].[PerformanceEvaluation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.PerformanceEvaluationRating') AND name = N'UX_PerformanceEvaluationRating_ChangeVersion')
    CREATE INDEX [UX_PerformanceEvaluationRating_ChangeVersion] ON [tpdm].[PerformanceEvaluationRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ProfessionalDevelopmentEvent') AND name = N'UX_ProfessionalDevelopmentEvent_ChangeVersion')
    CREATE INDEX [UX_ProfessionalDevelopmentEvent_ChangeVersion] ON [tpdm].[ProfessionalDevelopmentEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ProfessionalDevelopmentEventAttendance') AND name = N'UX_ProfessionalDevelopmentEventAttendance_ChangeVersion')
    CREATE INDEX [UX_ProfessionalDevelopmentEventAttendance_ChangeVersion] ON [tpdm].[ProfessionalDevelopmentEventAttendance] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.QuantitativeMeasure') AND name = N'UX_QuantitativeMeasure_ChangeVersion')
    CREATE INDEX [UX_QuantitativeMeasure_ChangeVersion] ON [tpdm].[QuantitativeMeasure] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.QuantitativeMeasureScore') AND name = N'UX_QuantitativeMeasureScore_ChangeVersion')
    CREATE INDEX [UX_QuantitativeMeasureScore_ChangeVersion] ON [tpdm].[QuantitativeMeasureScore] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RecruitmentEvent') AND name = N'UX_RecruitmentEvent_ChangeVersion')
    CREATE INDEX [UX_RecruitmentEvent_ChangeVersion] ON [tpdm].[RecruitmentEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RecruitmentEventAttendance') AND name = N'UX_RecruitmentEventAttendance_ChangeVersion')
    CREATE INDEX [UX_RecruitmentEventAttendance_ChangeVersion] ON [tpdm].[RecruitmentEventAttendance] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RubricDimension') AND name = N'UX_RubricDimension_ChangeVersion')
    CREATE INDEX [UX_RubricDimension_ChangeVersion] ON [tpdm].[RubricDimension] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffEducatorPreparationProgramAssociation') AND name = N'UX_StaffEducatorPreparationProgramAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffEducatorPreparationProgramAssociation_ChangeVersion] ON [tpdm].[StaffEducatorPreparationProgramAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveyResponsePersonTargetAssociation') AND name = N'UX_SurveyResponsePersonTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveyResponsePersonTargetAssociation_ChangeVersion] ON [tpdm].[SurveyResponsePersonTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionAggregateResponse') AND name = N'UX_SurveySectionAggregateResponse_ChangeVersion')
    CREATE INDEX [UX_SurveySectionAggregateResponse_ChangeVersion] ON [tpdm].[SurveySectionAggregateResponse] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionResponsePersonTargetAssociation') AND name = N'UX_SurveySectionResponsePersonTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveySectionResponsePersonTargetAssociation_ChangeVersion] ON [tpdm].[SurveySectionResponsePersonTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

