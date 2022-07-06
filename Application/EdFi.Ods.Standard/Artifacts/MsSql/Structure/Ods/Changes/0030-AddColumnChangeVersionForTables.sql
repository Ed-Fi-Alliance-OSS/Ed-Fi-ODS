-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AcademicWeek]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[AcademicWeek] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Account]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Account] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AccountCode]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[AccountCode] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AccountabilityRating]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[AccountabilityRating] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Actual]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Actual] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Assessment]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Assessment] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AssessmentItem]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[AssessmentItem] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[AssessmentScoreRangeLearningStandard]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[BellSchedule]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[BellSchedule] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Budget]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Budget] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Calendar]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Calendar] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CalendarDate]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[CalendarDate] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ClassPeriod]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[ClassPeriod] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Cohort]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Cohort] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CommunityProviderLicense]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[CommunityProviderLicense] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CompetencyObjective]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[CompetencyObjective] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ContractedStaff]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[ContractedStaff] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Course]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Course] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CourseOffering]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[CourseOffering] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[CourseTranscript]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[CourseTranscript] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Credential]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Credential] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Descriptor]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Descriptor] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[DisciplineAction]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[DisciplineAction] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[DisciplineIncident]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[DisciplineIncident] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationContent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[EducationContent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganization]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[EducationOrganization] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganizationInterventionPrescriptionAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganizationNetworkAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[EducationOrganizationPeerAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[FeederSchoolAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GeneralStudentProgramAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Grade]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Grade] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GradebookEntry]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[GradebookEntry] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GradingPeriod]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[GradingPeriod] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[GraduationPlan]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[GraduationPlan] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Intervention]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Intervention] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[InterventionPrescription]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[InterventionPrescription] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[InterventionStudy]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[InterventionStudy] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LearningObjective]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[LearningObjective] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LearningStandard]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[LearningStandard] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[LearningStandardEquivalenceAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Location]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Location] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ObjectiveAssessment]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[ObjectiveAssessment] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[OpenStaffPosition]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[OpenStaffPosition] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Parent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Parent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Payroll]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Payroll] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Person]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Person] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[PostSecondaryEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[PostSecondaryEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Program]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Program] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[ReportCard]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[ReportCard] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[RestraintEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[RestraintEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SchoolYearType]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SchoolYearType] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Section]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Section] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SectionAttendanceTakenEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Session]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Session] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Staff]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Staff] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffAbsenceEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffCohortAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffCohortAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffDisciplineIncidentAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffEducationOrganizationAssignmentAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffEducationOrganizationContactAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffEducationOrganizationEmploymentAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffLeave]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffLeave] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffProgramAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffProgramAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffSchoolAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StaffSectionAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StaffSectionAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Student]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Student] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentAcademicRecord]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentAcademicRecord] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentAssessment]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentAssessment] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentCohortAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentCohortAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentCompetencyObjective]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentDisciplineIncidentAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentDisciplineIncidentBehaviorAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentDisciplineIncidentNonOffenderAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentEducationOrganizationAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentEducationOrganizationResponsibilityAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentGradebookEntry]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentGradebookEntry] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentInterventionAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentInterventionAttendanceEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentLearningObjective]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentLearningObjective] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentParentAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentParentAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentProgramAttendanceEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSchoolAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSchoolAttendanceEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSectionAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentSectionAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[StudentSectionAttendanceEvent]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[Survey]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[Survey] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyCourseAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyProgramAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyQuestion]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveyQuestion] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyQuestionResponse]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyResponse]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveyResponse] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyResponseEducationOrganizationTargetAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveyResponseStaffTargetAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySection]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveySection] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveySectionAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionResponse]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveySectionResponse] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[edfi].[SurveySectionResponseStaffTargetAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

