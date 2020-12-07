-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

PRINT N'Altering [auth].[StaffUSIToTeacherPreparationProviderId]...';
GO

ALTER VIEW [auth].[StaffUSIToTeacherPreparationProviderId]
AS
    -- TeacherPreparationProvider to Staff (through TeacherPreparationProvider employment)
    SELECT emp.EducationOrganizationId AS TeacherPreparationProviderId
        ,emp.StaffUSI
    FROM tpdm.TeacherPreparationProvider tpp
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON tpp.TeacherPreparationProviderId = emp.EducationOrganizationId

    UNION

    -- TeacherPreparationProvider to Staff (through TeacherPreparationProvider assignment)
    SELECT assgn.EducationOrganizationId AS TeacherPreparationProviderId
        ,assgn.StaffUSI
    FROM tpdm.TeacherPreparationProvider tpp
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON tpp.TeacherPreparationProviderId = assgn.EducationOrganizationId;
GO

PRINT N'Altering [auth].[StaffUSIToUniversityId]...';
GO

ALTER VIEW [auth].[StaffUSIToUniversityId]
AS
    -- University to Staff (through University employment)
    SELECT emp.EducationOrganizationId AS UniversityId
        ,emp.StaffUSI
    FROM tpdm.University u
        INNER JOIN auth.EducationOrganizationToStaffUSI_Employment emp
            ON u.UniversityId = emp.EducationOrganizationId

    UNION

    -- University to Staff (through University assignment)
    SELECT assgn.EducationOrganizationId AS UniversityId
        ,assgn.StaffUSI
    FROM tpdm.University u
        INNER JOIN auth.EducationOrganizationToStaffUSI_Assignment assgn
            ON u.UniversityId = assgn.EducationOrganizationId;
GO
