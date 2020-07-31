-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table dbo.ApiClientApplicationEducationOrganizations --
CREATE TABLE dbo.ApiClientApplicationEducationOrganizations(
	ApiClient_ApiClientId INT NOT NULL,
	ApplicationEdOrg_ApplicationEdOrgId INT NOT NULL,
	CONSTRAINT ApiClientApplicationEducationOrganizations_PK PRIMARY KEY (
		ApiClient_ApiClientId,
		ApplicationEdOrg_ApplicationEdOrgId
	)
);

-- Table dbo.ApiClients --
CREATE TABLE dbo.ApiClients(
	ApiClientId SERIAL NOT NULL,
	Key VARCHAR(50) NOT NULL,
	Secret VARCHAR(100) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	IsApproved BOOLEAN NOT NULL,
	UseSandbox BOOLEAN NOT NULL,
	SandboxType INT NOT NULL,
	Application_ApplicationId INT NULL,
	User_UserId INT NULL,
	KeyStatus VARCHAR NULL,
	ChallengeId VARCHAR NULL,
	ChallengeExpiry TIMESTAMP NULL,
	ActivationCode VARCHAR NULL,
	ActivationRetried INT NULL,
	SecretIsHashed BOOLEAN NOT NULL,
	StudentIdentificationSystemDescriptor VARCHAR(306) NULL,
	CONSTRAINT ApiClients_PK PRIMARY KEY (
		ApiClientId
	)
);
ALTER TABLE dbo.ApiClients ALTER COLUMN SecretIsHashed SET DEFAULT FALSE;

-- Table dbo.ApplicationEducationOrganizations --
CREATE TABLE dbo.ApplicationEducationOrganizations(
	ApplicationEducationOrganizationId SERIAL NOT NULL,
	EducationOrganizationId INT NOT NULL,
	Application_ApplicationId INT NULL,
	CONSTRAINT ApplicationEducationOrganizations_PK PRIMARY KEY (
		ApplicationEducationOrganizationId
	)
);

-- Table dbo.Applications --
CREATE TABLE dbo.Applications(
	ApplicationId SERIAL NOT NULL,
	ApplicationName VARCHAR NULL,
	Vendor_VendorId INT NULL,
	ClaimSetName VARCHAR(255) NULL,
	OdsInstance_OdsInstanceId INT NULL,
	OperationalContextUri VARCHAR(255) NOT NULL,
	CONSTRAINT Applications_PK PRIMARY KEY (
		ApplicationId
	)
);
ALTER TABLE dbo.Applications ALTER COLUMN OperationalContextUri SET DEFAULT '';

-- Table dbo.ClientAccessTokens --
CREATE TABLE dbo.ClientAccessTokens(
	Id UUID NOT NULL,
	Expiration TIMESTAMP NOT NULL,
	Scope VARCHAR NULL,
	ApiClient_ApiClientId INT NULL,
	CONSTRAINT ClientAccessTokens_PK PRIMARY KEY (
		Id
	)
);

-- Table dbo.OdsInstanceComponents --
CREATE TABLE dbo.OdsInstanceComponents(
	OdsInstanceComponentId SERIAL NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Url VARCHAR(200) NOT NULL,
	Version VARCHAR(20) NOT NULL,
	OdsInstance_OdsInstanceId INT NOT NULL,
	CONSTRAINT OdsInstanceComponents_PK PRIMARY KEY (
		OdsInstanceComponentId
	)
);

-- Table dbo.OdsInstances --
CREATE TABLE dbo.OdsInstances(
	OdsInstanceId SERIAL NOT NULL,
	Name VARCHAR(100) NOT NULL,
	InstanceType VARCHAR(100) NOT NULL,
	Status VARCHAR(100) NOT NULL,
	IsExtended BOOLEAN NOT NULL,
	Version VARCHAR(20) NOT NULL,
	CONSTRAINT OdsInstances_PK PRIMARY KEY (
		OdsInstanceId
	)
);

-- Table dbo.ProfileApplications --
CREATE TABLE dbo.ProfileApplications(
	Profile_ProfileId INT NOT NULL,
	Application_ApplicationId INT NOT NULL,
	CONSTRAINT ProfileApplications_PK PRIMARY KEY (
		Profile_ProfileId,
		Application_ApplicationId
	)
);

-- Table dbo.Profiles --
CREATE TABLE dbo.Profiles(
	ProfileId SERIAL NOT NULL,
	ProfileName VARCHAR NOT NULL,
	CONSTRAINT Profiles_PK PRIMARY KEY (
		ProfileId
	)
);

-- Table dbo.Users --
CREATE TABLE dbo.Users(
	UserId SERIAL NOT NULL,
	Email VARCHAR NULL,
	FullName VARCHAR NULL,
	Vendor_VendorId INT NULL,
	CONSTRAINT Users_PK PRIMARY KEY (
		UserId
	)
);

-- Table dbo.VendorNamespacePrefixes --
CREATE TABLE dbo.VendorNamespacePrefixes(
	VendorNamespacePrefixId SERIAL NOT NULL,
	NamespacePrefix VARCHAR(255) NOT NULL,
	Vendor_VendorId INT NOT NULL,
	CONSTRAINT VendorNamespacePrefixes_PK PRIMARY KEY (
		VendorNamespacePrefixId
	)
);

-- Table dbo.Vendors --
CREATE TABLE dbo.Vendors(
	VendorId SERIAL NOT NULL,
	VendorName VARCHAR NULL,
	CONSTRAINT Vendors_PK PRIMARY KEY (
		VendorId
	)
);
