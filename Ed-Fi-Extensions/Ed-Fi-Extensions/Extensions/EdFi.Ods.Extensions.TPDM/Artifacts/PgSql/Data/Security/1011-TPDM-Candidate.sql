-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$

DECLARE authorization_strategy_id INT;
DECLARE resource_claim_id INT;

BEGIN

    SELECT AuthorizationStrategyId
    INTO authorization_strategy_id
    FROM dbo.AuthorizationStrategies
    WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    SELECT ResourceClaimId
    INTO resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/tpdm/candidate';

    -- Create CRUD action claims for @resourceClaimName

    INSERT INTO dbo.ResourceClaimActions (
     ActionId
    ,ResourceClaimId
    ,ValidationRuleSetName
    )
    SELECT a.ActionId ,ResourceClaimId ,NULL
    FROM dbo.ResourceClaims RC
    CROSS JOIN dbo.Actions a
    WHERE ResourceClaimId = resource_claim_id;

    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    SELECT RCA.ResourceClaimActionId,authorization_strategy_id FROM dbo.ResourceClaimActionS RCA 
    INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
    INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
    WHERE RCA.ResourceClaimId = resource_claim_id;

END $$;