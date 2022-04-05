-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM information_schema.schemata WHERE schema_name = 'tracked_changes_sample') THEN
CREATE SCHEMA tracked_changes_edfi;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_sample' AND table_name = 'bus') THEN
CREATE TABLE tracked_changes_sample.bus
(
       oldbusid VARCHAR(60) NOT NULL,
       newbusid VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT bus_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_sample' AND table_name = 'busroute') THEN
CREATE TABLE tracked_changes_sample.busroute
(
       oldbusid VARCHAR(60) NOT NULL,
       oldbusroutenumber INT NOT NULL,
       newbusid VARCHAR(60) NULL,
       newbusroutenumber INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT busroute_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_sample' AND table_name = 'studentgraduationplanassociation') THEN
CREATE TABLE tracked_changes_sample.studentgraduationplanassociation
(
       oldeducationorganizationid INT NOT NULL,
       oldgraduationplantypedescriptorid INT NOT NULL,
       oldgraduationplantypedescriptornamespace VARCHAR(255) NOT NULL,
       oldgraduationplantypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgraduationschoolyear SMALLINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid INT NULL,
       newgraduationplantypedescriptorid INT NULL,
       newgraduationplantypedescriptornamespace VARCHAR(255) NULL,
       newgraduationplantypedescriptorcodevalue VARCHAR(50) NULL,
       newgraduationschoolyear SMALLINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentgraduationplanassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

END
$$;
