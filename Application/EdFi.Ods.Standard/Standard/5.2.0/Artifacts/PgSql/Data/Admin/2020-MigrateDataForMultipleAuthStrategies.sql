-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
BEGIN
    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'resourceclaimauthorizationmetadatas')
    THEN

        -- ResourceClaimAuthorizationMetadatas -> ResourceClaimActions
        WITH source AS (
            SELECT
                ResourceClaim_ResourceClaimId,
                Action_ActionId,
                ValidationRuleSetName
            FROM dbo.ResourceClaimAuthorizationMetadatas
        )
        INSERT INTO dbo.ResourceClaimActions (
            ResourceClaimId,
            ActionId,
            ValidationRuleSetName
        )
        SELECT
            source.ResourceClaim_ResourceClaimId,
            source.Action_ActionId,
            source.ValidationRuleSetName
        FROM source
        ON CONFLICT DO NOTHING;

        -- ResourceClaimAuthorizationMetadatas.AuthorizationStrategy_AuthorizationStrategyId -> ResourceClaimActionAuthorizationStrategies
        WITH source AS (
            SELECT
                rca.ResourceClaimActionId,
                rcam.AuthorizationStrategy_AuthorizationStrategyId
            FROM dbo.ResourceClaimAuthorizationMetadatas rcam
            JOIN dbo.ResourceClaimActions rca
                ON rcam.ResourceClaim_ResourceClaimId = rca.ResourceClaimId
                    AND rcam.Action_ActionId = rca.ActionId
            WHERE rcam.AuthorizationStrategy_AuthorizationStrategyId IS NOT NULL
        )
        INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies (
            ResourceClaimActionId,
            AuthorizationStrategyId
        )
        SELECT
            source.ResourceClaimActionId,
            source.AuthorizationStrategy_AuthorizationStrategyId
        FROM source
        ON CONFLICT DO NOTHING;

    END IF;

    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'claimsetresourceclaims')
    THEN

        -- ClaimSetResourceClaims -> ClaimSetResourceClaimActions
        WITH source AS (
            SELECT
                ClaimSet_ClaimSetId,
                ResourceClaim_ResourceClaimId,
                Action_ActionId,
                ValidationRuleSetNameOverride
            FROM dbo.ClaimSetResourceClaims
        )
        INSERT INTO dbo.ClaimSetResourceClaimActions (
            ClaimSetId,
            ResourceClaimId,
            ActionId,
            ValidationRuleSetNameOverride
        )
        SELECT
            source.ClaimSet_ClaimSetId,
            source.ResourceClaim_ResourceClaimId,
            source.Action_ActionId,
            source.ValidationRuleSetNameOverride
        FROM source
        ON CONFLICT DO NOTHING;

        -- ClaimSetResourceClaims.AuthorizationStrategyOverride_AuthorizationStrategyId -> ClaimSetResourceClaimActionAuthorizationStrategyOverrides
        WITH source AS (
            SELECT
                csrca.ClaimSetResourceClaimActionId,
                csrc.AuthorizationStrategyOverride_AuthorizationStrategyId
            FROM dbo.ClaimSetResourceClaims csrc
            INNER JOIN dbo.ClaimSetResourceClaimActions csrca
                ON csrc.ClaimSet_ClaimSetId = csrca.ClaimSetId
                    AND csrc.ResourceClaim_ResourceClaimId = csrca.ResourceClaimId
                    AND csrc.Action_ActionId = csrca.ActionId
            WHERE csrc.AuthorizationStrategyOverride_AuthorizationStrategyId IS NOT NULL
        )
        INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides (
            ClaimSetResourceClaimActionId,
            AuthorizationStrategyId
        )
        SELECT
            source.ClaimSetResourceClaimActionId,
            source.AuthorizationStrategyOverride_AuthorizationStrategyId
        FROM source
        ON CONFLICT DO NOTHING;

    END IF;
END $$
