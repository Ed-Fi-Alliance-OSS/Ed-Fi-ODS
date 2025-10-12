<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="text" />
<!-- Transform online at: https://xslttest.appspot.com/ -->
<!-- Transform online at: https://www.freeformatter.com/xsl-transformer.html -->

<xsl:template match="/">
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  <xsl:apply-templates select="SecurityMetadata" />
</xsl:template>

<xsl:template match="/" mode="SqlServer">
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  <xsl:apply-templates select="SecurityMetadata" mode="SqlServer" />
</xsl:template>

<xsl:template match="/" mode="PostgreSql">
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  <xsl:apply-templates select="SecurityMetadata" mode="PostgreSql" />
</xsl:template>

<!-- SqlServer support -->
<xsl:template match="SecurityMetadata" mode="SqlServer">
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
<xsl:apply-templates select="Claims" mode="SqlServer" />

    COMMIT TRANSACTION
END
</xsl:template>

<xsl:template match="Claims" mode="SqlServer">
    -- Push claimId to the stack
    INSERT INTO @claimIdStack (ResourceClaimId) VALUES (@claimId)

    -- Processing children of <xsl:value-of select="../@name" /><xsl:if test="not(../@name)">root</xsl:if>

    <xsl:apply-templates select="Claim" mode="SqlServer" />

    -- Pop the stack
    DELETE FROM @claimIdStack WHERE Id = (SELECT Max(Id) FROM @claimIdStack)
</xsl:template>

<xsl:template match="Claim" mode="SqlServer">
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: '<xsl:value-of select="@name" />'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimName = '<xsl:value-of select="@name" />'
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
            VALUES ('<xsl:value-of select="tokenize(@name, '/')[last()]" />', '<xsl:value-of select="@name" />', @parentResourceClaimId)

            SET @claimId = SCOPE_IDENTITY()
        END
<xsl:if test="/*/@modifyHierarchy = 'true'">
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
</xsl:if>
  <xsl:apply-templates select="DefaultAuthorization" mode="SqlServer" />
  <xsl:apply-templates select="ClaimSets" mode="SqlServer" />
  <xsl:apply-templates select="Claims" mode="SqlServer" />
</xsl:template>

<xsl:template match="DefaultAuthorization" mode="SqlServer">
    -- Setting default authorization metadata
    PRINT 'Deleting default action authorizations for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    
    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = @claimId);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = @claimId
    <xsl:apply-templates select="Action" mode="SqlServer-DefaultAuthorization" />
</xsl:template>

<xsl:template match="Action" mode="SqlServer-DefaultAuthorization">
    -- Default <xsl:value-of select="@name" /> authorization
    PRINT 'Creating action ''<xsl:value-of select="@name" />'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (@claimId, @<xsl:value-of select="@name" />ActionId)

    SET @resourceClaimActionId = SCOPE_IDENTITY()

    <xsl:apply-templates select="AuthorizationStrategies/AuthorizationStrategy" mode="SqlServer-DefaultAuthorization" />
</xsl:template>

<xsl:template match="AuthorizationStrategy" mode="SqlServer-DefaultAuthorization">
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = '<xsl:value-of select="@name" />'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''<xsl:value-of select="@name" />''';
        THROW 50000, @msg, 1
    END

    PRINT 'Adding authorization strategy ''<xsl:value-of select="@name" />'' for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@resourceClaimActionId, @authorizationStrategyId)

</xsl:template>

<xsl:template match="ClaimSets" mode="SqlServer">
    -- Processing claim sets for <xsl:value-of select="../@name" />
    <xsl:apply-templates select="ClaimSet" mode="SqlServer" />
</xsl:template>

<xsl:template match="ClaimSet" mode="SqlServer">
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: '<xsl:value-of select="@name" />'
    ----------------------------------------------------------------------------------------------------------------------------
    SET @claimSetName = '<xsl:value-of select="@name" />'
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
  <xsl:apply-templates select="Actions" mode="SqlServer-ClaimSet" />
</xsl:template>

<xsl:template match="Actions" mode="SqlServer-ClaimSet">
    PRINT 'Deleting existing actions for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ') on resource claim ''' + @claimName + '''.'

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @claimId)

    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = @claimSetId AND ResourceClaimId = @claimId
    <xsl:apply-templates select="Action" mode="SqlServer-ClaimSet" />
</xsl:template>

<xsl:template match="Action" mode="SqlServer-ClaimSet">

    -- Claim set-specific <xsl:value-of select="@name" /> authorization
    PRINT 'Creating ''<xsl:value-of select="@name"/>'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @<xsl:value-of select="@name" />ActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (@claimId, @claimSetId, @<xsl:value-of select="@name" />ActionId) -- <xsl:value-of select="@name" />

    SET @claimSetResourceClaimActionId = SCOPE_IDENTITY()

    <!-- Apply overrides -->
    <xsl:apply-templates select="AuthorizationStrategyOverrides/AuthorizationStrategy" mode="SqlServer-ClaimSet" />
</xsl:template>

<xsl:template match="AuthorizationStrategy" mode="SqlServer-ClaimSet">
    SET @authorizationStrategyId = NULL

    SELECT @authorizationStrategyId = a.AuthorizationStrategyId
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = '<xsl:value-of select="@name" />'

    IF @authorizationStrategyId IS NULL
    BEGIN
        SET @msg = 'AuthorizationStrategy does not exist: ''<xsl:value-of select="@name" />''';
        THROW 50000, @msg, 1
    END

    PRINT 'Creating authorization strategy override entry of ''<xsl:value-of select="@name" />''' + '(authorizationStrategyId = ' + CONVERT(nvarchar, @authorizationStrategyId) + ' for ''<xsl:value-of select="../../@name"/>'' action for claim set ''' + @claimSetName + ''' (claimSetId=' + CONVERT(nvarchar, @claimSetId) + ', actionId = ' + CONVERT(nvarchar, @<xsl:value-of select="../../@name" />ActionId) + ').'

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (@claimSetResourceClaimActionId, @authorizationStrategyId)
</xsl:template>

<!-- PostgreSql support -->
<xsl:template match="SecurityMetadata" mode="PostgreSql">
DO $$
DECLARE
    claim_id INTEGER;
    claim_name VARCHAR(2048);
    parent_resource_claim_id INTEGER;
    existing_parent_resource_claim_id INTEGER;
    claim_set_id INTEGER;
    claim_set_name VARCHAR(255);
    authorization_strategy_id INTEGER;
    create_action_id INTEGER;
    read_action_id INTEGER;
    update_action_id INTEGER;
    delete_action_id INTEGER;
    readchanges_action_id INTEGER;
    resource_claim_action_id INTEGER;
    claim_set_resource_claim_action_id INTEGER;
    claim_id_stack INTEGER ARRAY;
BEGIN
    SELECT actionid INTO create_action_id
    FROM dbo.actions WHERE ActionName = 'Create';

    SELECT actionid INTO read_action_id
    FROM dbo.actions WHERE ActionName = 'Read';

    SELECT actionid INTO update_action_id
    FROM dbo.actions WHERE ActionName = 'Update';

    SELECT actionid INTO delete_action_id
    FROM dbo.actions WHERE ActionName = 'Delete';

    SELECT actionid INTO readchanges_action_id
    FROM dbo.actions WHERE ActionName = 'ReadChanges';
    
<xsl:apply-templates select="Claims" mode="PostgreSql" />
    COMMIT;

    -- TODO: Remove - For interactive development only
    -- SELECT dbo.GetAuthorizationMetadataDocument();
    -- ROLLBACK;
END $$;
</xsl:template>

<xsl:template match="Claims" mode="PostgreSql">
    -- Push claimId to the stack
    claim_id_stack := array_append(claim_id_stack, claim_id);

    -- Processing children of <xsl:value-of select="../@name" /><xsl:if test="not(../@name)">root</xsl:if>

    <xsl:apply-templates select="Claim" mode="PostgreSql" />

    -- Pop the stack
    claim_id_stack := (select claim_id_stack[1:array_upper(claim_id_stack, 1) - 1]);
</xsl:template>

<xsl:template match="Claim" mode="PostgreSql">
    ----------------------------------------------------------------------------------------------------------------------------
    -- Resource Claim: '<xsl:value-of select="@name" />'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_name := '<xsl:value-of select="@name" />';
    claim_id := NULL;

    SELECT ResourceClaimId, ParentResourceClaimId INTO claim_id, existing_parent_resource_claim_id
    FROM dbo.ResourceClaims
    WHERE ClaimName = claim_name;

    parent_resource_claim_id := claim_id_stack[array_upper(claim_id_stack, 1)];

    IF claim_id IS NULL THEN
        RAISE NOTICE 'Creating new claim: %', claim_name;

        INSERT INTO dbo.ResourceClaims(ResourceName, ClaimName, ParentResourceClaimId)
        VALUES ('<xsl:value-of select="tokenize(@name, '/')[last()]" />', '<xsl:value-of select="@name" />', parent_resource_claim_id)
        RETURNING ResourceClaimId
        INTO claim_id;
<xsl:if test="/*/@modifyHierarchy = 'true'">
    ELSE
        IF parent_resource_claim_id != existing_parent_resource_claim_id OR (parent_resource_claim_id IS NULL AND existing_parent_resource_claim_id IS NOT NULL) OR (parent_resource_claim_id IS NOT NULL AND existing_parent_resource_claim_id IS NULL) THEN
            RAISE NOTICE USING MESSAGE = 'Moving claim ''' || claim_name || ''' (ResourceClaimId=' || claim_id || ') to be a child of a different resource claim (from ResourceClaimId=' || COALESCE(existing_parent_resource_claim_id, 0) || ' to ResourceClaimId=' || COALESCE(parent_resource_claim_id, 0) || ')';

            UPDATE dbo.ResourceClaims
            SET ParentResourceClaimId = parent_resource_claim_id
            WHERE ResourceClaimId = claim_id;
        END IF;
</xsl:if>
    END IF;
  <xsl:apply-templates select="DefaultAuthorization" mode="PostgreSql" />
  <xsl:apply-templates select="ClaimSets" mode="PostgreSql" />
  <xsl:apply-templates select="Claims" mode="PostgreSql" />
</xsl:template>

<xsl:template match="DefaultAuthorization" mode="PostgreSql">
    -- Setting default authorization metadata
    RAISE NOTICE USING MESSAGE = 'Deleting default action authorizations for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    DELETE FROM dbo.ResourceClaimActionAuthorizationStrategies
    WHERE ResourceClaimActionId IN (SELECT ResourceClaimActionId FROM dbo.ResourceClaimActions WHERE ResourceClaimId = claim_id);

    DELETE FROM dbo.ResourceClaimActions
    WHERE ResourceClaimId = claim_id;

    <xsl:apply-templates select="Action" mode="PostgreSql-DefaultAuthorization" />
</xsl:template>

<xsl:template match="Action" mode="PostgreSql-DefaultAuthorization">
    -- Default <xsl:value-of select="@name" /> authorization
    RAISE NOTICE USING MESSAGE = 'Creating action ''<xsl:value-of select="@name" />'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';

    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    VALUES (claim_id, <xsl:value-of select="@name" />_action_id)
    RETURNING ResourceClaimActionId
    INTO resource_claim_action_id;

    <xsl:apply-templates select="AuthorizationStrategies/AuthorizationStrategy" mode="PostgreSql-DefaultAuthorization" />
</xsl:template>

<xsl:template match="AuthorizationStrategy" mode="PostgreSql-DefaultAuthorization">
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = '<xsl:value-of select="@name" />';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''<xsl:value-of select="@name" />''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Adding authorization strategy ''<xsl:value-of select="@name" />'' for resource claim ''' || claim_name || ''' (claimId=' || claim_id || ').';
    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    VALUES (resource_claim_action_id, authorization_strategy_id);
</xsl:template>

<xsl:template match="ClaimSets" mode="PostgreSql">
    -- Processing claimsets for <xsl:value-of select="../@name" />
    <xsl:apply-templates select="ClaimSet" mode="PostgreSql" />
</xsl:template>

<xsl:template match="ClaimSet" mode="PostgreSql">
    ----------------------------------------------------------------------------------------------------------------------------
    -- Claim set: '<xsl:value-of select="@name" />'
    ----------------------------------------------------------------------------------------------------------------------------
    claim_set_name := '<xsl:value-of select="@name" />';
    claim_set_id := NULL;

    SELECT ClaimSetId INTO claim_set_id
    FROM dbo.ClaimSets
    WHERE ClaimSetName = claim_set_name;

    IF claim_set_id IS NULL THEN
        RAISE NOTICE 'Creating new claim set: %', claim_set_name;

        INSERT INTO dbo.ClaimSets(ClaimSetName)
        VALUES (claim_set_name)
        RETURNING ClaimSetId
        INTO claim_set_id;
    END IF;

  <xsl:apply-templates select="Actions" mode="PostgreSql-ClaimSet" />
</xsl:template>

<xsl:template match="Actions" mode="PostgreSql-ClaimSet">
    RAISE NOTICE USING MESSAGE = 'Deleting existing actions for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ') on resource claim ''' || claim_name || '''.';

    DELETE FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    WHERE ClaimSetResourceClaimActionId IN (
        SELECT ClaimSetResourceClaimActionId FROM dbo.ClaimSetResourceClaimActions WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id);
    
    DELETE FROM dbo.ClaimSetResourceClaimActions
    WHERE ClaimSetId = claim_set_id AND ResourceClaimId = claim_id;

    <xsl:apply-templates select="Action" mode="PostgreSql-ClaimSet" />
</xsl:template>

<xsl:template match="Action" mode="PostgreSql-ClaimSet">

    -- Claim set-specific <xsl:value-of select="@name" /> authorization
    RAISE NOTICE USING MESSAGE = 'Creating ''<xsl:value-of select="@name"/>'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || <xsl:value-of select="@name" />_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActions(ResourceClaimId, ClaimSetId, ActionId)
    VALUES (claim_id, claim_set_id, <xsl:value-of select="@name" />_action_id) -- <xsl:value-of select="@name" />
    RETURNING ClaimSetResourceClaimActionId
    INTO claim_set_resource_claim_action_id;

    <!-- Apply overrides -->
    <xsl:apply-templates select="AuthorizationStrategyOverrides/AuthorizationStrategy" mode="PostgreSql-ClaimSet" />
</xsl:template>

<xsl:template match="AuthorizationStrategy" mode="PostgreSql-ClaimSet">
    authorization_strategy_id := NULL;

    SELECT a.AuthorizationStrategyId INTO authorization_strategy_id
    FROM    dbo.AuthorizationStrategies a
    WHERE   a.AuthorizationStrategyName = '<xsl:value-of select="@name" />';

    IF authorization_strategy_id IS NULL THEN
        RAISE EXCEPTION USING MESSAGE = 'AuthorizationStrategy does not exist: ''<xsl:value-of select="@name" />''';
    END IF;

    RAISE NOTICE USING MESSAGE = 'Creating authorization strategy override entry of ''<xsl:value-of select="@name" />''' || '(authorizationStrategyId = ' || authorization_strategy_id || ' for ''<xsl:value-of select="../../@name"/>'' action for claim set ''' || claim_set_name || ''' (claimSetId=' || claim_set_id || ', actionId = ' || <xsl:value-of select="../../@name" />_action_id || ').';

    INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId, AuthorizationStrategyId)
    VALUES (claim_set_resource_claim_action_id, authorization_strategy_id);
</xsl:template>

</xsl:stylesheet>
