-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'tracked_changes_sample')
EXEC sys.sp_executesql N'CREATE SCHEMA [tracked_changes_sample]'
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_sample].[Bus]'))
CREATE TABLE [tracked_changes_sample].[Bus]
(
       OldBusId [NVARCHAR](60) NOT NULL,
       NewBusId [NVARCHAR](60) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Bus PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_sample].[BusRoute]'))
CREATE TABLE [tracked_changes_sample].[BusRoute]
(
       OldBusId [NVARCHAR](60) NOT NULL,
       OldBusRouteNumber [INT] NOT NULL,
       NewBusId [NVARCHAR](60) NULL,
       NewBusRouteNumber [INT] NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_BusRoute PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_sample].[StudentGraduationPlanAssociation]'))
CREATE TABLE [tracked_changes_sample].[StudentGraduationPlanAssociation]
(
       OldEducationOrganizationId [INT] NOT NULL,
       OldGraduationPlanTypeDescriptorId [INT] NOT NULL,
       OldGraduationPlanTypeDescriptorNamespace [NVARCHAR](255) NOT NULL,
       OldGraduationPlanTypeDescriptorCodeValue [NVARCHAR](50) NOT NULL,
       OldGraduationSchoolYear [SMALLINT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewEducationOrganizationId [INT] NULL,
       NewGraduationPlanTypeDescriptorId [INT] NULL,
       NewGraduationPlanTypeDescriptorNamespace [NVARCHAR](255) NULL,
       NewGraduationPlanTypeDescriptorCodeValue [NVARCHAR](50) NULL,
       NewGraduationSchoolYear [SMALLINT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentGraduationPlanAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
