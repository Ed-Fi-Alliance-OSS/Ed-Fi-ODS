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

CREATE FUNCTION auth.edfi_School_TR_Insert()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId
    SELECT NEW.LocalEducationAgencyId, NEW.SchoolId
    WHERE NEW.LocalEducationAgencyId IS NOT NULL
    ON CONFLICT DO NOTHING;

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId
    SELECT p.SourceEducationOrganizationId, NEW.SchoolId
    FROM auth.EducationOrganizationIdToEducationOrganizationId p
    WHERE NEW.LocalEducationAgencyId IS NOT NULL
      AND NEW.LocalEducationAgencyId = p.TargetEducationOrganizationId
    ON CONFLICT DO NOTHING;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.School
    FOR EACH ROW EXECUTE PROCEDURE auth.edfi_School_TR_Insert();

CREATE FUNCTION auth.edfi_School_TR_Update()
    RETURNS trigger AS
$BODY$
BEGIN
    DELETE FROM auth.EducationOrganizationIdToEducationOrganizationId
    WHERE TargetEducationOrganizationId = OLD.SchoolId
        AND SourceEducationOrganizationId IN (
        SELECT SourceEducationOrganizationId
        FROM auth.EducationOrganizationIdToEducationOrganizationId p
        -- LocalEducationAgencyId is changing and was not originally null
        WHERE OLD.LocalEducationAgencyId IS NOT NULL
            AND TargetEducationOrganizationId = OLD.LocalEducationAgencyId
            AND (NEW.LocalEducationAgencyId IS NULL
                 OR OLD.LocalEducationAgencyId <> NEW.LocalEducationAgencyId));

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId
    SELECT NEW.LocalEducationAgencyId, NEW.SchoolId
    WHERE NEW.LocalEducationAgencyId IS NOT NULL
    ON CONFLICT DO NOTHING;

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId
    SELECT p.SourceEducationOrganizationId, NEW.SchoolId
    FROM auth.EducationOrganizationIdToEducationOrganizationId p
    WHERE NEW.LocalEducationAgencyId IS NOT NULL
      AND NEW.LocalEducationAgencyId = p.TargetEducationOrganizationId
    ON CONFLICT DO NOTHING;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER UpdateAuthTuples AFTER UPDATE ON edfi.School
    FOR EACH ROW EXECUTE PROCEDURE auth.edfi_School_TR_Update();
