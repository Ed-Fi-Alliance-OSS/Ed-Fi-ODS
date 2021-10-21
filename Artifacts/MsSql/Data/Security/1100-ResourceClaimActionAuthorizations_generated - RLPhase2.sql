DECLARE @ClaimSetId INT;
DECLARE @AuthorizationStrategyId INT;
DECLARE @applicationId INT;

DECLARE @peopleResourceClaimId INT;
DECLARE @relationshipBasedDataResourceClaimId INT;
DECLARE @assessmentMetadataResourceClaimId INT;
DECLARE @educationStandardsResourceClaimId INT;
DECLARE @primaryRelationshipsResourceClaimId INT;
DECLARE @educationOrganizationsResourceClaimId INT;
DECLARE @typesResourceClaimId INT;
DECLARE @systemDescriptorsResourceClaimId INT;
DECLARE @managedDescriptorsResourceClaimId INT;
DECLARE @identityResourceClaimId INT;
DECLARE @surveyDomainResourceClaimId INT;

/* --------------------------------- */

/* --------------------------------- */
/*           Applications            */
/* --------------------------------- */

INSERT INTO [dbo].[Applications] ([ApplicationName])
VALUES ('Ed-Fi ODS API');

SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = 'Ed-Fi ODS API');

/* --------------------------------- */

/* --------------------------------- */
/*      Authorization Strategies     */
/* --------------------------------- */

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Ownership Based', 'OwnershipBased', @applicationId);

/* --------------------------------- */

/* --------------------------------- */
/*     ClaimSetResourceClaimActionAuthorizations        */
/* --------------------------------- */

/* SIS Vendors Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'SIS Vendor');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizations]
    ([Action_ActionId]
    ,[ClaimSet_ClaimSetId]
    ,[ResourceClaim_ResourceClaimId]   
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
   (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId,  null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
WHERE ResourceName IN ('people'
    , 'relationshipBasedData'
    , 'assessmentMetadata'
    , 'managedDescriptors'
    , 'primaryRelationships'
    , 'educationStandards'
    , 'educationContent');

/* EdFi Sandbox Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Ed-Fi Sandbox');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizations]
    ([Action_ActionId]
    ,[ClaimSet_ClaimSetId]
    ,[ResourceClaim_ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('types', 'identity')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create', 'Update')) AS ac
WHERE ResourceName IN ('identity')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null  FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
WHERE ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
    'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
    'educationContent', 'surveyDomain');

/* EdFi Sandbox Claims with Overrides */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizations]
    ([Action_ActionId]
    ,[ClaimSet_ClaimSetId]
    ,[ResourceClaim_ResourceClaimId]    
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
WHERE ResourceName IN ('communityProviderLicense');


INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([AuthorizationStrategy_AuthorizationStrategyId]
    ,[ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId])
SELECT @AuthorizationStrategyId, ClaimSetResourceClaimActionAuthorizationId
FROM [dbo].[ClaimSetResourceClaimActionAuthorizations]
INNER JOIN [dbo].[ResourceClaims] ON 
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE ResourceName IN ('communityProviderLicense');



/* Roster Vendor Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Roster Vendor');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizations]
    ([Action_ActionId]
    ,[ClaimSet_ClaimSetId]
    ,[ResourceClaim_ResourceClaimId]    
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'section', 'student', 'staff', 'courseOffering',
    'session', 'classPeriod', 'location', 'course', 'staffSectionAssociation',
    'staffEducationOrganizationAssignmentAssociation', 'studentSectionAssociation', 'studentSchoolAssociation');

/* Assessment Vendor Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Vendor');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizations]
    ([Action_ActionId]
    ,[ClaimSet_ClaimSetId]
    ,[ResourceClaim_ResourceClaimId]    
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
WHERE ResourceName IN ('assessmentMetadata')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('learningObjective', 'learningStandard', 'student');

/* Assessment Read Resource Claims */
SET @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Read');
INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizations]
    ([Action_ActionId]
    ,[ClaimSet_ClaimSetId]
    ,[ResourceClaim_ResourceClaimId]    
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('assessmentMetadata', 'learningObjective', 'learningStandard', 'student');

/* Bootstrap Descriptors and EdOrgs Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Bootstrap Descriptors and EdOrgs');
SELECT @AuthorizationStrategyId = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizations]
    ([Action_ActionId]
    ,[ClaimSet_ClaimSetId]
    ,[ResourceClaim_ResourceClaimId]  
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
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

SELECT @AuthorizationStrategyId = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([AuthorizationStrategy_AuthorizationStrategyId]
    ,[ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId])
SELECT @AuthorizationStrategyId, ClaimSetResourceClaimActionAuthorizationId
FROM [dbo].[ClaimSetResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
action_actionid=Actionid and 
   ActionName IN ('Create')
INNER JOIN [dbo].[ResourceClaims] ON 
ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE ResourceName IN  (
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

/* --------------------------------- */
/* ResourceClaimAuthorizationMeatada */
/* --------------------------------- */

/* NoFurtherAuthorizationRequired */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

INSERT INTO [dbo].[ResourceClaimActionAuthorizations]
    ([Action_ActionId]   
    ,[ResourceClaim_ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person' )
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Update')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )
UNION
SELECT ac.ActionId, ResourceClaimId, null FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Delete')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'people', 'credential', 'person');


SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
	([AuthorizationStrategy_AuthorizationStrategyId],
	[ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId])
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid and 
	ActionName IN ('Read')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE ResourceName IN  ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person' )
UNION
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid and 
	ActionName IN ('Create')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE ResourceName IN  ('educationOrganizations', 'credential', 'people', 'identity', 'person')
UNION
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid and 
	ActionName IN ('UPDATE','DELETE')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE ResourceName IN   ('educationOrganizations', 'identity', 'credential', 'person' )
UNION
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid and 
	ActionName IN ('DELETE')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE ResourceName IN  ('educationOrganizations', 'people', 'credential', 'person');



/* NamespaceBased */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NamespaceBased');

INSERT INTO [dbo].[ResourceClaimActionAuthorizations]
    ([Action_ActionId]    
    ,[ResourceClaim_ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create', 'Update', 'Delete')) AS ac
WHERE ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain');

DECLARE @AuthorizationStrategyId INT;
SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NamespaceBased');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
	([AuthorizationStrategy_AuthorizationStrategyId],
	[ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId])
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid AND 
	   ActionName IN ('Read')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE  ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )
UNION
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid AND 
	ActionName IN ('Create', 'Update', 'Delete')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE  ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain');


/* RelationshipsWithEdOrgsAndPeople */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople');

INSERT INTO [dbo].[ResourceClaimActionAuthorizations]
    ([Action_ActionId]    
    ,[ResourceClaim_ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read', 'Update')) AS ac
WHERE ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('relationshipBasedData')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Delete')) AS ac
WHERE ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
	([AuthorizationStrategy_AuthorizationStrategyId],
	[ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId])
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid AND 
	ActionName IN  ('Read', 'Update')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE  ResourceName IN  ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
UNION
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid AND 
    ActionName IN ('Create')
INNER JOIN [dbo].[ResourceClaims] ON
ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE  ResourceName IN ('relationshipBasedData')
UNION
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid AND 
	ActionName IN ('DELETE')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE  ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships')

/* RelationshipsWithStudentsOnly */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnly');

INSERT INTO [dbo].[ResourceClaimAuthorizationMetadatas]
    ([Action_ActionId]
    ,[AuthorizationStrategy_AuthorizationStrategyId]
    ,[ResourceClaim_ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, @AuthorizationStrategyId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('studentParentAssociation');


INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
	([AuthorizationStrategy_AuthorizationStrategyId],
	[ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId])
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid AND 
	ActionName IN  ('Create')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE  ResourceName IN ('studentParentAssociation')
/* RelationshipsWithEdOrgsOnly */

SET @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly');

INSERT INTO [dbo].[ResourceClaimAuthorizationMetadatas]
    ([Action_ActionId]
    ,[AuthorizationStrategy_AuthorizationStrategyId]
    ,[ResourceClaim_ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, @AuthorizationStrategyId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('primaryRelationships')

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
	([AuthorizationStrategy_AuthorizationStrategyId],
	[ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId])
SELECT @AuthorizationStrategyId,  [ResourceClaimActionAuthorizationId]
FROM [dbo].[ResourceClaimActionAuthorizations]
INNER JOIN [dbo].[Actions] ON
	action_actionid=Actionid AND 
	ActionName IN  ('Create')
INNER JOIN [dbo].[ResourceClaims] ON
	ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE  ResourceName IN ('primaryRelationships')

/* --------------------------------- */

