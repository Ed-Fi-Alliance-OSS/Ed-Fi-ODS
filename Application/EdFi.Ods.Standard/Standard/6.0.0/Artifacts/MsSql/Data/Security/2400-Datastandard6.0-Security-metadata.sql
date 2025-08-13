
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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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


    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'SIS Vendor'
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Assessment Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Assessment Vendor'
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
    -- Claim set: 'Bootstrap Descriptors and EdOrgs'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Bootstrap Descriptors and EdOrgs'
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

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'District Hosted SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'District Hosted SIS Vendor'
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
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Reader'
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

    
    

    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Writer'
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

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific Read authorization
    PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadActionId) -- Read

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific Update authorization
    PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @UpdateActionId) -- Update

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific Delete authorization
    PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @DeleteActionId) -- Delete

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Education Preparation Program'
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

    
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/englishLanguageExamDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/englishLanguageExamDescriptor'
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
            VALUES ('englishLanguageExamDescriptor', 'http://ed-fi.org/ods/identity/claims/englishLanguageExamDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ePPProgramPathwayDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ePPProgramPathwayDescriptor'
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
            VALUES ('ePPProgramPathwayDescriptor', 'http://ed-fi.org/ods/identity/claims/ePPProgramPathwayDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationRouteDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/certificationRouteDescriptor'
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
            VALUES ('certificationRouteDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationRouteDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/aidTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/aidTypeDescriptor'
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
            VALUES ('aidTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/aidTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/credentialStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/credentialStatusDescriptor'
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
            VALUES ('credentialStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/credentialStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/educatorRoleDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/educatorRoleDescriptor'
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
            VALUES ('educatorRoleDescriptor', 'http://ed-fi.org/ods/identity/claims/educatorRoleDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/accreditationStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/accreditationStatusDescriptor'
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
            VALUES ('accreditationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/accreditationStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/pathPhaseStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/pathPhaseStatusDescriptor'
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
            VALUES ('pathPhaseStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/pathPhaseStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/pathMilestoneTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/pathMilestoneTypeDescriptor'
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
            VALUES ('pathMilestoneTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/pathMilestoneTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/pathMilestoneStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/pathMilestoneStatusDescriptor'
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
            VALUES ('pathMilestoneStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/pathMilestoneStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/staffToCandidateRelationshipDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/staffToCandidateRelationshipDescriptor'
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
            VALUES ('staffToCandidateRelationshipDescriptor', 'http://ed-fi.org/ods/identity/claims/staffToCandidateRelationshipDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/lengthOfContractDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/lengthOfContractDescriptor'
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
            VALUES ('lengthOfContractDescriptor', 'http://ed-fi.org/ods/identity/claims/lengthOfContractDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationEventResultDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/applicationEventResultDescriptor'
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
            VALUES ('applicationEventResultDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationEventResultDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/applicationEventTypeDescriptor'
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
            VALUES ('applicationEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationEventTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/applicationSourceDescriptor'
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
            VALUES ('applicationSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationSourceDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/applicationStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/applicationStatusDescriptor'
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
            VALUES ('applicationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/applicationStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/backgroundCheckStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/backgroundCheckStatusDescriptor'
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
            VALUES ('backgroundCheckStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/backgroundCheckStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/backgroundCheckTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/backgroundCheckTypeDescriptor'
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
            VALUES ('backgroundCheckTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/backgroundCheckTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationExamStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/certificationExamStatusDescriptor'
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
            VALUES ('certificationExamStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationExamStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationExamTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/certificationExamTypeDescriptor'
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
            VALUES ('certificationExamTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationExamTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationFieldDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/certificationFieldDescriptor'
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
            VALUES ('certificationFieldDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationFieldDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/certificationLevelDescriptor'
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
            VALUES ('certificationLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationLevelDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/certificationStandardDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/certificationStandardDescriptor'
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
            VALUES ('certificationStandardDescriptor', 'http://ed-fi.org/ods/identity/claims/certificationStandardDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/credentialEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/credentialEventTypeDescriptor'
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
            VALUES ('credentialEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/credentialEventTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/degreeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/degreeDescriptor'
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
            VALUES ('degreeDescriptor', 'http://ed-fi.org/ods/identity/claims/degreeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/federalLocaleCodeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/federalLocaleCodeDescriptor'
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
            VALUES ('federalLocaleCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/federalLocaleCodeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/fieldworkTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/fieldworkTypeDescriptor'
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
            VALUES ('fieldworkTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/fieldworkTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/fundingSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/fundingSourceDescriptor'
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
            VALUES ('fundingSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/fundingSourceDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/goalTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/goalTypeDescriptor'
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
            VALUES ('goalTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/goalTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/hireStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/hireStatusDescriptor'
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
            VALUES ('hireStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/hireStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/hiringSourceDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/hiringSourceDescriptor'
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
            VALUES ('hiringSourceDescriptor', 'http://ed-fi.org/ods/identity/claims/hiringSourceDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/instructionalSettingDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/instructionalSettingDescriptor'
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
            VALUES ('instructionalSettingDescriptor', 'http://ed-fi.org/ods/identity/claims/instructionalSettingDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventStatusDescriptor'
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
            VALUES ('openStaffPositionEventStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventStatusDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventTypeDescriptor'
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
            VALUES ('openStaffPositionEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/openStaffPositionEventTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/openStaffPositionReasonDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/openStaffPositionReasonDescriptor'
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
            VALUES ('openStaffPositionReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/openStaffPositionReasonDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/previousCareerDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/previousCareerDescriptor'
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
            VALUES ('previousCareerDescriptor', 'http://ed-fi.org/ods/identity/claims/previousCareerDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/professionalDevelopmentOfferedByDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/professionalDevelopmentOfferedByDescriptor'
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
            VALUES ('professionalDevelopmentOfferedByDescriptor', 'http://ed-fi.org/ods/identity/claims/professionalDevelopmentOfferedByDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/programGatewayDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/programGatewayDescriptor'
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
            VALUES ('programGatewayDescriptor', 'http://ed-fi.org/ods/identity/claims/programGatewayDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/recruitmentEventAttendeeTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/recruitmentEventAttendeeTypeDescriptor'
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
            VALUES ('recruitmentEventAttendeeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/recruitmentEventAttendeeTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureDatatypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureDatatypeDescriptor'
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
            VALUES ('quantitativeMeasureDatatypeDescriptor', 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureDatatypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureTypeDescriptor'
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
            VALUES ('quantitativeMeasureTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/quantitativeMeasureTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/recruitmentEventTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/recruitmentEventTypeDescriptor'
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
            VALUES ('recruitmentEventTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/recruitmentEventTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/salaryTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/salaryTypeDescriptor'
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
            VALUES ('salaryTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/salaryTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/candidateCharacteristicDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/candidateCharacteristicDescriptor'
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
            VALUES ('candidateCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/candidateCharacteristicDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/educatorPreparationProgramTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/educatorPreparationProgramTypeDescriptor'
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
            VALUES ('educatorPreparationProgramTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/educatorPreparationProgramTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ePPDegreeTypeDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ePPDegreeTypeDescriptor'
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
            VALUES ('ePPDegreeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/ePPDegreeTypeDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/withdrawReasonDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/withdrawReasonDescriptor'
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
            VALUES ('withdrawReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/withdrawReasonDescriptor', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm'
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
            VALUES ('tpdm', 'http://ed-fi.org/ods/identity/claims/domains/tpdm', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/tpdm
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Reader'
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

    
    

    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Writer'
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

    
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation'
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
            VALUES ('performanceEvaluation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/performanceEvaluation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluation'
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
            VALUES ('performanceEvaluation', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/evaluation'
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
            VALUES ('evaluation', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjective'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjective'
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
            VALUES ('evaluationObjective', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjective', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElement'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElement'
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
            VALUES ('evaluationElement', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElement', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/rubricDimension'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/rubricDimension'
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
            VALUES ('rubricDimension', 'http://ed-fi.org/ods/identity/claims/tpdm/rubricDimension', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRating'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRating'
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
            VALUES ('evaluationRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationRating', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjectiveRating'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjectiveRating'
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
            VALUES ('evaluationObjectiveRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationObjectiveRating', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRating'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRating'
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
            VALUES ('evaluationElementRating', 'http://ed-fi.org/ods/identity/claims/tpdm/evaluationElementRating', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating'
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
            VALUES ('performanceEvaluationRating', 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasure'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasure'
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
            VALUES ('quantitativeMeasure', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasure', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureScore'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureScore'
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
            VALUES ('quantitativeMeasureScore', 'http://ed-fi.org/ods/identity/claims/tpdm/quantitativeMeasureScore', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/goal'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/goal'
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
            VALUES ('goal', 'http://ed-fi.org/ods/identity/claims/tpdm/goal', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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


    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path'
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
            VALUES ('path', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/path
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/path'
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
            VALUES ('path', 'http://ed-fi.org/ods/identity/claims/tpdm/path', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase'
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
            VALUES ('pathPhase', 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath'
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
            VALUES ('studentPath', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus'
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
            VALUES ('studentPathMilestoneStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus'
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
            VALUES ('studentPathPhaseStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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



    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData'
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
            VALUES ('noFurtherAuthorizationRequiredData', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/noFurtherAuthorizationRequiredData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation'
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
            VALUES ('candidatePreparation', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Education Preparation Program'
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

    
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/candidatePreparation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/candidateEducatorPreparationProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/candidateEducatorPreparationProgramAssociation'
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
            VALUES ('candidateEducatorPreparationProgramAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/candidateEducatorPreparationProgramAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/students'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/students'
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
            VALUES ('students', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/students', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/students
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/financialAid'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/financialAid'
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
            VALUES ('financialAid', 'http://ed-fi.org/ods/identity/claims/tpdm/financialAid', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperience'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperience'
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
            VALUES ('fieldworkExperience', 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperience', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperienceSectionAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperienceSectionAssociation'
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
            VALUES ('fieldworkExperienceSectionAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/fieldworkExperienceSectionAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/pathMilestone'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/pathMilestone'
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
            VALUES ('pathMilestone', 'http://ed-fi.org/ods/identity/claims/tpdm/pathMilestone', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations'
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
            VALUES ('personRoleAssociations', 'http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/personRoleAssociations
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/staffEducatorPreparationProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/staffEducatorPreparationProgramAssociation'
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
            VALUES ('staffEducatorPreparationProgramAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/staffEducatorPreparationProgramAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/candidateRelationshipToStaffAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/candidateRelationshipToStaffAssociation'
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
            VALUES ('candidateRelationshipToStaffAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/candidateRelationshipToStaffAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram'
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
            VALUES ('educatorPreparationProgram', 'http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/tpdm/educatorPreparationProgram
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Bootstrap Descriptors and EdOrgs'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Bootstrap Descriptors and EdOrgs'
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path'
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
            VALUES ('path', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/path', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/path
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/path'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/path'
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
            VALUES ('path', 'http://ed-fi.org/ods/identity/claims/tpdm/path', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase'
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
            VALUES ('pathPhase', 'http://ed-fi.org/ods/identity/claims/tpdm/pathPhase', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath'
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
            VALUES ('studentPath', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPath', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus'
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
            VALUES ('studentPathMilestoneStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathMilestoneStatus', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus'
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
            VALUES ('studentPathPhaseStatus', 'http://ed-fi.org/ods/identity/claims/tpdm/studentPathPhaseStatus', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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



    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials'
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
            VALUES ('credentials', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/credentials
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certification'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/certification'
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
            VALUES ('certification', 'http://ed-fi.org/ods/identity/claims/tpdm/certification', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExam'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExam'
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
            VALUES ('certificationExam', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExam', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamResult'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamResult'
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
            VALUES ('certificationExamResult', 'http://ed-fi.org/ods/identity/claims/tpdm/certificationExamResult', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEvent'
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
            VALUES ('credentialEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/credentialEvent', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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



    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment'
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
            VALUES ('professionalDevelopment', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/professionalDevelopment
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEvent'
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
            VALUES ('professionalDevelopmentEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEvent', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEventAttendance'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEventAttendance'
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
            VALUES ('professionalDevelopmentEventAttendance', 'http://ed-fi.org/ods/identity/claims/tpdm/professionalDevelopmentEventAttendance', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting'
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
            VALUES ('recruiting', 'http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsOnly'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/tpdm/recruiting
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/application'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/application'
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
            VALUES ('application', 'http://ed-fi.org/ods/identity/claims/tpdm/application', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEvent'
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
            VALUES ('applicationEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/applicationEvent', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEvent'
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
            VALUES ('openStaffPositionEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/openStaffPositionEvent', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEvent'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEvent'
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
            VALUES ('recruitmentEvent', 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEvent', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventAttendance'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventAttendance'
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
            VALUES ('recruitmentEventAttendance', 'http://ed-fi.org/ods/identity/claims/tpdm/recruitmentEventAttendance', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProfile'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProfile'
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
            VALUES ('applicantProfile', 'http://ed-fi.org/ods/identity/claims/tpdm/applicantProfile', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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



    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('relationshipBasedData', 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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


    -- Default ReadChanges authorization
    PRINT 'Creating action ''ReadChanges'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (@claimId, @ReadChangesActionId)

    SET @resourceClaimActionId = SCOPE_IDENTITY()

    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'SIS Vendor'
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Assessment Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Assessment Vendor'
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
    -- Claim set: 'District Hosted SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'District Hosted SIS Vendor'
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Reader'
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

    
    

    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Writer'
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

    
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain'
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
            VALUES ('surveyDomain', 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
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
    WHERE   a.AuthorizationStrategyName = 'NamespaceBased'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NamespaceBased''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''NamespaceBased'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/surveyDomain
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Writer'
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

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific Read authorization
    PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadActionId) -- Read

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific Update authorization
    PRINT 'Creating ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @UpdateActionId) -- Update

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific Delete authorization
    PRINT 'Creating ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @DeleteActionId) -- Delete

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'NoFurtherAuthorizationRequired'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''NoFurtherAuthorizationRequired''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''NoFurtherAuthorizationRequired''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Education Preparation Program'
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

    
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/surveyDomain
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponsePersonTargetAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponsePersonTargetAssociation'
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
            VALUES ('surveyResponsePersonTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveyResponsePersonTargetAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponsePersonTargetAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponsePersonTargetAssociation'
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
            VALUES ('surveySectionResponsePersonTargetAssociation', 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionResponsePersonTargetAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionAggregateResponse'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionAggregateResponse'
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
            VALUES ('surveySectionAggregateResponse', 'http://ed-fi.org/ods/identity/claims/tpdm/surveySectionAggregateResponse', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('people', 'http://ed-fi.org/ods/identity/claims/domains/people', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)


    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'SIS Vendor'
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'District Hosted SIS Vendor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'District Hosted SIS Vendor'
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

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Reader'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Reader'
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

    
    

    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Ed-Fi API Publisher - Writer'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Ed-Fi API Publisher - Writer'
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

    
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/tpdm/candidate'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/candidate'
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
            VALUES ('candidate', 'http://ed-fi.org/ods/identity/claims/tpdm/candidate', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
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


    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/tpdm/candidate
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Education Preparation Program'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Education Preparation Program'
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

    
    

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    COMMIT TRANSACTION
END
