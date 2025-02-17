-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'candidate') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.candidate';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'candidateeducatorpreparationprogramassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.candidateeducatorpreparationprogramassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'educatorpreparationprogram') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.educatorpreparationprogram';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.evaluation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationelement') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.evaluationelement';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationelementrating') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.evaluationelementrating';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationobjective') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.evaluationobjective';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationobjectiverating') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.evaluationobjectiverating';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'financialaid') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.financialaid';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.performanceevaluation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluationrating') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.performanceevaluationrating';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'rubricdimension') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.rubricdimension';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'surveyresponsepersontargetassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.surveyresponsepersontargetassociation';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'surveysectionresponsepersontargetassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON tpdm.surveysectionresponsepersontargetassociation';
END IF;

END
$$;
