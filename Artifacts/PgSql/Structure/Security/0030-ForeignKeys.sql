-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.AuthorizationStrategies ADD CONSTRAINT FK_AuthorizationStrategies_Applications FOREIGN KEY(Application_ApplicationId)
REFERENCES dbo.Applications (ApplicationId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ClaimSetResourceClaims ADD CONSTRAINT FK_ClaimSetResourceClaims_Actions FOREIGN KEY(Action_ActionId)
REFERENCES dbo.Actions (ActionId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ClaimSetResourceClaims ADD CONSTRAINT FK_ClaimSetResourceClaims_AuthorizationStrategies FOREIGN KEY(AuthorizationStrategyOverride_AuthorizationStrategyId)
REFERENCES dbo.AuthorizationStrategies (AuthorizationStrategyId)
;

ALTER TABLE dbo.ClaimSetResourceClaims ADD CONSTRAINT FK_ClaimSetResourceClaims_ClaimSets FOREIGN KEY(ClaimSet_ClaimSetId)
REFERENCES dbo.ClaimSets (ClaimSetId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ClaimSetResourceClaims ADD CONSTRAINT FK_ClaimSetResourceClaims_ResourceClaims FOREIGN KEY(ResourceClaim_ResourceClaimId)
REFERENCES dbo.ResourceClaims (ResourceClaimId)
;

ALTER TABLE dbo.ClaimSets ADD CONSTRAINT FK_ClaimSets_Applications FOREIGN KEY(Application_ApplicationId)
REFERENCES dbo.Applications (ApplicationId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ResourceClaimAuthorizationMetadatas ADD CONSTRAINT FK_ResourceClaimAuthorizationStrategies_Actions FOREIGN KEY(Action_ActionId)
REFERENCES dbo.Actions (ActionId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ResourceClaimAuthorizationMetadatas ADD CONSTRAINT FK_ResourceClaimAuthorizationStrategies_AuthorizationStrategies FOREIGN KEY(AuthorizationStrategy_AuthorizationStrategyId)
REFERENCES dbo.AuthorizationStrategies (AuthorizationStrategyId)
;

ALTER TABLE dbo.ResourceClaimAuthorizationMetadatas ADD CONSTRAINT FK_ResourceClaimAuthorizationStrategies_ResourceClaims FOREIGN KEY(ResourceClaim_ResourceClaimId)
REFERENCES dbo.ResourceClaims (ResourceClaimId)
;

ALTER TABLE dbo.ResourceClaims ADD CONSTRAINT FK_ResourceClaims_Applications FOREIGN KEY(Application_ApplicationId)
REFERENCES dbo.Applications (ApplicationId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ResourceClaims ADD CONSTRAINT FK_ResourceClaims_ResourceClaims FOREIGN KEY(ParentResourceClaimId)
REFERENCES dbo.ResourceClaims (ResourceClaimId)
;