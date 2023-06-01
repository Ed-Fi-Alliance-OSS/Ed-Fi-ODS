-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

        DECLARE @claimSetId INT;
        DECLARE @applicationId INT;

        SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = 'Ed-Fi ODS API');

        IF  EXISTS(SELECT 1 FROM [dbo].[ClaimSets] WHERE [ClaimSetName] ='Ownership Based Test' AND Application_ApplicationId = @applicationId)
        BEGIN
        PRINT 'Deleting ''Ownership Based Test'' claimset data from  ''EdFi_Security'' database';
        SELECT @claimSetId = claimsetid FROM [dbo].[ClaimSets] 
        WHERE [ClaimSetName] ='Ownership Based Test' AND Application_ApplicationId = @applicationId

        DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides WHERE ClaimSetResourceClaimActionId 
        IN (SELECT ClaimSetResourceClaimActionId FROM dbo.claimsetresourceclaimactions WHERE claimsetid =@claimSetId)

        DELETE FROM dbo.ClaimSetResourceClaimActions where claimsetid =@claimSetId

        DELETE FROM [dbo].[ClaimSets]  WHERE [ClaimSetName] ='Ownership Based Test' AND Application_ApplicationId = @applicationId

        END