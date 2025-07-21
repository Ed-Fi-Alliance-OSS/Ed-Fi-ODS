-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE FUNCTION homograph.update_Contact_lastmodifieddate()
RETURNS TRIGGER AS $$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.SchoolName IS DISTINCT FROM OLD.SchoolName
       OR NEW.StudentFirstName IS DISTINCT FROM OLD.StudentFirstName
       OR NEW.StudentLastSurname IS DISTINCT FROM OLD.StudentLastSurname
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE homograph.Contact rt
       SET LastModifiedDate = NOW()
       WHERE rt.ContactFirstName = NEW.ContactFirstName
         AND rt.ContactLastSurname = NEW.ContactLastSurname;
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_homograph_ContactStudentSchoolAssociation_afterupdate
AFTER UPDATE ON homograph.ContactStudentSchoolAssociation
FOR EACH ROW
EXECUTE FUNCTION homograph.update_Contact_lastmodifieddate();

CREATE OR REPLACE FUNCTION homograph.update_Staff_lastmodifieddate()
RETURNS TRIGGER AS $$
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
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_homograph_StaffStudentSchoolAssociation_afterupdate
AFTER UPDATE ON homograph.StaffStudentSchoolAssociation
FOR EACH ROW
EXECUTE FUNCTION homograph.update_Staff_lastmodifieddate();

