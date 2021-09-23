-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE tracked_deletes_tpdm.AccreditationStatusDescriptor
(
       AccreditationStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AccreditationStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AidTypeDescriptor
(
       AidTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AidTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Candidate
(
       CandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Candidate_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CandidateEducatorPreparationProgramAssociation
(
       BeginDate DATE NOT NULL,
       CandidateIdentifier VARCHAR(32) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(255) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CandidateEducatorPreparationProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationRouteDescriptor
(
       CertificationRouteDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationRouteDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CoteachingStyleObservedDescriptor
(
       CoteachingStyleObservedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CoteachingStyleObservedDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CredentialStatusDescriptor
(
       CredentialStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CredentialStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EPPProgramPathwayDescriptor
(
       EPPProgramPathwayDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EPPProgramPathwayDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EducatorPreparationProgram
(
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(255) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducatorPreparationProgram_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EducatorRoleDescriptor
(
       EducatorRoleDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducatorRoleDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EnglishLanguageExamDescriptor
(
       EnglishLanguageExamDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EnglishLanguageExamDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Evaluation
(
       EducationOrganizationId INT NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Evaluation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationElement
(
       EducationOrganizationId INT NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationElement_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationElementRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationElementRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationElementRatingLevelDescriptor
(
       EvaluationElementRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationElementRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationObjective
(
       EducationOrganizationId INT NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationObjective_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationObjectiveRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationObjectiveRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationPeriodDescriptor
(
       EvaluationPeriodDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationPeriodDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationRatingLevelDescriptor
(
       EvaluationRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationTypeDescriptor
(
       EvaluationTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.FinancialAid
(
       AidTypeDescriptorId INT NOT NULL,
       BeginDate DATE NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FinancialAid_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.GenderDescriptor
(
       GenderDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GenderDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ObjectiveRatingLevelDescriptor
(
       ObjectiveRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ObjectiveRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluation
(
       EducationOrganizationId INT NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluationRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluationRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluationRatingLevelDescriptor
(
       PerformanceEvaluationRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluationRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluationTypeDescriptor
(
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluationTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RubricDimension
(
       EducationOrganizationId INT NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       RubricRating INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RubricDimension_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RubricRatingLevelDescriptor
(
       RubricRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RubricRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.SurveyResponsePersonTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyResponsePersonTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.SurveySectionResponsePersonTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionResponsePersonTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

