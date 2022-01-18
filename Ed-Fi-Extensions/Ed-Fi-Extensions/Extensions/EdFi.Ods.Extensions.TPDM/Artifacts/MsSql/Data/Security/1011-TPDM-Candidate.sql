-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @authorizationStrategyId INT
SELECT @authorizationStrategyId = AuthorizationStrategyId
FROM dbo.AuthorizationStrategies
WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

DECLARE @resourceClaimId INT
SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/tpdm/candidate'

-- Create CRUD action claims for @resourceClaimName
INSERT INTO dbo.ResourceClaimActions (
     ActionId
    ,ResourceClaimId
    ,ValidationRuleSetName
)
SELECT a.ActionId ,ResourceClaimId ,NULL
FROM dbo.ResourceClaims RC
CROSS JOIN dbo.Actions a
WHERE ResourceClaimId = @resourceClaimId

INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
SELECT RCA.ResourceClaimActionId,@authorizationStrategyId FROM dbo.ResourceClaimActionS RCA 
INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
WHERE RCA.ResourceClaimId = @resourceClaimId

