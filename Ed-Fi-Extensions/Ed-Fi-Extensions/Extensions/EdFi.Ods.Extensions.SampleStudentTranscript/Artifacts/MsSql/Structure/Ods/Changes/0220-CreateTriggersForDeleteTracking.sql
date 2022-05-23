-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [samplestudenttranscript].[samplestudenttranscript_InstitutionControlDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [samplestudenttranscript].[samplestudenttranscript_InstitutionControlDescriptor_TR_DeleteTracking] ON [samplestudenttranscript].[InstitutionControlDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_samplestudenttranscript].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InstitutionControlDescriptorId, b.CodeValue, b.Namespace, b.Id, 'samplestudenttranscript.InstitutionControlDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InstitutionControlDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [samplestudenttranscript].[InstitutionControlDescriptor] ENABLE TRIGGER [samplestudenttranscript_InstitutionControlDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [samplestudenttranscript].[samplestudenttranscript_InstitutionLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [samplestudenttranscript].[samplestudenttranscript_InstitutionLevelDescriptor_TR_DeleteTracking] ON [samplestudenttranscript].[InstitutionLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_samplestudenttranscript].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InstitutionLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'samplestudenttranscript.InstitutionLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InstitutionLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [samplestudenttranscript].[InstitutionLevelDescriptor] ENABLE TRIGGER [samplestudenttranscript_InstitutionLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [samplestudenttranscript].[samplestudenttranscript_PostSecondaryOrganization_TR_DeleteTracking]
GO

CREATE TRIGGER [samplestudenttranscript].[samplestudenttranscript_PostSecondaryOrganization_TR_DeleteTracking] ON [samplestudenttranscript].[PostSecondaryOrganization] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_samplestudenttranscript].[PostSecondaryOrganization](OldNameOfInstitution, Id, Discriminator, ChangeVersion)
    SELECT d.NameOfInstitution, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] ENABLE TRIGGER [samplestudenttranscript_PostSecondaryOrganization_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [samplestudenttranscript].[samplestudenttranscript_SpecialEducationGraduationStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [samplestudenttranscript].[samplestudenttranscript_SpecialEducationGraduationStatusDescriptor_TR_DeleteTracking] ON [samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_samplestudenttranscript].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SpecialEducationGraduationStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'samplestudenttranscript.SpecialEducationGraduationStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SpecialEducationGraduationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor] ENABLE TRIGGER [samplestudenttranscript_SpecialEducationGraduationStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [samplestudenttranscript].[samplestudenttranscript_SubmissionCertificationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [samplestudenttranscript].[samplestudenttranscript_SubmissionCertificationDescriptor_TR_DeleteTracking] ON [samplestudenttranscript].[SubmissionCertificationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_samplestudenttranscript].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SubmissionCertificationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'samplestudenttranscript.SubmissionCertificationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SubmissionCertificationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [samplestudenttranscript].[SubmissionCertificationDescriptor] ENABLE TRIGGER [samplestudenttranscript_SubmissionCertificationDescriptor_TR_DeleteTracking]
GO


