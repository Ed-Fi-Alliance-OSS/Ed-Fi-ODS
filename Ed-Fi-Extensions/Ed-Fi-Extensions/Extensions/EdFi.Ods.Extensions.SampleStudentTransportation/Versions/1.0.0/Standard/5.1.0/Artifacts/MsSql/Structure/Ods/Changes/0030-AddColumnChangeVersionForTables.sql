-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[samplestudenttransportation].[StudentTransportation]') AND name = 'ChangeVersion')
BEGIN
ALTER TABLE [samplestudenttransportation].[StudentTransportation] ADD [ChangeVersion] [BIGINT] CONSTRAINT StudentTransportation_DF_ChangeVersion DEFAULT (0) NOT NULL;
ALTER TABLE [samplestudenttransportation].[StudentTransportation] DROP CONSTRAINT StudentTransportation_DF_ChangeVersion;
ALTER TABLE [samplestudenttransportation].[StudentTransportation] ADD CONSTRAINT StudentTransportation_DF_ChangeVersion DEFAULT (NEXT VALUE FOR [changes].[ChangeVersionSequence]) For [ChangeVersion];
END


