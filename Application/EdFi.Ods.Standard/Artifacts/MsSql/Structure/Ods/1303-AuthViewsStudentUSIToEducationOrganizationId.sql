-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF OBJECT_ID('auth.StudentUSIToEducationOrganizationId', 'V') IS NOT NULL
    DROP VIEW auth.StudentUSIToEducationOrganizationId
GO

CREATE VIEW auth.StudentUSIToEducationOrganizationId AS
SELECT  tuple.SourceEducationOrganizationId AS  SourceEducationOrganizationId ,ssa.studentUSI  AS studentUSI
FROM edfi.StudentSchoolAssociation ssa
INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuple
ON ssa.SchoolId = tuple.TargetEducationOrganizationId

GO
