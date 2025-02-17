-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'sample' AND event_object_table = 'bus') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON sample.bus';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'sample' AND event_object_table = 'busroute') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON sample.busroute';
END IF;

IF EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updatechangeversion' AND event_object_schema = 'sample' AND event_object_table = 'studentgraduationplanassociation') THEN
    EXECUTE 'DROP TRIGGER updatechangeversion ON sample.studentgraduationplanassociation';
END IF;

END
$$;
