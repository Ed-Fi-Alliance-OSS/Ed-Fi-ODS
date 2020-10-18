-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @AuthorizationStrategyId INT;

DECLARE @applicationId INT
SELECT @applicationId = ApplicationId
FROM [dbo].[Applications]
WHERE ApplicationName = 'Ed-Fi ODS API'

DECLARE @systemDescriptorsResourceClaimId INT
SELECT @systemDescriptorsResourceClaimId = ResourceClaimId
FROM [dbo].[ResourceClaims]
WHERE ResourceName = 'systemDescriptors'

DECLARE @relationshipBasedDataResourceClaimId INT
SELECT @relationshipBasedDataResourceClaimId = ResourceClaimId
FROM [dbo].[ResourceClaims]
WHERE ResourceName = 'relationshipBasedData'

DECLARE @educationOrganizationsResourceClaimId INT
SELECT @educationOrganizationsResourceClaimId = ResourceClaimId
FROM [dbo].[ResourceClaims]
WHERE ResourceName = 'educationOrganizations'

INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'artMediumDescriptor'
    , 'artMediumDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample/artMediumDescriptor'
    , @systemDescriptorsResourceClaimId
    , @applicationId
    )

INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'favoriteBookCategoryDescriptor'
    , 'favoriteBookCategoryDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample/favoriteBookCategoryDescriptor'
    , @systemDescriptorsResourceClaimId
    , @applicationId
    )

INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'membershipTypeDescriptor'
    , 'membershipTypeDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample/membershipTypeDescriptor'
    , @systemDescriptorsResourceClaimId
    , @applicationId
    )

INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'bus'
    , 'bus'
    , 'http://ed-fi.org/ods/identity/claims/sample/bus'
    , @educationOrganizationsResourceClaimId
    , @applicationId
    )

INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'busRoute'
    , 'busRoute'
    , 'http://ed-fi.org/ods/identity/claims/sample/busRoute'
    , @educationOrganizationsResourceClaimId
    , @applicationId
    )

INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'studentArtProgramAssociation'
    , 'studentArtProgramAssociation'
    , 'http://ed-fi.org/ods/identity/claims/sample/studentArtProgramAssociation'
    , @relationshipBasedDataResourceClaimId
    , @applicationId
    )

INSERT INTO [dbo].[ResourceClaims] (
    [DisplayName]
    ,[ResourceName]
    ,[ClaimName]
    ,[ParentResourceClaimId]
    ,[Application_ApplicationId]
    )
VALUES (
    'studentGraduationPlanAssociation'
    , 'studentGraduationPlanAssociation'
    , 'http://ed-fi.org/ods/identity/claims/sample/studentGraduationPlanAssociation'
    , @relationshipBasedDataResourceClaimId
    , @applicationId
    )
	
SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');	

--- These Resources need explicit metadata ---
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
    WHERE ActionName IN ('Create', 'Read', 'Update', 'Delete')) AS ac
WHERE ResourceName IN ('studentArtProgramAssociation'
, 'studentGraduationPlanAssociation');
