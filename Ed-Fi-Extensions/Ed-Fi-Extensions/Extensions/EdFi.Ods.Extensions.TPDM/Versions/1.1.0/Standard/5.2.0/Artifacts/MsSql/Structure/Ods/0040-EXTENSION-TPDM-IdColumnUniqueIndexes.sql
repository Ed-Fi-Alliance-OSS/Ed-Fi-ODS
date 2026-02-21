-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

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
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FinancialAid') AND name = N'UX_FinancialAid_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_FinancialAid_Id ON [tpdm].[FinancialAid]
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
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RubricDimension') AND name = N'UX_RubricDimension_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_RubricDimension_Id ON [tpdm].[RubricDimension]
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
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionResponsePersonTargetAssociation') AND name = N'UX_SurveySectionResponsePersonTargetAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SurveySectionResponsePersonTargetAssociation_Id ON [tpdm].[SurveySectionResponsePersonTargetAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

