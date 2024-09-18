;

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
/*      Authorization Strategies     */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'NoFurtherAuthorizationRequired')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('No Further Authorization Required', 'NoFurtherAuthorizationRequired');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithEdOrgsAndPeople')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Education Organizations and People', 'RelationshipsWithEdOrgsAndPeople');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithEdOrgsOnly')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Education Organizations only', 'RelationshipsWithEdOrgsOnly');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'NamespaceBased')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Namespace Based', 'NamespaceBased');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithPeopleOnly')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with People only', 'RelationshipsWithPeopleOnly');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithStudentsOnly')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Students only', 'RelationshipsWithStudentsOnly');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithStudentsOnlyThroughResponsibility')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Students only (through StudentEducationOrganizationResponsibilityAssociation)', 'RelationshipsWithStudentsOnlyThroughResponsibility');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'OwnershipBased')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Ownership Based', 'OwnershipBased');
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes');
END

/* ==================================================================================================================================== */

/* --------------------------------- */
/*           Claimsets               */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'SIS Vendor')
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [IsEdfiPreset])
    VALUES ('SIS Vendor', 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Ed-Fi Sandbox')
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [IsEdfiPreset])
    VALUES ('Ed-Fi Sandbox', 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Roster Vendor')
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [IsEdfiPreset])
    VALUES ('Roster Vendor', 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Vendor')
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [IsEdfiPreset])
    VALUES ('Assessment Vendor', 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Read')
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [IsEdfiPreset])
    VALUES ('Assessment Read', 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Bootstrap Descriptors and EdOrgs')
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [ForApplicationUseOnly], [IsEdfiPreset])
    VALUES ('Bootstrap Descriptors and EdOrgs', 1, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] ='Ownership Based Test' )
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [ForApplicationUseOnly], [IsEdfiPreset])
    VALUES ('Ownership Based Test', 1, 1);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] ='District Hosted SIS Vendor' )
BEGIN
    INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [IsEdfiPreset])
    VALUES ('District Hosted SIS Vendor', 1);
END

/* ==================================================================================================================================== */

/* --------------------------------- */
/*     Parent resource claims        */
/* --------------------------------- */

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/edFiTypes')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'types', N'http://ed-fi.org/ods/identity/claims/domains/edFiTypes', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'systemDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'managedDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizations', N'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/people')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'people', N'http://ed-fi.org/ods/identity/claims/domains/people', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'relationshipBasedData', N'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentMetadata', N'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/services/identity')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'identity', N'http://ed-fi.org/ods/identity/claims/services/identity', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/educationStandards')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationStandards', N'http://ed-fi.org/ods/identity/claims/domains/educationStandards', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'primaryRelationships', N'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', NULL);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain')
BEGIN
    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyDomain', N'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', NULL);
END