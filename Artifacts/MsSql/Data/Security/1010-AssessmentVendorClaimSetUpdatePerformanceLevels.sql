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
DECLARE @academicSubjectDescriptor as INT
SELECT @academicSubjectDescriptor = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'academicSubjectDescriptor'

DECLARE @assessmentMetadata as INT
SELECT @assessmentMetadata = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'assessmentMetadata'

DECLARE @learningObjective as INT
SELECT @learningObjective = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'learningObjective'

DECLARE @learningStandard as INT
SELECT @learningStandard = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'learningStandard'

DECLARE @managedDescriptors as INT
SELECT @managedDescriptors = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'managedDescriptors'

DECLARE @student as INT
SELECT @student = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'student'

DECLARE @systemDescriptors as INT
SELECT @systemDescriptors = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'systemDescriptors'

DECLARE @types as INT
SELECT @types = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'types'

IF (@assessmentVendorClaimSetId IS NOT NULL)
 BEGIN
    DELETE FROM [dbo].[ClaimSetResourceClaimActions]
    WHERE [ClaimSetId] = @assessmentVendorClaimSetId
 END

ElSE IF (@assessmentVendorClaimSetId IS NULL )
 BEGIN
    --Create a new ClaimSet--
    INSERT INTO dbo.ClaimSets (ClaimSetName,Application_ApplicationId) values ('Assessment Vendor',@applicationId)

    SELECT @assessmentVendorClaimSetId = ClaimsetId
    FROM dbo.ClaimSets c
    WHERE c.ClaimSetName = 'Assessment Vendor'
 END
 
--academicSubjectDescriptor CRUD--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @academicSubjectDescriptor, @create)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @academicSubjectDescriptor, @read)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @academicSubjectDescriptor, @update)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @academicSubjectDescriptor, @delete)

--assessmentMetadata CRUD--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @assessmentMetadata, @create)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @assessmentMetadata, @read)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @assessmentMetadata, @update)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @assessmentMetadata, @delete)

--learningObjective CRUD--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningObjective, @create)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningObjective, @read)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningObjective, @update)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningObjective, @delete)

--learningStandards R--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @learningStandard, @read)

--managedDescriptors CRUD--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @managedDescriptors, @create)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @managedDescriptors, @read)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @managedDescriptors, @update)
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @managedDescriptors, @delete)

--student R-- 
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @student, @read)

--systemDescriptors R--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @systemDescriptors, @read)

--types R--
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@assessmentVendorClaimSetId, @types, @read)