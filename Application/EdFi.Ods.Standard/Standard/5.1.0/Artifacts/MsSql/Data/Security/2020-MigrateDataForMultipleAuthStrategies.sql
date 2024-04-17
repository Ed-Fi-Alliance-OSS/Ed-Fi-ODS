-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ResourceClaimAuthorizationMetadatas')
BEGIN

    -- ResourceClaimAuthorizationMetadatas -> ResourceClaimActions
    MERGE INTO dbo.ResourceClaimActions target
    USING (
        SELECT
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
            ValidationRuleSetName
        FROM dbo.ResourceClaimAuthorizationMetadatas
    ) AS source
    ON target.ResourceClaimId = source.ResourceClaim_ResourceClaimId
        AND target.ActionId = source.Action_ActionId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ResourceClaimId,
            ActionId,
            ValidationRuleSetName
        )
        VALUES (
            source.ResourceClaim_ResourceClaimId,
            source.Action_ActionId,
            source.ValidationRuleSetName
        );

    -- ResourceClaimAuthorizationMetadatas.AuthorizationStrategy_AuthorizationStrategyId -> ResourceClaimActionAuthorizationStrategies
    MERGE INTO dbo.ResourceClaimActionAuthorizationStrategies target
    USING (
        SELECT
            rca.ResourceClaimActionId,
            rcam.AuthorizationStrategy_AuthorizationStrategyId
        FROM dbo.ResourceClaimAuthorizationMetadatas rcam
        JOIN dbo.ResourceClaimActions rca
            ON rcam.ResourceClaim_ResourceClaimId = rca.ResourceClaimId
                AND rcam.Action_ActionId = rca.ActionId
        WHERE rcam.AuthorizationStrategy_AuthorizationStrategyId IS NOT NULL
    ) AS source
    ON target.ResourceClaimActionId = source.ResourceClaimActionId
        AND target.AuthorizationStrategyId = source.AuthorizationStrategy_AuthorizationStrategyId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ResourceClaimActionId,
            AuthorizationStrategyId
        )
        VALUES (
            source.ResourceClaimActionId,
            source.AuthorizationStrategy_AuthorizationStrategyId
        );

END

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ClaimSetResourceClaims')
BEGIN

    -- ClaimSetResourceClaims -> ClaimSetResourceClaimActions
    MERGE INTO dbo.ClaimSetResourceClaimActions target
    USING (
        SELECT
            ClaimSet_ClaimSetId,
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
            ValidationRuleSetNameOverride
        FROM dbo.ClaimSetResourceClaims
    ) AS source
    ON target.ClaimSetId = source.ClaimSet_ClaimSetId
        AND target.ResourceClaimId = source.ResourceClaim_ResourceClaimId
        AND target.ActionId = source.Action_ActionId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ClaimSetId,
            ResourceClaimId,
            ActionId,
            ValidationRuleSetNameOverride
        )
        VALUES (
            source.ClaimSet_ClaimSetId,
            source.ResourceClaim_ResourceClaimId,
            source.Action_ActionId,
            source.ValidationRuleSetNameOverride
        );

    -- ClaimSetResourceClaims.AuthorizationStrategyOverride_AuthorizationStrategyId -> ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    MERGE INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides target
    USING (
        SELECT
            csrca.ClaimSetResourceClaimActionId,
            csrc.AuthorizationStrategyOverride_AuthorizationStrategyId
        FROM dbo.ClaimSetResourceClaims csrc
        INNER JOIN dbo.ClaimSetResourceClaimActions csrca
            ON csrc.ClaimSet_ClaimSetId = csrca.ClaimSetId
                AND csrc.ResourceClaim_ResourceClaimId = csrca.ResourceClaimId
                AND csrc.Action_ActionId = csrca.ActionId
        WHERE csrc.AuthorizationStrategyOverride_AuthorizationStrategyId IS NOT NULL
    ) AS source
    ON target.ClaimSetResourceClaimActionId = source.ClaimSetResourceClaimActionId
        AND target.AuthorizationStrategyId = source.AuthorizationStrategyOverride_AuthorizationStrategyId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ClaimSetResourceClaimActionId,
            AuthorizationStrategyId
        )
        VALUES (
            source.ClaimSetResourceClaimActionId,
            source.AuthorizationStrategyOverride_AuthorizationStrategyId
        );

END
