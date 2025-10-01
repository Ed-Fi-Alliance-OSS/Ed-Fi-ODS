-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION homograph.Parent_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.SchoolName IS DISTINCT FROM OLD.SchoolName
       OR NEW.StudentFirstName IS DISTINCT FROM OLD.StudentFirstName
       OR NEW.StudentLastSurname IS DISTINCT FROM OLD.StudentLastSurname
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE homograph.Parent rt
       SET LastModifiedDate = NOW()
       WHERE rt.ParentFirstName = NEW.ParentFirstName
         AND rt.ParentLastSurname = NEW.ParentLastSurname;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'homograph' AND event_object_table = 'parentstudentschoolassociation') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON homograph.parentstudentschoolassociation
  FOR EACH ROW
  EXECUTE FUNCTION homograph.Parent_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION homograph.Staff_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.SchoolName IS DISTINCT FROM OLD.SchoolName
       OR NEW.StudentFirstName IS DISTINCT FROM OLD.StudentFirstName
       OR NEW.StudentLastSurname IS DISTINCT FROM OLD.StudentLastSurname
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE homograph.Staff rt
       SET LastModifiedDate = NOW()
       WHERE rt.StaffFirstName = NEW.StaffFirstName
         AND rt.StaffLastSurname = NEW.StaffLastSurname;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'homograph' AND event_object_table = 'staffstudentschoolassociation') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON homograph.staffstudentschoolassociation
  FOR EACH ROW
  EXECUTE FUNCTION homograph.Staff_UpdLastModDate();
END IF;

END
$$;
