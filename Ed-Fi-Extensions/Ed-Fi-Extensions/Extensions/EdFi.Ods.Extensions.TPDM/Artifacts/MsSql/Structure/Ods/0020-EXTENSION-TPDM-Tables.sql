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

-- Table [tpdm].[ApplicantProfile] --
CREATE TABLE [tpdm].[ApplicantProfile] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [SexDescriptorId] [INT] NULL,
    [BirthDate] [DATE] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [GenderDescriptorId] [INT] NULL,
    [EconomicDisadvantaged] [BIT] NULL,
    [FirstGenerationStudent] [BIT] NULL,
    [HighestCompletedLevelOfEducationDescriptorId] [INT] NULL,
    [YearsOfPriorProfessionalExperience] [DECIMAL](5, 2) NULL,
    [YearsOfPriorTeachingExperience] [DECIMAL](5, 2) NULL,
    [HighlyQualifiedTeacher] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ApplicantProfile_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfile] ADD CONSTRAINT [ApplicantProfile_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[ApplicantProfile] ADD CONSTRAINT [ApplicantProfile_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[ApplicantProfile] ADD CONSTRAINT [ApplicantProfile_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ApplicantProfileAddress] --
CREATE TABLE [tpdm].[ApplicantProfileAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [ApplicantProfileAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [ApplicantProfileIdentifier] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileAddress] ADD CONSTRAINT [ApplicantProfileAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileAddressPeriod] --
CREATE TABLE [tpdm].[ApplicantProfileAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [ApplicantProfileIdentifier] ASC,
        [BeginDate] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileAddressPeriod] ADD CONSTRAINT [ApplicantProfileAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileApplicantCharacteristic] --
CREATE TABLE [tpdm].[ApplicantProfileApplicantCharacteristic] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileApplicantCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [StudentCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileApplicantCharacteristic] ADD CONSTRAINT [ApplicantProfileApplicantCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileBackgroundCheck] --
CREATE TABLE [tpdm].[ApplicantProfileBackgroundCheck] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [BackgroundCheckTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileBackgroundCheck] ADD CONSTRAINT [ApplicantProfileBackgroundCheck_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileDisability] --
CREATE TABLE [tpdm].[ApplicantProfileDisability] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileDisability_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileDisability] ADD CONSTRAINT [ApplicantProfileDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileDisabilityDesignation] --
CREATE TABLE [tpdm].[ApplicantProfileDisabilityDesignation] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileDisabilityDesignation] ADD CONSTRAINT [ApplicantProfileDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileEducatorPreparationProgramName] --
CREATE TABLE [tpdm].[ApplicantProfileEducatorPreparationProgramName] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [EducatorPreparationProgramName] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileEducatorPreparationProgramName_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [EducatorPreparationProgramName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileEducatorPreparationProgramName] ADD CONSTRAINT [ApplicantProfileEducatorPreparationProgramName_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileElectronicMail] --
CREATE TABLE [tpdm].[ApplicantProfileElectronicMail] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileElectronicMail] ADD CONSTRAINT [ApplicantProfileElectronicMail_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileGradePointAverage] --
CREATE TABLE [tpdm].[ApplicantProfileGradePointAverage] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [IsCumulative] [BIT] NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [GradePointAverageTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileGradePointAverage] ADD CONSTRAINT [ApplicantProfileGradePointAverage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] --
CREATE TABLE [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileHighlyQualifiedAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [ApplicantProfileIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] ADD CONSTRAINT [ApplicantProfileHighlyQualifiedAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileIdentificationDocument] --
CREATE TABLE [tpdm].[ApplicantProfileIdentificationDocument] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileIdentificationDocument] ADD CONSTRAINT [ApplicantProfileIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileInternationalAddress] --
CREATE TABLE [tpdm].[ApplicantProfileInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [ApplicantProfileIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileInternationalAddress] ADD CONSTRAINT [ApplicantProfileInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileLanguage] --
CREATE TABLE [tpdm].[ApplicantProfileLanguage] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileLanguage_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileLanguage] ADD CONSTRAINT [ApplicantProfileLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileLanguageUse] --
CREATE TABLE [tpdm].[ApplicantProfileLanguageUse] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileLanguageUse] ADD CONSTRAINT [ApplicantProfileLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfilePersonalIdentificationDocument] --
CREATE TABLE [tpdm].[ApplicantProfilePersonalIdentificationDocument] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfilePersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfilePersonalIdentificationDocument] ADD CONSTRAINT [ApplicantProfilePersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileRace] --
CREATE TABLE [tpdm].[ApplicantProfileRace] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileRace_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileRace] ADD CONSTRAINT [ApplicantProfileRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileTelephone] --
CREATE TABLE [tpdm].[ApplicantProfileTelephone] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileTelephone_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileTelephone] ADD CONSTRAINT [ApplicantProfileTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProfileVisa] --
CREATE TABLE [tpdm].[ApplicantProfileVisa] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileVisa_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProfileVisa] ADD CONSTRAINT [ApplicantProfileVisa_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[Application] --
CREATE TABLE [tpdm].[Application] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ApplicationDate] [DATE] NOT NULL,
    [ApplicationStatusDescriptorId] [INT] NOT NULL,
    [CurrentEmployee] [BIT] NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [AcceptedDate] [DATE] NULL,
    [ApplicationSourceDescriptorId] [INT] NULL,
    [FirstContactDate] [DATE] NULL,
    [HighNeedsAcademicSubjectDescriptorId] [INT] NULL,
    [HireStatusDescriptorId] [INT] NULL,
    [HiringSourceDescriptorId] [INT] NULL,
    [WithdrawDate] [DATE] NULL,
    [WithdrawReasonDescriptorId] [INT] NULL,
    [RequisitionNumber] [NVARCHAR](20) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Application_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ApplicationIdentifier] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[Application] ADD CONSTRAINT [Application_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[Application] ADD CONSTRAINT [Application_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[Application] ADD CONSTRAINT [Application_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ApplicationEvent] --
CREATE TABLE [tpdm].[ApplicationEvent] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationEventTypeDescriptorId] [INT] NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [SequenceNumber] [INT] NOT NULL,
    [EventEndDate] [DATE] NULL,
    [ApplicationEvaluationScore] [DECIMAL](36, 18) NULL,
    [ApplicationEventResultDescriptorId] [INT] NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ApplicationEvent_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ApplicationEventTypeDescriptorId] ASC,
        [ApplicationIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [SequenceNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicationEvent] ADD CONSTRAINT [ApplicationEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[ApplicationEvent] ADD CONSTRAINT [ApplicationEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[ApplicationEvent] ADD CONSTRAINT [ApplicationEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ApplicationEventResultDescriptor] --
CREATE TABLE [tpdm].[ApplicationEventResultDescriptor] (
    [ApplicationEventResultDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationEventResultDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationEventResultDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ApplicationEventTypeDescriptor] --
CREATE TABLE [tpdm].[ApplicationEventTypeDescriptor] (
    [ApplicationEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ApplicationRecruitmentEventAttendance] --
CREATE TABLE [tpdm].[ApplicationRecruitmentEventAttendance] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationRecruitmentEventAttendance_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ApplicationIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicationRecruitmentEventAttendance] ADD CONSTRAINT [ApplicationRecruitmentEventAttendance_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicationScoreResult] --
CREATE TABLE [tpdm].[ApplicationScoreResult] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationScoreResult_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ApplicationIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicationScoreResult] ADD CONSTRAINT [ApplicationScoreResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicationSourceDescriptor] --
CREATE TABLE [tpdm].[ApplicationSourceDescriptor] (
    [ApplicationSourceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationSourceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationSourceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ApplicationStatusDescriptor] --
CREATE TABLE [tpdm].[ApplicationStatusDescriptor] (
    [ApplicationStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ApplicationTerm] --
CREATE TABLE [tpdm].[ApplicationTerm] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationTerm_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ApplicationIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicationTerm] ADD CONSTRAINT [ApplicationTerm_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AssessmentExtension] --
CREATE TABLE [tpdm].[AssessmentExtension] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProgramGatewayDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentExtension_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AssessmentExtension] ADD CONSTRAINT [AssessmentExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[BackgroundCheckStatusDescriptor] --
CREATE TABLE [tpdm].[BackgroundCheckStatusDescriptor] (
    [BackgroundCheckStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [BackgroundCheckStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [BackgroundCheckStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[BackgroundCheckTypeDescriptor] --
CREATE TABLE [tpdm].[BackgroundCheckTypeDescriptor] (
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [BackgroundCheckTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [BackgroundCheckTypeDescriptorId] ASC
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
    [ProfileThumbnail] [NVARCHAR](255) NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [OldEthnicityDescriptorId] [INT] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [EconomicDisadvantaged] [BIT] NULL,
    [LimitedEnglishProficiencyDescriptorId] [INT] NULL,
    [DisplacementStatus] [NVARCHAR](30) NULL,
    [LoginId] [NVARCHAR](60) NULL,
    [GenderDescriptorId] [INT] NULL,
    [TuitionCost] [MONEY] NULL,
    [EnglishLanguageExamDescriptorId] [INT] NULL,
    [PreviousCareerDescriptorId] [INT] NULL,
    [ProgramComplete] [BIT] NULL,
    [FirstGenerationStudent] [BIT] NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NULL,
    [EducationOrganizationId] [INT] NULL,
    [ApplicantProfileIdentifier] [NVARCHAR](32) NULL,
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

-- Table [tpdm].[CandidateAid] --
CREATE TABLE [tpdm].[CandidateAid] (
    [AidTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EndDate] [DATE] NULL,
    [AidConditionDescription] [NVARCHAR](1024) NULL,
    [AidAmount] [MONEY] NULL,
    [PellGrantRecipient] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateAid_PK] PRIMARY KEY CLUSTERED (
        [AidTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [CandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateAid] ADD CONSTRAINT [CandidateAid_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateBackgroundCheck] --
CREATE TABLE [tpdm].[CandidateBackgroundCheck] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateBackgroundCheck] ADD CONSTRAINT [CandidateBackgroundCheck_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateCharacteristic] --
CREATE TABLE [tpdm].[CandidateCharacteristic] (
    [CandidateCharacteristicDescriptorId] [INT] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [CandidateCharacteristicDescriptorId] ASC,
        [CandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateCharacteristic] ADD CONSTRAINT [CandidateCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateCharacteristicDescriptor] --
CREATE TABLE [tpdm].[CandidateCharacteristicDescriptor] (
    [CandidateCharacteristicDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CandidateCharacteristicDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CandidateCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CandidateCohortYear] --
CREATE TABLE [tpdm].[CandidateCohortYear] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CohortYearTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateCohortYear_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [CohortYearTypeDescriptorId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateCohortYear] ADD CONSTRAINT [CandidateCohortYear_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateDegreeSpecialization] --
CREATE TABLE [tpdm].[CandidateDegreeSpecialization] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [MajorSpecialization] [NVARCHAR](75) NOT NULL,
    [MinorSpecialization] [NVARCHAR](75) NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateDegreeSpecialization_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [MajorSpecialization] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateDegreeSpecialization] ADD CONSTRAINT [CandidateDegreeSpecialization_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [MajorSpecialization] [NVARCHAR](75) NULL,
    [MinorSpecialization] [NVARCHAR](75) NULL,
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

-- Table [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] --
CREATE TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [IndicatorGroup] [NVARCHAR](200) NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [Indicator] [NVARCHAR](60) NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociationCandidateIndicator_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociationCandidateIndicator_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod] --
CREATE TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [tpdm].[CandidateEPPProgramDegree] --
CREATE TABLE [tpdm].[CandidateEPPProgramDegree] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EPPDegreeTypeDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEPPProgramDegree_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [CandidateIdentifier] ASC,
        [EPPDegreeTypeDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateEPPProgramDegree] ADD CONSTRAINT [CandidateEPPProgramDegree_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateIdentificationCode] --
CREATE TABLE [tpdm].[CandidateIdentificationCode] (
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [AssigningOrganizationIdentificationCode] ASC,
        [CandidateIdentifier] ASC,
        [IdentificationCode] ASC,
        [StudentIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateIdentificationCode] ADD CONSTRAINT [CandidateIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateIdentificationDocument] --
CREATE TABLE [tpdm].[CandidateIdentificationDocument] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateIdentificationDocument] ADD CONSTRAINT [CandidateIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateIndicator] --
CREATE TABLE [tpdm].[CandidateIndicator] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [IndicatorGroup] [NVARCHAR](200) NULL,
    [Indicator] [NVARCHAR](60) NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateIndicator_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [IndicatorName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateIndicator] ADD CONSTRAINT [CandidateIndicator_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateIndicatorPeriod] --
CREATE TABLE [tpdm].[CandidateIndicatorPeriod] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateIndicatorPeriod_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [IndicatorName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateIndicatorPeriod] ADD CONSTRAINT [CandidateIndicatorPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CandidateInternationalAddress] --
CREATE TABLE [tpdm].[CandidateInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [CandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateInternationalAddress] ADD CONSTRAINT [CandidateInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [tpdm].[CandidateRelationshipToStaffAssociation] --
CREATE TABLE [tpdm].[CandidateRelationshipToStaffAssociation] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [StaffToCandidateRelationshipDescriptorId] [INT] NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CandidateRelationshipToStaffAssociation_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] ADD CONSTRAINT [CandidateRelationshipToStaffAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] ADD CONSTRAINT [CandidateRelationshipToStaffAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] ADD CONSTRAINT [CandidateRelationshipToStaffAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

-- Table [tpdm].[CandidateVisa] --
CREATE TABLE [tpdm].[CandidateVisa] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateVisa_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CandidateVisa] ADD CONSTRAINT [CandidateVisa_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[Certification] --
CREATE TABLE [tpdm].[Certification] (
    [CertificationIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CertificationTitle] [NVARCHAR](64) NOT NULL,
    [EducationOrganizationId] [INT] NULL,
    [CertificationLevelDescriptorId] [INT] NULL,
    [CertificationFieldDescriptorId] [INT] NULL,
    [CertificationStandardDescriptorId] [INT] NULL,
    [MinimumDegreeDescriptorId] [INT] NULL,
    [EducatorRoleDescriptorId] [INT] NULL,
    [PopulationServedDescriptorId] [INT] NULL,
    [InstructionalSettingDescriptorId] [INT] NULL,
    [EffectiveDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Certification_PK] PRIMARY KEY CLUSTERED (
        [CertificationIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[Certification] ADD CONSTRAINT [Certification_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[Certification] ADD CONSTRAINT [Certification_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[Certification] ADD CONSTRAINT [Certification_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[CertificationCertificationExam] --
CREATE TABLE [tpdm].[CertificationCertificationExam] (
    [CertificationExamIdentifier] [NVARCHAR](60) NOT NULL,
    [CertificationExamNamespace] [NVARCHAR](255) NOT NULL,
    [CertificationIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CertificationCertificationExam_PK] PRIMARY KEY CLUSTERED (
        [CertificationExamIdentifier] ASC,
        [CertificationExamNamespace] ASC,
        [CertificationIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CertificationCertificationExam] ADD CONSTRAINT [CertificationCertificationExam_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CertificationExam] --
CREATE TABLE [tpdm].[CertificationExam] (
    [CertificationExamIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CertificationExamTitle] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NULL,
    [CertificationExamTypeDescriptorId] [INT] NULL,
    [EffectiveDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CertificationExam_PK] PRIMARY KEY CLUSTERED (
        [CertificationExamIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CertificationExam] ADD CONSTRAINT [CertificationExam_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[CertificationExam] ADD CONSTRAINT [CertificationExam_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[CertificationExam] ADD CONSTRAINT [CertificationExam_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[CertificationExamResult] --
CREATE TABLE [tpdm].[CertificationExamResult] (
    [CertificationExamDate] [DATE] NOT NULL,
    [CertificationExamIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [AttemptNumber] [INT] NULL,
    [CertificationExamScore] [DECIMAL](6, 3) NULL,
    [CertificationExamPassIndicator] [BIT] NULL,
    [CertificationExamStatusDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CertificationExamResult_PK] PRIMARY KEY CLUSTERED (
        [CertificationExamDate] ASC,
        [CertificationExamIdentifier] ASC,
        [Namespace] ASC,
        [PersonId] ASC,
        [SourceSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CertificationExamResult] ADD CONSTRAINT [CertificationExamResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[CertificationExamResult] ADD CONSTRAINT [CertificationExamResult_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[CertificationExamResult] ADD CONSTRAINT [CertificationExamResult_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[CertificationExamStatusDescriptor] --
CREATE TABLE [tpdm].[CertificationExamStatusDescriptor] (
    [CertificationExamStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationExamStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationExamStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CertificationExamTypeDescriptor] --
CREATE TABLE [tpdm].[CertificationExamTypeDescriptor] (
    [CertificationExamTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationExamTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationExamTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CertificationFieldDescriptor] --
CREATE TABLE [tpdm].[CertificationFieldDescriptor] (
    [CertificationFieldDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationFieldDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationFieldDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CertificationGradeLevel] --
CREATE TABLE [tpdm].[CertificationGradeLevel] (
    [CertificationIdentifier] [NVARCHAR](60) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CertificationGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CertificationIdentifier] ASC,
        [GradeLevelDescriptorId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CertificationGradeLevel] ADD CONSTRAINT [CertificationGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CertificationLevelDescriptor] --
CREATE TABLE [tpdm].[CertificationLevelDescriptor] (
    [CertificationLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CertificationRoute] --
CREATE TABLE [tpdm].[CertificationRoute] (
    [CertificationIdentifier] [NVARCHAR](60) NOT NULL,
    [CertificationRouteDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CertificationRoute_PK] PRIMARY KEY CLUSTERED (
        [CertificationIdentifier] ASC,
        [CertificationRouteDescriptorId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CertificationRoute] ADD CONSTRAINT [CertificationRoute_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[CertificationRouteDescriptor] --
CREATE TABLE [tpdm].[CertificationRouteDescriptor] (
    [CertificationRouteDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationRouteDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationRouteDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CertificationStandardDescriptor] --
CREATE TABLE [tpdm].[CertificationStandardDescriptor] (
    [CertificationStandardDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationStandardDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationStandardDescriptorId] ASC
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

-- Table [tpdm].[CredentialEvent] --
CREATE TABLE [tpdm].[CredentialEvent] (
    [CredentialEventDate] [DATE] NOT NULL,
    [CredentialEventTypeDescriptorId] [INT] NOT NULL,
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [CredentialEventReason] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CredentialEvent_PK] PRIMARY KEY CLUSTERED (
        [CredentialEventDate] ASC,
        [CredentialEventTypeDescriptorId] ASC,
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CredentialEvent] ADD CONSTRAINT [CredentialEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[CredentialEvent] ADD CONSTRAINT [CredentialEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[CredentialEvent] ADD CONSTRAINT [CredentialEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[CredentialEventTypeDescriptor] --
CREATE TABLE [tpdm].[CredentialEventTypeDescriptor] (
    [CredentialEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CredentialEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CredentialEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[CredentialExtension] --
CREATE TABLE [tpdm].[CredentialExtension] (
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [CertificationTitle] [NVARCHAR](64) NOT NULL,
    [CertificationIdentifier] [NVARCHAR](60) NULL,
    [Namespace] [NVARCHAR](255) NULL,
    [CertificationRouteDescriptorId] [INT] NULL,
    [BoardCertificationIndicator] [BIT] NULL,
    [CredentialStatusDescriptorId] [INT] NULL,
    [CredentialStatusDate] [DATE] NULL,
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

-- Table [tpdm].[DegreeDescriptor] --
CREATE TABLE [tpdm].[DegreeDescriptor] (
    [DegreeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DegreeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DegreeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EducatorPreparationProgram] --
CREATE TABLE [tpdm].[EducatorPreparationProgram] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ProgramId] [NVARCHAR](20) NULL,
    [EducatorPreparationProgramTypeDescriptorId] [INT] NULL,
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

-- Table [tpdm].[EducatorPreparationProgramTypeDescriptor] --
CREATE TABLE [tpdm].[EducatorPreparationProgramTypeDescriptor] (
    [EducatorPreparationProgramTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducatorPreparationProgramTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducatorPreparationProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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

-- Table [tpdm].[EPPDegreeTypeDescriptor] --
CREATE TABLE [tpdm].[EPPDegreeTypeDescriptor] (
    [EPPDegreeTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EPPDegreeTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EPPDegreeTypeDescriptorId] ASC
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
    [Feedback] [NVARCHAR](1024) NULL,
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

-- Table [tpdm].[FederalLocaleCodeDescriptor] --
CREATE TABLE [tpdm].[FederalLocaleCodeDescriptor] (
    [FederalLocaleCodeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [FederalLocaleCodeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [FederalLocaleCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[FieldworkExperience] --
CREATE TABLE [tpdm].[FieldworkExperience] (
    [BeginDate] [DATE] NOT NULL,
    [FieldworkIdentifier] [NVARCHAR](64) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [SchoolId] [INT] NULL,
    [EducationOrganizationId] [INT] NULL,
    [ProgramName] [NVARCHAR](255) NULL,
    [ProgramTypeDescriptorId] [INT] NULL,
    [FieldworkTypeDescriptorId] [INT] NOT NULL,
    [HoursCompleted] [DECIMAL](5, 2) NULL,
    [EndDate] [DATE] NULL,
    [ProgramGatewayDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [FieldworkExperience_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [FieldworkIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[FieldworkExperience] ADD CONSTRAINT [FieldworkExperience_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[FieldworkExperience] ADD CONSTRAINT [FieldworkExperience_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[FieldworkExperience] ADD CONSTRAINT [FieldworkExperience_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[FieldworkExperienceCoteaching] --
CREATE TABLE [tpdm].[FieldworkExperienceCoteaching] (
    [BeginDate] [DATE] NOT NULL,
    [FieldworkIdentifier] [NVARCHAR](64) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CoteachingBeginDate] [DATE] NOT NULL,
    [CoteachingEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [FieldworkExperienceCoteaching_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [FieldworkIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[FieldworkExperienceCoteaching] ADD CONSTRAINT [FieldworkExperienceCoteaching_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[FieldworkExperienceSectionAssociation] --
CREATE TABLE [tpdm].[FieldworkExperienceSectionAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [FieldworkIdentifier] [NVARCHAR](64) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [FieldworkExperienceSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [FieldworkIdentifier] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[FieldworkExperienceSectionAssociation] ADD CONSTRAINT [FieldworkExperienceSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[FieldworkExperienceSectionAssociation] ADD CONSTRAINT [FieldworkExperienceSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[FieldworkExperienceSectionAssociation] ADD CONSTRAINT [FieldworkExperienceSectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[FieldworkTypeDescriptor] --
CREATE TABLE [tpdm].[FieldworkTypeDescriptor] (
    [FieldworkTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [FieldworkTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [FieldworkTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[FundingSourceDescriptor] --
CREATE TABLE [tpdm].[FundingSourceDescriptor] (
    [FundingSourceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [FundingSourceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [FundingSourceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[GenderDescriptor] --
CREATE TABLE [tpdm].[GenderDescriptor] (
    [GenderDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GenderDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GenderDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[Goal] --
CREATE TABLE [tpdm].[Goal] (
    [AssignmentDate] [DATE] NOT NULL,
    [GoalTitle] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NULL,
    [TermDescriptorId] [INT] NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [EvaluationPeriodDescriptorId] [INT] NULL,
    [EducationOrganizationId] [INT] NULL,
    [EvaluationTitle] [NVARCHAR](50) NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NULL,
    [GoalTypeDescriptorId] [INT] NULL,
    [GoalDescription] [NVARCHAR](1024) NULL,
    [DueDate] [DATE] NULL,
    [CompletedIndicator] [BIT] NULL,
    [CompletedDate] [DATE] NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Goal_PK] PRIMARY KEY CLUSTERED (
        [AssignmentDate] ASC,
        [GoalTitle] ASC,
        [PersonId] ASC,
        [SourceSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[Goal] ADD CONSTRAINT [Goal_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[Goal] ADD CONSTRAINT [Goal_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[Goal] ADD CONSTRAINT [Goal_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[GoalTypeDescriptor] --
CREATE TABLE [tpdm].[GoalTypeDescriptor] (
    [GoalTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GoalTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GoalTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[GraduationPlanRequiredCertification] --
CREATE TABLE [tpdm].[GraduationPlanRequiredCertification] (
    [CertificationTitle] [NVARCHAR](64) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [CertificationIdentifier] [NVARCHAR](60) NULL,
    [Namespace] [NVARCHAR](255) NULL,
    [CertificationRouteDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredCertification_PK] PRIMARY KEY CLUSTERED (
        [CertificationTitle] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[GraduationPlanRequiredCertification] ADD CONSTRAINT [GraduationPlanRequiredCertification_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[HireStatusDescriptor] --
CREATE TABLE [tpdm].[HireStatusDescriptor] (
    [HireStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [HireStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [HireStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[HiringSourceDescriptor] --
CREATE TABLE [tpdm].[HiringSourceDescriptor] (
    [HiringSourceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [HiringSourceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [HiringSourceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[InstructionalSettingDescriptor] --
CREATE TABLE [tpdm].[InstructionalSettingDescriptor] (
    [InstructionalSettingDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InstructionalSettingDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InstructionalSettingDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[LengthOfContractDescriptor] --
CREATE TABLE [tpdm].[LengthOfContractDescriptor] (
    [LengthOfContractDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LengthOfContractDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LengthOfContractDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[LocalEducationAgencyExtension] --
CREATE TABLE [tpdm].[LocalEducationAgencyExtension] (
    [LocalEducationAgencyId] [INT] NOT NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LocalEducationAgencyExtension_PK] PRIMARY KEY CLUSTERED (
        [LocalEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[LocalEducationAgencyExtension] ADD CONSTRAINT [LocalEducationAgencyExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ObjectiveRatingLevelDescriptor] --
CREATE TABLE [tpdm].[ObjectiveRatingLevelDescriptor] (
    [ObjectiveRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ObjectiveRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ObjectiveRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[OpenStaffPositionEvent] --
CREATE TABLE [tpdm].[OpenStaffPositionEvent] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [OpenStaffPositionEventTypeDescriptorId] [INT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [OpenStaffPositionEventStatusDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [OpenStaffPositionEvent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [OpenStaffPositionEventTypeDescriptorId] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[OpenStaffPositionEvent] ADD CONSTRAINT [OpenStaffPositionEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[OpenStaffPositionEvent] ADD CONSTRAINT [OpenStaffPositionEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[OpenStaffPositionEvent] ADD CONSTRAINT [OpenStaffPositionEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[OpenStaffPositionEventStatusDescriptor] --
CREATE TABLE [tpdm].[OpenStaffPositionEventStatusDescriptor] (
    [OpenStaffPositionEventStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OpenStaffPositionEventStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OpenStaffPositionEventStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[OpenStaffPositionEventTypeDescriptor] --
CREATE TABLE [tpdm].[OpenStaffPositionEventTypeDescriptor] (
    [OpenStaffPositionEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OpenStaffPositionEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OpenStaffPositionEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[OpenStaffPositionExtension] --
CREATE TABLE [tpdm].[OpenStaffPositionExtension] (
    [EducationOrganizationId] [INT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [SchoolYear] [SMALLINT] NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
    [OpenStaffPositionReasonDescriptorId] [INT] NULL,
    [IsActive] [BIT] NULL,
    [MaxSalary] [DECIMAL](9, 2) NULL,
    [MinSalary] [DECIMAL](9, 2) NULL,
    [FundingSourceDescriptorId] [INT] NULL,
    [HighNeedAcademicSubject] [BIT] NULL,
    [PositionControlNumber] [NVARCHAR](20) NULL,
    [TermDescriptorId] [INT] NULL,
    [TotalBudgeted] [DECIMAL](9, 2) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [OpenStaffPositionExtension_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[OpenStaffPositionExtension] ADD CONSTRAINT [OpenStaffPositionExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[OpenStaffPositionReasonDescriptor] --
CREATE TABLE [tpdm].[OpenStaffPositionReasonDescriptor] (
    [OpenStaffPositionReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OpenStaffPositionReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OpenStaffPositionReasonDescriptorId] ASC
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

-- Table [tpdm].[PerformanceEvaluationProgramGateway] --
CREATE TABLE [tpdm].[PerformanceEvaluationProgramGateway] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramGatewayDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationProgramGateway_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [ProgramGatewayDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PerformanceEvaluationProgramGateway] ADD CONSTRAINT [PerformanceEvaluationProgramGateway_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [tpdm].[PostSecondaryInstitutionExtension] --
CREATE TABLE [tpdm].[PostSecondaryInstitutionExtension] (
    [PostSecondaryInstitutionId] [INT] NOT NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PostSecondaryInstitutionExtension_PK] PRIMARY KEY CLUSTERED (
        [PostSecondaryInstitutionId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[PostSecondaryInstitutionExtension] ADD CONSTRAINT [PostSecondaryInstitutionExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[PreviousCareerDescriptor] --
CREATE TABLE [tpdm].[PreviousCareerDescriptor] (
    [PreviousCareerDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PreviousCareerDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PreviousCareerDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ProfessionalDevelopmentEvent] --
CREATE TABLE [tpdm].[ProfessionalDevelopmentEvent] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProfessionalDevelopmentTitle] [NVARCHAR](60) NOT NULL,
    [ProfessionalDevelopmentOfferedByDescriptorId] [INT] NOT NULL,
    [TotalHours] [INT] NULL,
    [Required] [BIT] NULL,
    [MultipleSession] [BIT] NULL,
    [ProfessionalDevelopmentReason] [NVARCHAR](60) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ProfessionalDevelopmentEvent_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [ProfessionalDevelopmentTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProfessionalDevelopmentEvent] ADD CONSTRAINT [ProfessionalDevelopmentEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[ProfessionalDevelopmentEvent] ADD CONSTRAINT [ProfessionalDevelopmentEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[ProfessionalDevelopmentEvent] ADD CONSTRAINT [ProfessionalDevelopmentEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ProfessionalDevelopmentEventAttendance] --
CREATE TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] (
    [AttendanceDate] [DATE] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [ProfessionalDevelopmentTitle] [NVARCHAR](60) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [AttendanceEventReason] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ProfessionalDevelopmentEventAttendance_PK] PRIMARY KEY CLUSTERED (
        [AttendanceDate] ASC,
        [Namespace] ASC,
        [PersonId] ASC,
        [ProfessionalDevelopmentTitle] ASC,
        [SourceSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] ADD CONSTRAINT [ProfessionalDevelopmentEventAttendance_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] ADD CONSTRAINT [ProfessionalDevelopmentEventAttendance_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] ADD CONSTRAINT [ProfessionalDevelopmentEventAttendance_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] --
CREATE TABLE [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] (
    [ProfessionalDevelopmentOfferedByDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProfessionalDevelopmentOfferedByDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProfessionalDevelopmentOfferedByDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ProgramGatewayDescriptor] --
CREATE TABLE [tpdm].[ProgramGatewayDescriptor] (
    [ProgramGatewayDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgramGatewayDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgramGatewayDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[QuantitativeMeasure] --
CREATE TABLE [tpdm].[QuantitativeMeasure] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [QuantitativeMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [QuantitativeMeasureTypeDescriptorId] [INT] NULL,
    [QuantitativeMeasureDatatypeDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [QuantitativeMeasure_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [QuantitativeMeasureIdentifier] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[QuantitativeMeasure] ADD CONSTRAINT [QuantitativeMeasure_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[QuantitativeMeasure] ADD CONSTRAINT [QuantitativeMeasure_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[QuantitativeMeasure] ADD CONSTRAINT [QuantitativeMeasure_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[QuantitativeMeasureDatatypeDescriptor] --
CREATE TABLE [tpdm].[QuantitativeMeasureDatatypeDescriptor] (
    [QuantitativeMeasureDatatypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [QuantitativeMeasureDatatypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [QuantitativeMeasureDatatypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[QuantitativeMeasureScore] --
CREATE TABLE [tpdm].[QuantitativeMeasureScore] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [QuantitativeMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ScoreValue] [DECIMAL](6, 3) NOT NULL,
    [StandardError] [DECIMAL](6, 3) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [QuantitativeMeasureScore_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [QuantitativeMeasureIdentifier] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[QuantitativeMeasureScore] ADD CONSTRAINT [QuantitativeMeasureScore_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[QuantitativeMeasureScore] ADD CONSTRAINT [QuantitativeMeasureScore_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[QuantitativeMeasureScore] ADD CONSTRAINT [QuantitativeMeasureScore_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[QuantitativeMeasureTypeDescriptor] --
CREATE TABLE [tpdm].[QuantitativeMeasureTypeDescriptor] (
    [QuantitativeMeasureTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [QuantitativeMeasureTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [QuantitativeMeasureTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[RecruitmentEvent] --
CREATE TABLE [tpdm].[RecruitmentEvent] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [EventDescription] [NVARCHAR](255) NULL,
    [RecruitmentEventTypeDescriptorId] [INT] NOT NULL,
    [EventLocation] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [RecruitmentEvent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEvent] ADD CONSTRAINT [RecruitmentEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[RecruitmentEvent] ADD CONSTRAINT [RecruitmentEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[RecruitmentEvent] ADD CONSTRAINT [RecruitmentEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[RecruitmentEventAttendance] --
CREATE TABLE [tpdm].[RecruitmentEventAttendance] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [Applied] [BIT] NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [GenderDescriptorId] [INT] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [Met] [BIT] NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [Notes] [NVARCHAR](255) NULL,
    [PreScreeningRating] [INT] NULL,
    [RecruitmentEventAttendeeTypeDescriptorId] [INT] NULL,
    [Referral] [BIT] NULL,
    [ReferredBy] [NVARCHAR](50) NULL,
    [SexDescriptorId] [INT] NULL,
    [SocialMediaNetworkName] [NVARCHAR](50) NULL,
    [SocialMediaUserName] [NVARCHAR](50) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendance_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendance] ADD CONSTRAINT [RecruitmentEventAttendance_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendance] ADD CONSTRAINT [RecruitmentEventAttendance_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendance] ADD CONSTRAINT [RecruitmentEventAttendance_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceCurrentPosition] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceCurrentPosition] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [Location] [NVARCHAR](75) NOT NULL,
    [PositionTitle] [NVARCHAR](100) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceCurrentPosition_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceCurrentPosition] ADD CONSTRAINT [RecruitmentEventAttendanceCurrentPosition_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceCurrentPositionGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [GradeLevelDescriptorId] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] ADD CONSTRAINT [RecruitmentEventAttendanceCurrentPositionGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceDisability] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceDisability] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceDisability_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceDisability] ADD CONSTRAINT [RecruitmentEventAttendanceDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] ADD CONSTRAINT [RecruitmentEventAttendanceDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] --
CREATE TABLE [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendancePersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] ADD CONSTRAINT [RecruitmentEventAttendancePersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceRace] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceRace] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceRace_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RaceDescriptorId] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceRace] ADD CONSTRAINT [RecruitmentEventAttendanceRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [Eligible] [BIT] NOT NULL,
    [CapacityToServe] [BIT] NULL,
    [YearsOfServiceCurrentPlacement] [DECIMAL](5, 2) NULL,
    [YearsOfServiceTotal] [DECIMAL](5, 2) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] ADD CONSTRAINT [RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceTelephone] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceTelephone] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceTelephone] ADD CONSTRAINT [RecruitmentEventAttendanceTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendanceTouchpoint] --
CREATE TABLE [tpdm].[RecruitmentEventAttendanceTouchpoint] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [TouchpointContent] [NVARCHAR](255) NOT NULL,
    [TouchpointDate] [DATE] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceTouchpoint_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC,
        [TouchpointContent] ASC,
        [TouchpointDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[RecruitmentEventAttendanceTouchpoint] ADD CONSTRAINT [RecruitmentEventAttendanceTouchpoint_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[RecruitmentEventAttendeeTypeDescriptor] --
CREATE TABLE [tpdm].[RecruitmentEventAttendeeTypeDescriptor] (
    [RecruitmentEventAttendeeTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendeeTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RecruitmentEventAttendeeTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[RecruitmentEventTypeDescriptor] --
CREATE TABLE [tpdm].[RecruitmentEventTypeDescriptor] (
    [RecruitmentEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RecruitmentEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RecruitmentEventTypeDescriptorId] ASC
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

-- Table [tpdm].[SalaryTypeDescriptor] --
CREATE TABLE [tpdm].[SalaryTypeDescriptor] (
    [SalaryTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SalaryTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SalaryTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[SchoolExtension] --
CREATE TABLE [tpdm].[SchoolExtension] (
    [SchoolId] [INT] NOT NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    [PostSecondaryInstitutionId] [INT] NULL,
    [ImprovingSchool] [BIT] NULL,
    [AccreditationStatusDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SchoolExtension_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SchoolExtension] ADD CONSTRAINT [SchoolExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] --
CREATE TABLE [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StaffClassificationDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [YearsOfExperienceAtCurrentEducationOrganization] [DECIMAL](5, 2) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationAssignmentAssociationExtension_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [StaffClassificationDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] ADD CONSTRAINT [StaffEducationOrganizationAssignmentAssociationExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] --
CREATE TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] (
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociationBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [BackgroundCheckTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociationBackgroundCheck_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] --
CREATE TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [ProbationCompleteDate] [DATE] NULL,
    [LengthOfContractDescriptorId] [INT] NULL,
    [TenureTrack] [BIT] NULL,
    [Tenured] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociationExtension_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociationExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] --
CREATE TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [SalaryMinRange] [INT] NULL,
    [SalaryMaxRange] [INT] NULL,
    [SalaryTypeDescriptorId] [INT] NULL,
    [SalaryAmount] [MONEY] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSalary_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSalary_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] --
CREATE TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] (
    [CredentialFieldDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [YearsExperience] [DECIMAL](5, 2) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSeniority_PK] PRIMARY KEY CLUSTERED (
        [CredentialFieldDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [NameOfInstitution] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSeniority_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffEducatorPreparationProgram] --
CREATE TABLE [tpdm].[StaffEducatorPreparationProgram] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducatorPreparationProgram_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducatorPreparationProgram] ADD CONSTRAINT [StaffEducatorPreparationProgram_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffEducatorPreparationProgramAssociation] --
CREATE TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [Completer] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffEducatorPreparationProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] ADD CONSTRAINT [StaffEducatorPreparationProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] ADD CONSTRAINT [StaffEducatorPreparationProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] ADD CONSTRAINT [StaffEducatorPreparationProgramAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[StaffEducatorResearch] --
CREATE TABLE [tpdm].[StaffEducatorResearch] (
    [StaffUSI] [INT] NOT NULL,
    [ResearchExperienceDate] [DATE] NOT NULL,
    [ResearchExperienceTitle] [NVARCHAR](60) NULL,
    [ResearchExperienceDescription] [NVARCHAR](1024) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducatorResearch_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffEducatorResearch] ADD CONSTRAINT [StaffEducatorResearch_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffExtension] --
CREATE TABLE [tpdm].[StaffExtension] (
    [StaffUSI] [INT] NOT NULL,
    [GenderDescriptorId] [INT] NULL,
    [RequisitionNumber] [NVARCHAR](20) NULL,
    [EducationOrganizationId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffExtension_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffExtension] ADD CONSTRAINT [StaffExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffHighlyQualifiedAcademicSubject] --
CREATE TABLE [tpdm].[StaffHighlyQualifiedAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffHighlyQualifiedAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffHighlyQualifiedAcademicSubject] ADD CONSTRAINT [StaffHighlyQualifiedAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffToCandidateRelationshipDescriptor] --
CREATE TABLE [tpdm].[StaffToCandidateRelationshipDescriptor] (
    [StaffToCandidateRelationshipDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StaffToCandidateRelationshipDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StaffToCandidateRelationshipDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[StateEducationAgencyExtension] --
CREATE TABLE [tpdm].[StateEducationAgencyExtension] (
    [StateEducationAgencyId] [INT] NOT NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StateEducationAgencyExtension_PK] PRIMARY KEY CLUSTERED (
        [StateEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StateEducationAgencyExtension] ADD CONSTRAINT [StateEducationAgencyExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StudentGradebookEntryExtension] --
CREATE TABLE [tpdm].[StudentGradebookEntryExtension] (
    [BeginDate] [DATE] NOT NULL,
    [DateAssigned] [DATE] NOT NULL,
    [GradebookEntryTitle] [NVARCHAR](60) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DateCompleted] [DATE] NULL,
    [AssignmentPassed] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentGradebookEntryExtension_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [DateAssigned] ASC,
        [GradebookEntryTitle] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StudentGradebookEntryExtension] ADD CONSTRAINT [StudentGradebookEntryExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [tpdm].[SurveySectionAggregateResponse] --
CREATE TABLE [tpdm].[SurveySectionAggregateResponse] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EvaluationDate] [DATE] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ScoreValue] [DECIMAL](6, 3) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySectionAggregateResponse_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [Namespace] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [SurveyIdentifier] ASC,
        [SurveySectionTitle] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SurveySectionAggregateResponse] ADD CONSTRAINT [SurveySectionAggregateResponse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[SurveySectionAggregateResponse] ADD CONSTRAINT [SurveySectionAggregateResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[SurveySectionAggregateResponse] ADD CONSTRAINT [SurveySectionAggregateResponse_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[SurveySectionExtension] --
CREATE TABLE [tpdm].[SurveySectionExtension] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NULL,
    [TermDescriptorId] [INT] NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [EvaluationPeriodDescriptorId] [INT] NULL,
    [EducationOrganizationId] [INT] NULL,
    [EvaluationTitle] [NVARCHAR](50) NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveySectionExtension_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveySectionTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SurveySectionExtension] ADD CONSTRAINT [SurveySectionExtension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [tpdm].[WithdrawReasonDescriptor] --
CREATE TABLE [tpdm].[WithdrawReasonDescriptor] (
    [WithdrawReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [WithdrawReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [WithdrawReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

