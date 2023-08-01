-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE tracked_deletes_samplestudenttranscript.InstitutionControlDescriptor
(
       InstitutionControlDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InstitutionControlDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_samplestudenttranscript.InstitutionLevelDescriptor
(
       InstitutionLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InstitutionLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_samplestudenttranscript.PostSecondaryOrganization
(
       NameOfInstitution VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PostSecondaryOrganization_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_samplestudenttranscript.SpecialEducationGraduationStatusDescriptor
(
       SpecialEducationGraduationStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SpecialEducationGraduationStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_samplestudenttranscript.SubmissionCertificationDescriptor
(
       SubmissionCertificationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SubmissionCertificationDescriptor_PK PRIMARY KEY (ChangeVersion)
);

