-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'tracked_changes_samplestudenttransportation')
EXEC sys.sp_executesql N'CREATE SCHEMA [tracked_changes_samplestudenttransportation]'
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_samplestudenttransportation].[StudentTransportation]'))
CREATE TABLE [tracked_changes_samplestudenttransportation].[StudentTransportation]
(
       OldAMBusNumber [NVARCHAR](6) NOT NULL,
       OldPMBusNumber [NVARCHAR](6) NOT NULL,
       OldSchoolId [INT] NOT NULL,
       OldStudentUSI [INT] NOT NULL,
       OldStudentUniqueId [NVARCHAR](32) NOT NULL,
       NewAMBusNumber [NVARCHAR](6) NULL,
       NewPMBusNumber [NVARCHAR](6) NULL,
       NewSchoolId [INT] NULL,
       NewStudentUSI [INT] NULL,
       NewStudentUniqueId [NVARCHAR](32) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentTransportation PRIMARY KEY CLUSTERED (ChangeVersion)
)
