-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TRIGGER [tpdm].[tpdm_ApplicantProfile_TR_UpdateChangeVersion] ON [tpdm].[ApplicantProfile] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ApplicantProfile]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ApplicantProfile] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Application_TR_UpdateChangeVersion] ON [tpdm].[Application] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Application]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Application] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_ApplicationEvent_TR_UpdateChangeVersion] ON [tpdm].[ApplicationEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ApplicationEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ApplicationEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Candidate_TR_UpdateChangeVersion] ON [tpdm].[Candidate] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Candidate]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Candidate] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CandidateEducatorPreparationProgramAssociation_TR_UpdateChangeVersion] ON [tpdm].[CandidateEducatorPreparationProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CandidateEducatorPreparationProgramAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CandidateEducatorPreparationProgramAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CandidateRelationshipToStaffAssociation_TR_UpdateChangeVersion] ON [tpdm].[CandidateRelationshipToStaffAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CandidateRelationshipToStaffAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CandidateRelationshipToStaffAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Certification_TR_UpdateChangeVersion] ON [tpdm].[Certification] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Certification]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Certification] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CertificationExam_TR_UpdateChangeVersion] ON [tpdm].[CertificationExam] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CertificationExam]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CertificationExam] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CertificationExamResult_TR_UpdateChangeVersion] ON [tpdm].[CertificationExamResult] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CertificationExamResult]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CertificationExamResult] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CredentialEvent_TR_UpdateChangeVersion] ON [tpdm].[CredentialEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CredentialEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CredentialEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EducatorPreparationProgram_TR_UpdateChangeVersion] ON [tpdm].[EducatorPreparationProgram] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EducatorPreparationProgram]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EducatorPreparationProgram] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Evaluation_TR_UpdateChangeVersion] ON [tpdm].[Evaluation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Evaluation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Evaluation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationElement_TR_UpdateChangeVersion] ON [tpdm].[EvaluationElement] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationElement]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationElement] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationElementRating_TR_UpdateChangeVersion] ON [tpdm].[EvaluationElementRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationElementRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationElementRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationObjective_TR_UpdateChangeVersion] ON [tpdm].[EvaluationObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationObjective]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationObjective] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationObjectiveRating_TR_UpdateChangeVersion] ON [tpdm].[EvaluationObjectiveRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationObjectiveRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationObjectiveRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationRating_TR_UpdateChangeVersion] ON [tpdm].[EvaluationRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_FieldworkExperience_TR_UpdateChangeVersion] ON [tpdm].[FieldworkExperience] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[FieldworkExperience]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[FieldworkExperience] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_FieldworkExperienceSectionAssociation_TR_UpdateChangeVersion] ON [tpdm].[FieldworkExperienceSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[FieldworkExperienceSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[FieldworkExperienceSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Goal_TR_UpdateChangeVersion] ON [tpdm].[Goal] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Goal]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Goal] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_OpenStaffPositionEvent_TR_UpdateChangeVersion] ON [tpdm].[OpenStaffPositionEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[OpenStaffPositionEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[OpenStaffPositionEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluation_TR_UpdateChangeVersion] ON [tpdm].[PerformanceEvaluation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[PerformanceEvaluation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[PerformanceEvaluation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationRating_TR_UpdateChangeVersion] ON [tpdm].[PerformanceEvaluationRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[PerformanceEvaluationRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[PerformanceEvaluationRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_ProfessionalDevelopmentEvent_TR_UpdateChangeVersion] ON [tpdm].[ProfessionalDevelopmentEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ProfessionalDevelopmentEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ProfessionalDevelopmentEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_ProfessionalDevelopmentEventAttendance_TR_UpdateChangeVersion] ON [tpdm].[ProfessionalDevelopmentEventAttendance] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ProfessionalDevelopmentEventAttendance]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ProfessionalDevelopmentEventAttendance] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasure_TR_UpdateChangeVersion] ON [tpdm].[QuantitativeMeasure] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[QuantitativeMeasure]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[QuantitativeMeasure] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasureScore_TR_UpdateChangeVersion] ON [tpdm].[QuantitativeMeasureScore] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[QuantitativeMeasureScore]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[QuantitativeMeasureScore] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_RecruitmentEvent_TR_UpdateChangeVersion] ON [tpdm].[RecruitmentEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[RecruitmentEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[RecruitmentEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_RecruitmentEventAttendance_TR_UpdateChangeVersion] ON [tpdm].[RecruitmentEventAttendance] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[RecruitmentEventAttendance]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[RecruitmentEventAttendance] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_RubricDimension_TR_UpdateChangeVersion] ON [tpdm].[RubricDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[RubricDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[RubricDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffEducatorPreparationProgramAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffEducatorPreparationProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffEducatorPreparationProgramAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffEducatorPreparationProgramAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_SurveyResponsePersonTargetAssociation_TR_UpdateChangeVersion] ON [tpdm].[SurveyResponsePersonTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[SurveyResponsePersonTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[SurveyResponsePersonTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_SurveySectionAggregateResponse_TR_UpdateChangeVersion] ON [tpdm].[SurveySectionAggregateResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[SurveySectionAggregateResponse]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[SurveySectionAggregateResponse] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_SurveySectionResponsePersonTargetAssociation_TR_UpdateChangeVersion] ON [tpdm].[SurveySectionResponsePersonTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[SurveySectionResponsePersonTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[SurveySectionResponsePersonTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

