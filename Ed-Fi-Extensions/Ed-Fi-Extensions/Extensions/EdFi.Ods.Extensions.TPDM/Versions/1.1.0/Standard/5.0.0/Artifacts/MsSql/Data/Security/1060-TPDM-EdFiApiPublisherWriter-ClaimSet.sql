-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Include TPDM Claim in Ed-Fi API Publisher - Writer ClaimSet

BEGIN
    DECLARE
        @claimSetName nvarchar(255),
        @claimSetId INT,
        @resourceClaimId INT,
        @createActionId AS INT,
        @readActionId AS INT,
        @updateActionId AS INT,
        @deleteActionId AS INT

    SET @claimSetName = 'Ed-Fi API Publisher - Writer'

    SELECT @claimSetId = ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = @claimSetName

    SELECT @resourceClaimId = ResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm'

    SELECT @createActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Create';

    SELECT @readActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Read';

    SELECT @updateActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Update';

    SELECT @deleteActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Delete';

-- Ensure ClaimSet exists
    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Ensuring Ed-Fi API Publisher - Writer Claimset exists.'

        INSERT INTO dbo.ClaimSets (ClaimSetName)
        VALUES (@claimSetName)

        SET @claimSetId = SCOPE_IDENTITY()
    END


-- Create Action
    IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @createActionId)
    BEGIN
       INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
       VALUES (@claimSetId, @resourceClaimId, @createActionId)
    END

-- Read Action
    IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readActionId)
    BEGIN
       INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
       VALUES (@claimSetId, @resourceClaimId, @readActionId)
    END

-- Update Action
    IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @updateActionId)
    BEGIN
       INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
       VALUES (@claimSetId, @resourceClaimId, @updateActionId)
    END

-- Delete Action
    IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @deleteActionId)
    BEGIN
       INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
       VALUES (@claimSetId, @resourceClaimId, @deleteActionId)
    END

END
