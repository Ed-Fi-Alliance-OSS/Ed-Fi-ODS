-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW auth.ParentUSIToEducationOrganizationId 
AS
SELECT tuple.SourceEducationOrganizationId AS SourceEducationOrganizationId, spa.ParentUSI AS ParentUSI
FROM edfi.StudentSchoolAssociation ssa 
INNER JOIN edfi.StudentParentAssociation spa ON
ssa.StudentUSI = spa.StudentUSI
INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuple
ON ssa.SchoolId = tuple.TargetEducationOrganizationId
GROUP BY tuple.SourceEducationOrganizationId, spa.ParentUSI
