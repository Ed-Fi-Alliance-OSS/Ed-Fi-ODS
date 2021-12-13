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

DELETE csrcaaso 
FROM [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides] csrcaaso
INNER JOIN [dbo].[ClaimSetResourceClaimActions] csrc ON csrcaaso.ClaimSetResourceClaimActionId = csrc.ClaimSetResourceClaimActionId
WHERE csrc.[ClaimSetId] = @edFiOdsAdminAppClaimSetId

DELETE FROM [dbo].[ClaimSetResourceClaimActions]
WHERE [ClaimSetId] = @edFiOdsAdminAppClaimSetId

PRINT 'Creating Temporary Records.'
INSERT INTO @resourceNames VALUES ('educationOrganizations'),('systemDescriptors'),('managedDescriptors')
INSERT INTO @resourceClaimIds SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName IN (SELECT ResourceName FROM @resourceNames)

SELECT @authorizationStrategyId = AuthorizationStrategyId
FROM   dbo.AuthorizationStrategies
WHERE  AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

DECLARE @actionId int
DECLARE @claimSetId int

SELECT @claimSetId = ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = @claimSetName

PRINT 'Configuring Claims for Ed-Fi ODS Admin App Claimset...'
IF NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSetResourceClaimActions csraa,dbo.Actions a, @resourceClaimIds rc
				  WHERE csraa.ActionId = a.ActionId AND ClaimSetId = @claimSetId AND csraa.ResourceClaimId = rc.ResourceClaimId)
BEGIN				  
	INSERT INTO dbo.ClaimSetResourceClaimActions
		(ActionId, ClaimSetId, ResourceClaimId)
	SELECT ActionId, @claimSetId, ResourceClaimId  FROM dbo.Actions a, @resourceClaimIds rc
	WHERE NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSetResourceClaimActions
				  WHERE ActionId = a.ActionId AND ClaimSetId = @claimSetId AND ResourceClaimId = rc.ResourceClaimId)

	INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
		([AuthorizationStrategyId]
		,[ClaimSetResourceClaimActionId])
	SELECT @authorizationStrategyId, ClaimSetResourceClaimActionId
	FROM [dbo].[ClaimSetResourceClaimActions] csrc
	INNER JOIN [dbo].[ResourceClaims] r 
		ON csrc.ResourceClaimId = r.ResourceClaimId AND csrc.ClaimSetId = @claimSetId
	WHERE r.ResourceName IN  ('educationOrganizations','systemDescriptors','managedDescriptors')
END 

SELECT @actionId = ActionId FROM dbo.Actions WHERE ActionName = 'Read'
SELECT @ResourceClaimId = ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'types'

INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId, ClaimSetId, ResourceClaimId)
	VALUES (@actionId, @claimSetId, @ResourceClaimId)

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([AuthorizationStrategyId]
    ,[ClaimSetResourceClaimActionId])
SELECT @authorizationStrategyId, csrc.ClaimSetResourceClaimActionId
FROM [dbo].[ClaimSetResourceClaimActions] csrc
INNER JOIN [dbo].[ResourceClaims] r ON 
	csrc.ResourceClaimId = r.ResourceClaimId
INNER JOIN [dbo].[Actions] a ON
	a.actionId =csrc.ActionId
	AND a.ActionName in ('Read')
WHERE r.ResourceName IN  ('types') AND csrc.ActionId = @actionId AND csrc.ClaimSetId = @claimSetId;

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

DELETE FROM [dbo].[ClaimSetResourceClaimActions]
WHERE [ClaimSetId] = @abConnectClaimSetId

PRINT 'Creating Temporary Records.'
INSERT INTO @resourceNames VALUES ('gradeLevelDescriptor'),('academicSubjectDescriptor'),('publicationStatusDescriptor'),('educationStandards')
INSERT INTO @resourceClaimIds SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName IN (SELECT ResourceName FROM @resourceNames)

DECLARE @claimSetId int

SELECT @claimSetId = ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = @claimSetName

PRINT 'Configuring Claims for AB Connect Claimset...'
INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId, ClaimSetId, ResourceClaimId)
SELECT ActionId, @claimSetId, ResourceClaimId FROM dbo.Actions a, @resourceClaimIds rc
WHERE NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSetResourceClaimActions
				  WHERE ActionId = a.ActionId AND ClaimSetId = @claimSetId AND ResourceClaimId = rc.ResourceClaimId)
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

UPDATE rcaas SET AuthorizationStrategyId = @authorizationStrategyId
FROM dbo.ResourceClaimActionAuthorizationStrategies rcaas
INNER JOIN dbo.ResourceClaimActions rca
	ON rcaas.ResourceClaimActionId = rca.ResourceClaimActionId
WHERE  ActionId = @actionId AND ResourceClaimId = @resourceClaimId

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

IF EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ResourceClaimId = @performanceLevelDescriptorClaimId AND ClaimSetId = @claimSetId)
BEGIN

	DELETE FROM dbo.ClaimSetResourceClaimActions WHERE ResourceClaimId = @performanceLevelDescriptorClaimId AND ClaimSetId = @claimSetId

END


INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId, ClaimSetId, ResourceClaimId)
SELECT ActionId, @claimSetId, @performanceLevelDescriptorClaimId FROM dbo.Actions a
WHERE a.ActionName in ('Read','Create') AND NOT EXISTS (SELECT 1
                  FROM dbo.ClaimSetResourceClaimActions
				  WHERE ActionId = a.ActionId AND ClaimSetId = @claimSetId AND ResourceClaimId = @performanceLevelDescriptorClaimId)
GO
----------------------------------------------------------------------------------------------------
