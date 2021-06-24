-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TRIGGER edfi.edfi_EducationOrganization_TR_Insert ON edfi.EducationOrganization AFTER INSERT AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId
    SELECT i.EducationOrganizationId, i.EducationOrganizationId
    FROM inserted as i
END
GO

CREATE TRIGGER edfi.edfi_EducationOrganization_TR_Update ON edfi.EducationOrganization AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON
    UPDATE auth.EducationOrganizationIdToEducationOrganizationId
    SET SourceEducationOrganizationId = i.EducationOrganizationId,
        TargetEducationOrganizationId = i.EducationOrganizationId
    FROM inserted i
    WHERE SourceEducationOrganizationId IN (SELECT EducationOrganizationId FROM deleted)
    AND TargetEducationOrganizationId IN (SELECT EducationOrganizationId FROM deleted)
END
GO

CREATE TRIGGER edfi.edfi_EducationOrganization_TR_Delete ON edfi.EducationOrganization AFTER DELETE AS
BEGIN
    SET NOCOUNT ON
    DELETE FROM auth.EducationOrganizationIdToEducationOrganizationId
    WHERE SourceEducationOrganizationId IN (SELECT EducationOrganizationId FROM deleted)
    AND TargetEducationOrganizationId IN (SELECT EducationOrganizationId FROM deleted)
END
GO