-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
authorizationStrategy_Id INT;
resourceClaim_Id INT;
application_Id INT;
BEGIN

    SELECT authorizationstrategyId INTO authorizationStrategy_Id   FROM dbo.AuthorizationStrategies  WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';
	
    SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/balanceSheetDimension';

    -- Create CRUD action claims for balanceSheetDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  balanceSheetDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/functionDimension';

    -- Create CRUD action claims for functionDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  functionDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/fundDimension';

    -- Create CRUD action claims for fundDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  fundDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/objectDimension';

    -- Create CRUD action claims for objectDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  objectDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/operationalUnitDimension';

    -- Create CRUD action claims for operationalUnitDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  operationalUnitDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/programDimension';

    -- Create CRUD action claims for programDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  programDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	 SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/projectDimension';

    -- Create CRUD action claims for projectDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  projectDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/sourceDimension';

    -- Create CRUD action claims for sourceDimension
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  sourceDimension resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	SELECT authorizationstrategyId INTO authorizationStrategy_Id   FROM dbo.AuthorizationStrategies  WHERE AuthorizationStrategyName = 'NamespaceBased';
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/descriptorMapping';

    -- Create CRUD action claims for descriptorMapping
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  descriptorMapping resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;

    -- Descriptor Resources Claims That May Be Missing if Upgrading
SELECT applicationid INTO application_id FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

SELECT ResourceClaimId INTO resourceClaim_Id
FROM dbo.ResourceClaims 
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors';

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'accountTypeDescriptor', N'accountTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'assignmentLateStatusDescriptor', N'assignmentLateStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/chartOfAccount' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'chartOfAccount', N'chartOfAccount', N'http://ed-fi.org/ods/identity/claims/chartOfAccount', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/descriptorMapping' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'descriptorMapping', N'descriptorMapping', N'http://ed-fi.org/ods/identity/claims/descriptorMapping', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'financialCollectionDescriptor', N'financialCollectionDescriptor', N'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localAccount' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'localAccount', N'localAccount', N'http://ed-fi.org/ods/identity/claims/localAccount', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localActual' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'localActual', N'localActual', N'http://ed-fi.org/ods/identity/claims/localActual', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localBudget' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'localBudget', N'localBudget', N'http://ed-fi.org/ods/identity/claims/localBudget', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localContractedStaff' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'localContractedStaff', N'localContractedStaff', N'http://ed-fi.org/ods/identity/claims/localContractedStaff', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localEncumbrance' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'localEncumbrance', N'localEncumbrance', N'http://ed-fi.org/ods/identity/claims/localEncumbrance', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/localPayroll' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'localPayroll', N'localPayroll', N'http://ed-fi.org/ods/identity/claims/localPayroll', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'modelEntityDescriptor', N'modelEntityDescriptor', N'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'reportingTagDescriptor', N'reportingTagDescriptor', N'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor', resourceClaim_Id, application_id);
END IF;

IF (NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = N'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor' AND Application_ApplicationId = application_id)) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'submissionStatusDescriptor', N'submissionStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor', resourceClaim_Id, application_id);
END IF;

END $$; 