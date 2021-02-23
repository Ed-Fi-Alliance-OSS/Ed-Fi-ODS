    -- SPDX-License-Identifier: Apache-2.0
    -- Licensed to the Ed-Fi Alliance under one or more agreements.
    -- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
    -- See the LICENSE and NOTICES files in the project root for more information.

    DECLARE @applicationId INT;
    DECLARE @systemDescriptorsResourceClaimId INT;
    DECLARE @relationshipBasedDataResourceClaimId INT;
    DECLARE @authorizationStrategyId INT;
    DECLARE @assessmentMetadataResourceClaimId INT;
    DECLARE @claimSetId INT;

    SELECT @applicationId = (SELECT applicationid FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API');
    SELECT @systemDescriptorsResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = @applicationId);
    SELECT @relationshipBasedDataResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'relationshipBasedData' AND Application_ApplicationId = @applicationId);
    SELECT @assessmentMetadataResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'assessmentMetadata' AND Application_ApplicationId = @applicationId);
    SELECT @authorizationStrategyId= (SELECT AuthorizationStrategyId FROM dbo.AuthorizationStrategies WHERE DisplayName='No Further Authorization Required');
    SELECT @claimSetId= (SELECT ClaimSetId  FROM dbo.ClaimSets where ClaimSetName='Bootstrap Descriptors and EdOrgs');

    /* new descriptors */
    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'ancestryEthnicOriginDescriptor' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'ancestryEthnicOriginDescriptor', N'ancestryEthnicOriginDescriptor', N'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor', @systemDescriptorsResourceClaimId, @applicationId);
    END

    -- Try insert StudentDisciplineIncidentBehaviorAssociation
    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'studentDisciplineIncidentBehaviorAssociation' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
        VALUES (N'studentDisciplineIncidentBehaviorAssociation', N'studentDisciplineIncidentBehaviorAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation', @relationshipBasedDataResourceClaimId, @applicationId);
    END

    -- Try insert StudentDisciplineIncidentNonOffenderAssociation
    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'studentDisciplineIncidentNonOffenderAssociation' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
        VALUES (N'studentDisciplineIncidentNonOffenderAssociation', N'studentDisciplineIncidentNonOffenderAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOffenderAssociation', @relationshipBasedDataResourceClaimId, @applicationId);
    END

    -- Try insert AssessmentScoreRangeLearningStandard
    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'assessmentScoreRangeLearningStandard' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
        VALUES (N'assessmentScoreRangeLearningStandard', N'assessmentScoreRangeLearningStandard', N'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard', @assessmentMetadataResourceClaimId, @applicationId);
    END

    -- Try insert OrganizationDepartment
    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'organizationDepartment' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
        VALUES (N'organizationDepartment', N'organizationDepartment', N'http://ed-fi.org/ods/identity/claims/organizationDepartment', @relationshipBasedDataResourceClaimId, @applicationId);
    END

    --Apply  NofurhterauthorizationRequired on this OrganizationDepartment resource
    INSERT INTO  dbo.ClaimSetResourceClaims( Action_ActionId , ClaimSet_ClaimSetId , ResourceClaim_ResourceClaimId , AuthorizationStrategyOverride_AuthorizationStrategyId , ValidationRuleSetNameOverride )
    SELECT ac.ActionId, @claimSetId, ResourceClaimId, @authorizationStrategyId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
    (SELECT ActionId  FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
    WHERE ResourceName = 'organizationDepartment';
