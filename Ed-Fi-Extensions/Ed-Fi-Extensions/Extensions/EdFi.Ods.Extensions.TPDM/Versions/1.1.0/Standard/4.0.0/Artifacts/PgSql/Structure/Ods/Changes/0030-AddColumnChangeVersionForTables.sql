-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='candidate' AND column_name='changeversion') THEN
ALTER TABLE tpdm.Candidate ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.Candidate ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='candidateeducatorpreparationprogramassociation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='educatorpreparationprogram' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EducatorPreparationProgram ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.EducatorPreparationProgram ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='evaluation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.Evaluation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.Evaluation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='evaluationelement' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationElement ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.EvaluationElement ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='evaluationelementrating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationElementRating ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.EvaluationElementRating ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='evaluationobjective' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationObjective ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.EvaluationObjective ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='evaluationobjectiverating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationObjectiveRating ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.EvaluationObjectiveRating ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='evaluationrating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationRating ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.EvaluationRating ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='financialaid' AND column_name='changeversion') THEN
ALTER TABLE tpdm.FinancialAid ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.FinancialAid ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='performanceevaluation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.PerformanceEvaluation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.PerformanceEvaluation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='performanceevaluationrating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.PerformanceEvaluationRating ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.PerformanceEvaluationRating ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='rubricdimension' AND column_name='changeversion') THEN
ALTER TABLE tpdm.RubricDimension ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.RubricDimension ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='surveyresponsepersontargetassociation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='surveysectionresponsepersontargetassociation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

END
$$;
