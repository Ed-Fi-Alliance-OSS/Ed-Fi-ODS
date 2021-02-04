-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @ClaimSetId INT;
DECLARE @AuthorizationStrategyId INT;
DECLARE @applicationId INT;
DECLARE @systemDescriptorsResourceClaimId INT;
DECLARE @relationshipBasedDataResourceClaimId INT;

SELECT @applicationId = (SELECT applicationid FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API');
SELECT @systemDescriptorsResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = @applicationId);
SELECT @relationshipBasedDataResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'relationshipBasedData' AND Application_ApplicationId = @applicationId);

/* new descriptors */
IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'AncestryEthnicOriginDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
	INSERT dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
	VALUES (N'AncestryEthnicOriginDescriptor', N'AncestryEthnicOriginDescriptor', N'http://ed-fi.org/ods/identity/claims/AncestryEthnicOriginDescriptor', @systemDescriptorsResourceClaimId, @applicationId);
END

-- Try insert StudentDisciplineIncidentBehaviorAssociation
IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'StudentDisciplineIncidentBehaviorAssociation' AND Application_ApplicationId = @applicationId))
BEGIN
INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'StudentDisciplineIncidentBehaviorAssociation', N'StudentDisciplineIncidentBehaviorAssociation', N'http://ed-fi.org/ods/identity/claims/StudentDisciplineIncidentBehaviorAssociation', @relationshipBasedDataResourceClaimId, @applicationId);
END

-- Try insert StudentDisciplineIncidentNonOffenderAssociation
IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'StudentDisciplineIncidentNonOffenderAssociation' AND Application_ApplicationId = @applicationId))
BEGIN
INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'StudentDisciplineIncidentNonOffenderAssociation', N'StudentDisciplineIncidentNonOffenderAssociation', N'http://ed-fi.org/ods/identity/claims/StudentDisciplineIncidentNonOffenderAssociation', @relationshipBasedDataResourceClaimId, @applicationId);
END
