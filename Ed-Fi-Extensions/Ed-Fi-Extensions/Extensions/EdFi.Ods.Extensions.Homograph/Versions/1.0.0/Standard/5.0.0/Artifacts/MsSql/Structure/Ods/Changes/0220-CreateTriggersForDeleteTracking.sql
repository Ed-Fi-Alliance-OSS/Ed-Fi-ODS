-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [homograph].[homograph_Name_TR_DeleteTracking]
GO

CREATE TRIGGER [homograph].[homograph_Name_TR_DeleteTracking] ON [homograph].[Name] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_homograph].[Name](OldFirstName, OldLastSurname, Id, Discriminator, ChangeVersion)
    SELECT d.FirstName, d.LastSurname, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Name] ENABLE TRIGGER [homograph_Name_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [homograph].[homograph_Parent_TR_DeleteTracking]
GO

CREATE TRIGGER [homograph].[homograph_Parent_TR_DeleteTracking] ON [homograph].[Parent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_homograph].[Parent](OldParentFirstName, OldParentLastSurname, Id, Discriminator, ChangeVersion)
    SELECT d.ParentFirstName, d.ParentLastSurname, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Parent] ENABLE TRIGGER [homograph_Parent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [homograph].[homograph_School_TR_DeleteTracking]
GO

CREATE TRIGGER [homograph].[homograph_School_TR_DeleteTracking] ON [homograph].[School] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_homograph].[School](OldSchoolName, Id, Discriminator, ChangeVersion)
    SELECT d.SchoolName, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[School] ENABLE TRIGGER [homograph_School_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [homograph].[homograph_SchoolYearType_TR_DeleteTracking]
GO

CREATE TRIGGER [homograph].[homograph_SchoolYearType_TR_DeleteTracking] ON [homograph].[SchoolYearType] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_homograph].[SchoolYearType](OldSchoolYear, Id, Discriminator, ChangeVersion)
    SELECT d.SchoolYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[SchoolYearType] ENABLE TRIGGER [homograph_SchoolYearType_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [homograph].[homograph_Staff_TR_DeleteTracking]
GO

CREATE TRIGGER [homograph].[homograph_Staff_TR_DeleteTracking] ON [homograph].[Staff] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_homograph].[Staff](OldStaffFirstName, OldStaffLastSurname, Id, Discriminator, ChangeVersion)
    SELECT d.StaffFirstName, d.StaffLastSurname, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Staff] ENABLE TRIGGER [homograph_Staff_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [homograph].[homograph_Student_TR_DeleteTracking]
GO

CREATE TRIGGER [homograph].[homograph_Student_TR_DeleteTracking] ON [homograph].[Student] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_homograph].[Student](OldStudentFirstName, OldStudentLastSurname, Id, Discriminator, ChangeVersion)
    SELECT d.StudentFirstName, d.StudentLastSurname, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[Student] ENABLE TRIGGER [homograph_Student_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [homograph].[homograph_StudentSchoolAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [homograph].[homograph_StudentSchoolAssociation_TR_DeleteTracking] ON [homograph].[StudentSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_homograph].[StudentSchoolAssociation](OldSchoolName, OldStudentFirstName, OldStudentLastSurname, Id, Discriminator, ChangeVersion)
    SELECT d.SchoolName, d.StudentFirstName, d.StudentLastSurname, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [homograph].[StudentSchoolAssociation] ENABLE TRIGGER [homograph_StudentSchoolAssociation_TR_DeleteTracking]
GO


