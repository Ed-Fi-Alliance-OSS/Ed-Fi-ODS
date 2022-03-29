-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS ux_a97956_changeversion ON edfi.academicweek(changeversion);

CREATE INDEX IF NOT EXISTS ux_7e1b0d_changeversion ON edfi.account(changeversion);

CREATE INDEX IF NOT EXISTS ux_2d3c0c_changeversion ON edfi.accountabilityrating(changeversion);

CREATE INDEX IF NOT EXISTS ux_fb1ef3_changeversion ON edfi.accountcode(changeversion);

CREATE INDEX IF NOT EXISTS ux_c40642_changeversion ON edfi.actual(changeversion);

CREATE INDEX IF NOT EXISTS ux_7808ee_changeversion ON edfi.assessment(changeversion);

CREATE INDEX IF NOT EXISTS ux_dc3dcf_changeversion ON edfi.assessmentitem(changeversion);

CREATE INDEX IF NOT EXISTS ux_a20588_changeversion ON edfi.assessmentscorerangelearningstandard(changeversion);

CREATE INDEX IF NOT EXISTS ux_9bbaf5_changeversion ON edfi.bellschedule(changeversion);

CREATE INDEX IF NOT EXISTS ux_1c6225_changeversion ON edfi.budget(changeversion);

CREATE INDEX IF NOT EXISTS ux_d5d0a3_changeversion ON edfi.calendar(changeversion);

CREATE INDEX IF NOT EXISTS ux_8a9a67_changeversion ON edfi.calendardate(changeversion);

CREATE INDEX IF NOT EXISTS ux_01fe80_changeversion ON edfi.classperiod(changeversion);

CREATE INDEX IF NOT EXISTS ux_19c6d6_changeversion ON edfi.cohort(changeversion);

CREATE INDEX IF NOT EXISTS ux_f092ff_changeversion ON edfi.communityproviderlicense(changeversion);

CREATE INDEX IF NOT EXISTS ux_5e9932_changeversion ON edfi.competencyobjective(changeversion);

CREATE INDEX IF NOT EXISTS ux_57ca0f_changeversion ON edfi.contractedstaff(changeversion);

CREATE INDEX IF NOT EXISTS ux_2096ce_changeversion ON edfi.course(changeversion);

CREATE INDEX IF NOT EXISTS ux_0325c5_changeversion ON edfi.courseoffering(changeversion);

CREATE INDEX IF NOT EXISTS ux_6acf2b_changeversion ON edfi.coursetranscript(changeversion);

CREATE INDEX IF NOT EXISTS ux_b1c42b_changeversion ON edfi.credential(changeversion);

CREATE INDEX IF NOT EXISTS ux_219915_changeversion ON edfi.descriptor(changeversion);

CREATE INDEX IF NOT EXISTS ux_eec7b6_changeversion ON edfi.disciplineaction(changeversion);

CREATE INDEX IF NOT EXISTS ux_e45c0b_changeversion ON edfi.disciplineincident(changeversion);

CREATE INDEX IF NOT EXISTS ux_9965a5_changeversion ON edfi.educationcontent(changeversion);

CREATE INDEX IF NOT EXISTS ux_4525e6_changeversion ON edfi.educationorganization(changeversion);

CREATE INDEX IF NOT EXISTS ux_e670ae_changeversion ON edfi.educationorganizationinterventionprescriptionassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_252151_changeversion ON edfi.educationorganizationnetworkassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_74e4e5_changeversion ON edfi.educationorganizationpeerassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_11f7b6_changeversion ON edfi.feederschoolassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_0516f9_changeversion ON edfi.generalstudentprogramassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_839e20_changeversion ON edfi.grade(changeversion);

CREATE INDEX IF NOT EXISTS ux_466cfa_changeversion ON edfi.gradebookentry(changeversion);

CREATE INDEX IF NOT EXISTS ux_5a18f9_changeversion ON edfi.gradingperiod(changeversion);

CREATE INDEX IF NOT EXISTS ux_be1ea4_changeversion ON edfi.graduationplan(changeversion);

CREATE INDEX IF NOT EXISTS ux_0fae05_changeversion ON edfi.intervention(changeversion);

CREATE INDEX IF NOT EXISTS ux_e93bc3_changeversion ON edfi.interventionprescription(changeversion);

CREATE INDEX IF NOT EXISTS ux_d92986_changeversion ON edfi.interventionstudy(changeversion);

CREATE INDEX IF NOT EXISTS ux_588d15_changeversion ON edfi.learningobjective(changeversion);

CREATE INDEX IF NOT EXISTS ux_8ceb4c_changeversion ON edfi.learningstandard(changeversion);

CREATE INDEX IF NOT EXISTS ux_17c02a_changeversion ON edfi.learningstandardequivalenceassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_15b619_changeversion ON edfi.location(changeversion);

CREATE INDEX IF NOT EXISTS ux_269e10_changeversion ON edfi.objectiveassessment(changeversion);

CREATE INDEX IF NOT EXISTS ux_3cc1d4_changeversion ON edfi.openstaffposition(changeversion);

CREATE INDEX IF NOT EXISTS ux_5f7953_changeversion ON edfi.parent(changeversion);

CREATE INDEX IF NOT EXISTS ux_53fe8d_changeversion ON edfi.payroll(changeversion);

CREATE INDEX IF NOT EXISTS ux_6007db_changeversion ON edfi.person(changeversion);

CREATE INDEX IF NOT EXISTS ux_b8b6d7_changeversion ON edfi.postsecondaryevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_90920d_changeversion ON edfi.program(changeversion);

CREATE INDEX IF NOT EXISTS ux_ec1992_changeversion ON edfi.reportcard(changeversion);

CREATE INDEX IF NOT EXISTS ux_3800be_changeversion ON edfi.restraintevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_464d7a_changeversion ON edfi.schoolyeartype(changeversion);

CREATE INDEX IF NOT EXISTS ux_dfca5d_changeversion ON edfi.section(changeversion);

CREATE INDEX IF NOT EXISTS ux_7bbbe7_changeversion ON edfi.sectionattendancetakenevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_6959b4_changeversion ON edfi.session(changeversion);

CREATE INDEX IF NOT EXISTS ux_681927_changeversion ON edfi.staff(changeversion);

CREATE INDEX IF NOT EXISTS ux_b13bbd_changeversion ON edfi.staffabsenceevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_170747_changeversion ON edfi.staffcohortassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_af86db_changeversion ON edfi.staffdisciplineincidentassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_b9be24_changeversion ON edfi.staffeducationorganizationassignmentassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_735dd8_changeversion ON edfi.staffeducationorganizationcontactassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_4e79b9_changeversion ON edfi.staffeducationorganizationemploymentassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_debd4f_changeversion ON edfi.staffleave(changeversion);

CREATE INDEX IF NOT EXISTS ux_a9c0d9_changeversion ON edfi.staffprogramassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_ce2080_changeversion ON edfi.staffschoolassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_515cb5_changeversion ON edfi.staffsectionassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_2a164d_changeversion ON edfi.student(changeversion);

CREATE INDEX IF NOT EXISTS ux_0ff8d6_changeversion ON edfi.studentacademicrecord(changeversion);

CREATE INDEX IF NOT EXISTS ux_ee3b2a_changeversion ON edfi.studentassessment(changeversion);

CREATE INDEX IF NOT EXISTS ux_369ddc_changeversion ON edfi.studentcohortassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_395c07_changeversion ON edfi.studentcompetencyobjective(changeversion);

CREATE INDEX IF NOT EXISTS ux_679174_changeversion ON edfi.studentdisciplineincidentassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_f4934f_changeversion ON edfi.studentdisciplineincidentbehaviorassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_4b43da_changeversion ON edfi.studentdisciplineincidentnonoffenderassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_8e1257_changeversion ON edfi.studenteducationorganizationassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_42aa64_changeversion ON edfi.studenteducationorganizationresponsibilityassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_c2efaa_changeversion ON edfi.studentgradebookentry(changeversion);

CREATE INDEX IF NOT EXISTS ux_25cb9c_changeversion ON edfi.studentinterventionassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_631023_changeversion ON edfi.studentinterventionattendanceevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_baaa9d_changeversion ON edfi.studentlearningobjective(changeversion);

CREATE INDEX IF NOT EXISTS ux_bf9d92_changeversion ON edfi.studentparentassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_317aeb_changeversion ON edfi.studentprogramattendanceevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_857b52_changeversion ON edfi.studentschoolassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_78fd7f_changeversion ON edfi.studentschoolattendanceevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_39aa3c_changeversion ON edfi.studentsectionassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_61b087_changeversion ON edfi.studentsectionattendanceevent(changeversion);

CREATE INDEX IF NOT EXISTS ux_211bb3_changeversion ON edfi.survey(changeversion);

CREATE INDEX IF NOT EXISTS ux_9f1246_changeversion ON edfi.surveycourseassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_e3e5a4_changeversion ON edfi.surveyprogramassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_1bb88c_changeversion ON edfi.surveyquestion(changeversion);

CREATE INDEX IF NOT EXISTS ux_eddd02_changeversion ON edfi.surveyquestionresponse(changeversion);

CREATE INDEX IF NOT EXISTS ux_8d6383_changeversion ON edfi.surveyresponse(changeversion);

CREATE INDEX IF NOT EXISTS ux_b2bd0a_changeversion ON edfi.surveyresponseeducationorganizationtargetassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_f9457e_changeversion ON edfi.surveyresponsestafftargetassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_e5572a_changeversion ON edfi.surveysection(changeversion);

CREATE INDEX IF NOT EXISTS ux_c16804_changeversion ON edfi.surveysectionassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_2189c3_changeversion ON edfi.surveysectionresponse(changeversion);

CREATE INDEX IF NOT EXISTS ux_730be1_changeversion ON edfi.surveysectionresponseeducationorganizationtargetassociation(changeversion);

CREATE INDEX IF NOT EXISTS ux_39073d_changeversion ON edfi.surveysectionresponsestafftargetassociation(changeversion);

