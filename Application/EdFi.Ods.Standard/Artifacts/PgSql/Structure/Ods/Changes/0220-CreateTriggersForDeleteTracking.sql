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
    SELECT OLD.absenceeventcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AbsenceEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.absenceeventcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'absenceeventcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.absenceeventcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.absenceeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.academichonorcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.academichonorcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AcademicHonorCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.academichonorcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'academichonorcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.academichonorcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.academichonorcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.academicsubjectdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.academicsubjectdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AcademicSubjectDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.academicsubjectdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'academicsubjectdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.academicsubjectdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.academicsubjectdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.academicweek_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.academicweek(
        oldschoolid, oldweekidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.schoolid, OLD.weekidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'academicweek') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.academicweek 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.academicweek_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accommodationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.accommodationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AccommodationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.accommodationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accommodationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.accommodationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accommodationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.account_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.account(
        oldaccountidentifier, oldeducationorganizationid, oldfiscalyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.accountidentifier, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'account') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.account 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.account_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accountabilityrating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.accountabilityrating(
        oldeducationorganizationid, oldratingtitle, oldschoolyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.ratingtitle, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accountabilityrating') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.accountabilityrating 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accountabilityrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accountclassificationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.accountclassificationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AccountClassificationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.accountclassificationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accountclassificationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.accountclassificationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accountclassificationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.accountcode_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.accountclassificationdescriptorid;

    INSERT INTO tracked_changes_edfi.accountcode(
        oldaccountclassificationdescriptorid, oldaccountclassificationdescriptornamespace, oldaccountclassificationdescriptorcodevalue, oldaccountcodenumber, oldeducationorganizationid, oldfiscalyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.accountclassificationdescriptorid, dj0.namespace, dj0.codevalue, OLD.accountcodenumber, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'accountcode') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.accountcode 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.accountcode_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.achievementcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.achievementcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AchievementCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.achievementcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'achievementcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.achievementcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.achievementcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.actual_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.actual(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'actual') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.actual 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.actual_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.additionalcredittypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.additionalcredittypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AdditionalCreditTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.additionalcredittypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'additionalcredittypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.additionalcredittypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.additionalcredittypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.addresstypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.addresstypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AddressTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.addresstypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'addresstypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.addresstypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.addresstypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.administrationenvironmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.administrationenvironmentdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AdministrationEnvironmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.administrationenvironmentdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'administrationenvironmentdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.administrationenvironmentdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.administrationenvironmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.administrativefundingcontroldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.administrativefundingcontroldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AdministrativeFundingControlDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.administrativefundingcontroldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'administrativefundingcontroldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.administrativefundingcontroldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.administrativefundingcontroldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.ancestryethnicorigindescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ancestryethnicorigindescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AncestryEthnicOriginDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ancestryethnicorigindescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'ancestryethnicorigindescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.ancestryethnicorigindescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.ancestryethnicorigindescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessment_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.assessment(
        oldassessmentidentifier, oldnamespace, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.assessmentidentifier, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessment') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessment 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessment_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.assessmentcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AssessmentCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.assessmentcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.assessmentidentificationsystemdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AssessmentIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.assessmentidentificationsystemdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentidentificationsystemdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentidentificationsystemdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentitem_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.assessmentitem(
        oldassessmentidentifier, oldidentificationcode, oldnamespace, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.assessmentidentifier, OLD.identificationcode, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitem') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentitem 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentitem_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentitemcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.assessmentitemcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AssessmentItemCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.assessmentitemcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitemcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentitemcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentitemcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentitemresultdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.assessmentitemresultdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AssessmentItemResultDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.assessmentitemresultdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentitemresultdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentitemresultdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentitemresultdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentperioddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.assessmentperioddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AssessmentPeriodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.assessmentperioddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentperioddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentperioddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentperioddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentreportingmethoddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.assessmentreportingmethoddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AssessmentReportingMethodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.assessmentreportingmethoddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentreportingmethoddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentreportingmethoddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentreportingmethoddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.assessmentscorerangelearningstandard_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.assessmentscorerangelearningstandard(
        oldassessmentidentifier, oldnamespace, oldscorerangeid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.assessmentidentifier, OLD.namespace, OLD.scorerangeid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentscorerangelearningstandard') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.assessmentscorerangelearningstandard 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.assessmentscorerangelearningstandard_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.attemptstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.attemptstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AttemptStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.attemptstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'attemptstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.attemptstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.attemptstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.attendanceeventcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.attendanceeventcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.AttendanceEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.attendanceeventcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'attendanceeventcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.attendanceeventcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.attendanceeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.barriertointernetaccessinresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.barriertointernetaccessinresidencedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.BarrierToInternetAccessInResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.barriertointernetaccessinresidencedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'barriertointernetaccessinresidencedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.barriertointernetaccessinresidencedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.barriertointernetaccessinresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.behaviordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.behaviordescriptorid, b.codevalue, b.namespace, b.id, 'edfi.BehaviorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.behaviordescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'behaviordescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.behaviordescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.behaviordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.bellschedule_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.bellschedule(
        oldbellschedulename, oldschoolid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.bellschedulename, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'bellschedule') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.bellschedule 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.bellschedule_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.budget_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.budget(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'budget') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.budget 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.budget_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendar_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.calendar(
        oldcalendarcode, oldschoolid, oldschoolyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.calendarcode, OLD.schoolid, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendar') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.calendar 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendar_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendardate_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.calendardate(
        oldcalendarcode, olddate, oldschoolid, oldschoolyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.calendarcode, OLD.date, OLD.schoolid, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendardate') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.calendardate 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendardate_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendareventdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.calendareventdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CalendarEventDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.calendareventdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendareventdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.calendareventdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendareventdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.calendartypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.calendartypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CalendarTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.calendartypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'calendartypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.calendartypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.calendartypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.careerpathwaydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.careerpathwaydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CareerPathwayDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.careerpathwaydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'careerpathwaydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.careerpathwaydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.careerpathwaydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.charterapprovalagencytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.charterapprovalagencytypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CharterApprovalAgencyTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.charterapprovalagencytypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'charterapprovalagencytypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.charterapprovalagencytypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.charterapprovalagencytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.charterstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.charterstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CharterStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.charterstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'charterstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.charterstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.charterstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.citizenshipstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.citizenshipstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CitizenshipStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.citizenshipstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'citizenshipstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.citizenshipstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.citizenshipstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.classperiod_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.classperiod(
        oldclassperiodname, oldschoolid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.classperiodname, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'classperiod') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.classperiod 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.classperiod_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.classroompositiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.classroompositiondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ClassroomPositionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.classroompositiondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'classroompositiondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.classroompositiondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.classroompositiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohort_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.cohort(
        oldcohortidentifier, oldeducationorganizationid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.cohortidentifier, OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohort') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.cohort 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohort_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohortscopedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.cohortscopedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CohortScopeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.cohortscopedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohortscopedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.cohortscopedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohortscopedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohorttypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.cohorttypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CohortTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.cohorttypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohorttypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.cohorttypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohorttypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cohortyeartypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.cohortyeartypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CohortYearTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.cohortyeartypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cohortyeartypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.cohortyeartypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cohortyeartypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.communityproviderlicense_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.communityproviderlicense(
        oldcommunityproviderid, oldlicenseidentifier, oldlicensingorganization, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.communityproviderid, OLD.licenseidentifier, OLD.licensingorganization, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'communityproviderlicense') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.communityproviderlicense 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.communityproviderlicense_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.competencyleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.competencyleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CompetencyLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.competencyleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'competencyleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.competencyleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.competencyleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.competencyobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.objectivegradeleveldescriptorid;

    INSERT INTO tracked_changes_edfi.competencyobjective(
        oldeducationorganizationid, oldobjective, oldobjectivegradeleveldescriptorid, oldobjectivegradeleveldescriptornamespace, oldobjectivegradeleveldescriptorcodevalue, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.objective, OLD.objectivegradeleveldescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'competencyobjective') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.competencyobjective 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.competencyobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contacttypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.contacttypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ContactTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.contacttypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contacttypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.contacttypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contacttypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contentclassdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.contentclassdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ContentClassDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.contentclassdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contentclassdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.contentclassdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contentclassdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.continuationofservicesreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.continuationofservicesreasondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ContinuationOfServicesReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.continuationofservicesreasondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'continuationofservicesreasondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.continuationofservicesreasondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.continuationofservicesreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.contractedstaff_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj4 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj4 * FROM edfi.staff j4 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.contractedstaff(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, OLD.staffusi, dj4.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'contractedstaff') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.contractedstaff 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.contractedstaff_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.costratedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.costratedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CostRateDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.costratedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'costratedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.costratedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.costratedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.countrydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.countrydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CountryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.countrydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'countrydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.countrydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.countrydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.course_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.course(
        oldcoursecode, oldeducationorganizationid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.coursecode, OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'course') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.course 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.course_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courseattemptresultdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.courseattemptresultdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CourseAttemptResultDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.courseattemptresultdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courseattemptresultdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.courseattemptresultdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courseattemptresultdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.coursedefinedbydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.coursedefinedbydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CourseDefinedByDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.coursedefinedbydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'coursedefinedbydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.coursedefinedbydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.coursedefinedbydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.coursegpaapplicabilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.coursegpaapplicabilitydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CourseGPAApplicabilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.coursegpaapplicabilitydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'coursegpaapplicabilitydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.coursegpaapplicabilitydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.coursegpaapplicabilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courseidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.courseidentificationsystemdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CourseIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.courseidentificationsystemdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courseidentificationsystemdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.courseidentificationsystemdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courseidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courselevelcharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.courselevelcharacteristicdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CourseLevelCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.courselevelcharacteristicdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courselevelcharacteristicdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.courselevelcharacteristicdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courselevelcharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courseoffering_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.courseoffering(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsessionname, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courseoffering') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.courseoffering 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courseoffering_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.courserepeatcodedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.courserepeatcodedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CourseRepeatCodeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.courserepeatcodedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'courserepeatcodedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.courserepeatcodedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.courserepeatcodedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.coursetranscript_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj5 edfi.student%ROWTYPE;
    dj6 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.courseattemptresultdescriptorid;
    SELECT INTO dj5 * FROM edfi.student j5 WHERE studentusi = old.studentusi;
    SELECT INTO dj6 * FROM edfi.descriptor j6 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.coursetranscript(
        oldcourseattemptresultdescriptorid, oldcourseattemptresultdescriptornamespace, oldcourseattemptresultdescriptorcodevalue, oldcoursecode, oldcourseeducationorganizationid, oldeducationorganizationid, oldschoolyear, oldstudentusi, oldstudentuniqueid, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.courseattemptresultdescriptorid, dj0.namespace, dj0.codevalue, OLD.coursecode, OLD.courseeducationorganizationid, OLD.educationorganizationid, OLD.schoolyear, OLD.studentusi, dj5.studentuniqueid, OLD.termdescriptorid, dj6.namespace, dj6.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'coursetranscript') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.coursetranscript 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.coursetranscript_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credential_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.stateofissuestateabbreviationdescriptorid;

    INSERT INTO tracked_changes_edfi.credential(
        oldcredentialidentifier, oldstateofissuestateabbreviationdescriptorid, oldstateofissuestateabbreviationdescriptornamespace, oldstateofissuestateabbreviationdescriptorcodevalue, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.credentialidentifier, OLD.stateofissuestateabbreviationdescriptorid, dj1.namespace, dj1.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credential') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.credential 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credential_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credentialfielddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.credentialfielddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CredentialFieldDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.credentialfielddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credentialfielddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.credentialfielddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credentialfielddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credentialtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.credentialtypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CredentialTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.credentialtypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credentialtypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.credentialtypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credentialtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.creditcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.creditcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CreditCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.creditcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'creditcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.creditcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.creditcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.credittypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.credittypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CreditTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.credittypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'credittypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.credittypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.credittypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.cteprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.cteprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CTEProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.cteprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'cteprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.cteprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.cteprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.curriculumuseddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.curriculumuseddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.CurriculumUsedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.curriculumuseddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'curriculumuseddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.curriculumuseddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.curriculumuseddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.deliverymethoddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.deliverymethoddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DeliveryMethodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.deliverymethoddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'deliverymethoddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.deliverymethoddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.deliverymethoddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.diagnosisdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.diagnosisdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DiagnosisDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.diagnosisdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'diagnosisdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.diagnosisdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.diagnosisdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.diplomaleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.diplomaleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DiplomaLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.diplomaleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'diplomaleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.diplomaleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.diplomaleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.diplomatypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.diplomatypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DiplomaTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.diplomatypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'diplomatypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.diplomatypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.diplomatypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disabilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.disabilitydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DisabilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.disabilitydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disabilitydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disabilitydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disabilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disabilitydesignationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.disabilitydesignationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DisabilityDesignationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.disabilitydesignationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disabilitydesignationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disabilitydesignationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disabilitydesignationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disabilitydeterminationsourcetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.disabilitydeterminationsourcetypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DisabilityDeterminationSourceTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.disabilitydeterminationsourcetypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disabilitydeterminationsourcetypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disabilitydeterminationsourcetypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disabilitydeterminationsourcetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineaction_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.disciplineaction(
        olddisciplineactionidentifier, olddisciplinedate, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.disciplineactionidentifier, OLD.disciplinedate, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineaction') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disciplineaction 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineaction_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineactionlengthdifferencereasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.disciplineactionlengthdifferencereasondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DisciplineActionLengthDifferenceReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.disciplineactionlengthdifferencereasondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineactionlengthdifferencereasondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disciplineactionlengthdifferencereasondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineactionlengthdifferencereasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplinedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.disciplinedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DisciplineDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.disciplinedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplinedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disciplinedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplinedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineincident_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.disciplineincident(
        oldincidentidentifier, oldschoolid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.incidentidentifier, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineincident') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disciplineincident 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineincident_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.disciplineincidentparticipationcodedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.disciplineincidentparticipationcodedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.DisciplineIncidentParticipationCodeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.disciplineincidentparticipationcodedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'disciplineincidentparticipationcodedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.disciplineincidentparticipationcodedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.disciplineincidentparticipationcodedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationalenvironmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.educationalenvironmentdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EducationalEnvironmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.educationalenvironmentdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationalenvironmentdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationalenvironmentdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationalenvironmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationcontent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.educationcontent(
        oldcontentidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.contentidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationcontent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationcontent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationcontent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganization_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.educationorganization(
        oldeducationorganizationid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganization') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationorganization 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganization_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.educationorganizationcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EducationOrganizationCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.educationorganizationcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationorganizationcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.educationorganizationidentificationsystemdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EducationOrganizationIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.educationorganizationidentificationsystemdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationidentificationsystemdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationorganizationidentificationsystemdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationinterventionprescriptionass_e670ae_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.educationorganizationinterventionprescriptionassociation(
        oldeducationorganizationid, oldinterventionprescriptioneducationorganizationid, oldinterventionprescriptionidentificationcode, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.interventionprescriptioneducationorganizationid, OLD.interventionprescriptionidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationinterventionprescriptionassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationorganizationinterventionprescriptionassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationinterventionprescriptionass_e670ae_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationnetworkassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.educationorganizationnetworkassociation(
        oldeducationorganizationnetworkid, oldmembereducationorganizationid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationnetworkid, OLD.membereducationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationnetworkassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationorganizationnetworkassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationnetworkassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationorganizationpeerassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.educationorganizationpeerassociation(
        oldeducationorganizationid, oldpeereducationorganizationid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.peereducationorganizationid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationorganizationpeerassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationorganizationpeerassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationorganizationpeerassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.educationplandescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.educationplandescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EducationPlanDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.educationplandescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'educationplandescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.educationplandescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.educationplandescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.electronicmailtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.electronicmailtypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ElectronicMailTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.electronicmailtypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'electronicmailtypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.electronicmailtypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.electronicmailtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.employmentstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.employmentstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EmploymentStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.employmentstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'employmentstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.employmentstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.employmentstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.entrygradelevelreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.entrygradelevelreasondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EntryGradeLevelReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.entrygradelevelreasondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'entrygradelevelreasondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.entrygradelevelreasondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.entrygradelevelreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.entrytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.entrytypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EntryTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.entrytypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'entrytypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.entrytypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.entrytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.eventcircumstancedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.eventcircumstancedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.EventCircumstanceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.eventcircumstancedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'eventcircumstancedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.eventcircumstancedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.eventcircumstancedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.exitwithdrawtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.exitwithdrawtypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ExitWithdrawTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.exitwithdrawtypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'exitwithdrawtypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.exitwithdrawtypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.exitwithdrawtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.feederschoolassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.feederschoolassociation(
        oldbegindate, oldfeederschoolid, oldschoolid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.feederschoolid, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'feederschoolassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.feederschoolassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.feederschoolassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.generalstudentprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj4 edfi.descriptor%ROWTYPE;
    dj5 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj4 * FROM edfi.descriptor j4 WHERE descriptorid = old.programtypedescriptorid;
    SELECT INTO dj5 * FROM edfi.student j5 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.generalstudentprogramassociation(
        oldbegindate, oldeducationorganizationid, oldprogrameducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.educationorganizationid, OLD.programeducationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj4.namespace, dj4.codevalue, OLD.studentusi, dj5.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'generalstudentprogramassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.generalstudentprogramassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.generalstudentprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.grade_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.descriptor%ROWTYPE;
    dj10 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.gradetypedescriptorid;
    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.gradingperioddescriptorid;
    SELECT INTO dj10 * FROM edfi.student j10 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.grade(
        oldbegindate, oldgradetypedescriptorid, oldgradetypedescriptornamespace, oldgradetypedescriptorcodevalue, oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodschoolyear, oldgradingperiodsequence, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.gradetypedescriptorid, dj1.namespace, dj1.codevalue, OLD.gradingperioddescriptorid, dj2.namespace, dj2.codevalue, OLD.gradingperiodschoolyear, OLD.gradingperiodsequence, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj10.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'grade') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.grade 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.grade_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradebookentry_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.gradebookentry(
        olddateassigned, oldgradebookentrytitle, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.dateassigned, OLD.gradebookentrytitle, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradebookentry') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gradebookentry 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradebookentry_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradebookentrytypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.gradebookentrytypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.GradebookEntryTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.gradebookentrytypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradebookentrytypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gradebookentrytypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradebookentrytypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradeleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.gradeleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.GradeLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.gradeleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradeleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gradeleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradeleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradepointaveragetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.gradepointaveragetypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.GradePointAverageTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.gradepointaveragetypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradepointaveragetypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gradepointaveragetypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradepointaveragetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.gradetypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.GradeTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.gradetypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradetypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gradetypedescriptor 
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
        oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldperiodsequence, oldschoolid, oldschoolyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.gradingperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.periodsequence, OLD.schoolid, OLD.schoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradingperiod') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gradingperiod 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradingperiod_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gradingperioddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.gradingperioddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.GradingPeriodDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.gradingperioddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gradingperioddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gradingperioddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gradingperioddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.graduationplan_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.graduationplantypedescriptorid;

    INSERT INTO tracked_changes_edfi.graduationplan(
        oldeducationorganizationid, oldgraduationplantypedescriptorid, oldgraduationplantypedescriptornamespace, oldgraduationplantypedescriptorcodevalue, oldgraduationschoolyear, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.graduationplantypedescriptorid, dj1.namespace, dj1.codevalue, OLD.graduationschoolyear, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'graduationplan') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.graduationplan 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.graduationplan_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.graduationplantypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.graduationplantypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.GraduationPlanTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.graduationplantypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'graduationplantypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.graduationplantypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.graduationplantypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.gunfreeschoolsactreportingstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.gunfreeschoolsactreportingstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.GunFreeSchoolsActReportingStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.gunfreeschoolsactreportingstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'gunfreeschoolsactreportingstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.gunfreeschoolsactreportingstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.gunfreeschoolsactreportingstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.homelessprimarynighttimeresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.homelessprimarynighttimeresidencedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.HomelessPrimaryNighttimeResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.homelessprimarynighttimeresidencedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'homelessprimarynighttimeresidencedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.homelessprimarynighttimeresidencedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.homelessprimarynighttimeresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.homelessprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.homelessprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.HomelessProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.homelessprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'homelessprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.homelessprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.homelessprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.identificationdocumentusedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.identificationdocumentusedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.IdentificationDocumentUseDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.identificationdocumentusedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'identificationdocumentusedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.identificationdocumentusedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.identificationdocumentusedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.incidentlocationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.incidentlocationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.IncidentLocationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.incidentlocationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'incidentlocationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.incidentlocationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.incidentlocationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.indicatordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.indicatordescriptorid, b.codevalue, b.namespace, b.id, 'edfi.IndicatorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.indicatordescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'indicatordescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.indicatordescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.indicatordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.indicatorgroupdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.indicatorgroupdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.IndicatorGroupDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.indicatorgroupdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'indicatorgroupdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.indicatorgroupdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.indicatorgroupdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.indicatorleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.indicatorleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.IndicatorLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.indicatorleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'indicatorleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.indicatorleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.indicatorleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.institutiontelephonenumbertypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.institutiontelephonenumbertypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.InstitutionTelephoneNumberTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.institutiontelephonenumbertypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'institutiontelephonenumbertypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.institutiontelephonenumbertypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.institutiontelephonenumbertypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interactivitystyledescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.interactivitystyledescriptorid, b.codevalue, b.namespace, b.id, 'edfi.InteractivityStyleDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.interactivitystyledescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interactivitystyledescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.interactivitystyledescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interactivitystyledescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.internetaccessdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.internetaccessdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.InternetAccessDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.internetaccessdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'internetaccessdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.internetaccessdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.internetaccessdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.internetaccesstypeinresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.internetaccesstypeinresidencedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.InternetAccessTypeInResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.internetaccesstypeinresidencedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'internetaccesstypeinresidencedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.internetaccesstypeinresidencedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.internetaccesstypeinresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.internetperformanceinresidencedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.internetperformanceinresidencedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.InternetPerformanceInResidenceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.internetperformanceinresidencedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'internetperformanceinresidencedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.internetperformanceinresidencedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.internetperformanceinresidencedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.intervention_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.intervention(
        oldeducationorganizationid, oldinterventionidentificationcode, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.interventionidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'intervention') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.intervention 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.intervention_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventionclassdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.interventionclassdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.InterventionClassDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.interventionclassdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventionclassdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.interventionclassdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventionclassdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventioneffectivenessratingdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.interventioneffectivenessratingdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.InterventionEffectivenessRatingDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.interventioneffectivenessratingdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventioneffectivenessratingdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.interventioneffectivenessratingdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventioneffectivenessratingdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventionprescription_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.interventionprescription(
        oldeducationorganizationid, oldinterventionprescriptionidentificationcode, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.interventionprescriptionidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventionprescription') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.interventionprescription 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventionprescription_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.interventionstudy_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.interventionstudy(
        oldeducationorganizationid, oldinterventionstudyidentificationcode, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.interventionstudyidentificationcode, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'interventionstudy') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.interventionstudy 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.interventionstudy_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.languagedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.languagedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LanguageDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.languagedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'languagedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.languagedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.languagedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.languageinstructionprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.languageinstructionprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LanguageInstructionProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.languageinstructionprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'languageinstructionprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.languageinstructionprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.languageinstructionprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.languageusedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.languageusedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LanguageUseDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.languageusedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'languageusedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.languageusedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.languageusedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.learningobjective(
        oldlearningobjectiveid, oldnamespace, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.learningobjectiveid, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningobjective') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.learningobjective 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandard_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.learningstandard(
        oldlearningstandardid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.learningstandardid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandard') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.learningstandard 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandard_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.learningstandardcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LearningStandardCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.learningstandardcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.learningstandardcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardequivalenceassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.learningstandardequivalenceassociation(
        oldnamespace, oldsourcelearningstandardid, oldtargetlearningstandardid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.sourcelearningstandardid, OLD.targetlearningstandardid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardequivalenceassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.learningstandardequivalenceassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardequivalenceassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardequivalencestrengthdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.learningstandardequivalencestrengthdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LearningStandardEquivalenceStrengthDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.learningstandardequivalencestrengthdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardequivalencestrengthdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.learningstandardequivalencestrengthdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardequivalencestrengthdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.learningstandardscopedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.learningstandardscopedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LearningStandardScopeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.learningstandardscopedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'learningstandardscopedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.learningstandardscopedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.learningstandardscopedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.levelofeducationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.levelofeducationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LevelOfEducationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.levelofeducationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'levelofeducationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.levelofeducationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.levelofeducationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.licensestatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.licensestatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LicenseStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.licensestatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'licensestatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.licensestatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.licensestatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.licensetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.licensetypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LicenseTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.licensetypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'licensetypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.licensetypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.licensetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.limitedenglishproficiencydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.limitedenglishproficiencydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LimitedEnglishProficiencyDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.limitedenglishproficiencydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'limitedenglishproficiencydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.limitedenglishproficiencydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.limitedenglishproficiencydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.localedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LocaleDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.localedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.localedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.localeducationagencycategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.localeducationagencycategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.LocalEducationAgencyCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.localeducationagencycategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'localeducationagencycategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.localeducationagencycategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.localeducationagencycategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.location_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.location(
        oldclassroomidentificationcode, oldschoolid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.classroomidentificationcode, OLD.schoolid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'location') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.location 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.location_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.magnetspecialprogramemphasisschooldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.magnetspecialprogramemphasisschooldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.MagnetSpecialProgramEmphasisSchoolDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.magnetspecialprogramemphasisschooldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'magnetspecialprogramemphasisschooldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.magnetspecialprogramemphasisschooldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.magnetspecialprogramemphasisschooldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.mediumofinstructiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.mediumofinstructiondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.MediumOfInstructionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.mediumofinstructiondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'mediumofinstructiondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.mediumofinstructiondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.mediumofinstructiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.methodcreditearneddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.methodcreditearneddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.MethodCreditEarnedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.methodcreditearneddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'methodcreditearneddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.methodcreditearneddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.methodcreditearneddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.migranteducationprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.migranteducationprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.MigrantEducationProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.migranteducationprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'migranteducationprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.migranteducationprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.migranteducationprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.monitoreddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.monitoreddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.MonitoredDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.monitoreddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'monitoreddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.monitoreddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.monitoreddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.neglectedordelinquentprogramdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.neglectedordelinquentprogramdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.NeglectedOrDelinquentProgramDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.neglectedordelinquentprogramdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'neglectedordelinquentprogramdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.neglectedordelinquentprogramdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.neglectedordelinquentprogramdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.neglectedordelinquentprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.neglectedordelinquentprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.NeglectedOrDelinquentProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.neglectedordelinquentprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'neglectedordelinquentprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.neglectedordelinquentprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.neglectedordelinquentprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.networkpurposedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.networkpurposedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.NetworkPurposeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.networkpurposedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'networkpurposedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.networkpurposedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.networkpurposedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.objectiveassessment_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.objectiveassessment(
        oldassessmentidentifier, oldidentificationcode, oldnamespace, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.assessmentidentifier, OLD.identificationcode, OLD.namespace, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'objectiveassessment') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.objectiveassessment 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.objectiveassessment_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.oldethnicitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.oldethnicitydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.OldEthnicityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.oldethnicitydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'oldethnicitydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.oldethnicitydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.oldethnicitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.openstaffposition_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.openstaffposition(
        oldeducationorganizationid, oldrequisitionnumber, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.requisitionnumber, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'openstaffposition') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.openstaffposition 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.openstaffposition_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.operationalstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.operationalstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.OperationalStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.operationalstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'operationalstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.operationalstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.operationalstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.othernametypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.othernametypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.OtherNameTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.othernametypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'othernametypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.othernametypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.othernametypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.parent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.parent(
        oldparentusi, oldparentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.parentusi, OLD.parentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'parent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.parent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.parent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.participationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.participationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ParticipationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.participationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'participationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.participationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.participationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.participationstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.participationstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ParticipationStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.participationstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'participationstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.participationstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.participationstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.payroll_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj4 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj4 * FROM edfi.staff j4 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.payroll(
        oldaccountidentifier, oldasofdate, oldeducationorganizationid, oldfiscalyear, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.accountidentifier, OLD.asofdate, OLD.educationorganizationid, OLD.fiscalyear, OLD.staffusi, dj4.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'payroll') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.payroll 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.payroll_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performancebaseconversiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.performancebaseconversiondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PerformanceBaseConversionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.performancebaseconversiondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performancebaseconversiondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.performancebaseconversiondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performancebaseconversiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.performanceleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.performanceleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PerformanceLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.performanceleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'performanceleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.performanceleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.performanceleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.person_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_edfi.person(
        oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.personid, OLD.sourcesystemdescriptorid, dj1.namespace, dj1.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'person') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.person 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.person_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.personalinformationverificationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.personalinformationverificationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PersonalInformationVerificationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.personalinformationverificationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'personalinformationverificationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.personalinformationverificationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.personalinformationverificationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.platformtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.platformtypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PlatformTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.platformtypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'platformtypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.platformtypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.platformtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.populationserveddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.populationserveddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PopulationServedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.populationserveddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'populationserveddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.populationserveddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.populationserveddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postingresultdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.postingresultdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PostingResultDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.postingresultdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postingresultdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.postingresultdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postingresultdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postsecondaryevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.postsecondaryeventcategorydescriptorid;
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.postsecondaryevent(
        oldeventdate, oldpostsecondaryeventcategorydescriptorid, oldpostsecondaryeventcategorydescriptornamespace, oldpostsecondaryeventcategorydescriptorcodevalue, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.eventdate, OLD.postsecondaryeventcategorydescriptorid, dj1.namespace, dj1.codevalue, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.postsecondaryevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postsecondaryevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postsecondaryeventcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.postsecondaryeventcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PostSecondaryEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.postsecondaryeventcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryeventcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.postsecondaryeventcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postsecondaryeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.postsecondaryinstitutionleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.postsecondaryinstitutionleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PostSecondaryInstitutionLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.postsecondaryinstitutionleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'postsecondaryinstitutionleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.postsecondaryinstitutionleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.postsecondaryinstitutionleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.primarylearningdeviceaccessdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.primarylearningdeviceaccessdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PrimaryLearningDeviceAccessDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.primarylearningdeviceaccessdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'primarylearningdeviceaccessdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.primarylearningdeviceaccessdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.primarylearningdeviceaccessdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.primarylearningdeviceawayfromschooldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.primarylearningdeviceawayfromschooldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.primarylearningdeviceawayfromschooldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'primarylearningdeviceawayfromschooldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.primarylearningdeviceawayfromschooldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.primarylearningdeviceawayfromschooldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.primarylearningdeviceproviderdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.primarylearningdeviceproviderdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PrimaryLearningDeviceProviderDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.primarylearningdeviceproviderdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'primarylearningdeviceproviderdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.primarylearningdeviceproviderdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.primarylearningdeviceproviderdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.proficiencydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.proficiencydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProficiencyDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.proficiencydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'proficiencydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.proficiencydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.proficiencydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.program_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.program(
        oldeducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'program') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.program 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.program_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programassignmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.programassignmentdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProgramAssignmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.programassignmentdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programassignmentdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.programassignmentdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programassignmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programcharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.programcharacteristicdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProgramCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.programcharacteristicdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programcharacteristicdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.programcharacteristicdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programcharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programsponsordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.programsponsordescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProgramSponsorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.programsponsordescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programsponsordescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.programsponsordescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programsponsordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.programtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.programtypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProgramTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.programtypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'programtypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.programtypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.programtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.progressdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.progressdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProgressDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.progressdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'progressdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.progressdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.progressdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.progressleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.progressleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProgressLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.progressleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'progressleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.progressleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.progressleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.providercategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.providercategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProviderCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.providercategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'providercategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.providercategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.providercategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.providerprofitabilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.providerprofitabilitydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProviderProfitabilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.providerprofitabilitydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'providerprofitabilitydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.providerprofitabilitydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.providerprofitabilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.providerstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.providerstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ProviderStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.providerstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'providerstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.providerstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.providerstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.publicationstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.publicationstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.PublicationStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.publicationstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'publicationstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.publicationstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.publicationstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.questionformdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.questionformdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.QuestionFormDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.questionformdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'questionformdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.questionformdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.questionformdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.racedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.racedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.RaceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.racedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'racedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.racedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.racedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reasonexiteddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.reasonexiteddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ReasonExitedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.reasonexiteddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reasonexiteddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.reasonexiteddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reasonexiteddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reasonnottesteddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.reasonnottesteddescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ReasonNotTestedDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.reasonnottesteddescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reasonnottesteddescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.reasonnottesteddescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reasonnottesteddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.recognitiontypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.recognitiontypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.RecognitionTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.recognitiontypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'recognitiontypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.recognitiontypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.recognitiontypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.relationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.relationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.RelationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.relationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'relationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.relationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.relationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.repeatidentifierdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.repeatidentifierdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.RepeatIdentifierDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.repeatidentifierdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'repeatidentifierdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.repeatidentifierdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.repeatidentifierdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reportcard_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
    dj5 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.gradingperioddescriptorid;
    SELECT INTO dj5 * FROM edfi.student j5 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.reportcard(
        oldeducationorganizationid, oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodschoolid, oldgradingperiodschoolyear, oldgradingperiodsequence, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.gradingperioddescriptorid, dj1.namespace, dj1.codevalue, OLD.gradingperiodschoolid, OLD.gradingperiodschoolyear, OLD.gradingperiodsequence, OLD.studentusi, dj5.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reportcard') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.reportcard 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reportcard_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.reporterdescriptiondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.reporterdescriptiondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ReporterDescriptionDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.reporterdescriptiondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'reporterdescriptiondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.reporterdescriptiondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.reporterdescriptiondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.residencystatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.residencystatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ResidencyStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.residencystatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'residencystatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.residencystatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.residencystatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.responseindicatordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.responseindicatordescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ResponseIndicatorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.responseindicatordescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'responseindicatordescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.responseindicatordescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.responseindicatordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.responsibilitydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.responsibilitydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ResponsibilityDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.responsibilitydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'responsibilitydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.responsibilitydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.responsibilitydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.restraintevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.restraintevent(
        oldrestrainteventidentifier, oldschoolid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.restrainteventidentifier, OLD.schoolid, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'restraintevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.restraintevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.restraintevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.restrainteventreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.restrainteventreasondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.RestraintEventReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.restrainteventreasondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'restrainteventreasondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.restrainteventreasondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.restrainteventreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.resultdatatypetypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.resultdatatypetypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ResultDatatypeTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.resultdatatypetypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'resultdatatypetypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.resultdatatypetypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.resultdatatypetypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.retestindicatordescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.retestindicatordescriptorid, b.codevalue, b.namespace, b.id, 'edfi.RetestIndicatorDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.retestindicatordescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'retestindicatordescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.retestindicatordescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.retestindicatordescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.schoolcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SchoolCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.schoolcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.schoolcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolchoiceimplementstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.schoolchoiceimplementstatusdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SchoolChoiceImplementStatusDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.schoolchoiceimplementstatusdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolchoiceimplementstatusdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.schoolchoiceimplementstatusdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolchoiceimplementstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolfoodserviceprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.schoolfoodserviceprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SchoolFoodServiceProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.schoolfoodserviceprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolfoodserviceprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.schoolfoodserviceprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolfoodserviceprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schooltypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.schooltypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SchoolTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.schooltypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schooltypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.schooltypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schooltypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.schoolyeartype_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.schoolyeartype(
        oldschoolyear, 
        id, changeversion)
    VALUES( 
        OLD.schoolyear, 
        OLD.id, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'schoolyeartype') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.schoolyeartype 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.schoolyeartype_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.section_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.section(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'section') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.section 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.section_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sectionattendancetakenevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.sectionattendancetakenevent(
        oldcalendarcode, olddate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.calendarcode, OLD.date, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sectionattendancetakenevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.sectionattendancetakenevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sectionattendancetakenevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sectioncharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.sectioncharacteristicdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SectionCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.sectioncharacteristicdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sectioncharacteristicdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.sectioncharacteristicdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sectioncharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.separationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.separationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SeparationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.separationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'separationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.separationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.separationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.separationreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.separationreasondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SeparationReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.separationreasondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'separationreasondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.separationreasondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.separationreasondescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.servicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.servicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.ServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.servicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'servicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.servicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.servicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.session_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.session(
        oldschoolid, oldschoolyear, oldsessionname, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.schoolid, OLD.schoolyear, OLD.sessionname, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'session') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.session 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.session_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sexdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.sexdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SexDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.sexdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sexdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.sexdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sexdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.sourcesystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.sourcesystemdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SourceSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.sourcesystemdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'sourcesystemdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.sourcesystemdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.sourcesystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.specialeducationprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.specialeducationprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SpecialEducationProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.specialeducationprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'specialeducationprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.specialeducationprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.specialeducationprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.specialeducationsettingdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.specialeducationsettingdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SpecialEducationSettingDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.specialeducationsettingdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'specialeducationsettingdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.specialeducationsettingdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.specialeducationsettingdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staff_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.staff(
        oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.staffusi, OLD.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staff') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staff 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staff_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffabsenceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj2 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.absenceeventcategorydescriptorid;
    SELECT INTO dj2 * FROM edfi.staff j2 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffabsenceevent(
        oldabsenceeventcategorydescriptorid, oldabsenceeventcategorydescriptornamespace, oldabsenceeventcategorydescriptorcodevalue, oldeventdate, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.absenceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.eventdate, OLD.staffusi, dj2.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffabsenceevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffabsenceevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffabsenceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffclassificationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.staffclassificationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.StaffClassificationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.staffclassificationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffclassificationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffclassificationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffclassificationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffcohortassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj3 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj3 * FROM edfi.staff j3 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffcohortassociation(
        oldbegindate, oldcohortidentifier, oldeducationorganizationid, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.cohortidentifier, OLD.educationorganizationid, OLD.staffusi, dj3.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffcohortassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffcohortassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffcohortassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffdisciplineincidentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.staff j2 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffdisciplineincidentassociation(
        oldincidentidentifier, oldschoolid, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.incidentidentifier, OLD.schoolid, OLD.staffusi, dj2.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffdisciplineincidentassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffdisciplineincidentassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffdisciplineincidentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffeducationorganizationassignmentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.staffclassificationdescriptorid;
    SELECT INTO dj3 * FROM edfi.staff j3 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffeducationorganizationassignmentassociation(
        oldbegindate, oldeducationorganizationid, oldstaffclassificationdescriptorid, oldstaffclassificationdescriptornamespace, oldstaffclassificationdescriptorcodevalue, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.educationorganizationid, OLD.staffclassificationdescriptorid, dj2.namespace, dj2.codevalue, OLD.staffusi, dj3.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationassignmentassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffeducationorganizationassignmentassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffeducationorganizationassignmentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffeducationorganizationcontactassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.staff j2 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffeducationorganizationcontactassociation(
        oldcontacttitle, oldeducationorganizationid, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.contacttitle, OLD.educationorganizationid, OLD.staffusi, dj2.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationcontactassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffeducationorganizationcontactassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffeducationorganizationcontactassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffeducationorganizationemploymentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
    dj3 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.employmentstatusdescriptorid;
    SELECT INTO dj3 * FROM edfi.staff j3 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffeducationorganizationemploymentassociation(
        oldeducationorganizationid, oldemploymentstatusdescriptorid, oldemploymentstatusdescriptornamespace, oldemploymentstatusdescriptorcodevalue, oldhiredate, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.employmentstatusdescriptorid, dj1.namespace, dj1.codevalue, OLD.hiredate, OLD.staffusi, dj3.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffeducationorganizationemploymentassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffeducationorganizationemploymentassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffeducationorganizationemploymentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.staffidentificationsystemdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.StaffIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.staffidentificationsystemdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffidentificationsystemdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffidentificationsystemdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffleave_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.descriptor%ROWTYPE;
    dj2 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.staffleaveeventcategorydescriptorid;
    SELECT INTO dj2 * FROM edfi.staff j2 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffleave(
        oldbegindate, oldstaffleaveeventcategorydescriptorid, oldstaffleaveeventcategorydescriptornamespace, oldstaffleaveeventcategorydescriptorcodevalue, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.staffleaveeventcategorydescriptorid, dj1.namespace, dj1.codevalue, OLD.staffusi, dj2.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffleave') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffleave 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffleave_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffleaveeventcategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.staffleaveeventcategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.StaffLeaveEventCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.staffleaveeventcategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffleaveeventcategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffleaveeventcategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffleaveeventcategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj3 edfi.descriptor%ROWTYPE;
    dj4 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.programtypedescriptorid;
    SELECT INTO dj4 * FROM edfi.staff j4 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffprogramassociation(
        oldbegindate, oldprogrameducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.programeducationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj3.namespace, dj3.codevalue, OLD.staffusi, dj4.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffprogramassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffprogramassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffschoolassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj2 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programassignmentdescriptorid;
    SELECT INTO dj2 * FROM edfi.staff j2 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffschoolassociation(
        oldprogramassignmentdescriptorid, oldprogramassignmentdescriptornamespace, oldprogramassignmentdescriptorcodevalue, oldschoolid, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.programassignmentdescriptorid, dj0.namespace, dj0.codevalue, OLD.schoolid, OLD.staffusi, dj2.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffschoolassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffschoolassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffschoolassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.staffsectionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj5 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj5 * FROM edfi.staff j5 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.staffsectionassociation(
        oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstaffusi, oldstaffuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.staffusi, dj5.staffuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'staffsectionassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.staffsectionassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.staffsectionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.stateabbreviationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.stateabbreviationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.StateAbbreviationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.stateabbreviationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'stateabbreviationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.stateabbreviationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.stateabbreviationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.student_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.student(
        oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.studentusi, OLD.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'student') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.student 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.student_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentacademicrecord_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.student%ROWTYPE;
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;
    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_edfi.studentacademicrecord(
        oldeducationorganizationid, oldschoolyear, oldstudentusi, oldstudentuniqueid, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.schoolyear, OLD.studentusi, dj2.studentuniqueid, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentacademicrecord') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentacademicrecord 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentacademicrecord_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentassessment_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj3 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj3 * FROM edfi.student j3 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentassessment(
        oldassessmentidentifier, oldnamespace, oldstudentassessmentidentifier, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.assessmentidentifier, OLD.namespace, OLD.studentassessmentidentifier, OLD.studentusi, dj3.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentassessment') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentassessment 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentassessment_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentcharacteristicdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.studentcharacteristicdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.StudentCharacteristicDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.studentcharacteristicdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentcharacteristicdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentcharacteristicdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentcharacteristicdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentcohortassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj3 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj3 * FROM edfi.student j3 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentcohortassociation(
        oldbegindate, oldcohortidentifier, oldeducationorganizationid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.cohortidentifier, OLD.educationorganizationid, OLD.studentusi, dj3.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentcohortassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentcohortassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentcohortassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentcompetencyobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj6 edfi.descriptor%ROWTYPE;
    dj7 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.gradingperioddescriptorid;
    SELECT INTO dj6 * FROM edfi.descriptor j6 WHERE descriptorid = old.objectivegradeleveldescriptorid;
    SELECT INTO dj7 * FROM edfi.student j7 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentcompetencyobjective(
        oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodschoolid, oldgradingperiodschoolyear, oldgradingperiodsequence, oldobjective, oldobjectiveeducationorganizationid, oldobjectivegradeleveldescriptorid, oldobjectivegradeleveldescriptornamespace, oldobjectivegradeleveldescriptorcodevalue, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.gradingperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.gradingperiodschoolid, OLD.gradingperiodschoolyear, OLD.gradingperiodsequence, OLD.objective, OLD.objectiveeducationorganizationid, OLD.objectivegradeleveldescriptorid, dj6.namespace, dj6.codevalue, OLD.studentusi, dj7.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentcompetencyobjective') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentcompetencyobjective 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentcompetencyobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentdisciplineincidentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentdisciplineincidentassociation(
        oldincidentidentifier, oldschoolid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.incidentidentifier, OLD.schoolid, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentdisciplineincidentassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentdisciplineincidentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentdisciplineincidentbehaviorassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj3 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.behaviordescriptorid;
    SELECT INTO dj3 * FROM edfi.student j3 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentdisciplineincidentbehaviorassociation(
        oldbehaviordescriptorid, oldbehaviordescriptornamespace, oldbehaviordescriptorcodevalue, oldincidentidentifier, oldschoolid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.behaviordescriptorid, dj0.namespace, dj0.codevalue, OLD.incidentidentifier, OLD.schoolid, OLD.studentusi, dj3.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentbehaviorassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentdisciplineincidentbehaviorassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentdisciplineincidentbehaviorassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation(
        oldincidentidentifier, oldschoolid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.incidentidentifier, OLD.schoolid, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentdisciplineincidentnonoffenderassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentdisciplineincidentnonoffenderassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studenteducationorganizationassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studenteducationorganizationassociation(
        oldeducationorganizationid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studenteducationorganizationassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studenteducationorganizationassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studenteducationorganizationresponsibilityassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.descriptor%ROWTYPE;
    dj3 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.responsibilitydescriptorid;
    SELECT INTO dj3 * FROM edfi.student j3 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studenteducationorganizationresponsibilityassociation(
        oldbegindate, oldeducationorganizationid, oldresponsibilitydescriptorid, oldresponsibilitydescriptornamespace, oldresponsibilitydescriptorcodevalue, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.educationorganizationid, OLD.responsibilitydescriptorid, dj2.namespace, dj2.codevalue, OLD.studentusi, dj3.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studenteducationorganizationresponsibilityassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studenteducationorganizationresponsibilityassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studenteducationorganizationresponsibilityassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentgradebookentry_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj8 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj8 * FROM edfi.student j8 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentgradebookentry(
        oldbegindate, olddateassigned, oldgradebookentrytitle, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.dateassigned, OLD.gradebookentrytitle, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj8.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentgradebookentry') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentgradebookentry 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentgradebookentry_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentidentificationsystemdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.studentidentificationsystemdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.StudentIdentificationSystemDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.studentidentificationsystemdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentidentificationsystemdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentidentificationsystemdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentidentificationsystemdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentinterventionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentinterventionassociation(
        oldeducationorganizationid, oldinterventionidentificationcode, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.interventionidentificationcode, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentinterventionassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentinterventionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentinterventionattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj4 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;
    SELECT INTO dj4 * FROM edfi.student j4 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentinterventionattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeducationorganizationid, oldeventdate, oldinterventionidentificationcode, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.educationorganizationid, OLD.eventdate, OLD.interventionidentificationcode, OLD.studentusi, dj4.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentinterventionattendanceevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentinterventionattendanceevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentinterventionattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentlearningobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj6 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.gradingperioddescriptorid;
    SELECT INTO dj6 * FROM edfi.student j6 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentlearningobjective(
        oldgradingperioddescriptorid, oldgradingperioddescriptornamespace, oldgradingperioddescriptorcodevalue, oldgradingperiodschoolid, oldgradingperiodschoolyear, oldgradingperiodsequence, oldlearningobjectiveid, oldnamespace, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.gradingperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.gradingperiodschoolid, OLD.gradingperiodschoolyear, OLD.gradingperiodsequence, OLD.learningobjectiveid, OLD.namespace, OLD.studentusi, dj6.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentlearningobjective') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentlearningobjective 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentlearningobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentparentassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.parent%ROWTYPE;
    dj1 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.parent j0 WHERE parentusi = old.parentusi;
    SELECT INTO dj1 * FROM edfi.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentparentassociation(
        oldparentusi, oldparentuniqueid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.parentusi, dj0.parentuniqueid, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentparentassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentparentassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentparentassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentparticipationcodedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.studentparticipationcodedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.StudentParticipationCodeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.studentparticipationcodedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentparticipationcodedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentparticipationcodedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentparticipationcodedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentprogramattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj5 edfi.descriptor%ROWTYPE;
    dj6 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;
    SELECT INTO dj5 * FROM edfi.descriptor j5 WHERE descriptorid = old.programtypedescriptorid;
    SELECT INTO dj6 * FROM edfi.student j6 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentprogramattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeducationorganizationid, oldeventdate, oldprogrameducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.educationorganizationid, OLD.eventdate, OLD.programeducationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj5.namespace, dj5.codevalue, OLD.studentusi, dj6.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentprogramattendanceevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentprogramattendanceevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentprogramattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentschoolassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj2 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj2 * FROM edfi.student j2 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentschoolassociation(
        oldentrydate, oldschoolid, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.entrydate, OLD.schoolid, OLD.studentusi, dj2.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentschoolassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentschoolassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentschoolattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj5 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;
    SELECT INTO dj5 * FROM edfi.student j5 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentschoolattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeventdate, oldschoolid, oldschoolyear, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.eventdate, OLD.schoolid, OLD.schoolyear, OLD.sessionname, OLD.studentusi, dj5.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentschoolattendanceevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentschoolattendanceevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentschoolattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentsectionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj6 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj6 * FROM edfi.student j6 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentsectionassociation(
        oldbegindate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.begindate, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj6.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentsectionassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentsectionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.studentsectionattendanceevent_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 edfi.descriptor%ROWTYPE;
    dj7 edfi.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.attendanceeventcategorydescriptorid;
    SELECT INTO dj7 * FROM edfi.student j7 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_edfi.studentsectionattendanceevent(
        oldattendanceeventcategorydescriptorid, oldattendanceeventcategorydescriptornamespace, oldattendanceeventcategorydescriptorcodevalue, oldeventdate, oldlocalcoursecode, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldstudentusi, oldstudentuniqueid, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.attendanceeventcategorydescriptorid, dj0.namespace, dj0.codevalue, OLD.eventdate, OLD.localcoursecode, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.studentusi, dj7.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionattendanceevent') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.studentsectionattendanceevent 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.studentsectionattendanceevent_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.survey_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.survey(
        oldnamespace, oldsurveyidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'survey') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.survey 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.survey_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveycategorydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.surveycategorydescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SurveyCategoryDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.surveycategorydescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveycategorydescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveycategorydescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveycategorydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveycourseassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveycourseassociation(
        oldcoursecode, oldeducationorganizationid, oldnamespace, oldsurveyidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.coursecode, OLD.educationorganizationid, OLD.namespace, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveycourseassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveycourseassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveycourseassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.surveyleveldescriptorid, b.codevalue, b.namespace, b.id, 'edfi.SurveyLevelDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.surveyleveldescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyleveldescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveyleveldescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj3 edfi.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_edfi.surveyprogramassociation(
        oldeducationorganizationid, oldnamespace, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue, oldsurveyidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.namespace, OLD.programname, OLD.programtypedescriptorid, dj3.namespace, dj3.codevalue, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyprogramassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveyprogramassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyquestion_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveyquestion(
        oldnamespace, oldquestioncode, oldsurveyidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.questioncode, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestion') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveyquestion 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyquestion_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyquestionresponse_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveyquestionresponse(
        oldnamespace, oldquestioncode, oldsurveyidentifier, oldsurveyresponseidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.questioncode, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyquestionresponse') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveyquestionresponse 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyquestionresponse_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyresponse_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveyresponse(
        oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponse') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveyresponse 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyresponse_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation(
        oldeducationorganizationid, oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponseeducationorganizationtargetassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveyresponseeducationorganizationtargetassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveyresponsestafftargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.surveyresponsestafftargetassociation(
        oldnamespace, oldstaffusi, oldstaffuniqueid, oldsurveyidentifier, oldsurveyresponseidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.staffusi, dj1.staffuniqueid, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveyresponsestafftargetassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveyresponsestafftargetassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveyresponsestafftargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysection_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveysection(
        oldnamespace, oldsurveyidentifier, oldsurveysectiontitle, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.surveyidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysection') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveysection 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysection_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveysectionassociation(
        oldlocalcoursecode, oldnamespace, oldschoolid, oldschoolyear, oldsectionidentifier, oldsessionname, oldsurveyidentifier, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.localcoursecode, OLD.namespace, OLD.schoolid, OLD.schoolyear, OLD.sectionidentifier, OLD.sessionname, OLD.surveyidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveysectionassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionresponse_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveysectionresponse(
        oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponse') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveysectionresponse 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionresponse_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionresponseeducationorganizationtarget_730be1_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
BEGIN

    INSERT INTO tracked_changes_edfi.surveysectionresponseeducationorganizationtargetassociation(
        oldeducationorganizationid, oldnamespace, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.educationorganizationid, OLD.namespace, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponseeducationorganizationtargetassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveysectionresponseeducationorganizationtargetassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionresponseeducationorganizationtarget_730be1_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.surveysectionresponsestafftargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj1 edfi.staff%ROWTYPE;
BEGIN
    SELECT INTO dj1 * FROM edfi.staff j1 WHERE staffusi = old.staffusi;

    INSERT INTO tracked_changes_edfi.surveysectionresponsestafftargetassociation(
        oldnamespace, oldstaffusi, oldstaffuniqueid, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle, 
        id, discriminator, changeversion)
    VALUES( 
        OLD.namespace, OLD.staffusi, dj1.staffuniqueid, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'surveysectionresponsestafftargetassociation') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.surveysectionresponsestafftargetassociation 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.surveysectionresponsestafftargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.teachingcredentialbasisdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.teachingcredentialbasisdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TeachingCredentialBasisDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.teachingcredentialbasisdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'teachingcredentialbasisdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.teachingcredentialbasisdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.teachingcredentialbasisdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.teachingcredentialdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.teachingcredentialdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TeachingCredentialDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.teachingcredentialdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'teachingcredentialdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.teachingcredentialdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.teachingcredentialdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.technicalskillsassessmentdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.technicalskillsassessmentdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TechnicalSkillsAssessmentDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.technicalskillsassessmentdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'technicalskillsassessmentdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.technicalskillsassessmentdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.technicalskillsassessmentdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.telephonenumbertypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.telephonenumbertypedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TelephoneNumberTypeDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.telephonenumbertypedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'telephonenumbertypedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.telephonenumbertypedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.telephonenumbertypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.termdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.termdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TermDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.termdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'termdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.termdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.termdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.titleipartaparticipantdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.titleipartaparticipantdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TitleIPartAParticipantDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.titleipartaparticipantdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'titleipartaparticipantdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.titleipartaparticipantdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.titleipartaparticipantdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.titleipartaprogramservicedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.titleipartaprogramservicedescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TitleIPartAProgramServiceDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.titleipartaprogramservicedescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'titleipartaprogramservicedescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.titleipartaprogramservicedescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.titleipartaprogramservicedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.titleipartaschooldesignationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.titleipartaschooldesignationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TitleIPartASchoolDesignationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.titleipartaschooldesignationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'titleipartaschooldesignationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.titleipartaschooldesignationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.titleipartaschooldesignationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.tribalaffiliationdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.tribalaffiliationdescriptorid, b.codevalue, b.namespace, b.id, 'edfi.TribalAffiliationDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.tribalaffiliationdescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'tribalaffiliationdescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.tribalaffiliationdescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.tribalaffiliationdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.visadescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.visadescriptorid, b.codevalue, b.namespace, b.id, 'edfi.VisaDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.visadescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'visadescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.visadescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.visadescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_edfi.weapondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.weapondescriptorid, b.codevalue, b.namespace, b.id, 'edfi.WeaponDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.weapondescriptorid = b.descriptorid;

    RETURN null;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'edfi' AND event_object_table = 'weapondescriptor') THEN
    CREATE TRIGGER trackdeletes AFTER DELETE ON edfi.weapondescriptor 
        FOR EACH ROW EXECUTE PROCEDURE tracked_changes_edfi.weapondescriptor_deleted();
END IF;

END
$$;