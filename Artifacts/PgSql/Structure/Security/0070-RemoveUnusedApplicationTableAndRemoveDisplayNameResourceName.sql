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
            AND t.table_name = 'resourceclaims'
            AND tc.constraint_name = 'fk_resourceclaims_applications'
            AND tc.constraint_type = 'FOREIGN KEY'
    )
    THEN
        ALTER TABLE "dbo"."resourceclaims"
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
            AND t.table_name = 'claimsets'
            AND tc.constraint_name = 'fk_claimsets_applications'
            AND tc.constraint_type = 'FOREIGN KEY'
    )
    THEN
        ALTER TABLE "dbo"."claimsets"
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
            AND t.table_name = 'authorizationstrategies'
            AND tc.constraint_name = 'fk_authorizationstrategies_applications'
            AND tc.constraint_type = 'FOREIGN KEY'
    )
    THEN
        ALTER TABLE "dbo"."authorizationstrategies"
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
            AND t.table_name = 'applications'
            AND tc.constraint_name = 'applications_pk'
            AND tc.constraint_type = 'PRIMARY KEY'
    )
    THEN
        ALTER TABLE "dbo"."applications"
        DROP CONSTRAINT "applications_pk";
        RAISE NOTICE 'applications_pk Constraint dropped.';
    ELSE
        RAISE NOTICE 'applications_pk Constraint does not exist.';
    END IF;
END $$;

DO $$ 
BEGIN
    IF EXISTS (
        SELECT 1
        FROM information_schema.tables AS t
        WHERE t.table_schema = 'dbo'
            AND t.table_name = 'applications'
    )
    THEN
        DROP TABLE "dbo"."applications";
        RAISE NOTICE 'Table dbo.Applications dropped.';
    ELSE
        RAISE NOTICE 'Table dbo.Applications does not exist.';
    END IF;
END $$;

DO $$ 
BEGIN

    DROP INDEX IF EXISTS dbo.ix_resourceclaims_application_applicationid;

    IF EXISTS (
        SELECT *
        FROM information_schema.columns
        WHERE table_schema = 'dbo'
            AND table_name = 'resourceclaims'
            AND column_name IN ('displayname','application_applicationid')
    )
    THEN
        ALTER TABLE "dbo"."resourceclaims"
        DROP COLUMN "displayname";

        ALTER TABLE "dbo"."resourceclaims"
        DROP COLUMN application_applicationid;	
        RAISE NOTICE 'Columns DisplayName and application_applicationid dropped from dbo.ResourceClaims.';
    ELSE
        RAISE NOTICE 'Columns DisplayName and application_applicationid do not exist in dbo.ResourceClaims.';
    END IF;
END $$;

DO $$ 
BEGIN

    DROP INDEX IF EXISTS dbo.ix_claimsets_application_applicationid;

    IF EXISTS (
        SELECT *
        FROM information_schema.columns
        WHERE table_schema = 'dbo'
            AND table_name = 'claimsets'
            AND column_name IN ('application_applicationid')
    )
    THEN
        ALTER TABLE "dbo"."claimsets"
        DROP COLUMN "application_applicationid";

        RAISE NOTICE 'Column  application_applicationid dropped from dbo.claimsets.';
    ELSE
        RAISE NOTICE 'Column application_applicationid do not exist in dbo.claimsets.';
    END IF;
END $$;


DO $$ 
BEGIN

    DROP INDEX IF EXISTS dbo.ix_authorizationstrategies_application_applicationid;

    IF EXISTS (
        SELECT *
        FROM information_schema.columns
        WHERE table_schema = 'dbo'
            AND table_name = 'authorizationstrategies'
            AND column_name IN ('application_applicationid')
    )
    THEN
        ALTER TABLE "dbo"."authorizationstrategies"
        DROP COLUMN "application_applicationid";

        RAISE NOTICE 'Column  application_applicationid dropped from dbo.authorizationstrategies.';
    ELSE
        RAISE NOTICE 'Column application_applicationid do not exist in dbo.authorizationstrategies.';
    END IF;
END $$;