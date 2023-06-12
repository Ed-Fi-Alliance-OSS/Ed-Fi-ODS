-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'samplestudenttranscript.PostSecondaryOrganization') AND name = N'UX_PostSecondaryOrganization_ChangeVersion')
    CREATE INDEX [UX_PostSecondaryOrganization_ChangeVersion] ON [samplestudenttranscript].[PostSecondaryOrganization] ([ChangeVersion] ASC)
    GO
COMMIT

