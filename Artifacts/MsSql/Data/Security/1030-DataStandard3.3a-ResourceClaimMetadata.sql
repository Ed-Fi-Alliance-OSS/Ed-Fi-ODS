    -- SPDX-License-Identifier: Apache-2.0
    -- Licensed to the Ed-Fi Alliance under one or more agreements.
    -- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
    -- See the LICENSE and NOTICES files in the project root for more information.

    DECLARE @applicationId INT;
    DECLARE @systemDescriptorsResourceClaimId INT;
    DECLARE @relationshipBasedDataResourceClaimId INT;
    DECLARE @noFurtherAuthRequiredAuthorizationStrategyId INT;
    DECLARE @assessmentMetadataResourceClaimId INT;

    SELECT @applicationId = (SELECT applicationid FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API');
    SELECT @systemDescriptorsResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = @applicationId);
    SELECT @relationshipBasedDataResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'relationshipBasedData' AND Application_ApplicationId = @applicationId);
    SELECT @assessmentMetadataResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'assessmentMetadata' AND Application_ApplicationId = @applicationId);
    SELECT @noFurtherAuthRequiredAuthorizationStrategyId= (SELECT AuthorizationStrategyId FROM dbo.AuthorizationStrategies WHERE DisplayName='No Further Authorization Required');
    

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

    --Apply  No Further Authorization Required on this OrganizationDepartment resource
    INSERT INTO  dbo.ClaimSetResourceClaimActions( ActionId , ClaimSetId , ResourceClaimId , ValidationRuleSetNameOverride )
    SELECT ac.ActionId, cs.claimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
    (SELECT ActionId  FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
   CROSS APPLY
    (SELECT claimSetId  FROM dbo.ClaimSets
    WHERE ClaimSetName IN ('SIS Vendor','Ed-Fi Sandbox','District Hosted SIS Vendor')) AS cs
    WHERE ResourceName = 'organizationDepartment';

	INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
		([AuthorizationStrategyId]
		,[ClaimSetResourceClaimActionId])
	SELECT @noFurtherAuthRequiredAuthorizationStrategyId, crc.ClaimSetResourceClaimActionId
	FROM [dbo].[ClaimSetResourceClaimActions] crc
	INNER JOIN [dbo].[ClaimSets] cs ON
		crc.ClaimSetId = cs.ClaimSetId
	INNER JOIN [dbo].[Actions] a ON
		crc.ActionId=a.Actionid and 
	    a.ActionName IN ('Create','Read','Update','Delete')
	INNER JOIN [dbo].[ResourceClaims] r ON 
	crc.ResourceClaimId = r.ResourceClaimId
	WHERE cs.ClaimSetName IN ('SIS Vendor','Ed-Fi Sandbox','District Hosted SIS Vendor') 
		AND r.ResourceName IN  ('organizationDepartment');
