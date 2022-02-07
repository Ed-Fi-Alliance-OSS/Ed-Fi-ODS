-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.educationorganizationidtostudentusiincludingdeletes;

CREATE VIEW auth.educationorganizationidtostudentusiincludingdeletes(sourceeducationorganizationid, studentusi) AS
    -- TODO: Remove this statement and UNION and compose in security metadata, when available (but must ensure uniqueness is retained)
    SELECT a.sourceeducationorganizationid, a.studentusi
    FROM auth.educationorganizationidtostudentusi a

    UNION

    SELECT  edOrgs.sourceeducationorganizationid, ssa_tc.oldstudentusi AS studentusi
    FROM    auth.educationorganizationidtoeducationorganizationid edOrgs
        INNER JOIN tracked_changes_edfi.studentschoolassociation ssa_tc
            ON edOrgs.targeteducationorganizationid = ssa_tc.oldschoolid
    GROUP BY edOrgs.sourceeducationorganizationid, ssa_tc.oldstudentusi;

ALTER TABLE auth.educationorganizationidtostudentusiincludingdeletes OWNER TO postgres;

DROP VIEW IF EXISTS auth.educationorganizationidtostaffusiincludingdeletes;

CREATE VIEW auth.educationorganizationidtostaffusiincludingdeletes(sourceeducationorganizationid, staffusi) AS
    -- TODO: Remove this statement and UNION and compose in security metadata, when available (but must ensure uniqueness is retained)
    SELECT a.sourceeducationorganizationid, a.staffusi
    FROM auth.educationorganizationidtostaffusi a

    UNION

    -- EdOrg Assignments
    SELECT  edOrgs.sourceeducationorganizationid, seo_assign_tc.oldstaffusi AS staffusi
    FROM    auth.educationorganizationidtoeducationorganizationid edOrgs
            INNER JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation seo_assign_tc
                ON edOrgs.targeteducationorganizationid = seo_assign_tc.oldeducationorganizationid
    
    UNION

    -- EdOrg Employment
    SELECT  edOrgs.sourceeducationorganizationid, seo_empl_tc.oldstaffusi AS staffusi
    FROM    auth.educationorganizationidtoeducationorganizationid edOrgs
            INNER JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation seo_empl_tc
                ON edOrgs.targeteducationorganizationid = seo_empl_tc.oldeducationorganizationid;

ALTER TABLE auth.educationorganizationidtostaffusiincludingdeletes OWNER TO postgres;

DROP VIEW IF EXISTS auth.educationorganizationidtoparentusiincludingdeletes;

CREATE VIEW auth.educationorganizationidtoparentusiincludingdeletes(sourceeducationorganizationid, parentusi) AS
    -- TODO: Remove this statement and UNION and compose in security metadata, when available (but must ensure uniqueness is retained)
    -- Intact StudentSchoolAssociation and intact StudentParentAssociation
    SELECT  a.sourceeducationorganizationid, a.parentusi
    FROM    auth.educationorganizationidtoparentusi a

    UNION

    -- Intact StudentSchoolAssociation and deleted StudentParentAssociation
    SELECT  edOrgs.sourceeducationorganizationid, spa_tc.oldparentusi AS parentusi
    FROM    auth.educationorganizationidtoeducationorganizationid edOrgs
            INNER JOIN edfi.studentschoolassociation ssa 
                ON edOrgs.targeteducationorganizationid = ssa.schoolid
            INNER JOIN tracked_changes_edfi.studentparentassociation spa_tc
                ON ssa.studentusi = spa_tc.oldstudentusi

    UNION

    -- Deleted StudentSchoolAssociation and intact StudentParentAssociation
    SELECT  edOrgs.sourceeducationorganizationid, spa.parentusi
    FROM    auth.educationorganizationidtoeducationorganizationid edOrgs
            INNER JOIN tracked_changes_edfi.studentschoolassociation ssa_tc
                ON edOrgs.targeteducationorganizationid = ssa_tc.oldschoolid
            INNER JOIN edfi.studentparentassociation spa 
                ON ssa_tc.oldstudentusi = spa.studentusi
                
    UNION

    -- Deleted StudentSchoolAssociation and deleted StudentParentAssociation
    SELECT  edOrgs.sourceeducationorganizationid, spa_tc.oldparentusi AS parentusi
    FROM    auth.educationorganizationidtoeducationorganizationid edOrgs
            INNER JOIN tracked_changes_edfi.studentschoolassociation ssa_tc
                ON edOrgs.targeteducationorganizationid = ssa_tc.oldschoolid
            INNER JOIN tracked_changes_edfi.studentparentassociation spa_tc
                ON ssa_tc.oldstudentusi = spa_tc.oldstudentusi;

ALTER TABLE auth.educationorganizationidtoparentusiincludingdeletes OWNER TO postgres;
