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
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/balanceSheetDimension'

-- Create CRUD action claims for balanceSheetDimension
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


SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/functionDimension'

-- Create CRUD action claims for functionDimension
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


SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/fundDimension'

-- Create CRUD action claims for fundDimension
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

SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/objectDimension'

-- Create CRUD action claims for objectDimension
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


SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/operationalUnitDimension'

-- Create CRUD action claims for operationalUnitDimension
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


SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/programDimension'

-- Create CRUD action claims for programDimension
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


SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/projectDimension'

-- Create CRUD action claims for projectDimension
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

SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/sourceDimension'

-- Create CRUD action claims for sourceDimension
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


/* NamespaceBased */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NamespaceBased');

SELECT @resourceClaimId = ResourceClaimId
FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/descriptorMapping'

-- Create CRUD action claims for descriptorMapping
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

