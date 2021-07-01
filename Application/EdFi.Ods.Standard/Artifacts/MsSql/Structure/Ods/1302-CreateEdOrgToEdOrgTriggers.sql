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