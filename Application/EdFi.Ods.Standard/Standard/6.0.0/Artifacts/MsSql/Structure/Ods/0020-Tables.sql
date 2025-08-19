-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table [edfi].[AbsenceEventCategoryDescriptor] --
CREATE TABLE [edfi].[AbsenceEventCategoryDescriptor] (
    [AbsenceEventCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AbsenceEventCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AbsenceEventCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AcademicHonorCategoryDescriptor] --
CREATE TABLE [edfi].[AcademicHonorCategoryDescriptor] (
    [AcademicHonorCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AcademicHonorCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AcademicHonorCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AcademicSubjectDescriptor] --
CREATE TABLE [edfi].[AcademicSubjectDescriptor] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AcademicSubjectDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AcademicWeek] --
CREATE TABLE [edfi].[AcademicWeek] (
    [SchoolId] [BIGINT] NOT NULL,
    [WeekIdentifier] [NVARCHAR](80) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NOT NULL,
    [TotalInstructionalDays] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AcademicWeek_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC,
        [WeekIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AcademicWeek] ADD CONSTRAINT [AcademicWeek_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AcademicWeek] ADD CONSTRAINT [AcademicWeek_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AcademicWeek] ADD CONSTRAINT [AcademicWeek_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AccommodationDescriptor] --
CREATE TABLE [edfi].[AccommodationDescriptor] (
    [AccommodationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AccommodationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AccommodationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AccountabilityRating] --
CREATE TABLE [edfi].[AccountabilityRating] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [RatingTitle] [NVARCHAR](60) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [Rating] [NVARCHAR](35) NOT NULL,
    [RatingDate] [DATE] NULL,
    [RatingOrganization] [NVARCHAR](35) NULL,
    [RatingProgram] [NVARCHAR](30) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AccountabilityRating_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RatingTitle] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AccountabilityRating] ADD CONSTRAINT [AccountabilityRating_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AccountabilityRating] ADD CONSTRAINT [AccountabilityRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AccountabilityRating] ADD CONSTRAINT [AccountabilityRating_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AccountTypeDescriptor] --
CREATE TABLE [edfi].[AccountTypeDescriptor] (
    [AccountTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AccountTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AccountTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AccreditationStatusDescriptor] --
CREATE TABLE [edfi].[AccreditationStatusDescriptor] (
    [AccreditationStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AccreditationStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AccreditationStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AchievementCategoryDescriptor] --
CREATE TABLE [edfi].[AchievementCategoryDescriptor] (
    [AchievementCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AchievementCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AchievementCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AdditionalCreditTypeDescriptor] --
CREATE TABLE [edfi].[AdditionalCreditTypeDescriptor] (
    [AdditionalCreditTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AdditionalCreditTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AdditionalCreditTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AddressTypeDescriptor] --
CREATE TABLE [edfi].[AddressTypeDescriptor] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AddressTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AdministrationEnvironmentDescriptor] --
CREATE TABLE [edfi].[AdministrationEnvironmentDescriptor] (
    [AdministrationEnvironmentDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AdministrationEnvironmentDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AdministrationEnvironmentDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AdministrativeFundingControlDescriptor] --
CREATE TABLE [edfi].[AdministrativeFundingControlDescriptor] (
    [AdministrativeFundingControlDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AdministrativeFundingControlDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AdministrativeFundingControlDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AidTypeDescriptor] --
CREATE TABLE [edfi].[AidTypeDescriptor] (
    [AidTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AidTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AidTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AncestryEthnicOriginDescriptor] --
CREATE TABLE [edfi].[AncestryEthnicOriginDescriptor] (
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AncestryEthnicOriginDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AncestryEthnicOriginDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ApplicantProfile] --
CREATE TABLE [edfi].[ApplicantProfile] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [BirthDate] [DATE] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [EconomicDisadvantaged] [BIT] NULL,
    [FirstGenerationStudent] [BIT] NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [HighestCompletedLevelOfEducationDescriptorId] [INT] NULL,
    [HighlyQualifiedTeacher] [BIT] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [PreferredFirstName] [NVARCHAR](75) NULL,
    [PreferredLastSurname] [NVARCHAR](75) NULL,
    [SexDescriptorId] [INT] NULL,
    [YearsOfPriorProfessionalExperience] [DECIMAL](5, 2) NULL,
    [YearsOfPriorTeachingExperience] [DECIMAL](5, 2) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ApplicantProfile_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfile] ADD CONSTRAINT [ApplicantProfile_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ApplicantProfile] ADD CONSTRAINT [ApplicantProfile_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ApplicantProfile] ADD CONSTRAINT [ApplicantProfile_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ApplicantProfileAddress] --
CREATE TABLE [edfi].[ApplicantProfileAddress] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileAddress_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileAddress] ADD CONSTRAINT [ApplicantProfileAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileAddressPeriod] --
CREATE TABLE [edfi].[ApplicantProfileAddressPeriod] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileAddressPeriod] ADD CONSTRAINT [ApplicantProfileAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileApplicantCharacteristic] --
CREATE TABLE [edfi].[ApplicantProfileApplicantCharacteristic] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileApplicantCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [StudentCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileApplicantCharacteristic] ADD CONSTRAINT [ApplicantProfileApplicantCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileBackgroundCheck] --
CREATE TABLE [edfi].[ApplicantProfileBackgroundCheck] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [BackgroundCheckTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileBackgroundCheck] ADD CONSTRAINT [ApplicantProfileBackgroundCheck_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileDisability] --
CREATE TABLE [edfi].[ApplicantProfileDisability] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileDisability_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileDisability] ADD CONSTRAINT [ApplicantProfileDisability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileDisabilityDesignation] --
CREATE TABLE [edfi].[ApplicantProfileDisabilityDesignation] (
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
ALTER TABLE [edfi].[ApplicantProfileDisabilityDesignation] ADD CONSTRAINT [ApplicantProfileDisabilityDesignation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileEducatorPreparationProgramName] --
CREATE TABLE [edfi].[ApplicantProfileEducatorPreparationProgramName] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [EducatorPreparationProgramName] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileEducatorPreparationProgramName_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [EducatorPreparationProgramName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileEducatorPreparationProgramName] ADD CONSTRAINT [ApplicantProfileEducatorPreparationProgramName_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileElectronicMail] --
CREATE TABLE [edfi].[ApplicantProfileElectronicMail] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileElectronicMail] ADD CONSTRAINT [ApplicantProfileElectronicMail_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileGradePointAverage] --
CREATE TABLE [edfi].[ApplicantProfileGradePointAverage] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [IsCumulative] [BIT] NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [GradePointAverageTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileGradePointAverage] ADD CONSTRAINT [ApplicantProfileGradePointAverage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileHighlyQualifiedAcademicSubject] --
CREATE TABLE [edfi].[ApplicantProfileHighlyQualifiedAcademicSubject] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileHighlyQualifiedAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileHighlyQualifiedAcademicSubject] ADD CONSTRAINT [ApplicantProfileHighlyQualifiedAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileIdentificationDocument] --
CREATE TABLE [edfi].[ApplicantProfileIdentificationDocument] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileIdentificationDocument] ADD CONSTRAINT [ApplicantProfileIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileInternationalAddress] --
CREATE TABLE [edfi].[ApplicantProfileInternationalAddress] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileInternationalAddress] ADD CONSTRAINT [ApplicantProfileInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileLanguage] --
CREATE TABLE [edfi].[ApplicantProfileLanguage] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileLanguage_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileLanguage] ADD CONSTRAINT [ApplicantProfileLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileLanguageUse] --
CREATE TABLE [edfi].[ApplicantProfileLanguageUse] (
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
ALTER TABLE [edfi].[ApplicantProfileLanguageUse] ADD CONSTRAINT [ApplicantProfileLanguageUse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfilePersonalIdentificationDocument] --
CREATE TABLE [edfi].[ApplicantProfilePersonalIdentificationDocument] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfilePersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfilePersonalIdentificationDocument] ADD CONSTRAINT [ApplicantProfilePersonalIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileRace] --
CREATE TABLE [edfi].[ApplicantProfileRace] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileRace_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileRace] ADD CONSTRAINT [ApplicantProfileRace_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileTelephone] --
CREATE TABLE [edfi].[ApplicantProfileTelephone] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileTelephone_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileTelephone] ADD CONSTRAINT [ApplicantProfileTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicantProfileVisa] --
CREATE TABLE [edfi].[ApplicantProfileVisa] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantProfileVisa_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicantProfileVisa] ADD CONSTRAINT [ApplicantProfileVisa_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[Application] --
CREATE TABLE [edfi].[Application] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [AcceptedDate] [DATE] NULL,
    [ApplicationDate] [DATE] NOT NULL,
    [ApplicationSourceDescriptorId] [INT] NULL,
    [ApplicationStatusDescriptorId] [INT] NOT NULL,
    [CurrentEmployee] [BIT] NULL,
    [FirstContactDate] [DATE] NULL,
    [HighNeedsAcademicSubjectDescriptorId] [INT] NULL,
    [HireStatusDescriptorId] [INT] NULL,
    [HiringSourceDescriptorId] [INT] NULL,
    [RequisitionNumber] [NVARCHAR](20) NULL,
    [WithdrawDate] [DATE] NULL,
    [WithdrawReasonDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[Application] ADD CONSTRAINT [Application_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Application] ADD CONSTRAINT [Application_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Application] ADD CONSTRAINT [Application_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ApplicationEvent] --
CREATE TABLE [edfi].[ApplicationEvent] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationEventTypeDescriptorId] [INT] NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [SequenceNumber] [INT] NOT NULL,
    [ApplicationEvaluationScore] [DECIMAL](36, 18) NULL,
    [ApplicationEventResultDescriptorId] [INT] NULL,
    [EventEndDate] [DATE] NULL,
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
ALTER TABLE [edfi].[ApplicationEvent] ADD CONSTRAINT [ApplicationEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ApplicationEvent] ADD CONSTRAINT [ApplicationEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ApplicationEvent] ADD CONSTRAINT [ApplicationEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ApplicationEventResultDescriptor] --
CREATE TABLE [edfi].[ApplicationEventResultDescriptor] (
    [ApplicationEventResultDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationEventResultDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationEventResultDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ApplicationEventTypeDescriptor] --
CREATE TABLE [edfi].[ApplicationEventTypeDescriptor] (
    [ApplicationEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ApplicationRecruitmentEventAttendance] --
CREATE TABLE [edfi].[ApplicationRecruitmentEventAttendance] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
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
ALTER TABLE [edfi].[ApplicationRecruitmentEventAttendance] ADD CONSTRAINT [ApplicationRecruitmentEventAttendance_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicationScoreResult] --
CREATE TABLE [edfi].[ApplicationScoreResult] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationScoreResult_PK] PRIMARY KEY CLUSTERED (
        [ApplicantProfileIdentifier] ASC,
        [ApplicationIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [AssessmentReportingMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ApplicationScoreResult] ADD CONSTRAINT [ApplicationScoreResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ApplicationSourceDescriptor] --
CREATE TABLE [edfi].[ApplicationSourceDescriptor] (
    [ApplicationSourceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationSourceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationSourceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ApplicationStatusDescriptor] --
CREATE TABLE [edfi].[ApplicationStatusDescriptor] (
    [ApplicationStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ApplicationStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ApplicationStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ApplicationTerm] --
CREATE TABLE [edfi].[ApplicationTerm] (
    [ApplicantProfileIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
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
ALTER TABLE [edfi].[ApplicationTerm] ADD CONSTRAINT [ApplicationTerm_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[Assessment] --
CREATE TABLE [edfi].[Assessment] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AdaptiveAssessment] [BIT] NULL,
    [AssessmentCategoryDescriptorId] [INT] NULL,
    [AssessmentFamily] [NVARCHAR](60) NULL,
    [AssessmentForm] [NVARCHAR](60) NULL,
    [AssessmentTitle] [NVARCHAR](255) NOT NULL,
    [AssessmentVersion] [INT] NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [MaxRawScore] [DECIMAL](15, 5) NULL,
    [Nomenclature] [NVARCHAR](100) NULL,
    [RevisionDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Assessment_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Assessment] ADD CONSTRAINT [Assessment_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Assessment] ADD CONSTRAINT [Assessment_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Assessment] ADD CONSTRAINT [Assessment_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentAcademicSubject] --
CREATE TABLE [edfi].[AssessmentAcademicSubject] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAcademicSubject] ADD CONSTRAINT [AssessmentAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentAdministration] --
CREATE TABLE [edfi].[AssessmentAdministration] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AssessmentAdministration_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAdministration] ADD CONSTRAINT [AssessmentAdministration_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AssessmentAdministration] ADD CONSTRAINT [AssessmentAdministration_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AssessmentAdministration] ADD CONSTRAINT [AssessmentAdministration_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentAdministrationAssessmentBatteryPart] --
CREATE TABLE [edfi].[AssessmentAdministrationAssessmentBatteryPart] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentBatteryPartName] [NVARCHAR](65) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentAdministrationAssessmentBatteryPart_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [Namespace] ASC,
        [AssessmentBatteryPartName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAdministrationAssessmentBatteryPart] ADD CONSTRAINT [AssessmentAdministrationAssessmentBatteryPart_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentAdministrationParticipation] --
CREATE TABLE [edfi].[AssessmentAdministrationParticipation] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ParticipatingEducationOrganizationId] [BIGINT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AssessmentAdministrationParticipation_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [Namespace] ASC,
        [ParticipatingEducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAdministrationParticipation] ADD CONSTRAINT [AssessmentAdministrationParticipation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AssessmentAdministrationParticipation] ADD CONSTRAINT [AssessmentAdministrationParticipation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AssessmentAdministrationParticipation] ADD CONSTRAINT [AssessmentAdministrationParticipation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentAdministrationParticipationAdministrationPointOfContact] --
CREATE TABLE [edfi].[AssessmentAdministrationParticipationAdministrationPointOfContact] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ParticipatingEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [LoginId] [NVARCHAR](120) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentAdministrationParticipationAdministrationPointOfContact_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [Namespace] ASC,
        [ParticipatingEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [ElectronicMailAddress] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAdministrationParticipationAdministrationPointOfContact] ADD CONSTRAINT [AssessmentAdministrationParticipationAdministrationPointOfContact_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentAdministrationPeriod] --
CREATE TABLE [edfi].[AssessmentAdministrationPeriod] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentAdministrationPeriod_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [Namespace] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAdministrationPeriod] ADD CONSTRAINT [AssessmentAdministrationPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentAssessedGradeLevel] --
CREATE TABLE [edfi].[AssessmentAssessedGradeLevel] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentAssessedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAssessedGradeLevel] ADD CONSTRAINT [AssessmentAssessedGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentBatteryPart] --
CREATE TABLE [edfi].[AssessmentBatteryPart] (
    [AssessmentBatteryPartName] [NVARCHAR](65) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AssessmentBatteryPart_PK] PRIMARY KEY CLUSTERED (
        [AssessmentBatteryPartName] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentBatteryPart] ADD CONSTRAINT [AssessmentBatteryPart_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AssessmentBatteryPart] ADD CONSTRAINT [AssessmentBatteryPart_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AssessmentBatteryPart] ADD CONSTRAINT [AssessmentBatteryPart_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentBatteryPartObjectiveAssessment] --
CREATE TABLE [edfi].[AssessmentBatteryPartObjectiveAssessment] (
    [AssessmentBatteryPartName] [NVARCHAR](65) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentBatteryPartObjectiveAssessment_PK] PRIMARY KEY CLUSTERED (
        [AssessmentBatteryPartName] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [IdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentBatteryPartObjectiveAssessment] ADD CONSTRAINT [AssessmentBatteryPartObjectiveAssessment_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentCategoryDescriptor] --
CREATE TABLE [edfi].[AssessmentCategoryDescriptor] (
    [AssessmentCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AssessmentCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AssessmentContentStandard] --
CREATE TABLE [edfi].[AssessmentContentStandard] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [MandatingEducationOrganizationId] [BIGINT] NULL,
    [PublicationDate] [DATE] NULL,
    [PublicationStatusDescriptorId] [INT] NULL,
    [PublicationYear] [SMALLINT] NULL,
    [Title] [NVARCHAR](100) NOT NULL,
    [URI] [NVARCHAR](255) NULL,
    [Version] [NVARCHAR](50) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentContentStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentContentStandard] ADD CONSTRAINT [AssessmentContentStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentContentStandardAuthor] --
CREATE TABLE [edfi].[AssessmentContentStandardAuthor] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Author] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentContentStandardAuthor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [Author] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentContentStandardAuthor] ADD CONSTRAINT [AssessmentContentStandardAuthor_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentIdentificationCode] --
CREATE TABLE [edfi].[AssessmentIdentificationCode] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](120) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [AssessmentIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentIdentificationCode] ADD CONSTRAINT [AssessmentIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[AssessmentIdentificationSystemDescriptor] (
    [AssessmentIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AssessmentIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AssessmentItem] --
CREATE TABLE [edfi].[AssessmentItem] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentItemCategoryDescriptorId] [INT] NULL,
    [AssessmentItemURI] [NVARCHAR](255) NULL,
    [ExpectedTimeAssessed] [NVARCHAR](30) NULL,
    [ItemText] [NVARCHAR](1024) NULL,
    [MaxRawScore] [DECIMAL](15, 5) NULL,
    [Nomenclature] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AssessmentItem_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentItem] ADD CONSTRAINT [AssessmentItem_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AssessmentItem] ADD CONSTRAINT [AssessmentItem_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AssessmentItem] ADD CONSTRAINT [AssessmentItem_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentItemCategoryDescriptor] --
CREATE TABLE [edfi].[AssessmentItemCategoryDescriptor] (
    [AssessmentItemCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AssessmentItemCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentItemCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AssessmentItemLearningStandard] --
CREATE TABLE [edfi].[AssessmentItemLearningStandard] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentItemLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentItemLearningStandard] ADD CONSTRAINT [AssessmentItemLearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentItemPossibleResponse] --
CREATE TABLE [edfi].[AssessmentItemPossibleResponse] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ResponseValue] [NVARCHAR](60) NOT NULL,
    [CorrectResponse] [BIT] NULL,
    [ResponseDescription] [NVARCHAR](1024) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentItemPossibleResponse_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [ResponseValue] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentItemPossibleResponse] ADD CONSTRAINT [AssessmentItemPossibleResponse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentItemResultDescriptor] --
CREATE TABLE [edfi].[AssessmentItemResultDescriptor] (
    [AssessmentItemResultDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AssessmentItemResultDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentItemResultDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AssessmentLanguage] --
CREATE TABLE [edfi].[AssessmentLanguage] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentLanguage_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentLanguage] ADD CONSTRAINT [AssessmentLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentPerformanceLevel] --
CREATE TABLE [edfi].[AssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [PerformanceLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentPerformanceLevel] ADD CONSTRAINT [AssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentPeriod] --
CREATE TABLE [edfi].[AssessmentPeriod] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentPeriodDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentPeriod_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [AssessmentPeriodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentPeriod] ADD CONSTRAINT [AssessmentPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentPeriodDescriptor] --
CREATE TABLE [edfi].[AssessmentPeriodDescriptor] (
    [AssessmentPeriodDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AssessmentPeriodDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentPeriodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AssessmentPlatformType] --
CREATE TABLE [edfi].[AssessmentPlatformType] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PlatformTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentPlatformType_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [PlatformTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentPlatformType] ADD CONSTRAINT [AssessmentPlatformType_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentProgram] --
CREATE TABLE [edfi].[AssessmentProgram] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentProgram_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentProgram] ADD CONSTRAINT [AssessmentProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentReportingMethodDescriptor] --
CREATE TABLE [edfi].[AssessmentReportingMethodDescriptor] (
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AssessmentReportingMethodDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentReportingMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AssessmentScore] --
CREATE TABLE [edfi].[AssessmentScore] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentScore_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [AssessmentReportingMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentScore] ADD CONSTRAINT [AssessmentScore_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentScoreRangeLearningStandard] --
CREATE TABLE [edfi].[AssessmentScoreRangeLearningStandard] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ScoreRangeId] [NVARCHAR](120) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NULL,
    [IdentificationCode] [NVARCHAR](120) NULL,
    [MaximumScore] [NVARCHAR](35) NOT NULL,
    [MinimumScore] [NVARCHAR](35) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AssessmentScoreRangeLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [ScoreRangeId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandard_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandard_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] --
CREATE TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ScoreRangeId] [NVARCHAR](120) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentScoreRangeLearningStandardLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [ScoreRangeId] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandardLearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentSection] --
CREATE TABLE [edfi].[AssessmentSection] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentSection_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentSection] ADD CONSTRAINT [AssessmentSection_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssignmentLateStatusDescriptor] --
CREATE TABLE [edfi].[AssignmentLateStatusDescriptor] (
    [AssignmentLateStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AssignmentLateStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AssignmentLateStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AttemptStatusDescriptor] --
CREATE TABLE [edfi].[AttemptStatusDescriptor] (
    [AttemptStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AttemptStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AttemptStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[AttendanceEventCategoryDescriptor] --
CREATE TABLE [edfi].[AttendanceEventCategoryDescriptor] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AttendanceEventCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AttendanceEventCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[BackgroundCheckStatusDescriptor] --
CREATE TABLE [edfi].[BackgroundCheckStatusDescriptor] (
    [BackgroundCheckStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [BackgroundCheckStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [BackgroundCheckStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[BackgroundCheckTypeDescriptor] --
CREATE TABLE [edfi].[BackgroundCheckTypeDescriptor] (
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [BackgroundCheckTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [BackgroundCheckTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[BalanceSheetDimension] --
CREATE TABLE [edfi].[BalanceSheetDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [BalanceSheetDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BalanceSheetDimension] ADD CONSTRAINT [BalanceSheetDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[BalanceSheetDimension] ADD CONSTRAINT [BalanceSheetDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[BalanceSheetDimension] ADD CONSTRAINT [BalanceSheetDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[BalanceSheetDimensionReportingTag] --
CREATE TABLE [edfi].[BalanceSheetDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [BalanceSheetDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BalanceSheetDimensionReportingTag] ADD CONSTRAINT [BalanceSheetDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[BarrierToInternetAccessInResidenceDescriptor] --
CREATE TABLE [edfi].[BarrierToInternetAccessInResidenceDescriptor] (
    [BarrierToInternetAccessInResidenceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [BarrierToInternetAccessInResidenceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [BarrierToInternetAccessInResidenceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[BehaviorDescriptor] --
CREATE TABLE [edfi].[BehaviorDescriptor] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    CONSTRAINT [BehaviorDescriptor_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[BellSchedule] --
CREATE TABLE [edfi].[BellSchedule] (
    [BellScheduleName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [AlternateDayName] [NVARCHAR](20) NULL,
    [EndTime] [TIME](7) NULL,
    [StartTime] [TIME](7) NULL,
    [TotalInstructionalTime] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [BellSchedule_PK] PRIMARY KEY CLUSTERED (
        [BellScheduleName] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BellSchedule] ADD CONSTRAINT [BellSchedule_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[BellSchedule] ADD CONSTRAINT [BellSchedule_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[BellSchedule] ADD CONSTRAINT [BellSchedule_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[BellScheduleClassPeriod] --
CREATE TABLE [edfi].[BellScheduleClassPeriod] (
    [BellScheduleName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [BellScheduleClassPeriod_PK] PRIMARY KEY CLUSTERED (
        [BellScheduleName] ASC,
        [SchoolId] ASC,
        [ClassPeriodName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BellScheduleClassPeriod] ADD CONSTRAINT [BellScheduleClassPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[BellScheduleDate] --
CREATE TABLE [edfi].[BellScheduleDate] (
    [BellScheduleName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [Date] [DATE] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [BellScheduleDate_PK] PRIMARY KEY CLUSTERED (
        [BellScheduleName] ASC,
        [SchoolId] ASC,
        [Date] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BellScheduleDate] ADD CONSTRAINT [BellScheduleDate_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[BellScheduleGradeLevel] --
CREATE TABLE [edfi].[BellScheduleGradeLevel] (
    [BellScheduleName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [BellScheduleGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [BellScheduleName] ASC,
        [SchoolId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BellScheduleGradeLevel] ADD CONSTRAINT [BellScheduleGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[BusRouteDescriptor] --
CREATE TABLE [edfi].[BusRouteDescriptor] (
    [BusRouteDescriptorId] [INT] NOT NULL,
    CONSTRAINT [BusRouteDescriptor_PK] PRIMARY KEY CLUSTERED (
        [BusRouteDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Calendar] --
CREATE TABLE [edfi].[Calendar] (
    [CalendarCode] [NVARCHAR](120) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CalendarTypeDescriptorId] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Calendar_PK] PRIMARY KEY CLUSTERED (
        [CalendarCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Calendar] ADD CONSTRAINT [Calendar_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Calendar] ADD CONSTRAINT [Calendar_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Calendar] ADD CONSTRAINT [Calendar_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CalendarDate] --
CREATE TABLE [edfi].[CalendarDate] (
    [CalendarCode] [NVARCHAR](120) NOT NULL,
    [Date] [DATE] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CalendarDate_PK] PRIMARY KEY CLUSTERED (
        [CalendarCode] ASC,
        [Date] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CalendarDate] ADD CONSTRAINT [CalendarDate_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CalendarDate] ADD CONSTRAINT [CalendarDate_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CalendarDate] ADD CONSTRAINT [CalendarDate_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CalendarDateCalendarEvent] --
CREATE TABLE [edfi].[CalendarDateCalendarEvent] (
    [CalendarCode] [NVARCHAR](120) NOT NULL,
    [Date] [DATE] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CalendarEventDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CalendarDateCalendarEvent_PK] PRIMARY KEY CLUSTERED (
        [CalendarCode] ASC,
        [Date] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [CalendarEventDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CalendarDateCalendarEvent] ADD CONSTRAINT [CalendarDateCalendarEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CalendarEventDescriptor] --
CREATE TABLE [edfi].[CalendarEventDescriptor] (
    [CalendarEventDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CalendarEventDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CalendarEventDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CalendarGradeLevel] --
CREATE TABLE [edfi].[CalendarGradeLevel] (
    [CalendarCode] [NVARCHAR](120) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CalendarGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CalendarCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CalendarGradeLevel] ADD CONSTRAINT [CalendarGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CalendarTypeDescriptor] --
CREATE TABLE [edfi].[CalendarTypeDescriptor] (
    [CalendarTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CalendarTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CalendarTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Candidate] --
CREATE TABLE [edfi].[Candidate] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BirthCity] [NVARCHAR](30) NULL,
    [BirthCountryDescriptorId] [INT] NULL,
    [BirthDate] [DATE] NOT NULL,
    [BirthInternationalProvince] [NVARCHAR](150) NULL,
    [BirthSexDescriptorId] [INT] NULL,
    [BirthStateAbbreviationDescriptorId] [INT] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [DateEnteredUS] [DATE] NULL,
    [DisplacementStatus] [NVARCHAR](30) NULL,
    [EconomicDisadvantaged] [BIT] NULL,
    [EnglishLanguageExamDescriptorId] [INT] NULL,
    [FirstGenerationStudent] [BIT] NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [LimitedEnglishProficiencyDescriptorId] [INT] NULL,
    [LoginId] [NVARCHAR](120) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [MultipleBirthStatus] [BIT] NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [PreferredFirstName] [NVARCHAR](75) NULL,
    [PreferredLastSurname] [NVARCHAR](75) NULL,
    [PreviousCareerDescriptorId] [INT] NULL,
    [ProfileThumbnail] [NVARCHAR](255) NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [TuitionCost] [DECIMAL](19, 4) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Candidate_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Candidate] ADD CONSTRAINT [Candidate_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Candidate] ADD CONSTRAINT [Candidate_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Candidate] ADD CONSTRAINT [Candidate_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CandidateAddress] --
CREATE TABLE [edfi].[CandidateAddress] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateAddress_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateAddress] ADD CONSTRAINT [CandidateAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateAddressPeriod] --
CREATE TABLE [edfi].[CandidateAddressPeriod] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateAddressPeriod] ADD CONSTRAINT [CandidateAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateBackgroundCheck] --
CREATE TABLE [edfi].[CandidateBackgroundCheck] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateBackgroundCheck] ADD CONSTRAINT [CandidateBackgroundCheck_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateCharacteristic] --
CREATE TABLE [edfi].[CandidateCharacteristic] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CandidateCharacteristicDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [CandidateCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateCharacteristic] ADD CONSTRAINT [CandidateCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateCharacteristicDescriptor] --
CREATE TABLE [edfi].[CandidateCharacteristicDescriptor] (
    [CandidateCharacteristicDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CandidateCharacteristicDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CandidateCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CandidateDisability] --
CREATE TABLE [edfi].[CandidateDisability] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateDisability_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateDisability] ADD CONSTRAINT [CandidateDisability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateDisabilityDesignation] --
CREATE TABLE [edfi].[CandidateDisabilityDesignation] (
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
ALTER TABLE [edfi].[CandidateDisabilityDesignation] ADD CONSTRAINT [CandidateDisabilityDesignation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateEducatorPreparationProgramAssociation] --
CREATE TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ApplicantProfileIdentifier] [NVARCHAR](32) NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NULL,
    [EndDate] [DATE] NULL,
    [EPPProgramPathwayDescriptorId] [INT] NULL,
    [ReasonExitedDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] --
CREATE TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [EndDate] [DATE] NULL,
    [Indicator] [NVARCHAR](60) NOT NULL,
    [IndicatorGroup] [NVARCHAR](200) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociationCandidateIndicator_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [IndicatorName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociationCandidateIndicator_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] --
CREATE TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CohortYearTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociationCohortYear_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [CohortYearTypeDescriptorId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociationCohortYear_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] --
CREATE TABLE [edfi].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] (
    [BeginDate] [DATE] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [MajorSpecialization] [NVARCHAR](255) NOT NULL,
    [EndDate] [DATE] NULL,
    [MinorSpecialization] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEducatorPreparationProgramAssociationDegreeSpecialization_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [MajorSpecialization] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] ADD CONSTRAINT [CandidateEducatorPreparationProgramAssociationDegreeSpecialization_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateElectronicMail] --
CREATE TABLE [edfi].[CandidateElectronicMail] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateElectronicMail] ADD CONSTRAINT [CandidateElectronicMail_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateEPPProgramDegree] --
CREATE TABLE [edfi].[CandidateEPPProgramDegree] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [EPPDegreeTypeDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateEPPProgramDegree_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [AcademicSubjectDescriptorId] ASC,
        [EPPDegreeTypeDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateEPPProgramDegree] ADD CONSTRAINT [CandidateEPPProgramDegree_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateIdentificationCode] --
CREATE TABLE [edfi].[CandidateIdentificationCode] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [AssigningOrganizationIdentificationCode] ASC,
        [IdentificationCode] ASC,
        [StudentIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateIdentificationCode] ADD CONSTRAINT [CandidateIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateIdentificationDocument] --
CREATE TABLE [edfi].[CandidateIdentificationDocument] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateIdentificationDocument] ADD CONSTRAINT [CandidateIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[CandidateIdentificationSystemDescriptor] (
    [CandidateIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CandidateIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CandidateIdentity] --
CREATE TABLE [edfi].[CandidateIdentity] (
    [CandidateIdentificationSystemDescriptorId] [INT] NOT NULL,
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CandidateIdentity_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentificationSystemDescriptorId] ASC,
        [CandidateIdentifier] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateIdentity] ADD CONSTRAINT [CandidateIdentity_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CandidateIdentity] ADD CONSTRAINT [CandidateIdentity_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CandidateIdentity] ADD CONSTRAINT [CandidateIdentity_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CandidateIndicator] --
CREATE TABLE [edfi].[CandidateIndicator] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [EndDate] [DATE] NULL,
    [Indicator] [NVARCHAR](60) NOT NULL,
    [IndicatorGroup] [NVARCHAR](200) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateIndicator_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [BeginDate] ASC,
        [IndicatorName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateIndicator] ADD CONSTRAINT [CandidateIndicator_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateInternationalAddress] --
CREATE TABLE [edfi].[CandidateInternationalAddress] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateInternationalAddress] ADD CONSTRAINT [CandidateInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateLanguage] --
CREATE TABLE [edfi].[CandidateLanguage] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateLanguage_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateLanguage] ADD CONSTRAINT [CandidateLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateLanguageUse] --
CREATE TABLE [edfi].[CandidateLanguageUse] (
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
ALTER TABLE [edfi].[CandidateLanguageUse] ADD CONSTRAINT [CandidateLanguageUse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateOtherName] --
CREATE TABLE [edfi].[CandidateOtherName] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateOtherName_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [OtherNameTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateOtherName] ADD CONSTRAINT [CandidateOtherName_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidatePersonalIdentificationDocument] --
CREATE TABLE [edfi].[CandidatePersonalIdentificationDocument] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidatePersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidatePersonalIdentificationDocument] ADD CONSTRAINT [CandidatePersonalIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateRace] --
CREATE TABLE [edfi].[CandidateRace] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateRace_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateRace] ADD CONSTRAINT [CandidateRace_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateRelationshipToStaffAssociation] --
CREATE TABLE [edfi].[CandidateRelationshipToStaffAssociation] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [StaffToCandidateRelationshipDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[CandidateRelationshipToStaffAssociation] ADD CONSTRAINT [CandidateRelationshipToStaffAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CandidateRelationshipToStaffAssociation] ADD CONSTRAINT [CandidateRelationshipToStaffAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CandidateRelationshipToStaffAssociation] ADD CONSTRAINT [CandidateRelationshipToStaffAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CandidateTelephone] --
CREATE TABLE [edfi].[CandidateTelephone] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateTelephone_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateTelephone] ADD CONSTRAINT [CandidateTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CandidateVisa] --
CREATE TABLE [edfi].[CandidateVisa] (
    [CandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CandidateVisa_PK] PRIMARY KEY CLUSTERED (
        [CandidateIdentifier] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CandidateVisa] ADD CONSTRAINT [CandidateVisa_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CareerPathwayDescriptor] --
CREATE TABLE [edfi].[CareerPathwayDescriptor] (
    [CareerPathwayDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CareerPathwayDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CareerPathwayDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Certification] --
CREATE TABLE [edfi].[Certification] (
    [CertificationIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CertificationFieldDescriptorId] [INT] NULL,
    [CertificationLevelDescriptorId] [INT] NULL,
    [CertificationStandardDescriptorId] [INT] NULL,
    [CertificationTitle] [NVARCHAR](64) NOT NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [EducatorRoleDescriptorId] [INT] NULL,
    [EffectiveDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [InstructionalSettingDescriptorId] [INT] NULL,
    [MinimumDegreeDescriptorId] [INT] NULL,
    [PopulationServedDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[Certification] ADD CONSTRAINT [Certification_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Certification] ADD CONSTRAINT [Certification_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Certification] ADD CONSTRAINT [Certification_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CertificationCertificationExam] --
CREATE TABLE [edfi].[CertificationCertificationExam] (
    [CertificationIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CertificationExamIdentifier] [NVARCHAR](120) NOT NULL,
    [CertificationExamNamespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CertificationCertificationExam_PK] PRIMARY KEY CLUSTERED (
        [CertificationIdentifier] ASC,
        [Namespace] ASC,
        [CertificationExamIdentifier] ASC,
        [CertificationExamNamespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CertificationCertificationExam] ADD CONSTRAINT [CertificationCertificationExam_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CertificationExam] --
CREATE TABLE [edfi].[CertificationExam] (
    [CertificationExamIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CertificationExamTitle] [NVARCHAR](60) NOT NULL,
    [CertificationExamTypeDescriptorId] [INT] NULL,
    [EducationOrganizationId] [BIGINT] NULL,
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
ALTER TABLE [edfi].[CertificationExam] ADD CONSTRAINT [CertificationExam_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CertificationExam] ADD CONSTRAINT [CertificationExam_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CertificationExam] ADD CONSTRAINT [CertificationExam_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CertificationExamResult] --
CREATE TABLE [edfi].[CertificationExamResult] (
    [CertificationExamDate] [DATE] NOT NULL,
    [CertificationExamIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [AttemptNumber] [INT] NULL,
    [CertificationExamAssessmentIdentifier] [NVARCHAR](120) NULL,
    [CertificationExamNamespace] [NVARCHAR](255) NULL,
    [CertificationExamPassIndicator] [BIT] NULL,
    [CertificationExamScore] [DECIMAL](6, 3) NULL,
    [CertificationExamStatusDescriptorId] [INT] NULL,
    [CertificationExamStudentAssessmentIdentifier] [NVARCHAR](120) NULL,
    [CertificationExamStudentUSI] [INT] NULL,
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
ALTER TABLE [edfi].[CertificationExamResult] ADD CONSTRAINT [CertificationExamResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CertificationExamResult] ADD CONSTRAINT [CertificationExamResult_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CertificationExamResult] ADD CONSTRAINT [CertificationExamResult_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CertificationExamStatusDescriptor] --
CREATE TABLE [edfi].[CertificationExamStatusDescriptor] (
    [CertificationExamStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationExamStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationExamStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CertificationExamTypeDescriptor] --
CREATE TABLE [edfi].[CertificationExamTypeDescriptor] (
    [CertificationExamTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationExamTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationExamTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CertificationFieldDescriptor] --
CREATE TABLE [edfi].[CertificationFieldDescriptor] (
    [CertificationFieldDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationFieldDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationFieldDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CertificationGradeLevel] --
CREATE TABLE [edfi].[CertificationGradeLevel] (
    [CertificationIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CertificationGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CertificationIdentifier] ASC,
        [Namespace] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CertificationGradeLevel] ADD CONSTRAINT [CertificationGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CertificationLevelDescriptor] --
CREATE TABLE [edfi].[CertificationLevelDescriptor] (
    [CertificationLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CertificationRoute] --
CREATE TABLE [edfi].[CertificationRoute] (
    [CertificationIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CertificationRouteDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CertificationRoute_PK] PRIMARY KEY CLUSTERED (
        [CertificationIdentifier] ASC,
        [Namespace] ASC,
        [CertificationRouteDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CertificationRoute] ADD CONSTRAINT [CertificationRoute_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CertificationRouteDescriptor] --
CREATE TABLE [edfi].[CertificationRouteDescriptor] (
    [CertificationRouteDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationRouteDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationRouteDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CertificationStandardDescriptor] --
CREATE TABLE [edfi].[CertificationStandardDescriptor] (
    [CertificationStandardDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CertificationStandardDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CertificationStandardDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CharterApprovalAgencyTypeDescriptor] --
CREATE TABLE [edfi].[CharterApprovalAgencyTypeDescriptor] (
    [CharterApprovalAgencyTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CharterApprovalAgencyTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CharterApprovalAgencyTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CharterStatusDescriptor] --
CREATE TABLE [edfi].[CharterStatusDescriptor] (
    [CharterStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CharterStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CharterStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ChartOfAccount] --
CREATE TABLE [edfi].[ChartOfAccount] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [AccountName] [NVARCHAR](100) NULL,
    [AccountTypeDescriptorId] [INT] NOT NULL,
    [BalanceSheetCode] [NVARCHAR](16) NULL,
    [FunctionCode] [NVARCHAR](16) NULL,
    [FundCode] [NVARCHAR](16) NULL,
    [ObjectCode] [NVARCHAR](16) NULL,
    [OperationalUnitCode] [NVARCHAR](16) NULL,
    [ProgramCode] [NVARCHAR](16) NULL,
    [ProjectCode] [NVARCHAR](16) NULL,
    [SourceCode] [NVARCHAR](16) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ChartOfAccount_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ChartOfAccount] ADD CONSTRAINT [ChartOfAccount_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ChartOfAccount] ADD CONSTRAINT [ChartOfAccount_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ChartOfAccount] ADD CONSTRAINT [ChartOfAccount_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ChartOfAccountReportingTag] --
CREATE TABLE [edfi].[ChartOfAccountReportingTag] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [TagValue] [NVARCHAR](100) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ChartOfAccountReportingTag_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ChartOfAccountReportingTag] ADD CONSTRAINT [ChartOfAccountReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CitizenshipStatusDescriptor] --
CREATE TABLE [edfi].[CitizenshipStatusDescriptor] (
    [CitizenshipStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CitizenshipStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CitizenshipStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ClassPeriod] --
CREATE TABLE [edfi].[ClassPeriod] (
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [OfficialAttendancePeriod] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ClassPeriod_PK] PRIMARY KEY CLUSTERED (
        [ClassPeriodName] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ClassPeriod] ADD CONSTRAINT [ClassPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ClassPeriod] ADD CONSTRAINT [ClassPeriod_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ClassPeriod] ADD CONSTRAINT [ClassPeriod_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ClassPeriodMeetingTime] --
CREATE TABLE [edfi].[ClassPeriodMeetingTime] (
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [EndTime] [TIME](7) NOT NULL,
    [StartTime] [TIME](7) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ClassPeriodMeetingTime_PK] PRIMARY KEY CLUSTERED (
        [ClassPeriodName] ASC,
        [SchoolId] ASC,
        [EndTime] ASC,
        [StartTime] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ClassPeriodMeetingTime] ADD CONSTRAINT [ClassPeriodMeetingTime_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ClassroomPositionDescriptor] --
CREATE TABLE [edfi].[ClassroomPositionDescriptor] (
    [ClassroomPositionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ClassroomPositionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ClassroomPositionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Cohort] --
CREATE TABLE [edfi].[Cohort] (
    [CohortIdentifier] [NVARCHAR](36) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [CohortDescription] [NVARCHAR](1024) NULL,
    [CohortScopeDescriptorId] [INT] NULL,
    [CohortTypeDescriptorId] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Cohort_PK] PRIMARY KEY CLUSTERED (
        [CohortIdentifier] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Cohort] ADD CONSTRAINT [Cohort_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Cohort] ADD CONSTRAINT [Cohort_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Cohort] ADD CONSTRAINT [Cohort_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CohortProgram] --
CREATE TABLE [edfi].[CohortProgram] (
    [CohortIdentifier] [NVARCHAR](36) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CohortProgram_PK] PRIMARY KEY CLUSTERED (
        [CohortIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CohortProgram] ADD CONSTRAINT [CohortProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CohortScopeDescriptor] --
CREATE TABLE [edfi].[CohortScopeDescriptor] (
    [CohortScopeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CohortScopeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CohortScopeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CohortTypeDescriptor] --
CREATE TABLE [edfi].[CohortTypeDescriptor] (
    [CohortTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CohortTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CohortTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CohortYearTypeDescriptor] --
CREATE TABLE [edfi].[CohortYearTypeDescriptor] (
    [CohortYearTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CohortYearTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CohortYearTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CommunityOrganization] --
CREATE TABLE [edfi].[CommunityOrganization] (
    [CommunityOrganizationId] [BIGINT] NOT NULL,
    CONSTRAINT [CommunityOrganization_PK] PRIMARY KEY CLUSTERED (
        [CommunityOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CommunityProvider] --
CREATE TABLE [edfi].[CommunityProvider] (
    [CommunityProviderId] [BIGINT] NOT NULL,
    [CommunityOrganizationId] [BIGINT] NULL,
    [LicenseExemptIndicator] [BIT] NULL,
    [ProviderCategoryDescriptorId] [INT] NOT NULL,
    [ProviderProfitabilityDescriptorId] [INT] NULL,
    [ProviderStatusDescriptorId] [INT] NOT NULL,
    [SchoolIndicator] [BIT] NULL,
    CONSTRAINT [CommunityProvider_PK] PRIMARY KEY CLUSTERED (
        [CommunityProviderId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CommunityProviderLicense] --
CREATE TABLE [edfi].[CommunityProviderLicense] (
    [CommunityProviderId] [BIGINT] NOT NULL,
    [LicenseIdentifier] [NVARCHAR](36) NOT NULL,
    [LicensingOrganization] [NVARCHAR](75) NOT NULL,
    [AuthorizedFacilityCapacity] [INT] NULL,
    [LicenseEffectiveDate] [DATE] NOT NULL,
    [LicenseExpirationDate] [DATE] NULL,
    [LicenseIssueDate] [DATE] NULL,
    [LicenseStatusDescriptorId] [INT] NULL,
    [LicenseTypeDescriptorId] [INT] NOT NULL,
    [OldestAgeAuthorizedToServe] [INT] NULL,
    [YoungestAgeAuthorizedToServe] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CommunityProviderLicense_PK] PRIMARY KEY CLUSTERED (
        [CommunityProviderId] ASC,
        [LicenseIdentifier] ASC,
        [LicensingOrganization] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CommunityProviderLicense] ADD CONSTRAINT [CommunityProviderLicense_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CommunityProviderLicense] ADD CONSTRAINT [CommunityProviderLicense_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CommunityProviderLicense] ADD CONSTRAINT [CommunityProviderLicense_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CompetencyLevelDescriptor] --
CREATE TABLE [edfi].[CompetencyLevelDescriptor] (
    [CompetencyLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CompetencyLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CompetencyLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CompetencyObjective] --
CREATE TABLE [edfi].[CompetencyObjective] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [CompetencyObjectiveId] [NVARCHAR](120) NULL,
    [Description] [NVARCHAR](1024) NULL,
    [SuccessCriteria] [NVARCHAR](150) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CompetencyObjective_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [Objective] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CompetencyObjective] ADD CONSTRAINT [CompetencyObjective_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CompetencyObjective] ADD CONSTRAINT [CompetencyObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CompetencyObjective] ADD CONSTRAINT [CompetencyObjective_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[Contact] --
CREATE TABLE [edfi].[Contact] (
    [ContactUSI] [INT] IDENTITY(1,1) NOT NULL,
    [ContactUniqueId] [NVARCHAR](32) NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [HighestCompletedLevelOfEducationDescriptorId] [INT] NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [LoginId] [NVARCHAR](120) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [PreferredFirstName] [NVARCHAR](75) NULL,
    [PreferredLastSurname] [NVARCHAR](75) NULL,
    [SexDescriptorId] [INT] NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Contact_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Contact_UI_ContactUniqueId] ON [edfi].[Contact] (
    [ContactUniqueId] ASC
) INCLUDE (ContactUSI) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Contact] ADD CONSTRAINT [Contact_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Contact] ADD CONSTRAINT [Contact_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Contact] ADD CONSTRAINT [Contact_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ContactAddress] --
CREATE TABLE [edfi].[ContactAddress] (
    [ContactUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactAddress_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactAddress] ADD CONSTRAINT [ContactAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactAddressPeriod] --
CREATE TABLE [edfi].[ContactAddressPeriod] (
    [ContactUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactAddressPeriod] ADD CONSTRAINT [ContactAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactElectronicMail] --
CREATE TABLE [edfi].[ContactElectronicMail] (
    [ContactUSI] [INT] NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactElectronicMail] ADD CONSTRAINT [ContactElectronicMail_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[ContactIdentificationSystemDescriptor] (
    [ContactIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ContactIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ContactIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ContactIdentity] --
CREATE TABLE [edfi].[ContactIdentity] (
    [ContactIdentificationSystemDescriptorId] [INT] NOT NULL,
    [ContactUSI] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ContactIdentity_PK] PRIMARY KEY CLUSTERED (
        [ContactIdentificationSystemDescriptorId] ASC,
        [ContactUSI] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactIdentity] ADD CONSTRAINT [ContactIdentity_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ContactIdentity] ADD CONSTRAINT [ContactIdentity_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ContactIdentity] ADD CONSTRAINT [ContactIdentity_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ContactInternationalAddress] --
CREATE TABLE [edfi].[ContactInternationalAddress] (
    [ContactUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactInternationalAddress] ADD CONSTRAINT [ContactInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactLanguage] --
CREATE TABLE [edfi].[ContactLanguage] (
    [ContactUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactLanguage_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactLanguage] ADD CONSTRAINT [ContactLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactLanguageUse] --
CREATE TABLE [edfi].[ContactLanguageUse] (
    [ContactUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactLanguageUse] ADD CONSTRAINT [ContactLanguageUse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactOtherName] --
CREATE TABLE [edfi].[ContactOtherName] (
    [ContactUSI] [INT] NOT NULL,
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactOtherName_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [OtherNameTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactOtherName] ADD CONSTRAINT [ContactOtherName_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactPersonalIdentificationDocument] --
CREATE TABLE [edfi].[ContactPersonalIdentificationDocument] (
    [ContactUSI] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] ADD CONSTRAINT [ContactPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactTelephone] --
CREATE TABLE [edfi].[ContactTelephone] (
    [ContactUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ContactTelephone_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ContactTelephone] ADD CONSTRAINT [ContactTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ContactTypeDescriptor] --
CREATE TABLE [edfi].[ContactTypeDescriptor] (
    [ContactTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ContactTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ContactTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ContentClassDescriptor] --
CREATE TABLE [edfi].[ContentClassDescriptor] (
    [ContentClassDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ContentClassDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ContentClassDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ContinuationOfServicesReasonDescriptor] --
CREATE TABLE [edfi].[ContinuationOfServicesReasonDescriptor] (
    [ContinuationOfServicesReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ContinuationOfServicesReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ContinuationOfServicesReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CostRateDescriptor] --
CREATE TABLE [edfi].[CostRateDescriptor] (
    [CostRateDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CostRateDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CostRateDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CoteachingStyleObservedDescriptor] --
CREATE TABLE [edfi].[CoteachingStyleObservedDescriptor] (
    [CoteachingStyleObservedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CoteachingStyleObservedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CoteachingStyleObservedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CountryDescriptor] --
CREATE TABLE [edfi].[CountryDescriptor] (
    [CountryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CountryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CountryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Course] --
CREATE TABLE [edfi].[Course] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [CareerPathwayDescriptorId] [INT] NULL,
    [CourseDefinedByDescriptorId] [INT] NULL,
    [CourseDescription] [NVARCHAR](1024) NULL,
    [CourseGPAApplicabilityDescriptorId] [INT] NULL,
    [CourseTitle] [NVARCHAR](120) NOT NULL,
    [DateCourseAdopted] [DATE] NULL,
    [HighSchoolCourseRequirement] [BIT] NULL,
    [MaxCompletionsForCredit] [INT] NULL,
    [MaximumAvailableCreditConversion] [DECIMAL](9, 2) NULL,
    [MaximumAvailableCredits] [DECIMAL](9, 3) NULL,
    [MaximumAvailableCreditTypeDescriptorId] [INT] NULL,
    [MinimumAvailableCreditConversion] [DECIMAL](9, 2) NULL,
    [MinimumAvailableCredits] [DECIMAL](9, 3) NULL,
    [MinimumAvailableCreditTypeDescriptorId] [INT] NULL,
    [NumberOfParts] [INT] NOT NULL,
    [TimeRequiredForCompletion] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Course_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Course] ADD CONSTRAINT [Course_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Course] ADD CONSTRAINT [Course_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Course] ADD CONSTRAINT [Course_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CourseAcademicSubject] --
CREATE TABLE [edfi].[CourseAcademicSubject] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseAcademicSubject] ADD CONSTRAINT [CourseAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseAttemptResultDescriptor] --
CREATE TABLE [edfi].[CourseAttemptResultDescriptor] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CourseAttemptResultDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CourseCompetencyLevel] --
CREATE TABLE [edfi].[CourseCompetencyLevel] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [CompetencyLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseCompetencyLevel_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [CompetencyLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseCompetencyLevel] ADD CONSTRAINT [CourseCompetencyLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseDefinedByDescriptor] --
CREATE TABLE [edfi].[CourseDefinedByDescriptor] (
    [CourseDefinedByDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CourseDefinedByDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CourseDefinedByDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CourseGPAApplicabilityDescriptor] --
CREATE TABLE [edfi].[CourseGPAApplicabilityDescriptor] (
    [CourseGPAApplicabilityDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CourseGPAApplicabilityDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CourseGPAApplicabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CourseIdentificationCode] --
CREATE TABLE [edfi].[CourseIdentificationCode] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [CourseIdentificationSystemDescriptorId] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](120) NULL,
    [CourseCatalogURL] [NVARCHAR](255) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [CourseIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseIdentificationCode] ADD CONSTRAINT [CourseIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[CourseIdentificationSystemDescriptor] (
    [CourseIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CourseIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CourseIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CourseLearningStandard] --
CREATE TABLE [edfi].[CourseLearningStandard] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseLearningStandard] ADD CONSTRAINT [CourseLearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseLevelCharacteristic] --
CREATE TABLE [edfi].[CourseLevelCharacteristic] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [CourseLevelCharacteristicDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseLevelCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [CourseLevelCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseLevelCharacteristic] ADD CONSTRAINT [CourseLevelCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseLevelCharacteristicDescriptor] --
CREATE TABLE [edfi].[CourseLevelCharacteristicDescriptor] (
    [CourseLevelCharacteristicDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CourseLevelCharacteristicDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CourseLevelCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CourseOfferedGradeLevel] --
CREATE TABLE [edfi].[CourseOfferedGradeLevel] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferedGradeLevel] ADD CONSTRAINT [CourseOfferedGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseOffering] --
CREATE TABLE [edfi].[CourseOffering] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InstructionalTimePlanned] [INT] NULL,
    [LocalCourseTitle] [NVARCHAR](120) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CourseOffering_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOffering] ADD CONSTRAINT [CourseOffering_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CourseOffering] ADD CONSTRAINT [CourseOffering_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CourseOffering] ADD CONSTRAINT [CourseOffering_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CourseOfferingCourseLevelCharacteristic] --
CREATE TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CourseLevelCharacteristicDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferingCourseLevelCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC,
        [CourseLevelCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] ADD CONSTRAINT [CourseOfferingCourseLevelCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseOfferingCurriculumUsed] --
CREATE TABLE [edfi].[CourseOfferingCurriculumUsed] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CurriculumUsedDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferingCurriculumUsed_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC,
        [CurriculumUsedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] ADD CONSTRAINT [CourseOfferingCurriculumUsed_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseOfferingOfferedGradeLevel] --
CREATE TABLE [edfi].[CourseOfferingOfferedGradeLevel] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferingOfferedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] ADD CONSTRAINT [CourseOfferingOfferedGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseRepeatCodeDescriptor] --
CREATE TABLE [edfi].[CourseRepeatCodeDescriptor] (
    [CourseRepeatCodeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CourseRepeatCodeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CourseRepeatCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CourseTranscript] --
CREATE TABLE [edfi].[CourseTranscript] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AlternativeCourseTitle] [NVARCHAR](120) NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](120) NULL,
    [AttemptedCreditConversion] [DECIMAL](9, 2) NULL,
    [AttemptedCredits] [DECIMAL](9, 3) NULL,
    [AttemptedCreditTypeDescriptorId] [INT] NULL,
    [CourseCatalogURL] [NVARCHAR](255) NULL,
    [CourseRepeatCodeDescriptorId] [INT] NULL,
    [CourseTitle] [NVARCHAR](120) NULL,
    [EarnedCreditConversion] [DECIMAL](9, 2) NULL,
    [EarnedCredits] [DECIMAL](9, 3) NULL,
    [EarnedCreditTypeDescriptorId] [INT] NULL,
    [ExternalEducationOrganizationId] [BIGINT] NULL,
    [ExternalEducationOrganizationNameOfInstitution] [NVARCHAR](75) NULL,
    [FinalLetterGradeEarned] [NVARCHAR](20) NULL,
    [FinalNumericGradeEarned] [DECIMAL](9, 2) NULL,
    [MethodCreditEarnedDescriptorId] [INT] NULL,
    [ResponsibleTeacherStaffUSI] [INT] NULL,
    [WhenTakenGradeLevelDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CourseTranscript_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscript] ADD CONSTRAINT [CourseTranscript_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CourseTranscript] ADD CONSTRAINT [CourseTranscript_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CourseTranscript] ADD CONSTRAINT [CourseTranscript_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CourseTranscriptAcademicSubject] --
CREATE TABLE [edfi].[CourseTranscriptAcademicSubject] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptAcademicSubject] ADD CONSTRAINT [CourseTranscriptAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] --
CREATE TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CourseIdentificationSystemDescriptorId] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](120) NULL,
    [CourseCatalogURL] [NVARCHAR](255) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptAlternativeCourseIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [CourseIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] ADD CONSTRAINT [CourseTranscriptAlternativeCourseIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptCourseProgram] --
CREATE TABLE [edfi].[CourseTranscriptCourseProgram] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CourseProgramName] [NVARCHAR](60) NOT NULL,
    [CourseProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptCourseProgram_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [CourseProgramName] ASC,
        [CourseProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptCourseProgram] ADD CONSTRAINT [CourseTranscriptCourseProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptCreditCategory] --
CREATE TABLE [edfi].[CourseTranscriptCreditCategory] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreditCategoryDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptCreditCategory_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [CreditCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptCreditCategory] ADD CONSTRAINT [CourseTranscriptCreditCategory_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptEarnedAdditionalCredits] --
CREATE TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AdditionalCreditTypeDescriptorId] [INT] NOT NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptEarnedAdditionalCredits_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [AdditionalCreditTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] ADD CONSTRAINT [CourseTranscriptEarnedAdditionalCredits_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptPartialCourseTranscriptAwards] --
CREATE TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AwardDate] [DATE] NOT NULL,
    [EarnedCredits] [DECIMAL](9, 3) NOT NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [MethodCreditEarnedDescriptorId] [INT] NULL,
    [NumericGradeEarned] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptPartialCourseTranscriptAwards_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [AwardDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] ADD CONSTRAINT [CourseTranscriptPartialCourseTranscriptAwards_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptSection] --
CREATE TABLE [edfi].[CourseTranscriptSection] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptSection_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptSection] ADD CONSTRAINT [CourseTranscriptSection_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[Credential] --
CREATE TABLE [edfi].[Credential] (
    [CredentialIdentifier] [NVARCHAR](120) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [BoardCertificationIndicator] [BIT] NULL,
    [CertificationIdentifier] [NVARCHAR](120) NULL,
    [CertificationRouteDescriptorId] [INT] NULL,
    [CertificationTitle] [NVARCHAR](64) NULL,
    [CredentialFieldDescriptorId] [INT] NULL,
    [CredentialStatusDate] [DATE] NULL,
    [CredentialStatusDescriptorId] [INT] NULL,
    [CredentialTypeDescriptorId] [INT] NOT NULL,
    [EducatorRoleDescriptorId] [INT] NULL,
    [EffectiveDate] [DATE] NULL,
    [ExpirationDate] [DATE] NULL,
    [IssuanceDate] [DATE] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [TeachingCredentialBasisDescriptorId] [INT] NULL,
    [TeachingCredentialDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Credential_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Credential] ADD CONSTRAINT [Credential_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Credential] ADD CONSTRAINT [Credential_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Credential] ADD CONSTRAINT [Credential_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CredentialAcademicSubject] --
CREATE TABLE [edfi].[CredentialAcademicSubject] (
    [CredentialIdentifier] [NVARCHAR](120) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CredentialAcademicSubject] ADD CONSTRAINT [CredentialAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CredentialEndorsement] --
CREATE TABLE [edfi].[CredentialEndorsement] (
    [CredentialIdentifier] [NVARCHAR](120) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [CredentialEndorsement] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialEndorsement_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC,
        [CredentialEndorsement] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CredentialEndorsement] ADD CONSTRAINT [CredentialEndorsement_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CredentialEvent] --
CREATE TABLE [edfi].[CredentialEvent] (
    [CredentialEventDate] [DATE] NOT NULL,
    [CredentialEventTypeDescriptorId] [INT] NOT NULL,
    [CredentialIdentifier] [NVARCHAR](120) NOT NULL,
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
ALTER TABLE [edfi].[CredentialEvent] ADD CONSTRAINT [CredentialEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CredentialEvent] ADD CONSTRAINT [CredentialEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CredentialEvent] ADD CONSTRAINT [CredentialEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CredentialEventTypeDescriptor] --
CREATE TABLE [edfi].[CredentialEventTypeDescriptor] (
    [CredentialEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CredentialEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CredentialEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CredentialFieldDescriptor] --
CREATE TABLE [edfi].[CredentialFieldDescriptor] (
    [CredentialFieldDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CredentialFieldDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CredentialFieldDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CredentialGradeLevel] --
CREATE TABLE [edfi].[CredentialGradeLevel] (
    [CredentialIdentifier] [NVARCHAR](120) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CredentialGradeLevel] ADD CONSTRAINT [CredentialGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CredentialStatusDescriptor] --
CREATE TABLE [edfi].[CredentialStatusDescriptor] (
    [CredentialStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CredentialStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CredentialStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CredentialStudentAcademicRecord] --
CREATE TABLE [edfi].[CredentialStudentAcademicRecord] (
    [CredentialIdentifier] [NVARCHAR](120) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialStudentAcademicRecord_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CredentialStudentAcademicRecord] ADD CONSTRAINT [CredentialStudentAcademicRecord_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[CredentialTypeDescriptor] --
CREATE TABLE [edfi].[CredentialTypeDescriptor] (
    [CredentialTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CredentialTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CredentialTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CreditCategoryDescriptor] --
CREATE TABLE [edfi].[CreditCategoryDescriptor] (
    [CreditCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CreditCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CreditCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CreditTypeDescriptor] --
CREATE TABLE [edfi].[CreditTypeDescriptor] (
    [CreditTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CreditTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CreditTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CrisisEvent] --
CREATE TABLE [edfi].[CrisisEvent] (
    [CrisisEventName] [NVARCHAR](100) NOT NULL,
    [CrisisDescription] [NVARCHAR](1024) NULL,
    [CrisisEndDate] [DATE] NULL,
    [CrisisStartDate] [DATE] NULL,
    [CrisisTypeDescriptorId] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CrisisEvent_PK] PRIMARY KEY CLUSTERED (
        [CrisisEventName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CrisisEvent] ADD CONSTRAINT [CrisisEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CrisisEvent] ADD CONSTRAINT [CrisisEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CrisisEvent] ADD CONSTRAINT [CrisisEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CrisisTypeDescriptor] --
CREATE TABLE [edfi].[CrisisTypeDescriptor] (
    [CrisisTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CrisisTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CrisisTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CTEProgramServiceDescriptor] --
CREATE TABLE [edfi].[CTEProgramServiceDescriptor] (
    [CTEProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CTEProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CTEProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CurriculumUsedDescriptor] --
CREATE TABLE [edfi].[CurriculumUsedDescriptor] (
    [CurriculumUsedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CurriculumUsedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CurriculumUsedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DegreeDescriptor] --
CREATE TABLE [edfi].[DegreeDescriptor] (
    [DegreeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DegreeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DegreeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DeliveryMethodDescriptor] --
CREATE TABLE [edfi].[DeliveryMethodDescriptor] (
    [DeliveryMethodDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DeliveryMethodDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DeliveryMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Descriptor] --
CREATE TABLE [edfi].[Descriptor] (
    [DescriptorId] [INT] IDENTITY(1,1) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CodeValue] [NVARCHAR](50) NOT NULL,
    [ShortDescription] [NVARCHAR](75) NOT NULL,
    [Description] [NVARCHAR](1024) NULL,
    [PriorDescriptorId] [INT] NULL,
    [EffectiveBeginDate] [DATE] NULL,
    [EffectiveEndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [Uri] AS CONCAT(Namespace, '#', CodeValue) PERSISTED NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Descriptor_PK] PRIMARY KEY CLUSTERED (
        [DescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
    CONSTRAINT [Descriptor_AK] UNIQUE NONCLUSTERED (
        [Namespace] ASC,
        [CodeValue] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Descriptor] ADD CONSTRAINT [Descriptor_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Descriptor] ADD CONSTRAINT [Descriptor_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Descriptor] ADD CONSTRAINT [Descriptor_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO
CREATE UNIQUE INDEX UX_Descriptor_Uri ON [edfi].[Descriptor] (Uri) INCLUDE (DescriptorId, Discriminator)
GO

-- Table [edfi].[DescriptorMapping] --
CREATE TABLE [edfi].[DescriptorMapping] (
    [MappedNamespace] [NVARCHAR](255) NOT NULL,
    [MappedValue] [NVARCHAR](50) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Value] [NVARCHAR](50) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [DescriptorMapping_PK] PRIMARY KEY CLUSTERED (
        [MappedNamespace] ASC,
        [MappedValue] ASC,
        [Namespace] ASC,
        [Value] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DescriptorMapping] ADD CONSTRAINT [DescriptorMapping_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[DescriptorMapping] ADD CONSTRAINT [DescriptorMapping_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[DescriptorMapping] ADD CONSTRAINT [DescriptorMapping_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[DescriptorMappingModelEntity] --
CREATE TABLE [edfi].[DescriptorMappingModelEntity] (
    [MappedNamespace] [NVARCHAR](255) NOT NULL,
    [MappedValue] [NVARCHAR](50) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Value] [NVARCHAR](50) NOT NULL,
    [ModelEntityDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DescriptorMappingModelEntity_PK] PRIMARY KEY CLUSTERED (
        [MappedNamespace] ASC,
        [MappedValue] ASC,
        [Namespace] ASC,
        [Value] ASC,
        [ModelEntityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DescriptorMappingModelEntity] ADD CONSTRAINT [DescriptorMappingModelEntity_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[DiagnosisDescriptor] --
CREATE TABLE [edfi].[DiagnosisDescriptor] (
    [DiagnosisDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DiagnosisDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DiagnosisDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DiplomaLevelDescriptor] --
CREATE TABLE [edfi].[DiplomaLevelDescriptor] (
    [DiplomaLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DiplomaLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DiplomaLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DiplomaTypeDescriptor] --
CREATE TABLE [edfi].[DiplomaTypeDescriptor] (
    [DiplomaTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DiplomaTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DiplomaTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DisabilityDescriptor] --
CREATE TABLE [edfi].[DisabilityDescriptor] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DisabilityDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DisabilityDesignationDescriptor] --
CREATE TABLE [edfi].[DisabilityDesignationDescriptor] (
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DisabilityDesignationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DisabilityDeterminationSourceTypeDescriptor] --
CREATE TABLE [edfi].[DisabilityDeterminationSourceTypeDescriptor] (
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DisabilityDeterminationSourceTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDeterminationSourceTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DisciplineAction] --
CREATE TABLE [edfi].[DisciplineAction] (
    [DisciplineActionIdentifier] [NVARCHAR](36) NOT NULL,
    [DisciplineDate] [DATE] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ActualDisciplineActionLength] [DECIMAL](5, 2) NULL,
    [AssignmentSchoolId] [BIGINT] NULL,
    [DisciplineActionLength] [DECIMAL](5, 2) NULL,
    [DisciplineActionLengthDifferenceReasonDescriptorId] [INT] NULL,
    [IEPPlacementMeetingIndicator] [BIT] NULL,
    [RelatedToZeroTolerancePolicy] [BIT] NULL,
    [ResponsibilitySchoolId] [BIGINT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [DisciplineAction_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineAction] ADD CONSTRAINT [DisciplineAction_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[DisciplineAction] ADD CONSTRAINT [DisciplineAction_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[DisciplineAction] ADD CONSTRAINT [DisciplineAction_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[DisciplineActionDiscipline] --
CREATE TABLE [edfi].[DisciplineActionDiscipline] (
    [DisciplineActionIdentifier] [NVARCHAR](36) NOT NULL,
    [DisciplineDate] [DATE] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisciplineDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineActionDiscipline_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [StudentUSI] ASC,
        [DisciplineDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineActionDiscipline] ADD CONSTRAINT [DisciplineActionDiscipline_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] --
CREATE TABLE [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] (
    [DisciplineActionLengthDifferenceReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DisciplineActionLengthDifferenceReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionLengthDifferenceReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DisciplineActionStaff] --
CREATE TABLE [edfi].[DisciplineActionStaff] (
    [DisciplineActionIdentifier] [NVARCHAR](36) NOT NULL,
    [DisciplineDate] [DATE] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineActionStaff_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [StudentUSI] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineActionStaff] ADD CONSTRAINT [DisciplineActionStaff_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] --
CREATE TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] (
    [DisciplineActionIdentifier] [NVARCHAR](36) NOT NULL,
    [DisciplineDate] [DATE] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BehaviorDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineActionStudentDisciplineIncidentBehaviorAssociation_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [StudentUSI] ASC,
        [BehaviorDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [DisciplineActionStudentDisciplineIncidentBehaviorAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineDescriptor] --
CREATE TABLE [edfi].[DisciplineDescriptor] (
    [DisciplineDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DisciplineDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DisciplineDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DisciplineIncident] --
CREATE TABLE [edfi].[DisciplineIncident] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [CaseNumber] [NVARCHAR](20) NULL,
    [IncidentCost] [MONEY] NULL,
    [IncidentDate] [DATE] NOT NULL,
    [IncidentDescription] [NVARCHAR](1024) NULL,
    [IncidentLocationDescriptorId] [INT] NULL,
    [IncidentTime] [TIME](7) NULL,
    [ReportedToLawEnforcement] [BIT] NULL,
    [ReporterDescriptionDescriptorId] [INT] NULL,
    [ReporterName] [NVARCHAR](75) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [DisciplineIncident_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineIncident] ADD CONSTRAINT [DisciplineIncident_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[DisciplineIncident] ADD CONSTRAINT [DisciplineIncident_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[DisciplineIncident] ADD CONSTRAINT [DisciplineIncident_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[DisciplineIncidentBehavior] --
CREATE TABLE [edfi].[DisciplineIncidentBehavior] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [BehaviorDescriptorId] [INT] NOT NULL,
    [BehaviorDetailedDescription] [NVARCHAR](1024) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineIncidentBehavior_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [BehaviorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineIncidentBehavior] ADD CONSTRAINT [DisciplineIncidentBehavior_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineIncidentExternalParticipant] --
CREATE TABLE [edfi].[DisciplineIncidentExternalParticipant] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineIncidentExternalParticipant_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [DisciplineIncidentParticipationCodeDescriptorId] ASC,
        [FirstName] ASC,
        [LastSurname] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineIncidentExternalParticipant] ADD CONSTRAINT [DisciplineIncidentExternalParticipant_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineIncidentParticipationCodeDescriptor] --
CREATE TABLE [edfi].[DisciplineIncidentParticipationCodeDescriptor] (
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DisciplineIncidentParticipationCodeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DisciplineIncidentParticipationCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DisciplineIncidentWeapon] --
CREATE TABLE [edfi].[DisciplineIncidentWeapon] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [WeaponDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineIncidentWeapon_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [WeaponDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineIncidentWeapon] ADD CONSTRAINT [DisciplineIncidentWeapon_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisplacedStudentStatusDescriptor] --
CREATE TABLE [edfi].[DisplacedStudentStatusDescriptor] (
    [DisplacedStudentStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DisplacedStudentStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DisplacedStudentStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DualCreditInstitutionDescriptor] --
CREATE TABLE [edfi].[DualCreditInstitutionDescriptor] (
    [DualCreditInstitutionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DualCreditInstitutionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DualCreditInstitutionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[DualCreditTypeDescriptor] --
CREATE TABLE [edfi].[DualCreditTypeDescriptor] (
    [DualCreditTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [DualCreditTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [DualCreditTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationalEnvironmentDescriptor] --
CREATE TABLE [edfi].[EducationalEnvironmentDescriptor] (
    [EducationalEnvironmentDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationalEnvironmentDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducationalEnvironmentDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationContent] --
CREATE TABLE [edfi].[EducationContent] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [AdditionalAuthorsIndicator] [BIT] NULL,
    [ContentClassDescriptorId] [INT] NULL,
    [Cost] [MONEY] NULL,
    [CostRateDescriptorId] [INT] NULL,
    [Description] [NVARCHAR](1024) NULL,
    [InteractivityStyleDescriptorId] [INT] NULL,
    [LearningResourceMetadataURI] [NVARCHAR](255) NULL,
    [LearningStandardId] [NVARCHAR](60) NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PublicationDate] [DATE] NULL,
    [PublicationYear] [SMALLINT] NULL,
    [Publisher] [NVARCHAR](50) NULL,
    [ShortDescription] [NVARCHAR](75) NULL,
    [TimeRequired] [NVARCHAR](30) NULL,
    [UseRightsURL] [NVARCHAR](255) NULL,
    [Version] [NVARCHAR](10) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationContent_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContent] ADD CONSTRAINT [EducationContent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationContent] ADD CONSTRAINT [EducationContent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationContent] ADD CONSTRAINT [EducationContent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationContentAppropriateGradeLevel] --
CREATE TABLE [edfi].[EducationContentAppropriateGradeLevel] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentAppropriateGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentAppropriateGradeLevel] ADD CONSTRAINT [EducationContentAppropriateGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationContentAppropriateSex] --
CREATE TABLE [edfi].[EducationContentAppropriateSex] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentAppropriateSex_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentAppropriateSex] ADD CONSTRAINT [EducationContentAppropriateSex_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationContentAuthor] --
CREATE TABLE [edfi].[EducationContentAuthor] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [Author] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentAuthor_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [Author] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentAuthor] ADD CONSTRAINT [EducationContentAuthor_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationContentDerivativeSourceEducationContent] --
CREATE TABLE [edfi].[EducationContentDerivativeSourceEducationContent] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [DerivativeSourceContentIdentifier] [NVARCHAR](225) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentDerivativeSourceEducationContent_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [DerivativeSourceContentIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentDerivativeSourceEducationContent] ADD CONSTRAINT [EducationContentDerivativeSourceEducationContent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] --
CREATE TABLE [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [DerivativeSourceLearningResourceMetadataURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentDerivativeSourceLearningResourceMetadataURI_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [DerivativeSourceLearningResourceMetadataURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] ADD CONSTRAINT [EducationContentDerivativeSourceLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationContentDerivativeSourceURI] --
CREATE TABLE [edfi].[EducationContentDerivativeSourceURI] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [DerivativeSourceURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentDerivativeSourceURI_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [DerivativeSourceURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentDerivativeSourceURI] ADD CONSTRAINT [EducationContentDerivativeSourceURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationContentLanguage] --
CREATE TABLE [edfi].[EducationContentLanguage] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentLanguage_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentLanguage] ADD CONSTRAINT [EducationContentLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganization] --
CREATE TABLE [edfi].[EducationOrganization] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [OperationalStatusDescriptorId] [INT] NULL,
    [ShortNameOfInstitution] [NVARCHAR](75) NULL,
    [WebSite] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationOrganization_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganization] ADD CONSTRAINT [EducationOrganization_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganization] ADD CONSTRAINT [EducationOrganization_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganization] ADD CONSTRAINT [EducationOrganization_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationOrganizationAddress] --
CREATE TABLE [edfi].[EducationOrganizationAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationAddress] ADD CONSTRAINT [EducationOrganizationAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationAddressPeriod] --
CREATE TABLE [edfi].[EducationOrganizationAddressPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationAddressPeriod] ADD CONSTRAINT [EducationOrganizationAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationAssociationTypeDescriptor] --
CREATE TABLE [edfi].[EducationOrganizationAssociationTypeDescriptor] (
    [EducationOrganizationAssociationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationOrganizationAssociationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationAssociationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationOrganizationCategory] --
CREATE TABLE [edfi].[EducationOrganizationCategory] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationCategoryDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationCategory_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EducationOrganizationCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationCategory] ADD CONSTRAINT [EducationOrganizationCategory_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationCategoryDescriptor] --
CREATE TABLE [edfi].[EducationOrganizationCategoryDescriptor] (
    [EducationOrganizationCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationOrganizationCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationOrganizationIdentificationCode] --
CREATE TABLE [edfi].[EducationOrganizationIdentificationCode] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationIdentificationSystemDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EducationOrganizationIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationIdentificationCode] ADD CONSTRAINT [EducationOrganizationIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[EducationOrganizationIdentificationSystemDescriptor] (
    [EducationOrganizationIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationOrganizationIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationOrganizationIdentity] --
CREATE TABLE [edfi].[EducationOrganizationIdentity] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationIdentificationSystemDescriptorId] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationOrganizationIdentity_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EducationOrganizationIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationIdentity] ADD CONSTRAINT [EducationOrganizationIdentity_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganizationIdentity] ADD CONSTRAINT [EducationOrganizationIdentity_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganizationIdentity] ADD CONSTRAINT [EducationOrganizationIdentity_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationOrganizationIndicator] --
CREATE TABLE [edfi].[EducationOrganizationIndicator] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [IndicatorDescriptorId] [INT] NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [IndicatorGroupDescriptorId] [INT] NULL,
    [IndicatorLevelDescriptorId] [INT] NULL,
    [IndicatorValue] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationIndicator_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [IndicatorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationIndicator] ADD CONSTRAINT [EducationOrganizationIndicator_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationIndicatorPeriod] --
CREATE TABLE [edfi].[EducationOrganizationIndicatorPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [IndicatorDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationIndicatorPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [IndicatorDescriptorId] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationIndicatorPeriod] ADD CONSTRAINT [EducationOrganizationIndicatorPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationInstitutionTelephone] --
CREATE TABLE [edfi].[EducationOrganizationInstitutionTelephone] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InstitutionTelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationInstitutionTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InstitutionTelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationInstitutionTelephone] ADD CONSTRAINT [EducationOrganizationInstitutionTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationInternationalAddress] --
CREATE TABLE [edfi].[EducationOrganizationInternationalAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] ADD CONSTRAINT [EducationOrganizationInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationInterventionPrescriptionAssociation] --
CREATE TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionEducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationOrganizationInterventionPrescriptionAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionEducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD CONSTRAINT [EducationOrganizationInterventionPrescriptionAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD CONSTRAINT [EducationOrganizationInterventionPrescriptionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD CONSTRAINT [EducationOrganizationInterventionPrescriptionAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationOrganizationNetwork] --
CREATE TABLE [edfi].[EducationOrganizationNetwork] (
    [EducationOrganizationNetworkId] [BIGINT] NOT NULL,
    [NetworkPurposeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationOrganizationNetwork_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationNetworkId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationOrganizationNetworkAssociation] --
CREATE TABLE [edfi].[EducationOrganizationNetworkAssociation] (
    [EducationOrganizationNetworkId] [BIGINT] NOT NULL,
    [MemberEducationOrganizationId] [BIGINT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationOrganizationNetworkAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationNetworkId] ASC,
        [MemberEducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD CONSTRAINT [EducationOrganizationNetworkAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD CONSTRAINT [EducationOrganizationNetworkAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD CONSTRAINT [EducationOrganizationNetworkAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationOrganizationPeerAssociation] --
CREATE TABLE [edfi].[EducationOrganizationPeerAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PeerEducationOrganizationId] [BIGINT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationOrganizationPeerAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PeerEducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD CONSTRAINT [EducationOrganizationPeerAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD CONSTRAINT [EducationOrganizationPeerAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD CONSTRAINT [EducationOrganizationPeerAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationPlanDescriptor] --
CREATE TABLE [edfi].[EducationPlanDescriptor] (
    [EducationPlanDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationPlanDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducationPlanDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationServiceCenter] --
CREATE TABLE [edfi].[EducationServiceCenter] (
    [EducationServiceCenterId] [BIGINT] NOT NULL,
    [StateEducationAgencyId] [BIGINT] NULL,
    CONSTRAINT [EducationServiceCenter_PK] PRIMARY KEY CLUSTERED (
        [EducationServiceCenterId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducatorPreparationProgram] --
CREATE TABLE [edfi].[EducatorPreparationProgram] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [AccreditationStatusDescriptorId] [INT] NULL,
    [ProgramId] [NVARCHAR](20) NULL,
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
ALTER TABLE [edfi].[EducatorPreparationProgram] ADD CONSTRAINT [EducatorPreparationProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducatorPreparationProgram] ADD CONSTRAINT [EducatorPreparationProgram_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducatorPreparationProgram] ADD CONSTRAINT [EducatorPreparationProgram_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducatorPreparationProgramGradeLevel] --
CREATE TABLE [edfi].[EducatorPreparationProgramGradeLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducatorPreparationProgramGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducatorPreparationProgramGradeLevel] ADD CONSTRAINT [EducatorPreparationProgramGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducatorRoleDescriptor] --
CREATE TABLE [edfi].[EducatorRoleDescriptor] (
    [EducatorRoleDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducatorRoleDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducatorRoleDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ElectronicMailTypeDescriptor] --
CREATE TABLE [edfi].[ElectronicMailTypeDescriptor] (
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ElectronicMailTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EligibilityDelayReasonDescriptor] --
CREATE TABLE [edfi].[EligibilityDelayReasonDescriptor] (
    [EligibilityDelayReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EligibilityDelayReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EligibilityDelayReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EligibilityEvaluationTypeDescriptor] --
CREATE TABLE [edfi].[EligibilityEvaluationTypeDescriptor] (
    [EligibilityEvaluationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EligibilityEvaluationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EligibilityEvaluationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EmploymentStatusDescriptor] --
CREATE TABLE [edfi].[EmploymentStatusDescriptor] (
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EmploymentStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EmploymentStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EnglishLanguageExamDescriptor] --
CREATE TABLE [edfi].[EnglishLanguageExamDescriptor] (
    [EnglishLanguageExamDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EnglishLanguageExamDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EnglishLanguageExamDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EnrollmentTypeDescriptor] --
CREATE TABLE [edfi].[EnrollmentTypeDescriptor] (
    [EnrollmentTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EnrollmentTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EnrollmentTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EntryGradeLevelReasonDescriptor] --
CREATE TABLE [edfi].[EntryGradeLevelReasonDescriptor] (
    [EntryGradeLevelReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EntryGradeLevelReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EntryGradeLevelReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EntryTypeDescriptor] --
CREATE TABLE [edfi].[EntryTypeDescriptor] (
    [EntryTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EntryTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EntryTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EPPDegreeTypeDescriptor] --
CREATE TABLE [edfi].[EPPDegreeTypeDescriptor] (
    [EPPDegreeTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EPPDegreeTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EPPDegreeTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EPPProgramPathwayDescriptor] --
CREATE TABLE [edfi].[EPPProgramPathwayDescriptor] (
    [EPPProgramPathwayDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EPPProgramPathwayDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EPPProgramPathwayDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Evaluation] --
CREATE TABLE [edfi].[Evaluation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationDescription] [NVARCHAR](255) NULL,
    [EvaluationTypeDescriptorId] [INT] NULL,
    [InterRaterReliabilityScore] [INT] NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
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
ALTER TABLE [edfi].[Evaluation] ADD CONSTRAINT [Evaluation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Evaluation] ADD CONSTRAINT [Evaluation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Evaluation] ADD CONSTRAINT [Evaluation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EvaluationDelayReasonDescriptor] --
CREATE TABLE [edfi].[EvaluationDelayReasonDescriptor] (
    [EvaluationDelayReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationDelayReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationDelayReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EvaluationElement] --
CREATE TABLE [edfi].[EvaluationElement] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationTypeDescriptorId] [INT] NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [SortOrder] [INT] NULL,
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
ALTER TABLE [edfi].[EvaluationElement] ADD CONSTRAINT [EvaluationElement_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EvaluationElement] ADD CONSTRAINT [EvaluationElement_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EvaluationElement] ADD CONSTRAINT [EvaluationElement_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EvaluationElementRating] --
CREATE TABLE [edfi].[EvaluationElementRating] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
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
    [AreaOfRefinement] [NVARCHAR](1024) NULL,
    [AreaOfReinforcement] [NVARCHAR](1024) NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [EvaluationElementRatingLevelDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[EvaluationElementRating] ADD CONSTRAINT [EvaluationElementRating_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EvaluationElementRating] ADD CONSTRAINT [EvaluationElementRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EvaluationElementRating] ADD CONSTRAINT [EvaluationElementRating_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EvaluationElementRatingLevel] --
CREATE TABLE [edfi].[EvaluationElementRatingLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationElementRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationElementTitle] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationElementRatingLevel] ADD CONSTRAINT [EvaluationElementRatingLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationElementRatingLevelDescriptor] --
CREATE TABLE [edfi].[EvaluationElementRatingLevelDescriptor] (
    [EvaluationElementRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationElementRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationElementRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EvaluationElementRatingResult] --
CREATE TABLE [edfi].[EvaluationElementRatingResult] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
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
    [NumericRating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
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
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [NumericRating] ASC,
        [RatingResultTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationElementRatingResult] ADD CONSTRAINT [EvaluationElementRatingResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationObjective] --
CREATE TABLE [edfi].[EvaluationObjective] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationObjectiveDescription] [NVARCHAR](255) NULL,
    [EvaluationTypeDescriptorId] [INT] NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [SortOrder] [INT] NULL,
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
ALTER TABLE [edfi].[EvaluationObjective] ADD CONSTRAINT [EvaluationObjective_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EvaluationObjective] ADD CONSTRAINT [EvaluationObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EvaluationObjective] ADD CONSTRAINT [EvaluationObjective_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EvaluationObjectiveRating] --
CREATE TABLE [edfi].[EvaluationObjectiveRating] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [ObjectiveRatingLevelDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[EvaluationObjectiveRating] ADD CONSTRAINT [EvaluationObjectiveRating_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EvaluationObjectiveRating] ADD CONSTRAINT [EvaluationObjectiveRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EvaluationObjectiveRating] ADD CONSTRAINT [EvaluationObjectiveRating_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EvaluationObjectiveRatingLevel] --
CREATE TABLE [edfi].[EvaluationObjectiveRatingLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationObjectiveRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationObjectiveTitle] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationObjectiveRatingLevel] ADD CONSTRAINT [EvaluationObjectiveRatingLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationObjectiveRatingResult] --
CREATE TABLE [edfi].[EvaluationObjectiveRatingResult] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [NumericRating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
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
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [NumericRating] ASC,
        [RatingResultTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationObjectiveRatingResult] ADD CONSTRAINT [EvaluationObjectiveRatingResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationPeriodDescriptor] --
CREATE TABLE [edfi].[EvaluationPeriodDescriptor] (
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationPeriodDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationPeriodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EvaluationRating] --
CREATE TABLE [edfi].[EvaluationRating] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ActualDuration] [INT] NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NULL,
    [EvaluationRatingStatusDescriptorId] [INT] NULL,
    [LocalCourseCode] [NVARCHAR](60) NULL,
    [SchoolId] [BIGINT] NULL,
    [SectionIdentifier] [NVARCHAR](255) NULL,
    [SessionName] [NVARCHAR](120) NULL,
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
ALTER TABLE [edfi].[EvaluationRating] ADD CONSTRAINT [EvaluationRating_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EvaluationRating] ADD CONSTRAINT [EvaluationRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EvaluationRating] ADD CONSTRAINT [EvaluationRating_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EvaluationRatingLevel] --
CREATE TABLE [edfi].[EvaluationRatingLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationRatingLevel] ADD CONSTRAINT [EvaluationRatingLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationRatingLevelDescriptor] --
CREATE TABLE [edfi].[EvaluationRatingLevelDescriptor] (
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EvaluationRatingResult] --
CREATE TABLE [edfi].[EvaluationRatingResult] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [NumericRating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
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
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [NumericRating] ASC,
        [RatingResultTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationRatingResult] ADD CONSTRAINT [EvaluationRatingResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationRatingReviewer] --
CREATE TABLE [edfi].[EvaluationRatingReviewer] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [ReviewerPersonId] [NVARCHAR](32) NULL,
    [ReviewerSourceSystemDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationRatingReviewer_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [FirstName] ASC,
        [LastSurname] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationRatingReviewer] ADD CONSTRAINT [EvaluationRatingReviewer_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationRatingReviewerReceivedTraining] --
CREATE TABLE [edfi].[EvaluationRatingReviewerReceivedTraining] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [InterRaterReliabilityScore] [INT] NULL,
    [ReceivedTrainingDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EvaluationRatingReviewerReceivedTraining_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationDate] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [EvaluationTitle] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [FirstName] ASC,
        [LastSurname] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationRatingReviewerReceivedTraining] ADD CONSTRAINT [EvaluationRatingReviewerReceivedTraining_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[EvaluationRatingStatusDescriptor] --
CREATE TABLE [edfi].[EvaluationRatingStatusDescriptor] (
    [EvaluationRatingStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationRatingStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationRatingStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EvaluationRubricDimension] --
CREATE TABLE [edfi].[EvaluationRubricDimension] (
    [EvaluationRubricRating] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationElementTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [EvaluationCriterionDescription] [NVARCHAR](1024) NOT NULL,
    [EvaluationRubricRatingLevelDescriptorId] [INT] NULL,
    [RubricDimensionSortOrder] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EvaluationRubricDimension_PK] PRIMARY KEY CLUSTERED (
        [EvaluationRubricRating] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationElementTitle] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EvaluationRubricDimension] ADD CONSTRAINT [EvaluationRubricDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EvaluationRubricDimension] ADD CONSTRAINT [EvaluationRubricDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EvaluationRubricDimension] ADD CONSTRAINT [EvaluationRubricDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EvaluationTypeDescriptor] --
CREATE TABLE [edfi].[EvaluationTypeDescriptor] (
    [EvaluationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EvaluationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EvaluationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EventCircumstanceDescriptor] --
CREATE TABLE [edfi].[EventCircumstanceDescriptor] (
    [EventCircumstanceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EventCircumstanceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EventCircumstanceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ExitWithdrawTypeDescriptor] --
CREATE TABLE [edfi].[ExitWithdrawTypeDescriptor] (
    [ExitWithdrawTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ExitWithdrawTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ExitWithdrawTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[FederalLocaleCodeDescriptor] --
CREATE TABLE [edfi].[FederalLocaleCodeDescriptor] (
    [FederalLocaleCodeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [FederalLocaleCodeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [FederalLocaleCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[FeederSchoolAssociation] --
CREATE TABLE [edfi].[FeederSchoolAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [FeederSchoolId] [BIGINT] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [EndDate] [DATE] NULL,
    [FeederRelationshipDescription] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [FeederSchoolAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [FeederSchoolId] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD CONSTRAINT [FeederSchoolAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD CONSTRAINT [FeederSchoolAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD CONSTRAINT [FeederSchoolAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[FieldworkExperience] --
CREATE TABLE [edfi].[FieldworkExperience] (
    [BeginDate] [DATE] NOT NULL,
    [FieldworkIdentifier] [NVARCHAR](64) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [EndDate] [DATE] NULL,
    [FieldworkTypeDescriptorId] [INT] NOT NULL,
    [HoursCompleted] [DECIMAL](5, 2) NULL,
    [ProgramName] [NVARCHAR](255) NULL,
    [ProgramTypeDescriptorId] [INT] NULL,
    [SchoolId] [BIGINT] NULL,
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
ALTER TABLE [edfi].[FieldworkExperience] ADD CONSTRAINT [FieldworkExperience_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FieldworkExperience] ADD CONSTRAINT [FieldworkExperience_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FieldworkExperience] ADD CONSTRAINT [FieldworkExperience_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[FieldworkExperienceCoteaching] --
CREATE TABLE [edfi].[FieldworkExperienceCoteaching] (
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
ALTER TABLE [edfi].[FieldworkExperienceCoteaching] ADD CONSTRAINT [FieldworkExperienceCoteaching_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[FieldworkExperienceSectionAssociation] --
CREATE TABLE [edfi].[FieldworkExperienceSectionAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [FieldworkIdentifier] [NVARCHAR](64) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
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
ALTER TABLE [edfi].[FieldworkExperienceSectionAssociation] ADD CONSTRAINT [FieldworkExperienceSectionAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FieldworkExperienceSectionAssociation] ADD CONSTRAINT [FieldworkExperienceSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FieldworkExperienceSectionAssociation] ADD CONSTRAINT [FieldworkExperienceSectionAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[FieldworkTypeDescriptor] --
CREATE TABLE [edfi].[FieldworkTypeDescriptor] (
    [FieldworkTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [FieldworkTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [FieldworkTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[FinancialAid] --
CREATE TABLE [edfi].[FinancialAid] (
    [AidTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AidAmount] [DECIMAL](19, 4) NULL,
    [AidConditionDescription] [NVARCHAR](1024) NULL,
    [EndDate] [DATE] NULL,
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
ALTER TABLE [edfi].[FinancialAid] ADD CONSTRAINT [FinancialAid_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FinancialAid] ADD CONSTRAINT [FinancialAid_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FinancialAid] ADD CONSTRAINT [FinancialAid_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[FinancialCollectionDescriptor] --
CREATE TABLE [edfi].[FinancialCollectionDescriptor] (
    [FinancialCollectionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [FinancialCollectionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [FinancialCollectionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[FunctionDimension] --
CREATE TABLE [edfi].[FunctionDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [FunctionDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[FunctionDimension] ADD CONSTRAINT [FunctionDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FunctionDimension] ADD CONSTRAINT [FunctionDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FunctionDimension] ADD CONSTRAINT [FunctionDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[FunctionDimensionReportingTag] --
CREATE TABLE [edfi].[FunctionDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [FunctionDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[FunctionDimensionReportingTag] ADD CONSTRAINT [FunctionDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[FundDimension] --
CREATE TABLE [edfi].[FundDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [FundDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[FundDimension] ADD CONSTRAINT [FundDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FundDimension] ADD CONSTRAINT [FundDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FundDimension] ADD CONSTRAINT [FundDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[FundDimensionReportingTag] --
CREATE TABLE [edfi].[FundDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [FundDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[FundDimensionReportingTag] ADD CONSTRAINT [FundDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[FundingSourceDescriptor] --
CREATE TABLE [edfi].[FundingSourceDescriptor] (
    [FundingSourceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [FundingSourceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [FundingSourceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[GeneralStudentProgramAssociation] --
CREATE TABLE [edfi].[GeneralStudentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [ReasonExitedDescriptorId] [INT] NULL,
    [ServedOutsideOfRegularSession] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [GeneralStudentProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD CONSTRAINT [GeneralStudentProgramAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD CONSTRAINT [GeneralStudentProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD CONSTRAINT [GeneralStudentProgramAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] --
CREATE TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ParticipationStatusDescriptorId] [INT] NOT NULL,
    [StatusBeginDate] [DATE] NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [StatusEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GeneralStudentProgramAssociationProgramParticipationStatus_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [ParticipationStatusDescriptorId] ASC,
        [StatusBeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] ADD CONSTRAINT [GeneralStudentProgramAssociationProgramParticipationStatus_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[Goal] --
CREATE TABLE [edfi].[Goal] (
    [AssignmentDate] [DATE] NOT NULL,
    [GoalTitle] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [CompletedDate] [DATE] NULL,
    [CompletedIndicator] [BIT] NULL,
    [DueDate] [DATE] NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NULL,
    [EvaluationPeriodDescriptorId] [INT] NULL,
    [EvaluationTitle] [NVARCHAR](50) NULL,
    [GoalDescription] [NVARCHAR](1024) NULL,
    [GoalTypeDescriptorId] [INT] NULL,
    [ParentAssignmentDate] [DATE] NULL,
    [ParentGoalTitle] [NVARCHAR](255) NULL,
    [ParentPersonId] [NVARCHAR](32) NULL,
    [ParentSourceSystemDescriptorId] [INT] NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [TermDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[Goal] ADD CONSTRAINT [Goal_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Goal] ADD CONSTRAINT [Goal_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Goal] ADD CONSTRAINT [Goal_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GoalTypeDescriptor] --
CREATE TABLE [edfi].[GoalTypeDescriptor] (
    [GoalTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GoalTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GoalTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Grade] --
CREATE TABLE [edfi].[Grade] (
    [BeginDate] [DATE] NOT NULL,
    [GradeTypeDescriptorId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CurrentGradeAsOfDate] [DATE] NULL,
    [CurrentGradeIndicator] [BIT] NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [GradeEarnedDescription] [NVARCHAR](64) NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [NumericGradeEarned] [DECIMAL](9, 2) NULL,
    [PerformanceBaseConversionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Grade_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [GradeTypeDescriptorId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolYear] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Grade] ADD CONSTRAINT [Grade_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Grade] ADD CONSTRAINT [Grade_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Grade] ADD CONSTRAINT [Grade_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GradebookEntry] --
CREATE TABLE [edfi].[GradebookEntry] (
    [GradebookEntryIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [DateAssigned] [DATE] NOT NULL,
    [Description] [NVARCHAR](1024) NULL,
    [DueDate] [DATE] NULL,
    [DueTime] [TIME](7) NULL,
    [GradebookEntryTypeDescriptorId] [INT] NULL,
    [GradingPeriodDescriptorId] [INT] NULL,
    [GradingPeriodName] [NVARCHAR](60) NULL,
    [LocalCourseCode] [NVARCHAR](60) NULL,
    [MaxPoints] [DECIMAL](9, 2) NULL,
    [SchoolId] [BIGINT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [SectionIdentifier] [NVARCHAR](255) NULL,
    [SessionName] [NVARCHAR](120) NULL,
    [SourceSectionIdentifier] [NVARCHAR](255) NOT NULL,
    [Title] [NVARCHAR](100) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [GradebookEntry_PK] PRIMARY KEY CLUSTERED (
        [GradebookEntryIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GradebookEntry] ADD CONSTRAINT [GradebookEntry_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GradebookEntry] ADD CONSTRAINT [GradebookEntry_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GradebookEntry] ADD CONSTRAINT [GradebookEntry_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GradebookEntryLearningStandard] --
CREATE TABLE [edfi].[GradebookEntryLearningStandard] (
    [GradebookEntryIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GradebookEntryLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [GradebookEntryIdentifier] ASC,
        [Namespace] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GradebookEntryLearningStandard] ADD CONSTRAINT [GradebookEntryLearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GradebookEntryTypeDescriptor] --
CREATE TABLE [edfi].[GradebookEntryTypeDescriptor] (
    [GradebookEntryTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GradebookEntryTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GradebookEntryTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[GradeLearningStandardGrade] --
CREATE TABLE [edfi].[GradeLearningStandardGrade] (
    [BeginDate] [DATE] NOT NULL,
    [GradeTypeDescriptorId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [NumericGradeEarned] [DECIMAL](9, 2) NULL,
    [PerformanceBaseConversionDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GradeLearningStandardGrade_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [GradeTypeDescriptorId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolYear] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GradeLearningStandardGrade] ADD CONSTRAINT [GradeLearningStandardGrade_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GradeLevelDescriptor] --
CREATE TABLE [edfi].[GradeLevelDescriptor] (
    [GradeLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GradeLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[GradePointAverageTypeDescriptor] --
CREATE TABLE [edfi].[GradePointAverageTypeDescriptor] (
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GradePointAverageTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GradePointAverageTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[GradeTypeDescriptor] --
CREATE TABLE [edfi].[GradeTypeDescriptor] (
    [GradeTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GradeTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GradeTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[GradingPeriod] --
CREATE TABLE [edfi].[GradingPeriod] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NOT NULL,
    [PeriodSequence] [INT] NULL,
    [TotalInstructionalDays] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [GradingPeriod_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GradingPeriod] ADD CONSTRAINT [GradingPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GradingPeriod] ADD CONSTRAINT [GradingPeriod_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GradingPeriod] ADD CONSTRAINT [GradingPeriod_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GradingPeriodDescriptor] --
CREATE TABLE [edfi].[GradingPeriodDescriptor] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GradingPeriodDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[GraduationPlan] --
CREATE TABLE [edfi].[GraduationPlan] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [IndividualPlan] [BIT] NULL,
    [TotalRequiredCreditConversion] [DECIMAL](9, 2) NULL,
    [TotalRequiredCredits] [DECIMAL](9, 3) NOT NULL,
    [TotalRequiredCreditTypeDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [GraduationPlan_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlan] ADD CONSTRAINT [GraduationPlan_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GraduationPlan] ADD CONSTRAINT [GraduationPlan_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GraduationPlan] ADD CONSTRAINT [GraduationPlan_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GraduationPlanCreditsByCourse] --
CREATE TABLE [edfi].[GraduationPlanCreditsByCourse] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [CourseSetName] [NVARCHAR](120) NOT NULL,
    [CreditConversion] [DECIMAL](9, 2) NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreditTypeDescriptorId] [INT] NULL,
    [WhenTakenGradeLevelDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsByCourse_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [CourseSetName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] ADD CONSTRAINT [GraduationPlanCreditsByCourse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanCreditsByCourseCourse] --
CREATE TABLE [edfi].[GraduationPlanCreditsByCourseCourse] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [CourseSetName] [NVARCHAR](120) NOT NULL,
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [CourseEducationOrganizationId] [BIGINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsByCourseCourse_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [CourseSetName] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsByCourseCourse] ADD CONSTRAINT [GraduationPlanCreditsByCourseCourse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanCreditsByCreditCategory] --
CREATE TABLE [edfi].[GraduationPlanCreditsByCreditCategory] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [CreditCategoryDescriptorId] [INT] NOT NULL,
    [CreditConversion] [DECIMAL](9, 2) NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreditTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsByCreditCategory_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [CreditCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] ADD CONSTRAINT [GraduationPlanCreditsByCreditCategory_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanCreditsBySubject] --
CREATE TABLE [edfi].[GraduationPlanCreditsBySubject] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreditConversion] [DECIMAL](9, 2) NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreditTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsBySubject_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] ADD CONSTRAINT [GraduationPlanCreditsBySubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanRequiredAssessment] --
CREATE TABLE [edfi].[GraduationPlanRequiredAssessment] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredAssessment_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanRequiredAssessment] ADD CONSTRAINT [GraduationPlanRequiredAssessment_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] ADD CONSTRAINT [GraduationPlanRequiredAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanRequiredAssessmentScore] --
CREATE TABLE [edfi].[GraduationPlanRequiredAssessmentScore] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredAssessmentScore_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [AssessmentReportingMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] ADD CONSTRAINT [GraduationPlanRequiredAssessmentScore_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanRequiredCertification] --
CREATE TABLE [edfi].[GraduationPlanRequiredCertification] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [CertificationTitle] [NVARCHAR](64) NOT NULL,
    [CertificationIdentifier] [NVARCHAR](120) NULL,
    [CertificationRouteDescriptorId] [INT] NULL,
    [Namespace] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredCertification_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [CertificationTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanRequiredCertification] ADD CONSTRAINT [GraduationPlanRequiredCertification_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanTypeDescriptor] --
CREATE TABLE [edfi].[GraduationPlanTypeDescriptor] (
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GraduationPlanTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GraduationPlanTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[GunFreeSchoolsActReportingStatusDescriptor] --
CREATE TABLE [edfi].[GunFreeSchoolsActReportingStatusDescriptor] (
    [GunFreeSchoolsActReportingStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [GunFreeSchoolsActReportingStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [GunFreeSchoolsActReportingStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[HireStatusDescriptor] --
CREATE TABLE [edfi].[HireStatusDescriptor] (
    [HireStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [HireStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [HireStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[HiringSourceDescriptor] --
CREATE TABLE [edfi].[HiringSourceDescriptor] (
    [HiringSourceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [HiringSourceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [HiringSourceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] --
CREATE TABLE [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] (
    [HomelessPrimaryNighttimeResidenceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [HomelessPrimaryNighttimeResidenceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [HomelessPrimaryNighttimeResidenceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[HomelessProgramServiceDescriptor] --
CREATE TABLE [edfi].[HomelessProgramServiceDescriptor] (
    [HomelessProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [HomelessProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [HomelessProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[IDEAPartDescriptor] --
CREATE TABLE [edfi].[IDEAPartDescriptor] (
    [IDEAPartDescriptorId] [INT] NOT NULL,
    CONSTRAINT [IDEAPartDescriptor_PK] PRIMARY KEY CLUSTERED (
        [IDEAPartDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[IdentificationDocumentUseDescriptor] --
CREATE TABLE [edfi].[IdentificationDocumentUseDescriptor] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    CONSTRAINT [IdentificationDocumentUseDescriptor_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ImmunizationTypeDescriptor] --
CREATE TABLE [edfi].[ImmunizationTypeDescriptor] (
    [ImmunizationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ImmunizationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ImmunizationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[IncidentLocationDescriptor] --
CREATE TABLE [edfi].[IncidentLocationDescriptor] (
    [IncidentLocationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [IncidentLocationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [IncidentLocationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[IndicatorDescriptor] --
CREATE TABLE [edfi].[IndicatorDescriptor] (
    [IndicatorDescriptorId] [INT] NOT NULL,
    CONSTRAINT [IndicatorDescriptor_PK] PRIMARY KEY CLUSTERED (
        [IndicatorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[IndicatorGroupDescriptor] --
CREATE TABLE [edfi].[IndicatorGroupDescriptor] (
    [IndicatorGroupDescriptorId] [INT] NOT NULL,
    CONSTRAINT [IndicatorGroupDescriptor_PK] PRIMARY KEY CLUSTERED (
        [IndicatorGroupDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[IndicatorLevelDescriptor] --
CREATE TABLE [edfi].[IndicatorLevelDescriptor] (
    [IndicatorLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [IndicatorLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [IndicatorLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InstitutionTelephoneNumberTypeDescriptor] --
CREATE TABLE [edfi].[InstitutionTelephoneNumberTypeDescriptor] (
    [InstitutionTelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InstitutionTelephoneNumberTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InstitutionTelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InstructionalSettingDescriptor] --
CREATE TABLE [edfi].[InstructionalSettingDescriptor] (
    [InstructionalSettingDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InstructionalSettingDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InstructionalSettingDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InteractivityStyleDescriptor] --
CREATE TABLE [edfi].[InteractivityStyleDescriptor] (
    [InteractivityStyleDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InteractivityStyleDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InteractivityStyleDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InternetAccessDescriptor] --
CREATE TABLE [edfi].[InternetAccessDescriptor] (
    [InternetAccessDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InternetAccessDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InternetAccessDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InternetAccessTypeInResidenceDescriptor] --
CREATE TABLE [edfi].[InternetAccessTypeInResidenceDescriptor] (
    [InternetAccessTypeInResidenceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InternetAccessTypeInResidenceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InternetAccessTypeInResidenceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InternetPerformanceInResidenceDescriptor] --
CREATE TABLE [edfi].[InternetPerformanceInResidenceDescriptor] (
    [InternetPerformanceInResidenceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InternetPerformanceInResidenceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InternetPerformanceInResidenceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Intervention] --
CREATE TABLE [edfi].[Intervention] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [DeliveryMethodDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [InterventionClassDescriptorId] [INT] NOT NULL,
    [MaxDosage] [INT] NULL,
    [MinDosage] [INT] NULL,
    [Namespace] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Intervention_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Intervention] ADD CONSTRAINT [Intervention_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Intervention] ADD CONSTRAINT [Intervention_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Intervention] ADD CONSTRAINT [Intervention_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[InterventionAppropriateGradeLevel] --
CREATE TABLE [edfi].[InterventionAppropriateGradeLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionAppropriateGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionAppropriateGradeLevel] ADD CONSTRAINT [InterventionAppropriateGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionAppropriateSex] --
CREATE TABLE [edfi].[InterventionAppropriateSex] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionAppropriateSex_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionAppropriateSex] ADD CONSTRAINT [InterventionAppropriateSex_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionClassDescriptor] --
CREATE TABLE [edfi].[InterventionClassDescriptor] (
    [InterventionClassDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InterventionClassDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InterventionClassDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InterventionDiagnosis] --
CREATE TABLE [edfi].[InterventionDiagnosis] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionDiagnosis_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [DiagnosisDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionDiagnosis] ADD CONSTRAINT [InterventionDiagnosis_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionEducationContent] --
CREATE TABLE [edfi].[InterventionEducationContent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionEducationContent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [ContentIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionEducationContent] ADD CONSTRAINT [InterventionEducationContent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionEffectivenessRatingDescriptor] --
CREATE TABLE [edfi].[InterventionEffectivenessRatingDescriptor] (
    [InterventionEffectivenessRatingDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InterventionEffectivenessRatingDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InterventionEffectivenessRatingDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[InterventionInterventionPrescription] --
CREATE TABLE [edfi].[InterventionInterventionPrescription] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [InterventionPrescriptionEducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionInterventionPrescription_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [InterventionPrescriptionEducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionInterventionPrescription] ADD CONSTRAINT [InterventionInterventionPrescription_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionLearningResourceMetadataURI] --
CREATE TABLE [edfi].[InterventionLearningResourceMetadataURI] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [LearningResourceMetadataURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionLearningResourceMetadataURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [LearningResourceMetadataURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionLearningResourceMetadataURI] ADD CONSTRAINT [InterventionLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionMeetingTime] --
CREATE TABLE [edfi].[InterventionMeetingTime] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [EndTime] [TIME](7) NOT NULL,
    [StartTime] [TIME](7) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionMeetingTime_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [EndTime] ASC,
        [StartTime] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionMeetingTime] ADD CONSTRAINT [InterventionMeetingTime_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPopulationServed] --
CREATE TABLE [edfi].[InterventionPopulationServed] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPopulationServed_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPopulationServed] ADD CONSTRAINT [InterventionPopulationServed_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescription] --
CREATE TABLE [edfi].[InterventionPrescription] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [DeliveryMethodDescriptorId] [INT] NOT NULL,
    [InterventionClassDescriptorId] [INT] NOT NULL,
    [MaxDosage] [INT] NULL,
    [MinDosage] [INT] NULL,
    [Namespace] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [InterventionPrescription_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescription] ADD CONSTRAINT [InterventionPrescription_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[InterventionPrescription] ADD CONSTRAINT [InterventionPrescription_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[InterventionPrescription] ADD CONSTRAINT [InterventionPrescription_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[InterventionPrescriptionAppropriateGradeLevel] --
CREATE TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionAppropriateGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] ADD CONSTRAINT [InterventionPrescriptionAppropriateGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionAppropriateSex] --
CREATE TABLE [edfi].[InterventionPrescriptionAppropriateSex] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionAppropriateSex_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionAppropriateSex] ADD CONSTRAINT [InterventionPrescriptionAppropriateSex_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionDiagnosis] --
CREATE TABLE [edfi].[InterventionPrescriptionDiagnosis] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionDiagnosis_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [DiagnosisDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionDiagnosis] ADD CONSTRAINT [InterventionPrescriptionDiagnosis_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionEducationContent] --
CREATE TABLE [edfi].[InterventionPrescriptionEducationContent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionEducationContent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [ContentIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionEducationContent] ADD CONSTRAINT [InterventionPrescriptionEducationContent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionLearningResourceMetadataURI] --
CREATE TABLE [edfi].[InterventionPrescriptionLearningResourceMetadataURI] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [LearningResourceMetadataURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionLearningResourceMetadataURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [LearningResourceMetadataURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionLearningResourceMetadataURI] ADD CONSTRAINT [InterventionPrescriptionLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionPopulationServed] --
CREATE TABLE [edfi].[InterventionPrescriptionPopulationServed] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionPopulationServed_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionPopulationServed] ADD CONSTRAINT [InterventionPrescriptionPopulationServed_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionURI] --
CREATE TABLE [edfi].[InterventionPrescriptionURI] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [URI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [URI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionURI] ADD CONSTRAINT [InterventionPrescriptionURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStaff] --
CREATE TABLE [edfi].[InterventionStaff] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStaff_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStaff] ADD CONSTRAINT [InterventionStaff_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudy] --
CREATE TABLE [edfi].[InterventionStudy] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [DeliveryMethodDescriptorId] [INT] NOT NULL,
    [InterventionClassDescriptorId] [INT] NOT NULL,
    [InterventionPrescriptionEducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [Participants] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [InterventionStudy_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudy] ADD CONSTRAINT [InterventionStudy_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[InterventionStudy] ADD CONSTRAINT [InterventionStudy_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[InterventionStudy] ADD CONSTRAINT [InterventionStudy_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[InterventionStudyAppropriateGradeLevel] --
CREATE TABLE [edfi].[InterventionStudyAppropriateGradeLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyAppropriateGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyAppropriateGradeLevel] ADD CONSTRAINT [InterventionStudyAppropriateGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyAppropriateSex] --
CREATE TABLE [edfi].[InterventionStudyAppropriateSex] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyAppropriateSex_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyAppropriateSex] ADD CONSTRAINT [InterventionStudyAppropriateSex_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyEducationContent] --
CREATE TABLE [edfi].[InterventionStudyEducationContent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyEducationContent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [ContentIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyEducationContent] ADD CONSTRAINT [InterventionStudyEducationContent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyInterventionEffectiveness] --
CREATE TABLE [edfi].[InterventionStudyInterventionEffectiveness] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [ImprovementIndex] [INT] NULL,
    [InterventionEffectivenessRatingDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyInterventionEffectiveness_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [DiagnosisDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] ADD CONSTRAINT [InterventionStudyInterventionEffectiveness_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyLearningResourceMetadataURI] --
CREATE TABLE [edfi].[InterventionStudyLearningResourceMetadataURI] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [LearningResourceMetadataURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyLearningResourceMetadataURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [LearningResourceMetadataURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyLearningResourceMetadataURI] ADD CONSTRAINT [InterventionStudyLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyPopulationServed] --
CREATE TABLE [edfi].[InterventionStudyPopulationServed] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyPopulationServed_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyPopulationServed] ADD CONSTRAINT [InterventionStudyPopulationServed_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyStateAbbreviation] --
CREATE TABLE [edfi].[InterventionStudyStateAbbreviation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyStateAbbreviation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [StateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyStateAbbreviation] ADD CONSTRAINT [InterventionStudyStateAbbreviation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyURI] --
CREATE TABLE [edfi].[InterventionStudyURI] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](120) NOT NULL,
    [URI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [URI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyURI] ADD CONSTRAINT [InterventionStudyURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionURI] --
CREATE TABLE [edfi].[InterventionURI] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [URI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [URI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionURI] ADD CONSTRAINT [InterventionURI_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LanguageDescriptor] --
CREATE TABLE [edfi].[LanguageDescriptor] (
    [LanguageDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LanguageDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LanguageInstructionProgramServiceDescriptor] --
CREATE TABLE [edfi].[LanguageInstructionProgramServiceDescriptor] (
    [LanguageInstructionProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LanguageInstructionProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LanguageInstructionProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LanguageUseDescriptor] --
CREATE TABLE [edfi].[LanguageUseDescriptor] (
    [LanguageUseDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LanguageUseDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LearningStandard] --
CREATE TABLE [edfi].[LearningStandard] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CourseTitle] [NVARCHAR](120) NULL,
    [Description] [NVARCHAR](1024) NOT NULL,
    [LearningStandardCategoryDescriptorId] [INT] NULL,
    [LearningStandardItemCode] [NVARCHAR](120) NULL,
    [LearningStandardScopeDescriptorId] [INT] NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ParentLearningStandardId] [NVARCHAR](60) NULL,
    [SuccessCriteria] [NVARCHAR](150) NULL,
    [URI] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LearningStandard_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandard] ADD CONSTRAINT [LearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LearningStandard] ADD CONSTRAINT [LearningStandard_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LearningStandard] ADD CONSTRAINT [LearningStandard_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LearningStandardAcademicSubject] --
CREATE TABLE [edfi].[LearningStandardAcademicSubject] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardAcademicSubject] ADD CONSTRAINT [LearningStandardAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardCategoryDescriptor] --
CREATE TABLE [edfi].[LearningStandardCategoryDescriptor] (
    [LearningStandardCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LearningStandardCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LearningStandardContentStandard] --
CREATE TABLE [edfi].[LearningStandardContentStandard] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [MandatingEducationOrganizationId] [BIGINT] NULL,
    [PublicationDate] [DATE] NULL,
    [PublicationStatusDescriptorId] [INT] NULL,
    [PublicationYear] [SMALLINT] NULL,
    [Title] [NVARCHAR](100) NOT NULL,
    [URI] [NVARCHAR](255) NULL,
    [Version] [NVARCHAR](50) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardContentStandard_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardContentStandard] ADD CONSTRAINT [LearningStandardContentStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardContentStandardAuthor] --
CREATE TABLE [edfi].[LearningStandardContentStandardAuthor] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [Author] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardContentStandardAuthor_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC,
        [Author] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardContentStandardAuthor] ADD CONSTRAINT [LearningStandardContentStandardAuthor_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardEquivalenceAssociation] --
CREATE TABLE [edfi].[LearningStandardEquivalenceAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SourceLearningStandardId] [NVARCHAR](60) NOT NULL,
    [TargetLearningStandardId] [NVARCHAR](60) NOT NULL,
    [EffectiveDate] [DATE] NULL,
    [LearningStandardEquivalenceStrengthDescription] [NVARCHAR](255) NULL,
    [LearningStandardEquivalenceStrengthDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LearningStandardEquivalenceAssociation_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SourceLearningStandardId] ASC,
        [TargetLearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD CONSTRAINT [LearningStandardEquivalenceAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD CONSTRAINT [LearningStandardEquivalenceAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD CONSTRAINT [LearningStandardEquivalenceAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LearningStandardEquivalenceStrengthDescriptor] --
CREATE TABLE [edfi].[LearningStandardEquivalenceStrengthDescriptor] (
    [LearningStandardEquivalenceStrengthDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LearningStandardEquivalenceStrengthDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardEquivalenceStrengthDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LearningStandardGradeLevel] --
CREATE TABLE [edfi].[LearningStandardGradeLevel] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardGradeLevel] ADD CONSTRAINT [LearningStandardGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardIdentificationCode] --
CREATE TABLE [edfi].[LearningStandardIdentificationCode] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [ContentStandardName] [NVARCHAR](65) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC,
        [ContentStandardName] ASC,
        [IdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardIdentificationCode] ADD CONSTRAINT [LearningStandardIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardScopeDescriptor] --
CREATE TABLE [edfi].[LearningStandardScopeDescriptor] (
    [LearningStandardScopeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LearningStandardScopeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardScopeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LengthOfContractDescriptor] --
CREATE TABLE [edfi].[LengthOfContractDescriptor] (
    [LengthOfContractDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LengthOfContractDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LengthOfContractDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LevelOfEducationDescriptor] --
CREATE TABLE [edfi].[LevelOfEducationDescriptor] (
    [LevelOfEducationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LevelOfEducationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LevelOfEducationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LicenseStatusDescriptor] --
CREATE TABLE [edfi].[LicenseStatusDescriptor] (
    [LicenseStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LicenseStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LicenseStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LicenseTypeDescriptor] --
CREATE TABLE [edfi].[LicenseTypeDescriptor] (
    [LicenseTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LicenseTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LicenseTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LimitedEnglishProficiencyDescriptor] --
CREATE TABLE [edfi].[LimitedEnglishProficiencyDescriptor] (
    [LimitedEnglishProficiencyDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LimitedEnglishProficiencyDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LimitedEnglishProficiencyDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LocalAccount] --
CREATE TABLE [edfi].[LocalAccount] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [AccountName] [NVARCHAR](100) NULL,
    [ChartOfAccountIdentifier] [NVARCHAR](50) NOT NULL,
    [ChartOfAccountEducationOrganizationId] [BIGINT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LocalAccount_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalAccount] ADD CONSTRAINT [LocalAccount_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalAccount] ADD CONSTRAINT [LocalAccount_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalAccount] ADD CONSTRAINT [LocalAccount_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalAccountReportingTag] --
CREATE TABLE [edfi].[LocalAccountReportingTag] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [TagValue] [NVARCHAR](100) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LocalAccountReportingTag_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalAccountReportingTag] ADD CONSTRAINT [LocalAccountReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LocalActual] --
CREATE TABLE [edfi].[LocalActual] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [Amount] [MONEY] NOT NULL,
    [FinancialCollectionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LocalActual_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [AsOfDate] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalActual] ADD CONSTRAINT [LocalActual_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalActual] ADD CONSTRAINT [LocalActual_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalActual] ADD CONSTRAINT [LocalActual_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalBudget] --
CREATE TABLE [edfi].[LocalBudget] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [Amount] [MONEY] NOT NULL,
    [FinancialCollectionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LocalBudget_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [AsOfDate] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalBudget] ADD CONSTRAINT [LocalBudget_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalBudget] ADD CONSTRAINT [LocalBudget_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalBudget] ADD CONSTRAINT [LocalBudget_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalContractedStaff] --
CREATE TABLE [edfi].[LocalContractedStaff] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [Amount] [MONEY] NOT NULL,
    [FinancialCollectionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LocalContractedStaff_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [AsOfDate] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalContractedStaff] ADD CONSTRAINT [LocalContractedStaff_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalContractedStaff] ADD CONSTRAINT [LocalContractedStaff_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalContractedStaff] ADD CONSTRAINT [LocalContractedStaff_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocaleDescriptor] --
CREATE TABLE [edfi].[LocaleDescriptor] (
    [LocaleDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LocaleDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LocaleDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LocalEducationAgency] --
CREATE TABLE [edfi].[LocalEducationAgency] (
    [LocalEducationAgencyId] [BIGINT] NOT NULL,
    [CharterStatusDescriptorId] [INT] NULL,
    [EducationServiceCenterId] [BIGINT] NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    [LocalEducationAgencyCategoryDescriptorId] [INT] NOT NULL,
    [ParentLocalEducationAgencyId] [BIGINT] NULL,
    [StateEducationAgencyId] [BIGINT] NULL,
    CONSTRAINT [LocalEducationAgency_PK] PRIMARY KEY CLUSTERED (
        [LocalEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LocalEducationAgencyAccountability] --
CREATE TABLE [edfi].[LocalEducationAgencyAccountability] (
    [LocalEducationAgencyId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [GunFreeSchoolsActReportingStatusDescriptorId] [INT] NULL,
    [SchoolChoiceImplementStatusDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LocalEducationAgencyAccountability_PK] PRIMARY KEY CLUSTERED (
        [LocalEducationAgencyId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalEducationAgencyAccountability] ADD CONSTRAINT [LocalEducationAgencyAccountability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LocalEducationAgencyCategoryDescriptor] --
CREATE TABLE [edfi].[LocalEducationAgencyCategoryDescriptor] (
    [LocalEducationAgencyCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LocalEducationAgencyCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LocalEducationAgencyCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LocalEducationAgencyFederalFunds] --
CREATE TABLE [edfi].[LocalEducationAgencyFederalFunds] (
    [LocalEducationAgencyId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [InnovativeDollarsSpent] [MONEY] NULL,
    [InnovativeDollarsSpentStrategicPriorities] [MONEY] NULL,
    [InnovativeProgramsFundsReceived] [MONEY] NULL,
    [SchoolImprovementAllocation] [MONEY] NULL,
    [SchoolImprovementReservedFundsPercentage] [DECIMAL](5, 4) NULL,
    [StateAssessmentAdministrationFunding] [DECIMAL](5, 4) NULL,
    [SupplementalEducationalServicesFundsSpent] [MONEY] NULL,
    [SupplementalEducationalServicesPerPupilExpenditure] [MONEY] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LocalEducationAgencyFederalFunds_PK] PRIMARY KEY CLUSTERED (
        [LocalEducationAgencyId] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalEducationAgencyFederalFunds] ADD CONSTRAINT [LocalEducationAgencyFederalFunds_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[LocalEncumbrance] --
CREATE TABLE [edfi].[LocalEncumbrance] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [Amount] [MONEY] NOT NULL,
    [FinancialCollectionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LocalEncumbrance_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [AsOfDate] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalEncumbrance] ADD CONSTRAINT [LocalEncumbrance_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalEncumbrance] ADD CONSTRAINT [LocalEncumbrance_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalEncumbrance] ADD CONSTRAINT [LocalEncumbrance_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalPayroll] --
CREATE TABLE [edfi].[LocalPayroll] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [Amount] [MONEY] NOT NULL,
    [FinancialCollectionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LocalPayroll_PK] PRIMARY KEY CLUSTERED (
        [AccountIdentifier] ASC,
        [AsOfDate] ASC,
        [EducationOrganizationId] ASC,
        [FiscalYear] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalPayroll] ADD CONSTRAINT [LocalPayroll_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalPayroll] ADD CONSTRAINT [LocalPayroll_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalPayroll] ADD CONSTRAINT [LocalPayroll_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[Location] --
CREATE TABLE [edfi].[Location] (
    [ClassroomIdentificationCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [MaximumNumberOfSeats] [INT] NULL,
    [OptimalNumberOfSeats] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Location_PK] PRIMARY KEY CLUSTERED (
        [ClassroomIdentificationCode] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Location] ADD CONSTRAINT [Location_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Location] ADD CONSTRAINT [Location_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Location] ADD CONSTRAINT [Location_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] --
CREATE TABLE [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] (
    [MagnetSpecialProgramEmphasisSchoolDescriptorId] [INT] NOT NULL,
    CONSTRAINT [MagnetSpecialProgramEmphasisSchoolDescriptor_PK] PRIMARY KEY CLUSTERED (
        [MagnetSpecialProgramEmphasisSchoolDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[MediumOfInstructionDescriptor] --
CREATE TABLE [edfi].[MediumOfInstructionDescriptor] (
    [MediumOfInstructionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [MediumOfInstructionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [MediumOfInstructionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[MethodCreditEarnedDescriptor] --
CREATE TABLE [edfi].[MethodCreditEarnedDescriptor] (
    [MethodCreditEarnedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [MethodCreditEarnedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [MethodCreditEarnedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[MigrantEducationProgramServiceDescriptor] --
CREATE TABLE [edfi].[MigrantEducationProgramServiceDescriptor] (
    [MigrantEducationProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [MigrantEducationProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [MigrantEducationProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ModelEntityDescriptor] --
CREATE TABLE [edfi].[ModelEntityDescriptor] (
    [ModelEntityDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ModelEntityDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ModelEntityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[MonitoredDescriptor] --
CREATE TABLE [edfi].[MonitoredDescriptor] (
    [MonitoredDescriptorId] [INT] NOT NULL,
    CONSTRAINT [MonitoredDescriptor_PK] PRIMARY KEY CLUSTERED (
        [MonitoredDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[NeglectedOrDelinquentProgramDescriptor] --
CREATE TABLE [edfi].[NeglectedOrDelinquentProgramDescriptor] (
    [NeglectedOrDelinquentProgramDescriptorId] [INT] NOT NULL,
    CONSTRAINT [NeglectedOrDelinquentProgramDescriptor_PK] PRIMARY KEY CLUSTERED (
        [NeglectedOrDelinquentProgramDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] --
CREATE TABLE [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] (
    [NeglectedOrDelinquentProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [NeglectedOrDelinquentProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [NeglectedOrDelinquentProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[NetworkPurposeDescriptor] --
CREATE TABLE [edfi].[NetworkPurposeDescriptor] (
    [NetworkPurposeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [NetworkPurposeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [NetworkPurposeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[NonMedicalImmunizationExemptionDescriptor] --
CREATE TABLE [edfi].[NonMedicalImmunizationExemptionDescriptor] (
    [NonMedicalImmunizationExemptionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [NonMedicalImmunizationExemptionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [NonMedicalImmunizationExemptionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ObjectDimension] --
CREATE TABLE [edfi].[ObjectDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ObjectDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectDimension] ADD CONSTRAINT [ObjectDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ObjectDimension] ADD CONSTRAINT [ObjectDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ObjectDimension] ADD CONSTRAINT [ObjectDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ObjectDimensionReportingTag] --
CREATE TABLE [edfi].[ObjectDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectDimensionReportingTag] ADD CONSTRAINT [ObjectDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessment] --
CREATE TABLE [edfi].[ObjectiveAssessment] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [Description] [NVARCHAR](1024) NULL,
    [MaxRawScore] [DECIMAL](15, 5) NULL,
    [Nomenclature] [NVARCHAR](100) NULL,
    [ParentIdentificationCode] [NVARCHAR](120) NULL,
    [PercentOfAssessment] [DECIMAL](5, 4) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ObjectiveAssessment_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessment] ADD CONSTRAINT [ObjectiveAssessment_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ObjectiveAssessment] ADD CONSTRAINT [ObjectiveAssessment_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ObjectiveAssessment] ADD CONSTRAINT [ObjectiveAssessment_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ObjectiveAssessmentAssessmentItem] --
CREATE TABLE [edfi].[ObjectiveAssessmentAssessmentItem] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentItemIdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentAssessmentItem_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [AssessmentItemIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentAssessmentItem] ADD CONSTRAINT [ObjectiveAssessmentAssessmentItem_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessmentLearningStandard] --
CREATE TABLE [edfi].[ObjectiveAssessmentLearningStandard] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentLearningStandard] ADD CONSTRAINT [ObjectiveAssessmentLearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [PerformanceLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] ADD CONSTRAINT [ObjectiveAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessmentScore] --
CREATE TABLE [edfi].[ObjectiveAssessmentScore] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentScore_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [AssessmentReportingMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentScore] ADD CONSTRAINT [ObjectiveAssessmentScore_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveRatingLevelDescriptor] --
CREATE TABLE [edfi].[ObjectiveRatingLevelDescriptor] (
    [ObjectiveRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ObjectiveRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ObjectiveRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[OpenStaffPosition] --
CREATE TABLE [edfi].[OpenStaffPosition] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [DatePosted] [DATE] NOT NULL,
    [DatePostingRemoved] [DATE] NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
    [FundingSourceDescriptorId] [INT] NULL,
    [HighNeedAcademicSubject] [BIT] NULL,
    [IsActive] [BIT] NULL,
    [MaxSalary] [DECIMAL](9, 2) NULL,
    [MinSalary] [DECIMAL](9, 2) NULL,
    [OpenStaffPositionReasonDescriptorId] [INT] NULL,
    [PositionControlNumber] [NVARCHAR](20) NULL,
    [PositionTitle] [NVARCHAR](100) NULL,
    [PostingResultDescriptorId] [INT] NULL,
    [ProgramAssignmentDescriptorId] [INT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [StaffClassificationDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NULL,
    [TotalBudgeted] [DECIMAL](9, 2) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [OpenStaffPosition_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[OpenStaffPosition] ADD CONSTRAINT [OpenStaffPosition_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[OpenStaffPosition] ADD CONSTRAINT [OpenStaffPosition_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[OpenStaffPosition] ADD CONSTRAINT [OpenStaffPosition_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[OpenStaffPositionAcademicSubject] --
CREATE TABLE [edfi].[OpenStaffPositionAcademicSubject] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [OpenStaffPositionAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RequisitionNumber] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[OpenStaffPositionAcademicSubject] ADD CONSTRAINT [OpenStaffPositionAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[OpenStaffPositionEvent] --
CREATE TABLE [edfi].[OpenStaffPositionEvent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
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
ALTER TABLE [edfi].[OpenStaffPositionEvent] ADD CONSTRAINT [OpenStaffPositionEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[OpenStaffPositionEvent] ADD CONSTRAINT [OpenStaffPositionEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[OpenStaffPositionEvent] ADD CONSTRAINT [OpenStaffPositionEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[OpenStaffPositionEventStatusDescriptor] --
CREATE TABLE [edfi].[OpenStaffPositionEventStatusDescriptor] (
    [OpenStaffPositionEventStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OpenStaffPositionEventStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OpenStaffPositionEventStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[OpenStaffPositionEventTypeDescriptor] --
CREATE TABLE [edfi].[OpenStaffPositionEventTypeDescriptor] (
    [OpenStaffPositionEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OpenStaffPositionEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OpenStaffPositionEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[OpenStaffPositionInstructionalGradeLevel] --
CREATE TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [OpenStaffPositionInstructionalGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RequisitionNumber] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] ADD CONSTRAINT [OpenStaffPositionInstructionalGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[OpenStaffPositionReasonDescriptor] --
CREATE TABLE [edfi].[OpenStaffPositionReasonDescriptor] (
    [OpenStaffPositionReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OpenStaffPositionReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OpenStaffPositionReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[OperationalStatusDescriptor] --
CREATE TABLE [edfi].[OperationalStatusDescriptor] (
    [OperationalStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OperationalStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OperationalStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[OperationalUnitDimension] --
CREATE TABLE [edfi].[OperationalUnitDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [OperationalUnitDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[OperationalUnitDimension] ADD CONSTRAINT [OperationalUnitDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[OperationalUnitDimension] ADD CONSTRAINT [OperationalUnitDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[OperationalUnitDimension] ADD CONSTRAINT [OperationalUnitDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[OperationalUnitDimensionReportingTag] --
CREATE TABLE [edfi].[OperationalUnitDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [OperationalUnitDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[OperationalUnitDimensionReportingTag] ADD CONSTRAINT [OperationalUnitDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[OrganizationDepartment] --
CREATE TABLE [edfi].[OrganizationDepartment] (
    [OrganizationDepartmentId] [BIGINT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [ParentEducationOrganizationId] [BIGINT] NULL,
    CONSTRAINT [OrganizationDepartment_PK] PRIMARY KEY CLUSTERED (
        [OrganizationDepartmentId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[OtherNameTypeDescriptor] --
CREATE TABLE [edfi].[OtherNameTypeDescriptor] (
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OtherNameTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OtherNameTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ParticipationDescriptor] --
CREATE TABLE [edfi].[ParticipationDescriptor] (
    [ParticipationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ParticipationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ParticipationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ParticipationStatusDescriptor] --
CREATE TABLE [edfi].[ParticipationStatusDescriptor] (
    [ParticipationStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ParticipationStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ParticipationStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Path] --
CREATE TABLE [edfi].[Path] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NULL,
    [GraduationSchoolYear] [SMALLINT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Path_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Path] ADD CONSTRAINT [Path_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Path] ADD CONSTRAINT [Path_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Path] ADD CONSTRAINT [Path_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[PathMilestone] --
CREATE TABLE [edfi].[PathMilestone] (
    [PathMilestoneName] [NVARCHAR](60) NOT NULL,
    [PathMilestoneTypeDescriptorId] [INT] NOT NULL,
    [PathMilestoneCode] [NVARCHAR](60) NULL,
    [PathMilestoneDescription] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [PathMilestone_PK] PRIMARY KEY CLUSTERED (
        [PathMilestoneName] ASC,
        [PathMilestoneTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PathMilestone] ADD CONSTRAINT [PathMilestone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[PathMilestone] ADD CONSTRAINT [PathMilestone_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[PathMilestone] ADD CONSTRAINT [PathMilestone_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[PathMilestoneStatusDescriptor] --
CREATE TABLE [edfi].[PathMilestoneStatusDescriptor] (
    [PathMilestoneStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PathMilestoneStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PathMilestoneStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PathMilestoneTypeDescriptor] --
CREATE TABLE [edfi].[PathMilestoneTypeDescriptor] (
    [PathMilestoneTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PathMilestoneTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PathMilestoneTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PathPhase] --
CREATE TABLE [edfi].[PathPhase] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [PathPhaseName] [NVARCHAR](60) NOT NULL,
    [PathPhaseSequence] [INT] NULL,
    [PhasePathDescription] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [PathPhase_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC,
        [PathPhaseName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PathPhase] ADD CONSTRAINT [PathPhase_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[PathPhase] ADD CONSTRAINT [PathPhase_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[PathPhase] ADD CONSTRAINT [PathPhase_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[PathPhasePathMilestone] --
CREATE TABLE [edfi].[PathPhasePathMilestone] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [PathPhaseName] [NVARCHAR](60) NOT NULL,
    [PathMilestoneName] [NVARCHAR](60) NOT NULL,
    [PathMilestoneTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PathPhasePathMilestone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC,
        [PathPhaseName] ASC,
        [PathMilestoneName] ASC,
        [PathMilestoneTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PathPhasePathMilestone] ADD CONSTRAINT [PathPhasePathMilestone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[PathPhaseStatusDescriptor] --
CREATE TABLE [edfi].[PathPhaseStatusDescriptor] (
    [PathPhaseStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PathPhaseStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PathPhaseStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PerformanceBaseConversionDescriptor] --
CREATE TABLE [edfi].[PerformanceBaseConversionDescriptor] (
    [PerformanceBaseConversionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PerformanceBaseConversionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PerformanceBaseConversionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PerformanceEvaluation] --
CREATE TABLE [edfi].[PerformanceEvaluation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [PerformanceEvaluationDescription] [NVARCHAR](255) NULL,
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
ALTER TABLE [edfi].[PerformanceEvaluation] ADD CONSTRAINT [PerformanceEvaluation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[PerformanceEvaluation] ADD CONSTRAINT [PerformanceEvaluation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[PerformanceEvaluation] ADD CONSTRAINT [PerformanceEvaluation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[PerformanceEvaluationGradeLevel] --
CREATE TABLE [edfi].[PerformanceEvaluationGradeLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PerformanceEvaluationGradeLevel] ADD CONSTRAINT [PerformanceEvaluationGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[PerformanceEvaluationRating] --
CREATE TABLE [edfi].[PerformanceEvaluationRating] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ActualDate] [DATE] NOT NULL,
    [ActualDuration] [INT] NULL,
    [ActualTime] [TIME](7) NULL,
    [Announced] [BIT] NULL,
    [Comments] [NVARCHAR](1024) NULL,
    [CoteachingStyleObservedDescriptorId] [INT] NULL,
    [PerformanceEvaluationRatingLevelDescriptorId] [INT] NULL,
    [ScheduleDate] [DATE] NULL,
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
ALTER TABLE [edfi].[PerformanceEvaluationRating] ADD CONSTRAINT [PerformanceEvaluationRating_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[PerformanceEvaluationRating] ADD CONSTRAINT [PerformanceEvaluationRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[PerformanceEvaluationRating] ADD CONSTRAINT [PerformanceEvaluationRating_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[PerformanceEvaluationRatingLevel] --
CREATE TABLE [edfi].[PerformanceEvaluationRatingLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC,
        [EvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PerformanceEvaluationRatingLevel] ADD CONSTRAINT [PerformanceEvaluationRatingLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[PerformanceEvaluationRatingLevelDescriptor] --
CREATE TABLE [edfi].[PerformanceEvaluationRatingLevelDescriptor] (
    [PerformanceEvaluationRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PerformanceEvaluationRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PerformanceEvaluationRatingResult] --
CREATE TABLE [edfi].[PerformanceEvaluationRatingResult] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [NumericRating] [DECIMAL](6, 3) NOT NULL,
    [RatingResultTitle] [NVARCHAR](50) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingResult_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [NumericRating] ASC,
        [RatingResultTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PerformanceEvaluationRatingResult] ADD CONSTRAINT [PerformanceEvaluationRatingResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[PerformanceEvaluationRatingReviewer] --
CREATE TABLE [edfi].[PerformanceEvaluationRatingReviewer] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [ReviewerPersonId] [NVARCHAR](32) NULL,
    [ReviewerSourceSystemDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingReviewer_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [FirstName] ASC,
        [LastSurname] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PerformanceEvaluationRatingReviewer] ADD CONSTRAINT [PerformanceEvaluationRatingReviewer_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[PerformanceEvaluationRatingReviewerReceivedTraining] --
CREATE TABLE [edfi].[PerformanceEvaluationRatingReviewerReceivedTraining] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [InterRaterReliabilityScore] [INT] NULL,
    [ReceivedTrainingDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PerformanceEvaluationRatingReviewerReceivedTraining_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EvaluationPeriodDescriptorId] ASC,
        [PerformanceEvaluationTitle] ASC,
        [PerformanceEvaluationTypeDescriptorId] ASC,
        [PersonId] ASC,
        [SchoolYear] ASC,
        [SourceSystemDescriptorId] ASC,
        [TermDescriptorId] ASC,
        [FirstName] ASC,
        [LastSurname] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PerformanceEvaluationRatingReviewerReceivedTraining] ADD CONSTRAINT [PerformanceEvaluationRatingReviewerReceivedTraining_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[PerformanceEvaluationTypeDescriptor] --
CREATE TABLE [edfi].[PerformanceEvaluationTypeDescriptor] (
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PerformanceEvaluationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PerformanceEvaluationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PerformanceLevelDescriptor] --
CREATE TABLE [edfi].[PerformanceLevelDescriptor] (
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PerformanceLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PerformanceLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Person] --
CREATE TABLE [edfi].[Person] (
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Person_PK] PRIMARY KEY CLUSTERED (
        [PersonId] ASC,
        [SourceSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Person] ADD CONSTRAINT [Person_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Person] ADD CONSTRAINT [Person_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Person] ADD CONSTRAINT [Person_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[PersonalInformationVerificationDescriptor] --
CREATE TABLE [edfi].[PersonalInformationVerificationDescriptor] (
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PersonalInformationVerificationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PlatformTypeDescriptor] --
CREATE TABLE [edfi].[PlatformTypeDescriptor] (
    [PlatformTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PlatformTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PlatformTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PopulationServedDescriptor] --
CREATE TABLE [edfi].[PopulationServedDescriptor] (
    [PopulationServedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PopulationServedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PostingResultDescriptor] --
CREATE TABLE [edfi].[PostingResultDescriptor] (
    [PostingResultDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PostingResultDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PostingResultDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PostSecondaryEvent] --
CREATE TABLE [edfi].[PostSecondaryEvent] (
    [EventDate] [DATE] NOT NULL,
    [PostSecondaryEventCategoryDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PostSecondaryInstitutionId] [BIGINT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [PostSecondaryEvent_PK] PRIMARY KEY CLUSTERED (
        [EventDate] ASC,
        [PostSecondaryEventCategoryDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PostSecondaryEvent] ADD CONSTRAINT [PostSecondaryEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[PostSecondaryEvent] ADD CONSTRAINT [PostSecondaryEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[PostSecondaryEvent] ADD CONSTRAINT [PostSecondaryEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[PostSecondaryEventCategoryDescriptor] --
CREATE TABLE [edfi].[PostSecondaryEventCategoryDescriptor] (
    [PostSecondaryEventCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PostSecondaryEventCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PostSecondaryEventCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PostSecondaryInstitution] --
CREATE TABLE [edfi].[PostSecondaryInstitution] (
    [PostSecondaryInstitutionId] [BIGINT] NOT NULL,
    [AdministrativeFundingControlDescriptorId] [INT] NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    [PostSecondaryInstitutionLevelDescriptorId] [INT] NULL,
    CONSTRAINT [PostSecondaryInstitution_PK] PRIMARY KEY CLUSTERED (
        [PostSecondaryInstitutionId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PostSecondaryInstitutionLevelDescriptor] --
CREATE TABLE [edfi].[PostSecondaryInstitutionLevelDescriptor] (
    [PostSecondaryInstitutionLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PostSecondaryInstitutionLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PostSecondaryInstitutionLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PostSecondaryInstitutionMediumOfInstruction] --
CREATE TABLE [edfi].[PostSecondaryInstitutionMediumOfInstruction] (
    [PostSecondaryInstitutionId] [BIGINT] NOT NULL,
    [MediumOfInstructionDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PostSecondaryInstitutionMediumOfInstruction_PK] PRIMARY KEY CLUSTERED (
        [PostSecondaryInstitutionId] ASC,
        [MediumOfInstructionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PostSecondaryInstitutionMediumOfInstruction] ADD CONSTRAINT [PostSecondaryInstitutionMediumOfInstruction_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[PreviousCareerDescriptor] --
CREATE TABLE [edfi].[PreviousCareerDescriptor] (
    [PreviousCareerDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PreviousCareerDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PreviousCareerDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PrimaryLearningDeviceAccessDescriptor] --
CREATE TABLE [edfi].[PrimaryLearningDeviceAccessDescriptor] (
    [PrimaryLearningDeviceAccessDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PrimaryLearningDeviceAccessDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PrimaryLearningDeviceAccessDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] --
CREATE TABLE [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] (
    [PrimaryLearningDeviceAwayFromSchoolDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PrimaryLearningDeviceAwayFromSchoolDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PrimaryLearningDeviceAwayFromSchoolDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PrimaryLearningDeviceProviderDescriptor] --
CREATE TABLE [edfi].[PrimaryLearningDeviceProviderDescriptor] (
    [PrimaryLearningDeviceProviderDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PrimaryLearningDeviceProviderDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PrimaryLearningDeviceProviderDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProfessionalDevelopmentEvent] --
CREATE TABLE [edfi].[ProfessionalDevelopmentEvent] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProfessionalDevelopmentTitle] [NVARCHAR](60) NOT NULL,
    [MultipleSession] [BIT] NULL,
    [ProfessionalDevelopmentOfferedByDescriptorId] [INT] NOT NULL,
    [ProfessionalDevelopmentReason] [NVARCHAR](60) NULL,
    [Required] [BIT] NULL,
    [TotalHours] [INT] NULL,
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
ALTER TABLE [edfi].[ProfessionalDevelopmentEvent] ADD CONSTRAINT [ProfessionalDevelopmentEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProfessionalDevelopmentEvent] ADD CONSTRAINT [ProfessionalDevelopmentEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProfessionalDevelopmentEvent] ADD CONSTRAINT [ProfessionalDevelopmentEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProfessionalDevelopmentEventAttendance] --
CREATE TABLE [edfi].[ProfessionalDevelopmentEventAttendance] (
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
ALTER TABLE [edfi].[ProfessionalDevelopmentEventAttendance] ADD CONSTRAINT [ProfessionalDevelopmentEventAttendance_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProfessionalDevelopmentEventAttendance] ADD CONSTRAINT [ProfessionalDevelopmentEventAttendance_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProfessionalDevelopmentEventAttendance] ADD CONSTRAINT [ProfessionalDevelopmentEventAttendance_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProfessionalDevelopmentOfferedByDescriptor] --
CREATE TABLE [edfi].[ProfessionalDevelopmentOfferedByDescriptor] (
    [ProfessionalDevelopmentOfferedByDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProfessionalDevelopmentOfferedByDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProfessionalDevelopmentOfferedByDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProficiencyDescriptor] --
CREATE TABLE [edfi].[ProficiencyDescriptor] (
    [ProficiencyDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProficiencyDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProficiencyDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Program] --
CREATE TABLE [edfi].[Program] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ProgramId] [NVARCHAR](20) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Program_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Program] ADD CONSTRAINT [Program_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Program] ADD CONSTRAINT [Program_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Program] ADD CONSTRAINT [Program_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProgramAssignmentDescriptor] --
CREATE TABLE [edfi].[ProgramAssignmentDescriptor] (
    [ProgramAssignmentDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgramAssignmentDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgramAssignmentDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProgramCharacteristic] --
CREATE TABLE [edfi].[ProgramCharacteristic] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ProgramCharacteristicDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [ProgramCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramCharacteristic] ADD CONSTRAINT [ProgramCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramCharacteristicDescriptor] --
CREATE TABLE [edfi].[ProgramCharacteristicDescriptor] (
    [ProgramCharacteristicDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgramCharacteristicDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgramCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProgramDimension] --
CREATE TABLE [edfi].[ProgramDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ProgramDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramDimension] ADD CONSTRAINT [ProgramDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProgramDimension] ADD CONSTRAINT [ProgramDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProgramDimension] ADD CONSTRAINT [ProgramDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProgramDimensionReportingTag] --
CREATE TABLE [edfi].[ProgramDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramDimensionReportingTag] ADD CONSTRAINT [ProgramDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramEvaluation] --
CREATE TABLE [edfi].[ProgramEvaluation] (
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [EvaluationMaxNumericRating] [DECIMAL](6, 3) NULL,
    [EvaluationMinNumericRating] [DECIMAL](6, 3) NULL,
    [ProgramEvaluationDescription] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ProgramEvaluation_PK] PRIMARY KEY CLUSTERED (
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramEvaluation] ADD CONSTRAINT [ProgramEvaluation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProgramEvaluation] ADD CONSTRAINT [ProgramEvaluation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProgramEvaluation] ADD CONSTRAINT [ProgramEvaluation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProgramEvaluationElement] --
CREATE TABLE [edfi].[ProgramEvaluationElement] (
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationElementTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ElementMaxNumericRating] [DECIMAL](6, 3) NULL,
    [ElementMinNumericRating] [DECIMAL](6, 3) NULL,
    [ElementSortOrder] [INT] NULL,
    [ProgramEvaluationElementDescription] [NVARCHAR](255) NULL,
    [ProgramEvaluationObjectiveTitle] [NVARCHAR](50) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ProgramEvaluationElement_PK] PRIMARY KEY CLUSTERED (
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationElementTitle] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramEvaluationElement] ADD CONSTRAINT [ProgramEvaluationElement_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProgramEvaluationElement] ADD CONSTRAINT [ProgramEvaluationElement_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProgramEvaluationElement] ADD CONSTRAINT [ProgramEvaluationElement_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProgramEvaluationElementProgramEvaluationLevel] --
CREATE TABLE [edfi].[ProgramEvaluationElementProgramEvaluationLevel] (
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationElementTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [RatingLevelDescriptorId] [INT] NOT NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramEvaluationElementProgramEvaluationLevel_PK] PRIMARY KEY CLUSTERED (
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationElementTitle] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [RatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramEvaluationElementProgramEvaluationLevel] ADD CONSTRAINT [ProgramEvaluationElementProgramEvaluationLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramEvaluationLevel] --
CREATE TABLE [edfi].[ProgramEvaluationLevel] (
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [RatingLevelDescriptorId] [INT] NOT NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramEvaluationLevel_PK] PRIMARY KEY CLUSTERED (
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [RatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramEvaluationLevel] ADD CONSTRAINT [ProgramEvaluationLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramEvaluationObjective] --
CREATE TABLE [edfi].[ProgramEvaluationObjective] (
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ObjectiveMaxNumericRating] [DECIMAL](6, 3) NULL,
    [ObjectiveMinNumericRating] [DECIMAL](6, 3) NULL,
    [ObjectiveSortOrder] [INT] NULL,
    [ProgramEvaluationObjectiveDescription] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ProgramEvaluationObjective_PK] PRIMARY KEY CLUSTERED (
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationObjectiveTitle] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramEvaluationObjective] ADD CONSTRAINT [ProgramEvaluationObjective_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProgramEvaluationObjective] ADD CONSTRAINT [ProgramEvaluationObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProgramEvaluationObjective] ADD CONSTRAINT [ProgramEvaluationObjective_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProgramEvaluationObjectiveProgramEvaluationLevel] --
CREATE TABLE [edfi].[ProgramEvaluationObjectiveProgramEvaluationLevel] (
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [RatingLevelDescriptorId] [INT] NOT NULL,
    [MaxNumericRating] [DECIMAL](6, 3) NULL,
    [MinNumericRating] [DECIMAL](6, 3) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramEvaluationObjectiveProgramEvaluationLevel_PK] PRIMARY KEY CLUSTERED (
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationObjectiveTitle] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [RatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramEvaluationObjectiveProgramEvaluationLevel] ADD CONSTRAINT [ProgramEvaluationObjectiveProgramEvaluationLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramEvaluationPeriodDescriptor] --
CREATE TABLE [edfi].[ProgramEvaluationPeriodDescriptor] (
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgramEvaluationPeriodDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgramEvaluationPeriodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProgramEvaluationTypeDescriptor] --
CREATE TABLE [edfi].[ProgramEvaluationTypeDescriptor] (
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgramEvaluationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgramEvaluationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProgramLearningStandard] --
CREATE TABLE [edfi].[ProgramLearningStandard] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramLearningStandard] ADD CONSTRAINT [ProgramLearningStandard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramSponsor] --
CREATE TABLE [edfi].[ProgramSponsor] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ProgramSponsorDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramSponsor_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [ProgramSponsorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramSponsor] ADD CONSTRAINT [ProgramSponsor_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramSponsorDescriptor] --
CREATE TABLE [edfi].[ProgramSponsorDescriptor] (
    [ProgramSponsorDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgramSponsorDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgramSponsorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProgramTypeDescriptor] --
CREATE TABLE [edfi].[ProgramTypeDescriptor] (
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgramTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProgressDescriptor] --
CREATE TABLE [edfi].[ProgressDescriptor] (
    [ProgressDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgressDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgressDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProgressLevelDescriptor] --
CREATE TABLE [edfi].[ProgressLevelDescriptor] (
    [ProgressLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProgressLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProgressLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProjectDimension] --
CREATE TABLE [edfi].[ProjectDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ProjectDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProjectDimension] ADD CONSTRAINT [ProjectDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProjectDimension] ADD CONSTRAINT [ProjectDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProjectDimension] ADD CONSTRAINT [ProjectDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ProjectDimensionReportingTag] --
CREATE TABLE [edfi].[ProjectDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProjectDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProjectDimensionReportingTag] ADD CONSTRAINT [ProjectDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProviderCategoryDescriptor] --
CREATE TABLE [edfi].[ProviderCategoryDescriptor] (
    [ProviderCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProviderCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProviderCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProviderProfitabilityDescriptor] --
CREATE TABLE [edfi].[ProviderProfitabilityDescriptor] (
    [ProviderProfitabilityDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProviderProfitabilityDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProviderProfitabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ProviderStatusDescriptor] --
CREATE TABLE [edfi].[ProviderStatusDescriptor] (
    [ProviderStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProviderStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProviderStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[PublicationStatusDescriptor] --
CREATE TABLE [edfi].[PublicationStatusDescriptor] (
    [PublicationStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PublicationStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PublicationStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[QuantitativeMeasure] --
CREATE TABLE [edfi].[QuantitativeMeasure] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [QuantitativeMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [QuantitativeMeasureDatatypeDescriptorId] [INT] NULL,
    [QuantitativeMeasureTypeDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[QuantitativeMeasure] ADD CONSTRAINT [QuantitativeMeasure_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[QuantitativeMeasure] ADD CONSTRAINT [QuantitativeMeasure_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[QuantitativeMeasure] ADD CONSTRAINT [QuantitativeMeasure_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[QuantitativeMeasureDatatypeDescriptor] --
CREATE TABLE [edfi].[QuantitativeMeasureDatatypeDescriptor] (
    [QuantitativeMeasureDatatypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [QuantitativeMeasureDatatypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [QuantitativeMeasureDatatypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[QuantitativeMeasureScore] --
CREATE TABLE [edfi].[QuantitativeMeasureScore] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
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
ALTER TABLE [edfi].[QuantitativeMeasureScore] ADD CONSTRAINT [QuantitativeMeasureScore_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[QuantitativeMeasureScore] ADD CONSTRAINT [QuantitativeMeasureScore_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[QuantitativeMeasureScore] ADD CONSTRAINT [QuantitativeMeasureScore_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[QuantitativeMeasureTypeDescriptor] --
CREATE TABLE [edfi].[QuantitativeMeasureTypeDescriptor] (
    [QuantitativeMeasureTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [QuantitativeMeasureTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [QuantitativeMeasureTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[QuestionFormDescriptor] --
CREATE TABLE [edfi].[QuestionFormDescriptor] (
    [QuestionFormDescriptorId] [INT] NOT NULL,
    CONSTRAINT [QuestionFormDescriptor_PK] PRIMARY KEY CLUSTERED (
        [QuestionFormDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RaceDescriptor] --
CREATE TABLE [edfi].[RaceDescriptor] (
    [RaceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RaceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RatingLevelDescriptor] --
CREATE TABLE [edfi].[RatingLevelDescriptor] (
    [RatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ReasonExitedDescriptor] --
CREATE TABLE [edfi].[ReasonExitedDescriptor] (
    [ReasonExitedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ReasonExitedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ReasonExitedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ReasonNotTestedDescriptor] --
CREATE TABLE [edfi].[ReasonNotTestedDescriptor] (
    [ReasonNotTestedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ReasonNotTestedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ReasonNotTestedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RecognitionTypeDescriptor] --
CREATE TABLE [edfi].[RecognitionTypeDescriptor] (
    [RecognitionTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RecognitionTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RecognitionTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RecruitmentEvent] --
CREATE TABLE [edfi].[RecruitmentEvent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [EventDescription] [NVARCHAR](255) NULL,
    [EventLocation] [NVARCHAR](255) NULL,
    [RecruitmentEventTypeDescriptorId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[RecruitmentEvent] ADD CONSTRAINT [RecruitmentEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[RecruitmentEvent] ADD CONSTRAINT [RecruitmentEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[RecruitmentEvent] ADD CONSTRAINT [RecruitmentEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[RecruitmentEventAttendance] --
CREATE TABLE [edfi].[RecruitmentEventAttendance] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [Applied] [BIT] NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [Met] [BIT] NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [Notes] [NVARCHAR](255) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [PreferredFirstName] [NVARCHAR](75) NULL,
    [PreferredLastSurname] [NVARCHAR](75) NULL,
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
ALTER TABLE [edfi].[RecruitmentEventAttendance] ADD CONSTRAINT [RecruitmentEventAttendance_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendance] ADD CONSTRAINT [RecruitmentEventAttendance_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendance] ADD CONSTRAINT [RecruitmentEventAttendance_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceCurrentPosition] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceCurrentPosition] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [Location] [NVARCHAR](75) NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [PositionTitle] [NVARCHAR](100) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceCurrentPosition_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendanceCurrentPosition] ADD CONSTRAINT [RecruitmentEventAttendanceCurrentPosition_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceCurrentPositionGradeLevel] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceCurrentPositionGradeLevel] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceCurrentPositionGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendanceCurrentPositionGradeLevel] ADD CONSTRAINT [RecruitmentEventAttendanceCurrentPositionGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceDisability] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceDisability] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceDisability_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendanceDisability] ADD CONSTRAINT [RecruitmentEventAttendanceDisability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceDisabilityDesignation] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceDisabilityDesignation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendanceDisabilityDesignation] ADD CONSTRAINT [RecruitmentEventAttendanceDisabilityDesignation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] --
CREATE TABLE [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendancePersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] ADD CONSTRAINT [RecruitmentEventAttendancePersonalIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceRace] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceRace] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendanceRace_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [RecruitmentEventAttendeeIdentifier] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RecruitmentEventAttendanceRace] ADD CONSTRAINT [RecruitmentEventAttendanceRace_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [CapacityToServe] [BIT] NULL,
    [Eligible] [BIT] NOT NULL,
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
ALTER TABLE [edfi].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] ADD CONSTRAINT [RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceTelephone] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceTelephone] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [RecruitmentEventAttendeeIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
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
ALTER TABLE [edfi].[RecruitmentEventAttendanceTelephone] ADD CONSTRAINT [RecruitmentEventAttendanceTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendanceTouchpoint] --
CREATE TABLE [edfi].[RecruitmentEventAttendanceTouchpoint] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
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
ALTER TABLE [edfi].[RecruitmentEventAttendanceTouchpoint] ADD CONSTRAINT [RecruitmentEventAttendanceTouchpoint_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RecruitmentEventAttendeeTypeDescriptor] --
CREATE TABLE [edfi].[RecruitmentEventAttendeeTypeDescriptor] (
    [RecruitmentEventAttendeeTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RecruitmentEventAttendeeTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RecruitmentEventAttendeeTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RecruitmentEventTypeDescriptor] --
CREATE TABLE [edfi].[RecruitmentEventTypeDescriptor] (
    [RecruitmentEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RecruitmentEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RecruitmentEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RelationDescriptor] --
CREATE TABLE [edfi].[RelationDescriptor] (
    [RelationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RelationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RelationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RepeatIdentifierDescriptor] --
CREATE TABLE [edfi].[RepeatIdentifierDescriptor] (
    [RepeatIdentifierDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RepeatIdentifierDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RepeatIdentifierDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ReportCard] --
CREATE TABLE [edfi].[ReportCard] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [NumberOfDaysAbsent] [DECIMAL](18, 4) NULL,
    [NumberOfDaysInAttendance] [DECIMAL](18, 4) NULL,
    [NumberOfDaysTardy] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ReportCard_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCard] ADD CONSTRAINT [ReportCard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ReportCard] ADD CONSTRAINT [ReportCard_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ReportCard] ADD CONSTRAINT [ReportCard_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ReportCardGrade] --
CREATE TABLE [edfi].[ReportCardGrade] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [GradeTypeDescriptorId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ReportCardGrade_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [StudentUSI] ASC,
        [BeginDate] ASC,
        [GradeTypeDescriptorId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCardGrade] ADD CONSTRAINT [ReportCardGrade_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ReportCardGradePointAverage] --
CREATE TABLE [edfi].[ReportCardGradePointAverage] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [IsCumulative] [BIT] NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ReportCardGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [StudentUSI] ASC,
        [GradePointAverageTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCardGradePointAverage] ADD CONSTRAINT [ReportCardGradePointAverage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ReportCardStudentCompetencyObjective] --
CREATE TABLE [edfi].[ReportCardStudentCompetencyObjective] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ObjectiveEducationOrganizationId] [BIGINT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ReportCardStudentCompetencyObjective_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [StudentUSI] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [Objective] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCardStudentCompetencyObjective] ADD CONSTRAINT [ReportCardStudentCompetencyObjective_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[ReporterDescriptionDescriptor] --
CREATE TABLE [edfi].[ReporterDescriptionDescriptor] (
    [ReporterDescriptionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ReporterDescriptionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ReporterDescriptionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ReportingTagDescriptor] --
CREATE TABLE [edfi].[ReportingTagDescriptor] (
    [ReportingTagDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ReportingTagDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ResidencyStatusDescriptor] --
CREATE TABLE [edfi].[ResidencyStatusDescriptor] (
    [ResidencyStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ResidencyStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ResidencyStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ResponseIndicatorDescriptor] --
CREATE TABLE [edfi].[ResponseIndicatorDescriptor] (
    [ResponseIndicatorDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ResponseIndicatorDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ResponseIndicatorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ResponsibilityDescriptor] --
CREATE TABLE [edfi].[ResponsibilityDescriptor] (
    [ResponsibilityDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ResponsibilityDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ResponsibilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RestraintEvent] --
CREATE TABLE [edfi].[RestraintEvent] (
    [RestraintEventIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [EventDate] [DATE] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [RestraintEvent_PK] PRIMARY KEY CLUSTERED (
        [RestraintEventIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RestraintEvent] ADD CONSTRAINT [RestraintEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[RestraintEvent] ADD CONSTRAINT [RestraintEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[RestraintEvent] ADD CONSTRAINT [RestraintEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[RestraintEventProgram] --
CREATE TABLE [edfi].[RestraintEventProgram] (
    [RestraintEventIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RestraintEventProgram_PK] PRIMARY KEY CLUSTERED (
        [RestraintEventIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RestraintEventProgram] ADD CONSTRAINT [RestraintEventProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RestraintEventReason] --
CREATE TABLE [edfi].[RestraintEventReason] (
    [RestraintEventIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [RestraintEventReasonDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RestraintEventReason_PK] PRIMARY KEY CLUSTERED (
        [RestraintEventIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC,
        [RestraintEventReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RestraintEventReason] ADD CONSTRAINT [RestraintEventReason_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[RestraintEventReasonDescriptor] --
CREATE TABLE [edfi].[RestraintEventReasonDescriptor] (
    [RestraintEventReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RestraintEventReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RestraintEventReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ResultDatatypeTypeDescriptor] --
CREATE TABLE [edfi].[ResultDatatypeTypeDescriptor] (
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ResultDatatypeTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ResultDatatypeTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RetestIndicatorDescriptor] --
CREATE TABLE [edfi].[RetestIndicatorDescriptor] (
    [RetestIndicatorDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RetestIndicatorDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RetestIndicatorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[RubricDimension] --
CREATE TABLE [edfi].[RubricDimension] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NOT NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationPeriodDescriptorId] [INT] NOT NULL,
    [EvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NOT NULL,
    [RubricRating] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CriterionDescription] [NVARCHAR](1024) NOT NULL,
    [DimensionOrder] [INT] NULL,
    [RubricRatingLevelDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[RubricDimension] ADD CONSTRAINT [RubricDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[RubricDimension] ADD CONSTRAINT [RubricDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[RubricDimension] ADD CONSTRAINT [RubricDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[RubricRatingLevelDescriptor] --
CREATE TABLE [edfi].[RubricRatingLevelDescriptor] (
    [RubricRatingLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [RubricRatingLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [RubricRatingLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SalaryTypeDescriptor] --
CREATE TABLE [edfi].[SalaryTypeDescriptor] (
    [SalaryTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SalaryTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SalaryTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[School] --
CREATE TABLE [edfi].[School] (
    [SchoolId] [BIGINT] NOT NULL,
    [AccreditationStatusDescriptorId] [INT] NULL,
    [AdministrativeFundingControlDescriptorId] [INT] NULL,
    [CharterApprovalAgencyTypeDescriptorId] [INT] NULL,
    [CharterApprovalSchoolYear] [SMALLINT] NULL,
    [CharterStatusDescriptorId] [INT] NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    [ImprovingSchool] [BIT] NULL,
    [InternetAccessDescriptorId] [INT] NULL,
    [LocalEducationAgencyId] [BIGINT] NULL,
    [MagnetSpecialProgramEmphasisSchoolDescriptorId] [INT] NULL,
    [PostSecondaryInstitutionId] [BIGINT] NULL,
    [SchoolTypeDescriptorId] [INT] NULL,
    [TitleIPartASchoolDesignationDescriptorId] [INT] NULL,
    CONSTRAINT [School_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SchoolCategory] --
CREATE TABLE [edfi].[SchoolCategory] (
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolCategoryDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SchoolCategory_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC,
        [SchoolCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SchoolCategory] ADD CONSTRAINT [SchoolCategory_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SchoolCategoryDescriptor] --
CREATE TABLE [edfi].[SchoolCategoryDescriptor] (
    [SchoolCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SchoolCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SchoolCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SchoolChoiceBasisDescriptor] --
CREATE TABLE [edfi].[SchoolChoiceBasisDescriptor] (
    [SchoolChoiceBasisDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SchoolChoiceBasisDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SchoolChoiceBasisDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SchoolChoiceImplementStatusDescriptor] --
CREATE TABLE [edfi].[SchoolChoiceImplementStatusDescriptor] (
    [SchoolChoiceImplementStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SchoolChoiceImplementStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SchoolChoiceImplementStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SchoolFoodServiceProgramServiceDescriptor] --
CREATE TABLE [edfi].[SchoolFoodServiceProgramServiceDescriptor] (
    [SchoolFoodServiceProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SchoolFoodServiceProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SchoolFoodServiceProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SchoolGradeLevel] --
CREATE TABLE [edfi].[SchoolGradeLevel] (
    [SchoolId] [BIGINT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SchoolGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SchoolGradeLevel] ADD CONSTRAINT [SchoolGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SchoolTypeDescriptor] --
CREATE TABLE [edfi].[SchoolTypeDescriptor] (
    [SchoolTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SchoolTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SchoolTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SchoolYearType] --
CREATE TABLE [edfi].[SchoolYearType] (
    [SchoolYear] [SMALLINT] NOT NULL,
    [SchoolYearDescription] [NVARCHAR](50) NOT NULL,
    [CurrentSchoolYear] [BIT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SchoolYearType_PK] PRIMARY KEY CLUSTERED (
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SchoolYearType] ADD CONSTRAINT [SchoolYearType_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SchoolYearType] ADD CONSTRAINT [SchoolYearType_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SchoolYearType] ADD CONSTRAINT [SchoolYearType_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[Section] --
CREATE TABLE [edfi].[Section] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [AvailableCreditConversion] [DECIMAL](9, 2) NULL,
    [AvailableCredits] [DECIMAL](9, 3) NULL,
    [AvailableCreditTypeDescriptorId] [INT] NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [InstructionLanguageDescriptorId] [INT] NULL,
    [LocationClassroomIdentificationCode] [NVARCHAR](60) NULL,
    [LocationSchoolId] [BIGINT] NULL,
    [MediumOfInstructionDescriptorId] [INT] NULL,
    [OfficialAttendancePeriod] [BIT] NULL,
    [PopulationServedDescriptorId] [INT] NULL,
    [SectionName] [NVARCHAR](100) NULL,
    [SectionTypeDescriptorId] [INT] NULL,
    [SequenceOfCourse] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Section_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Section] ADD CONSTRAINT [Section_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Section] ADD CONSTRAINT [Section_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Section] ADD CONSTRAINT [Section_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[Section504DisabilityDescriptor] --
CREATE TABLE [edfi].[Section504DisabilityDescriptor] (
    [Section504DisabilityDescriptorId] [INT] NOT NULL,
    CONSTRAINT [Section504DisabilityDescriptor_PK] PRIMARY KEY CLUSTERED (
        [Section504DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SectionAttendanceTakenEvent] --
CREATE TABLE [edfi].[SectionAttendanceTakenEvent] (
    [CalendarCode] [NVARCHAR](120) NOT NULL,
    [Date] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SectionAttendanceTakenEvent_PK] PRIMARY KEY CLUSTERED (
        [CalendarCode] ASC,
        [Date] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD CONSTRAINT [SectionAttendanceTakenEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD CONSTRAINT [SectionAttendanceTakenEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD CONSTRAINT [SectionAttendanceTakenEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SectionCharacteristic] --
CREATE TABLE [edfi].[SectionCharacteristic] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [SectionCharacteristicDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [SectionCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionCharacteristic] ADD CONSTRAINT [SectionCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionCharacteristicDescriptor] --
CREATE TABLE [edfi].[SectionCharacteristicDescriptor] (
    [SectionCharacteristicDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SectionCharacteristicDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SectionCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SectionClassPeriod] --
CREATE TABLE [edfi].[SectionClassPeriod] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionClassPeriod_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [ClassPeriodName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionClassPeriod] ADD CONSTRAINT [SectionClassPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionCourseLevelCharacteristic] --
CREATE TABLE [edfi].[SectionCourseLevelCharacteristic] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CourseLevelCharacteristicDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionCourseLevelCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [CourseLevelCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionCourseLevelCharacteristic] ADD CONSTRAINT [SectionCourseLevelCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionOfferedGradeLevel] --
CREATE TABLE [edfi].[SectionOfferedGradeLevel] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionOfferedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionOfferedGradeLevel] ADD CONSTRAINT [SectionOfferedGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionProgram] --
CREATE TABLE [edfi].[SectionProgram] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionProgram_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionProgram] ADD CONSTRAINT [SectionProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionTypeDescriptor] --
CREATE TABLE [edfi].[SectionTypeDescriptor] (
    [SectionTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SectionTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SectionTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SeparationDescriptor] --
CREATE TABLE [edfi].[SeparationDescriptor] (
    [SeparationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SeparationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SeparationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SeparationReasonDescriptor] --
CREATE TABLE [edfi].[SeparationReasonDescriptor] (
    [SeparationReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SeparationReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SeparationReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[ServiceDescriptor] --
CREATE TABLE [edfi].[ServiceDescriptor] (
    [ServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Session] --
CREATE TABLE [edfi].[Session] (
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [TotalInstructionalDays] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Session_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Session] ADD CONSTRAINT [Session_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Session] ADD CONSTRAINT [Session_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Session] ADD CONSTRAINT [Session_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SessionAcademicWeek] --
CREATE TABLE [edfi].[SessionAcademicWeek] (
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [WeekIdentifier] [NVARCHAR](80) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SessionAcademicWeek_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC,
        [WeekIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SessionAcademicWeek] ADD CONSTRAINT [SessionAcademicWeek_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SessionGradingPeriod] --
CREATE TABLE [edfi].[SessionGradingPeriod] (
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SessionGradingPeriod_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SessionGradingPeriod] ADD CONSTRAINT [SessionGradingPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SexDescriptor] --
CREATE TABLE [edfi].[SexDescriptor] (
    [SexDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SexDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SourceDimension] --
CREATE TABLE [edfi].[SourceDimension] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [CodeName] [NVARCHAR](100) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SourceDimension_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SourceDimension] ADD CONSTRAINT [SourceDimension_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SourceDimension] ADD CONSTRAINT [SourceDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SourceDimension] ADD CONSTRAINT [SourceDimension_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SourceDimensionReportingTag] --
CREATE TABLE [edfi].[SourceDimensionReportingTag] (
    [Code] [NVARCHAR](16) NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [ReportingTagDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SourceDimensionReportingTag_PK] PRIMARY KEY CLUSTERED (
        [Code] ASC,
        [FiscalYear] ASC,
        [ReportingTagDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SourceDimensionReportingTag] ADD CONSTRAINT [SourceDimensionReportingTag_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SourceSystemDescriptor] --
CREATE TABLE [edfi].[SourceSystemDescriptor] (
    [SourceSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SourceSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SourceSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SpecialEducationExitReasonDescriptor] --
CREATE TABLE [edfi].[SpecialEducationExitReasonDescriptor] (
    [SpecialEducationExitReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SpecialEducationExitReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SpecialEducationExitReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SpecialEducationProgramServiceDescriptor] --
CREATE TABLE [edfi].[SpecialEducationProgramServiceDescriptor] (
    [SpecialEducationProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SpecialEducationProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SpecialEducationProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SpecialEducationSettingDescriptor] --
CREATE TABLE [edfi].[SpecialEducationSettingDescriptor] (
    [SpecialEducationSettingDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SpecialEducationSettingDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SpecialEducationSettingDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Staff] --
CREATE TABLE [edfi].[Staff] (
    [StaffUSI] [INT] IDENTITY(1,1) NOT NULL,
    [BirthDate] [DATE] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [HighestCompletedLevelOfEducationDescriptorId] [INT] NULL,
    [HighlyQualifiedTeacher] [BIT] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [LoginId] [NVARCHAR](120) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [PreferredFirstName] [NVARCHAR](75) NULL,
    [PreferredLastSurname] [NVARCHAR](75) NULL,
    [RequisitionNumber] [NVARCHAR](20) NULL,
    [SexDescriptorId] [INT] NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [StaffUniqueId] [NVARCHAR](32) NOT NULL,
    [YearsOfPriorProfessionalExperience] [DECIMAL](5, 2) NULL,
    [YearsOfPriorTeachingExperience] [DECIMAL](5, 2) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Staff_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Staff_UI_StaffUniqueId] ON [edfi].[Staff] (
    [StaffUniqueId] ASC
) INCLUDE (StaffUSI) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Staff] ADD CONSTRAINT [Staff_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Staff] ADD CONSTRAINT [Staff_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Staff] ADD CONSTRAINT [Staff_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffAbsenceEvent] --
CREATE TABLE [edfi].[StaffAbsenceEvent] (
    [AbsenceEventCategoryDescriptorId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AbsenceEventReason] [NVARCHAR](40) NULL,
    [HoursAbsent] [DECIMAL](18, 2) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffAbsenceEvent_PK] PRIMARY KEY CLUSTERED (
        [AbsenceEventCategoryDescriptorId] ASC,
        [EventDate] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD CONSTRAINT [StaffAbsenceEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD CONSTRAINT [StaffAbsenceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD CONSTRAINT [StaffAbsenceEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffAddress] --
CREATE TABLE [edfi].[StaffAddress] (
    [StaffUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffAddress_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffAddress] ADD CONSTRAINT [StaffAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffAddressPeriod] --
CREATE TABLE [edfi].[StaffAddressPeriod] (
    [StaffUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffAddressPeriod] ADD CONSTRAINT [StaffAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffAncestryEthnicOrigin] --
CREATE TABLE [edfi].[StaffAncestryEthnicOrigin] (
    [StaffUSI] [INT] NOT NULL,
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffAncestryEthnicOrigin_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [AncestryEthnicOriginDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffAncestryEthnicOrigin] ADD CONSTRAINT [StaffAncestryEthnicOrigin_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffClassificationDescriptor] --
CREATE TABLE [edfi].[StaffClassificationDescriptor] (
    [StaffClassificationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StaffClassificationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StaffClassificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StaffCohortAssociation] --
CREATE TABLE [edfi].[StaffCohortAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [CohortIdentifier] [NVARCHAR](36) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [StudentRecordAccess] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffCohortAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CohortIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffCohortAssociation] ADD CONSTRAINT [StaffCohortAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffCohortAssociation] ADD CONSTRAINT [StaffCohortAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffCohortAssociation] ADD CONSTRAINT [StaffCohortAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffCredential] --
CREATE TABLE [edfi].[StaffCredential] (
    [StaffUSI] [INT] NOT NULL,
    [CredentialIdentifier] [NVARCHAR](120) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffCredential_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffCredential] ADD CONSTRAINT [StaffCredential_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDemographic] --
CREATE TABLE [edfi].[StaffDemographic] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [SexDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffDemographic_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographic] ADD CONSTRAINT [StaffDemographic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffDemographic] ADD CONSTRAINT [StaffDemographic_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffDemographic] ADD CONSTRAINT [StaffDemographic_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffDemographicAncestryEthnicOrigin] --
CREATE TABLE [edfi].[StaffDemographicAncestryEthnicOrigin] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDemographicAncestryEthnicOrigin_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [AncestryEthnicOriginDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographicAncestryEthnicOrigin] ADD CONSTRAINT [StaffDemographicAncestryEthnicOrigin_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDemographicIdentificationDocument] --
CREATE TABLE [edfi].[StaffDemographicIdentificationDocument] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDemographicIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographicIdentificationDocument] ADD CONSTRAINT [StaffDemographicIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDemographicLanguage] --
CREATE TABLE [edfi].[StaffDemographicLanguage] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDemographicLanguage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographicLanguage] ADD CONSTRAINT [StaffDemographicLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDemographicLanguageUse] --
CREATE TABLE [edfi].[StaffDemographicLanguageUse] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDemographicLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographicLanguageUse] ADD CONSTRAINT [StaffDemographicLanguageUse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDemographicRace] --
CREATE TABLE [edfi].[StaffDemographicRace] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDemographicRace_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographicRace] ADD CONSTRAINT [StaffDemographicRace_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDemographicTribalAffiliation] --
CREATE TABLE [edfi].[StaffDemographicTribalAffiliation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [TribalAffiliationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDemographicTribalAffiliation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [TribalAffiliationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographicTribalAffiliation] ADD CONSTRAINT [StaffDemographicTribalAffiliation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDemographicVisa] --
CREATE TABLE [edfi].[StaffDemographicVisa] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDemographicVisa_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDemographicVisa] ADD CONSTRAINT [StaffDemographicVisa_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDirectory] --
CREATE TABLE [edfi].[StaffDirectory] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffDirectory_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDirectory] ADD CONSTRAINT [StaffDirectory_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffDirectory] ADD CONSTRAINT [StaffDirectory_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffDirectory] ADD CONSTRAINT [StaffDirectory_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffDirectoryAddress] --
CREATE TABLE [edfi].[StaffDirectoryAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDirectoryAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDirectoryAddress] ADD CONSTRAINT [StaffDirectoryAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDirectoryAddressPeriod] --
CREATE TABLE [edfi].[StaffDirectoryAddressPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDirectoryAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDirectoryAddressPeriod] ADD CONSTRAINT [StaffDirectoryAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDirectoryElectronicMail] --
CREATE TABLE [edfi].[StaffDirectoryElectronicMail] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDirectoryElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDirectoryElectronicMail] ADD CONSTRAINT [StaffDirectoryElectronicMail_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDirectoryInternationalAddress] --
CREATE TABLE [edfi].[StaffDirectoryInternationalAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDirectoryInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDirectoryInternationalAddress] ADD CONSTRAINT [StaffDirectoryInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDirectoryTelephone] --
CREATE TABLE [edfi].[StaffDirectoryTelephone] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDirectoryTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDirectoryTelephone] ADD CONSTRAINT [StaffDirectoryTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDisciplineIncidentAssociation] --
CREATE TABLE [edfi].[StaffDisciplineIncidentAssociation] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffDisciplineIncidentAssociation_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD CONSTRAINT [StaffDisciplineIncidentAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD CONSTRAINT [StaffDisciplineIncidentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD CONSTRAINT [StaffDisciplineIncidentAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] --
CREATE TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC,
        [DisciplineIncidentParticipationCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] ADD CONSTRAINT [StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducationOrganizationAssignmentAssociation] --
CREATE TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffClassificationDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CredentialIdentifier] [NVARCHAR](120) NULL,
    [EmploymentEducationOrganizationId] [BIGINT] NULL,
    [EmploymentStatusDescriptorId] [INT] NULL,
    [EmploymentHireDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
    [OrderOfAssignment] [INT] NULL,
    [PositionTitle] [NVARCHAR](100) NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NULL,
    [YearsOfExperienceAtCurrentEducationOrganization] [DECIMAL](5, 2) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationAssignmentAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [StaffClassificationDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD CONSTRAINT [StaffEducationOrganizationAssignmentAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD CONSTRAINT [StaffEducationOrganizationAssignmentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD CONSTRAINT [StaffEducationOrganizationAssignmentAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffEducationOrganizationEmploymentAssociation] --
CREATE TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AnnualWage] [MONEY] NULL,
    [CredentialIdentifier] [NVARCHAR](120) NULL,
    [Department] [NVARCHAR](60) NULL,
    [EndDate] [DATE] NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
    [HourlyWage] [MONEY] NULL,
    [LengthOfContractDescriptorId] [INT] NULL,
    [OfferDate] [DATE] NULL,
    [ProbationCompleteDate] [DATE] NULL,
    [SeparationDescriptorId] [INT] NULL,
    [SeparationReasonDescriptorId] [INT] NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NULL,
    [Tenured] [BIT] NULL,
    [TenureTrack] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] --
CREATE TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociationBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [StaffUSI] ASC,
        [BackgroundCheckTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociationBackgroundCheck_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducationOrganizationEmploymentAssociationSalary] --
CREATE TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSalary] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [SalaryAmount] [DECIMAL](19, 4) NULL,
    [SalaryMaxRange] [INT] NULL,
    [SalaryMinRange] [INT] NULL,
    [SalaryTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSalary_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSalary] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSalary_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducationOrganizationEmploymentAssociationSeniority] --
CREATE TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSeniority] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CredentialFieldDescriptorId] [INT] NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [YearsExperience] [DECIMAL](5, 2) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSeniority_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentStatusDescriptorId] ASC,
        [HireDate] ASC,
        [StaffUSI] ASC,
        [CredentialFieldDescriptorId] ASC,
        [NameOfInstitution] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSeniority] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociationSeniority_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducatorPreparationProgram] --
CREATE TABLE [edfi].[StaffEducatorPreparationProgram] (
    [StaffUSI] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducatorPreparationProgram_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducatorPreparationProgram] ADD CONSTRAINT [StaffEducatorPreparationProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducatorPreparationProgramAssociation] --
CREATE TABLE [edfi].[StaffEducatorPreparationProgramAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [Completer] [BIT] NULL,
    [EndDate] [DATE] NULL,
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
ALTER TABLE [edfi].[StaffEducatorPreparationProgramAssociation] ADD CONSTRAINT [StaffEducatorPreparationProgramAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffEducatorPreparationProgramAssociation] ADD CONSTRAINT [StaffEducatorPreparationProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffEducatorPreparationProgramAssociation] ADD CONSTRAINT [StaffEducatorPreparationProgramAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffEducatorResearch] --
CREATE TABLE [edfi].[StaffEducatorResearch] (
    [StaffUSI] [INT] NOT NULL,
    [ResearchExperienceDate] [DATE] NOT NULL,
    [ResearchExperienceDescription] [NVARCHAR](1024) NULL,
    [ResearchExperienceTitle] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducatorResearch_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducatorResearch] ADD CONSTRAINT [StaffEducatorResearch_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffElectronicMail] --
CREATE TABLE [edfi].[StaffElectronicMail] (
    [StaffUSI] [INT] NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffElectronicMail] ADD CONSTRAINT [StaffElectronicMail_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffHighlyQualifiedAcademicSubject] --
CREATE TABLE [edfi].[StaffHighlyQualifiedAcademicSubject] (
    [StaffUSI] [INT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffHighlyQualifiedAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffHighlyQualifiedAcademicSubject] ADD CONSTRAINT [StaffHighlyQualifiedAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffIdentificationCode] --
CREATE TABLE [edfi].[StaffIdentificationCode] (
    [StaffUSI] [INT] NOT NULL,
    [StaffIdentificationSystemDescriptorId] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](120) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [StaffIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffIdentificationCode] ADD CONSTRAINT [StaffIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffIdentificationDocument] --
CREATE TABLE [edfi].[StaffIdentificationDocument] (
    [StaffUSI] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffIdentificationDocument] ADD CONSTRAINT [StaffIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[StaffIdentificationSystemDescriptor] (
    [StaffIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StaffIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StaffIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StaffIdentity] --
CREATE TABLE [edfi].[StaffIdentity] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StaffIdentificationSystemDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffIdentity_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StaffIdentificationSystemDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffIdentity] ADD CONSTRAINT [StaffIdentity_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffIdentity] ADD CONSTRAINT [StaffIdentity_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffIdentity] ADD CONSTRAINT [StaffIdentity_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffInternationalAddress] --
CREATE TABLE [edfi].[StaffInternationalAddress] (
    [StaffUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffInternationalAddress] ADD CONSTRAINT [StaffInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffLanguage] --
CREATE TABLE [edfi].[StaffLanguage] (
    [StaffUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffLanguage_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffLanguage] ADD CONSTRAINT [StaffLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffLanguageUse] --
CREATE TABLE [edfi].[StaffLanguageUse] (
    [StaffUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffLanguageUse] ADD CONSTRAINT [StaffLanguageUse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffLeave] --
CREATE TABLE [edfi].[StaffLeave] (
    [BeginDate] [DATE] NOT NULL,
    [StaffLeaveEventCategoryDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Reason] [NVARCHAR](40) NULL,
    [SubstituteAssigned] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffLeave_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [StaffLeaveEventCategoryDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffLeave] ADD CONSTRAINT [StaffLeave_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffLeave] ADD CONSTRAINT [StaffLeave_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffLeave] ADD CONSTRAINT [StaffLeave_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffLeaveEventCategoryDescriptor] --
CREATE TABLE [edfi].[StaffLeaveEventCategoryDescriptor] (
    [StaffLeaveEventCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StaffLeaveEventCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StaffLeaveEventCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StaffOtherName] --
CREATE TABLE [edfi].[StaffOtherName] (
    [StaffUSI] [INT] NOT NULL,
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffOtherName_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [OtherNameTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffOtherName] ADD CONSTRAINT [StaffOtherName_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffPersonalIdentificationDocument] --
CREATE TABLE [edfi].[StaffPersonalIdentificationDocument] (
    [StaffUSI] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] ADD CONSTRAINT [StaffPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffProgramAssociation] --
CREATE TABLE [edfi].[StaffProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [StudentRecordAccess] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffProgramAssociation] ADD CONSTRAINT [StaffProgramAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffProgramAssociation] ADD CONSTRAINT [StaffProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffProgramAssociation] ADD CONSTRAINT [StaffProgramAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffRace] --
CREATE TABLE [edfi].[StaffRace] (
    [StaffUSI] [INT] NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffRace_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffRace] ADD CONSTRAINT [StaffRace_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffRecognition] --
CREATE TABLE [edfi].[StaffRecognition] (
    [StaffUSI] [INT] NOT NULL,
    [RecognitionTypeDescriptorId] [INT] NOT NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [RecognitionAwardDate] [DATE] NULL,
    [RecognitionAwardExpiresDate] [DATE] NULL,
    [RecognitionDescription] [NVARCHAR](80) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffRecognition_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [RecognitionTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffRecognition] ADD CONSTRAINT [StaffRecognition_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffSchoolAssociation] --
CREATE TABLE [edfi].[StaffSchoolAssociation] (
    [ProgramAssignmentDescriptorId] [INT] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CalendarCode] [NVARCHAR](120) NULL,
    [SchoolYear] [SMALLINT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffSchoolAssociation_PK] PRIMARY KEY CLUSTERED (
        [ProgramAssignmentDescriptorId] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD CONSTRAINT [StaffSchoolAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD CONSTRAINT [StaffSchoolAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD CONSTRAINT [StaffSchoolAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffSchoolAssociationAcademicSubject] --
CREATE TABLE [edfi].[StaffSchoolAssociationAcademicSubject] (
    [ProgramAssignmentDescriptorId] [INT] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffSchoolAssociationAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [ProgramAssignmentDescriptorId] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC,
        [AcademicSubjectDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffSchoolAssociationAcademicSubject] ADD CONSTRAINT [StaffSchoolAssociationAcademicSubject_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffSchoolAssociationGradeLevel] --
CREATE TABLE [edfi].[StaffSchoolAssociationGradeLevel] (
    [ProgramAssignmentDescriptorId] [INT] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffSchoolAssociationGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [ProgramAssignmentDescriptorId] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffSchoolAssociationGradeLevel] ADD CONSTRAINT [StaffSchoolAssociationGradeLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffSectionAssociation] --
CREATE TABLE [edfi].[StaffSectionAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [ClassroomPositionDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [HighlyQualifiedTeacher] [BIT] NULL,
    [PercentageContribution] [DECIMAL](5, 4) NULL,
    [TeacherStudentDataLinkExclusion] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffSectionAssociation] ADD CONSTRAINT [StaffSectionAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffSectionAssociation] ADD CONSTRAINT [StaffSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffSectionAssociation] ADD CONSTRAINT [StaffSectionAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffTelephone] --
CREATE TABLE [edfi].[StaffTelephone] (
    [StaffUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffTelephone_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffTelephone] ADD CONSTRAINT [StaffTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffToCandidateRelationshipDescriptor] --
CREATE TABLE [edfi].[StaffToCandidateRelationshipDescriptor] (
    [StaffToCandidateRelationshipDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StaffToCandidateRelationshipDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StaffToCandidateRelationshipDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StaffTribalAffiliation] --
CREATE TABLE [edfi].[StaffTribalAffiliation] (
    [StaffUSI] [INT] NOT NULL,
    [TribalAffiliationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffTribalAffiliation_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [TribalAffiliationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffTribalAffiliation] ADD CONSTRAINT [StaffTribalAffiliation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffVisa] --
CREATE TABLE [edfi].[StaffVisa] (
    [StaffUSI] [INT] NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffVisa_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffVisa] ADD CONSTRAINT [StaffVisa_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StateAbbreviationDescriptor] --
CREATE TABLE [edfi].[StateAbbreviationDescriptor] (
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StateAbbreviationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StateEducationAgency] --
CREATE TABLE [edfi].[StateEducationAgency] (
    [StateEducationAgencyId] [BIGINT] NOT NULL,
    [FederalLocaleCodeDescriptorId] [INT] NULL,
    CONSTRAINT [StateEducationAgency_PK] PRIMARY KEY CLUSTERED (
        [StateEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StateEducationAgencyAccountability] --
CREATE TABLE [edfi].[StateEducationAgencyAccountability] (
    [StateEducationAgencyId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CTEGraduationRateInclusion] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StateEducationAgencyAccountability_PK] PRIMARY KEY CLUSTERED (
        [StateEducationAgencyId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StateEducationAgencyAccountability] ADD CONSTRAINT [StateEducationAgencyAccountability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StateEducationAgencyFederalFunds] --
CREATE TABLE [edfi].[StateEducationAgencyFederalFunds] (
    [StateEducationAgencyId] [BIGINT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [FederalProgramsFundingAllocation] [MONEY] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StateEducationAgencyFederalFunds_PK] PRIMARY KEY CLUSTERED (
        [StateEducationAgencyId] ASC,
        [FiscalYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StateEducationAgencyFederalFunds] ADD CONSTRAINT [StateEducationAgencyFederalFunds_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[Student] --
CREATE TABLE [edfi].[Student] (
    [StudentUSI] [INT] IDENTITY(1,1) NOT NULL,
    [BirthCity] [NVARCHAR](30) NULL,
    [BirthCountryDescriptorId] [INT] NULL,
    [BirthDate] [DATE] NOT NULL,
    [BirthInternationalProvince] [NVARCHAR](150) NULL,
    [BirthSexDescriptorId] [INT] NULL,
    [BirthStateAbbreviationDescriptorId] [INT] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [DateEnteredUS] [DATE] NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [MultipleBirthStatus] [BIT] NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [PreferredFirstName] [NVARCHAR](75) NULL,
    [PreferredLastSurname] [NVARCHAR](75) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [StudentUniqueId] [NVARCHAR](32) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Student_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Student_UI_StudentUniqueId] ON [edfi].[Student] (
    [StudentUniqueId] ASC
) INCLUDE (StudentUSI) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Student] ADD CONSTRAINT [Student_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Student] ADD CONSTRAINT [Student_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Student] ADD CONSTRAINT [Student_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAcademicRecord] --
CREATE TABLE [edfi].[StudentAcademicRecord] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CumulativeAttemptedCreditConversion] [DECIMAL](9, 2) NULL,
    [CumulativeAttemptedCredits] [DECIMAL](9, 3) NULL,
    [CumulativeAttemptedCreditTypeDescriptorId] [INT] NULL,
    [CumulativeEarnedCreditConversion] [DECIMAL](9, 2) NULL,
    [CumulativeEarnedCredits] [DECIMAL](9, 3) NULL,
    [CumulativeEarnedCreditTypeDescriptorId] [INT] NULL,
    [ProjectedGraduationDate] [DATE] NULL,
    [SessionAttemptedCreditConversion] [DECIMAL](9, 2) NULL,
    [SessionAttemptedCredits] [DECIMAL](9, 3) NULL,
    [SessionAttemptedCreditTypeDescriptorId] [INT] NULL,
    [SessionEarnedCreditConversion] [DECIMAL](9, 2) NULL,
    [SessionEarnedCredits] [DECIMAL](9, 3) NULL,
    [SessionEarnedCreditTypeDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentAcademicRecord_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecord] ADD CONSTRAINT [StudentAcademicRecord_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAcademicRecord] ADD CONSTRAINT [StudentAcademicRecord_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAcademicRecord] ADD CONSTRAINT [StudentAcademicRecord_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAcademicRecordAcademicHonor] --
CREATE TABLE [edfi].[StudentAcademicRecordAcademicHonor] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AcademicHonorCategoryDescriptorId] [INT] NOT NULL,
    [HonorDescription] [NVARCHAR](80) NOT NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [HonorAwardDate] [DATE] NULL,
    [HonorAwardExpiresDate] [DATE] NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordAcademicHonor_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [AcademicHonorCategoryDescriptorId] ASC,
        [HonorDescription] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] ADD CONSTRAINT [StudentAcademicRecordAcademicHonor_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordClassRanking] --
CREATE TABLE [edfi].[StudentAcademicRecordClassRanking] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ClassRank] [INT] NOT NULL,
    [ClassRankingDate] [DATE] NULL,
    [PercentageRanking] [INT] NULL,
    [TotalNumberInClass] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordClassRanking_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordClassRanking] ADD CONSTRAINT [StudentAcademicRecordClassRanking_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordDiploma] --
CREATE TABLE [edfi].[StudentAcademicRecordDiploma] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [DiplomaAwardDate] [DATE] NOT NULL,
    [DiplomaTypeDescriptorId] [INT] NOT NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [CTECompleter] [BIT] NULL,
    [DiplomaAwardExpiresDate] [DATE] NULL,
    [DiplomaDescription] [NVARCHAR](80) NULL,
    [DiplomaLevelDescriptorId] [INT] NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordDiploma_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [DiplomaAwardDate] ASC,
        [DiplomaTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordDiploma] ADD CONSTRAINT [StudentAcademicRecordDiploma_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordGradePointAverage] --
CREATE TABLE [edfi].[StudentAcademicRecordGradePointAverage] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [IsCumulative] [BIT] NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [GradePointAverageTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordGradePointAverage] ADD CONSTRAINT [StudentAcademicRecordGradePointAverage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordRecognition] --
CREATE TABLE [edfi].[StudentAcademicRecordRecognition] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [RecognitionTypeDescriptorId] [INT] NOT NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [RecognitionAwardDate] [DATE] NULL,
    [RecognitionAwardExpiresDate] [DATE] NULL,
    [RecognitionDescription] [NVARCHAR](80) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordRecognition_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [RecognitionTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordRecognition] ADD CONSTRAINT [StudentAcademicRecordRecognition_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordReportCard] --
CREATE TABLE [edfi].[StudentAcademicRecordReportCard] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordReportCard_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordReportCard] ADD CONSTRAINT [StudentAcademicRecordReportCard_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessment] --
CREATE TABLE [edfi].[StudentAssessment] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AdministrationDate] [DATETIME2](7) NULL,
    [AdministrationEndDate] [DATETIME2](7) NULL,
    [AdministrationEnvironmentDescriptorId] [INT] NULL,
    [AdministrationLanguageDescriptorId] [INT] NULL,
    [AssessedMinutes] [INT] NULL,
    [EventCircumstanceDescriptorId] [INT] NULL,
    [EventDescription] [NVARCHAR](1024) NULL,
    [PlatformTypeDescriptorId] [INT] NULL,
    [ReasonNotTestedDescriptorId] [INT] NULL,
    [ReportedSchoolId] [BIGINT] NULL,
    [ReportedSchoolIdentifier] [NVARCHAR](60) NULL,
    [RetestIndicatorDescriptorId] [INT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [SerialNumber] [NVARCHAR](120) NULL,
    [WhenAssessedGradeLevelDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentAssessment_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessment] ADD CONSTRAINT [StudentAssessment_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAssessment] ADD CONSTRAINT [StudentAssessment_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAssessment] ADD CONSTRAINT [StudentAssessment_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAssessmentAccommodation] --
CREATE TABLE [edfi].[StudentAssessmentAccommodation] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AccommodationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentAccommodation_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC,
        [AccommodationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentAccommodation] ADD CONSTRAINT [StudentAssessmentAccommodation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentEducationOrganizationAssociation] --
CREATE TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationAssociationTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentAssessmentEducationOrganizationAssociation_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [EducationOrganizationAssociationTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD CONSTRAINT [StudentAssessmentEducationOrganizationAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD CONSTRAINT [StudentAssessmentEducationOrganizationAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD CONSTRAINT [StudentAssessmentEducationOrganizationAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAssessmentItem] --
CREATE TABLE [edfi].[StudentAssessmentItem] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [AssessmentItemResultDescriptorId] [INT] NOT NULL,
    [AssessmentResponse] [NVARCHAR](255) NULL,
    [DescriptiveFeedback] [NVARCHAR](1024) NULL,
    [ItemNumber] [INT] NULL,
    [RawScoreResult] [DECIMAL](15, 5) NULL,
    [ResponseIndicatorDescriptorId] [INT] NULL,
    [TimeAssessed] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentItem_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC,
        [IdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentItem] ADD CONSTRAINT [StudentAssessmentItem_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[StudentAssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [PerformanceLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] ADD CONSTRAINT [StudentAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentPeriod] --
CREATE TABLE [edfi].[StudentAssessmentPeriod] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssessmentPeriodDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentPeriod_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentPeriod] ADD CONSTRAINT [StudentAssessmentPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentRegistration] --
CREATE TABLE [edfi].[StudentAssessmentRegistration] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssessmentGradeLevelDescriptorId] [INT] NULL,
    [EntryDate] [DATE] NOT NULL,
    [PlatformTypeDescriptorId] [INT] NULL,
    [ReportingEducationOrganizationId] [BIGINT] NULL,
    [ScheduledEducationOrganizationId] [BIGINT] NULL,
    [ScheduledStudentUSI] [INT] NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [TestingEducationOrganizationId] [BIGINT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentAssessmentRegistration_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistration] ADD CONSTRAINT [StudentAssessmentRegistration_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistration] ADD CONSTRAINT [StudentAssessmentRegistration_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistration] ADD CONSTRAINT [StudentAssessmentRegistration_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAssessmentRegistrationAssessmentAccommodation] --
CREATE TABLE [edfi].[StudentAssessmentRegistrationAssessmentAccommodation] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AccommodationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentRegistrationAssessmentAccommodation_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC,
        [AccommodationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistrationAssessmentAccommodation] ADD CONSTRAINT [StudentAssessmentRegistrationAssessmentAccommodation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentRegistrationAssessmentCustomization] --
CREATE TABLE [edfi].[StudentAssessmentRegistrationAssessmentCustomization] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CustomizationKey] [NVARCHAR](60) NOT NULL,
    [CustomizationValue] [NVARCHAR](1024) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentRegistrationAssessmentCustomization_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC,
        [CustomizationKey] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistrationAssessmentCustomization] ADD CONSTRAINT [StudentAssessmentRegistrationAssessmentCustomization_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] --
CREATE TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentBatteryPartName] [NVARCHAR](65) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentAssessmentRegistrationBatteryPartAssociation_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentBatteryPartName] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] ADD CONSTRAINT [StudentAssessmentRegistrationBatteryPartAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] ADD CONSTRAINT [StudentAssessmentRegistrationBatteryPartAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] ADD CONSTRAINT [StudentAssessmentRegistrationBatteryPartAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAssessmentRegistrationBatteryPartAssociationAccommodation] --
CREATE TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociationAccommodation] (
    [AdministrationIdentifier] [NVARCHAR](255) NOT NULL,
    [AssessmentBatteryPartName] [NVARCHAR](65) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [AssigningEducationOrganizationId] [BIGINT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AccommodationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentRegistrationBatteryPartAssociationAccommodation_PK] PRIMARY KEY CLUSTERED (
        [AdministrationIdentifier] ASC,
        [AssessmentBatteryPartName] ASC,
        [AssessmentIdentifier] ASC,
        [AssigningEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC,
        [AccommodationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociationAccommodation] ADD CONSTRAINT [StudentAssessmentRegistrationBatteryPartAssociationAccommodation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentScoreResult] --
CREATE TABLE [edfi].[StudentAssessmentScoreResult] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentScoreResult_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC,
        [AssessmentReportingMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentScoreResult] ADD CONSTRAINT [StudentAssessmentScoreResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentStudentObjectiveAssessment] --
CREATE TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [AdministrationDate] [DATETIME2](7) NULL,
    [AdministrationEndDate] [DATETIME2](7) NULL,
    [AssessedMinutes] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentStudentObjectiveAssessment_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC,
        [IdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] ADD CONSTRAINT [StudentAssessmentStudentObjectiveAssessment_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC,
        [IdentificationCode] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [PerformanceLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] ADD CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] --
CREATE TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] (
    [AssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentScoreResult_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC,
        [IdentificationCode] ASC,
        [AssessmentReportingMethodDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] ADD CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentScoreResult_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCharacteristicDescriptor] --
CREATE TABLE [edfi].[StudentCharacteristicDescriptor] (
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StudentCharacteristicDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StudentCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentCohortAssociation] --
CREATE TABLE [edfi].[StudentCohortAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [CohortIdentifier] [NVARCHAR](36) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentCohortAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CohortIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCohortAssociation] ADD CONSTRAINT [StudentCohortAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentCohortAssociation] ADD CONSTRAINT [StudentCohortAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentCohortAssociation] ADD CONSTRAINT [StudentCohortAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentCohortAssociationSection] --
CREATE TABLE [edfi].[StudentCohortAssociationSection] (
    [BeginDate] [DATE] NOT NULL,
    [CohortIdentifier] [NVARCHAR](36) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCohortAssociationSection_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CohortIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCohortAssociationSection] ADD CONSTRAINT [StudentCohortAssociationSection_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCompetencyObjective] --
CREATE TABLE [edfi].[StudentCompetencyObjective] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [ObjectiveEducationOrganizationId] [BIGINT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CompetencyLevelDescriptorId] [INT] NOT NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentCompetencyObjective_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [Objective] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD CONSTRAINT [StudentCompetencyObjective_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD CONSTRAINT [StudentCompetencyObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD CONSTRAINT [StudentCompetencyObjective_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] --
CREATE TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [ObjectiveEducationOrganizationId] [BIGINT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCompetencyObjectiveGeneralStudentProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [Objective] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC,
        [StudentUSI] ASC,
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] ADD CONSTRAINT [StudentCompetencyObjectiveGeneralStudentProgramAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] --
CREATE TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodName] [NVARCHAR](60) NOT NULL,
    [GradingPeriodSchoolId] [BIGINT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [ObjectiveEducationOrganizationId] [BIGINT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCompetencyObjectiveStudentSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodName] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [Objective] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC,
        [StudentUSI] ASC,
        [BeginDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] ADD CONSTRAINT [StudentCompetencyObjectiveStudentSectionAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentContactAssociation] --
CREATE TABLE [edfi].[StudentContactAssociation] (
    [ContactUSI] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ContactPriority] [INT] NULL,
    [ContactRestrictions] [NVARCHAR](250) NULL,
    [EmergencyContactStatus] [BIT] NULL,
    [LegalGuardian] [BIT] NULL,
    [LivesWith] [BIT] NULL,
    [PrimaryContactStatus] [BIT] NULL,
    [RelationDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentContactAssociation_PK] PRIMARY KEY CLUSTERED (
        [ContactUSI] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentContactAssociation] ADD CONSTRAINT [StudentContactAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentContactAssociation] ADD CONSTRAINT [StudentContactAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentContactAssociation] ADD CONSTRAINT [StudentContactAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentCTEProgramAssociation] --
CREATE TABLE [edfi].[StudentCTEProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [NonTraditionalGenderStatus] [BIT] NULL,
    [PrivateCTEProgram] [BIT] NULL,
    [TechnicalSkillsAssessmentDescriptorId] [INT] NULL,
    CONSTRAINT [StudentCTEProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentCTEProgramAssociationCTEProgramService] --
CREATE TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CTEProgramServiceDescriptorId] [INT] NOT NULL,
    [CIPCode] [NVARCHAR](120) NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCTEProgramAssociationCTEProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [CTEProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] ADD CONSTRAINT [StudentCTEProgramAssociationCTEProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographic] --
CREATE TABLE [edfi].[StudentDemographic] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [LimitedEnglishProficiencyDescriptorId] [INT] NULL,
    [SexDescriptorId] [INT] NULL,
    [SupporterMilitaryConnectionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentDemographic_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographic] ADD CONSTRAINT [StudentDemographic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentDemographic] ADD CONSTRAINT [StudentDemographic_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentDemographic] ADD CONSTRAINT [StudentDemographic_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentDemographicAncestryEthnicOrigin] --
CREATE TABLE [edfi].[StudentDemographicAncestryEthnicOrigin] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicAncestryEthnicOrigin_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AncestryEthnicOriginDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicAncestryEthnicOrigin] ADD CONSTRAINT [StudentDemographicAncestryEthnicOrigin_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicDisability] --
CREATE TABLE [edfi].[StudentDemographicDisability] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicDisability_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicDisability] ADD CONSTRAINT [StudentDemographicDisability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicDisabilityDesignation] --
CREATE TABLE [edfi].[StudentDemographicDisabilityDesignation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicDisabilityDesignation] ADD CONSTRAINT [StudentDemographicDisabilityDesignation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicIdentificationDocument] --
CREATE TABLE [edfi].[StudentDemographicIdentificationDocument] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicIdentificationDocument] ADD CONSTRAINT [StudentDemographicIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicLanguage] --
CREATE TABLE [edfi].[StudentDemographicLanguage] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicLanguage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicLanguage] ADD CONSTRAINT [StudentDemographicLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicLanguageUse] --
CREATE TABLE [edfi].[StudentDemographicLanguageUse] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicLanguageUse] ADD CONSTRAINT [StudentDemographicLanguageUse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicRace] --
CREATE TABLE [edfi].[StudentDemographicRace] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicRace_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicRace] ADD CONSTRAINT [StudentDemographicRace_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicTribalAffiliation] --
CREATE TABLE [edfi].[StudentDemographicTribalAffiliation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TribalAffiliationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicTribalAffiliation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [TribalAffiliationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicTribalAffiliation] ADD CONSTRAINT [StudentDemographicTribalAffiliation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDemographicVisa] --
CREATE TABLE [edfi].[StudentDemographicVisa] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDemographicVisa_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDemographicVisa] ADD CONSTRAINT [StudentDemographicVisa_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDirectory] --
CREATE TABLE [edfi].[StudentDirectory] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentDirectory_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDirectory] ADD CONSTRAINT [StudentDirectory_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentDirectory] ADD CONSTRAINT [StudentDirectory_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentDirectory] ADD CONSTRAINT [StudentDirectory_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentDirectoryAddress] --
CREATE TABLE [edfi].[StudentDirectoryAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDirectoryAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDirectoryAddress] ADD CONSTRAINT [StudentDirectoryAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDirectoryAddressPeriod] --
CREATE TABLE [edfi].[StudentDirectoryAddressPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDirectoryAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDirectoryAddressPeriod] ADD CONSTRAINT [StudentDirectoryAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDirectoryElectronicMail] --
CREATE TABLE [edfi].[StudentDirectoryElectronicMail] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDirectoryElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDirectoryElectronicMail] ADD CONSTRAINT [StudentDirectoryElectronicMail_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDirectoryInternationalAddress] --
CREATE TABLE [edfi].[StudentDirectoryInternationalAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDirectoryInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDirectoryInternationalAddress] ADD CONSTRAINT [StudentDirectoryInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDirectoryTelephone] --
CREATE TABLE [edfi].[StudentDirectoryTelephone] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDirectoryTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDirectoryTelephone] ADD CONSTRAINT [StudentDirectoryTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDisciplineIncidentBehaviorAssociation] --
CREATE TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BehaviorDetailedDescription] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentBehaviorAssociation_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] --
CREATE TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC,
        [DisciplineIncidentParticipationCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDisciplineIncidentBehaviorAssociationWeapon] --
CREATE TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationWeapon] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [WeaponDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentBehaviorAssociationWeapon_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC,
        [WeaponDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationWeapon] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociationWeapon_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDisciplineIncidentNonOffenderAssociation] --
CREATE TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociation_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] --
CREATE TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC,
        [DisciplineIncidentParticipationCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssessmentAccommodation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssessmentAccommodation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodation] ADD CONSTRAINT [StudentEducationOrganizationAssessmentAccommodation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodation] ADD CONSTRAINT [StudentEducationOrganizationAssessmentAccommodation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodation] ADD CONSTRAINT [StudentEducationOrganizationAssessmentAccommodation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AccommodationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AccommodationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation] ADD CONSTRAINT [StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BarrierToInternetAccessInResidenceDescriptorId] [INT] NULL,
    [GenderIdentity] [NVARCHAR](60) NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [InternetAccessInResidence] [BIT] NULL,
    [InternetAccessTypeInResidenceDescriptorId] [INT] NULL,
    [InternetPerformanceInResidenceDescriptorId] [INT] NULL,
    [LimitedEnglishProficiencyDescriptorId] [INT] NULL,
    [LoginId] [NVARCHAR](120) NULL,
    [PrimaryLearningDeviceAccessDescriptorId] [INT] NULL,
    [PrimaryLearningDeviceAwayFromSchoolDescriptorId] [INT] NULL,
    [PrimaryLearningDeviceProviderDescriptorId] [INT] NULL,
    [ProfileThumbnail] [NVARCHAR](255) NULL,
    [SexDescriptorId] [INT] NULL,
    [SupporterMilitaryConnectionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD CONSTRAINT [StudentEducationOrganizationAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD CONSTRAINT [StudentEducationOrganizationAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD CONSTRAINT [StudentEducationOrganizationAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationAddress] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddress] ADD CONSTRAINT [StudentEducationOrganizationAssociationAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationAddressPeriod] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationAddressPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddressPeriod] ADD CONSTRAINT [StudentEducationOrganizationAssociationAddressPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationAncestryEthnicOrigin_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AncestryEthnicOriginDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] ADD CONSTRAINT [StudentEducationOrganizationAssociationAncestryEthnicOrigin_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationCohortYear] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CohortYearTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationCohortYear_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [CohortYearTypeDescriptorId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] ADD CONSTRAINT [StudentEducationOrganizationAssociationCohortYear_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationDisability] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationDisability] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationDisability_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisability] ADD CONSTRAINT [StudentEducationOrganizationAssociationDisability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] ADD CONSTRAINT [StudentEducationOrganizationAssociationDisabilityDesignation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CrisisEventName] [NVARCHAR](100) NOT NULL,
    [CrisisHomelessnessIndicator] [BIT] NULL,
    [DisplacedStudentEndDate] [DATE] NULL,
    [DisplacedStudentStartDate] [DATE] NULL,
    [DisplacedStudentStatusDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationDisplacedStudent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [CrisisEventName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] ADD CONSTRAINT [StudentEducationOrganizationAssociationDisplacedStudent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationElectronicMail] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationElectronicMail] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationElectronicMail] ADD CONSTRAINT [StudentEducationOrganizationAssociationElectronicMail_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationInternationalAddress] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationInternationalAddress] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [AddressLine1] [NVARCHAR](150) NOT NULL,
    [AddressLine2] [NVARCHAR](150) NULL,
    [AddressLine3] [NVARCHAR](150) NULL,
    [AddressLine4] [NVARCHAR](150) NULL,
    [BeginDate] [DATE] NULL,
    [CountryDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AddressTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationInternationalAddress] ADD CONSTRAINT [StudentEducationOrganizationAssociationInternationalAddress_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationLanguage] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationLanguage] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationLanguage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguage] ADD CONSTRAINT [StudentEducationOrganizationAssociationLanguage_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationLanguageUse] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationLanguageUse] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguageUse] ADD CONSTRAINT [StudentEducationOrganizationAssociationLanguageUse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationRace] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationRace] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationRace_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationRace] ADD CONSTRAINT [StudentEducationOrganizationAssociationRace_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [StudentCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristic_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentCharacteristicPeriod] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristicPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristicPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [StudentCharacteristicDescriptorId] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristicPeriod] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristicPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](120) NOT NULL,
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [AssigningOrganizationIdentificationCode] ASC,
        [StudentIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentIdentificationCode_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentIndicator] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicator] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [Indicator] [NVARCHAR](60) NOT NULL,
    [IndicatorGroup] [NVARCHAR](200) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicator_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [IndicatorName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicator] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicator_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicatorPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [IndicatorName] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicatorPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationTelephone] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationTelephone] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTelephone] ADD CONSTRAINT [StudentEducationOrganizationAssociationTelephone_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TribalAffiliationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationTribalAffiliation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [TribalAffiliationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] ADD CONSTRAINT [StudentEducationOrganizationAssociationTribalAffiliation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationResponsibilityAssociation] --
CREATE TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ResponsibilityDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationResponsibilityAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ResponsibilityDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD CONSTRAINT [StudentEducationOrganizationResponsibilityAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD CONSTRAINT [StudentEducationOrganizationResponsibilityAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD CONSTRAINT [StudentEducationOrganizationResponsibilityAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentGradebookEntry] --
CREATE TABLE [edfi].[StudentGradebookEntry] (
    [GradebookEntryIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssignmentLateStatusDescriptorId] [INT] NULL,
    [AssignmentPassed] [BIT] NULL,
    [CompetencyLevelDescriptorId] [INT] NULL,
    [DateCompleted] [DATE] NULL,
    [DateFulfilled] [DATE] NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [NumericGradeEarned] [DECIMAL](9, 2) NULL,
    [PointsEarned] [DECIMAL](9, 2) NULL,
    [SubmissionStatusDescriptorId] [INT] NULL,
    [TimeFulfilled] [TIME](7) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentGradebookEntry_PK] PRIMARY KEY CLUSTERED (
        [GradebookEntryIdentifier] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentGradebookEntry] ADD CONSTRAINT [StudentGradebookEntry_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentGradebookEntry] ADD CONSTRAINT [StudentGradebookEntry_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentGradebookEntry] ADD CONSTRAINT [StudentGradebookEntry_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentHealth] --
CREATE TABLE [edfi].[StudentHealth] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [NonMedicalImmunizationExemptionDate] [DATE] NULL,
    [NonMedicalImmunizationExemptionDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentHealth_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentHealth] ADD CONSTRAINT [StudentHealth_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentHealth] ADD CONSTRAINT [StudentHealth_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentHealth] ADD CONSTRAINT [StudentHealth_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentHealthAdditionalImmunization] --
CREATE TABLE [edfi].[StudentHealthAdditionalImmunization] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ImmunizationName] [NVARCHAR](100) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentHealthAdditionalImmunization_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [ImmunizationName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentHealthAdditionalImmunization] ADD CONSTRAINT [StudentHealthAdditionalImmunization_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentHealthAdditionalImmunizationDate] --
CREATE TABLE [edfi].[StudentHealthAdditionalImmunizationDate] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ImmunizationName] [NVARCHAR](100) NOT NULL,
    [ImmunizationDate] [DATE] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentHealthAdditionalImmunizationDate_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [ImmunizationName] ASC,
        [ImmunizationDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentHealthAdditionalImmunizationDate] ADD CONSTRAINT [StudentHealthAdditionalImmunizationDate_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentHealthRequiredImmunization] --
CREATE TABLE [edfi].[StudentHealthRequiredImmunization] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ImmunizationTypeDescriptorId] [INT] NOT NULL,
    [MedicalExemption] [NVARCHAR](1024) NULL,
    [MedicalExemptionDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentHealthRequiredImmunization_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [ImmunizationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentHealthRequiredImmunization] ADD CONSTRAINT [StudentHealthRequiredImmunization_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentHealthRequiredImmunizationDate] --
CREATE TABLE [edfi].[StudentHealthRequiredImmunizationDate] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ImmunizationTypeDescriptorId] [INT] NOT NULL,
    [ImmunizationDate] [DATE] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentHealthRequiredImmunizationDate_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [ImmunizationTypeDescriptorId] ASC,
        [ImmunizationDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentHealthRequiredImmunizationDate] ADD CONSTRAINT [StudentHealthRequiredImmunizationDate_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentHomelessProgramAssociation] --
CREATE TABLE [edfi].[StudentHomelessProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AwaitingFosterCare] [BIT] NULL,
    [HomelessPrimaryNighttimeResidenceDescriptorId] [INT] NULL,
    [HomelessUnaccompaniedYouth] [BIT] NULL,
    CONSTRAINT [StudentHomelessProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentHomelessProgramAssociationHomelessProgramService] --
CREATE TABLE [edfi].[StudentHomelessProgramAssociationHomelessProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [HomelessProgramServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentHomelessProgramAssociationHomelessProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [HomelessProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentHomelessProgramAssociationHomelessProgramService] ADD CONSTRAINT [StudentHomelessProgramAssociationHomelessProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentIdentificationDocument] --
CREATE TABLE [edfi].[StudentIdentificationDocument] (
    [StudentUSI] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentIdentificationDocument] ADD CONSTRAINT [StudentIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[StudentIdentificationSystemDescriptor] (
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StudentIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StudentIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentIdentity] --
CREATE TABLE [edfi].[StudentIdentity] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [IdentificationCode] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentIdentity_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentIdentificationSystemDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentIdentity] ADD CONSTRAINT [StudentIdentity_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentIdentity] ADD CONSTRAINT [StudentIdentity_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentIdentity] ADD CONSTRAINT [StudentIdentity_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentInterventionAssociation] --
CREATE TABLE [edfi].[StudentInterventionAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CohortIdentifier] [NVARCHAR](36) NULL,
    [CohortEducationOrganizationId] [BIGINT] NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [Dosage] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentInterventionAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD CONSTRAINT [StudentInterventionAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD CONSTRAINT [StudentInterventionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD CONSTRAINT [StudentInterventionAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentInterventionAssociationInterventionEffectiveness] --
CREATE TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [ImprovementIndex] [INT] NULL,
    [InterventionEffectivenessRatingDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentInterventionAssociationInterventionEffectiveness_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [StudentUSI] ASC,
        [DiagnosisDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] ADD CONSTRAINT [StudentInterventionAssociationInterventionEffectiveness_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentInterventionAttendanceEvent] --
CREATE TABLE [edfi].[StudentInterventionAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AttendanceEventReason] [NVARCHAR](255) NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [EventDuration] [DECIMAL](3, 2) NULL,
    [InterventionDuration] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentInterventionAttendanceEvent_PK] PRIMARY KEY CLUSTERED (
        [AttendanceEventCategoryDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [InterventionIdentificationCode] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD CONSTRAINT [StudentInterventionAttendanceEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD CONSTRAINT [StudentInterventionAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD CONSTRAINT [StudentInterventionAttendanceEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentLanguageInstructionProgramAssociation] --
CREATE TABLE [edfi].[StudentLanguageInstructionProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Dosage] [INT] NULL,
    [EnglishLearnerParticipation] [BIT] NULL,
    CONSTRAINT [StudentLanguageInstructionProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] --
CREATE TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [MonitoredDescriptorId] [INT] NULL,
    [ParticipationDescriptorId] [INT] NULL,
    [ProficiencyDescriptorId] [INT] NULL,
    [ProgressDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] ADD CONSTRAINT [StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] --
CREATE TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LanguageInstructionProgramServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [LanguageInstructionProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] ADD CONSTRAINT [StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentMigrantEducationProgramAssociation] --
CREATE TABLE [edfi].[StudentMigrantEducationProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ContinuationOfServicesReasonDescriptorId] [INT] NULL,
    [EligibilityExpirationDate] [DATE] NULL,
    [LastQualifyingMove] [DATE] NOT NULL,
    [PriorityForServices] [BIT] NOT NULL,
    [QualifyingArrivalDate] [DATE] NULL,
    [StateResidencyDate] [DATE] NULL,
    [USInitialEntry] [DATE] NULL,
    [USInitialSchoolEntry] [DATE] NULL,
    [USMostRecentEntry] [DATE] NULL,
    CONSTRAINT [StudentMigrantEducationProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] --
CREATE TABLE [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [MigrantEducationProgramServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentMigrantEducationProgramAssociationMigrantEducationProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [MigrantEducationProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] ADD CONSTRAINT [StudentMigrantEducationProgramAssociationMigrantEducationProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentNeglectedOrDelinquentProgramAssociation] --
CREATE TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ELAProgressLevelDescriptorId] [INT] NULL,
    [MathematicsProgressLevelDescriptorId] [INT] NULL,
    [NeglectedOrDelinquentProgramDescriptorId] [INT] NULL,
    CONSTRAINT [StudentNeglectedOrDelinquentProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] --
CREATE TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [NeglectedOrDelinquentProgramServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [NeglectedOrDelinquentProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] ADD CONSTRAINT [StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentOtherName] --
CREATE TABLE [edfi].[StudentOtherName] (
    [StudentUSI] [INT] NOT NULL,
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentOtherName_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [OtherNameTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentOtherName] ADD CONSTRAINT [StudentOtherName_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentPath] --
CREATE TABLE [edfi].[StudentPath] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentPath_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPath] ADD CONSTRAINT [StudentPath_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentPath] ADD CONSTRAINT [StudentPath_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentPath] ADD CONSTRAINT [StudentPath_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentPathMilestoneStatus] --
CREATE TABLE [edfi].[StudentPathMilestoneStatus] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathMilestoneName] [NVARCHAR](60) NOT NULL,
    [PathMilestoneTypeDescriptorId] [INT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CompletionIndicator] [BIT] NULL,
    [PathPhaseName] [NVARCHAR](60) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentPathMilestoneStatus_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathMilestoneName] ASC,
        [PathMilestoneTypeDescriptorId] ASC,
        [PathName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPathMilestoneStatus] ADD CONSTRAINT [StudentPathMilestoneStatus_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentPathMilestoneStatus] ADD CONSTRAINT [StudentPathMilestoneStatus_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentPathMilestoneStatus] ADD CONSTRAINT [StudentPathMilestoneStatus_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentPathMilestoneStatusEvent] --
CREATE TABLE [edfi].[StudentPathMilestoneStatusEvent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathMilestoneName] [NVARCHAR](60) NOT NULL,
    [PathMilestoneTypeDescriptorId] [INT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Description] [NVARCHAR](1024) NULL,
    [PathMilestoneStatusDate] [DATE] NOT NULL,
    [PathMilestoneStatusDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentPathMilestoneStatusEvent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathMilestoneName] ASC,
        [PathMilestoneTypeDescriptorId] ASC,
        [PathName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPathMilestoneStatusEvent] ADD CONSTRAINT [StudentPathMilestoneStatusEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentPathPeriod] --
CREATE TABLE [edfi].[StudentPathPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentPathPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC,
        [StudentUSI] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPathPeriod] ADD CONSTRAINT [StudentPathPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentPathPhaseStatus] --
CREATE TABLE [edfi].[StudentPathPhaseStatus] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [PathPhaseName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CompletionIndicator] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentPathPhaseStatus_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC,
        [PathPhaseName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPathPhaseStatus] ADD CONSTRAINT [StudentPathPhaseStatus_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentPathPhaseStatus] ADD CONSTRAINT [StudentPathPhaseStatus_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentPathPhaseStatus] ADD CONSTRAINT [StudentPathPhaseStatus_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentPathPhaseStatusEvent] --
CREATE TABLE [edfi].[StudentPathPhaseStatusEvent] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [PathPhaseName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PathPhaseStatusDate] [DATE] NOT NULL,
    [PathPhaseStatusDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentPathPhaseStatusEvent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC,
        [PathPhaseName] ASC,
        [StudentUSI] ASC,
        [PathPhaseStatusDate] ASC,
        [PathPhaseStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPathPhaseStatusEvent] ADD CONSTRAINT [StudentPathPhaseStatusEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentPathPhaseStatusPeriod] --
CREATE TABLE [edfi].[StudentPathPhaseStatusPeriod] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [PathName] [NVARCHAR](60) NOT NULL,
    [PathPhaseName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentPathPhaseStatusPeriod_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [PathName] ASC,
        [PathPhaseName] ASC,
        [StudentUSI] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPathPhaseStatusPeriod] ADD CONSTRAINT [StudentPathPhaseStatusPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentPersonalIdentificationDocument] --
CREATE TABLE [edfi].[StudentPersonalIdentificationDocument] (
    [StudentUSI] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](120) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] ADD CONSTRAINT [StudentPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentProgramAssociation] --
CREATE TABLE [edfi].[StudentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    CONSTRAINT [StudentProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentProgramAssociationService] --
CREATE TABLE [edfi].[StudentProgramAssociationService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentProgramAssociationService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [ServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentProgramAssociationService] ADD CONSTRAINT [StudentProgramAssociationService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentProgramAttendanceEvent] --
CREATE TABLE [edfi].[StudentProgramAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AttendanceEventReason] [NVARCHAR](255) NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [EventDuration] [DECIMAL](3, 2) NULL,
    [ProgramAttendanceDuration] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentProgramAttendanceEvent_PK] PRIMARY KEY CLUSTERED (
        [AttendanceEventCategoryDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD CONSTRAINT [StudentProgramAttendanceEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD CONSTRAINT [StudentProgramAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD CONSTRAINT [StudentProgramAttendanceEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentProgramEvaluation] --
CREATE TABLE [edfi].[StudentProgramEvaluation] (
    [EvaluationDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [EvaluationDuration] [INT] NULL,
    [StaffEvaluatorStaffUSI] [INT] NULL,
    [SummaryEvaluationComment] [NVARCHAR](1024) NULL,
    [SummaryEvaluationNumericRating] [DECIMAL](6, 3) NULL,
    [SummaryEvaluationRatingLevelDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentProgramEvaluation_PK] PRIMARY KEY CLUSTERED (
        [EvaluationDate] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentProgramEvaluation] ADD CONSTRAINT [StudentProgramEvaluation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentProgramEvaluation] ADD CONSTRAINT [StudentProgramEvaluation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentProgramEvaluation] ADD CONSTRAINT [StudentProgramEvaluation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentProgramEvaluationExternalEvaluator] --
CREATE TABLE [edfi].[StudentProgramEvaluationExternalEvaluator] (
    [EvaluationDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ExternalEvaluator] [NVARCHAR](150) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentProgramEvaluationExternalEvaluator_PK] PRIMARY KEY CLUSTERED (
        [EvaluationDate] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [ExternalEvaluator] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentProgramEvaluationExternalEvaluator] ADD CONSTRAINT [StudentProgramEvaluationExternalEvaluator_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentProgramEvaluationStudentEvaluationElement] --
CREATE TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] (
    [EvaluationDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ProgramEvaluationElementTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationElementNumericRating] [DECIMAL](6, 3) NULL,
    [EvaluationElementRatingLevelDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentProgramEvaluationStudentEvaluationElement_PK] PRIMARY KEY CLUSTERED (
        [EvaluationDate] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [ProgramEvaluationElementTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] ADD CONSTRAINT [StudentProgramEvaluationStudentEvaluationElement_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentProgramEvaluationStudentEvaluationObjective] --
CREATE TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] (
    [EvaluationDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEvaluationPeriodDescriptorId] [INT] NOT NULL,
    [ProgramEvaluationTitle] [NVARCHAR](50) NOT NULL,
    [ProgramEvaluationTypeDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ProgramEvaluationObjectiveTitle] [NVARCHAR](50) NOT NULL,
    [EvaluationObjectiveNumericRating] [DECIMAL](6, 3) NULL,
    [EvaluationObjectiveRatingLevelDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentProgramEvaluationStudentEvaluationObjective_PK] PRIMARY KEY CLUSTERED (
        [EvaluationDate] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramEvaluationPeriodDescriptorId] ASC,
        [ProgramEvaluationTitle] ASC,
        [ProgramEvaluationTypeDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [ProgramEvaluationObjectiveTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] ADD CONSTRAINT [StudentProgramEvaluationStudentEvaluationObjective_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSchoolAssociation] --
CREATE TABLE [edfi].[StudentSchoolAssociation] (
    [EntryDate] [DATE] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CalendarCode] [NVARCHAR](120) NULL,
    [ClassOfSchoolYear] [SMALLINT] NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [EmployedWhileEnrolled] [BIT] NULL,
    [EnrollmentTypeDescriptorId] [INT] NULL,
    [EntryGradeLevelDescriptorId] [INT] NOT NULL,
    [EntryGradeLevelReasonDescriptorId] [INT] NULL,
    [EntryTypeDescriptorId] [INT] NULL,
    [ExitWithdrawDate] [DATE] NULL,
    [ExitWithdrawTypeDescriptorId] [INT] NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
    [GraduationPlanTypeDescriptorId] [INT] NULL,
    [GraduationSchoolYear] [SMALLINT] NULL,
    [NextYearGradeLevelDescriptorId] [INT] NULL,
    [NextYearSchoolId] [BIGINT] NULL,
    [PrimarySchool] [BIT] NULL,
    [RepeatGradeIndicator] [BIT] NULL,
    [ResidencyStatusDescriptorId] [INT] NULL,
    [SchoolChoice] [BIT] NULL,
    [SchoolChoiceBasisDescriptorId] [INT] NULL,
    [SchoolChoiceTransfer] [BIT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [TermCompletionIndicator] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentSchoolAssociation_PK] PRIMARY KEY CLUSTERED (
        [EntryDate] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD CONSTRAINT [StudentSchoolAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD CONSTRAINT [StudentSchoolAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD CONSTRAINT [StudentSchoolAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] --
CREATE TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] (
    [EntryDate] [DATE] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AlternativeEducationOrganizationId] [BIGINT] NOT NULL,
    [AlternativeGraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [AlternativeGraduationSchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSchoolAssociationAlternativeGraduationPlan_PK] PRIMARY KEY CLUSTERED (
        [EntryDate] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC,
        [AlternativeEducationOrganizationId] ASC,
        [AlternativeGraduationPlanTypeDescriptorId] ASC,
        [AlternativeGraduationSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] ADD CONSTRAINT [StudentSchoolAssociationAlternativeGraduationPlan_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSchoolAssociationEducationPlan] --
CREATE TABLE [edfi].[StudentSchoolAssociationEducationPlan] (
    [EntryDate] [DATE] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EducationPlanDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSchoolAssociationEducationPlan_PK] PRIMARY KEY CLUSTERED (
        [EntryDate] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC,
        [EducationPlanDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolAssociationEducationPlan] ADD CONSTRAINT [StudentSchoolAssociationEducationPlan_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSchoolAttendanceEvent] --
CREATE TABLE [edfi].[StudentSchoolAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ArrivalTime] [TIME](7) NULL,
    [AttendanceEventReason] [NVARCHAR](255) NULL,
    [DepartureTime] [TIME](7) NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [EventDuration] [DECIMAL](3, 2) NULL,
    [SchoolAttendanceDuration] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentSchoolAttendanceEvent_PK] PRIMARY KEY CLUSTERED (
        [AttendanceEventCategoryDescriptorId] ASC,
        [EventDate] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD CONSTRAINT [StudentSchoolAttendanceEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD CONSTRAINT [StudentSchoolAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD CONSTRAINT [StudentSchoolAttendanceEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSchoolFoodServiceProgramAssociation] --
CREATE TABLE [edfi].[StudentSchoolFoodServiceProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DirectCertification] [BIT] NULL,
    CONSTRAINT [StudentSchoolFoodServiceProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] --
CREATE TABLE [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [SchoolFoodServiceProgramServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [SchoolFoodServiceProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] ADD CONSTRAINT [StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSection504ProgramAssociation] --
CREATE TABLE [edfi].[StudentSection504ProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AccommodationPlan] [BIT] NULL,
    [Section504DisabilityDescriptorId] [INT] NULL,
    [Section504Eligibility] [BIT] NOT NULL,
    [Section504EligibilityDecisionDate] [DATE] NULL,
    [Section504MeetingDate] [DATE] NULL,
    CONSTRAINT [StudentSection504ProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentSectionAssociation] --
CREATE TABLE [edfi].[StudentSectionAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AttemptStatusDescriptorId] [INT] NULL,
    [DualCreditEducationOrganizationId] [BIGINT] NULL,
    [DualCreditIndicator] [BIT] NULL,
    [DualCreditInstitutionDescriptorId] [INT] NULL,
    [DualCreditTypeDescriptorId] [INT] NULL,
    [DualHighSchoolCreditIndicator] [BIT] NULL,
    [EndDate] [DATE] NULL,
    [HomeroomIndicator] [BIT] NULL,
    [RepeatIdentifierDescriptorId] [INT] NULL,
    [TeacherStudentDataLinkExclusion] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSectionAssociation] ADD CONSTRAINT [StudentSectionAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSectionAssociation] ADD CONSTRAINT [StudentSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSectionAssociation] ADD CONSTRAINT [StudentSectionAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSectionAssociationProgram] --
CREATE TABLE [edfi].[StudentSectionAssociationProgram] (
    [BeginDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSectionAssociationProgram_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSectionAssociationProgram] ADD CONSTRAINT [StudentSectionAssociationProgram_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSectionAttendanceEvent] --
CREATE TABLE [edfi].[StudentSectionAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ArrivalTime] [TIME](7) NULL,
    [AttendanceEventReason] [NVARCHAR](255) NULL,
    [DepartureTime] [TIME](7) NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [EventDuration] [DECIMAL](3, 2) NULL,
    [SectionAttendanceDuration] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentSectionAttendanceEvent_PK] PRIMARY KEY CLUSTERED (
        [AttendanceEventCategoryDescriptorId] ASC,
        [EventDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD CONSTRAINT [StudentSectionAttendanceEvent_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD CONSTRAINT [StudentSectionAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD CONSTRAINT [StudentSectionAttendanceEvent_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSectionAttendanceEventClassPeriod] --
CREATE TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSectionAttendanceEventClassPeriod_PK] PRIMARY KEY CLUSTERED (
        [AttendanceEventCategoryDescriptorId] ASC,
        [EventDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC,
        [ClassPeriodName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] ADD CONSTRAINT [StudentSectionAttendanceEventClassPeriod_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociation] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdeaEligibility] [BIT] NULL,
    [IEPBeginDate] [DATE] NULL,
    [IEPEndDate] [DATE] NULL,
    [IEPEvaluationDueDate] [DATE] NULL,
    [IEPLastEvaluationDate] [DATE] NULL,
    [IEPLastReviewDate] [DATE] NULL,
    [IEPReviewDueDate] [DATE] NULL,
    [MedicallyFragile] [BIT] NULL,
    [MultiplyDisabled] [BIT] NULL,
    [ReductionInHoursPerWeekComparedToPeers] [DECIMAL](5, 2) NULL,
    [SchoolHoursPerWeek] [DECIMAL](5, 2) NULL,
    [ShortenedSchoolDayIndicator] [BIT] NULL,
    [SpecialEducationExitDate] [DATE] NULL,
    [SpecialEducationExitExplained] [NVARCHAR](1024) NULL,
    [SpecialEducationExitReasonDescriptorId] [INT] NULL,
    [SpecialEducationHoursPerWeek] [DECIMAL](5, 2) NULL,
    [SpecialEducationSettingDescriptorId] [INT] NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationDisability] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationDisability_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationDisability_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationDisabilityDesignation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [PrimaryProvider] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationServiceProvider_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationServiceProvider_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [SpecialEducationProgramServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationSpecialEducationProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [SpecialEducationProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationSpecialEducationProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [SpecialEducationProgramServiceDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [PrimaryProvider] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [SpecialEducationProgramServiceDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramEligibilityAssociation] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] (
    [ConsentToEvaluationReceivedDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ConsentToEvaluationDate] [DATE] NULL,
    [EligibilityConferenceDate] [DATE] NULL,
    [EligibilityDelayReasonDescriptorId] [INT] NULL,
    [EligibilityDeterminationDate] [DATE] NULL,
    [EligibilityEvaluationDate] [DATE] NULL,
    [EligibilityEvaluationTypeDescriptorId] [INT] NULL,
    [EvaluationCompleteIndicator] [BIT] NULL,
    [EvaluationDelayDays] [INT] NULL,
    [EvaluationDelayReasonDescriptorId] [INT] NULL,
    [EvaluationLateReason] [NVARCHAR](255) NULL,
    [IDEAIndicator] [BIT] NULL,
    [IDEAPartDescriptorId] [INT] NOT NULL,
    [OriginalECIServicesDate] [DATE] NULL,
    [TransitionConferenceDate] [DATE] NULL,
    [TransitionNotificationDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramEligibilityAssociation_PK] PRIMARY KEY CLUSTERED (
        [ConsentToEvaluationReceivedDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ADD CONSTRAINT [StudentSpecialEducationProgramEligibilityAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ADD CONSTRAINT [StudentSpecialEducationProgramEligibilityAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ADD CONSTRAINT [StudentSpecialEducationProgramEligibilityAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentTitleIPartAProgramAssociation] --
CREATE TABLE [edfi].[StudentTitleIPartAProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TitleIPartAParticipantDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StudentTitleIPartAProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] --
CREATE TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TitleIPartAProgramServiceDescriptorId] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentTitleIPartAProgramAssociationTitleIPartAProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [TitleIPartAProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] ADD CONSTRAINT [StudentTitleIPartAProgramAssociationTitleIPartAProgramService_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentTransportation] --
CREATE TABLE [edfi].[StudentTransportation] (
    [StudentUSI] [INT] NOT NULL,
    [TransportationEducationOrganizationId] [BIGINT] NOT NULL,
    [SpecialAccomodationRequirements] [NVARCHAR](1024) NULL,
    [TransportationPublicExpenseEligibilityTypeDescriptorId] [INT] NULL,
    [TransportationTypeDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentTransportation_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [TransportationEducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentTransportation] ADD CONSTRAINT [StudentTransportation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentTransportation] ADD CONSTRAINT [StudentTransportation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentTransportation] ADD CONSTRAINT [StudentTransportation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentTransportationStudentBusDetails] --
CREATE TABLE [edfi].[StudentTransportationStudentBusDetails] (
    [StudentUSI] [INT] NOT NULL,
    [TransportationEducationOrganizationId] [BIGINT] NOT NULL,
    [BusNumber] [NVARCHAR](36) NOT NULL,
    [BusRouteDescriptorId] [INT] NOT NULL,
    [Mileage] [DECIMAL](5, 2) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentTransportationStudentBusDetails_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [TransportationEducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentTransportationStudentBusDetails] ADD CONSTRAINT [StudentTransportationStudentBusDetails_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentTransportationStudentBusDetailsTravelDayofWeek] --
CREATE TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDayofWeek] (
    [StudentUSI] [INT] NOT NULL,
    [TransportationEducationOrganizationId] [BIGINT] NOT NULL,
    [TravelDayofWeekDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentTransportationStudentBusDetailsTravelDayofWeek_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [TransportationEducationOrganizationId] ASC,
        [TravelDayofWeekDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDayofWeek] ADD CONSTRAINT [StudentTransportationStudentBusDetailsTravelDayofWeek_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentTransportationStudentBusDetailsTravelDirection] --
CREATE TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDirection] (
    [StudentUSI] [INT] NOT NULL,
    [TransportationEducationOrganizationId] [BIGINT] NOT NULL,
    [TravelDirectionDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentTransportationStudentBusDetailsTravelDirection_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [TransportationEducationOrganizationId] ASC,
        [TravelDirectionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDirection] ADD CONSTRAINT [StudentTransportationStudentBusDetailsTravelDirection_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentVisa] --
CREATE TABLE [edfi].[StudentVisa] (
    [StudentUSI] [INT] NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentVisa_PK] PRIMARY KEY CLUSTERED (
        [StudentUSI] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentVisa] ADD CONSTRAINT [StudentVisa_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SubmissionStatusDescriptor] --
CREATE TABLE [edfi].[SubmissionStatusDescriptor] (
    [SubmissionStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SubmissionStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SubmissionStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SupporterMilitaryConnectionDescriptor] --
CREATE TABLE [edfi].[SupporterMilitaryConnectionDescriptor] (
    [SupporterMilitaryConnectionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SupporterMilitaryConnectionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SupporterMilitaryConnectionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Survey] --
CREATE TABLE [edfi].[Survey] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [NumberAdministered] [INT] NULL,
    [SchoolId] [BIGINT] NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](120) NULL,
    [SurveyCategoryDescriptorId] [INT] NULL,
    [SurveyTitle] [NVARCHAR](255) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Survey_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Survey] ADD CONSTRAINT [Survey_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Survey] ADD CONSTRAINT [Survey_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Survey] ADD CONSTRAINT [Survey_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyCategoryDescriptor] --
CREATE TABLE [edfi].[SurveyCategoryDescriptor] (
    [SurveyCategoryDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SurveyCategoryDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SurveyCategoryDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SurveyCourseAssociation] --
CREATE TABLE [edfi].[SurveyCourseAssociation] (
    [CourseCode] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyCourseAssociation_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [SurveyIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD CONSTRAINT [SurveyCourseAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD CONSTRAINT [SurveyCourseAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD CONSTRAINT [SurveyCourseAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyLevelDescriptor] --
CREATE TABLE [edfi].[SurveyLevelDescriptor] (
    [SurveyLevelDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SurveyLevelDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SurveyLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SurveyProgramAssociation] --
CREATE TABLE [edfi].[SurveyProgramAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [SurveyIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD CONSTRAINT [SurveyProgramAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD CONSTRAINT [SurveyProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD CONSTRAINT [SurveyProgramAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyQuestion] --
CREATE TABLE [edfi].[SurveyQuestion] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](120) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [QuestionFormDescriptorId] [INT] NOT NULL,
    [QuestionText] [NVARCHAR](1024) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyQuestion_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestion] ADD CONSTRAINT [SurveyQuestion_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyQuestion] ADD CONSTRAINT [SurveyQuestion_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyQuestion] ADD CONSTRAINT [SurveyQuestion_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyQuestionMatrix] --
CREATE TABLE [edfi].[SurveyQuestionMatrix] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](120) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [MatrixElement] [NVARCHAR](255) NOT NULL,
    [MaxRawScore] [INT] NULL,
    [MinRawScore] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionMatrix_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC,
        [MatrixElement] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionMatrix] ADD CONSTRAINT [SurveyQuestionMatrix_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyQuestionResponse] --
CREATE TABLE [edfi].[SurveyQuestionResponse] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](120) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [Comment] [NVARCHAR](1024) NULL,
    [NoResponse] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyQuestionResponse_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD CONSTRAINT [SurveyQuestionResponse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD CONSTRAINT [SurveyQuestionResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD CONSTRAINT [SurveyQuestionResponse_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyQuestionResponseChoice] --
CREATE TABLE [edfi].[SurveyQuestionResponseChoice] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](120) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SortOrder] [INT] NOT NULL,
    [NumericValue] [INT] NULL,
    [TextValue] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionResponseChoice_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC,
        [SortOrder] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionResponseChoice] ADD CONSTRAINT [SurveyQuestionResponseChoice_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] --
CREATE TABLE [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](120) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [MatrixElement] [NVARCHAR](255) NOT NULL,
    [MaxNumericResponse] [INT] NULL,
    [MinNumericResponse] [INT] NULL,
    [NoResponse] [BIT] NULL,
    [NumericResponse] [INT] NULL,
    [TextResponse] [NVARCHAR](2048) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionResponseSurveyQuestionMatrixElementResponse_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [MatrixElement] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] ADD CONSTRAINT [SurveyQuestionResponseSurveyQuestionMatrixElementResponse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyQuestionResponseValue] --
CREATE TABLE [edfi].[SurveyQuestionResponseValue] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](120) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyQuestionResponseValueIdentifier] [INT] NOT NULL,
    [NumericResponse] [INT] NULL,
    [TextResponse] [NVARCHAR](2048) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionResponseValue_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [SurveyQuestionResponseValueIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionResponseValue] ADD CONSTRAINT [SurveyQuestionResponseValue_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyResponse] --
CREATE TABLE [edfi].[SurveyResponse] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [ContactUSI] [INT] NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NULL,
    [FullName] [NVARCHAR](80) NULL,
    [Location] [NVARCHAR](75) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [ResponseDate] [DATE] NOT NULL,
    [ResponseTime] [INT] NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [StaffUSI] [INT] NULL,
    [StudentUSI] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyResponse_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyResponse] ADD CONSTRAINT [SurveyResponse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyResponse] ADD CONSTRAINT [SurveyResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyResponse] ADD CONSTRAINT [SurveyResponse_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyResponseEducationOrganizationTargetAssociation] --
CREATE TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyResponseEducationOrganizationTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveyResponseEducationOrganizationTargetAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveyResponseEducationOrganizationTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveyResponseEducationOrganizationTargetAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyResponsePersonTargetAssociation] --
CREATE TABLE [edfi].[SurveyResponsePersonTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
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
ALTER TABLE [edfi].[SurveyResponsePersonTargetAssociation] ADD CONSTRAINT [SurveyResponsePersonTargetAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyResponsePersonTargetAssociation] ADD CONSTRAINT [SurveyResponsePersonTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyResponsePersonTargetAssociation] ADD CONSTRAINT [SurveyResponsePersonTargetAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyResponseStaffTargetAssociation] --
CREATE TABLE [edfi].[SurveyResponseStaffTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyResponseStaffTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [StaffUSI] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD CONSTRAINT [SurveyResponseStaffTargetAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD CONSTRAINT [SurveyResponseStaffTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD CONSTRAINT [SurveyResponseStaffTargetAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyResponseSurveyLevel] --
CREATE TABLE [edfi].[SurveyResponseSurveyLevel] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyResponseSurveyLevel_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [SurveyLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyResponseSurveyLevel] ADD CONSTRAINT [SurveyResponseSurveyLevel_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveySection] --
CREATE TABLE [edfi].[SurveySection] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [EducationOrganizationId] [BIGINT] NULL,
    [EvaluationElementTitle] [NVARCHAR](255) NULL,
    [EvaluationObjectiveTitle] [NVARCHAR](50) NULL,
    [EvaluationPeriodDescriptorId] [INT] NULL,
    [EvaluationTitle] [NVARCHAR](50) NULL,
    [PerformanceEvaluationTitle] [NVARCHAR](50) NULL,
    [PerformanceEvaluationTypeDescriptorId] [INT] NULL,
    [SchoolYear] [SMALLINT] NULL,
    [TermDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySection_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveySectionTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveySection] ADD CONSTRAINT [SurveySection_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySection] ADD CONSTRAINT [SurveySection_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySection] ADD CONSTRAINT [SurveySection_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionAggregateResponse] --
CREATE TABLE [edfi].[SurveySectionAggregateResponse] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [EvaluationDate] [DATETIME2](7) NOT NULL,
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
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
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
ALTER TABLE [edfi].[SurveySectionAggregateResponse] ADD CONSTRAINT [SurveySectionAggregateResponse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionAggregateResponse] ADD CONSTRAINT [SurveySectionAggregateResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionAggregateResponse] ADD CONSTRAINT [SurveySectionAggregateResponse_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionAssociation] --
CREATE TABLE [edfi].[SurveySectionAssociation] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](120) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [Namespace] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [SurveyIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveySectionAssociation] ADD CONSTRAINT [SurveySectionAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionAssociation] ADD CONSTRAINT [SurveySectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionAssociation] ADD CONSTRAINT [SurveySectionAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionResponse] --
CREATE TABLE [edfi].[SurveySectionResponse] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [SectionRating] [DECIMAL](9, 3) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySectionResponse_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [SurveySectionTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveySectionResponse] ADD CONSTRAINT [SurveySectionResponse_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionResponse] ADD CONSTRAINT [SurveySectionResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionResponse] ADD CONSTRAINT [SurveySectionResponse_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] --
CREATE TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] (
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySectionResponseEducationOrganizationTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [SurveySectionTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveySectionResponseEducationOrganizationTargetAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveySectionResponseEducationOrganizationTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveySectionResponseEducationOrganizationTargetAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionResponsePersonTargetAssociation] --
CREATE TABLE [edfi].[SurveySectionResponsePersonTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PersonId] [NVARCHAR](32) NOT NULL,
    [SourceSystemDescriptorId] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
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
ALTER TABLE [edfi].[SurveySectionResponsePersonTargetAssociation] ADD CONSTRAINT [SurveySectionResponsePersonTargetAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionResponsePersonTargetAssociation] ADD CONSTRAINT [SurveySectionResponsePersonTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionResponsePersonTargetAssociation] ADD CONSTRAINT [SurveySectionResponsePersonTargetAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionResponseStaffTargetAssociation] --
CREATE TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](120) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySectionResponseStaffTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [StaffUSI] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [SurveySectionTitle] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD CONSTRAINT [SurveySectionResponseStaffTargetAssociation_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD CONSTRAINT [SurveySectionResponseStaffTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD CONSTRAINT [SurveySectionResponseStaffTargetAssociation_DF_LastModifiedDate] DEFAULT (getutcdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[TeachingCredentialBasisDescriptor] --
CREATE TABLE [edfi].[TeachingCredentialBasisDescriptor] (
    [TeachingCredentialBasisDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TeachingCredentialBasisDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TeachingCredentialBasisDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TeachingCredentialDescriptor] --
CREATE TABLE [edfi].[TeachingCredentialDescriptor] (
    [TeachingCredentialDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TeachingCredentialDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TeachingCredentialDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TechnicalSkillsAssessmentDescriptor] --
CREATE TABLE [edfi].[TechnicalSkillsAssessmentDescriptor] (
    [TechnicalSkillsAssessmentDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TechnicalSkillsAssessmentDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TechnicalSkillsAssessmentDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TelephoneNumberTypeDescriptor] --
CREATE TABLE [edfi].[TelephoneNumberTypeDescriptor] (
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TelephoneNumberTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TermDescriptor] --
CREATE TABLE [edfi].[TermDescriptor] (
    [TermDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TermDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TitleIPartAParticipantDescriptor] --
CREATE TABLE [edfi].[TitleIPartAParticipantDescriptor] (
    [TitleIPartAParticipantDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TitleIPartAParticipantDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TitleIPartAParticipantDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TitleIPartAProgramServiceDescriptor] --
CREATE TABLE [edfi].[TitleIPartAProgramServiceDescriptor] (
    [TitleIPartAProgramServiceDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TitleIPartAProgramServiceDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TitleIPartAProgramServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TitleIPartASchoolDesignationDescriptor] --
CREATE TABLE [edfi].[TitleIPartASchoolDesignationDescriptor] (
    [TitleIPartASchoolDesignationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TitleIPartASchoolDesignationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TitleIPartASchoolDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TransportationPublicExpenseEligibilityTypeDescriptor] --
CREATE TABLE [edfi].[TransportationPublicExpenseEligibilityTypeDescriptor] (
    [TransportationPublicExpenseEligibilityTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TransportationPublicExpenseEligibilityTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TransportationPublicExpenseEligibilityTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TransportationTypeDescriptor] --
CREATE TABLE [edfi].[TransportationTypeDescriptor] (
    [TransportationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TransportationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TransportationTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TravelDayofWeekDescriptor] --
CREATE TABLE [edfi].[TravelDayofWeekDescriptor] (
    [TravelDayofWeekDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TravelDayofWeekDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TravelDayofWeekDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TravelDirectionDescriptor] --
CREATE TABLE [edfi].[TravelDirectionDescriptor] (
    [TravelDirectionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TravelDirectionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TravelDirectionDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[TribalAffiliationDescriptor] --
CREATE TABLE [edfi].[TribalAffiliationDescriptor] (
    [TribalAffiliationDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TribalAffiliationDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TribalAffiliationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[VisaDescriptor] --
CREATE TABLE [edfi].[VisaDescriptor] (
    [VisaDescriptorId] [INT] NOT NULL,
    CONSTRAINT [VisaDescriptor_PK] PRIMARY KEY CLUSTERED (
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[WeaponDescriptor] --
CREATE TABLE [edfi].[WeaponDescriptor] (
    [WeaponDescriptorId] [INT] NOT NULL,
    CONSTRAINT [WeaponDescriptor_PK] PRIMARY KEY CLUSTERED (
        [WeaponDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[WithdrawReasonDescriptor] --
CREATE TABLE [edfi].[WithdrawReasonDescriptor] (
    [WithdrawReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [WithdrawReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [WithdrawReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

