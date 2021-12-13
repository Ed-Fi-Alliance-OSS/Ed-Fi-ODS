-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @claimSetName NVARCHAR(255) = 'District Hosted SIS Vendor';
DECLARE @applicationName NVARCHAR(MAX) = 'Ed-Fi ODS API';


IF EXISTS (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = @applicationName) 
BEGIN
    IF NOT EXISTS (SELECT [ClaimSetName]  FROM [dbo].[ClaimSets]
               WHERE ClaimSetName = @claimSetName)
    BEGIN
        --Create a new ClaimSet
        DECLARE @applicationId INT;
        SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = @applicationName);
        INSERT INTO dbo.ClaimSets (ClaimSetName,Application_ApplicationId) values (@claimSetName, @applicationId)
    
        DECLARE @claimSetId as INT
        SELECT @claimSetId = ClaimsetId
        FROM dbo.ClaimSets c
        WHERE c.ClaimSetName = @claimSetName
      
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
        DECLARE @types as INT
        SELECT @types = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'types'
    
        DECLARE @systemDescriptors as INT
        SELECT @systemDescriptors = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'systemDescriptors'
    
        DECLARE @relationshipBasedData as INT
        SELECT @relationshipBasedData = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'relationshipBasedData'
    
        DECLARE @managedDescriptors as INT
        SELECT @managedDescriptors = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'managedDescriptors'
    
        DECLARE @assessmentMetadata as INT
        SELECT @assessmentMetadata = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'assessmentMetadata'
    
        DECLARE @educationOrganizations as INT
        SELECT @educationOrganizations = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'educationOrganizations'
    
        DECLARE @educationStandards as INT
        SELECT @educationStandards = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'educationStandards'
    
        DECLARE @people as INT
        SELECT @people = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'people'
    
        DECLARE @primaryRelationships as INT
        SELECT @primaryRelationships = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'primaryRelationships'
    
        DECLARE @educationContent as INT
        SELECT @educationContent = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'educationContent'
    
        DECLARE @schoolResourceClaimId as INT
        SELECT @schoolResourceClaimId = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'school'
    
        DECLARE @localEducationAgencyResourceClaimId as INT
        SELECT @localEducationAgencyResourceClaimId = ResourceClaimId
        FROM dbo.ResourceClaims rc
        WHERE rc.ResourceName = 'localEducationAgency'
    
        --Add claims from SIS Vendor ClaimSet
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @types, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @systemDescriptors, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @managedDescriptors, @create)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @managedDescriptors, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @managedDescriptors,  @update)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @managedDescriptors, @delete)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationOrganizations, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @people, @create)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @people, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @people,  @update)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @people, @delete)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @relationshipBasedData, @create)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @relationshipBasedData, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @relationshipBasedData,  @update)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @relationshipBasedData, @delete)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @assessmentMetadata, @create)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @assessmentMetadata, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @assessmentMetadata,  @update)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @assessmentMetadata, @delete)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationStandards, @create)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationStandards, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationStandards,  @update)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationStandards, @delete)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @primaryRelationships, @create)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @primaryRelationships, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @primaryRelationships,  @update)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @primaryRelationships, @delete)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationContent, @create)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationContent, @read)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationContent,  @update)
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (@claimSetId, @educationContent, @delete)
    
        --Add District Hosted SIS Vendor Claims
    
        -- Create Schools
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
        VALUES (@claimSetId, @schoolResourceClaimId, @create)
    
        -- Read Schools
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
        VALUES (@claimSetId, @schoolResourceClaimId, @read)
    
        -- Update Schools
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
        VALUES (@claimSetId, @schoolResourceClaimId,  @update)
    
        -- Delete Schools
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
        VALUES (@claimSetId, @schoolResourceClaimId, @delete)
    
        -- Read localEducationAgency
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
        VALUES (@claimSetId, @localEducationAgencyResourceClaimId, @read)
    
        -- Update localEducationAgency
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
        VALUES (@claimSetId, @localEducationAgencyResourceClaimId,  @update)
    END
END