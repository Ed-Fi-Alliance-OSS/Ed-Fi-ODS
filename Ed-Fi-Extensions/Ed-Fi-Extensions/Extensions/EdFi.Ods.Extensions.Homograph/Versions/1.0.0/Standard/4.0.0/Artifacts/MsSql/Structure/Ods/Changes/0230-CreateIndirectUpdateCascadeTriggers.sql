-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TRIGGER [homograph].[homograph_ParentStudentSchoolAssociation_TR_Parent_Update]
ON [homograph].[ParentStudentSchoolAssociation]
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
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [homograph].[Parent] rt
        INNER JOIN inserted i
            ON rt.ParentFirstName = i.ParentFirstName
               AND rt.ParentLastSurname = i.ParentLastSurname;
    END
END;
GO

CREATE TRIGGER [homograph].[homograph_StaffStudentSchoolAssociation_TR_Staff_Update]
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
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [homograph].[Staff] rt
        INNER JOIN inserted i
            ON rt.StaffFirstName = i.StaffFirstName
               AND rt.StaffLastSurname = i.StaffLastSurname;
    END
END;
GO

