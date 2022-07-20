-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='academicweek' AND column_name='changeversion') THEN
ALTER TABLE edfi.academicweek
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='account' AND column_name='changeversion') THEN
ALTER TABLE edfi.account
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='accountcode' AND column_name='changeversion') THEN
ALTER TABLE edfi.accountcode
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='accountabilityrating' AND column_name='changeversion') THEN
ALTER TABLE edfi.accountabilityrating
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='actual' AND column_name='changeversion') THEN
ALTER TABLE edfi.actual
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='assessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.assessment
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='assessmentitem' AND column_name='changeversion') THEN
ALTER TABLE edfi.assessmentitem
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='assessmentscorerangelearningstandard' AND column_name='changeversion') THEN
ALTER TABLE edfi.assessmentscorerangelearningstandard
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='bellschedule' AND column_name='changeversion') THEN
ALTER TABLE edfi.bellschedule
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='budget' AND column_name='changeversion') THEN
ALTER TABLE edfi.budget
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='calendar' AND column_name='changeversion') THEN
ALTER TABLE edfi.calendar
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='calendardate' AND column_name='changeversion') THEN
ALTER TABLE edfi.calendardate
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='classperiod' AND column_name='changeversion') THEN
ALTER TABLE edfi.classperiod
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='cohort' AND column_name='changeversion') THEN
ALTER TABLE edfi.cohort
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='communityproviderlicense' AND column_name='changeversion') THEN
ALTER TABLE edfi.communityproviderlicense
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='competencyobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.competencyobjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='contractedstaff' AND column_name='changeversion') THEN
ALTER TABLE edfi.contractedstaff
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='course' AND column_name='changeversion') THEN
ALTER TABLE edfi.course
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='courseoffering' AND column_name='changeversion') THEN
ALTER TABLE edfi.courseoffering
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='coursetranscript' AND column_name='changeversion') THEN
ALTER TABLE edfi.coursetranscript
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='credential' AND column_name='changeversion') THEN
ALTER TABLE edfi.credential
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='descriptor' AND column_name='changeversion') THEN
ALTER TABLE edfi.descriptor
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='disciplineaction' AND column_name='changeversion') THEN
ALTER TABLE edfi.disciplineaction
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='disciplineincident' AND column_name='changeversion') THEN
ALTER TABLE edfi.disciplineincident
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationcontent' AND column_name='changeversion') THEN
ALTER TABLE edfi.educationcontent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganization' AND column_name='changeversion') THEN
ALTER TABLE edfi.educationorganization
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganizationinterventionprescriptionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.educationorganizationinterventionprescriptionassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganizationnetworkassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.educationorganizationnetworkassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='educationorganizationpeerassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.educationorganizationpeerassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='feederschoolassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.feederschoolassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='generalstudentprogramassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.generalstudentprogramassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='grade' AND column_name='changeversion') THEN
ALTER TABLE edfi.grade
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='gradebookentry' AND column_name='changeversion') THEN
ALTER TABLE edfi.gradebookentry
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='gradingperiod' AND column_name='changeversion') THEN
ALTER TABLE edfi.gradingperiod
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='graduationplan' AND column_name='changeversion') THEN
ALTER TABLE edfi.graduationplan
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='intervention' AND column_name='changeversion') THEN
ALTER TABLE edfi.intervention
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='interventionprescription' AND column_name='changeversion') THEN
ALTER TABLE edfi.interventionprescription
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='interventionstudy' AND column_name='changeversion') THEN
ALTER TABLE edfi.interventionstudy
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='learningobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.learningobjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='learningstandard' AND column_name='changeversion') THEN
ALTER TABLE edfi.learningstandard
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='learningstandardequivalenceassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.learningstandardequivalenceassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='location' AND column_name='changeversion') THEN
ALTER TABLE edfi.location
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='objectiveassessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.objectiveassessment
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='openstaffposition' AND column_name='changeversion') THEN
ALTER TABLE edfi.openstaffposition
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='parent' AND column_name='changeversion') THEN
ALTER TABLE edfi.parent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='payroll' AND column_name='changeversion') THEN
ALTER TABLE edfi.payroll
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='person' AND column_name='changeversion') THEN
ALTER TABLE edfi.person
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='postsecondaryevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.postsecondaryevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='program' AND column_name='changeversion') THEN
ALTER TABLE edfi.program
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='reportcard' AND column_name='changeversion') THEN
ALTER TABLE edfi.reportcard
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='restraintevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.restraintevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='schoolyeartype' AND column_name='changeversion') THEN
ALTER TABLE edfi.schoolyeartype
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='section' AND column_name='changeversion') THEN
ALTER TABLE edfi.section
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='sectionattendancetakenevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.sectionattendancetakenevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='session' AND column_name='changeversion') THEN
ALTER TABLE edfi.session
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staff' AND column_name='changeversion') THEN
ALTER TABLE edfi.staff
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffabsenceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffabsenceevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffcohortassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffcohortassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffdisciplineincidentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffdisciplineincidentassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffeducationorganizationassignmentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffeducationorganizationassignmentassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffeducationorganizationcontactassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffeducationorganizationcontactassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffeducationorganizationemploymentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffeducationorganizationemploymentassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffleave' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffleave
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffprogramassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffprogramassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffschoolassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffschoolassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='staffsectionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.staffsectionassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='student' AND column_name='changeversion') THEN
ALTER TABLE edfi.student
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentacademicrecord' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentacademicrecord
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentassessment' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentassessment
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentcohortassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentcohortassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentcompetencyobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentcompetencyobjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentdisciplineincidentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentdisciplineincidentassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentdisciplineincidentbehaviorassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentdisciplineincidentbehaviorassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentdisciplineincidentnonoffenderassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentdisciplineincidentnonoffenderassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studenteducationorganizationassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studenteducationorganizationassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studenteducationorganizationresponsibilityassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studenteducationorganizationresponsibilityassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentgradebookentry' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentgradebookentry
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentinterventionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentinterventionassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentinterventionattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentinterventionattendanceevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentlearningobjective' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentlearningobjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentparentassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentparentassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentprogramattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentprogramattendanceevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentschoolassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentschoolassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentschoolattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentschoolattendanceevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentsectionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentsectionassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='studentsectionattendanceevent' AND column_name='changeversion') THEN
ALTER TABLE edfi.studentsectionattendanceevent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='survey' AND column_name='changeversion') THEN
ALTER TABLE edfi.survey
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveycourseassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveycourseassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyprogramassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveyprogramassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyquestion' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveyquestion
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyquestionresponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveyquestionresponse
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyresponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveyresponse
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyresponseeducationorganizationtargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveyresponseeducationorganizationtargetassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveyresponsestafftargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveyresponsestafftargetassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysection' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveysection
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveysectionassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionresponse' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveysectionresponse
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionresponseeducationorganizationtargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveysectionresponseeducationorganizationtargetassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='edfi' AND table_name='surveysectionresponsestafftargetassociation' AND column_name='changeversion') THEN
ALTER TABLE edfi.surveysectionresponsestafftargetassociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

END
$$;
