-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Drop dependent views
DROP VIEW IF EXISTS auth.EducationOrganizationIdToStaffUSI;

DROP VIEW IF EXISTS auth.CommunityProviderIdToStaffUSI;

CREATE VIEW auth.CommunityProviderIdToStaffUSI
AS
    -- CommunityProvider to Staff (through CommunityProvider employment)
    SELECT emp.EducationOrganizationId AS CommunityProviderId
        ,emp.StaffUSI
    FROM edfi.CommunityProvider cp
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON cp.CommunityProviderId = emp.EducationOrganizationId

    UNION

    -- CommunityProvider to Staff (through CommunityProvider assignment)
    SELECT assgn.EducationOrganizationId AS CommunityProviderId
        ,assgn.StaffUSI
    FROM edfi.CommunityProvider cp
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON cp.CommunityProviderId = assgn.EducationOrganizationId;

DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStaffUSI;

CREATE VIEW auth.LocalEducationAgencyIdToStaffUSI
AS
    -- LEA to Staff (through LEA employment)
    SELECT emp.EducationOrganizationId AS LocalEducationAgencyId
        ,emp.StaffUSI
    FROM edfi.LocalEducationAgency lea
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON lea.LocalEducationAgencyId = emp.EducationOrganizationId

    UNION

    -- LEA to Staff (through LEA assignment)
    SELECT assgn.EducationOrganizationId AS LocalEducationAgencyId
         ,assgn.StaffUSI
    FROM edfi.LocalEducationAgency lea
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON lea.LocalEducationAgencyId = assgn.EducationOrganizationId

    UNION

    -- LEA to Staff (through School employment)
    SELECT sch.LocalEducationAgencyId
         ,emp.StaffUSI
    FROM edfi.School sch
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON sch.SchoolId = emp.EducationOrganizationId

    UNION

    -- LEA to Staff (through School assignment)
    SELECT sch.LocalEducationAgencyId
         ,assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON sch.SchoolId = assgn.EducationOrganizationId;

DROP VIEW IF EXISTS auth.PostSecondaryInstitutionIdToStaffUSI;

CREATE VIEW auth.PostSecondaryInstitutionIdToStaffUSI
AS
    -- PostSecondaryInstitution to Staff (through PostSecondaryInstitution employment)
    SELECT emp.EducationOrganizationId AS PostSecondaryInstitutionId
        ,emp.StaffUSI
    FROM edfi.PostSecondaryInstitution psi
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON psi.PostSecondaryInstitutionId = emp.EducationOrganizationId

    UNION

    -- PostSecondaryInstitution to Staff (through PostSecondaryInstitution assignment)
    SELECT assgn.EducationOrganizationId AS PostSecondaryInstitutionId
        ,assgn.StaffUSI
    FROM edfi.PostSecondaryInstitution psi
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON psi.PostSecondaryInstitutionId = assgn.EducationOrganizationId;

DROP VIEW IF EXISTS auth.SchoolIdToStaffUSI;

CREATE VIEW auth.SchoolIdToStaffUSI
AS
    -- School to Staff (through School employment)
    SELECT sch.SchoolId
        ,seo_empl.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation seo_empl
            ON sch.SchoolId = seo_empl.EducationOrganizationId

    UNION

    -- School to Staff (through School assignment)
    SELECT sch.SchoolId
        ,seo_assgn.StaffUSI
    FROM edfi.School sch
        INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn
            ON sch.SchoolId = seo_assgn.EducationOrganizationId;

-- Recreate dependent views
CREATE VIEW auth.EducationOrganizationIdToStaffUSI
AS
    SELECT SchoolId AS EducationOrganizationId
         ,StaffUSI
    FROM auth.SchoolIdToStaffUSI

    UNION ALL

    SELECT LocalEducationAgencyId AS EducationOrganizationId
         ,StaffUSI
    FROM auth.LocalEducationAgencyIdToStaffUSI;
