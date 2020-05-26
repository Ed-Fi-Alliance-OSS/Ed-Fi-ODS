-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @applicationId INT;
SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications]
WHERE [ApplicationName] = 'Ed-Fi ODS API');

IF (@applicationId IS NULL) RETURN

DECLARE @systemDescriptorsResourceClaimId INT;

SELECT @systemDescriptorsResourceClaimId = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'systemDescriptors'

DECLARE @educationStandardsResourceClaimId INT;

SELECT @educationStandardsResourceClaimId = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'educationStandards'

-- Try insert learningStandardEquivalenceStrengthDescriptor
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandardEquivalenceStrengthDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardEquivalenceStrengthDescriptor', N'learningStandardEquivalenceStrengthDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

END

-- Try insert learningStandardScopeDescriptor
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandardScopeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardScopeDescriptor', N'learningStandardScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

END

-- Try insert platformTypeDescriptor
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'platformTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'platformTypeDescriptor', N'platformTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

END

-- Try insert learningStandardEquivalenceAssociation
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandardEquivalenceAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardEquivalenceAssociation', N'learningStandardEquivalenceAssociation', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation', @educationStandardsResourceClaimId, @applicationId);

END
