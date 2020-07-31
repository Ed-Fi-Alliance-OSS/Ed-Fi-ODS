-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS IX_AuthorizationStrategies_Application_ApplicationId
    ON dbo.AuthorizationStrategies(Application_ApplicationId);
;

CREATE INDEX IF NOT EXISTS IX_ClaimSetResourceClaims_Action_ActionId
    ON dbo.ClaimSetResourceClaims(Action_ActionId);
;

CREATE INDEX IF NOT EXISTS IX_ClaimSetResourceClaims_AuthStratOver_AuthStratId
    ON dbo.ClaimSetResourceClaims(AuthorizationStrategyOverride_AuthorizationStrategyId);
;

CREATE INDEX IF NOT EXISTS IX_ClaimSetResourceClaims_ClaimSet_ClaimSetId
    ON dbo.ClaimSetResourceClaims(ClaimSet_ClaimSetId);
;

CREATE INDEX IF NOT EXISTS IX_ClaimSetResourceClaims_ResourceClaim_ResourceClaimId
    ON dbo.ClaimSetResourceClaims(ResourceClaim_ResourceClaimId);
;

CREATE INDEX IF NOT EXISTS IX_ClaimSets_Application_ApplicationId
    ON dbo.ClaimSets(Application_ApplicationId);
;

CREATE INDEX IF NOT EXISTS IX_ResourceClaimAuthorizationMetadatas_Action_ActionId
    ON dbo.ResourceClaimAuthorizationMetadatas(Action_ActionId);
;

CREATE INDEX IF NOT EXISTS IX_ResourceClaimAuthorizationMetadatas_AuthStrat_AuthStratId
    ON dbo.ResourceClaimAuthorizationMetadatas(AuthorizationStrategy_AuthorizationStrategyId);
;

CREATE INDEX IF NOT EXISTS IX_ResourceClaimAuthorizationMetadatas_ResCla_ResClaId
    ON dbo.ResourceClaimAuthorizationMetadatas(ResourceClaim_ResourceClaimId);
;

CREATE INDEX IF NOT EXISTS IX_ResourceClaims_Application_ApplicationId
    ON dbo.ResourceClaims(Application_ApplicationId);
;

CREATE INDEX IF NOT EXISTS IX_ResourceClaims_ParentResourceClaimId
    ON dbo.ResourceClaims(ParentResourceClaimId);
;