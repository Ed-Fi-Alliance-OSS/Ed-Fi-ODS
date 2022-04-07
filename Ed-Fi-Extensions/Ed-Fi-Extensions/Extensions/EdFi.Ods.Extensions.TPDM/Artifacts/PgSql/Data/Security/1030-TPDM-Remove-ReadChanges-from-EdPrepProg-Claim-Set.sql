-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
DECLARE claim_set_id int;
DECLARE action_id int;

BEGIN
    -- Remove ReadChanges action from all the 'Education Preparation Program' permissions
    SELECT ActionId INTO action_id FROM dbo.Actions WHERE ActionName = 'ReadChanges';
    SELECT ClaimSetId INTO claim_set_id FROM dbo.ClaimSets WHERE ClaimSetName = 'Education Preparation Program';

    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE Action_ActionId = action_id AND ClaimSet_ClaimSetId = claim_set_id;
END $$;
