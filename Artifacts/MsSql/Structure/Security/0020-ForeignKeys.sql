-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [dbo].[AuthorizationStrategies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AuthorizationStrategies_dbo.Applications_Application_ApplicationId] FOREIGN KEY([Application_ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ClaimSetResourceClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaims_dbo.Actions_Action_ActionId] FOREIGN KEY([Action_ActionId])
REFERENCES [dbo].[Actions] ([ActionId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ClaimSetResourceClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaims_dbo.AuthorizationStrategies_AuthorizationStrategyOverride_AuthorizationStrategyId] FOREIGN KEY([AuthorizationStrategyOverride_AuthorizationStrategyId])
REFERENCES [dbo].[AuthorizationStrategies] ([AuthorizationStrategyId])
GO

ALTER TABLE [dbo].[ClaimSetResourceClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaims_dbo.ClaimSets_ClaimSet_ClaimSetId] FOREIGN KEY([ClaimSet_ClaimSetId])
REFERENCES [dbo].[ClaimSets] ([ClaimSetId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ClaimSetResourceClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaims_dbo.ResourceClaims_ResourceClaim_ResourceClaimId] FOREIGN KEY([ResourceClaim_ResourceClaimId])
REFERENCES [dbo].[ResourceClaims] ([ResourceClaimId])
GO

ALTER TABLE [dbo].[ClaimSets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSets_dbo.Applications_Application_ApplicationId] FOREIGN KEY([Application_ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ResourceClaimAuthorizationMetadatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimAuthorizationStrategies_dbo.Actions_Action_ActionId] FOREIGN KEY([Action_ActionId])
REFERENCES [dbo].[Actions] ([ActionId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ResourceClaimAuthorizationMetadatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimAuthorizationStrategies_dbo.AuthorizationStrategies_AuthorizationStrategy_AuthorizationStrategyId] FOREIGN KEY([AuthorizationStrategy_AuthorizationStrategyId])
REFERENCES [dbo].[AuthorizationStrategies] ([AuthorizationStrategyId])
GO

ALTER TABLE [dbo].[ResourceClaimAuthorizationMetadatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimAuthorizationStrategies_dbo.ResourceClaims_ResourceClaim_ResourceClaimId] FOREIGN KEY([ResourceClaim_ResourceClaimId])
REFERENCES [dbo].[ResourceClaims] ([ResourceClaimId])
GO

ALTER TABLE [dbo].[ResourceClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaims_dbo.Applications_Application_ApplicationId] FOREIGN KEY([Application_ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ResourceClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaims_dbo.ResourceClaims_ParentResourceClaimId] FOREIGN KEY([ParentResourceClaimId])
REFERENCES [dbo].[ResourceClaims] ([ResourceClaimId])
GO