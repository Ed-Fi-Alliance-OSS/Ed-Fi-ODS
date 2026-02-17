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
    -- Resource Claim: 'https://purl.imsglobal.org/spec/or/v1p2/scope'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'https://purl.imsglobal.org/spec/or/v1p2/scope'
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
            VALUES ('scope', 'https://purl.imsglobal.org/spec/or/v1p2/scope', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeople'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of https://purl.imsglobal.org/spec/or/v1p2/scope
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster-core'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster-core'
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
            VALUES ('roster-core', 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster-core', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    -- Processing claim sets for https://purl.imsglobal.org/spec/or/v1p2/scope/roster-core
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
    

    -- Claim set-specific Read authorization
    PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadActionId) -- Read

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster'
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
            VALUES ('roster', 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    -- Processing claim sets for https://purl.imsglobal.org/spec/or/v1p2/scope/roster
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
    

    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster-demographics'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster-demographics'
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
            VALUES ('roster-demographics', 'https://purl.imsglobal.org/spec/or/v1p2/scope/roster-demographics', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    -- Processing claim sets for https://purl.imsglobal.org/spec/or/v1p2/scope/roster-demographics
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
    

    -- Claim set-specific Read authorization
    PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadActionId) -- Read

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'https://purl.imsglobal.org/spec/or/v1p2/scope/resource'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'https://purl.imsglobal.org/spec/or/v1p2/scope/resource'
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
            VALUES ('resource', 'https://purl.imsglobal.org/spec/or/v1p2/scope/resource', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    -- Processing claim sets for https://purl.imsglobal.org/spec/or/v1p2/scope/resource
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
    

    -- Claim set-specific Delete authorization
    PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @DeleteActionId) -- Delete

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'https://purl.imsglobal.org/spec/or/v1p2/scope/gradebook'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'https://purl.imsglobal.org/spec/or/v1p2/scope/gradebook'
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
            VALUES ('gradebook', 'https://purl.imsglobal.org/spec/or/v1p2/scope/gradebook', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ELSE
        BEGIN
            IF @parentResourceClaimId != @existingParentResourceClaimId OR (@parentResourceClaimId IS NULL AND @existingParentResourceClaimId IS NOT NULL) OR (@parentResourceClaimId IS NOT NULL AND @existingParentResourceClaimId IS NULL)
            BEGIN
                PRINT 'Moving claim ''' + @claimName + ''' (ResourceClaimId=' + CONVERT(nvarchar, @claimId) + ') to be a child of a different resource claim (ResourceClaimId=' + CONVERT(nvarchar, @parentResourceClaimId) + ')'

                UPDATE dbo.ResourceClaims
                SET ParentResourceClaimId = @parentResourceClaimId
                WHERE ResourceClaimId = @claimId
            END
        END

    -- Processing claim sets for https://purl.imsglobal.org/spec/or/v1p2/scope/gradebook
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
    

    -- Claim set-specific Read authorization
    PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadActionId) -- Read

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    

    -- Claim set-specific Create authorization
    PRINT 'Creating ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @CreateActionId) -- Create

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    

    -- Claim set-specific Update authorization
    PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @UpdateActionId) -- Update

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    COMMIT TRANSACTION
END