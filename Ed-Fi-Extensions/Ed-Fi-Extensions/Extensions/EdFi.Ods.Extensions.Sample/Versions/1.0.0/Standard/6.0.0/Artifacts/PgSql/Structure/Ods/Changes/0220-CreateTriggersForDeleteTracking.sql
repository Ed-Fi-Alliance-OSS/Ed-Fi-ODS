-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION tracked_changes_sample.artmediumdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ArtMediumDescriptorId, b.codevalue, b.namespace, b.id, 'sample.ArtMediumDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ArtMediumDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'sample' AND event_object_table = 'artmediumdescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.artmediumdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_sample.artmediumdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_sample.bus_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_sample.bus(
        oldbusid,
        id, discriminator, changeversion)
    VALUES (
        OLD.busid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'sample' AND event_object_table = 'bus') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.bus 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_sample.bus_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_sample.busroute_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_sample.busroute(
        oldbusid, oldbusroutenumber,
        id, discriminator, changeversion)
    VALUES (
        OLD.busid, OLD.busroutenumber, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'sample' AND event_object_table = 'busroute') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.busroute 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_sample.busroute_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_sample.favoritebookcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.FavoriteBookCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'sample.FavoriteBookCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.FavoriteBookCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'sample' AND event_object_table = 'favoritebookcategorydescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.favoritebookcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_sample.favoritebookcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_sample.membershiptypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.MembershipTypeDescriptorId, b.codevalue, b.namespace, b.id, 'sample.MembershipTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.MembershipTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'sample' AND event_object_table = 'membershiptypedescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.membershiptypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_sample.membershiptypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_sample.studentgraduationplanassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.graduationplantypedescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_sample.studentgraduationplanassociation(
        oldeducationorganizationid, oldgraduationplantypedescriptorid, oldgraduationplantypedescriptornamespace, oldgraduationplantypedescriptorcodevalue, oldgraduationschoolyear, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.graduationplantypedescriptorid, dj0.namespace, dj0.codevalue, OLD.graduationschoolyear, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'sample' AND event_object_table = 'studentgraduationplanassociation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.studentgraduationplanassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_sample.studentgraduationplanassociation_deleted();
END IF;

END
$$;
