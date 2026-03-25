-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_AcademicWeek_SchoolId' AND object_id = OBJECT_ID('edfi.AcademicWeek')) 
BEGIN
    CREATE INDEX IX_AcademicWeek_SchoolId ON [edfi].[AcademicWeek](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_AccountabilityRating_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.AccountabilityRating')) 
BEGIN
    CREATE INDEX IX_AccountabilityRating_EducationOrganizationId ON [edfi].[AccountabilityRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Application_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Application')) 
BEGIN
    CREATE INDEX IX_Application_EducationOrganizationId ON [edfi].[Application](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ApplicationEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.ApplicationEvent')) 
BEGIN
    CREATE INDEX IX_ApplicationEvent_EducationOrganizationId ON [edfi].[ApplicationEvent](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Assessment_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Assessment')) 
BEGIN
    CREATE INDEX IX_Assessment_EducationOrganizationId ON [edfi].[Assessment](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_AssessmentAdministrationParticipation_AssigningEducationOrganizationId' AND object_id = OBJECT_ID('edfi.AssessmentAdministrationParticipation')) 
BEGIN
    CREATE INDEX IX_AssessmentAdministrationParticipation_AssigningEducationOrganizationId ON [edfi].[AssessmentAdministrationParticipation](AssigningEducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_BellSchedule_SchoolId' AND object_id = OBJECT_ID('edfi.BellSchedule')) 
BEGIN
    CREATE INDEX IX_BellSchedule_SchoolId ON [edfi].[BellSchedule](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Calendar_SchoolId' AND object_id = OBJECT_ID('edfi.Calendar')) 
BEGIN
    CREATE INDEX IX_Calendar_SchoolId ON [edfi].[Calendar](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CalendarDate_SchoolId' AND object_id = OBJECT_ID('edfi.CalendarDate')) 
BEGIN
    CREATE INDEX IX_CalendarDate_SchoolId ON [edfi].[CalendarDate](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CandidateEducatorPreparationProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CandidateEducatorPreparationProgramAssociation')) 
BEGIN
    CREATE INDEX IX_CandidateEducatorPreparationProgramAssociation_EducationOrganizationId ON [edfi].[CandidateEducatorPreparationProgramAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CandidateIdentificationCode_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CandidateIdentificationCode')) 
BEGIN
    CREATE INDEX IX_CandidateIdentificationCode_EducationOrganizationId ON [edfi].[CandidateIdentificationCode](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Certification_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Certification')) 
BEGIN
    CREATE INDEX IX_Certification_EducationOrganizationId ON [edfi].[Certification](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CertificationExam_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CertificationExam')) 
BEGIN
    CREATE INDEX IX_CertificationExam_EducationOrganizationId ON [edfi].[CertificationExam](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ChartOfAccount_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.ChartOfAccount')) 
BEGIN
    CREATE INDEX IX_ChartOfAccount_EducationOrganizationId ON [edfi].[ChartOfAccount](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ClassPeriod_SchoolId' AND object_id = OBJECT_ID('edfi.ClassPeriod')) 
BEGIN
    CREATE INDEX IX_ClassPeriod_SchoolId ON [edfi].[ClassPeriod](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Cohort_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Cohort')) 
BEGIN
    CREATE INDEX IX_Cohort_EducationOrganizationId ON [edfi].[Cohort](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CommunityProviderLicense_CommunityProviderId' AND object_id = OBJECT_ID('edfi.CommunityProviderLicense')) 
BEGIN
    CREATE INDEX IX_CommunityProviderLicense_CommunityProviderId ON [edfi].[CommunityProviderLicense](CommunityProviderId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CompetencyObjective_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CompetencyObjective')) 
BEGIN
    CREATE INDEX IX_CompetencyObjective_EducationOrganizationId ON [edfi].[CompetencyObjective](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ContactIdentificationCode_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.ContactIdentificationCode')) 
BEGIN
    CREATE INDEX IX_ContactIdentificationCode_EducationOrganizationId ON [edfi].[ContactIdentificationCode](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Course_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Course')) 
BEGIN
    CREATE INDEX IX_Course_EducationOrganizationId ON [edfi].[Course](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseOffering_SchoolId' AND object_id = OBJECT_ID('edfi.CourseOffering')) 
BEGIN
    CREATE INDEX IX_CourseOffering_SchoolId ON [edfi].[CourseOffering](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseOffering_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CourseOffering')) 
BEGIN
    CREATE INDEX IX_CourseOffering_EducationOrganizationId ON [edfi].[CourseOffering](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseTranscript_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CourseTranscript')) 
BEGIN
    CREATE INDEX IX_CourseTranscript_EducationOrganizationId ON [edfi].[CourseTranscript](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_DisciplineIncident_SchoolId' AND object_id = OBJECT_ID('edfi.DisciplineIncident')) 
BEGIN
    CREATE INDEX IX_DisciplineIncident_SchoolId ON [edfi].[DisciplineIncident](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganization_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducationOrganization')) 
BEGIN
    CREATE INDEX IX_EducationOrganization_EducationOrganizationId ON [edfi].[EducationOrganization](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganizationIdentificationCode_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducationOrganizationIdentificationCode')) 
BEGIN
    CREATE INDEX IX_EducationOrganizationIdentificationCode_EducationOrganizationId ON [edfi].[EducationOrganizationIdentificationCode](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducationOrganizationInterventionPrescriptionAssociation')) 
BEGIN
    CREATE INDEX IX_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganizationId ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganizationNetworkAssociation_EducationOrganizationNetworkId' AND object_id = OBJECT_ID('edfi.EducationOrganizationNetworkAssociation')) 
BEGIN
    CREATE INDEX IX_EducationOrganizationNetworkAssociation_EducationOrganizationNetworkId ON [edfi].[EducationOrganizationNetworkAssociation](EducationOrganizationNetworkId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganizationPeerAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducationOrganizationPeerAssociation')) 
BEGIN
    CREATE INDEX IX_EducationOrganizationPeerAssociation_EducationOrganizationId ON [edfi].[EducationOrganizationPeerAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducatorPreparationProgram_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducatorPreparationProgram')) 
BEGIN
    CREATE INDEX IX_EducatorPreparationProgram_EducationOrganizationId ON [edfi].[EducatorPreparationProgram](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Evaluation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Evaluation')) 
BEGIN
    CREATE INDEX IX_Evaluation_EducationOrganizationId ON [edfi].[Evaluation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationElement_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EvaluationElement')) 
BEGIN
    CREATE INDEX IX_EvaluationElement_EducationOrganizationId ON [edfi].[EvaluationElement](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationElementRating_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EvaluationElementRating')) 
BEGIN
    CREATE INDEX IX_EvaluationElementRating_EducationOrganizationId ON [edfi].[EvaluationElementRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationObjective_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EvaluationObjective')) 
BEGIN
    CREATE INDEX IX_EvaluationObjective_EducationOrganizationId ON [edfi].[EvaluationObjective](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationObjectiveRating_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EvaluationObjectiveRating')) 
BEGIN
    CREATE INDEX IX_EvaluationObjectiveRating_EducationOrganizationId ON [edfi].[EvaluationObjectiveRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationRating_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EvaluationRating')) 
BEGIN
    CREATE INDEX IX_EvaluationRating_EducationOrganizationId ON [edfi].[EvaluationRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationRating_SchoolId' AND object_id = OBJECT_ID('edfi.EvaluationRating')) 
BEGIN
    CREATE INDEX IX_EvaluationRating_SchoolId ON [edfi].[EvaluationRating](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationRubricDimension_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.EvaluationRubricDimension')) 
BEGIN
    CREATE INDEX IX_EvaluationRubricDimension_ProgramEducationOrganizationId ON [edfi].[EvaluationRubricDimension](ProgramEducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_FeederSchoolAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.FeederSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_FeederSchoolAssociation_SchoolId ON [edfi].[FeederSchoolAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_FieldworkExperience_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.FieldworkExperience')) 
BEGIN
    CREATE INDEX IX_FieldworkExperience_EducationOrganizationId ON [edfi].[FieldworkExperience](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_FieldworkExperience_SchoolId' AND object_id = OBJECT_ID('edfi.FieldworkExperience')) 
BEGIN
    CREATE INDEX IX_FieldworkExperience_SchoolId ON [edfi].[FieldworkExperience](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_FieldworkExperienceSectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.FieldworkExperienceSectionAssociation')) 
BEGIN
    CREATE INDEX IX_FieldworkExperienceSectionAssociation_SchoolId ON [edfi].[FieldworkExperienceSectionAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GeneralStudentProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.GeneralStudentProgramAssociation')) 
BEGIN
    CREATE INDEX IX_GeneralStudentProgramAssociation_EducationOrganizationId ON [edfi].[GeneralStudentProgramAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Goal_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Goal')) 
BEGIN
    CREATE INDEX IX_Goal_EducationOrganizationId ON [edfi].[Goal](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Grade_SchoolId' AND object_id = OBJECT_ID('edfi.Grade')) 
BEGIN
    CREATE INDEX IX_Grade_SchoolId ON [edfi].[Grade](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GradebookEntry_SchoolId' AND object_id = OBJECT_ID('edfi.GradebookEntry')) 
BEGIN
    CREATE INDEX IX_GradebookEntry_SchoolId ON [edfi].[GradebookEntry](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GradingPeriod_SchoolId' AND object_id = OBJECT_ID('edfi.GradingPeriod')) 
BEGIN
    CREATE INDEX IX_GradingPeriod_SchoolId ON [edfi].[GradingPeriod](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GraduationPlan_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.GraduationPlan')) 
BEGIN
    CREATE INDEX IX_GraduationPlan_EducationOrganizationId ON [edfi].[GraduationPlan](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Intervention_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Intervention')) 
BEGIN
    CREATE INDEX IX_Intervention_EducationOrganizationId ON [edfi].[Intervention](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_InterventionPrescription_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.InterventionPrescription')) 
BEGIN
    CREATE INDEX IX_InterventionPrescription_EducationOrganizationId ON [edfi].[InterventionPrescription](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_InterventionStudy_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.InterventionStudy')) 
BEGIN
    CREATE INDEX IX_InterventionStudy_EducationOrganizationId ON [edfi].[InterventionStudy](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalAccount_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalAccount')) 
BEGIN
    CREATE INDEX IX_LocalAccount_EducationOrganizationId ON [edfi].[LocalAccount](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalActual_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalActual')) 
BEGIN
    CREATE INDEX IX_LocalActual_EducationOrganizationId ON [edfi].[LocalActual](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalBudget_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalBudget')) 
BEGIN
    CREATE INDEX IX_LocalBudget_EducationOrganizationId ON [edfi].[LocalBudget](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalContractedStaff_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalContractedStaff')) 
BEGIN
    CREATE INDEX IX_LocalContractedStaff_EducationOrganizationId ON [edfi].[LocalContractedStaff](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalEncumbrance_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalEncumbrance')) 
BEGIN
    CREATE INDEX IX_LocalEncumbrance_EducationOrganizationId ON [edfi].[LocalEncumbrance](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalPayroll_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalPayroll')) 
BEGIN
    CREATE INDEX IX_LocalPayroll_EducationOrganizationId ON [edfi].[LocalPayroll](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Location_SchoolId' AND object_id = OBJECT_ID('edfi.Location')) 
BEGIN
    CREATE INDEX IX_Location_SchoolId ON [edfi].[Location](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_OpenStaffPosition_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.OpenStaffPosition')) 
BEGIN
    CREATE INDEX IX_OpenStaffPosition_EducationOrganizationId ON [edfi].[OpenStaffPosition](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_OpenStaffPositionEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.OpenStaffPositionEvent')) 
BEGIN
    CREATE INDEX IX_OpenStaffPositionEvent_EducationOrganizationId ON [edfi].[OpenStaffPositionEvent](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Path_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Path')) 
BEGIN
    CREATE INDEX IX_Path_EducationOrganizationId ON [edfi].[Path](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PathPhase_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.PathPhase')) 
BEGIN
    CREATE INDEX IX_PathPhase_EducationOrganizationId ON [edfi].[PathPhase](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PerformanceEvaluation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.PerformanceEvaluation')) 
BEGIN
    CREATE INDEX IX_PerformanceEvaluation_EducationOrganizationId ON [edfi].[PerformanceEvaluation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PerformanceEvaluationRating_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.PerformanceEvaluationRating')) 
BEGIN
    CREATE INDEX IX_PerformanceEvaluationRating_EducationOrganizationId ON [edfi].[PerformanceEvaluationRating](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PostSecondaryEvent_PostSecondaryInstitutionId' AND object_id = OBJECT_ID('edfi.PostSecondaryEvent')) 
BEGIN
    CREATE INDEX IX_PostSecondaryEvent_PostSecondaryInstitutionId ON [edfi].[PostSecondaryEvent](PostSecondaryInstitutionId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Program_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Program')) 
BEGIN
    CREATE INDEX IX_Program_EducationOrganizationId ON [edfi].[Program](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ProgramEvaluationElement_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.ProgramEvaluationElement')) 
BEGIN
    CREATE INDEX IX_ProgramEvaluationElement_ProgramEducationOrganizationId ON [edfi].[ProgramEvaluationElement](ProgramEducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ProgramEvaluationObjective_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.ProgramEvaluationObjective')) 
BEGIN
    CREATE INDEX IX_ProgramEvaluationObjective_ProgramEducationOrganizationId ON [edfi].[ProgramEvaluationObjective](ProgramEducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_QuantitativeMeasure_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.QuantitativeMeasure')) 
BEGIN
    CREATE INDEX IX_QuantitativeMeasure_EducationOrganizationId ON [edfi].[QuantitativeMeasure](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_QuantitativeMeasureScore_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.QuantitativeMeasureScore')) 
BEGIN
    CREATE INDEX IX_QuantitativeMeasureScore_EducationOrganizationId ON [edfi].[QuantitativeMeasureScore](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RecruitmentEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.RecruitmentEvent')) 
BEGIN
    CREATE INDEX IX_RecruitmentEvent_EducationOrganizationId ON [edfi].[RecruitmentEvent](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RecruitmentEventAttendance_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.RecruitmentEventAttendance')) 
BEGIN
    CREATE INDEX IX_RecruitmentEventAttendance_EducationOrganizationId ON [edfi].[RecruitmentEventAttendance](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ReportCard_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.ReportCard')) 
BEGIN
    CREATE INDEX IX_ReportCard_EducationOrganizationId ON [edfi].[ReportCard](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RestraintEvent_SchoolId' AND object_id = OBJECT_ID('edfi.RestraintEvent')) 
BEGIN
    CREATE INDEX IX_RestraintEvent_SchoolId ON [edfi].[RestraintEvent](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RubricDimension_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.RubricDimension')) 
BEGIN
    CREATE INDEX IX_RubricDimension_EducationOrganizationId ON [edfi].[RubricDimension](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Section_SchoolId' AND object_id = OBJECT_ID('edfi.Section')) 
BEGIN
    CREATE INDEX IX_Section_SchoolId ON [edfi].[Section](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SectionAttendanceTakenEvent_SchoolId' AND object_id = OBJECT_ID('edfi.SectionAttendanceTakenEvent')) 
BEGIN
    CREATE INDEX IX_SectionAttendanceTakenEvent_SchoolId ON [edfi].[SectionAttendanceTakenEvent](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Session_SchoolId' AND object_id = OBJECT_ID('edfi.Session')) 
BEGIN
    CREATE INDEX IX_Session_SchoolId ON [edfi].[Session](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Staff_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Staff')) 
BEGIN
    CREATE INDEX IX_Staff_EducationOrganizationId ON [edfi].[Staff](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffCohortAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StaffCohortAssociation_EducationOrganizationId ON [edfi].[StaffCohortAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffDemographic_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffDemographic')) 
BEGIN
    CREATE INDEX IX_StaffDemographic_EducationOrganizationId ON [edfi].[StaffDemographic](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffDirectory_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffDirectory')) 
BEGIN
    CREATE INDEX IX_StaffDirectory_EducationOrganizationId ON [edfi].[StaffDirectory](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffDisciplineIncidentAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StaffDisciplineIncidentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffDisciplineIncidentAssociation_SchoolId ON [edfi].[StaffDisciplineIncidentAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationAssignmentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationAssignmentAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationEmploymentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationEmploymentAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducatorPreparationProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducatorPreparationProgramAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducatorPreparationProgramAssociation_EducationOrganizationId ON [edfi].[StaffEducatorPreparationProgramAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffIdentificationCode_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffIdentificationCode')) 
BEGIN
    CREATE INDEX IX_StaffIdentificationCode_EducationOrganizationId ON [edfi].[StaffIdentificationCode](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffSchoolAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StaffSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StaffSchoolAssociation_SchoolId ON [edfi].[StaffSchoolAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffSectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StaffSectionAssociation')) 
BEGIN
    CREATE INDEX IX_StaffSectionAssociation_SchoolId ON [edfi].[StaffSectionAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAcademicRecord_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAcademicRecord')) 
BEGIN
    CREATE INDEX IX_StudentAcademicRecord_EducationOrganizationId ON [edfi].[StudentAcademicRecord](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentEducationOrganizationAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationId ON [edfi].[StudentAssessmentEducationOrganizationAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistration_AssigningEducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistration')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistration_AssigningEducationOrganizationId ON [edfi].[StudentAssessmentRegistration](AssigningEducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistration_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistration')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistration_EducationOrganizationId ON [edfi].[StudentAssessmentRegistration](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistration_SchoolId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistration')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistration_SchoolId ON [edfi].[StudentAssessmentRegistration](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistrationBatteryPartAssociation_AssigningEducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistrationBatteryPartAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistrationBatteryPartAssociation_AssigningEducationOrganizationId ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation](AssigningEducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistrationBatteryPartAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistrationBatteryPartAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistrationBatteryPartAssociation_EducationOrganizationId ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentCohortAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StudentCohortAssociation_EducationOrganizationId ON [edfi].[StudentCohortAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDemographic_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentDemographic')) 
BEGIN
    CREATE INDEX IX_StudentDemographic_EducationOrganizationId ON [edfi].[StudentDemographic](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDirectory_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentDirectory')) 
BEGIN
    CREATE INDEX IX_StudentDirectory_EducationOrganizationId ON [edfi].[StudentDirectory](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentBehaviorAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId ON [edfi].[StudentDisciplineIncidentBehaviorAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentNonOffenderAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationAssessmentAccommodation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationAssessmentAccommodation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationAssessmentAccommodation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationAssessmentAccommodation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationAssociation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationResponsibilityAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationResponsibilityAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentHealth_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentHealth')) 
BEGIN
    CREATE INDEX IX_StudentHealth_EducationOrganizationId ON [edfi].[StudentHealth](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentIdentificationCode_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentIdentificationCode')) 
BEGIN
    CREATE INDEX IX_StudentIdentificationCode_EducationOrganizationId ON [edfi].[StudentIdentificationCode](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentInterventionAssociation')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAssociation_EducationOrganizationId ON [edfi].[StudentInterventionAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAttendanceEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentInterventionAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAttendanceEvent_EducationOrganizationId ON [edfi].[StudentInterventionAttendanceEvent](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentPath_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentPath')) 
BEGIN
    CREATE INDEX IX_StudentPath_EducationOrganizationId ON [edfi].[StudentPath](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentPathMilestoneStatus_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentPathMilestoneStatus')) 
BEGIN
    CREATE INDEX IX_StudentPathMilestoneStatus_EducationOrganizationId ON [edfi].[StudentPathMilestoneStatus](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentPathPhaseStatus_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentPathPhaseStatus')) 
BEGIN
    CREATE INDEX IX_StudentPathPhaseStatus_EducationOrganizationId ON [edfi].[StudentPathPhaseStatus](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramAttendanceEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentProgramAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentProgramAttendanceEvent_EducationOrganizationId ON [edfi].[StudentProgramAttendanceEvent](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramEvaluation_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentProgramEvaluation')) 
BEGIN
    CREATE INDEX IX_StudentProgramEvaluation_ProgramEducationOrganizationId ON [edfi].[StudentProgramEvaluation](ProgramEducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramEvaluation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentProgramEvaluation')) 
BEGIN
    CREATE INDEX IX_StudentProgramEvaluation_EducationOrganizationId ON [edfi].[StudentProgramEvaluation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAssociation_SchoolId ON [edfi].[StudentSchoolAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAssociation_EducationOrganizationId ON [edfi].[StudentSchoolAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAttendanceEvent_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSchoolAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAttendanceEvent_SchoolId ON [edfi].[StudentSchoolAttendanceEvent](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSectionAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSectionAssociation_SchoolId ON [edfi].[StudentSectionAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSectionAttendanceEvent_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSectionAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentSectionAttendanceEvent_SchoolId ON [edfi].[StudentSectionAttendanceEvent](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentSpecialEducationProgramEligibilityAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganizationId ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Survey_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Survey')) 
BEGIN
    CREATE INDEX IX_Survey_EducationOrganizationId ON [edfi].[Survey](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Survey_SchoolId' AND object_id = OBJECT_ID('edfi.Survey')) 
BEGIN
    CREATE INDEX IX_Survey_SchoolId ON [edfi].[Survey](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyCourseAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveyCourseAssociation')) 
BEGIN
    CREATE INDEX IX_SurveyCourseAssociation_EducationOrganizationId ON [edfi].[SurveyCourseAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveyProgramAssociation')) 
BEGIN
    CREATE INDEX IX_SurveyProgramAssociation_EducationOrganizationId ON [edfi].[SurveyProgramAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveyResponseEducationOrganizationTargetAssociation')) 
BEGIN
    CREATE INDEX IX_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySection_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveySection')) 
BEGIN
    CREATE INDEX IX_SurveySection_EducationOrganizationId ON [edfi].[SurveySection](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionAggregateResponse_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveySectionAggregateResponse')) 
BEGIN
    CREATE INDEX IX_SurveySectionAggregateResponse_EducationOrganizationId ON [edfi].[SurveySectionAggregateResponse](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.SurveySectionAssociation')) 
BEGIN
    CREATE INDEX IX_SurveySectionAssociation_SchoolId ON [edfi].[SurveySectionAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveySectionResponseEducationOrganizationTargetAssociation')) 
BEGIN
    CREATE INDEX IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation](EducationOrganizationId) INCLUDE (Id)
END;
