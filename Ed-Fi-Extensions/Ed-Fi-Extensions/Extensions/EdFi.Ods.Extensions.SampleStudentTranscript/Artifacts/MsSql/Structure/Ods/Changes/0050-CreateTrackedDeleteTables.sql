CREATE TABLE [tracked_deletes_samplestudenttranscript].[InstitutionControlDescriptor]
(
       InstitutionControlDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_InstitutionControlDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_samplestudenttranscript].[InstitutionLevelDescriptor]
(
       InstitutionLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_InstitutionLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_samplestudenttranscript].[PostSecondaryOrganization]
(
       NameOfInstitution [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PostSecondaryOrganization PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor]
(
       SpecialEducationGraduationStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SpecialEducationGraduationStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_samplestudenttranscript].[SubmissionCertificationDescriptor]
(
       SubmissionCertificationDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SubmissionCertificationDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
