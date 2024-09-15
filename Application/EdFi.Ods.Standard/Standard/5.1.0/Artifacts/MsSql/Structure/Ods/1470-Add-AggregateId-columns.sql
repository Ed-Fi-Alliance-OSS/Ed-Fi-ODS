-- Add SEQUENCEs for tables that already have IDENTITY columns
--------------------------------------------------------------
CREATE SEQUENCE edfi.ContactSequence AS int START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE edfi.Contact ADD AggregateId int NOT NULL CONSTRAINT DF_Contact_AggregateId DEFAULT (NEXT VALUE FOR edfi.ContactSequence);

CREATE SEQUENCE edfi.StudentSequence AS int START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE edfi.Student ADD AggregateId int NOT NULL CONSTRAINT DF_Student_AggregateId DEFAULT (NEXT VALUE FOR edfi.StudentSequence);

CREATE SEQUENCE edfi.StaffSequence AS int START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE edfi.Staff ADD AggregateId int NOT NULL CONSTRAINT DF_Staff_AggregateId DEFAULT (NEXT VALUE FOR edfi.StaffSequence);

CREATE SEQUENCE edfi.DescriptorSequence AS int START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE edfi.Descriptor ADD AggregateId int NOT NULL CONSTRAINT DF_Descriptor_AggregateId DEFAULT (NEXT VALUE FOR edfi.DescriptorSequence);

/* Generated with SSMS using:
------------------------------------------------
SELECT 'ALTER TABLE ' + c.TABLE_SCHEMA + '.' + c.TABLE_NAME + ' ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1); CREATE INDEX IX_' + c.TABLE_NAME + '_AggregateId ON ' + c.TABLE_SCHEMA + '.' + c.TABLE_NAME + ' (AggregateId);'
FROM INFORMATION_SCHEMA.COLUMNS c
WHERE c.COLUMN_NAME = 'Id' and c.TABLE_SCHEMA = 'edfi'
	AND c.TABLE_NAME NOT IN ('Contact', 'Parent', 'Staff', 'Student', 'Descriptor')
ORDER BY c.TABLE_SCHEMA, c.TABLE_NAME
------------------------------------------------
*/

-- Add IDENTITY columns for the rest
-------------------------------------

ALTER TABLE edfi.AcademicWeek ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_AcademicWeek_AggregateId ON edfi.AcademicWeek (AggregateId);

ALTER TABLE edfi.AccountabilityRating ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_AccountabilityRating_AggregateId ON edfi.AccountabilityRating (AggregateId);

ALTER TABLE edfi.Assessment ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Assessment_AggregateId ON edfi.Assessment (AggregateId);

ALTER TABLE edfi.AssessmentItem ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_AssessmentItem_AggregateId ON edfi.AssessmentItem (AggregateId);

ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_AssessmentScoreRangeLearningStandard_AggregateId ON edfi.AssessmentScoreRangeLearningStandard (AggregateId);

ALTER TABLE edfi.BalanceSheetDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_BalanceSheetDimension_AggregateId ON edfi.BalanceSheetDimension (AggregateId);

ALTER TABLE edfi.BellSchedule ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_BellSchedule_AggregateId ON edfi.BellSchedule (AggregateId);

ALTER TABLE edfi.Calendar ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Calendar_AggregateId ON edfi.Calendar (AggregateId);

ALTER TABLE edfi.CalendarDate ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_CalendarDate_AggregateId ON edfi.CalendarDate (AggregateId);

ALTER TABLE edfi.ChartOfAccount ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ChartOfAccount_AggregateId ON edfi.ChartOfAccount (AggregateId);

ALTER TABLE edfi.ClassPeriod ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ClassPeriod_AggregateId ON edfi.ClassPeriod (AggregateId);

ALTER TABLE edfi.Cohort ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Cohort_AggregateId ON edfi.Cohort (AggregateId);

ALTER TABLE edfi.CommunityProviderLicense ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_CommunityProviderLicense_AggregateId ON edfi.CommunityProviderLicense (AggregateId);

ALTER TABLE edfi.CompetencyObjective ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_CompetencyObjective_AggregateId ON edfi.CompetencyObjective (AggregateId);

ALTER TABLE edfi.Course ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Course_AggregateId ON edfi.Course (AggregateId);

ALTER TABLE edfi.CourseOffering ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_CourseOffering_AggregateId ON edfi.CourseOffering (AggregateId);

ALTER TABLE edfi.CourseTranscript ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_CourseTranscript_AggregateId ON edfi.CourseTranscript (AggregateId);

ALTER TABLE edfi.Credential ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Credential_AggregateId ON edfi.Credential (AggregateId);

ALTER TABLE edfi.CrisisEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_CrisisEvent_AggregateId ON edfi.CrisisEvent (AggregateId);

ALTER TABLE edfi.DescriptorMapping ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_DescriptorMapping_AggregateId ON edfi.DescriptorMapping (AggregateId);

ALTER TABLE edfi.DisciplineAction ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_DisciplineAction_AggregateId ON edfi.DisciplineAction (AggregateId);

ALTER TABLE edfi.DisciplineIncident ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_DisciplineIncident_AggregateId ON edfi.DisciplineIncident (AggregateId);

ALTER TABLE edfi.EducationContent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_EducationContent_AggregateId ON edfi.EducationContent (AggregateId);

ALTER TABLE edfi.EducationOrganization ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_EducationOrganization_AggregateId ON edfi.EducationOrganization (AggregateId);

ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_EducationOrganizationInterventionPrescriptionAssociation_AggregateId ON edfi.EducationOrganizationInterventionPrescriptionAssociation (AggregateId);

ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_EducationOrganizationNetworkAssociation_AggregateId ON edfi.EducationOrganizationNetworkAssociation (AggregateId);

ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_EducationOrganizationPeerAssociation_AggregateId ON edfi.EducationOrganizationPeerAssociation (AggregateId);

ALTER TABLE edfi.EvaluationRubricDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_EvaluationRubricDimension_AggregateId ON edfi.EvaluationRubricDimension (AggregateId);

ALTER TABLE edfi.FeederSchoolAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_FeederSchoolAssociation_AggregateId ON edfi.FeederSchoolAssociation (AggregateId);

ALTER TABLE edfi.FunctionDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_FunctionDimension_AggregateId ON edfi.FunctionDimension (AggregateId);

ALTER TABLE edfi.FundDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_FundDimension_AggregateId ON edfi.FundDimension (AggregateId);

ALTER TABLE edfi.GeneralStudentProgramAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_GeneralStudentProgramAssociation_AggregateId ON edfi.GeneralStudentProgramAssociation (AggregateId);

ALTER TABLE edfi.Grade ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Grade_AggregateId ON edfi.Grade (AggregateId);

ALTER TABLE edfi.GradebookEntry ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_GradebookEntry_AggregateId ON edfi.GradebookEntry (AggregateId);

ALTER TABLE edfi.GradingPeriod ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_GradingPeriod_AggregateId ON edfi.GradingPeriod (AggregateId);

ALTER TABLE edfi.GraduationPlan ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_GraduationPlan_AggregateId ON edfi.GraduationPlan (AggregateId);

ALTER TABLE edfi.Intervention ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Intervention_AggregateId ON edfi.Intervention (AggregateId);

ALTER TABLE edfi.InterventionPrescription ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_InterventionPrescription_AggregateId ON edfi.InterventionPrescription (AggregateId);

ALTER TABLE edfi.InterventionStudy ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_InterventionStudy_AggregateId ON edfi.InterventionStudy (AggregateId);

ALTER TABLE edfi.LearningStandard ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LearningStandard_AggregateId ON edfi.LearningStandard (AggregateId);

ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LearningStandardEquivalenceAssociation_AggregateId ON edfi.LearningStandardEquivalenceAssociation (AggregateId);

ALTER TABLE edfi.LocalAccount ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LocalAccount_AggregateId ON edfi.LocalAccount (AggregateId);

ALTER TABLE edfi.LocalActual ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LocalActual_AggregateId ON edfi.LocalActual (AggregateId);

ALTER TABLE edfi.LocalBudget ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LocalBudget_AggregateId ON edfi.LocalBudget (AggregateId);

ALTER TABLE edfi.LocalContractedStaff ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LocalContractedStaff_AggregateId ON edfi.LocalContractedStaff (AggregateId);

ALTER TABLE edfi.LocalEncumbrance ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LocalEncumbrance_AggregateId ON edfi.LocalEncumbrance (AggregateId);

ALTER TABLE edfi.LocalPayroll ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_LocalPayroll_AggregateId ON edfi.LocalPayroll (AggregateId);

ALTER TABLE edfi.Location ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Location_AggregateId ON edfi.Location (AggregateId);

ALTER TABLE edfi.ObjectDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ObjectDimension_AggregateId ON edfi.ObjectDimension (AggregateId);

ALTER TABLE edfi.ObjectiveAssessment ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ObjectiveAssessment_AggregateId ON edfi.ObjectiveAssessment (AggregateId);

ALTER TABLE edfi.OpenStaffPosition ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_OpenStaffPosition_AggregateId ON edfi.OpenStaffPosition (AggregateId);

ALTER TABLE edfi.OperationalUnitDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_OperationalUnitDimension_AggregateId ON edfi.OperationalUnitDimension (AggregateId);

ALTER TABLE edfi.Person ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Person_AggregateId ON edfi.Person (AggregateId);

ALTER TABLE edfi.PostSecondaryEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_PostSecondaryEvent_AggregateId ON edfi.PostSecondaryEvent (AggregateId);

ALTER TABLE edfi.Program ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Program_AggregateId ON edfi.Program (AggregateId);

ALTER TABLE edfi.ProgramDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ProgramDimension_AggregateId ON edfi.ProgramDimension (AggregateId);

ALTER TABLE edfi.ProgramEvaluation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ProgramEvaluation_AggregateId ON edfi.ProgramEvaluation (AggregateId);

ALTER TABLE edfi.ProgramEvaluationElement ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ProgramEvaluationElement_AggregateId ON edfi.ProgramEvaluationElement (AggregateId);

ALTER TABLE edfi.ProgramEvaluationObjective ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ProgramEvaluationObjective_AggregateId ON edfi.ProgramEvaluationObjective (AggregateId);

ALTER TABLE edfi.ProjectDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ProjectDimension_AggregateId ON edfi.ProjectDimension (AggregateId);

ALTER TABLE edfi.ReportCard ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_ReportCard_AggregateId ON edfi.ReportCard (AggregateId);

ALTER TABLE edfi.RestraintEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_RestraintEvent_AggregateId ON edfi.RestraintEvent (AggregateId);

ALTER TABLE edfi.SchoolYearType ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SchoolYearType_AggregateId ON edfi.SchoolYearType (AggregateId);

ALTER TABLE edfi.Section ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Section_AggregateId ON edfi.Section (AggregateId);

ALTER TABLE edfi.SectionAttendanceTakenEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SectionAttendanceTakenEvent_AggregateId ON edfi.SectionAttendanceTakenEvent (AggregateId);

ALTER TABLE edfi.Session ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Session_AggregateId ON edfi.Session (AggregateId);

ALTER TABLE edfi.SourceDimension ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SourceDimension_AggregateId ON edfi.SourceDimension (AggregateId);

ALTER TABLE edfi.StaffAbsenceEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffAbsenceEvent_AggregateId ON edfi.StaffAbsenceEvent (AggregateId);

ALTER TABLE edfi.StaffCohortAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffCohortAssociation_AggregateId ON edfi.StaffCohortAssociation (AggregateId);

ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffDisciplineIncidentAssociation_AggregateId ON edfi.StaffDisciplineIncidentAssociation (AggregateId);

ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffEducationOrganizationAssignmentAssociation_AggregateId ON edfi.StaffEducationOrganizationAssignmentAssociation (AggregateId);

ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffEducationOrganizationContactAssociation_AggregateId ON edfi.StaffEducationOrganizationContactAssociation (AggregateId);

ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffEducationOrganizationEmploymentAssociation_AggregateId ON edfi.StaffEducationOrganizationEmploymentAssociation (AggregateId);

ALTER TABLE edfi.StaffLeave ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffLeave_AggregateId ON edfi.StaffLeave (AggregateId);

ALTER TABLE edfi.StaffProgramAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffProgramAssociation_AggregateId ON edfi.StaffProgramAssociation (AggregateId);

ALTER TABLE edfi.StaffSchoolAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffSchoolAssociation_AggregateId ON edfi.StaffSchoolAssociation (AggregateId);

ALTER TABLE edfi.StaffSectionAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StaffSectionAssociation_AggregateId ON edfi.StaffSectionAssociation (AggregateId);

ALTER TABLE edfi.StudentAcademicRecord ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentAcademicRecord_AggregateId ON edfi.StudentAcademicRecord (AggregateId);

ALTER TABLE edfi.StudentAssessment ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentAssessment_AggregateId ON edfi.StudentAssessment (AggregateId);

ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentAssessmentEducationOrganizationAssociation_AggregateId ON edfi.StudentAssessmentEducationOrganizationAssociation (AggregateId);

ALTER TABLE edfi.StudentCohortAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentCohortAssociation_AggregateId ON edfi.StudentCohortAssociation (AggregateId);

ALTER TABLE edfi.StudentCompetencyObjective ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentCompetencyObjective_AggregateId ON edfi.StudentCompetencyObjective (AggregateId);

ALTER TABLE edfi.StudentContactAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentContactAssociation_AggregateId ON edfi.StudentContactAssociation (AggregateId);

ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentDisciplineIncidentBehaviorAssociation_AggregateId ON edfi.StudentDisciplineIncidentBehaviorAssociation (AggregateId);

ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentDisciplineIncidentNonOffenderAssociation_AggregateId ON edfi.StudentDisciplineIncidentNonOffenderAssociation (AggregateId);

ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentEducationOrganizationAssociation_AggregateId ON edfi.StudentEducationOrganizationAssociation (AggregateId);

ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentEducationOrganizationResponsibilityAssociation_AggregateId ON edfi.StudentEducationOrganizationResponsibilityAssociation (AggregateId);

ALTER TABLE edfi.StudentGradebookEntry ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentGradebookEntry_AggregateId ON edfi.StudentGradebookEntry (AggregateId);

ALTER TABLE edfi.StudentHealth ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentHealth_AggregateId ON edfi.StudentHealth (AggregateId);

ALTER TABLE edfi.StudentInterventionAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentInterventionAssociation_AggregateId ON edfi.StudentInterventionAssociation (AggregateId);

ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentInterventionAttendanceEvent_AggregateId ON edfi.StudentInterventionAttendanceEvent (AggregateId);

ALTER TABLE edfi.StudentProgramAttendanceEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentProgramAttendanceEvent_AggregateId ON edfi.StudentProgramAttendanceEvent (AggregateId);

ALTER TABLE edfi.StudentProgramEvaluation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentProgramEvaluation_AggregateId ON edfi.StudentProgramEvaluation (AggregateId);

ALTER TABLE edfi.StudentSchoolAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentSchoolAssociation_AggregateId ON edfi.StudentSchoolAssociation (AggregateId);

ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentSchoolAttendanceEvent_AggregateId ON edfi.StudentSchoolAttendanceEvent (AggregateId);

ALTER TABLE edfi.StudentSectionAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentSectionAssociation_AggregateId ON edfi.StudentSectionAssociation (AggregateId);

ALTER TABLE edfi.StudentSectionAttendanceEvent ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentSectionAttendanceEvent_AggregateId ON edfi.StudentSectionAttendanceEvent (AggregateId);

ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentSpecialEducationProgramEligibilityAssociation_AggregateId ON edfi.StudentSpecialEducationProgramEligibilityAssociation (AggregateId);

ALTER TABLE edfi.StudentTransportation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_StudentTransportation_AggregateId ON edfi.StudentTransportation (AggregateId);

ALTER TABLE edfi.Survey ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_Survey_AggregateId ON edfi.Survey (AggregateId);

ALTER TABLE edfi.SurveyCourseAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveyCourseAssociation_AggregateId ON edfi.SurveyCourseAssociation (AggregateId);

ALTER TABLE edfi.SurveyProgramAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveyProgramAssociation_AggregateId ON edfi.SurveyProgramAssociation (AggregateId);

ALTER TABLE edfi.SurveyQuestion ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveyQuestion_AggregateId ON edfi.SurveyQuestion (AggregateId);

ALTER TABLE edfi.SurveyQuestionResponse ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveyQuestionResponse_AggregateId ON edfi.SurveyQuestionResponse (AggregateId);

ALTER TABLE edfi.SurveyResponse ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveyResponse_AggregateId ON edfi.SurveyResponse (AggregateId);

ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveyResponseEducationOrganizationTargetAssociation_AggregateId ON edfi.SurveyResponseEducationOrganizationTargetAssociation (AggregateId);

ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveyResponseStaffTargetAssociation_AggregateId ON edfi.SurveyResponseStaffTargetAssociation (AggregateId);

ALTER TABLE edfi.SurveySection ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveySection_AggregateId ON edfi.SurveySection (AggregateId);

ALTER TABLE edfi.SurveySectionAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveySectionAssociation_AggregateId ON edfi.SurveySectionAssociation (AggregateId);

ALTER TABLE edfi.SurveySectionResponse ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveySectionResponse_AggregateId ON edfi.SurveySectionResponse (AggregateId);

ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveySectionResponseEducationOrganizationTargetAssociation_AggregateId ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation (AggregateId);

ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD AggregateId int NOT NULL IDENTITY (-2147483648, 1);
CREATE INDEX IX_SurveySectionResponseStaffTargetAssociation_AggregateId ON edfi.SurveySectionResponseStaffTargetAssociation (AggregateId);
