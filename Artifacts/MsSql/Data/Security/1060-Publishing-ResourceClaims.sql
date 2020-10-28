BEGIN
    DECLARE 
        @applicationId AS INT,
        @claimId AS INT,
        @claimName AS nvarchar(max),
        @claimSetId AS INT,
        @claimSetName AS nvarchar(max),
		@authorizationStrategyId AS INT,
        @msg AS nvarchar(max),
        @readActionId AS INT

    BEGIN TRANSACTION

    SELECT @applicationId = ApplicationId
    FROM [dbo].[Applications] WHERE ApplicationName = 'Ed-Fi ODS API';
    
    SELECT @readActionId = ActionId
    FROM [dbo].[Actions] WHERE ActionName = 'Read';

    SET @claimName = 'http://ed-fi.org/ods/identity/claims/publishing/snapshot'
    SET @claimId = NULL

    SELECT @claimId = ResourceClaimId 
    FROM dbo.ResourceClaims 
    WHERE ClaimName = @claimName

    IF @claimId IS NULL
    BEGIN
        PRINT 'Creating new claim: ' + @claimName

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('snapshot', 'snapshot', @claimName, null, @applicationId)

        SET @claimId = SCOPE_IDENTITY()
    END     
  
    -- Setting default authorization metadata
    PRINT 'Deleting default action authorizations for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
    WHERE ResourceClaim_ResourceClaimId = @claimId
    
    -- Default Create authorization
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.DisplayName = 'No Further Authorization Required'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''No Further Authorization Required''';
        THROW 50000, @msg, 1
    END

    INSERT INTO dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId, Action_ActionId, AuthorizationStrategy_AuthorizationStrategyId)
    VALUES (@claimId, @readActionId, @authorizationStrategyId)
		
	
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

        SET @claimSetId = @@IDENTITY
    END

    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ').'
    DELETE FROM dbo.ClaimSetResourceClaims
    WHERE ClaimSet_ClaimSetId = @claimSetId AND ResourceClaim_ResourceClaimId = @claimId

  
          
    PRINT 'Creating ''Read'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @ReadActionId) + ').'
    INSERT INTO dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId, ClaimSet_ClaimSetId, Action_ActionId)
    VALUES (@claimId, @claimSetId, @ReadActionId) -- Read
	
	COMMIT TRANSACTION
END