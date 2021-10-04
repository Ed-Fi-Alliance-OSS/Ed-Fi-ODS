-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE FUNCTION tracked_deletes_tpdm.AccreditationStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AccreditationStatusDescriptor(AccreditationStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.AccreditationStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AccreditationStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AccreditationStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AccreditationStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AidTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AidTypeDescriptor(AidTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.AidTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AidTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AidTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AidTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CandidateEducatorPreparationProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CandidateEducatorPreparationProgramAssociation(BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.CandidateIdentifier, OLD.EducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CandidateEducatorPreparationProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CandidateEducatorPreparationProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.Candidate_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.Candidate(CandidateIdentifier, Id, ChangeVersion)
    VALUES (OLD.CandidateIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.Candidate 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.Candidate_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CertificationRouteDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationRouteDescriptor(CertificationRouteDescriptorId, Id, ChangeVersion)
    SELECT OLD.CertificationRouteDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CertificationRouteDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationRouteDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationRouteDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CoteachingStyleObservedDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CoteachingStyleObservedDescriptor(CoteachingStyleObservedDescriptorId, Id, ChangeVersion)
    SELECT OLD.CoteachingStyleObservedDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CoteachingStyleObservedDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CoteachingStyleObservedDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CoteachingStyleObservedDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CredentialStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CredentialStatusDescriptor(CredentialStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.CredentialStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CredentialStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CredentialStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CredentialStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EPPProgramPathwayDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EPPProgramPathwayDescriptor(EPPProgramPathwayDescriptorId, Id, ChangeVersion)
    SELECT OLD.EPPProgramPathwayDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EPPProgramPathwayDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EPPProgramPathwayDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EPPProgramPathwayDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EducatorPreparationProgram_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EducatorPreparationProgram(EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EducatorPreparationProgram 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EducatorPreparationProgram_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EducatorRoleDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EducatorRoleDescriptor(EducatorRoleDescriptorId, Id, ChangeVersion)
    SELECT OLD.EducatorRoleDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EducatorRoleDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EducatorRoleDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EducatorRoleDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EnglishLanguageExamDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EnglishLanguageExamDescriptor(EnglishLanguageExamDescriptorId, Id, ChangeVersion)
    SELECT OLD.EnglishLanguageExamDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EnglishLanguageExamDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EnglishLanguageExamDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EnglishLanguageExamDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationElementRatingLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationElementRatingLevelDescriptor(EvaluationElementRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.EvaluationElementRatingLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EvaluationElementRatingLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationElementRatingLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationElementRatingLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationElementRating_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationElementRating(EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationDate, OLD.EvaluationElementTitle, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.PersonId, OLD.SchoolYear, OLD.SourceSystemDescriptorId, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationElementRating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationElementRating_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationElement_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationElement(EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationElementTitle, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationElement 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationElement_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationObjectiveRating_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationObjectiveRating(EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationDate, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.PersonId, OLD.SchoolYear, OLD.SourceSystemDescriptorId, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationObjectiveRating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationObjectiveRating_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationObjective_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationObjective(EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationObjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationObjective_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationPeriodDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationPeriodDescriptor(EvaluationPeriodDescriptorId, Id, ChangeVersion)
    SELECT OLD.EvaluationPeriodDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EvaluationPeriodDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationPeriodDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationPeriodDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationRatingLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationRatingLevelDescriptor(EvaluationRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.EvaluationRatingLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EvaluationRatingLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationRatingLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationRatingLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationRatingStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationRatingStatusDescriptor(EvaluationRatingStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.EvaluationRatingStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EvaluationRatingStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationRatingStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationRatingStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationRating_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationRating(EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationDate, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.PersonId, OLD.SchoolYear, OLD.SourceSystemDescriptorId, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationRating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationRating_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EvaluationTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EvaluationTypeDescriptor(EvaluationTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.EvaluationTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EvaluationTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EvaluationTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EvaluationTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.Evaluation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.Evaluation(EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.Evaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.Evaluation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.FinancialAid_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.FinancialAid(AidTypeDescriptorId, BeginDate, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.AidTypeDescriptorId, OLD.BeginDate, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.FinancialAid 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.FinancialAid_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.GenderDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.GenderDescriptor(GenderDescriptorId, Id, ChangeVersion)
    SELECT OLD.GenderDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GenderDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.GenderDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.GenderDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ObjectiveRatingLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ObjectiveRatingLevelDescriptor(ObjectiveRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.ObjectiveRatingLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ObjectiveRatingLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ObjectiveRatingLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ObjectiveRatingLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.PerformanceEvaluationRatingLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.PerformanceEvaluationRatingLevelDescriptor(PerformanceEvaluationRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.PerformanceEvaluationRatingLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PerformanceEvaluationRatingLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.PerformanceEvaluationRatingLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.PerformanceEvaluationRatingLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.PerformanceEvaluationRating_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.PerformanceEvaluationRating(EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationPeriodDescriptorId, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.PersonId, OLD.SchoolYear, OLD.SourceSystemDescriptorId, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.PerformanceEvaluationRating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.PerformanceEvaluationRating_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.PerformanceEvaluationTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.PerformanceEvaluationTypeDescriptor(PerformanceEvaluationTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.PerformanceEvaluationTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PerformanceEvaluationTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.PerformanceEvaluationTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.PerformanceEvaluationTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.PerformanceEvaluation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.PerformanceEvaluation(EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationPeriodDescriptorId, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.PerformanceEvaluation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.PerformanceEvaluation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.RubricDimension_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.RubricDimension(EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, RubricRating, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationElementTitle, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.RubricRating, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.RubricDimension 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.RubricDimension_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.RubricRatingLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.RubricRatingLevelDescriptor(RubricRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.RubricRatingLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RubricRatingLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.RubricRatingLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.RubricRatingLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.SurveyResponsePersonTargetAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.SurveyResponsePersonTargetAssociation(Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.PersonId, OLD.SourceSystemDescriptorId, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.SurveyResponsePersonTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.SurveyResponsePersonTargetAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.SurveySectionResponsePersonTargetAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.SurveySectionResponsePersonTargetAssociation(Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.PersonId, OLD.SourceSystemDescriptorId, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.SurveySectionTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.SurveySectionResponsePersonTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.SurveySectionResponsePersonTargetAssociation_TR_DelTrkg();

