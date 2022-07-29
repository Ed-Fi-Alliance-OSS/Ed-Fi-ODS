-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='academicweek' AND column_name='changeversion') THEN
ALTER TABLE edfi.AcademicWeek ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.AcademicWeek ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='accountabilityrating' AND column_name='changeversion') THEN
ALTER TABLE edfi.AccountabilityRating ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.AccountabilityRating ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='assessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.Assessment ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Assessment ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='assessmentitem' AND column_name='changeversion') THEN
ALTER TABLE edfi.AssessmentItem ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.AssessmentItem ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='assessmentscorerangelearningstandard' AND column_name='changeversion') THEN
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='balancesheetdimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.BalanceSheetDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.BalanceSheetDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='bellschedule' AND column_name='changeversion') THEN
ALTER TABLE edfi.BellSchedule ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.BellSchedule ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='calendar' AND column_name='changeversion') THEN
ALTER TABLE edfi.Calendar ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Calendar ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='calendardate' AND column_name='changeversion') THEN
ALTER TABLE edfi.CalendarDate ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.CalendarDate ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='chartofaccount' AND column_name='changeversion') THEN
ALTER TABLE edfi.ChartOfAccount ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.ChartOfAccount ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='classperiod' AND column_name='changeversion') THEN
ALTER TABLE edfi.ClassPeriod ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.ClassPeriod ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='cohort' AND column_name='changeversion') THEN
ALTER TABLE edfi.Cohort ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Cohort ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='communityproviderlicense' AND column_name='changeversion') THEN
ALTER TABLE edfi.CommunityProviderLicense ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.CommunityProviderLicense ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='competencyobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.CompetencyObjective ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.CompetencyObjective ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='course' AND column_name='changeversion') THEN
ALTER TABLE edfi.Course ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Course ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='courseoffering' AND column_name='changeversion') THEN
ALTER TABLE edfi.CourseOffering ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.CourseOffering ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='coursetranscript' AND column_name='changeversion') THEN
ALTER TABLE edfi.CourseTranscript ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.CourseTranscript ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='credential' AND column_name='changeversion') THEN
ALTER TABLE edfi.Credential ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Credential ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='descriptor' AND column_name='changeversion') THEN
ALTER TABLE edfi.Descriptor ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Descriptor ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='descriptormapping' AND column_name='changeversion') THEN
ALTER TABLE edfi.DescriptorMapping ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.DescriptorMapping ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='disciplineaction' AND column_name='changeversion') THEN
ALTER TABLE edfi.DisciplineAction ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.DisciplineAction ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='disciplineincident' AND column_name='changeversion') THEN
ALTER TABLE edfi.DisciplineIncident ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.DisciplineIncident ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationcontent' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationContent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.EducationContent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganization' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganization ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.EducationOrganization ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganizationinterventionprescriptionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganizationnetworkassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganizationpeerassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.EducationOrganizationPeerAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='feederschoolassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.FeederSchoolAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.FeederSchoolAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='functiondimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.FunctionDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.FunctionDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='funddimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.FundDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.FundDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='generalstudentprogramassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.GeneralStudentProgramAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.GeneralStudentProgramAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='grade' AND column_name='changeversion') THEN
ALTER TABLE edfi.Grade ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Grade ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='gradebookentry' AND column_name='changeversion') THEN
ALTER TABLE edfi.GradebookEntry ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.GradebookEntry ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='gradingperiod' AND column_name='changeversion') THEN
ALTER TABLE edfi.GradingPeriod ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.GradingPeriod ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='graduationplan' AND column_name='changeversion') THEN
ALTER TABLE edfi.GraduationPlan ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.GraduationPlan ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='intervention' AND column_name='changeversion') THEN
ALTER TABLE edfi.Intervention ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Intervention ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='interventionprescription' AND column_name='changeversion') THEN
ALTER TABLE edfi.InterventionPrescription ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.InterventionPrescription ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='interventionstudy' AND column_name='changeversion') THEN
ALTER TABLE edfi.InterventionStudy ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.InterventionStudy ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='learningobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.LearningObjective ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LearningObjective ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='learningstandard' AND column_name='changeversion') THEN
ALTER TABLE edfi.LearningStandard ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LearningStandard ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='learningstandardequivalenceassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='localaccount' AND column_name='changeversion') THEN
ALTER TABLE edfi.LocalAccount ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LocalAccount ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='localactual' AND column_name='changeversion') THEN
ALTER TABLE edfi.LocalActual ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LocalActual ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='localbudget' AND column_name='changeversion') THEN
ALTER TABLE edfi.LocalBudget ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LocalBudget ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='localcontractedstaff' AND column_name='changeversion') THEN
ALTER TABLE edfi.LocalContractedStaff ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LocalContractedStaff ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='localencumbrance' AND column_name='changeversion') THEN
ALTER TABLE edfi.LocalEncumbrance ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LocalEncumbrance ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='localpayroll' AND column_name='changeversion') THEN
ALTER TABLE edfi.LocalPayroll ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.LocalPayroll ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='location' AND column_name='changeversion') THEN
ALTER TABLE edfi.Location ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Location ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='objectdimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.ObjectDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.ObjectDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='objectiveassessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.ObjectiveAssessment ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.ObjectiveAssessment ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='openstaffposition' AND column_name='changeversion') THEN
ALTER TABLE edfi.OpenStaffPosition ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.OpenStaffPosition ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='operationalunitdimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.OperationalUnitDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.OperationalUnitDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='parent' AND column_name='changeversion') THEN
ALTER TABLE edfi.Parent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Parent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='person' AND column_name='changeversion') THEN
ALTER TABLE edfi.Person ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Person ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='postsecondaryevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.PostSecondaryEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.PostSecondaryEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='program' AND column_name='changeversion') THEN
ALTER TABLE edfi.Program ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Program ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='programdimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.ProgramDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.ProgramDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='projectdimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.ProjectDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.ProjectDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='reportcard' AND column_name='changeversion') THEN
ALTER TABLE edfi.ReportCard ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.ReportCard ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='restraintevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.RestraintEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.RestraintEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='schoolyeartype' AND column_name='changeversion') THEN
ALTER TABLE edfi.SchoolYearType ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SchoolYearType ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='section' AND column_name='changeversion') THEN
ALTER TABLE edfi.Section ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Section ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='sectionattendancetakenevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.SectionAttendanceTakenEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SectionAttendanceTakenEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='session' AND column_name='changeversion') THEN
ALTER TABLE edfi.Session ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Session ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='sourcedimension' AND column_name='changeversion') THEN
ALTER TABLE edfi.SourceDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SourceDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staff' AND column_name='changeversion') THEN
ALTER TABLE edfi.Staff ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Staff ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffabsenceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffAbsenceEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffAbsenceEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffcohortassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffCohortAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffCohortAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffdisciplineincidentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffeducationorganizationassignmentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffeducationorganizationcontactassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffeducationorganizationemploymentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffleave' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffLeave ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffLeave ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffprogramassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffProgramAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffProgramAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffschoolassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffSchoolAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffSchoolAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffsectionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StaffSectionAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StaffSectionAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='student' AND column_name='changeversion') THEN
ALTER TABLE edfi.Student ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Student ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentacademicrecord' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentAcademicRecord ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentAcademicRecord ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentassessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentAssessment ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentAssessment ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentcohortassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentCohortAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentCohortAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentcompetencyobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentCompetencyObjective ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentCompetencyObjective ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentdisciplineincidentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentDisciplineIncidentAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentDisciplineIncidentAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentdisciplineincidentbehaviorassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentdisciplineincidentnonoffenderassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studenteducationorganizationassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentEducationOrganizationAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studenteducationorganizationresponsibilityassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentgradebookentry' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentGradebookEntry ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentGradebookEntry ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentinterventionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentInterventionAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentInterventionAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentinterventionattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentInterventionAttendanceEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentlearningobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentLearningObjective ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentLearningObjective ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentparentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentParentAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentParentAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentprogramattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentProgramAttendanceEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentProgramAttendanceEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentschoolassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSchoolAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentSchoolAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentschoolattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentSchoolAttendanceEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentsectionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSectionAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentSectionAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentsectionattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.StudentSectionAttendanceEvent ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.StudentSectionAttendanceEvent ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='survey' AND column_name='changeversion') THEN
ALTER TABLE edfi.Survey ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.Survey ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveycourseassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyCourseAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveyCourseAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyprogramassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyProgramAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveyProgramAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyquestion' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyQuestion ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveyQuestion ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyquestionresponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyQuestionResponse ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveyQuestionResponse ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyresponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyResponse ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveyResponse ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyresponseeducationorganizationtargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyresponsestafftargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysection' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySection ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveySection ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveySectionAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionresponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionResponse ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveySectionResponse ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionresponseeducationorganizationtargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionresponsestafftargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

END
$$;
