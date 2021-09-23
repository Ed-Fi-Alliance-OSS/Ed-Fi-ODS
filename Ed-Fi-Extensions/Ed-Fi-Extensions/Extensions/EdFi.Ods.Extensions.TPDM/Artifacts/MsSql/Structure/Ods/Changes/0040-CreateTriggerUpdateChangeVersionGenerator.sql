-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

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

CREATE TRIGGER [tpdm].[tpdm_FinancialAid_TR_UpdateChangeVersion] ON [tpdm].[FinancialAid] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[FinancialAid]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[FinancialAid] u
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

CREATE TRIGGER [tpdm].[tpdm_RubricDimension_TR_UpdateChangeVersion] ON [tpdm].[RubricDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[RubricDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[RubricDimension] u
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

CREATE TRIGGER [tpdm].[tpdm_SurveySectionResponsePersonTargetAssociation_TR_UpdateChangeVersion] ON [tpdm].[SurveySectionResponsePersonTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[SurveySectionResponsePersonTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[SurveySectionResponsePersonTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

