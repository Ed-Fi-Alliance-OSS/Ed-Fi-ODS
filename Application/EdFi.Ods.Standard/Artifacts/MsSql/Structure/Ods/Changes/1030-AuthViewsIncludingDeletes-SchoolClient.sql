-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW [auth].[SchoolIdToStudentUSIIncludingDeletes]
AS
	-- School to Student
	SELECT ssa.SchoolId, ssa.StudentUSI
	FROM edfi.StudentSchoolAssociation ssa

    UNION

    -- School to Student (deleted)
    SELECT sch.SchoolId, ssa_tc.OldStudentUSI as StudentUSI
    FROM edfi.School sch
        INNER JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc 
            ON sch.SchoolId = ssa_tc.OldSchoolId
GO

CREATE OR ALTER VIEW [auth].[SchoolIdToStaffUSIIncludingDeletes]
AS
    -- School to Staff (through School employment)
    SELECT sch.SchoolId
        ,seo_empl.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation seo_empl
            ON sch.SchoolId = seo_empl.EducationOrganizationId

    UNION

    -- School to Staff (through deleted School employment)
    SELECT sch.SchoolId
        ,seo_empl_tc.OldStaffUSI AS StaffUSI
    FROM edfi.School sch
        INNER JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation seo_empl_tc
            ON sch.SchoolId = seo_empl_tc.OldEducationOrganizationId

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

    -- School to Staff (through deleted School-level department employment)
    SELECT sch.SchoolId
        ,seo_empl_tc.OldStaffUSI AS StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        INNER JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation seo_empl_tc
            ON od.OrganizationDepartmentId = seo_empl_tc.OldEducationOrganizationId

    UNION

    -- School to Staff (through School assignment)
    SELECT sch.SchoolId
        ,seo_assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn
            ON sch.SchoolId = seo_assgn.EducationOrganizationId

    UNION

    -- School to Staff (through deleted School assignment)
    SELECT sch.SchoolId
        ,seo_assgn_tc.OldStaffUSI AS StaffUSI
    FROM edfi.School sch
        INNER JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn_tc
            ON sch.SchoolId = seo_assgn_tc.OldEducationOrganizationId

    UNION

    -- School to Staff (through School-level department assignment)
    SELECT sch.SchoolId
        ,seo_assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn
            ON od.OrganizationDepartmentId = seo_assgn.EducationOrganizationId

    UNION

    -- School to Staff (through deleted School-level department assignment)
    SELECT sch.SchoolId
        ,seo_assgn_tc.OldStaffUSI AS StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        INNER JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn_tc
            ON od.OrganizationDepartmentId = seo_assgn_tc.OldEducationOrganizationId;
GO

CREATE VIEW [auth].[ParentUSIToSchoolIdIncludingDeletes]
AS
    -- School to Parent USI
    SELECT ssa.SchoolId, spa.ParentUSI
    FROM edfi.StudentSchoolAssociation ssa
		INNER JOIN edfi.StudentParentAssociation spa 
			ON ssa.StudentUSI = spa.StudentUSI
    
	UNION

    SELECT ssa.SchoolId, spa_tc.OldParentUSI AS ParentUSI
    FROM edfi.StudentSchoolAssociation ssa
		INNER JOIN tracked_changes_edfi.StudentParentAssociation spa_tc
			ON ssa.StudentUSI = spa_tc.OldStudentUSI
GO
