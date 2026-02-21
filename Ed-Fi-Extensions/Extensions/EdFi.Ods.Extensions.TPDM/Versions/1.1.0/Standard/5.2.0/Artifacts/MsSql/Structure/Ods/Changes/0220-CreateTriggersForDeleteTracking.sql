-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [tpdm].[tpdm_AccreditationStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_AccreditationStatusDescriptor_TR_DeleteTracking] ON [tpdm].[AccreditationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AccreditationStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.AccreditationStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AccreditationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[AccreditationStatusDescriptor] ENABLE TRIGGER [tpdm_AccreditationStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_AidTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_AidTypeDescriptor_TR_DeleteTracking] ON [tpdm].[AidTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AidTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.AidTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AidTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[AidTypeDescriptor] ENABLE TRIGGER [tpdm_AidTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_Candidate_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_Candidate_TR_DeleteTracking] ON [tpdm].[Candidate] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[Candidate](OldCandidateIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.CandidateIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[Candidate] ENABLE TRIGGER [tpdm_Candidate_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_CandidateEducatorPreparationProgramAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_CandidateEducatorPreparationProgramAssociation_TR_DeleteTracking] ON [tpdm].[CandidateEducatorPreparationProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[CandidateEducatorPreparationProgramAssociation](OldBeginDate, OldCandidateIdentifier, OldEducationOrganizationId, OldProgramName, OldProgramTypeDescriptorId, OldProgramTypeDescriptorNamespace, OldProgramTypeDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.CandidateIdentifier, d.EducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, j0.Namespace, j0.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ProgramTypeDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ENABLE TRIGGER [tpdm_CandidateEducatorPreparationProgramAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_CertificationRouteDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_CertificationRouteDescriptor_TR_DeleteTracking] ON [tpdm].[CertificationRouteDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CertificationRouteDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.CertificationRouteDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CertificationRouteDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CertificationRouteDescriptor] ENABLE TRIGGER [tpdm_CertificationRouteDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_CoteachingStyleObservedDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_CoteachingStyleObservedDescriptor_TR_DeleteTracking] ON [tpdm].[CoteachingStyleObservedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CoteachingStyleObservedDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.CoteachingStyleObservedDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CoteachingStyleObservedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CoteachingStyleObservedDescriptor] ENABLE TRIGGER [tpdm_CoteachingStyleObservedDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_CredentialStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_CredentialStatusDescriptor_TR_DeleteTracking] ON [tpdm].[CredentialStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CredentialStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.CredentialStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CredentialStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[CredentialStatusDescriptor] ENABLE TRIGGER [tpdm_CredentialStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EducatorPreparationProgram_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EducatorPreparationProgram_TR_DeleteTracking] ON [tpdm].[EducatorPreparationProgram] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[EducatorPreparationProgram](OldEducationOrganizationId, OldProgramName, OldProgramTypeDescriptorId, OldProgramTypeDescriptorNamespace, OldProgramTypeDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, j0.Namespace, j0.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ProgramTypeDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [tpdm].[EducatorPreparationProgram] ENABLE TRIGGER [tpdm_EducatorPreparationProgram_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EducatorRoleDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EducatorRoleDescriptor_TR_DeleteTracking] ON [tpdm].[EducatorRoleDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EducatorRoleDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EducatorRoleDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducatorRoleDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EducatorRoleDescriptor] ENABLE TRIGGER [tpdm_EducatorRoleDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EnglishLanguageExamDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EnglishLanguageExamDescriptor_TR_DeleteTracking] ON [tpdm].[EnglishLanguageExamDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EnglishLanguageExamDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EnglishLanguageExamDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EnglishLanguageExamDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EnglishLanguageExamDescriptor] ENABLE TRIGGER [tpdm_EnglishLanguageExamDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EPPProgramPathwayDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EPPProgramPathwayDescriptor_TR_DeleteTracking] ON [tpdm].[EPPProgramPathwayDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EPPProgramPathwayDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EPPProgramPathwayDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EPPProgramPathwayDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EPPProgramPathwayDescriptor] ENABLE TRIGGER [tpdm_EPPProgramPathwayDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_Evaluation_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_Evaluation_TR_DeleteTracking] ON [tpdm].[Evaluation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[Evaluation](OldEducationOrganizationId, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldEvaluationTitle, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldSchoolYear, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.EvaluationTitle, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.SchoolYear, d.TermDescriptorId, j2.Namespace, j2.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.TermDescriptorId = j2.DescriptorId
END
GO

ALTER TABLE [tpdm].[Evaluation] ENABLE TRIGGER [tpdm_Evaluation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationElement_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationElement_TR_DeleteTracking] ON [tpdm].[EvaluationElement] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[EvaluationElement](OldEducationOrganizationId, OldEvaluationElementTitle, OldEvaluationObjectiveTitle, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldEvaluationTitle, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldSchoolYear, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationElementTitle, d.EvaluationObjectiveTitle, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.EvaluationTitle, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.SchoolYear, d.TermDescriptorId, j2.Namespace, j2.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.TermDescriptorId = j2.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationElement] ENABLE TRIGGER [tpdm_EvaluationElement_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationElementRating_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationElementRating_TR_DeleteTracking] ON [tpdm].[EvaluationElementRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[EvaluationElementRating](OldEducationOrganizationId, OldEvaluationDate, OldEvaluationElementTitle, OldEvaluationObjectiveTitle, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldEvaluationTitle, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldPersonId, OldSchoolYear, OldSourceSystemDescriptorId, OldSourceSystemDescriptorNamespace, OldSourceSystemDescriptorCodeValue, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationDate, d.EvaluationElementTitle, d.EvaluationObjectiveTitle, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.EvaluationTitle, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.PersonId, d.SchoolYear, d.SourceSystemDescriptorId, j2.Namespace, j2.CodeValue, d.TermDescriptorId, j3.Namespace, j3.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.SourceSystemDescriptorId = j2.DescriptorId
        INNER JOIN edfi.Descriptor j3
            ON d.TermDescriptorId = j3.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationElementRating] ENABLE TRIGGER [tpdm_EvaluationElementRating_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationElementRatingLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationElementRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationElementRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EvaluationElementRatingLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EvaluationElementRatingLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationElementRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationElementRatingLevelDescriptor] ENABLE TRIGGER [tpdm_EvaluationElementRatingLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationObjective_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationObjective_TR_DeleteTracking] ON [tpdm].[EvaluationObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[EvaluationObjective](OldEducationOrganizationId, OldEvaluationObjectiveTitle, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldEvaluationTitle, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldSchoolYear, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationObjectiveTitle, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.EvaluationTitle, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.SchoolYear, d.TermDescriptorId, j2.Namespace, j2.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.TermDescriptorId = j2.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationObjective] ENABLE TRIGGER [tpdm_EvaluationObjective_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationObjectiveRating_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationObjectiveRating_TR_DeleteTracking] ON [tpdm].[EvaluationObjectiveRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[EvaluationObjectiveRating](OldEducationOrganizationId, OldEvaluationDate, OldEvaluationObjectiveTitle, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldEvaluationTitle, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldPersonId, OldSchoolYear, OldSourceSystemDescriptorId, OldSourceSystemDescriptorNamespace, OldSourceSystemDescriptorCodeValue, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationDate, d.EvaluationObjectiveTitle, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.EvaluationTitle, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.PersonId, d.SchoolYear, d.SourceSystemDescriptorId, j2.Namespace, j2.CodeValue, d.TermDescriptorId, j3.Namespace, j3.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.SourceSystemDescriptorId = j2.DescriptorId
        INNER JOIN edfi.Descriptor j3
            ON d.TermDescriptorId = j3.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRating] ENABLE TRIGGER [tpdm_EvaluationObjectiveRating_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationPeriodDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationPeriodDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationPeriodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EvaluationPeriodDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EvaluationPeriodDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationPeriodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationPeriodDescriptor] ENABLE TRIGGER [tpdm_EvaluationPeriodDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationRating_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationRating_TR_DeleteTracking] ON [tpdm].[EvaluationRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[EvaluationRating](OldEducationOrganizationId, OldEvaluationDate, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldEvaluationTitle, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldPersonId, OldSchoolYear, OldSourceSystemDescriptorId, OldSourceSystemDescriptorNamespace, OldSourceSystemDescriptorCodeValue, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationDate, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.EvaluationTitle, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.PersonId, d.SchoolYear, d.SourceSystemDescriptorId, j2.Namespace, j2.CodeValue, d.TermDescriptorId, j3.Namespace, j3.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.SourceSystemDescriptorId = j2.DescriptorId
        INNER JOIN edfi.Descriptor j3
            ON d.TermDescriptorId = j3.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationRating] ENABLE TRIGGER [tpdm_EvaluationRating_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationRatingLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EvaluationRatingLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EvaluationRatingLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationRatingLevelDescriptor] ENABLE TRIGGER [tpdm_EvaluationRatingLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationRatingStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationRatingStatusDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationRatingStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EvaluationRatingStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EvaluationRatingStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationRatingStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationRatingStatusDescriptor] ENABLE TRIGGER [tpdm_EvaluationRatingStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_EvaluationTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_EvaluationTypeDescriptor_TR_DeleteTracking] ON [tpdm].[EvaluationTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EvaluationTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.EvaluationTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EvaluationTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[EvaluationTypeDescriptor] ENABLE TRIGGER [tpdm_EvaluationTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_FinancialAid_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_FinancialAid_TR_DeleteTracking] ON [tpdm].[FinancialAid] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[FinancialAid](OldAidTypeDescriptorId, OldAidTypeDescriptorNamespace, OldAidTypeDescriptorCodeValue, OldBeginDate, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AidTypeDescriptorId, j0.Namespace, j0.CodeValue, d.BeginDate, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.AidTypeDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [tpdm].[FinancialAid] ENABLE TRIGGER [tpdm_FinancialAid_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_GenderDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_GenderDescriptor_TR_DeleteTracking] ON [tpdm].[GenderDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GenderDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.GenderDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GenderDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[GenderDescriptor] ENABLE TRIGGER [tpdm_GenderDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_ObjectiveRatingLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_ObjectiveRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[ObjectiveRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ObjectiveRatingLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.ObjectiveRatingLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ObjectiveRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[ObjectiveRatingLevelDescriptor] ENABLE TRIGGER [tpdm_ObjectiveRatingLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_PerformanceEvaluation_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluation_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[PerformanceEvaluation](OldEducationOrganizationId, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldSchoolYear, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.SchoolYear, d.TermDescriptorId, j2.Namespace, j2.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.TermDescriptorId = j2.DescriptorId
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] ENABLE TRIGGER [tpdm_PerformanceEvaluation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_PerformanceEvaluationRating_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationRating_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluationRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[PerformanceEvaluationRating](OldEducationOrganizationId, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldPersonId, OldSchoolYear, OldSourceSystemDescriptorId, OldSourceSystemDescriptorNamespace, OldSourceSystemDescriptorCodeValue, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.PersonId, d.SchoolYear, d.SourceSystemDescriptorId, j2.Namespace, j2.CodeValue, d.TermDescriptorId, j3.Namespace, j3.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.SourceSystemDescriptorId = j2.DescriptorId
        INNER JOIN edfi.Descriptor j3
            ON d.TermDescriptorId = j3.DescriptorId
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRating] ENABLE TRIGGER [tpdm_PerformanceEvaluationRating_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_PerformanceEvaluationRatingLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluationRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PerformanceEvaluationRatingLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.PerformanceEvaluationRatingLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceEvaluationRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingLevelDescriptor] ENABLE TRIGGER [tpdm_PerformanceEvaluationRatingLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_PerformanceEvaluationTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_PerformanceEvaluationTypeDescriptor_TR_DeleteTracking] ON [tpdm].[PerformanceEvaluationTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PerformanceEvaluationTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.PerformanceEvaluationTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceEvaluationTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[PerformanceEvaluationTypeDescriptor] ENABLE TRIGGER [tpdm_PerformanceEvaluationTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_RubricDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_RubricDimension_TR_DeleteTracking] ON [tpdm].[RubricDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[RubricDimension](OldEducationOrganizationId, OldEvaluationElementTitle, OldEvaluationObjectiveTitle, OldEvaluationPeriodDescriptorId, OldEvaluationPeriodDescriptorNamespace, OldEvaluationPeriodDescriptorCodeValue, OldEvaluationTitle, OldPerformanceEvaluationTitle, OldPerformanceEvaluationTypeDescriptorId, OldPerformanceEvaluationTypeDescriptorNamespace, OldPerformanceEvaluationTypeDescriptorCodeValue, OldRubricRating, OldSchoolYear, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EvaluationElementTitle, d.EvaluationObjectiveTitle, d.EvaluationPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.EvaluationTitle, d.PerformanceEvaluationTitle, d.PerformanceEvaluationTypeDescriptorId, j1.Namespace, j1.CodeValue, d.RubricRating, d.SchoolYear, d.TermDescriptorId, j2.Namespace, j2.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EvaluationPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.PerformanceEvaluationTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Descriptor j2
            ON d.TermDescriptorId = j2.DescriptorId
END
GO

ALTER TABLE [tpdm].[RubricDimension] ENABLE TRIGGER [tpdm_RubricDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_RubricRatingLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_RubricRatingLevelDescriptor_TR_DeleteTracking] ON [tpdm].[RubricRatingLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.RubricRatingLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'tpdm.RubricRatingLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RubricRatingLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [tpdm].[RubricRatingLevelDescriptor] ENABLE TRIGGER [tpdm_RubricRatingLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_SurveyResponsePersonTargetAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_SurveyResponsePersonTargetAssociation_TR_DeleteTracking] ON [tpdm].[SurveyResponsePersonTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[SurveyResponsePersonTargetAssociation](OldNamespace, OldPersonId, OldSourceSystemDescriptorId, OldSourceSystemDescriptorNamespace, OldSourceSystemDescriptorCodeValue, OldSurveyIdentifier, OldSurveyResponseIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.PersonId, d.SourceSystemDescriptorId, j0.Namespace, j0.CodeValue, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.SourceSystemDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ENABLE TRIGGER [tpdm_SurveyResponsePersonTargetAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [tpdm].[tpdm_SurveySectionResponsePersonTargetAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [tpdm].[tpdm_SurveySectionResponsePersonTargetAssociation_TR_DeleteTracking] ON [tpdm].[SurveySectionResponsePersonTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_tpdm].[SurveySectionResponsePersonTargetAssociation](OldNamespace, OldPersonId, OldSourceSystemDescriptorId, OldSourceSystemDescriptorNamespace, OldSourceSystemDescriptorCodeValue, OldSurveyIdentifier, OldSurveyResponseIdentifier, OldSurveySectionTitle, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.PersonId, d.SourceSystemDescriptorId, j0.Namespace, j0.CodeValue, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.SurveySectionTitle, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.SourceSystemDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ENABLE TRIGGER [tpdm_SurveySectionResponsePersonTargetAssociation_TR_DeleteTracking]
GO


