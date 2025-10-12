
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  
DO $$
DECLARE
    claim_id INTEGER;
    claim_name VARCHAR(2048);
    parent_resource_claim_id INTEGER;
    existing_parent_resource_claim_id INTEGER;
    claim_set_id INTEGER;
    claim_set_name VARCHAR(255);
    authorization_strategy_id INTEGER;
    create_action_id INTEGER;
    read_action_id INTEGER;
    update_action_id INTEGER;
    delete_action_id INTEGER;
    readchanges_action_id INTEGER;
    resource_claim_action_id INTEGER;
    claim_set_resource_claim_action_id INTEGER;
    claim_id_stack INTEGER ARRAY;
BEGIN
    SELECT actionid INTO create_action_id
    FROM dbo.actions WHERE ActionName = 'Create';

    SELECT actionid INTO read_action_id
    FROM dbo.actions WHERE ActionName = 'Read';

    SELECT actionid INTO update_action_id
    FROM dbo.actions WHERE ActionName = 'Update';

    SELECT actionid INTO delete_action_id
    FROM dbo.actions WHERE ActionName = 'Delete';

    SELECT actionid INTO readchanges_action_id
    FROM dbo.actions WHERE ActionName = 'ReadChanges';
    

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of root
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('relationshipBasedData', 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentProgramAssociation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Create_action_id) -- Create
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentSpecialEducationProgramEligibilityAssociation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Create_action_id) -- Create
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentTransportation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Create_action_id) -- Create
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('accountabilityRating', 'http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Create_action_id) -- Create
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('chartOfAccount', 'http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Create_action_id) -- Create
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assessmentMetadata', 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentAssessment', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Create_action_id) -- Create
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('primaryRelationships', 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/primaryRelationships
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/people'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/people';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('people', 'http://ed-fi.org/ods/identity/claims/domains/people', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/student'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ed-fi/student';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('student', 'http://ed-fi.org/ods/identity/claims/ed-fi/student', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/ed-fi/student
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Custom View Test';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    COMMIT;

    -- TODO: Remove - For interactive development only
    -- SELECT dbo.GetAuthorizationMetadataDocument();
    -- ROLLBACK;
END $$;
