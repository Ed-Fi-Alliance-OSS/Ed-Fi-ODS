-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE FUNCTION changes.updateChangeVersion()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Always update ChangeVersion
    NEW.ChangeVersion := nextval('changes.ChangeVersionSequence');

    -- Only update LastModifiedDate if it was not modified in the update
    IF NEW.LastModifiedDate IS NOT DISTINCT FROM OLD.LastModifiedDate THEN
        NEW.LastModifiedDate := NOW();
    END IF;
    
    RETURN new;
END;
$BODY$ LANGUAGE plpgsql;
