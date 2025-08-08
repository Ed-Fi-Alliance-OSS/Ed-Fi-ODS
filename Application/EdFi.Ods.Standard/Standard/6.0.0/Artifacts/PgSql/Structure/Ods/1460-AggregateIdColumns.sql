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


CREATE SEQUENCE edfi.ApplicantProfile_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ApplicantProfile ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ApplicantProfile_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ApplicantProfile_aggid ON edfi.ApplicantProfile (AggregateId);


CREATE SEQUENCE edfi.Application_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Application ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Application_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Application_aggid ON edfi.Application (AggregateId);


CREATE SEQUENCE edfi.ApplicationEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ApplicationEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ApplicationEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ApplicationEvent_aggid ON edfi.ApplicationEvent (AggregateId);


CREATE SEQUENCE edfi.Assessment_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Assessment ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Assessment_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Assessment_aggid ON edfi.Assessment (AggregateId);


CREATE SEQUENCE edfi.AssessmentAdministration_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentAdministration ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.AssessmentAdministration_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_AssessmentAdministration_aggid ON edfi.AssessmentAdministration (AggregateId);


CREATE SEQUENCE edfi.AssessmentAdministrationParticipation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentAdministrationParticipation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.AssessmentAdministrationParticipation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_AssessmentAdministrationParticipation_aggid ON edfi.AssessmentAdministrationParticipation (AggregateId);


CREATE SEQUENCE edfi.AssessmentBatteryPart_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.AssessmentBatteryPart ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.AssessmentBatteryPart_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_AssessmentBatteryPart_aggid ON edfi.AssessmentBatteryPart (AggregateId);


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


CREATE SEQUENCE edfi.Candidate_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Candidate ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Candidate_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Candidate_aggid ON edfi.Candidate (AggregateId);


CREATE SEQUENCE edfi.CandidateEducatorPreparationProgramAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CandidateEducatorPreparationProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CandidateEducatorPreparationProgramAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CandidateEducatorPreparationProgramAssociation_aggid ON edfi.CandidateEducatorPreparationProgramAssociation (AggregateId);


CREATE SEQUENCE edfi.CandidateIdentity_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CandidateIdentity ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CandidateIdentity_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CandidateIdentity_aggid ON edfi.CandidateIdentity (AggregateId);


CREATE SEQUENCE edfi.CandidateRelationshipToStaffAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CandidateRelationshipToStaffAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CandidateRelationshipToStaffAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CandidateRelationshipToStaffAssociation_aggid ON edfi.CandidateRelationshipToStaffAssociation (AggregateId);


CREATE SEQUENCE edfi.Certification_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Certification ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Certification_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Certification_aggid ON edfi.Certification (AggregateId);


CREATE SEQUENCE edfi.CertificationExam_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CertificationExam ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CertificationExam_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CertificationExam_aggid ON edfi.CertificationExam (AggregateId);


CREATE SEQUENCE edfi.CertificationExamResult_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CertificationExamResult ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CertificationExamResult_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CertificationExamResult_aggid ON edfi.CertificationExamResult (AggregateId);


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


CREATE SEQUENCE edfi.Contact_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Contact ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Contact_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Contact_aggid ON edfi.Contact (AggregateId);


CREATE SEQUENCE edfi.ContactIdentity_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ContactIdentity ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ContactIdentity_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ContactIdentity_aggid ON edfi.ContactIdentity (AggregateId);


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


CREATE SEQUENCE edfi.CredentialEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CredentialEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CredentialEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CredentialEvent_aggid ON edfi.CredentialEvent (AggregateId);


CREATE SEQUENCE edfi.CrisisEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.CrisisEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.CrisisEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_CrisisEvent_aggid ON edfi.CrisisEvent (AggregateId);


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


CREATE SEQUENCE edfi.EducationOrganizationIdentity_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationIdentity ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganizationIdentity_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganizationIdentity_aggid ON edfi.EducationOrganizationIdentity (AggregateId);


CREATE SEQUENCE edfi.EducationOrganizationInterventionPrescriptionAs_e670ae_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganizationInterventionPrescriptionAs_e670ae_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganizationInterventionPrescriptionAs_e670ae_aggid ON edfi.EducationOrganizationInterventionPrescriptionAssociation (AggregateId);


CREATE SEQUENCE edfi.EducationOrganizationNetworkAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganizationNetworkAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganizationNetworkAssociation_aggid ON edfi.EducationOrganizationNetworkAssociation (AggregateId);


CREATE SEQUENCE edfi.EducationOrganizationPeerAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducationOrganizationPeerAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducationOrganizationPeerAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducationOrganizationPeerAssociation_aggid ON edfi.EducationOrganizationPeerAssociation (AggregateId);


CREATE SEQUENCE edfi.EducatorPreparationProgram_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EducatorPreparationProgram ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EducatorPreparationProgram_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EducatorPreparationProgram_aggid ON edfi.EducatorPreparationProgram (AggregateId);


CREATE SEQUENCE edfi.Evaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Evaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Evaluation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Evaluation_aggid ON edfi.Evaluation (AggregateId);


CREATE SEQUENCE edfi.EvaluationElement_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationElement ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EvaluationElement_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EvaluationElement_aggid ON edfi.EvaluationElement (AggregateId);


CREATE SEQUENCE edfi.EvaluationElementRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationElementRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EvaluationElementRating_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EvaluationElementRating_aggid ON edfi.EvaluationElementRating (AggregateId);


CREATE SEQUENCE edfi.EvaluationObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EvaluationObjective_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EvaluationObjective_aggid ON edfi.EvaluationObjective (AggregateId);


CREATE SEQUENCE edfi.EvaluationObjectiveRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationObjectiveRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EvaluationObjectiveRating_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EvaluationObjectiveRating_aggid ON edfi.EvaluationObjectiveRating (AggregateId);


CREATE SEQUENCE edfi.EvaluationRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EvaluationRating_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EvaluationRating_aggid ON edfi.EvaluationRating (AggregateId);


CREATE SEQUENCE edfi.EvaluationRubricDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.EvaluationRubricDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.EvaluationRubricDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_EvaluationRubricDimension_aggid ON edfi.EvaluationRubricDimension (AggregateId);


CREATE SEQUENCE edfi.FeederSchoolAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FeederSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FeederSchoolAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FeederSchoolAssociation_aggid ON edfi.FeederSchoolAssociation (AggregateId);


CREATE SEQUENCE edfi.FieldworkExperience_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FieldworkExperience ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FieldworkExperience_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FieldworkExperience_aggid ON edfi.FieldworkExperience (AggregateId);


CREATE SEQUENCE edfi.FieldworkExperienceSectionAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FieldworkExperienceSectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FieldworkExperienceSectionAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FieldworkExperienceSectionAssociation_aggid ON edfi.FieldworkExperienceSectionAssociation (AggregateId);


CREATE SEQUENCE edfi.FinancialAid_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FinancialAid ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FinancialAid_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FinancialAid_aggid ON edfi.FinancialAid (AggregateId);


CREATE SEQUENCE edfi.FunctionDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FunctionDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FunctionDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FunctionDimension_aggid ON edfi.FunctionDimension (AggregateId);


CREATE SEQUENCE edfi.FundDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.FundDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.FundDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_FundDimension_aggid ON edfi.FundDimension (AggregateId);


CREATE SEQUENCE edfi.GeneralStudentProgramAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.GeneralStudentProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.GeneralStudentProgramAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_GeneralStudentProgramAssociation_aggid ON edfi.GeneralStudentProgramAssociation (AggregateId);


CREATE SEQUENCE edfi.Goal_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Goal ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Goal_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Goal_aggid ON edfi.Goal (AggregateId);


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


CREATE SEQUENCE edfi.OpenStaffPositionEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OpenStaffPositionEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.OpenStaffPositionEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_OpenStaffPositionEvent_aggid ON edfi.OpenStaffPositionEvent (AggregateId);


CREATE SEQUENCE edfi.OperationalUnitDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.OperationalUnitDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.OperationalUnitDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_OperationalUnitDimension_aggid ON edfi.OperationalUnitDimension (AggregateId);


CREATE SEQUENCE edfi.Path_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Path ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Path_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Path_aggid ON edfi.Path (AggregateId);


CREATE SEQUENCE edfi.PathMilestone_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PathMilestone ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.PathMilestone_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_PathMilestone_aggid ON edfi.PathMilestone (AggregateId);


CREATE SEQUENCE edfi.PathPhase_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PathPhase ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.PathPhase_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_PathPhase_aggid ON edfi.PathPhase (AggregateId);


CREATE SEQUENCE edfi.PerformanceEvaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PerformanceEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.PerformanceEvaluation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_PerformanceEvaluation_aggid ON edfi.PerformanceEvaluation (AggregateId);


CREATE SEQUENCE edfi.PerformanceEvaluationRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PerformanceEvaluationRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.PerformanceEvaluationRating_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_PerformanceEvaluationRating_aggid ON edfi.PerformanceEvaluationRating (AggregateId);


CREATE SEQUENCE edfi.Person_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Person ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Person_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Person_aggid ON edfi.Person (AggregateId);


CREATE SEQUENCE edfi.PostSecondaryEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.PostSecondaryEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.PostSecondaryEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_PostSecondaryEvent_aggid ON edfi.PostSecondaryEvent (AggregateId);


CREATE SEQUENCE edfi.ProfessionalDevelopmentEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProfessionalDevelopmentEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProfessionalDevelopmentEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProfessionalDevelopmentEvent_aggid ON edfi.ProfessionalDevelopmentEvent (AggregateId);


CREATE SEQUENCE edfi.ProfessionalDevelopmentEventAttendance_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProfessionalDevelopmentEventAttendance ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProfessionalDevelopmentEventAttendance_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProfessionalDevelopmentEventAttendance_aggid ON edfi.ProfessionalDevelopmentEventAttendance (AggregateId);


CREATE SEQUENCE edfi.Program_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.Program ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.Program_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Program_aggid ON edfi.Program (AggregateId);


CREATE SEQUENCE edfi.ProgramDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProgramDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProgramDimension_aggid ON edfi.ProgramDimension (AggregateId);


CREATE SEQUENCE edfi.ProgramEvaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProgramEvaluation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProgramEvaluation_aggid ON edfi.ProgramEvaluation (AggregateId);


CREATE SEQUENCE edfi.ProgramEvaluationElement_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluationElement ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProgramEvaluationElement_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProgramEvaluationElement_aggid ON edfi.ProgramEvaluationElement (AggregateId);


CREATE SEQUENCE edfi.ProgramEvaluationObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProgramEvaluationObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProgramEvaluationObjective_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProgramEvaluationObjective_aggid ON edfi.ProgramEvaluationObjective (AggregateId);


CREATE SEQUENCE edfi.ProjectDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ProjectDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ProjectDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ProjectDimension_aggid ON edfi.ProjectDimension (AggregateId);


CREATE SEQUENCE edfi.QuantitativeMeasure_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.QuantitativeMeasure ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.QuantitativeMeasure_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_QuantitativeMeasure_aggid ON edfi.QuantitativeMeasure (AggregateId);


CREATE SEQUENCE edfi.QuantitativeMeasureScore_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.QuantitativeMeasureScore ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.QuantitativeMeasureScore_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_QuantitativeMeasureScore_aggid ON edfi.QuantitativeMeasureScore (AggregateId);


CREATE SEQUENCE edfi.RecruitmentEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.RecruitmentEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.RecruitmentEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_RecruitmentEvent_aggid ON edfi.RecruitmentEvent (AggregateId);


CREATE SEQUENCE edfi.RecruitmentEventAttendance_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.RecruitmentEventAttendance ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.RecruitmentEventAttendance_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_RecruitmentEventAttendance_aggid ON edfi.RecruitmentEventAttendance (AggregateId);


CREATE SEQUENCE edfi.ReportCard_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.ReportCard ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.ReportCard_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_ReportCard_aggid ON edfi.ReportCard (AggregateId);


CREATE SEQUENCE edfi.RestraintEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.RestraintEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.RestraintEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_RestraintEvent_aggid ON edfi.RestraintEvent (AggregateId);


CREATE SEQUENCE edfi.RubricDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.RubricDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.RubricDimension_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_RubricDimension_aggid ON edfi.RubricDimension (AggregateId);


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


CREATE SEQUENCE edfi.StaffDemographic_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffDemographic ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffDemographic_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffDemographic_aggid ON edfi.StaffDemographic (AggregateId);


CREATE SEQUENCE edfi.StaffDirectory_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffDirectory ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffDirectory_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffDirectory_aggid ON edfi.StaffDirectory (AggregateId);


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


CREATE SEQUENCE edfi.StaffEducatorPreparationProgramAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffEducatorPreparationProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffEducatorPreparationProgramAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffEducatorPreparationProgramAssociation_aggid ON edfi.StaffEducatorPreparationProgramAssociation (AggregateId);


CREATE SEQUENCE edfi.StaffIdentity_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StaffIdentity ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StaffIdentity_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StaffIdentity_aggid ON edfi.StaffIdentity (AggregateId);


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


CREATE SEQUENCE edfi.StudentAssessmentRegistration_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessmentRegistration ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentAssessmentRegistration_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentAssessmentRegistration_aggid ON edfi.StudentAssessmentRegistration (AggregateId);


CREATE SEQUENCE edfi.StudentAssessmentRegistrationBatteryPartAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentAssessmentRegistrationBatteryPartAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentAssessmentRegistrationBatteryPartAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentAssessmentRegistrationBatteryPartAssociation_aggid ON edfi.StudentAssessmentRegistrationBatteryPartAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentCohortAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCohortAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentCohortAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentCohortAssociation_aggid ON edfi.StudentCohortAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentCompetencyObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentCompetencyObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentCompetencyObjective_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentCompetencyObjective_aggid ON edfi.StudentCompetencyObjective (AggregateId);


CREATE SEQUENCE edfi.StudentContactAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentContactAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentContactAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentContactAssociation_aggid ON edfi.StudentContactAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentDemographic_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDemographic ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentDemographic_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentDemographic_aggid ON edfi.StudentDemographic (AggregateId);


CREATE SEQUENCE edfi.StudentDirectory_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDirectory ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentDirectory_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentDirectory_aggid ON edfi.StudentDirectory (AggregateId);


CREATE SEQUENCE edfi.StudentDisciplineIncidentBehaviorAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentDisciplineIncidentBehaviorAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentDisciplineIncidentBehaviorAssociation_aggid ON edfi.StudentDisciplineIncidentBehaviorAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentDisciplineIncidentNonOffenderAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentDisciplineIncidentNonOffenderAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentDisciplineIncidentNonOffenderAssociation_aggid ON edfi.StudentDisciplineIncidentNonOffenderAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentEducationOrganizationAssessmentAccommodation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationAssessmentAccommodation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentEducationOrganizationAssessmentAccommodation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentEducationOrganizationAssessmentAccommodation_aggid ON edfi.StudentEducationOrganizationAssessmentAccommodation (AggregateId);


CREATE SEQUENCE edfi.StudentEducationOrganizationAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentEducationOrganizationAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentEducationOrganizationAssociation_aggid ON edfi.StudentEducationOrganizationAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentEducationOrganizationResponsibilityAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentEducationOrganizationResponsibilityAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentEducationOrganizationResponsibilityAssociation_aggid ON edfi.StudentEducationOrganizationResponsibilityAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentGradebookEntry_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentGradebookEntry ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentGradebookEntry_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentGradebookEntry_aggid ON edfi.StudentGradebookEntry (AggregateId);


CREATE SEQUENCE edfi.StudentHealth_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentHealth ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentHealth_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentHealth_aggid ON edfi.StudentHealth (AggregateId);


CREATE SEQUENCE edfi.StudentIdentity_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentIdentity ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentIdentity_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentIdentity_aggid ON edfi.StudentIdentity (AggregateId);


CREATE SEQUENCE edfi.StudentInterventionAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentInterventionAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentInterventionAssociation_aggid ON edfi.StudentInterventionAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentInterventionAttendanceEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentInterventionAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentInterventionAttendanceEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentInterventionAttendanceEvent_aggid ON edfi.StudentInterventionAttendanceEvent (AggregateId);


CREATE SEQUENCE edfi.StudentPath_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentPath ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentPath_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentPath_aggid ON edfi.StudentPath (AggregateId);


CREATE SEQUENCE edfi.StudentPathMilestoneStatus_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentPathMilestoneStatus ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentPathMilestoneStatus_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentPathMilestoneStatus_aggid ON edfi.StudentPathMilestoneStatus (AggregateId);


CREATE SEQUENCE edfi.StudentPathPhaseStatus_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentPathPhaseStatus ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentPathPhaseStatus_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentPathPhaseStatus_aggid ON edfi.StudentPathPhaseStatus (AggregateId);


CREATE SEQUENCE edfi.StudentProgramAttendanceEvent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentProgramAttendanceEvent ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentProgramAttendanceEvent_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentProgramAttendanceEvent_aggid ON edfi.StudentProgramAttendanceEvent (AggregateId);


CREATE SEQUENCE edfi.StudentProgramEvaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentProgramEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentProgramEvaluation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentProgramEvaluation_aggid ON edfi.StudentProgramEvaluation (AggregateId);


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


CREATE SEQUENCE edfi.StudentSpecialEducationProgramEligibilityAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentSpecialEducationProgramEligibilityAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentSpecialEducationProgramEligibilityAssociation_aggid ON edfi.StudentSpecialEducationProgramEligibilityAssociation (AggregateId);


CREATE SEQUENCE edfi.StudentTransportation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.StudentTransportation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.StudentTransportation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentTransportation_aggid ON edfi.StudentTransportation (AggregateId);


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


CREATE SEQUENCE edfi.SurveyResponsePersonTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponsePersonTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyResponsePersonTargetAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyResponsePersonTargetAssociation_aggid ON edfi.SurveyResponsePersonTargetAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveyResponseStaffTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveyResponseStaffTargetAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveyResponseStaffTargetAssociation_aggid ON edfi.SurveyResponseStaffTargetAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveySection_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySection ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySection_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySection_aggid ON edfi.SurveySection (AggregateId);


CREATE SEQUENCE edfi.SurveySectionAggregateResponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionAggregateResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionAggregateResponse_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionAggregateResponse_aggid ON edfi.SurveySectionAggregateResponse (AggregateId);


CREATE SEQUENCE edfi.SurveySectionAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionAssociation_aggid ON edfi.SurveySectionAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveySectionResponse_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponse ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionResponse_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionResponse_aggid ON edfi.SurveySectionResponse (AggregateId);


CREATE SEQUENCE edfi.SurveySectionResponseEducationOrganizationTarge_730be1_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionResponseEducationOrganizationTarge_730be1_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionResponseEducationOrganizationTarge_730be1_aggid ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveySectionResponsePersonTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponsePersonTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionResponsePersonTargetAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionResponsePersonTargetAssociation_aggid ON edfi.SurveySectionResponsePersonTargetAssociation (AggregateId);


CREATE SEQUENCE edfi.SurveySectionResponseStaffTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('edfi.SurveySectionResponseStaffTargetAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SurveySectionResponseStaffTargetAssociation_aggid ON edfi.SurveySectionResponseStaffTargetAssociation (AggregateId);

