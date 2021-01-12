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

CREATE FUNCTION tracked_deletes_tpdm.ApplicantProfile_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ApplicantProfile(ApplicantProfileIdentifier, Id, ChangeVersion)
    VALUES (OLD.ApplicantProfileIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ApplicantProfile 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ApplicantProfile_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ApplicationEventResultDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ApplicationEventResultDescriptor(ApplicationEventResultDescriptorId, Id, ChangeVersion)
    SELECT OLD.ApplicationEventResultDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ApplicationEventResultDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ApplicationEventResultDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ApplicationEventResultDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ApplicationEventTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ApplicationEventTypeDescriptor(ApplicationEventTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ApplicationEventTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ApplicationEventTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ApplicationEventTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ApplicationEventTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ApplicationEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ApplicationEvent(ApplicantProfileIdentifier, ApplicationEventTypeDescriptorId, ApplicationIdentifier, EducationOrganizationId, EventDate, SequenceNumber, Id, ChangeVersion)
    VALUES (OLD.ApplicantProfileIdentifier, OLD.ApplicationEventTypeDescriptorId, OLD.ApplicationIdentifier, OLD.EducationOrganizationId, OLD.EventDate, OLD.SequenceNumber, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ApplicationEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ApplicationEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ApplicationSourceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ApplicationSourceDescriptor(ApplicationSourceDescriptorId, Id, ChangeVersion)
    SELECT OLD.ApplicationSourceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ApplicationSourceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ApplicationSourceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ApplicationSourceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ApplicationStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ApplicationStatusDescriptor(ApplicationStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.ApplicationStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ApplicationStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ApplicationStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ApplicationStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.Application_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.Application(ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, Id, ChangeVersion)
    VALUES (OLD.ApplicantProfileIdentifier, OLD.ApplicationIdentifier, OLD.EducationOrganizationId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.Application 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.Application_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.BackgroundCheckStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.BackgroundCheckStatusDescriptor(BackgroundCheckStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.BackgroundCheckStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.BackgroundCheckStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.BackgroundCheckStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.BackgroundCheckStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.BackgroundCheckTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.BackgroundCheckTypeDescriptor(BackgroundCheckTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.BackgroundCheckTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.BackgroundCheckTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.BackgroundCheckTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.BackgroundCheckTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CandidateCharacteristicDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CandidateCharacteristicDescriptor(CandidateCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT OLD.CandidateCharacteristicDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CandidateCharacteristicDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CandidateCharacteristicDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CandidateCharacteristicDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.CandidateRelationshipToStaffAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CandidateRelationshipToStaffAssociation(CandidateIdentifier, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.CandidateIdentifier, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CandidateRelationshipToStaffAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CandidateRelationshipToStaffAssociation_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.CertificationExamResult_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationExamResult(CertificationExamDate, CertificationExamIdentifier, Namespace, PersonId, SourceSystemDescriptorId, Id, ChangeVersion)
    VALUES (OLD.CertificationExamDate, OLD.CertificationExamIdentifier, OLD.Namespace, OLD.PersonId, OLD.SourceSystemDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationExamResult 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationExamResult_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CertificationExamStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationExamStatusDescriptor(CertificationExamStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.CertificationExamStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CertificationExamStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationExamStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationExamStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CertificationExamTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationExamTypeDescriptor(CertificationExamTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CertificationExamTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CertificationExamTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationExamTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationExamTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CertificationExam_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationExam(CertificationExamIdentifier, Namespace, Id, ChangeVersion)
    VALUES (OLD.CertificationExamIdentifier, OLD.Namespace, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationExam 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationExam_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CertificationFieldDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationFieldDescriptor(CertificationFieldDescriptorId, Id, ChangeVersion)
    SELECT OLD.CertificationFieldDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CertificationFieldDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationFieldDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationFieldDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CertificationLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationLevelDescriptor(CertificationLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.CertificationLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CertificationLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationLevelDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.CertificationStandardDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CertificationStandardDescriptor(CertificationStandardDescriptorId, Id, ChangeVersion)
    SELECT OLD.CertificationStandardDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CertificationStandardDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CertificationStandardDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CertificationStandardDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.Certification_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.Certification(CertificationIdentifier, Namespace, Id, ChangeVersion)
    VALUES (OLD.CertificationIdentifier, OLD.Namespace, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.Certification 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.Certification_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.CredentialEventTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CredentialEventTypeDescriptor(CredentialEventTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CredentialEventTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CredentialEventTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CredentialEventTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CredentialEventTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.CredentialEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CredentialEvent(CredentialEventDate, CredentialEventTypeDescriptorId, CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, Id, ChangeVersion)
    VALUES (OLD.CredentialEventDate, OLD.CredentialEventTypeDescriptorId, OLD.CredentialIdentifier, OLD.StateOfIssueStateAbbreviationDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CredentialEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CredentialEvent_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.DegreeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.DegreeDescriptor(DegreeDescriptorId, Id, ChangeVersion)
    SELECT OLD.DegreeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DegreeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.DegreeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.DegreeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EPPDegreeTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EPPDegreeTypeDescriptor(EPPDegreeTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.EPPDegreeTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EPPDegreeTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EPPDegreeTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EPPDegreeTypeDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.EducatorPreparationProgramTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EducatorPreparationProgramTypeDescriptor(EducatorPreparationProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.EducatorPreparationProgramTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EducatorPreparationProgramTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EducatorPreparationProgramTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EducatorPreparationProgramTypeDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.FederalLocaleCodeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.FederalLocaleCodeDescriptor(FederalLocaleCodeDescriptorId, Id, ChangeVersion)
    SELECT OLD.FederalLocaleCodeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.FederalLocaleCodeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.FederalLocaleCodeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.FederalLocaleCodeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.FieldworkExperienceSectionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.FieldworkExperienceSectionAssociation(BeginDate, FieldworkIdentifier, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.FieldworkIdentifier, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.FieldworkExperienceSectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.FieldworkExperienceSectionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.FieldworkExperience_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.FieldworkExperience(BeginDate, FieldworkIdentifier, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.FieldworkIdentifier, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.FieldworkExperience 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.FieldworkExperience_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.FieldworkTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.FieldworkTypeDescriptor(FieldworkTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.FieldworkTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.FieldworkTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.FieldworkTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.FieldworkTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.FundingSourceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.FundingSourceDescriptor(FundingSourceDescriptorId, Id, ChangeVersion)
    SELECT OLD.FundingSourceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.FundingSourceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.FundingSourceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.FundingSourceDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.GoalTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.GoalTypeDescriptor(GoalTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.GoalTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GoalTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.GoalTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.GoalTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.Goal_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.Goal(AssignmentDate, GoalTitle, PersonId, SourceSystemDescriptorId, Id, ChangeVersion)
    VALUES (OLD.AssignmentDate, OLD.GoalTitle, OLD.PersonId, OLD.SourceSystemDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.Goal 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.Goal_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.HireStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.HireStatusDescriptor(HireStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.HireStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.HireStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.HireStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.HireStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.HiringSourceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.HiringSourceDescriptor(HiringSourceDescriptorId, Id, ChangeVersion)
    SELECT OLD.HiringSourceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.HiringSourceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.HiringSourceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.HiringSourceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.InstructionalSettingDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.InstructionalSettingDescriptor(InstructionalSettingDescriptorId, Id, ChangeVersion)
    SELECT OLD.InstructionalSettingDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InstructionalSettingDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.InstructionalSettingDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.InstructionalSettingDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.LengthOfContractDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.LengthOfContractDescriptor(LengthOfContractDescriptorId, Id, ChangeVersion)
    SELECT OLD.LengthOfContractDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LengthOfContractDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.LengthOfContractDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.LengthOfContractDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.OpenStaffPositionEventStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.OpenStaffPositionEventStatusDescriptor(OpenStaffPositionEventStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.OpenStaffPositionEventStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.OpenStaffPositionEventStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.OpenStaffPositionEventStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.OpenStaffPositionEventStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.OpenStaffPositionEventTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.OpenStaffPositionEventTypeDescriptor(OpenStaffPositionEventTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.OpenStaffPositionEventTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.OpenStaffPositionEventTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.OpenStaffPositionEventTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.OpenStaffPositionEventTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.OpenStaffPositionEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.OpenStaffPositionEvent(EducationOrganizationId, EventDate, OpenStaffPositionEventTypeDescriptorId, RequisitionNumber, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EventDate, OLD.OpenStaffPositionEventTypeDescriptorId, OLD.RequisitionNumber, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.OpenStaffPositionEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.OpenStaffPositionEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.OpenStaffPositionReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.OpenStaffPositionReasonDescriptor(OpenStaffPositionReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.OpenStaffPositionReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.OpenStaffPositionReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.OpenStaffPositionReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.OpenStaffPositionReasonDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.PreviousCareerDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.PreviousCareerDescriptor(PreviousCareerDescriptorId, Id, ChangeVersion)
    SELECT OLD.PreviousCareerDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PreviousCareerDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.PreviousCareerDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.PreviousCareerDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ProfessionalDevelopmentEventAttendance_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ProfessionalDevelopmentEventAttendance(AttendanceDate, Namespace, PersonId, ProfessionalDevelopmentTitle, SourceSystemDescriptorId, Id, ChangeVersion)
    VALUES (OLD.AttendanceDate, OLD.Namespace, OLD.PersonId, OLD.ProfessionalDevelopmentTitle, OLD.SourceSystemDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ProfessionalDevelopmentEventAttendance 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ProfessionalDevelopmentEventAttendance_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ProfessionalDevelopmentEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ProfessionalDevelopmentEvent(Namespace, ProfessionalDevelopmentTitle, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.ProfessionalDevelopmentTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ProfessionalDevelopmentEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ProfessionalDevelopmentEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ProfessionalDevelopmentOfferedByDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ProfessionalDevelopmentOfferedByDescriptor(ProfessionalDevelopmentOfferedByDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProfessionalDevelopmentOfferedByDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProfessionalDevelopmentOfferedByDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ProfessionalDevelopmentOfferedByDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ProfessionalDevelopmentOfferedByDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ProgramGatewayDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ProgramGatewayDescriptor(ProgramGatewayDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProgramGatewayDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProgramGatewayDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ProgramGatewayDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ProgramGatewayDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.QuantitativeMeasureDatatypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.QuantitativeMeasureDatatypeDescriptor(QuantitativeMeasureDatatypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.QuantitativeMeasureDatatypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.QuantitativeMeasureDatatypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.QuantitativeMeasureDatatypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.QuantitativeMeasureDatatypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.QuantitativeMeasureScore_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.QuantitativeMeasureScore(EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, QuantitativeMeasureIdentifier, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationDate, OLD.EvaluationElementTitle, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.PersonId, OLD.QuantitativeMeasureIdentifier, OLD.SchoolYear, OLD.SourceSystemDescriptorId, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.QuantitativeMeasureScore 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.QuantitativeMeasureScore_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.QuantitativeMeasureTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.QuantitativeMeasureTypeDescriptor(QuantitativeMeasureTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.QuantitativeMeasureTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.QuantitativeMeasureTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.QuantitativeMeasureTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.QuantitativeMeasureTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.QuantitativeMeasure_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.QuantitativeMeasure(EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationElementTitle, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.QuantitativeMeasureIdentifier, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.QuantitativeMeasure 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.QuantitativeMeasure_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.RecruitmentEventAttendance_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.RecruitmentEventAttendance(EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EventDate, OLD.EventTitle, OLD.RecruitmentEventAttendeeIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.RecruitmentEventAttendance 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.RecruitmentEventAttendance_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.RecruitmentEventAttendeeTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.RecruitmentEventAttendeeTypeDescriptor(RecruitmentEventAttendeeTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.RecruitmentEventAttendeeTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RecruitmentEventAttendeeTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.RecruitmentEventAttendeeTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.RecruitmentEventAttendeeTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.RecruitmentEventTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.RecruitmentEventTypeDescriptor(RecruitmentEventTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.RecruitmentEventTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RecruitmentEventTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.RecruitmentEventTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.RecruitmentEventTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.RecruitmentEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.RecruitmentEvent(EducationOrganizationId, EventDate, EventTitle, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EventDate, OLD.EventTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.RecruitmentEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.RecruitmentEvent_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.SalaryTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.SalaryTypeDescriptor(SalaryTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.SalaryTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SalaryTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.SalaryTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.SalaryTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffEducatorPreparationProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffEducatorPreparationProgramAssociation(EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffEducatorPreparationProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffEducatorPreparationProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffToCandidateRelationshipDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffToCandidateRelationshipDescriptor(StaffToCandidateRelationshipDescriptorId, Id, ChangeVersion)
    SELECT OLD.StaffToCandidateRelationshipDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StaffToCandidateRelationshipDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffToCandidateRelationshipDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffToCandidateRelationshipDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.SurveySectionAggregateResponse_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.SurveySectionAggregateResponse(EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, Namespace, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, SurveyIdentifier, SurveySectionTitle, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EvaluationDate, OLD.EvaluationElementTitle, OLD.EvaluationObjectiveTitle, OLD.EvaluationPeriodDescriptorId, OLD.EvaluationTitle, OLD.Namespace, OLD.PerformanceEvaluationTitle, OLD.PerformanceEvaluationTypeDescriptorId, OLD.PersonId, OLD.SchoolYear, OLD.SourceSystemDescriptorId, OLD.SurveyIdentifier, OLD.SurveySectionTitle, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.SurveySectionAggregateResponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.SurveySectionAggregateResponse_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.WithdrawReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.WithdrawReasonDescriptor(WithdrawReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.WithdrawReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.WithdrawReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.WithdrawReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.WithdrawReasonDescriptor_TR_DelTrkg();

