-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @ApplicationId INT
DECLARE @SystemDescriptorsId INT
  
SELECT @ApplicationId = ApplicationId
FROM [dbo].[Applications]
WHERE ApplicationName = 'Ed-Fi ODS API'
 
SELECT @SystemDescriptorsId = resourceclaimid
FROM   [dbo].[resourceclaims]
WHERE  displayname = 'systemDescriptors'
 
INSERT INTO [dbo].[resourceclaims]
            ([displayname],
             [resourcename],
             [claimname],
             [parentresourceclaimid],
             [application_applicationid])
VALUES      ( 'institutionControlDescriptor',
              'institutionControlDescriptor',
'http://ed-fi.org/ods/identity/claims/sample-student-transcript/institutionControlDescriptor',
@SystemDescriptorsId,
@ApplicationId )
 
INSERT INTO [dbo].[resourceclaims]
            ([displayname],
             [resourcename],
             [claimname],
             [parentresourceclaimid],
             [application_applicationid])
VALUES      ( 'institutionLevelDescriptor',
              'institutionLevelDescriptor',
              'http://ed-fi.org/ods/identity/claims/sample-student-transcript/institutionLevelDescriptor',
              @SystemDescriptorsId,
              @ApplicationId )
 
INSERT INTO [dbo].[resourceclaims]
            ([displayname],
             [resourcename],
             [claimname],
             [parentresourceclaimid],
             [application_applicationid])
VALUES      ( 'specialEducationGraduationStatusDescriptor',
              'specialEducationGraduationStatusDescriptor',
'http://ed-fi.org/ods/identity/claims/sample-student-transcript/specialEducationGraduationStatusDescriptor'
              ,
@SystemDescriptorsId,
@ApplicationId )
 
INSERT INTO [dbo].[resourceclaims]
            ([displayname],
             [resourcename],
             [claimname],
             [parentresourceclaimid],
             [application_applicationid])
VALUES      ( 'submissionCertificationDescriptor',
              'submissionCertificationDescriptor',
'http://ed-fi.org/ods/identity/claims/sample-student-transcript/submissionCertificationDescriptor',
@SystemDescriptorsId,
@ApplicationId )
  
INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'postSecondaryOrganization'
    ,'postSecondaryOrganization'
    ,'http://ed-fi.org/ods/identity/claims/sample-student-transcript/postSecondaryOrganization'
    ,NULL
    ,@ApplicationId
    )
  
--Setup Authorization Strategy
  
DECLARE @AuthorizationStrategyId INT
DECLARE @ResourceClaimId INT
  
SELECT @AuthorizationStrategyId = AuthorizationStrategyId
FROM AuthorizationStrategies
WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'
  
SELECT @ResourceClaimId = resourceclaimid
FROM ResourceClaims
WHERE ResourceName = 'postSecondaryOrganization'
  
INSERT INTO ResourceClaimAuthorizationMetadatas
SELECT ActionId
    ,@AuthorizationStrategyId
    ,@ResourceClaimId
    ,NULL
FROM Actions a
WHERE NOT EXISTS (
        SELECT 1
        FROM ResourceClaimAuthorizationMetadatas
        WHERE Action_ActionId = a.ActionId
            AND AuthorizationStrategy_AuthorizationStrategyId = @AuthorizationStrategyId
            AND ResourceClaim_ResourceClaimId = @ResourceClaimId
        )
  
--Add to SIS Vendor and Ed-Fi Sandbox claim sets
INSERT INTO [dbo].[ClaimSetResourceClaims]
SELECT [ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,NULL
    ,NULL
FROM Actions a
    ,ClaimSets c
    ,ResourceClaims r
WHERE r.ResourceName = 'postSecondaryOrganization'
    AND (
        c.ClaimSetName = 'SIS Vendor'
        OR c.ClaimSetName = 'Ed-Fi Sandbox'
        )
    AND NOT EXISTS (
        SELECT 1
        FROM ClaimSetResourceClaims
        WHERE Action_ActionId = a.ActionId
            AND ClaimSet_ClaimSetId = c.ClaimSetId
                 AND ResourceClaim_ResourceClaimId = r.ResourceClaimId
        )