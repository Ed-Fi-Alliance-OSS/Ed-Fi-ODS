-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
DECLARE
    application_id INTEGER;
    claim_set_id INTEGER;
BEGIN

    SELECT applicationid INTO application_id  FROM dbo.applications WHERE ApplicationName = 'Ed-Fi ODS API';

    IF  EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Ownership Based Test' AND Application_ApplicationId = application_Id) THEN

        RAISE NOTICE 'Deleting ''Ownership Based Test'' claimset data from ''EdFi_Security'' database' ;
        SELECT claimsetid INTO claim_set_id FROM dbo.ClaimSets 
        WHERE ClaimSetName ='Ownership Based Test' AND Application_ApplicationId = application_Id;

        DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides WHERE ClaimSetResourceClaimActionId 
        IN (SELECT ClaimSetResourceClaimActionId FROM dbo.claimsetresourceclaimactions WHERE claimsetid =claim_set_id);

        DELETE FROM dbo.ClaimSetResourceClaimActions where claimsetid =claim_set_id;

        DELETE FROM dbo.ClaimSets  WHERE ClaimSetName ='Ownership Based Test' AND Application_ApplicationId = application_Id;
    END IF;

END $$;