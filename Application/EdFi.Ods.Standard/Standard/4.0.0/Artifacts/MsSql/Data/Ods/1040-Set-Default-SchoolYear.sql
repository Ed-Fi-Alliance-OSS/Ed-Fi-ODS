-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @currentYear int, @currentMonth int

SET @currentYear = DATEPART(YEAR, GetUtcDate())
SET @currentMonth = DATEPART(M, GetUtcDate()) 

-- If current date is after June, use the next school year
IF (@currentMonth > 6)
    SET @currentYear = @currentYear + 1

EXEC [edfi].[SetCurrentSchoolYear] @schoolYear = @currentYear
