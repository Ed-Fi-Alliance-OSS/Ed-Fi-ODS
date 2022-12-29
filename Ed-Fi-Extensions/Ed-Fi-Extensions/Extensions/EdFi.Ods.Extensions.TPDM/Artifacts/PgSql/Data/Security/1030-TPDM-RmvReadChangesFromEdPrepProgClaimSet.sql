-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Renamed from 1030-TPDM-Remove-ReadChanges-from-EdPrepProg-Claim-Set.sql to shorten file name.

DO $$
DECLARE claim_set_id int;
DECLARE action_id int;

BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Actions WHERE ActionName = 'ReadChanges') AND EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = 'Education Preparation Program') THEN
        -- Remove ReadChanges action from all the 'Education Preparation Program' permissions
        SELECT ActionId INTO action_id FROM dbo.Actions WHERE ActionName = 'ReadChanges';
        SELECT ClaimSetId INTO claim_set_id FROM dbo.ClaimSets WHERE ClaimSetName = 'Education Preparation Program';

        IF EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = action_id AND ClaimSetId = claim_set_id) THEN
            DELETE FROM dbo.ClaimSetResourceClaimActions
            WHERE ActionId = action_id AND ClaimSetId = claim_set_id;
        END IF;
    END IF;
END $$;
