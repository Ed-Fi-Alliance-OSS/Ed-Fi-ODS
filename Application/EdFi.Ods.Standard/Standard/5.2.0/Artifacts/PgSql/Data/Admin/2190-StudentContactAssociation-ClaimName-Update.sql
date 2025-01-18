-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO
$$
DECLARE
    claim_id INT;
    claim_name VARCHAR(2048);
    parent_resource_claim_id INT;
    existing_parent_resource_claim_id INT;
BEGIN
    -- Begin transaction
    BEGIN

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships';

    SELECT resourceclaimid INTO parent_resource_claim_id
    FROM dbo.resourceclaims
    WHERE claimname = claim_name;

    -- Processing children of 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships'
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentContactAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentContactAssociation';
    claim_id := NULL;

    SELECT resourceclaimid, parentresourceclaimid INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.resourceclaims
    WHERE claimname = claim_name;

    IF parent_resource_claim_id IS NOT NULL THEN
        IF parent_resource_claim_id != existing_parent_resource_claim_id THEN
            RAISE NOTICE 'Repointing claim % (ResourceClaimId=%) to new parent (ResourceClaimId=%)',
                claim_name, claim_id, parent_resource_claim_id;

            RAISE NOTICE 'Updating parent resource claim to primaryRelationships';

            UPDATE dbo.resourceclaims
            SET parentresourceclaimid = parent_resource_claim_id
            WHERE resourceclaimid = claim_id;
        END IF;
    END IF;

    -- Commit transaction
    COMMIT;

    END;
END
$$;
