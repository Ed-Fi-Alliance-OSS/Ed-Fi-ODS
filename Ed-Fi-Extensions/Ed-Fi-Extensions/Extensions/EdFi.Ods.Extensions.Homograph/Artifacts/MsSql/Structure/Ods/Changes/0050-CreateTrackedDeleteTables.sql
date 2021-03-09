-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE [tracked_deletes_homograph].[Name]
(
       FirstName [NVARCHAR](75) NOT NULL,
       LastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Name PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_homograph].[Parent]
(
       ParentFirstName [NVARCHAR](75) NOT NULL,
       ParentLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Parent PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_homograph].[School]
(
       SchoolName [NVARCHAR](100) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_School PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_homograph].[SchoolYearType]
(
       SchoolYear [NVARCHAR](20) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SchoolYearType PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_homograph].[Staff]
(
       StaffFirstName [NVARCHAR](75) NOT NULL,
       StaffLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Staff PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_homograph].[Student]
(
       StudentFirstName [NVARCHAR](75) NOT NULL,
       StudentLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Student PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_homograph].[StudentSchoolAssociation]
(
       SchoolName [NVARCHAR](100) NOT NULL,
       StudentFirstName [NVARCHAR](75) NOT NULL,
       StudentLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StudentSchoolAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
