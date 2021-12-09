-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Create and configure Ed-Fi ODS Admin App claim set
DO $$
    DECLARE application_name varchar(50) := 'Ed-Fi ODS API';
    DECLARE application_id int;
    DECLARE claimset_name varchar(50) := 'Ed-Fi ODS Admin App';
    DECLARE claimset_id int;
	DECLARE authorizationStrategy_id int;
BEGIN
	SELECT applicationid INTO application_id
    FROM dbo.applications
    WHERE applicationname = application_name;
	
	-- Creating Ed-Fi ODS Admin App claim set
	IF EXISTS (SELECT 1 FROM dbo.claimsets WHERE claimsetname = claimset_name)
    THEN
        RAISE NOTICE '% claimset exists', claimset_name;
    ELSE
        RAISE NOTICE 'adding % claimset', claimset_name;
        INSERT INTO dbo.claimsets (claimsetname, application_applicationid) VALUES (claimset_name, application_id);
    END IF;	

    -- Configure Ed-Fi ODS Admin App claim set
	
	SELECT claimsetid INTO claimset_id
    FROM dbo.claimsets
    WHERE claimsetname = claimset_name;
	
	DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizations WHERE ClaimSet_ClaimSetId = claimset_id;
	
	SELECT authorizationstrategyid INTO authorizationStrategy_id
    FROM dbo.authorizationstrategies
    WHERE authorizationstrategyname = 'NoFurtherAuthorizationRequired';
	
    IF EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActionAuthorizations WHERE claimset_claimsetid = claimset_id)
    THEN
        RAISE NOTICE 'claims already exist for claim %', claimset_name;
    ELSE
        RAISE NOTICE 'Configuring Claims for % Claimset...', claimset_name;
        INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
            (Action_ActionId
            ,ClaimSet_ClaimSetId
            ,ResourceClaim_ResourceClaimId)
        SELECT ac.actionid, claimset_id, resourceclaimid
        FROM dbo.resourceclaims
        INNER JOIN LATERAL
            (SELECT actionid
            FROM dbo.actions
            WHERE actionname in ('Create','Read','Update','Delete')) AS ac ON true
        WHERE resourcename IN ('educationOrganizations','systemDescriptors','managedDescriptors');
		
		INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
            (AuthorizationStrategy_AuthorizationStrategyId
            ,ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId)
        SELECT authorizationStrategy_id, ClaimSetResourceClaimActionAuthorizationId
        FROM dbo.ClaimSetResourceClaimActionAuthorizations
        INNER JOIN dbo.ResourceClaims ON ResourceClaim_ResourceClaimId = ResourceClaimId
        WHERE resourcename IN ('educationOrganizations','systemDescriptors','managedDescriptors');
		
    END IF;	
	
	INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
		(Action_ActionId
		,ClaimSet_ClaimSetId
		,ResourceClaim_ResourceClaimId)
	SELECT ac.actionid, claimset_id, resourceclaimid
	FROM dbo.resourceclaims
	INNER JOIN LATERAL
		(SELECT actionid
		FROM dbo.actions
		WHERE actionname in ('Read')) AS ac ON true
	WHERE resourcename IN ('types');
	
	INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
		(AuthorizationStrategy_AuthorizationStrategyId
		,ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId)
	SELECT authorizationStrategy_id, ClaimSetResourceClaimActionAuthorizationId
	FROM dbo.ClaimSetResourceClaimActionAuthorizations
	INNER JOIN dbo.ResourceClaims ON ResourceClaim_ResourceClaimId = ResourceClaimId
	INNER JOIN dbo.Actions ON ActionId = Action_ActionId AND ActionName in ('READ')
	WHERE resourcename IN ('types');
END $$;

-- Create and configure AB Connect claim set
DO $$
    DECLARE application_name varchar(50) := 'Ed-Fi ODS API';
    DECLARE application_id int;
    DECLARE claimset_name varchar(50) := 'AB Connect';
    DECLARE claimset_id int;
BEGIN

    IF NOT EXISTS (SELECT 1 FROM dbo.applications WHERE applicationname = application_name)
    THEN
        RAISE NOTICE '% does not exist', application_name;
    END IF;

    SELECT applicationid INTO application_id
    FROM dbo.applications
    WHERE applicationname = application_name;

    -- Create AB Connect ClaimSet
    IF EXISTS (SELECT 1 FROM dbo.claimsets WHERE claimsetname = claimset_name)
    THEN
        RAISE NOTICE '% claimset exists', claimset_name;
    ELSE
        RAISE NOTICE 'adding % claimset', claimset_name;
        INSERT INTO dbo.claimsets (claimsetname, application_applicationid) VALUES (claimset_name, application_id);
    END IF;
	
    SELECT claimsetid INTO claimset_id
    FROM dbo.claimsets
    WHERE claimsetname = claimset_name;
	
	DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizations WHERE ClaimSet_ClaimSetId = claimset_id;

    -- Configure AB Connect ClaimSet
    IF EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActionAuthorizations WHERE claimset_claimsetid = claimset_id)
    THEN
        RAISE NOTICE 'claims already exist for claim %', claimset_name;
    ELSE
        RAISE NOTICE 'Configuring Claims for % Claimset...', claimset_name;
        INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
            (Action_ActionId
            ,ClaimSet_ClaimSetId
            ,ResourceClaim_ResourceClaimId)
        SELECT ac.actionid, claimset_id, resourceclaimid
        FROM dbo.resourceclaims
        INNER JOIN LATERAL
            (SELECT actionid
            FROM dbo.actions
            WHERE actionname in ('Create','Read','Update','Delete')) AS ac ON true
        WHERE resourcename IN ('gradeLevelDescriptor','academicSubjectDescriptor','publicationStatusDescriptor','educationStandards');
    END IF;
END $$;

-- Set educationStandards to not require further authorization for READ 
DO $$
    DECLARE authorization_strategy_id int;
    DECLARE resource_claim_id int;
    DECLARE action_id int;
BEGIN
    SELECT authorizationstrategyid INTO authorization_strategy_id
    FROM dbo.authorizationstrategies
    WHERE authorizationstrategyname = 'NoFurtherAuthorizationRequired';

    SELECT resourceclaimid INTO resource_claim_id
    FROM dbo.resourceclaims
    WHERE resourcename = 'educationStandards';

    SELECT actionid INTO action_id
    FROM dbo.actions
    WHERE actionname = 'Read';

    RAISE NOTICE 'Updating educationStandards authorization strategy for READ.';

    UPDATE dbo.ResourceClaimActionAuthorizationStrategies
    SET authorizationstrategy_authorizationstrategyid = authorization_strategy_id
	INNER JOIN dbo.ResourceClaimActionAuthorizations
		ON ResourceClaimActionAuthorizationId = ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId
    WHERE action_actionid = action_id AND resourceclaim_resourceclaimid = resource_claim_id;
END $$;

-- Add performanceLevel descriptor to the assessment vendor claimset (if not already present)
DO $$
    DECLARE resourceclaim_id int;
    DECLARE claimset_id int;
BEGIN
    SELECT resourceclaimid into resourceclaim_id
    FROM dbo.resourceclaims
    WHERE resourcename = 'performanceLevelDescriptor';

    SELECT claimsetid into claimset_id
    FROM dbo.claimsets
    WHERE claimsetname = 'Assessment Vendor';

    IF EXISTS (SELECT 1
               FROM dbo.ClaimSetResourceClaimActionAuthorizations 
               WHERE claimset_claimsetid = claimset_id AND resourceclaim_resourceclaimid = resourceclaim_id)
    THEN
        DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizations WHERE ResourceClaim_ResourceClaimId = resourceclaim_id AND ClaimSet_ClaimSetId = claimset_id;
    END IF;
	
	RAISE NOTICE 'Ensuring create, read actions for performanceLevelDescriptor are assigned to Assessment Vendor claimset';
    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations
        (Action_ActionId
        ,ClaimSet_ClaimSetId
        ,ResourceClaim_ResourceClaimId)
    SELECT ac.actionid, claimset_id, resourceclaimid
    FROM dbo.resourceclaims
    INNER JOIN LATERAL
    (SELECT actionid
        FROM dbo.actions
        WHERE actionname IN ('Create','Read')) AS ac ON true
    WHERE resourceclaimid = resourceclaim_id;
		
END $$;