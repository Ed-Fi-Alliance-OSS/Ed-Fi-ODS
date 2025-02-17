-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
    CREATE SEQUENCE IF NOT EXISTS changes.ChangeVersionSequence START WITH 1;

    IF NOT EXISTS (
        SELECT 1 FROM pg_proc
        JOIN pg_namespace ON pg_proc.pronamespace = pg_namespace.oid
        WHERE pg_proc.proname = 'updatechangeversion'
        AND pg_namespace.nspname = 'changes'
    ) THEN
        CREATE FUNCTION changes.updateChangeVersion()
            RETURNS trigger AS
        $BODY$
        BEGIN
            new.ChangeVersion := nextval('changes.ChangeVersionSequence');
            RETURN new;
        END;
        $BODY$ LANGUAGE plpgsql;
    END IF;
END $$;
