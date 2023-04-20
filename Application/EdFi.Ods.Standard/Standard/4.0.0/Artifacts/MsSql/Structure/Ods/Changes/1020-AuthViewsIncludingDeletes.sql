-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStudentUSIIncludingDeletes 
GO

CREATE VIEW auth.EducationOrganizationIdToStudentUSIIncludingDeletes AS
    SELECT SourceEducationOrganizationId, StudentUSI
    FROM auth.EducationOrganizationIdToStudentUSI

    UNION

    SELECT edOrgs.SourceEducationOrganizationId, ssa_tc.OldStudentUSI as StudentUSI
    FROM auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId;
GO

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStaffUSIIncludingDeletes
GO

CREATE VIEW auth.EducationOrganizationIdToStaffUSIIncludingDeletes AS
    SELECT	SourceEducationOrganizationId, StaffUSI
    FROM	auth.EducationOrganizationIdToStaffUSI edOrgToStaff
    
    UNION

    -- Deleted employment
    SELECT	edOrgs.SourceEducationOrganizationId, emp_tc.OldStaffUSI as StaffUSI
    FROM	auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation emp_tc
                ON edOrgs.TargetEducationOrganizationId = emp_tc.OldEducationOrganizationId

    UNION

    -- Deleted assignments
    SELECT	edOrgs.SourceEducationOrganizationId, assgn_tc.OldStaffUSI as StaffUSI
    FROM	auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation assgn_tc
                ON edOrgs.TargetEducationOrganizationId = assgn_tc.OldEducationOrganizationId
GO

DROP VIEW IF EXISTS auth.EducationOrganizationIdToParentUSIIncludingDeletes;
GO

CREATE VIEW auth.EducationOrganizationIdToParentUSIIncludingDeletes AS
    -- Intact StudentSchoolAssociation and intact StudentParentAssociation
    SELECT	SourceEducationOrganizationId, ParentUSI
    FROM	auth.EducationOrganizationIdToParentUSI

    UNION

    -- Intact StudentSchoolAssociation and deleted StudentParentAssociation
    SELECT edOrgs.SourceEducationOrganizationId, spa_tc.OldParentUSI as ParentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        JOIN edfi.StudentSchoolAssociation ssa ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
        JOIN tracked_changes_edfi.StudentParentAssociation spa_tc ON ssa.StudentUSI = spa_tc.OldStudentUSI

    UNION

    -- Deleted StudentSchoolAssociation and intact StudentParentAssociation
    SELECT	edOrgs.SourceEducationOrganizationId, spa.ParentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId
        JOIN edfi.StudentParentAssociation spa ON ssa_tc.OldStudentUSI = spa.StudentUSI

    UNION

    -- Deleted StudentSchoolAssociation and StudentParentAssociation
    SELECT	edOrgs.SourceEducationOrganizationId, spa_tc.OldParentUSI as ParentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId
        JOIN tracked_changes_edfi.StudentParentAssociation spa_tc ON ssa_tc.OldStudentUSI = spa_tc.OldStudentUSI;
GO
