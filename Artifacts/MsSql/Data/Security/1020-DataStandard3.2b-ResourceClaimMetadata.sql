-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @ClaimSetId INT;
DECLARE @AuthorizationStrategyId INT;
DECLARE @applicationId INT;
DECLARE @systemDescriptorsResourceClaimId INT;

SELECT @applicationId = (SELECT applicationid FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API');
SELECT @systemDescriptorsResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = @applicationId);

/* new descriptors */
IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'gradePointAverageTypeDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
	INSERT dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
	VALUES (N'gradePointAverageTypeDescriptor', N'gradePointAverageTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);
END

/* New claimset Bootstrap Descriptors and EdOrgs */
IF NOT EXISTS (SELECT ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = 'Bootstrap Descriptors and EdOrgs' and Application_ApplicationId = @applicationId)
BEGIN
	INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId) VALUES ('Bootstrap Descriptors and EdOrgs', @applicationId);
		
	SELECT @ClaimSetId = (SELECT ClaimSetId FROM  dbo.ClaimSets  WHERE  ClaimSetName  = 'Bootstrap Descriptors and EdOrgs');
	SELECT @AuthorizationStrategyId = (SELECT AuthorizationStrategyId FROM  dbo.AuthorizationStrategies  WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

	INSERT INTO  dbo.ClaimSetResourceClaimActions 
		( ActionId 
		, ClaimSetId 
		, ResourceClaimId
		, ValidationRuleSetNameOverride )
	SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
	FROM  dbo.ResourceClaims 
	CROSS APPLY
		(SELECT ActionId
		FROM  dbo.Actions 
		WHERE ActionName IN ('Create')) AS ac
	WHERE ResourceName IN (
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

	INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
		([AuthorizationStrategyId]
		,[ClaimSetResourceClaimActionId])
	SELECT @AuthorizationStrategyId, crc.ClaimSetResourceClaimActionId
	FROM [dbo].[ClaimSetResourceClaimActions] crc
	INNER JOIN [dbo].[Actions] a ON
		crc.ActionId=a.Actionid and 
	    a.ActionName IN ('Create')
	INNER JOIN [dbo].[ResourceClaims] r ON 
	crc.ResourceClaimId = r.ResourceClaimId
	WHERE crc.ClaimSetId = @ClaimSetId 
		AND r.ResourceName IN  (
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
END

