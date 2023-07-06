-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'tracked_changes_homograph')
EXEC sys.sp_executesql N'CREATE SCHEMA [tracked_changes_homograph]'
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_homograph].[Contact]'))
CREATE TABLE [tracked_changes_homograph].[Contact]
(
       OldContactFirstName [NVARCHAR](75) NOT NULL,
       OldContactLastSurname [NVARCHAR](75) NOT NULL,
       NewContactFirstName [NVARCHAR](75) NULL,
       NewContactLastSurname [NVARCHAR](75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Contact PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_homograph].[Name]'))
CREATE TABLE [tracked_changes_homograph].[Name]
(
       OldFirstName [NVARCHAR](75) NOT NULL,
       OldLastSurname [NVARCHAR](75) NOT NULL,
       NewFirstName [NVARCHAR](75) NULL,
       NewLastSurname [NVARCHAR](75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Name PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_homograph].[School]'))
CREATE TABLE [tracked_changes_homograph].[School]
(
       OldSchoolName [NVARCHAR](100) NOT NULL,
       NewSchoolName [NVARCHAR](100) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_School PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_homograph].[SchoolYearType]'))
CREATE TABLE [tracked_changes_homograph].[SchoolYearType]
(
       OldSchoolYear [NVARCHAR](20) NOT NULL,
       NewSchoolYear [NVARCHAR](20) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_SchoolYearType PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_homograph].[Staff]'))
CREATE TABLE [tracked_changes_homograph].[Staff]
(
       OldStaffFirstName [NVARCHAR](75) NOT NULL,
       OldStaffLastSurname [NVARCHAR](75) NOT NULL,
       NewStaffFirstName [NVARCHAR](75) NULL,
       NewStaffLastSurname [NVARCHAR](75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Staff PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_homograph].[Student]'))
CREATE TABLE [tracked_changes_homograph].[Student]
(
       OldStudentFirstName [NVARCHAR](75) NOT NULL,
       OldStudentLastSurname [NVARCHAR](75) NOT NULL,
       NewStudentFirstName [NVARCHAR](75) NULL,
       NewStudentLastSurname [NVARCHAR](75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_Student PRIMARY KEY CLUSTERED (ChangeVersion)
)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[tracked_changes_homograph].[StudentSchoolAssociation]'))
CREATE TABLE [tracked_changes_homograph].[StudentSchoolAssociation]
(
       OldSchoolName [NVARCHAR](100) NOT NULL,
       OldStudentFirstName [NVARCHAR](75) NOT NULL,
       OldStudentLastSurname [NVARCHAR](75) NOT NULL,
       NewSchoolName [NVARCHAR](100) NULL,
       NewStudentFirstName [NVARCHAR](75) NULL,
       NewStudentLastSurname [NVARCHAR](75) NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       Discriminator [NVARCHAR](128) NULL,
       CreateDate DateTime2 NOT NULL DEFAULT (getutcdate()),
       CONSTRAINT PK_StudentSchoolAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
