-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [sample].[sample_ArtMediumDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [sample].[sample_ArtMediumDescriptor_TR_DeleteTracking] ON [sample].[ArtMediumDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_sample].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ArtMediumDescriptorId, b.CodeValue, b.Namespace, b.Id, 'sample.ArtMediumDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ArtMediumDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [sample].[ArtMediumDescriptor] ENABLE TRIGGER [sample_ArtMediumDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [sample].[sample_Bus_TR_DeleteTracking]
GO

CREATE TRIGGER [sample].[sample_Bus_TR_DeleteTracking] ON [sample].[Bus] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_sample].[Bus](OldBusId, Id, Discriminator, ChangeVersion)
    SELECT d.BusId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [sample].[Bus] ENABLE TRIGGER [sample_Bus_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [sample].[sample_BusRoute_TR_DeleteTracking]
GO

CREATE TRIGGER [sample].[sample_BusRoute_TR_DeleteTracking] ON [sample].[BusRoute] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_sample].[BusRoute](OldBusId, OldBusRouteNumber, Id, Discriminator, ChangeVersion)
    SELECT d.BusId, d.BusRouteNumber, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [sample].[BusRoute] ENABLE TRIGGER [sample_BusRoute_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [sample].[sample_FavoriteBookCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [sample].[sample_FavoriteBookCategoryDescriptor_TR_DeleteTracking] ON [sample].[FavoriteBookCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_sample].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.FavoriteBookCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'sample.FavoriteBookCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.FavoriteBookCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [sample].[FavoriteBookCategoryDescriptor] ENABLE TRIGGER [sample_FavoriteBookCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [sample].[sample_MembershipTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [sample].[sample_MembershipTypeDescriptor_TR_DeleteTracking] ON [sample].[MembershipTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_sample].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.MembershipTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'sample.MembershipTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MembershipTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [sample].[MembershipTypeDescriptor] ENABLE TRIGGER [sample_MembershipTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [sample].[sample_StudentGraduationPlanAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [sample].[sample_StudentGraduationPlanAssociation_TR_DeleteTracking] ON [sample].[StudentGraduationPlanAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_sample].[StudentGraduationPlanAssociation](OldEducationOrganizationId, OldGraduationPlanTypeDescriptorId, OldGraduationPlanTypeDescriptorNamespace, OldGraduationPlanTypeDescriptorCodeValue, OldGraduationSchoolYear, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.GraduationPlanTypeDescriptorId, j0.Namespace, j0.CodeValue, d.GraduationSchoolYear, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.GraduationPlanTypeDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociation] ENABLE TRIGGER [sample_StudentGraduationPlanAssociation_TR_DeleteTracking]
GO


