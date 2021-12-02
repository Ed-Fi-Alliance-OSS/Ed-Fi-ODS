-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
BEGIN
    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'resourceclaimauthorizationmetadatas')
    THEN

        -- ResourceClaimAuthorizationMetadatas -> ResourceClaimActionAuthorizations
        WITH source AS (
            SELECT
                ResourceClaim_ResourceClaimId,
                Action_ActionId,
                ValidationRuleSetName
            FROM dbo.ResourceClaimAuthorizationMetadatas
        )
        INSERT INTO dbo.ResourceClaimActionAuthorizations (
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
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
                rcaa.ResourceClaimActionAuthorizationId,
                rcam.AuthorizationStrategy_AuthorizationStrategyId
            FROM dbo.ResourceClaimAuthorizationMetadatas rcam
            JOIN dbo.ResourceClaimActionAuthorizations rcaa
                ON rcam.ResourceClaim_ResourceClaimId = rcaa.ResourceClaim_ResourceClaimId
                    AND rcam.Action_ActionId = rcaa.Action_ActionId
            WHERE rcam.AuthorizationStrategy_AuthorizationStrategyId IS NOT NULL
        )
        INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies (
            ResourceClaimActionAuthorization_ClaimActionAuthId,
            AuthorizationStrategy_AuthorizationStrategyId
        )
        SELECT
            source.ResourceClaimActionAuthorizationId,
            source.AuthorizationStrategy_AuthorizationStrategyId
        FROM source
        ON CONFLICT DO NOTHING;

    END IF;

    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'claimsetresourceclaims')
    THEN

        -- ClaimSetResourceClaims -> ClaimSetResourceClaimActionAuthorizations
        WITH source AS (
            SELECT
                ClaimSet_ClaimSetId,
                ResourceClaim_ResourceClaimId,
                Action_ActionId,
                ValidationRuleSetNameOverride
            FROM dbo.ClaimSetResourceClaims
        )
        INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizations (
            ClaimSet_ClaimSetId,
            ResourceClaim_ResourceClaimId,
            Action_ActionId,
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
                csrcaa.ClaimSetResourceClaimActionAuthorizationId,
                csrc.AuthorizationStrategyOverride_AuthorizationStrategyId
            FROM dbo.ClaimSetResourceClaims csrc
            INNER JOIN dbo.ClaimSetResourceClaimActionAuthorizations csrcaa
                ON csrc.ClaimSet_ClaimSetId = csrcaa.ClaimSet_ClaimSetId
                    AND csrc.ResourceClaim_ResourceClaimId = csrcaa.ResourceClaim_ResourceClaimId
                    AND csrc.Action_ActionId = csrcaa.Action_ActionId
            WHERE csrc.AuthorizationStrategyOverride_AuthorizationStrategyId IS NOT NULL
        )
        INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides (
            ClaimSetResourceClaimActionAuthorization_ClaimActionAuthId,
            AuthorizationStrategy_AuthorizationStrategyId
        )
        SELECT
            source.ClaimSetResourceClaimActionAuthorizationId,
            source.AuthorizationStrategyOverride_AuthorizationStrategyId
        FROM source
        ON CONFLICT DO NOTHING;

    END IF;
END $$
