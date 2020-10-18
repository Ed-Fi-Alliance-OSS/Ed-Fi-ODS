-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE UNIQUE INDEX IF NOT EXISTS UX_91a31b_Id ON tpdm.AnonymizedStudent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a5aeb2_Id ON tpdm.AnonymizedStudentAcademicRecord(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e4eb73_Id ON tpdm.AnonymizedStudentAssessment(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e6ba6c_Id ON tpdm.AnonymizedStudentAssessmentCourseAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_64d5d3_Id ON tpdm.AnonymizedStudentAssessmentSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2abb16_Id ON tpdm.AnonymizedStudentCourseAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_d194a8_Id ON tpdm.AnonymizedStudentCourseTranscript(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_7f59f4_Id ON tpdm.AnonymizedStudentEducationOrganizationAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_562e9d_Id ON tpdm.AnonymizedStudentSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_0a1ce1_Id ON tpdm.Applicant(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_57cdba_Id ON tpdm.ApplicantProspectAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e7ad52_Id ON tpdm.Application(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_143de6_Id ON tpdm.ApplicationEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_86846f_Id ON tpdm.Certification(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_cb139c_Id ON tpdm.CertificationExam(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_aed83e_Id ON tpdm.CertificationExamResult(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_447e8f_Id ON tpdm.CompleterAsStaffAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_3d6d96_Id ON tpdm.CredentialEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_786774_Id ON tpdm.EmploymentEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f51cef_Id ON tpdm.EmploymentSeparationEvent(Id);

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

CREATE UNIQUE INDEX IF NOT EXISTS UX_f84f61_Id ON tpdm.Prospect(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8b89fe_Id ON tpdm.QuantitativeMeasure(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e61067_Id ON tpdm.QuantitativeMeasureScore(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6232e8_Id ON tpdm.RecruitmentEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_643c81_Id ON tpdm.RubricDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_11e466_Id ON tpdm.StaffApplicantAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_990b71_Id ON tpdm.StaffProspectAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_609983_Id ON tpdm.StaffStudentGrowthMeasure(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f22014_Id ON tpdm.StaffStudentGrowthMeasureCourseAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_120788_Id ON tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fbfeb4_Id ON tpdm.StaffStudentGrowthMeasureSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_7bf40b_Id ON tpdm.StaffTeacherPreparationProviderAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_5bac62_Id ON tpdm.StaffTeacherPreparationProviderProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_049bd0_Id ON tpdm.SurveyResponseTeacherCandidateTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f37ae9_Id ON tpdm.SurveySectionAggregateResponse(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_948dd8_Id ON tpdm.SurveySectionResponseTeacherCandidateTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_835b49_Id ON tpdm.TeacherCandidate(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_163dde_Id ON tpdm.TeacherCandidateAcademicRecord(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_87fd83_Id ON tpdm.TeacherCandidateCourseTranscript(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_3395e5_Id ON tpdm.TeacherCandidateStaffAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_464a58_Id ON tpdm.TeacherCandidateStudentGrowthMeasure(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_512fab_Id ON tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_22b9a4_Id ON tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b8b1b0_Id ON tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_0dff08_Id ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_81475b_Id ON tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_aceeb9_Id ON tpdm.TeacherPreparationProviderProgram(Id);

