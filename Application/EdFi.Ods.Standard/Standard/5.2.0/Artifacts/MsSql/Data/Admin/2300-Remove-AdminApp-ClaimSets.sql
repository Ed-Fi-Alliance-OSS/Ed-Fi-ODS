-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Remove Ed-Fi ODS Admin App ClaimSet

-- Find the ClaimSetId for 'Ed-Fi ODS Admin App'
DECLARE @ClaimSetId INT;

SELECT @ClaimSetId = ClaimSetId 
FROM [dbo].[ClaimSets] 
WHERE ClaimSetName = 'Ed-Fi ODS Admin App';

-- Check if ClaimSetId was found
IF @ClaimSetId IS NOT NULL
BEGIN

    -- Delete associated ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    DELETE 
    FROM [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId 
        FROM [dbo].[ClaimSetResourceClaimActions]
        WHERE ClaimSetId = @ClaimSetId
    );

    -- Delete associated ClaimSetResourceClaimActions
    DELETE FROM [dbo].[ClaimSetResourceClaimActions]
    WHERE ClaimSetId = @ClaimSetId;

    -- Delete the ClaimSet itself
    DELETE FROM [dbo].[ClaimSets] 
    WHERE ClaimSetId = @ClaimSetId;

    PRINT 'ClaimSet ''Ed-Fi ODS Admin App'' and associated records deleted successfully.';
END
ELSE
BEGIN
    PRINT 'ClaimSet ''Ed-Fi ODS Admin App'' not found.';
END
