-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SCHEMA interop AUTHORIZATION dbo
GO

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO

CREATE TABLE [interop].[OperationalContext]
	(
	[OperationalContextUri] nvarchar(255) NOT NULL,
	[DisplayName] nvarchar(100) NOT NULL,
	[OrganizationName] nvarchar(50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE [interop].[OperationalContext] ADD CONSTRAINT
	[PK_OperationalContext] PRIMARY KEY CLUSTERED 
	(
	[OperationalContextUri]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [interop].[OperationalContext]
ADD CONSTRAINT [OperationalContext_DF_Id] DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [interop].[OperationalContext]
ADD CONSTRAINT [OperationalContext_DF_CreateDate] DEFAULT (GETDATE()) FOR [CreateDate] 
GO

ALTER TABLE [interop].[OperationalContext]
ADD CONSTRAINT [OperationalContext_DF_LastModifiedDate] DEFAULT (GETDATE()) FOR [LastModifiedDate]
GO

ALTER TABLE [interop].[OperationalContext] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO


CREATE TABLE [interop].[DescriptorEquivalenceGroup]
	(
	[DescriptorEquivalenceGroupId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL	
	)  ON [PRIMARY]
GO
ALTER TABLE [interop].[DescriptorEquivalenceGroup] ADD CONSTRAINT
	[PK_DescriptorEquivalenceGroup] PRIMARY KEY CLUSTERED 
	(
	[DescriptorEquivalenceGroupId]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [interop].[DescriptorEquivalenceGroup]
ADD CONSTRAINT [DescriptorEquivalenceGroup_DF_DescriptorEquivalenceGroupId] DEFAULT (newid()) FOR [DescriptorEquivalenceGroupId]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroup]
ADD CONSTRAINT [DescriptorEquivalenceGroup_DF_Id] DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroup]
ADD CONSTRAINT [DescriptorEquivalenceGroup_DF_CreateDate] DEFAULT (GETDATE()) FOR [CreateDate]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroup]
ADD CONSTRAINT [DescriptorEquivalenceGroup_DF_LastModifiedDate] DEFAULT (GETDATE()) FOR [LastModifiedDate]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroup] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO


CREATE TABLE [interop].[DescriptorEquivalenceGroupGeneralization]
	(
	[DescriptorEquivalenceGroupId] [uniqueidentifier] NOT NULL,
	[GeneralizationDescriptorEquivalenceGroupId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL	
	)  ON [PRIMARY]
GO
ALTER TABLE [interop].[DescriptorEquivalenceGroupGeneralization] ADD CONSTRAINT
	[PK_DescriptorEquivalenceGroupGeneralization] PRIMARY KEY CLUSTERED 
	(
	[DescriptorEquivalenceGroupId],
	[GeneralizationDescriptorEquivalenceGroupId]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE [interop].[DescriptorEquivalenceGroupGeneralization] ADD CONSTRAINT
	[FK_DescriptorEquivalenceGroupGeneralization_DescriptorEquivalenceGroup] FOREIGN KEY
	(
	[DescriptorEquivalenceGroupId]
	) REFERENCES [interop].[DescriptorEquivalenceGroup]
	(
	[DescriptorEquivalenceGroupId]
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE [interop].[DescriptorEquivalenceGroupGeneralization] ADD CONSTRAINT
	[FK_DescriptorEquivalenceGroupGeneralization_DescriptorEquivalenceGroupGeneralization] FOREIGN KEY
	(
	[GeneralizationDescriptorEquivalenceGroupId]
	) REFERENCES [interop].[DescriptorEquivalenceGroup]
	(
	[DescriptorEquivalenceGroupId]
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE [interop].[DescriptorEquivalenceGroupGeneralization]
ADD CONSTRAINT [DescriptorEquivalenceGroupGeneralization_DF_Id] DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroupGeneralization]
ADD CONSTRAINT [DescriptorEquivalenceGroupGeneralization_DF_CreateDate] DEFAULT (GETDATE()) FOR [CreateDate]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroupGeneralization]
ADD CONSTRAINT [DescriptorEquivalenceGroupGeneralization_DF_LastModifiedDate] DEFAULT (GETDATE()) FOR [LastModifiedDate]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroupGeneralization] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE [edfi].[Descriptor] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO


CREATE TABLE [interop].[OperationalContextDescriptorUsage]
	(
	[OperationalContextUri] nvarchar(255) NOT NULL,
	[DescriptorId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL)  ON [PRIMARY]
GO
ALTER TABLE [interop].[OperationalContextDescriptorUsage] ADD CONSTRAINT
	[PK_OperationalContextDescriptorUsage] PRIMARY KEY CLUSTERED 
	(
	[OperationalContextUri],
	[DescriptorId]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE [interop].[OperationalContextDescriptorUsage] ADD CONSTRAINT
	[FK_OperationalContextDescriptorUsage_Descriptor] FOREIGN KEY
	(
	[DescriptorId]
	) REFERENCES [edfi].[Descriptor]
	(
	[DescriptorId]
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE
	
GO
ALTER TABLE [interop].[OperationalContextDescriptorUsage] ADD CONSTRAINT
	[FK_OperationalContextDescriptorUsage_OperationalContext] FOREIGN KEY
	(
	[OperationalContextUri]
	) REFERENCES [interop].[OperationalContext]
	(
	[OperationalContextUri]
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE [interop].[OperationalContextDescriptorUsage]
ADD CONSTRAINT [OperationalContextDescriptorUsage_DF_CreateDate] DEFAULT (GETDATE()) FOR [CreateDate]
GO

ALTER TABLE [interop].[OperationalContextDescriptorUsage] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO


CREATE TABLE [interop].[DescriptorEquivalenceGroupAssignment]
	(
	[DescriptorId] [int] NOT NULL,
	[DescriptorEquivalenceGroupId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL	
	)  ON [PRIMARY]
GO
ALTER TABLE [interop].[DescriptorEquivalenceGroupAssignment] ADD CONSTRAINT
	[PK_DescriptorEquivalenceGroupAssignment] PRIMARY KEY CLUSTERED 
	(
	[DescriptorId]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE [interop].[DescriptorEquivalenceGroupAssignment] ADD CONSTRAINT
	[FK_DescriptorEquivalenceGroupAssignment_DescriptorEquivalenceGroup] FOREIGN KEY
	(
	[DescriptorEquivalenceGroupId]
	) REFERENCES [interop].[DescriptorEquivalenceGroup]
	(
	[DescriptorEquivalenceGroupId]
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE [interop].[DescriptorEquivalenceGroupAssignment] ADD CONSTRAINT
	[FK_DescriptorEquivalenceGroupAssignment_Descriptor] FOREIGN KEY
	(
	[DescriptorId]
	) REFERENCES [edfi].[Descriptor]
	(
	[DescriptorId]
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE
	
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroupAssignment]
ADD CONSTRAINT [DescriptorEquivalenceGroupAssignment_DF_Id] DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroupAssignment]
ADD CONSTRAINT [DescriptorEquivalenceGroupAssignment_DF_CreateDate] DEFAULT (GETDATE()) FOR [CreateDate]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroupAssignment]
ADD CONSTRAINT [DescriptorEquivalenceGroupAssignment_DF_LastModifiedDate] DEFAULT (GETDATE()) FOR [LastModifiedDate]
GO

ALTER TABLE [interop].[DescriptorEquivalenceGroupAssignment] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT