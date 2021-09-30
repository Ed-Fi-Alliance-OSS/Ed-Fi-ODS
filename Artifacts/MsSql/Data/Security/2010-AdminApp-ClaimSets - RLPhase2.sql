-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Create Ed-Fi ODS Admin App ClaimSet

DECLARE @applicationId int
DECLARE @applicationName  nvarchar(max)
DECLARE @claimSetName  nvarchar(255)
SET @claimSetName = 'Ed-Fi ODS Admin App'
SET @applicationName = 'Ed-Fi ODS API'

SELECT @applicationId = ApplicationId FROM dbo.Applications WHERE ApplicationName = @applicationName

PRINT 'Ensuring Ed-Fi ODS Admin App Claimset exists.'
INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
SELECT DISTINCT @claimSetName, @applicationId FROM dbo.ClaimSets
WHERE NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSets
				  WHERE ClaimSetName = @claimSetName AND Application_ApplicationId = @applicationId )
GO

-- Configure Ed-Fi ODS Admin App ClaimSet

DECLARE @actionName nvarchar(255)
DECLARE @claimSetName nvarchar(255)
DECLARE @resourceNames TABLE (ResourceName nvarchar(255))
DECLARE @resourceClaimIds TABLE (ResourceClaimId int)
DECLARE @authorizationStrategyId INT
DECLARE @ResourceClaimId INT

SET @claimSetName = 'Ed-Fi ODS Admin App'

DECLARE @edFiOdsAdminAppClaimSetId as INT
SELECT @edFiOdsAdminAppClaimSetId = ClaimsetId
FROM dbo.ClaimSets c
WHERE c.ClaimSetName = @claimSetName

DELETE FROM [dbo].[ClaimSetResourceClaimActionAuthorizations]
WHERE [ClaimSet_ClaimSetId] = @edFiOdsAdminAppClaimSetId

PRINT 'Creating Temporary Records.'
INSERT INTO @resourceNames VALUES ('educationOrganizations'),('systemDescriptors'),('managedDescriptors')
INSERT INTO @resourceClaimIds SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName IN (SELECT ResourceName FROM @resourceNames)

SELECT @authorizationStrategyId = AuthorizationStrategyId
FROM   dbo.AuthorizationStrategies
WHERE  AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

DECLARE @actionId int
DECLARE @claimSetId int

SELECT @actionId = ActionId FROM dbo.Actions WHERE ActionName = @actionName
SELECT @claimSetId = ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = @claimSetName

PRINT 'Configuring Claims for Ed-Fi ODS Admin App Claimset...'
IF NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSetResourceClaimActionAuthorizations
				  WHERE Action_ActionId = a.ActionId AND ClaimSet_ClaimSetId = @claimSetId AND ResourceClaimId = rc.ResourceClaimId)
BEGIN				  
INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId)
SELECT ActionId, @claimSetId, ResourceClaimId  FROM dbo.Actions a, @resourceClaimIds rc

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([AuthorizationStrategy_AuthorizationStrategyId]
    ,[ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId])
SELECT @authorizationStrategyId, ClaimSetResourceClaimActionAuthorizationId
FROM [dbo].[ClaimSetResourceClaimActionAuthorizations]
INNER JOIN [dbo].[ResourceClaims] ON 
ResourceClaim_ResourceClaimId = ResourceClaimId
WHERE ResourceName IN  ('educationOrganizations'),('systemDescriptors'),('managedDescriptors');


END 
				  
	

SELECT @actionId = ActionId FROM dbo.Actions WHERE ActionName = 'Read'
SELECT @ResourceClaimId = ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'types'

INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId)
	VALUES (@actionId, @claimSetId, @ResourceClaimId , @authorizationStrategyId)

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([AuthorizationStrategy_AuthorizationStrategyId]
    ,[ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId])
SELECT @authorizationStrategyId, ClaimSetResourceClaimActionAuthorizationId
FROM [dbo].[ClaimSetResourceClaimActionAuthorizations]
INNER JOIN [dbo].[ResourceClaims] ON 
	ResourceClaim_ResourceClaimId = ResourceClaimId
INNER JOIn [dbo].[Action] ON
	actionId =Action_ActionId
	AND ActionName in ('READ')
WHERE ResourceName IN  ('types');


GO

-- Create AB Connect ClaimSet

DECLARE @applicationId int
DECLARE @applicationName  nvarchar(max)
DECLARE @claimSetName  nvarchar(255)
SET @claimSetName = 'AB Connect'
SET @applicationName = 'Ed-Fi ODS API'

SELECT @applicationId = ApplicationId FROM  dbo.Applications WHERE ApplicationName = @applicationName

PRINT 'Ensuring AB Connect Claimset exists.'
INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
SELECT DISTINCT @claimSetName, @applicationId FROM dbo.ClaimSets
WHERE NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSets
				  WHERE ClaimSetName = @claimSetName AND Application_ApplicationId = @applicationId )
GO

-- Configure AB Connect ClaimSet

DECLARE @actionName nvarchar(255)
DECLARE @claimSetName nvarchar(255)
DECLARE @resourceNames TABLE (ResourceName nvarchar(255))
DECLARE @resourceClaimIds TABLE (ResourceClaimId int)

SET @claimSetName = 'AB Connect'

DECLARE @abConnectClaimSetId as INT
SELECT @abConnectClaimSetId = ClaimsetId
FROM dbo.ClaimSets c
WHERE c.ClaimSetName = @claimSetName

DELETE FROM [dbo].[ClaimSetResourceClaimActionAuthorizations]
WHERE [ClaimSet_ClaimSetId] = @abConnectClaimSetId

PRINT 'Creating Temporary Records.'
INSERT INTO @resourceNames VALUES ('gradeLevelDescriptor'),('academicSubjectDescriptor'),('publicationStatusDescriptor'),('educationStandards')
INSERT INTO @resourceClaimIds SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName IN (SELECT ResourceName FROM @resourceNames)

DECLARE @actionId int
DECLARE @claimSetId int

SELECT @actionId = ActionId FROM dbo.Actions WHERE ActionName = @actionName
SELECT @claimSetId = ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = @claimSetName

PRINT 'Configuring Claims for AB Connect Claimset...'
INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId)
SELECT ActionId, @claimSetId, ResourceClaimId FROM dbo.Actions a, @resourceClaimIds rc
WHERE NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSetResourceClaimActionAuthorizations
				  WHERE Action_ActionId = a.ActionId AND ClaimSet_ClaimSetId = @claimSetId AND ResourceClaimId = rc.ResourceClaimId)
GO

-- Set educationStandards to not require further authorization for READ 

DECLARE @authorizationStrategyId INT
DECLARE @resourceClaimId INT
DECLARE @actionId INT

SELECT @authorizationStrategyId = AuthorizationStrategyId
FROM   dbo.AuthorizationStrategies
WHERE  AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

SELECT @resourceClaimId = ResourceClaimId
FROM   dbo.ResourceClaims
WHERE  ResourceName = 'educationStandards'

SELECT @ActionId = ActionId FROM dbo.Actions WHERE ActionName = 'Read'

PRINT 'Updating educationStandards authorization strategy for READ.'

UPDATE dbo.ResourceClaimActionAuthorizationStrategies SET AuthorizationStrategy_AuthorizationStrategyId = @authorizationStrategyId
INNER JOIN dbo.ResourceClaimActionAuthorizations ON
	ResourceClaimActionAuthorizationId =ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId
WHERE  Action_ActionId = @actionId AND ResourceClaim_ResourceClaimId = @resourceClaimId

GO

-- Add performanceLevelDescriptor to the assessment vendor claimset (if not already present)

DECLARE @performanceLevelDescriptorClaimId as INT

SELECT @performanceLevelDescriptorClaimId = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'performanceLevelDescriptor'

DECLARE @claimSetId as INT

SELECT @claimSetId = ClaimsetId
FROM dbo.ClaimSets c
WHERE c.ClaimSetName = 'Assessment Vendor'

PRINT 'Ensuring create and read actions for performanceLevelDescriptor are assigned to Assessment Vendor claimset'

IF EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActionAuthorizations WHERE ResourceClaim_ResourceClaimId = @performanceLevelDescriptorClaimId AND ClaimSet_ClaimSetId = @claimSetId)
BEGIN

	DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizations WHERE ResourceClaim_ResourceClaimId = @performanceLevelDescriptorClaimId AND ClaimSet_ClaimSetId = @claimSetId

END


INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId)
SELECT ActionId, @claimSetId, @performanceLevelDescriptorClaimId FROM dbo.Actions a
WHERE a.ActionName in ('Read','Create') AND NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSetResourceClaimActionAuthorizations
				  WHERE Action_ActionId = a.ActionId AND ClaimSet_ClaimSetId = @claimSetId AND ClaimSetResourceClaimActionAuthorizations.ResourceClaim_ResourceClaimId = @performanceLevelDescriptorClaimId)
GO
----------------------------------------------------------------------------------------------------
