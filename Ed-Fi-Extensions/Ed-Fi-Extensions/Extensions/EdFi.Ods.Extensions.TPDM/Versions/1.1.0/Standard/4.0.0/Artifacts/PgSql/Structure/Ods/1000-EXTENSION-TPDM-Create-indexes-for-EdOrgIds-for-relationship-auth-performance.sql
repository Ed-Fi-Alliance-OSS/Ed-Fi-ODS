-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS IX_daf78c_EducationOrganizationId ON tpdm.CandidateEducatorPreparationProgramAssociation(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_edd2a6_EducationOrganizationId ON tpdm.EducatorPreparationProgram(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_5cd1ce_EducationOrganizationId ON tpdm.Evaluation(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_abfec9_EducationOrganizationId ON tpdm.EvaluationElement(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_dd8fc5_EducationOrganizationId ON tpdm.EvaluationElementRating(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_4945b9_EducationOrganizationId ON tpdm.EvaluationObjective(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_45a18e_EducationOrganizationId ON tpdm.EvaluationObjectiveRating(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_5ae528_EducationOrganizationId ON tpdm.EvaluationRating(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_5ae528_SchoolId ON tpdm.EvaluationRating(SchoolId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_4d3d3e_EducationOrganizationId ON tpdm.PerformanceEvaluation(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_ea3e25_EducationOrganizationId ON tpdm.PerformanceEvaluationRating(EducationOrganizationId) INCLUDE (Id);
CREATE INDEX IF NOT EXISTS IX_9b6225_EducationOrganizationId ON tpdm.RubricDimension(EducationOrganizationId) INCLUDE (Id);