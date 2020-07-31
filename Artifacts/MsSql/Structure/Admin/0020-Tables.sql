-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table [dbo].[ApiClientApplicationEducationOrganizations] --
CREATE TABLE [dbo].[ApiClientApplicationEducationOrganizations](
	[ApiClient_ApiClientId] [int] NOT NULL,
	[ApplicationEducationOrganization_ApplicationEducationOrganizationId] [int] NOT NULL,
	CONSTRAINT [ApiClientApplicationEducationOrganizations_PK] PRIMARY KEY CLUSTERED (
		[ApiClient_ApiClientId] ASC,
		[ApplicationEducationOrganization_ApplicationEducationOrganizationId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [dbo].[ApiClients] --
CREATE TABLE [dbo].[ApiClients](
	[ApiClientId] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](50) NOT NULL,
	[Secret] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[UseSandbox] [bit] NOT NULL,
	[SandboxType] [int] NOT NULL,
	[Application_ApplicationId] [int] NULL,
	[User_UserId] [int] NULL,
	[KeyStatus] [nvarchar](max) NULL,
	[ChallengeId] [nvarchar](max) NULL,
	[ChallengeExpiry] [datetime] NULL,
	[ActivationCode] [nvarchar](max) NULL,
	[ActivationRetried] [int] NULL,
	[SecretIsHashed] [bit] NOT NULL,
	[StudentIdentificationSystemDescriptor] [nvarchar](306) NULL,
	CONSTRAINT [ApiClients_PK] PRIMARY KEY CLUSTERED (
		[ApiClientId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApiClients] ADD CONSTRAINT [ApiClients_DF_SecretIsHashed] DEFAULT ((0)) FOR [SecretIsHashed]
GO

-- Table [dbo].[ApplicationEducationOrganizations] --
CREATE TABLE [dbo].[ApplicationEducationOrganizations](
	[ApplicationEducationOrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[EducationOrganizationId] [int] NOT NULL,
	[Application_ApplicationId] [int] NULL,
	CONSTRAINT [ApplicationEducationOrganizations_PK] PRIMARY KEY CLUSTERED (
		[ApplicationEducationOrganizationId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [dbo].[Applications] --
CREATE TABLE [dbo].[Applications](
	[ApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationName] [nvarchar](max) NULL,
	[Vendor_VendorId] [int] NULL,
	[ClaimSetName] [nvarchar](255) NULL,
	[OdsInstance_OdsInstanceId] [int] NULL,
	[OperationalContextUri] [nvarchar](255) NOT NULL,
	CONSTRAINT [Applications_PK] PRIMARY KEY CLUSTERED (
		[ApplicationId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [Applications_DF_OperationalContextUri]  DEFAULT ('') FOR [OperationalContextUri]
GO

-- Table [dbo].[ClientAccessTokens] --
CREATE TABLE [dbo].[ClientAccessTokens](
	[Id] [uniqueidentifier] NOT NULL,
	[Expiration] [datetime] NOT NULL,
	[Scope] [nvarchar](max) NULL,
	[ApiClient_ApiClientId] [int] NULL,
	CONSTRAINT [ClientAccessTokens_PK] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Table [dbo].[OdsInstanceComponents] --
CREATE TABLE [dbo].[OdsInstanceComponents](
	[OdsInstanceComponentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Url] [nvarchar](200) NOT NULL,
	[Version] [nvarchar](20) NOT NULL,
	[OdsInstance_OdsInstanceId] [int] NOT NULL,
	CONSTRAINT [OdsInstanceComponents_PK] PRIMARY KEY CLUSTERED (
		[OdsInstanceComponentId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [dbo].[OdsInstances] --
CREATE TABLE [dbo].[OdsInstances](
	[OdsInstanceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[InstanceType] [nvarchar](100) NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
	[IsExtended] [bit] NOT NULL,
	[Version] [nvarchar](20) NOT NULL,
	CONSTRAINT [OdsInstances_PK] PRIMARY KEY CLUSTERED (
		[OdsInstanceId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [dbo].[ProfileApplications] --
CREATE TABLE [dbo].[ProfileApplications](
	[Profile_ProfileId] [int] NOT NULL,
	[Application_ApplicationId] [int] NOT NULL,
	CONSTRAINT [ProfileApplications_PK] PRIMARY KEY CLUSTERED (
		[Profile_ProfileId] ASC,
		[Application_ApplicationId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [dbo].[Profiles] --
CREATE TABLE [dbo].[Profiles](
	[ProfileId] [int] IDENTITY(1,1) NOT NULL,
	[ProfileName] [nvarchar](max) NOT NULL,
	CONSTRAINT [Profiles_PK] PRIMARY KEY CLUSTERED (
		[ProfileId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Table [dbo].[Users] --
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Vendor_VendorId] [int] NULL,
	CONSTRAINT [Users_PK] PRIMARY KEY CLUSTERED (
		[UserId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Table [dbo].[VendorNamespacePrefixes] --
CREATE TABLE [dbo].[VendorNamespacePrefixes](
	[VendorNamespacePrefixId] [int] IDENTITY(1,1) NOT NULL,
	[NamespacePrefix] [nvarchar](255) NOT NULL,
	[Vendor_VendorId] [int] NOT NULL,
	CONSTRAINT [VendorNamespacePrefixes_PK] PRIMARY KEY CLUSTERED (
		[VendorNamespacePrefixId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [dbo].[Vendors] --
CREATE TABLE [dbo].[Vendors](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [nvarchar](max) NULL,
	CONSTRAINT [Vendors_PK] PRIMARY KEY CLUSTERED (
		[VendorId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO