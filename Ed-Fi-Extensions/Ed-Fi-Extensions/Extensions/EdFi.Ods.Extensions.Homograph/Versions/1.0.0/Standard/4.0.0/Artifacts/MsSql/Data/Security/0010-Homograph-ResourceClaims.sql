-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


DECLARE @systemDescriptorsResourceClaimId INT
SELECT @systemDescriptorsResourceClaimId = ResourceClaimId
FROM [dbo].[ResourceClaims]
WHERE ResourceName = 'systemDescriptors'

DECLARE @relationshipBasedDataResourceClaimId INT
SELECT @relationshipBasedDataResourceClaimId = ResourceClaimId
FROM [dbo].[ResourceClaims]
WHERE ResourceName = 'relationshipBasedData'

DECLARE @educationOrganizationsResourceClaimId INT
SELECT @educationOrganizationsResourceClaimId = ResourceClaimId
FROM [dbo].[ResourceClaims]
WHERE ResourceName = 'educationOrganizations'

INSERT INTO [dbo].[ResourceClaims]
    ([ResourceName], [ClaimName], [ParentResourceClaimId])
VALUES
    ('name',  'http://ed-fi.org/ods/identity/claims/homograph/name', @educationOrganizationsResourceClaimId)

INSERT INTO [dbo].[ResourceClaims]
    ([ResourceName], [ClaimName], [ParentResourceClaimId])
VALUES
    ('school', 'http://ed-fi.org/ods/identity/claims/homograph/school', @educationOrganizationsResourceClaimId)

INSERT INTO [dbo].[ResourceClaims]
    ([ResourceName], [ClaimName], [ParentResourceClaimId])
VALUES
    ('parent', 'http://ed-fi.org/ods/identity/claims/homograph/parent', @educationOrganizationsResourceClaimId)

INSERT INTO [dbo].[ResourceClaims]
    ([ResourceName], [ClaimName], [ParentResourceClaimId])
VALUES
    ('student', 'http://ed-fi.org/ods/identity/claims/homograph/student', @educationOrganizationsResourceClaimId)

INSERT INTO [dbo].[ResourceClaims]
    ([ResourceName], [ClaimName], [ParentResourceClaimId])
VALUES
    ('staff', 'http://ed-fi.org/ods/identity/claims/homograph/staff', @educationOrganizationsResourceClaimId)

INSERT INTO [dbo].[ResourceClaims]
    ([ResourceName], [ClaimName], [ParentResourceClaimId])
VALUES
    ('schoolYearType', 'http://ed-fi.org/ods/identity/claims/homograph/schoolYearType', @educationOrganizationsResourceClaimId)

INSERT INTO [dbo].[ResourceClaims]
    ([ResourceName], [ClaimName], [ParentResourceClaimId])
VALUES
    ('studentSchoolAssociation','http://ed-fi.org/ods/identity/claims/homograph/studentSchoolAssociation', @educationOrganizationsResourceClaimId)
