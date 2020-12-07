-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  
DO $$
BEGIN
  IF EXISTS  (SELECT schema_name  FROM information_schema.schemata   WHERE schema_name = 'tpdm')  THEN
        RAISE EXCEPTION USING MESSAGE = 'Upgrades are not supported at this time for database type ODS using the TPDM data model. This tool only supports feature scripts for this type. Please use other tooling such as Migration Utility to upgrade this database.';
  END IF;
END
$$