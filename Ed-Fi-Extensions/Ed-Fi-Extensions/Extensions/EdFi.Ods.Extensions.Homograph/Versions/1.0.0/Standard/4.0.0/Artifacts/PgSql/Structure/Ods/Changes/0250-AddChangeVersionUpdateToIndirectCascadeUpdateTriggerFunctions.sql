-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE FUNCTION homograph.update_Parent_lastmodifieddate()
RETURNS TRIGGER AS $$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.SchoolName IS DISTINCT FROM OLD.SchoolName
       OR NEW.StudentFirstName IS DISTINCT FROM OLD.StudentFirstName
       OR NEW.StudentLastSurname IS DISTINCT FROM OLD.StudentLastSurname
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE homograph.Parent rt
       SET LastModifiedDate = NOW(), ChangeVersion = nextval('changes.ChangeVersionSequence'), AggregateData = NULL
       WHERE rt.ParentFirstName = NEW.ParentFirstName
         AND rt.ParentLastSurname = NEW.ParentLastSurname;
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

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
       SET LastModifiedDate = NOW(), ChangeVersion = nextval('changes.ChangeVersionSequence'), AggregateData = NULL
       WHERE rt.StaffFirstName = NEW.StaffFirstName
         AND rt.StaffLastSurname = NEW.StaffLastSurname;
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

