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
DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
WHERE ClaimSetResourceClaimActionId IN (
    SELECT  csrc.ClaimSetResourceClaimActionId
    FROM    dbo.ClaimSetResourceClaimActions csrc
	INNER JOIN dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides csrcaaso
		ON csrc.ClaimSetResourceClaimActionId = csrcaaso.ClaimSetResourceClaimActionId
    INNER JOIN dbo.ClaimSets cs
        ON csrc.ClaimSetId = cs.ClaimSetId
    INNER JOIN dbo.AuthorizationStrategies strat
        ON csrcaaso.AuthorizationStrategyId = strat.AuthorizationStrategyId
    WHERE   csrc.ResourceClaimId = @organizationDepartmentClaimId
        AND cs.ClaimSetName IN ('SIS Vendor', 'Ed-Fi Sandbox', 'District Hosted SIS Vendor')
        AND strat.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'
)

DELETE FROM dbo.ClaimSetResourceClaimActions
WHERE ClaimSetResourceClaimActionId IN (
    SELECT  csrc.ClaimSetResourceClaimActionId
    FROM    dbo.ClaimSetResourceClaimActions csrc
	INNER JOIN dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides csrcaaso
		ON csrc.ClaimSetResourceClaimActionId = csrcaaso.ClaimSetResourceClaimActionId
    INNER JOIN dbo.ClaimSets cs
        ON csrc.ClaimSetId = cs.ClaimSetId
    INNER JOIN dbo.AuthorizationStrategies strat
        ON csrcaaso.AuthorizationStrategyId = strat.AuthorizationStrategyId
    WHERE   csrc.ResourceClaimId = @organizationDepartmentClaimId
        AND cs.ClaimSetName IN ('SIS Vendor', 'Ed-Fi Sandbox', 'District Hosted SIS Vendor')
        AND strat.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'
)

-- Set default authorization strategy for OrganizationDepartment to relationship-based
SELECT @relationshipsAuthorizationStrategyId = AuthorizationStrategyId
FROM dbo.AuthorizationStrategies
WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

IF NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActions WHERE ResourceClaimId = @organizationDepartmentClaimId)
BEGIN
    PRINT 'Assigning default metadata for CRUD operations on OrganizationDepartment to the relationship-based authorization strategy.'
    
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    SELECT @organizationDepartmentClaimId, ActionId
    FROM    dbo.Actions
    WHERE   ActionName IN ('Create', 'Read', 'Update', 'Delete')

	INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies](ResourceClaimActionId, AuthorizationStrategyId)
	SELECT rca.ResourceClaimActionId, @relationshipsAuthorizationStrategyId
	FROM dbo.ResourceClaimActions rca
	INNER JOIN dbo.Actions a
		ON rca.ActionId = a.ActionId
	WHERE rca.ResourceClaimId = @organizationDepartmentClaimId AND a.ActionName IN ('Create', 'Read', 'Update', 'Delete')
END

-- Move OrganizationDepartment under EducationOrganizations
UPDATE  dbo.ResourceClaims
SET     ParentResourceClaimId = @educationOrganizationsClaimId
WHERE   ResourceClaimId = @organizationDepartmentClaimId

SELECT  @schoolClaimId = ResourceClaimId 
FROM    dbo.ResourceClaims rc 
WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/school'

IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions csrc INNER JOIN dbo.ClaimSets cs ON csrc.ClaimSetId = cs.ClaimSetId WHERE cs.ClaimSetName = 'District Hosted SIS Vendor' AND csrc.ResourceClaimId = @schoolClaimId)
BEGIN
    PRINT 'Copying School overrides to OrganizationDepartment for District Hosted Vendor claim set.'

    -- Assign same permissions to School overrides for District Hosted SIS Vendor
    INSERT INTO dbo.ClaimSetResourceClaimActions(ClaimSetId, ResourceClaimId, ActionId)
    SELECT  csrc.ClaimSetId, @organizationDepartmentClaimId, csrc.ActionId
    FROM    dbo.ClaimSetResourceClaimActions csrc
    INNER JOIN dbo.ClaimSets cs
        ON csrc.ClaimSetId = cs.ClaimSetId
    WHERE   cs.ClaimSetName = 'District Hosted SIS Vendor'
        AND csrc.ResourceClaimId = @schoolClaimId 

	INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
	SELECT csrc.ClaimSetResourceClaimActionId, csrcaaso.AuthorizationStrategyId
	FROM dbo.ClaimSetResourceClaimActions csrc
	INNER JOIN dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides csrcaaso
		ON csrc.ClaimSetResourceClaimActionId = csrcaaso.ClaimSetResourceClaimActionId
	INNER JOIN dbo.ClaimSets cs
        ON csrc.ClaimSetId = cs.ClaimSetId
	WHERE cs.ClaimSetName = 'District Hosted SIS Vendor'
        AND csrc.ResourceClaimId = @schoolClaimId
END
