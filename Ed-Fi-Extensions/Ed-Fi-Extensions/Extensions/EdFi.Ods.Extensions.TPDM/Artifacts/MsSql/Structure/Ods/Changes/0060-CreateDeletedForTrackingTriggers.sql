CREATE TRIGGER [tpdm].[tpdm_AccreditationStatusDescriptor_TR_DeleteTracking] ON [tpdm].[AccreditationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[AccreditationStatusDescriptor](AccreditationStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.AccreditationStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AccreditationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[AccreditationStatusDescriptor] ENABLE TRIGGER [tpdm_AccreditationStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_AidTypeDescriptor_TR_DeleteTracking] ON [tpdm].[AidTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[AidTypeDescriptor](AidTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.AidTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AidTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[AidTypeDescriptor] ENABLE TRIGGER [tpdm_AidTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ApplicantProfile_TR_DeleteTracking] ON [tpdm].[ApplicantProfile] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ApplicantProfile](ApplicantProfileIdentifier, Id, ChangeVersion)
    SELECT  ApplicantProfileIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[ApplicantProfile] ENABLE TRIGGER [tpdm_ApplicantProfile_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ApplicationEventResultDescriptor_TR_DeleteTracking] ON [tpdm].[ApplicationEventResultDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ApplicationEventResultDescriptor](ApplicationEventResultDescriptorId, Id, ChangeVersion)
    SELECT  d.ApplicationEventResultDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ApplicationEventResultDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ApplicationEventResultDescriptor] ENABLE TRIGGER [tpdm_ApplicationEventResultDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ApplicationEventTypeDescriptor_TR_DeleteTracking] ON [tpdm].[ApplicationEventTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ApplicationEventTypeDescriptor](ApplicationEventTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.ApplicationEventTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ApplicationEventTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ApplicationEventTypeDescriptor] ENABLE TRIGGER [tpdm_ApplicationEventTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ApplicationEvent_TR_DeleteTracking] ON [tpdm].[ApplicationEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ApplicationEvent](ApplicantProfileIdentifier, ApplicationEventTypeDescriptorId, ApplicationIdentifier, EducationOrganizationId, EventDate, SequenceNumber, Id, ChangeVersion)
    SELECT  ApplicantProfileIdentifier, ApplicationEventTypeDescriptorId, ApplicationIdentifier, EducationOrganizationId, EventDate, SequenceNumber, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[ApplicationEvent] ENABLE TRIGGER [tpdm_ApplicationEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ApplicationSourceDescriptor_TR_DeleteTracking] ON [tpdm].[ApplicationSourceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ApplicationSourceDescriptor](ApplicationSourceDescriptorId, Id, ChangeVersion)
    SELECT  d.ApplicationSourceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ApplicationSourceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ApplicationSourceDescriptor] ENABLE TRIGGER [tpdm_ApplicationSourceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ApplicationStatusDescriptor_TR_DeleteTracking] ON [tpdm].[ApplicationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ApplicationStatusDescriptor](ApplicationStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.ApplicationStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ApplicationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ApplicationStatusDescriptor] ENABLE TRIGGER [tpdm_ApplicationStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_Application_TR_DeleteTracking] ON [tpdm].[Application] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[Application](ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, Id, ChangeVersion)
    SELECT  ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[Application] ENABLE TRIGGER [tpdm_Application_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_BackgroundCheckStatusDescriptor_TR_DeleteTracking] ON [tpdm].[BackgroundCheckStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[BackgroundCheckStatusDescriptor](BackgroundCheckStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.BackgroundCheckStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.BackgroundCheckStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[BackgroundCheckStatusDescriptor] ENABLE TRIGGER [tpdm_BackgroundCheckStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_BackgroundCheckTypeDescriptor_TR_DeleteTracking] ON [tpdm].[BackgroundCheckTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[BackgroundCheckTypeDescriptor](BackgroundCheckTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.BackgroundCheckTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.BackgroundCheckTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[BackgroundCheckTypeDescriptor] ENABLE TRIGGER [tpdm_BackgroundCheckTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CandidateCharacteristicDescriptor_TR_DeleteTracking] ON [tpdm].[CandidateCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CandidateCharacteristicDescriptor](CandidateCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT  d.CandidateCharacteristicDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CandidateCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CandidateCharacteristicDescriptor] ENABLE TRIGGER [tpdm_CandidateCharacteristicDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CandidateEducatorPreparationProgramAssociation_TR_DeleteTracking] ON [tpdm].[CandidateEducatorPreparationProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CandidateEducatorPreparationProgramAssociation](BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT  BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ENABLE TRIGGER [tpdm_CandidateEducatorPreparationProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CandidateRelationshipToStaffAssociation_TR_DeleteTracking] ON [tpdm].[CandidateRelationshipToStaffAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CandidateRelationshipToStaffAssociation](CandidateIdentifier, StaffUSI, Id, ChangeVersion)
    SELECT  CandidateIdentifier, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] ENABLE TRIGGER [tpdm_CandidateRelationshipToStaffAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_Candidate_TR_DeleteTracking] ON [tpdm].[Candidate] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[Candidate](CandidateIdentifier, Id, ChangeVersion)
    SELECT  CandidateIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[Candidate] ENABLE TRIGGER [tpdm_Candidate_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationExamResult_TR_DeleteTracking] ON [tpdm].[CertificationExamResult] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationExamResult](CertificationExamDate, CertificationExamIdentifier, Namespace, PersonId, SourceSystemDescriptorId, Id, ChangeVersion)
    SELECT  CertificationExamDate, CertificationExamIdentifier, Namespace, PersonId, SourceSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[CertificationExamResult] ENABLE TRIGGER [tpdm_CertificationExamResult_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationExamStatusDescriptor_TR_DeleteTracking] ON [tpdm].[CertificationExamStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationExamStatusDescriptor](CertificationExamStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.CertificationExamStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CertificationExamStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CertificationExamStatusDescriptor] ENABLE TRIGGER [tpdm_CertificationExamStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationExamTypeDescriptor_TR_DeleteTracking] ON [tpdm].[CertificationExamTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationExamTypeDescriptor](CertificationExamTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CertificationExamTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CertificationExamTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CertificationExamTypeDescriptor] ENABLE TRIGGER [tpdm_CertificationExamTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationExam_TR_DeleteTracking] ON [tpdm].[CertificationExam] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationExam](CertificationExamIdentifier, Namespace, Id, ChangeVersion)
    SELECT  CertificationExamIdentifier, Namespace, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[CertificationExam] ENABLE TRIGGER [tpdm_CertificationExam_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationFieldDescriptor_TR_DeleteTracking] ON [tpdm].[CertificationFieldDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationFieldDescriptor](CertificationFieldDescriptorId, Id, ChangeVersion)
    SELECT  d.CertificationFieldDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CertificationFieldDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CertificationFieldDescriptor] ENABLE TRIGGER [tpdm_CertificationFieldDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationLevelDescriptor_TR_DeleteTracking] ON [tpdm].[CertificationLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationLevelDescriptor](CertificationLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.CertificationLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CertificationLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CertificationLevelDescriptor] ENABLE TRIGGER [tpdm_CertificationLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationRouteDescriptor_TR_DeleteTracking] ON [tpdm].[CertificationRouteDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationRouteDescriptor](CertificationRouteDescriptorId, Id, ChangeVersion)
    SELECT  d.CertificationRouteDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CertificationRouteDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CertificationRouteDescriptor] ENABLE TRIGGER [tpdm_CertificationRouteDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CertificationStandardDescriptor_TR_DeleteTracking] ON [tpdm].[CertificationStandardDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CertificationStandardDescriptor](CertificationStandardDescriptorId, Id, ChangeVersion)
    SELECT  d.CertificationStandardDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CertificationStandardDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CertificationStandardDescriptor] ENABLE TRIGGER [tpdm_CertificationStandardDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_Certification_TR_DeleteTracking] ON [tpdm].[Certification] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[Certification](CertificationIdentifier, Namespace, Id, ChangeVersion)
    SELECT  CertificationIdentifier, Namespace, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[Certification] ENABLE TRIGGER [tpdm_Certification_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CoteachingStyleObservedDescriptor_TR_DeleteTracking] ON [tpdm].[CoteachingStyleObservedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CoteachingStyleObservedDescriptor](CoteachingStyleObservedDescriptorId, Id, ChangeVersion)
    SELECT  d.CoteachingStyleObservedDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CoteachingStyleObservedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CoteachingStyleObservedDescriptor] ENABLE TRIGGER [tpdm_CoteachingStyleObservedDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CredentialEventTypeDescriptor_TR_DeleteTracking] ON [tpdm].[CredentialEventTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CredentialEventTypeDescriptor](CredentialEventTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CredentialEventTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CredentialEventTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CredentialEventTypeDescriptor] ENABLE TRIGGER [tpdm_CredentialEventTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CredentialEvent_TR_DeleteTracking] ON [tpdm].[CredentialEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CredentialEvent](CredentialEventDate, CredentialEventTypeDescriptorId, CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, Id, ChangeVersion)
    SELECT  CredentialEventDate, CredentialEventTypeDescriptorId, CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[CredentialEvent] ENABLE TRIGGER [tpdm_CredentialEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_CredentialStatusDescriptor_TR_DeleteTracking] ON [tpdm].[CredentialStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[CredentialStatusDescriptor](CredentialStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.CredentialStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CredentialStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CredentialStatusDescriptor] ENABLE TRIGGER [tpdm_CredentialStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_DegreeDescriptor_TR_DeleteTracking] ON [tpdm].[DegreeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[DegreeDescriptor](DegreeDescriptorId, Id, ChangeVersion)
    SELECT  d.DegreeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DegreeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[DegreeDescriptor] ENABLE TRIGGER [tpdm_DegreeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EPPDegreeTypeDescriptor_TR_DeleteTracking] ON [tpdm].[EPPDegreeTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EPPDegreeTypeDescriptor](EPPDegreeTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.EPPDegreeTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EPPDegreeTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EPPDegreeTypeDescriptor] ENABLE TRIGGER [tpdm_EPPDegreeTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EPPProgramPathwayDescriptor_TR_DeleteTracking] ON [tpdm].[EPPProgramPathwayDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EPPProgramPathwayDescriptor](EPPProgramPathwayDescriptorId, Id, ChangeVersion)
    SELECT  d.EPPProgramPathwayDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EPPProgramPathwayDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EPPProgramPathwayDescriptor] ENABLE TRIGGER [tpdm_EPPProgramPathwayDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EducatorPreparationProgramTypeDescriptor_TR_DeleteTracking] ON [tpdm].[EducatorPreparationProgramTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EducatorPreparationProgramTypeDescriptor](EducatorPreparationProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.EducatorPreparationProgramTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducatorPreparationProgramTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EducatorPreparationProgramTypeDescriptor] ENABLE TRIGGER [tpdm_EducatorPreparationProgramTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EducatorPreparationProgram_TR_DeleteTracking] ON [tpdm].[EducatorPreparationProgram] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EducatorPreparationProgram](EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[EducatorPreparationProgram] ENABLE TRIGGER [tpdm_EducatorPreparationProgram_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EducatorRoleDescriptor_TR_DeleteTracking] ON [tpdm].[EducatorRoleDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EducatorRoleDescriptor](EducatorRoleDescriptorId, Id, ChangeVersion)
    SELECT  d.EducatorRoleDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducatorRoleDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EducatorRoleDescriptor] ENABLE TRIGGER [tpdm_EducatorRoleDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EnglishLanguageExamDescriptor_TR_DeleteTracking] ON [tpdm].[EnglishLanguageExamDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EnglishLanguageExamDescriptor](EnglishLanguageExamDescriptorId, Id, ChangeVersion)
    SELECT  d.EnglishLanguageExamDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EnglishLanguageExamDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EnglishLanguageExamDescriptor] ENABLE TRIGGER [tpdm_EnglishLanguageExamDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationElementRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationElementRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationElementRatingLevelDescriptor](EvaluationElementRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.EvaluationElementRatingLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationElementRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationElementRatingLevelDescriptor] ENABLE TRIGGER [tpdm_EvaluationElementRatingLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationElementRating_TR_DeleteTracking] ON [tpdm].[EvaluationElementRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationElementRating](EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[EvaluationElementRating] ENABLE TRIGGER [tpdm_EvaluationElementRating_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationElement_TR_DeleteTracking] ON [tpdm].[EvaluationElement] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationElement](EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[EvaluationElement] ENABLE TRIGGER [tpdm_EvaluationElement_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationObjectiveRating_TR_DeleteTracking] ON [tpdm].[EvaluationObjectiveRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationObjectiveRating](EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRating] ENABLE TRIGGER [tpdm_EvaluationObjectiveRating_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationObjective_TR_DeleteTracking] ON [tpdm].[EvaluationObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationObjective](EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[EvaluationObjective] ENABLE TRIGGER [tpdm_EvaluationObjective_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationPeriodDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationPeriodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationPeriodDescriptor](EvaluationPeriodDescriptorId, Id, ChangeVersion)
    SELECT  d.EvaluationPeriodDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationPeriodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationPeriodDescriptor] ENABLE TRIGGER [tpdm_EvaluationPeriodDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationRatingLevelDescriptor](EvaluationRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.EvaluationRatingLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationRatingLevelDescriptor] ENABLE TRIGGER [tpdm_EvaluationRatingLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationRating_TR_DeleteTracking] ON [tpdm].[EvaluationRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationRating](EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[EvaluationRating] ENABLE TRIGGER [tpdm_EvaluationRating_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_EvaluationTypeDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[EvaluationTypeDescriptor](EvaluationTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.EvaluationTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationTypeDescriptor] ENABLE TRIGGER [tpdm_EvaluationTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_Evaluation_TR_DeleteTracking] ON [tpdm].[Evaluation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[Evaluation](EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[Evaluation] ENABLE TRIGGER [tpdm_Evaluation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_FederalLocaleCodeDescriptor_TR_DeleteTracking] ON [tpdm].[FederalLocaleCodeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[FederalLocaleCodeDescriptor](FederalLocaleCodeDescriptorId, Id, ChangeVersion)
    SELECT  d.FederalLocaleCodeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.FederalLocaleCodeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[FederalLocaleCodeDescriptor] ENABLE TRIGGER [tpdm_FederalLocaleCodeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_FieldworkExperienceSectionAssociation_TR_DeleteTracking] ON [tpdm].[FieldworkExperienceSectionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[FieldworkExperienceSectionAssociation](BeginDate, FieldworkIdentifier, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, FieldworkIdentifier, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[FieldworkExperienceSectionAssociation] ENABLE TRIGGER [tpdm_FieldworkExperienceSectionAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_FieldworkExperience_TR_DeleteTracking] ON [tpdm].[FieldworkExperience] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[FieldworkExperience](BeginDate, FieldworkIdentifier, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, FieldworkIdentifier, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[FieldworkExperience] ENABLE TRIGGER [tpdm_FieldworkExperience_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_FieldworkTypeDescriptor_TR_DeleteTracking] ON [tpdm].[FieldworkTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[FieldworkTypeDescriptor](FieldworkTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.FieldworkTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.FieldworkTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[FieldworkTypeDescriptor] ENABLE TRIGGER [tpdm_FieldworkTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_FundingSourceDescriptor_TR_DeleteTracking] ON [tpdm].[FundingSourceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[FundingSourceDescriptor](FundingSourceDescriptorId, Id, ChangeVersion)
    SELECT  d.FundingSourceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.FundingSourceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[FundingSourceDescriptor] ENABLE TRIGGER [tpdm_FundingSourceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_GenderDescriptor_TR_DeleteTracking] ON [tpdm].[GenderDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[GenderDescriptor](GenderDescriptorId, Id, ChangeVersion)
    SELECT  d.GenderDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GenderDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[GenderDescriptor] ENABLE TRIGGER [tpdm_GenderDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_GoalTypeDescriptor_TR_DeleteTracking] ON [tpdm].[GoalTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[GoalTypeDescriptor](GoalTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.GoalTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GoalTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[GoalTypeDescriptor] ENABLE TRIGGER [tpdm_GoalTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_Goal_TR_DeleteTracking] ON [tpdm].[Goal] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[Goal](AssignmentDate, GoalTitle, PersonId, SourceSystemDescriptorId, Id, ChangeVersion)
    SELECT  AssignmentDate, GoalTitle, PersonId, SourceSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[Goal] ENABLE TRIGGER [tpdm_Goal_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_HireStatusDescriptor_TR_DeleteTracking] ON [tpdm].[HireStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[HireStatusDescriptor](HireStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.HireStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.HireStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[HireStatusDescriptor] ENABLE TRIGGER [tpdm_HireStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_HiringSourceDescriptor_TR_DeleteTracking] ON [tpdm].[HiringSourceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[HiringSourceDescriptor](HiringSourceDescriptorId, Id, ChangeVersion)
    SELECT  d.HiringSourceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.HiringSourceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[HiringSourceDescriptor] ENABLE TRIGGER [tpdm_HiringSourceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_InstructionalSettingDescriptor_TR_DeleteTracking] ON [tpdm].[InstructionalSettingDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[InstructionalSettingDescriptor](InstructionalSettingDescriptorId, Id, ChangeVersion)
    SELECT  d.InstructionalSettingDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InstructionalSettingDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[InstructionalSettingDescriptor] ENABLE TRIGGER [tpdm_InstructionalSettingDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_LengthOfContractDescriptor_TR_DeleteTracking] ON [tpdm].[LengthOfContractDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[LengthOfContractDescriptor](LengthOfContractDescriptorId, Id, ChangeVersion)
    SELECT  d.LengthOfContractDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LengthOfContractDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[LengthOfContractDescriptor] ENABLE TRIGGER [tpdm_LengthOfContractDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ObjectiveRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[ObjectiveRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ObjectiveRatingLevelDescriptor](ObjectiveRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.ObjectiveRatingLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ObjectiveRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ObjectiveRatingLevelDescriptor] ENABLE TRIGGER [tpdm_ObjectiveRatingLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_OpenStaffPositionEventStatusDescriptor_TR_DeleteTracking] ON [tpdm].[OpenStaffPositionEventStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[OpenStaffPositionEventStatusDescriptor](OpenStaffPositionEventStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.OpenStaffPositionEventStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OpenStaffPositionEventStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[OpenStaffPositionEventStatusDescriptor] ENABLE TRIGGER [tpdm_OpenStaffPositionEventStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_OpenStaffPositionEventTypeDescriptor_TR_DeleteTracking] ON [tpdm].[OpenStaffPositionEventTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[OpenStaffPositionEventTypeDescriptor](OpenStaffPositionEventTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.OpenStaffPositionEventTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OpenStaffPositionEventTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[OpenStaffPositionEventTypeDescriptor] ENABLE TRIGGER [tpdm_OpenStaffPositionEventTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_OpenStaffPositionEvent_TR_DeleteTracking] ON [tpdm].[OpenStaffPositionEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[OpenStaffPositionEvent](EducationOrganizationId, EventDate, OpenStaffPositionEventTypeDescriptorId, RequisitionNumber, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EventDate, OpenStaffPositionEventTypeDescriptorId, RequisitionNumber, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[OpenStaffPositionEvent] ENABLE TRIGGER [tpdm_OpenStaffPositionEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_OpenStaffPositionReasonDescriptor_TR_DeleteTracking] ON [tpdm].[OpenStaffPositionReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[OpenStaffPositionReasonDescriptor](OpenStaffPositionReasonDescriptorId, Id, ChangeVersion)
    SELECT  d.OpenStaffPositionReasonDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OpenStaffPositionReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[OpenStaffPositionReasonDescriptor] ENABLE TRIGGER [tpdm_OpenStaffPositionReasonDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluationRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[PerformanceEvaluationRatingLevelDescriptor](PerformanceEvaluationRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.PerformanceEvaluationRatingLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceEvaluationRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingLevelDescriptor] ENABLE TRIGGER [tpdm_PerformanceEvaluationRatingLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationRating_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluationRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[PerformanceEvaluationRating](EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRating] ENABLE TRIGGER [tpdm_PerformanceEvaluationRating_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationTypeDescriptor_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluationTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[PerformanceEvaluationTypeDescriptor](PerformanceEvaluationTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.PerformanceEvaluationTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceEvaluationTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluationTypeDescriptor] ENABLE TRIGGER [tpdm_PerformanceEvaluationTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluation_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[PerformanceEvaluation](EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] ENABLE TRIGGER [tpdm_PerformanceEvaluation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_PreviousCareerDescriptor_TR_DeleteTracking] ON [tpdm].[PreviousCareerDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[PreviousCareerDescriptor](PreviousCareerDescriptorId, Id, ChangeVersion)
    SELECT  d.PreviousCareerDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PreviousCareerDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[PreviousCareerDescriptor] ENABLE TRIGGER [tpdm_PreviousCareerDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ProfessionalDevelopmentEventAttendance_TR_DeleteTracking] ON [tpdm].[ProfessionalDevelopmentEventAttendance] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ProfessionalDevelopmentEventAttendance](AttendanceDate, Namespace, PersonId, ProfessionalDevelopmentTitle, SourceSystemDescriptorId, Id, ChangeVersion)
    SELECT  AttendanceDate, Namespace, PersonId, ProfessionalDevelopmentTitle, SourceSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] ENABLE TRIGGER [tpdm_ProfessionalDevelopmentEventAttendance_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ProfessionalDevelopmentEvent_TR_DeleteTracking] ON [tpdm].[ProfessionalDevelopmentEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ProfessionalDevelopmentEvent](Namespace, ProfessionalDevelopmentTitle, Id, ChangeVersion)
    SELECT  Namespace, ProfessionalDevelopmentTitle, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentEvent] ENABLE TRIGGER [tpdm_ProfessionalDevelopmentEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ProfessionalDevelopmentOfferedByDescriptor_TR_DeleteTracking] ON [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ProfessionalDevelopmentOfferedByDescriptor](ProfessionalDevelopmentOfferedByDescriptorId, Id, ChangeVersion)
    SELECT  d.ProfessionalDevelopmentOfferedByDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProfessionalDevelopmentOfferedByDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] ENABLE TRIGGER [tpdm_ProfessionalDevelopmentOfferedByDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_ProgramGatewayDescriptor_TR_DeleteTracking] ON [tpdm].[ProgramGatewayDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[ProgramGatewayDescriptor](ProgramGatewayDescriptorId, Id, ChangeVersion)
    SELECT  d.ProgramGatewayDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramGatewayDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ProgramGatewayDescriptor] ENABLE TRIGGER [tpdm_ProgramGatewayDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasureDatatypeDescriptor_TR_DeleteTracking] ON [tpdm].[QuantitativeMeasureDatatypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[QuantitativeMeasureDatatypeDescriptor](QuantitativeMeasureDatatypeDescriptorId, Id, ChangeVersion)
    SELECT  d.QuantitativeMeasureDatatypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.QuantitativeMeasureDatatypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[QuantitativeMeasureDatatypeDescriptor] ENABLE TRIGGER [tpdm_QuantitativeMeasureDatatypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasureScore_TR_DeleteTracking] ON [tpdm].[QuantitativeMeasureScore] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[QuantitativeMeasureScore](EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, QuantitativeMeasureIdentifier, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, QuantitativeMeasureIdentifier, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[QuantitativeMeasureScore] ENABLE TRIGGER [tpdm_QuantitativeMeasureScore_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasureTypeDescriptor_TR_DeleteTracking] ON [tpdm].[QuantitativeMeasureTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[QuantitativeMeasureTypeDescriptor](QuantitativeMeasureTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.QuantitativeMeasureTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.QuantitativeMeasureTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[QuantitativeMeasureTypeDescriptor] ENABLE TRIGGER [tpdm_QuantitativeMeasureTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_QuantitativeMeasure_TR_DeleteTracking] ON [tpdm].[QuantitativeMeasure] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[QuantitativeMeasure](EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[QuantitativeMeasure] ENABLE TRIGGER [tpdm_QuantitativeMeasure_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_RecruitmentEventAttendance_TR_DeleteTracking] ON [tpdm].[RecruitmentEventAttendance] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[RecruitmentEventAttendance](EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendance] ENABLE TRIGGER [tpdm_RecruitmentEventAttendance_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_RecruitmentEventAttendeeTypeDescriptor_TR_DeleteTracking] ON [tpdm].[RecruitmentEventAttendeeTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[RecruitmentEventAttendeeTypeDescriptor](RecruitmentEventAttendeeTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.RecruitmentEventAttendeeTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RecruitmentEventAttendeeTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendeeTypeDescriptor] ENABLE TRIGGER [tpdm_RecruitmentEventAttendeeTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_RecruitmentEventTypeDescriptor_TR_DeleteTracking] ON [tpdm].[RecruitmentEventTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[RecruitmentEventTypeDescriptor](RecruitmentEventTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.RecruitmentEventTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RecruitmentEventTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[RecruitmentEventTypeDescriptor] ENABLE TRIGGER [tpdm_RecruitmentEventTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_RecruitmentEvent_TR_DeleteTracking] ON [tpdm].[RecruitmentEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[RecruitmentEvent](EducationOrganizationId, EventDate, EventTitle, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EventDate, EventTitle, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[RecruitmentEvent] ENABLE TRIGGER [tpdm_RecruitmentEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_RubricDimension_TR_DeleteTracking] ON [tpdm].[RubricDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[RubricDimension](EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, RubricRating, SchoolYear, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, RubricRating, SchoolYear, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[RubricDimension] ENABLE TRIGGER [tpdm_RubricDimension_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_RubricRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[RubricRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[RubricRatingLevelDescriptor](RubricRatingLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.RubricRatingLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RubricRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[RubricRatingLevelDescriptor] ENABLE TRIGGER [tpdm_RubricRatingLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_SalaryTypeDescriptor_TR_DeleteTracking] ON [tpdm].[SalaryTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[SalaryTypeDescriptor](SalaryTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.SalaryTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SalaryTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[SalaryTypeDescriptor] ENABLE TRIGGER [tpdm_SalaryTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_StaffEducatorPreparationProgramAssociation_TR_DeleteTracking] ON [tpdm].[StaffEducatorPreparationProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[StaffEducatorPreparationProgramAssociation](EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI, Id, ChangeVersion)
    SELECT  EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] ENABLE TRIGGER [tpdm_StaffEducatorPreparationProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_StaffToCandidateRelationshipDescriptor_TR_DeleteTracking] ON [tpdm].[StaffToCandidateRelationshipDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[StaffToCandidateRelationshipDescriptor](StaffToCandidateRelationshipDescriptorId, Id, ChangeVersion)
    SELECT  d.StaffToCandidateRelationshipDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StaffToCandidateRelationshipDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[StaffToCandidateRelationshipDescriptor] ENABLE TRIGGER [tpdm_StaffToCandidateRelationshipDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_SurveyResponsePersonTargetAssociation_TR_DeleteTracking] ON [tpdm].[SurveyResponsePersonTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[SurveyResponsePersonTargetAssociation](Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    SELECT  Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ENABLE TRIGGER [tpdm_SurveyResponsePersonTargetAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_SurveySectionAggregateResponse_TR_DeleteTracking] ON [tpdm].[SurveySectionAggregateResponse] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[SurveySectionAggregateResponse](EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, Namespace, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, SurveyIdentifier, SurveySectionTitle, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, Namespace, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, SurveyIdentifier, SurveySectionTitle, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[SurveySectionAggregateResponse] ENABLE TRIGGER [tpdm_SurveySectionAggregateResponse_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_SurveySectionResponsePersonTargetAssociation_TR_DeleteTracking] ON [tpdm].[SurveySectionResponsePersonTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[SurveySectionResponsePersonTargetAssociation](Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    SELECT  Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ENABLE TRIGGER [tpdm_SurveySectionResponsePersonTargetAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [tpdm].[tpdm_WithdrawReasonDescriptor_TR_DeleteTracking] ON [tpdm].[WithdrawReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[WithdrawReasonDescriptor](WithdrawReasonDescriptorId, Id, ChangeVersion)
    SELECT  d.WithdrawReasonDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.WithdrawReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[WithdrawReasonDescriptor] ENABLE TRIGGER [tpdm_WithdrawReasonDescriptor_TR_DeleteTracking]
GO


