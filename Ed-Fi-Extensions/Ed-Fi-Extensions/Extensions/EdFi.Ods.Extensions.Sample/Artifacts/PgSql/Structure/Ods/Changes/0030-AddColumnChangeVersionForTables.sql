-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='sample' AND table_name='Bus' AND column_name='changeversion') THEN
ALTER TABLE sample.Bus
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='sample' AND table_name='BusRoute' AND column_name='changeversion') THEN
ALTER TABLE sample.BusRoute
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='sample' AND table_name='StudentGraduationPlanAssociation' AND column_name='changeversion') THEN
ALTER TABLE sample.StudentGraduationPlanAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

END
$$;
