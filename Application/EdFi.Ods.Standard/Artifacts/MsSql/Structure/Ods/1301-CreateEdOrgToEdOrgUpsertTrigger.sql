-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TRIGGER [edfi].[edfi_EducationOrganization_TR_Insert] ON [edfi].[EducationOrganization] AFTER UPDATE, INSERT, DELETE AS
BEGIN
    SET NOCOUNT ON
    MERGE [auth].[EducationOrganizationIdToEducationOrganizationId] WITH (HOLDLOCK) AS tgt
    USING (
        SELECT [EducationOrganizationId]
        FROM [edfi].[EducationOrganization]
    ) AS src
    ON (
        tgt.SourceEducationOrganizationId = src.EducationOrganizationId
        AND tgt.TargetEducationOrganizationId = src.EducationOrganizationId)
    WHEN MATCHED THEN
        UPDATE SET
            SourceEducationOrganizationId = src.EducationOrganizationId,
            TargetEducationOrganizationId = src.EducationOrganizationId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (SourceEducationOrganizationId, TargetEducationOrganizationId)
        VALUES (src.EducationOrganizationId, src.EducationOrganizationId)
    WHEN NOT MATCHED BY SOURCE THEN DELETE;
END
GO
