-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION tracked_changes_edfi.absenceeventcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AbsenceEventCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AbsenceEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AbsenceEventCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'absenceeventcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.absenceeventcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.absenceeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.academichonorcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AcademicHonorCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AcademicHonorCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AcademicHonorCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'academichonorcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.academichonorcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.academichonorcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.academicsubjectdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AcademicSubjectDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AcademicSubjectDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AcademicSubjectDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'academicsubjectdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.academicsubjectdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.academicsubjectdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.academicweek_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.academicweek(
        oldschoolid, oldweekidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.schoolid, OLD.weekidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'academicweek') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.academicweek 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.academicweek_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accommodationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AccommodationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AccommodationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AccommodationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accommodationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.accommodationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accommodationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accountabilityrating_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.accountabilityrating(
        oldeducationorganizationid, oldratingtitle, oldschoolyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.ratingtitle, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accountabilityrating') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.accountabilityrating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accountabilityrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accounttypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AccountTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AccountTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AccountTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accounttypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.accounttypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accounttypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accreditationstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AccreditationStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AccreditationStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AccreditationStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accreditationstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.accreditationstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accreditationstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.achievementcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AchievementCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AchievementCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AchievementCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'achievementcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.achievementcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.achievementcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.additionalcredittypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AdditionalCreditTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AdditionalCreditTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AdditionalCreditTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'additionalcredittypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.additionalcredittypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.additionalcredittypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.addresstypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AddressTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AddressTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AddressTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'addresstypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.addresstypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.addresstypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.administrationenvironmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AdministrationEnvironmentDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AdministrationEnvironmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AdministrationEnvironmentDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'administrationenvironmentdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.administrationenvironmentdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.administrationenvironmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.administrativefundingcontroldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AdministrativeFundingControlDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AdministrativeFundingControlDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AdministrativeFundingControlDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'administrativefundingcontroldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.administrativefundingcontroldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.administrativefundingcontroldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.aidtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AidTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AidTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AidTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'aidtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.aidtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.aidtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.ancestryethnicorigindescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AncestryEthnicOriginDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AncestryEthnicOriginDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AncestryEthnicOriginDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'ancestryethnicorigindescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.ancestryethnicorigindescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.ancestryethnicorigindescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.applicantprofile_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.applicantprofile(
        oldapplicantprofileidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.applicantprofileidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'applicantprofile') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.applicantprofile 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.applicantprofile_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.application_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.application(
        oldapplicantprofileidentifier, oldapplicationidentifier, oldeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.applicantprofileidentifier, OLD.applicationidentifier, OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'application') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.application 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.application_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.applicationevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.applicationeventtypedescriptorid;

    INSERT INTO tracked_changes_edfi.applicationevent(
        oldapplicantprofileidentifier, oldapplicationeventtypedescriptorid, oldapplicationeventtypedescriptornamespace, oldapplicationeventtypedescriptorcodevalue, oldapplicationidentifier, oldeducationorganizationid, oldeventdate, oldsequencenumber,
        id, discriminator, changeversion)
    VALUES (
        OLD.applicantprofileidentifier, OLD.applicationeventtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.applicationidentifier, OLD.educationorganizationid, OLD.eventdate, OLD.sequencenumber, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'applicationevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.applicationevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.applicationevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.applicationeventresultdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ApplicationEventResultDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ApplicationEventResultDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ApplicationEventResultDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'applicationeventresultdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.applicationeventresultdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.applicationeventresultdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.applicationeventtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ApplicationEventTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ApplicationEventTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ApplicationEventTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'applicationeventtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.applicationeventtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.applicationeventtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.applicationsourcedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ApplicationSourceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ApplicationSourceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ApplicationSourceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'applicationsourcedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.applicationsourcedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.applicationsourcedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.applicationstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ApplicationStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ApplicationStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ApplicationStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'applicationstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.applicationstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.applicationstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessment_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.assessment(
        oldassessmentidentifier, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.assessmentidentifier, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessment') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessment_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentadministration_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.assessmentadministration(
        oldadministrationidentifier, oldassessmentidentifier, oldassigningeducationorganizationid, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.administrationidentifier, OLD.assessmentidentifier, OLD.assigningeducationorganizationid, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentadministration') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentadministration 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentadministration_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentadministrationparticipation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.assessmentadministrationparticipation(
        oldadministrationidentifier, oldassessmentidentifier, oldassigningeducationorganizationid, oldnamespace, oldparticipatingeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.administrationidentifier, OLD.assessmentidentifier, OLD.assigningeducationorganizationid, OLD.namespace, OLD.participatingeducationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentadministrationparticipation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentadministrationparticipation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentadministrationparticipation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentbatterypart_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.assessmentbatterypart(
        oldassessmentbatterypartname, oldassessmentidentifier, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.assessmentbatterypartname, OLD.assessmentidentifier, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentbatterypart') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentbatterypart 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentbatterypart_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AssessmentCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AssessmentCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AssessmentCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AssessmentIdentificationSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AssessmentIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AssessmentIdentificationSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentidentificationsystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentidentificationsystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentitem_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.assessmentitem(
        oldassessmentidentifier, oldidentificationcode, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.assessmentidentifier, OLD.identificationcode, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitem') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentitem 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentitem_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentitemcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AssessmentItemCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AssessmentItemCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AssessmentItemCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitemcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentitemcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentitemcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentitemresultdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AssessmentItemResultDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AssessmentItemResultDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AssessmentItemResultDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitemresultdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentitemresultdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentitemresultdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentperioddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AssessmentPeriodDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AssessmentPeriodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AssessmentPeriodDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentperioddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentperioddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentperioddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentreportingmethoddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AssessmentReportingMethodDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AssessmentReportingMethodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AssessmentReportingMethodDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentreportingmethoddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentreportingmethoddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentreportingmethoddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentscorerangelearningstandard_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.assessmentscorerangelearningstandard(
        oldassessmentidentifier, oldnamespace, oldscorerangeid,
        id, discriminator, changeversion)
    VALUES (
        OLD.assessmentidentifier, OLD.namespace, OLD.scorerangeid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentscorerangelearningstandard') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assessmentscorerangelearningstandard 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentscorerangelearningstandard_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assignmentlatestatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AssignmentLateStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AssignmentLateStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AssignmentLateStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assignmentlatestatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.assignmentlatestatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assignmentlatestatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.attemptstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AttemptStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AttemptStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AttemptStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'attemptstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.attemptstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.attemptstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.attendanceeventcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AttendanceEventCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.AttendanceEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AttendanceEventCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'attendanceeventcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.attendanceeventcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.attendanceeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.backgroundcheckstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.BackgroundCheckStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.BackgroundCheckStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.BackgroundCheckStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'backgroundcheckstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.backgroundcheckstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.backgroundcheckstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.backgroundchecktypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.BackgroundCheckTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.BackgroundCheckTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.BackgroundCheckTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'backgroundchecktypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.backgroundchecktypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.backgroundchecktypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.balancesheetdimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.balancesheetdimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'balancesheetdimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.balancesheetdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.balancesheetdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.barriertointernetaccessinresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.BarrierToInternetAccessInResidenceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.BarrierToInternetAccessInResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.BarrierToInternetAccessInResidenceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'barriertointernetaccessinresidencedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.barriertointernetaccessinresidencedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.barriertointernetaccessinresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.behaviordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.BehaviorDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.BehaviorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.BehaviorDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'behaviordescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.behaviordescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.behaviordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.bellschedule_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.bellschedule(
        oldbellschedulename, oldschoolid,
        id, discriminator, changeversion)
    VALUES (
        OLD.bellschedulename, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'bellschedule') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.bellschedule 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.bellschedule_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.busroutedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.BusRouteDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.BusRouteDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.BusRouteDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'busroutedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.busroutedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.busroutedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendar_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.calendar(
        oldcalendarcode, oldschoolid, oldschoolyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.calendarcode, OLD.schoolid, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendar') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.calendar 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendar_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendardate_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.calendardate(
        oldcalendarcode, olddate, oldschoolid, oldschoolyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.calendarcode, OLD.date, OLD.schoolid, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendardate') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.calendardate 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendardate_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendareventdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CalendarEventDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CalendarEventDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CalendarEventDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendareventdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.calendareventdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendareventdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendartypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CalendarTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CalendarTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CalendarTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendartypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.calendartypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendartypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.candidate_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.candidate(
        oldcandidateidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.candidateidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'candidate') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.candidate 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.candidate_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.candidatecharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CandidateCharacteristicDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CandidateCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CandidateCharacteristicDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'candidatecharacteristicdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.candidatecharacteristicdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.candidatecharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.candidateeducatorpreparationprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.candidateeducatorpreparationprogramassociation(
        oldbegindate, oldcandidateidentifier, oldeducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.candidateidentifier, OLD.educationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'candidateeducatorpreparationprogramassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.candidateeducatorpreparationprogramassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.candidateeducatorpreparationprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.candidateidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CandidateIdentificationSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CandidateIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CandidateIdentificationSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'candidateidentificationsystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.candidateidentificationsystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.candidateidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.candidateidentity_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.candidateidentificationsystemdescriptorid;

    INSERT INTO tracked_changes_edfi.candidateidentity(
        oldcandidateidentificationsystemdescriptorid, oldcandidateidentificationsystemdescriptornamespace, oldcandidateidentificationsystemdescriptorcodevalue, oldcandidateidentifier, oldeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.candidateidentificationsystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.candidateidentifier, OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'candidateidentity') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.candidateidentity 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.candidateidentity_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.candidaterelationshiptostaffassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.candidaterelationshiptostaffassociation(
        oldcandidateidentifier, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.candidateidentifier, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'candidaterelationshiptostaffassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.candidaterelationshiptostaffassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.candidaterelationshiptostaffassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.careerpathwaydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CareerPathwayDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CareerPathwayDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CareerPathwayDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'careerpathwaydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.careerpathwaydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.careerpathwaydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certification_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.certification(
        oldcertificationidentifier, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.certificationidentifier, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certification') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certification 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certification_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationexam_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.certificationexam(
        oldcertificationexamidentifier, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.certificationexamidentifier, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationexam') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationexam 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationexam_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationexamresult_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_edfi.certificationexamresult(
        oldcertificationexamdate, oldcertificationexamidentifier, oldnamespace, oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.certificationexamdate, OLD.certificationexamidentifier, OLD.namespace, OLD.personid, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationexamresult') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationexamresult 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationexamresult_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationexamstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CertificationExamStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CertificationExamStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CertificationExamStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationexamstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationexamstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationexamstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationexamtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CertificationExamTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CertificationExamTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CertificationExamTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationexamtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationexamtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationexamtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationfielddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CertificationFieldDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CertificationFieldDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CertificationFieldDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationfielddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationfielddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationfielddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CertificationLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CertificationLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CertificationLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationroutedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CertificationRouteDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CertificationRouteDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CertificationRouteDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationroutedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationroutedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationroutedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.certificationstandarddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CertificationStandardDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CertificationStandardDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CertificationStandardDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'certificationstandarddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.certificationstandarddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.certificationstandarddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.charterapprovalagencytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CharterApprovalAgencyTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CharterApprovalAgencyTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CharterApprovalAgencyTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'charterapprovalagencytypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.charterapprovalagencytypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.charterapprovalagencytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.charterstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CharterStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CharterStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CharterStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'charterstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.charterstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.charterstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.chartofaccount_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.chartofaccount(
        oldaccountidentifier, oldeducationorganizationid, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.accountidentifier, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'chartofaccount') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.chartofaccount 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.chartofaccount_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.citizenshipstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CitizenshipStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CitizenshipStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CitizenshipStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'citizenshipstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.citizenshipstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.citizenshipstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.classperiod_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.classperiod(
        oldclassperiodname, oldschoolid,
        id, discriminator, changeversion)
    VALUES (
        OLD.classperiodname, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'classperiod') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.classperiod 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.classperiod_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.classroompositiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ClassroomPositionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ClassroomPositionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ClassroomPositionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'classroompositiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.classroompositiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.classroompositiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohort_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.cohort(
        oldcohortidentifier, oldeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.cohortidentifier, OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohort') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.cohort 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohort_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohortscopedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CohortScopeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CohortScopeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CohortScopeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohortscopedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.cohortscopedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohortscopedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohorttypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CohortTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CohortTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CohortTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohorttypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.cohorttypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohorttypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohortyeartypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CohortYearTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CohortYearTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CohortYearTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohortyeartypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.cohortyeartypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohortyeartypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.communityproviderlicense_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.communityproviderlicense(
        oldcommunityproviderid, oldlicenseidentifier, oldlicensingorganization,
        id, discriminator, changeversion)
    VALUES (
        OLD.communityproviderid, OLD.licenseidentifier, OLD.licensingorganization, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'communityproviderlicense') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.communityproviderlicense 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.communityproviderlicense_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.competencyleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CompetencyLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CompetencyLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CompetencyLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'competencyleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.competencyleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.competencyleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.competencyobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.objectivegradeleveldescriptorid;

    INSERT INTO tracked_changes_edfi.competencyobjective(
        oldeducationorganizationid, oldobjective, oldobjectivegradeleveldescriptorid, oldobjectivegradeleveldescriptornamespace, oldobjectivegradeleveldescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.objective, OLD.objectivegradeleveldescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'competencyobjective') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.competencyobjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.competencyobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contact_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.contact(
        oldcontactusi, oldcontactuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.contactusi, OLD.contactuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contact') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.contact 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contact_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contactidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ContactIdentificationSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ContactIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ContactIdentificationSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contactidentificationsystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.contactidentificationsystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contactidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contactidentity_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.contact%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.contactidentificationsystemdescriptorid;

    SELECT INTO dj1 * FROM edfi.contact j1 WHERE contactusi = old.contactusi;

    INSERT INTO tracked_changes_edfi.contactidentity(
        oldcontactidentificationsystemdescriptorid, oldcontactidentificationsystemdescriptornamespace, oldcontactidentificationsystemdescriptorcodevalue, oldcontactusi, oldcontactuniqueid, oldeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.contactidentificationsystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.contactusi, dj1.contactuniqueid, OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contactidentity') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.contactidentity 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contactidentity_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contacttypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ContactTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ContactTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ContactTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contacttypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.contacttypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contacttypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contentclassdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ContentClassDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ContentClassDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ContentClassDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contentclassdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.contentclassdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contentclassdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.continuationofservicesreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ContinuationOfServicesReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ContinuationOfServicesReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ContinuationOfServicesReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'continuationofservicesreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.continuationofservicesreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.continuationofservicesreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.costratedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CostRateDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CostRateDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CostRateDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'costratedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.costratedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.costratedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.coteachingstyleobserveddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CoteachingStyleObservedDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CoteachingStyleObservedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CoteachingStyleObservedDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'coteachingstyleobserveddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.coteachingstyleobserveddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.coteachingstyleobserveddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.countrydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CountryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CountryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CountryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'countrydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.countrydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.countrydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.course_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.course(
        oldcoursecode, oldeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.coursecode, OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'course') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.course 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.course_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courseattemptresultdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CourseAttemptResultDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CourseAttemptResultDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CourseAttemptResultDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courseattemptresultdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.courseattemptresultdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courseattemptresultdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.coursedefinedbydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CourseDefinedByDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CourseDefinedByDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CourseDefinedByDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'coursedefinedbydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.coursedefinedbydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.coursedefinedbydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.coursegpaapplicabilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CourseGPAApplicabilityDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CourseGPAApplicabilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CourseGPAApplicabilityDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'coursegpaapplicabilitydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.coursegpaapplicabilitydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.coursegpaapplicabilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courseidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CourseIdentificationSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CourseIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CourseIdentificationSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courseidentificationsystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.courseidentificationsystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courseidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courselevelcharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CourseLevelCharacteristicDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CourseLevelCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CourseLevelCharacteristicDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courselevelcharacteristicdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.courselevelcharacteristicdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courselevelcharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courseoffering_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.courseoffering(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsessionname,
        id, discriminator, changeversion)
    VALUES (
        OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courseoffering') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.courseoffering 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courseoffering_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courserepeatcodedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CourseRepeatCodeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CourseRepeatCodeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CourseRepeatCodeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courserepeatcodedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.courserepeatcodedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courserepeatcodedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.coursetranscript_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.courseattemptresultdescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.coursetranscript(
        oldcourseattemptresultdescriptorid, oldcourseattemptresultdescriptornamespace, oldcourseattemptresultdescriptorcodevalue, oldcoursecode, oldcourseeducationorganizationid, oldeducationorganizationid, oldschoolyear, oldstudentusi, oldstudentuniqueid, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.courseattemptresultdescriptorid, dj0.namespace, dj0.codevalue, OLD.coursecode, OLD.courseeducationorganizationid, OLD.educationorganizationid, OLD.schoolyear, OLD.studentusi, dj1.studentuniqueid, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'coursetranscript') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.coursetranscript 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.coursetranscript_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credential_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.stateofissuestateabbreviationdescriptorid;

    INSERT INTO tracked_changes_edfi.credential(
        oldcredentialidentifier, oldstateofissuestateabbreviationdescriptorid, oldstateofissuestateabbreviationdescriptornamespace, oldstateofissuestateabbreviationdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.credentialidentifier, OLD.stateofissuestateabbreviationdescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credential') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.credential 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credential_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credentialevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.credentialeventtypedescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.stateofissuestateabbreviationdescriptorid;

    INSERT INTO tracked_changes_edfi.credentialevent(
        oldcredentialeventdate, oldcredentialeventtypedescriptorid, oldcredentialeventtypedescriptornamespace, oldcredentialeventtypedescriptorcodevalue, oldcredentialidentifier, oldstateofissuestateabbreviationdescriptorid, oldstateofissuestateabbreviationdescriptornamespace, oldstateofissuestateabbreviationdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.credentialeventdate, OLD.credentialeventtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.credentialidentifier, OLD.stateofissuestateabbreviationdescriptorid, dj1.namespace, dj1.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credentialevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.credentialevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credentialevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credentialeventtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CredentialEventTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CredentialEventTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CredentialEventTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credentialeventtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.credentialeventtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credentialeventtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credentialfielddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CredentialFieldDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CredentialFieldDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CredentialFieldDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credentialfielddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.credentialfielddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credentialfielddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credentialstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CredentialStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CredentialStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CredentialStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credentialstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.credentialstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credentialstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credentialtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CredentialTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CredentialTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CredentialTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credentialtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.credentialtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credentialtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.creditcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CreditCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CreditCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CreditCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'creditcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.creditcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.creditcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credittypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CreditTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CreditTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CreditTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credittypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.credittypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credittypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.crisisevent_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.crisisevent(
        oldcrisiseventname,
        id, discriminator, changeversion)
    VALUES (
        OLD.crisiseventname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'crisisevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.crisisevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.crisisevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.crisistypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CrisisTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CrisisTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CrisisTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'crisistypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.crisistypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.crisistypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cteprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CTEProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CTEProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CTEProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cteprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.cteprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cteprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.curriculumuseddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CurriculumUsedDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.CurriculumUsedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CurriculumUsedDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'curriculumuseddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.curriculumuseddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.curriculumuseddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.degreedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DegreeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DegreeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DegreeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'degreedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.degreedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.degreedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.deliverymethoddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DeliveryMethodDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DeliveryMethodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DeliveryMethodDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'deliverymethoddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.deliverymethoddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.deliverymethoddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.descriptormapping_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptormapping(
        oldmappednamespace, oldmappedvalue, oldnamespace, oldvalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.mappednamespace, OLD.mappedvalue, OLD.namespace, OLD.value, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'descriptormapping') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.descriptormapping 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.descriptormapping_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.diagnosisdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DiagnosisDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DiagnosisDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DiagnosisDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'diagnosisdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.diagnosisdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.diagnosisdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.diplomaleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DiplomaLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DiplomaLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DiplomaLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'diplomaleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.diplomaleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.diplomaleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.diplomatypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DiplomaTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DiplomaTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DiplomaTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'diplomatypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.diplomatypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.diplomatypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disabilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DisabilityDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DisabilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DisabilityDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disabilitydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disabilitydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disabilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disabilitydesignationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DisabilityDesignationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DisabilityDesignationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DisabilityDesignationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disabilitydesignationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disabilitydesignationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disabilitydesignationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disabilitydeterminationsourcetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DisabilityDeterminationSourceTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DisabilityDeterminationSourceTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DisabilityDeterminationSourceTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disabilitydeterminationsourcetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disabilitydeterminationsourcetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disabilitydeterminationsourcetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineaction_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.disciplineaction(
        olddisciplineactionidentifier, olddisciplinedate, oldstudentusi, oldstudentuniqueid, oldresponsibilityschoolid,
        id, discriminator, changeversion)
    VALUES (
        OLD.disciplineactionidentifier, OLD.disciplinedate, OLD.studentusi, dj0.studentuniqueid, OLD.responsibilityschoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineaction') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disciplineaction 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineaction_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineactionlengthdifferencereasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DisciplineActionLengthDifferenceReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DisciplineActionLengthDifferenceReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DisciplineActionLengthDifferenceReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineactionlengthdifferencereasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disciplineactionlengthdifferencereasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineactionlengthdifferencereasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplinedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DisciplineDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DisciplineDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DisciplineDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplinedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disciplinedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplinedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineincident_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.disciplineincident(
        oldincidentidentifier, oldschoolid,
        id, discriminator, changeversion)
    VALUES (
        OLD.incidentidentifier, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineincident') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disciplineincident 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineincident_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineincidentparticipationcodedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DisciplineIncidentParticipationCodeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DisciplineIncidentParticipationCodeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DisciplineIncidentParticipationCodeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineincidentparticipationcodedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.disciplineincidentparticipationcodedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineincidentparticipationcodedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.displacedstudentstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DisplacedStudentStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DisplacedStudentStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DisplacedStudentStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'displacedstudentstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.displacedstudentstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.displacedstudentstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.dualcreditinstitutiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DualCreditInstitutionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DualCreditInstitutionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DualCreditInstitutionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'dualcreditinstitutiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.dualcreditinstitutiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.dualcreditinstitutiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.dualcredittypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.DualCreditTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.DualCreditTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.DualCreditTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'dualcredittypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.dualcredittypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.dualcredittypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationalenvironmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EducationalEnvironmentDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EducationalEnvironmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EducationalEnvironmentDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationalenvironmentdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationalenvironmentdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationalenvironmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationcontent_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.educationcontent(
        oldcontentidentifier,
        id, oldnamespace, discriminator, changeversion)
    VALUES (
        OLD.contentidentifier, 
        OLD.id, OLD.namespace, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationcontent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationcontent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationcontent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganization_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.educationorganization(
        oldeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganization') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganization 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganization_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationassociationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EducationOrganizationAssociationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EducationOrganizationAssociationTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EducationOrganizationAssociationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationassociationtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganizationassociationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationassociationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EducationOrganizationCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EducationOrganizationCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EducationOrganizationCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganizationcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EducationOrganizationIdentificationSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EducationOrganizationIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EducationOrganizationIdentificationSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationidentificationsystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganizationidentificationsystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationidentity_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.educationorganizationidentificationsystemdescriptorid;

    INSERT INTO tracked_changes_edfi.educationorganizationidentity(
        oldeducationorganizationid, oldeducationorganizationidentificationsystemdescriptorid, oldeducationorganizationidentificationsystemdescriptornamespace, oldeducationorganizationidentificationsystemdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.educationorganizationidentificationsystemdescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationidentity') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganizationidentity 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationidentity_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationinterventionprescriptionass_e670ae_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.educationorganizationinterventionprescriptionassociation(
        oldeducationorganizationid, oldinterventionprescriptioneducationorganizationid, oldinterventionprescriptionidentificationcode,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.interventionprescriptioneducationorganizationid, OLD.interventionprescriptionidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationinterventionprescriptionassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganizationinterventionprescriptionassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationinterventionprescriptionass_e670ae_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationnetworkassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.educationorganizationnetworkassociation(
        oldeducationorganizationnetworkid, oldmembereducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationnetworkid, OLD.membereducationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationnetworkassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganizationnetworkassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationnetworkassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationpeerassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.educationorganizationpeerassociation(
        oldeducationorganizationid, oldpeereducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.peereducationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationpeerassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationorganizationpeerassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationpeerassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationplandescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EducationPlanDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EducationPlanDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EducationPlanDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationplandescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educationplandescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationplandescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educatorpreparationprogram_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.educatorpreparationprogram(
        oldeducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educatorpreparationprogram') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educatorpreparationprogram 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educatorpreparationprogram_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educatorroledescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EducatorRoleDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EducatorRoleDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EducatorRoleDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educatorroledescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.educatorroledescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educatorroledescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.electronicmailtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ElectronicMailTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ElectronicMailTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ElectronicMailTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'electronicmailtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.electronicmailtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.electronicmailtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.eligibilitydelayreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EligibilityDelayReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EligibilityDelayReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EligibilityDelayReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'eligibilitydelayreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.eligibilitydelayreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.eligibilitydelayreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.eligibilityevaluationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EligibilityEvaluationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EligibilityEvaluationTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EligibilityEvaluationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'eligibilityevaluationtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.eligibilityevaluationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.eligibilityevaluationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.employmentstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EmploymentStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EmploymentStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EmploymentStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'employmentstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.employmentstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.employmentstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.englishlanguageexamdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EnglishLanguageExamDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EnglishLanguageExamDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EnglishLanguageExamDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'englishlanguageexamdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.englishlanguageexamdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.englishlanguageexamdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.enrollmenttypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EnrollmentTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EnrollmentTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EnrollmentTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'enrollmenttypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.enrollmenttypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.enrollmenttypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.entrygradelevelreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EntryGradeLevelReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EntryGradeLevelReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EntryGradeLevelReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'entrygradelevelreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.entrygradelevelreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.entrygradelevelreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.entrytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EntryTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EntryTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EntryTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'entrytypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.entrytypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.entrytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.eppdegreetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EPPDegreeTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EPPDegreeTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EPPDegreeTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'eppdegreetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.eppdegreetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.eppdegreetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.eppprogrampathwaydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EPPProgramPathwayDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EPPProgramPathwayDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EPPProgramPathwayDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'eppprogrampathwaydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.eppprogrampathwaydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.eppprogrampathwaydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.evaluation(
        oldeducationorganizationid, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationdelayreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationDelayReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EvaluationDelayReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationDelayReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationdelayreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationdelayreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationdelayreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationelement_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.evaluationelement(
        oldeducationorganizationid, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationelement') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationelement 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationelement_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationelementrating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.evaluationelementrating(
        oldeducationorganizationid, oldevaluationdate, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationelementrating') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationelementrating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationelementrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationelementratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationElementRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EvaluationElementRatingLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationElementRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationelementratingleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationelementratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationelementratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.evaluationobjective(
        oldeducationorganizationid, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationobjective') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationobjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationobjectiverating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.evaluationobjectiverating(
        oldeducationorganizationid, oldevaluationdate, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationobjectiverating') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationobjectiverating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationobjectiverating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationperioddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationPeriodDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EvaluationPeriodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationPeriodDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationperioddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationperioddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationperioddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationrating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.evaluationrating(
        oldeducationorganizationid, oldevaluationdate, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationrating') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationrating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EvaluationRatingLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationratingleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationratingstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationRatingStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EvaluationRatingStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationRatingStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationratingstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationratingstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationratingstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationrubricdimension_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programevaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.programevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.evaluationrubricdimension(
        oldevaluationrubricrating, oldprogrameducationorganizationid, oldprogramevaluationelementtitle, oldprogramevaluationperioddescriptorid, oldprogramevaluationperioddescriptornamespace, oldprogramevaluationperioddescriptorcodevalue, oldprogramevaluationtitle, oldprogramevaluationtypedescriptorid, oldprogramevaluationtypedescriptornamespace, oldprogramevaluationtypedescriptorcodevalue, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.evaluationrubricrating, OLD.programeducationorganizationid, OLD.programevaluationelementtitle, OLD.programevaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.programevaluationtitle, OLD.programevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.programname, OLD.programtypedescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationrubricdimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationrubricdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationrubricdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.evaluationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EvaluationTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'evaluationtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.evaluationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.evaluationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.eventcircumstancedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EventCircumstanceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.EventCircumstanceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EventCircumstanceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'eventcircumstancedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.eventcircumstancedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.eventcircumstancedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.exitwithdrawtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ExitWithdrawTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ExitWithdrawTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ExitWithdrawTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'exitwithdrawtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.exitwithdrawtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.exitwithdrawtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.federallocalecodedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.FederalLocaleCodeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.FederalLocaleCodeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.FederalLocaleCodeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'federallocalecodedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.federallocalecodedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.federallocalecodedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.feederschoolassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.feederschoolassociation(
        oldbegindate, oldfeederschoolid, oldschoolid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.feederschoolid, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'feederschoolassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.feederschoolassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.feederschoolassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.fieldworkexperience_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.fieldworkexperience(
        oldbegindate, oldfieldworkidentifier, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.fieldworkidentifier, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'fieldworkexperience') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.fieldworkexperience 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.fieldworkexperience_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.fieldworkexperiencesectionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.fieldworkexperiencesectionassociation(
        oldbegindate, oldfieldworkidentifier, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.fieldworkidentifier, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'fieldworkexperiencesectionassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.fieldworkexperiencesectionassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.fieldworkexperiencesectionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.fieldworktypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.FieldworkTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.FieldworkTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.FieldworkTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'fieldworktypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.fieldworktypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.fieldworktypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.financialaid_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.aidtypedescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.financialaid(
        oldaidtypedescriptorid, oldaidtypedescriptornamespace, oldaidtypedescriptorcodevalue, oldbegindate, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.aidtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.begindate, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'financialaid') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.financialaid 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.financialaid_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.financialcollectiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.FinancialCollectionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.FinancialCollectionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.FinancialCollectionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'financialcollectiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.financialcollectiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.financialcollectiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.functiondimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.functiondimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'functiondimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.functiondimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.functiondimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.funddimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.funddimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'funddimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.funddimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.funddimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.fundingsourcedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.FundingSourceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.FundingSourceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.FundingSourceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'fundingsourcedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.fundingsourcedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.fundingsourcedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.generalstudentprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.generalstudentprogramassociation(
        oldbegindate, oldeducationorganizationid, oldprogrameducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.educationorganizationid, OLD.programeducationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'generalstudentprogramassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.generalstudentprogramassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.generalstudentprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.goal_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_edfi.goal(
        oldassignmentdate, oldgoaltitle, oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.assignmentdate, OLD.goaltitle, OLD.personid, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'goal') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.goal 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.goal_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.goaltypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GoalTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GoalTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GoalTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'goaltypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.goaltypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.goaltypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.grade_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.gradetypedescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.gradingperioddescriptorid;

    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.grade(
        oldbegindate, oldgradetypedescriptorid, oldgradetypedescriptornamespace, oldgradetypedescriptorcodevalue, oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodname, oldgradingperiodschoolyear, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.gradetypedescriptorid, dj0.namespace, dj0.codevalue, OLD.gradingperioddescriptorid, dj1.namespace, dj1.codevalue, OLD.gradingperiodname, OLD.gradingperiodschoolyear, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'grade') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.grade 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.grade_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradebookentry_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.gradebookentry(
        oldgradebookentryidentifier, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.gradebookentryidentifier, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradebookentry') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gradebookentry 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradebookentry_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradebookentrytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GradebookEntryTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GradebookEntryTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GradebookEntryTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradebookentrytypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gradebookentrytypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradebookentrytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradeleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GradeLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GradeLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GradeLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradeleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gradeleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradeleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradepointaveragetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GradePointAverageTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GradePointAverageTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GradePointAverageTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradepointaveragetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gradepointaveragetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradepointaveragetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GradeTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GradeTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GradeTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gradetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradingperiod_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.gradingperioddescriptorid;

    INSERT INTO tracked_changes_edfi.gradingperiod(
        oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodname, oldschoolid, oldschoolyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.gradingperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.gradingperiodname, OLD.schoolid, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradingperiod') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gradingperiod 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradingperiod_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradingperioddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GradingPeriodDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GradingPeriodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GradingPeriodDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradingperioddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gradingperioddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradingperioddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.graduationplan_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.graduationplantypedescriptorid;

    INSERT INTO tracked_changes_edfi.graduationplan(
        oldeducationorganizationid, oldgraduationplantypedescriptorid, oldgraduationplantypedescriptornamespace, oldgraduationplantypedescriptorcodevalue, oldgraduationschoolyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.graduationplantypedescriptorid, dj0.namespace, dj0.codevalue, OLD.graduationschoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'graduationplan') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.graduationplan 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.graduationplan_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.graduationplantypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GraduationPlanTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GraduationPlanTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GraduationPlanTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'graduationplantypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.graduationplantypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.graduationplantypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gunfreeschoolsactreportingstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GunFreeSchoolsActReportingStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.GunFreeSchoolsActReportingStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GunFreeSchoolsActReportingStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gunfreeschoolsactreportingstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.gunfreeschoolsactreportingstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gunfreeschoolsactreportingstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.hirestatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.HireStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.HireStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.HireStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'hirestatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.hirestatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.hirestatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.hiringsourcedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.HiringSourceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.HiringSourceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.HiringSourceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'hiringsourcedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.hiringsourcedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.hiringsourcedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.homelessprimarynighttimeresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.HomelessPrimaryNighttimeResidenceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.HomelessPrimaryNighttimeResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.HomelessPrimaryNighttimeResidenceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'homelessprimarynighttimeresidencedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.homelessprimarynighttimeresidencedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.homelessprimarynighttimeresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.homelessprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.HomelessProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.HomelessProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.HomelessProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'homelessprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.homelessprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.homelessprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.ideapartdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.IDEAPartDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.IDEAPartDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.IDEAPartDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'ideapartdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.ideapartdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.ideapartdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.identificationdocumentusedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.IdentificationDocumentUseDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.IdentificationDocumentUseDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.IdentificationDocumentUseDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'identificationdocumentusedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.identificationdocumentusedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.identificationdocumentusedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.immunizationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ImmunizationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ImmunizationTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ImmunizationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'immunizationtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.immunizationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.immunizationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.incidentlocationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.IncidentLocationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.IncidentLocationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.IncidentLocationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'incidentlocationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.incidentlocationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.incidentlocationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.indicatordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.IndicatorDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.IndicatorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.IndicatorDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'indicatordescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.indicatordescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.indicatordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.indicatorgroupdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.IndicatorGroupDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.IndicatorGroupDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.IndicatorGroupDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'indicatorgroupdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.indicatorgroupdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.indicatorgroupdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.indicatorleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.IndicatorLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.IndicatorLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.IndicatorLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'indicatorleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.indicatorleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.indicatorleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.institutiontelephonenumbertypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InstitutionTelephoneNumberTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InstitutionTelephoneNumberTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InstitutionTelephoneNumberTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'institutiontelephonenumbertypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.institutiontelephonenumbertypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.institutiontelephonenumbertypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.instructionalsettingdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InstructionalSettingDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InstructionalSettingDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InstructionalSettingDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'instructionalsettingdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.instructionalsettingdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.instructionalsettingdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interactivitystyledescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InteractivityStyleDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InteractivityStyleDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InteractivityStyleDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interactivitystyledescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.interactivitystyledescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interactivitystyledescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.internetaccessdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InternetAccessDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InternetAccessDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InternetAccessDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'internetaccessdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.internetaccessdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.internetaccessdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.internetaccesstypeinresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InternetAccessTypeInResidenceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InternetAccessTypeInResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InternetAccessTypeInResidenceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'internetaccesstypeinresidencedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.internetaccesstypeinresidencedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.internetaccesstypeinresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.internetperformanceinresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InternetPerformanceInResidenceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InternetPerformanceInResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InternetPerformanceInResidenceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'internetperformanceinresidencedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.internetperformanceinresidencedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.internetperformanceinresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.intervention_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.intervention(
        oldeducationorganizationid, oldinterventionidentificationcode,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.interventionidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'intervention') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.intervention 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.intervention_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventionclassdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InterventionClassDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InterventionClassDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InterventionClassDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventionclassdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.interventionclassdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventionclassdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventioneffectivenessratingdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.InterventionEffectivenessRatingDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.InterventionEffectivenessRatingDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.InterventionEffectivenessRatingDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventioneffectivenessratingdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.interventioneffectivenessratingdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventioneffectivenessratingdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventionprescription_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.interventionprescription(
        oldeducationorganizationid, oldinterventionprescriptionidentificationcode,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.interventionprescriptionidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventionprescription') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.interventionprescription 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventionprescription_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventionstudy_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.interventionstudy(
        oldeducationorganizationid, oldinterventionstudyidentificationcode,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.interventionstudyidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventionstudy') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.interventionstudy 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventionstudy_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.languagedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LanguageDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LanguageDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LanguageDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'languagedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.languagedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.languagedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.languageinstructionprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LanguageInstructionProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LanguageInstructionProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LanguageInstructionProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'languageinstructionprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.languageinstructionprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.languageinstructionprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.languageusedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LanguageUseDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LanguageUseDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LanguageUseDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'languageusedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.languageusedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.languageusedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandard_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.learningstandard(
        oldlearningstandardid,
        id, oldnamespace, discriminator, changeversion)
    VALUES (
        OLD.learningstandardid, 
        OLD.id, OLD.namespace, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandard') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.learningstandard 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandard_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LearningStandardCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LearningStandardCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LearningStandardCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.learningstandardcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardequivalenceassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.learningstandardequivalenceassociation(
        oldnamespace, oldsourcelearningstandardid, oldtargetlearningstandardid,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.sourcelearningstandardid, OLD.targetlearningstandardid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardequivalenceassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.learningstandardequivalenceassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardequivalenceassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardequivalencestrengthdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LearningStandardEquivalenceStrengthDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LearningStandardEquivalenceStrengthDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LearningStandardEquivalenceStrengthDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardequivalencestrengthdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.learningstandardequivalencestrengthdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardequivalencestrengthdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardscopedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LearningStandardScopeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LearningStandardScopeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LearningStandardScopeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardscopedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.learningstandardscopedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardscopedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.lengthofcontractdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LengthOfContractDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LengthOfContractDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LengthOfContractDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'lengthofcontractdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.lengthofcontractdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.lengthofcontractdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.levelofeducationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LevelOfEducationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LevelOfEducationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LevelOfEducationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'levelofeducationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.levelofeducationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.levelofeducationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.licensestatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LicenseStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LicenseStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LicenseStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'licensestatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.licensestatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.licensestatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.licensetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LicenseTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LicenseTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LicenseTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'licensetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.licensetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.licensetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.limitedenglishproficiencydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LimitedEnglishProficiencyDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LimitedEnglishProficiencyDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LimitedEnglishProficiencyDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'limitedenglishproficiencydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.limitedenglishproficiencydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.limitedenglishproficiencydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localaccount_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.localaccount(
        oldaccountidentifier, oldeducationorganizationid, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.accountidentifier, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localaccount') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localaccount 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localaccount_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localactual_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.localactual(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localactual') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localactual 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localactual_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localbudget_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.localbudget(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localbudget') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localbudget 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localbudget_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localcontractedstaff_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.localcontractedstaff(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localcontractedstaff') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localcontractedstaff 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localcontractedstaff_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LocaleDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LocaleDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LocaleDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localeducationagencycategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.LocalEducationAgencyCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.LocalEducationAgencyCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.LocalEducationAgencyCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localeducationagencycategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localeducationagencycategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localeducationagencycategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localencumbrance_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.localencumbrance(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localencumbrance') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localencumbrance 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localencumbrance_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localpayroll_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.localpayroll(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localpayroll') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.localpayroll 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localpayroll_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.location_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.location(
        oldclassroomidentificationcode, oldschoolid,
        id, discriminator, changeversion)
    VALUES (
        OLD.classroomidentificationcode, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'location') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.location 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.location_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.magnetspecialprogramemphasisschooldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.MagnetSpecialProgramEmphasisSchoolDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.MagnetSpecialProgramEmphasisSchoolDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.MagnetSpecialProgramEmphasisSchoolDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'magnetspecialprogramemphasisschooldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.magnetspecialprogramemphasisschooldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.magnetspecialprogramemphasisschooldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.mediumofinstructiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.MediumOfInstructionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.MediumOfInstructionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.MediumOfInstructionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'mediumofinstructiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.mediumofinstructiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.mediumofinstructiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.methodcreditearneddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.MethodCreditEarnedDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.MethodCreditEarnedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.MethodCreditEarnedDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'methodcreditearneddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.methodcreditearneddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.methodcreditearneddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.migranteducationprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.MigrantEducationProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.MigrantEducationProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.MigrantEducationProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'migranteducationprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.migranteducationprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.migranteducationprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.modelentitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ModelEntityDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ModelEntityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ModelEntityDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'modelentitydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.modelentitydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.modelentitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.monitoreddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.MonitoredDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.MonitoredDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.MonitoredDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'monitoreddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.monitoreddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.monitoreddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.neglectedordelinquentprogramdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.NeglectedOrDelinquentProgramDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.NeglectedOrDelinquentProgramDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.NeglectedOrDelinquentProgramDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'neglectedordelinquentprogramdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.neglectedordelinquentprogramdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.neglectedordelinquentprogramdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.neglectedordelinquentprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.NeglectedOrDelinquentProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.NeglectedOrDelinquentProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.NeglectedOrDelinquentProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'neglectedordelinquentprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.neglectedordelinquentprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.neglectedordelinquentprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.networkpurposedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.NetworkPurposeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.NetworkPurposeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.NetworkPurposeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'networkpurposedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.networkpurposedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.networkpurposedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.nonmedicalimmunizationexemptiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.NonMedicalImmunizationExemptionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.NonMedicalImmunizationExemptionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.NonMedicalImmunizationExemptionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'nonmedicalimmunizationexemptiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.nonmedicalimmunizationexemptiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.nonmedicalimmunizationexemptiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.objectdimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.objectdimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'objectdimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.objectdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.objectdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.objectiveassessment_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.objectiveassessment(
        oldassessmentidentifier, oldidentificationcode, oldnamespace,
        id, discriminator, changeversion)
    VALUES (
        OLD.assessmentidentifier, OLD.identificationcode, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'objectiveassessment') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.objectiveassessment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.objectiveassessment_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.objectiveratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ObjectiveRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ObjectiveRatingLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ObjectiveRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'objectiveratingleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.objectiveratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.objectiveratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.openstaffposition_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.openstaffposition(
        oldeducationorganizationid, oldrequisitionnumber,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.requisitionnumber, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffposition') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.openstaffposition 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.openstaffposition_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.openstaffpositionevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.openstaffpositioneventtypedescriptorid;

    INSERT INTO tracked_changes_edfi.openstaffpositionevent(
        oldeducationorganizationid, oldeventdate, oldopenstaffpositioneventtypedescriptorid, oldopenstaffpositioneventtypedescriptornamespace, oldopenstaffpositioneventtypedescriptorcodevalue, oldrequisitionnumber,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.eventdate, OLD.openstaffpositioneventtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.requisitionnumber, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffpositionevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.openstaffpositionevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.openstaffpositionevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.openstaffpositioneventstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.OpenStaffPositionEventStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.OpenStaffPositionEventStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.OpenStaffPositionEventStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffpositioneventstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.openstaffpositioneventstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.openstaffpositioneventstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.openstaffpositioneventtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.OpenStaffPositionEventTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.OpenStaffPositionEventTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.OpenStaffPositionEventTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffpositioneventtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.openstaffpositioneventtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.openstaffpositioneventtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.openstaffpositionreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.OpenStaffPositionReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.OpenStaffPositionReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.OpenStaffPositionReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffpositionreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.openstaffpositionreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.openstaffpositionreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.operationalstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.OperationalStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.OperationalStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.OperationalStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'operationalstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.operationalstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.operationalstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.operationalunitdimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.operationalunitdimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'operationalunitdimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.operationalunitdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.operationalunitdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.othernametypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.OtherNameTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.OtherNameTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.OtherNameTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'othernametypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.othernametypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.othernametypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.participationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ParticipationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ParticipationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ParticipationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'participationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.participationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.participationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.participationstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ParticipationStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ParticipationStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ParticipationStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'participationstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.participationstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.participationstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.path_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.path(
        oldeducationorganizationid, oldpathname,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.pathname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'path') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.path 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.path_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.pathmilestone_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.pathmilestonetypedescriptorid;

    INSERT INTO tracked_changes_edfi.pathmilestone(
        oldpathmilestonename, oldpathmilestonetypedescriptorid, oldpathmilestonetypedescriptornamespace, oldpathmilestonetypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.pathmilestonename, OLD.pathmilestonetypedescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'pathmilestone') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.pathmilestone 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.pathmilestone_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.pathmilestonestatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PathMilestoneStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PathMilestoneStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PathMilestoneStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'pathmilestonestatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.pathmilestonestatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.pathmilestonestatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.pathmilestonetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PathMilestoneTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PathMilestoneTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PathMilestoneTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'pathmilestonetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.pathmilestonetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.pathmilestonetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.pathphase_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.pathphase(
        oldeducationorganizationid, oldpathname, oldpathphasename,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.pathname, OLD.pathphasename, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'pathphase') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.pathphase 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.pathphase_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.pathphasestatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PathPhaseStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PathPhaseStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PathPhaseStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'pathphasestatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.pathphasestatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.pathphasestatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performancebaseconversiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PerformanceBaseConversionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PerformanceBaseConversionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PerformanceBaseConversionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performancebaseconversiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.performancebaseconversiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performancebaseconversiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performanceevaluation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.performanceevaluation(
        oldeducationorganizationid, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performanceevaluation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.performanceevaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performanceevaluation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performanceevaluationrating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.performanceevaluationrating(
        oldeducationorganizationid, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performanceevaluationrating') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.performanceevaluationrating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performanceevaluationrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performanceevaluationratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PerformanceEvaluationRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PerformanceEvaluationRatingLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PerformanceEvaluationRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performanceevaluationratingleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.performanceevaluationratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performanceevaluationratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performanceevaluationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PerformanceEvaluationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PerformanceEvaluationTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PerformanceEvaluationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performanceevaluationtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.performanceevaluationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performanceevaluationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performanceleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PerformanceLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PerformanceLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PerformanceLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performanceleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.performanceleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performanceleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.person_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_edfi.person(
        oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.personid, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'person') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.person 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.person_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.personalinformationverificationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PersonalInformationVerificationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PersonalInformationVerificationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PersonalInformationVerificationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'personalinformationverificationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.personalinformationverificationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.personalinformationverificationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.platformtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PlatformTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PlatformTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PlatformTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'platformtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.platformtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.platformtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.populationserveddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PopulationServedDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PopulationServedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PopulationServedDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'populationserveddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.populationserveddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.populationserveddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postingresultdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PostingResultDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PostingResultDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PostingResultDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postingresultdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.postingresultdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postingresultdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postsecondaryevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.postsecondaryeventcategorydescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.postsecondaryevent(
        oldeventdate, oldpostsecondaryeventcategorydescriptorid, oldpostsecondaryeventcategorydescriptornamespace, oldpostsecondaryeventcategorydescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.eventdate, OLD.postsecondaryeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.postsecondaryevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postsecondaryevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postsecondaryeventcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PostSecondaryEventCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PostSecondaryEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PostSecondaryEventCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryeventcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.postsecondaryeventcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postsecondaryeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postsecondaryinstitutionleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PostSecondaryInstitutionLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PostSecondaryInstitutionLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PostSecondaryInstitutionLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryinstitutionleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.postsecondaryinstitutionleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postsecondaryinstitutionleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.previouscareerdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PreviousCareerDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PreviousCareerDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PreviousCareerDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'previouscareerdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.previouscareerdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.previouscareerdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.primarylearningdeviceaccessdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PrimaryLearningDeviceAccessDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PrimaryLearningDeviceAccessDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PrimaryLearningDeviceAccessDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'primarylearningdeviceaccessdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.primarylearningdeviceaccessdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.primarylearningdeviceaccessdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.primarylearningdeviceawayfromschooldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PrimaryLearningDeviceAwayFromSchoolDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PrimaryLearningDeviceAwayFromSchoolDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'primarylearningdeviceawayfromschooldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.primarylearningdeviceawayfromschooldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.primarylearningdeviceawayfromschooldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.primarylearningdeviceproviderdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PrimaryLearningDeviceProviderDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PrimaryLearningDeviceProviderDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PrimaryLearningDeviceProviderDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'primarylearningdeviceproviderdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.primarylearningdeviceproviderdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.primarylearningdeviceproviderdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.professionaldevelopmentevent_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.professionaldevelopmentevent(
        oldnamespace, oldprofessionaldevelopmenttitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.professionaldevelopmenttitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'professionaldevelopmentevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.professionaldevelopmentevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.professionaldevelopmentevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.professionaldevelopmenteventattendance_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_edfi.professionaldevelopmenteventattendance(
        oldattendancedate, oldnamespace, oldpersonid, oldprofessionaldevelopmenttitle, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.attendancedate, OLD.namespace, OLD.personid, OLD.professionaldevelopmenttitle, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'professionaldevelopmenteventattendance') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.professionaldevelopmenteventattendance 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.professionaldevelopmenteventattendance_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.professionaldevelopmentofferedbydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProfessionalDevelopmentOfferedByDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProfessionalDevelopmentOfferedByDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProfessionalDevelopmentOfferedByDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'professionaldevelopmentofferedbydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.professionaldevelopmentofferedbydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.professionaldevelopmentofferedbydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.proficiencydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProficiencyDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProficiencyDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProficiencyDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'proficiencydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.proficiencydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.proficiencydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.program_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.program(
        oldeducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'program') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.program 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.program_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programassignmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgramAssignmentDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgramAssignmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgramAssignmentDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programassignmentdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programassignmentdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programassignmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programcharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgramCharacteristicDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgramCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgramCharacteristicDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programcharacteristicdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programcharacteristicdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programcharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programdimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.programdimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programdimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programevaluation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programevaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.programevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.programevaluation(
        oldprogrameducationorganizationid, oldprogramevaluationperioddescriptorid, oldprogramevaluationperioddescriptornamespace, oldprogramevaluationperioddescriptorcodevalue, oldprogramevaluationtitle, oldprogramevaluationtypedescriptorid, oldprogramevaluationtypedescriptornamespace, oldprogramevaluationtypedescriptorcodevalue, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.programeducationorganizationid, OLD.programevaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.programevaluationtitle, OLD.programevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.programname, OLD.programtypedescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programevaluation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programevaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programevaluation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programevaluationelement_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programevaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.programevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.programevaluationelement(
        oldprogrameducationorganizationid, oldprogramevaluationelementtitle, oldprogramevaluationperioddescriptorid, oldprogramevaluationperioddescriptornamespace, oldprogramevaluationperioddescriptorcodevalue, oldprogramevaluationtitle, oldprogramevaluationtypedescriptorid, oldprogramevaluationtypedescriptornamespace, oldprogramevaluationtypedescriptorcodevalue, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.programeducationorganizationid, OLD.programevaluationelementtitle, OLD.programevaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.programevaluationtitle, OLD.programevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.programname, OLD.programtypedescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programevaluationelement') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programevaluationelement 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programevaluationelement_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programevaluationobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programevaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.programevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.programevaluationobjective(
        oldprogrameducationorganizationid, oldprogramevaluationobjectivetitle, oldprogramevaluationperioddescriptorid, oldprogramevaluationperioddescriptornamespace, oldprogramevaluationperioddescriptorcodevalue, oldprogramevaluationtitle, oldprogramevaluationtypedescriptorid, oldprogramevaluationtypedescriptornamespace, oldprogramevaluationtypedescriptorcodevalue, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.programeducationorganizationid, OLD.programevaluationobjectivetitle, OLD.programevaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.programevaluationtitle, OLD.programevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.programname, OLD.programtypedescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programevaluationobjective') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programevaluationobjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programevaluationobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programevaluationperioddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgramEvaluationPeriodDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgramEvaluationPeriodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgramEvaluationPeriodDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programevaluationperioddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programevaluationperioddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programevaluationperioddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programevaluationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgramEvaluationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgramEvaluationTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgramEvaluationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programevaluationtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programevaluationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programevaluationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programsponsordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgramSponsorDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgramSponsorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgramSponsorDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programsponsordescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programsponsordescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programsponsordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgramTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgramTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgramTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.programtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.progressdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgressDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgressDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgressDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'progressdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.progressdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.progressdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.progressleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProgressLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProgressLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProgressLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'progressleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.progressleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.progressleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.projectdimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.projectdimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'projectdimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.projectdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.projectdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.providercategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProviderCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProviderCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProviderCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'providercategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.providercategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.providercategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.providerprofitabilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProviderProfitabilityDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProviderProfitabilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProviderProfitabilityDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'providerprofitabilitydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.providerprofitabilitydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.providerprofitabilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.providerstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ProviderStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ProviderStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ProviderStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'providerstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.providerstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.providerstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.publicationstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PublicationStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.PublicationStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PublicationStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'publicationstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.publicationstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.publicationstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.quantitativemeasure_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.quantitativemeasure(
        oldeducationorganizationid, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldquantitativemeasureidentifier, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.quantitativemeasureidentifier, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'quantitativemeasure') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.quantitativemeasure 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.quantitativemeasure_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.quantitativemeasuredatatypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.QuantitativeMeasureDatatypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.QuantitativeMeasureDatatypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.QuantitativeMeasureDatatypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'quantitativemeasuredatatypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.quantitativemeasuredatatypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.quantitativemeasuredatatypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.quantitativemeasurescore_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.quantitativemeasurescore(
        oldeducationorganizationid, oldevaluationdate, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldquantitativemeasureidentifier, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.quantitativemeasureidentifier, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'quantitativemeasurescore') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.quantitativemeasurescore 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.quantitativemeasurescore_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.quantitativemeasuretypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.QuantitativeMeasureTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.QuantitativeMeasureTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.QuantitativeMeasureTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'quantitativemeasuretypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.quantitativemeasuretypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.quantitativemeasuretypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.questionformdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.QuestionFormDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.QuestionFormDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.QuestionFormDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'questionformdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.questionformdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.questionformdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.racedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RaceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RaceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RaceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'racedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.racedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.racedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.ratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RatingLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'ratingleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.ratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.ratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reasonexiteddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ReasonExitedDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ReasonExitedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ReasonExitedDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reasonexiteddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.reasonexiteddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reasonexiteddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reasonnottesteddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ReasonNotTestedDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ReasonNotTestedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ReasonNotTestedDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reasonnottesteddescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.reasonnottesteddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reasonnottesteddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.recognitiontypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RecognitionTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RecognitionTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RecognitionTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'recognitiontypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.recognitiontypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.recognitiontypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.recruitmentevent_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.recruitmentevent(
        oldeducationorganizationid, oldeventdate, oldeventtitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.eventdate, OLD.eventtitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'recruitmentevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.recruitmentevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.recruitmentevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.recruitmenteventattendance_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.recruitmenteventattendance(
        oldeducationorganizationid, oldeventdate, oldeventtitle, oldrecruitmenteventattendeeidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.eventdate, OLD.eventtitle, OLD.recruitmenteventattendeeidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'recruitmenteventattendance') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.recruitmenteventattendance 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.recruitmenteventattendance_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.recruitmenteventattendeetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RecruitmentEventAttendeeTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RecruitmentEventAttendeeTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RecruitmentEventAttendeeTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'recruitmenteventattendeetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.recruitmenteventattendeetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.recruitmenteventattendeetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.recruitmenteventtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RecruitmentEventTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RecruitmentEventTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RecruitmentEventTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'recruitmenteventtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.recruitmenteventtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.recruitmenteventtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.relationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RelationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RelationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RelationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'relationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.relationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.relationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.repeatidentifierdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RepeatIdentifierDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RepeatIdentifierDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RepeatIdentifierDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'repeatidentifierdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.repeatidentifierdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.repeatidentifierdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reportcard_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.gradingperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.reportcard(
        oldeducationorganizationid, oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodname, oldgradingperiodschoolid, oldgradingperiodschoolyear, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.gradingperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.gradingperiodname, OLD.gradingperiodschoolid, OLD.gradingperiodschoolyear, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reportcard') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.reportcard 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reportcard_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reporterdescriptiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ReporterDescriptionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ReporterDescriptionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ReporterDescriptionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reporterdescriptiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.reporterdescriptiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reporterdescriptiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reportingtagdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ReportingTagDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ReportingTagDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ReportingTagDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reportingtagdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.reportingtagdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reportingtagdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.residencystatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ResidencyStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ResidencyStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ResidencyStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'residencystatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.residencystatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.residencystatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.responseindicatordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ResponseIndicatorDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ResponseIndicatorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ResponseIndicatorDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'responseindicatordescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.responseindicatordescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.responseindicatordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.responsibilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ResponsibilityDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ResponsibilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ResponsibilityDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'responsibilitydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.responsibilitydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.responsibilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.restraintevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.restraintevent(
        oldrestrainteventidentifier, oldschoolid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.restrainteventidentifier, OLD.schoolid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'restraintevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.restraintevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.restraintevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.restrainteventreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RestraintEventReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RestraintEventReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RestraintEventReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'restrainteventreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.restrainteventreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.restrainteventreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.resultdatatypetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ResultDatatypeTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ResultDatatypeTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ResultDatatypeTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'resultdatatypetypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.resultdatatypetypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.resultdatatypetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.retestindicatordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RetestIndicatorDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RetestIndicatorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RetestIndicatorDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'retestindicatordescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.retestindicatordescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.retestindicatordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.rubricdimension_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.rubricdimension(
        oldeducationorganizationid, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldrubricrating, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.rubricrating, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'rubricdimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.rubricdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.rubricdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.rubricratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RubricRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.RubricRatingLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RubricRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'rubricratingleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.rubricratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.rubricratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.salarytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SalaryTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SalaryTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SalaryTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'salarytypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.salarytypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.salarytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SchoolCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SchoolCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SchoolCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.schoolcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolchoicebasisdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SchoolChoiceBasisDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SchoolChoiceBasisDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SchoolChoiceBasisDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolchoicebasisdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.schoolchoicebasisdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolchoicebasisdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolchoiceimplementstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SchoolChoiceImplementStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SchoolChoiceImplementStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SchoolChoiceImplementStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolchoiceimplementstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.schoolchoiceimplementstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolchoiceimplementstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolfoodserviceprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SchoolFoodServiceProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SchoolFoodServiceProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SchoolFoodServiceProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolfoodserviceprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.schoolfoodserviceprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolfoodserviceprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schooltypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SchoolTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SchoolTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SchoolTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schooltypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.schooltypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schooltypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolyeartype_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.schoolyeartype(
        oldschoolyear,
        id, changeversion)
    VALUES (
        OLD.schoolyear, 
        OLD.id, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolyeartype') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.schoolyeartype 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolyeartype_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.section504disabilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.Section504DisabilityDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.Section504DisabilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.Section504DisabilityDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'section504disabilitydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.section504disabilitydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.section504disabilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.section_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.section(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname,
        id, discriminator, changeversion)
    VALUES (
        OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'section') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.section 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.section_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sectionattendancetakenevent_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.sectionattendancetakenevent(
        oldcalendarcode, olddate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname,
        id, discriminator, changeversion)
    VALUES (
        OLD.calendarcode, OLD.date, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sectionattendancetakenevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.sectionattendancetakenevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sectionattendancetakenevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sectioncharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SectionCharacteristicDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SectionCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SectionCharacteristicDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sectioncharacteristicdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.sectioncharacteristicdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sectioncharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sectiontypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SectionTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SectionTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SectionTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sectiontypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.sectiontypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sectiontypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.separationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SeparationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SeparationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SeparationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'separationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.separationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.separationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.separationreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SeparationReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SeparationReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SeparationReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'separationreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.separationreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.separationreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.servicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.ServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'servicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.servicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.servicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.session_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.session(
        oldschoolid, oldschoolyear, oldsessionname,
        id, discriminator, changeversion)
    VALUES (
        OLD.schoolid, OLD.schoolyear, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'session') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.session 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.session_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sexdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SexDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SexDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SexDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sexdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.sexdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sexdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sourcedimension_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.sourcedimension(
        oldcode, oldfiscalyear,
        id, discriminator, changeversion)
    VALUES (
        OLD.code, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sourcedimension') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.sourcedimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sourcedimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sourcesystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SourceSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SourceSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SourceSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sourcesystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.sourcesystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sourcesystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.specialeducationexitreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SpecialEducationExitReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SpecialEducationExitReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SpecialEducationExitReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'specialeducationexitreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.specialeducationexitreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.specialeducationexitreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.specialeducationprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SpecialEducationProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SpecialEducationProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SpecialEducationProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'specialeducationprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.specialeducationprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.specialeducationprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.specialeducationsettingdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SpecialEducationSettingDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SpecialEducationSettingDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SpecialEducationSettingDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'specialeducationsettingdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.specialeducationsettingdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.specialeducationsettingdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staff_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.staff(
        oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.staffusi, OLD.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staff') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staff 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staff_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffabsenceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.absenceeventcategorydescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffabsenceevent(
        oldabsenceeventcategorydescriptorid, oldabsenceeventcategorydescriptornamespace, oldabsenceeventcategorydescriptorcodevalue, oldeventdate, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.absenceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.eventdate, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffabsenceevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffabsenceevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffabsenceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffclassificationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.StaffClassificationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.StaffClassificationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.StaffClassificationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffclassificationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffclassificationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffclassificationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffcohortassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffcohortassociation(
        oldbegindate, oldcohortidentifier, oldeducationorganizationid, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.cohortidentifier, OLD.educationorganizationid, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffcohortassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffcohortassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffcohortassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffdemographic_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffdemographic(
        oldeducationorganizationid, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffdemographic') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffdemographic 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffdemographic_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffdirectory_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffdirectory(
        oldeducationorganizationid, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffdirectory') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffdirectory 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffdirectory_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffdisciplineincidentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffdisciplineincidentassociation(
        oldincidentidentifier, oldschoolid, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.incidentidentifier, OLD.schoolid, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffdisciplineincidentassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffdisciplineincidentassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffdisciplineincidentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffeducationorganizationassignmentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.staffclassificationdescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffeducationorganizationassignmentassociation(
        oldbegindate, oldeducationorganizationid, oldstaffclassificationdescriptorid, oldstaffclassificationdescriptornamespace, oldstaffclassificationdescriptorcodevalue, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.educationorganizationid, OLD.staffclassificationdescriptorid, dj0.namespace, dj0.codevalue, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationassignmentassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffeducationorganizationassignmentassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffeducationorganizationassignmentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffeducationorganizationcontactassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffeducationorganizationcontactassociation(
        oldcontacttitle, oldeducationorganizationid, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.contacttitle, OLD.educationorganizationid, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationcontactassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffeducationorganizationcontactassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffeducationorganizationcontactassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffeducationorganizationemploymentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.employmentstatusdescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffeducationorganizationemploymentassociation(
        oldeducationorganizationid, oldemploymentstatusdescriptorid, oldemploymentstatusdescriptornamespace, oldemploymentstatusdescriptorcodevalue, oldhiredate, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.employmentstatusdescriptorid, dj0.namespace, dj0.codevalue, OLD.hiredate, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationemploymentassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffeducationorganizationemploymentassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffeducationorganizationemploymentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffeducatorpreparationprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffeducatorpreparationprogramassociation(
        oldeducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducatorpreparationprogramassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffeducatorpreparationprogramassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffeducatorpreparationprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.StaffIdentificationSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.StaffIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.StaffIdentificationSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffidentificationsystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffidentificationsystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffidentity_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.staffidentificationsystemdescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffidentity(
        oldeducationorganizationid, oldstaffidentificationsystemdescriptorid, oldstaffidentificationsystemdescriptornamespace, oldstaffidentificationsystemdescriptorcodevalue, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.staffidentificationsystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffidentity') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffidentity 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffidentity_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffleave_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.staffleaveeventcategorydescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffleave(
        oldbegindate, oldstaffleaveeventcategorydescriptorid, oldstaffleaveeventcategorydescriptornamespace, oldstaffleaveeventcategorydescriptorcodevalue, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.staffleaveeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffleave') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffleave 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffleave_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffleaveeventcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.StaffLeaveEventCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.StaffLeaveEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.StaffLeaveEventCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffleaveeventcategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffleaveeventcategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffleaveeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffprogramassociation(
        oldbegindate, oldprogrameducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.programeducationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffprogramassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffprogramassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffschoolassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programassignmentdescriptorid;

    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffschoolassociation(
        oldprogramassignmentdescriptorid, oldprogramassignmentdescriptornamespace, oldprogramassignmentdescriptorcodevalue, oldschoolid, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.programassignmentdescriptorid, dj0.namespace, dj0.codevalue, OLD.schoolid, OLD.staffusi, dj1.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffschoolassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffschoolassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffschoolassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffsectionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffsectionassociation(
        oldbegindate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstaffusi, oldstaffuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.staffusi, dj0.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffsectionassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.staffsectionassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffsectionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.stafftocandidaterelationshipdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.StaffToCandidateRelationshipDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.StaffToCandidateRelationshipDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.StaffToCandidateRelationshipDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'stafftocandidaterelationshipdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.stafftocandidaterelationshipdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.stafftocandidaterelationshipdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.stateabbreviationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.StateAbbreviationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.StateAbbreviationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.StateAbbreviationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'stateabbreviationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.stateabbreviationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.stateabbreviationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.student_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.student(
        oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.studentusi, OLD.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'student') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.student 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.student_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentacademicrecord_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.studentacademicrecord(
        oldeducationorganizationid, oldschoolyear, oldstudentusi, oldstudentuniqueid, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.schoolyear, OLD.studentusi, dj0.studentuniqueid, OLD.termdescriptorid, dj1.namespace, dj1.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentacademicrecord') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentacademicrecord 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentacademicrecord_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentassessment_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentassessment(
        oldassessmentidentifier, oldnamespace, oldstudentassessmentidentifier, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.assessmentidentifier, OLD.namespace, OLD.studentassessmentidentifier, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessment') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentassessment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentassessment_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentassessmenteducationorganizationassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.educationorganizationassociationtypedescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentassessmenteducationorganizationassociation(
        oldassessmentidentifier, oldeducationorganizationassociationtypedescriptorid, oldeducationorganizationassociationtypedescriptornamespace, oldeducationorganizationassociationtypedescriptorcodevalue, oldeducationorganizationid, oldnamespace, oldstudentassessmentidentifier, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.assessmentidentifier, OLD.educationorganizationassociationtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.educationorganizationid, OLD.namespace, OLD.studentassessmentidentifier, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessmenteducationorganizationassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentassessmenteducationorganizationassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentassessmenteducationorganizationassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentassessmentregistration_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentassessmentregistration(
        oldadministrationidentifier, oldassessmentidentifier, oldassigningeducationorganizationid, oldeducationorganizationid, oldnamespace, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.administrationidentifier, OLD.assessmentidentifier, OLD.assigningeducationorganizationid, OLD.educationorganizationid, OLD.namespace, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessmentregistration') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentassessmentregistration 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentassessmentregistration_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentassessmentregistrationbatterypartassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentassessmentregistrationbatterypartassociation(
        oldadministrationidentifier, oldassessmentbatterypartname, oldassessmentidentifier, oldassigningeducationorganizationid, oldeducationorganizationid, oldnamespace, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.administrationidentifier, OLD.assessmentbatterypartname, OLD.assessmentidentifier, OLD.assigningeducationorganizationid, OLD.educationorganizationid, OLD.namespace, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessmentregistrationbatterypartassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentassessmentregistrationbatterypartassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentassessmentregistrationbatterypartassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentcharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.StudentCharacteristicDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.StudentCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.StudentCharacteristicDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentcharacteristicdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentcharacteristicdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentcharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentcohortassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentcohortassociation(
        oldbegindate, oldcohortidentifier, oldeducationorganizationid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.cohortidentifier, OLD.educationorganizationid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentcohortassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentcohortassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentcohortassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentcompetencyobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.gradingperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.objectivegradeleveldescriptorid;

    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentcompetencyobjective(
        oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodname, oldgradingperiodschoolid, oldgradingperiodschoolyear, oldobjectiveeducationorganizationid, oldobjective, oldobjectivegradeleveldescriptorid, oldobjectivegradeleveldescriptornamespace, oldobjectivegradeleveldescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.gradingperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.gradingperiodname, OLD.gradingperiodschoolid, OLD.gradingperiodschoolyear, OLD.objectiveeducationorganizationid, OLD.objective, OLD.objectivegradeleveldescriptorid, dj1.namespace, dj1.codevalue, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentcompetencyobjective') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentcompetencyobjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentcompetencyobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentcontactassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.contact%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.contact j0 WHERE contactusi = old.contactusi;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentcontactassociation(
        oldcontactusi, oldcontactuniqueid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.contactusi, dj0.contactuniqueid, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentcontactassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentcontactassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentcontactassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentdemographic_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentdemographic(
        oldeducationorganizationid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentdemographic') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentdemographic 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentdemographic_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentdirectory_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentdirectory(
        oldeducationorganizationid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentdirectory') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentdirectory 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentdirectory_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentdisciplineincidentbehaviorassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.behaviordescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentdisciplineincidentbehaviorassociation(
        oldbehaviordescriptorid, oldbehaviordescriptornamespace, oldbehaviordescriptorcodevalue, oldincidentidentifier, oldschoolid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.behaviordescriptorid, dj0.namespace, dj0.codevalue, OLD.incidentidentifier, OLD.schoolid, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentbehaviorassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentdisciplineincidentbehaviorassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentdisciplineincidentbehaviorassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation(
        oldincidentidentifier, oldschoolid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.incidentidentifier, OLD.schoolid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentnonoffenderassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentdisciplineincidentnonoffenderassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studenteducationorganizationassessmentaccommodation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studenteducationorganizationassessmentaccommodation(
        oldeducationorganizationid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationassessmentaccommodation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studenteducationorganizationassessmentaccommodation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studenteducationorganizationassessmentaccommodation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studenteducationorganizationassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studenteducationorganizationassociation(
        oldeducationorganizationid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studenteducationorganizationassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studenteducationorganizationassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studenteducationorganizationresponsibilityassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.responsibilitydescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studenteducationorganizationresponsibilityassociation(
        oldbegindate, oldeducationorganizationid, oldresponsibilitydescriptorid, oldresponsibilitydescriptornamespace, oldresponsibilitydescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.educationorganizationid, OLD.responsibilitydescriptorid, dj0.namespace, dj0.codevalue, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationresponsibilityassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studenteducationorganizationresponsibilityassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studenteducationorganizationresponsibilityassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentgradebookentry_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentgradebookentry(
        oldgradebookentryidentifier, oldnamespace, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.gradebookentryidentifier, OLD.namespace, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentgradebookentry') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentgradebookentry 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentgradebookentry_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studenthealth_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studenthealth(
        oldeducationorganizationid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studenthealth') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studenthealth 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studenthealth_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.StudentIdentificationSystemDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.StudentIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.StudentIdentificationSystemDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentidentificationsystemdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentidentificationsystemdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentidentity_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.studentidentificationsystemdescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentidentity(
        oldeducationorganizationid, oldstudentidentificationsystemdescriptorid, oldstudentidentificationsystemdescriptornamespace, oldstudentidentificationsystemdescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.studentidentificationsystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentidentity') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentidentity 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentidentity_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentinterventionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentinterventionassociation(
        oldeducationorganizationid, oldinterventionidentificationcode, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.interventionidentificationcode, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentinterventionassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentinterventionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentinterventionattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentinterventionattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeducationorganizationid, oldeventdate, oldinterventionidentificationcode, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.educationorganizationid, OLD.eventdate, OLD.interventionidentificationcode, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionattendanceevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentinterventionattendanceevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentinterventionattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentpath_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentpath(
        oldeducationorganizationid, oldpathname, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.pathname, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentpath') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentpath 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentpath_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentpathmilestonestatus_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.pathmilestonetypedescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentpathmilestonestatus(
        oldeducationorganizationid, oldpathmilestonename, oldpathmilestonetypedescriptorid, oldpathmilestonetypedescriptornamespace, oldpathmilestonetypedescriptorcodevalue, oldpathname, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.pathmilestonename, OLD.pathmilestonetypedescriptorid, dj0.namespace, dj0.codevalue, OLD.pathname, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentpathmilestonestatus') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentpathmilestonestatus 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentpathmilestonestatus_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentpathphasestatus_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentpathphasestatus(
        oldeducationorganizationid, oldpathname, oldpathphasename, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.pathname, OLD.pathphasename, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentpathphasestatus') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentpathphasestatus 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentpathphasestatus_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentprogramattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.programtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentprogramattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeducationorganizationid, oldeventdate, oldprogrameducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.educationorganizationid, OLD.eventdate, OLD.programeducationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentprogramattendanceevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentprogramattendanceevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentprogramattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentprogramevaluation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programevaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.programevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.programtypedescriptorid;

    SELECT INTO dj3 * FROM edfi.student j3 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentprogramevaluation(
        oldevaluationdate, oldprogrameducationorganizationid, oldprogramevaluationperioddescriptorid, oldprogramevaluationperioddescriptornamespace, oldprogramevaluationperioddescriptorcodevalue, oldprogramevaluationtitle, oldprogramevaluationtypedescriptorid, oldprogramevaluationtypedescriptornamespace, oldprogramevaluationtypedescriptorcodevalue, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.evaluationdate, OLD.programeducationorganizationid, OLD.programevaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.programevaluationtitle, OLD.programevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.programname, OLD.programtypedescriptorid, dj2.namespace, dj2.codevalue, OLD.studentusi, dj3.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentprogramevaluation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentprogramevaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentprogramevaluation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentschoolassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentschoolassociation(
        oldentrydate, oldschoolid, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.entrydate, OLD.schoolid, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentschoolassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentschoolassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentschoolattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentschoolattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeventdate, oldschoolid, oldschoolyear, oldsessionname, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.eventdate, OLD.schoolid, OLD.schoolyear, OLD.sessionname, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolattendanceevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentschoolattendanceevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentschoolattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentsectionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentsectionassociation(
        oldbegindate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj0.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentsectionassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentsectionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentsectionattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentsectionattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeventdate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.eventdate, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionattendanceevent') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentsectionattendanceevent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentsectionattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentspecialeducationprogrameligibilityassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentspecialeducationprogrameligibilityassociation(
        oldconsenttoevaluationreceiveddate, oldeducationorganizationid, oldprogrameducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.consenttoevaluationreceiveddate, OLD.educationorganizationid, OLD.programeducationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentspecialeducationprogrameligibilityassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studentspecialeducationprogrameligibilityassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentspecialeducationprogrameligibilityassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studenttransportation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.student j0 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studenttransportation(
        oldstudentusi, oldstudentuniqueid, oldtransportationeducationorganizationid,
        id, discriminator, changeversion)
    VALUES (
        OLD.studentusi, dj0.studentuniqueid, OLD.transportationeducationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studenttransportation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.studenttransportation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studenttransportation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.submissionstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SubmissionStatusDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SubmissionStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SubmissionStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'submissionstatusdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.submissionstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.submissionstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.supportermilitaryconnectiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SupporterMilitaryConnectionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SupporterMilitaryConnectionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SupporterMilitaryConnectionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'supportermilitaryconnectiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.supportermilitaryconnectiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.supportermilitaryconnectiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.survey_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.survey(
        oldnamespace, oldsurveyidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'survey') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.survey 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.survey_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveycategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SurveyCategoryDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SurveyCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SurveyCategoryDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveycategorydescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveycategorydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveycategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveycourseassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveycourseassociation(
        oldcoursecode, oldeducationorganizationid, oldnamespace, oldsurveyidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.coursecode, OLD.educationorganizationid, OLD.namespace, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveycourseassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveycourseassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveycourseassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.SurveyLevelDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.SurveyLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.SurveyLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyleveldescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.surveyprogramassociation(
        oldeducationorganizationid, oldnamespace, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldsurveyidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.namespace, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyprogramassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyprogramassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyquestion_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveyquestion(
        oldnamespace, oldquestioncode, oldsurveyidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.questioncode, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestion') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyquestion 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyquestion_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyquestionresponse_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveyquestionresponse(
        oldnamespace, oldquestioncode, oldsurveyidentifier, oldsurveyresponseidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.questioncode, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestionresponse') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyquestionresponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyquestionresponse_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyresponse_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveyresponse(
        oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponse') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyresponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyresponse_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation(
        oldeducationorganizationid, oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponseeducationorganizationtargetassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyresponseeducationorganizationtargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyresponsepersontargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_edfi.surveyresponsepersontargetassociation(
        oldnamespace, oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldsurveyidentifier, oldsurveyresponseidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.personid, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponsepersontargetassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyresponsepersontargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyresponsepersontargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyresponsestafftargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.surveyresponsestafftargetassociation(
        oldnamespace, oldstaffusi, oldstaffuniqueid, oldsurveyidentifier, oldsurveyresponseidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.staffusi, dj0.staffuniqueid, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponsestafftargetassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveyresponsestafftargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyresponsestafftargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysection_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveysection(
        oldnamespace, oldsurveyidentifier, oldsurveysectiontitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.surveyidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysection') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveysection 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysection_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionaggregateresponse_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.surveysectionaggregateresponse(
        oldeducationorganizationid, oldevaluationdate, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldnamespace, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldsurveyidentifier, oldsurveysectiontitle, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.namespace, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.surveyidentifier, OLD.surveysectiontitle, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionaggregateresponse') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveysectionaggregateresponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionaggregateresponse_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionassociation_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveysectionassociation(
        oldlocalcoursecode, oldnamespace, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldsurveyidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.localcoursecode, OLD.namespace, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveysectionassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionresponse_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveysectionresponse(
        oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponse') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveysectionresponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionresponse_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionresponseeducationorganizationtarget_730be1_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.surveysectionresponseeducationorganizationtargetassociation(
        oldeducationorganizationid, oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponseeducationorganizationtargetassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveysectionresponseeducationorganizationtargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionresponseeducationorganizationtarget_730be1_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionresponsepersontargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_edfi.surveysectionresponsepersontargetassociation(
        oldnamespace, oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.personid, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponsepersontargetassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveysectionresponsepersontargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionresponsepersontargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionresponsestafftargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.staff j0 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.surveysectionresponsestafftargetassociation(
        oldnamespace, oldstaffusi, oldstaffuniqueid, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.staffusi, dj0.staffuniqueid, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponsestafftargetassociation') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.surveysectionresponsestafftargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionresponsestafftargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.teachingcredentialbasisdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TeachingCredentialBasisDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TeachingCredentialBasisDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TeachingCredentialBasisDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'teachingcredentialbasisdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.teachingcredentialbasisdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.teachingcredentialbasisdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.teachingcredentialdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TeachingCredentialDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TeachingCredentialDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TeachingCredentialDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'teachingcredentialdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.teachingcredentialdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.teachingcredentialdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.technicalskillsassessmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TechnicalSkillsAssessmentDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TechnicalSkillsAssessmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TechnicalSkillsAssessmentDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'technicalskillsassessmentdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.technicalskillsassessmentdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.technicalskillsassessmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.telephonenumbertypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TelephoneNumberTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TelephoneNumberTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TelephoneNumberTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'telephonenumbertypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.telephonenumbertypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.telephonenumbertypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.termdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TermDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TermDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TermDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'termdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.termdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.termdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.titleipartaparticipantdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TitleIPartAParticipantDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TitleIPartAParticipantDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TitleIPartAParticipantDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'titleipartaparticipantdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.titleipartaparticipantdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.titleipartaparticipantdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.titleipartaprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TitleIPartAProgramServiceDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TitleIPartAProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TitleIPartAProgramServiceDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'titleipartaprogramservicedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.titleipartaprogramservicedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.titleipartaprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.titleipartaschooldesignationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TitleIPartASchoolDesignationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TitleIPartASchoolDesignationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TitleIPartASchoolDesignationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'titleipartaschooldesignationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.titleipartaschooldesignationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.titleipartaschooldesignationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.transportationpublicexpenseeligibilitytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TransportationPublicExpenseEligibilityTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TransportationPublicExpenseEligibilityTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TransportationPublicExpenseEligibilityTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'transportationpublicexpenseeligibilitytypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.transportationpublicexpenseeligibilitytypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.transportationpublicexpenseeligibilitytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.transportationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TransportationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TransportationTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TransportationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'transportationtypedescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.transportationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.transportationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.traveldayofweekdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TravelDayofWeekDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TravelDayofWeekDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TravelDayofWeekDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'traveldayofweekdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.traveldayofweekdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.traveldayofweekdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.traveldirectiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TravelDirectionDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TravelDirectionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TravelDirectionDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'traveldirectiondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.traveldirectiondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.traveldirectiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.tribalaffiliationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.TribalAffiliationDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.TribalAffiliationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.TribalAffiliationDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'tribalaffiliationdescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.tribalaffiliationdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.tribalaffiliationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.visadescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.VisaDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.VisaDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.VisaDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'visadescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.visadescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.visadescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.weapondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.WeaponDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.WeaponDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.WeaponDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'weapondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.weapondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.weapondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.withdrawreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.WithdrawReasonDescriptorId, b.codevalue, b.namespace, b.id, 'edfi.WithdrawReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.WithdrawReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'withdrawreasondescriptor') THEN
CREATE OR ALTER TRIGGER TrackDeletes AFTER DELETE ON edfi.withdrawreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.withdrawreasondescriptor_deleted();
END IF;

END
$$;
