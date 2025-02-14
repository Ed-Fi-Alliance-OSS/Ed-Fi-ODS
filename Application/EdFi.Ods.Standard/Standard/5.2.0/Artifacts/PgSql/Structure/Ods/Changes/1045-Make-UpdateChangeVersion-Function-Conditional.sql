-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE FUNCTION changes.updateChangeVersion()
    RETURNS trigger AS
$BODY$
BEGIN
    IF old.ChangeVersion = new.ChangeVersion THEN
        -- If ChangeVersion wasn't updated, this is being invoked by trigger due to cascading key changes
        -- and we need to also update LastModifiedDate
        new.ChangeVersion := nextval('changes.ChangeVersionSequence');
        new.LastModifiedDate := NOW();
        new.AggregateData := NULL;
    END IF;

    RETURN new;
END;
$BODY$ LANGUAGE plpgsql;
