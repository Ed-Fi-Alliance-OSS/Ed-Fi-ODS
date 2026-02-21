-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [tpdm].[Candidate] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[Evaluation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationElement] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationElementRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationObjective] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[FinancialAid] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[PerformanceEvaluation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[RubricDimension] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

