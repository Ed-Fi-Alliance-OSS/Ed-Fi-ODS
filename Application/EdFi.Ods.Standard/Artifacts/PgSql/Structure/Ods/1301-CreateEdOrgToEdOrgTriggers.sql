-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE FUNCTION auth.edfi_EducationOrganization_TR_Insert()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId
    VALUES(NEW.EducationOrganizationId, NEW.EducationOrganizationId);
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.EducationOrganization
    FOR EACH ROW EXECUTE PROCEDURE auth.edfi_EducationOrganization_TR_Insert();

CREATE FUNCTION auth.edfi_EducationOrganization_TR_Delete()
    RETURNS trigger AS
$BODY$
BEGIN
    DELETE FROM auth.EducationOrganizationIdToEducationOrganizationId
    WHERE SourceEducationOrganizationId = OLD.EducationOrganizationId
        AND TargetEducationOrganizationId = OLD.EducationOrganizationId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.EducationOrganization
    FOR EACH ROW EXECUTE PROCEDURE auth.edfi_EducationOrganization_TR_Delete();