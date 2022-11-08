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
	
    SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor';

    -- Create CRUD action claims for educationOrganizationAssociationTypeDescriptor
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  educationOrganizationAssociationTypeDescriptor resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation';

    -- Create CRUD action claims for studentAssessmentEducationOrganizationAssociation
	INSERT INTO dbo.ResourceClaimActions (ActionId ,ResourceClaimId ,ValidationRuleSetName)
	SELECT a.ActionId ,ResourceClaimId ,NULL FROM dbo.ResourceClaims RC
	CROSS JOIN dbo.Actions a
	WHERE ResourceClaimId = resourceClaim_Id;
	
	--- 'NoFurtherAuthorizationRequired' AuthorizationStrategyName added for  studentAssessmentEducationOrganizationAssociation resource
	INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
	SELECT RCA.ResourceClaimActionId,authorizationStrategy_Id FROM dbo.ResourceClaimActionS RCA 
	INNER JOIN dbo.ResourceClaims RC ON RCA.ResourceClaimId = RC.ResourceClaimId
	INNER JOIN dbo.Actions A ON RCA.ActionId = A.ActionId
	WHERE RCA.ResourceClaimId = resourceClaim_Id;
	
	

END $$; 