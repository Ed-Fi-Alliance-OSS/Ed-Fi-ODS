-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.ContactUSIToSchoolId;

CREATE VIEW auth.ContactUSIToSchoolId
AS
    -- School to Contact USI
    SELECT ssa.SchoolId
        ,spa.ContactUSI
        ,COUNT(*) AS Count
    FROM edfi.StudentSchoolAssociation ssa
            INNER JOIN edfi.StudentContactAssociation spa ON
            ssa.StudentUSI = spa.StudentUSI
    GROUP BY spa.ContactUSI
        ,Contact;
