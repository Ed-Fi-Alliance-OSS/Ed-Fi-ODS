-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$ 
BEGIN

    IF EXISTS (
        SELECT *
        FROM information_schema.columns
        WHERE table_schema = 'dbo'
            AND table_name = 'resourceclaims'
            AND column_name IN ('displayname')
    )
    THEN
        ALTER TABLE "dbo"."resourceclaims"
        DROP COLUMN "displayname";

        RAISE NOTICE 'Column DisplayName dropped from dbo.ResourceClaims.';
    ELSE
        RAISE NOTICE 'Column DisplayName does not exist in dbo.ResourceClaims.';
    END IF;
END $$;
