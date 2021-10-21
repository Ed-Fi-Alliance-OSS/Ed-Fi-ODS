-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStudentUSIIncludingDeletes;
GO

CREATE VIEW auth.LocalEducationAgencyIdToStudentUSIIncludingDeletes AS
    SELECT sch.LocalEducationAgencyId, ssa.StudentUSI
    FROM edfi.School sch
        JOIN edfi.StudentSchoolAssociation ssa ON sch.SchoolId = ssa.SchoolId

    UNION

    SELECT sch.LocalEducationAgencyId, ssa_tc.OldStudentUSI as StudentUSI
    FROM edfi.School sch
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON sch.SchoolId = ssa_tc.OldSchoolId;
GO

DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStaffUSIIncludingDeletes;
GO

CREATE VIEW auth.LocalEducationAgencyIdToStaffUSIIncludingDeletes AS
    -- LEA employment
    SELECT lea.LocalEducationAgencyId, emp.StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN edfi.StaffEducationOrganizationEmploymentAssociation emp
            ON lea.LocalEducationAgencyId = emp.EducationOrganizationId

    UNION

    -- LEA employment (deleted employment)
    SELECT lea.LocalEducationAgencyId, emp_tc.OldStaffUSI as StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation emp_tc
            ON lea.LocalEducationAgencyId = emp_tc.OldEducationOrganizationId

    UNION

    -- LEA-level organization department employment
    SELECT lea.LocalEducationAgencyId, emp.StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId
        JOIN edfi.StaffEducationOrganizationEmploymentAssociation emp
            ON od.OrganizationDepartmentId = emp.EducationOrganizationId

    UNION

    -- LEA-level organization department employment (deleted employment)
    SELECT lea.LocalEducationAgencyId, emp_tc.OldStaffUSI as StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId
        JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation emp_tc
            ON od.OrganizationDepartmentId = emp_tc.OldEducationOrganizationId

    UNION

    -- LEA assignment
    SELECT lea.LocalEducationAgencyId, assgn.StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN edfi.StaffEducationOrganizationAssignmentAssociation assgn
            ON lea.LocalEducationAgencyId = assgn.EducationOrganizationId

    UNION

    -- LEA assignment (deleted assignment)
    SELECT lea.LocalEducationAgencyId, assgn_tc.OldStaffUSI as StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation assgn_tc
            ON lea.LocalEducationAgencyId = assgn_tc.OldEducationOrganizationId

    UNION

    -- LEA-level organization department assignment
    SELECT lea.LocalEducationAgencyId, assgn.StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId
        JOIN edfi.StaffEducationOrganizationAssignmentAssociation assgn
            ON od.OrganizationDepartmentId = assgn.EducationOrganizationId

    UNION

    -- LEA-level organization department assignment (deleted assignment)
    SELECT lea.LocalEducationAgencyId, assgn_tc.OldStaffUSI as StaffUSI
    FROM edfi.LocalEducationAgency lea
        JOIN edfi.OrganizationDepartment od
            ON lea.LocalEducationAgencyId = od.ParentEducationOrganizationId
        JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation assgn_tc
            ON od.OrganizationDepartmentId = assgn_tc.OldEducationOrganizationId

    UNION

    -- School employment
    SELECT sch.LocalEducationAgencyId, emp.StaffUSI
    FROM edfi.School sch
        JOIN edfi.StaffEducationOrganizationEmploymentAssociation emp
            ON sch.SchoolId = emp.EducationOrganizationId

    UNION

    -- School employment (deleted employment)
    SELECT sch.LocalEducationAgencyId, emp_tc.OldStaffUSI as StaffUSI
    FROM edfi.School sch
        JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation emp_tc
            ON sch.SchoolId = emp_tc.OldEducationOrganizationId

    UNION

    -- School-level organization department employment
    SELECT sch.LocalEducationAgencyId, emp.StaffUSI
    FROM edfi.School sch
        JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        JOIN edfi.StaffEducationOrganizationEmploymentAssociation emp
            ON od.OrganizationDepartmentId = emp.EducationOrganizationId

    UNION

    -- School-level organization department employment (deleted employment)
    SELECT sch.LocalEducationAgencyId, emp_tc.OldStaffUSI as StaffUSI
    FROM edfi.School sch
        JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation emp_tc
            ON od.OrganizationDepartmentId = emp_tc.OldEducationOrganizationId

    UNION

    -- School assignment
    SELECT sch.LocalEducationAgencyId, assgn.StaffUSI
    FROM edfi.School sch
        JOIN edfi.StaffEducationOrganizationAssignmentAssociation assgn
            ON sch.SchoolId = assgn.EducationOrganizationId

    UNION

    -- School assignment (deleted assignment)
    SELECT sch.LocalEducationAgencyId, assgn_tc.OldStaffUSI as StaffUSI
    FROM edfi.School sch
        JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation assgn_tc
            ON sch.SchoolId = assgn_tc.OldEducationOrganizationId

    UNION

    -- School-level organization department assignment
    SELECT sch.LocalEducationAgencyId, assgn.StaffUSI
    FROM edfi.School sch
        JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        JOIN edfi.StaffEducationOrganizationAssignmentAssociation assgn
            ON od.OrganizationDepartmentId = assgn.EducationOrganizationId

    UNION

    SELECT sch.LocalEducationAgencyId, assgn_tc.OldStaffUSI as StaffUSI
    FROM edfi.School sch
        JOIN edfi.OrganizationDepartment od
            ON sch.SchoolId = od.ParentEducationOrganizationId
        JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation assgn_tc
            ON od.OrganizationDepartmentId = assgn_tc.OldEducationOrganizationId;
GO

DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToParentUSIIncludingDeletes;
GO

CREATE VIEW auth.LocalEducationAgencyIdToParentUSIIncludingDeletes AS
    -- Intact StudentSchoolAssociation and intact StudentParentAssociation
    SELECT sch.LocalEducationAgencyId, spa.ParentUSI
    FROM edfi.School sch
        JOIN edfi.StudentSchoolAssociation ssa ON sch.SchoolId = ssa.SchoolId
        JOIN edfi.Student s ON ssa.StudentUSI = s.StudentUSI
        JOIN edfi.StudentParentAssociation spa ON ssa.StudentUSI = spa.StudentUSI

    UNION

    -- Intact StudentSchoolAssociation and deleted StudentParentAssociation
    SELECT sch.LocalEducationAgencyId, spa_tc.OldParentUSI as ParentUSI
    FROM edfi.School sch
        JOIN edfi.StudentSchoolAssociation ssa ON sch.SchoolId = ssa.SchoolId
        JOIN tracked_changes_edfi.StudentParentAssociation spa_tc ON ssa.StudentUSI = spa_tc.OldStudentUSI

    UNION

    -- Deleted StudentSchoolAssociation and intact StudentParentAssociation
    SELECT sch.LocalEducationAgencyId, spa.ParentUSI
    FROM edfi.School sch
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON sch.SchoolId = ssa_tc.OldSchoolId
        JOIN edfi.StudentParentAssociation spa ON ssa_tc.OldStudentUSI = spa.StudentUSI

    UNION

    -- Deleted StudentSchoolAssociation and StudentParentAssociation
    SELECT sch.LocalEducationAgencyId, spa_tc.OldParentUSI as ParentUSI
    FROM edfi.School sch
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON sch.SchoolId = ssa_tc.OldSchoolId
        JOIN tracked_changes_edfi.StudentParentAssociation spa_tc ON ssa_tc.OldStudentUSI = spa_tc.OldStudentUSI;
GO
