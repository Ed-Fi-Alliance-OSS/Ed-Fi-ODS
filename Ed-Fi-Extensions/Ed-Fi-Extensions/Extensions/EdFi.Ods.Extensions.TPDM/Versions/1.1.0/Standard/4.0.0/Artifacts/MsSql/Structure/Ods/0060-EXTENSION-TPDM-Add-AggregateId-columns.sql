-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SEQUENCE [tpdm].[Candidate_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[Candidate] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[Candidate_AggSeq];
GO
CREATE INDEX [IX_Candidate_AggregateId] ON [tpdm].[Candidate] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[CandidateEducatorPreparationProgramAssociation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[CandidateEducatorPreparationProgramAssociation_AggSeq];
GO
CREATE INDEX [IX_CandidateEducatorPreparationProgramAssociation_AggregateId] ON [tpdm].[CandidateEducatorPreparationProgramAssociation] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[EducatorPreparationProgram_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[EducatorPreparationProgram_AggSeq];
GO
CREATE INDEX [IX_EducatorPreparationProgram_AggregateId] ON [tpdm].[EducatorPreparationProgram] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[Evaluation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[Evaluation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[Evaluation_AggSeq];
GO
CREATE INDEX [IX_Evaluation_AggregateId] ON [tpdm].[Evaluation] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[EvaluationElement_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[EvaluationElement] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[EvaluationElement_AggSeq];
GO
CREATE INDEX [IX_EvaluationElement_AggregateId] ON [tpdm].[EvaluationElement] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[EvaluationElementRating_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[EvaluationElementRating] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[EvaluationElementRating_AggSeq];
GO
CREATE INDEX [IX_EvaluationElementRating_AggregateId] ON [tpdm].[EvaluationElementRating] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[EvaluationObjective_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[EvaluationObjective] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[EvaluationObjective_AggSeq];
GO
CREATE INDEX [IX_EvaluationObjective_AggregateId] ON [tpdm].[EvaluationObjective] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[EvaluationObjectiveRating_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[EvaluationObjectiveRating_AggSeq];
GO
CREATE INDEX [IX_EvaluationObjectiveRating_AggregateId] ON [tpdm].[EvaluationObjectiveRating] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[EvaluationRating_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[EvaluationRating] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[EvaluationRating_AggSeq];
GO
CREATE INDEX [IX_EvaluationRating_AggregateId] ON [tpdm].[EvaluationRating] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[FinancialAid_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[FinancialAid] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[FinancialAid_AggSeq];
GO
CREATE INDEX [IX_FinancialAid_AggregateId] ON [tpdm].[FinancialAid] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[PerformanceEvaluation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[PerformanceEvaluation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[PerformanceEvaluation_AggSeq];
GO
CREATE INDEX [IX_PerformanceEvaluation_AggregateId] ON [tpdm].[PerformanceEvaluation] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[PerformanceEvaluationRating_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[PerformanceEvaluationRating_AggSeq];
GO
CREATE INDEX [IX_PerformanceEvaluationRating_AggregateId] ON [tpdm].[PerformanceEvaluationRating] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[RubricDimension_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[RubricDimension] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[RubricDimension_AggSeq];
GO
CREATE INDEX [IX_RubricDimension_AggregateId] ON [tpdm].[RubricDimension] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[SurveyResponsePersonTargetAssociation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[SurveyResponsePersonTargetAssociation_AggSeq];
GO
CREATE INDEX [IX_SurveyResponsePersonTargetAssociation_AggregateId] ON [tpdm].[SurveyResponsePersonTargetAssociation] (AggregateId);
GO

CREATE SEQUENCE [tpdm].[SurveySectionResponsePersonTargetAssociation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [tpdm].[SurveySectionResponsePersonTargetAssociation_AggSeq];
GO
CREATE INDEX [IX_SurveySectionResponsePersonTargetAssociation_AggregateId] ON [tpdm].[SurveySectionResponsePersonTargetAssociation] (AggregateId);
GO
