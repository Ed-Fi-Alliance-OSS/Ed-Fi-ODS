-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Adds the resource claims for the descriptors that are new in Data Standard 6.2 as children of the existing
-- systemDescriptors claim. The systemDescriptors claim itself is not modified, so its authorization metadata and
-- claim set assignments are kept as they are.

BEGIN
    DECLARE
        @claimId AS INT,
        @claimName AS nvarchar(max),
        @parentResourceClaimId AS INT,
        @existingParentResourceClaimId AS INT

    BEGIN TRANSACTION

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM dbo.ResourceClaims
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors'

    IF @parentResourceClaimId IS NULL
        BEGIN
            ROLLBACK TRANSACTION
            RAISERROR('The systemDescriptors resource claim does not exist.', 16, 1)
            RETURN
        END

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
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    COMMIT TRANSACTION
END
