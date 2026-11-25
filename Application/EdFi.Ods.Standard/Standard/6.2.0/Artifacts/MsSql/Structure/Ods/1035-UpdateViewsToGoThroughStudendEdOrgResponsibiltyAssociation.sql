-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

PRINT N'Altering [auth].[LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation]...';


GO
ALTER VIEW auth.LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation
AS
    SELECT DISTINCT lea.LocalEducationAgencyId
         ,seoa_lea.StudentUSI
    FROM edfi.LocalEducationAgency lea
             INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seoa_lea ON
            lea.LocalEducationAgencyId = seoa_lea.EducationOrganizationId

    UNION

    SELECT DISTINCT sch.LocalEducationAgencyId
         ,seoa_sch.StudentUSI
    FROM edfi.School sch
             INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seoa_sch ON
            sch.SchoolId = seoa_sch.EducationOrganizationId;
GO
PRINT N'Altering [auth].[SchoolIdToStudentUSIThroughEdOrgAssociation]...';


GO
ALTER VIEW auth.SchoolIdToStudentUSIThroughEdOrgAssociation
    WITH SCHEMABINDING
AS
SELECT DISTINCT SchoolId
     ,seoa.StudentUSI
FROM edfi.School sch
         INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seoa ON
        sch.SchoolId = seoa.EducationOrganizationId;
GO
