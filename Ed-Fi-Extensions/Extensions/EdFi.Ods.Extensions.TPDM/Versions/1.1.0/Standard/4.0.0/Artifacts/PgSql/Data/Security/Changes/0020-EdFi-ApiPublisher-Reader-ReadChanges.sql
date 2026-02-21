-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Include TPDM Claim in Ed-Fi API Publisher - Reader ClaimSet

DO $$
DECLARE
    claim_set_name VARCHAR(255);
    claim_set_id INTEGER;
    resource_claim_id INTEGER;
    readchanges_action_id INTEGER;
BEGIN

    claim_set_name := 'Ed-Fi API Publisher - Reader';

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets WHERE ClaimSetName = claim_set_name;

    SELECT ResourceClaimId INTO resource_claim_id
    FROM dbo.ResourceClaims WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm';

    SELECT ActionId INTO readchanges_action_id
    FROM dbo.Actions WHERE ActionName = 'ReadChanges';

-- Ensure ClaimSet exists
    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Ensuring Ed-Fi API Publisher - Reader Claimset exists.';

        INSERT INTO dbo.ClaimSets (ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

-- Read Action
    IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = readchanges_action_id) THEN
        INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
        VALUES (claim_set_id, resource_claim_id, readchanges_action_id);
    END IF;

END $$;
