-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.localeducationagencyidtostudentusiincludingdeletes;

CREATE VIEW auth.localeducationagencyidtostudentusiincludingdeletes(localeducationagencyid, studentusi) AS
    SELECT sch.localeducationagencyid, ssa.studentusi
    FROM edfi.school sch
        JOIN edfi.studentschoolassociation ssa ON sch.schoolid = ssa.schoolid

    UNION

    SELECT sch.localeducationagencyid, ssa_tc.oldstudentusi as studentusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.studentschoolassociation ssa_tc ON sch.schoolid = ssa_tc.oldschoolid;

ALTER TABLE auth.localeducationagencyidtostudentusiincludingdeletes OWNER TO postgres;

DROP VIEW IF EXISTS auth.localeducationagencyidtostaffusiincludingdeletes;

CREATE VIEW auth.localeducationagencyidtostaffusiincludingdeletes(localeducationagencyid, staffusi) AS
    -- LEA employment
    SELECT lea.localeducationagencyid, emp.staffusi
    FROM edfi.localeducationagency lea
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON lea.localeducationagencyid = emp.educationorganizationid

    UNION

    -- LEA employment (deleted employment)
    SELECT lea.localeducationagencyid, emp_tc.oldstaffusi as staffusi
    FROM edfi.localeducationagency lea
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON lea.localeducationagencyid = emp_tc.oldeducationorganizationid

    UNION

    -- LEA-level organization department employment
    SELECT lea.localeducationagencyid, emp.staffusi
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON od.organizationdepartmentid = emp.educationorganizationid

    UNION

    -- LEA-level organization department employment (deleted employment)
    SELECT lea.localeducationagencyid, emp_tc.oldstaffusi as staffusi
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON od.organizationdepartmentid = emp_tc.oldeducationorganizationid

    UNION

    -- LEA assignment
    SELECT lea.localeducationagencyid, assgn.staffusi
    FROM edfi.localeducationagency lea
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON lea.localeducationagencyid = assgn.educationorganizationid

    UNION

    -- LEA assignment (deleted assignment)
    SELECT lea.localeducationagencyid, assgn_tc.oldstaffusi as staffusi
    FROM edfi.localeducationagency lea
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON lea.localeducationagencyid = assgn_tc.oldeducationorganizationid

    UNION

    -- LEA-level organization department assignment
    SELECT lea.localeducationagencyid, assgn.staffusi
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON od.organizationdepartmentid = assgn.educationorganizationid

    UNION

    -- LEA-level organization department assignment (deleted assignment)
    SELECT lea.localeducationagencyid, assgn_tc.oldstaffusi as staffusi
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON od.organizationdepartmentid = assgn_tc.oldeducationorganizationid

    UNION

    -- School employment
    SELECT sch.localeducationagencyid, emp.staffusi
    FROM edfi.school sch
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON sch.schoolid = emp.educationorganizationid

    UNION

    -- School employment (deleted employment)
    SELECT sch.localeducationagencyid, emp_tc.oldstaffusi as staffusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON sch.schoolid = emp_tc.oldeducationorganizationid

    UNION

    -- School-level organization department employment
    SELECT sch.localeducationagencyid, emp.staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON od.organizationdepartmentid = emp.educationorganizationid

    UNION

    -- School-level organization department employment (deleted employment)
    SELECT sch.localeducationagencyid, emp_tc.oldstaffusi as staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON od.organizationdepartmentid = emp_tc.oldeducationorganizationid

    UNION

    -- School assignment
    SELECT sch.localeducationagencyid, assgn.staffusi
    FROM edfi.school sch
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON sch.schoolid = assgn.educationorganizationid

    UNION

    -- School assignment (deleted assignment)
    SELECT sch.localeducationagencyid, assgn_tc.oldstaffusi as staffusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON sch.schoolid = assgn_tc.oldeducationorganizationid

    UNION

    -- School-level organization department assignment
    SELECT sch.localeducationagencyid, assgn.staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON od.organizationdepartmentid = assgn.educationorganizationid

    UNION

    SELECT sch.localeducationagencyid, assgn_tc.oldstaffusi as staffusi
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON od.organizationdepartmentid = assgn_tc.oldeducationorganizationid;

ALTER TABLE auth.localeducationagencyidtostaffusiincludingdeletes OWNER TO postgres;

DROP VIEW IF EXISTS auth.localeducationagencyidtoparentusiincludingdeletes;

CREATE VIEW auth.localeducationagencyidtoparentusiincludingdeletes(localeducationagencyid, parentusi) AS
    -- Intact studentschoolassociation and intact studentparentassociation
    SELECT sch.localeducationagencyid, spa.parentusi
    FROM edfi.school sch
        JOIN edfi.studentschoolassociation ssa ON sch.schoolid = ssa.schoolid
        JOIN edfi.student s ON ssa.studentusi = s.studentusi
        JOIN edfi.studentparentassociation spa ON ssa.studentusi = spa.studentusi

    UNION

    -- Intact studentschoolassociation and deleted studentparentassociation
    SELECT sch.localeducationagencyid, spa_tc.oldparentusi as parentusi
    FROM edfi.school sch
        JOIN edfi.studentschoolassociation ssa ON sch.schoolid = ssa.schoolid
        JOIN tracked_changes_edfi.studentparentassociation spa_tc ON ssa.studentusi = spa_tc.oldstudentusi

    UNION

    -- Deleted studentschoolassociation and intact studentparentassociation
    SELECT sch.localeducationagencyid, spa.parentusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.studentschoolassociation ssa_tc ON sch.schoolid = ssa_tc.oldschoolid
        JOIN edfi.studentparentassociation spa ON ssa_tc.oldstudentusi = spa.studentusi

    UNION

    -- Deleted studentschoolassociation and studentparentassociation
    SELECT sch.localeducationagencyid, spa_tc.oldparentusi as parentusi
    FROM edfi.school sch
        JOIN tracked_changes_edfi.studentschoolassociation ssa_tc ON sch.schoolid = ssa_tc.oldschoolid
        JOIN tracked_changes_edfi.studentparentassociation spa_tc ON ssa_tc.oldstudentusi = spa_tc.oldstudentusi;

ALTER TABLE auth.localeducationagencyidtoparentusi OWNER TO postgres;
