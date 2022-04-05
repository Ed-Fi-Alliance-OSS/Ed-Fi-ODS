-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION tracked_changes_tpdm.accreditationstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AccreditationStatusDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.accreditationstatusdescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AccreditationStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'accreditationstatusdescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.accreditationstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.accreditationstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.aidtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AidTypeDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.aidtypedescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AidTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'aidtypedescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.aidtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.aidtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.candidate_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_tpdm.candidate(
        oldcandidateidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.candidateidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'candidate') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.candidate 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.candidate_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.candidateeducatorpreparationprogramassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_tpdm.candidateeducatorpreparationprogramassociation(
        oldbegindate, oldcandidateidentifier, oldeducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.begindate, OLD.candidateidentifier, OLD.educationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'candidateeducatorpreparationprogramassociation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.candidateeducatorpreparationprogramassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.candidateeducatorpreparationprogramassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.certificationroutedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CertificationRouteDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.certificationroutedescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CertificationRouteDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'certificationroutedescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.certificationroutedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.certificationroutedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.coteachingstyleobserveddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CoteachingStyleObservedDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.coteachingstyleobserveddescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CoteachingStyleObservedDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'coteachingstyleobserveddescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.coteachingstyleobserveddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.coteachingstyleobserveddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.credentialstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.CredentialStatusDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.credentialstatusdescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.CredentialStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'credentialstatusdescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.credentialstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.credentialstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.educatorpreparationprogram_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.programtypedescriptorid;

    INSERT INTO tracked_changes_tpdm.educatorpreparationprogram(
        oldeducationorganizationid, oldprogramname, oldprogramtypedescriptorid, oldprogramtypedescriptornamespace, oldprogramtypedescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.programname, OLD.programtypedescriptorid, dj0.namespace, dj0.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'educatorpreparationprogram') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.educatorpreparationprogram 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.educatorpreparationprogram_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.educatorroledescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EducatorRoleDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.educatorroledescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EducatorRoleDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'educatorroledescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.educatorroledescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.educatorroledescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.englishlanguageexamdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EnglishLanguageExamDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.englishlanguageexamdescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EnglishLanguageExamDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'englishlanguageexamdescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.englishlanguageexamdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.englishlanguageexamdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.eppprogrampathwaydescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EPPProgramPathwayDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.eppprogrampathwaydescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EPPProgramPathwayDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'eppprogrampathwaydescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.eppprogrampathwaydescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.eppprogrampathwaydescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.evaluation(
        oldeducationorganizationid, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationelement_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.evaluationelement(
        oldeducationorganizationid, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationelement') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationelement 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationelement_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationelementrating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
    dj3 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.evaluationelementrating(
        oldeducationorganizationid, oldevaluationdate, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationelementrating') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationelementrating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationelementrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationelementratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationElementRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.evaluationelementratingleveldescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationElementRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationelementratingleveldescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationelementratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationelementratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationobjective_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.evaluationobjective(
        oldeducationorganizationid, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationobjective') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationobjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationobjective_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationobjectiverating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
    dj3 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.evaluationobjectiverating(
        oldeducationorganizationid, oldevaluationdate, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationobjectiverating') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationobjectiverating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationobjectiverating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationperioddescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationPeriodDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.evaluationperioddescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationPeriodDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationperioddescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationperioddescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationperioddescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationrating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
    dj3 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.evaluationrating(
        oldeducationorganizationid, oldevaluationdate, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationdate, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationrating') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationrating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.evaluationratingleveldescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationratingleveldescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationratingstatusdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationRatingStatusDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.evaluationratingstatusdescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationRatingStatusDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationratingstatusdescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationratingstatusdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationratingstatusdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.evaluationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.EvaluationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.evaluationtypedescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.EvaluationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationtypedescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.evaluationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.evaluationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.financialaid_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.student%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.aidtypedescriptorid;

    SELECT INTO dj1 * FROM tpdm.student j1 WHERE studentusi = old.studentusi;

    INSERT INTO tracked_changes_tpdm.financialaid(
        oldaidtypedescriptorid, oldaidtypedescriptornamespace, oldaidtypedescriptorcodevalue, oldbegindate, oldstudentusi, oldstudentuniqueid,
        id, discriminator, changeversion)
    VALUES (
        OLD.aidtypedescriptorid, dj0.namespace, dj0.codevalue, OLD.begindate, OLD.studentusi, dj1.studentuniqueid, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'financialaid') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.financialaid 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.financialaid_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.genderdescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.GenderDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.genderdescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.GenderDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'genderdescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.genderdescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.genderdescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.objectiveratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.ObjectiveRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.objectiveratingleveldescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.ObjectiveRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'objectiveratingleveldescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.objectiveratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.objectiveratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.performanceevaluation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.performanceevaluation(
        oldeducationorganizationid, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.performanceevaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.performanceevaluation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.performanceevaluationrating_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
    dj3 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.sourcesystemdescriptorid;

    SELECT INTO dj3 * FROM edfi.descriptor j3 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.performanceevaluationrating(
        oldeducationorganizationid, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldpersonid, oldschoolyear, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.personid, OLD.schoolyear, OLD.sourcesystemdescriptorid, dj2.namespace, dj2.codevalue, OLD.termdescriptorid, dj3.namespace, dj3.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluationrating') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.performanceevaluationrating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.performanceevaluationrating_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.performanceevaluationratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PerformanceEvaluationRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.performanceevaluationratingleveldescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PerformanceEvaluationRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluationratingleveldescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.performanceevaluationratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.performanceevaluationratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.performanceevaluationtypedescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.PerformanceEvaluationTypeDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.performanceevaluationtypedescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.PerformanceEvaluationTypeDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluationtypedescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.performanceevaluationtypedescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.performanceevaluationtypedescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.rubricdimension_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
    dj1 tpdm.descriptor%ROWTYPE;
    dj2 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.evaluationperioddescriptorid;

    SELECT INTO dj1 * FROM edfi.descriptor j1 WHERE descriptorid = old.performanceevaluationtypedescriptorid;

    SELECT INTO dj2 * FROM edfi.descriptor j2 WHERE descriptorid = old.termdescriptorid;

    INSERT INTO tracked_changes_tpdm.rubricdimension(
        oldeducationorganizationid, oldevaluationelementtitle, oldevaluationobjectivetitle, oldevaluationperioddescriptorid, oldevaluationperioddescriptornamespace, oldevaluationperioddescriptorcodevalue, oldevaluationtitle, oldperformanceevaluationtitle, oldperformanceevaluationtypedescriptorid, oldperformanceevaluationtypedescriptornamespace, oldperformanceevaluationtypedescriptorcodevalue, oldrubricrating, oldschoolyear, oldtermdescriptorid, oldtermdescriptornamespace, oldtermdescriptorcodevalue,
        id, discriminator, changeversion)
    VALUES (
        OLD.educationorganizationid, OLD.evaluationelementtitle, OLD.evaluationobjectivetitle, OLD.evaluationperioddescriptorid, dj0.namespace, dj0.codevalue, OLD.evaluationtitle, OLD.performanceevaluationtitle, OLD.performanceevaluationtypedescriptorid, dj1.namespace, dj1.codevalue, OLD.rubricrating, OLD.schoolyear, OLD.termdescriptorid, dj2.namespace, dj2.codevalue, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'rubricdimension') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.rubricdimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.rubricdimension_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.rubricratingleveldescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.RubricRatingLevelDescriptorId, b.codevalue, b.namespace, b.id, 'tpdm.rubricratingleveldescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.RubricRatingLevelDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'rubricratingleveldescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.rubricratingleveldescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.rubricratingleveldescriptor_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.surveyresponsepersontargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_tpdm.surveyresponsepersontargetassociation(
        oldnamespace, oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldsurveyidentifier, oldsurveyresponseidentifier,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.personid, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.surveyidentifier, OLD.surveyresponseidentifier, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'surveyresponsepersontargetassociation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.surveyresponsepersontargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.surveyresponsepersontargetassociation_deleted();
END IF;

CREATE OR REPLACE FUNCTION tracked_changes_tpdm.surveysectionresponsepersontargetassociation_deleted()
    RETURNS trigger AS
$BODY$
DECLARE
    dj0 tpdm.descriptor%ROWTYPE;
BEGIN
    SELECT INTO dj0 * FROM edfi.descriptor j0 WHERE descriptorid = old.sourcesystemdescriptorid;

    INSERT INTO tracked_changes_tpdm.surveysectionresponsepersontargetassociation(
        oldnamespace, oldpersonid, oldsourcesystemdescriptorid, oldsourcesystemdescriptornamespace, oldsourcesystemdescriptorcodevalue, oldsurveyidentifier, oldsurveyresponseidentifier, oldsurveysectiontitle,
        id, discriminator, changeversion)
    VALUES (
        OLD.namespace, OLD.personid, OLD.sourcesystemdescriptorid, dj0.namespace, dj0.codevalue, OLD.surveyidentifier, OLD.surveyresponseidentifier, OLD.surveysectiontitle, 
        OLD.id, OLD.discriminator, nextval('changes.changeversionsequence'));

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'tpdm' AND event_object_table = 'surveysectionresponsepersontargetassociation') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.surveysectionresponsepersontargetassociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_tpdm.surveysectionresponsepersontargetassociation_deleted();
END IF;

END
$$;
