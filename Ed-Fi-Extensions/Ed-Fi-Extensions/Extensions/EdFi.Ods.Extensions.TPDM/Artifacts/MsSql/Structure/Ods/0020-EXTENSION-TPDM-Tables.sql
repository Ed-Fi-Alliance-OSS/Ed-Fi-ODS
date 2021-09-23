-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table [tpdm].[AccreditationStatusDescriptor] --
CREATE TABLE [tpdm].[AccreditationStatusDescriptor] (
    [AccreditationStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AccreditationStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AccreditationStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[AidTypeDescriptor] --
CREATE TABLE [tpdm].[AidTypeDescriptor] (
    [AidTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AidTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AidTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[Candidate] --
CREATE TABLE [tpdm].[Candidate] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [BirthDate] [DATE] NOT NULL,
    [BirthCity] [NVARCHAR](30) NULL,
    [BirthStateAbbreviationDescriptorId] [INT] NULL,
    [BirthInternationalProvince] [NVARCHAR](150) NULL,
    [BirthCountryDescriptorId] [INT] NULL,
    [DateEnteredUS] [DATE] NULL,
    [MultipleBirthStatus] [BIT] NULL,
    [BirthSexDescriptorId] [INT] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [EconomicDisadvantaged] [BIT] NULL,
    [LimitedEnglishProficiencyDescriptorId] [INT] NULL,
    [DisplacementStatus] [NVARCHAR](30) NULL,
    [GenderDescriptorId] [INT] NULL,
    [EnglishLanguageExamDescriptorId] [INT] NULL,
    [FirstGenerationStudent] [BIT] NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Candidate_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[Candidate] ADD CONSTRAINT [Candidate_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[Candidate] ADD CONSTRAINT [Candidate_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[Candidate] ADD CONSTRAINT [Candidate_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[CandidateAddress] --
CREATE TABLE [tpdm].[CandidateAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [CandidateIdentifier] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateAddress] ADD CONSTRAINT [CandidateAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateAddressPeriod] --
CREATE TABLE [tpdm].[CandidateAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateAddressPeriod] ADD CONSTRAINT [CandidateAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateDisability] --
CREATE TABLE [tpdm].[CandidateDisability] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateDisability_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateDisability] ADD CONSTRAINT [CandidateDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateDisabilityDesignation] --
CREATE TABLE [tpdm].[CandidateDisabilityDesignation] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateDisabilityDesignation] ADD CONSTRAINT [CandidateDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateEducatorPreparationProgramAssociation] --
CREATE TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [ReasonExitedDescriptorId] [INT] NULL,
    [EPPProgramPathwayDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] --
CREATE TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CohortYearTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociationCohortYear_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [CohortYearTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociationCohortYear_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] --
CREATE TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [MajorSpecialization] [NVARCHAR](255) NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [MinorSpecialization] [NVARCHAR](255) NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociationDegreeSpecialization_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [MajorSpecialization] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociationDegreeSpecialization_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateElectronicMail] --
CREATE TABLE [tpdm].[CandidateElectronicMail] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateElectronicMail] ADD CONSTRAINT [CandidateElectronicMail_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateLanguage] --
CREATE TABLE [tpdm].[CandidateLanguage] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateLanguage_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateLanguage] ADD CONSTRAINT [CandidateLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateLanguageUse] --
CREATE TABLE [tpdm].[CandidateLanguageUse] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateLanguageUse] ADD CONSTRAINT [CandidateLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateOtherName] --
CREATE TABLE [tpdm].[CandidateOtherName] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateOtherName_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [OtherNameTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateOtherName] ADD CONSTRAINT [CandidateOtherName_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidatePersonalIdentificationDocument] --
CREATE TABLE [tpdm].[CandidatePersonalIdentificationDocument] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidatePersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidatePersonalIdentificationDocument] ADD CONSTRAINT [CandidatePersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateRace] --
CREATE TABLE [tpdm].[CandidateRace] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateRace_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateRace] ADD CONSTRAINT [CandidateRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateTelephone] --
CREATE TABLE [tpdm].[CandidateTelephone] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateTelephone_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateTelephone] ADD CONSTRAINT [CandidateTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CertificationRouteDescriptor] --
CREATE TABLE [tpdm].[CertificationRouteDescriptor] (
    [CertificationRouteDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationRouteDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationRouteDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CoteachingStyleObservedDescriptor] --
CREATE TABLE [tpdm].[CoteachingStyleObservedDescriptor] (
    [CoteachingStyleObservedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CoteachingStyleObservedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CoteachingStyleObservedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CredentialExtension] --
CREATE TABLE [tpdm].[CredentialExtension] (
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [CertificationTitle] [NVARCHAR](64) NULL,
    [CertificationRouteDescriptorId] [INT] NULL,
    [BoardCertificationIndicator] [BIT] NULL,
    [CredentialStatusDescriptorId] [INT] NULL,
    [CredentialStatusDate] [DATE] NULL,
    [EducatorRoleDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialExtension_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CredentialExtension] ADD CONSTRAINT [CredentialExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CredentialStatusDescriptor] --
CREATE TABLE [tpdm].[CredentialStatusDescriptor] (
    [CredentialStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CredentialStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CredentialStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CredentialStudentAcademicRecord] --
CREATE TABLE [tpdm].[CredentialStudentAcademicRecord] (
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialStudentAcademicRecord_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CredentialStudentAcademicRecord] ADD CONSTRAINT [CredentialStudentAcademicRecord_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EducatorPreparationProgram] --
CREATE TABLE [tpdm].[EducatorPreparationProgram] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ProgramId] [NVARCHAR](20) NULL,
    [AccreditationStatusDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducatorPreparationProgram_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD CONSTRAINT [EducatorPreparationProgram_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD CONSTRAINT [EducatorPreparationProgram_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EducatorPreparationProgram] ADD CONSTRAINT [EducatorPreparationProgram_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EducatorPreparationProgramGradeLevel] --
CREATE TABLE [tpdm].[EducatorPreparationProgramGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducatorPreparationProgramGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EducatorPreparationProgramGradeLevel] ADD CONSTRAINT [EducatorPreparationProgramGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EducatorRoleDescriptor] --
CREATE TABLE [tpdm].[EducatorRoleDescriptor] (
    [EducatorRoleDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducatorRoleDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducatorRoleDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EnglishLanguageExamDescriptor] --
CREATE TABLE [tpdm].[EnglishLanguageExamDescriptor] (
    [EnglishLanguageExamDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EnglishLanguageExamDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EnglishLanguageExamDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EPPProgramPathwayDescriptor] --
CREATE TABLE [tpdm].[EPPProgramPathwayDescriptor] (
    [EPPProgramPathwayDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EPPProgramPathwayDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EPPProgramPathwayDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[Evaluation] --
CREATE TABLE [tpdm].[Evaluation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationDescription] [NVARCHAR](255) NULL,
    [MinRating] [DECIMAL](6, 3) NULL,
    [MaxRating] [DECIMAL](6, 3) NULL,
    [EvaluationTypeDescriptorId] [INT] NULL,
    [InterRaterReliabilityScore] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Evaluation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[Evaluation] ADD CONSTRAINT [Evaluation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[Evaluation] ADD CONSTRAINT [Evaluation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[Evaluation] ADD CONSTRAINT [Evaluation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EvaluationElement] --
CREATE TABLE [tpdm].[EvaluationElement] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [SortOrder] [INT] NULL,
    [MinRating] [DECIMAL](6, 3) NULL,
    [MaxRating] [DECIMAL](6, 3) NULL,
    [EvaluationTypeDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EvaluationElement_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationElement] ADD CONSTRAINT [EvaluationElement_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EvaluationElement] ADD CONSTRAINT [EvaluationElement_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EvaluationElement] ADD CONSTRAINT [EvaluationElement_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EvaluationElementRating] --
CREATE TABLE [tpdm].[EvaluationElementRating] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationElementRatingLevelDescriptorId] [INT] NULL,
    [AreaOfRefinement] [NVARCHAR](1024) NULL,
    [AreaOfReinforcement] [NVARCHAR](1024) NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [Feedback] [NVARCHAR](2048) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EvaluationElementRating_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationElementRating] ADD CONSTRAINT [EvaluationElementRating_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EvaluationElementRating] ADD CONSTRAINT [EvaluationElementRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EvaluationElementRating] ADD CONSTRAINT [EvaluationElementRating_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EvaluationElementRatingLevel] --
CREATE TABLE [tpdm].[EvaluationElementRatingLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [MinRating] [DECIMAL](6, 3) NULL,
    [MaxRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationElementRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationElementRatingLevel] ADD CONSTRAINT [EvaluationElementRatingLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationElementRatingLevelDescriptor] --
CREATE TABLE [tpdm].[EvaluationElementRatingLevelDescriptor] (
    [EvaluationElementRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationElementRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationElementRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EvaluationElementRatingResult] --
CREATE TABLE [tpdm].[EvaluationElementRatingResult] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [Rating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationElementRatingResult_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [Rating] ASC,
        [RatingResultTitle] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationElementRatingResult] ADD CONSTRAINT [EvaluationElementRatingResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationObjective] --
CREATE TABLE [tpdm].[EvaluationObjective] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationObjectiveDescription] [NVARCHAR](255) NULL,
    [SortOrder] [INT] NULL,
    [MinRating] [DECIMAL](6, 3) NULL,
    [MaxRating] [DECIMAL](6, 3) NULL,
    [EvaluationTypeDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EvaluationObjective_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationObjective] ADD CONSTRAINT [EvaluationObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EvaluationObjective] ADD CONSTRAINT [EvaluationObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EvaluationObjective] ADD CONSTRAINT [EvaluationObjective_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EvaluationObjectiveRating] --
CREATE TABLE [tpdm].[EvaluationObjectiveRating] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ObjectiveRatingLevelDescriptorId] [INT] NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EvaluationObjectiveRating_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD CONSTRAINT [EvaluationObjectiveRating_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD CONSTRAINT [EvaluationObjectiveRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EvaluationObjectiveRating] ADD CONSTRAINT [EvaluationObjectiveRating_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EvaluationObjectiveRatingLevel] --
CREATE TABLE [tpdm].[EvaluationObjectiveRatingLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [MinRating] [DECIMAL](6, 3) NULL,
    [MaxRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationObjectiveRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationObjectiveRatingLevel] ADD CONSTRAINT [EvaluationObjectiveRatingLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationObjectiveRatingResult] --
CREATE TABLE [tpdm].[EvaluationObjectiveRatingResult] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [Rating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationObjectiveRatingResult_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [Rating] ASC,
        [RatingResultTitle] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationObjectiveRatingResult] ADD CONSTRAINT [EvaluationObjectiveRatingResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationPeriodDescriptor] --
CREATE TABLE [tpdm].[EvaluationPeriodDescriptor] (
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationPeriodDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationPeriodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EvaluationRating] --
CREATE TABLE [tpdm].[EvaluationRating] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NULL,
    [SectionIdentifier] [NVARCHAR](255) NULL,
    [LocalCourseCode] [NVARCHAR](60) NULL,
    [SessionName] [NVARCHAR](60) NULL,
    [SchoolId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EvaluationRating_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationRating] ADD CONSTRAINT [EvaluationRating_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EvaluationRating] ADD CONSTRAINT [EvaluationRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EvaluationRating] ADD CONSTRAINT [EvaluationRating_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EvaluationRatingLevel] --
CREATE TABLE [tpdm].[EvaluationRatingLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [MinRating] [DECIMAL](6, 3) NULL,
    [MaxRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationRatingLevel] ADD CONSTRAINT [EvaluationRatingLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationRatingLevelDescriptor] --
CREATE TABLE [tpdm].[EvaluationRatingLevelDescriptor] (
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EvaluationRatingResult] --
CREATE TABLE [tpdm].[EvaluationRatingResult] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [Rating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationRatingResult_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [Rating] ASC,
        [RatingResultTitle] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationRatingResult] ADD CONSTRAINT [EvaluationRatingResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationRatingReviewer] --
CREATE TABLE [tpdm].[EvaluationRatingReviewer] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ReviewerPersonId] [NVARCHAR](32) NULL,
    [ReviewerSourceSystemDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationRatingReviewer_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [FirstName] ASC,
        [LastSurname] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationRatingReviewer] ADD CONSTRAINT [EvaluationRatingReviewer_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationRatingReviewerReceivedTraining] --
CREATE TABLE [tpdm].[EvaluationRatingReviewerReceivedTraining] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ReceivedTrainingDate] [DATE] NULL,
    [InterRaterReliabilityScore] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationRatingReviewerReceivedTraining_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [FirstName] ASC,
        [LastSurname] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EvaluationRatingReviewerReceivedTraining] ADD CONSTRAINT [EvaluationRatingReviewerReceivedTraining_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[EvaluationTypeDescriptor] --
CREATE TABLE [tpdm].[EvaluationTypeDescriptor] (
    [EvaluationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[FinancialAid] --
CREATE TABLE [tpdm].[FinancialAid] (
    [AidTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [AidConditionDescription] [NVARCHAR](1024) NULL,
    [AidAmount] [DECIMAL](19, 4) NULL,
    [PellGrantRecipient] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [FinancialAid_PK] PRIMARY KEY CLUSTERED (
        [AidTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[FinancialAid] ADD CONSTRAINT [FinancialAid_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[FinancialAid] ADD CONSTRAINT [FinancialAid_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[FinancialAid] ADD CONSTRAINT [FinancialAid_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[GenderDescriptor] --
CREATE TABLE [tpdm].[GenderDescriptor] (
    [GenderDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GenderDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GenderDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ObjectiveRatingLevelDescriptor] --
CREATE TABLE [tpdm].[ObjectiveRatingLevelDescriptor] (
    [ObjectiveRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ObjectiveRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ObjectiveRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[PerformanceEvaluation] --
CREATE TABLE [tpdm].[PerformanceEvaluation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationDescription] [NVARCHAR](255) NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [PerformanceEvaluation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluation] ADD CONSTRAINT [PerformanceEvaluation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[PerformanceEvaluation] ADD CONSTRAINT [PerformanceEvaluation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[PerformanceEvaluation] ADD CONSTRAINT [PerformanceEvaluation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[PerformanceEvaluationGradeLevel] --
CREATE TABLE [tpdm].[PerformanceEvaluationGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationGradeLevel] ADD CONSTRAINT [PerformanceEvaluationGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[PerformanceEvaluationRating] --
CREATE TABLE [tpdm].[PerformanceEvaluationRating] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ActualDate] [DATE] NOT NULL,
    [Announced] [BIT] NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [CoteachingStyleObservedDescriptorId] [INT] NULL,
    [ActualDuration] [INT] NULL,
    [PerformanceEvaluationRatingLevelDescriptorId] [INT] NULL,
    [ScheduleDate] [DATE] NULL,
    [ActualTime] [TIME](7) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRating_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD CONSTRAINT [PerformanceEvaluationRating_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD CONSTRAINT [PerformanceEvaluationRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRating] ADD CONSTRAINT [PerformanceEvaluationRating_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[PerformanceEvaluationRatingLevel] --
CREATE TABLE [tpdm].[PerformanceEvaluationRatingLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [MinRating] [DECIMAL](6, 3) NULL,
    [MaxRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRatingLevel] ADD CONSTRAINT [PerformanceEvaluationRatingLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[PerformanceEvaluationRatingLevelDescriptor] --
CREATE TABLE [tpdm].[PerformanceEvaluationRatingLevelDescriptor] (
    [PerformanceEvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PerformanceEvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[PerformanceEvaluationRatingResult] --
CREATE TABLE [tpdm].[PerformanceEvaluationRatingResult] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [Rating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingResult_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [Rating] ASC,
        [RatingResultTitle] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRatingResult] ADD CONSTRAINT [PerformanceEvaluationRatingResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[PerformanceEvaluationRatingReviewer] --
CREATE TABLE [tpdm].[PerformanceEvaluationRatingReviewer] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ReviewerPersonId] [NVARCHAR](32) NULL,
    [ReviewerSourceSystemDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingReviewer_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [FirstName] ASC,
        [LastSurname] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewer] ADD CONSTRAINT [PerformanceEvaluationRatingReviewer_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] --
CREATE TABLE [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ReceivedTrainingDate] [DATE] NULL,
    [InterRaterReliabilityScore] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingReviewerReceivedTraining_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [FirstName] ASC,
        [LastSurname] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] ADD CONSTRAINT [PerformanceEvaluationRatingReviewerReceivedTraining_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[PerformanceEvaluationTypeDescriptor] --
CREATE TABLE [tpdm].[PerformanceEvaluationTypeDescriptor] (
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PerformanceEvaluationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PerformanceEvaluationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[RubricDimension] --
CREATE TABLE [tpdm].[RubricDimension] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [RubricRating] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [RubricRatingLevelDescriptorId] [INT] NULL,
    [CriterionDescription] [NVARCHAR](1024) NOT NULL,
    [DimensionOrder] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [RubricDimension_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [RubricRating] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RubricDimension] ADD CONSTRAINT [RubricDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[RubricDimension] ADD CONSTRAINT [RubricDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[RubricDimension] ADD CONSTRAINT [RubricDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[RubricRatingLevelDescriptor] --
CREATE TABLE [tpdm].[RubricRatingLevelDescriptor] (
    [RubricRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RubricRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RubricRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[SurveyResponseExtension] --
CREATE TABLE [tpdm].[SurveyResponseExtension] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyResponseExtension_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SurveyResponseExtension] ADD CONSTRAINT [SurveyResponseExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[SurveyResponsePersonTargetAssociation] --
CREATE TABLE [tpdm].[SurveyResponsePersonTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyResponsePersonTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [PersonId] ASC,
        [SourceSystemDescriptorId] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD CONSTRAINT [SurveyResponsePersonTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD CONSTRAINT [SurveyResponsePersonTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] ADD CONSTRAINT [SurveyResponsePersonTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[SurveySectionResponsePersonTargetAssociation] --
CREATE TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySectionResponsePersonTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [PersonId] ASC,
        [SourceSystemDescriptorId] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [SurveySectionTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD CONSTRAINT [SurveySectionResponsePersonTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD CONSTRAINT [SurveySectionResponsePersonTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] ADD CONSTRAINT [SurveySectionResponsePersonTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

