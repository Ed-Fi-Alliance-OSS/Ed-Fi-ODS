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

DECLARE @relationshipBasedDataResourceClaimId INT;

SELECT @relationshipBasedDataResourceClaimId = ResourceClaimId
FROM dbo.ResourceClaims rc
WHERE rc.ResourceName = 'relationshipBasedData'

-- Try insert cteProgramServiceDescriptor
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'cteProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cteProgramServiceDescriptor', N'cteProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

END

-- Try insert gradePointAverageWeightSystemDescriptor
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradePointAverageWeightSystemDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradePointAverageWeightSystemDescriptor', N'gradePointAverageWeightSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/gradePointAverageWeightSystemDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

END

-- Try insert participationStatusDescriptor
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'participationStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'participationStatusDescriptor', N'participationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

END

-- Try insert titleIPartAProgramServiceDescriptor
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'titleIPartAProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'titleIPartAProgramServiceDescriptor', N'titleIPartAProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

END

-- Try insert staffDisciplineIncidentAssociation
IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffDisciplineIncidentAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffDisciplineIncidentAssociation', N'staffDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

END
