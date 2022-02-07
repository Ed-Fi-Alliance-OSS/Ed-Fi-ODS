-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStudentUSIIncludingDeletes;
GO

CREATE VIEW auth.EducationOrganizationIdToStudentUSIIncludingDeletes AS
    -- TODO: Remove this statement and UNION and compose in security metadata, when available (but must ensure uniqueness is retained)
    SELECT a.SourceEducationOrganizationId, a.StudentUSI
    FROM auth.EducationOrganizationIdToStudentUSI a

    UNION

    SELECT  edOrgs.SourceEducationOrganizationId, ssa_tc.OldStudentUSI AS StudentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        INNER JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc
            ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId
    GROUP BY edOrgs.SourceEducationOrganizationId, ssa_tc.OldStudentUSI
GO

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStaffUSIIncludingDeletes;
GO

CREATE VIEW auth.EducationOrganizationIdToStaffUSIIncludingDeletes AS
    -- TODO: Remove this statement and UNION and compose in security metadata, when available (but must ensure uniqueness is retained)
    SELECT a.SourceEducationOrganizationId, a.StaffUSI
    FROM auth.EducationOrganizationIdToStaffUSI a

    UNION

    -- EdOrg Assignments
    SELECT  edOrgs.SourceEducationOrganizationId, seo_assign_tc.OldStaffUSI AS StaffUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN tracked_changes_edfi.StaffEducationOrganizationAssignmentAssociation seo_assign_tc
                ON edOrgs.TargetEducationOrganizationId = seo_assign_tc.OldEducationOrganizationId
    
    UNION

    -- EdOrg Employment
    SELECT  edOrgs.SourceEducationOrganizationId, seo_empl_tc.OldStaffUSI AS StaffUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN tracked_changes_edfi.StaffEducationOrganizationEmploymentAssociation seo_empl_tc
                ON edOrgs.TargetEducationOrganizationId = seo_empl_tc.OldEducationOrganizationId
GO

DROP VIEW IF EXISTS auth.EducationOrganizationIdToParentUSIIncludingDeletes;
GO

CREATE VIEW auth.EducationOrganizationIdToParentUSIIncludingDeletes WITH SCHEMABINDING AS
    -- TODO: Remove this statement and UNION and compose in security metadata, when available (but must ensure uniqueness is retained)
    -- Intact StudentSchoolAssociation and intact StudentParentAssociation
    SELECT  a.SourceEducationOrganizationId, a.ParentUSI
    FROM    auth.EducationOrganizationIdToParentUSI a

    UNION

    -- Intact StudentSchoolAssociation and deleted StudentParentAssociation
    SELECT  edOrgs.SourceEducationOrganizationId, spa_tc.OldParentUSI AS ParentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentSchoolAssociation ssa 
                ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
            INNER JOIN tracked_changes_edfi.StudentParentAssociation spa_tc
                ON ssa.StudentUSI = spa_tc.OldStudentUSI

    UNION

    -- Deleted StudentSchoolAssociation and intact StudentParentAssociation
    SELECT  edOrgs.SourceEducationOrganizationId, spa.ParentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc
                ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId
            INNER JOIN edfi.StudentParentAssociation spa 
                ON ssa_tc.OldStudentUSI = spa.StudentUSI
                
    UNION

    -- Deleted StudentSchoolAssociation and deleted StudentParentAssociation
    SELECT  edOrgs.SourceEducationOrganizationId, spa_tc.OldParentUSI AS ParentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN tracked_changes_edfi.StudentSchoolAssociation ssa_tc
                ON edOrgs.TargetEducationOrganizationId = ssa_tc.OldSchoolId
            INNER JOIN tracked_changes_edfi.StudentParentAssociation spa_tc
                ON ssa_tc.OldStudentUSI = spa_tc.OldStudentUSI
GO
