-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS UX_b2452d_ChangeVersion ON tpdm.Candidate(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_fc61b2_ChangeVersion ON tpdm.CandidateEducatorPreparationProgramAssociation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_195935_ChangeVersion ON tpdm.EducatorPreparationProgram(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_163e44_ChangeVersion ON tpdm.Evaluation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_e53186_ChangeVersion ON tpdm.EvaluationElement(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_4479ea_ChangeVersion ON tpdm.EvaluationElementRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_d4565d_ChangeVersion ON tpdm.EvaluationObjective(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_7ae19d_ChangeVersion ON tpdm.EvaluationObjectiveRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_bfaa20_ChangeVersion ON tpdm.EvaluationRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_a465f2_ChangeVersion ON tpdm.FinancialAid(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_15d685_ChangeVersion ON tpdm.PerformanceEvaluation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_759abe_ChangeVersion ON tpdm.PerformanceEvaluationRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_643c81_ChangeVersion ON tpdm.RubricDimension(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_520027_ChangeVersion ON tpdm.SurveyResponsePersonTargetAssociation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_e21e4b_ChangeVersion ON tpdm.SurveySectionResponsePersonTargetAssociation(ChangeVersion);

