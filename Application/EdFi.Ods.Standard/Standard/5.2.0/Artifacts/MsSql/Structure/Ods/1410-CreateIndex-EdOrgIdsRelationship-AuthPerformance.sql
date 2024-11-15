-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS IX_AcademicWeek_SchoolId ON edfi.AcademicWeek(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_AccountabilityRating_EducationOrganizationId ON edfi.AccountabilityRating(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Assessment_EducationOrganizationId ON edfi.Assessment(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_AssessmentAdministrationParticipation_AssigningEducationOrganizationId ON edfi.AssessmentAdministrationParticipation(AssigningEducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_BellSchedule_SchoolId ON edfi.BellSchedule(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Calendar_SchoolId ON edfi.Calendar(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_CalendarDate_SchoolId ON edfi.CalendarDate(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_ChartOfAccount_EducationOrganizationId ON edfi.ChartOfAccount(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_ClassPeriod_SchoolId ON edfi.ClassPeriod(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Cohort_EducationOrganizationId ON edfi.Cohort(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_CommunityProviderLicense_CommunityProviderId ON edfi.CommunityProviderLicense(CommunityProviderId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_CompetencyObjective_EducationOrganizationId ON edfi.CompetencyObjective(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Course_EducationOrganizationId ON edfi.Course(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_CourseOffering_SchoolId ON edfi.CourseOffering(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_CourseOffering_EducationOrganizationId ON edfi.CourseOffering(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_CourseTranscript_EducationOrganizationId ON edfi.CourseTranscript(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_DisciplineIncident_SchoolId ON edfi.DisciplineIncident(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_EducationOrganization_EducationOrganizationId ON edfi.EducationOrganization(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganizationId ON edfi.EducationOrganizationInterventionPrescriptionAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_EducationOrganizationNetworkAssociation_EducationOrganizationNetworkId ON edfi.EducationOrganizationNetworkAssociation(EducationOrganizationNetworkId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_EducationOrganizationPeerAssociation_EducationOrganizationId ON edfi.EducationOrganizationPeerAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_EvaluationRubricDimension_ProgramEducationOrganizationId ON edfi.EvaluationRubricDimension(ProgramEducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_FeederSchoolAssociation_SchoolId ON edfi.FeederSchoolAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_GeneralStudentProgramAssociation_EducationOrganizationId ON edfi.GeneralStudentProgramAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Grade_SchoolId ON edfi.Grade(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_GradebookEntry_SchoolId ON edfi.GradebookEntry(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_GradingPeriod_SchoolId ON edfi.GradingPeriod(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_GraduationPlan_EducationOrganizationId ON edfi.GraduationPlan(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Intervention_EducationOrganizationId ON edfi.Intervention(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_InterventionPrescription_EducationOrganizationId ON edfi.InterventionPrescription(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_InterventionStudy_EducationOrganizationId ON edfi.InterventionStudy(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_LocalAccount_EducationOrganizationId ON edfi.LocalAccount(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_LocalActual_EducationOrganizationId ON edfi.LocalActual(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_LocalBudget_EducationOrganizationId ON edfi.LocalBudget(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_LocalContractedStaff_EducationOrganizationId ON edfi.LocalContractedStaff(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_LocalEncumbrance_EducationOrganizationId ON edfi.LocalEncumbrance(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_LocalPayroll_EducationOrganizationId ON edfi.LocalPayroll(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Location_SchoolId ON edfi.Location(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_OpenStaffPosition_EducationOrganizationId ON edfi.OpenStaffPosition(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_PostSecondaryEvent_PostSecondaryInstitutionId ON edfi.PostSecondaryEvent(PostSecondaryInstitutionId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Program_EducationOrganizationId ON edfi.Program(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_ProgramEvaluationElement_ProgramEducationOrganizationId ON edfi.ProgramEvaluationElement(ProgramEducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_ProgramEvaluationObjective_ProgramEducationOrganizationId ON edfi.ProgramEvaluationObjective(ProgramEducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_ReportCard_EducationOrganizationId ON edfi.ReportCard(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_RestraintEvent_SchoolId ON edfi.RestraintEvent(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Section_SchoolId ON edfi.Section(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_SectionAttendanceTakenEvent_SchoolId ON edfi.SectionAttendanceTakenEvent(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Session_SchoolId ON edfi.Session(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StaffCohortAssociation_EducationOrganizationId ON edfi.StaffCohortAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StaffDisciplineIncidentAssociation_SchoolId ON edfi.StaffDisciplineIncidentAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId ON edfi.StaffEducationOrganizationAssignmentAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationContactAssociation_EducationOrganizationId ON edfi.StaffEducationOrganizationContactAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId ON edfi.StaffEducationOrganizationEmploymentAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StaffSchoolAssociation_SchoolId ON edfi.StaffSchoolAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StaffSectionAssociation_SchoolId ON edfi.StaffSectionAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentAcademicRecord_EducationOrganizationId ON edfi.StudentAcademicRecord(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationId ON edfi.StudentAssessmentEducationOrganizationAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_AssigningEducationOrganizationId ON edfi.StudentAssessmentRegistration(AssigningEducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_EducationOrganizationId ON edfi.StudentAssessmentRegistration(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_SchoolId ON edfi.StudentAssessmentRegistration(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistrationBatteryPartAssociation_AssigningEducationOrganizationId ON edfi.StudentAssessmentRegistrationBatteryPartAssociation(AssigningEducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistrationBatteryPartAssociation_EducationOrganizationId ON edfi.StudentAssessmentRegistrationBatteryPartAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentCohortAssociation_EducationOrganizationId ON edfi.StudentCohortAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId ON edfi.StudentDisciplineIncidentBehaviorAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId ON edfi.StudentDisciplineIncidentNonOffenderAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationAssessmentAccommodation_EducationOrganizationId ON edfi.StudentEducationOrganizationAssessmentAccommodation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationAssociation_EducationOrganizationId ON edfi.StudentEducationOrganizationAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId ON edfi.StudentEducationOrganizationResponsibilityAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentHealth_EducationOrganizationId ON edfi.StudentHealth(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentInterventionAssociation_EducationOrganizationId ON edfi.StudentInterventionAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentInterventionAttendanceEvent_EducationOrganizationId ON edfi.StudentInterventionAttendanceEvent(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentProgramAttendanceEvent_EducationOrganizationId ON edfi.StudentProgramAttendanceEvent(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentProgramEvaluation_ProgramEducationOrganizationId ON edfi.StudentProgramEvaluation(ProgramEducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentProgramEvaluation_EducationOrganizationId ON edfi.StudentProgramEvaluation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentSchoolAssociation_SchoolId ON edfi.StudentSchoolAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentSchoolAssociation_EducationOrganizationId ON edfi.StudentSchoolAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentSchoolAttendanceEvent_SchoolId ON edfi.StudentSchoolAttendanceEvent(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentSectionAssociation_SchoolId ON edfi.StudentSectionAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentSectionAttendanceEvent_SchoolId ON edfi.StudentSectionAttendanceEvent(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganizationId ON edfi.StudentSpecialEducationProgramEligibilityAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Survey_EducationOrganizationId ON edfi.Survey(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_Survey_SchoolId ON edfi.Survey(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_SurveyCourseAssociation_EducationOrganizationId ON edfi.SurveyCourseAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_SurveyProgramAssociation_EducationOrganizationId ON edfi.SurveyProgramAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON edfi.SurveyResponseEducationOrganizationTargetAssociation(EducationOrganizationId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_SurveySectionAssociation_SchoolId ON edfi.SurveySectionAssociation(SchoolId) INCLUDE (Id);

CREATE INDEX IF NOT EXISTS IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation(EducationOrganizationId) INCLUDE (Id);