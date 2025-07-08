-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
    managed_descriptors_resource_claim_id INT;
BEGIN
    SELECT ResourceClaimId INTO managed_descriptors_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors';

    UPDATE dbo.ResourceClaims SET ParentResourceClaimId = managed_descriptors_resource_claim_id WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor';

END $$;