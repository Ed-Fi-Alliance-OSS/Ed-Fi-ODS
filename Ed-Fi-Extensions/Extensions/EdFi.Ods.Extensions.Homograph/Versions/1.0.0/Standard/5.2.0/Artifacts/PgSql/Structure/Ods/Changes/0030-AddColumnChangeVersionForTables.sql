-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- For performance reasons on existing data sets, all existing records will start with ChangeVersion of 0.
DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='contact' AND column_name='changeversion') THEN
ALTER TABLE homograph.Contact ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE homograph.Contact ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='name' AND column_name='changeversion') THEN
ALTER TABLE homograph.Name ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE homograph.Name ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='school' AND column_name='changeversion') THEN
ALTER TABLE homograph.School ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE homograph.School ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='schoolyeartype' AND column_name='changeversion') THEN
ALTER TABLE homograph.SchoolYearType ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE homograph.SchoolYearType ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='staff' AND column_name='changeversion') THEN
ALTER TABLE homograph.Staff ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE homograph.Staff ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='student' AND column_name='changeversion') THEN
ALTER TABLE homograph.Student ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE homograph.Student ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='studentschoolassociation' AND column_name='changeversion') THEN
ALTER TABLE homograph.StudentSchoolAssociation ADD ChangeVersion BIGINT DEFAULT (0) NOT NULL;
ALTER TABLE homograph.StudentSchoolAssociation ALTER ChangeVersion SET DEFAULT nextval('changes.ChangeVersionSequence');
END IF;

END
$$;
