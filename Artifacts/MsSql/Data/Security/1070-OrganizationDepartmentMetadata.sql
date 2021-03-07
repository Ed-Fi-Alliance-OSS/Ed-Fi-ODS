-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE 
    @organizationDepartmentClaimId INT,
    @educationOrganizationsClaimId INT,
    @schoolClaimId INT,
	@relationshipsAuthorizationStrategyId INT

SELECT  @organizationDepartmentClaimId = ResourceClaimId 
FROM    dbo.ResourceClaims rc 
WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/organizationDepartment'

SELECT  @educationOrganizationsClaimId = ResourceClaimId 
FROM    dbo.ResourceClaims rc 
WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations'

-- Remove existing claim set overrides for OrganizationDepartment
DELETE FROM dbo.ClaimSetResourceClaims
WHERE ClaimSetResourceClaimId IN (
    SELECT  ClaimSetResourceClaimId
    FROM    dbo.ClaimSetResourceClaims csrc
        INNER JOIN dbo.ClaimSets cs
            ON csrc.ClaimSet_ClaimSetId = cs.ClaimSetId
        INNER JOIN dbo.AuthorizationStrategies strat
            ON csrc.AuthorizationStrategyOverride_AuthorizationStrategyId = strat.AuthorizationStrategyId
    WHERE   csrc.ResourceClaim_ResourceClaimId = @organizationDepartmentClaimId
        AND cs.ClaimSetName IN ('SIS Vendor', 'Ed-Fi Sandbox', 'District Hosted SIS Vendor')
        AND strat.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'
)

-- Set default authorization strategy for OrganizationDepartment to relationship-based
SELECT @relationshipsAuthorizationStrategyId = AuthorizationStrategyId
FROM dbo.AuthorizationStrategies
WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
SELECT @organizationDepartmentClaimId, ActionId, @relationshipsAuthorizationStrategyId
FROM    dbo.Actions
WHERE   ActionName IN ('Create', 'Read', 'Update', 'Delete')

-- Move OrganizationDepartment under EducationOrganizations
UPDATE  dbo.ResourceClaims
SET     ParentResourceClaimId = @educationOrganizationsClaimId
WHERE   ResourceClaimId = @organizationDepartmentClaimId

SELECT  @schoolClaimId = ResourceClaimId 
FROM    dbo.ResourceClaims rc 
WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/school'

-- Assign same permissions to School overrides for District Hosted SIS Vendor
INSERT INTO dbo.ClaimSetResourceClaims(ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
SELECT  csrc.ClaimSet_ClaimSetId, @organizationDepartmentClaimId, csrc.Action_ActionId, csrc.AuthorizationStrategyOverride_AuthorizationStrategyId
FROM    dbo.ClaimSetResourceClaims csrc
    INNER JOIN dbo.ClaimSets cs
        ON csrc.ClaimSet_ClaimSetId = cs.ClaimSetId
WHERE   cs.ClaimSetName = 'District Hosted SIS Vendor'
    AND csrc.ResourceClaim_ResourceClaimId = @schoolClaimId 
