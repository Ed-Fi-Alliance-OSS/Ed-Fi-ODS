-- Create Ed-Fi ODS Admin App ClaimSet

DECLARE @applicationId int
DECLARE @applicationName  nvarchar(max)
DECLARE @claimSetName  nvarchar(255)
SET @claimSetName = 'Ed-Fi ODS Admin App'
SET @applicationName = 'Ed-Fi ODS API'

SELECT @applicationId = ApplicationId FROM  Applications WHERE ApplicationName = @applicationName

PRINT 'Ensuring Ed-Fi ODS Admin App Claimset exists.'
INSERT INTO ClaimSets (ClaimSetName, Application_ApplicationId)
SELECT DISTINCT @claimSetName, @applicationId FROM ClaimSets
WHERE NOT EXISTS (SELECT 1
                  FROM ClaimSets
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
PRINT 'Creating temorary records.'
INSERT INTO @resourceNames VALUES ('educationOrganizations'),('systemDescriptors'),('managedDescriptors')
INSERT INTO @resourceClaimIds SELECT ResourceClaimId FROM ResourceClaims WHERE ResourceName IN (SELECT ResourceName FROM @resourceNames)

SELECT @authorizationStrategyId = AuthorizationStrategyId
FROM   AuthorizationStrategies
WHERE  AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

DECLARE @actionId int
DECLARE @claimSetId int

SELECT @actionId = ActionId FROM Actions WHERE ActionName = @actionName
SELECT @claimSetId = ClaimSetId FROM ClaimSets WHERE ClaimSetName = @claimSetName

PRINT 'Configuring Claims for Ed-Fi ODS Admin App Claimset...'
INSERT INTO ClaimSetResourceClaims
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, AuthorizationStrategyOverride_AuthorizationStrategyId)
SELECT ActionId, @claimSetId, ResourceClaimId , @authorizationStrategyId FROM Actions a, @resourceClaimIds rc
WHERE NOT EXISTS (SELECT *
                  FROM ClaimSetResourceClaims
				  WHERE Action_ActionId = a.ActionId AND ClaimSet_ClaimSetId = @claimSetId AND ResourceClaimId = rc.ResourceClaimId)

SELECT @actionId = ActionId FROM Actions WHERE ActionName = 'Read'
SELECT @ResourceClaimId = ResourceClaimId FROM ResourceClaims WHERE ResourceName = 'types'
INSERT INTO ClaimSetResourceClaims
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, AuthorizationStrategyOverride_AuthorizationStrategyId)
	vALUES (@actionId, @claimSetId, @ResourceClaimId , @authorizationStrategyId)

GO

-- Create AB Connect ClaimSet

DECLARE @applicationId int
DECLARE @applicationName  nvarchar(max)
DECLARE @claimSetName  nvarchar(255)
SET @claimSetName = 'AB Connect'
SET @applicationName = 'Ed-Fi ODS API'

SELECT @applicationId = ApplicationId FROM  Applications WHERE ApplicationName = @applicationName

PRINT 'Ensuring AB Connect Claimset exists.'
INSERT INTO ClaimSets (ClaimSetName, Application_ApplicationId)
SELECT DISTINCT @claimSetName, @applicationId FROM ClaimSets
WHERE NOT EXISTS (SELECT *
                  FROM ClaimSets
				  WHERE ClaimSetName = @claimSetName AND Application_ApplicationId = @applicationId )
GO

-- Configure AB Connect ClaimSet

DECLARE @actionName nvarchar(255)
DECLARE @claimSetName nvarchar(255)
DECLARE @resourceNames TABLE (ResourceName nvarchar(255))
DECLARE @resourceClaimIds TABLE (ResourceClaimId int)

SET @claimSetName = 'AB Connect'
PRINT 'Creating temorary records.'
INSERT INTO @resourceNames VALUES ('gradeLevelDescriptor'),('academicSubjectDescriptor'),('publicationStatusDescriptor'),('educationStandards')
INSERT INTO @resourceClaimIds SELECT ResourceClaimId FROM ResourceClaims WHERE ResourceName IN (SELECT ResourceName FROM @resourceNames)

DECLARE @actionId int
DECLARE @claimSetId int

SELECT @actionId = ActionId FROM Actions WHERE ActionName = @actionName
SELECT @claimSetId = ClaimSetId FROM ClaimSets WHERE ClaimSetName = @claimSetName

PRINT 'Configuring Claims for AB Connect Claimset...'
INSERT INTO ClaimSetResourceClaims
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId)
SELECT ActionId, @claimSetId, ResourceClaimId FROM Actions a, @resourceClaimIds rc
WHERE NOT EXISTS (SELECT *
                  FROM ClaimSetResourceClaims
				  WHERE Action_ActionId = a.ActionId AND ClaimSet_ClaimSetId = @claimSetId AND ResourceClaimId = rc.ResourceClaimId)
GO

-- Set educationStandards to not require further authorization for READ 

DECLARE @authorizationStrategyId INT
DECLARE @resourceClaimId INT
DECLARE @actionId INT

SELECT @authorizationStrategyId = AuthorizationStrategyId
FROM   AuthorizationStrategies
WHERE  AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

SELECT @resourceClaimId = ResourceClaimId
FROM   ResourceClaims
WHERE  ResourceName = 'educationStandards'

SELECT @ActionId = ActionId FROM Actions WHERE ActionName = 'Read'

PRINT 'Updating educationStandards authorization strategy for READ.'

UPDATE ResourceClaimAuthorizationMetadatas SET AuthorizationStrategy_AuthorizationStrategyId = @authorizationStrategyId
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

INSERT INTO ClaimSetResourceClaims
    (Action_ActionId, ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId)
SELECT ActionId, @claimSetId, @performanceLevelDescriptorClaimId FROM Actions a
WHERE a.ActionName in ('Read','Create') AND NOT EXISTS (SELECT *
                  FROM ClaimSetResourceClaims
				  WHERE Action_ActionId = a.ActionId AND ClaimSet_ClaimSetId = @claimSetId AND ClaimsetResourceClaims.ResourceClaim_ResourceClaimId = @performanceLevelDescriptorClaimId)
GO
----------------------------------------------------------------------------------------------------
