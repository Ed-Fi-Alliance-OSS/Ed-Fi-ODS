
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
  
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/systemDescriptors
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor'
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
            VALUES ('academicSubjectDescriptor', 'academicSubjectDescriptor', 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor', @parentResourceClaimId, @applicationId)

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
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'AB Connect'
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
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor'
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
            VALUES ('gradeLevelDescriptor', 'gradeLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor', @parentResourceClaimId, @applicationId)

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
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'AB Connect'
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
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor'
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
            VALUES ('publicationStatusDescriptor', 'publicationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor', @parentResourceClaimId, @applicationId)

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
  
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'AB Connect'
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

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

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
    -- Claim set: 'AB Connect'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'AB Connect'
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

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    COMMIT TRANSACTION
END
