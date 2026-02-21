-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM information_schema.schemata WHERE schema_name = 'tracked_changes_samplestudenttranscript') THEN
CREATE SCHEMA tracked_changes_samplestudenttranscript;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_samplestudenttranscript' AND table_name = 'postsecondaryorganization') THEN
CREATE TABLE tracked_changes_samplestudenttranscript.postsecondaryorganization
(
       oldnameofinstitution VARCHAR(75) NOT NULL,
       newnameofinstitution VARCHAR(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT postsecondaryorganization_pk PRIMARY KEY (ChangeVersion)
);
END IF;

END
$$;
