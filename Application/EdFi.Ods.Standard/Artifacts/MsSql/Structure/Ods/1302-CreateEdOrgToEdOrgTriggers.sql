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

CREATE TRIGGER edfi.edfi_EducationOrganization_TR_Delete ON edfi.EducationOrganization INSTEAD OF DELETE AS
BEGIN
    SET NOCOUNT ON
    DELETE auth.EducationOrganizationIdToEducationOrganizationId
    FROM auth.EducationOrganizationIdToEducationOrganizationId
    INNER JOIN deleted d
        ON SourceEducationOrganizationId = d.EducationOrganizationId
        OR TargetEducationOrganizationId = d.EducationOrganizationId

    DELETE edfi.EducationOrganization
    FROM edfi.EducationOrganization eo
    INNER JOIN deleted d
        ON eo.EducationOrganizationId = d.EducationOrganizationId
END
GO

CREATE TRIGGER edfi.edfi_School_TR_Insert ON edfi.School AFTER INSERT AS
BEGIN
    SET NOCOUNT ON
    MERGE INTO auth.EducationOrganizationIdToEducationOrganizationId eoeo1
    USING (
        SELECT i.LocalEducationAgencyId, i.SchoolId
        FROM inserted i
        WHERE i.LocalEducationAgencyId IS NOT NULL) eoeo2
    ON eoeo1.SourceEducationOrganizationId = eoeo2.LocalEducationAgencyId
        AND eoeo1.TargetEducationOrganizationId = eoeo2.SchoolId
    WHEN NOT MATCHED THEN
        INSERT VALUES(eoeo2.LocalEducationAgencyId, eoeo2.SchoolId);
END
GO

CREATE TRIGGER edfi.edfi_School_TR_Update ON edfi.School AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON
    DELETE auth.EducationOrganizationIdToEducationOrganizationId
    FROM auth.EducationOrganizationIdToEducationOrganizationId
    INNER JOIN deleted d
        ON TargetEducationOrganizationId = d.SchoolId
    WHERE SourceEducationOrganizationId IN (
        SELECT SourceEducationOrganizationId
        FROM auth.EducationOrganizationIdToEducationOrganizationId p
        INNER JOIN deleted d
            ON TargetEducationOrganizationId = d.LocalEducationAgencyId
        INNER JOIN inserted i
            ON d.SchoolId = i.SchoolId
        -- LocalEducationAgencyId is changing and was not originally null
        WHERE d.LocalEducationAgencyId IS NOT NULL
        AND (i.LocalEducationAgencyId IS NULL OR d.LocalEducationAgencyId <> i.LocalEducationAgencyId))

    MERGE INTO auth.EducationOrganizationIdToEducationOrganizationId eoeo1
    USING (
        SELECT p.SourceEducationOrganizationId, i.SchoolId
        FROM inserted i
        INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId p
            ON i.LocalEducationAgencyId = p.TargetEducationOrganizationId
        WHERE i.LocalEducationAgencyId IS NOT NULL) eoeo2
    ON eoeo1.SourceEducationOrganizationId = eoeo2.SourceEducationOrganizationId
        AND eoeo1.TargetEducationOrganizationId = eoeo2.SchoolId
    WHEN NOT MATCHED THEN
        INSERT VALUES(eoeo2.SourceEducationOrganizationId, eoeo2.SchoolId);
END
GO