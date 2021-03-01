CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON sample.Bus
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();

CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON sample.BusRoute
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();

CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON sample.StudentGraduationPlanAssociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();

