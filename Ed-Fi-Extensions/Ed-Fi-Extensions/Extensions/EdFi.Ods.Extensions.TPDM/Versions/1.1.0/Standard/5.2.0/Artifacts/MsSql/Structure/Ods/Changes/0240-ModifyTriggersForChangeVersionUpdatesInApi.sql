-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [tpdm].[tpdm_Candidate_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_CandidateEducatorPreparationProgramAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_EducatorPreparationProgram_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_Evaluation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationElement_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationElementRating_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationObjective_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationObjectiveRating_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationRating_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationRating_TR_UpdateChangeVersion] ON [tpdm].[EvaluationRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [tpdm].[EvaluationRating]
    SET LastModifiedDate = GETUTCDATE(), ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);
END	
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_FinancialAid_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_PerformanceEvaluation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_PerformanceEvaluationRating_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_RubricDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_SurveyResponsePersonTargetAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [tpdm].[tpdm_SurveySectionResponsePersonTargetAssociation_TR_UpdateChangeVersion]
GO

