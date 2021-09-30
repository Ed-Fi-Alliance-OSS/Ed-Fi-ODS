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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('candidatePreparation', 'candidatePreparation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation', parent_resource_claim_id, application_id)
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('candidateEducatorPreparationProgramAssociation', 'candidateEducatorPreparationProgramAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/candidateEducatorPreparationProgramAssociation', parent_resource_claim_id, application_id)
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('financialAid', 'financialAid', 'http://ed-fi.org/ods/identity/claims/tpdm/financialAid', parent_resource_claim_id, application_id)
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('educatorPreparationProgram', 'educatorPreparationProgram', 'http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram', parent_resource_claim_id, application_id)
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
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/ePPProgramPathwayDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/ePPProgramPathwayDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('ePPProgramPathwayDescriptor', 'ePPProgramPathwayDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/ePPProgramPathwayDescriptor', parent_resource_claim_id, application_id)
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
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRatingStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRatingStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('evaluationRatingStatusDescriptor', 'evaluationRatingStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRatingStatusDescriptor', parent_resource_claim_id, application_id)
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('candidate', 'candidate', 'http://ed-fi.org/ods/identity/claims/tpdm/candidate', parent_resource_claim_id, application_id)
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
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/survey'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/tpdm/survey';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('survey', 'survey', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/survey', parent_resource_claim_id, application_id)
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

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/survey
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('surveyResponsePersonTargetAssociation', 'surveyResponsePersonTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponsePersonTargetAssociation', parent_resource_claim_id, application_id)
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('surveySectionResponsePersonTargetAssociation', 'surveySectionResponsePersonTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponsePersonTargetAssociation', parent_resource_claim_id, application_id)
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
