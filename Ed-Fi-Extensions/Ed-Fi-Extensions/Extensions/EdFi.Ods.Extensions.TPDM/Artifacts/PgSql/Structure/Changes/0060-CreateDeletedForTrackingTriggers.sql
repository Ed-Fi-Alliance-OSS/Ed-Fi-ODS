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

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentAcademicRecord_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentAcademicRecord(AnonymizedStudentIdentifier, EducationOrganizationId, FactAsOfDate, FactsAsOfDate, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.AnonymizedStudentIdentifier, OLD.EducationOrganizationId, OLD.FactAsOfDate, OLD.FactsAsOfDate, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentAcademicRecord 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentAcademicRecord_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentAssessmentCourseAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentAssessmentCourseAssociation(AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, CourseCode, EducationOrganizationId, FactsAsOfDate, SchoolYear, TakenSchoolYear, Id, ChangeVersion)
    VALUES (OLD.AdministrationDate, OLD.AnonymizedStudentIdentifier, OLD.AssessmentIdentifier, OLD.CourseCode, OLD.EducationOrganizationId, OLD.FactsAsOfDate, OLD.SchoolYear, OLD.TakenSchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentAssessmentCourseAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentAssessmentCourseAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentAssessmentSectionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentAssessmentSectionAssociation(AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, TakenSchoolYear, Id, ChangeVersion)
    VALUES (OLD.AdministrationDate, OLD.AnonymizedStudentIdentifier, OLD.AssessmentIdentifier, OLD.FactsAsOfDate, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.TakenSchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentAssessmentSectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentAssessmentSectionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentAssessment_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentAssessment(AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear, Id, ChangeVersion)
    VALUES (OLD.AdministrationDate, OLD.AnonymizedStudentIdentifier, OLD.AssessmentIdentifier, OLD.FactsAsOfDate, OLD.SchoolYear, OLD.TakenSchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentAssessment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentAssessment_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentCourseAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentCourseAssociation(AnonymizedStudentIdentifier, BeginDate, CourseCode, EducationOrganizationId, FactsAsOfDate, SchoolYear, Id, ChangeVersion)
    VALUES (OLD.AnonymizedStudentIdentifier, OLD.BeginDate, OLD.CourseCode, OLD.EducationOrganizationId, OLD.FactsAsOfDate, OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentCourseAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentCourseAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentCourseTranscript_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentCourseTranscript(AnonymizedStudentIdentifier, CourseCode, EducationOrganizationId, FactAsOfDate, FactsAsOfDate, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.AnonymizedStudentIdentifier, OLD.CourseCode, OLD.EducationOrganizationId, OLD.FactAsOfDate, OLD.FactsAsOfDate, OLD.SchoolYear, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentCourseTranscript 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentCourseTranscript_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentEducationOrganizationAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentEducationOrganizationAssociation(AnonymizedStudentIdentifier, BeginDate, EducationOrganizationId, FactsAsOfDate, SchoolYear, Id, ChangeVersion)
    VALUES (OLD.AnonymizedStudentIdentifier, OLD.BeginDate, OLD.EducationOrganizationId, OLD.FactsAsOfDate, OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentEducationOrganizationAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentEducationOrganizationAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudentSectionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudentSectionAssociation(AnonymizedStudentIdentifier, BeginDate, FactsAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, ChangeVersion)
    VALUES (OLD.AnonymizedStudentIdentifier, OLD.BeginDate, OLD.FactsAsOfDate, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudentSectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudentSectionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.AnonymizedStudent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.AnonymizedStudent(AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear, Id, ChangeVersion)
    VALUES (OLD.AnonymizedStudentIdentifier, OLD.FactsAsOfDate, OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.AnonymizedStudent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.AnonymizedStudent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ApplicantProspectAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ApplicantProspectAssociation(ApplicantIdentifier, EducationOrganizationId, ProspectIdentifier, Id, ChangeVersion)
    VALUES (OLD.ApplicantIdentifier, OLD.EducationOrganizationId, OLD.ProspectIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ApplicantProspectAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ApplicantProspectAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.Applicant_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.Applicant(ApplicantIdentifier, Id, ChangeVersion)
    VALUES (OLD.ApplicantIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.Applicant 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.Applicant_TR_DelTrkg();

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
    INSERT INTO tracked_deletes_tpdm.ApplicationEvent(ApplicantIdentifier, ApplicationEventTypeDescriptorId, ApplicationIdentifier, EducationOrganizationId, EventDate, SequenceNumber, Id, ChangeVersion)
    VALUES (OLD.ApplicantIdentifier, OLD.ApplicationEventTypeDescriptorId, OLD.ApplicationIdentifier, OLD.EducationOrganizationId, OLD.EventDate, OLD.SequenceNumber, OLD.Id, nextval('changes.ChangeVersionSequence'));
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
    INSERT INTO tracked_deletes_tpdm.Application(ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId, Id, ChangeVersion)
    VALUES (OLD.ApplicantIdentifier, OLD.ApplicationIdentifier, OLD.EducationOrganizationId, OLD.Id, nextval('changes.ChangeVersionSequence'));
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

CREATE FUNCTION tracked_deletes_tpdm.CompleterAsStaffAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.CompleterAsStaffAssociation(StaffUSI, TeacherCandidateIdentifier, Id, ChangeVersion)
    VALUES (OLD.StaffUSI, OLD.TeacherCandidateIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.CompleterAsStaffAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.CompleterAsStaffAssociation_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.EmploymentEventTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EmploymentEventTypeDescriptor(EmploymentEventTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.EmploymentEventTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EmploymentEventTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EmploymentEventTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EmploymentEventTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EmploymentEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EmploymentEvent(EducationOrganizationId, EmploymentEventTypeDescriptorId, RequisitionNumber, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EmploymentEventTypeDescriptorId, OLD.RequisitionNumber, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EmploymentEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EmploymentEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EmploymentSeparationEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EmploymentSeparationEvent(EducationOrganizationId, EmploymentSeparationDate, RequisitionNumber, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EmploymentSeparationDate, OLD.RequisitionNumber, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EmploymentSeparationEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EmploymentSeparationEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EmploymentSeparationReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EmploymentSeparationReasonDescriptor(EmploymentSeparationReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.EmploymentSeparationReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EmploymentSeparationReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EmploymentSeparationReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EmploymentSeparationReasonDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.EmploymentSeparationTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.EmploymentSeparationTypeDescriptor(EmploymentSeparationTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.EmploymentSeparationTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EmploymentSeparationTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.EmploymentSeparationTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.EmploymentSeparationTypeDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.InternalExternalHireDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.InternalExternalHireDescriptor(InternalExternalHireDescriptorId, Id, ChangeVersion)
    SELECT OLD.InternalExternalHireDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InternalExternalHireDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.InternalExternalHireDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.InternalExternalHireDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.LevelOfDegreeAwardedDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.LevelOfDegreeAwardedDescriptor(LevelOfDegreeAwardedDescriptorId, Id, ChangeVersion)
    SELECT OLD.LevelOfDegreeAwardedDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LevelOfDegreeAwardedDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.LevelOfDegreeAwardedDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.LevelOfDegreeAwardedDescriptor_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.ProspectTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ProspectTypeDescriptor(ProspectTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProspectTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProspectTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ProspectTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ProspectTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.Prospect_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.Prospect(EducationOrganizationId, ProspectIdentifier, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.ProspectIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.Prospect 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.Prospect_TR_DelTrkg();

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
    INSERT INTO tracked_deletes_tpdm.RecruitmentEvent(EventDate, EventTitle, Id, ChangeVersion)
    VALUES (OLD.EventDate, OLD.EventTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
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

CREATE FUNCTION tracked_deletes_tpdm.SchoolStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.SchoolStatusDescriptor(SchoolStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.SchoolStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SchoolStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.SchoolStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.SchoolStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffApplicantAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffApplicantAssociation(ApplicantIdentifier, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.ApplicantIdentifier, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffApplicantAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffApplicantAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffProspectAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffProspectAssociation(EducationOrganizationId, ProspectIdentifier, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.ProspectIdentifier, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffProspectAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffProspectAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffStudentGrowthMeasureCourseAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffStudentGrowthMeasureCourseAssociation(CourseCode, EducationOrganizationId, FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.CourseCode, OLD.EducationOrganizationId, OLD.FactAsOfDate, OLD.SchoolYear, OLD.StaffStudentGrowthMeasureIdentifier, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffStudentGrowthMeasureCourseAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffStudentGrowthMeasureCourseAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffStudentGrowthMeasureEducationOrganizatio_120788_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation(EducationOrganizationId, FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.FactAsOfDate, OLD.SchoolYear, OLD.StaffStudentGrowthMeasureIdentifier, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffStudentGrowthMeasureEducationOrganizatio_120788_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffStudentGrowthMeasureSectionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffStudentGrowthMeasureSectionAssociation(FactAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StaffStudentGrowthMeasureIdentifier, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.FactAsOfDate, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.StaffStudentGrowthMeasureIdentifier, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffStudentGrowthMeasureSectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffStudentGrowthMeasureSectionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffStudentGrowthMeasure_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffStudentGrowthMeasure(FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.FactAsOfDate, OLD.SchoolYear, OLD.StaffStudentGrowthMeasureIdentifier, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffStudentGrowthMeasure 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffStudentGrowthMeasure_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffTeacherPreparationProviderAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffTeacherPreparationProviderAssociation(StaffUSI, TeacherPreparationProviderId, Id, ChangeVersion)
    VALUES (OLD.StaffUSI, OLD.TeacherPreparationProviderId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffTeacherPreparationProviderAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffTeacherPreparationProviderAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StaffTeacherPreparationProviderProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StaffTeacherPreparationProviderProgramAssociation(EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StaffTeacherPreparationProviderProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StaffTeacherPreparationProviderProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.StudentGrowthTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.StudentGrowthTypeDescriptor(StudentGrowthTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.StudentGrowthTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StudentGrowthTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.StudentGrowthTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.StudentGrowthTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.SurveyResponseTeacherCandidateTargetAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.SurveyResponseTeacherCandidateTargetAssociation(Namespace, SurveyIdentifier, SurveyResponseIdentifier, TeacherCandidateIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.TeacherCandidateIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.SurveyResponseTeacherCandidateTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.SurveyResponseTeacherCandidateTargetAssociation_TR_DelTrkg();

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

CREATE FUNCTION tracked_deletes_tpdm.SurveySectionResponseTeacherCandidateTargetAs_948dd8_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.SurveySectionResponseTeacherCandidateTargetAssociation(Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, TeacherCandidateIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.SurveySectionTitle, OLD.TeacherCandidateIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.SurveySectionResponseTeacherCandidateTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.SurveySectionResponseTeacherCandidateTargetAs_948dd8_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TPPDegreeTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TPPDegreeTypeDescriptor(TPPDegreeTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.TPPDegreeTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TPPDegreeTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TPPDegreeTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TPPDegreeTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TPPProgramPathwayDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TPPProgramPathwayDescriptor(TPPProgramPathwayDescriptorId, Id, ChangeVersion)
    SELECT OLD.TPPProgramPathwayDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TPPProgramPathwayDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TPPProgramPathwayDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TPPProgramPathwayDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateAcademicRecord_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateAcademicRecord(EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.SchoolYear, OLD.TeacherCandidateIdentifier, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateAcademicRecord 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateAcademicRecord_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateCharacteristicDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateCharacteristicDescriptor(TeacherCandidateCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT OLD.TeacherCandidateCharacteristicDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TeacherCandidateCharacteristicDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateCharacteristicDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateCharacteristicDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateCourseTranscript_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateCourseTranscript(CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.CourseAttemptResultDescriptorId, OLD.CourseCode, OLD.CourseEducationOrganizationId, OLD.EducationOrganizationId, OLD.SchoolYear, OLD.TeacherCandidateIdentifier, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateCourseTranscript 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateCourseTranscript_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateStaffAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateStaffAssociation(StaffUSI, TeacherCandidateIdentifier, Id, ChangeVersion)
    VALUES (OLD.StaffUSI, OLD.TeacherCandidateIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateStaffAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateStaffAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureCourseAss_512fab_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation(CourseCode, EducationOrganizationId, FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier, Id, ChangeVersion)
    VALUES (OLD.CourseCode, OLD.EducationOrganizationId, OLD.FactAsOfDate, OLD.SchoolYear, OLD.TeacherCandidateIdentifier, OLD.TeacherCandidateStudentGrowthMeasureIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureCourseAss_512fab_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureEducation_22b9a4_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4(EducationOrganizationId, FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.FactAsOfDate, OLD.SchoolYear, OLD.TeacherCandidateIdentifier, OLD.TeacherCandidateStudentGrowthMeasureIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureEducation_22b9a4_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureSectionAs_b8b1b0_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation(FactAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier, Id, ChangeVersion)
    VALUES (OLD.FactAsOfDate, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.TeacherCandidateIdentifier, OLD.TeacherCandidateStudentGrowthMeasureIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureSectionAs_b8b1b0_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasure_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasure(FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier, Id, ChangeVersion)
    VALUES (OLD.FactAsOfDate, OLD.SchoolYear, OLD.TeacherCandidateIdentifier, OLD.TeacherCandidateStudentGrowthMeasureIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateStudentGrowthMeasure 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasure_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateTeacherPreparationProviderAss_0dff08_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateTeacherPreparationProviderAssociation(EntryDate, TeacherCandidateIdentifier, TeacherPreparationProviderId, Id, ChangeVersion)
    VALUES (OLD.EntryDate, OLD.TeacherCandidateIdentifier, OLD.TeacherPreparationProviderId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateTeacherPreparationProviderAss_0dff08_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidateTeacherPreparationProviderPro_81475b_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation(BeginDate, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, TeacherCandidateIdentifier, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.TeacherCandidateIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidateTeacherPreparationProviderPro_81475b_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherCandidate_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherCandidate(TeacherCandidateIdentifier, Id, ChangeVersion)
    VALUES (OLD.TeacherCandidateIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherCandidate 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherCandidate_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherPreparationProgramTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherPreparationProgramTypeDescriptor(TeacherPreparationProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.TeacherPreparationProgramTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TeacherPreparationProgramTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherPreparationProgramTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherPreparationProgramTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherPreparationProviderProgram_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherPreparationProviderProgram(EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherPreparationProviderProgram 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherPreparationProviderProgram_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.TeacherPreparationProvider_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.TeacherPreparationProvider(TeacherPreparationProviderId, Id, ChangeVersion)
    SELECT OLD.TeacherPreparationProviderId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.TeacherPreparationProviderId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.TeacherPreparationProvider 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.TeacherPreparationProvider_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.University_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.University(UniversityId, Id, ChangeVersion)
    SELECT OLD.UniversityId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.UniversityId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.University 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.University_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_tpdm.ValueTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_tpdm.ValueTypeDescriptor(ValueTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ValueTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ValueTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON tpdm.ValueTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_tpdm.ValueTypeDescriptor_TR_DelTrkg();

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

