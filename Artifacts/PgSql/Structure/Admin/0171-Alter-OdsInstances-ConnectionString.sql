-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$ 
BEGIN
    IF EXISTS (SELECT 1 FROM information_schema.columns   WHERE table_name = 'odsinstances' AND column_name = 'connectionstring'  AND DATA_TYPE = 'character varying') THEN
        ALTER TABLE dbo.OdsInstances ALTER COLUMN ConnectionString TYPE character varying(1500);
    END IF;
END $$;
