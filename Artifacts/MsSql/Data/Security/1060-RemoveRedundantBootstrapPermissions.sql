    -- SPDX-License-Identifier: Apache-2.0
    -- Licensed to the Ed-Fi Alliance under one or more agreements.
    -- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
    -- See the LICENSE and NOTICES files in the project root for more information.

    DECLARE @claim_Name NVARCHAR(MAX) = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations';
    DECLARE @claimSet_Name NVARCHAR(MAX) = 'Bootstrap Descriptors and EdOrgs';
    DECLARE @educationOrganizationsResourceClaimId INT;
    DECLARE @claimSet_Id INT;
    DECLARE @msg NVARCHAR(MAX);
    DECLARE @messageText NVARCHAR(MAX);
    DECLARE @createActionId INT;
    DECLARE @authorizationStrategyId INT;

    SELECT @authorizationStrategyId=AuthorizationStrategyId FROM dbo.AuthorizationStrategies where DisplayName='No Further Authorization Required'
    SELECT @createActionId =ActionId FROM dbo.Actions where ActionName='Create'

    --New message for claimname does not exist error
    EXEC sys.sp_addmessage
    @msgnum = 50001,
    @severity = 1,
    @msgtext = N'ClaimName ''%s'' does not exist.',
    @with_log = true,
    @replace = 'REPLACE',
    @lang = 'us_english';

    IF NOT  EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = @claim_Name)
    BEGIN
        SET @messageText =  FORMATMESSAGE(50001,@claim_Name);
        THROW 50001, @messageText, 1
    END

    --New message for ClaimSetName does not exist error
    EXEC sys.sp_addmessage
    @msgnum = 50002,
    @severity = 1,
    @msgtext = N'ClaimSetName ''%s'' does not exist.',
    @with_log = true,
    @replace = 'REPLACE',
    @lang = 'us_english';

    IF NOT  EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = @claimSet_Name)
    BEGIN
        SET @messageText =  FORMATMESSAGE(50002,@claimSet_Name);
        THROW 50002, @messageText, 1
    END

    SELECT	@educationOrganizationsResourceClaimId = ResourceClaimId
    FROM	dbo.ResourceClaims rc
    WHERE	rc.ClaimName = @claim_Name

    SELECT	@claimSet_Id = claimSetId
    FROM	dbo.ClaimSets rc
    WHERE	rc.ClaimSetName = @claimSet_Name

    DELETE FROM dbo.ClaimSetResourceClaims 
    WHERE  ClaimSetResourceClaimId IN (SELECT ClaimSetResourceClaimId
    FROM   dbo.ClaimSetResourceClaims csrc
    WHERE  csrc.ClaimSet_ClaimSetId = @claimSet_Id
    AND csrc.Action_ActionId = @createActionId
    AND csrc.AuthorizationStrategyOverride_AuthorizationStrategyId = @authorizationStrategyId
    AND csrc.ResourceClaim_ResourceClaimId IN 
    (SELECT  ResourceClaimId
    FROM	dbo.ResourceClaims rc
    WHERE	rc.ParentResourceClaimId = @educationOrganizationsResourceClaimId))