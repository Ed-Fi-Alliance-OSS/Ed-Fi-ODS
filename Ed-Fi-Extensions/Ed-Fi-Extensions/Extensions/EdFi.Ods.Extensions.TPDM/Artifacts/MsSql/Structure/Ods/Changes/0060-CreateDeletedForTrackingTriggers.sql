-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

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


CREATE TRIGGER [tpdm].[tpdm_FinancialAid_TR_DeleteTracking] ON [tpdm].[FinancialAid] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_tpdm].[FinancialAid](AidTypeDescriptorId, BeginDate, StudentUSI, Id, ChangeVersion)
    SELECT  AidTypeDescriptorId, BeginDate, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [tpdm].[FinancialAid] ENABLE TRIGGER [tpdm_FinancialAid_TR_DeleteTracking]
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


