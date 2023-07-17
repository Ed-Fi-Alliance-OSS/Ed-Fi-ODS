-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table samplestudenttranscript.InstitutionControlDescriptor --
CREATE TABLE samplestudenttranscript.InstitutionControlDescriptor (
    InstitutionControlDescriptorId INT NOT NULL,
    CONSTRAINT InstitutionControlDescriptor_PK PRIMARY KEY (InstitutionControlDescriptorId)
);

-- Table samplestudenttranscript.InstitutionLevelDescriptor --
CREATE TABLE samplestudenttranscript.InstitutionLevelDescriptor (
    InstitutionLevelDescriptorId INT NOT NULL,
    CONSTRAINT InstitutionLevelDescriptor_PK PRIMARY KEY (InstitutionLevelDescriptorId)
);

-- Table samplestudenttranscript.PostSecondaryOrganization --
CREATE TABLE samplestudenttranscript.PostSecondaryOrganization (
    NameOfInstitution VARCHAR(75) NOT NULL,
    InstitutionLevelDescriptorId INT NOT NULL,
    InstitutionControlDescriptorId INT NOT NULL,
    AcceptanceIndicator BOOLEAN NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PostSecondaryOrganization_PK PRIMARY KEY (NameOfInstitution)
);
ALTER TABLE samplestudenttranscript.PostSecondaryOrganization ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE samplestudenttranscript.PostSecondaryOrganization ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE samplestudenttranscript.PostSecondaryOrganization ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table samplestudenttranscript.SpecialEducationGraduationStatusDescriptor --
CREATE TABLE samplestudenttranscript.SpecialEducationGraduationStatusDescriptor (
    SpecialEducationGraduationStatusDescriptorId INT NOT NULL,
    CONSTRAINT SpecialEducationGraduationStatusDescriptor_PK PRIMARY KEY (SpecialEducationGraduationStatusDescriptorId)
);

-- Table samplestudenttranscript.StudentAcademicRecordClassRankingExtension --
CREATE TABLE samplestudenttranscript.StudentAcademicRecordClassRankingExtension (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    SpecialEducationGraduationStatusDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordClassRankingExtension_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
);
ALTER TABLE samplestudenttranscript.StudentAcademicRecordClassRankingExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table samplestudenttranscript.StudentAcademicRecordExtension --
CREATE TABLE samplestudenttranscript.StudentAcademicRecordExtension (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    NameOfInstitution VARCHAR(75) NULL,
    SubmissionCertificationDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordExtension_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
);
ALTER TABLE samplestudenttranscript.StudentAcademicRecordExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table samplestudenttranscript.SubmissionCertificationDescriptor --
CREATE TABLE samplestudenttranscript.SubmissionCertificationDescriptor (
    SubmissionCertificationDescriptorId INT NOT NULL,
    CONSTRAINT SubmissionCertificationDescriptor_PK PRIMARY KEY (SubmissionCertificationDescriptorId)
);

