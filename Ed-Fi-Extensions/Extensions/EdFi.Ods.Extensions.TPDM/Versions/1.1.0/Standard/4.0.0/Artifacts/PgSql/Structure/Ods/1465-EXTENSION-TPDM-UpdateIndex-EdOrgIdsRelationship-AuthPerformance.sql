-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


DROP INDEX IF EXISTS IX_CandidateEducatorPreparationProgramAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_CandidateEducatorPreparationProgramAssociation_EducationOrganizationId ON tpdm.CandidateEducatorPreparationProgramAssociation(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EducatorPreparationProgram_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EducatorPreparationProgram_EducationOrganizationId ON tpdm.EducatorPreparationProgram(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Evaluation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_Evaluation_EducationOrganizationId ON tpdm.Evaluation(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EvaluationElement_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EvaluationElement_EducationOrganizationId ON tpdm.EvaluationElement(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EvaluationElementRating_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EvaluationElementRating_EducationOrganizationId ON tpdm.EvaluationElementRating(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EvaluationObjective_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EvaluationObjective_EducationOrganizationId ON tpdm.EvaluationObjective(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EvaluationObjectiveRating_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EvaluationObjectiveRating_EducationOrganizationId ON tpdm.EvaluationObjectiveRating(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EvaluationRating_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EvaluationRating_EducationOrganizationId ON tpdm.EvaluationRating(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EvaluationRating_SchoolId;
CREATE INDEX IF NOT EXISTS IX_EvaluationRating_SchoolId ON tpdm.EvaluationRating(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_FinancialAid_StudentUSI ON tpdm.FinancialAid(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_PerformanceEvaluation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_PerformanceEvaluation_EducationOrganizationId ON tpdm.PerformanceEvaluation(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_PerformanceEvaluationRating_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_PerformanceEvaluationRating_EducationOrganizationId ON tpdm.PerformanceEvaluationRating(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_RubricDimension_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_RubricDimension_EducationOrganizationId ON tpdm.RubricDimension(EducationOrganizationId) INCLUDE (AggregateId);
