-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_AcademicWeek_SchoolId' AND object_id = OBJECT_ID('edfi.AcademicWeek')) 
BEGIN
    CREATE INDEX IX_AcademicWeek_SchoolId ON [edfi].[AcademicWeek](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_AccountabilityRating_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.AccountabilityRating')) 
BEGIN
    CREATE INDEX IX_AccountabilityRating_EducationOrganizationId ON [edfi].[AccountabilityRating](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Assessment_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Assessment')) 
BEGIN
    CREATE INDEX IX_Assessment_EducationOrganizationId ON [edfi].[Assessment](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_AssessmentAdministrationParticipation_AssigningEducationOrganizationId' AND object_id = OBJECT_ID('edfi.AssessmentAdministrationParticipation')) 
BEGIN
    CREATE INDEX IX_AssessmentAdministrationParticipation_AssigningEducationOrganizationId ON [edfi].[AssessmentAdministrationParticipation](AssigningEducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_BellSchedule_SchoolId' AND object_id = OBJECT_ID('edfi.BellSchedule')) 
BEGIN
    CREATE INDEX IX_BellSchedule_SchoolId ON [edfi].[BellSchedule](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Calendar_SchoolId' AND object_id = OBJECT_ID('edfi.Calendar')) 
BEGIN
    CREATE INDEX IX_Calendar_SchoolId ON [edfi].[Calendar](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CalendarDate_SchoolId' AND object_id = OBJECT_ID('edfi.CalendarDate')) 
BEGIN
    CREATE INDEX IX_CalendarDate_SchoolId ON [edfi].[CalendarDate](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ChartOfAccount_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.ChartOfAccount')) 
BEGIN
    CREATE INDEX IX_ChartOfAccount_EducationOrganizationId ON [edfi].[ChartOfAccount](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ClassPeriod_SchoolId' AND object_id = OBJECT_ID('edfi.ClassPeriod')) 
BEGIN
    CREATE INDEX IX_ClassPeriod_SchoolId ON [edfi].[ClassPeriod](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Cohort_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Cohort')) 
BEGIN
    CREATE INDEX IX_Cohort_EducationOrganizationId ON [edfi].[Cohort](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CommunityProviderLicense_CommunityProviderId' AND object_id = OBJECT_ID('edfi.CommunityProviderLicense')) 
BEGIN
    CREATE INDEX IX_CommunityProviderLicense_CommunityProviderId ON [edfi].[CommunityProviderLicense](CommunityProviderId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CompetencyObjective_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CompetencyObjective')) 
BEGIN
    CREATE INDEX IX_CompetencyObjective_EducationOrganizationId ON [edfi].[CompetencyObjective](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Contact_ContactUSI' AND object_id = OBJECT_ID('edfi.Contact')) 
BEGIN
    CREATE INDEX IX_Contact_ContactUSI ON [edfi].[Contact](ContactUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Course_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Course')) 
BEGIN
    CREATE INDEX IX_Course_EducationOrganizationId ON [edfi].[Course](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseOffering_SchoolId' AND object_id = OBJECT_ID('edfi.CourseOffering')) 
BEGIN
    CREATE INDEX IX_CourseOffering_SchoolId ON [edfi].[CourseOffering](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseOffering_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CourseOffering')) 
BEGIN
    CREATE INDEX IX_CourseOffering_EducationOrganizationId ON [edfi].[CourseOffering](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseTranscript_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.CourseTranscript')) 
BEGIN
    CREATE INDEX IX_CourseTranscript_EducationOrganizationId ON [edfi].[CourseTranscript](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseTranscript_StudentUSI' AND object_id = OBJECT_ID('edfi.CourseTranscript')) 
BEGIN
    CREATE INDEX IX_CourseTranscript_StudentUSI ON [edfi].[CourseTranscript](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_CourseTranscript_ResponsibleTeacherStaffUSI' AND object_id = OBJECT_ID('edfi.CourseTranscript')) 
BEGIN
    CREATE INDEX IX_CourseTranscript_ResponsibleTeacherStaffUSI ON [edfi].[CourseTranscript](ResponsibleTeacherStaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_DisciplineAction_StudentUSI' AND object_id = OBJECT_ID('edfi.DisciplineAction')) 
BEGIN
    CREATE INDEX IX_DisciplineAction_StudentUSI ON [edfi].[DisciplineAction](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_DisciplineIncident_SchoolId' AND object_id = OBJECT_ID('edfi.DisciplineIncident')) 
BEGIN
    CREATE INDEX IX_DisciplineIncident_SchoolId ON [edfi].[DisciplineIncident](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganization_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducationOrganization')) 
BEGIN
    CREATE INDEX IX_EducationOrganization_EducationOrganizationId ON [edfi].[EducationOrganization](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducationOrganizationInterventionPrescriptionAssociation')) 
BEGIN
    CREATE INDEX IX_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganizationId ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganizationNetworkAssociation_EducationOrganizationNetworkId' AND object_id = OBJECT_ID('edfi.EducationOrganizationNetworkAssociation')) 
BEGIN
    CREATE INDEX IX_EducationOrganizationNetworkAssociation_EducationOrganizationNetworkId ON [edfi].[EducationOrganizationNetworkAssociation](EducationOrganizationNetworkId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EducationOrganizationPeerAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.EducationOrganizationPeerAssociation')) 
BEGIN
    CREATE INDEX IX_EducationOrganizationPeerAssociation_EducationOrganizationId ON [edfi].[EducationOrganizationPeerAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_EvaluationRubricDimension_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.EvaluationRubricDimension')) 
BEGIN
    CREATE INDEX IX_EvaluationRubricDimension_ProgramEducationOrganizationId ON [edfi].[EvaluationRubricDimension](ProgramEducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_FeederSchoolAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.FeederSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_FeederSchoolAssociation_SchoolId ON [edfi].[FeederSchoolAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GeneralStudentProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.GeneralStudentProgramAssociation')) 
BEGIN
    CREATE INDEX IX_GeneralStudentProgramAssociation_EducationOrganizationId ON [edfi].[GeneralStudentProgramAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GeneralStudentProgramAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.GeneralStudentProgramAssociation')) 
BEGIN
    CREATE INDEX IX_GeneralStudentProgramAssociation_StudentUSI ON [edfi].[GeneralStudentProgramAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Grade_SchoolId' AND object_id = OBJECT_ID('edfi.Grade')) 
BEGIN
    CREATE INDEX IX_Grade_SchoolId ON [edfi].[Grade](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Grade_StudentUSI' AND object_id = OBJECT_ID('edfi.Grade')) 
BEGIN
    CREATE INDEX IX_Grade_StudentUSI ON [edfi].[Grade](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GradebookEntry_SchoolId' AND object_id = OBJECT_ID('edfi.GradebookEntry')) 
BEGIN
    CREATE INDEX IX_GradebookEntry_SchoolId ON [edfi].[GradebookEntry](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GradingPeriod_SchoolId' AND object_id = OBJECT_ID('edfi.GradingPeriod')) 
BEGIN
    CREATE INDEX IX_GradingPeriod_SchoolId ON [edfi].[GradingPeriod](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_GraduationPlan_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.GraduationPlan')) 
BEGIN
    CREATE INDEX IX_GraduationPlan_EducationOrganizationId ON [edfi].[GraduationPlan](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Intervention_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Intervention')) 
BEGIN
    CREATE INDEX IX_Intervention_EducationOrganizationId ON [edfi].[Intervention](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_InterventionPrescription_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.InterventionPrescription')) 
BEGIN
    CREATE INDEX IX_InterventionPrescription_EducationOrganizationId ON [edfi].[InterventionPrescription](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_InterventionStudy_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.InterventionStudy')) 
BEGIN
    CREATE INDEX IX_InterventionStudy_EducationOrganizationId ON [edfi].[InterventionStudy](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalAccount_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalAccount')) 
BEGIN
    CREATE INDEX IX_LocalAccount_EducationOrganizationId ON [edfi].[LocalAccount](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalActual_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalActual')) 
BEGIN
    CREATE INDEX IX_LocalActual_EducationOrganizationId ON [edfi].[LocalActual](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalBudget_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalBudget')) 
BEGIN
    CREATE INDEX IX_LocalBudget_EducationOrganizationId ON [edfi].[LocalBudget](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalContractedStaff_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalContractedStaff')) 
BEGIN
    CREATE INDEX IX_LocalContractedStaff_EducationOrganizationId ON [edfi].[LocalContractedStaff](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalContractedStaff_StaffUSI' AND object_id = OBJECT_ID('edfi.LocalContractedStaff')) 
BEGIN
    CREATE INDEX IX_LocalContractedStaff_StaffUSI ON [edfi].[LocalContractedStaff](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalEncumbrance_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalEncumbrance')) 
BEGIN
    CREATE INDEX IX_LocalEncumbrance_EducationOrganizationId ON [edfi].[LocalEncumbrance](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalPayroll_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.LocalPayroll')) 
BEGIN
    CREATE INDEX IX_LocalPayroll_EducationOrganizationId ON [edfi].[LocalPayroll](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_LocalPayroll_StaffUSI' AND object_id = OBJECT_ID('edfi.LocalPayroll')) 
BEGIN
    CREATE INDEX IX_LocalPayroll_StaffUSI ON [edfi].[LocalPayroll](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Location_SchoolId' AND object_id = OBJECT_ID('edfi.Location')) 
BEGIN
    CREATE INDEX IX_Location_SchoolId ON [edfi].[Location](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_OpenStaffPosition_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.OpenStaffPosition')) 
BEGIN
    CREATE INDEX IX_OpenStaffPosition_EducationOrganizationId ON [edfi].[OpenStaffPosition](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PostSecondaryEvent_PostSecondaryInstitutionId' AND object_id = OBJECT_ID('edfi.PostSecondaryEvent')) 
BEGIN
    CREATE INDEX IX_PostSecondaryEvent_PostSecondaryInstitutionId ON [edfi].[PostSecondaryEvent](PostSecondaryInstitutionId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_PostSecondaryEvent_StudentUSI' AND object_id = OBJECT_ID('edfi.PostSecondaryEvent')) 
BEGIN
    CREATE INDEX IX_PostSecondaryEvent_StudentUSI ON [edfi].[PostSecondaryEvent](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Program_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Program')) 
BEGIN
    CREATE INDEX IX_Program_EducationOrganizationId ON [edfi].[Program](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ProgramEvaluationElement_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.ProgramEvaluationElement')) 
BEGIN
    CREATE INDEX IX_ProgramEvaluationElement_ProgramEducationOrganizationId ON [edfi].[ProgramEvaluationElement](ProgramEducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ProgramEvaluationObjective_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.ProgramEvaluationObjective')) 
BEGIN
    CREATE INDEX IX_ProgramEvaluationObjective_ProgramEducationOrganizationId ON [edfi].[ProgramEvaluationObjective](ProgramEducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ReportCard_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.ReportCard')) 
BEGIN
    CREATE INDEX IX_ReportCard_EducationOrganizationId ON [edfi].[ReportCard](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ReportCard_StudentUSI' AND object_id = OBJECT_ID('edfi.ReportCard')) 
BEGIN
    CREATE INDEX IX_ReportCard_StudentUSI ON [edfi].[ReportCard](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RestraintEvent_SchoolId' AND object_id = OBJECT_ID('edfi.RestraintEvent')) 
BEGIN
    CREATE INDEX IX_RestraintEvent_SchoolId ON [edfi].[RestraintEvent](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_RestraintEvent_StudentUSI' AND object_id = OBJECT_ID('edfi.RestraintEvent')) 
BEGIN
    CREATE INDEX IX_RestraintEvent_StudentUSI ON [edfi].[RestraintEvent](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Section_SchoolId' AND object_id = OBJECT_ID('edfi.Section')) 
BEGIN
    CREATE INDEX IX_Section_SchoolId ON [edfi].[Section](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SectionAttendanceTakenEvent_SchoolId' AND object_id = OBJECT_ID('edfi.SectionAttendanceTakenEvent')) 
BEGIN
    CREATE INDEX IX_SectionAttendanceTakenEvent_SchoolId ON [edfi].[SectionAttendanceTakenEvent](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SectionAttendanceTakenEvent_StaffUSI' AND object_id = OBJECT_ID('edfi.SectionAttendanceTakenEvent')) 
BEGIN
    CREATE INDEX IX_SectionAttendanceTakenEvent_StaffUSI ON [edfi].[SectionAttendanceTakenEvent](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Session_SchoolId' AND object_id = OBJECT_ID('edfi.Session')) 
BEGIN
    CREATE INDEX IX_Session_SchoolId ON [edfi].[Session](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Staff_StaffUSI' AND object_id = OBJECT_ID('edfi.Staff')) 
BEGIN
    CREATE INDEX IX_Staff_StaffUSI ON [edfi].[Staff](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffAbsenceEvent_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffAbsenceEvent')) 
BEGIN
    CREATE INDEX IX_StaffAbsenceEvent_StaffUSI ON [edfi].[StaffAbsenceEvent](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffCohortAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StaffCohortAssociation_EducationOrganizationId ON [edfi].[StaffCohortAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffCohortAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StaffCohortAssociation_StaffUSI ON [edfi].[StaffCohortAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffDisciplineIncidentAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StaffDisciplineIncidentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffDisciplineIncidentAssociation_SchoolId ON [edfi].[StaffDisciplineIncidentAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffDisciplineIncidentAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffDisciplineIncidentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffDisciplineIncidentAssociation_StaffUSI ON [edfi].[StaffDisciplineIncidentAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationAssignmentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationAssignmentAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationAssignmentAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationAssignmentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationAssignmentAssociation_StaffUSI ON [edfi].[StaffEducationOrganizationAssignmentAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationContactAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationContactAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationContactAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationContactAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationContactAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationContactAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationContactAssociation_StaffUSI ON [edfi].[StaffEducationOrganizationContactAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationEmploymentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId ON [edfi].[StaffEducationOrganizationEmploymentAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffEducationOrganizationEmploymentAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffEducationOrganizationEmploymentAssociation')) 
BEGIN
    CREATE INDEX IX_StaffEducationOrganizationEmploymentAssociation_StaffUSI ON [edfi].[StaffEducationOrganizationEmploymentAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffLeave_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffLeave')) 
BEGIN
    CREATE INDEX IX_StaffLeave_StaffUSI ON [edfi].[StaffLeave](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffProgramAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffProgramAssociation')) 
BEGIN
    CREATE INDEX IX_StaffProgramAssociation_StaffUSI ON [edfi].[StaffProgramAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffSchoolAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StaffSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StaffSchoolAssociation_SchoolId ON [edfi].[StaffSchoolAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffSchoolAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StaffSchoolAssociation_StaffUSI ON [edfi].[StaffSchoolAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffSectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StaffSectionAssociation')) 
BEGIN
    CREATE INDEX IX_StaffSectionAssociation_SchoolId ON [edfi].[StaffSectionAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StaffSectionAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.StaffSectionAssociation')) 
BEGIN
    CREATE INDEX IX_StaffSectionAssociation_StaffUSI ON [edfi].[StaffSectionAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Student_StudentUSI' AND object_id = OBJECT_ID('edfi.Student')) 
BEGIN
    CREATE INDEX IX_Student_StudentUSI ON [edfi].[Student](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAcademicRecord_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAcademicRecord')) 
BEGIN
    CREATE INDEX IX_StudentAcademicRecord_EducationOrganizationId ON [edfi].[StudentAcademicRecord](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAcademicRecord_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentAcademicRecord')) 
BEGIN
    CREATE INDEX IX_StudentAcademicRecord_StudentUSI ON [edfi].[StudentAcademicRecord](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessment_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentAssessment')) 
BEGIN
    CREATE INDEX IX_StudentAssessment_StudentUSI ON [edfi].[StudentAssessment](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentEducationOrganizationAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationId ON [edfi].[StudentAssessmentEducationOrganizationAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentEducationOrganizationAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentAssessmentEducationOrganizationAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentEducationOrganizationAssociation_StudentUSI ON [edfi].[StudentAssessmentEducationOrganizationAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistration_AssigningEducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistration')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistration_AssigningEducationOrganizationId ON [edfi].[StudentAssessmentRegistration](AssigningEducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistration_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistration')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistration_EducationOrganizationId ON [edfi].[StudentAssessmentRegistration](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistration_SchoolId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistration')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistration_SchoolId ON [edfi].[StudentAssessmentRegistration](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistration_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistration')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistration_StudentUSI ON [edfi].[StudentAssessmentRegistration](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistrationBatteryPartAssociation_AssigningEducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistrationBatteryPartAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistrationBatteryPartAssociation_AssigningEducationOrganizationId ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation](AssigningEducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistrationBatteryPartAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistrationBatteryPartAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistrationBatteryPartAssociation_EducationOrganizationId ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentAssessmentRegistrationBatteryPartAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentAssessmentRegistrationBatteryPartAssociation')) 
BEGIN
    CREATE INDEX IX_StudentAssessmentRegistrationBatteryPartAssociation_StudentUSI ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentCohortAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StudentCohortAssociation_EducationOrganizationId ON [edfi].[StudentCohortAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentCohortAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentCohortAssociation')) 
BEGIN
    CREATE INDEX IX_StudentCohortAssociation_StudentUSI ON [edfi].[StudentCohortAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentCompetencyObjective_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentCompetencyObjective')) 
BEGIN
    CREATE INDEX IX_StudentCompetencyObjective_StudentUSI ON [edfi].[StudentCompetencyObjective](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentContactAssociation_ContactUSI' AND object_id = OBJECT_ID('edfi.StudentContactAssociation')) 
BEGIN
    CREATE INDEX IX_StudentContactAssociation_ContactUSI ON [edfi].[StudentContactAssociation](ContactUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentContactAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentContactAssociation')) 
BEGIN
    CREATE INDEX IX_StudentContactAssociation_StudentUSI ON [edfi].[StudentContactAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentBehaviorAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId ON [edfi].[StudentDisciplineIncidentBehaviorAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentBehaviorAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentBehaviorAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentBehaviorAssociation_StudentUSI ON [edfi].[StudentDisciplineIncidentBehaviorAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentNonOffenderAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentDisciplineIncidentNonOffenderAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentDisciplineIncidentNonOffenderAssociation')) 
BEGIN
    CREATE INDEX IX_StudentDisciplineIncidentNonOffenderAssociation_StudentUSI ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationAssessmentAccommodation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationAssessmentAccommodation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationAssessmentAccommodation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationAssessmentAccommodation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationAssessmentAccommodation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationAssessmentAccommodation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationAssessmentAccommodation_StudentUSI ON [edfi].[StudentEducationOrganizationAssessmentAccommodation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationAssociation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationAssociation_StudentUSI ON [edfi].[StudentEducationOrganizationAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationResponsibilityAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId ON [edfi].[StudentEducationOrganizationResponsibilityAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentEducationOrganizationResponsibilityAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentEducationOrganizationResponsibilityAssociation')) 
BEGIN
    CREATE INDEX IX_StudentEducationOrganizationResponsibilityAssociation_StudentUSI ON [edfi].[StudentEducationOrganizationResponsibilityAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentGradebookEntry_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentGradebookEntry')) 
BEGIN
    CREATE INDEX IX_StudentGradebookEntry_StudentUSI ON [edfi].[StudentGradebookEntry](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentHealth_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentHealth')) 
BEGIN
    CREATE INDEX IX_StudentHealth_EducationOrganizationId ON [edfi].[StudentHealth](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentHealth_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentHealth')) 
BEGIN
    CREATE INDEX IX_StudentHealth_StudentUSI ON [edfi].[StudentHealth](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentInterventionAssociation')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAssociation_EducationOrganizationId ON [edfi].[StudentInterventionAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentInterventionAssociation')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAssociation_StudentUSI ON [edfi].[StudentInterventionAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAttendanceEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentInterventionAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAttendanceEvent_EducationOrganizationId ON [edfi].[StudentInterventionAttendanceEvent](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentInterventionAttendanceEvent_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentInterventionAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentInterventionAttendanceEvent_StudentUSI ON [edfi].[StudentInterventionAttendanceEvent](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramAttendanceEvent_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentProgramAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentProgramAttendanceEvent_EducationOrganizationId ON [edfi].[StudentProgramAttendanceEvent](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramAttendanceEvent_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentProgramAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentProgramAttendanceEvent_StudentUSI ON [edfi].[StudentProgramAttendanceEvent](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramEvaluation_ProgramEducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentProgramEvaluation')) 
BEGIN
    CREATE INDEX IX_StudentProgramEvaluation_ProgramEducationOrganizationId ON [edfi].[StudentProgramEvaluation](ProgramEducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramEvaluation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentProgramEvaluation')) 
BEGIN
    CREATE INDEX IX_StudentProgramEvaluation_EducationOrganizationId ON [edfi].[StudentProgramEvaluation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramEvaluation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentProgramEvaluation')) 
BEGIN
    CREATE INDEX IX_StudentProgramEvaluation_StudentUSI ON [edfi].[StudentProgramEvaluation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentProgramEvaluation_StaffEvaluatorStaffUSI' AND object_id = OBJECT_ID('edfi.StudentProgramEvaluation')) 
BEGIN
    CREATE INDEX IX_StudentProgramEvaluation_StaffEvaluatorStaffUSI ON [edfi].[StudentProgramEvaluation](StaffEvaluatorStaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAssociation_SchoolId ON [edfi].[StudentSchoolAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAssociation_EducationOrganizationId ON [edfi].[StudentSchoolAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentSchoolAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAssociation_StudentUSI ON [edfi].[StudentSchoolAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAttendanceEvent_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSchoolAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAttendanceEvent_SchoolId ON [edfi].[StudentSchoolAttendanceEvent](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSchoolAttendanceEvent_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentSchoolAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentSchoolAttendanceEvent_StudentUSI ON [edfi].[StudentSchoolAttendanceEvent](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSectionAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSectionAssociation_SchoolId ON [edfi].[StudentSectionAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSectionAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentSectionAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSectionAssociation_StudentUSI ON [edfi].[StudentSectionAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSectionAttendanceEvent_SchoolId' AND object_id = OBJECT_ID('edfi.StudentSectionAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentSectionAttendanceEvent_SchoolId ON [edfi].[StudentSectionAttendanceEvent](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSectionAttendanceEvent_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentSectionAttendanceEvent')) 
BEGIN
    CREATE INDEX IX_StudentSectionAttendanceEvent_StudentUSI ON [edfi].[StudentSectionAttendanceEvent](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.StudentSpecialEducationProgramEligibilityAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganizationId ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentSpecialEducationProgramEligibilityAssociation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentSpecialEducationProgramEligibilityAssociation')) 
BEGIN
    CREATE INDEX IX_StudentSpecialEducationProgramEligibilityAssociation_StudentUSI ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentTransportation_StudentUSI' AND object_id = OBJECT_ID('edfi.StudentTransportation')) 
BEGIN
    CREATE INDEX IX_StudentTransportation_StudentUSI ON [edfi].[StudentTransportation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Survey_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.Survey')) 
BEGIN
    CREATE INDEX IX_Survey_EducationOrganizationId ON [edfi].[Survey](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_Survey_SchoolId' AND object_id = OBJECT_ID('edfi.Survey')) 
BEGIN
    CREATE INDEX IX_Survey_SchoolId ON [edfi].[Survey](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyCourseAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveyCourseAssociation')) 
BEGIN
    CREATE INDEX IX_SurveyCourseAssociation_EducationOrganizationId ON [edfi].[SurveyCourseAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyProgramAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveyProgramAssociation')) 
BEGIN
    CREATE INDEX IX_SurveyProgramAssociation_EducationOrganizationId ON [edfi].[SurveyProgramAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyResponse_ContactUSI' AND object_id = OBJECT_ID('edfi.SurveyResponse')) 
BEGIN
    CREATE INDEX IX_SurveyResponse_ContactUSI ON [edfi].[SurveyResponse](ContactUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyResponse_StaffUSI' AND object_id = OBJECT_ID('edfi.SurveyResponse')) 
BEGIN
    CREATE INDEX IX_SurveyResponse_StaffUSI ON [edfi].[SurveyResponse](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyResponse_StudentUSI' AND object_id = OBJECT_ID('edfi.SurveyResponse')) 
BEGIN
    CREATE INDEX IX_SurveyResponse_StudentUSI ON [edfi].[SurveyResponse](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveyResponseEducationOrganizationTargetAssociation')) 
BEGIN
    CREATE INDEX IX_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveyResponseStaffTargetAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.SurveyResponseStaffTargetAssociation')) 
BEGIN
    CREATE INDEX IX_SurveyResponseStaffTargetAssociation_StaffUSI ON [edfi].[SurveyResponseStaffTargetAssociation](StaffUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionAssociation_SchoolId' AND object_id = OBJECT_ID('edfi.SurveySectionAssociation')) 
BEGIN
    CREATE INDEX IX_SurveySectionAssociation_SchoolId ON [edfi].[SurveySectionAssociation](SchoolId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId' AND object_id = OBJECT_ID('edfi.SurveySectionResponseEducationOrganizationTargetAssociation')) 
BEGIN
    CREATE INDEX IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation](EducationOrganizationId) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_SurveySectionResponseStaffTargetAssociation_StaffUSI' AND object_id = OBJECT_ID('edfi.SurveySectionResponseStaffTargetAssociation')) 
BEGIN
    CREATE INDEX IX_SurveySectionResponseStaffTargetAssociation_StaffUSI ON [edfi].[SurveySectionResponseStaffTargetAssociation](StaffUSI) INCLUDE (AggregateId)
END;
