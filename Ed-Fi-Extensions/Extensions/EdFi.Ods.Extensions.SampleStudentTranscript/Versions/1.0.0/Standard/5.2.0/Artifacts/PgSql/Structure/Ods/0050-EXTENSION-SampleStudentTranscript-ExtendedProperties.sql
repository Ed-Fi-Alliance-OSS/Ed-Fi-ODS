-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [samplestudenttranscript].[InstitutionControlDescriptor] --
COMMENT ON TABLE samplestudenttranscript.InstitutionControlDescriptor IS 'The type of control for an institution (e.g., public or private).';
COMMENT ON COLUMN samplestudenttranscript.InstitutionControlDescriptor.InstitutionControlDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [samplestudenttranscript].[InstitutionLevelDescriptor] --
COMMENT ON TABLE samplestudenttranscript.InstitutionLevelDescriptor IS 'The typical level of postsecondary degree offered by the institute.';
COMMENT ON COLUMN samplestudenttranscript.InstitutionLevelDescriptor.InstitutionLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [samplestudenttranscript].[PostSecondaryOrganization] --
COMMENT ON TABLE samplestudenttranscript.PostSecondaryOrganization IS 'PostSecondaryOrganization';
COMMENT ON COLUMN samplestudenttranscript.PostSecondaryOrganization.NameOfInstitution IS 'The name of the institution.';
COMMENT ON COLUMN samplestudenttranscript.PostSecondaryOrganization.AcceptanceIndicator IS 'An indication of acceptance.';
COMMENT ON COLUMN samplestudenttranscript.PostSecondaryOrganization.InstitutionControlDescriptorId IS 'The type of control of the institution (i.e., public or private).';
COMMENT ON COLUMN samplestudenttranscript.PostSecondaryOrganization.InstitutionLevelDescriptorId IS 'The level of the institution.';

-- Extended Properties [samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor] --
COMMENT ON TABLE samplestudenttranscript.SpecialEducationGraduationStatusDescriptor IS 'The graduation status for special education.';
COMMENT ON COLUMN samplestudenttranscript.SpecialEducationGraduationStatusDescriptor.SpecialEducationGraduationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [samplestudenttranscript].[StudentAcademicRecordClassRankingExtension] --
COMMENT ON TABLE samplestudenttranscript.StudentAcademicRecordClassRankingExtension IS 'Class Ranking Extension';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordClassRankingExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordClassRankingExtension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordClassRankingExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordClassRankingExtension.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordClassRankingExtension.SpecialEducationGraduationStatusDescriptorId IS 'The graduation status for special education.';

-- Extended Properties [samplestudenttranscript].[StudentAcademicRecordExtension] --
COMMENT ON TABLE samplestudenttranscript.StudentAcademicRecordExtension IS '';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordExtension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordExtension.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordExtension.NameOfInstitution IS 'The name of the institution.';
COMMENT ON COLUMN samplestudenttranscript.StudentAcademicRecordExtension.SubmissionCertificationDescriptorId IS 'The type of submission certification.';

-- Extended Properties [samplestudenttranscript].[SubmissionCertificationDescriptor] --
COMMENT ON TABLE samplestudenttranscript.SubmissionCertificationDescriptor IS 'The type of submission certification.';
COMMENT ON COLUMN samplestudenttranscript.SubmissionCertificationDescriptor.SubmissionCertificationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

