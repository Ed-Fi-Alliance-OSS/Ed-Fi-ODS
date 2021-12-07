-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

------------------------------ [dbo].[ResourceClaimActions] -------------------------------------------------
CREATE TABLE [dbo].[ResourceClaimActions](
	[ResourceClaimActionId] [int] IDENTITY(1,1) NOT NULL,
	[ResourceClaimId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[ValidationRuleSetName] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.ResourceClaimActions] PRIMARY KEY CLUSTERED 
(
	[ResourceClaimActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--UNIQUE NONCLUSTERED INDEX for [ActionId],[ResourceClaimId] columns 
CREATE UNIQUE NONCLUSTERED INDEX [IX_ResourceClaimId_ActionId] ON [dbo].[ResourceClaimActions] (
    [ResourceClaimId],[ActionId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- FOREIGN KEY for [ActionId]  column
ALTER TABLE [dbo].[ResourceClaimActions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActions_dbo.Actions_ActionId] FOREIGN KEY([ActionId])
REFERENCES [dbo].[Actions] ([ActionId])
GO

-- FOREIGN KEY for [[ResourceClaimId]]  column
ALTER TABLE [dbo].[ResourceClaimActions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActions_dbo.ResourceClaims_ResourceClaimId] FOREIGN KEY([ResourceClaimId])
REFERENCES [dbo].[ResourceClaims] ([ResourceClaimId])
ON DELETE CASCADE
GO

---------------------------- [dbo].[ClaimSetResourceClaimActions] --------------------------------------------------------

CREATE TABLE [dbo].[ClaimSetResourceClaimActions](
	[ClaimSetResourceClaimActionId] [int] IDENTITY(1,1) NOT NULL,
	[ClaimSetId] [int] NOT NULL,
	[ResourceClaimId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[ValidationRuleSetNameOverride] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.ClaimSetResourceClaimActions] PRIMARY KEY CLUSTERED 
(
	[ClaimSetResourceClaimActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- UNIQUE NONCLUSTERED INDEX for [ActionId],[ClaimSetId],[ResourceClaimId] columns 
CREATE UNIQUE NONCLUSTERED INDEX [IX_ClaimSetId_ResourceClaimId_ActionId] ON [dbo].[ClaimSetResourceClaimActions] (
    [ClaimSetId],[ResourceClaimId],[ActionId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- FOREIGN KEY for [ActionId]  column
ALTER TABLE [dbo].[ClaimSetResourceClaimActions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActions_dbo.Actions_ActionId] FOREIGN KEY([ActionId])
REFERENCES [dbo].[Actions] ([ActionId])
GO

-- FOREIGN KEY for [ClaimSetId]  column
ALTER TABLE [dbo].[ClaimSetResourceClaimActions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActions_dbo.ClaimSets_ClaimSetId] FOREIGN KEY([ClaimSetId])
REFERENCES [dbo].[ClaimSets] ([ClaimSetId])
ON DELETE CASCADE
GO

-- FOREIGN KEY for [ResourceClaimId] column
ALTER TABLE [dbo].[ClaimSetResourceClaimActions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActions_dbo.ResourceClaims_ResourceClaimId] FOREIGN KEY([ResourceClaimId])
REFERENCES [dbo].[ResourceClaims] ([ResourceClaimId])
GO

---------------------------- [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides] --------------------------------------------------------

CREATE TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides](
	[ClaimSetResourceClaimActionAuthorizationStrategyOverrideId] [int] IDENTITY(1,1) NOT NULL,
	[ClaimSetResourceClaimActionId] [int] NOT NULL,
	[AuthorizationStrategyId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides] PRIMARY KEY CLUSTERED 
(
	[ClaimSetResourceClaimActionAuthorizationStrategyOverrideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- UNIQUE NONCLUSTERED INDEX for [ClaimSetResourceClaimActionId],[AuthorizationStrategyId] columns 
CREATE UNIQUE NONCLUSTERED INDEX [IX_ClaimSetResourceClaimActionId_AuthorizationStrategyId]
    ON [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]([ClaimSetResourceClaimActionId],[AuthorizationStrategyId] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- FOREIGN KEY for [AuthorizationStrategyId]  column
ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides_dbo.AuthorizationStrategies_AuthorizationStrategyId] FOREIGN KEY([AuthorizationStrategyId])
REFERENCES [dbo].[AuthorizationStrategies] ([AuthorizationStrategyId])
ON DELETE CASCADE
GO

-- FOREIGN KEY for [ClaimSetResourceClaimActionId]  column
ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides_dbo.ClaimSetResourceClaimActions_ClaimSetResourceClaimActionId] FOREIGN KEY([ClaimSetResourceClaimActionId])
REFERENCES [dbo].[ClaimSetResourceClaimActions] ([ClaimSetResourceClaimActionId])
GO

------------------------------ [dbo].[ResourceClaimActionAuthorizationStrategies] -------------------------------------------------

CREATE TABLE [dbo].[ResourceClaimActionAuthorizationStrategies](
	[ResourceClaimActionAuthorizationStrategyId] [int] IDENTITY(1,1) NOT NULL,
	[ResourceClaimActionId] [int] NOT NULL,
	[AuthorizationStrategyId] [int] NOT NULL,

 CONSTRAINT [PK_dbo.ResourceClaimActionAuthorizationStrategies] PRIMARY KEY CLUSTERED 
(
	[ResourceClaimActionAuthorizationStrategyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- UNIQUE NONCLUSTERED INDEX for [AuthorizationStrategyId],[ResourceClaimActionId] columns 
CREATE UNIQUE NONCLUSTERED INDEX [IX_ResourceClaimActionId_AuthorizationStrategyId]
    ON [dbo].[ResourceClaimActionAuthorizationStrategies]([ResourceClaimActionId],[AuthorizationStrategyId] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- FOREIGN KEY for [AuthorizationStrategyId]  column
ALTER TABLE [dbo].[ResourceClaimActionAuthorizationStrategies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizationStrategies_dbo.AuthorizationStrategies_AuthorizationStrategyId] FOREIGN KEY([AuthorizationStrategyId])
REFERENCES [dbo].[AuthorizationStrategies] ([AuthorizationStrategyId])
ON DELETE CASCADE
GO

-- FOREIGN KEY for [ResourceClaimActionId]  column
ALTER TABLE [dbo].[ResourceClaimActionAuthorizationStrategies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizationStrategies_dbo.ResourceClaimActionAuthorizations_ResourceClaimActionId] FOREIGN KEY([ResourceClaimActionId])
REFERENCES [dbo].[ResourceClaimActions] ([ResourceClaimActionId])
GO

