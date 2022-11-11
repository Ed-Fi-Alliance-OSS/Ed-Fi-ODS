-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @resourceClaimId INT
SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation'

DECLARE @parentResourceClaimId INT
SELECT @parentResourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData'
-- UPDATE relationshipBasedData AS parentresource for studentAssessmentEducationOrganizationAssociation
IF @resourceClaimId IS NOT NULL
BEGIN
    UPDATE dbo.ResourceClaims
    SET ParentResourceClaimId = @parentResourceClaimId
    WHERE ResourceClaimId = @resourceClaimId;;
    END
GO