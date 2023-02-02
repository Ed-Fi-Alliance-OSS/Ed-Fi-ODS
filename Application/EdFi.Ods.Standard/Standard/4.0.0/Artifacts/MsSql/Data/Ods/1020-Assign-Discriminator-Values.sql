-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Set the discriminators for Education Organization
UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.CommunityOrganization'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.CommunityOrganization b ON a.EducationOrganizationId = b.CommunityOrganizationId
        );

UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.CommunityProvider'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.CommunityProvider b ON a.EducationOrganizationId = b.CommunityProviderId
        );

UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.EducationOrganizationNetwork'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.EducationOrganizationNetwork b ON a.EducationOrganizationId = b.EducationOrganizationNetworkId
        );

UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.EducationServiceCenter'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.EducationServiceCenter b ON a.EducationOrganizationId = b.EducationServiceCenterId
        );

UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.LocalEducationAgency'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.LocalEducationAgency b ON a.EducationOrganizationId = b.LocalEducationAgencyId
        );

UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.PostSecondaryInstitution'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.PostSecondaryInstitution b ON a.EducationOrganizationId = b.PostSecondaryInstitutionId
        );

UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.School'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.School b ON a.EducationOrganizationId = b.SchoolId
        );

UPDATE edfi.EducationOrganization
SET Discriminator = 'edfi.StateEducationAgency'
WHERE EducationOrganizationId IN (
        SELECT EducationOrganizationId
        FROM edfi.EducationOrganization a
        INNER JOIN edfi.StateEducationAgency b ON a.EducationOrganizationId = b.StateEducationAgencyId
        );

-- Set the discriminators for General Student Program Association
UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentCTEProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentCTEProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentHomelessProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentHomelessProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentLanguageInstructionProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentLanguageInstructionProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentMigrantEducationProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentMigrantEducationProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentNeglectedOrDelinquentProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentNeglectedOrDelinquentProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentSchoolFoodServiceProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentSchoolFoodServiceProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentSpecialEducationProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentSpecialEducationProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;

UPDATE edfi.GeneralStudentProgramAssociation
SET Discriminator = 'edfi.StudentTitleIPartAProgramAssociation'
FROM edfi.GeneralStudentProgramAssociation a
INNER JOIN edfi.StudentTitleIPartAProgramAssociation b ON a.BeginDate = b.BeginDate
    AND a.EducationOrganizationId = b.EducationOrganizationId
    AND a.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId
    AND a.ProgramName = b.ProgramName
    AND a.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId
    AND a.StudentUSI = b.StudentUSI;
