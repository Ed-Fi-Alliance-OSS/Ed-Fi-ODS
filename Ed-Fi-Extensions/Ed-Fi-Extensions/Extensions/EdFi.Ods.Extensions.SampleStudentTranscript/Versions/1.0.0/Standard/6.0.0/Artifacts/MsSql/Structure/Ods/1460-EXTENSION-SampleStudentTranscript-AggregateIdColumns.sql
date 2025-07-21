-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SEQUENCE [samplestudenttranscript].[PostSecondaryOrganization_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [samplestudenttranscript].[PostSecondaryOrganization_AggSeq], AggregateData varbinary(8000);
CREATE INDEX [IX_PostSecondaryOrganization_AggregateId] ON [samplestudenttranscript].[PostSecondaryOrganization] (AggregateId);

