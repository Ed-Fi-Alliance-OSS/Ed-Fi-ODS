-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Remove Ed-Fi ODS Admin App ClaimSet
DO $$
DECLARE
    claim_set_id INTEGER;
    claim_set_name VARCHAR(255);	
BEGIN

    claim_set_name := 'Ed-Fi ODS Admin App';
    claim_set_id := NULL;

    SELECT claimsetid INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

	-- Check if ClaimSetId was found
	IF claim_set_id IS NOT NULL THEN
	
		-- Delete associated ClaimSetResourceClaimActionAuthorizationStrategyOverrides
		DELETE 
		FROM dbo.claimsetresourceclaimactionauthorizationstrategyoverrides
		WHERE ClaimSetResourceClaimActionId IN (
			SELECT ClaimSetResourceClaimActionId 
			FROM dbo.ClaimSetResourceClaimActions
			WHERE claimsetid = claim_set_id
		);
		
		-- Delete associated ClaimSetResourceClaimActions
		DELETE FROM dbo.ClaimSetResourceClaimActions 
		WHERE claimsetid = claim_set_id;

		-- Delete the ClaimSet itself
		DELETE FROM dbo.ClaimSets 
		WHERE claimsetid = claim_set_id;

		RAISE NOTICE 'ClaimSet ''Ed-Fi ODS Admin App'' and associated records deleted successfully.';

	ELSE
		RAISE NOTICE 'ClaimSet ''Ed-Fi ODS Admin App'' not found.';		
	END IF;

END $$;