-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToStudentUSIIncludingDeletes'))
    DROP VIEW auth.EducationOrganizationIdToStudentUSIIncludingDeletes;
GO 

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToStudentUSI'))
    DROP VIEW auth.EducationOrganizationIdToStudentUSI;
GO 

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToContactUSIIncludingDeletes'))
    DROP VIEW auth.EducationOrganizationIdToContactUSIIncludingDeletes;
GO 

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToContactUSI'))
    DROP VIEW auth.EducationOrganizationIdToContactUSI;
GO 

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToStaffUSIIncludingDeletes'))
    DROP VIEW auth.EducationOrganizationIdToStaffUSIIncludingDeletes;
GO 

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToStaffUSI'))
    DROP VIEW auth.EducationOrganizationIdToStaffUSI;
GO 

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToStudentUSIThroughResponsibility'))
    DROP VIEW auth.EducationOrganizationIdToStudentUSIThroughResponsibility;
GO 

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToStudentUSIThroughDeletedResponsibility'))
    DROP VIEW auth.EducationOrganizationIdToStudentUSIThroughDeletedResponsibility;
GO 

ALTER TABLE auth.EducationOrganizationIdToEducationOrganizationId 
ALTER COLUMN SourceEducationOrganizationId BIGINT NOT NULL;
ALTER TABLE auth.EducationOrganizationIdToEducationOrganizationId
ALTER COLUMN TargetEducationOrganizationId BIGINT NOT NULL;

GO

CREATE OR ALTER VIEW auth.EducationOrganizationIdToStudentUSI 
    WITH SCHEMABINDING AS
    SELECT  edOrgs.SourceEducationOrganizationId, ssa.StudentUSI, COUNT_BIG(*) AS Ignored
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        INNER JOIN edfi.StudentSchoolAssociation ssa
            ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
    GROUP BY edOrgs.SourceEducationOrganizationId, ssa.StudentUSI

GO

CREATE UNIQUE CLUSTERED INDEX UX_EducationOrganizationIdToStudentUSI 
	ON auth.EducationOrganizationIdToStudentUSI (SourceEducationOrganizationId, StudentUSI);

GO

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

CREATE OR ALTER VIEW auth.EducationOrganizationIdToContactUSI 
    WITH SCHEMABINDING AS
    SELECT  edOrgs.SourceEducationOrganizationId, spa.ContactUSI, COUNT_BIG(*) AS Ignored
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentSchoolAssociation ssa 
                ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
            INNER JOIN edfi.StudentContactAssociation spa 
                ON ssa.StudentUSI = spa.StudentUSI
    GROUP BY edOrgs.SourceEducationOrganizationId, spa.ContactUSI
    
GO

CREATE UNIQUE CLUSTERED INDEX UX_EducationOrganizationIdToContactUSI 
	ON auth.EducationOrganizationIdToContactUSI (SourceEducationOrganizationId, ContactUSI);

GO

CREATE OR ALTER VIEW auth.EducationOrganizationIdToStudentUSIThroughResponsibility
    WITH SCHEMABINDING AS
    SELECT  edOrgs.SourceEducationOrganizationId, seora.StudentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seora
                ON edOrgs.TargetEducationOrganizationId = seora.EducationOrganizationId
    GROUP BY edOrgs.SourceEducationOrganizationId, seora.StudentUSI

GO