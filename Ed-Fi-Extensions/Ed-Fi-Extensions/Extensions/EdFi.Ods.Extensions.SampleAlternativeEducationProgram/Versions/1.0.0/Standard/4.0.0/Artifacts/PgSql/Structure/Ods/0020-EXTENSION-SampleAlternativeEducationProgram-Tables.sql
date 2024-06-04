-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor --
CREATE TABLE samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor (
    AlternativeEducationEligibilityReasonDescriptorId INT NOT NULL,
    CONSTRAINT AlternativeEducationEligibilityReasonDescriptor_PK PRIMARY KEY (AlternativeEducationEligibilityReasonDescriptorId)
);

-- Table samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation --
CREATE TABLE samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    AlternativeEducationEligibilityReasonDescriptorId INT NOT NULL,
    CONSTRAINT StudentAlternativeEducationProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime --
CREATE TABLE samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    EndTime TIME NOT NULL,
    StartTime TIME NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAlternativeEducationProgramAssociationMeetingTime_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, EndTime, StartTime)
);
ALTER TABLE samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

