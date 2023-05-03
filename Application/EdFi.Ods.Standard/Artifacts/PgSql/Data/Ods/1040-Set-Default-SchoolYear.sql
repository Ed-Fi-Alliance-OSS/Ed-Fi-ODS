-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
DECLARE
    currentYear integer;
    currentMonth integer;

BEGIN
    currentYear = date_part('year', current_date);
    currentMonth = date_part('month', current_date);

    IF currentMonth > 6 THEN
        currentYear = currentYear + 1;
    END IF;

    PERFORM edfi.SetCurrentSchoolYear(currentYear);
END $$;
