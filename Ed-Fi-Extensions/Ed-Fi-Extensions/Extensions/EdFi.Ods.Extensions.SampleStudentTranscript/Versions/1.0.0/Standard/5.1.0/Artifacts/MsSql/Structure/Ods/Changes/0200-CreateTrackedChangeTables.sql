-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'tracked_changes_samplestudenttranscript')
EXEC sys.sp_executesql N'CREATE SCHEMA [tracked_changes_samplestudenttranscript]'
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_samplestudenttranscript].[PostSecondaryOrganization]'))
CREATE TABLE [tracked_changes_samplestudenttranscript].[PostSecondaryOrganization]
(
       OldNameOfInstitution [NVARCHAR](75) NOT NULL,
       NewNameOfInstitution [NVARCHAR](75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_PostSecondaryOrganization PRIMARY KEY CLUSTERED (ChangeVersion)
)
