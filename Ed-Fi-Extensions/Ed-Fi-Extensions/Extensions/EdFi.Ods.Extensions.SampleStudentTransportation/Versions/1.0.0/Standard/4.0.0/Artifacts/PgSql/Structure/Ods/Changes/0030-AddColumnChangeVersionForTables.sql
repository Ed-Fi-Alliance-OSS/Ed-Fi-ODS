-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='samplestudenttransportation' AND table_name='studenttransportation' AND column_name='changeversion') THEN
ALTER TABLE samplestudenttransportation.StudentTransportation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE samplestudenttransportation.StudentTransportation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

END
$$;
