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

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Assessment_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Assessment')) 
BEGIN
    CREATE INDEX IX_Assessment_EducationOrganizationId ON [edfi].[Assessment](EducationOrganizationId) INCLUDE (Id)
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

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_FeederSchoolAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.FeederSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_FeederSchoolAssociation_SchoolId ON [edfi].[FeederSchoolAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GeneralStudentProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.GeneralStudentProgramAssociation')) 
BEGIN
    CREATE INDEX IX_GeneralStudentProgramAssociation_EducationOrganizationId ON [edfi].[GeneralStudentProgramAssociation](EducationOrganizationId) INCLUDE (Id)
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

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PostSecondaryEvent_PostSecondaryInstitutionId' AND object_id = OBJECT_ID('edfi.PostSecondaryEvent')) 
BEGIN
    CREATE INDEX IX_PostSecondaryEvent_PostSecondaryInstitutionId ON [edfi].[PostSecondaryEvent](PostSecondaryInstitutionId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Program_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Program')) 
BEGIN
    CREATE INDEX IX_Program_EducationOrganizationId ON [edfi].[Program](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ReportCard_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.ReportCard')) 
BEGIN
    CREATE INDEX IX_ReportCard_EducationOrganizationId ON [edfi].[ReportCard](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RestraintEvent_SchoolId' AND object_id = OBJECT_ID('edfi.RestraintEvent')) 
BEGIN
    CREATE INDEX IX_RestraintEvent_SchoolId ON [edfi].[RestraintEvent](SchoolId) INCLUDE (Id)
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

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffCohortAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StaffCohortAssociation_EducationOrganizationId ON [edfi].[StaffCohortAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffDisciplineIncidentAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StaffDisciplineIncidentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffDisciplineIncidentAssociation_SchoolId ON [edfi].[StaffDisciplineIncidentAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationAssignmentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationAssignmentAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationContactAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationContactAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationContactAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationContactAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationEmploymentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationEmploymentAssociation](EducationOrganizationId) INCLUDE (Id)
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

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentCohortAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StudentCohortAssociation_EducationOrganizationId ON [edfi].[StudentCohortAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentAssociation_SchoolId ON [edfi].[StudentDisciplineIncidentAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentBehaviorAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId ON [edfi].[StudentDisciplineIncidentBehaviorAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentNonOffenderAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationAssociation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationResponsibilityAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationResponsibilityAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentInterventionAssociation')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAssociation_EducationOrganizationId ON [edfi].[StudentInterventionAssociation](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAttendanceEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentInterventionAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAttendanceEvent_EducationOrganizationId ON [edfi].[StudentInterventionAttendanceEvent](EducationOrganizationId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramAttendanceEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentProgramAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentProgramAttendanceEvent_EducationOrganizationId ON [edfi].[StudentProgramAttendanceEvent](EducationOrganizationId) INCLUDE (Id)
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

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.SurveySectionAssociation')) 
BEGIN
    CREATE INDEX IX_SurveySectionAssociation_SchoolId ON [edfi].[SurveySectionAssociation](SchoolId) INCLUDE (Id)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveySectionResponseEducationOrganizationTargetAssociation')) 
BEGIN
    CREATE INDEX IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation](EducationOrganizationId) INCLUDE (Id)
END;
