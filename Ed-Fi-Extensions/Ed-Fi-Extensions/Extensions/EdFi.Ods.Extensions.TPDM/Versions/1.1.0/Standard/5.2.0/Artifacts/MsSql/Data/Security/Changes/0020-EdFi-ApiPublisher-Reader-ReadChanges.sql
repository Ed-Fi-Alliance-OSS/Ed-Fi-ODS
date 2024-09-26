-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Include TPDM Claim in Ed-Fi API Publisher - Reader ClaimSet

BEGIN
    DECLARE
        @claimSetName nvarchar(255),
        @claimSetId INT,
        @resourceClaimId INT,
        @readChangesActionId AS INT

    SET @claimSetName = 'Ed-Fi API Publisher - Reader'

    SELECT @claimSetId = ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = @claimSetName

    SELECT @resourceClaimId = ResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm'

    SELECT @readChangesActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'ReadChanges';

-- Ensure ClaimSet exists
    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Ensuring Ed-Fi API Publisher - Reader Claimset exists.'

        INSERT INTO dbo.ClaimSets (ClaimSetName)
        VALUES (@claimSetName)

        SET @claimSetId = SCOPE_IDENTITY()
    END

-- Read Action
    IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readChangesActionId)
    BEGIN
       INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
       VALUES (@claimSetId, @resourceClaimId, @readChangesActionId)
    END

END
