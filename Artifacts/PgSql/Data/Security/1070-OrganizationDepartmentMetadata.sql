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
		WHERE   csrc.ResourceClaimId = organization_department_claim_id
			AND cs.ClaimSetName IN ('SIS Vendor', 'Ed-Fi Sandbox', 'District Hosted SIS Vendor')
			AND strat.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'
	);
	
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
		WHERE   csrc.ResourceClaimId = organization_department_claim_id
			AND cs.ClaimSetName IN ('SIS Vendor', 'Ed-Fi Sandbox', 'District Hosted SIS Vendor')
			AND strat.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'
	);

	-- Set default authorization strategy for OrganizationDepartment to relationship-based
	SELECT AuthorizationStrategyId INTO relationships_authorization_strategy_id
	FROM dbo.AuthorizationStrategies
	WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

	IF NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActions WHERE ResourceClaimId = organization_department_claim_id)
	THEN
		RAISE NOTICE 'Assigning default metadata for CRUD operations on OrganizationDepartment to the relationship-based authorization strategy.';

		INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
		SELECT  organization_department_claim_id, ActionId
		FROM    dbo.Actions
		WHERE   ActionName IN ('Create', 'Read', 'Update', 'Delete');
		
		INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
		SELECT rca.ResourceClaimActionId, relationships_authorization_strategy_id
		FROM dbo.ResourceClaimActions rca
		INNER JOIN dbo.Actions a
			ON rca.ActionId = a.ActionId
		WHERE rca.ResourceClaimId = organization_department_claim_id AND a.ActionName IN ('Create', 'Read', 'Update', 'Delete');
	END IF;

	-- Move OrganizationDepartment under EducationOrganizations
	UPDATE  dbo.ResourceClaims
	SET     ParentResourceClaimId = education_organizations_claim_id
	WHERE   ResourceClaimId = organization_department_claim_id;

	SELECT  ResourceClaimId INTO school_claim_id
	FROM    dbo.ResourceClaims rc
	WHERE   rc.ClaimName = 'http://ed-fi.org/ods/identity/claims/school';

	-- Assign same permissions to School overrides for District Hosted SIS Vendor
	IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions csrc INNER JOIN dbo.ClaimSets cs ON csrc.ClaimSetId = cs.ClaimSetId WHERE cs.ClaimSetName = 'District Hosted SIS Vendor' AND csrc.ResourceClaimId = school_claim_id)
	THEN
		RAISE NOTICE 'Copying School overrides to OrganizationDepartment for District Hosted Vendor claim set.';

		INSERT INTO dbo.ClaimSetResourceClaimActions(ClaimSetId, ResourceClaimId, ActionId)
		SELECT  csrc.ClaimSetId, organization_department_claim_id, csrc.ActionId
		FROM    dbo.ClaimSetResourceClaimActions csrc
		INNER JOIN dbo.ClaimSets cs
			ON csrc.ClaimSetId = cs.ClaimSetId
		WHERE   cs.ClaimSetName = 'District Hosted SIS Vendor'
			AND csrc.ResourceClaimId = school_claim_id;
			
		INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
		SELECT csrc.ClaimSetResourceClaimActionId, csrcaaso.AuthorizationStrategyId
		FROM dbo.ClaimSetResourceClaimActions csrc
		INNER JOIN dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides csrcaaso
			ON csrc.ClaimSetResourceClaimActionId = csrcaaso.ClaimSetResourceClaimActionId
		INNER JOIN dbo.ClaimSets cs
			ON csrc.ClaimSetId = cs.ClaimSetId
		WHERE cs.ClaimSetName = 'District Hosted SIS Vendor'
			AND csrc.ResourceClaimId = @schoolClaimId;
	END IF;

END $$;
