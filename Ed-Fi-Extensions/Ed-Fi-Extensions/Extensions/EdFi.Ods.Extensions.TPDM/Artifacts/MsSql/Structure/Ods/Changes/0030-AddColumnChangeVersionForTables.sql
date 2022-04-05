-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[Candidate]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[Candidate] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[CandidateEducatorPreparationProgramAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EducatorPreparationProgram]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[Evaluation]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[Evaluation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationElement]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[EvaluationElement] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationElementRating]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[EvaluationElementRating] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationObjective]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[EvaluationObjective] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationObjectiveRating]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationRating]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[EvaluationRating] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[FinancialAid]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[FinancialAid] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[PerformanceEvaluation]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[PerformanceEvaluation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[PerformanceEvaluationRating]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[RubricDimension]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[RubricDimension] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[SurveyResponsePersonTargetAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[SurveySectionResponsePersonTargetAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

