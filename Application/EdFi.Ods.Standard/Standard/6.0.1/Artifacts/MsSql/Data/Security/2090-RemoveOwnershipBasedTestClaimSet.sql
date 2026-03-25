-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

        DECLARE @claimSetId INT;

        IF  EXISTS(SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] ='Ownership Based Test' )
        BEGIN
        PRINT 'Deleting ''Ownership Based Test'' claimset data from  ''EdFi_Security'' database';
        SELECT @claimSetId = claimsetid FROM [dbo].[ClaimSets] 
        WHERE [ClaimSetName] ='Ownership Based Test' 

        DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides WHERE ClaimSetResourceClaimActionId 
        IN (SELECT ClaimSetResourceClaimActionId FROM dbo.claimsetresourceclaimactions WHERE claimsetid =@claimSetId)

        DELETE FROM dbo.ClaimSetResourceClaimActions where claimsetid =@claimSetId

        DELETE FROM [dbo].[ClaimSets]  WHERE [ClaimSetName] ='Ownership Based Test' 

        END