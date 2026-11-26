-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Adds the resource claim for the descriptor that is new in Data Standard 6.2 as a child of the existing
-- systemDescriptors claim. The systemDescriptors claim itself is not modified, so its authorization metadata and
-- claim set assignments are kept as they are.
--
-- This script is intentionally hand-written instead of generated from the XML like the 2800 script: the generated
-- shape would re-apply the systemDescriptors metadata. The XML next to it describes the same change.

BEGIN
    DECLARE
        @claimId AS INT,
        @claimName AS nvarchar(max),
        @parentResourceClaimId AS INT,
        @existingParentResourceClaimId AS INT,
        @msg AS nvarchar(max)

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM dbo.ResourceClaims
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors'

    IF @parentResourceClaimId IS NULL
        BEGIN
            SET @msg = 'Resource claim does not exist: ''http://ed-fi.org/ods/identity/claims/domains/systemDescriptors''. Run the earlier security metadata scripts first.';
            THROW 50000, @msg, 1
        END

    BEGIN TRANSACTION

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/contactResponsibilityDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/contactResponsibilityDescriptor'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims
    WHERE ClaimName = @claimName

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('contactResponsibilityDescriptor', 'http://ed-fi.org/ods/identity/claims/ed-fi/contactResponsibilityDescriptor', @parentResourceClaimId)
        END

    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR @existingParentResourceClaimId IS NULL
            BEGIN
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (from ResourceClaimId=' + CONVERT(nvarchar, COALESCE(@existingParentResourceClaimId, 0)) + ' to ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    COMMIT TRANSACTION
END
