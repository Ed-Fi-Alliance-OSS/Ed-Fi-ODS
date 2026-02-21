-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Note: This step undoes the parent resource claim assignment that resulted in people being placed under EducationOrganizations.
-- This was previously (inadvertently) performed in 1010-TPDM-ResourceClaims.sql, starting at line 2044.

-- Renamed from 1040-TPDM-Ensure-people-claim-has-no-parent-resource-claim.sql to shorten file name.

IF EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/people' AND ParentResourceClaimId IS NOT NULL)
BEGIN
    PRINT 'Moving ''people'' resource claim to top of the hierarchy...'

    UPDATE  dbo.ResourceClaims
    SET     ParentResourceClaimId = NULL
    WHERE   ResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/people')
END
