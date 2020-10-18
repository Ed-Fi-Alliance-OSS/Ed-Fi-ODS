-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE FUNCTION tracked_deletes_homograph.Name_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_homograph.Name(FirstName, LastSurname, Id, ChangeVersion)
    VALUES (OLD.FirstName, OLD.LastSurname, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.Name 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_homograph.Name_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_homograph.Parent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_homograph.Parent(ParentFirstName, ParentLastSurname, Id, ChangeVersion)
    VALUES (OLD.ParentFirstName, OLD.ParentLastSurname, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.Parent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_homograph.Parent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_homograph.SchoolYearType_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_homograph.SchoolYearType(SchoolYear, Id, ChangeVersion)
    VALUES (OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.SchoolYearType 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_homograph.SchoolYearType_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_homograph.School_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_homograph.School(SchoolName, Id, ChangeVersion)
    VALUES (OLD.SchoolName, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.School 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_homograph.School_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_homograph.Staff_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_homograph.Staff(StaffFirstName, StaffLastSurname, Id, ChangeVersion)
    VALUES (OLD.StaffFirstName, OLD.StaffLastSurname, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.Staff 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_homograph.Staff_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_homograph.StudentSchoolAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_homograph.StudentSchoolAssociation(SchoolName, StudentFirstName, StudentLastSurname, Id, ChangeVersion)
    VALUES (OLD.SchoolName, OLD.StudentFirstName, OLD.StudentLastSurname, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.StudentSchoolAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_homograph.StudentSchoolAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_homograph.Student_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_homograph.Student(StudentFirstName, StudentLastSurname, Id, ChangeVersion)
    VALUES (OLD.StudentFirstName, OLD.StudentLastSurname, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON homograph.Student 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_homograph.Student_TR_DelTrkg();

