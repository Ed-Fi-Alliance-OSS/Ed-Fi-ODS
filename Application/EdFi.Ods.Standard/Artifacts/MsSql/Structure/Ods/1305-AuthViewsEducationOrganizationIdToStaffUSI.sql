-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW auth.EducationOrganizationIdToStaffUSI 
    WITH SCHEMABINDING AS

    -- EdOrg Assignments
    SELECT  edOrgs.SourceEducationOrganizationId, seo_assign.StaffUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assign
                ON edOrgs.TargetEducationOrganizationId =  seo_assign.EducationOrganizationId
    
    UNION

    -- EdOrg Employment
    SELECT  edOrgs.SourceEducationOrganizationId, seo_empl.StaffUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation seo_empl
                ON edOrgs.TargetEducationOrganizationId = seo_empl.EducationOrganizationId
GO
