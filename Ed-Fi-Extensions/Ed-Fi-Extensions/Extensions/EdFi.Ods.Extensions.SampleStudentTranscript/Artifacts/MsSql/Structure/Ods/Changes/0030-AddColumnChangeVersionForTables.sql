-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[samplestudenttranscript].[PostSecondaryOrganization]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] ADD [ChangeVersion] [BIGINT] CONSTRAINT PostSecondaryOrganization_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] DROP CONSTRAINT PostSecondaryOrganization_DF_ChangeVersion;
ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] ADD CONSTRAINT PostSecondaryOrganization_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


