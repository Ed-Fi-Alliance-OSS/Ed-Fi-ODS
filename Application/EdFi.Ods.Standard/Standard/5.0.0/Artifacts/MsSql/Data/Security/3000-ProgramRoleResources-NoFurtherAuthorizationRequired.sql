-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE
    @claimSetId AS INT,
    @resourceClaimId AS INT,
    @authorizationStrategyId AS INT,
    @createActionId AS INT,
    @readActionId AS INT,
    @updateActionId AS INT,
    @deleteActionId AS INT,
    @readChangesActionId AS INT

SELECT @createActionId = ActionId
FROM [dbo].[Actions] WHERE ActionName = 'Create';

SELECT @readActionId = ActionId
FROM [dbo].[Actions] WHERE ActionName = 'Read';

SELECT @updateActionId = ActionId
FROM [dbo].[Actions] WHERE ActionName = 'Update';

SELECT @deleteActionId = ActionId
FROM [dbo].[Actions] WHERE ActionName = 'Delete';

SELECT @readChangesActionId = ActionId
FROM [dbo].[Actions] WHERE ActionName = 'ReadChanges';

SELECT @claimSetId = ClaimSetId FROM ClaimSets WHERE claimSetName = 'Ed-Fi Sandbox'

SELECT @authorizationStrategyId = AuthorizationStrategyId FROM AuthorizationStrategies
WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

---- Update EvaluationRubricDimension Authorization Strategy -----

SELECT @resourceClaimId = ResourceClaimId FROM ResourceClaims WHERE ResourceName = 'EvaluationRubricDimension'

INSERT INTO ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
VALUES
(@claimSetId, @resourceClaimId, @createActionId),
(@claimSetId, @resourceClaimId, @readActionId),
(@claimSetId, @resourceClaimId, @updateActionId),
(@claimSetId, @resourceClaimId, @deleteActionId),
(@claimSetId, @resourceClaimId, @readChangesActionId);
 
INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @createActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @updateActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @deleteActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readChangesActionId

---- Update ProgramEvaluation Authorization Strategy -------------

SELECT @resourceClaimId = ResourceClaimId FROM ResourceClaims WHERE ResourceName = 'ProgramEvaluation'

INSERT INTO ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
VALUES
(@claimSetId, @resourceClaimId, @createActionId),
(@claimSetId, @resourceClaimId, @readActionId),
(@claimSetId, @resourceClaimId, @updateActionId),
(@claimSetId, @resourceClaimId, @deleteActionId),
(@claimSetId, @resourceClaimId, @readChangesActionId);
 
INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @createActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @updateActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @deleteActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readChangesActionId

---- Update ProgramEvaluationElement Authorization Strategy ------

SELECT @resourceClaimId = ResourceClaimId FROM ResourceClaims WHERE ResourceName = 'ProgramEvaluationElement'

INSERT INTO ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
VALUES
(@claimSetId, @resourceClaimId, @createActionId),
(@claimSetId, @resourceClaimId, @readActionId),
(@claimSetId, @resourceClaimId, @updateActionId),
(@claimSetId, @resourceClaimId, @deleteActionId),
(@claimSetId, @resourceClaimId, @readChangesActionId);
 
INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @createActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @updateActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @deleteActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readChangesActionId

---- Update ProgramEvaluationObjective Authorization Strategy ----

SELECT @resourceClaimId = ResourceClaimId FROM ResourceClaims WHERE ResourceName = 'ProgramEvaluationObjective'

INSERT INTO ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
VALUES
(@claimSetId, @resourceClaimId, @createActionId),
(@claimSetId, @resourceClaimId, @readActionId),
(@claimSetId, @resourceClaimId, @updateActionId),
(@claimSetId, @resourceClaimId, @deleteActionId),
(@claimSetId, @resourceClaimId, @readChangesActionId);
 
INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @createActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @updateActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @deleteActionId

INSERT INTO ClaimSetResourceClaimActionAuthorizationStrategyOverrides
 (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    SELECT ClaimSetResourceClaimActionId, @authorizationStrategyId FROM ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @resourceClaimId AND ActionId = @readChangesActionId
