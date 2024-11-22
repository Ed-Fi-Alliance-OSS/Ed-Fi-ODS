-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CandidateEducatorPreparationProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.CandidateEducatorPreparationProgramAssociation')) 
BEGIN
    CREATE INDEX IX_CandidateEducatorPreparationProgramAssociation_EducationOrganizationId ON [tpdm].[CandidateEducatorPreparationProgramAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducatorPreparationProgram_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.EducatorPreparationProgram')) 
BEGIN
    CREATE INDEX IX_EducatorPreparationProgram_EducationOrganizationId ON [tpdm].[EducatorPreparationProgram](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Evaluation_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.Evaluation')) 
BEGIN
    CREATE INDEX IX_Evaluation_EducationOrganizationId ON [tpdm].[Evaluation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationElement_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.EvaluationElement')) 
BEGIN
    CREATE INDEX IX_EvaluationElement_EducationOrganizationId ON [tpdm].[EvaluationElement](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationElementRating_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.EvaluationElementRating')) 
BEGIN
    CREATE INDEX IX_EvaluationElementRating_EducationOrganizationId ON [tpdm].[EvaluationElementRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationObjective_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.EvaluationObjective')) 
BEGIN
    CREATE INDEX IX_EvaluationObjective_EducationOrganizationId ON [tpdm].[EvaluationObjective](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationObjectiveRating_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.EvaluationObjectiveRating')) 
BEGIN
    CREATE INDEX IX_EvaluationObjectiveRating_EducationOrganizationId ON [tpdm].[EvaluationObjectiveRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationRating_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.EvaluationRating')) 
BEGIN
    CREATE INDEX IX_EvaluationRating_EducationOrganizationId ON [tpdm].[EvaluationRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationRating_SchoolId' AND object_id = OBJECT_ID('tpdm.EvaluationRating')) 
BEGIN
    CREATE INDEX IX_EvaluationRating_SchoolId ON [tpdm].[EvaluationRating](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PerformanceEvaluation_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.PerformanceEvaluation')) 
BEGIN
    CREATE INDEX IX_PerformanceEvaluation_EducationOrganizationId ON [tpdm].[PerformanceEvaluation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PerformanceEvaluationRating_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.PerformanceEvaluationRating')) 
BEGIN
    CREATE INDEX IX_PerformanceEvaluationRating_EducationOrganizationId ON [tpdm].[PerformanceEvaluationRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RubricDimension_EducationOrganizationId' AND object_id = OBJECT_ID('tpdm.RubricDimension')) 
BEGIN
    CREATE INDEX IX_RubricDimension_EducationOrganizationId ON [tpdm].[RubricDimension](EducationOrganizationId) INCLUDE (Id)
END;
