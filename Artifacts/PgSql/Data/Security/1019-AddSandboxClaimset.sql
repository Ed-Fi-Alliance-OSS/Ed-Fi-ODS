-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
    declare application_id int;
	declare claim_set_id int;
	declare authorization_strategy_id int;
begin
    select ApplicationId into application_id from dbo.Applications where ApplicationName = 'Ed-Fi ODS API';
	
	if not exists (select ClaimsetId from dbo.ClaimSets where ClaimSetName = 'Ed-Fi Sandbox' and  Application_ApplicationId = application_id)
	then
		insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    	values ('Ed-Fi Sandbox', application_id);
		
		/* EdFi Sandbox Claims */
		select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Ed-Fi Sandbox';

		insert into dbo.ClaimSetResourceClaims
			(Action_ActionId
			,ClaimSet_ClaimSetId
			,ResourceClaim_ResourceClaimId
			,AuthorizationStrategyOverride_AuthorizationStrategyId
			,ValidationRuleSetNameOverride)
		select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int), cast(null as int)
		from dbo.ResourceClaims
		inner join lateral
			(select ActionId
			from dbo.Actions
			where ActionName IN ('Read')) as ac on true
		where ResourceName IN ('types', 'identity')
		union
		select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int), cast(null as int)
		from dbo.ResourceClaims
		inner join lateral
			(select ActionId
			from dbo.Actions
			where ActionName IN ('Create', 'Update')) as ac on true
		where ResourceName IN ('identity')
		union
		select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int), cast(null as int)
		from dbo.ResourceClaims
		inner join lateral
			(select ActionId
			from dbo.Actions
			where ActionName IN ('Create','Read','Update','Delete')) as ac on true
		where ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
			'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
			'educationContent');

		/* EdFi Sandbox Claims with Overrides */
		select AuthorizationStrategyId INTO authorization_strategy_id
		from dbo.AuthorizationStrategies
		where AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

		insert into dbo.ClaimSetResourceClaims
			(Action_ActionId
			,ClaimSet_ClaimSetId
			,ResourceClaim_ResourceClaimId
			,AuthorizationStrategyOverride_AuthorizationStrategyId
			,ValidationRuleSetNameOverride)
		select ac.ActionId, claim_set_id, ResourceClaimId, authorization_strategy_id, cast (null as int)
		from dbo.ResourceClaims
		inner join lateral
			(select ActionId
			from dbo.Actions
			where ActionName IN ('Create','Read','Update','Delete')) as ac on true
		where ResourceName IN ('communityProviderLicense');
	end if;
end $$;