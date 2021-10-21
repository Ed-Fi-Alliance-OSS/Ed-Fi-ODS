-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

---------------------------- [dbo].[ClaimSetResourceClaimActionAuthorizations] --------------------------------------------------------

CREATE TABLE [dbo].[ClaimSetResourceClaimActionAuthorizations](
	[ClaimSetResourceClaimActionAuthorizationId] [int] IDENTITY(1,1) NOT NULL,
	[ValidationRuleSetNameOverride] [nvarchar](255) NULL,
	[Action_ActionId] [int] NOT NULL,
	[ClaimSet_ClaimSetId] [int] NOT NULL,
	[ResourceClaim_ResourceClaimId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ClaimSetResourceClaimActionAuthorizations] PRIMARY KEY CLUSTERED 
(
	[ClaimSetResourceClaimActionAuthorizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [ClaimSetResourceClaimActionAuthorizations_AK] UNIQUE NONCLUSTERED 
(
	[Action_ActionId] ASC,
	[ClaimSet_ClaimSetId] ASC,
	[ResourceClaim_ResourceClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizations_dbo.Actions_Action_ActionId] FOREIGN KEY([Action_ActionId])
REFERENCES [dbo].[Actions] ([ActionId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizations] CHECK CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizations_dbo.Actions_Action_ActionId]
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizations_dbo.ClaimSets_ClaimSet_ClaimSetId] FOREIGN KEY([ClaimSet_ClaimSetId])
REFERENCES [dbo].[ClaimSets] ([ClaimSetId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizations] CHECK CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizations_dbo.ClaimSets_ClaimSet_ClaimSetId]
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizations_dbo.ResourceClaims_ResourceClaim_ResourceClaimId] FOREIGN KEY([ResourceClaim_ResourceClaimId])
REFERENCES [dbo].[ResourceClaims] ([ResourceClaimId])
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizations] CHECK CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizations_dbo.ResourceClaims_ResourceClaim_ResourceClaimId]
GO

---------------------------- [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides] --------------------------------------------------------


CREATE TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides](
	[ClaimSetResourceClaimActionAuthorizationStrategyOverrideId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorizationStrategy_AuthorizationStrategyId] [int] NOT NULL,
	[ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides] PRIMARY KEY CLUSTERED 
(
	[ClaimSetResourceClaimActionAuthorizationStrategyOverrideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [ClaimSetResourceClaimActionAuthorizationStrategyOverrides_AK] UNIQUE NONCLUSTERED 
(
	[AuthorizationStrategy_AuthorizationStrategyId] ASC,
	[ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides_dbo.AuthorizationStrategies_AuthorizationStrategy_Authorization] FOREIGN KEY([AuthorizationStrategy_AuthorizationStrategyId])
REFERENCES [dbo].[AuthorizationStrategies] ([AuthorizationStrategyId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides] CHECK CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides_dbo.AuthorizationStrategies_AuthorizationStrategy_Authorization]
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides_dbo.ClaimSetResourceClaimActionAuthorizations_ClaimSetResourceC] FOREIGN KEY([ClaimSetResourceClaimActionAuthorization_ClaimSetResourceClaimActionAuthorizationId])
REFERENCES [dbo].[ClaimSetResourceClaimActionAuthorizations] ([ClaimSetResourceClaimActionAuthorizationId])
GO

ALTER TABLE [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides] CHECK CONSTRAINT [FK_dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides_dbo.ClaimSetResourceClaimActionAuthorizations_ClaimSetResourceC]
GO


------------------------------ [dbo].[ResourceClaimActionAuthorizations] -------------------------------------------------
CREATE TABLE [dbo].[ResourceClaimActionAuthorizations](
	[ResourceClaimActionAuthorizationId] [int] IDENTITY(1,1) NOT NULL,
	[ValidationRuleSetName] [nvarchar](255) NULL,
	[Action_ActionId] [int] NOT NULL,
	[ResourceClaim_ResourceClaimId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ResourceClaimActionAuthorizations] PRIMARY KEY CLUSTERED 
(
	[ResourceClaimActionAuthorizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [ResourceClaimActionAuthorizations_AK] UNIQUE NONCLUSTERED 
(
	[Action_ActionId] ASC,
	[ResourceClaim_ResourceClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizations_dbo.Actions_Action_ActionId] FOREIGN KEY([Action_ActionId])
REFERENCES [dbo].[Actions] ([ActionId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizations] CHECK CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizations_dbo.Actions_Action_ActionId]
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizations_dbo.ResourceClaims_ResourceClaim_ResourceClaimId] FOREIGN KEY([ResourceClaim_ResourceClaimId])
REFERENCES [dbo].[ResourceClaims] ([ResourceClaimId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizations] CHECK CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizations_dbo.ResourceClaims_ResourceClaim_ResourceClaimId]
GO

------------------------------ [dbo].[ResourceClaimActionAuthorizationStrategies] -------------------------------------------------


CREATE TABLE [dbo].[ResourceClaimActionAuthorizationStrategies](
	[ResourceClaimActionAuthorizationStrategyId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorizationStrategy_AuthorizationStrategyId] [int] NOT NULL,
	[ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ResourceClaimActionAuthorizationStrategies] PRIMARY KEY CLUSTERED 
(
	[ResourceClaimActionAuthorizationStrategyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [ResourceClaimActionAuthorizationStrategies_AK] UNIQUE NONCLUSTERED 
(
	[AuthorizationStrategy_AuthorizationStrategyId] ASC,
	[ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizationStrategies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizationStrategies_dbo.AuthorizationStrategies_AuthorizationStrategy_AuthorizationStrategyId] FOREIGN KEY([AuthorizationStrategy_AuthorizationStrategyId])
REFERENCES [dbo].[AuthorizationStrategies] ([AuthorizationStrategyId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizationStrategies] CHECK CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizationStrategies_dbo.AuthorizationStrategies_AuthorizationStrategy_AuthorizationStrategyId]
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizationStrategies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizationStrategies_dbo.ResourceClaimActionAuthorizations_ResourceClaimActionAuthorizations_Resour] FOREIGN KEY([ResourceClaimActionAuthorization_ResourceClaimActionAuthorizationId])
REFERENCES [dbo].[ResourceClaimActionAuthorizations] ([ResourceClaimActionAuthorizationId])
GO

ALTER TABLE [dbo].[ResourceClaimActionAuthorizationStrategies] CHECK CONSTRAINT [FK_dbo.ResourceClaimActionAuthorizationStrategies_dbo.ResourceClaimActionAuthorizations_ResourceClaimActionAuthorizations_Resour]
GO


