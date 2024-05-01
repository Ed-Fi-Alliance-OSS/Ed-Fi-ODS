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

DROP VIEW IF EXISTS auth.EducationOrganizationIdToContactUSIIncludingDeletes;
GO

CREATE VIEW auth.EducationOrganizationIdToContactUSIIncludingDeletes AS
    -- Intact StudentSchoolAssociation and intact StudentContactAssociation
    SELECT	SourceEducationOrganizationId, ContactUSI
    FROM	auth.EducationOrganizationIdToContactUSI

    UNION

    -- Intact StudentSchoolAssociation and deleted StudentContactAssociation
    SELECT edOrgs.SourceEducationOrganizationId, spa_tc.OldContactUSI as ContactUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        JOIN edfi.StudentSchoolAssociation ssa ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
        JOIN tracked_changes_edfi.StudentContactAssociation spa_tc ON ssa.StudentUSI = spa_tc.OldStudentUSI

    UNION

    -- Deleted StudentSchoolAssociation and intact StudentContactAssociation
    SELECT	edOrgs.SourceEducationOrganizationId, spa.ContactUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId
        JOIN edfi.StudentContactAssociation spa ON ssa_tc.OldStudentUSI = spa.StudentUSI

    UNION

    -- Deleted StudentSchoolAssociation and StudentContactAssociation
    SELECT	edOrgs.SourceEducationOrganizationId, spa_tc.OldContactUSI as ContactUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId
        JOIN tracked_changes_edfi.StudentContactAssociation spa_tc ON ssa_tc.OldStudentUSI = spa_tc.OldStudentUSI;
GO
