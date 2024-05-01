-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION tracked_changes_samplestudenttransportation.studenttransportation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_samplestudenttransportation.studenttransportation(
        oldambusnumber, oldpmbusnumber, oldschoolid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.ambusnumber, OLD.pmbusnumber, OLD.schoolid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'samplestudenttransportation' AND event_object_table = 'studenttransportation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON samplestudenttransportation.studenttransportation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_samplestudenttransportation.studenttransportation_deleted();
END IF;

END
$$;
