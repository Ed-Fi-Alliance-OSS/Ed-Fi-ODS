/* Generated with SSMS using:
------------------------------------------------
SELECT 'CREATE SEQUENCE ' + LOWER(c.TABLE_SCHEMA) + '.' + LOWER(c.TABLE_NAME) + '_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE ' + c.TABLE_SCHEMA + '.' + c.TABLE_NAME + ' ADD COLUMN AggregateId int NOT NULL DEFAULT nextval(''' + LOWER(c.TABLE_SCHEMA) + '.' + LOWER(c.TABLE_NAME) + 'agg_seq'');
CREATE INDEX ix_' + LOWER(c.TABLE_NAME) + '_aggid ON ' + c.TABLE_SCHEMA + '.' + c.TABLE_NAME + ' (AggregateId);'
FROM INFORMATION_SCHEMA.COLUMNS c
WHERE c.COLUMN_NAME = 'Id' and c.TABLE_SCHEMA = 'edfi'
ORDER BY c.TABLE_SCHEMA, c.TABLE_NAME
------------------------------------------------
*/

CREATE SEQUENCE edfi.academicweek_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AcademicWeek ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.academicweekagg_seq');
CREATE INDEX ix_academicweek_aggid ON edfi.AcademicWeek (AggregateId)

CREATE SEQUENCE edfi.accountabilityrating_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AccountabilityRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.accountabilityratingagg_seq');
CREATE INDEX ix_accountabilityrating_aggid ON edfi.AccountabilityRating (AggregateId)

CREATE SEQUENCE edfi.assessment_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Assessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.assessmentagg_seq');
CREATE INDEX ix_assessment_aggid ON edfi.Assessment (AggregateId)

CREATE SEQUENCE edfi.assessmentitem_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentItem ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.assessmentitemagg_seq');
CREATE INDEX ix_assessmentitem_aggid ON edfi.AssessmentItem (AggregateId)

CREATE SEQUENCE edfi.assessmentscorerangelearningstandard_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.assessmentscorerangelearningstandardagg_seq');
CREATE INDEX ix_assessmentscorerangelearningstandard_aggid ON edfi.AssessmentScoreRangeLearningStandard (AggregateId)

CREATE SEQUENCE edfi.balancesheetdimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.BalanceSheetDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.balancesheetdimensionagg_seq');
CREATE INDEX ix_balancesheetdimension_aggid ON edfi.BalanceSheetDimension (AggregateId)

CREATE SEQUENCE edfi.bellschedule_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.BellSchedule ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.bellscheduleagg_seq');
CREATE INDEX ix_bellschedule_aggid ON edfi.BellSchedule (AggregateId)

CREATE SEQUENCE edfi.calendar_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Calendar ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.calendaragg_seq');
CREATE INDEX ix_calendar_aggid ON edfi.Calendar (AggregateId)

CREATE SEQUENCE edfi.calendardate_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CalendarDate ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.calendardateagg_seq');
CREATE INDEX ix_calendardate_aggid ON edfi.CalendarDate (AggregateId)

CREATE SEQUENCE edfi.chartofaccount_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ChartOfAccount ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.chartofaccountagg_seq');
CREATE INDEX ix_chartofaccount_aggid ON edfi.ChartOfAccount (AggregateId)

CREATE SEQUENCE edfi.classperiod_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ClassPeriod ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.classperiodagg_seq');
CREATE INDEX ix_classperiod_aggid ON edfi.ClassPeriod (AggregateId)

CREATE SEQUENCE edfi.cohort_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Cohort ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.cohortagg_seq');
CREATE INDEX ix_cohort_aggid ON edfi.Cohort (AggregateId)

CREATE SEQUENCE edfi.communityproviderlicense_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CommunityProviderLicense ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.communityproviderlicenseagg_seq');
CREATE INDEX ix_communityproviderlicense_aggid ON edfi.CommunityProviderLicense (AggregateId)

CREATE SEQUENCE edfi.competencyobjective_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CompetencyObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.competencyobjectiveagg_seq');
CREATE INDEX ix_competencyobjective_aggid ON edfi.CompetencyObjective (AggregateId)

CREATE SEQUENCE edfi.contact_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Contact ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.contactagg_seq');
CREATE INDEX ix_contact_aggid ON edfi.Contact (AggregateId)

CREATE SEQUENCE edfi.course_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Course ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.courseagg_seq');
CREATE INDEX ix_course_aggid ON edfi.Course (AggregateId)

CREATE SEQUENCE edfi.courseoffering_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CourseOffering ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.courseofferingagg_seq');
CREATE INDEX ix_courseoffering_aggid ON edfi.CourseOffering (AggregateId)

CREATE SEQUENCE edfi.coursetranscript_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CourseTranscript ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.coursetranscriptagg_seq');
CREATE INDEX ix_coursetranscript_aggid ON edfi.CourseTranscript (AggregateId)

CREATE SEQUENCE edfi.credential_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Credential ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.credentialagg_seq');
CREATE INDEX ix_credential_aggid ON edfi.Credential (AggregateId)

CREATE SEQUENCE edfi.crisisevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CrisisEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.crisiseventagg_seq');
CREATE INDEX ix_crisisevent_aggid ON edfi.CrisisEvent (AggregateId)

CREATE SEQUENCE edfi.descriptor_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Descriptor ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.descriptoragg_seq');
CREATE INDEX ix_descriptor_aggid ON edfi.Descriptor (AggregateId)

CREATE SEQUENCE edfi.descriptormapping_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DescriptorMapping ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.descriptormappingagg_seq');
CREATE INDEX ix_descriptormapping_aggid ON edfi.DescriptorMapping (AggregateId)

CREATE SEQUENCE edfi.disciplineaction_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DisciplineAction ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.disciplineactionagg_seq');
CREATE INDEX ix_disciplineaction_aggid ON edfi.DisciplineAction (AggregateId)

CREATE SEQUENCE edfi.disciplineincident_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DisciplineIncident ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.disciplineincidentagg_seq');
CREATE INDEX ix_disciplineincident_aggid ON edfi.DisciplineIncident (AggregateId)

CREATE SEQUENCE edfi.educationcontent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationContent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationcontentagg_seq');
CREATE INDEX ix_educationcontent_aggid ON edfi.EducationContent (AggregateId)

CREATE SEQUENCE edfi.educationorganization_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganization ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganizationagg_seq');
CREATE INDEX ix_educationorganization_aggid ON edfi.EducationOrganization (AggregateId)

CREATE SEQUENCE edfi.educationorganizationinterventionprescriptionassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganizationinterventionprescriptionassociationagg_seq');
CREATE INDEX ix_educationorganizationinterventionprescriptionassociation_aggid ON edfi.EducationOrganizationInterventionPrescriptionAssociation (AggregateId)

CREATE SEQUENCE edfi.educationorganizationnetworkassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganizationnetworkassociationagg_seq');
CREATE INDEX ix_educationorganizationnetworkassociation_aggid ON edfi.EducationOrganizationNetworkAssociation (AggregateId)

CREATE SEQUENCE edfi.educationorganizationpeerassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.educationorganizationpeerassociationagg_seq');
CREATE INDEX ix_educationorganizationpeerassociation_aggid ON edfi.EducationOrganizationPeerAssociation (AggregateId)

CREATE SEQUENCE edfi.evaluationrubricdimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationRubricDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.evaluationrubricdimensionagg_seq');
CREATE INDEX ix_evaluationrubricdimension_aggid ON edfi.EvaluationRubricDimension (AggregateId)

CREATE SEQUENCE edfi.feederschoolassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FeederSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.feederschoolassociationagg_seq');
CREATE INDEX ix_feederschoolassociation_aggid ON edfi.FeederSchoolAssociation (AggregateId)

CREATE SEQUENCE edfi.functiondimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FunctionDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.functiondimensionagg_seq');
CREATE INDEX ix_functiondimension_aggid ON edfi.FunctionDimension (AggregateId)

CREATE SEQUENCE edfi.funddimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FundDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.funddimensionagg_seq');
CREATE INDEX ix_funddimension_aggid ON edfi.FundDimension (AggregateId)

CREATE SEQUENCE edfi.generalstudentprogramassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GeneralStudentProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.generalstudentprogramassociationagg_seq');
CREATE INDEX ix_generalstudentprogramassociation_aggid ON edfi.GeneralStudentProgramAssociation (AggregateId)

CREATE SEQUENCE edfi.grade_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Grade ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.gradeagg_seq');
CREATE INDEX ix_grade_aggid ON edfi.Grade (AggregateId)

CREATE SEQUENCE edfi.gradebookentry_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GradebookEntry ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.gradebookentryagg_seq');
CREATE INDEX ix_gradebookentry_aggid ON edfi.GradebookEntry (AggregateId)

CREATE SEQUENCE edfi.gradingperiod_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GradingPeriod ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.gradingperiodagg_seq');
CREATE INDEX ix_gradingperiod_aggid ON edfi.GradingPeriod (AggregateId)

CREATE SEQUENCE edfi.graduationplan_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GraduationPlan ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.graduationplanagg_seq');
CREATE INDEX ix_graduationplan_aggid ON edfi.GraduationPlan (AggregateId)

CREATE SEQUENCE edfi.intervention_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Intervention ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.interventionagg_seq');
CREATE INDEX ix_intervention_aggid ON edfi.Intervention (AggregateId)

CREATE SEQUENCE edfi.interventionprescription_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.InterventionPrescription ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.interventionprescriptionagg_seq');
CREATE INDEX ix_interventionprescription_aggid ON edfi.InterventionPrescription (AggregateId)

CREATE SEQUENCE edfi.interventionstudy_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.InterventionStudy ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.interventionstudyagg_seq');
CREATE INDEX ix_interventionstudy_aggid ON edfi.InterventionStudy (AggregateId)

CREATE SEQUENCE edfi.learningstandard_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LearningStandard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.learningstandardagg_seq');
CREATE INDEX ix_learningstandard_aggid ON edfi.LearningStandard (AggregateId)

CREATE SEQUENCE edfi.learningstandardequivalenceassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.learningstandardequivalenceassociationagg_seq');
CREATE INDEX ix_learningstandardequivalenceassociation_aggid ON edfi.LearningStandardEquivalenceAssociation (AggregateId)

CREATE SEQUENCE edfi.localaccount_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalAccount ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localaccountagg_seq');
CREATE INDEX ix_localaccount_aggid ON edfi.LocalAccount (AggregateId)

CREATE SEQUENCE edfi.localactual_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalActual ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localactualagg_seq');
CREATE INDEX ix_localactual_aggid ON edfi.LocalActual (AggregateId)

CREATE SEQUENCE edfi.localbudget_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalBudget ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localbudgetagg_seq');
CREATE INDEX ix_localbudget_aggid ON edfi.LocalBudget (AggregateId)

CREATE SEQUENCE edfi.localcontractedstaff_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalContractedStaff ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localcontractedstaffagg_seq');
CREATE INDEX ix_localcontractedstaff_aggid ON edfi.LocalContractedStaff (AggregateId)

CREATE SEQUENCE edfi.localencumbrance_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalEncumbrance ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localencumbranceagg_seq');
CREATE INDEX ix_localencumbrance_aggid ON edfi.LocalEncumbrance (AggregateId)

CREATE SEQUENCE edfi.localpayroll_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalPayroll ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.localpayrollagg_seq');
CREATE INDEX ix_localpayroll_aggid ON edfi.LocalPayroll (AggregateId)

CREATE SEQUENCE edfi.location_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Location ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.locationagg_seq');
CREATE INDEX ix_location_aggid ON edfi.Location (AggregateId)

CREATE SEQUENCE edfi.objectdimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ObjectDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.objectdimensionagg_seq');
CREATE INDEX ix_objectdimension_aggid ON edfi.ObjectDimension (AggregateId)

CREATE SEQUENCE edfi.objectiveassessment_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ObjectiveAssessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.objectiveassessmentagg_seq');
CREATE INDEX ix_objectiveassessment_aggid ON edfi.ObjectiveAssessment (AggregateId)

CREATE SEQUENCE edfi.openstaffposition_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OpenStaffPosition ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.openstaffpositionagg_seq');
CREATE INDEX ix_openstaffposition_aggid ON edfi.OpenStaffPosition (AggregateId)

CREATE SEQUENCE edfi.operationalunitdimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OperationalUnitDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.operationalunitdimensionagg_seq');
CREATE INDEX ix_operationalunitdimension_aggid ON edfi.OperationalUnitDimension (AggregateId)

CREATE SEQUENCE edfi.person_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Person ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.personagg_seq');
CREATE INDEX ix_person_aggid ON edfi.Person (AggregateId)

CREATE SEQUENCE edfi.postsecondaryevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PostSecondaryEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.postsecondaryeventagg_seq');
CREATE INDEX ix_postsecondaryevent_aggid ON edfi.PostSecondaryEvent (AggregateId)

CREATE SEQUENCE edfi.program_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Program ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programagg_seq');
CREATE INDEX ix_program_aggid ON edfi.Program (AggregateId)

CREATE SEQUENCE edfi.programdimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programdimensionagg_seq');
CREATE INDEX ix_programdimension_aggid ON edfi.ProgramDimension (AggregateId)

CREATE SEQUENCE edfi.programevaluation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programevaluationagg_seq');
CREATE INDEX ix_programevaluation_aggid ON edfi.ProgramEvaluation (AggregateId)

CREATE SEQUENCE edfi.programevaluationelement_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluationElement ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programevaluationelementagg_seq');
CREATE INDEX ix_programevaluationelement_aggid ON edfi.ProgramEvaluationElement (AggregateId)

CREATE SEQUENCE edfi.programevaluationobjective_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluationObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.programevaluationobjectiveagg_seq');
CREATE INDEX ix_programevaluationobjective_aggid ON edfi.ProgramEvaluationObjective (AggregateId)

CREATE SEQUENCE edfi.projectdimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProjectDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.projectdimensionagg_seq');
CREATE INDEX ix_projectdimension_aggid ON edfi.ProjectDimension (AggregateId)

CREATE SEQUENCE edfi.reportcard_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ReportCard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.reportcardagg_seq');
CREATE INDEX ix_reportcard_aggid ON edfi.ReportCard (AggregateId)

CREATE SEQUENCE edfi.restraintevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.RestraintEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.restrainteventagg_seq');
CREATE INDEX ix_restraintevent_aggid ON edfi.RestraintEvent (AggregateId)

CREATE SEQUENCE edfi.schoolyeartype_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SchoolYearType ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.schoolyeartypeagg_seq');
CREATE INDEX ix_schoolyeartype_aggid ON edfi.SchoolYearType (AggregateId)

CREATE SEQUENCE edfi.section_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Section ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.sectionagg_seq');
CREATE INDEX ix_section_aggid ON edfi.Section (AggregateId)

CREATE SEQUENCE edfi.sectionattendancetakenevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SectionAttendanceTakenEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.sectionattendancetakeneventagg_seq');
CREATE INDEX ix_sectionattendancetakenevent_aggid ON edfi.SectionAttendanceTakenEvent (AggregateId)

CREATE SEQUENCE edfi.session_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Session ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.sessionagg_seq');
CREATE INDEX ix_session_aggid ON edfi.Session (AggregateId)

CREATE SEQUENCE edfi.sourcedimension_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SourceDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.sourcedimensionagg_seq');
CREATE INDEX ix_sourcedimension_aggid ON edfi.SourceDimension (AggregateId)

CREATE SEQUENCE edfi.staff_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Staff ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffagg_seq');
CREATE INDEX ix_staff_aggid ON edfi.Staff (AggregateId)

CREATE SEQUENCE edfi.staffabsenceevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffAbsenceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffabsenceeventagg_seq');
CREATE INDEX ix_staffabsenceevent_aggid ON edfi.StaffAbsenceEvent (AggregateId)

CREATE SEQUENCE edfi.staffcohortassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffCohortAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffcohortassociationagg_seq');
CREATE INDEX ix_staffcohortassociation_aggid ON edfi.StaffCohortAssociation (AggregateId)

CREATE SEQUENCE edfi.staffdisciplineincidentassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffdisciplineincidentassociationagg_seq');
CREATE INDEX ix_staffdisciplineincidentassociation_aggid ON edfi.StaffDisciplineIncidentAssociation (AggregateId)

CREATE SEQUENCE edfi.staffeducationorganizationassignmentassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffeducationorganizationassignmentassociationagg_seq');
CREATE INDEX ix_staffeducationorganizationassignmentassociation_aggid ON edfi.StaffEducationOrganizationAssignmentAssociation (AggregateId)

CREATE SEQUENCE edfi.staffeducationorganizationcontactassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffeducationorganizationcontactassociationagg_seq');
CREATE INDEX ix_staffeducationorganizationcontactassociation_aggid ON edfi.StaffEducationOrganizationContactAssociation (AggregateId)

CREATE SEQUENCE edfi.staffeducationorganizationemploymentassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffeducationorganizationemploymentassociationagg_seq');
CREATE INDEX ix_staffeducationorganizationemploymentassociation_aggid ON edfi.StaffEducationOrganizationEmploymentAssociation (AggregateId)

CREATE SEQUENCE edfi.staffleave_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffLeave ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffleaveagg_seq');
CREATE INDEX ix_staffleave_aggid ON edfi.StaffLeave (AggregateId)

CREATE SEQUENCE edfi.staffprogramassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffprogramassociationagg_seq');
CREATE INDEX ix_staffprogramassociation_aggid ON edfi.StaffProgramAssociation (AggregateId)

CREATE SEQUENCE edfi.staffschoolassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffschoolassociationagg_seq');
CREATE INDEX ix_staffschoolassociation_aggid ON edfi.StaffSchoolAssociation (AggregateId)

CREATE SEQUENCE edfi.staffsectionassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffSectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.staffsectionassociationagg_seq');
CREATE INDEX ix_staffsectionassociation_aggid ON edfi.StaffSectionAssociation (AggregateId)

CREATE SEQUENCE edfi.student_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Student ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentagg_seq');
CREATE INDEX ix_student_aggid ON edfi.Student (AggregateId)

CREATE SEQUENCE edfi.studentacademicrecord_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAcademicRecord ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentacademicrecordagg_seq');
CREATE INDEX ix_studentacademicrecord_aggid ON edfi.StudentAcademicRecord (AggregateId)

CREATE SEQUENCE edfi.studentassessment_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentassessmentagg_seq');
CREATE INDEX ix_studentassessment_aggid ON edfi.StudentAssessment (AggregateId)

CREATE SEQUENCE edfi.studentassessmenteducationorganizationassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentassessmenteducationorganizationassociationagg_seq');
CREATE INDEX ix_studentassessmenteducationorganizationassociation_aggid ON edfi.StudentAssessmentEducationOrganizationAssociation (AggregateId)

CREATE SEQUENCE edfi.studentcohortassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCohortAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentcohortassociationagg_seq');
CREATE INDEX ix_studentcohortassociation_aggid ON edfi.StudentCohortAssociation (AggregateId)

CREATE SEQUENCE edfi.studentcompetencyobjective_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCompetencyObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentcompetencyobjectiveagg_seq');
CREATE INDEX ix_studentcompetencyobjective_aggid ON edfi.StudentCompetencyObjective (AggregateId)

CREATE SEQUENCE edfi.studentcontactassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentContactAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentcontactassociationagg_seq');
CREATE INDEX ix_studentcontactassociation_aggid ON edfi.StudentContactAssociation (AggregateId)

CREATE SEQUENCE edfi.studentdisciplineincidentbehaviorassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentdisciplineincidentbehaviorassociationagg_seq');
CREATE INDEX ix_studentdisciplineincidentbehaviorassociation_aggid ON edfi.StudentDisciplineIncidentBehaviorAssociation (AggregateId)

CREATE SEQUENCE edfi.studentdisciplineincidentnonoffenderassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentdisciplineincidentnonoffenderassociationagg_seq');
CREATE INDEX ix_studentdisciplineincidentnonoffenderassociation_aggid ON edfi.StudentDisciplineIncidentNonOffenderAssociation (AggregateId)

CREATE SEQUENCE edfi.studenteducationorganizationassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenteducationorganizationassociationagg_seq');
CREATE INDEX ix_studenteducationorganizationassociation_aggid ON edfi.StudentEducationOrganizationAssociation (AggregateId)

CREATE SEQUENCE edfi.studenteducationorganizationresponsibilityassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenteducationorganizationresponsibilityassociationagg_seq');
CREATE INDEX ix_studenteducationorganizationresponsibilityassociation_aggid ON edfi.StudentEducationOrganizationResponsibilityAssociation (AggregateId)

CREATE SEQUENCE edfi.studentgradebookentry_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentGradebookEntry ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentgradebookentryagg_seq');
CREATE INDEX ix_studentgradebookentry_aggid ON edfi.StudentGradebookEntry (AggregateId)

CREATE SEQUENCE edfi.studenthealth_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentHealth ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenthealthagg_seq');
CREATE INDEX ix_studenthealth_aggid ON edfi.StudentHealth (AggregateId)

CREATE SEQUENCE edfi.studentinterventionassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentinterventionassociationagg_seq');
CREATE INDEX ix_studentinterventionassociation_aggid ON edfi.StudentInterventionAssociation (AggregateId)

CREATE SEQUENCE edfi.studentinterventionattendanceevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentinterventionattendanceeventagg_seq');
CREATE INDEX ix_studentinterventionattendanceevent_aggid ON edfi.StudentInterventionAttendanceEvent (AggregateId)

CREATE SEQUENCE edfi.studentprogramattendanceevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentProgramAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentprogramattendanceeventagg_seq');
CREATE INDEX ix_studentprogramattendanceevent_aggid ON edfi.StudentProgramAttendanceEvent (AggregateId)

CREATE SEQUENCE edfi.studentprogramevaluation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentProgramEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentprogramevaluationagg_seq');
CREATE INDEX ix_studentprogramevaluation_aggid ON edfi.StudentProgramEvaluation (AggregateId)

CREATE SEQUENCE edfi.studentschoolassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentschoolassociationagg_seq');
CREATE INDEX ix_studentschoolassociation_aggid ON edfi.StudentSchoolAssociation (AggregateId)

CREATE SEQUENCE edfi.studentschoolattendanceevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentschoolattendanceeventagg_seq');
CREATE INDEX ix_studentschoolattendanceevent_aggid ON edfi.StudentSchoolAttendanceEvent (AggregateId)

CREATE SEQUENCE edfi.studentsectionassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentsectionassociationagg_seq');
CREATE INDEX ix_studentsectionassociation_aggid ON edfi.StudentSectionAssociation (AggregateId)

CREATE SEQUENCE edfi.studentsectionattendanceevent_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSectionAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentsectionattendanceeventagg_seq');
CREATE INDEX ix_studentsectionattendanceevent_aggid ON edfi.StudentSectionAttendanceEvent (AggregateId)

CREATE SEQUENCE edfi.studentspecialeducationprogrameligibilityassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studentspecialeducationprogrameligibilityassociationagg_seq');
CREATE INDEX ix_studentspecialeducationprogrameligibilityassociation_aggid ON edfi.StudentSpecialEducationProgramEligibilityAssociation (AggregateId)

CREATE SEQUENCE edfi.studenttransportation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentTransportation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.studenttransportationagg_seq');
CREATE INDEX ix_studenttransportation_aggid ON edfi.StudentTransportation (AggregateId)

CREATE SEQUENCE edfi.survey_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Survey ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyagg_seq');
CREATE INDEX ix_survey_aggid ON edfi.Survey (AggregateId)

CREATE SEQUENCE edfi.surveycourseassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyCourseAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveycourseassociationagg_seq');
CREATE INDEX ix_surveycourseassociation_aggid ON edfi.SurveyCourseAssociation (AggregateId)

CREATE SEQUENCE edfi.surveyprogramassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyprogramassociationagg_seq');
CREATE INDEX ix_surveyprogramassociation_aggid ON edfi.SurveyProgramAssociation (AggregateId)

CREATE SEQUENCE edfi.surveyquestion_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyQuestion ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyquestionagg_seq');
CREATE INDEX ix_surveyquestion_aggid ON edfi.SurveyQuestion (AggregateId)

CREATE SEQUENCE edfi.surveyquestionresponse_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyQuestionResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyquestionresponseagg_seq');
CREATE INDEX ix_surveyquestionresponse_aggid ON edfi.SurveyQuestionResponse (AggregateId)

CREATE SEQUENCE edfi.surveyresponse_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyresponseagg_seq');
CREATE INDEX ix_surveyresponse_aggid ON edfi.SurveyResponse (AggregateId)

CREATE SEQUENCE edfi.surveyresponseeducationorganizationtargetassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyresponseeducationorganizationtargetassociationagg_seq');
CREATE INDEX ix_surveyresponseeducationorganizationtargetassociation_aggid ON edfi.SurveyResponseEducationOrganizationTargetAssociation (AggregateId)

CREATE SEQUENCE edfi.surveyresponsestafftargetassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveyresponsestafftargetassociationagg_seq');
CREATE INDEX ix_surveyresponsestafftargetassociation_aggid ON edfi.SurveyResponseStaffTargetAssociation (AggregateId)

CREATE SEQUENCE edfi.surveysection_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySection ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionagg_seq');
CREATE INDEX ix_surveysection_aggid ON edfi.SurveySection (AggregateId)

CREATE SEQUENCE edfi.surveysectionassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionassociationagg_seq');
CREATE INDEX ix_surveysectionassociation_aggid ON edfi.SurveySectionAssociation (AggregateId)

CREATE SEQUENCE edfi.surveysectionresponse_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionresponseagg_seq');
CREATE INDEX ix_surveysectionresponse_aggid ON edfi.SurveySectionResponse (AggregateId)

CREATE SEQUENCE edfi.surveysectionresponseeducationorganizationtargetassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionresponseeducationorganizationtargetassociationagg_seq');
CREATE INDEX ix_surveysectionresponseeducationorganizationtargetassociation_aggid ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation (AggregateId)

CREATE SEQUENCE edfi.surveysectionresponsestafftargetassociation_agg_seq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.surveysectionresponsestafftargetassociationagg_seq');
CREATE INDEX ix_surveysectionresponsestafftargetassociation_aggid ON edfi.SurveySectionResponseStaffTargetAssociation (AggregateId)
