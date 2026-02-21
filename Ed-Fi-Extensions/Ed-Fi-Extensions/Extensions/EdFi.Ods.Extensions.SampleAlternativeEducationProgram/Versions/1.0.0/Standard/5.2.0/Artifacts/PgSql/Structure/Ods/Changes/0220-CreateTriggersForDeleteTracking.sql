-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION tracked_changes_samplealternativeeducationprogram.alternativeeducationeligibilityreasondescriptor_deleted()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_changes_edfi.descriptor(olddescriptorid, oldcodevalue, oldnamespace, id, discriminator, changeversion)
    SELECT OLD.AlternativeEducationEligibilityReasonDescriptorId, b.codevalue, b.namespace, b.id, 'samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor', nextval('changes.ChangeVersionSequence')
    FROM edfi.descriptor b WHERE old.AlternativeEducationEligibilityReasonDescriptorId = b.descriptorid ;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'trackdeletes' AND event_object_schema = 'samplealternativeeducationprogram' AND event_object_table = 'alternativeeducationeligibilityreasondescriptor') THEN
CREATE TRIGGER TrackDeletes AFTER DELETE ON samplealternativeeducationprogram.alternativeeducationeligibilityreasondescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_changes_samplealternativeeducationprogram.alternativeeducationeligibilityreasondescriptor_deleted();
END IF;

END
$$;
