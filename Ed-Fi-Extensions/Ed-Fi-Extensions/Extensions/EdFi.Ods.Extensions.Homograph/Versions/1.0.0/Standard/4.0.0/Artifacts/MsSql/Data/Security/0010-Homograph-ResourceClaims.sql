-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @applicationId INT
SELECT @applicationId = ApplicationId
FROM [dbo].[Applications]
WHERE ApplicationName = 'Ed-Fi ODS API'

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
    ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES
    ('name', 'name', 'http://ed-fi.org/ods/identity/claims/homograph/name', @educationOrganizationsResourceClaimId, @applicationId)

INSERT INTO [dbo].[ResourceClaims]
    ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES
    ('school', 'school', 'http://ed-fi.org/ods/identity/claims/homograph/school', @educationOrganizationsResourceClaimId, @applicationId)

INSERT INTO [dbo].[ResourceClaims]
    ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES
    ('parent', 'parent', 'http://ed-fi.org/ods/identity/claims/homograph/parent', @educationOrganizationsResourceClaimId, @applicationId)

INSERT INTO [dbo].[ResourceClaims]
    ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES
    ('student', 'student', 'http://ed-fi.org/ods/identity/claims/homograph/student', @educationOrganizationsResourceClaimId, @applicationId)

INSERT INTO [dbo].[ResourceClaims]
    ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES
    ('staff', 'staff', 'http://ed-fi.org/ods/identity/claims/homograph/staff', @educationOrganizationsResourceClaimId, @applicationId)

INSERT INTO [dbo].[ResourceClaims]
    ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES
    ('schoolYearType', 'schoolYearType', 'http://ed-fi.org/ods/identity/claims/homograph/schoolYearType', @educationOrganizationsResourceClaimId, @applicationId)

INSERT INTO [dbo].[ResourceClaims]
    ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES
    ('studentSchoolAssociation', 'studentSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/homograph/studentSchoolAssociation', @educationOrganizationsResourceClaimId, @applicationId)
