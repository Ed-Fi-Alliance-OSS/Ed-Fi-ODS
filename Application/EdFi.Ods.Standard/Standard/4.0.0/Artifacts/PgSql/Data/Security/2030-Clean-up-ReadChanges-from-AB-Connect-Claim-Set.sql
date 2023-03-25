
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
    readchanges_action_id INTEGER;
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

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('systemDescriptors', 'systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (from ResourceClaimId=' || COALESCE(existing_parent_resource_claim_id, 0) || ' to ResourceClaimId=' || COALESCE(parent_resource_claim_id, 0) || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('academicSubjectDescriptor', 'academicSubjectDescriptor', 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (from ResourceClaimId=' || COALESCE(existing_parent_resource_claim_id, 0) || ' to ResourceClaimId=' || COALESCE(parent_resource_claim_id, 0) || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'AB Connect';
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
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('gradeLevelDescriptor', 'gradeLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (from ResourceClaimId=' || COALESCE(existing_parent_resource_claim_id, 0) || ' to ResourceClaimId=' || COALESCE(parent_resource_claim_id, 0) || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'AB Connect';
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
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('publicationStatusDescriptor', 'publicationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (from ResourceClaimId=' || COALESCE(existing_parent_resource_claim_id, 0) || ' to ResourceClaimId=' || COALESCE(parent_resource_claim_id, 0) || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'AB Connect';
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

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/educationStandards'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := 'http://ed-fi.org/ods/identity/claims/domains/educationStandards';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('educationStandards', 'educationStandards', 'http://ed-fi.org/ods/identity/claims/domains/educationStandards', parent_resource_claim_id, application_id)
        RETURNING ResourceClaimId
        INTO claim_id;
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Repointing claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to new parent (from ResourceClaimId=' || COALESCE(existing_parent_resource_claim_id, 0) || ' to ResourceClaimId=' || COALESCE(parent_resource_claim_id, 0) || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
    END IF;
  
    -- Processing claimsets for http://ed-fi.org/ods/identity/claims/domains/educationStandards
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := 'AB Connect';
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

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);

    COMMIT;
END $$;
