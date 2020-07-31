-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table dbo.Actions --
CREATE TABLE dbo.Actions(
	ActionId SERIAL NOT NULL,
	ActionName VARCHAR(255) NOT NULL,
	ActionUri VARCHAR(2048) NOT NULL,
	CONSTRAINT Actions_PK PRIMARY KEY
	(
		ActionId
	)
);

-- Table dbo.Applications --
CREATE TABLE dbo.Applications(
	ApplicationId SERIAL NOT NULL,
	ApplicationName VARCHAR NULL,
	CONSTRAINT Applications_PK PRIMARY KEY
	(
		ApplicationId
	)
);

-- Table dbo.AuthorizationStrategies -- 
CREATE TABLE dbo.AuthorizationStrategies(
	AuthorizationStrategyId SERIAL NOT NULL,
	DisplayName VARCHAR(255) NOT NULL,
	AuthorizationStrategyName VARCHAR(255) NOT NULL,
	Application_ApplicationId INT NOT NULL,
	CONSTRAINT AuthorizationStrategies_PK PRIMARY KEY
	(
		AuthorizationStrategyId
	)
);

----- Table dbo.ClaimSetResourceClaims -- 
CREATE TABLE dbo.ClaimSetResourceClaims(
	ClaimSetResourceClaimId SERIAL NOT NULL,
	Action_ActionId INT NOT NULL,
	ClaimSet_ClaimSetId INT NOT NULL,
	ResourceClaim_ResourceClaimId INT NOT NULL,
	AuthorizationStrategyOverride_AuthorizationStrategyId INT NULL,
	ValidationRuleSetNameOverride VARCHAR(255) NULL,
	CONSTRAINT ClaimSetResourceClaims_PK PRIMARY KEY
	(
		ClaimSetResourceClaimId
	)
);

-- Table dbo.ClaimSets -- 
CREATE TABLE dbo.ClaimSets(
	ClaimSetId SERIAL NOT NULL,
	ClaimSetName VARCHAR(255) NOT NULL,
	Application_ApplicationId INT NOT NULL,
	CONSTRAINT ClaimSets_PK PRIMARY KEY
	(
		ClaimSetId
	)
);

-- Table dbo.ResourceClaimAuthorizationMetadatas -- 
CREATE TABLE dbo.ResourceClaimAuthorizationMetadatas(
	ResourceClaimAuthorizationStrategyId SERIAL NOT NULL,
	Action_ActionId INT NOT NULL,
	AuthorizationStrategy_AuthorizationStrategyId INT NULL,
	ResourceClaim_ResourceClaimId INT NOT NULL,
	ValidationRuleSetName VARCHAR(255) NULL,
	CONSTRAINT ResourceClaimAuthorizationMetadatas_PK PRIMARY KEY
	(
		ResourceClaimAuthorizationStrategyId
	)
);

-- Table dbo.ResourceClaims -- 
CREATE TABLE dbo.ResourceClaims(
	ResourceClaimId SERIAL NOT NULL,
	DisplayName VARCHAR(255) NOT NULL,
	ResourceName VARCHAR(2048) NOT NULL,
	ClaimName VARCHAR(2048) NOT NULL,
	ParentResourceClaimId INT NULL,
	Application_ApplicationId INT NOT NULL,
	CONSTRAINT ResourceClaims_PK PRIMARY KEY
	(
		ResourceClaimId
	)
);
