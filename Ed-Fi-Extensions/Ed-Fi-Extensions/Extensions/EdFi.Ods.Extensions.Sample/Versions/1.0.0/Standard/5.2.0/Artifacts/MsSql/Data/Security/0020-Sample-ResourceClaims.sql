
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  
BEGIN
    DECLARE 
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
        @readChangesActionId AS INT,
        @resourceClaimActionId AS INT,
        @claimSetResourceClaimActionId AS INT

    DECLARE @claimIdStack AS TABLE (Id INT IDENTITY, ResourceClaimId INT)

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
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/sample'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/sample'
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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('sample', 'http://ed-fi.org/ods/identity/claims/domains/sample', @parentResourceClaimId)

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
  
    -- Setting default authorization metadata
    PRINT 'Deleting default action authorizations for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    
    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = @claimId);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = @claimId
    
    -- Default Create authorization
    PRINT 'Creating action ''Create'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (@claimId, @CreateActionId)

    SET @resourceClaimActionId = SCOPE_IDENTITY()

    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Default Read authorization
    PRINT 'Creating action ''Read'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (@claimId, @ReadActionId)

    SET @resourceClaimActionId = SCOPE_IDENTITY()

    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Default Update authorization
    PRINT 'Creating action ''Update'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (@claimId, @UpdateActionId)

    SET @resourceClaimActionId = SCOPE_IDENTITY()

    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Default Delete authorization
    PRINT 'Creating action ''Delete'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (@claimId, @DeleteActionId)

    SET @resourceClaimActionId = SCOPE_IDENTITY()

    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Default ReadChanges authorization
    PRINT 'Creating action ''ReadChanges'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (@claimId, @ReadChangesActionId)

    SET @resourceClaimActionId = SCOPE_IDENTITY()

    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NoFurtherAuthorizationRequired'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/sample
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

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (@claimSetName)

        SET @claimSetId = SCOPE_IDENTITY()
    END
  
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @claimId)

    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @claimId
    

    -- Claim set-specific Create authorization
    PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @CreateActionId) -- Create

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    

    -- Claim set-specific Read authorization
    PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadActionId) -- Read

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    

    -- Claim set-specific Update authorization
    PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @UpdateActionId) -- Update

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    

    -- Claim set-specific Delete authorization
    PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @DeleteActionId) -- Delete

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    

    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/sample
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/sample/bus'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/sample/bus'
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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('bus', 'http://ed-fi.org/ods/identity/claims/sample/bus', @parentResourceClaimId)

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
  
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/sample/busRoute'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/sample/busRoute'
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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('busRoute', 'http://ed-fi.org/ods/identity/claims/sample/busRoute', @parentResourceClaimId)

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
  

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    COMMIT TRANSACTION

    -- TODO: Remove - For interactive development only
	-- SELECT dbo.GetAuthorizationMetadataDocument();
    -- ROLLBACK TRANSACTION
END
