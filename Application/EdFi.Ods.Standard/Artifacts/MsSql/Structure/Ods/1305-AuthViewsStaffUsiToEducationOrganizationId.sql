-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW auth.StaffUSIToEducationOrganizationId 
AS
SELECT SourceEducationOrganizationId, StaffUSI
FROM edfi.StaffEducationOrganizationAssignmentAssociation
INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId
ON EducationOrganizationId = TargetEducationOrganizationId

UNION

SELECT SourceEducationOrganizationId, StaffUSI
FROM edfi.StaffEducationOrganizationEmploymentAssociation
INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId
ON EducationOrganizationId = TargetEducationOrganizationId