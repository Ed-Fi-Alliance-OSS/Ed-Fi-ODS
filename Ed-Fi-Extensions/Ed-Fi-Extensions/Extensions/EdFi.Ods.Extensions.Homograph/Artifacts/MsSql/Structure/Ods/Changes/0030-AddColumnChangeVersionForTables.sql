-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[homograph].[Name]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [homograph].[Name] ADD [ChangeVersion] [BIGINT] CONSTRAINT Name_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [homograph].[Name] DROP CONSTRAINT Name_DF_ChangeVersion;
ALTER TABLE [homograph].[Name] ADD CONSTRAINT Name_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[homograph].[Parent]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [homograph].[Parent] ADD [ChangeVersion] [BIGINT] CONSTRAINT Parent_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [homograph].[Parent] DROP CONSTRAINT Parent_DF_ChangeVersion;
ALTER TABLE [homograph].[Parent] ADD CONSTRAINT Parent_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[homograph].[School]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [homograph].[School] ADD [ChangeVersion] [BIGINT] CONSTRAINT School_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [homograph].[School] DROP CONSTRAINT School_DF_ChangeVersion;
ALTER TABLE [homograph].[School] ADD CONSTRAINT School_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[homograph].[SchoolYearType]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [homograph].[SchoolYearType] ADD [ChangeVersion] [BIGINT] CONSTRAINT SchoolYearType_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [homograph].[SchoolYearType] DROP CONSTRAINT SchoolYearType_DF_ChangeVersion;
ALTER TABLE [homograph].[SchoolYearType] ADD CONSTRAINT SchoolYearType_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[homograph].[Staff]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [homograph].[Staff] ADD [ChangeVersion] [BIGINT] CONSTRAINT Staff_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [homograph].[Staff] DROP CONSTRAINT Staff_DF_ChangeVersion;
ALTER TABLE [homograph].[Staff] ADD CONSTRAINT Staff_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[homograph].[Student]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [homograph].[Student] ADD [ChangeVersion] [BIGINT] CONSTRAINT Student_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [homograph].[Student] DROP CONSTRAINT Student_DF_ChangeVersion;
ALTER TABLE [homograph].[Student] ADD CONSTRAINT Student_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[homograph].[StudentSchoolAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [homograph].[StudentSchoolAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentSchoolAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [homograph].[StudentSchoolAssociation] DROP CONSTRAINT StudentSchoolAssociation_DF_ChangeVersion;
ALTER TABLE [homograph].[StudentSchoolAssociation] ADD CONSTRAINT StudentSchoolAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


