-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE NONCLUSTERED INDEX [IX_Application_ApplicationId]
    ON [dbo].[AuthorizationStrategies]([Application_ApplicationId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Action_ActionId]
    ON [dbo].[ClaimSetResourceClaims]([Action_ActionId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_AuthorizationStrategyOverride_AuthorizationStrategyId]
    ON [dbo].[ClaimSetResourceClaims]([AuthorizationStrategyOverride_AuthorizationStrategyId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ClaimSet_ClaimSetId]
    ON [dbo].[ClaimSetResourceClaims]([ClaimSet_ClaimSetId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ResourceClaim_ResourceClaimId]
    ON [dbo].[ClaimSetResourceClaims]([ResourceClaim_ResourceClaimId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Application_ApplicationId]
    ON [dbo].[ClaimSets]([Application_ApplicationId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Action_ActionId]
    ON [dbo].[ResourceClaimAuthorizationMetadatas]([Action_ActionId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_AuthorizationStrategy_AuthorizationStrategyId]
    ON [dbo].[ResourceClaimAuthorizationMetadatas]([AuthorizationStrategy_AuthorizationStrategyId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ResourceClaim_ResourceClaimId]
    ON [dbo].[ResourceClaimAuthorizationMetadatas]([ResourceClaim_ResourceClaimId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Application_ApplicationId]
    ON [dbo].[ResourceClaims]([Application_ApplicationId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ParentResourceClaimId]
    ON [dbo].[ResourceClaims]([ParentResourceClaimId] ASC);
GO