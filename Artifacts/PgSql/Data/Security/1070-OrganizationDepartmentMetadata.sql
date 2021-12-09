-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
organization_department_claim_id INT;
education_organizations_claim_id INT;
school_claim_id INT;
relationships_authorization_strategy_id INT;

BEGIN

	SELECT  ResourceClaimId INTO organization_department_claim_id
	FROM    dbo.ResourceClaims rc
	WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/organizationDepartment';

	SELECT  ResourceClaimId INTO education_organizations_claim_id
	FROM    dbo.ResourceClaims rc
	WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations';

	-- Remove existing claim set overrides for OrganizationDepartment
	DELETE FROM dbo.ClaimSetResourceClaims
	WHERE ClaimSetResourceClaimId IN (
		SELECT  ClaimSetResourceClaimId
		FROM    dbo.ClaimSetResourceClaims csrc
			INNER JOIN dbo.ClaimSets cs
				ON csrc.ClaimSet_ClaimSetId = cs.ClaimSetId
			INNER JOIN dbo.AuthorizationStrategies strat
				ON csrc.AuthorizationStrategyOverride_AuthorizationStrategyId = strat.AuthorizationStrategyId
		WHERE   csrc.ResourceClaim_ResourceClaimId = organization_department_claim_id
			AND cs.ClaimSetName IN ('SIS Vendor', 'Ed-Fi Sandbox', 'District Hosted SIS Vendor')
			AND strat.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'
	);

	-- Set default authorization strategy for OrganizationDepartment to relationship-based
	SELECT AuthorizationStrategyId INTO relationships_authorization_strategy_id
	FROM dbo.AuthorizationStrategies
	WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

	IF NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimAuthorizationMetadatas WHERE ResourceClaim_ResourceClaimId = organization_department_claim_id)
	THEN
		RAISE NOTICE 'Assigning default metadata for CRUD operations on OrganizationDepartment to the relationship-based authorization strategy.';

		INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
		SELECT  organization_department_claim_id, ActionId, relationships_authorization_strategy_id
		FROM    dbo.Actions
		WHERE   ActionName IN ('Create', 'Read', 'Update', 'Delete');
	END IF;

	-- Move OrganizationDepartment under EducationOrganizations
	UPDATE  dbo.ResourceClaims
	SET     ParentResourceClaimId = education_organizations_claim_id
	WHERE   ResourceClaimId = organization_department_claim_id;

	SELECT  ResourceClaimId INTO school_claim_id
	FROM    dbo.ResourceClaims rc
	WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/school';

	-- Assign same permissions to School overrides for District Hosted SIS Vendor
	IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaims csrc INNER JOIN dbo.ClaimSets cs ON csrc.ClaimSet_ClaimSetId = cs.ClaimSetId WHERE cs.ClaimSetName = 'District Hosted SIS Vendor' AND csrc.ResourceClaim_ResourceClaimId = school_claim_id)
	THEN
		RAISE NOTICE 'Copying School overrides to OrganizationDepartment for District Hosted Vendor claim set.';

		INSERT INTO dbo.ClaimSetResourceClaims(ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
		SELECT  csrc.ClaimSet_ClaimSetId, organization_department_claim_id, csrc.Action_ActionId, csrc.AuthorizationStrategyOverride_AuthorizationStrategyId
		FROM    dbo.ClaimSetResourceClaims csrc
			INNER JOIN dbo.ClaimSets cs
				ON csrc.ClaimSet_ClaimSetId = cs.ClaimSetId
		WHERE   cs.ClaimSetName = 'District Hosted SIS Vendor'
			AND csrc.ResourceClaim_ResourceClaimId = school_claim_id;
	END IF;

END $$;
