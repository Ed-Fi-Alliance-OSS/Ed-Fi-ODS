-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

------------------------------ dbo.ResourceClaimActionAuthorizations -------------------------------------------------
CREATE TABLE dbo.ResourceClaimActionAuthorizations(
	ResourceClaimActionAuthorizationId SERIAL NOT NULL,
	Action_ActionId INT NOT NULL,
	ResourceClaim_ResourceClaimId INT NOT NULL,
	ValidationRuleSetName VARCHAR NULL,
 CONSTRAINT ResourceClaimActionAuthorizations_PK PRIMARY KEY
(
	ResourceClaimActionAuthorizationId 
));


CREATE INDEX IF NOT EXISTS IX_ResourceClaimActionAuthorizations_Action_ActionId
    ON dbo.ResourceClaimActionAuthorizations
	(Action_ActionId);


CREATE INDEX IF NOT EXISTS IX_ActionAuthorizations_ResourceClaimId
    ON dbo.ResourceClaimActionAuthorizations
	(ResourceClaim_ResourceClaimId);


ALTER TABLE dbo.ResourceClaimActionAuthorizations  ADD  CONSTRAINT FK_ResourceClaimActionAuthorizations_Actions FOREIGN KEY(Action_ActionId)
REFERENCES dbo.Actions (ActionId)
ON DELETE CASCADE;


ALTER TABLE dbo.ResourceClaimActionAuthorizations  ADD  CONSTRAINT FK_ResourceClaimActionAuthorizations_ResourceClaims FOREIGN KEY(ResourceClaim_ResourceClaimId)
REFERENCES dbo.ResourceClaims (ResourceClaimId)
ON DELETE CASCADE;

---------------------------- dbo.ClaimSetResourceClaimActionAuthorizations --------------------------------------------------------

CREATE TABLE dbo.ClaimSetResourceClaimActionAuthorizations(
	ClaimSetResourceClaimActionAuthorizationId SERIAL NOT NULL,
	Action_ActionId INT NOT NULL,
	ClaimSet_ClaimSetId INT NOT NULL,
	ResourceClaim_ResourceClaimId INT NOT NULL,
	ValidationRuleSetNameOverride VARCHAR NULL,
 CONSTRAINT ClaimSetResourceClaimActionAuthorizations_PK PRIMARY KEY  
(
	ClaimSetResourceClaimActionAuthorizationId 
));

CREATE INDEX IF NOT EXISTS IX_ClaimSetResourceClaimActionAuthorizations_ActionId
    ON dbo.ClaimSetResourceClaimActionAuthorizations(Action_ActionId);

CREATE INDEX IF NOT EXISTS IX_ClaimSetResourceClaimActionAuthorizations_ClaimSetId
    ON dbo.ClaimSetResourceClaimActionAuthorizations(ClaimSet_ClaimSetId);

CREATE INDEX IF NOT EXISTS IX_ClaimSetResourceClaimActionAuthorizations_ResourceClaimId
    ON dbo.ClaimSetResourceClaimActionAuthorizations(ResourceClaim_ResourceClaimId);


ALTER TABLE dbo.ClaimSetResourceClaimActionAuthorizations ADD CONSTRAINT FK_ClaimSetResourceClaimActionAuthorizations_Actions FOREIGN KEY(Action_ActionId)
REFERENCES dbo.Actions (ActionId)
ON DELETE CASCADE;

ALTER TABLE dbo.ClaimSetResourceClaimActionAuthorizations ADD CONSTRAINT FK_ClaimSetResourceClaimActionAuthorizations_ClaimSets FOREIGN KEY(ClaimSet_ClaimSetId)
REFERENCES dbo.ClaimSets (ClaimSetId)
ON DELETE CASCADE;

ALTER TABLE dbo.ClaimSetResourceClaimActionAuthorizations  ADD  CONSTRAINT FK_ClaimSetResourceClaimActionAuthorizations_ResourceClaims FOREIGN KEY(ResourceClaim_ResourceClaimId)
REFERENCES dbo.ResourceClaims (ResourceClaimId);



---------------------------- dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides --------------------------------------------------------


CREATE TABLE dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides(
	ClaimSetResourceClaimActionAuthorizationStrategyOverrideId SERIAL NOT NULL,
	ClaimSetResourceClaimActionAuthorizationId INT NOT NULL,
	AuthorizationStrategy_AuthorizationStrategyId INT NOT NULL,
 CONSTRAINT ClaimSetResourceClaimActionAuthorizationStrategyOverrides_PK PRIMARY KEY  
(
	ClaimSetResourceClaimActionAuthorizationStrategyOverrideId 
));


CREATE INDEX IF NOT EXISTS IX_ActionAuthorizationStrategyOverrides_AuthorizationStrategyId
    ON dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
	(AuthorizationStrategy_AuthorizationStrategyId);


CREATE INDEX IF NOT EXISTS IX_ActionAuthorizationStrategyOverrides__ClaimActionAuthId
    ON dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
	(ClaimSetResourceClaimActionAuthorizationId);

ALTER TABLE dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides  ADD  CONSTRAINT FK_ActionAuthorizationStrategyOverrides_AuthorizationStrategies FOREIGN KEY(AuthorizationStrategy_AuthorizationStrategyId)
REFERENCES dbo.AuthorizationStrategies (AuthorizationStrategyId)
ON DELETE CASCADE;


ALTER TABLE dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides  ADD  CONSTRAINT FK_ActionAuthorizationStrategyOverrides_ActionAuthorizations FOREIGN KEY(ClaimSetResourceClaimActionAuthorizationId)
REFERENCES dbo.ClaimSetResourceClaimActionAuthorizations (ClaimSetResourceClaimActionAuthorizationId);

------------------------------ dbo.ResourceClaimActionAuthorizationStrategies -------------------------------------------------


CREATE TABLE dbo.ResourceClaimActionAuthorizationStrategies(
	ResourceClaimActionAuthorizationStrategyId SERIAL NOT NULL,
	ResourceClaimActionAuthorizationId INT NOT NULL,
	AuthorizationStrategy_AuthorizationStrategyId INT NOT NULL,
 CONSTRAINT ResourceClaimActionAuthorizationStrategies_PK PRIMARY KEY
(
	ResourceClaimActionAuthorizationStrategyId 
));


CREATE INDEX IF NOT EXISTS IX_ActionAuthorizationStrategies_AuthorizationStrategyId
    ON dbo.ResourceClaimActionAuthorizationStrategies
	(AuthorizationStrategy_AuthorizationStrategyId);

CREATE INDEX IF NOT EXISTS IX_ActionAuthorizationStrategies_ClaimActionAuthId
    ON dbo.ResourceClaimActionAuthorizationStrategies
	(ResourceClaimActionAuthorizationId);


ALTER TABLE dbo.ResourceClaimActionAuthorizationStrategies   ADD  CONSTRAINT FK_ActionAuthorizationStrategies_AuthorizationStrategyId FOREIGN KEY(AuthorizationStrategy_AuthorizationStrategyId)
REFERENCES dbo.AuthorizationStrategies (AuthorizationStrategyId)
ON DELETE CASCADE;

ALTER TABLE dbo.ResourceClaimActionAuthorizationStrategies   ADD  CONSTRAINT FK_ActionAuthorizationStrategies_ActionAuthorizationId FOREIGN KEY(ResourceClaimActionAuthorizationId)
REFERENCES dbo.ResourceClaimActionAuthorizations (ResourceClaimActionAuthorizationId);
