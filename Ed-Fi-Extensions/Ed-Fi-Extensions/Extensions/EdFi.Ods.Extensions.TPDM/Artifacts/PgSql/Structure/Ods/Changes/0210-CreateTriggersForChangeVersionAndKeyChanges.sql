-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'candidate') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.candidate
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'candidateeducatorpreparationprogramassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.candidateeducatorpreparationprogramassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'educatorpreparationprogram') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.educatorpreparationprogram
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.evaluation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationelement') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.evaluationelement
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationelementrating') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.evaluationelementrating
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationobjective') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.evaluationobjective
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationobjectiverating') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.evaluationobjectiverating
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'evaluationrating') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.evaluationrating
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'financialaid') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.financialaid
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.performanceevaluation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'performanceevaluationrating') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.performanceevaluationrating
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'rubricdimension') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.rubricdimension
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'surveyresponsepersontargetassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.surveyresponsepersontargetassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'tpdm' AND event_object_table = 'surveysectionresponsepersontargetassociation') THEN
CREATE TRIGGER UpdateChangeVersion BEFORE UPDATE ON tpdm.surveysectionresponsepersontargetassociation
    FOR EACH ROW EXECUTE PROCEDURE changes.UpdateChangeVersion();
END IF;

END
$$;
