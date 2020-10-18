-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TRIGGER [sample].[sample_ArtMediumDescriptor_TR_DeleteTracking] ON [sample].[ArtMediumDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_sample].[ArtMediumDescriptor](ArtMediumDescriptorId, Id, ChangeVersion)
    SELECT  d.ArtMediumDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ArtMediumDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [sample].[ArtMediumDescriptor] ENABLE TRIGGER [sample_ArtMediumDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [sample].[sample_BusRoute_TR_DeleteTracking] ON [sample].[BusRoute] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_sample].[BusRoute](BusId, BusRouteNumber, Id, ChangeVersion)
    SELECT  BusId, BusRouteNumber, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [sample].[BusRoute] ENABLE TRIGGER [sample_BusRoute_TR_DeleteTracking]
GO


CREATE TRIGGER [sample].[sample_Bus_TR_DeleteTracking] ON [sample].[Bus] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_sample].[Bus](BusId, Id, ChangeVersion)
    SELECT  BusId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [sample].[Bus] ENABLE TRIGGER [sample_Bus_TR_DeleteTracking]
GO


CREATE TRIGGER [sample].[sample_FavoriteBookCategoryDescriptor_TR_DeleteTracking] ON [sample].[FavoriteBookCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_sample].[FavoriteBookCategoryDescriptor](FavoriteBookCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.FavoriteBookCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.FavoriteBookCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [sample].[FavoriteBookCategoryDescriptor] ENABLE TRIGGER [sample_FavoriteBookCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [sample].[sample_MembershipTypeDescriptor_TR_DeleteTracking] ON [sample].[MembershipTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_sample].[MembershipTypeDescriptor](MembershipTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.MembershipTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MembershipTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [sample].[MembershipTypeDescriptor] ENABLE TRIGGER [sample_MembershipTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [sample].[sample_StudentArtProgramAssociation_TR_DeleteTracking] ON [sample].[StudentArtProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_sample].[StudentArtProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [sample].[StudentArtProgramAssociation] ENABLE TRIGGER [sample_StudentArtProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [sample].[sample_StudentGraduationPlanAssociation_TR_DeleteTracking] ON [sample].[StudentGraduationPlanAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_sample].[StudentGraduationPlanAssociation](EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI, Id, ChangeVersion)
    SELECT  EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociation] ENABLE TRIGGER [sample_StudentGraduationPlanAssociation_TR_DeleteTracking]
GO


