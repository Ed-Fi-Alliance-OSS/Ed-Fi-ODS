-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE UNIQUE INDEX IF NOT EXISTS UX_b2452d_Id ON tpdm.Candidate(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fc61b2_Id ON tpdm.CandidateEducatorPreparationProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_195935_Id ON tpdm.EducatorPreparationProgram(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_163e44_Id ON tpdm.Evaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e53186_Id ON tpdm.EvaluationElement(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4479ea_Id ON tpdm.EvaluationElementRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_d4565d_Id ON tpdm.EvaluationObjective(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_7ae19d_Id ON tpdm.EvaluationObjectiveRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_bfaa20_Id ON tpdm.EvaluationRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a465f2_Id ON tpdm.FinancialAid(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_15d685_Id ON tpdm.PerformanceEvaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_759abe_Id ON tpdm.PerformanceEvaluationRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_643c81_Id ON tpdm.RubricDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_520027_Id ON tpdm.SurveyResponsePersonTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e21e4b_Id ON tpdm.SurveySectionResponsePersonTargetAssociation(Id);

