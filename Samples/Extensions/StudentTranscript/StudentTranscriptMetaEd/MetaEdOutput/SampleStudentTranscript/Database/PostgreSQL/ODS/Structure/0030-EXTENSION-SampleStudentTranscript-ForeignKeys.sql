-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE samplestudenttranscript.InstitutionControlDescriptor ADD CONSTRAINT FK_f8fa08_Descriptor FOREIGN KEY (InstitutionControlDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE samplestudenttranscript.InstitutionLevelDescriptor ADD CONSTRAINT FK_3d8765_Descriptor FOREIGN KEY (InstitutionLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE samplestudenttranscript.PostSecondaryOrganization ADD CONSTRAINT FK_aa7b2a_InstitutionControlDescriptor FOREIGN KEY (InstitutionControlDescriptorId)
REFERENCES samplestudenttranscript.InstitutionControlDescriptor (InstitutionControlDescriptorId)
;

CREATE INDEX FK_aa7b2a_InstitutionControlDescriptor
ON samplestudenttranscript.PostSecondaryOrganization (InstitutionControlDescriptorId ASC);

ALTER TABLE samplestudenttranscript.PostSecondaryOrganization ADD CONSTRAINT FK_aa7b2a_InstitutionLevelDescriptor FOREIGN KEY (InstitutionLevelDescriptorId)
REFERENCES samplestudenttranscript.InstitutionLevelDescriptor (InstitutionLevelDescriptorId)
;

CREATE INDEX FK_aa7b2a_InstitutionLevelDescriptor
ON samplestudenttranscript.PostSecondaryOrganization (InstitutionLevelDescriptorId ASC);

ALTER TABLE samplestudenttranscript.SpecialEducationGraduationStatusDescriptor ADD CONSTRAINT FK_a7b9e2_Descriptor FOREIGN KEY (SpecialEducationGraduationStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE samplestudenttranscript.StudentAcademicRecordClassRankingExtension ADD CONSTRAINT FK_072d36_SpecialEducationGraduationStatusDescriptor FOREIGN KEY (SpecialEducationGraduationStatusDescriptorId)
REFERENCES samplestudenttranscript.SpecialEducationGraduationStatusDescriptor (SpecialEducationGraduationStatusDescriptorId)
;

CREATE INDEX FK_072d36_SpecialEducationGraduationStatusDescriptor
ON samplestudenttranscript.StudentAcademicRecordClassRankingExtension (SpecialEducationGraduationStatusDescriptorId ASC);

ALTER TABLE samplestudenttranscript.StudentAcademicRecordClassRankingExtension ADD CONSTRAINT FK_072d36_StudentAcademicRecordClassRanking FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecordClassRanking (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE samplestudenttranscript.StudentAcademicRecordExtension ADD CONSTRAINT FK_ee832f_PostSecondaryOrganization FOREIGN KEY (NameOfInstitution)
REFERENCES samplestudenttranscript.PostSecondaryOrganization (NameOfInstitution)
;

CREATE INDEX FK_ee832f_PostSecondaryOrganization
ON samplestudenttranscript.StudentAcademicRecordExtension (NameOfInstitution ASC);

ALTER TABLE samplestudenttranscript.StudentAcademicRecordExtension ADD CONSTRAINT FK_ee832f_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE samplestudenttranscript.StudentAcademicRecordExtension ADD CONSTRAINT FK_ee832f_SubmissionCertificationDescriptor FOREIGN KEY (SubmissionCertificationDescriptorId)
REFERENCES samplestudenttranscript.SubmissionCertificationDescriptor (SubmissionCertificationDescriptorId)
;

CREATE INDEX FK_ee832f_SubmissionCertificationDescriptor
ON samplestudenttranscript.StudentAcademicRecordExtension (SubmissionCertificationDescriptorId ASC);

ALTER TABLE samplestudenttranscript.SubmissionCertificationDescriptor ADD CONSTRAINT FK_caf4be_Descriptor FOREIGN KEY (SubmissionCertificationDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

