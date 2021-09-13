-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF OBJECT_ID('auth.StudentUSIToEducationOrganizationIdThroughEdOrgAssociation', 'V') IS NOT NULL
    DROP VIEW auth.StudentUSIToEducationOrganizationIdThroughEdOrgAssociation
GO

CREATE VIEW auth.StudentUSIToEducationOrganizationIdThroughEdOrgAssociation AS
SELECT tuple.SourceEducationOrganizationId, seoa.StudentUSI
FROM edfi.StudentEducationOrganizationAssociation seoa
INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuple
ON seoa.EducationOrganizationId = tuple.TargetEducationOrganizationId

GO
