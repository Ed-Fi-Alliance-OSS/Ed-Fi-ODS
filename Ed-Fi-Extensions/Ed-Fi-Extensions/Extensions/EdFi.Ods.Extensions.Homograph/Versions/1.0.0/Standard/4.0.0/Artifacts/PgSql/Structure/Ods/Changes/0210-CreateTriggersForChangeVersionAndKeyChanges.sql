-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'name') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON homograph.name
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'parent') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON homograph.parent
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'school') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON homograph.school
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'schoolyeartype') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON homograph.schoolyeartype
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'staff') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON homograph.staff
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'student') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON homograph.student
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'studentschoolassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON homograph.studentschoolassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_homograph.studentschoolassociation_keychg()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    -- Handle key changes
    INSERT INTO tracked_changes_homograph.studentschoolassociation(
        oldschoolname, oldstudentfirstname, oldstudentlastsurname, 
        newschoolname, newstudentfirstname, newstudentlastsurname, 
        id, changeversion)
    VALUES (
        old.schoolname, old.studentfirstname, old.studentlastsurname, 
        new.schoolname, new.studentfirstname, new.studentlastsurname, 
        old.id, (nextval('changes.changeversionsequence')));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'handlekeychanges' AND event_object_schema = 'homograph' AND event_object_table = 'studentschoolassociation') THEN
    CREATE TRIGGER HandleKeyChanges AFTER UPDATE OF schoolname, studentfirstname, studentlastsurname ON homograph.studentschoolassociation
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_homograph.studentschoolassociation_keychg();
END IF;

END
$$;
