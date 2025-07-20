-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW auth.EducationOrganizationIdToContactUSI 
    WITH SCHEMABINDING AS
    SELECT  edOrgs.SourceEducationOrganizationId, spa.ContactUSI, COUNT_BIG(*) AS Ignored
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentSchoolAssociation ssa 
                ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
            INNER JOIN edfi.StudentContactAssociation spa 
                ON ssa.StudentUSI = spa.StudentUSI
    GROUP BY edOrgs.SourceEducationOrganizationId, spa.ContactUSI
    
GO

CREATE UNIQUE CLUSTERED INDEX UX_EducationOrganizationIdToContactUSI 
	ON auth.EducationOrganizationIdToContactUSI (SourceEducationOrganizationId, ContactUSI);

GO