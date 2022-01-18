-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @applicationId INT;
SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] 
WHERE [ApplicationName] = 'Ed-Fi ODS API');

IF (@applicationId IS NULL) RETURN

DECLARE @assessmentVendorClaimSetId as INT
SELECT @assessmentVendorClaimSetId = ClaimsetId
FROM dbo.ClaimSets c
WHERE c.ClaimSetName = 'Assessment Vendor'

--Actions--
DECLARE @create as INT
SELECT @create = ActionId
FROM dbo.Actions a
WHERE a.ActionName = 'Create'

DECLARE @read as INT
SELECT @read = ActionId
FROM dbo.Actions a
WHERE a.ActionName = 'Read'

DECLARE  @update as INT
SELECT  @update = ActionId
FROM dbo.Actions a
WHERE a.ActionName = 'Update'

DECLARE @delete as INT
SELECT @delete = ActionId
FROM dbo.Actions a
WHERE a.ActionName = 'Delete'

--ResourceClaims--
DECLARE @learningStandard as INT
SELECT @learningStandard = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'LearningStandard'

IF (@assessmentVendorClaimSetId IS NOT NULL)
 BEGIN
    DELETE FROM [dbo].[ClaimSetResourceClaimActions]
    WHERE [ClaimSetId] = @assessmentVendorClaimSetId AND [ResourceClaimId] = @learningStandard
 END

ElSE IF (@assessmentVendorClaimSetId IS NULL )
 BEGIN
    --Create a new ClaimSet--
    INSERT INTO dbo.ClaimSets (ClaimSetName,Application_ApplicationId) values ('Assessment Vendor',@applicationId)

    SELECT @assessmentVendorClaimSetId = ClaimsetId
    FROM dbo.ClaimSets c
    WHERE c.ClaimSetName = 'Assessment Vendor'
 END
 
--learningStandardDescriptor CRUD--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningStandard, @create)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningStandard, @read)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningStandard, @update)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningStandard, @delete)

