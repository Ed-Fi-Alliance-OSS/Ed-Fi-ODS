-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW auth.EducationOrganizationIdToStudentUSI
AS
    SELECT  edOrgs.SourceEducationOrganizationId, ssa.StudentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
        INNER JOIN edfi.StudentSchoolAssociation ssa
            ON edOrgs.TargetEducationOrganizationId = ssa.SchoolId
    GROUP BY edOrgs.SourceEducationOrganizationId, ssa.StudentUSI
