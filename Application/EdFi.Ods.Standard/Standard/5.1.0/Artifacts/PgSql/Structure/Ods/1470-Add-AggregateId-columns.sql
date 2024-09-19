-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/* Generated with SSMS using:
------------------------------------------------
	SELECT 'CREATE SEQUENCE ' + LOWER(c.TABLE_SCHEMA) + '.' + LOWER(c.TABLE_NAME) + '_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
	ALTER TABLE ' + c.TABLE_SCHEMA + '.' + c.TABLE_NAME + ' ADD COLUMN AggregateId int NOT NULL DEFAULT nextval(''' + LOWER(c.TABLE_SCHEMA) + '.' + LOWER(c.TABLE_NAME) + '_aggseq'');
	CREATE INDEX ix_' + LOWER(c.TABLE_NAME) + '_aggid ON ' + c.TABLE_SCHEMA + '.' + c.TABLE_NAME + ' (AggregateId);' AS PostgreSQL
	FROM INFORMATION_SCHEMA.COLUMNS c
	WHERE c.COLUMN_NAME = 'Id' and c.TABLE_SCHEMA = @schema
	ORDER BY c.TABLE_SCHEMA, c.TABLE_NAME
------------------------------------------------
*/

CREATE SEQUENCE edfi.academicweek_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AcademicWeek ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.academicweek_aggseq');
CREATE INDEX ix_academicweek_aggid ON edfi.AcademicWeek (AggregateId);

CREATE SEQUENCE edfi.accountabilityrating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AccountabilityRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.accountabilityrating_aggseq');
CREATE INDEX ix_accountabilityrating_aggid ON edfi.AccountabilityRating (AggregateId);

CREATE SEQUENCE edfi.assessment_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Assessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.assessment_aggseq');
CREATE INDEX ix_assessment_aggid ON edfi.Assessment (AggregateId);

CREATE SEQUENCE edfi.assessmentitem_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentItem ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.assessmentitem_aggseq');
CREATE INDEX ix_assessmentitem_aggid ON edfi.AssessmentItem (AggregateId);

CREATE SEQUENCE edfi.assessmentscorerangelearningstandard_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.assessmentscorerangelearningstandard_aggseq');
CREATE INDEX ix_assessmentscorerangelearningstandard_aggid ON edfi.AssessmentScoreRangeLearningStandard (AggregateId);

CREATE SEQUENCE edfi.balancesheetdimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.BalanceSheetDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.balancesheetdimension_aggseq');
CREATE INDEX ix_balancesheetdimension_aggid ON edfi.BalanceSheetDimension (AggregateId);

CREATE SEQUENCE edfi.bellschedule_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.BellSchedule ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.bellschedule_aggseq');
CREATE INDEX ix_bellschedule_aggid ON edfi.BellSchedule (AggregateId);

CREATE SEQUENCE edfi.calendar_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Calendar ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.calendar_aggseq');
CREATE INDEX ix_calendar_aggid ON edfi.Calendar (AggregateId);

CREATE SEQUENCE edfi.calendardate_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CalendarDate ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.calendardate_aggseq');
CREATE INDEX ix_calendardate_aggid ON edfi.CalendarDate (AggregateId);

CREATE SEQUENCE edfi.chartofaccount_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ChartOfAccount ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.chartofaccount_aggseq');
CREATE INDEX ix_chartofaccount_aggid ON edfi.ChartOfAccount (AggregateId);

CREATE SEQUENCE edfi.classperiod_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ClassPeriod ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.classperiod_aggseq');
CREATE INDEX ix_classperiod_aggid ON edfi.ClassPeriod (AggregateId);

CREATE SEQUENCE edfi.cohort_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Cohort ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.cohort_aggseq');
CREATE INDEX ix_cohort_aggid ON edfi.Cohort (AggregateId);

CREATE SEQUENCE edfi.communityproviderlicense_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CommunityProviderLicense ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.communityproviderlicense_aggseq');
CREATE INDEX ix_communityproviderlicense_aggid ON edfi.CommunityProviderLicense (AggregateId);

CREATE SEQUENCE edfi.competencyobjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CompetencyObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.competencyobjective_aggseq');
CREATE INDEX ix_competencyobjective_aggid ON edfi.CompetencyObjective (AggregateId);

CREATE SEQUENCE edfi.contact_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Contact ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.contact_aggseq');
CREATE INDEX ix_contact_aggid ON edfi.Contact (AggregateId);

CREATE SEQUENCE edfi.course_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Course ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.course_aggseq');
CREATE INDEX ix_course_aggid ON edfi.Course (AggregateId);

CREATE SEQUENCE edfi.courseoffering_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CourseOffering ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.courseoffering_aggseq');
CREATE INDEX ix_courseoffering_aggid ON edfi.CourseOffering (AggregateId);

CREATE SEQUENCE edfi.coursetranscript_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CourseTranscript ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.coursetranscript_aggseq');
CREATE INDEX ix_coursetranscript_aggid ON edfi.CourseTranscript (AggregateId);

CREATE SEQUENCE edfi.credential_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Credential ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.credential_aggseq');
CREATE INDEX ix_credential_aggid ON edfi.Credential (AggregateId);

CREATE SEQUENCE edfi.crisisevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CrisisEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.crisisevent_aggseq');
CREATE INDEX ix_crisisevent_aggid ON edfi.CrisisEvent (AggregateId);

CREATE SEQUENCE edfi.descriptor_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Descriptor ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.descriptor_aggseq');
CREATE INDEX ix_descriptor_aggid ON edfi.Descriptor (AggregateId);

CREATE SEQUENCE edfi.descriptormapping_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DescriptorMapping ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.descriptormapping_aggseq');
CREATE INDEX ix_descriptormapping_aggid ON edfi.DescriptorMapping (AggregateId);

CREATE SEQUENCE edfi.disciplineaction_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DisciplineAction ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.disciplineaction_aggseq');
CREATE INDEX ix_disciplineaction_aggid ON edfi.DisciplineAction (AggregateId);

CREATE SEQUENCE edfi.disciplineincident_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DisciplineIncident ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.disciplineincident_aggseq');
CREATE INDEX ix_disciplineincident_aggid ON edfi.DisciplineIncident (AggregateId);

CREATE SEQUENCE edfi.educationcontent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationContent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationcontent_aggseq');
CREATE INDEX ix_educationcontent_aggid ON edfi.EducationContent (AggregateId);

CREATE SEQUENCE edfi.educationorganization_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganization ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganization_aggseq');
CREATE INDEX ix_educationorganization_aggid ON edfi.EducationOrganization (AggregateId);

CREATE SEQUENCE edfi.educationorganizationinterventionprescriptionassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganizationinterventionprescriptionassociation_aggseq');
CREATE INDEX ix_educationorganizationinterventionprescriptionassociation_aggid ON edfi.EducationOrganizationInterventionPrescriptionAssociation (AggregateId);

CREATE SEQUENCE edfi.educationorganizationnetworkassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganizationnetworkassociation_aggseq');
CREATE INDEX ix_educationorganizationnetworkassociation_aggid ON edfi.EducationOrganizationNetworkAssociation (AggregateId);

CREATE SEQUENCE edfi.educationorganizationpeerassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganizationpeerassociation_aggseq');
CREATE INDEX ix_educationorganizationpeerassociation_aggid ON edfi.EducationOrganizationPeerAssociation (AggregateId);

CREATE SEQUENCE edfi.evaluationrubricdimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationRubricDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.evaluationrubricdimension_aggseq');
CREATE INDEX ix_evaluationrubricdimension_aggid ON edfi.EvaluationRubricDimension (AggregateId);

CREATE SEQUENCE edfi.feederschoolassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FeederSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.feederschoolassociation_aggseq');
CREATE INDEX ix_feederschoolassociation_aggid ON edfi.FeederSchoolAssociation (AggregateId);

CREATE SEQUENCE edfi.functiondimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FunctionDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.functiondimension_aggseq');
CREATE INDEX ix_functiondimension_aggid ON edfi.FunctionDimension (AggregateId);

CREATE SEQUENCE edfi.funddimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FundDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.funddimension_aggseq');
CREATE INDEX ix_funddimension_aggid ON edfi.FundDimension (AggregateId);

CREATE SEQUENCE edfi.generalstudentprogramassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GeneralStudentProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.generalstudentprogramassociation_aggseq');
CREATE INDEX ix_generalstudentprogramassociation_aggid ON edfi.GeneralStudentProgramAssociation (AggregateId);

CREATE SEQUENCE edfi.grade_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Grade ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.grade_aggseq');
CREATE INDEX ix_grade_aggid ON edfi.Grade (AggregateId);

CREATE SEQUENCE edfi.gradebookentry_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GradebookEntry ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.gradebookentry_aggseq');
CREATE INDEX ix_gradebookentry_aggid ON edfi.GradebookEntry (AggregateId);

CREATE SEQUENCE edfi.gradingperiod_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GradingPeriod ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.gradingperiod_aggseq');
CREATE INDEX ix_gradingperiod_aggid ON edfi.GradingPeriod (AggregateId);

CREATE SEQUENCE edfi.graduationplan_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GraduationPlan ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.graduationplan_aggseq');
CREATE INDEX ix_graduationplan_aggid ON edfi.GraduationPlan (AggregateId);

CREATE SEQUENCE edfi.intervention_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Intervention ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.intervention_aggseq');
CREATE INDEX ix_intervention_aggid ON edfi.Intervention (AggregateId);

CREATE SEQUENCE edfi.interventionprescription_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.InterventionPrescription ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.interventionprescription_aggseq');
CREATE INDEX ix_interventionprescription_aggid ON edfi.InterventionPrescription (AggregateId);

CREATE SEQUENCE edfi.interventionstudy_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.InterventionStudy ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.interventionstudy_aggseq');
CREATE INDEX ix_interventionstudy_aggid ON edfi.InterventionStudy (AggregateId);

CREATE SEQUENCE edfi.learningstandard_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LearningStandard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.learningstandard_aggseq');
CREATE INDEX ix_learningstandard_aggid ON edfi.LearningStandard (AggregateId);

CREATE SEQUENCE edfi.learningstandardequivalenceassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.learningstandardequivalenceassociation_aggseq');
CREATE INDEX ix_learningstandardequivalenceassociation_aggid ON edfi.LearningStandardEquivalenceAssociation (AggregateId);

CREATE SEQUENCE edfi.localaccount_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalAccount ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localaccount_aggseq');
CREATE INDEX ix_localaccount_aggid ON edfi.LocalAccount (AggregateId);

CREATE SEQUENCE edfi.localactual_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalActual ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localactual_aggseq');
CREATE INDEX ix_localactual_aggid ON edfi.LocalActual (AggregateId);

CREATE SEQUENCE edfi.localbudget_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalBudget ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localbudget_aggseq');
CREATE INDEX ix_localbudget_aggid ON edfi.LocalBudget (AggregateId);

CREATE SEQUENCE edfi.localcontractedstaff_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalContractedStaff ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localcontractedstaff_aggseq');
CREATE INDEX ix_localcontractedstaff_aggid ON edfi.LocalContractedStaff (AggregateId);

CREATE SEQUENCE edfi.localencumbrance_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalEncumbrance ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localencumbrance_aggseq');
CREATE INDEX ix_localencumbrance_aggid ON edfi.LocalEncumbrance (AggregateId);

CREATE SEQUENCE edfi.localpayroll_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalPayroll ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localpayroll_aggseq');
CREATE INDEX ix_localpayroll_aggid ON edfi.LocalPayroll (AggregateId);

CREATE SEQUENCE edfi.location_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Location ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.location_aggseq');
CREATE INDEX ix_location_aggid ON edfi.Location (AggregateId);

CREATE SEQUENCE edfi.objectdimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ObjectDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.objectdimension_aggseq');
CREATE INDEX ix_objectdimension_aggid ON edfi.ObjectDimension (AggregateId);

CREATE SEQUENCE edfi.objectiveassessment_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ObjectiveAssessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.objectiveassessment_aggseq');
CREATE INDEX ix_objectiveassessment_aggid ON edfi.ObjectiveAssessment (AggregateId);

CREATE SEQUENCE edfi.openstaffposition_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OpenStaffPosition ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.openstaffposition_aggseq');
CREATE INDEX ix_openstaffposition_aggid ON edfi.OpenStaffPosition (AggregateId);

CREATE SEQUENCE edfi.operationalunitdimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OperationalUnitDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.operationalunitdimension_aggseq');
CREATE INDEX ix_operationalunitdimension_aggid ON edfi.OperationalUnitDimension (AggregateId);

CREATE SEQUENCE edfi.person_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Person ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.person_aggseq');
CREATE INDEX ix_person_aggid ON edfi.Person (AggregateId);

CREATE SEQUENCE edfi.postsecondaryevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PostSecondaryEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.postsecondaryevent_aggseq');
CREATE INDEX ix_postsecondaryevent_aggid ON edfi.PostSecondaryEvent (AggregateId);

CREATE SEQUENCE edfi.program_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Program ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.program_aggseq');
CREATE INDEX ix_program_aggid ON edfi.Program (AggregateId);

CREATE SEQUENCE edfi.programdimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programdimension_aggseq');
CREATE INDEX ix_programdimension_aggid ON edfi.ProgramDimension (AggregateId);

CREATE SEQUENCE edfi.programevaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programevaluation_aggseq');
CREATE INDEX ix_programevaluation_aggid ON edfi.ProgramEvaluation (AggregateId);

CREATE SEQUENCE edfi.programevaluationelement_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluationElement ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programevaluationelement_aggseq');
CREATE INDEX ix_programevaluationelement_aggid ON edfi.ProgramEvaluationElement (AggregateId);

CREATE SEQUENCE edfi.programevaluationobjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluationObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programevaluationobjective_aggseq');
CREATE INDEX ix_programevaluationobjective_aggid ON edfi.ProgramEvaluationObjective (AggregateId);

CREATE SEQUENCE edfi.projectdimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProjectDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.projectdimension_aggseq');
CREATE INDEX ix_projectdimension_aggid ON edfi.ProjectDimension (AggregateId);

CREATE SEQUENCE edfi.reportcard_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ReportCard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.reportcard_aggseq');
CREATE INDEX ix_reportcard_aggid ON edfi.ReportCard (AggregateId);

CREATE SEQUENCE edfi.restraintevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.RestraintEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.restraintevent_aggseq');
CREATE INDEX ix_restraintevent_aggid ON edfi.RestraintEvent (AggregateId);

CREATE SEQUENCE edfi.schoolyeartype_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SchoolYearType ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.schoolyeartype_aggseq');
CREATE INDEX ix_schoolyeartype_aggid ON edfi.SchoolYearType (AggregateId);

CREATE SEQUENCE edfi.section_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Section ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.section_aggseq');
CREATE INDEX ix_section_aggid ON edfi.Section (AggregateId);

CREATE SEQUENCE edfi.sectionattendancetakenevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SectionAttendanceTakenEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.sectionattendancetakenevent_aggseq');
CREATE INDEX ix_sectionattendancetakenevent_aggid ON edfi.SectionAttendanceTakenEvent (AggregateId);

CREATE SEQUENCE edfi.session_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Session ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.session_aggseq');
CREATE INDEX ix_session_aggid ON edfi.Session (AggregateId);

CREATE SEQUENCE edfi.sourcedimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SourceDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.sourcedimension_aggseq');
CREATE INDEX ix_sourcedimension_aggid ON edfi.SourceDimension (AggregateId);

CREATE SEQUENCE edfi.staff_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Staff ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staff_aggseq');
CREATE INDEX ix_staff_aggid ON edfi.Staff (AggregateId);

CREATE SEQUENCE edfi.staffabsenceevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffAbsenceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffabsenceevent_aggseq');
CREATE INDEX ix_staffabsenceevent_aggid ON edfi.StaffAbsenceEvent (AggregateId);

CREATE SEQUENCE edfi.staffcohortassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffCohortAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffcohortassociation_aggseq');
CREATE INDEX ix_staffcohortassociation_aggid ON edfi.StaffCohortAssociation (AggregateId);

CREATE SEQUENCE edfi.staffdisciplineincidentassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffdisciplineincidentassociation_aggseq');
CREATE INDEX ix_staffdisciplineincidentassociation_aggid ON edfi.StaffDisciplineIncidentAssociation (AggregateId);

CREATE SEQUENCE edfi.staffeducationorganizationassignmentassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffeducationorganizationassignmentassociation_aggseq');
CREATE INDEX ix_staffeducationorganizationassignmentassociation_aggid ON edfi.StaffEducationOrganizationAssignmentAssociation (AggregateId);

CREATE SEQUENCE edfi.staffeducationorganizationcontactassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffeducationorganizationcontactassociation_aggseq');
CREATE INDEX ix_staffeducationorganizationcontactassociation_aggid ON edfi.StaffEducationOrganizationContactAssociation (AggregateId);

CREATE SEQUENCE edfi.staffeducationorganizationemploymentassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffeducationorganizationemploymentassociation_aggseq');
CREATE INDEX ix_staffeducationorganizationemploymentassociation_aggid ON edfi.StaffEducationOrganizationEmploymentAssociation (AggregateId);

CREATE SEQUENCE edfi.staffleave_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffLeave ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffleave_aggseq');
CREATE INDEX ix_staffleave_aggid ON edfi.StaffLeave (AggregateId);

CREATE SEQUENCE edfi.staffprogramassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffprogramassociation_aggseq');
CREATE INDEX ix_staffprogramassociation_aggid ON edfi.StaffProgramAssociation (AggregateId);

CREATE SEQUENCE edfi.staffschoolassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffschoolassociation_aggseq');
CREATE INDEX ix_staffschoolassociation_aggid ON edfi.StaffSchoolAssociation (AggregateId);

CREATE SEQUENCE edfi.staffsectionassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffSectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffsectionassociation_aggseq');
CREATE INDEX ix_staffsectionassociation_aggid ON edfi.StaffSectionAssociation (AggregateId);

CREATE SEQUENCE edfi.student_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Student ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.student_aggseq');
CREATE INDEX ix_student_aggid ON edfi.Student (AggregateId);

CREATE SEQUENCE edfi.studentacademicrecord_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAcademicRecord ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentacademicrecord_aggseq');
CREATE INDEX ix_studentacademicrecord_aggid ON edfi.StudentAcademicRecord (AggregateId);

CREATE SEQUENCE edfi.studentassessment_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentassessment_aggseq');
CREATE INDEX ix_studentassessment_aggid ON edfi.StudentAssessment (AggregateId);

CREATE SEQUENCE edfi.studentassessmenteducationorganizationassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentassessmenteducationorganizationassociation_aggseq');
CREATE INDEX ix_studentassessmenteducationorganizationassociation_aggid ON edfi.StudentAssessmentEducationOrganizationAssociation (AggregateId);

CREATE SEQUENCE edfi.studentcohortassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCohortAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentcohortassociation_aggseq');
CREATE INDEX ix_studentcohortassociation_aggid ON edfi.StudentCohortAssociation (AggregateId);

CREATE SEQUENCE edfi.studentcompetencyobjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCompetencyObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentcompetencyobjective_aggseq');
CREATE INDEX ix_studentcompetencyobjective_aggid ON edfi.StudentCompetencyObjective (AggregateId);

CREATE SEQUENCE edfi.studentcontactassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentContactAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentcontactassociation_aggseq');
CREATE INDEX ix_studentcontactassociation_aggid ON edfi.StudentContactAssociation (AggregateId);

CREATE SEQUENCE edfi.studentdisciplineincidentbehaviorassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentdisciplineincidentbehaviorassociation_aggseq');
CREATE INDEX ix_studentdisciplineincidentbehaviorassociation_aggid ON edfi.StudentDisciplineIncidentBehaviorAssociation (AggregateId);

CREATE SEQUENCE edfi.studentdisciplineincidentnonoffenderassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentdisciplineincidentnonoffenderassociation_aggseq');
CREATE INDEX ix_studentdisciplineincidentnonoffenderassociation_aggid ON edfi.StudentDisciplineIncidentNonOffenderAssociation (AggregateId);

CREATE SEQUENCE edfi.studenteducationorganizationassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenteducationorganizationassociation_aggseq');
CREATE INDEX ix_studenteducationorganizationassociation_aggid ON edfi.StudentEducationOrganizationAssociation (AggregateId);

CREATE SEQUENCE edfi.studenteducationorganizationresponsibilityassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenteducationorganizationresponsibilityassociation_aggseq');
CREATE INDEX ix_studenteducationorganizationresponsibilityassociation_aggid ON edfi.StudentEducationOrganizationResponsibilityAssociation (AggregateId);

CREATE SEQUENCE edfi.studentgradebookentry_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentGradebookEntry ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentgradebookentry_aggseq');
CREATE INDEX ix_studentgradebookentry_aggid ON edfi.StudentGradebookEntry (AggregateId);

CREATE SEQUENCE edfi.studenthealth_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentHealth ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenthealth_aggseq');
CREATE INDEX ix_studenthealth_aggid ON edfi.StudentHealth (AggregateId);

CREATE SEQUENCE edfi.studentinterventionassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentinterventionassociation_aggseq');
CREATE INDEX ix_studentinterventionassociation_aggid ON edfi.StudentInterventionAssociation (AggregateId);

CREATE SEQUENCE edfi.studentinterventionattendanceevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentinterventionattendanceevent_aggseq');
CREATE INDEX ix_studentinterventionattendanceevent_aggid ON edfi.StudentInterventionAttendanceEvent (AggregateId);

CREATE SEQUENCE edfi.studentprogramattendanceevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentProgramAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentprogramattendanceevent_aggseq');
CREATE INDEX ix_studentprogramattendanceevent_aggid ON edfi.StudentProgramAttendanceEvent (AggregateId);

CREATE SEQUENCE edfi.studentprogramevaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentProgramEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentprogramevaluation_aggseq');
CREATE INDEX ix_studentprogramevaluation_aggid ON edfi.StudentProgramEvaluation (AggregateId);

CREATE SEQUENCE edfi.studentschoolassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentschoolassociation_aggseq');
CREATE INDEX ix_studentschoolassociation_aggid ON edfi.StudentSchoolAssociation (AggregateId);

CREATE SEQUENCE edfi.studentschoolattendanceevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentschoolattendanceevent_aggseq');
CREATE INDEX ix_studentschoolattendanceevent_aggid ON edfi.StudentSchoolAttendanceEvent (AggregateId);

CREATE SEQUENCE edfi.studentsectionassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentsectionassociation_aggseq');
CREATE INDEX ix_studentsectionassociation_aggid ON edfi.StudentSectionAssociation (AggregateId);

CREATE SEQUENCE edfi.studentsectionattendanceevent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSectionAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentsectionattendanceevent_aggseq');
CREATE INDEX ix_studentsectionattendanceevent_aggid ON edfi.StudentSectionAttendanceEvent (AggregateId);

CREATE SEQUENCE edfi.studentspecialeducationprogrameligibilityassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentspecialeducationprogrameligibilityassociation_aggseq');
CREATE INDEX ix_studentspecialeducationprogrameligibilityassociation_aggid ON edfi.StudentSpecialEducationProgramEligibilityAssociation (AggregateId);

CREATE SEQUENCE edfi.studenttransportation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentTransportation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenttransportation_aggseq');
CREATE INDEX ix_studenttransportation_aggid ON edfi.StudentTransportation (AggregateId);

CREATE SEQUENCE edfi.survey_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Survey ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.survey_aggseq');
CREATE INDEX ix_survey_aggid ON edfi.Survey (AggregateId);

CREATE SEQUENCE edfi.surveycourseassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyCourseAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveycourseassociation_aggseq');
CREATE INDEX ix_surveycourseassociation_aggid ON edfi.SurveyCourseAssociation (AggregateId);

CREATE SEQUENCE edfi.surveyprogramassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyprogramassociation_aggseq');
CREATE INDEX ix_surveyprogramassociation_aggid ON edfi.SurveyProgramAssociation (AggregateId);

CREATE SEQUENCE edfi.surveyquestion_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyQuestion ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyquestion_aggseq');
CREATE INDEX ix_surveyquestion_aggid ON edfi.SurveyQuestion (AggregateId);

CREATE SEQUENCE edfi.surveyquestionresponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyQuestionResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyquestionresponse_aggseq');
CREATE INDEX ix_surveyquestionresponse_aggid ON edfi.SurveyQuestionResponse (AggregateId);

CREATE SEQUENCE edfi.surveyresponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyresponse_aggseq');
CREATE INDEX ix_surveyresponse_aggid ON edfi.SurveyResponse (AggregateId);

CREATE SEQUENCE edfi.surveyresponseeducationorganizationtargetassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyresponseeducationorganizationtargetassociation_aggseq');
CREATE INDEX ix_surveyresponseeducationorganizationtargetassociation_aggid ON edfi.SurveyResponseEducationOrganizationTargetAssociation (AggregateId);

CREATE SEQUENCE edfi.surveyresponsestafftargetassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyresponsestafftargetassociation_aggseq');
CREATE INDEX ix_surveyresponsestafftargetassociation_aggid ON edfi.SurveyResponseStaffTargetAssociation (AggregateId);

CREATE SEQUENCE edfi.surveysection_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySection ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysection_aggseq');
CREATE INDEX ix_surveysection_aggid ON edfi.SurveySection (AggregateId);

CREATE SEQUENCE edfi.surveysectionassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionassociation_aggseq');
CREATE INDEX ix_surveysectionassociation_aggid ON edfi.SurveySectionAssociation (AggregateId);

CREATE SEQUENCE edfi.surveysectionresponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionresponse_aggseq');
CREATE INDEX ix_surveysectionresponse_aggid ON edfi.SurveySectionResponse (AggregateId);

CREATE SEQUENCE edfi.surveysectionresponseeducationorganizationtargetassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionresponseeducationorganizationtargetassociation_aggseq');
CREATE INDEX ix_surveysectionresponseeducationorganizationtargetassociation_aggid ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation (AggregateId);

CREATE SEQUENCE edfi.surveysectionresponsestafftargetassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionresponsestafftargetassociation_aggseq');
CREATE INDEX ix_surveysectionresponsestafftargetassociation_aggid ON edfi.SurveySectionResponseStaffTargetAssociation (AggregateId);
