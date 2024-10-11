-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


CREATE SEQUENCE samplestudenttranscript.PostSecondaryOrganization_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE samplestudenttranscript.PostSecondaryOrganization ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('samplestudenttranscript.PostSecondaryOrganization_aggseq');
CREATE INDEX ix_PostSecondaryOrganization_aggid ON samplestudenttranscript.PostSecondaryOrganization (AggregateId);

