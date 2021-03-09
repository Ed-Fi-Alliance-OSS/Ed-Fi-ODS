-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[FieldworkExperienceSectionAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[ApplicantProfile] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[Application] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[ApplicationEvent] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[Candidate] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[Certification] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[CertificationExam] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[CertificationExamResult] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[CredentialEvent] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[Evaluation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationElement] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationElementRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationObjective] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[EvaluationRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[FieldworkExperience] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[Goal] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[OpenStaffPositionEvent] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[PerformanceEvaluation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[ProfessionalDevelopmentEvent] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[QuantitativeMeasure] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[QuantitativeMeasureScore] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[RecruitmentEvent] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[RecruitmentEventAttendance] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[RubricDimension] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [tpdm].[SurveySectionAggregateResponse] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

