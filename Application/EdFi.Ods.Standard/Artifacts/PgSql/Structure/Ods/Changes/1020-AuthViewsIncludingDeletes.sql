CREATE OR REPLACE VIEW auth.localeducationagencyidtostudentusiincludingdeletes(localeducationagencyid, studentusi) AS
    SELECT sch.localeducationagencyid, ssa.studentusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.studentschoolassociation ssa ON sch.schoolid = ssa.schoolid
    GROUP BY sch.localeducationagencyid, ssa.studentusi

    UNION

    SELECT sch.localeducationagencyid, ssa_tc.oldstudentusi as studentusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN tracked_changes_edfi.studentschoolassociation ssa_tc ON sch.schoolid = ssa_tc.oldschoolid
    GROUP BY sch.localeducationagencyid, ssa_tc.oldstudentusi;

ALTER TABLE auth.localeducationagencyidtostudentusiincludingdeletes OWNER TO postgres;

CREATE OR REPLACE VIEW auth.localeducationagencyidtostaffusiincludingdeletes(localeducationagencyid, staffusi) AS
    -- LEA employment
    SELECT lea.localeducationagencyid, emp.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON lea.localeducationagencyid = emp.educationorganizationid
    GROUP BY lea.localeducationagencyid, emp.staffusi

    UNION

    -- LEA employment (deleted employment)
    SELECT lea.localeducationagencyid, emp_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON lea.localeducationagencyid = emp_tc.oldeducationorganizationid
    GROUP BY lea.localeducationagencyid, emp_tc.oldstaffusi

    UNION

    -- LEA-level organization department employment
    SELECT lea.localeducationagencyid, emp.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON od.organizationdepartmentid = emp.educationorganizationid
    GROUP BY lea.localeducationagencyid, emp.staffusi

    UNION

    -- LEA-level organization department employment (deleted employment)
    SELECT lea.localeducationagencyid, emp_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON od.organizationdepartmentid = emp_tc.oldeducationorganizationid
    GROUP BY lea.localeducationagencyid, emp_tc.oldstaffusi

    UNION

    -- LEA assignment
    SELECT lea.localeducationagencyid, assgn.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON lea.localeducationagencyid = assgn.educationorganizationid
    GROUP BY lea.localeducationagencyid, assgn.staffusi

    UNION

    -- LEA assignment (deleted assignment)
    SELECT lea.localeducationagencyid, assgn_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON lea.localeducationagencyid = assgn_tc.oldeducationorganizationid
    GROUP BY lea.localeducationagencyid, assgn_tc.oldstaffusi

    UNION

    -- LEA-level organization department assignment
    SELECT lea.localeducationagencyid, assgn.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON od.organizationdepartmentid = assgn.educationorganizationid
    GROUP BY lea.localeducationagencyid, assgn.staffusi

    UNION

    -- LEA-level organization department assignment (deleted assignment)
    SELECT lea.localeducationagencyid, assgn_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.localeducationagency lea
        JOIN edfi.organizationdepartment od
            ON lea.localeducationagencyid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON od.organizationdepartmentid = assgn_tc.oldeducationorganizationid
    GROUP BY lea.localeducationagencyid, assgn_tc.oldstaffusi

    UNION

    -- School employment
    SELECT sch.localeducationagencyid, emp.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON sch.schoolid = emp.educationorganizationid
    GROUP BY sch.localeducationagencyid, emp.staffusi

    UNION

    -- School employment (deleted employment)
    SELECT sch.localeducationagencyid, emp_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON sch.schoolid = emp_tc.oldeducationorganizationid
    GROUP BY sch.localeducationagencyid, emp_tc.oldstaffusi

    UNION

    -- School-level organization department employment
    SELECT sch.localeducationagencyid, emp.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationemploymentassociation emp
            ON od.organizationdepartmentid = emp.educationorganizationid
    GROUP BY sch.localeducationagencyid, emp.staffusi

    UNION

    -- School-level organization department employment (deleted employment)
    SELECT sch.localeducationagencyid, emp_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationemploymentassociation emp_tc
            ON od.organizationdepartmentid = emp_tc.oldeducationorganizationid
    GROUP BY sch.localeducationagencyid, emp_tc.oldstaffusi

    UNION

    -- School assignment
    SELECT sch.localeducationagencyid, assgn.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON sch.schoolid = assgn.educationorganizationid
    GROUP BY sch.localeducationagencyid, assgn.staffusi

    UNION

    -- School assignment (deleted assignment)
    SELECT sch.localeducationagencyid, assgn_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON sch.schoolid = assgn_tc.oldeducationorganizationid
    GROUP BY sch.localeducationagencyid, assgn_tc.oldstaffusi

    UNION

    -- School-level organization department assignment
    SELECT sch.localeducationagencyid, assgn.staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN edfi.staffeducationorganizationassignmentassociation assgn
            ON od.organizationdepartmentid = assgn.educationorganizationid
    GROUP BY sch.localeducationagencyid, assgn.staffusi

    UNION

    SELECT sch.localeducationagencyid, assgn_tc.oldstaffusi as staffusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.organizationdepartment od
            ON sch.schoolid = od.parenteducationorganizationid
        JOIN tracked_changes_edfi.staffeducationorganizationassignmentassociation assgn_tc
            ON od.organizationdepartmentid = assgn_tc.oldeducationorganizationid
    GROUP BY sch.localeducationagencyid, assgn_tc.oldstaffusi;

ALTER TABLE auth.localeducationagencyidtostaffusiincludingdeletes OWNER TO postgres;

CREATE OR REPLACE VIEW auth.localeducationagencyidtoparentusiincludingdeletes(localeducationagencyid, parentusi) AS
    -- Intact studentschoolassociation and intact studentparentassociation
    SELECT sch.localeducationagencyid, spa.parentusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.studentschoolassociation ssa ON sch.schoolid = ssa.schoolid
        JOIN edfi.student s ON ssa.studentusi = s.studentusi
        JOIN edfi.studentparentassociation spa ON ssa.studentusi = spa.studentusi
    GROUP BY sch.localeducationagencyid, spa.parentusi
    UNION

    -- Intact studentschoolassociation and deleted studentparentassociation
    SELECT sch.localeducationagencyid, spa_tc.oldparentusi as parentusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN edfi.studentschoolassociation ssa ON sch.schoolid = ssa.schoolid
        JOIN tracked_changes_edfi.studentparentassociation spa_tc ON ssa.studentusi = spa_tc.oldstudentusi
    GROUP BY sch.localeducationagencyid, spa_tc.oldparentusi

    UNION

    -- Deleted studentschoolassociation and intact studentparentassociation
    SELECT sch.localeducationagencyid, spa.parentusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN tracked_changes_edfi.studentschoolassociation ssa_tc ON sch.schoolid = ssa_tc.oldschoolid
        JOIN edfi.studentparentassociation spa ON ssa_tc.oldstudentusi = spa.studentusi
    GROUP BY sch.localeducationagencyid, spa.parentusi

    UNION

    -- Deleted studentschoolassociation and studentparentassociation
    SELECT sch.localeducationagencyid, spa_tc.oldparentusi as parentusi, coalesce(1, count(1)) as ignored
    FROM edfi.school sch
        JOIN tracked_changes_edfi.studentschoolassociation ssa_tc ON sch.schoolid = ssa_tc.oldschoolid
        JOIN tracked_changes_edfi.studentparentassociation spa_tc ON ssa_tc.oldstudentusi = spa_tc.oldstudentusi
    GROUP BY sch.localeducationagencyid, spa_tc.oldparentusi;

ALTER TABLE auth.localeducationagencyidtoparentusi OWNER TO postgres;
