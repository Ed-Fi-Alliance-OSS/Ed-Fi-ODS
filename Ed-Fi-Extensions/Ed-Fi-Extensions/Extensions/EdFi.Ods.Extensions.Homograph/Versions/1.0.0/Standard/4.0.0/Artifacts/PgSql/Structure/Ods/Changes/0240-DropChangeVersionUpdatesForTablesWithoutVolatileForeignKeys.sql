-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'name') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON homograph.name';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'parent') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON homograph.parent';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'school') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON homograph.school';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'schoolyeartype') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON homograph.schoolyeartype';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'staff') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON homograph.staff';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'student') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON homograph.student';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'homograph' AND event_object_table = 'studentschoolassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON homograph.studentschoolassociation';
END IF;

END
$$;
