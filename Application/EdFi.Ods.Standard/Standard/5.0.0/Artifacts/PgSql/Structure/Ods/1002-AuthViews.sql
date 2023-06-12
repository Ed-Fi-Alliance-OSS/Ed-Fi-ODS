-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW auth.EducationOrganizationToStaffUSI_Assignment
AS
-- EdOrg to Staff (through assignment)
SELECT edorg.EducationOrganizationId
     ,assgn.StaffUSI
     ,COUNT(*) AS Count
FROM edfi.EducationOrganization edorg
         INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation assgn ON
        edorg.EducationOrganizationId = assgn.EducationOrganizationId
GROUP BY assgn.StaffUSI
       ,edorg.EducationOrganizationId;

CREATE VIEW auth.EducationOrganizationToStaffUSI_Employment
AS
-- EdOrg to Staff (through Employment)
SELECT edorg.EducationOrganizationId
     ,empl.StaffUSI
     ,COUNT(*) AS Count
FROM edfi.EducationOrganization edorg
         INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation empl ON edorg.EducationOrganizationId = empl.EducationOrganizationId
GROUP BY empl.StaffUSI
       ,edorg.EducationOrganizationId;

CREATE VIEW auth.LocalEducationAgencyIdToStaffUSI
AS
-- LEA to Staff (through employment)
    SELECT emp.EducationOrganizationId AS LocalEducationAgencyId
         ,cast(NULL AS INT) AS SchoolId
         ,emp.StaffUSI
    FROM edfi.LocalEducationAgency lea
             INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp ON
            lea.LocalEducationAgencyId = emp.EducationOrganizationId

    UNION ALL

-- LEA to Staff (through assignment)
    SELECT assgn.EducationOrganizationId AS LocalEducationAgencyId
         ,cast(NULL AS INT) AS SchoolId
         ,assgn.StaffUSI
    FROM edfi.LocalEducationAgency lea
             INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn ON
            lea.LocalEducationAgencyId = assgn.EducationOrganizationId

    UNION ALL

-- School to Staff (through employment)
    SELECT sch.LocalEducationAgencyId
         ,emp.EducationOrganizationId AS SchoolId
         ,emp.StaffUSI
    FROM edfi.School sch
             INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp ON
            sch.SchoolId = emp.EducationOrganizationId

    UNION ALL

-- School to Staff (through assignment)
    SELECT sch.LocalEducationAgencyId
         ,assgn.EducationOrganizationId AS SchoolId
         ,assgn.StaffUSI
    FROM edfi.School sch
             INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn ON
            sch.SchoolId = assgn.EducationOrganizationId;

CREATE VIEW auth.SchoolIdToStaffUSI
AS
-- School to Staff (through employment)
    SELECT DISTINCT sch.SchoolId
         ,seo_empl.StaffUSI
    FROM edfi.School sch
             INNER JOIN edfi.StaffEducationOrganizationEmploymentAssociation seo_empl ON
            sch.SchoolId = seo_empl.EducationOrganizationId

    UNION ALL

-- School to Staff (through assignment)
    SELECT DISTINCT sch.SchoolId
         ,seo_assgn.StaffUSI
    FROM edfi.School sch
             INNER JOIN edfi.StaffEducationOrganizationAssignmentAssociation seo_assgn ON
            sch.SchoolId = seo_assgn.EducationOrganizationId;

CREATE VIEW auth.EducationOrganizationIdToStaffUSI
AS
    SELECT SchoolId AS EducationOrganizationId
         ,StaffUSI
    FROM auth.SchoolIdToStaffUSI

    UNION ALL

    SELECT LocalEducationAgencyId AS EducationOrganizationId
         ,StaffUSI
    FROM auth.LocalEducationAgencyIdToStaffUSI;

CREATE VIEW auth.LocalEducationAgencyIdToStudentUSI
AS
-- LEA to Student GUID
SELECT sch.LocalEducationAgencyId
     ,ssa.StudentUSI
     ,COUNT(*) AS Ignored
FROM edfi.School sch
         INNER JOIN edfi.StudentSchoolAssociation ssa ON sch.SchoolId = ssa.SchoolId
GROUP BY sch.LocalEducationAgencyId
       ,ssa.StudentUSI;

CREATE VIEW auth.SchoolIdToStudentUSI
AS
-- LEA to Student GUID
SELECT ssa.SchoolId
     ,ssa.StudentUSI
     ,COUNT(*) AS Ignored
FROM edfi.StudentSchoolAssociation ssa
GROUP BY ssa.SchoolId
     ,ssa.StudentUSI;

CREATE VIEW auth.EducationOrganizationIdToStudentUSI
AS
    SELECT SchoolId As EducationOrganizationId, StudentUSI
    FROM auth.SchoolIdToStudentUSI

    UNION ALL
    SELECT LocalEducationAgencyId As EducationOrganizationId, StudentUSI
    FROM auth.LocalEducationAgencyIdToStudentUSI;

CREATE VIEW auth.EducationOrganizationIdentifiers
AS
-- NOTE: Multiple results for a single Education Organization are possible if they are a part of multiple Education Organization Networks
SELECT edorg.EducationOrganizationId
     ,CASE
          WHEN sea.StateEducationAgencyId IS NOT NULL
              THEN N'StateEducationAgency'
          WHEN esc.EducationServiceCenterId IS NOT NULL
              THEN N'EducationServiceCenter'
          WHEN lea.LocalEducationAgencyId IS NOT NULL
              THEN N'LocalEducationAgency'
          WHEN sch.SchoolId IS NOT NULL
              THEN N'School'
          WHEN co.CommunityOrganizationId IS NOT NULL
              THEN N'CommunityOrganization'
          WHEN cp.CommunityProviderId IS NOT NULL
              THEN N'CommunityProvider'
          WHEN co.CommunityOrganizationId IS NOT NULL
              THEN N'CommunityOrganization'
          WHEN psi.PostSecondaryInstitutionId IS NOT NULL
              THEN N'PostSecondaryInstitution'
    END AS EducationOrganizationType
     ,COALESCE(sea.StateEducationAgencyId, esc.StateEducationAgencyId, lea.StateEducationAgencyId, lea_sch.StateEducationAgencyId) AS StateEducationAgencyId
     ,COALESCE(esc.EducationServiceCenterId, lea.EducationServiceCenterId, lea_sch.EducationServiceCenterId) AS EducationServiceCenterId
     ,COALESCE(lea.LocalEducationAgencyId, sch.LocalEducationAgencyId) AS LocalEducationAgencyId
     ,COALESCE(co.CommunityOrganizationId, cp.CommunityOrganizationId) AS CommunityOrganizationId
     ,cp.CommunityProviderId
     ,psi.PostSecondaryInstitutionId
     ,sch.SchoolId
FROM edfi.EducationOrganization edorg
         LEFT JOIN edfi.StateEducationAgency sea ON
        edorg.EducationOrganizationId = sea.StateEducationAgencyId
         LEFT JOIN edfi.EducationServiceCenter esc ON
        edorg.EducationOrganizationId = esc.EducationServiceCenterId
         LEFT JOIN edfi.LocalEducationAgency lea ON
        edorg.EducationOrganizationId = lea.LocalEducationAgencyId
         LEFT JOIN edfi.School sch ON
        edorg.EducationOrganizationId = sch.SchoolId
         LEFT JOIN edfi.LocalEducationAgency lea_sch ON
        sch.LocalEducationAgencyId = lea_sch.LocalEducationAgencyId
         LEFT JOIN edfi.CommunityOrganization co ON
        edorg.EducationOrganizationId = co.CommunityOrganizationId
         LEFT JOIN edfi.CommunityProvider cp ON
        edorg.EducationOrganizationId = cp.CommunityProviderId
         LEFT JOIN edfi.CommunityOrganization cp_co ON
        cp.CommunityOrganizationId = cp_co.CommunityOrganizationId
         LEFT JOIN edfi.PostSecondaryInstitution psi ON
        edorg.EducationOrganizationId = psi.PostSecondaryInstitutionId
WHERE --Use same CASE as above to eliminate non-institutions (e.g. Networks)
      CASE
          WHEN sea.StateEducationAgencyId IS NOT NULL
              THEN N'StateEducationAgency'
          WHEN esc.EducationServiceCenterId IS NOT NULL
              THEN N'EducationServiceCenter'
          WHEN lea.LocalEducationAgencyId IS NOT NULL
              THEN N'LocalEducationAgency'
          WHEN sch.SchoolId IS NOT NULL
              THEN N'School'
          WHEN co.CommunityOrganizationId IS NOT NULL
              THEN N'CommunityOrganization'
          WHEN cp.CommunityProviderId IS NOT NULL
              THEN N'CommunityProvider'
          WHEN psi.PostSecondaryInstitutionId IS NOT NULL
              THEN N'PostSecondaryInstitution'
          END IS NOT NULL;

CREATE VIEW auth.EducationOrganizationIdToEducationServiceCenterId
AS
-- Only LEAs and Schools are accessible to ESC-level claims
    SELECT EducationServiceCenterId
         ,LocalEducationAgencyId AS EducationOrganizationId
    FROM auth.EducationOrganizationIdentifiers
    WHERE LocalEducationAgencyId IS NOT NULL

    UNION
    SELECT EducationServiceCenterId
         ,SchoolId AS EducationOrganizationId
    FROM auth.EducationOrganizationIdentifiers
    WHERE SchoolId IS NOT NULL

    UNION
-- ESC-level claims also can access the ESC
    SELECT EducationServiceCenterId
         ,EducationServiceCenterId AS EducationOrganizationId
    FROM edfi.EducationServiceCenter;

CREATE VIEW auth.EducationOrganizationIdToStateAgencyId
AS
-- Only ESCs, LEAs and Schools are accessible to State-level claims
    SELECT StateEducationAgencyId
         ,EducationServiceCenterId AS EducationOrganizationId
    FROM auth.EducationOrganizationIdentifiers
    WHERE EducationServiceCenterId IS NOT NULL

    UNION
    SELECT StateEducationAgencyId
         ,LocalEducationAgencyId AS EducationOrganizationId
    FROM auth.EducationOrganizationIdentifiers
    WHERE LocalEducationAgencyId IS NOT NULL

    UNION
    SELECT StateEducationAgencyId
         ,SchoolId AS EducationOrganizationId
    FROM auth.EducationOrganizationIdentifiers
    WHERE SchoolId IS NOT NULL

    UNION
-- State-level claims also can access the State
    SELECT StateEducationAgencyId
         ,StateEducationAgencyId AS EducationOrganizationId
    FROM edfi.StateEducationAgency;

CREATE VIEW auth.CommunityOrganizationIdToCommunityProviderId
AS
SELECT CommunityOrganizationId
     ,CommunityProviderId
FROM edfi.CommunityProvider;

CREATE VIEW auth.EducationOrganizationIdToCommunityOrganizationId
AS
    SELECT CommunityOrganizationId
         ,CommunityProviderId AS EducationOrganizationId
    FROM edfi.CommunityProvider

    UNION

    SELECT CommunityOrganizationId
         ,CommunityOrganizationId AS EducationOrganizationId
    FROM edfi.CommunityOrganization;

CREATE VIEW auth.EducationOrganizationIdToCommunityProviderId
AS
SELECT CommunityProviderId
     ,CommunityProviderId AS EducationOrganizationId
FROM edfi.CommunityProvider;

CREATE VIEW auth.EducationOrganizationIdToLocalEducationAgencyId
AS
    SELECT LocalEducationAgencyId
         ,SchoolId AS EducationOrganizationId
    FROM edfi.School

    UNION

-- LEA-level claims also can access the LEA
    SELECT LocalEducationAgencyId
         ,LocalEducationAgencyId AS EducationOrganizationId
    FROM edfi.LocalEducationAgency;

CREATE VIEW auth.EducationOrganizationIdToPostSecondaryInstitutionId
AS
SELECT PostSecondaryInstitutionId
     ,PostSecondaryInstitutionId AS EducationOrganizationId
FROM edfi.PostSecondaryInstitution;

CREATE VIEW auth.EducationOrganizationIdToSchoolId
AS
-- School-level claims only can access the school
SELECT SchoolId
     ,SchoolId AS EducationOrganizationId
FROM edfi.School;

CREATE VIEW auth.LocalEducationAgency
AS
SELECT Id
     ,LocalEducationAgencyId
FROM edfi.LocalEducationAgency lea
         INNER JOIN edfi.EducationOrganization edorg ON
        edorg.EducationOrganizationId = lea.LocalEducationAgencyId;

CREATE VIEW auth.LocalEducationAgencyIdToParentUSI
AS
-- LEA to Parent USI
SELECT sch.LocalEducationAgencyId
     ,spa.ParentUSI
     ,COUNT(*) AS Count
FROM edfi.School sch
         INNER JOIN edfi.StudentSchoolAssociation ssa ON
        sch.SchoolId = ssa.SchoolId
         INNER JOIN edfi.Student s ON
        ssa.StudentUSI = s.StudentUSI
         INNER JOIN edfi.StudentParentAssociation spa ON
        ssa.StudentUSI = spa.StudentUSI
GROUP BY spa.ParentUSI
       ,LocalEducationAgencyId;

CREATE VIEW auth.LocalEducationAgencyIdToSchoolId
AS
-- LEA to School
SELECT LocalEducationAgencyId
     ,SchoolId
FROM edfi.School sch;

CREATE VIEW auth.LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation
AS
    SELECT DISTINCT lea.LocalEducationAgencyId
         ,seoa_lea.StudentUSI
    FROM edfi.LocalEducationAgency lea
             INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seoa_lea ON
            lea.LocalEducationAgencyId = seoa_lea.EducationOrganizationId

    UNION

    SELECT DISTINCT sch.LocalEducationAgencyId
         ,seoa_sch.StudentUSI
    FROM edfi.School sch
             INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seoa_sch ON
            sch.SchoolId = seoa_sch.EducationOrganizationId;

CREATE VIEW auth.ParentUSIToSchoolId
AS
-- School to Parent USI
SELECT ssa.SchoolId
     ,spa.ParentUSI
     ,COUNT(*) AS Count
FROM edfi.StudentSchoolAssociation ssa
         INNER JOIN edfi.Student s ON
        ssa.StudentUSI = s.StudentUSI
         INNER JOIN edfi.StudentParentAssociation spa ON
        ssa.StudentUSI = spa.StudentUSI
GROUP BY spa.ParentUSI
       ,SchoolId;

CREATE VIEW auth.ParentUSIToStudentUSI
AS
SELECT spa.StudentUSI
     ,spa.ParentUSI
     ,COUNT(*) AS Count
FROM edfi.StudentParentAssociation spa
GROUP BY spa.StudentUSI
     ,spa.ParentUSI;

CREATE VIEW auth.School
AS
SELECT Id
     ,SchoolId
     ,LocalEducationAgencyId
FROM edfi.School sch
         INNER JOIN edfi.EducationOrganization edorg ON
        edorg.EducationOrganizationId = sch.SchoolId;

CREATE VIEW auth.SchoolIdToStudentUSIThroughEdOrgAssociation
AS
SELECT DISTINCT SchoolId
     ,seoa.StudentUSI
FROM edfi.School sch
         INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seoa ON
        sch.SchoolId = seoa.EducationOrganizationId;
