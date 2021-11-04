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
    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas (
         Action_ActionId
        ,AuthorizationStrategy_AuthorizationStrategyId
        ,ResourceClaim_ResourceClaimId
        ,ValidationRuleSetName
    )
    SELECT
         a.ActionId
        ,authorization_strategy_id
        ,ResourceClaimId
        ,NULL
    FROM dbo.ResourceClaims
    CROSS JOIN dbo.Actions a
    WHERE ResourceClaimId = resource_claim_id;
END $$;