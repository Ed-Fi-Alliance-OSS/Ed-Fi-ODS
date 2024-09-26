-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER VIEW [auth].[EducationOrganizationIdToSchoolId]
AS
-- School-level claims only can access the school
SELECT SchoolId
     ,SchoolId AS EducationOrganizationId
FROM edfi.School

UNION

-- School-level claims can access the school's departments
SELECT SchoolId
    ,OrganizationDepartmentId AS EducationOrganizationId
FROM edfi.School sch
    INNER JOIN edfi.OrganizationDepartment od
        ON sch.SchoolId = od.ParentEducationOrganizationId;
GO

ALTER VIEW [auth].[EducationOrganizationIdToLocalEducationAgencyId]
AS
    -- Schools in the LEA
    SELECT LocalEducationAgencyId
         ,SchoolId AS EducationOrganizationId
    FROM edfi.School

    UNION
	
    -- LEA-level claims can access the LEA's School's departments
    SELECT LocalEducationAgencyId
        , OrganizationDepartmentId AS EducationOrganizationId
    FROM  edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId

    UNION

    -- LEA-level claims also can access the LEA
    SELECT LocalEducationAgencyId
         ,LocalEducationAgencyId AS EducationOrganizationId
    FROM edfi.LocalEducationAgency

    UNION

    -- LEA-level claims also can access LEA's departments
    SELECT LocalEducationAgencyId
         ,OrganizationDepartmentId AS EducationOrganizationId
    FROM edfi.LocalEducationAgency lea
        INNER JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId
GO

ALTER VIEW [auth].[LocalEducationAgencyIdToStaffUSI]
AS
    -- LEA to Staff (through LEA employment)
    SELECT lea.LocalEducationAgencyId
        ,emp.StaffUSI
    FROM edfi.LocalEducationAgency lea
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON lea.LocalEducationAgencyId = emp.EducationOrganizationId

    UNION

    -- LEA to Staff (through LEA-level department employment)
    SELECT lea.LocalEducationAgencyId
        ,emp.StaffUSI
    FROM edfi.LocalEducationAgency lea
		INNER JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON od.OrganizationDepartmentId = emp.EducationOrganizationId

    UNION

    -- LEA to Staff (through LEA assignment)
    SELECT lea.LocalEducationAgencyId
         ,assgn.StaffUSI
    FROM edfi.LocalEducationAgency lea
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON lea.LocalEducationAgencyId = assgn.EducationOrganizationId

    UNION

    -- LEA to Staff (through LEA-level department assignment)
    SELECT lea.LocalEducationAgencyId
         ,assgn.StaffUSI
    FROM edfi.LocalEducationAgency lea
        INNER JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON od.OrganizationDepartmentId = assgn.EducationOrganizationId

    UNION

    -- LEA to Staff (through School employment)
    SELECT sch.LocalEducationAgencyId
         ,emp.StaffUSI
    FROM edfi.School sch
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON sch.SchoolId = emp.EducationOrganizationId

    UNION

    -- LEA to Staff (through School-level department employment)
    SELECT sch.LocalEducationAgencyId
         ,emp.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON od.OrganizationDepartmentId = emp.EducationOrganizationId

    UNION

    -- LEA to Staff (through School assignment)
    SELECT sch.LocalEducationAgencyId
         ,assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON sch.SchoolId = assgn.EducationOrganizationId
            
    UNION

    -- LEA to Staff (through School-level department assignment)
    SELECT sch.LocalEducationAgencyId
         ,assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON od.OrganizationDepartmentId = assgn.EducationOrganizationId;
GO

ALTER VIEW [auth].[SchoolIdToStaffUSI]
AS
    -- School to Staff (through School employment)
    SELECT sch.SchoolId
        ,seo_empl.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation seo_empl
            ON sch.SchoolId = seo_empl.EducationOrganizationId

    UNION

    -- School to Staff (through School-level department employment)
    SELECT sch.SchoolId
        ,seo_empl.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation seo_empl
            ON od.OrganizationDepartmentId = seo_empl.EducationOrganizationId

    UNION

    -- School to Staff (through School assignment)
    SELECT sch.SchoolId
        ,seo_assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn
            ON sch.SchoolId = seo_assgn.EducationOrganizationId

    UNION

    -- School to Staff (through School-level department assignment)
    SELECT sch.SchoolId
        ,seo_assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn
            ON od.OrganizationDepartmentId = seo_assgn.EducationOrganizationId;

GO

CREATE VIEW [auth].[LocalEducationAgencyIdToOrganizationDepartmentId]
AS
    SELECT  LocalEducationAgencyId, OrganizationDepartmentId
    FROM    edfi.LocalEducationAgency lea
        INNER JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId

    UNION

    SELECT  LocalEducationAgencyId, OrganizationDepartmentId
    FROM    edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
GO

CREATE VIEW [auth].[OrganizationDepartmentIdToSchoolId]
AS
    SELECT  SchoolId, OrganizationDepartmentId
    FROM    edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
GO

