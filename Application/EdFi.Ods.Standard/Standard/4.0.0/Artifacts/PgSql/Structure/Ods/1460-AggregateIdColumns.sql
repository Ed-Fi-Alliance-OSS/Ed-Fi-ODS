-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


CREATE SEQUENCE edfi.AcademicWeek_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AcademicWeek ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.AcademicWeek_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_AcademicWeek_aggid ON edfi.AcademicWeek (AggregateId);


CREATE SEQUENCE edfi.AccountabilityRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AccountabilityRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.AccountabilityRating_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_AccountabilityRating_aggid ON edfi.AccountabilityRating (AggregateId);


CREATE SEQUENCE edfi.Assessment_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Assessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Assessment_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Assessment_aggid ON edfi.Assessment (AggregateId);


CREATE SEQUENCE edfi.AssessmentItem_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentItem ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.AssessmentItem_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_AssessmentItem_aggid ON edfi.AssessmentItem (AggregateId);


CREATE SEQUENCE edfi.AssessmentScoreRangeLearningStandard_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.AssessmentScoreRangeLearningStandard_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_AssessmentScoreRangeLearningStandard_aggid ON edfi.AssessmentScoreRangeLearningStandard (AggregateId);


CREATE SEQUENCE edfi.BalanceSheetDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.BalanceSheetDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.BalanceSheetDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_BalanceSheetDimension_aggid ON edfi.BalanceSheetDimension (AggregateId);


CREATE SEQUENCE edfi.BellSchedule_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.BellSchedule ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.BellSchedule_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_BellSchedule_aggid ON edfi.BellSchedule (AggregateId);


CREATE SEQUENCE edfi.Calendar_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Calendar ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Calendar_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Calendar_aggid ON edfi.Calendar (AggregateId);


CREATE SEQUENCE edfi.CalendarDate_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CalendarDate ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CalendarDate_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CalendarDate_aggid ON edfi.CalendarDate (AggregateId);


CREATE SEQUENCE edfi.ChartOfAccount_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ChartOfAccount ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ChartOfAccount_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ChartOfAccount_aggid ON edfi.ChartOfAccount (AggregateId);


CREATE SEQUENCE edfi.ClassPeriod_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ClassPeriod ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ClassPeriod_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ClassPeriod_aggid ON edfi.ClassPeriod (AggregateId);


CREATE SEQUENCE edfi.Cohort_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Cohort ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Cohort_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Cohort_aggid ON edfi.Cohort (AggregateId);


CREATE SEQUENCE edfi.CommunityProviderLicense_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CommunityProviderLicense ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CommunityProviderLicense_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CommunityProviderLicense_aggid ON edfi.CommunityProviderLicense (AggregateId);


CREATE SEQUENCE edfi.CompetencyObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CompetencyObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CompetencyObjective_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CompetencyObjective_aggid ON edfi.CompetencyObjective (AggregateId);


CREATE SEQUENCE edfi.Course_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Course ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Course_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Course_aggid ON edfi.Course (AggregateId);


CREATE SEQUENCE edfi.CourseOffering_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CourseOffering ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CourseOffering_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CourseOffering_aggid ON edfi.CourseOffering (AggregateId);


CREATE SEQUENCE edfi.CourseTranscript_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CourseTranscript ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CourseTranscript_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CourseTranscript_aggid ON edfi.CourseTranscript (AggregateId);


CREATE SEQUENCE edfi.Credential_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Credential ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Credential_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Credential_aggid ON edfi.Credential (AggregateId);


CREATE SEQUENCE edfi.Descriptor_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Descriptor ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Descriptor_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Descriptor_aggid ON edfi.Descriptor (AggregateId);


CREATE SEQUENCE edfi.DescriptorMapping_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DescriptorMapping ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.DescriptorMapping_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_DescriptorMapping_aggid ON edfi.DescriptorMapping (AggregateId);


CREATE SEQUENCE edfi.DisciplineAction_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DisciplineAction ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.DisciplineAction_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_DisciplineAction_aggid ON edfi.DisciplineAction (AggregateId);


CREATE SEQUENCE edfi.DisciplineIncident_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.DisciplineIncident ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.DisciplineIncident_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_DisciplineIncident_aggid ON edfi.DisciplineIncident (AggregateId);


CREATE SEQUENCE edfi.EducationContent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationContent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationContent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationContent_aggid ON edfi.EducationContent (AggregateId);


CREATE SEQUENCE edfi.EducationOrganization_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganization ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganization_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganization_aggid ON edfi.EducationOrganization (AggregateId);


CREATE SEQUENCE edfi.EducationOrganizationInterventionPrescriptionAs_e670ae_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganizationInterventionPrescriptionAs_e670ae_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganizationInterventionPrescriptionAs_e670ae_aggid ON edfi.EducationOrganizationInterventionPrescriptionAssociation (AggregateId);


CREATE SEQUENCE edfi.EducationOrganizationNetworkAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganizationNetworkAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganizationNetworkAssociation_aggid ON edfi.EducationOrganizationNetworkAssociation (AggregateId);


CREATE SEQUENCE edfi.EducationOrganizationPeerAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganizationPeerAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganizationPeerAssociation_aggid ON edfi.EducationOrganizationPeerAssociation (AggregateId);


CREATE SEQUENCE edfi.FeederSchoolAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FeederSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FeederSchoolAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FeederSchoolAssociation_aggid ON edfi.FeederSchoolAssociation (AggregateId);


CREATE SEQUENCE edfi.FunctionDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FunctionDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FunctionDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FunctionDimension_aggid ON edfi.FunctionDimension (AggregateId);


CREATE SEQUENCE edfi.FundDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FundDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FundDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FundDimension_aggid ON edfi.FundDimension (AggregateId);


CREATE SEQUENCE edfi.GeneralStudentProgramAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GeneralStudentProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.GeneralStudentProgramAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_GeneralStudentProgramAssociation_aggid ON edfi.GeneralStudentProgramAssociation (AggregateId);


CREATE SEQUENCE edfi.Grade_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Grade ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Grade_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Grade_aggid ON edfi.Grade (AggregateId);


CREATE SEQUENCE edfi.GradebookEntry_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GradebookEntry ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.GradebookEntry_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_GradebookEntry_aggid ON edfi.GradebookEntry (AggregateId);


CREATE SEQUENCE edfi.GradingPeriod_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GradingPeriod ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.GradingPeriod_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_GradingPeriod_aggid ON edfi.GradingPeriod (AggregateId);


CREATE SEQUENCE edfi.GraduationPlan_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GraduationPlan ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.GraduationPlan_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_GraduationPlan_aggid ON edfi.GraduationPlan (AggregateId);


CREATE SEQUENCE edfi.Intervention_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Intervention ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Intervention_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Intervention_aggid ON edfi.Intervention (AggregateId);


CREATE SEQUENCE edfi.InterventionPrescription_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.InterventionPrescription ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.InterventionPrescription_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_InterventionPrescription_aggid ON edfi.InterventionPrescription (AggregateId);


CREATE SEQUENCE edfi.InterventionStudy_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.InterventionStudy ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.InterventionStudy_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_InterventionStudy_aggid ON edfi.InterventionStudy (AggregateId);


CREATE SEQUENCE edfi.LearningObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LearningObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LearningObjective_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LearningObjective_aggid ON edfi.LearningObjective (AggregateId);


CREATE SEQUENCE edfi.LearningStandard_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LearningStandard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LearningStandard_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LearningStandard_aggid ON edfi.LearningStandard (AggregateId);


CREATE SEQUENCE edfi.LearningStandardEquivalenceAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LearningStandardEquivalenceAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LearningStandardEquivalenceAssociation_aggid ON edfi.LearningStandardEquivalenceAssociation (AggregateId);


CREATE SEQUENCE edfi.LocalAccount_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalAccount ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LocalAccount_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LocalAccount_aggid ON edfi.LocalAccount (AggregateId);


CREATE SEQUENCE edfi.LocalActual_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalActual ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LocalActual_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LocalActual_aggid ON edfi.LocalActual (AggregateId);


CREATE SEQUENCE edfi.LocalBudget_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalBudget ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LocalBudget_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LocalBudget_aggid ON edfi.LocalBudget (AggregateId);


CREATE SEQUENCE edfi.LocalContractedStaff_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalContractedStaff ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LocalContractedStaff_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LocalContractedStaff_aggid ON edfi.LocalContractedStaff (AggregateId);


CREATE SEQUENCE edfi.LocalEncumbrance_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalEncumbrance ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LocalEncumbrance_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LocalEncumbrance_aggid ON edfi.LocalEncumbrance (AggregateId);


CREATE SEQUENCE edfi.LocalPayroll_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.LocalPayroll ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.LocalPayroll_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_LocalPayroll_aggid ON edfi.LocalPayroll (AggregateId);


CREATE SEQUENCE edfi.Location_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Location ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Location_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Location_aggid ON edfi.Location (AggregateId);


CREATE SEQUENCE edfi.ObjectDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ObjectDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ObjectDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ObjectDimension_aggid ON edfi.ObjectDimension (AggregateId);


CREATE SEQUENCE edfi.ObjectiveAssessment_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ObjectiveAssessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ObjectiveAssessment_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ObjectiveAssessment_aggid ON edfi.ObjectiveAssessment (AggregateId);


CREATE SEQUENCE edfi.OpenStaffPosition_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OpenStaffPosition ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.OpenStaffPosition_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_OpenStaffPosition_aggid ON edfi.OpenStaffPosition (AggregateId);


CREATE SEQUENCE edfi.OperationalUnitDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OperationalUnitDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.OperationalUnitDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_OperationalUnitDimension_aggid ON edfi.OperationalUnitDimension (AggregateId);


CREATE SEQUENCE edfi.Parent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Parent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Parent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Parent_aggid ON edfi.Parent (AggregateId);


CREATE SEQUENCE edfi.Person_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Person ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Person_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Person_aggid ON edfi.Person (AggregateId);


CREATE SEQUENCE edfi.PostSecondaryEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PostSecondaryEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.PostSecondaryEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_PostSecondaryEvent_aggid ON edfi.PostSecondaryEvent (AggregateId);


CREATE SEQUENCE edfi.Program_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Program ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Program_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Program_aggid ON edfi.Program (AggregateId);


CREATE SEQUENCE edfi.ProgramDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProgramDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProgramDimension_aggid ON edfi.ProgramDimension (AggregateId);


CREATE SEQUENCE edfi.ProjectDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProjectDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProjectDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProjectDimension_aggid ON edfi.ProjectDimension (AggregateId);


CREATE SEQUENCE edfi.ReportCard_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ReportCard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ReportCard_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ReportCard_aggid ON edfi.ReportCard (AggregateId);


CREATE SEQUENCE edfi.RestraintEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.RestraintEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.RestraintEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_RestraintEvent_aggid ON edfi.RestraintEvent (AggregateId);


CREATE SEQUENCE edfi.SchoolYearType_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SchoolYearType ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SchoolYearType_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SchoolYearType_aggid ON edfi.SchoolYearType (AggregateId);


CREATE SEQUENCE edfi.Section_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Section ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Section_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Section_aggid ON edfi.Section (AggregateId);


CREATE SEQUENCE edfi.SectionAttendanceTakenEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SectionAttendanceTakenEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SectionAttendanceTakenEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SectionAttendanceTakenEvent_aggid ON edfi.SectionAttendanceTakenEvent (AggregateId);


CREATE SEQUENCE edfi.Session_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Session ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Session_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Session_aggid ON edfi.Session (AggregateId);


CREATE SEQUENCE edfi.SourceDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SourceDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SourceDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SourceDimension_aggid ON edfi.SourceDimension (AggregateId);


CREATE SEQUENCE edfi.Staff_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Staff ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Staff_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Staff_aggid ON edfi.Staff (AggregateId);


CREATE SEQUENCE edfi.StaffAbsenceEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffAbsenceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffAbsenceEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffAbsenceEvent_aggid ON edfi.StaffAbsenceEvent (AggregateId);


CREATE SEQUENCE edfi.StaffCohortAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffCohortAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffCohortAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffCohortAssociation_aggid ON edfi.StaffCohortAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffDisciplineIncidentAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffDisciplineIncidentAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffDisciplineIncidentAssociation_aggid ON edfi.StaffDisciplineIncidentAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffEducationOrganizationAssignmentAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffEducationOrganizationAssignmentAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffEducationOrganizationAssignmentAssociation_aggid ON edfi.StaffEducationOrganizationAssignmentAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffEducationOrganizationContactAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationContactAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffEducationOrganizationContactAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffEducationOrganizationContactAssociation_aggid ON edfi.StaffEducationOrganizationContactAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffEducationOrganizationEmploymentAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffEducationOrganizationEmploymentAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffEducationOrganizationEmploymentAssociation_aggid ON edfi.StaffEducationOrganizationEmploymentAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffLeave_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffLeave ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffLeave_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffLeave_aggid ON edfi.StaffLeave (AggregateId);


CREATE SEQUENCE edfi.StaffProgramAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffProgramAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffProgramAssociation_aggid ON edfi.StaffProgramAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffSchoolAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffSchoolAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffSchoolAssociation_aggid ON edfi.StaffSchoolAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffSectionAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffSectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffSectionAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffSectionAssociation_aggid ON edfi.StaffSectionAssociation (AggregateId);


CREATE SEQUENCE edfi.Student_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Student ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Student_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Student_aggid ON edfi.Student (AggregateId);


CREATE SEQUENCE edfi.StudentAcademicRecord_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAcademicRecord ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentAcademicRecord_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentAcademicRecord_aggid ON edfi.StudentAcademicRecord (AggregateId);


CREATE SEQUENCE edfi.StudentAssessment_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentAssessment_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentAssessment_aggid ON edfi.StudentAssessment (AggregateId);


CREATE SEQUENCE edfi.StudentAssessmentEducationOrganizationAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentAssessmentEducationOrganizationAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentAssessmentEducationOrganizationAssociation_aggid ON edfi.StudentAssessmentEducationOrganizationAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentCohortAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCohortAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentCohortAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentCohortAssociation_aggid ON edfi.StudentCohortAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentCompetencyObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCompetencyObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentCompetencyObjective_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentCompetencyObjective_aggid ON edfi.StudentCompetencyObjective (AggregateId);


CREATE SEQUENCE edfi.StudentDisciplineIncidentAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentDisciplineIncidentAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentDisciplineIncidentAssociation_aggid ON edfi.StudentDisciplineIncidentAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentDisciplineIncidentBehaviorAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentDisciplineIncidentBehaviorAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentDisciplineIncidentBehaviorAssociation_aggid ON edfi.StudentDisciplineIncidentBehaviorAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentDisciplineIncidentNonOffenderAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentDisciplineIncidentNonOffenderAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentDisciplineIncidentNonOffenderAssociation_aggid ON edfi.StudentDisciplineIncidentNonOffenderAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentEducationOrganizationAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentEducationOrganizationAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentEducationOrganizationAssociation_aggid ON edfi.StudentEducationOrganizationAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentEducationOrganizationResponsibilityAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentEducationOrganizationResponsibilityAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentEducationOrganizationResponsibilityAssociation_aggid ON edfi.StudentEducationOrganizationResponsibilityAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentGradebookEntry_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentGradebookEntry ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentGradebookEntry_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentGradebookEntry_aggid ON edfi.StudentGradebookEntry (AggregateId);


CREATE SEQUENCE edfi.StudentInterventionAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentInterventionAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentInterventionAssociation_aggid ON edfi.StudentInterventionAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentInterventionAttendanceEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentInterventionAttendanceEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentInterventionAttendanceEvent_aggid ON edfi.StudentInterventionAttendanceEvent (AggregateId);


CREATE SEQUENCE edfi.StudentLearningObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentLearningObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentLearningObjective_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentLearningObjective_aggid ON edfi.StudentLearningObjective (AggregateId);


CREATE SEQUENCE edfi.StudentParentAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentParentAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentParentAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentParentAssociation_aggid ON edfi.StudentParentAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentProgramAttendanceEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentProgramAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentProgramAttendanceEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentProgramAttendanceEvent_aggid ON edfi.StudentProgramAttendanceEvent (AggregateId);


CREATE SEQUENCE edfi.StudentSchoolAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentSchoolAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentSchoolAssociation_aggid ON edfi.StudentSchoolAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentSchoolAttendanceEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSchoolAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentSchoolAttendanceEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentSchoolAttendanceEvent_aggid ON edfi.StudentSchoolAttendanceEvent (AggregateId);


CREATE SEQUENCE edfi.StudentSectionAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentSectionAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentSectionAssociation_aggid ON edfi.StudentSectionAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentSectionAttendanceEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSectionAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentSectionAttendanceEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentSectionAttendanceEvent_aggid ON edfi.StudentSectionAttendanceEvent (AggregateId);


CREATE SEQUENCE edfi.Survey_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Survey ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Survey_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Survey_aggid ON edfi.Survey (AggregateId);


CREATE SEQUENCE edfi.SurveyCourseAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyCourseAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyCourseAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyCourseAssociation_aggid ON edfi.SurveyCourseAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveyProgramAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyProgramAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyProgramAssociation_aggid ON edfi.SurveyProgramAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveyQuestion_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyQuestion ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyQuestion_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyQuestion_aggid ON edfi.SurveyQuestion (AggregateId);


CREATE SEQUENCE edfi.SurveyQuestionResponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyQuestionResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyQuestionResponse_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyQuestionResponse_aggid ON edfi.SurveyQuestionResponse (AggregateId);


CREATE SEQUENCE edfi.SurveyResponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyResponse_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyResponse_aggid ON edfi.SurveyResponse (AggregateId);


CREATE SEQUENCE edfi.SurveyResponseEducationOrganizationTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyResponseEducationOrganizationTargetAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyResponseEducationOrganizationTargetAssociation_aggid ON edfi.SurveyResponseEducationOrganizationTargetAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveyResponseStaffTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyResponseStaffTargetAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyResponseStaffTargetAssociation_aggid ON edfi.SurveyResponseStaffTargetAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveySection_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySection ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySection_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySection_aggid ON edfi.SurveySection (AggregateId);


CREATE SEQUENCE edfi.SurveySectionAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionAssociation_aggid ON edfi.SurveySectionAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveySectionResponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionResponse_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionResponse_aggid ON edfi.SurveySectionResponse (AggregateId);


CREATE SEQUENCE edfi.SurveySectionResponseEducationOrganizationTarge_730be1_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionResponseEducationOrganizationTarge_730be1_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionResponseEducationOrganizationTarge_730be1_aggid ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveySectionResponseStaffTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionResponseStaffTargetAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionResponseStaffTargetAssociation_aggid ON edfi.SurveySectionResponseStaffTargetAssociation (AggregateId);

