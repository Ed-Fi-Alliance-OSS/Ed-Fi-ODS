-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


DROP INDEX IF EXISTS IX_AcademicWeek_SchoolId;
CREATE INDEX IF NOT EXISTS IX_AcademicWeek_SchoolId ON edfi.AcademicWeek(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_AccountabilityRating_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_AccountabilityRating_EducationOrganizationId ON edfi.AccountabilityRating(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Assessment_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_Assessment_EducationOrganizationId ON edfi.Assessment(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_AssessmentAdministrationParticipation_AssigningEducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_AssessmentAdministrationParticipation_AssigningEducationOrganizationId ON edfi.AssessmentAdministrationParticipation(AssigningEducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_BellSchedule_SchoolId;
CREATE INDEX IF NOT EXISTS IX_BellSchedule_SchoolId ON edfi.BellSchedule(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Calendar_SchoolId;
CREATE INDEX IF NOT EXISTS IX_Calendar_SchoolId ON edfi.Calendar(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_CalendarDate_SchoolId;
CREATE INDEX IF NOT EXISTS IX_CalendarDate_SchoolId ON edfi.CalendarDate(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_ChartOfAccount_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_ChartOfAccount_EducationOrganizationId ON edfi.ChartOfAccount(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_ClassPeriod_SchoolId;
CREATE INDEX IF NOT EXISTS IX_ClassPeriod_SchoolId ON edfi.ClassPeriod(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Cohort_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_Cohort_EducationOrganizationId ON edfi.Cohort(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_CommunityProviderLicense_CommunityProviderId;
CREATE INDEX IF NOT EXISTS IX_CommunityProviderLicense_CommunityProviderId ON edfi.CommunityProviderLicense(CommunityProviderId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_CompetencyObjective_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_CompetencyObjective_EducationOrganizationId ON edfi.CompetencyObjective(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_Contact_ContactUSI ON edfi.Contact(ContactUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Course_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_Course_EducationOrganizationId ON edfi.Course(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_CourseOffering_SchoolId;
CREATE INDEX IF NOT EXISTS IX_CourseOffering_SchoolId ON edfi.CourseOffering(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_CourseOffering_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_CourseOffering_EducationOrganizationId ON edfi.CourseOffering(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_CourseTranscript_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_CourseTranscript_EducationOrganizationId ON edfi.CourseTranscript(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_CourseTranscript_StudentUSI ON edfi.CourseTranscript(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_CourseTranscript_ResponsibleTeacherStaffUSI ON edfi.CourseTranscript(ResponsibleTeacherStaffUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_DisciplineAction_StudentUSI ON edfi.DisciplineAction(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_DisciplineIncident_SchoolId;
CREATE INDEX IF NOT EXISTS IX_DisciplineIncident_SchoolId ON edfi.DisciplineIncident(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EducationOrganization_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EducationOrganization_EducationOrganizationId ON edfi.EducationOrganization(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganizationId ON edfi.EducationOrganizationInterventionPrescriptionAssociation(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EducationOrganizationNetworkAssociation_EducationOrganizationNetworkId;
CREATE INDEX IF NOT EXISTS IX_EducationOrganizationNetworkAssociation_EducationOrganizationNetworkId ON edfi.EducationOrganizationNetworkAssociation(EducationOrganizationNetworkId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EducationOrganizationPeerAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EducationOrganizationPeerAssociation_EducationOrganizationId ON edfi.EducationOrganizationPeerAssociation(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_EvaluationRubricDimension_ProgramEducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_EvaluationRubricDimension_ProgramEducationOrganizationId ON edfi.EvaluationRubricDimension(ProgramEducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_FeederSchoolAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_FeederSchoolAssociation_SchoolId ON edfi.FeederSchoolAssociation(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_GeneralStudentProgramAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_GeneralStudentProgramAssociation_EducationOrganizationId ON edfi.GeneralStudentProgramAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_GeneralStudentProgramAssociation_StudentUSI ON edfi.GeneralStudentProgramAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Grade_SchoolId;
CREATE INDEX IF NOT EXISTS IX_Grade_SchoolId ON edfi.Grade(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_Grade_StudentUSI ON edfi.Grade(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_GradebookEntry_SchoolId;
CREATE INDEX IF NOT EXISTS IX_GradebookEntry_SchoolId ON edfi.GradebookEntry(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_GradingPeriod_SchoolId;
CREATE INDEX IF NOT EXISTS IX_GradingPeriod_SchoolId ON edfi.GradingPeriod(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_GraduationPlan_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_GraduationPlan_EducationOrganizationId ON edfi.GraduationPlan(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Intervention_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_Intervention_EducationOrganizationId ON edfi.Intervention(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_InterventionPrescription_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_InterventionPrescription_EducationOrganizationId ON edfi.InterventionPrescription(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_InterventionStudy_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_InterventionStudy_EducationOrganizationId ON edfi.InterventionStudy(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_LocalAccount_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_LocalAccount_EducationOrganizationId ON edfi.LocalAccount(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_LocalActual_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_LocalActual_EducationOrganizationId ON edfi.LocalActual(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_LocalBudget_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_LocalBudget_EducationOrganizationId ON edfi.LocalBudget(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_LocalContractedStaff_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_LocalContractedStaff_EducationOrganizationId ON edfi.LocalContractedStaff(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_LocalContractedStaff_StaffUSI ON edfi.LocalContractedStaff(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_LocalEncumbrance_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_LocalEncumbrance_EducationOrganizationId ON edfi.LocalEncumbrance(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_LocalPayroll_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_LocalPayroll_EducationOrganizationId ON edfi.LocalPayroll(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_LocalPayroll_StaffUSI ON edfi.LocalPayroll(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Location_SchoolId;
CREATE INDEX IF NOT EXISTS IX_Location_SchoolId ON edfi.Location(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_OpenStaffPosition_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_OpenStaffPosition_EducationOrganizationId ON edfi.OpenStaffPosition(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_PostSecondaryEvent_PostSecondaryInstitutionId;
CREATE INDEX IF NOT EXISTS IX_PostSecondaryEvent_PostSecondaryInstitutionId ON edfi.PostSecondaryEvent(PostSecondaryInstitutionId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_PostSecondaryEvent_StudentUSI ON edfi.PostSecondaryEvent(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Program_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_Program_EducationOrganizationId ON edfi.Program(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_ProgramEvaluationElement_ProgramEducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_ProgramEvaluationElement_ProgramEducationOrganizationId ON edfi.ProgramEvaluationElement(ProgramEducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_ProgramEvaluationObjective_ProgramEducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_ProgramEvaluationObjective_ProgramEducationOrganizationId ON edfi.ProgramEvaluationObjective(ProgramEducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_ReportCard_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_ReportCard_EducationOrganizationId ON edfi.ReportCard(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_ReportCard_StudentUSI ON edfi.ReportCard(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_RestraintEvent_SchoolId;
CREATE INDEX IF NOT EXISTS IX_RestraintEvent_SchoolId ON edfi.RestraintEvent(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_RestraintEvent_StudentUSI ON edfi.RestraintEvent(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Section_SchoolId;
CREATE INDEX IF NOT EXISTS IX_Section_SchoolId ON edfi.Section(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_SectionAttendanceTakenEvent_SchoolId;
CREATE INDEX IF NOT EXISTS IX_SectionAttendanceTakenEvent_SchoolId ON edfi.SectionAttendanceTakenEvent(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_SectionAttendanceTakenEvent_StaffUSI ON edfi.SectionAttendanceTakenEvent(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Session_SchoolId;
CREATE INDEX IF NOT EXISTS IX_Session_SchoolId ON edfi.Session(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_Staff_StaffUSI ON edfi.Staff(StaffUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffAbsenceEvent_StaffUSI ON edfi.StaffAbsenceEvent(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StaffCohortAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StaffCohortAssociation_EducationOrganizationId ON edfi.StaffCohortAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffCohortAssociation_StaffUSI ON edfi.StaffCohortAssociation(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StaffDisciplineIncidentAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StaffDisciplineIncidentAssociation_SchoolId ON edfi.StaffDisciplineIncidentAssociation(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffDisciplineIncidentAssociation_StaffUSI ON edfi.StaffDisciplineIncidentAssociation(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationAssignmentAssociation_EducationOrganizationId ON edfi.StaffEducationOrganizationAssignmentAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationAssignmentAssociation_StaffUSI ON edfi.StaffEducationOrganizationAssignmentAssociation(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StaffEducationOrganizationContactAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationContactAssociation_EducationOrganizationId ON edfi.StaffEducationOrganizationContactAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationContactAssociation_StaffUSI ON edfi.StaffEducationOrganizationContactAssociation(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationEmploymentAssociation_EducationOrganizationId ON edfi.StaffEducationOrganizationEmploymentAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffEducationOrganizationEmploymentAssociation_StaffUSI ON edfi.StaffEducationOrganizationEmploymentAssociation(StaffUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffLeave_StaffUSI ON edfi.StaffLeave(StaffUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffProgramAssociation_StaffUSI ON edfi.StaffProgramAssociation(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StaffSchoolAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StaffSchoolAssociation_SchoolId ON edfi.StaffSchoolAssociation(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffSchoolAssociation_StaffUSI ON edfi.StaffSchoolAssociation(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StaffSectionAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StaffSectionAssociation_SchoolId ON edfi.StaffSectionAssociation(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StaffSectionAssociation_StaffUSI ON edfi.StaffSectionAssociation(StaffUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_Student_StudentUSI ON edfi.Student(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentAcademicRecord_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentAcademicRecord_EducationOrganizationId ON edfi.StudentAcademicRecord(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentAcademicRecord_StudentUSI ON edfi.StudentAcademicRecord(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentAssessment_StudentUSI ON edfi.StudentAssessment(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationId ON edfi.StudentAssessmentEducationOrganizationAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentEducationOrganizationAssociation_StudentUSI ON edfi.StudentAssessmentEducationOrganizationAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentAssessmentRegistration_AssigningEducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_AssigningEducationOrganizationId ON edfi.StudentAssessmentRegistration(AssigningEducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentAssessmentRegistration_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_EducationOrganizationId ON edfi.StudentAssessmentRegistration(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentAssessmentRegistration_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_SchoolId ON edfi.StudentAssessmentRegistration(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_StudentUSI ON edfi.StudentAssessmentRegistration(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistration_ScheduledStudentUSI ON edfi.StudentAssessmentRegistration(ScheduledStudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentAssessmentRegistrationBatteryPartAssociation_AssigningEducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistrationBatteryPartAssociation_AssigningEducationOrganizationId ON edfi.StudentAssessmentRegistrationBatteryPartAssociation(AssigningEducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentAssessmentRegistrationBatteryPartAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistrationBatteryPartAssociation_EducationOrganizationId ON edfi.StudentAssessmentRegistrationBatteryPartAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentAssessmentRegistrationBatteryPartAssociation_StudentUSI ON edfi.StudentAssessmentRegistrationBatteryPartAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentCohortAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentCohortAssociation_EducationOrganizationId ON edfi.StudentCohortAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentCohortAssociation_StudentUSI ON edfi.StudentCohortAssociation(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentCompetencyObjective_StudentUSI ON edfi.StudentCompetencyObjective(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentContactAssociation_ContactUSI ON edfi.StudentContactAssociation(ContactUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentContactAssociation_StudentUSI ON edfi.StudentContactAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StudentDisciplineIncidentBehaviorAssociation_SchoolId ON edfi.StudentDisciplineIncidentBehaviorAssociation(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentDisciplineIncidentBehaviorAssociation_StudentUSI ON edfi.StudentDisciplineIncidentBehaviorAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StudentDisciplineIncidentNonOffenderAssociation_SchoolId ON edfi.StudentDisciplineIncidentNonOffenderAssociation(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentDisciplineIncidentNonOffenderAssociation_StudentUSI ON edfi.StudentDisciplineIncidentNonOffenderAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentEducationOrganizationAssessmentAccommodation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationAssessmentAccommodation_EducationOrganizationId ON edfi.StudentEducationOrganizationAssessmentAccommodation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationAssessmentAccommodation_StudentUSI ON edfi.StudentEducationOrganizationAssessmentAccommodation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentEducationOrganizationAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationAssociation_EducationOrganizationId ON edfi.StudentEducationOrganizationAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationAssociation_StudentUSI ON edfi.StudentEducationOrganizationAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationResponsibilityAssociation_EducationOrganizationId ON edfi.StudentEducationOrganizationResponsibilityAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentEducationOrganizationResponsibilityAssociation_StudentUSI ON edfi.StudentEducationOrganizationResponsibilityAssociation(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentGradebookEntry_StudentUSI ON edfi.StudentGradebookEntry(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentHealth_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentHealth_EducationOrganizationId ON edfi.StudentHealth(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentHealth_StudentUSI ON edfi.StudentHealth(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentInterventionAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentInterventionAssociation_EducationOrganizationId ON edfi.StudentInterventionAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentInterventionAssociation_StudentUSI ON edfi.StudentInterventionAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentInterventionAttendanceEvent_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentInterventionAttendanceEvent_EducationOrganizationId ON edfi.StudentInterventionAttendanceEvent(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentInterventionAttendanceEvent_StudentUSI ON edfi.StudentInterventionAttendanceEvent(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentProgramAttendanceEvent_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentProgramAttendanceEvent_EducationOrganizationId ON edfi.StudentProgramAttendanceEvent(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentProgramAttendanceEvent_StudentUSI ON edfi.StudentProgramAttendanceEvent(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentProgramEvaluation_ProgramEducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentProgramEvaluation_ProgramEducationOrganizationId ON edfi.StudentProgramEvaluation(ProgramEducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentProgramEvaluation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentProgramEvaluation_EducationOrganizationId ON edfi.StudentProgramEvaluation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentProgramEvaluation_StudentUSI ON edfi.StudentProgramEvaluation(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentProgramEvaluation_StaffEvaluatorStaffUSI ON edfi.StudentProgramEvaluation(StaffEvaluatorStaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentSchoolAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StudentSchoolAssociation_SchoolId ON edfi.StudentSchoolAssociation(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentSchoolAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentSchoolAssociation_EducationOrganizationId ON edfi.StudentSchoolAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentSchoolAssociation_StudentUSI ON edfi.StudentSchoolAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentSchoolAttendanceEvent_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StudentSchoolAttendanceEvent_SchoolId ON edfi.StudentSchoolAttendanceEvent(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentSchoolAttendanceEvent_StudentUSI ON edfi.StudentSchoolAttendanceEvent(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentSectionAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StudentSectionAssociation_SchoolId ON edfi.StudentSectionAssociation(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentSectionAssociation_StudentUSI ON edfi.StudentSectionAssociation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentSectionAttendanceEvent_SchoolId;
CREATE INDEX IF NOT EXISTS IX_StudentSectionAttendanceEvent_SchoolId ON edfi.StudentSectionAttendanceEvent(SchoolId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentSectionAttendanceEvent_StudentUSI ON edfi.StudentSectionAttendanceEvent(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganizationId ON edfi.StudentSpecialEducationProgramEligibilityAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentSpecialEducationProgramEligibilityAssociation_StudentUSI ON edfi.StudentSpecialEducationProgramEligibilityAssociation(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentTransportation_StudentUSI ON edfi.StudentTransportation(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Survey_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_Survey_EducationOrganizationId ON edfi.Survey(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_Survey_SchoolId;
CREATE INDEX IF NOT EXISTS IX_Survey_SchoolId ON edfi.Survey(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_SurveyCourseAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_SurveyCourseAssociation_EducationOrganizationId ON edfi.SurveyCourseAssociation(EducationOrganizationId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_SurveyProgramAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_SurveyProgramAssociation_EducationOrganizationId ON edfi.SurveyProgramAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_SurveyResponse_ContactUSI ON edfi.SurveyResponse(ContactUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_SurveyResponse_StaffUSI ON edfi.SurveyResponse(StaffUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_SurveyResponse_StudentUSI ON edfi.SurveyResponse(StudentUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON edfi.SurveyResponseEducationOrganizationTargetAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_SurveyResponseStaffTargetAssociation_StaffUSI ON edfi.SurveyResponseStaffTargetAssociation(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_SurveySectionAssociation_SchoolId;
CREATE INDEX IF NOT EXISTS IX_SurveySectionAssociation_SchoolId ON edfi.SurveySectionAssociation(SchoolId) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganizationId ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_SurveySectionResponseStaffTargetAssociation_StaffUSI ON edfi.SurveySectionResponseStaffTargetAssociation(StaffUSI) INCLUDE (AggregateId);
