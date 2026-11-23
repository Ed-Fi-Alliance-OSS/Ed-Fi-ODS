-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Adds the resource claims for the descriptors that are new in Data Standard 6.2 as children of the existing
-- systemDescriptors claim. The systemDescriptors claim itself is not modified, so its authorization metadata and
-- claim set assignments are kept as they are.

DO $$
DECLARE
    claim_id INTEGER;
    claim_name VARCHAR(2048);
    parent_resource_claim_id INTEGER;
    existing_parent_resource_claim_id INTEGER;
BEGIN
    SELECT ResourceClaimId INTO parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors';

    IF parent_resource_claim_id IS NULL THEN
        RAISE EXCEPTION 'The systemDescriptors resource claim does not exist.';
    END IF;

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/contactResponsibilityDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/contactResponsibilityDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('contactResponsibilityDescriptor', 'http://ed-fi.org/ods/identity/claims/ed-fi/contactResponsibilityDescriptor', parent_resource_claim_id);

    ELSIF existing_parent_resource_claim_id IS NULL OR parent_resource_claim_id != existing_parent_resource_claim_id THEN
        RAISE NOTICE USING MESSAGE = 'Moving claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to be a child of a different resource claim (from ResourceClaimId=' || COALESCE(existing_parent_resource_claim_id, 0) || ' to ResourceClaimId=' || parent_resource_claim_id || ')';

        UPDATE dbo.ResourceClaims
        SET ParentResourceClaimId = parent_resource_claim_id
        WHERE ResourceClaimId = claim_id;
    END IF;
END $$;
