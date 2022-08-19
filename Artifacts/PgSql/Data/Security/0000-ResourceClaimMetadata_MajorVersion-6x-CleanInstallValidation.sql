-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
  IF EXISTS  (SELECT * FROM public."DeployJournal" WHERE scriptname = N'Artifacts.PgSql.Data.Security.0001-ResourceClaimMetadata_generated.sql')  THEN
        RAISE EXCEPTION USING MESSAGE = 'Upgrading from a previous major version of the security database to 6.x is not supported.';
  END IF;
END
$$