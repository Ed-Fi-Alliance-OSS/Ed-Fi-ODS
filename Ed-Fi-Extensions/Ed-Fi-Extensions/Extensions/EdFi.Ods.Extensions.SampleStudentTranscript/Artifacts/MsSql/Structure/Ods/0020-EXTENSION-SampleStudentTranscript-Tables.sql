-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table [samplestudenttranscript].[InstitutionControlDescriptor] --
CREATE TABLE [samplestudenttranscript].[InstitutionControlDescriptor] (
    [InstitutionControlDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InstitutionControlDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InstitutionControlDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [samplestudenttranscript].[InstitutionLevelDescriptor] --
CREATE TABLE [samplestudenttranscript].[InstitutionLevelDescriptor] (
    [InstitutionLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InstitutionLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InstitutionLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [samplestudenttranscript].[PostSecondaryOrganization] --
CREATE TABLE [samplestudenttranscript].[PostSecondaryOrganization] (
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [InstitutionLevelDescriptorId] [INT] NOT NULL,
    [InstitutionControlDescriptorId] [INT] NOT NULL,
    [AcceptanceIndicator] [BIT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [PostSecondaryOrganization_PK] PRIMARY KEY CLUSTERED (
        [NameOfInstitution] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] ADD CONSTRAINT [PostSecondaryOrganization_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] ADD CONSTRAINT [PostSecondaryOrganization_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] ADD CONSTRAINT [PostSecondaryOrganization_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor] --
CREATE TABLE [samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor] (
    [SpecialEducationGraduationStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SpecialEducationGraduationStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SpecialEducationGraduationStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [samplestudenttranscript].[StudentAcademicRecordClassRankingExtension] --
CREATE TABLE [samplestudenttranscript].[StudentAcademicRecordClassRankingExtension] (
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [SpecialEducationGraduationStatusDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordClassRankingExtension_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [samplestudenttranscript].[StudentAcademicRecordClassRankingExtension] ADD CONSTRAINT [StudentAcademicRecordClassRankingExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [samplestudenttranscript].[StudentAcademicRecordExtension] --
CREATE TABLE [samplestudenttranscript].[StudentAcademicRecordExtension] (
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NULL,
    [SubmissionCertificationDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordExtension_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [samplestudenttranscript].[StudentAcademicRecordExtension] ADD CONSTRAINT [StudentAcademicRecordExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [samplestudenttranscript].[SubmissionCertificationDescriptor] --
CREATE TABLE [samplestudenttranscript].[SubmissionCertificationDescriptor] (
    [SubmissionCertificationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SubmissionCertificationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SubmissionCertificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

