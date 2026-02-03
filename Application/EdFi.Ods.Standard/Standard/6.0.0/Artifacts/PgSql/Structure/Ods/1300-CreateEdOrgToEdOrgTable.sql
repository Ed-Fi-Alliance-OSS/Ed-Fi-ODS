-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW auth.EducationOrganizationIdToEducationOrganizationId
AS
WITH RECURSIVE EdOrgIdToEdOrgId(SourceEducationOrganizationId, TargetEducationOrganizationId) AS (

    -- Anchor member definition
    SELECT StateEducationAgencyId, StateEducationAgencyId FROM edfi.StateEducationAgency
    UNION ALL SELECT EducationServiceCenterId, EducationServiceCenterId FROM edfi.EducationServiceCenter
    UNION ALL SELECT LocalEducationAgencyId, LocalEducationAgencyId FROM edfi.LocalEducationAgency
    UNION ALL SELECT SchoolId, SchoolId FROM edfi.School
    UNION ALL SELECT CommunityOrganizationId, CommunityOrganizationId FROM edfi.CommunityOrganization
    UNION ALL SELECT CommunityProviderId, CommunityProviderId FROM edfi.CommunityProvider
    UNION ALL SELECT EducationOrganizationNetworkId, EducationOrganizationNetworkId FROM edfi.EducationOrganizationNetwork
    UNION ALL SELECT PostSecondaryInstitutionId, PostSecondaryInstitutionId FROM edfi.PostSecondaryInstitution
    UNION ALL SELECT OrganizationDepartmentId, OrganizationDepartmentId FROM edfi.OrganizationDepartment
    
    -- Recursive member definition
    UNION ALL
    
    SELECT 
        parent.SourceEducationOrganizationId,
        child.TargetEducationOrganizationId
    FROM EdOrgIdToEdOrgId parent
    CROSS JOIN LATERAL (
        SELECT EducationServiceCenterId AS TargetEducationOrganizationId
        FROM edfi.EducationServiceCenter 
        WHERE StateEducationAgencyId = parent.TargetEducationOrganizationId
        
        UNION ALL
        
        SELECT LocalEducationAgencyId
        FROM edfi.LocalEducationAgency 
        WHERE ParentLocalEducationAgencyId = parent.TargetEducationOrganizationId
           OR EducationServiceCenterId = parent.TargetEducationOrganizationId
           OR StateEducationAgencyId = parent.TargetEducationOrganizationId
        
        UNION ALL
        
        SELECT SchoolId
        FROM edfi.School 
        WHERE LocalEducationAgencyId = parent.TargetEducationOrganizationId
        
        UNION ALL

        SELECT CommunityProviderId
        FROM edfi.CommunityProvider 
        WHERE CommunityOrganizationId = parent.TargetEducationOrganizationId

        UNION ALL

        SELECT OrganizationDepartmentId
        FROM edfi.OrganizationDepartment 
        WHERE ParentEducationOrganizationId = parent.TargetEducationOrganizationId
    ) child
)
SELECT SourceEducationOrganizationId, TargetEducationOrganizationId FROM EdOrgIdToEdOrgId;

CREATE INDEX IX_EducationServiceCenter_StateEducationAgencyId ON edfi.EducationServiceCenter (StateEducationAgencyId) INCLUDE (EducationServiceCenterId);

CREATE INDEX IX_LocalEducationAgency_ParentLocalEducationAgencyId ON edfi.LocalEducationAgency (ParentLocalEducationAgencyId) INCLUDE (LocalEducationAgencyId);
CREATE INDEX IX_LocalEducationAgency_EducationServiceCenterId ON edfi.LocalEducationAgency (EducationServiceCenterId) INCLUDE (LocalEducationAgencyId);
CREATE INDEX IX_LocalEducationAgency_StateEducationAgencyId ON edfi.LocalEducationAgency (StateEducationAgencyId) INCLUDE (LocalEducationAgencyId);

CREATE INDEX IX_School_LocalEducationAgencyId ON edfi.School (LocalEducationAgencyId) INCLUDE (SchoolId);

CREATE INDEX IX_CommunityProvider_CommunityOrganizationId ON edfi.CommunityProvider (CommunityOrganizationId) INCLUDE (CommunityProviderId);

CREATE INDEX IX_OrganizationDepartment_ParentEducationOrganizationId ON edfi.OrganizationDepartment (ParentEducationOrganizationId) INCLUDE (OrganizationDepartmentId);