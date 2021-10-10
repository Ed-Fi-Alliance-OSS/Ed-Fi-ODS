-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  
BEGIN
    DECLARE 
        @applicationId AS INT,
        @claimId AS INT,
        @claimName AS nvarchar(max),
        @parentResourceClaimId AS INT,
        @existingParentResourceClaimId AS INT,
        @claimSetId AS INT,
        @claimSetName AS nvarchar(max),
        @authorizationStrategyId AS INT,
        @msg AS nvarchar(max),
        @createActionId AS INT,
        @readActionId AS INT,
        @updateActionId AS INT,
        @deleteActionId AS INT,
		@readChangesActionId AS INT

    DECLARE @claimIdStack AS TABLE (Id INT IDENTITY, ResourceClaimId INT)

    SELECT @applicationId = ApplicationId
    FROM [dbo].[Applications] WHERE ApplicationName = 'Ed-Fi ODS API';

    SELECT @createActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Create';

    SELECT @readActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Read';

    SELECT @updateActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Update';

    SELECT @deleteActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Delete';

	SELECT @readChangesActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'ReadChanges';

    BEGIN TRANSACTION

    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of root
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('systemDescriptors', 'systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'NoFurtherAuthorizationRequired'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('managedDescriptors', 'managedDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/managedDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'NoFurtherAuthorizationRequired'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('educationOrganizations', 'educationOrganizations', 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/educationOrganizations
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'NoFurtherAuthorizationRequired'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/people'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/people'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('people', 'people', 'http://ed-fi.org/ods/identity/claims/domains/people', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('relationshipBasedData', 'relationshipBasedData', 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('assessmentMetadata', 'assessmentMetadata', 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'NamespaceBased'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/educationStandards'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/educationStandards'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('educationStandards', 'educationStandards', 'http://ed-fi.org/ods/identity/claims/domains/educationStandards', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/educationStandards
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'NamespaceBased'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('primaryRelationships', 'primaryRelationships', 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/primaryRelationships
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/educationContent'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/educationContent'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId, @existingParentResourceClaimId = ParentResourceClaimId
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    SELECT @parentResourceClaimId = ResourceClaimId
    FROM @claimIdStack
    WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    IF @claimId IS NULL
        BEGIN
            PRINT 'Creating new claim: ' + @claimName

            INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
            VALUES ('educationContent', 'educationContent', 'http://ed-fi.org/ods/identity/claims/educationContent', @parentResourceClaimId, @applicationId)

            SET @claimId = SCOPE_IDENTITY()
        END
    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Repointing claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to new parent (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/educationContent
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi Sandbox'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi Sandbox'
    SET @claimSetId = NULL

    SELECT @claimSetId = ClaimSetId
    FROM dbo.ClaimSets
    WHERE ClaimSetName = @claimSetName

    IF @claimSetId IS NULL
    BEGIN
        PRINT 'Creating new claim set: ' + @claimSetName

        INSERT INTO dbo.ClaimSets(ClaimSetName, Application_ApplicationId)
        VALUES (@claimSetName, @applicationId)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'
    ELSE
        PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @CreateActionId, @authorizationStrategyId) -- Create

    -- Claim set-specific Read authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    ELSE
        PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadActionId, @authorizationStrategyId) -- Read

    -- Claim set-specific Update authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'
    ELSE
        PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @UpdateActionId, @authorizationStrategyId) -- Update

    -- Claim set-specific Delete authorization
    SET @authorizationStrategyId = NULL
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'
    ELSE
        PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @DeleteActionId, @authorizationStrategyId) -- Delete

    -- Claim set-specific ReadChanges authorization
    SET @authorizationStrategyId = NULL
    

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'NamespaceBased'
    

    IF @authorizationStrategyId IS NULL
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'
    ELSE
        PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ', authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ').'
        
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId, AuthorizationStrategyOverride_AuthorizationStrategyId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId, @authorizationStrategyId) -- ReadChanges

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    COMMIT TRANSACTION
END