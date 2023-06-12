-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[sample].[Bus]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [sample].[Bus] ADD [ChangeVersion] [BIGINT] CONSTRAINT Bus_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [sample].[Bus] DROP CONSTRAINT Bus_DF_ChangeVersion;
ALTER TABLE [sample].[Bus] ADD CONSTRAINT Bus_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[sample].[BusRoute]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [sample].[BusRoute] ADD [ChangeVersion] [BIGINT] CONSTRAINT BusRoute_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [sample].[BusRoute] DROP CONSTRAINT BusRoute_DF_ChangeVersion;
ALTER TABLE [sample].[BusRoute] ADD CONSTRAINT BusRoute_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[sample].[StudentGraduationPlanAssociation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [sample].[StudentGraduationPlanAssociation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentGraduationPlanAssociation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [sample].[StudentGraduationPlanAssociation] DROP CONSTRAINT StudentGraduationPlanAssociation_DF_ChangeVersion;
ALTER TABLE [sample].[StudentGraduationPlanAssociation] ADD CONSTRAINT StudentGraduationPlanAssociation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


