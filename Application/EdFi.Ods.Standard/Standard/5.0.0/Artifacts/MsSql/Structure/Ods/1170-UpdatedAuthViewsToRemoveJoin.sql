-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

PRINT N'Altering [auth].[ParentUSIToSchoolId]...';
GO

ALTER VIEW [auth].[ParentUSIToSchoolId]
    WITH SCHEMABINDING
AS
    -- School to Parent USI
    SELECT ssa.SchoolId
        ,spa.ParentUSI
        ,COUNT_BIG(*) AS Count
    FROM edfi.StudentSchoolAssociation ssa
            INNER JOIN edfi.StudentParentAssociation spa ON
            ssa.StudentUSI = spa.StudentUSI
    GROUP BY spa.ParentUSI
        ,SchoolId;
GO
