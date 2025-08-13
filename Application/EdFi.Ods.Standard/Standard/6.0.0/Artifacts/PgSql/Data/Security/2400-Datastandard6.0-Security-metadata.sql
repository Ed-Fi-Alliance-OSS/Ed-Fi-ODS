
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
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''ReadChanges'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, ReadChanges_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'SIS Vendor';
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi Sandbox';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Assessment Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Assessment Vendor';
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Bootstrap Descriptors and EdOrgs'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Bootstrap Descriptors and EdOrgs';
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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'District Hosted SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'District Hosted SIS Vendor';
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Reader';
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

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Writer';
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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Education Preparation Program';
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

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/pathPhaseStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/pathPhaseStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('pathPhaseStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/pathPhaseStatusDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/pathMilestoneTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/pathMilestoneTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('pathMilestoneTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/pathMilestoneTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/pathMilestoneStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/pathMilestoneStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('pathMilestoneStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/pathMilestoneStatusDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/staffToCandidateRelationshipDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/staffToCandidateRelationshipDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('staffToCandidateRelationshipDescriptor', 'http://ed-fi.org/ods/identity/claims/staffToCandidateRelationshipDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/lengthOfContractDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/lengthOfContractDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('lengthOfContractDescriptor', 'http://ed-fi.org/ods/identity/claims/lengthOfContractDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationEventResultDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/applicationEventResultDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('applicationEventResultDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationEventResultDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/applicationEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('applicationEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationEventTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/applicationSourceDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('applicationSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationSourceDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/applicationStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('applicationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationStatusDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/backgroundCheckStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/backgroundCheckStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('backgroundCheckStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/backgroundCheckStatusDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/backgroundCheckTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/backgroundCheckTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('backgroundCheckTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/backgroundCheckTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationExamStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/certificationExamStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certificationExamStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationExamStatusDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationExamTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/certificationExamTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certificationExamTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationExamTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationFieldDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/certificationFieldDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certificationFieldDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationFieldDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/certificationLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certificationLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationLevelDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationStandardDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/certificationStandardDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certificationStandardDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationStandardDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/credentialEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/credentialEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('credentialEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/credentialEventTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/degreeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/degreeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('degreeDescriptor', 'http://ed-fi.org/ods/identity/claims/degreeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/federalLocaleCodeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/federalLocaleCodeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('federalLocaleCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/federalLocaleCodeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/fieldworkTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/fieldworkTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('fieldworkTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/fieldworkTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/fundingSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/fundingSourceDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('fundingSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/fundingSourceDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/goalTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/goalTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('goalTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/goalTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/hireStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/hireStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('hireStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/hireStatusDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/hiringSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/hiringSourceDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('hiringSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/hiringSourceDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/instructionalSettingDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/instructionalSettingDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('instructionalSettingDescriptor', 'http://ed-fi.org/ods/identity/claims/instructionalSettingDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('openStaffPositionEventStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventStatusDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('openStaffPositionEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/openStaffPositionReasonDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/openStaffPositionReasonDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('openStaffPositionReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/openStaffPositionReasonDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/previousCareerDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/previousCareerDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('previousCareerDescriptor', 'http://ed-fi.org/ods/identity/claims/previousCareerDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/professionalDevelopmentOfferedByDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/professionalDevelopmentOfferedByDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('professionalDevelopmentOfferedByDescriptor', 'http://ed-fi.org/ods/identity/claims/professionalDevelopmentOfferedByDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/programGatewayDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/programGatewayDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('programGatewayDescriptor', 'http://ed-fi.org/ods/identity/claims/programGatewayDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/recruitmentEventAttendeeTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/recruitmentEventAttendeeTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('recruitmentEventAttendeeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/recruitmentEventAttendeeTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureDatatypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureDatatypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('quantitativeMeasureDatatypeDescriptor', 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureDatatypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('quantitativeMeasureTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/recruitmentEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/recruitmentEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('recruitmentEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/recruitmentEventTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/salaryTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/salaryTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('salaryTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/salaryTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/candidateCharacteristicDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/candidateCharacteristicDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('candidateCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/candidateCharacteristicDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/educatorPreparationProgramTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/educatorPreparationProgramTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('educatorPreparationProgramTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/educatorPreparationProgramTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ePPDegreeTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/ePPDegreeTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('ePPDegreeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/ePPDegreeTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/withdrawReasonDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/withdrawReasonDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('withdrawReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/withdrawReasonDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('tpdm', 'http://ed-fi.org/ods/identity/claims/domains/tpdm', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/tpdm
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi Sandbox';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Reader';
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

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Writer';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('performanceEvaluation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('performanceEvaluation', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('evaluation', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjective'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjective';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('evaluationObjective', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjective', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElement'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElement';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('evaluationElement', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElement', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/rubricDimension'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/rubricDimension';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('rubricDimension', 'http://ed-fi.org/ods/identity/claims/tpdm/rubricDimension', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRating'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRating';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('evaluationRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRating', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjectiveRating'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjectiveRating';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('evaluationObjectiveRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjectiveRating', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRating'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRating';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('evaluationElementRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRating', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('performanceEvaluationRating', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasure'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasure';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('quantitativeMeasure', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasure', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureScore'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureScore';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('quantitativeMeasureScore', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureScore', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/goal'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/goal';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('goal', 'http://ed-fi.org/ods/identity/claims/tpdm/goal', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('path', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/path
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/path';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('path', 'http://ed-fi.org/ods/identity/claims/tpdm/path', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('pathPhase', 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentPath', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentPathMilestoneStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentPathPhaseStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('noFurtherAuthorizationRequiredData', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('candidatePreparation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Education Preparation Program';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/candidateEducatorPreparationProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/candidateEducatorPreparationProgramAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('candidateEducatorPreparationProgramAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/candidateEducatorPreparationProgramAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/students'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/students';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('students', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/students', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/students
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/financialAid'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/financialAid';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('financialAid', 'http://ed-fi.org/ods/identity/claims/tpdm/financialAid', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperience'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperience';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('fieldworkExperience', 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperience', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperienceSectionAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperienceSectionAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('fieldworkExperienceSectionAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperienceSectionAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/pathMilestone'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/pathMilestone';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('pathMilestone', 'http://ed-fi.org/ods/identity/claims/tpdm/pathMilestone', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('personRoleAssociations', 'http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffEducatorPreparationProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/staffEducatorPreparationProgramAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('staffEducatorPreparationProgramAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/staffEducatorPreparationProgramAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/candidateRelationshipToStaffAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/candidateRelationshipToStaffAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('candidateRelationshipToStaffAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/candidateRelationshipToStaffAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('educatorPreparationProgram', 'http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Bootstrap Descriptors and EdOrgs'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Bootstrap Descriptors and EdOrgs';
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('path', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/path
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/path';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('path', 'http://ed-fi.org/ods/identity/claims/tpdm/path', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('pathPhase', 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentPath', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentPathMilestoneStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentPathPhaseStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('credentials', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certification'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certification';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certification', 'http://ed-fi.org/ods/identity/claims/tpdm/certification', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExam'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExam';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certificationExam', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExam', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamResult'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamResult';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('certificationExamResult', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamResult', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEvent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('credentialEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEvent', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('professionalDevelopment', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEvent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('professionalDevelopmentEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEvent', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEventAttendance'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEventAttendance';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('professionalDevelopmentEventAttendance', 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEventAttendance', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('recruiting', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/application'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/application';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('application', 'http://ed-fi.org/ods/identity/claims/tpdm/application', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEvent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('applicationEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEvent', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEvent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('openStaffPositionEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEvent', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEvent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('recruitmentEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEvent', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventAttendance'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventAttendance';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('recruitmentEventAttendance', 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventAttendance', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProfile'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProfile';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('applicantProfile', 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProfile', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

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
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''ReadChanges'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, ReadChanges_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'SIS Vendor';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi Sandbox';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Assessment Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Assessment Vendor';
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'District Hosted SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'District Hosted SIS Vendor';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Reader';
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

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Writer';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('surveyDomain', 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''ReadChanges'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, ReadChanges_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/surveyDomain
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi Sandbox';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Writer';
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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';

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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

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
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Education Preparation Program';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/surveyDomain
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponsePersonTargetAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponsePersonTargetAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('surveyResponsePersonTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponsePersonTargetAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponsePersonTargetAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponsePersonTargetAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('surveySectionResponsePersonTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponsePersonTargetAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionAggregateResponse'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionAggregateResponse';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('surveySectionAggregateResponse', 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionAggregateResponse', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


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
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''ReadChanges'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, ReadChanges_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'SIS Vendor';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi Sandbox';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'District Hosted SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'District Hosted SIS Vendor';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Reader';
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

    
    

    -- Claim set-specific ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''ReadChanges'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || ReadChanges_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, ReadChanges_action_id) -- ReadChanges
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Ed-Fi API Publisher - Writer';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/candidate'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/candidate';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('candidate', 'http://ed-fi.org/ods/identity/claims/tpdm/candidate', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    
    -- Default Create authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Create'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Create_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Read'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Read_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Update'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Update_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''Delete'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, Delete_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Default ReadChanges authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''ReadChanges'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, ReadChanges_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/tpdm/candidate
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'Education Preparation Program';
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

    
    

    -- Claim set-specific Read authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Read_action_id) -- Read
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Update authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Update_action_id) -- Update
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    
    

    -- Claim set-specific Delete authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, Delete_action_id) -- Delete
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
