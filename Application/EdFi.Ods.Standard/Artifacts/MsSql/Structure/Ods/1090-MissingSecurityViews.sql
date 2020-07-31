CREATE VIEW [auth].[CommunityProviderIdToStaffUSI]
AS
    SELECT emp.EducationOrganizationId AS CommunityProviderId
          ,emp.StaffUSI
    FROM edfi.CommunityProvider cp
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp ON
        cp.CommunityProviderId = emp.EducationOrganizationId

    UNION ALL

    SELECT assgn.EducationOrganizationId AS CommunityProviderId
          ,assgn.StaffUSI
    FROM edfi.CommunityProvider cp
             INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn ON
        cp.CommunityProviderId = assgn.EducationOrganizationId
GO

CREATE VIEW [auth].[PostSecondaryInstitutionIdToStaffUSI]
AS
    SELECT emp.EducationOrganizationId AS PostSecondaryInstitutionId
          ,emp.StaffUSI
    FROM edfi.PostSecondaryInstitution psi
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp ON
        psi.PostSecondaryInstitutionId = emp.EducationOrganizationId

    UNION ALL

    SELECT assgn.EducationOrganizationId AS PostSecondaryInstitutionId
          ,assgn.StaffUSI
    FROM edfi.PostSecondaryInstitution psi
             INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn ON
        psi.PostSecondaryInstitutionId = assgn.EducationOrganizationId
GO

