-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[Candidate]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[Candidate] ADD [ChangeVersion] [BIGINT] CONSTRAINT Candidate_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[Candidate] DROP CONSTRAINT Candidate_DF_ChangeVersion;
ALTER TABLE [tpdm].[Candidate] ADD CONSTRAINT Candidate_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[CandidateEducatorPreparationProgramAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT CandidateEducatorPreparationProgramAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] DROP CONSTRAINT CandidateEducatorPreparationProgramAssociation_DF_ChangeVersion;
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD CONSTRAINT CandidateEducatorPreparationProgramAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EducatorPreparationProgram]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD [ChangeVersion] [BIGINT] CONSTRAINT EducatorPreparationProgram_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[EducatorPreparationProgram] DROP CONSTRAINT EducatorPreparationProgram_DF_ChangeVersion;
ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD CONSTRAINT EducatorPreparationProgram_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[Evaluation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[Evaluation] ADD [ChangeVersion] [BIGINT] CONSTRAINT Evaluation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[Evaluation] DROP CONSTRAINT Evaluation_DF_ChangeVersion;
ALTER TABLE [tpdm].[Evaluation] ADD CONSTRAINT Evaluation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationElement]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[EvaluationElement] ADD [ChangeVersion] [BIGINT] CONSTRAINT EvaluationElement_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[EvaluationElement] DROP CONSTRAINT EvaluationElement_DF_ChangeVersion;
ALTER TABLE [tpdm].[EvaluationElement] ADD CONSTRAINT EvaluationElement_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationElementRating]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[EvaluationElementRating] ADD [ChangeVersion] [BIGINT] CONSTRAINT EvaluationElementRating_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[EvaluationElementRating] DROP CONSTRAINT EvaluationElementRating_DF_ChangeVersion;
ALTER TABLE [tpdm].[EvaluationElementRating] ADD CONSTRAINT EvaluationElementRating_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationObjective]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[EvaluationObjective] ADD [ChangeVersion] [BIGINT] CONSTRAINT EvaluationObjective_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[EvaluationObjective] DROP CONSTRAINT EvaluationObjective_DF_ChangeVersion;
ALTER TABLE [tpdm].[EvaluationObjective] ADD CONSTRAINT EvaluationObjective_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationObjectiveRating]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD [ChangeVersion] [BIGINT] CONSTRAINT EvaluationObjectiveRating_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[EvaluationObjectiveRating] DROP CONSTRAINT EvaluationObjectiveRating_DF_ChangeVersion;
ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD CONSTRAINT EvaluationObjectiveRating_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[EvaluationRating]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[EvaluationRating] ADD [ChangeVersion] [BIGINT] CONSTRAINT EvaluationRating_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[EvaluationRating] DROP CONSTRAINT EvaluationRating_DF_ChangeVersion;
ALTER TABLE [tpdm].[EvaluationRating] ADD CONSTRAINT EvaluationRating_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[FinancialAid]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[FinancialAid] ADD [ChangeVersion] [BIGINT] CONSTRAINT FinancialAid_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[FinancialAid] DROP CONSTRAINT FinancialAid_DF_ChangeVersion;
ALTER TABLE [tpdm].[FinancialAid] ADD CONSTRAINT FinancialAid_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[PerformanceEvaluation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[PerformanceEvaluation] ADD [ChangeVersion] [BIGINT] CONSTRAINT PerformanceEvaluation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[PerformanceEvaluation] DROP CONSTRAINT PerformanceEvaluation_DF_ChangeVersion;
ALTER TABLE [tpdm].[PerformanceEvaluation] ADD CONSTRAINT PerformanceEvaluation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[PerformanceEvaluationRating]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD [ChangeVersion] [BIGINT] CONSTRAINT PerformanceEvaluationRating_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[PerformanceEvaluationRating] DROP CONSTRAINT PerformanceEvaluationRating_DF_ChangeVersion;
ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD CONSTRAINT PerformanceEvaluationRating_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[RubricDimension]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[RubricDimension] ADD [ChangeVersion] [BIGINT] CONSTRAINT RubricDimension_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[RubricDimension] DROP CONSTRAINT RubricDimension_DF_ChangeVersion;
ALTER TABLE [tpdm].[RubricDimension] ADD CONSTRAINT RubricDimension_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[SurveyResponsePersonTargetAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveyResponsePersonTargetAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] DROP CONSTRAINT SurveyResponsePersonTargetAssociation_DF_ChangeVersion;
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD CONSTRAINT SurveyResponsePersonTargetAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[tpdm].[SurveySectionResponsePersonTargetAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT SurveySectionResponsePersonTargetAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] DROP CONSTRAINT SurveySectionResponsePersonTargetAssociation_DF_ChangeVersion;
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD CONSTRAINT SurveySectionResponsePersonTargetAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


