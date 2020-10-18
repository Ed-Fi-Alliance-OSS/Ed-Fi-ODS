ALTER VIEW [auth].[EducationOrganizationIdentifiers]
AS
-- NOTE: Multiple results for a single Education Organization are possible if they are a part of multiple Education Organization Networks
SELECT  edorg.EducationOrganizationId,
        CASE
            WHEN sea.StateEducationAgencyId IS NOT NULL THEN N'StateEducationAgency'
            WHEN esc.EducationServiceCenterId IS NOT NULL THEN N'EducationServiceCenter'
            WHEN lea.LocalEducationAgencyId IS NOT NULL THEN N'LocalEducationAgency'
            WHEN sch.SchoolId IS NOT NULL THEN N'School'
            WHEN co.CommunityOrganizationId IS NOT NULL THEN N'CommunityOrganization'
            WHEN cp.CommunityProviderId IS NOT NULL THEN N'CommunityProvider'
            WHEN co.CommunityOrganizationId IS NOT NULL THEN N'CommunityOrganization'
            WHEN psi.PostSecondaryInstitutionId IS NOT NULL THEN N'PostSecondaryInstitution'
            WHEN u.UniversityId IS NOT NULL THEN 'University'
            WHEN tpp.TeacherPreparationProviderId IS NOT NULL THEN 'TeacherPreparationProvider'
        END AS EducationOrganizationType,
        COALESCE(sea.StateEducationAgencyId, esc.StateEducationAgencyId, lea.StateEducationAgencyId, lea_sch.StateEducationAgencyId) AS StateEducationAgencyId,
        COALESCE(esc.EducationServiceCenterId, lea.EducationServiceCenterId, lea_sch.EducationServiceCenterId) AS EducationServiceCenterId,
        COALESCE(lea.LocalEducationAgencyId, sch.LocalEducationAgencyId) AS LocalEducationAgencyId,
        COALESCE(co.CommunityOrganizationID, cp.CommunityOrganizationId) AS CommunityOrganizationId,
        cp.CommunityProviderId,
        psi.PostSecondaryInstitutionId,
        sch.SchoolId,
        edorg.Discriminator AS FullEducationOrganizationType,
        edorg.NameOfInstitution,
        u.UniversityId,
        tpp.TeacherPreparationProviderId
FROM    edfi.EducationOrganization edorg
        LEFT JOIN edfi.StateEducationAgency sea
            ON edorg.EducationOrganizationId = sea.StateEducationAgencyId
        LEFT JOIN edfi.EducationServiceCenter esc
            ON edorg.EducationOrganizationId = esc.EducationServiceCenterId
        LEFT JOIN edfi.LocalEducationAgency lea
            ON edorg.EducationOrganizationId = lea.LocalEducationAgencyId
        LEFT JOIN edfi.School sch
            ON edorg.EducationOrganizationId = sch.SchoolId
        LEFT JOIN edfi.LocalEducationAgency lea_sch
            ON sch.LocalEducationAgencyId = lea_sch.LocalEducationAgencyId
        LEFT JOIN edfi.CommunityOrganization co
            ON edorg.EducationOrganizationId = co.CommunityOrganizationId
        LEFT JOIN edfi.CommunityProvider cp
            ON edorg.EducationOrganizationId = cp.CommunityProviderId
        LEFT JOIN edfi.CommunityOrganization cp_co
            ON cp.CommunityOrganizationId = cp_co.CommunityOrganizationId
        LEFT JOIN edfi.PostSecondaryInstitution psi
            ON edorg.EducationOrganizationId = psi.PostSecondaryInstitutionId
        LEFT JOIN tpdm.University u
            ON edorg.EducationOrganizationId = u.UniversityId
        LEFT JOIN tpdm.TeacherPreparationProvider tpp
            ON edorg.EducationOrganizationId = tpp.TeacherPreparationProviderId
WHERE   --Use same CASE as above to eliminate non-institutions (e.g. Networks)
        CASE
            WHEN sea.StateEducationAgencyId IS NOT NULL THEN N'StateEducationAgency'
            WHEN esc.EducationServiceCenterId IS NOT NULL THEN N'EducationServiceCenter'
            WHEN lea.LocalEducationAgencyId IS NOT NULL THEN N'LocalEducationAgency'
            WHEN sch.SchoolId IS NOT NULL THEN N'School'
            WHEN co.CommunityOrganizationId IS NOT NULL THEN N'CommunityOrganization'
            WHEN cp.CommunityProviderId IS NOT NULL THEN N'CommunityProvider'
            WHEN psi.PostSecondaryInstitutionId IS NOT NULL THEN N'PostSecondaryInstitution'
            WHEN u.UniversityId IS NOT NULL THEN 'University'
            WHEN tpp.TeacherPreparationProviderId IS NOT NULL THEN 'TeacherPreparationProvider'
        END IS NOT NULL
GO

CREATE VIEW [auth].[EducationOrganizationIdToUniversityId]
AS
    SELECT UniversityId
          ,UniversityId AS EducationOrganizationId
    FROM tpdm.University
GO

CREATE VIEW [auth].[EducationOrganizationIdToTeacherPreparationProviderId]
AS
    SELECT TeacherPreparationProviderId
          ,TeacherPreparationProviderId AS EducationOrganizationId
    FROM tpdm.TeacherPreparationProvider
GO

CREATE VIEW [auth].[StaffUSIToTeacherPreparationProviderId]
AS
    SELECT emp.EducationOrganizationId AS TeacherPreparationProviderId
          ,emp.StaffUSI
    FROM tpdm.TeacherPreparationProvider tpp
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp ON
        tpp.TeacherPreparationProviderId = emp.EducationOrganizationId

    UNION ALL

    SELECT assgn.EducationOrganizationId AS TeacherPreparationProviderId
          ,assgn.StaffUSI
    FROM tpdm.TeacherPreparationProvider tpp
             INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn ON
        tpp.TeacherPreparationProviderId = assgn.EducationOrganizationId
GO

CREATE VIEW [auth].[StaffUSIToUniversityId]
AS
    SELECT emp.EducationOrganizationId AS UniversityId
          ,emp.StaffUSI
    FROM tpdm.University u
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp ON
        u.UniversityId = emp.EducationOrganizationId

    UNION ALL

    SELECT assgn.EducationOrganizationId AS UniversityId
          ,assgn.StaffUSI
    FROM tpdm.University u
             INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn ON
        u.UniversityId = assgn.EducationOrganizationId
GO