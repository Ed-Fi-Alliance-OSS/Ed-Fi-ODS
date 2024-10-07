-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SEQUENCE tpdm.Candidate_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.Candidate ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.Candidate_AggSeq');
CREATE INDEX IX_Candidate_AggregateId ON tpdm.Candidate (AggregateId);

CREATE SEQUENCE tpdm.CandidateEducatorPreparationProgramAssociation_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.CandidateEducatorPreparationProgramAssociation_AggSeq');
CREATE INDEX IX_CandidateEducatorPreparationProgramAssociation_AggregateId ON tpdm.CandidateEducatorPreparationProgramAssociation (AggregateId);

CREATE SEQUENCE tpdm.EducatorPreparationProgram_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EducatorPreparationProgram ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.EducatorPreparationProgram_AggSeq');
CREATE INDEX IX_EducatorPreparationProgram_AggregateId ON tpdm.EducatorPreparationProgram (AggregateId);

CREATE SEQUENCE tpdm.Evaluation_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.Evaluation ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.Evaluation_AggSeq');
CREATE INDEX IX_Evaluation_AggregateId ON tpdm.Evaluation (AggregateId);

CREATE SEQUENCE tpdm.EvaluationElement_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationElement ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.EvaluationElement_AggSeq');
CREATE INDEX IX_EvaluationElement_AggregateId ON tpdm.EvaluationElement (AggregateId);

CREATE SEQUENCE tpdm.EvaluationElementRating_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationElementRating ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.EvaluationElementRating_AggSeq');
CREATE INDEX IX_EvaluationElementRating_AggregateId ON tpdm.EvaluationElementRating (AggregateId);

CREATE SEQUENCE tpdm.EvaluationObjective_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationObjective ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.EvaluationObjective_AggSeq');
CREATE INDEX IX_EvaluationObjective_AggregateId ON tpdm.EvaluationObjective (AggregateId);

CREATE SEQUENCE tpdm.EvaluationObjectiveRating_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationObjectiveRating ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.EvaluationObjectiveRating_AggSeq');
CREATE INDEX IX_EvaluationObjectiveRating_AggregateId ON tpdm.EvaluationObjectiveRating (AggregateId);

CREATE SEQUENCE tpdm.EvaluationRating_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationRating ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.EvaluationRating_AggSeq');
CREATE INDEX IX_EvaluationRating_AggregateId ON tpdm.EvaluationRating (AggregateId);

CREATE SEQUENCE tpdm.FinancialAid_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.FinancialAid ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.FinancialAid_AggSeq');
CREATE INDEX IX_FinancialAid_AggregateId ON tpdm.FinancialAid (AggregateId);

CREATE SEQUENCE tpdm.PerformanceEvaluation_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.PerformanceEvaluation ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.PerformanceEvaluation_AggSeq');
CREATE INDEX IX_PerformanceEvaluation_AggregateId ON tpdm.PerformanceEvaluation (AggregateId);

CREATE SEQUENCE tpdm.PerformanceEvaluationRating_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.PerformanceEvaluationRating ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.PerformanceEvaluationRating_AggSeq');
CREATE INDEX IX_PerformanceEvaluationRating_AggregateId ON tpdm.PerformanceEvaluationRating (AggregateId);

CREATE SEQUENCE tpdm.RubricDimension_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.RubricDimension ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.RubricDimension_AggSeq');
CREATE INDEX IX_RubricDimension_AggregateId ON tpdm.RubricDimension (AggregateId);

CREATE SEQUENCE tpdm.SurveyResponsePersonTargetAssociation_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.SurveyResponsePersonTargetAssociation_AggSeq');
CREATE INDEX IX_SurveyResponsePersonTargetAssociation_AggregateId ON tpdm.SurveyResponsePersonTargetAssociation (AggregateId);

CREATE SEQUENCE tpdm.SurveySectionResponsePersonTargetAssociation_AggSeq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ADD COLUMN AggregateId INT NOT NULL DEFAULT nextval('tpdm.SurveySectionResponsePersonTargetAssociation_AggSeq');
CREATE INDEX IX_SurveySectionResponsePersonTargetAssociation_AggregateId ON tpdm.SurveySectionResponsePersonTargetAssociation (AggregateId);
