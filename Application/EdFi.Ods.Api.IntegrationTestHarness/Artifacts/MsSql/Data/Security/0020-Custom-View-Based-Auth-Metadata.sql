
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
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation'
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
            VALUES ('studentProgramAssociation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/studentProgramAssociation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation'
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
            VALUES ('studentSpecialEducationProgramEligibilityAssociation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/studentSpecialEducationProgramEligibilityAssociation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibility'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibility''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibility''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation'
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
            VALUES ('studentTransportation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/studentTransportation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeople''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeople''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsAndPeopleIncludingDeletes''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'TransportationTypeDescriptorWithABus'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''TransportationTypeDescriptorWithABus''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''TransportationTypeDescriptorWithABus''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating'
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
            VALUES ('accountabilityRating', 'http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/accountabilityRating
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'EducationOrganizationWithACategoryContainingAnSWord'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''EducationOrganizationWithACategoryContainingAnSWord''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''EducationOrganizationWithACategoryContainingAnSWord''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount'
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
            VALUES ('chartOfAccount', 'http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/chartOfAccount
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'StudentWithCTECourseEnrollments'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''StudentWithCTECourseEnrollments''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''StudentWithCTECourseEnrollments''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('assessmentMetadata', 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment'
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
            VALUES ('studentAssessment', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/studentAssessment
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Create'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @CreateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Update'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @UpdateActionId) + ').'

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
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)

    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''RelationshipsWithEdOrgsOnly''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''RelationshipsWithEdOrgsOnly''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''Delete'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @DeleteActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Claim set-specific ReadChanges authorization
    PRINT 'Creating ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @ReadChangesActionId) -- ReadChanges

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    
    
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = 'AssessmentWithAnACTIdentifier'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''AssessmentWithAnACTIdentifier''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''AssessmentWithAnACTIdentifier''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''ReadChanges'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadChangesActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)

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

            INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
            VALUES ('primaryRelationships', 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/primaryRelationships
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation'
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
            VALUES ('studentSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/studentSchoolAssociation
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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
    
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of http://ed-fi.org/ods/identity/claims/domains/people
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: 'http://ed-fi.org/ods/identity/claims/ed-fi/student'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/student'
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
            VALUES ('student', 'http://ed-fi.org/ods/identity/claims/ed-fi/student', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
    
    -- Processing claim sets for http://ed-fi.org/ods/identity/claims/ed-fi/student
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: 'Custom View Test'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = 'Custom View Test'
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

    
    

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)


    COMMIT TRANSACTION
END
