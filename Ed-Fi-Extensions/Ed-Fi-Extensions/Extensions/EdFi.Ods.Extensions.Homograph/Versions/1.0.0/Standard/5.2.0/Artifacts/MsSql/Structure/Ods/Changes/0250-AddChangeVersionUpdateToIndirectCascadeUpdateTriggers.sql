-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER TRIGGER [homograph].[homograph_ContactStudentSchoolAssociation_TR_Contact_Update]
ON [homograph].[ContactStudentSchoolAssociation]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(SchoolName)
       OR UPDATE(StudentFirstName)
       OR UPDATE(StudentLastSurname)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE(), rt.ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence]), rt.AggregateData = NULL
        FROM [homograph].[Contact] rt
        INNER JOIN inserted i
            ON rt.ContactFirstName = i.ContactFirstName
               AND rt.ContactLastSurname = i.ContactLastSurname;
    END
END;
GO

CREATE OR ALTER TRIGGER [homograph].[homograph_StaffStudentSchoolAssociation_TR_Staff_Update]
ON [homograph].[StaffStudentSchoolAssociation]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(SchoolName)
       OR UPDATE(StudentFirstName)
       OR UPDATE(StudentLastSurname)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE(), rt.ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence]), rt.AggregateData = NULL
        FROM [homograph].[Staff] rt
        INNER JOIN inserted i
            ON rt.StaffFirstName = i.StaffFirstName
               AND rt.StaffLastSurname = i.StaffLastSurname;
    END
END;
GO

