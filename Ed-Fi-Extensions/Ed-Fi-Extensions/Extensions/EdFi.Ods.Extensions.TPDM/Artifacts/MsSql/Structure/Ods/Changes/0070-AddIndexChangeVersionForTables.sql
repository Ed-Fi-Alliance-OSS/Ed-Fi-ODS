-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudent') AND name = N'UX_AnonymizedStudent_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudent_ChangeVersion] ON [tpdm].[AnonymizedStudent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentAcademicRecord') AND name = N'UX_AnonymizedStudentAcademicRecord_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentAcademicRecord_ChangeVersion] ON [tpdm].[AnonymizedStudentAcademicRecord] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentAssessment') AND name = N'UX_AnonymizedStudentAssessment_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentAssessment_ChangeVersion] ON [tpdm].[AnonymizedStudentAssessment] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentAssessmentCourseAssociation') AND name = N'UX_AnonymizedStudentAssessmentCourseAssociation_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentAssessmentCourseAssociation_ChangeVersion] ON [tpdm].[AnonymizedStudentAssessmentCourseAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentAssessmentSectionAssociation') AND name = N'UX_AnonymizedStudentAssessmentSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentAssessmentSectionAssociation_ChangeVersion] ON [tpdm].[AnonymizedStudentAssessmentSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentCourseAssociation') AND name = N'UX_AnonymizedStudentCourseAssociation_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentCourseAssociation_ChangeVersion] ON [tpdm].[AnonymizedStudentCourseAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentCourseTranscript') AND name = N'UX_AnonymizedStudentCourseTranscript_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentCourseTranscript_ChangeVersion] ON [tpdm].[AnonymizedStudentCourseTranscript] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentEducationOrganizationAssociation') AND name = N'UX_AnonymizedStudentEducationOrganizationAssociation_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentEducationOrganizationAssociation_ChangeVersion] ON [tpdm].[AnonymizedStudentEducationOrganizationAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.AnonymizedStudentSectionAssociation') AND name = N'UX_AnonymizedStudentSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_AnonymizedStudentSectionAssociation_ChangeVersion] ON [tpdm].[AnonymizedStudentSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Applicant') AND name = N'UX_Applicant_ChangeVersion')
    CREATE INDEX [UX_Applicant_ChangeVersion] ON [tpdm].[Applicant] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ApplicantProspectAssociation') AND name = N'UX_ApplicantProspectAssociation_ChangeVersion')
    CREATE INDEX [UX_ApplicantProspectAssociation_ChangeVersion] ON [tpdm].[ApplicantProspectAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Application') AND name = N'UX_Application_ChangeVersion')
    CREATE INDEX [UX_Application_ChangeVersion] ON [tpdm].[Application] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ApplicationEvent') AND name = N'UX_ApplicationEvent_ChangeVersion')
    CREATE INDEX [UX_ApplicationEvent_ChangeVersion] ON [tpdm].[ApplicationEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Certification') AND name = N'UX_Certification_ChangeVersion')
    CREATE INDEX [UX_Certification_ChangeVersion] ON [tpdm].[Certification] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CertificationExam') AND name = N'UX_CertificationExam_ChangeVersion')
    CREATE INDEX [UX_CertificationExam_ChangeVersion] ON [tpdm].[CertificationExam] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CertificationExamResult') AND name = N'UX_CertificationExamResult_ChangeVersion')
    CREATE INDEX [UX_CertificationExamResult_ChangeVersion] ON [tpdm].[CertificationExamResult] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CompleterAsStaffAssociation') AND name = N'UX_CompleterAsStaffAssociation_ChangeVersion')
    CREATE INDEX [UX_CompleterAsStaffAssociation_ChangeVersion] ON [tpdm].[CompleterAsStaffAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.CredentialEvent') AND name = N'UX_CredentialEvent_ChangeVersion')
    CREATE INDEX [UX_CredentialEvent_ChangeVersion] ON [tpdm].[CredentialEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EmploymentEvent') AND name = N'UX_EmploymentEvent_ChangeVersion')
    CREATE INDEX [UX_EmploymentEvent_ChangeVersion] ON [tpdm].[EmploymentEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EmploymentSeparationEvent') AND name = N'UX_EmploymentSeparationEvent_ChangeVersion')
    CREATE INDEX [UX_EmploymentSeparationEvent_ChangeVersion] ON [tpdm].[EmploymentSeparationEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Evaluation') AND name = N'UX_Evaluation_ChangeVersion')
    CREATE INDEX [UX_Evaluation_ChangeVersion] ON [tpdm].[Evaluation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationElement') AND name = N'UX_EvaluationElement_ChangeVersion')
    CREATE INDEX [UX_EvaluationElement_ChangeVersion] ON [tpdm].[EvaluationElement] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationElementRating') AND name = N'UX_EvaluationElementRating_ChangeVersion')
    CREATE INDEX [UX_EvaluationElementRating_ChangeVersion] ON [tpdm].[EvaluationElementRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationObjective') AND name = N'UX_EvaluationObjective_ChangeVersion')
    CREATE INDEX [UX_EvaluationObjective_ChangeVersion] ON [tpdm].[EvaluationObjective] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationObjectiveRating') AND name = N'UX_EvaluationObjectiveRating_ChangeVersion')
    CREATE INDEX [UX_EvaluationObjectiveRating_ChangeVersion] ON [tpdm].[EvaluationObjectiveRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.EvaluationRating') AND name = N'UX_EvaluationRating_ChangeVersion')
    CREATE INDEX [UX_EvaluationRating_ChangeVersion] ON [tpdm].[EvaluationRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FieldworkExperience') AND name = N'UX_FieldworkExperience_ChangeVersion')
    CREATE INDEX [UX_FieldworkExperience_ChangeVersion] ON [tpdm].[FieldworkExperience] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.FieldworkExperienceSectionAssociation') AND name = N'UX_FieldworkExperienceSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_FieldworkExperienceSectionAssociation_ChangeVersion] ON [tpdm].[FieldworkExperienceSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Goal') AND name = N'UX_Goal_ChangeVersion')
    CREATE INDEX [UX_Goal_ChangeVersion] ON [tpdm].[Goal] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.OpenStaffPositionEvent') AND name = N'UX_OpenStaffPositionEvent_ChangeVersion')
    CREATE INDEX [UX_OpenStaffPositionEvent_ChangeVersion] ON [tpdm].[OpenStaffPositionEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.PerformanceEvaluation') AND name = N'UX_PerformanceEvaluation_ChangeVersion')
    CREATE INDEX [UX_PerformanceEvaluation_ChangeVersion] ON [tpdm].[PerformanceEvaluation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.PerformanceEvaluationRating') AND name = N'UX_PerformanceEvaluationRating_ChangeVersion')
    CREATE INDEX [UX_PerformanceEvaluationRating_ChangeVersion] ON [tpdm].[PerformanceEvaluationRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ProfessionalDevelopmentEvent') AND name = N'UX_ProfessionalDevelopmentEvent_ChangeVersion')
    CREATE INDEX [UX_ProfessionalDevelopmentEvent_ChangeVersion] ON [tpdm].[ProfessionalDevelopmentEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.ProfessionalDevelopmentEventAttendance') AND name = N'UX_ProfessionalDevelopmentEventAttendance_ChangeVersion')
    CREATE INDEX [UX_ProfessionalDevelopmentEventAttendance_ChangeVersion] ON [tpdm].[ProfessionalDevelopmentEventAttendance] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.Prospect') AND name = N'UX_Prospect_ChangeVersion')
    CREATE INDEX [UX_Prospect_ChangeVersion] ON [tpdm].[Prospect] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.QuantitativeMeasure') AND name = N'UX_QuantitativeMeasure_ChangeVersion')
    CREATE INDEX [UX_QuantitativeMeasure_ChangeVersion] ON [tpdm].[QuantitativeMeasure] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.QuantitativeMeasureScore') AND name = N'UX_QuantitativeMeasureScore_ChangeVersion')
    CREATE INDEX [UX_QuantitativeMeasureScore_ChangeVersion] ON [tpdm].[QuantitativeMeasureScore] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RecruitmentEvent') AND name = N'UX_RecruitmentEvent_ChangeVersion')
    CREATE INDEX [UX_RecruitmentEvent_ChangeVersion] ON [tpdm].[RecruitmentEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.RubricDimension') AND name = N'UX_RubricDimension_ChangeVersion')
    CREATE INDEX [UX_RubricDimension_ChangeVersion] ON [tpdm].[RubricDimension] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffApplicantAssociation') AND name = N'UX_StaffApplicantAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffApplicantAssociation_ChangeVersion] ON [tpdm].[StaffApplicantAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffProspectAssociation') AND name = N'UX_StaffProspectAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffProspectAssociation_ChangeVersion] ON [tpdm].[StaffProspectAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffStudentGrowthMeasure') AND name = N'UX_StaffStudentGrowthMeasure_ChangeVersion')
    CREATE INDEX [UX_StaffStudentGrowthMeasure_ChangeVersion] ON [tpdm].[StaffStudentGrowthMeasure] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffStudentGrowthMeasureCourseAssociation') AND name = N'UX_StaffStudentGrowthMeasureCourseAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffStudentGrowthMeasureCourseAssociation_ChangeVersion] ON [tpdm].[StaffStudentGrowthMeasureCourseAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation') AND name = N'UX_StaffStudentGrowthMeasureEducationOrganizationAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffStudentGrowthMeasureEducationOrganizationAssociation_ChangeVersion] ON [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffStudentGrowthMeasureSectionAssociation') AND name = N'UX_StaffStudentGrowthMeasureSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffStudentGrowthMeasureSectionAssociation_ChangeVersion] ON [tpdm].[StaffStudentGrowthMeasureSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffTeacherPreparationProviderAssociation') AND name = N'UX_StaffTeacherPreparationProviderAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffTeacherPreparationProviderAssociation_ChangeVersion] ON [tpdm].[StaffTeacherPreparationProviderAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.StaffTeacherPreparationProviderProgramAssociation') AND name = N'UX_StaffTeacherPreparationProviderProgramAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffTeacherPreparationProviderProgramAssociation_ChangeVersion] ON [tpdm].[StaffTeacherPreparationProviderProgramAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveyResponseTeacherCandidateTargetAssociation') AND name = N'UX_SurveyResponseTeacherCandidateTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveyResponseTeacherCandidateTargetAssociation_ChangeVersion] ON [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionAggregateResponse') AND name = N'UX_SurveySectionAggregateResponse_ChangeVersion')
    CREATE INDEX [UX_SurveySectionAggregateResponse_ChangeVersion] ON [tpdm].[SurveySectionAggregateResponse] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.SurveySectionResponseTeacherCandidateTargetAssociation') AND name = N'UX_SurveySectionResponseTeacherCandidateTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveySectionResponseTeacherCandidateTargetAssociation_ChangeVersion] ON [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidate') AND name = N'UX_TeacherCandidate_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidate_ChangeVersion] ON [tpdm].[TeacherCandidate] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateAcademicRecord') AND name = N'UX_TeacherCandidateAcademicRecord_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateAcademicRecord_ChangeVersion] ON [tpdm].[TeacherCandidateAcademicRecord] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateCourseTranscript') AND name = N'UX_TeacherCandidateCourseTranscript_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateCourseTranscript_ChangeVersion] ON [tpdm].[TeacherCandidateCourseTranscript] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateStaffAssociation') AND name = N'UX_TeacherCandidateStaffAssociation_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateStaffAssociation_ChangeVersion] ON [tpdm].[TeacherCandidateStaffAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateStudentGrowthMeasure') AND name = N'UX_TeacherCandidateStudentGrowthMeasure_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateStudentGrowthMeasure_ChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasure] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation') AND name = N'UX_TeacherCandidateStudentGrowthMeasureCourseAssociation_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateStudentGrowthMeasureCourseAssociation_ChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation') AND name = N'UX_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_ChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation') AND name = N'UX_TeacherCandidateStudentGrowthMeasureSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateStudentGrowthMeasureSectionAssociation_ChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateTeacherPreparationProviderAssociation') AND name = N'UX_TeacherCandidateTeacherPreparationProviderAssociation_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateTeacherPreparationProviderAssociation_ChangeVersion] ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation') AND name = N'UX_TeacherCandidateTeacherPreparationProviderProgramAssociation_ChangeVersion')
    CREATE INDEX [UX_TeacherCandidateTeacherPreparationProviderProgramAssociation_ChangeVersion] ON [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'tpdm.TeacherPreparationProviderProgram') AND name = N'UX_TeacherPreparationProviderProgram_ChangeVersion')
    CREATE INDEX [UX_TeacherPreparationProviderProgram_ChangeVersion] ON [tpdm].[TeacherPreparationProviderProgram] ([ChangeVersion] ASC)
    GO
COMMIT

