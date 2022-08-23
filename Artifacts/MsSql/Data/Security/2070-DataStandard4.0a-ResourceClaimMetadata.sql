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


-- Descriptor Resources Claims That May Be Missing if Upgrading
DECLARE @applicationId int;
SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = 'Ed-Fi ODS API');

SELECT @resourceClaimId = ResourceClaimId 
FROM ResourceClaims 
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors'

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'accountTypeDescriptor', N'accountTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'assignmentLateStatusDescriptor', N'assignmentLateStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/chartOfAccount' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'chartOfAccount', N'chartOfAccount', N'http://ed-fi.org/ods/identity/claims/chartOfAccount', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/descriptorMapping' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'descriptorMapping', N'descriptorMapping', N'http://ed-fi.org/ods/identity/claims/descriptorMapping', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'financialCollectionDescriptor', N'financialCollectionDescriptor', N'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localAccount' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'localAccount', N'localAccount', N'http://ed-fi.org/ods/identity/claims/localAccount', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localActual' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'localActual', N'localActual', N'http://ed-fi.org/ods/identity/claims/localActual', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localBudget' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'localBudget', N'localBudget', N'http://ed-fi.org/ods/identity/claims/localBudget', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localContractedStaff' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'localContractedStaff', N'localContractedStaff', N'http://ed-fi.org/ods/identity/claims/localContractedStaff', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localEncumbrance' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'localEncumbrance', N'localEncumbrance', N'http://ed-fi.org/ods/identity/claims/localEncumbrance', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localPayroll' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'localPayroll', N'localPayroll', N'http://ed-fi.org/ods/identity/claims/localPayroll', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'modelEntityDescriptor', N'modelEntityDescriptor', N'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'reportingTagDescriptor', N'reportingTagDescriptor', N'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor', @resourceClaimId, @applicationId);
END

IF (NOT EXISTS(SELECT 1 FROM ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor' AND Application_ApplicationId = @applicationId))
BEGIN
    INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
    VALUES (N'submissionStatusDescriptor', N'submissionStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor', @resourceClaimId, @applicationId);
END

