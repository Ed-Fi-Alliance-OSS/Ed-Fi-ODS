-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

    DO language plpgsql $$
    DECLARE
        claim_Name VARCHAR(250) := 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations';
        claimSet_Name VARCHAR(250) := 'Bootstrap Descriptors and EdOrgs';
        educationOrganizationsResourceClaimId INT;
        claimSet_Id INT;
        createAction_Id INT;
        authorizationStrategy_Id INT;

    BEGIN

        SELECT AuthorizationStrategyId INTO authorizationStrategy_Id FROM dbo.AuthorizationStrategies WHERE DisplayName='No Further Authorization Required';
        SELECT ActionId INTO createAction_Id FROM dbo.Actions WHERE ActionName='Create';

        IF NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = claim_Name)
        THEN
            RAISE EXCEPTION 'ClaimName ''%'' not found.', claim_Name;
        END IF;

        IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = claimSet_Name)
        THEN
            RAISE EXCEPTION 'ClaimSetName ''%'' not found.', claimSet_Name;
        END IF;

        SELECT ResourceClaimId INTO educationOrganizationsResourceClaimId
        FROM dbo.ResourceClaims
        WHERE ClaimName = claim_Name;

        SELECT claimSetId INTO claimSet_Id
        FROM dbo.ClaimSets
        WHERE ClaimSetName = claimSet_Name;

        DELETE FROM dbo.ClaimSetResourceClaims 
        WHERE ClaimSetResourceClaimId IN  
            (SELECT ClaimSetResourceClaimId  FROM dbo.ClaimSetResourceClaims 
            WHERE ClaimSet_ClaimSetId = claimSet_Id
                AND Action_ActionId = createAction_Id
                AND AuthorizationStrategyOverride_AuthorizationStrategyId = authorizationStrategy_Id
                AND ResourceClaim_ResourceClaimId IN 
                    (SELECT  ResourceClaimId  FROM dbo.ResourceClaims 
                    WHERE ParentResourceClaimId = educationOrganizationsResourceClaimId));

    END $$;