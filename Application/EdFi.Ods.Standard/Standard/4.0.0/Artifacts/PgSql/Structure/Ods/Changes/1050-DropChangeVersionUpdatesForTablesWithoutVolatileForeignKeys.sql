-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'academicweek') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.academicweek';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'accountabilityrating') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.accountabilityrating';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'assessment') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.assessment';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitem') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.assessmentitem';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentscorerangelearningstandard') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.assessmentscorerangelearningstandard';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'balancesheetdimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.balancesheetdimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'bellschedule') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.bellschedule';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'calendar') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.calendar';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'calendardate') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.calendardate';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'chartofaccount') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.chartofaccount';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'classperiod') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.classperiod';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'cohort') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.cohort';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'communityproviderlicense') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.communityproviderlicense';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'competencyobjective') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.competencyobjective';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'course') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.course';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'coursetranscript') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.coursetranscript';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'credential') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.credential';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'descriptor') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.descriptor';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'descriptormapping') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.descriptormapping';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineaction') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.disciplineaction';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineincident') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.disciplineincident';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationcontent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.educationcontent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganization') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.educationorganization';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationinterventionprescriptionassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.educationorganizationinterventionprescriptionassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationnetworkassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.educationorganizationnetworkassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationpeerassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.educationorganizationpeerassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'feederschoolassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.feederschoolassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'functiondimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.functiondimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'funddimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.funddimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'generalstudentprogramassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.generalstudentprogramassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'gradingperiod') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.gradingperiod';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'graduationplan') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.graduationplan';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'intervention') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.intervention';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'interventionprescription') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.interventionprescription';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'interventionstudy') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.interventionstudy';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'learningobjective') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.learningobjective';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandard') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.learningstandard';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardequivalenceassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.learningstandardequivalenceassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localaccount') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.localaccount';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localactual') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.localactual';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localbudget') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.localbudget';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localcontractedstaff') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.localcontractedstaff';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localencumbrance') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.localencumbrance';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localpayroll') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.localpayroll';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'location') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.location';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'objectdimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.objectdimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'objectiveassessment') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.objectiveassessment';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffposition') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.openstaffposition';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'operationalunitdimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.operationalunitdimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'parent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.parent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'person') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.person';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryevent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.postsecondaryevent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'program') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.program';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'programdimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.programdimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'projectdimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.projectdimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'reportcard') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.reportcard';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'restraintevent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.restraintevent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'schoolyeartype') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.schoolyeartype';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'session') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.session';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'sourcedimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.sourcedimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staff') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staff';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffabsenceevent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffabsenceevent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffcohortassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffcohortassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffdisciplineincidentassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffdisciplineincidentassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationassignmentassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffeducationorganizationassignmentassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationcontactassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffeducationorganizationcontactassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationemploymentassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffeducationorganizationemploymentassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffleave') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffleave';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffprogramassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffprogramassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffschoolassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.staffschoolassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'student') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.student';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentacademicrecord') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentacademicrecord';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessment') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentassessment';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessmenteducationorganizationassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentassessmenteducationorganizationassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentcohortassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentcohortassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentcompetencyobjective') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentcompetencyobjective';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentdisciplineincidentassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentbehaviorassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentdisciplineincidentbehaviorassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentnonoffenderassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentdisciplineincidentnonoffenderassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studenteducationorganizationassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationresponsibilityassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studenteducationorganizationresponsibilityassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentinterventionassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionattendanceevent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentinterventionattendanceevent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentlearningobjective') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentlearningobjective';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentparentassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentparentassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentprogramattendanceevent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentprogramattendanceevent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.studentschoolassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveycourseassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveycourseassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyprogramassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveyprogramassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestion') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveyquestion';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestionresponse') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveyquestionresponse';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponse') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveyresponse';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponseeducationorganizationtargetassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveyresponseeducationorganizationtargetassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponsestafftargetassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveyresponsestafftargetassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysection') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveysection';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponse') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveysectionresponse';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponseeducationorganizationtargetassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveysectionresponseeducationorganizationtargetassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponsestafftargetassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON edfi.surveysectionresponsestafftargetassociation';
END IF;

$$;
