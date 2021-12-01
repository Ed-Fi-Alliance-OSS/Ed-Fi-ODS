-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ResourceClaimAuthorizationMetadatas')
BEGIN

    -- ResourceClaimAuthorizationMetadatas -> ResourceClaimActionAuthorizations
    MERGE INTO dbo.ResourceClaimActionAuthorizations target
    USING (
        SELECT
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
            ValidationRuleSetName
        FROM dbo.ResourceClaimAuthorizationMetadatas
    ) AS source
    ON target.ResourceClaim_ResourceClaimId = source.ResourceClaim_ResourceClaimId
        AND target.Action_ActionId = source.Action_ActionId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
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
        SELECT rcaa.ResourceClaimActionAuthorizationId, rcam.AuthorizationStrategy_AuthorizationStrategyId
        FROM dbo.ResourceClaimAuthorizationMetadatas rcam
        JOIN dbo.ResourceClaimActionAuthorizations rcaa
            ON rcam.ResourceClaim_ResourceClaimId = rcaa.ResourceClaim_ResourceClaimId
                AND rcam.Action_ActionId = rcaa.Action_ActionId
        WHERE rcam.AuthorizationStrategy_AuthorizationStrategyId IS NOT NULL
    ) AS source
    ON target.ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId = source.ResourceClaimActionAuthorizationId
        AND target.AuthorizationStrategy_AuthorizationStrategyId = source.AuthorizationStrategy_AuthorizationStrategyId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId,
            AuthorizationStrategy_AuthorizationStrategyId
        )
        VALUES (
            source.ResourceClaimActionAuthorizationId,
            source.AuthorizationStrategy_AuthorizationStrategyId
        );

END

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ClaimSetResourceClaims')
BEGIN

    -- ClaimSetResourceClaims -> ClaimSetResourceClaimActionAuthorizations
    MERGE INTO dbo.ClaimSetResourceClaimActionAuthorizations target
    USING (
        SELECT
            ClaimSet_ClaimSetId,
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
            ValidationRuleSetNameOverride
        FROM dbo.ClaimSetResourceClaims
    ) AS source
    ON target.ClaimSet_ClaimSetId = source.ClaimSet_ClaimSetId
        AND target.ResourceClaim_ResourceClaimId = source.ResourceClaim_ResourceClaimId
        AND target.Action_ActionId = source.Action_ActionId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ClaimSet_ClaimSetId,
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
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
        SELECT csrcaa.ClaimSetResourceClaimActionAuthorizationId, csrc.AuthorizationStrategyOverride_AuthorizationStrategyId
        FROM dbo.ClaimSetResourceClaims csrc
        INNER JOIN dbo.ClaimSetResourceClaimActionAuthorizations csrcaa
            ON csrc.ClaimSet_ClaimSetId = csrcaa.ClaimSet_ClaimSetId
                AND csrc.ResourceClaim_ResourceClaimId = csrcaa.ResourceClaim_ResourceClaimId
                AND csrc.Action_ActionId = csrcaa.Action_ActionId
        WHERE csrc.AuthorizationStrategyOverride_AuthorizationStrategyId IS NOT NULL
    ) AS source
    ON target.ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId = source.ClaimSetResourceClaimActionAuthorizationId
        AND target.AuthorizationStrategy_AuthorizationStrategyId = source.AuthorizationStrategyOverride_AuthorizationStrategyId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId,
            AuthorizationStrategy_AuthorizationStrategyId
        )
        VALUES (
            source.ClaimSetResourceClaimActionAuthorizationId,
            source.AuthorizationStrategyOverride_AuthorizationStrategyId
        );

END
