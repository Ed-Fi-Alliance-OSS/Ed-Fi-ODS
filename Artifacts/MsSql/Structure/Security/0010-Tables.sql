-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

------------------- [dbo].[Actions] -----------------------------------------------------------
CREATE TABLE [dbo].[Actions](
	[ActionId] [int] IDENTITY(1,1) NOT NULL,
	[ActionName] [nvarchar](255) NOT NULL,
	[ActionUri] [nvarchar](2048) NOT NULL,
 CONSTRAINT [PK_dbo.Actions] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--------------------- [dbo].[Applications] -------------------------------------------------------
CREATE TABLE [dbo].[Applications](
	[ApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Applications] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--------------------- [dbo].[AuthorizationStrategies] -------------------------------------------
CREATE TABLE [dbo].[AuthorizationStrategies](
	[AuthorizationStrategyId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[AuthorizationStrategyName] [nvarchar](255) NOT NULL,
	[Application_ApplicationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AuthorizationStrategies] PRIMARY KEY CLUSTERED 
(
	[AuthorizationStrategyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------- [dbo].[ClaimSetResourceClaims] ------------------------------------
CREATE TABLE [dbo].[ClaimSetResourceClaims](
	[ClaimSetResourceClaimId] [int] IDENTITY(1,1) NOT NULL,
	[Action_ActionId] [int] NOT NULL,
	[ClaimSet_ClaimSetId] [int] NOT NULL,
	[ResourceClaim_ResourceClaimId] [int] NOT NULL,
	[AuthorizationStrategyOverride_AuthorizationStrategyId] [int] NULL,
	[ValidationRuleSetNameOverride] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.ClaimSetResourceClaims] PRIMARY KEY CLUSTERED 
(
	[ClaimSetResourceClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------------------- [dbo].[ClaimSets] --------------------------------------------------------
CREATE TABLE [dbo].[ClaimSets](
	[ClaimSetId] [int] IDENTITY(1,1) NOT NULL,
	[ClaimSetName] [nvarchar](255) NOT NULL,
	[Application_ApplicationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ClaimSets] PRIMARY KEY CLUSTERED 
(
	[ClaimSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------ [dbo].[ResourceClaimAuthorizationMetadatas] -------------------------------------------------
CREATE TABLE [dbo].[ResourceClaimAuthorizationMetadatas](
	[ResourceClaimAuthorizationStrategyId] [int] IDENTITY(1,1) NOT NULL,
	[Action_ActionId] [int] NOT NULL,
	[AuthorizationStrategy_AuthorizationStrategyId] [int] NULL,
	[ResourceClaim_ResourceClaimId] [int] NOT NULL,
	[ValidationRuleSetName] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.ResourceClaimAuthorizationMetadatas] PRIMARY KEY CLUSTERED 
(
	[ResourceClaimAuthorizationStrategyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------- [dbo].[ResourceClaims] -------------------------------------------------
CREATE TABLE [dbo].[ResourceClaims](
	[ResourceClaimId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[ResourceName] [nvarchar](2048) NOT NULL,
	[ClaimName] [nvarchar](2048) NOT NULL,
	[ParentResourceClaimId] [int] NULL,
	[Application_ApplicationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ResourceClaims] PRIMARY KEY CLUSTERED 
(
	[ResourceClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
