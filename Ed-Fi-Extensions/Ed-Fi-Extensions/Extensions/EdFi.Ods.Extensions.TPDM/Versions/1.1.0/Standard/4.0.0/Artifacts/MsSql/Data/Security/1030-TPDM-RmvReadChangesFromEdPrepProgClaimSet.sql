-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Remove ReadChanges action from all the 'Education Preparation Program' permissions

-- Renamed from 1030-TPDM-Remove-ReadChanges-from-EdPrepProg-Claim-Set.sql to shorten file name.

DECLARE @claimSetId INT, @actionId INT

IF EXISTS (SELECT 1 FROM dbo.Actions WHERE ActionName = 'ReadChanges') AND EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = 'Education Preparation Program')
BEGIN
    SELECT @actionId = ActionId FROM dbo.Actions WHERE ActionName = 'ReadChanges'
    SELECT @claimSetId = ClaimSetId FROM dbo.ClaimSets WHERE ClaimSetName = 'Education Preparation Program'

    IF EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = @actionId AND ClaimSetId = @claimSetId)
    BEGIN
        DELETE FROM dbo.ClaimSetResourceClaimActions
        WHERE ActionId = @actionId AND ClaimSetId = @claimSetId
    END
END
