-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [homograph].[homograph_Contact_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [homograph].[homograph_Name_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [homograph].[homograph_School_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [homograph].[homograph_SchoolYearType_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [homograph].[homograph_Staff_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [homograph].[homograph_Student_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [homograph].[homograph_StudentSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [homograph].[homograph_StudentSchoolAssociation_TR_UpdateChangeVersion] ON [homograph].[StudentSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;

    -- Handle key changes
    INSERT INTO tracked_changes_homograph.StudentSchoolAssociation(
        OldSchoolName, OldStudentFirstName, OldStudentLastSurname, 
        NewSchoolName, NewStudentFirstName, NewStudentLastSurname, 
        Id, ChangeVersion)
    SELECT
        d.SchoolName, d.StudentFirstName, d.StudentLastSurname, 
        i.SchoolName, i.StudentFirstName, i.StudentLastSurname, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.SchoolName <> i.SchoolName OR d.StudentFirstName <> i.StudentFirstName OR d.StudentLastSurname <> i.StudentLastSurname;
END	
GO

