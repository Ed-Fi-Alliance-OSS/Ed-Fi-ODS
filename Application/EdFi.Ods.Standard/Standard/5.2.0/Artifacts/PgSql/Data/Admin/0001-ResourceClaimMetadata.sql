begin transaction;

/* --------------------------------- */
/*      Applications and Actions     */
/* --------------------------------- */
do $$
begin
    IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Create' AND ActionUri = 'http://ed-fi.org/odsapi/actions/create') THEN
        INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Create' , 'http://ed-fi.org/odsapi/actions/create'); 
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Read' AND ActionUri = 'http://ed-fi.org/odsapi/actions/read') THEN
        INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Read' , 'http://ed-fi.org/odsapi/actions/read');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Update' AND ActionUri = 'http://ed-fi.org/odsapi/actions/update') THEN
        INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Update' , 'http://ed-fi.org/odsapi/actions/update');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Delete' AND ActionUri = 'http://ed-fi.org/odsapi/actions/delete') THEN
        INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Delete' , 'http://ed-fi.org/odsapi/actions/delete');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'ReadChanges' AND ActionUri = 'http://ed-fi.org/odsapi/actions/readChanges') THEN
        INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('ReadChanges' , 'http://ed-fi.org/odsapi/actions/readChanges');
    END IF;

end $$;

/* --------------------------------- */
/*      Authorization Strategies     */
/* --------------------------------- */
do $$

begin


    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('No Further Authorization Required', 'NoFurtherAuthorizationRequired');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with Education Organizations and People', 'RelationshipsWithEdOrgsAndPeople');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with Education Organizations only', 'RelationshipsWithEdOrgsOnly');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'NamespaceBased') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Namespace Based', 'NamespaceBased');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithPeopleOnly') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with People only', 'RelationshipsWithPeopleOnly');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnly') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with Students only', 'RelationshipsWithStudentsOnly');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with Students only (through StudentEducationOrganizationResponsibilityAssociation)', 'RelationshipsWithStudentsOnlyThroughResponsibility');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'OwnershipBased') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Ownership Based', 'OwnershipBased');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes') THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes');
    END IF;

    IF NOT EXISTS (SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyIncludingDeletes') THEN
    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
    VALUES ('Relationships With Students Only Including Deletes', 'RelationshipsWithStudentsOnlyIncludingDeletes');
    END IF;

end $$;

/* --------------------------------- */
/*           Claimsets               */
/* --------------------------------- */
do $$

begin


    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='SIS Vendor') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, IsEdfiPreset)
        VALUES ('SIS Vendor', 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Ed-Fi Sandbox') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, IsEdfiPreset)
        VALUES ('Ed-Fi Sandbox', 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Roster Vendor') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, IsEdfiPreset)
        VALUES ('Roster Vendor', 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Assessment Vendor') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, IsEdfiPreset)
        VALUES ('Assessment Vendor', 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Assessment Read') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, IsEdfiPreset)
        VALUES ('Assessment Read', 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Bootstrap Descriptors and EdOrgs') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName,  ForApplicationUseOnly, IsEdfiPreset)
        VALUES ('Bootstrap Descriptors and EdOrgs',  'TRUE', 'TRUE');
    END IF;
    
    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Ownership Based Test') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName,  ForApplicationUseOnly, IsEdfiPreset)
        VALUES ('Ownership Based Test',  'TRUE', 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='District Hosted SIS Vendor') THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, IsEdfiPreset)
        VALUES ('District Hosted SIS Vendor', 'TRUE');
    END IF;


end $$;

/* --------------------------------- */
/*     Parent resource claims        */
/* --------------------------------- */
do $$

begin


    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/edFiTypes') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        values ('types', 'http://ed-fi.org/ods/identity/claims/domains/edFiTypes', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/systemDescriptors') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/managedDescriptors') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('managedDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationOrganizations') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('educationOrganizations', 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/people') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('people', 'http://ed-fi.org/ods/identity/claims/domains/people', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('relationshipBasedData', 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assessmentMetadata', 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/services/identity') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        values ('identity', 'http://ed-fi.org/ods/identity/claims/services/identity', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationStandards') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('educationStandards', 'http://ed-fi.org/ods/identity/claims/domains/educationStandards', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/primaryRelationships') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('primaryRelationships', 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', null);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/surveyDomain') THEN
        insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('surveyDomain', 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', null);
    END IF;

end $$;

commit;
