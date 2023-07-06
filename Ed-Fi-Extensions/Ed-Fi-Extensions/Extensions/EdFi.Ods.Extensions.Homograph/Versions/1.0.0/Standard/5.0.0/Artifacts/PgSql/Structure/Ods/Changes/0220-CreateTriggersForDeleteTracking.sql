-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION tracked_changes_homograph.contact_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_homograph.contact(
        oldcontactfirstname, oldcontactlastsurname,
        id, discriminator, changeversion)
    VALUES (
        OLD.contactfirstname, OLD.contactlastsurname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'homograph' AND event_object_table = 'contact') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.contact 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.contact_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_homograph.name_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_homograph.name(
        oldfirstname, oldlastsurname,
        id, discriminator, changeversion)
    VALUES (
        OLD.firstname, OLD.lastsurname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'homograph' AND event_object_table = 'name') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.name 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.name_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_homograph.school_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_homograph.school(
        oldschoolname,
        id, discriminator, changeversion)
    VALUES (
        OLD.schoolname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'homograph' AND event_object_table = 'school') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.school 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.school_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_homograph.schoolyeartype_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_homograph.schoolyeartype(
        oldschoolyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'homograph' AND event_object_table = 'schoolyeartype') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.schoolyeartype 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.schoolyeartype_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_homograph.staff_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_homograph.staff(
        oldstafffirstname, oldstafflastsurname,
        id, discriminator, changeversion)
    VALUES (
        OLD.stafffirstname, OLD.stafflastsurname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'homograph' AND event_object_table = 'staff') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.staff 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.staff_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_homograph.student_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_homograph.student(
        oldstudentfirstname, oldstudentlastsurname,
        id, discriminator, changeversion)
    VALUES (
        OLD.studentfirstname, OLD.studentlastsurname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'homograph' AND event_object_table = 'student') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.student 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.student_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_homograph.studentschoolassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_homograph.studentschoolassociation(
        oldschoolname, oldstudentfirstname, oldstudentlastsurname,
        id, discriminator, changeversion)
    VALUES (
        OLD.schoolname, OLD.studentfirstname, OLD.studentlastsurname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'homograph' AND event_object_table = 'studentschoolassociation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.studentschoolassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.studentschoolassociation_deleted();
END IF;

END
$$;
