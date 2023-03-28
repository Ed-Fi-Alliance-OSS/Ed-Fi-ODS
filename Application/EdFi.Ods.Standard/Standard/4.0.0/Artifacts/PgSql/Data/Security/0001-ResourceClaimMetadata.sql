begin transaction;

/* --------------------------------- */
/*      Applications and Actions     */
/* --------------------------------- */
do $$
begin
    IF NOT EXISTS(SELECT 1 FROM dbo.Applications WHERE ApplicationName ='Ed-Fi ODS API') THEN
        INSERT INTO dbo.Applications (ApplicationName) VALUES ('Ed-Fi ODS API');
    END IF;

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
    DECLARE application_id INT;
begin
    SELECT Applicationid INTO application_Id FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('No Further Authorization Required', 'NoFurtherAuthorizationRequired', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Education Organizations and People', 'RelationshipsWithEdOrgsAndPeople', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Education Organizations only', 'RelationshipsWithEdOrgsOnly', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'NamespaceBased' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Namespace Based', 'NamespaceBased', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithPeopleOnly' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with People only', 'RelationshipsWithPeopleOnly', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnly' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Students only', 'RelationshipsWithStudentsOnly', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Students only (through StudentEducationOrganizationResponsibilityAssociation)', 'RelationshipsWithStudentsOnlyThroughResponsibility', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'OwnershipBased' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Ownership Based', 'OwnershipBased', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes', application_Id);
    END IF;

end $$;

/* --------------------------------- */
/*           Claimsets               */
/* --------------------------------- */
do $$
    declare application_id int;
begin
    SELECT Applicationid INTO application_Id FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='SIS Vendor' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, IsEdfiPreset)
        VALUES ('SIS Vendor', application_Id, 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Ed-Fi Sandbox' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, IsEdfiPreset)
        VALUES ('Ed-Fi Sandbox', application_Id, 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Roster Vendor' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, IsEdfiPreset)
        VALUES ('Roster Vendor', application_Id, 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Assessment Vendor' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, IsEdfiPreset)
        VALUES ('Assessment Vendor', application_Id, 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Assessment Read' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, IsEdfiPreset)
        VALUES ('Assessment Read', application_Id, 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Bootstrap Descriptors and EdOrgs' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, ForApplicationUseOnly, IsEdfiPreset)
        VALUES ('Bootstrap Descriptors and EdOrgs', application_Id, 'TRUE', 'TRUE');
    END IF;
    
    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Ownership Based Test' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, ForApplicationUseOnly, IsEdfiPreset)
        VALUES ('Ownership Based Test', application_Id, 'TRUE', 'TRUE');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='District Hosted SIS Vendor' AND Application_ApplicationId = application_Id) THEN
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId, IsEdfiPreset)
        VALUES ('District Hosted SIS Vendor', application_Id, 'TRUE');
    END IF;


end $$;

/* --------------------------------- */
/*     Parent resource claims        */
/* --------------------------------- */
do $$
    declare application_id int;
begin
    SELECT Applicationid INTO application_Id FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/edFiTypes' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('types', 'types', 'http://ed-fi.org/ods/identity/claims/domains/edFiTypes', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/systemDescriptors' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('systemDescriptors', 'systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/managedDescriptors' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('managedDescriptors', 'managedDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationOrganizations' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('educationOrganizations', 'educationOrganizations', 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/people' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('people', 'people', 'http://ed-fi.org/ods/identity/claims/domains/people', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('relationshipBasedData', 'relationshipBasedData', 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('assessmentMetadata', 'assessmentMetadata', 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/identity' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('identity', 'identity', 'http://ed-fi.org/ods/identity/claims/domains/identity', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationStandards' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('educationStandards', 'educationStandards', 'http://ed-fi.org/ods/identity/claims/domains/educationStandards', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/primaryRelationships' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('primaryRelationships', 'primaryRelationships', 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', null, application_id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/surveyDomain' AND Application_ApplicationId = application_Id) THEN
        insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        values ('surveyDomain', 'surveyDomain', 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', null, application_id);
    END IF;

end $$;

commit;
