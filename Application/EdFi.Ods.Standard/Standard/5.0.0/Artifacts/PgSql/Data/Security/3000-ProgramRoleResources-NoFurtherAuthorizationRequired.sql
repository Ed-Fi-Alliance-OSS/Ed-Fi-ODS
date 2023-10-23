-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
DECLARE
    claim_set_id INTEGER;
    resource_claim_id INTEGER;
    authorization_strategy_id INTEGER;
    create_action_id INTEGER;
    read_action_id INTEGER;
    update_action_id INTEGER;
    delete_action_id INTEGER;
    readchanges_action_id INTEGER;
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

    SELECT claimSetId INTO claim_set_id
    FROM dbo.claimSets WHERE claimSetName = 'Ed-Fi Sandbox';

    SELECT authorizationStrategyId INTO authorization_strategy_id
    FROM dbo.authorizationStrategies WHERE authorizationStrategyName = 'NoFurtherAuthorizationRequired';

    ---- Update EvaluationRubricDimension Authorization Strategy -----

    SELECT resourceClaimId INTO resource_claim_id
    FROM dbo.ResourceClaims WHERE ResourceName = 'evaluationRubricDimension';

    INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
    VALUES
    (claim_set_id, resource_claim_id, create_action_id),
    (claim_set_id, resource_claim_id, read_action_id),
    (claim_set_id, resource_claim_id, update_action_id),
    (claim_set_id, resource_claim_id, delete_action_id),
    (claim_set_id, resource_claim_id, readchanges_action_id);
     
    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = create_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = read_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = update_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = delete_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = readchanges_action_id;

    ---- Update ProgramEvaluation Authorization Strategy -------------

    SELECT resourceClaimId INTO resource_claim_id
    FROM dbo.ResourceClaims WHERE ResourceName = 'programEvaluation';

    INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
    VALUES
    (claim_set_id, resource_claim_id, create_action_id),
    (claim_set_id, resource_claim_id, read_action_id),
    (claim_set_id, resource_claim_id, update_action_id),
    (claim_set_id, resource_claim_id, delete_action_id),
    (claim_set_id, resource_claim_id, readchanges_action_id);
     
    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = create_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = read_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = update_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = delete_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = readchanges_action_id;

    ---- Update ProgramEvaluationElement Authorization Strategy ------

    SELECT resourceClaimId INTO resource_claim_id
    FROM dbo.ResourceClaims WHERE ResourceName = 'programEvaluationElement';

    INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
    VALUES
    (claim_set_id, resource_claim_id, create_action_id),
    (claim_set_id, resource_claim_id, read_action_id),
    (claim_set_id, resource_claim_id, update_action_id),
    (claim_set_id, resource_claim_id, delete_action_id),
    (claim_set_id, resource_claim_id, readchanges_action_id);
     
    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = create_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = read_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = update_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = delete_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = readchanges_action_id;

    ---- Update ProgramEvaluationObjective Authorization Strategy ----

    SELECT resourceClaimId INTO resource_claim_id
    FROM dbo.ResourceClaims WHERE ResourceName = 'programEvaluationObjective';

    INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
    VALUES
    (claim_set_id, resource_claim_id, create_action_id),
    (claim_set_id, resource_claim_id, read_action_id),
    (claim_set_id, resource_claim_id, update_action_id),
    (claim_set_id, resource_claim_id, delete_action_id),
    (claim_set_id, resource_claim_id, readchanges_action_id);
     
    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = create_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = read_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = update_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = delete_action_id;

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
     (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
        SELECT ClaimSetResourceClaimActionId, authorization_strategy_id FROM dbo.ClaimSetResourceClaimActions
        WHERE ClaimSetId = claim_set_id AND ResourceClaimId = resource_claim_id AND ActionId = readchanges_action_id;

END $$;
