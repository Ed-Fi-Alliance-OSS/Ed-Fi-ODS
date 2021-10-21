-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.schoolidtostudentusiincludingdeletes;

CREATE VIEW auth.schoolidtostudentusiincludingdeletes(schoolid, studentusi) AS
	-- School to Student
	SELECT ssa.schoolid, ssa.studentusi
	FROM edfi.studentschoolassociation ssa

    UNION

    -- School to Student (deleted)
    SELECT sch.schoolid, ssa_tc.oldstudentusi as studentusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.studentschoolassociation ssa_tc 
            ON sch.schoolid = ssa_tc.oldschoolid;

ALTER TABLE auth.schoolidtostudentusiincludingdeletes OWNER TO postgres;

DROP VIEW IF EXISTS auth.schoolidtostaffusiincludingdeletes;

CREATE VIEW auth.schoolidtostaffusiincludingdeletes(schoolid, staffusi) AS
    -- School to Staff (through School employment)
    SELECT sch.schoolid, seo_empl.staffusi
    FROM edfi.school sch
        JOIN edfi.staffeducationorganizationemploymentassociation seo_empl
            ON sch.SchoolId = seo_empl.educationorganizationid

    UNION

    -- School to Staff (through deleted School employment)
    SELECT sch.schoolid, seo_empl_tc.oldstaffusi AS staffusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation seo_empl_tc
            ON sch.schoolid = seo_empl_tc.oldeducationorganizationid

    UNION

    -- School to Staff (through School-level department employment)
    SELECT sch.schoolid, seo_empl.staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.SchoolId = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationemploymentassociation seo_empl
            ON od.organizationdepartmentid = seo_empl.educationorganizationid

    UNION

    -- School to Staff (through deleted School-level department employment)
    SELECT sch.schoolid
        ,seo_empl_tc.oldstaffusi AS staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation seo_empl_tc
            ON od.organizationdepartmentid = seo_empl_tc.oldeducationorganizationid

    UNION

    -- School to Staff (through School assignment)
    SELECT sch.schoolid
        ,seo_assgn.staffusi
    FROM edfi.school sch
        JOIN edfi.staffeducationorganizationassignmentassociation seo_assgn
            ON sch.schoolid = seo_assgn.educationorganizationid

    UNION

    -- School to Staff (through deleted School assignment)
    SELECT sch.schoolid
        ,seo_assgn_tc.oldstaffusi AS staffusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation seo_assgn_tc
            ON sch.schoolid = seo_assgn_tc.oldeducationorganizationid

    UNION

    -- School to Staff (through School-level department assignment)
    SELECT sch.schoolid
        ,seo_assgn.staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationassignmentassociation seo_assgn
            ON od.organizationdepartmentid = seo_assgn.educationorganizationid

    UNION

    -- School to Staff (through deleted School-level department assignment)
    SELECT sch.schoolid
        ,seo_assgn_tc.oldstaffusi AS staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation seo_assgn_tc
            ON od.organizationdepartmentid = seo_assgn_tc.oldeducationorganizationid;

ALTER TABLE auth.schoolidtostaffusiincludingdeletes OWNER TO postgres;

DROP VIEW IF EXISTS auth.parentusitoschoolidincludingdeletes;

CREATE VIEW auth.parentusitoschoolidincludingdeletes(schoolid, parentusi) AS
    -- School to Parent USI
    SELECT ssa.schoolid, spa.parentusi
    FROM edfi.studentschoolassociation ssa
		JOIN edfi.studentparentassociation spa 
			ON ssa.studentusi = spa.studentusi
    
	UNION

    SELECT ssa.schoolid, spa_tc.oldparentusi AS ParentUSI
    FROM edfi.studentschoolassociation ssa
		JOIN tracked_changes_edfi.studentparentassociation spa_tc
			ON ssa.studentusi = spa_tc.oldstudentusi;

ALTER TABLE auth.parentusitoschoolidincludingdeletes OWNER TO postgres;
