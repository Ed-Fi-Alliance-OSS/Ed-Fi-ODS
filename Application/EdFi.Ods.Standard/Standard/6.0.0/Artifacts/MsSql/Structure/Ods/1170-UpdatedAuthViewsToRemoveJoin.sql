-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

PRINT N'Altering [auth].[ContactUSIToSchoolId]...';
GO

ALTER VIEW [auth].[ContactUSIToSchoolId]
    WITH SCHEMABINDING
AS
    -- School to Contact USI
    SELECT ssa.SchoolId
        ,spa.ContactUSI
        ,COUNT_BIG(*) AS Count
    FROM edfi.StudentSchoolAssociation ssa
            INNER JOIN edfi.StudentContactAssociation spa ON
            ssa.StudentUSI = spa.StudentUSI
    GROUP BY spa.ContactUSI
        ,SchoolId;
GO
