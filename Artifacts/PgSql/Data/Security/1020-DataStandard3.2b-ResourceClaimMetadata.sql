-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
    declare application_id int;
	declare claim_set_id int;
	declare authorization_strategy_id int;
	declare systemDescriptorsResourceClaim_id int;
begin
    select ApplicationId into application_id from dbo.Applications where ApplicationName = 'Ed-Fi ODS API';
	select ResourceClaimId into systemDescriptorsResourceClaim_id FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = application_id;

	if not exists (select ResourceClaimId from dbo.ResourceClaims where ResourceName = 'gradePointAverageTypeDescriptor' and Application_ApplicationId = application_id)
	then
		insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
		values ('gradePointAverageTypeDescriptor', 'gradePointAverageTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor', systemDescriptorsResourceClaim_id, application_id);
	end if;

	if not exists (select ClaimsetId from dbo.ClaimSets where ClaimSetName = 'Bootstrap Descriptors and EdOrgs' and  Application_ApplicationId = application_id)
	then
		insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    	values ('Bootstrap Descriptors and EdOrgs', application_id);
		
		/* Bootstrap Descriptors and EdOrgs Claims */

		select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Bootstrap Descriptors and EdOrgs';
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
			where ActionName IN ('Create')) as ac on true
		where ResourceName IN (
			'systemDescriptors',
			'managedDescriptors',
			'educationOrganizations',
			-- from Interchange-Standards.xml
			'learningObjective',
			'learningStandard',
			'learningStandardEquivalenceAssociation',
			-- from Interchange-EducationOrganization.xml
			'accountabilityRating',
			'classPeriod',
			'communityOrganization',
			'communityProvider',
			'communityProviderLicense',
			'course',
			'educationOrganizationNetwork',
			'educationOrganizationNetworkAssociation',
			'educationOrganizationPeerAssociation',
			'educationServiceCenter',
			'feederSchoolAssociation',
			'localEducationAgency',
			'location',
			'postSecondaryInstitution',
			'program',
			'school',
			'stateEducationAgency'
		);
	end if;
end $$;

