-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

------------------------------ dbo.ResourceClaimActions -------------------------------------------------
CREATE TABLE dbo.ResourceClaimActions(
	ResourceClaimActionId SERIAL NOT NULL,
	ResourceClaimId INT NOT NULL,
	ActionId INT NOT NULL,
	ValidationRuleSetName VARCHAR NULL,
 CONSTRAINT ResourceClaimActionId_PK PRIMARY KEY
(
	ResourceClaimActionId 
));

CREATE UNIQUE INDEX IF NOT EXISTS ResourceClaimActions_UI_ResourceClaimId_ActionId ON dbo.ResourceClaimActions(ResourceClaimId,ActionId);

ALTER TABLE dbo.ResourceClaimActions  ADD  CONSTRAINT FK_ResourceClaimActions_Actions FOREIGN KEY(ActionId)
REFERENCES dbo.Actions (ActionId);


ALTER TABLE dbo.ResourceClaimActions  ADD  CONSTRAINT FK_ResourceClaimActions_ResourceClaims FOREIGN KEY(ResourceClaimId)
REFERENCES dbo.ResourceClaims (ResourceClaimId)
ON DELETE CASCADE;

---------------------------- dbo.ClaimSetResourceClaimActions --------------------------------------------------------

CREATE TABLE dbo.ClaimSetResourceClaimActions(
	ClaimSetResourceClaimActionId SERIAL NOT NULL,
	ClaimSetId INT NOT NULL,
	ResourceClaimId INT NOT NULL,
	ActionId INT NOT NULL,
	ValidationRuleSetNameOverride VARCHAR NULL,
 CONSTRAINT ClaimSetResourceClaimActions_PK PRIMARY KEY  
(
	ClaimSetResourceClaimActionId 
));

CREATE UNIQUE INDEX IF NOT EXISTS ClaimSetResourceClaimActions_UI_ClaimSetId_ResourceClaimId_ActionId ON dbo.ClaimSetResourceClaimActions(ClaimSetId,ResourceClaimId,ActionId);

ALTER TABLE dbo.ClaimSetResourceClaimActions ADD CONSTRAINT FK_ClaimSetResourceClaimActions_Actions FOREIGN KEY(ActionId)
REFERENCES dbo.Actions (ActionId);


ALTER TABLE dbo.ClaimSetResourceClaimActions ADD CONSTRAINT FK_ClaimSetResourceClaimActions_ClaimSets FOREIGN KEY(ClaimSetId)
REFERENCES dbo.ClaimSets (ClaimSetId)
ON DELETE CASCADE;

ALTER TABLE dbo.ClaimSetResourceClaimActions  ADD  CONSTRAINT FK_ClaimSetResourceClaimActions_ResourceClaims FOREIGN KEY(ResourceClaimId)
REFERENCES dbo.ResourceClaims (ResourceClaimId);



---------------------------- dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides --------------------------------------------------------


CREATE TABLE dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(
	ClaimSetResourceClaimActionAuthorizationStrategyOverrideId SERIAL NOT NULL,
	ClaimSetResourceClaimActionId INT NOT NULL,
	AuthorizationStrategyId INT NOT NULL,
 CONSTRAINT ClaimSetResourceClaimActionAuthorizationStrategyOverrides_PK PRIMARY KEY  
(
	ClaimSetResourceClaimActionAuthorizationStrategyOverrideId 
));

CREATE UNIQUE INDEX IF NOT EXISTS ActionAuthorizationStrategyOverrides_UI_ClaimSetResourceClaimActionId_AuthorizationStrategyId ON dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(ClaimSetResourceClaimActionId,AuthorizationStrategyId);

ALTER TABLE dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides  ADD  CONSTRAINT FK_ActionAuthorizationStrategyOverrides_AuthorizationStrategies FOREIGN KEY(AuthorizationStrategyId)
REFERENCES dbo.AuthorizationStrategies (AuthorizationStrategyId)
ON DELETE CASCADE;


ALTER TABLE dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides  ADD  CONSTRAINT FK_ActionAuthorizationStrategyOverrides_ActionAuthorizations FOREIGN KEY(ClaimSetResourceClaimActionId)
REFERENCES dbo.ClaimSetResourceClaimActions (ClaimSetResourceClaimActionId);

------------------------------ dbo.ResourceClaimActionAuthorizationStrategies -------------------------------------------------

CREATE TABLE dbo.ResourceClaimActionAuthorizationStrategies(
	ResourceClaimActionAuthorizationStrategyId SERIAL NOT NULL,
	ResourceClaimActionId INT NOT NULL,
	AuthorizationStrategyId INT NOT NULL,
 CONSTRAINT ResourceClaimActionAuthorizationStrategies_PK PRIMARY KEY
(
	ResourceClaimActionAuthorizationStrategyId 
));

CREATE UNIQUE INDEX IF NOT EXISTS ResourceClaimActionAuthorizationStrategies_UI_ResourceClaimActionId_AuthorizationStrategyId ON dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId,AuthorizationStrategyId);

ALTER TABLE dbo.ResourceClaimActionAuthorizationStrategies   ADD  CONSTRAINT FK_ActionAuthorizationStrategies_AuthorizationStrategyId FOREIGN KEY(AuthorizationStrategyId)
REFERENCES dbo.AuthorizationStrategies (AuthorizationStrategyId)
ON DELETE CASCADE;

ALTER TABLE dbo.ResourceClaimActionAuthorizationStrategies   ADD  CONSTRAINT FK_ActionAuthorizationStrategies_ActionAuthorizationId FOREIGN KEY(ResourceClaimActionId)
REFERENCES dbo.ResourceClaimActions (ResourceClaimActionId);
