-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

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
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FinancialAid') AND name = N'UX_FinancialAid_ChangeVersion')
    CREATE INDEX [UX_FinancialAid_ChangeVersion] ON [tpdm].[FinancialAid] ([ChangeVersion] ASC)
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
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RubricDimension') AND name = N'UX_RubricDimension_ChangeVersion')
    CREATE INDEX [UX_RubricDimension_ChangeVersion] ON [tpdm].[RubricDimension] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveyResponsePersonTargetAssociation') AND name = N'UX_SurveyResponsePersonTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveyResponsePersonTargetAssociation_ChangeVersion] ON [tpdm].[SurveyResponsePersonTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionResponsePersonTargetAssociation') AND name = N'UX_SurveySectionResponsePersonTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveySectionResponsePersonTargetAssociation_ChangeVersion] ON [tpdm].[SurveySectionResponsePersonTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

