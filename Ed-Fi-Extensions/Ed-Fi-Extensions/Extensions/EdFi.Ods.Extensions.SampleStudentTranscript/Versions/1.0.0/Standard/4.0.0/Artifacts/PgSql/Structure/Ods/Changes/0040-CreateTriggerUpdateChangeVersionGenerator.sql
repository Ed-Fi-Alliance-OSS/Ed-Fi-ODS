CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON samplestudenttranscript.PostSecondaryOrganization
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();

