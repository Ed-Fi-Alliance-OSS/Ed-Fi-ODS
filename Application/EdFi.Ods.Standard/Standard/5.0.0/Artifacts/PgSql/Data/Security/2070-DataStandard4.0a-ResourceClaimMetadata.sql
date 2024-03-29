-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
authorizationStrategy_Id INT;
resourceClaim_Id INT;

BEGIN

    SELECT authorizationstrategyId INTO authorizationStrategy_Id   FROM dbo.AuthorizationStrategies  WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';
	
    SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/balanceSheetDimension';

    -- Create CRUD action claims for balanceSheetDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);
	

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  balanceSheetDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);

	END IF;

	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/functionDimension';

    -- Create CRUD action claims for functionDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  functionDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id	
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);
	
	END IF;

	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/fundDimension';

    -- Create CRUD action claims for fundDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  fundDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);
	
	END IF;

	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/objectDimension';

    -- Create CRUD action claims for objectDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  objectDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);
	
	END IF;

	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/operationalUnitDimension';

    -- Create CRUD action claims for operationalUnitDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  operationalUnitDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);
	
	END IF;

	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/programDimension';

    -- Create CRUD action claims for programDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  programDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);
	
	END IF;

	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/projectDimension';

    -- Create CRUD action claims for projectDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  projectDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);
	
	END IF;
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/sourceDimension';

    -- Create CRUD action claims for sourceDimension
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  sourceDimension resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);

	END IF;

	SELECT authorizationstrategyId INTO authorizationStrategy_Id   FROM dbo.AuthorizationStrategies  WHERE AuthorizationStrategyName = 'NamespaceBased';
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/descriptorMapping';

    -- Create CRUD action claims for descriptorMapping
	IF resourceClaim_Id IS NOT NULL AND authorizationStrategy_Id IS NOT NULL THEN

	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActions RCA
    WHERE RCA.ResourceClaimId = RC.ResourceClaimId
    AND RCA.ActionId = a.ActionId);

	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  descriptorMapping resource

	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id
	AND NOT EXISTS (
    SELECT 1
    FROM dbo.ResourceClaimActionAuthorizationStrategies RCAAS
    WHERE RCAAS.ResourceClaimActionId = RCA.ResourceClaimActionId
    AND RCAAS.AuthorizationStrategyId = authorizationStrategy_Id);

    END IF;


END $$; 