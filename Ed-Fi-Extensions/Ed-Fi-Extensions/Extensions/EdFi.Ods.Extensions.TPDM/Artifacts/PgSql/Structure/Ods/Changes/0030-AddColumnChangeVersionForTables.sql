-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='Candidate' AND column_name='changeversion') THEN
ALTER TABLE tpdm.Candidate
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='CandidateEducatorPreparationProgramAssociation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='EducatorPreparationProgram' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EducatorPreparationProgram
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='Evaluation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.Evaluation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='EvaluationElement' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationElement
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='EvaluationElementRating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationElementRating
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='EvaluationObjective' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationObjective
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='EvaluationObjectiveRating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationObjectiveRating
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='EvaluationRating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.EvaluationRating
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='FinancialAid' AND column_name='changeversion') THEN
ALTER TABLE tpdm.FinancialAid
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='PerformanceEvaluation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.PerformanceEvaluation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='PerformanceEvaluationRating' AND column_name='changeversion') THEN
ALTER TABLE tpdm.PerformanceEvaluationRating
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='RubricDimension' AND column_name='changeversion') THEN
ALTER TABLE tpdm.RubricDimension
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='SurveyResponsePersonTargetAssociation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='tpdm' AND table_name='SurveySectionResponsePersonTargetAssociation' AND column_name='changeversion') THEN
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

END
$$;
