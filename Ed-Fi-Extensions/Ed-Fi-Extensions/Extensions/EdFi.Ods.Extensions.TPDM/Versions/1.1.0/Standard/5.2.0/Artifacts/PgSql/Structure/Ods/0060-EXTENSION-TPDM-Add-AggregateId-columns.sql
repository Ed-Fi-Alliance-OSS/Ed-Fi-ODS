-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- For the "Candidate" table
CREATE SEQUENCE tpdm.candidate_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.candidate ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.candidate_aggseq');
CREATE INDEX ix_candidate_aggregateid ON tpdm.candidate (aggregateid);

-- For the "CandidateEducatorPreparationProgramAssociation" table
CREATE SEQUENCE tpdm.candidateeducatorpreparationprogramassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.candidateeducatorpreparationprogramassociation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.candidateeducatorpreparationprogramassociation_aggseq');
CREATE INDEX ix_candidateeducatorpreparationprogramassociation_aggregateid ON tpdm.candidateeducatorpreparationprogramassociation (aggregateid);

-- For the "EducatorPreparationProgram" table
CREATE SEQUENCE tpdm.educatorpreparationprogram_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.educatorpreparationprogram ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.educatorpreparationprogram_aggseq');
CREATE INDEX ix_educatorpreparationprogram_aggregateid ON tpdm.educatorpreparationprogram (aggregateid);

-- For the "Evaluation" table
CREATE SEQUENCE tpdm.evaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.evaluation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.evaluation_aggseq');
CREATE INDEX ix_evaluation_aggregateid ON tpdm.evaluation (aggregateid);

-- For the "EvaluationElement" table
CREATE SEQUENCE tpdm.evaluationelement_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.evaluationelement ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.evaluationelement_aggseq');
CREATE INDEX ix_evaluationelement_aggregateid ON tpdm.evaluationelement (aggregateid);

-- For the "EvaluationElementRating" table
CREATE SEQUENCE tpdm.evaluationelementrating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.evaluationelementrating ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.evaluationelementrating_aggseq');
CREATE INDEX ix_evaluationelementrating_aggregateid ON tpdm.evaluationelementrating (aggregateid);

-- For the "EvaluationObjective" table
CREATE SEQUENCE tpdm.evaluationobjective_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.evaluationobjective ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.evaluationobjective_aggseq');
CREATE INDEX ix_evaluationobjective_aggregateid ON tpdm.evaluationobjective (aggregateid);

-- For the "EvaluationObjectiveRating" table
CREATE SEQUENCE tpdm.evaluationobjectiverating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.evaluationobjectiverating ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.evaluationobjectiverating_aggseq');
CREATE INDEX ix_evaluationobjectiverating_aggregateid ON tpdm.evaluationobjectiverating (aggregateid);

-- For the "EvaluationRating" table
CREATE SEQUENCE tpdm.evaluationrating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.evaluationrating ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.evaluationrating_aggseq');
CREATE INDEX ix_evaluationrating_aggregateid ON tpdm.evaluationrating (aggregateid);

-- For the "FinancialAid" table
CREATE SEQUENCE tpdm.financialaid_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.financialaid ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.financialaid_aggseq');
CREATE INDEX ix_financialaid_aggregateid ON tpdm.financialaid (aggregateid);

-- For the "PerformanceEvaluation" table
CREATE SEQUENCE tpdm.performanceevaluation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.performanceevaluation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.performanceevaluation_aggseq');
CREATE INDEX ix_performanceevaluation_aggregateid ON tpdm.performanceevaluation (aggregateid);

-- For the "PerformanceEvaluationRating" table
CREATE SEQUENCE tpdm.performanceevaluationrating_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.performanceevaluationrating ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.performanceevaluationrating_aggseq');
CREATE INDEX ix_performanceevaluationrating_aggregateid ON tpdm.performanceevaluationrating (aggregateid);

-- For the "RubricDimension" table
CREATE SEQUENCE tpdm.rubricdimension_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.rubricdimension ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.rubricdimension_aggseq');
CREATE INDEX ix_rubricdimension_aggregateid ON tpdm.rubricdimension (aggregateid);

-- For the "SurveyResponsePersonTargetAssociation" table
CREATE SEQUENCE tpdm.surveyresponsepersontargetassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.surveyresponsepersontargetassociation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.surveyresponsepersontargetassociation_aggseq');
CREATE INDEX ix_surveyresponsepersontargetassociation_aggregateid ON tpdm.surveyresponsepersontargetassociation (aggregateid);

-- For the "SurveySectionResponsePersonTargetAssociation" table
CREATE SEQUENCE tpdm.surveysectionresponsepersontargetassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE tpdm.surveysectionresponsepersontargetassociation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('tpdm.surveysectionresponsepersontargetassociation_aggseq');
CREATE INDEX ix_surveysectionresponsepersontargetassociation_aggregateid ON tpdm.surveysectionresponsepersontargetassociation (aggregateid);
