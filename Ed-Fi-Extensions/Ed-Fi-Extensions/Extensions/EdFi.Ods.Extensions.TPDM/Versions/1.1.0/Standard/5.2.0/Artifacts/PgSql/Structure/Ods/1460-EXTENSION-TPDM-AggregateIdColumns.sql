-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


CREATE SEQUENCE tpdm.Candidate_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.Candidate ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.Candidate_aggseq');
CREATE INDEX ix_Candidate_aggid ON tpdm.Candidate (AggregateId);


CREATE SEQUENCE tpdm.CandidateEducatorPreparationProgramAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.CandidateEducatorPreparationProgramAssociation_aggseq');
CREATE INDEX ix_CandidateEducatorPreparationProgramAssociation_aggid ON tpdm.CandidateEducatorPreparationProgramAssociation (AggregateId);


CREATE SEQUENCE tpdm.EducatorPreparationProgram_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EducatorPreparationProgram ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.EducatorPreparationProgram_aggseq');
CREATE INDEX ix_EducatorPreparationProgram_aggid ON tpdm.EducatorPreparationProgram (AggregateId);


CREATE SEQUENCE tpdm.Evaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.Evaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.Evaluation_aggseq');
CREATE INDEX ix_Evaluation_aggid ON tpdm.Evaluation (AggregateId);


CREATE SEQUENCE tpdm.EvaluationElement_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationElement ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.EvaluationElement_aggseq');
CREATE INDEX ix_EvaluationElement_aggid ON tpdm.EvaluationElement (AggregateId);


CREATE SEQUENCE tpdm.EvaluationElementRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationElementRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.EvaluationElementRating_aggseq');
CREATE INDEX ix_EvaluationElementRating_aggid ON tpdm.EvaluationElementRating (AggregateId);


CREATE SEQUENCE tpdm.EvaluationObjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationObjective ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.EvaluationObjective_aggseq');
CREATE INDEX ix_EvaluationObjective_aggid ON tpdm.EvaluationObjective (AggregateId);


CREATE SEQUENCE tpdm.EvaluationObjectiveRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationObjectiveRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.EvaluationObjectiveRating_aggseq');
CREATE INDEX ix_EvaluationObjectiveRating_aggid ON tpdm.EvaluationObjectiveRating (AggregateId);


CREATE SEQUENCE tpdm.EvaluationRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.EvaluationRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.EvaluationRating_aggseq');
CREATE INDEX ix_EvaluationRating_aggid ON tpdm.EvaluationRating (AggregateId);


CREATE SEQUENCE tpdm.FinancialAid_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.FinancialAid ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.FinancialAid_aggseq');
CREATE INDEX ix_FinancialAid_aggid ON tpdm.FinancialAid (AggregateId);


CREATE SEQUENCE tpdm.PerformanceEvaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.PerformanceEvaluation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.PerformanceEvaluation_aggseq');
CREATE INDEX ix_PerformanceEvaluation_aggid ON tpdm.PerformanceEvaluation (AggregateId);


CREATE SEQUENCE tpdm.PerformanceEvaluationRating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.PerformanceEvaluationRating ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.PerformanceEvaluationRating_aggseq');
CREATE INDEX ix_PerformanceEvaluationRating_aggid ON tpdm.PerformanceEvaluationRating (AggregateId);


CREATE SEQUENCE tpdm.RubricDimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.RubricDimension ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.RubricDimension_aggseq');
CREATE INDEX ix_RubricDimension_aggid ON tpdm.RubricDimension (AggregateId);


CREATE SEQUENCE tpdm.SurveyResponsePersonTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.SurveyResponsePersonTargetAssociation_aggseq');
CREATE INDEX ix_SurveyResponsePersonTargetAssociation_aggid ON tpdm.SurveyResponsePersonTargetAssociation (AggregateId);


CREATE SEQUENCE tpdm.SurveySectionResponsePersonTargetAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('tpdm.SurveySectionResponsePersonTargetAssociation_aggseq');
CREATE INDEX ix_SurveySectionResponsePersonTargetAssociation_aggid ON tpdm.SurveySectionResponsePersonTargetAssociation (AggregateId);

