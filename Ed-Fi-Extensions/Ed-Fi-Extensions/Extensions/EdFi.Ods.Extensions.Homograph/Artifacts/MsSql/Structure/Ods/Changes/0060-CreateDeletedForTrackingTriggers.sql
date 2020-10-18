-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TRIGGER [homograph].[homograph_Name_TR_DeleteTracking] ON [homograph].[Name] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_homograph].[Name](FirstName, LastSurname, Id, ChangeVersion)
    SELECT  FirstName, LastSurname, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Name] ENABLE TRIGGER [homograph_Name_TR_DeleteTracking]
GO


CREATE TRIGGER [homograph].[homograph_Parent_TR_DeleteTracking] ON [homograph].[Parent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_homograph].[Parent](ParentFirstName, ParentLastSurname, Id, ChangeVersion)
    SELECT  ParentFirstName, ParentLastSurname, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Parent] ENABLE TRIGGER [homograph_Parent_TR_DeleteTracking]
GO


CREATE TRIGGER [homograph].[homograph_SchoolYearType_TR_DeleteTracking] ON [homograph].[SchoolYearType] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_homograph].[SchoolYearType](SchoolYear, Id, ChangeVersion)
    SELECT  SchoolYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[SchoolYearType] ENABLE TRIGGER [homograph_SchoolYearType_TR_DeleteTracking]
GO


CREATE TRIGGER [homograph].[homograph_School_TR_DeleteTracking] ON [homograph].[School] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_homograph].[School](SchoolName, Id, ChangeVersion)
    SELECT  SchoolName, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[School] ENABLE TRIGGER [homograph_School_TR_DeleteTracking]
GO


CREATE TRIGGER [homograph].[homograph_Staff_TR_DeleteTracking] ON [homograph].[Staff] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_homograph].[Staff](StaffFirstName, StaffLastSurname, Id, ChangeVersion)
    SELECT  StaffFirstName, StaffLastSurname, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Staff] ENABLE TRIGGER [homograph_Staff_TR_DeleteTracking]
GO


CREATE TRIGGER [homograph].[homograph_StudentSchoolAssociation_TR_DeleteTracking] ON [homograph].[StudentSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_homograph].[StudentSchoolAssociation](SchoolName, StudentFirstName, StudentLastSurname, Id, ChangeVersion)
    SELECT  SchoolName, StudentFirstName, StudentLastSurname, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[StudentSchoolAssociation] ENABLE TRIGGER [homograph_StudentSchoolAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [homograph].[homograph_Student_TR_DeleteTracking] ON [homograph].[Student] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_homograph].[Student](StudentFirstName, StudentLastSurname, Id, ChangeVersion)
    SELECT  StudentFirstName, StudentLastSurname, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Student] ENABLE TRIGGER [homograph_Student_TR_DeleteTracking]
GO


