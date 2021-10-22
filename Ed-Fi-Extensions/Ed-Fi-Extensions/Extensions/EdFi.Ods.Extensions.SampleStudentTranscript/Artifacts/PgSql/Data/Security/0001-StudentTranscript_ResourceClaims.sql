-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
declare appId int;
declare systemDescriptorsResourceClaimId int;
declare authStrategyId int;
declare postSecondaryOrganizationResourceClaimId int;

begin

SELECT ApplicationId into appId
FROM dbo.Applications
WHERE ApplicationName = 'Ed-Fi ODS API';

SELECT ResourceClaimId into systemDescriptorsResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'systemDescriptors';

INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'institutionControlDescriptor'
    , 'institutionControlDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample-student-transcript/institutionControlDescriptor'
    , systemDescriptorsResourceClaimId
    , appId
    );
	
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'institutionLevelDescriptor'
    , 'institutionLevelDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample-student-transcript/institutionLevelDescriptor'
    , systemDescriptorsResourceClaimId
    , appId
    );
 
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'specialEducationGraduationStatusDescriptor'
    , 'specialEducationGraduationStatusDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample-student-transcript/specialEducationGraduationStatusDescriptor'
    , systemDescriptorsResourceClaimId
    , appId
    );
 
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'submissionCertificationDescriptor'
    , 'submissionCertificationDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample-student-transcript/submissionCertificationDescriptor'
    , systemDescriptorsResourceClaimId
    , appId
    );

INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'postSecondaryOrganization'
    , 'postSecondaryOrganization'
    , 'http://ed-fi.org/ods/identity/claims/sample-student-transcript/postSecondaryOrganization'
    , null
    , appId
    );

  
--Setup Authorization Strategy

SELECT AuthorizationStrategyId INTO authStrategyId 
FROM dbo.AuthorizationStrategies 
WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

SELECT ResourceClaimId INTO postSecondaryOrganizationResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'postSecondaryOrganization';
  
INSERT INTO dbo.ResourceClaimAuthorizationMetadatas (
    Action_ActionId, 
	AuthorizationStrategy_AuthorizationStrategyId,
	ResourceClaim_ResourceClaimId,
	ValidationRuleSetName )
SELECT ActionId
    ,authStrategyId
    ,postSecondaryOrganizationResourceClaimId
    ,null
FROM dbo.Actions;

--Add to SIS Vendor and Ed-Fi Sandbox claim sets
INSERT INTO dbo.ClaimSetResourceClaims (
    Action_ActionId, 
	ClaimSet_ClaimSetId, 
	ResourceClaim_ResourceClaimId, 
	AuthorizationStrategyOverride_AuthorizationStrategyId, 
	ValidationRulesetNameOverride)
SELECT ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,null
    ,null
FROM dbo.Actions a
    ,dbo.ClaimSets c
    ,dbo.ResourceClaims r
WHERE r.ResourceName = 'postSecondaryOrganization'
    AND (
        c.ClaimSetName = 'SIS Vendor'
        OR c.ClaimSetName = 'Ed-Fi Sandbox'
        );
		
end $$