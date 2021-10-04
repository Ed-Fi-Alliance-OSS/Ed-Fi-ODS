-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE [tracked_deletes_tpdm].[AccreditationStatusDescriptor]
(
       AccreditationStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AccreditationStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[AidTypeDescriptor]
(
       AidTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AidTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[Candidate]
(
       CandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Candidate PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CandidateEducatorPreparationProgramAssociation]
(
       BeginDate [DATE] NOT NULL,
       CandidateIdentifier [NVARCHAR](32) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CandidateEducatorPreparationProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationRouteDescriptor]
(
       CertificationRouteDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationRouteDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CoteachingStyleObservedDescriptor]
(
       CoteachingStyleObservedDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CoteachingStyleObservedDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CredentialStatusDescriptor]
(
       CredentialStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CredentialStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EPPProgramPathwayDescriptor]
(
       EPPProgramPathwayDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EPPProgramPathwayDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EducatorPreparationProgram]
(
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EducatorPreparationProgram PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EducatorRoleDescriptor]
(
       EducatorRoleDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EducatorRoleDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EnglishLanguageExamDescriptor]
(
       EnglishLanguageExamDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EnglishLanguageExamDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[Evaluation]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Evaluation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationElement]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationElement PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationElementRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATETIME2](7) NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationElementRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationElementRatingLevelDescriptor]
(
       EvaluationElementRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationElementRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationObjective]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationObjective PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationObjectiveRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATETIME2](7) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationObjectiveRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationPeriodDescriptor]
(
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationPeriodDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATETIME2](7) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationRatingLevelDescriptor]
(
       EvaluationRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationRatingStatusDescriptor]
(
       EvaluationRatingStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationRatingStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationTypeDescriptor]
(
       EvaluationTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[FinancialAid]
(
       AidTypeDescriptorId [INT] NOT NULL,
       BeginDate [DATE] NOT NULL,
       StudentUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_FinancialAid PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[GenderDescriptor]
(
       GenderDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_GenderDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ObjectiveRatingLevelDescriptor]
(
       ObjectiveRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ObjectiveRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluation]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluationRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluationRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluationRatingLevelDescriptor]
(
       PerformanceEvaluationRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluationRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluationTypeDescriptor]
(
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluationTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RubricDimension]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       RubricRating [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RubricDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RubricRatingLevelDescriptor]
(
       RubricRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RubricRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[SurveyResponsePersonTargetAssociation]
(
       Namespace [NVARCHAR](255) NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       SurveyIdentifier [NVARCHAR](60) NOT NULL,
       SurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SurveyResponsePersonTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[SurveySectionResponsePersonTargetAssociation]
(
       Namespace [NVARCHAR](255) NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       SurveyIdentifier [NVARCHAR](60) NOT NULL,
       SurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       SurveySectionTitle [NVARCHAR](255) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SurveySectionResponsePersonTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
