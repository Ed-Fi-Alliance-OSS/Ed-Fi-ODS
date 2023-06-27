-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW auth.EducationOrganizationIdToStudentUSIThroughResponsibilityIncludingDeletes AS
    SELECT  edOrgs.SourceEducationOrganizationId, seora.StudentUSI
    FROM    auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN edfi.StudentEducationOrganizationResponsibilityAssociation seora
                ON edOrgs.TargetEducationOrganizationId = seora.EducationOrganizationId

    UNION

    SELECT	edOrgs.SourceEducationOrganizationId, OldStudentUSI as StudentUSI
    FROM	auth.EducationOrganizationIdToEducationOrganizationId edOrgs
            INNER JOIN tracked_changes_edfi.StudentEducationOrganizationResponsibilityAssociation seora_tc
                ON edOrgs.TargetEducationOrganizationId = seora_tc.OldEducationOrganizationId
GO
