-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 
           FROM sys.indexes 
           WHERE name = 'UX_EducationOrganizationIdToStudentUSI' 
             AND object_id = OBJECT_ID('auth.EducationOrganizationIdToStudentUSI'))
   DROP INDEX UX_EducationOrganizationIdToStudentUSI ON auth.EducationOrganizationIdToStudentUSI;
GO

CREATE OR ALTER VIEW auth.EducationOrganizationIdToStudentUSI AS
    SELECT  edOrgs.SourceEducationOrganizationId, ssa.StudentUSI, COUNT_BIG(*) AS Ignored
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        INNER JOIN edfi.StudentSchoolAssociation ssa
            ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
    GROUP BY edOrgs.SourceEducationOrganizationId, ssa.StudentUSI
GO

IF EXISTS (SELECT 1 
           FROM sys.indexes 
           WHERE name = 'UX_EducationOrganizationIdToParentUSI' 
             AND object_id = OBJECT_ID('auth.EducationOrganizationIdToParentUSI'))
   DROP INDEX UX_EducationOrganizationIdToParentUSI ON auth.EducationOrganizationIdToParentUSI;
GO

CREATE OR ALTER VIEW auth.EducationOrganizationIdToParentUSI AS
    SELECT  edOrgs.SourceEducationOrganizationId, spa.ParentUSI, COUNT_BIG(*) AS Ignored
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentSchoolAssociation ssa 
                ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
            INNER JOIN edfi.StudentParentAssociation spa 
                ON ssa.StudentUSI = spa.StudentUSI
    GROUP BY edOrgs.SourceEducationOrganizationId, spa.ParentUSI
GO

CREATE OR ALTER VIEW auth.EducationOrganizationIdToStaffUSI AS

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

CREATE OR ALTER VIEW auth.EducationOrganizationIdToStudentUSIThroughResponsibility AS
    SELECT  edOrgs.SourceEducationOrganizationId, seora.StudentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seora
                ON edOrgs.TargetEducationOrganizationId = seora.EducationOrganizationId
    GROUP BY edOrgs.SourceEducationOrganizationId, seora.StudentUSI
GO
