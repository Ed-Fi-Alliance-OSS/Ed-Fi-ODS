
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

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata
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

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/assessmentAdministration'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/assessmentAdministration';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assessmentAdministration', 'http://ed-fi.org/ods/identity/claims/assessmentAdministration', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/assessmentAdministrationAssessmentAdminstrationPeriod'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/assessmentAdministrationAssessmentAdminstrationPeriod';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assessmentAdministrationAssessmentAdminstrationPeriod', 'http://ed-fi.org/ods/identity/claims/assessmentAdministrationAssessmentAdminstrationPeriod', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/assessmentAdministrationAssessmentBatteryPart'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/assessmentAdministrationAssessmentBatteryPart';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assessmentAdministrationAssessmentBatteryPart', 'http://ed-fi.org/ods/identity/claims/assessmentAdministrationAssessmentBatteryPart', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/assessmentBatteryPart'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/assessmentBatteryPart';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assessmentBatteryPart', 'http://ed-fi.org/ods/identity/claims/assessmentBatteryPart', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/assessmentBatteryPartObjectiveAssessment'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/assessmentBatteryPartObjectiveAssessment';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assessmentBatteryPartObjectiveAssessment', 'http://ed-fi.org/ods/identity/claims/assessmentBatteryPartObjectiveAssessment', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/assesssmentAdministrationParticipation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/assesssmentAdministrationParticipation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assesssmentAdministrationParticipation', 'http://ed-fi.org/ods/identity/claims/assesssmentAdministrationParticipation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/assesssmentAdministrationParticipationAdministrationPointOfContact'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/assesssmentAdministrationParticipationAdministrationPointOfContact';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('assesssmentAdministrationParticipationAdministrationPointOfContact', 'http://ed-fi.org/ods/identity/claims/assesssmentAdministrationParticipationAdministrationPointOfContact', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistration'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistration';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentAssessmentRegistration', 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistration', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationAssessmentAccommodation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationAssessmentAccommodation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentAssessmentRegistrationAssessmentAccommodation', 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationAssessmentAccommodation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationAssessmentCustomization'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationAssessmentCustomization';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentAssessmentRegistrationAssessmentCustomization', 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationAssessmentCustomization', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationBatteryPartAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationBatteryPartAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentAssessmentRegistrationBatteryPartAssociation', 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationBatteryPartAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationBatteryPartAssociationAccommodation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationBatteryPartAssociationAccommodation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentAssessmentRegistrationBatteryPartAssociationAccommodation', 'http://ed-fi.org/ods/identity/claims/studentAssessmentRegistrationBatteryPartAssociationAccommodation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

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

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/Section504DisabilityDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/Section504DisabilityDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('Section504DisabilityDescriptor', 'http://ed-fi.org/ods/identity/claims/Section504DisabilityDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/DualCreditTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/DualCreditTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('DualCreditTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/DualCreditTypeDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/DualCreditInstitutionDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/DualCreditInstitutionDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('DualCreditInstitutionDescriptor', 'http://ed-fi.org/ods/identity/claims/DualCreditInstitutionDescriptor', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

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

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentSection504ProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentSection504ProgramAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentSection504ProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentSection504ProgramAssociation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

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

    
    
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssessmentAccommodation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssessmentAccommodation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentEducationOrganizationAssessmentAccommodation', 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssessmentAccommodation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssessmentAccommodationGeneralAccommodation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssessmentAccommodationGeneralAccommodation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('studentEducationOrganizationAssessmentAccommodationGeneralAccommodation', 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssessmentAccommodationGeneralAccommodation', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;

    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    COMMIT;

    -- TODO: Remove - For interactive development only
    -- SELECT dbo.GetAuthorizationMetadataDocument();
    -- ROLLBACK;
END $$;
