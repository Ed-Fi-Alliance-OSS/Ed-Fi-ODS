-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE UNIQUE INDEX IF NOT EXISTS UX_a97956_Id ON edfi.AcademicWeek(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2d3c0c_Id ON edfi.AccountabilityRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_c322dc_Id ON edfi.ApplicantProfile(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e7ad52_Id ON edfi.Application(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_143de6_Id ON edfi.ApplicationEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_7808ee_Id ON edfi.Assessment(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_c64558_Id ON edfi.AssessmentAdministration(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_77818e_Id ON edfi.AssessmentAdministrationParticipation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6e22f2_Id ON edfi.AssessmentBatteryPart(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_dc3dcf_Id ON edfi.AssessmentItem(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a20588_Id ON edfi.AssessmentScoreRangeLearningStandard(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e52c9c_Id ON edfi.BalanceSheetDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_9bbaf5_Id ON edfi.BellSchedule(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_d5d0a3_Id ON edfi.Calendar(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8a9a67_Id ON edfi.CalendarDate(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b2452d_Id ON edfi.Candidate(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fc61b2_Id ON edfi.CandidateEducatorPreparationProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fa1b90_Id ON edfi.CandidateIdentity(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_610f76_Id ON edfi.CandidateRelationshipToStaffAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_86846f_Id ON edfi.Certification(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_cb139c_Id ON edfi.CertificationExam(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_aed83e_Id ON edfi.CertificationExamResult(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_131e2b_Id ON edfi.ChartOfAccount(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_01fe80_Id ON edfi.ClassPeriod(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_19c6d6_Id ON edfi.Cohort(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f092ff_Id ON edfi.CommunityProviderLicense(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_5e9932_Id ON edfi.CompetencyObjective(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2b5c3d_Id ON edfi.Contact(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_19b8bf_Id ON edfi.ContactIdentity(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2096ce_Id ON edfi.Course(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_0325c5_Id ON edfi.CourseOffering(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6acf2b_Id ON edfi.CourseTranscript(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b1c42b_Id ON edfi.Credential(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_3d6d96_Id ON edfi.CredentialEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f1bbb4_Id ON edfi.CrisisEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_219915_Id ON edfi.Descriptor(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_ee9047_Id ON edfi.DescriptorMapping(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_eec7b6_Id ON edfi.DisciplineAction(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e45c0b_Id ON edfi.DisciplineIncident(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_9965a5_Id ON edfi.EducationContent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4525e6_Id ON edfi.EducationOrganization(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_1b9f10_Id ON edfi.EducationOrganizationIdentity(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e670ae_Id ON edfi.EducationOrganizationInterventionPrescriptionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_252151_Id ON edfi.EducationOrganizationNetworkAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_74e4e5_Id ON edfi.EducationOrganizationPeerAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_195935_Id ON edfi.EducatorPreparationProgram(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_163e44_Id ON edfi.Evaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e53186_Id ON edfi.EvaluationElement(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4479ea_Id ON edfi.EvaluationElementRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_d4565d_Id ON edfi.EvaluationObjective(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_7ae19d_Id ON edfi.EvaluationObjectiveRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_bfaa20_Id ON edfi.EvaluationRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_1b7ccf_Id ON edfi.EvaluationRubricDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_11f7b6_Id ON edfi.FeederSchoolAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fd30bb_Id ON edfi.FieldworkExperience(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b2abcd_Id ON edfi.FieldworkExperienceSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a465f2_Id ON edfi.FinancialAid(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_c4d12e_Id ON edfi.FunctionDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_937af8_Id ON edfi.FundDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_0516f9_Id ON edfi.GeneralStudentProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_cdbf69_Id ON edfi.Goal(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_839e20_Id ON edfi.Grade(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_466cfa_Id ON edfi.GradebookEntry(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_5a18f9_Id ON edfi.GradingPeriod(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_be1ea4_Id ON edfi.GraduationPlan(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_0fae05_Id ON edfi.Intervention(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e93bc3_Id ON edfi.InterventionPrescription(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_d92986_Id ON edfi.InterventionStudy(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8ceb4c_Id ON edfi.LearningStandard(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_17c02a_Id ON edfi.LearningStandardEquivalenceAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_32eddb_Id ON edfi.LocalAccount(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b6310e_Id ON edfi.LocalActual(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_000683_Id ON edfi.LocalBudget(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4d9b4a_Id ON edfi.LocalContractedStaff(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_ea526f_Id ON edfi.LocalEncumbrance(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_46e5c2_Id ON edfi.LocalPayroll(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_15b619_Id ON edfi.Location(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4100ee_Id ON edfi.ObjectDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_269e10_Id ON edfi.ObjectiveAssessment(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_3cc1d4_Id ON edfi.OpenStaffPosition(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e809b0_Id ON edfi.OpenStaffPositionEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_28b7c4_Id ON edfi.OperationalUnitDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_62fa5a_Id ON edfi.Path(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_63a11e_Id ON edfi.PathMilestone(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_94a0ce_Id ON edfi.PathPhase(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_15d685_Id ON edfi.PerformanceEvaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_759abe_Id ON edfi.PerformanceEvaluationRating(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6007db_Id ON edfi.Person(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b8b6d7_Id ON edfi.PostSecondaryEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8c4ca1_Id ON edfi.ProfessionalDevelopmentEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_22e412_Id ON edfi.ProfessionalDevelopmentEventAttendance(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_90920d_Id ON edfi.Program(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a9a613_Id ON edfi.ProgramDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f3a20e_Id ON edfi.ProgramEvaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_784616_Id ON edfi.ProgramEvaluationElement(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a53c6c_Id ON edfi.ProgramEvaluationObjective(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_d16e19_Id ON edfi.ProjectDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8b89fe_Id ON edfi.QuantitativeMeasure(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e61067_Id ON edfi.QuantitativeMeasureScore(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6232e8_Id ON edfi.RecruitmentEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fca83b_Id ON edfi.RecruitmentEventAttendance(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_ec1992_Id ON edfi.ReportCard(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_3800be_Id ON edfi.RestraintEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_643c81_Id ON edfi.RubricDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_464d7a_Id ON edfi.SchoolYearType(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_dfca5d_Id ON edfi.Section(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_7bbbe7_Id ON edfi.SectionAttendanceTakenEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6959b4_Id ON edfi.Session(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e91a4d_Id ON edfi.SourceDimension(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_681927_Id ON edfi.Staff(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b13bbd_Id ON edfi.StaffAbsenceEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_170747_Id ON edfi.StaffCohortAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_29eb62_Id ON edfi.StaffDemographic(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_0ebb99_Id ON edfi.StaffDirectory(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_af86db_Id ON edfi.StaffDisciplineIncidentAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b9be24_Id ON edfi.StaffEducationOrganizationAssignmentAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4e79b9_Id ON edfi.StaffEducationOrganizationEmploymentAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2c9294_Id ON edfi.StaffEducatorPreparationProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_bb3aab_Id ON edfi.StaffIdentity(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_debd4f_Id ON edfi.StaffLeave(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a9c0d9_Id ON edfi.StaffProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_ce2080_Id ON edfi.StaffSchoolAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_515cb5_Id ON edfi.StaffSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2a164d_Id ON edfi.Student(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_0ff8d6_Id ON edfi.StudentAcademicRecord(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_ee3b2a_Id ON edfi.StudentAssessment(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_afb8b8_Id ON edfi.StudentAssessmentEducationOrganizationAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_79fd6b_Id ON edfi.StudentAssessmentRegistration(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_3bb369_Id ON edfi.StudentAssessmentRegistrationBatteryPartAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_369ddc_Id ON edfi.StudentCohortAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_395c07_Id ON edfi.StudentCompetencyObjective(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e2733e_Id ON edfi.StudentContactAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_576573_Id ON edfi.StudentDemographic(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6e4afb_Id ON edfi.StudentDirectory(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f4934f_Id ON edfi.StudentDisciplineIncidentBehaviorAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4b43da_Id ON edfi.StudentDisciplineIncidentNonOffenderAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_5f4481_Id ON edfi.StudentEducationOrganizationAssessmentAccommodation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8e1257_Id ON edfi.StudentEducationOrganizationAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_42aa64_Id ON edfi.StudentEducationOrganizationResponsibilityAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_c2efaa_Id ON edfi.StudentGradebookEntry(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_12f7e6_Id ON edfi.StudentHealth(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_45727b_Id ON edfi.StudentIdentity(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_25cb9c_Id ON edfi.StudentInterventionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_631023_Id ON edfi.StudentInterventionAttendanceEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_efd39c_Id ON edfi.StudentPath(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_bffe71_Id ON edfi.StudentPathMilestoneStatus(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_a174cf_Id ON edfi.StudentPathPhaseStatus(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_317aeb_Id ON edfi.StudentProgramAttendanceEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_4b1054_Id ON edfi.StudentProgramEvaluation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_857b52_Id ON edfi.StudentSchoolAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_78fd7f_Id ON edfi.StudentSchoolAttendanceEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_39aa3c_Id ON edfi.StudentSectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_61b087_Id ON edfi.StudentSectionAttendanceEvent(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_fcb699_Id ON edfi.StudentSpecialEducationProgramEligibilityAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_68afad_Id ON edfi.StudentTransportation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_211bb3_Id ON edfi.Survey(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_9f1246_Id ON edfi.SurveyCourseAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e3e5a4_Id ON edfi.SurveyProgramAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_1bb88c_Id ON edfi.SurveyQuestion(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_eddd02_Id ON edfi.SurveyQuestionResponse(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_8d6383_Id ON edfi.SurveyResponse(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_b2bd0a_Id ON edfi.SurveyResponseEducationOrganizationTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_520027_Id ON edfi.SurveyResponsePersonTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f9457e_Id ON edfi.SurveyResponseStaffTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e5572a_Id ON edfi.SurveySection(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_f37ae9_Id ON edfi.SurveySectionAggregateResponse(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_c16804_Id ON edfi.SurveySectionAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2189c3_Id ON edfi.SurveySectionResponse(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_730be1_Id ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_e21e4b_Id ON edfi.SurveySectionResponsePersonTargetAssociation(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_39073d_Id ON edfi.SurveySectionResponseStaffTargetAssociation(Id);

