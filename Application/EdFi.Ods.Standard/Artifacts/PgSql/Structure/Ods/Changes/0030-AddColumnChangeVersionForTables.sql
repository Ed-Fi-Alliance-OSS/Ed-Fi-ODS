-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='AcademicWeek' AND column_name='changeversion') THEN
ALTER TABLE edfi.AcademicWeek
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Account' AND column_name='changeversion') THEN
ALTER TABLE edfi.Account
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='AccountCode' AND column_name='changeversion') THEN
ALTER TABLE edfi.AccountCode
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='AccountabilityRating' AND column_name='changeversion') THEN
ALTER TABLE edfi.AccountabilityRating
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Actual' AND column_name='changeversion') THEN
ALTER TABLE edfi.Actual
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Assessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.Assessment
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='AssessmentItem' AND column_name='changeversion') THEN
ALTER TABLE edfi.AssessmentItem
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='AssessmentScoreRangeLearningStandard' AND column_name='changeversion') THEN
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='BellSchedule' AND column_name='changeversion') THEN
ALTER TABLE edfi.BellSchedule
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Budget' AND column_name='changeversion') THEN
ALTER TABLE edfi.Budget
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Calendar' AND column_name='changeversion') THEN
ALTER TABLE edfi.Calendar
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='CalendarDate' AND column_name='changeversion') THEN
ALTER TABLE edfi.CalendarDate
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='ClassPeriod' AND column_name='changeversion') THEN
ALTER TABLE edfi.ClassPeriod
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Cohort' AND column_name='changeversion') THEN
ALTER TABLE edfi.Cohort
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='CommunityProviderLicense' AND column_name='changeversion') THEN
ALTER TABLE edfi.CommunityProviderLicense
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='CompetencyObjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.CompetencyObjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='ContractedStaff' AND column_name='changeversion') THEN
ALTER TABLE edfi.ContractedStaff
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Course' AND column_name='changeversion') THEN
ALTER TABLE edfi.Course
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='CourseOffering' AND column_name='changeversion') THEN
ALTER TABLE edfi.CourseOffering
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='CourseTranscript' AND column_name='changeversion') THEN
ALTER TABLE edfi.CourseTranscript
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Credential' AND column_name='changeversion') THEN
ALTER TABLE edfi.Credential
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Descriptor' AND column_name='changeversion') THEN
ALTER TABLE edfi.Descriptor
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='DisciplineAction' AND column_name='changeversion') THEN
ALTER TABLE edfi.DisciplineAction
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='DisciplineIncident' AND column_name='changeversion') THEN
ALTER TABLE edfi.DisciplineIncident
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='EducationContent' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationContent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='EducationOrganization' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganization
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='EducationOrganizationInterventionPrescriptionAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='EducationOrganizationNetworkAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganizationNetworkAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='EducationOrganizationPeerAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganizationPeerAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='FeederSchoolAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.FeederSchoolAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='GeneralStudentProgramAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.GeneralStudentProgramAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Grade' AND column_name='changeversion') THEN
ALTER TABLE edfi.Grade
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='GradebookEntry' AND column_name='changeversion') THEN
ALTER TABLE edfi.GradebookEntry
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='GradingPeriod' AND column_name='changeversion') THEN
ALTER TABLE edfi.GradingPeriod
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='GraduationPlan' AND column_name='changeversion') THEN
ALTER TABLE edfi.GraduationPlan
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Intervention' AND column_name='changeversion') THEN
ALTER TABLE edfi.Intervention
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='InterventionPrescription' AND column_name='changeversion') THEN
ALTER TABLE edfi.InterventionPrescription
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='InterventionStudy' AND column_name='changeversion') THEN
ALTER TABLE edfi.InterventionStudy
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='LearningObjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.LearningObjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='LearningStandard' AND column_name='changeversion') THEN
ALTER TABLE edfi.LearningStandard
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='LearningStandardEquivalenceAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.LearningStandardEquivalenceAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Location' AND column_name='changeversion') THEN
ALTER TABLE edfi.Location
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='ObjectiveAssessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.ObjectiveAssessment
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='OpenStaffPosition' AND column_name='changeversion') THEN
ALTER TABLE edfi.OpenStaffPosition
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Parent' AND column_name='changeversion') THEN
ALTER TABLE edfi.Parent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Payroll' AND column_name='changeversion') THEN
ALTER TABLE edfi.Payroll
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Person' AND column_name='changeversion') THEN
ALTER TABLE edfi.Person
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='PostSecondaryEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.PostSecondaryEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Program' AND column_name='changeversion') THEN
ALTER TABLE edfi.Program
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='ReportCard' AND column_name='changeversion') THEN
ALTER TABLE edfi.ReportCard
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='RestraintEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.RestraintEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SchoolYearType' AND column_name='changeversion') THEN
ALTER TABLE edfi.SchoolYearType
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Section' AND column_name='changeversion') THEN
ALTER TABLE edfi.Section
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SectionAttendanceTakenEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.SectionAttendanceTakenEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Session' AND column_name='changeversion') THEN
ALTER TABLE edfi.Session
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Staff' AND column_name='changeversion') THEN
ALTER TABLE edfi.Staff
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffAbsenceEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffAbsenceEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffCohortAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffCohortAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffDisciplineIncidentAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffDisciplineIncidentAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffEducationOrganizationAssignmentAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffEducationOrganizationContactAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffEducationOrganizationContactAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffEducationOrganizationEmploymentAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffLeave' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffLeave
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffProgramAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffProgramAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffSchoolAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffSchoolAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StaffSectionAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffSectionAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Student' AND column_name='changeversion') THEN
ALTER TABLE edfi.Student
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentAcademicRecord' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentAcademicRecord
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentAssessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentAssessment
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentCohortAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentCohortAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentCompetencyObjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentCompetencyObjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentDisciplineIncidentAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentDisciplineIncidentAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentDisciplineIncidentBehaviorAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentDisciplineIncidentNonOffenderAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentEducationOrganizationAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentEducationOrganizationAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentEducationOrganizationResponsibilityAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentGradebookEntry' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentGradebookEntry
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentInterventionAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentInterventionAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentInterventionAttendanceEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentInterventionAttendanceEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentLearningObjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentLearningObjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentParentAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentParentAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentProgramAttendanceEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentProgramAttendanceEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentSchoolAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSchoolAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentSchoolAttendanceEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSchoolAttendanceEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentSectionAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSectionAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='StudentSectionAttendanceEvent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSectionAttendanceEvent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='Survey' AND column_name='changeversion') THEN
ALTER TABLE edfi.Survey
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveyCourseAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyCourseAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveyProgramAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyProgramAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveyQuestion' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyQuestion
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveyQuestionResponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyQuestionResponse
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveyResponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyResponse
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveyResponseEducationOrganizationTargetAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveyResponseStaffTargetAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveySection' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySection
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveySectionAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveySectionResponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionResponse
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveySectionResponseEducationOrganizationTargetAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='SurveySectionResponseStaffTargetAssociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

END
$$;
