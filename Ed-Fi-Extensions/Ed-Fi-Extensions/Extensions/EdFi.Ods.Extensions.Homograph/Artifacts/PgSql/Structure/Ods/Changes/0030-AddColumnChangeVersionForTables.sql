-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='Name' AND column_name='changeversion') THEN
ALTER TABLE homograph.Name
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='Parent' AND column_name='changeversion') THEN
ALTER TABLE homograph.Parent
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='School' AND column_name='changeversion') THEN
ALTER TABLE homograph.School
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='SchoolYearType' AND column_name='changeversion') THEN
ALTER TABLE homograph.SchoolYearType
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='Staff' AND column_name='changeversion') THEN
ALTER TABLE homograph.Staff
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='Student' AND column_name='changeversion') THEN
ALTER TABLE homograph.Student
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_schema='homograph' AND table_name='StudentSchoolAssociation' AND column_name='changeversion') THEN
ALTER TABLE homograph.StudentSchoolAssociation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;
END IF;

END
$$;
