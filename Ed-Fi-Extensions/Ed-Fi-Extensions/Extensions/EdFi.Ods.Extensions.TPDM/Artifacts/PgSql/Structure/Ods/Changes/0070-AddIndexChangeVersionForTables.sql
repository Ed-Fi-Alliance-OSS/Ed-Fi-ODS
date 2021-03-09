-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS UX_c322dc_ChangeVersion ON tpdm.ApplicantProfile(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_e7ad52_ChangeVersion ON tpdm.Application(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_143de6_ChangeVersion ON tpdm.ApplicationEvent(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_b2452d_ChangeVersion ON tpdm.Candidate(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_fc61b2_ChangeVersion ON tpdm.CandidateEducatorPreparationProgramAssociation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_610f76_ChangeVersion ON tpdm.CandidateRelationshipToStaffAssociation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_86846f_ChangeVersion ON tpdm.Certification(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_cb139c_ChangeVersion ON tpdm.CertificationExam(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_aed83e_ChangeVersion ON tpdm.CertificationExamResult(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_3d6d96_ChangeVersion ON tpdm.CredentialEvent(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_195935_ChangeVersion ON tpdm.EducatorPreparationProgram(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_163e44_ChangeVersion ON tpdm.Evaluation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_e53186_ChangeVersion ON tpdm.EvaluationElement(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_4479ea_ChangeVersion ON tpdm.EvaluationElementRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_d4565d_ChangeVersion ON tpdm.EvaluationObjective(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_7ae19d_ChangeVersion ON tpdm.EvaluationObjectiveRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_bfaa20_ChangeVersion ON tpdm.EvaluationRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_fd30bb_ChangeVersion ON tpdm.FieldworkExperience(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_b2abcd_ChangeVersion ON tpdm.FieldworkExperienceSectionAssociation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_cdbf69_ChangeVersion ON tpdm.Goal(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_e809b0_ChangeVersion ON tpdm.OpenStaffPositionEvent(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_15d685_ChangeVersion ON tpdm.PerformanceEvaluation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_759abe_ChangeVersion ON tpdm.PerformanceEvaluationRating(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_8c4ca1_ChangeVersion ON tpdm.ProfessionalDevelopmentEvent(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_22e412_ChangeVersion ON tpdm.ProfessionalDevelopmentEventAttendance(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_8b89fe_ChangeVersion ON tpdm.QuantitativeMeasure(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_e61067_ChangeVersion ON tpdm.QuantitativeMeasureScore(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_6232e8_ChangeVersion ON tpdm.RecruitmentEvent(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_fca83b_ChangeVersion ON tpdm.RecruitmentEventAttendance(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_643c81_ChangeVersion ON tpdm.RubricDimension(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_2c9294_ChangeVersion ON tpdm.StaffEducatorPreparationProgramAssociation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_520027_ChangeVersion ON tpdm.SurveyResponsePersonTargetAssociation(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_f37ae9_ChangeVersion ON tpdm.SurveySectionAggregateResponse(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_e21e4b_ChangeVersion ON tpdm.SurveySectionResponsePersonTargetAssociation(ChangeVersion);

