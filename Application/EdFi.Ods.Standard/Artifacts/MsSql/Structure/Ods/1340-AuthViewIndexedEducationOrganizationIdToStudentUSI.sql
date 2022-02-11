-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


CREATE OR ALTER VIEW auth.EducationOrganizationIdToStudentUSI 
    WITH SCHEMABINDING AS
    SELECT  edOrgs.SourceEducationOrganizationId, ssa.StudentUSI, COUNT_BIG(*) AS Ignored
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        INNER JOIN edfi.StudentSchoolAssociation ssa
            ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
    GROUP BY edOrgs.SourceEducationOrganizationId, ssa.StudentUSI

GO

CREATE UNIQUE CLUSTERED INDEX UX_EducationOrganizationIdToStudentUSI 
	ON auth.EducationOrganizationIdToStudentUSI (SourceEducationOrganizationId, StudentUSI);

GO