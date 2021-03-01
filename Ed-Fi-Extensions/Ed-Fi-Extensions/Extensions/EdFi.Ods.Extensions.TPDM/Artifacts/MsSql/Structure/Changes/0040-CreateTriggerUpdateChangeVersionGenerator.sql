CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudent_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentAcademicRecord_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentAcademicRecord] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentAcademicRecord]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentAcademicRecord] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentAssessment_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentAssessment] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentAssessment]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentAssessment] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentAssessmentCourseAssociation_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentAssessmentCourseAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentAssessmentCourseAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentAssessmentCourseAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentAssessmentSectionAssociation_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentAssessmentSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentAssessmentSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentAssessmentSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentCourseAssociation_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentCourseAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentCourseAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentCourseAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentCourseTranscript_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentCourseTranscript] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentCourseTranscript]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentCourseTranscript] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentEducationOrganizationAssociation_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentEducationOrganizationAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentEducationOrganizationAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentEducationOrganizationAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_AnonymizedStudentSectionAssociation_TR_UpdateChangeVersion] ON [tpdm].[AnonymizedStudentSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[AnonymizedStudentSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[AnonymizedStudentSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Applicant_TR_UpdateChangeVersion] ON [tpdm].[Applicant] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Applicant]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Applicant] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_ApplicantProspectAssociation_TR_UpdateChangeVersion] ON [tpdm].[ApplicantProspectAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ApplicantProspectAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ApplicantProspectAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Application_TR_UpdateChangeVersion] ON [tpdm].[Application] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Application]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Application] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_ApplicationEvent_TR_UpdateChangeVersion] ON [tpdm].[ApplicationEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ApplicationEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ApplicationEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Certification_TR_UpdateChangeVersion] ON [tpdm].[Certification] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Certification]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Certification] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CertificationExam_TR_UpdateChangeVersion] ON [tpdm].[CertificationExam] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CertificationExam]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CertificationExam] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CertificationExamResult_TR_UpdateChangeVersion] ON [tpdm].[CertificationExamResult] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CertificationExamResult]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CertificationExamResult] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CompleterAsStaffAssociation_TR_UpdateChangeVersion] ON [tpdm].[CompleterAsStaffAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CompleterAsStaffAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CompleterAsStaffAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_CredentialEvent_TR_UpdateChangeVersion] ON [tpdm].[CredentialEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[CredentialEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[CredentialEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EmploymentEvent_TR_UpdateChangeVersion] ON [tpdm].[EmploymentEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EmploymentEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EmploymentEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EmploymentSeparationEvent_TR_UpdateChangeVersion] ON [tpdm].[EmploymentSeparationEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EmploymentSeparationEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EmploymentSeparationEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Evaluation_TR_UpdateChangeVersion] ON [tpdm].[Evaluation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Evaluation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Evaluation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationElement_TR_UpdateChangeVersion] ON [tpdm].[EvaluationElement] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationElement]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationElement] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationElementRating_TR_UpdateChangeVersion] ON [tpdm].[EvaluationElementRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationElementRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationElementRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationObjective_TR_UpdateChangeVersion] ON [tpdm].[EvaluationObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationObjective]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationObjective] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationObjectiveRating_TR_UpdateChangeVersion] ON [tpdm].[EvaluationObjectiveRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationObjectiveRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationObjectiveRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationRating_TR_UpdateChangeVersion] ON [tpdm].[EvaluationRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[EvaluationRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[EvaluationRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_FieldworkExperience_TR_UpdateChangeVersion] ON [tpdm].[FieldworkExperience] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[FieldworkExperience]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[FieldworkExperience] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_FieldworkExperienceSectionAssociation_TR_UpdateChangeVersion] ON [tpdm].[FieldworkExperienceSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[FieldworkExperienceSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[FieldworkExperienceSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Goal_TR_UpdateChangeVersion] ON [tpdm].[Goal] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Goal]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Goal] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_OpenStaffPositionEvent_TR_UpdateChangeVersion] ON [tpdm].[OpenStaffPositionEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[OpenStaffPositionEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[OpenStaffPositionEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluation_TR_UpdateChangeVersion] ON [tpdm].[PerformanceEvaluation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[PerformanceEvaluation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[PerformanceEvaluation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationRating_TR_UpdateChangeVersion] ON [tpdm].[PerformanceEvaluationRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[PerformanceEvaluationRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[PerformanceEvaluationRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_ProfessionalDevelopmentEvent_TR_UpdateChangeVersion] ON [tpdm].[ProfessionalDevelopmentEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ProfessionalDevelopmentEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ProfessionalDevelopmentEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_ProfessionalDevelopmentEventAttendance_TR_UpdateChangeVersion] ON [tpdm].[ProfessionalDevelopmentEventAttendance] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[ProfessionalDevelopmentEventAttendance]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[ProfessionalDevelopmentEventAttendance] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_Prospect_TR_UpdateChangeVersion] ON [tpdm].[Prospect] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[Prospect]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[Prospect] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasure_TR_UpdateChangeVersion] ON [tpdm].[QuantitativeMeasure] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[QuantitativeMeasure]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[QuantitativeMeasure] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasureScore_TR_UpdateChangeVersion] ON [tpdm].[QuantitativeMeasureScore] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[QuantitativeMeasureScore]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[QuantitativeMeasureScore] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_RecruitmentEvent_TR_UpdateChangeVersion] ON [tpdm].[RecruitmentEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[RecruitmentEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[RecruitmentEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_RubricDimension_TR_UpdateChangeVersion] ON [tpdm].[RubricDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[RubricDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[RubricDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffApplicantAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffApplicantAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffApplicantAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffApplicantAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffProspectAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffProspectAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffProspectAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffProspectAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffStudentGrowthMeasure_TR_UpdateChangeVersion] ON [tpdm].[StaffStudentGrowthMeasure] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffStudentGrowthMeasure]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffStudentGrowthMeasure] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffStudentGrowthMeasureCourseAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffStudentGrowthMeasureCourseAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffStudentGrowthMeasureCourseAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffStudentGrowthMeasureCourseAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffStudentGrowthMeasureEducationOrganizationAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffStudentGrowthMeasureSectionAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffStudentGrowthMeasureSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffStudentGrowthMeasureSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffStudentGrowthMeasureSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffTeacherPreparationProviderAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffTeacherPreparationProviderAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffTeacherPreparationProviderAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffTeacherPreparationProviderAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_StaffTeacherPreparationProviderProgramAssociation_TR_UpdateChangeVersion] ON [tpdm].[StaffTeacherPreparationProviderProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[StaffTeacherPreparationProviderProgramAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[StaffTeacherPreparationProviderProgramAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_SurveyResponseTeacherCandidateTargetAssociation_TR_UpdateChangeVersion] ON [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[SurveyResponseTeacherCandidateTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_SurveySectionAggregateResponse_TR_UpdateChangeVersion] ON [tpdm].[SurveySectionAggregateResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[SurveySectionAggregateResponse]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[SurveySectionAggregateResponse] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_SurveySectionResponseTeacherCandidateTargetAssociation_TR_UpdateChangeVersion] ON [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidate_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidate] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidate]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidate] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateAcademicRecord_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateAcademicRecord] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateAcademicRecord]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateAcademicRecord] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateCourseTranscript_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateCourseTranscript] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateCourseTranscript]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateCourseTranscript] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateStaffAssociation_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateStaffAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateStaffAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateStaffAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateStudentGrowthMeasure_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasure] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateStudentGrowthMeasure]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateStudentGrowthMeasure] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateStudentGrowthMeasureCourseAssociation_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateStudentGrowthMeasureSectionAssociation_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateTeacherPreparationProviderAssociation_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherCandidateTeacherPreparationProviderProgramAssociation_TR_UpdateChangeVersion] ON [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [tpdm].[tpdm_TeacherPreparationProviderProgram_TR_UpdateChangeVersion] ON [tpdm].[TeacherPreparationProviderProgram] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tpdm].[TeacherPreparationProviderProgram]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [tpdm].[TeacherPreparationProviderProgram] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

