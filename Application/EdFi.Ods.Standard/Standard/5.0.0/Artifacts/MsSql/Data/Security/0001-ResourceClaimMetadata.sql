DECLARE @applicationId INT;

/* --------------------------------- */
/*             Actions               */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[Actions] WHERE [ActionName] = 'Create' AND [ActionUri] = 'http://ed-fi.org/odsapi/actions/create')
BEGIN
    INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Create' , 'http://ed-fi.org/odsapi/actions/create');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Actions] WHERE [ActionName] = 'Read' AND [ActionUri] = 'http://ed-fi.org/odsapi/actions/read')
BEGIN
    INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Read' , 'http://ed-fi.org/odsapi/actions/read');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Actions] WHERE [ActionName] = 'Update' AND [ActionUri] = 'http://ed-fi.org/odsapi/actions/update')
BEGIN
    INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Update' , 'http://ed-fi.org/odsapi/actions/update');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Actions] WHERE [ActionName] = 'Delete' AND [ActionUri] = 'http://ed-fi.org/odsapi/actions/delete')
BEGIN
    INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Delete' , 'http://ed-fi.org/odsapi/actions/delete');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Actions] WHERE [ActionName] = 'ReadChanges' AND [ActionUri] = 'http://ed-fi.org/odsapi/actions/readChanges')
BEGIN
    INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('ReadChanges', 'http://ed-fi.org/odsapi/actions/readChanges');
END

/* ==================================================================================================================================== */

/* --------------------------------- */
/*           Applications            */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[Applications] WHERE [ApplicationName] = 'Ed-Fi ODS API')
BEGIN
    INSERT INTO [dbo].[Applications] ([ApplicationName]) VALUES ('Ed-Fi ODS API');
END

SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = 'Ed-Fi ODS API');

/* ==================================================================================================================================== */

/* --------------------------------- */
/*      Authorization Strategies     */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'NoFurtherAuthorizationRequired' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('No Further Authorization Required', 'NoFurtherAuthorizationRequired', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithEdOrgsAndPeople' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with Education Organizations and People', 'RelationshipsWithEdOrgsAndPeople', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithEdOrgsOnly' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with Education Organizations only', 'RelationshipsWithEdOrgsOnly', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'NamespaceBased' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Namespace Based', 'NamespaceBased', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithPeopleOnly' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with People only', 'RelationshipsWithPeopleOnly', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithStudentsOnly' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with Students only', 'RelationshipsWithStudentsOnly', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithStudentsOnlyThroughResponsibility' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with Students only (through StudentEducationOrganizationResponsibilityAssociation)', 'RelationshipsWithStudentsOnlyThroughResponsibility', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'OwnershipBased' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Ownership Based', 'OwnershipBased', @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes', @applicationId);
END

/* ==================================================================================================================================== */

/* --------------------------------- */
/*           Claimsets               */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'SIS Vendor' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [IsEdfiPreset])
    VALUES ('SIS Vendor', @applicationId, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Ed-Fi Sandbox' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [IsEdfiPreset])
    VALUES ('Ed-Fi Sandbox', @applicationId, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Roster Vendor' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [IsEdfiPreset])
    VALUES ('Roster Vendor', @applicationId, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Vendor' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [IsEdfiPreset])
    VALUES ('Assessment Vendor', @applicationId, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Read' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [IsEdfiPreset])
    VALUES ('Assessment Read', @applicationId, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Bootstrap Descriptors and EdOrgs' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [ForApplicationUseOnly], [IsEdfiPreset])
    VALUES ('Bootstrap Descriptors and EdOrgs', @applicationId, 1, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] ='Ownership Based Test' AND Application_ApplicationId = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [ForApplicationUseOnly], [IsEdfiPreset])
    VALUES ('Ownership Based Test', @applicationId, 1, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] ='District Hosted SIS Vendor' AND Application_ApplicationId = @applicationId)
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId], [IsEdfiPreset])
    VALUES ('District Hosted SIS Vendor', @applicationId, 1);
END

/* ==================================================================================================================================== */

/* --------------------------------- */
/*     Parent resource claims        */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/edFiTypes' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'types', N'types', N'http://ed-fi.org/ods/identity/claims/domains/edFiTypes', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'systemDescriptors', N'systemDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'managedDescriptors', N'managedDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'educationOrganizations', N'educationOrganizations', N'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/people' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'people', N'people', N'http://ed-fi.org/ods/identity/claims/domains/people', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'relationshipBasedData', N'relationshipBasedData', N'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'assessmentMetadata', N'assessmentMetadata', N'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/identity' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'identity', N'identity', N'http://ed-fi.org/ods/identity/claims/domains/identity', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/educationStandards' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'educationStandards', N'educationStandards', N'http://ed-fi.org/ods/identity/claims/domains/educationStandards', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'primaryRelationships', N'primaryRelationships', N'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', NULL, @applicationId);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain' AND [Application_ApplicationId] = @applicationId)
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'surveyDomain', N'surveyDomain', N'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', NULL, @applicationId);
END