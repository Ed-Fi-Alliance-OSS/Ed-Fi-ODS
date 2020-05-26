-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE FUNCTION tracked_deletes_samplestudenttranscript.InstitutionControlDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_samplestudenttranscript.InstitutionControlDescriptor(InstitutionControlDescriptorId, Id, ChangeVersion)
    VALUES (OLD.InstitutionControlDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON samplestudenttranscript.InstitutionControlDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_samplestudenttranscript.InstitutionControlDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_samplestudenttranscript.InstitutionLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_samplestudenttranscript.InstitutionLevelDescriptor(InstitutionLevelDescriptorId, Id, ChangeVersion)
    VALUES (OLD.InstitutionLevelDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON samplestudenttranscript.InstitutionLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_samplestudenttranscript.InstitutionLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_samplestudenttranscript.PostSecondaryOrganization_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_samplestudenttranscript.PostSecondaryOrganization(NameOfInstitution, Id, ChangeVersion)
    VALUES (OLD.NameOfInstitution, OLD.Id, nextval('changes.ChangeVersionSequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON samplestudenttranscript.PostSecondaryOrganization 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_samplestudenttranscript.PostSecondaryOrganization_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_samplestudenttranscript.SpecialEducationGraduationStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_samplestudenttranscript.SpecialEducationGraduationStatusDescriptor(SpecialEducationGraduationStatusDescriptorId, Id, ChangeVersion)
    VALUES (OLD.SpecialEducationGraduationStatusDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON samplestudenttranscript.SpecialEducationGraduationStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_samplestudenttranscript.SpecialEducationGraduationStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_samplestudenttranscript.SubmissionCertificationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_samplestudenttranscript.SubmissionCertificationDescriptor(SubmissionCertificationDescriptorId, Id, ChangeVersion)
    VALUES (OLD.SubmissionCertificationDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON samplestudenttranscript.SubmissionCertificationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_samplestudenttranscript.SubmissionCertificationDescriptor_TR_DelTrkg();

