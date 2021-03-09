-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE UNIQUE INDEX IF NOT EXISTS UX_c322dc_Id ON tpdm.ApplicantProfile(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e7ad52_Id ON tpdm.Application(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_143de6_Id ON tpdm.ApplicationEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b2452d_Id ON tpdm.Candidate(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fc61b2_Id ON tpdm.CandidateEducatorPreparationProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_610f76_Id ON tpdm.CandidateRelationshipToStaffAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_86846f_Id ON tpdm.Certification(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_cb139c_Id ON tpdm.CertificationExam(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_aed83e_Id ON tpdm.CertificationExamResult(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_3d6d96_Id ON tpdm.CredentialEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_195935_Id ON tpdm.EducatorPreparationProgram(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_163e44_Id ON tpdm.Evaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e53186_Id ON tpdm.EvaluationElement(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4479ea_Id ON tpdm.EvaluationElementRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_d4565d_Id ON tpdm.EvaluationObjective(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_7ae19d_Id ON tpdm.EvaluationObjectiveRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_bfaa20_Id ON tpdm.EvaluationRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fd30bb_Id ON tpdm.FieldworkExperience(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b2abcd_Id ON tpdm.FieldworkExperienceSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_cdbf69_Id ON tpdm.Goal(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e809b0_Id ON tpdm.OpenStaffPositionEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_15d685_Id ON tpdm.PerformanceEvaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_759abe_Id ON tpdm.PerformanceEvaluationRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8c4ca1_Id ON tpdm.ProfessionalDevelopmentEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_22e412_Id ON tpdm.ProfessionalDevelopmentEventAttendance(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8b89fe_Id ON tpdm.QuantitativeMeasure(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e61067_Id ON tpdm.QuantitativeMeasureScore(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6232e8_Id ON tpdm.RecruitmentEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fca83b_Id ON tpdm.RecruitmentEventAttendance(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_643c81_Id ON tpdm.RubricDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2c9294_Id ON tpdm.StaffEducatorPreparationProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_520027_Id ON tpdm.SurveyResponsePersonTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f37ae9_Id ON tpdm.SurveySectionAggregateResponse(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e21e4b_Id ON tpdm.SurveySectionResponsePersonTargetAssociation(Id);

