-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE FUNCTION tracked_deletes_sample.ArtMediumDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_sample.ArtMediumDescriptor(ArtMediumDescriptorId, Id, ChangeVersion)
    SELECT OLD.ArtMediumDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ArtMediumDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.ArtMediumDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_sample.ArtMediumDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_sample.BusRoute_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_sample.BusRoute(BusId, BusRouteNumber, Id, ChangeVersion)
    VALUES (OLD.BusId, OLD.BusRouteNumber, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.BusRoute 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_sample.BusRoute_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_sample.Bus_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_sample.Bus(BusId, Id, ChangeVersion)
    VALUES (OLD.BusId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.Bus 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_sample.Bus_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_sample.FavoriteBookCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_sample.FavoriteBookCategoryDescriptor(FavoriteBookCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.FavoriteBookCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.FavoriteBookCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.FavoriteBookCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_sample.FavoriteBookCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_sample.MembershipTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_sample.MembershipTypeDescriptor(MembershipTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.MembershipTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.MembershipTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.MembershipTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_sample.MembershipTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_sample.StudentArtProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_sample.StudentArtProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.StudentArtProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_sample.StudentArtProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_sample.StudentGraduationPlanAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_sample.StudentGraduationPlanAssociation(EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.GraduationPlanTypeDescriptorId, OLD.GraduationSchoolYear, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON sample.StudentGraduationPlanAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_sample.StudentGraduationPlanAssociation_TR_DelTrkg();

