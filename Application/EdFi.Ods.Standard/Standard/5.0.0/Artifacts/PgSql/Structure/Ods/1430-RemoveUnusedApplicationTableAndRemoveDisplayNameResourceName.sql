-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$ 
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.table_constraints AS tc
        JOIN information_schema.tables AS t ON tc.table_name = t.table_name AND tc.table_schema = t.table_schema
        WHERE t.table_schema = 'dbo'
            AND t.table_name = 'ResourceClaims'
            AND tc.constraint_name = 'fk_resourceclaims_applications'
            AND tc.constraint_type = 'FOREIGN KEY'
    )
    THEN
        ALTER TABLE "dbo"."ResourceClaims"
        DROP CONSTRAINT "fk_resourceclaims_applications";
        RAISE NOTICE 'fk_resourceclaims_applications Constraint dropped.';
    ELSE
        RAISE NOTICE 'fk_resourceclaims_applications Constraint does not exist.';
    END IF;
END $$;

DO $$ 
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.table_constraints AS tc
        JOIN information_schema.tables AS t ON tc.table_name = t.table_name AND tc.table_schema = t.table_schema
        WHERE t.table_schema = 'dbo'
            AND t.table_name = 'ClaimSets'
            AND tc.constraint_name = 'fk_claimsets_applications'
            AND tc.constraint_type = 'FOREIGN KEY'
    )
    THEN
        ALTER TABLE "dbo"."ClaimSets"
        DROP CONSTRAINT "fk_claimsets_applications";
        RAISE NOTICE 'fk_claimsets_applications Constraint dropped.';
    ELSE
        RAISE NOTICE 'fk_claimsets_applications Constraint does not exist.';
    END IF;
END $$;

DO $$ 
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.table_constraints AS tc
        JOIN information_schema.tables AS t ON tc.table_name = t.table_name AND tc.table_schema = t.table_schema
        WHERE t.table_schema = 'dbo'
            AND t.table_name = 'AuthorizationStrategies'
            AND tc.constraint_name = 'fk_authorizationstrategies_applications'
            AND tc.constraint_type = 'FOREIGN KEY'
    )
    THEN
        ALTER TABLE "dbo"."AuthorizationStrategies"
        DROP CONSTRAINT "fk_authorizationstrategies_applications";
        RAISE NOTICE 'fk_authorizationstrategies_applications Constraint dropped.';
    ELSE
        RAISE NOTICE 'fk_authorizationstrategies_applications Constraint does not exist.';
    END IF;
END $$;

DO $$ 
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.table_constraints AS tc
        JOIN information_schema.tables AS t ON tc.table_name = t.table_name AND tc.table_schema = t.table_schema
        WHERE t.table_schema = 'dbo'
            AND t.table_name = 'Applications'
            AND tc.constraint_name = 'pk_applications'
            AND tc.constraint_type = 'PRIMARY KEY'
    )
    THEN
        ALTER TABLE "dbo"."Applications"
        DROP CONSTRAINT "pk_applications";
        RAISE NOTICE 'pk_applications Constraint dropped.';
    ELSE
        RAISE NOTICE 'pk_applications Constraint does not exist.';
    END IF;
END $$;

DO $$ 
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.tables AS t
        WHERE t.table_schema = 'dbo'
            AND t.table_name = 'Applications'
    )
    THEN
        DROP TABLE "dbo"."Applications";
        RAISE NOTICE 'Table dbo.Applications dropped.';
    ELSE
        RAISE NOTICE 'Table dbo.Applications does not exist.';
    END IF;
END $$;

DO $$ 
BEGIN
    IF EXISTS (
        SELECT *
        FROM information_schema.columns
        WHERE table_schema = 'dbo'
            AND table_name = 'ResourceClaims'
            AND column_name IN ('DisplayName', 'ResourceName')
    )
    THEN
        ALTER TABLE "dbo"."ResourceClaims"
        DROP COLUMN "DisplayName",
                    "ResourceName";
        RAISE NOTICE 'Columns DisplayName and ResourceName dropped from dbo.ResourceClaims.';
    ELSE
        RAISE NOTICE 'Columns DisplayName and ResourceName do not exist in dbo.ResourceClaims.';
    END IF;
END $$;