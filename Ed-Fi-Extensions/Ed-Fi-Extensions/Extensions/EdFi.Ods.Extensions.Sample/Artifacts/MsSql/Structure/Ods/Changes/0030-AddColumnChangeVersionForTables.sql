-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[sample].[Bus]') AND name = 'ChangeVersion')
ALTER TABLE [sample].[Bus] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[sample].[BusRoute]') AND name = 'ChangeVersion')
ALTER TABLE [sample].[BusRoute] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[sample].[StudentGraduationPlanAssociation]') AND name = 'ChangeVersion')
ALTER TABLE [sample].[StudentGraduationPlanAssociation] ADD [ChangeVersion] [BIGINT] DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) NOT NULL;

