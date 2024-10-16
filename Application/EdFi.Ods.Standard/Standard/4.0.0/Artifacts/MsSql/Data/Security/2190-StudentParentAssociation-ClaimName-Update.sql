
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  
BEGIN
    DECLARE 
        @claimId AS INT,
        @claimName AS nvarchar(max),
        @parentResourceClaimId AS INT,
        @existingParentResourceClaimId AS INT

    BEGIN TRANSACTION


    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships'

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/primaryRelationships
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentParentAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/studentParentAssociation'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    IF @parentResourceClaimId IS NOT NULL
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId 
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'
                PRINT 'Updating  parent resource claim to primaryRelationships'
                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    COMMIT TRANSACTION
END
