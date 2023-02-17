-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'academicweek') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.academicweek
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'accountabilityrating') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.accountabilityrating
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'assessment') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.assessment
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitem') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.assessmentitem
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentscorerangelearningstandard') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.assessmentscorerangelearningstandard
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'balancesheetdimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.balancesheetdimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'bellschedule') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.bellschedule
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'calendar') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.calendar
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'calendardate') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.calendardate
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'chartofaccount') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.chartofaccount
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'classperiod') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.classperiod
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.classperiod_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.classperiod(
        oldclassperiodname, oldschoolid, 
        newclassperiodname, newschoolid, 
        id, changeversion)
    VALUES (
        old.classperiodname, old.schoolid, 
        new.classperiodname, new.schoolid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'classperiod') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF classperiodname, schoolid ON edfi.classperiod
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.classperiod_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'cohort') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.cohort
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'communityproviderlicense') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.communityproviderlicense
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'competencyobjective') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.competencyobjective
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'course') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.course
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'courseoffering') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.courseoffering
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courseoffering_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.courseoffering(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsessionname, 
        newlocalcoursecode, newschoolid, newschoolyear, newsessionname, 
        id, changeversion)
    VALUES (
        old.localcoursecode, old.schoolid, old.schoolyear, old.sessionname, 
        new.localcoursecode, new.schoolid, new.schoolyear, new.sessionname, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'courseoffering') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF localcoursecode, schoolid, schoolyear, sessionname ON edfi.courseoffering
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courseoffering_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'coursetranscript') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.coursetranscript
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'credential') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.credential
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'descriptor') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.descriptor
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'descriptormapping') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.descriptormapping
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineaction') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.disciplineaction
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineincident') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.disciplineincident
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationcontent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.educationcontent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganization') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.educationorganization
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationinterventionprescriptionassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.educationorganizationinterventionprescriptionassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationnetworkassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.educationorganizationnetworkassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationpeerassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.educationorganizationpeerassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'feederschoolassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.feederschoolassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'functiondimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.functiondimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'funddimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.funddimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'generalstudentprogramassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.generalstudentprogramassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'grade') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.grade
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.grade_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    ij0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    ij1 edfi.descriptor%ROWTYPE;
    dj2 edfi.student%ROWTYPE;
    ij2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.gradetypedescriptorid;
    SELECT INTO ij0 * FROM edfi.descriptor j0 WHERE descriptorid = new.gradetypedescriptorid;
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.gradingperioddescriptorid;
    SELECT INTO ij1 * FROM edfi.descriptor j1 WHERE descriptorid = new.gradingperioddescriptorid;
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;
    SELECT INTO ij2 * FROM edfi.student j2 WHERE studentusi = new.studentusi;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.grade(
        oldbegindate, oldgradetypedescriptorid, oldgradetypedescriptornamespace, oldgradetypedescriptorcodevalue, oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodschoolyear, oldgradingperiodsequence, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        newbegindate, newgradetypedescriptorid, newgradetypedescriptornamespace, newgradetypedescriptorcodevalue, newgradingperioddescriptorid, newgradingperioddescriptornamespace, newgradingperioddescriptorcodevalue, newgradingperiodschoolyear, newgradingperiodsequence, newlocalcoursecode, newschoolid, newschoolyear, newsectionidentifier, newsessionname, newstudentusi, newstudentuniqueid, 
        id, changeversion)
    VALUES (
        old.begindate, old.gradetypedescriptorid, dj0.namespace, dj0.codevalue, old.gradingperioddescriptorid, dj1.namespace, dj1.codevalue, old.gradingperiodschoolyear, old.gradingperiodsequence, old.localcoursecode, old.schoolid, old.schoolyear, old.sectionidentifier, old.sessionname, old.studentusi, dj2.studentuniqueid, 
        new.begindate, new.gradetypedescriptorid, ij0.namespace, ij0.codevalue, new.gradingperioddescriptorid, ij1.namespace, ij1.codevalue, new.gradingperiodschoolyear, new.gradingperiodsequence, new.localcoursecode, new.schoolid, new.schoolyear, new.sectionidentifier, new.sessionname, new.studentusi, ij2.studentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'grade') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF begindate, gradetypedescriptorid, gradingperioddescriptorid, gradingperiodschoolyear, gradingperiodsequence, localcoursecode, schoolid, schoolyear, sectionidentifier, sessionname, studentusi ON edfi.grade
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.grade_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'gradebookentry') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.gradebookentry
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradebookentry_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.gradebookentry(
        oldgradebookentryidentifier, oldnamespace, 
        newgradebookentryidentifier, newnamespace, 
        id, changeversion)
    VALUES (
        old.gradebookentryidentifier, old.namespace, 
        new.gradebookentryidentifier, new.namespace, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'gradebookentry') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF gradebookentryidentifier, namespace ON edfi.gradebookentry
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradebookentry_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'gradingperiod') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.gradingperiod
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'graduationplan') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.graduationplan
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'intervention') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.intervention
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'interventionprescription') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.interventionprescription
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'interventionstudy') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.interventionstudy
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'learningobjective') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.learningobjective
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandard') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.learningstandard
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardequivalenceassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.learningstandardequivalenceassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localaccount') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.localaccount
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localactual') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.localactual
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localbudget') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.localbudget
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localcontractedstaff') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.localcontractedstaff
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localencumbrance') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.localencumbrance
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'localpayroll') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.localpayroll
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'location') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.location
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.location_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.location(
        oldclassroomidentificationcode, oldschoolid, 
        newclassroomidentificationcode, newschoolid, 
        id, changeversion)
    VALUES (
        old.classroomidentificationcode, old.schoolid, 
        new.classroomidentificationcode, new.schoolid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'location') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF classroomidentificationcode, schoolid ON edfi.location
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.location_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'objectdimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.objectdimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'objectiveassessment') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.objectiveassessment
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffposition') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.openstaffposition
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'operationalunitdimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.operationalunitdimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'parent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.parent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.parent_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.parent(
        oldparentusi, oldparentuniqueid, 
        newparentusi, newparentuniqueid, 
        id, changeversion)
    VALUES (
        old.parentusi, old.parentuniqueid, 
        new.parentusi, new.parentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'parent') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF parentuniqueid ON edfi.parent
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.parent_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'person') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.person
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.postsecondaryevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'program') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.program
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'programdimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.programdimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'projectdimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.projectdimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'reportcard') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.reportcard
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'restraintevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.restraintevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'schoolyeartype') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.schoolyeartype
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'section') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.section
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.section_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.section(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, 
        newlocalcoursecode, newschoolid, newschoolyear, newsectionidentifier, newsessionname, 
        id, changeversion)
    VALUES (
        old.localcoursecode, old.schoolid, old.schoolyear, old.sectionidentifier, old.sessionname, 
        new.localcoursecode, new.schoolid, new.schoolyear, new.sectionidentifier, new.sessionname, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'section') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF localcoursecode, schoolid, schoolyear, sectionidentifier, sessionname ON edfi.section
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.section_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'sectionattendancetakenevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.sectionattendancetakenevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sectionattendancetakenevent_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.sectionattendancetakenevent(
        oldcalendarcode, olddate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, 
        newcalendarcode, newdate, newlocalcoursecode, newschoolid, newschoolyear, newsectionidentifier, newsessionname, 
        id, changeversion)
    VALUES (
        old.calendarcode, old.date, old.localcoursecode, old.schoolid, old.schoolyear, old.sectionidentifier, old.sessionname, 
        new.calendarcode, new.date, new.localcoursecode, new.schoolid, new.schoolyear, new.sectionidentifier, new.sessionname, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'sectionattendancetakenevent') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF calendarcode, date, localcoursecode, schoolid, schoolyear, sectionidentifier, sessionname ON edfi.sectionattendancetakenevent
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sectionattendancetakenevent_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'session') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.session
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.session_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.session(
        oldschoolid, oldschoolyear, oldsessionname, 
        newschoolid, newschoolyear, newsessionname, 
        id, changeversion)
    VALUES (
        old.schoolid, old.schoolyear, old.sessionname, 
        new.schoolid, new.schoolyear, new.sessionname, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'session') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF schoolid, schoolyear, sessionname ON edfi.session
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.session_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'sourcedimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.sourcedimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staff') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staff
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staff_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.staff(
        oldstaffusi, oldstaffuniqueid, 
        newstaffusi, newstaffuniqueid, 
        id, changeversion)
    VALUES (
        old.staffusi, old.staffuniqueid, 
        new.staffusi, new.staffuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'staff') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF staffuniqueid ON edfi.staff
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staff_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffabsenceevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffabsenceevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffcohortassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffcohortassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffdisciplineincidentassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffdisciplineincidentassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationassignmentassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffeducationorganizationassignmentassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationcontactassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffeducationorganizationcontactassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationemploymentassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffeducationorganizationemploymentassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffleave') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffleave
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffprogramassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffprogramassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffschoolassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffschoolassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'staffsectionassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.staffsectionassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffsectionassociation_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
    ij0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;
    SELECT INTO ij0 * FROM edfi.staff j0 WHERE staffusi = new.staffusi;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.staffsectionassociation(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstaffusi, oldstaffuniqueid, 
        newlocalcoursecode, newschoolid, newschoolyear, newsectionidentifier, newsessionname, newstaffusi, newstaffuniqueid, 
        id, changeversion)
    VALUES (
        old.localcoursecode, old.schoolid, old.schoolyear, old.sectionidentifier, old.sessionname, old.staffusi, dj0.staffuniqueid, 
        new.localcoursecode, new.schoolid, new.schoolyear, new.sectionidentifier, new.sessionname, new.staffusi, ij0.staffuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'staffsectionassociation') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF localcoursecode, schoolid, schoolyear, sectionidentifier, sessionname, staffusi ON edfi.staffsectionassociation
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffsectionassociation_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'student') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.student
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.student_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.student(
        oldstudentusi, oldstudentuniqueid, 
        newstudentusi, newstudentuniqueid, 
        id, changeversion)
    VALUES (
        old.studentusi, old.studentuniqueid, 
        new.studentusi, new.studentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'student') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF studentuniqueid ON edfi.student
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.student_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentacademicrecord') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentacademicrecord
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessment') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentassessment
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessmenteducationorganizationassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentassessmenteducationorganizationassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentcohortassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentcohortassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentcompetencyobjective') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentcompetencyobjective
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentdisciplineincidentassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentbehaviorassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentdisciplineincidentbehaviorassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentnonoffenderassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentdisciplineincidentnonoffenderassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studenteducationorganizationassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationresponsibilityassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studenteducationorganizationresponsibilityassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentgradebookentry') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentgradebookentry
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentgradebookentry_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
    ij0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;
    SELECT INTO ij0 * FROM edfi.student j0 WHERE studentusi = new.studentusi;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.studentgradebookentry(
        oldgradebookentryidentifier, oldnamespace, oldstudentusi, oldstudentuniqueid, 
        newgradebookentryidentifier, newnamespace, newstudentusi, newstudentuniqueid, 
        id, changeversion)
    VALUES (
        old.gradebookentryidentifier, old.namespace, old.studentusi, dj0.studentuniqueid, 
        new.gradebookentryidentifier, new.namespace, new.studentusi, ij0.studentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'studentgradebookentry') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF gradebookentryidentifier, namespace, studentusi ON edfi.studentgradebookentry
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentgradebookentry_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentinterventionassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionattendanceevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentinterventionattendanceevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentlearningobjective') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentlearningobjective
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentparentassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentparentassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentprogramattendanceevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentprogramattendanceevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentschoolassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentschoolassociation_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
    ij0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;
    SELECT INTO ij0 * FROM edfi.student j0 WHERE studentusi = new.studentusi;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.studentschoolassociation(
        oldentrydate, oldschoolid, oldstudentusi, oldstudentuniqueid, 
        newentrydate, newschoolid, newstudentusi, newstudentuniqueid, 
        id, changeversion)
    VALUES (
        old.entrydate, old.schoolid, old.studentusi, dj0.studentuniqueid, 
        new.entrydate, new.schoolid, new.studentusi, ij0.studentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolassociation') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF entrydate, schoolid, studentusi ON edfi.studentschoolassociation
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentschoolassociation_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolattendanceevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentschoolattendanceevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentschoolattendanceevent_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    ij0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
    ij1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;
    SELECT INTO ij0 * FROM edfi.descriptor j0 WHERE descriptorid = new.attendanceeventcategorydescriptorid;
    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;
    SELECT INTO ij1 * FROM edfi.student j1 WHERE studentusi = new.studentusi;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.studentschoolattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeventdate, oldschoolid, oldschoolyear, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        newattendanceeventcategorydescriptorid, newattendanceeventcategorydescriptornamespace, newattendanceeventcategorydescriptorcodevalue, neweventdate, newschoolid, newschoolyear, newsessionname, newstudentusi, newstudentuniqueid, 
        id, changeversion)
    VALUES (
        old.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, old.eventdate, old.schoolid, old.schoolyear, old.sessionname, old.studentusi, dj1.studentuniqueid, 
        new.attendanceeventcategorydescriptorid, ij0.namespace, ij0.codevalue, new.eventdate, new.schoolid, new.schoolyear, new.sessionname, new.studentusi, ij1.studentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolattendanceevent') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF attendanceeventcategorydescriptorid, eventdate, schoolid, schoolyear, sessionname, studentusi ON edfi.studentschoolattendanceevent
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentschoolattendanceevent_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentsectionassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentsectionassociation_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
    ij0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;
    SELECT INTO ij0 * FROM edfi.student j0 WHERE studentusi = new.studentusi;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.studentsectionassociation(
        oldbegindate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        newbegindate, newlocalcoursecode, newschoolid, newschoolyear, newsectionidentifier, newsessionname, newstudentusi, newstudentuniqueid, 
        id, changeversion)
    VALUES (
        old.begindate, old.localcoursecode, old.schoolid, old.schoolyear, old.sectionidentifier, old.sessionname, old.studentusi, dj0.studentuniqueid, 
        new.begindate, new.localcoursecode, new.schoolid, new.schoolyear, new.sectionidentifier, new.sessionname, new.studentusi, ij0.studentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionassociation') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF begindate, localcoursecode, schoolid, schoolyear, sectionidentifier, sessionname, studentusi ON edfi.studentsectionassociation
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentsectionassociation_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionattendanceevent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.studentsectionattendanceevent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentsectionattendanceevent_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    ij0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
    ij1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;
    SELECT INTO ij0 * FROM edfi.descriptor j0 WHERE descriptorid = new.attendanceeventcategorydescriptorid;
    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;
    SELECT INTO ij1 * FROM edfi.student j1 WHERE studentusi = new.studentusi;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.studentsectionattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeventdate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        newattendanceeventcategorydescriptorid, newattendanceeventcategorydescriptornamespace, newattendanceeventcategorydescriptorcodevalue, neweventdate, newlocalcoursecode, newschoolid, newschoolyear, newsectionidentifier, newsessionname, newstudentusi, newstudentuniqueid, 
        id, changeversion)
    VALUES (
        old.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, old.eventdate, old.localcoursecode, old.schoolid, old.schoolyear, old.sectionidentifier, old.sessionname, old.studentusi, dj1.studentuniqueid, 
        new.attendanceeventcategorydescriptorid, ij0.namespace, ij0.codevalue, new.eventdate, new.localcoursecode, new.schoolid, new.schoolyear, new.sectionidentifier, new.sessionname, new.studentusi, ij1.studentuniqueid, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionattendanceevent') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF attendanceeventcategorydescriptorid, eventdate, localcoursecode, schoolid, schoolyear, sectionidentifier, sessionname, studentusi ON edfi.studentsectionattendanceevent
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentsectionattendanceevent_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'survey') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.survey
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveycourseassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveycourseassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyprogramassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveyprogramassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestion') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveyquestion
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestionresponse') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveyquestionresponse
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponse') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveyresponse
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponseeducationorganizationtargetassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveyresponseeducationorganizationtargetassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponsestafftargetassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveyresponsestafftargetassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysection') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveysection
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveysectionassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionassociation_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.surveysectionassociation(
        oldlocalcoursecode, oldnamespace, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldsurveyidentifier, 
        newlocalcoursecode, newnamespace, newschoolid, newschoolyear, newsectionidentifier, newsessionname, newsurveyidentifier, 
        id, changeversion)
    VALUES (
        old.localcoursecode, old.namespace, old.schoolid, old.schoolyear, old.sectionidentifier, old.sessionname, old.surveyidentifier, 
        new.localcoursecode, new.namespace, new.schoolid, new.schoolyear, new.sectionidentifier, new.sessionname, new.surveyidentifier, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionassociation') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF localcoursecode, namespace, schoolid, schoolyear, sectionidentifier, sessionname, surveyidentifier ON edfi.surveysectionassociation
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionassociation_keychg();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponse') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveysectionresponse
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponseeducationorganizationtargetassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveysectionresponseeducationorganizationtargetassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponsestafftargetassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON edfi.surveysectionresponsestafftargetassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

END
$$;
