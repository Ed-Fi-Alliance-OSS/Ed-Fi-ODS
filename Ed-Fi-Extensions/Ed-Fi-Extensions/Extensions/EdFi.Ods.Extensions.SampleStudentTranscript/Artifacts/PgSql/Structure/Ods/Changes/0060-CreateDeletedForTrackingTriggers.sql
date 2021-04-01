CREATE FUNCTION tracked_deletes_samplestudenttranscript.InstitutionControlDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_samplestudenttranscript.InstitutionControlDescriptor(InstitutionControlDescriptorId, Id, ChangeVersion)
    SELECT OLD.InstitutionControlDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InstitutionControlDescriptorId;
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
    SELECT OLD.InstitutionLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InstitutionLevelDescriptorId;
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
    SELECT OLD.SpecialEducationGraduationStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SpecialEducationGraduationStatusDescriptorId;
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
    SELECT OLD.SubmissionCertificationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SubmissionCertificationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON samplestudenttranscript.SubmissionCertificationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_samplestudenttranscript.SubmissionCertificationDescriptor_TR_DelTrkg();

