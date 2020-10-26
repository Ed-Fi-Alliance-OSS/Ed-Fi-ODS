-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SEQUENCE IF NOT EXISTS changes.ChangeVersionSequence START WITH 1;

CREATE OR REPLACE FUNCTION changes.updateChangeVersion()
    RETURNS trigger AS
$BODY$
BEGIN
    new.ChangeVersion := nextval('changes.ChangeVersionSequence');
    RETURN new;
END;
$BODY$ LANGUAGE plpgsql;
