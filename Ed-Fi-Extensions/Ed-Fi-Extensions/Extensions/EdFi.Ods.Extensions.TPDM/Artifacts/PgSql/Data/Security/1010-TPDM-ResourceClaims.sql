-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  
DO $$
DECLARE
    application_id INTEGER;
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
    claim_id_stack INTEGER ARRAY;
BEGIN
    SELECT applicationid INTO application_id
    FROM dbo.applications WHERE ApplicationName = 'Ed-Fi ODS API';

    SELECT actionid INTO create_action_id
    FROM dbo.actions WHERE ActionName = 'Create';

    SELECT actionid INTO read_action_id
    FROM dbo.actions WHERE ActionName = 'Read';

    SELECT actionid INTO update_action_id
    FROM dbo.actions WHERE ActionName = 'Update';

    SELECT actionid INTO delete_action_id
    FROM dbo.actions WHERE ActionName = 'Delete';


    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of root
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('tpdm', 'tpdm', 'http://ed-fi.org/ods/identity/claims/domains/tpdm', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (claim_set_name, application_id)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = claim_set_id AND ResourceClaim_ResourceClaimId = claim_id;
    

    -- Claim set-specific Create authorization
    authorization_strategy_id := NULL;
    

    IF authorization_strategy_id IS NULL THEN
        RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';
    ELSE
        RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ', authorizationStrategyId = ' || authorization_strategy_id || ').';
    END IF;

    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (claim_id, claim_set_id, Create_action_id, authorization_strategy_id); -- Create

    -- Claim set-specific Read authorization
    authorization_strategy_id := NULL;
    

    IF authorization_strategy_id IS NULL THEN
        RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ').';
    ELSE
        RAISE NOTICE USING MESSAGE = 'Creating ''Read'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Read_action_id || ', authorizationStrategyId = ' || authorization_strategy_id || ').';
    END IF;

    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (claim_id, claim_set_id, Read_action_id, authorization_strategy_id); -- Read

    -- Claim set-specific Update authorization
    authorization_strategy_id := NULL;
    

    IF authorization_strategy_id IS NULL THEN
        RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ').';
    ELSE
        RAISE NOTICE USING MESSAGE = 'Creating ''Update'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Update_action_id || ', authorizationStrategyId = ' || authorization_strategy_id || ').';
    END IF;

    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (claim_id, claim_set_id, Update_action_id, authorization_strategy_id); -- Update

    -- Claim set-specific Delete authorization
    authorization_strategy_id := NULL;
    

    IF authorization_strategy_id IS NULL THEN
        RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ').';
    ELSE
        RAISE NOTICE USING MESSAGE = 'Creating ''Delete'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Delete_action_id || ', authorizationStrategyId = ' || authorization_strategy_id || ').';
    END IF;

    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (claim_id, claim_set_id, Delete_action_id, authorization_strategy_id); -- Delete
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('performanceEvaluation', 'performanceEvaluation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);

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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('performanceEvaluation', 'performanceEvaluation', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluation', 'evaluation', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationObjective', 'evaluationObjective', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjective', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationElement', 'evaluationElement', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElement', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('rubricDimension', 'rubricDimension', 'http://ed-fi.org/ods/identity/claims/tpdm/rubricDimension', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('quantitativeMeasure', 'quantitativeMeasure', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasure', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationRating', 'evaluationRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRating', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationObjectiveRating', 'evaluationObjectiveRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjectiveRating', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationElementRating', 'evaluationElementRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRating', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('quantitativeMeasureScore', 'quantitativeMeasureScore', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureScore', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('performanceEvaluationRating', 'performanceEvaluationRating', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('goal', 'goal', 'http://ed-fi.org/ods/identity/claims/tpdm/goal', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);


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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('credentials', 'credentials', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Namespace Based';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Namespace Based''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Namespace Based';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Namespace Based''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Namespace Based';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Namespace Based''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Namespace Based';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Namespace Based''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);

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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certification', 'certification', 'http://ed-fi.org/ods/identity/claims/tpdm/certification', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationExam', 'certificationExam', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExam', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationExamResult', 'certificationExamResult', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamResult', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('credentialEvent', 'credentialEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEvent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);


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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('professionalDevelopment', 'professionalDevelopment', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);

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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('professionalDevelopmentEvent', 'professionalDevelopmentEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEvent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('professionalDevelopmentEventAttendance', 'professionalDevelopmentEventAttendance', 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEventAttendance', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('recruiting', 'recruiting', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);

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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('application', 'application', 'http://ed-fi.org/ods/identity/claims/tpdm/application', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('applicationEvent', 'applicationEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEvent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('openStaffPositionEvent', 'openStaffPositionEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEvent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('recruitmentEvent', 'recruitmentEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEvent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);


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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('noFurtherAuthorizationRequiredData', 'noFurtherAuthorizationRequiredData', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('personRoleAssociations', 'personRoleAssociations', 'http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProspectAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProspectAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('applicantProspectAssociation', 'applicantProspectAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProspectAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/completerAsStaffAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/completerAsStaffAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('completerAsStaffAssociation', 'completerAsStaffAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/completerAsStaffAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffApplicantAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/staffApplicantAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('staffApplicantAssociation', 'staffApplicantAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/staffApplicantAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffProspectAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/staffProspectAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('staffProspectAssociation', 'staffProspectAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/staffProspectAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStaffAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStaffAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateStaffAssociation', 'teacherCandidateStaffAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStaffAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/staffPreparation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/staffPreparation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('staffPreparation', 'staffPreparation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/staffPreparation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/staffPreparation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasure'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasure';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('staffStudentGrowthMeasure', 'staffStudentGrowthMeasure', 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasure', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureCourseAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureCourseAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('staffStudentGrowthMeasureCourseAssociation', 'staffStudentGrowthMeasureCourseAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureCourseAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureEducationOrganizationAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureEducationOrganizationAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('staffStudentGrowthMeasureEducationOrganizationAssociation', 'staffStudentGrowthMeasureEducationOrganizationAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureEducationOrganizationAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureSectionAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureSectionAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('staffStudentGrowthMeasureSectionAssociation', 'staffStudentGrowthMeasureSectionAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/staffStudentGrowthMeasureSectionAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/teacherCandidatePreparation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/teacherCandidatePreparation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidatePreparation', 'teacherCandidatePreparation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/teacherCandidatePreparation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/teacherCandidatePreparation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateAcademicRecord'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateAcademicRecord';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateAcademicRecord', 'teacherCandidateAcademicRecord', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateAcademicRecord', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateCourseTranscript'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateCourseTranscript';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateCourseTranscript', 'teacherCandidateCourseTranscript', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateCourseTranscript', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasure'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasure';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateStudentGrowthMeasure', 'teacherCandidateStudentGrowthMeasure', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasure', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureCourseAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureCourseAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateStudentGrowthMeasureCourseAssociation', 'teacherCandidateStudentGrowthMeasureCourseAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureCourseAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureEducationOrganizationAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureEducationOrganizationAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', 'teacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureSectionAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureSectionAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateStudentGrowthMeasureSectionAssociation', 'teacherCandidateStudentGrowthMeasureSectionAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateStudentGrowthMeasureSectionAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateTeacherPreparationProviderProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateTeacherPreparationProviderProgramAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateTeacherPreparationProviderProgramAssociation', 'teacherCandidateTeacherPreparationProviderProgramAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateTeacherPreparationProviderProgramAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('students', 'students', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/students', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/students
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('fieldworkExperience', 'fieldworkExperience', 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperience', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('fieldworkExperienceSectionAssociation', 'fieldworkExperienceSectionAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperienceSectionAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/employment'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/employment';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('employment', 'employment', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/employment', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/employment
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/employmentEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/employmentEvent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('employmentEvent', 'employmentEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/employmentEvent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationEvent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('employmentSeparationEvent', 'employmentSeparationEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationEvent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/anonymizedStudentAcademics'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/anonymizedStudentAcademics';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentAcademics', 'anonymizedStudentAcademics', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/anonymizedStudentAcademics', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/anonymizedStudentAcademics
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudent'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudent';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudent', 'anonymizedStudent', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudent', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAcademicRecord'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAcademicRecord';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentAcademicRecord', 'anonymizedStudentAcademicRecord', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAcademicRecord', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessment'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessment';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentAssessment', 'anonymizedStudentAssessment', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessment', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessmentCourseAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessmentCourseAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentAssessmentCourseAssociation', 'anonymizedStudentAssessmentCourseAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessmentCourseAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessmentSectionAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessmentSectionAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentAssessmentSectionAssociation', 'anonymizedStudentAssessmentSectionAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentAssessmentSectionAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentCourseAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentCourseAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentCourseAssociation', 'anonymizedStudentCourseAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentCourseAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentCourseTranscript'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentCourseTranscript';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentCourseTranscript', 'anonymizedStudentCourseTranscript', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentCourseTranscript', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentEducationOrganizationAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentEducationOrganizationAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentEducationOrganizationAssociation', 'anonymizedStudentEducationOrganizationAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentEducationOrganizationAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentSectionAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentSectionAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('anonymizedStudentSectionAssociation', 'anonymizedStudentSectionAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/anonymizedStudentSectionAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherPreparationProviderProgram'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherPreparationProviderProgram';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherPreparationProviderProgram', 'teacherPreparationProviderProgram', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherPreparationProviderProgram', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'Relationships with Education Organizations only';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''Relationships with Education Organizations only''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);

    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/tpdm/teacherPreparationProviderProgram
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

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (claim_set_name, application_id)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = claim_set_id AND ResourceClaim_ResourceClaimId = claim_id;
    

    -- Claim set-specific Create authorization
    authorization_strategy_id := NULL;
    

    IF authorization_strategy_id IS NULL THEN
        RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ').';
    ELSE
        RAISE NOTICE USING MESSAGE = 'Creating ''Create'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || Create_action_id || ', authorizationStrategyId = ' || authorization_strategy_id || ').';
    END IF;

    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (claim_id, claim_set_id, Create_action_id, authorization_strategy_id); -- Create

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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('systemDescriptors', 'systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/descriptors'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/descriptors';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('descriptors', 'descriptors', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/descriptors', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/descriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/accreditationStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/accreditationStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('accreditationStatusDescriptor', 'accreditationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/accreditationStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/aidTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/aidTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('aidTypeDescriptor', 'aidTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/aidTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEventResultDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEventResultDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('applicationEventResultDescriptor', 'applicationEventResultDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEventResultDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('applicationEventTypeDescriptor', 'applicationEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEventTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicationSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicationSourceDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('applicationSourceDescriptor', 'applicationSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/applicationSourceDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicationStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicationStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('applicationStatusDescriptor', 'applicationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/applicationStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/backgroundCheckStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/backgroundCheckStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('backgroundCheckStatusDescriptor', 'backgroundCheckStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/backgroundCheckStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/backgroundCheckTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/backgroundCheckTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('backgroundCheckTypeDescriptor', 'backgroundCheckTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/backgroundCheckTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationExamStatusDescriptor', 'certificationExamStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationExamTypeDescriptor', 'certificationExamTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationFieldDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationFieldDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationFieldDescriptor', 'certificationFieldDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationFieldDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationLevelDescriptor', 'certificationLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationLevelDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationRouteDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationRouteDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationRouteDescriptor', 'certificationRouteDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationRouteDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationStandardDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/certificationStandardDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('certificationStandardDescriptor', 'certificationStandardDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationStandardDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/coteachingStyleObservedDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/coteachingStyleObservedDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('coteachingStyleObservedDescriptor', 'coteachingStyleObservedDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/coteachingStyleObservedDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('credentialEventTypeDescriptor', 'credentialEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEventTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/credentialStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/credentialStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('credentialStatusDescriptor', 'credentialStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/credentialStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/degreeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/degreeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('degreeDescriptor', 'degreeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/degreeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/educatorRoleDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/educatorRoleDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('educatorRoleDescriptor', 'educatorRoleDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/educatorRoleDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/employmentEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/employmentEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('employmentEventTypeDescriptor', 'employmentEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/employmentEventTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationReasonDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationReasonDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('employmentSeparationReasonDescriptor', 'employmentSeparationReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationReasonDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('employmentSeparationTypeDescriptor', 'employmentSeparationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/employmentSeparationTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/englishLanguageExamDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/englishLanguageExamDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('englishLanguageExamDescriptor', 'englishLanguageExamDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/englishLanguageExamDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRatingLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRatingLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationElementRatingLevelDescriptor', 'evaluationElementRatingLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRatingLevelDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationPeriodDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationPeriodDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationPeriodDescriptor', 'evaluationPeriodDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationPeriodDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRatingLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRatingLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationRatingLevelDescriptor', 'evaluationRatingLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRatingLevelDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationTypeDescriptor', 'evaluationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/federalLocaleCodeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/federalLocaleCodeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('federalLocaleCodeDescriptor', 'federalLocaleCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/federalLocaleCodeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('fieldworkTypeDescriptor', 'fieldworkTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/fundingSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/fundingSourceDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('fundingSourceDescriptor', 'fundingSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/fundingSourceDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/genderDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/genderDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('genderDescriptor', 'genderDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/genderDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/goalTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/goalTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('goalTypeDescriptor', 'goalTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/goalTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/hireStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/hireStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('hireStatusDescriptor', 'hireStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/hireStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/hiringSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/hiringSourceDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('hiringSourceDescriptor', 'hiringSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/hiringSourceDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/instructionalSettingDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/instructionalSettingDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('instructionalSettingDescriptor', 'instructionalSettingDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/instructionalSettingDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/internalExternalHireDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/internalExternalHireDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('internalExternalHireDescriptor', 'internalExternalHireDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/internalExternalHireDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/levelOfDegreeAwardedDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/levelOfDegreeAwardedDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('levelOfDegreeAwardedDescriptor', 'levelOfDegreeAwardedDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/levelOfDegreeAwardedDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/objectiveRatingLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/objectiveRatingLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('objectiveRatingLevelDescriptor', 'objectiveRatingLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/objectiveRatingLevelDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEventStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEventStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('openStaffPositionEventStatusDescriptor', 'openStaffPositionEventStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEventStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('openStaffPositionEventTypeDescriptor', 'openStaffPositionEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEventTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionReasonDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionReasonDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('openStaffPositionReasonDescriptor', 'openStaffPositionReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionReasonDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRatingLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRatingLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('performanceEvaluationRatingLevelDescriptor', 'performanceEvaluationRatingLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRatingLevelDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('performanceEvaluationTypeDescriptor', 'performanceEvaluationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/previousCareerDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/previousCareerDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('previousCareerDescriptor', 'previousCareerDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/previousCareerDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentOfferedByDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentOfferedByDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('professionalDevelopmentOfferedByDescriptor', 'professionalDevelopmentOfferedByDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentOfferedByDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/programGatewayDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/programGatewayDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('programGatewayDescriptor', 'programGatewayDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/programGatewayDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/prospectTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/prospectTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('prospectTypeDescriptor', 'prospectTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/prospectTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureDatatypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureDatatypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('quantitativeMeasureDatatypeDescriptor', 'quantitativeMeasureDatatypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureDatatypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('quantitativeMeasureTypeDescriptor', 'quantitativeMeasureTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('recruitmentEventTypeDescriptor', 'recruitmentEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/rubricRatingLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/rubricRatingLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('rubricRatingLevelDescriptor', 'rubricRatingLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/rubricRatingLevelDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/salaryTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/salaryTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('salaryTypeDescriptor', 'salaryTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/salaryTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/schoolStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/schoolStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('schoolStatusDescriptor', 'schoolStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/schoolStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentGrowthTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/studentGrowthTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('studentGrowthTypeDescriptor', 'studentGrowthTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/studentGrowthTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateCharacteristicDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateCharacteristicDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidateCharacteristicDescriptor', 'teacherCandidateCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidateCharacteristicDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherPreparationProgramTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherPreparationProgramTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherPreparationProgramTypeDescriptor', 'teacherPreparationProgramTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherPreparationProgramTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/tPPDegreeTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/tPPDegreeTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('tPPDegreeTypeDescriptor', 'tPPDegreeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/tPPDegreeTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/tPPProgramPathwayDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/tPPProgramPathwayDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('tPPProgramPathwayDescriptor', 'tPPProgramPathwayDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/tPPProgramPathwayDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/valueTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/valueTypeDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('valueTypeDescriptor', 'valueTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/valueTypeDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/withdrawReasonDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/withdrawReasonDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('withdrawReasonDescriptor', 'withdrawReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/withdrawReasonDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('educationOrganizations', 'educationOrganizations', 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('people', 'people', 'http://ed-fi.org/ods/identity/claims/domains/people', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/people'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/people';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('people', 'people', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/people', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = claim_id;
    
    -- Default Create authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Create_action_id, authorization_strategy_id);

    -- Default Read authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Read_action_id, authorization_strategy_id);

    -- Default Update authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Update_action_id, authorization_strategy_id);

    -- Default Delete authorization
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
    END IF;

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (claim_id, Delete_action_id, authorization_strategy_id);

    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidate'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidate';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('teacherCandidate', 'teacherCandidate', 'http://ed-fi.org/ods/identity/claims/tpdm/teacherCandidate', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicant'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/applicant';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('applicant', 'applicant', 'http://ed-fi.org/ods/identity/claims/tpdm/applicant', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/prospect'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/prospect';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('prospect', 'prospect', 'http://ed-fi.org/ods/identity/claims/tpdm/prospect', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('surveyDomain', 'surveyDomain', 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/surveyDomain
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'https://ed-fi.org/ods/identity/claims/domains/tpdm/survey'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'https://ed-fi.org/ods/identity/claims/domains/tpdm/survey';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('survey', 'survey', 'https://ed-fi.org/ods/identity/claims/domains/tpdm/survey', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of https://ed-fi.org/ods/identity/claims/domains/tpdm/survey
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('surveySectionAggregateResponse', 'surveySectionAggregateResponse', 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionAggregateResponse', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponseTeacherCandidateTargetAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponseTeacherCandidateTargetAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('surveyResponseTeacherCandidateTargetAssociation', 'surveyResponseTeacherCandidateTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponseTeacherCandidateTargetAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponseTeacherCandidateTargetAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponseTeacherCandidateTargetAssociation';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('surveySectionResponseTeacherCandidateTargetAssociation', 'surveySectionResponseTeacherCandidateTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponseTeacherCandidateTargetAssociation', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (ResourceClaimId=' || parent_resource_claim_id || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);


    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

END $$;
