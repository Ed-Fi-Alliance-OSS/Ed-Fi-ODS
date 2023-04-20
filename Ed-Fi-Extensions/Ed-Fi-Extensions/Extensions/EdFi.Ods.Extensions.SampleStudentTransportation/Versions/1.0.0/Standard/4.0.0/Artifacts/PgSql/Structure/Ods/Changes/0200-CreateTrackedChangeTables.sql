-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM information_schema.schemata WHERE schema_name = 'tracked_changes_samplestudenttransportation') THEN
CREATE SCHEMA tracked_changes_samplestudenttransportation;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_samplestudenttransportation' AND table_name = 'studenttransportation') THEN
CREATE TABLE tracked_changes_samplestudenttransportation.studenttransportation
(
       oldambusnumber VARCHAR(6) NOT NULL,
       oldpmbusnumber VARCHAR(6) NOT NULL,
       oldschoolid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newambusnumber VARCHAR(6) NULL,
       newpmbusnumber VARCHAR(6) NULL,
       newschoolid INT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenttransportation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

END
$$;
