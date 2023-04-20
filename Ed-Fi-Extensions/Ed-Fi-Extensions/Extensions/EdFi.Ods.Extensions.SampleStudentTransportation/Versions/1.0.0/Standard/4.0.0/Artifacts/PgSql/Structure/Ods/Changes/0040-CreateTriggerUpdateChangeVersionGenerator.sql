CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON samplestudenttransportation.StudentTransportation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();

