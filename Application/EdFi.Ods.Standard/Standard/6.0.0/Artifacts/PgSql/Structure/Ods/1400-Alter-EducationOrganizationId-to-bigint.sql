-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStudentUSIIncludingDeletes;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStudentUSI;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToContactUSIIncludingDeletes;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToContactUSI;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStaffUSIIncludingDeletes;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStaffUSI;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStudentUSIThroughResponsibility;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToStudentUSIThroughDeletedResponsibility;

CREATE OR REPLACE VIEW auth.EducationOrganizationIdToStudentUSI
AS
    SELECT  edOrgs.SourceEducationOrganizationId, ssa.StudentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        INNER JOIN edfi.StudentSchoolAssociation ssa
            ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
    GROUP BY edOrgs.SourceEducationOrganizationId, ssa.StudentUSI;

CREATE OR REPLACE VIEW auth.EducationOrganizationIdToStaffUSI
AS
    -- EdOrg Assignments
    SELECT  edOrgs.SourceEducationOrganizationId, seo_assign.StaffUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assign
                ON edOrgs.TargetEducationOrganizationId =  seo_assign.EducationOrganizationId
    
    UNION

    -- EdOrg Employment
    SELECT  edOrgs.SourceEducationOrganizationId, seo_empl.StaffUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation seo_empl
                ON edOrgs.TargetEducationOrganizationId = seo_empl.EducationOrganizationId;


CREATE OR REPLACE VIEW auth.EducationOrganizationIdToContactUSI 
AS
    SELECT  edOrgs.SourceEducationOrganizationId, spa.ContactUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentSchoolAssociation ssa 
                ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
            INNER JOIN edfi.StudentContactAssociation spa 
                ON ssa.StudentUSI = spa.StudentUSI
    GROUP BY edOrgs.SourceEducationOrganizationId, spa.ContactUSI;

CREATE OR REPLACE VIEW auth.EducationOrganizationIdToStudentUSIThroughResponsibility
AS
    SELECT  edOrgs.SourceEducationOrganizationId, seora.StudentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seora
                ON edOrgs.TargetEducationOrganizationId = seora.EducationOrganizationId
    GROUP BY edOrgs.SourceEducationOrganizationId, seora.StudentUSI;

