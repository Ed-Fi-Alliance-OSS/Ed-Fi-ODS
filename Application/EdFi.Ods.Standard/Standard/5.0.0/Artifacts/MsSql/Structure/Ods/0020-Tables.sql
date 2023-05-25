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
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[AcademicWeek] ADD CONSTRAINT [AcademicWeek_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AcademicWeek] ADD CONSTRAINT [AcademicWeek_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AcademicWeek] ADD CONSTRAINT [AcademicWeek_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[AccountabilityRating] ADD CONSTRAINT [AccountabilityRating_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AccountabilityRating] ADD CONSTRAINT [AccountabilityRating_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AccountabilityRating] ADD CONSTRAINT [AccountabilityRating_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AccountTypeDescriptor] --
CREATE TABLE [edfi].[AccountTypeDescriptor] (
    [AccountTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AccountTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AccountTypeDescriptorId] ASC
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

-- Table [edfi].[AncestryEthnicOriginDescriptor] --
CREATE TABLE [edfi].[AncestryEthnicOriginDescriptor] (
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AncestryEthnicOriginDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AncestryEthnicOriginDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Assessment] --
CREATE TABLE [edfi].[Assessment] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentTitle] [NVARCHAR](255) NOT NULL,
    [AssessmentCategoryDescriptorId] [INT] NULL,
    [AssessmentForm] [NVARCHAR](60) NULL,
    [AssessmentVersion] [INT] NULL,
    [RevisionDate] [DATE] NULL,
    [MaxRawScore] [DECIMAL](15, 5) NULL,
    [Nomenclature] [NVARCHAR](100) NULL,
    [AssessmentFamily] [NVARCHAR](60) NULL,
    [EducationOrganizationId] [INT] NULL,
    [AdaptiveAssessment] [BIT] NULL,
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
ALTER TABLE [edfi].[Assessment] ADD CONSTRAINT [Assessment_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Assessment] ADD CONSTRAINT [Assessment_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Assessment] ADD CONSTRAINT [Assessment_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentAcademicSubject] --
CREATE TABLE [edfi].[AssessmentAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAcademicSubject] ADD CONSTRAINT [AssessmentAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentAssessedGradeLevel] --
CREATE TABLE [edfi].[AssessmentAssessedGradeLevel] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentAssessedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [GradeLevelDescriptorId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentAssessedGradeLevel] ADD CONSTRAINT [AssessmentAssessedGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Title] [NVARCHAR](75) NOT NULL,
    [Version] [NVARCHAR](50) NULL,
    [URI] [NVARCHAR](255) NULL,
    [PublicationDate] [DATE] NULL,
    [PublicationYear] [SMALLINT] NULL,
    [PublicationStatusDescriptorId] [INT] NULL,
    [MandatingEducationOrganizationId] [INT] NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentContentStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentContentStandard] ADD CONSTRAINT [AssessmentContentStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentContentStandardAuthor] --
CREATE TABLE [edfi].[AssessmentContentStandardAuthor] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Author] [NVARCHAR](100) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentContentStandardAuthor_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [Author] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentContentStandardAuthor] ADD CONSTRAINT [AssessmentContentStandardAuthor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentIdentificationCode] --
CREATE TABLE [edfi].[AssessmentIdentificationCode] (
    [AssessmentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentificationSystemDescriptorId] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentIdentificationCode] ADD CONSTRAINT [AssessmentIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [AssessmentItemCategoryDescriptorId] [INT] NULL,
    [MaxRawScore] [DECIMAL](15, 5) NULL,
    [ItemText] [NVARCHAR](1024) NULL,
    [ExpectedTimeAssessed] [NVARCHAR](30) NULL,
    [Nomenclature] [NVARCHAR](100) NULL,
    [AssessmentItemURI] [NVARCHAR](255) NULL,
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
ALTER TABLE [edfi].[AssessmentItem] ADD CONSTRAINT [AssessmentItem_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AssessmentItem] ADD CONSTRAINT [AssessmentItem_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AssessmentItem] ADD CONSTRAINT [AssessmentItem_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentItemLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [LearningStandardId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentItemLearningStandard] ADD CONSTRAINT [AssessmentItemLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentItemPossibleResponse] --
CREATE TABLE [edfi].[AssessmentItemPossibleResponse] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ResponseValue] [NVARCHAR](60) NOT NULL,
    [ResponseDescription] [NVARCHAR](1024) NULL,
    [CorrectResponse] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentItemPossibleResponse_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [ResponseValue] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentItemPossibleResponse] ADD CONSTRAINT [AssessmentItemPossibleResponse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentLanguage_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [LanguageDescriptorId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentLanguage] ADD CONSTRAINT [AssessmentLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentPerformanceLevel] --
CREATE TABLE [edfi].[AssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [Namespace] ASC,
        [PerformanceLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentPerformanceLevel] ADD CONSTRAINT [AssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentPeriod] --
CREATE TABLE [edfi].[AssessmentPeriod] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentPeriodDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentPeriod_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentPeriodDescriptorId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentPeriod] ADD CONSTRAINT [AssessmentPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[AssessmentPlatformType] ADD CONSTRAINT [AssessmentPlatformType_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentProgram] --
CREATE TABLE [edfi].[AssessmentProgram] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentProgram_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [Namespace] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentProgram] ADD CONSTRAINT [AssessmentProgram_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentScore_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentScore] ADD CONSTRAINT [AssessmentScore_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentScoreRangeLearningStandard] --
CREATE TABLE [edfi].[AssessmentScoreRangeLearningStandard] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ScoreRangeId] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NULL,
    [MinimumScore] [NVARCHAR](35) NOT NULL,
    [MaximumScore] [NVARCHAR](35) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NULL,
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
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandard_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandard_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] --
CREATE TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ScoreRangeId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentScoreRangeLearningStandardLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [LearningStandardId] ASC,
        [Namespace] ASC,
        [ScoreRangeId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] ADD CONSTRAINT [AssessmentScoreRangeLearningStandardLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[AssessmentSection] --
CREATE TABLE [edfi].[AssessmentSection] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AssessmentSection_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [LocalCourseCode] ASC,
        [Namespace] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[AssessmentSection] ADD CONSTRAINT [AssessmentSection_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[BalanceSheetDimension] ADD CONSTRAINT [BalanceSheetDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[BalanceSheetDimension] ADD CONSTRAINT [BalanceSheetDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[BalanceSheetDimension] ADD CONSTRAINT [BalanceSheetDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[BalanceSheetDimensionReportingTag] ADD CONSTRAINT [BalanceSheetDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [SchoolId] [INT] NOT NULL,
    [AlternateDayName] [NVARCHAR](20) NULL,
    [StartTime] [TIME](7) NULL,
    [EndTime] [TIME](7) NULL,
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
ALTER TABLE [edfi].[BellSchedule] ADD CONSTRAINT [BellSchedule_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[BellSchedule] ADD CONSTRAINT [BellSchedule_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[BellSchedule] ADD CONSTRAINT [BellSchedule_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[BellScheduleClassPeriod] --
CREATE TABLE [edfi].[BellScheduleClassPeriod] (
    [BellScheduleName] [NVARCHAR](60) NOT NULL,
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [BellScheduleClassPeriod_PK] PRIMARY KEY CLUSTERED (
        [BellScheduleName] ASC,
        [ClassPeriodName] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BellScheduleClassPeriod] ADD CONSTRAINT [BellScheduleClassPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[BellScheduleDate] --
CREATE TABLE [edfi].[BellScheduleDate] (
    [BellScheduleName] [NVARCHAR](60) NOT NULL,
    [Date] [DATE] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [BellScheduleDate_PK] PRIMARY KEY CLUSTERED (
        [BellScheduleName] ASC,
        [Date] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BellScheduleDate] ADD CONSTRAINT [BellScheduleDate_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[BellScheduleGradeLevel] --
CREATE TABLE [edfi].[BellScheduleGradeLevel] (
    [BellScheduleName] [NVARCHAR](60) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [BellScheduleGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [BellScheduleName] ASC,
        [GradeLevelDescriptorId] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[BellScheduleGradeLevel] ADD CONSTRAINT [BellScheduleGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[Calendar] --
CREATE TABLE [edfi].[Calendar] (
    [CalendarCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[Calendar] ADD CONSTRAINT [Calendar_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Calendar] ADD CONSTRAINT [Calendar_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Calendar] ADD CONSTRAINT [Calendar_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CalendarDate] --
CREATE TABLE [edfi].[CalendarDate] (
    [CalendarCode] [NVARCHAR](60) NOT NULL,
    [Date] [DATE] NOT NULL,
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[CalendarDate] ADD CONSTRAINT [CalendarDate_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CalendarDate] ADD CONSTRAINT [CalendarDate_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CalendarDate] ADD CONSTRAINT [CalendarDate_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CalendarDateCalendarEvent] --
CREATE TABLE [edfi].[CalendarDateCalendarEvent] (
    [CalendarCode] [NVARCHAR](60) NOT NULL,
    [CalendarEventDescriptorId] [INT] NOT NULL,
    [Date] [DATE] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CalendarDateCalendarEvent_PK] PRIMARY KEY CLUSTERED (
        [CalendarCode] ASC,
        [CalendarEventDescriptorId] ASC,
        [Date] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CalendarDateCalendarEvent] ADD CONSTRAINT [CalendarDateCalendarEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [CalendarCode] [NVARCHAR](60) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CalendarGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CalendarCode] ASC,
        [GradeLevelDescriptorId] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CalendarGradeLevel] ADD CONSTRAINT [CalendarGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CalendarTypeDescriptor] --
CREATE TABLE [edfi].[CalendarTypeDescriptor] (
    [CalendarTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CalendarTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CalendarTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CareerPathwayDescriptor] --
CREATE TABLE [edfi].[CareerPathwayDescriptor] (
    [CareerPathwayDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CareerPathwayDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CareerPathwayDescriptorId] ASC
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
    [EducationOrganizationId] [INT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [AccountTypeDescriptorId] [INT] NOT NULL,
    [AccountName] [NVARCHAR](100) NULL,
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
ALTER TABLE [edfi].[ChartOfAccount] ADD CONSTRAINT [ChartOfAccount_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ChartOfAccount] ADD CONSTRAINT [ChartOfAccount_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ChartOfAccount] ADD CONSTRAINT [ChartOfAccount_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ChartOfAccountReportingTag] --
CREATE TABLE [edfi].[ChartOfAccountReportingTag] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[ChartOfAccountReportingTag] ADD CONSTRAINT [ChartOfAccountReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[ClassPeriod] ADD CONSTRAINT [ClassPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ClassPeriod] ADD CONSTRAINT [ClassPeriod_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ClassPeriod] ADD CONSTRAINT [ClassPeriod_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ClassPeriodMeetingTime] --
CREATE TABLE [edfi].[ClassPeriodMeetingTime] (
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [EndTime] [TIME](7) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StartTime] [TIME](7) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ClassPeriodMeetingTime_PK] PRIMARY KEY CLUSTERED (
        [ClassPeriodName] ASC,
        [EndTime] ASC,
        [SchoolId] ASC,
        [StartTime] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ClassPeriodMeetingTime] ADD CONSTRAINT [ClassPeriodMeetingTime_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [CohortDescription] [NVARCHAR](1024) NULL,
    [CohortTypeDescriptorId] [INT] NOT NULL,
    [CohortScopeDescriptorId] [INT] NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[Cohort] ADD CONSTRAINT [Cohort_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Cohort] ADD CONSTRAINT [Cohort_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Cohort] ADD CONSTRAINT [Cohort_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CohortProgram] --
CREATE TABLE [edfi].[CohortProgram] (
    [CohortIdentifier] [NVARCHAR](36) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[CohortProgram] ADD CONSTRAINT [CohortProgram_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [CommunityOrganizationId] [INT] NOT NULL,
    CONSTRAINT [CommunityOrganization_PK] PRIMARY KEY CLUSTERED (
        [CommunityOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CommunityProvider] --
CREATE TABLE [edfi].[CommunityProvider] (
    [CommunityProviderId] [INT] NOT NULL,
    [CommunityOrganizationId] [INT] NULL,
    [ProviderProfitabilityDescriptorId] [INT] NULL,
    [ProviderStatusDescriptorId] [INT] NOT NULL,
    [ProviderCategoryDescriptorId] [INT] NOT NULL,
    [SchoolIndicator] [BIT] NULL,
    [LicenseExemptIndicator] [BIT] NULL,
    CONSTRAINT [CommunityProvider_PK] PRIMARY KEY CLUSTERED (
        [CommunityProviderId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CommunityProviderLicense] --
CREATE TABLE [edfi].[CommunityProviderLicense] (
    [CommunityProviderId] [INT] NOT NULL,
    [LicenseIdentifier] [NVARCHAR](36) NOT NULL,
    [LicensingOrganization] [NVARCHAR](75) NOT NULL,
    [LicenseEffectiveDate] [DATE] NOT NULL,
    [LicenseExpirationDate] [DATE] NULL,
    [LicenseIssueDate] [DATE] NULL,
    [LicenseStatusDescriptorId] [INT] NULL,
    [LicenseTypeDescriptorId] [INT] NOT NULL,
    [AuthorizedFacilityCapacity] [INT] NULL,
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
ALTER TABLE [edfi].[CommunityProviderLicense] ADD CONSTRAINT [CommunityProviderLicense_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CommunityProviderLicense] ADD CONSTRAINT [CommunityProviderLicense_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CommunityProviderLicense] ADD CONSTRAINT [CommunityProviderLicense_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [CompetencyObjectiveId] [NVARCHAR](60) NULL,
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
ALTER TABLE [edfi].[CompetencyObjective] ADD CONSTRAINT [CompetencyObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CompetencyObjective] ADD CONSTRAINT [CompetencyObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CompetencyObjective] ADD CONSTRAINT [CompetencyObjective_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [CourseTitle] [NVARCHAR](60) NOT NULL,
    [NumberOfParts] [INT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [CourseDescription] [NVARCHAR](1024) NULL,
    [TimeRequiredForCompletion] [INT] NULL,
    [DateCourseAdopted] [DATE] NULL,
    [HighSchoolCourseRequirement] [BIT] NULL,
    [CourseGPAApplicabilityDescriptorId] [INT] NULL,
    [CourseDefinedByDescriptorId] [INT] NULL,
    [MinimumAvailableCredits] [DECIMAL](9, 3) NULL,
    [MinimumAvailableCreditTypeDescriptorId] [INT] NULL,
    [MinimumAvailableCreditConversion] [DECIMAL](9, 2) NULL,
    [MaximumAvailableCredits] [DECIMAL](9, 3) NULL,
    [MaximumAvailableCreditTypeDescriptorId] [INT] NULL,
    [MaximumAvailableCreditConversion] [DECIMAL](9, 2) NULL,
    [CareerPathwayDescriptorId] [INT] NULL,
    [MaxCompletionsForCredit] [INT] NULL,
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
ALTER TABLE [edfi].[Course] ADD CONSTRAINT [Course_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Course] ADD CONSTRAINT [Course_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Course] ADD CONSTRAINT [Course_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [CompetencyLevelDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseCompetencyLevel_PK] PRIMARY KEY CLUSTERED (
        [CompetencyLevelDescriptorId] ASC,
        [CourseCode] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseCompetencyLevel] ADD CONSTRAINT [CourseCompetencyLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseIdentificationSystemDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [CourseCatalogURL] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [CourseIdentificationSystemDescriptorId] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseIdentificationCode] ADD CONSTRAINT [CourseIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[CourseIdentificationSystemDescriptor] (
    [CourseIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [CourseIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [CourseIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[CourseLearningObjective] --
CREATE TABLE [edfi].[CourseLearningObjective] (
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseLearningObjective_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseLearningObjective] ADD CONSTRAINT [CourseLearningObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseLearningStandard] --
CREATE TABLE [edfi].[CourseLearningStandard] (
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseLearningStandard] ADD CONSTRAINT [CourseLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseLevelCharacteristic] --
CREATE TABLE [edfi].[CourseLevelCharacteristic] (
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseLevelCharacteristicDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseLevelCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [CourseLevelCharacteristicDescriptorId] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseLevelCharacteristic] ADD CONSTRAINT [CourseLevelCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferedGradeLevel] ADD CONSTRAINT [CourseOfferedGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseOffering] --
CREATE TABLE [edfi].[CourseOffering] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [LocalCourseTitle] [NVARCHAR](60) NULL,
    [InstructionalTimePlanned] [INT] NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[CourseOffering] ADD CONSTRAINT [CourseOffering_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CourseOffering] ADD CONSTRAINT [CourseOffering_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CourseOffering] ADD CONSTRAINT [CourseOffering_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CourseOfferingCourseLevelCharacteristic] --
CREATE TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] (
    [CourseLevelCharacteristicDescriptorId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferingCourseLevelCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [CourseLevelCharacteristicDescriptorId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] ADD CONSTRAINT [CourseOfferingCourseLevelCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseOfferingCurriculumUsed] --
CREATE TABLE [edfi].[CourseOfferingCurriculumUsed] (
    [CurriculumUsedDescriptorId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferingCurriculumUsed_PK] PRIMARY KEY CLUSTERED (
        [CurriculumUsedDescriptorId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] ADD CONSTRAINT [CourseOfferingCurriculumUsed_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseOfferingOfferedGradeLevel] --
CREATE TABLE [edfi].[CourseOfferingOfferedGradeLevel] (
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseOfferingOfferedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [GradeLevelDescriptorId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] ADD CONSTRAINT [CourseOfferingOfferedGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AttemptedCredits] [DECIMAL](9, 3) NULL,
    [AttemptedCreditTypeDescriptorId] [INT] NULL,
    [AttemptedCreditConversion] [DECIMAL](9, 2) NULL,
    [EarnedCredits] [DECIMAL](9, 3) NULL,
    [EarnedCreditTypeDescriptorId] [INT] NULL,
    [EarnedCreditConversion] [DECIMAL](9, 2) NULL,
    [WhenTakenGradeLevelDescriptorId] [INT] NULL,
    [MethodCreditEarnedDescriptorId] [INT] NULL,
    [FinalLetterGradeEarned] [NVARCHAR](20) NULL,
    [FinalNumericGradeEarned] [DECIMAL](9, 2) NULL,
    [CourseRepeatCodeDescriptorId] [INT] NULL,
    [CourseTitle] [NVARCHAR](60) NULL,
    [AlternativeCourseTitle] [NVARCHAR](60) NULL,
    [AlternativeCourseCode] [NVARCHAR](60) NULL,
    [ExternalEducationOrganizationId] [INT] NULL,
    [ExternalEducationOrganizationNameOfInstitution] [NVARCHAR](75) NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [CourseCatalogURL] [NVARCHAR](255) NULL,
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
ALTER TABLE [edfi].[CourseTranscript] ADD CONSTRAINT [CourseTranscript_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[CourseTranscript] ADD CONSTRAINT [CourseTranscript_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[CourseTranscript] ADD CONSTRAINT [CourseTranscript_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CourseTranscriptAcademicSubject] --
CREATE TABLE [edfi].[CourseTranscriptAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
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
ALTER TABLE [edfi].[CourseTranscriptAcademicSubject] ADD CONSTRAINT [CourseTranscriptAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] --
CREATE TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [CourseIdentificationSystemDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [CourseCatalogURL] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptAlternativeCourseIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [CourseIdentificationSystemDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] ADD CONSTRAINT [CourseTranscriptAlternativeCourseIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptCreditCategory] --
CREATE TABLE [edfi].[CourseTranscriptCreditCategory] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [CreditCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptCreditCategory_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [CreditCategoryDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CourseTranscriptCreditCategory] ADD CONSTRAINT [CourseTranscriptCreditCategory_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptEarnedAdditionalCredits] --
CREATE TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] (
    [AdditionalCreditTypeDescriptorId] [INT] NOT NULL,
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptEarnedAdditionalCredits_PK] PRIMARY KEY CLUSTERED (
        [AdditionalCreditTypeDescriptorId] ASC,
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
ALTER TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] ADD CONSTRAINT [CourseTranscriptEarnedAdditionalCredits_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CourseTranscriptPartialCourseTranscriptAwards] --
CREATE TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] (
    [AwardDate] [DATE] NOT NULL,
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [EarnedCredits] [DECIMAL](9, 3) NOT NULL,
    [MethodCreditEarnedDescriptorId] [INT] NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [NumericGradeEarned] [NVARCHAR](20) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CourseTranscriptPartialCourseTranscriptAwards_PK] PRIMARY KEY CLUSTERED (
        [AwardDate] ASC,
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
ALTER TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] ADD CONSTRAINT [CourseTranscriptPartialCourseTranscriptAwards_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[Credential] --
CREATE TABLE [edfi].[Credential] (
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [EffectiveDate] [DATE] NULL,
    [ExpirationDate] [DATE] NULL,
    [CredentialFieldDescriptorId] [INT] NULL,
    [IssuanceDate] [DATE] NOT NULL,
    [CredentialTypeDescriptorId] [INT] NOT NULL,
    [TeachingCredentialDescriptorId] [INT] NULL,
    [TeachingCredentialBasisDescriptorId] [INT] NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
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
ALTER TABLE [edfi].[Credential] ADD CONSTRAINT [Credential_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Credential] ADD CONSTRAINT [Credential_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Credential] ADD CONSTRAINT [Credential_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[CredentialAcademicSubject] --
CREATE TABLE [edfi].[CredentialAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CredentialAcademicSubject] ADD CONSTRAINT [CredentialAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[CredentialEndorsement] --
CREATE TABLE [edfi].[CredentialEndorsement] (
    [CredentialEndorsement] [NVARCHAR](255) NOT NULL,
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialEndorsement_PK] PRIMARY KEY CLUSTERED (
        [CredentialEndorsement] ASC,
        [CredentialIdentifier] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CredentialEndorsement] ADD CONSTRAINT [CredentialEndorsement_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [CredentialGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [GradeLevelDescriptorId] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[CredentialGradeLevel] ADD CONSTRAINT [CredentialGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Descriptor_PK] PRIMARY KEY CLUSTERED (
        [DescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
    CONSTRAINT [Descriptor_AK] UNIQUE NONCLUSTERED (
        [CodeValue] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Descriptor] ADD CONSTRAINT [Descriptor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Descriptor] ADD CONSTRAINT [Descriptor_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Descriptor] ADD CONSTRAINT [Descriptor_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[DescriptorMapping] ADD CONSTRAINT [DescriptorMapping_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[DescriptorMapping] ADD CONSTRAINT [DescriptorMapping_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[DescriptorMapping] ADD CONSTRAINT [DescriptorMapping_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[DescriptorMappingModelEntity] --
CREATE TABLE [edfi].[DescriptorMappingModelEntity] (
    [MappedNamespace] [NVARCHAR](255) NOT NULL,
    [MappedValue] [NVARCHAR](50) NOT NULL,
    [ModelEntityDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Value] [NVARCHAR](50) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DescriptorMappingModelEntity_PK] PRIMARY KEY CLUSTERED (
        [MappedNamespace] ASC,
        [MappedValue] ASC,
        [ModelEntityDescriptorId] ASC,
        [Namespace] ASC,
        [Value] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DescriptorMappingModelEntity] ADD CONSTRAINT [DescriptorMappingModelEntity_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [DisciplineActionLength] [DECIMAL](5, 2) NULL,
    [ActualDisciplineActionLength] [DECIMAL](5, 2) NULL,
    [DisciplineActionLengthDifferenceReasonDescriptorId] [INT] NULL,
    [RelatedToZeroTolerancePolicy] [BIT] NULL,
    [ResponsibilitySchoolId] [INT] NOT NULL,
    [AssignmentSchoolId] [INT] NULL,
    [ReceivedEducationServicesDuringExpulsion] [BIT] NULL,
    [IEPPlacementMeetingIndicator] [BIT] NULL,
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
ALTER TABLE [edfi].[DisciplineAction] ADD CONSTRAINT [DisciplineAction_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[DisciplineAction] ADD CONSTRAINT [DisciplineAction_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[DisciplineAction] ADD CONSTRAINT [DisciplineAction_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[DisciplineActionDiscipline] --
CREATE TABLE [edfi].[DisciplineActionDiscipline] (
    [DisciplineActionIdentifier] [NVARCHAR](36) NOT NULL,
    [DisciplineDate] [DATE] NOT NULL,
    [DisciplineDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineActionDiscipline_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [DisciplineDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineActionDiscipline] ADD CONSTRAINT [DisciplineActionDiscipline_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [StaffUSI] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineActionStaff_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [StaffUSI] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineActionStaff] ADD CONSTRAINT [DisciplineActionStaff_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineActionStudentDisciplineIncidentAssociation] --
CREATE TABLE [edfi].[DisciplineActionStudentDisciplineIncidentAssociation] (
    [DisciplineActionIdentifier] [NVARCHAR](36) NOT NULL,
    [DisciplineDate] [DATE] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineActionStudentDisciplineIncidentAssociation_PK] PRIMARY KEY CLUSTERED (
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineActionStudentDisciplineIncidentAssociation] ADD CONSTRAINT [DisciplineActionStudentDisciplineIncidentAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] --
CREATE TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [DisciplineActionIdentifier] [NVARCHAR](36) NOT NULL,
    [DisciplineDate] [DATE] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineActionStudentDisciplineIncidentBehaviorAssociation_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC,
        [DisciplineActionIdentifier] ASC,
        [DisciplineDate] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [DisciplineActionStudentDisciplineIncidentBehaviorAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [SchoolId] [INT] NOT NULL,
    [IncidentDate] [DATE] NOT NULL,
    [IncidentTime] [TIME](7) NULL,
    [IncidentLocationDescriptorId] [INT] NULL,
    [IncidentDescription] [NVARCHAR](1024) NULL,
    [ReporterDescriptionDescriptorId] [INT] NULL,
    [ReporterName] [NVARCHAR](75) NULL,
    [ReportedToLawEnforcement] [BIT] NULL,
    [CaseNumber] [NVARCHAR](20) NULL,
    [IncidentCost] [MONEY] NULL,
    [StaffUSI] [INT] NULL,
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
ALTER TABLE [edfi].[DisciplineIncident] ADD CONSTRAINT [DisciplineIncident_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[DisciplineIncident] ADD CONSTRAINT [DisciplineIncident_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[DisciplineIncident] ADD CONSTRAINT [DisciplineIncident_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[DisciplineIncidentBehavior] --
CREATE TABLE [edfi].[DisciplineIncidentBehavior] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [BehaviorDetailedDescription] [NVARCHAR](1024) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineIncidentBehavior_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineIncidentBehavior] ADD CONSTRAINT [DisciplineIncidentBehavior_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[DisciplineIncidentExternalParticipant] --
CREATE TABLE [edfi].[DisciplineIncidentExternalParticipant] (
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineIncidentExternalParticipant_PK] PRIMARY KEY CLUSTERED (
        [DisciplineIncidentParticipationCodeDescriptorId] ASC,
        [FirstName] ASC,
        [IncidentIdentifier] ASC,
        [LastSurname] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineIncidentExternalParticipant] ADD CONSTRAINT [DisciplineIncidentExternalParticipant_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [SchoolId] [INT] NOT NULL,
    [WeaponDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [DisciplineIncidentWeapon_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [WeaponDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[DisciplineIncidentWeapon] ADD CONSTRAINT [DisciplineIncidentWeapon_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [LearningResourceMetadataURI] [NVARCHAR](255) NULL,
    [ShortDescription] [NVARCHAR](75) NULL,
    [Description] [NVARCHAR](1024) NULL,
    [AdditionalAuthorsIndicator] [BIT] NULL,
    [Publisher] [NVARCHAR](50) NULL,
    [TimeRequired] [NVARCHAR](30) NULL,
    [InteractivityStyleDescriptorId] [INT] NULL,
    [ContentClassDescriptorId] [INT] NULL,
    [UseRightsURL] [NVARCHAR](255) NULL,
    [PublicationDate] [DATE] NULL,
    [PublicationYear] [SMALLINT] NULL,
    [Version] [NVARCHAR](10) NULL,
    [LearningStandardId] [NVARCHAR](60) NULL,
    [Cost] [MONEY] NULL,
    [CostRateDescriptorId] [INT] NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationContent_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContent] ADD CONSTRAINT [EducationContent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationContent] ADD CONSTRAINT [EducationContent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationContent] ADD CONSTRAINT [EducationContent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[EducationContentAppropriateGradeLevel] ADD CONSTRAINT [EducationContentAppropriateGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[EducationContentAppropriateSex] ADD CONSTRAINT [EducationContentAppropriateSex_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationContentAuthor] --
CREATE TABLE [edfi].[EducationContentAuthor] (
    [Author] [NVARCHAR](100) NOT NULL,
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationContentAuthor_PK] PRIMARY KEY CLUSTERED (
        [Author] ASC,
        [ContentIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationContentAuthor] ADD CONSTRAINT [EducationContentAuthor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[EducationContentDerivativeSourceEducationContent] ADD CONSTRAINT [EducationContentDerivativeSourceEducationContent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] ADD CONSTRAINT [EducationContentDerivativeSourceLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[EducationContentDerivativeSourceURI] ADD CONSTRAINT [EducationContentDerivativeSourceURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[EducationContentLanguage] ADD CONSTRAINT [EducationContentLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganization] --
CREATE TABLE [edfi].[EducationOrganization] (
    [EducationOrganizationId] [INT] NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [ShortNameOfInstitution] [NVARCHAR](75) NULL,
    [WebSite] [NVARCHAR](255) NULL,
    [OperationalStatusDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EducationOrganization_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganization] ADD CONSTRAINT [EducationOrganization_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganization] ADD CONSTRAINT [EducationOrganization_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganization] ADD CONSTRAINT [EducationOrganization_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationOrganizationAddress] --
CREATE TABLE [edfi].[EducationOrganizationAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
    CONSTRAINT [EducationOrganizationAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [EducationOrganizationId] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationAddress] ADD CONSTRAINT [EducationOrganizationAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationAddressPeriod] --
CREATE TABLE [edfi].[EducationOrganizationAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [City] ASC,
        [EducationOrganizationId] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationAddressPeriod] ADD CONSTRAINT [EducationOrganizationAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationCategory_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationCategoryDescriptorId] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationCategory] ADD CONSTRAINT [EducationOrganizationCategory_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [EducationOrganizationIdentificationSystemDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EducationOrganizationIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationIdentificationCode] ADD CONSTRAINT [EducationOrganizationIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[EducationOrganizationIdentificationSystemDescriptor] (
    [EducationOrganizationIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationOrganizationIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationOrganizationIndicator] --
CREATE TABLE [edfi].[EducationOrganizationIndicator] (
    [EducationOrganizationId] [INT] NOT NULL,
    [IndicatorDescriptorId] [INT] NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [IndicatorValue] [NVARCHAR](60) NULL,
    [IndicatorLevelDescriptorId] [INT] NULL,
    [IndicatorGroupDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationIndicator_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [IndicatorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationIndicator] ADD CONSTRAINT [EducationOrganizationIndicator_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationIndicatorPeriod] --
CREATE TABLE [edfi].[EducationOrganizationIndicatorPeriod] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [IndicatorDescriptorId] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationIndicatorPeriod_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [IndicatorDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationIndicatorPeriod] ADD CONSTRAINT [EducationOrganizationIndicatorPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationInstitutionTelephone] --
CREATE TABLE [edfi].[EducationOrganizationInstitutionTelephone] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InstitutionTelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [EducationOrganizationInstitutionTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InstitutionTelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationInstitutionTelephone] ADD CONSTRAINT [EducationOrganizationInstitutionTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationInternationalAddress] --
CREATE TABLE [edfi].[EducationOrganizationInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
    CONSTRAINT [EducationOrganizationInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] ADD CONSTRAINT [EducationOrganizationInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[EducationOrganizationInterventionPrescriptionAssociation] --
CREATE TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionEducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD CONSTRAINT [EducationOrganizationInterventionPrescriptionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD CONSTRAINT [EducationOrganizationInterventionPrescriptionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD CONSTRAINT [EducationOrganizationInterventionPrescriptionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationOrganizationNetwork] --
CREATE TABLE [edfi].[EducationOrganizationNetwork] (
    [EducationOrganizationNetworkId] [INT] NOT NULL,
    [NetworkPurposeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EducationOrganizationNetwork_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationNetworkId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[EducationOrganizationNetworkAssociation] --
CREATE TABLE [edfi].[EducationOrganizationNetworkAssociation] (
    [EducationOrganizationNetworkId] [INT] NOT NULL,
    [MemberEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD CONSTRAINT [EducationOrganizationNetworkAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD CONSTRAINT [EducationOrganizationNetworkAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD CONSTRAINT [EducationOrganizationNetworkAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[EducationOrganizationPeerAssociation] --
CREATE TABLE [edfi].[EducationOrganizationPeerAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [PeerEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD CONSTRAINT [EducationOrganizationPeerAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD CONSTRAINT [EducationOrganizationPeerAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD CONSTRAINT [EducationOrganizationPeerAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [EducationServiceCenterId] [INT] NOT NULL,
    [StateEducationAgencyId] [INT] NULL,
    CONSTRAINT [EducationServiceCenter_PK] PRIMARY KEY CLUSTERED (
        [EducationServiceCenterId] ASC
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

-- Table [edfi].[EmploymentStatusDescriptor] --
CREATE TABLE [edfi].[EmploymentStatusDescriptor] (
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EmploymentStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EmploymentStatusDescriptorId] ASC
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

-- Table [edfi].[FeederSchoolAssociation] --
CREATE TABLE [edfi].[FeederSchoolAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [FeederSchoolId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD CONSTRAINT [FeederSchoolAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD CONSTRAINT [FeederSchoolAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FeederSchoolAssociation] ADD CONSTRAINT [FeederSchoolAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[FunctionDimension] ADD CONSTRAINT [FunctionDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FunctionDimension] ADD CONSTRAINT [FunctionDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FunctionDimension] ADD CONSTRAINT [FunctionDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[FunctionDimensionReportingTag] ADD CONSTRAINT [FunctionDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[FundDimension] ADD CONSTRAINT [FundDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[FundDimension] ADD CONSTRAINT [FundDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[FundDimension] ADD CONSTRAINT [FundDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[FundDimensionReportingTag] ADD CONSTRAINT [FundDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GeneralStudentProgramAssociation] --
CREATE TABLE [edfi].[GeneralStudentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD CONSTRAINT [GeneralStudentProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD CONSTRAINT [GeneralStudentProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ADD CONSTRAINT [GeneralStudentProgramAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GeneralStudentProgramAssociationParticipationStatus] --
CREATE TABLE [edfi].[GeneralStudentProgramAssociationParticipationStatus] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ParticipationStatusDescriptorId] [INT] NOT NULL,
    [StatusBeginDate] [DATE] NULL,
    [StatusEndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GeneralStudentProgramAssociationParticipationStatus_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociationParticipationStatus] ADD CONSTRAINT [GeneralStudentProgramAssociationParticipationStatus_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] --
CREATE TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ParticipationStatusDescriptorId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StatusBeginDate] [DATE] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [StatusEndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GeneralStudentProgramAssociationProgramParticipationStatus_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ParticipationStatusDescriptorId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StatusBeginDate] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] ADD CONSTRAINT [GeneralStudentProgramAssociationProgramParticipationStatus_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[Grade] --
CREATE TABLE [edfi].[Grade] (
    [BeginDate] [DATE] NOT NULL,
    [GradeTypeDescriptorId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [NumericGradeEarned] [DECIMAL](9, 2) NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [PerformanceBaseConversionDescriptorId] [INT] NULL,
    [CurrentGradeIndicator] [BIT] NULL,
    [CurrentGradeAsOfDate] [DATE] NULL,
    [GradeEarnedDescription] [NVARCHAR](64) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Grade_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [GradeTypeDescriptorId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Grade] ADD CONSTRAINT [Grade_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Grade] ADD CONSTRAINT [Grade_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Grade] ADD CONSTRAINT [Grade_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GradebookEntry] --
CREATE TABLE [edfi].[GradebookEntry] (
    [GradebookEntryIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SourceSectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NULL,
    [LocalCourseCode] [NVARCHAR](60) NULL,
    [SessionName] [NVARCHAR](60) NULL,
    [SchoolId] [INT] NULL,
    [DateAssigned] [DATE] NOT NULL,
    [Title] [NVARCHAR](100) NOT NULL,
    [Description] [NVARCHAR](1024) NULL,
    [DueDate] [DATE] NULL,
    [DueTime] [TIME](7) NULL,
    [GradebookEntryTypeDescriptorId] [INT] NULL,
    [MaxPoints] [DECIMAL](9, 2) NULL,
    [GradingPeriodDescriptorId] [INT] NULL,
    [PeriodSequence] [INT] NULL,
    [SchoolYear] [SMALLINT] NULL,
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
ALTER TABLE [edfi].[GradebookEntry] ADD CONSTRAINT [GradebookEntry_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GradebookEntry] ADD CONSTRAINT [GradebookEntry_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GradebookEntry] ADD CONSTRAINT [GradebookEntry_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GradebookEntryLearningStandard] --
CREATE TABLE [edfi].[GradebookEntryLearningStandard] (
    [GradebookEntryIdentifier] [NVARCHAR](60) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GradebookEntryLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [GradebookEntryIdentifier] ASC,
        [LearningStandardId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GradebookEntryLearningStandard] ADD CONSTRAINT [GradebookEntryLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [NumericGradeEarned] [DECIMAL](9, 2) NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [PerformanceBaseConversionDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GradeLearningStandardGrade_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [GradeTypeDescriptorId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LearningStandardId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GradeLearningStandardGrade] ADD CONSTRAINT [GradeLearningStandardGrade_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [PeriodSequence] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NOT NULL,
    [TotalInstructionalDays] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [GradingPeriod_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC,
        [PeriodSequence] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GradingPeriod] ADD CONSTRAINT [GradingPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GradingPeriod] ADD CONSTRAINT [GradingPeriod_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GradingPeriod] ADD CONSTRAINT [GradingPeriod_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [IndividualPlan] [BIT] NULL,
    [TotalRequiredCredits] [DECIMAL](9, 3) NOT NULL,
    [TotalRequiredCreditTypeDescriptorId] [INT] NULL,
    [TotalRequiredCreditConversion] [DECIMAL](9, 2) NULL,
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
ALTER TABLE [edfi].[GraduationPlan] ADD CONSTRAINT [GraduationPlan_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[GraduationPlan] ADD CONSTRAINT [GraduationPlan_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[GraduationPlan] ADD CONSTRAINT [GraduationPlan_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[GraduationPlanCreditsByCourse] --
CREATE TABLE [edfi].[GraduationPlanCreditsByCourse] (
    [CourseSetName] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreditTypeDescriptorId] [INT] NULL,
    [CreditConversion] [DECIMAL](9, 2) NULL,
    [WhenTakenGradeLevelDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsByCourse_PK] PRIMARY KEY CLUSTERED (
        [CourseSetName] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] ADD CONSTRAINT [GraduationPlanCreditsByCourse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanCreditsByCourseCourse] --
CREATE TABLE [edfi].[GraduationPlanCreditsByCourseCourse] (
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [CourseSetName] [NVARCHAR](120) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsByCourseCourse_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [CourseSetName] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsByCourseCourse] ADD CONSTRAINT [GraduationPlanCreditsByCourseCourse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanCreditsByCreditCategory] --
CREATE TABLE [edfi].[GraduationPlanCreditsByCreditCategory] (
    [CreditCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreditTypeDescriptorId] [INT] NULL,
    [CreditConversion] [DECIMAL](9, 2) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsByCreditCategory_PK] PRIMARY KEY CLUSTERED (
        [CreditCategoryDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] ADD CONSTRAINT [GraduationPlanCreditsByCreditCategory_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanCreditsBySubject] --
CREATE TABLE [edfi].[GraduationPlanCreditsBySubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreditTypeDescriptorId] [INT] NULL,
    [CreditConversion] [DECIMAL](9, 2) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanCreditsBySubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] ADD CONSTRAINT [GraduationPlanCreditsBySubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanRequiredAssessment] --
CREATE TABLE [edfi].[GraduationPlanRequiredAssessment] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredAssessment_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanRequiredAssessment] ADD CONSTRAINT [GraduationPlanRequiredAssessment_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] ADD CONSTRAINT [GraduationPlanRequiredAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[GraduationPlanRequiredAssessmentScore] --
CREATE TABLE [edfi].[GraduationPlanRequiredAssessmentScore] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [GraduationSchoolYear] [SMALLINT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [GraduationPlanRequiredAssessmentScore_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [GraduationPlanTypeDescriptorId] ASC,
        [GraduationSchoolYear] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] ADD CONSTRAINT [GraduationPlanRequiredAssessmentScore_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [edfi].[IdentificationDocumentUseDescriptor] --
CREATE TABLE [edfi].[IdentificationDocumentUseDescriptor] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    CONSTRAINT [IdentificationDocumentUseDescriptor_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC
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
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [InterventionClassDescriptorId] [INT] NOT NULL,
    [DeliveryMethodDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [MinDosage] [INT] NULL,
    [MaxDosage] [INT] NULL,
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
ALTER TABLE [edfi].[Intervention] ADD CONSTRAINT [Intervention_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Intervention] ADD CONSTRAINT [Intervention_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Intervention] ADD CONSTRAINT [Intervention_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[InterventionAppropriateGradeLevel] --
CREATE TABLE [edfi].[InterventionAppropriateGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionAppropriateGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [InterventionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionAppropriateGradeLevel] ADD CONSTRAINT [InterventionAppropriateGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionAppropriateSex] --
CREATE TABLE [edfi].[InterventionAppropriateSex] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionAppropriateSex_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionAppropriateSex] ADD CONSTRAINT [InterventionAppropriateSex_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionDiagnosis_PK] PRIMARY KEY CLUSTERED (
        [DiagnosisDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionDiagnosis] ADD CONSTRAINT [InterventionDiagnosis_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionEducationContent] --
CREATE TABLE [edfi].[InterventionEducationContent] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionEducationContent_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionEducationContent] ADD CONSTRAINT [InterventionEducationContent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [InterventionPrescriptionEducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionInterventionPrescription_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [InterventionPrescriptionEducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionInterventionPrescription] ADD CONSTRAINT [InterventionInterventionPrescription_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionLearningResourceMetadataURI] --
CREATE TABLE [edfi].[InterventionLearningResourceMetadataURI] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [LearningResourceMetadataURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionLearningResourceMetadataURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [LearningResourceMetadataURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionLearningResourceMetadataURI] ADD CONSTRAINT [InterventionLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionMeetingTime] --
CREATE TABLE [edfi].[InterventionMeetingTime] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EndTime] [TIME](7) NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [StartTime] [TIME](7) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionMeetingTime_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EndTime] ASC,
        [InterventionIdentificationCode] ASC,
        [StartTime] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionMeetingTime] ADD CONSTRAINT [InterventionMeetingTime_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPopulationServed] --
CREATE TABLE [edfi].[InterventionPopulationServed] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPopulationServed_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPopulationServed] ADD CONSTRAINT [InterventionPopulationServed_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescription] --
CREATE TABLE [edfi].[InterventionPrescription] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [InterventionClassDescriptorId] [INT] NOT NULL,
    [DeliveryMethodDescriptorId] [INT] NOT NULL,
    [MinDosage] [INT] NULL,
    [MaxDosage] [INT] NULL,
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
ALTER TABLE [edfi].[InterventionPrescription] ADD CONSTRAINT [InterventionPrescription_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[InterventionPrescription] ADD CONSTRAINT [InterventionPrescription_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[InterventionPrescription] ADD CONSTRAINT [InterventionPrescription_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[InterventionPrescriptionAppropriateGradeLevel] --
CREATE TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionAppropriateGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] ADD CONSTRAINT [InterventionPrescriptionAppropriateGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionAppropriateSex] --
CREATE TABLE [edfi].[InterventionPrescriptionAppropriateSex] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionAppropriateSex_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionAppropriateSex] ADD CONSTRAINT [InterventionPrescriptionAppropriateSex_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionDiagnosis] --
CREATE TABLE [edfi].[InterventionPrescriptionDiagnosis] (
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionDiagnosis_PK] PRIMARY KEY CLUSTERED (
        [DiagnosisDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionDiagnosis] ADD CONSTRAINT [InterventionPrescriptionDiagnosis_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionEducationContent] --
CREATE TABLE [edfi].[InterventionPrescriptionEducationContent] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionEducationContent_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionEducationContent] ADD CONSTRAINT [InterventionPrescriptionEducationContent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionLearningResourceMetadataURI] --
CREATE TABLE [edfi].[InterventionPrescriptionLearningResourceMetadataURI] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [LearningResourceMetadataURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionLearningResourceMetadataURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [LearningResourceMetadataURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionLearningResourceMetadataURI] ADD CONSTRAINT [InterventionPrescriptionLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionPopulationServed] --
CREATE TABLE [edfi].[InterventionPrescriptionPopulationServed] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionPopulationServed_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionPopulationServed] ADD CONSTRAINT [InterventionPrescriptionPopulationServed_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionPrescriptionURI] --
CREATE TABLE [edfi].[InterventionPrescriptionURI] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [URI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionPrescriptionURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionPrescriptionIdentificationCode] ASC,
        [URI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionPrescriptionURI] ADD CONSTRAINT [InterventionPrescriptionURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStaff] --
CREATE TABLE [edfi].[InterventionStaff] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStaff_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStaff] ADD CONSTRAINT [InterventionStaff_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudy] --
CREATE TABLE [edfi].[InterventionStudy] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [InterventionPrescriptionEducationOrganizationId] [INT] NOT NULL,
    [InterventionPrescriptionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [Participants] [INT] NOT NULL,
    [DeliveryMethodDescriptorId] [INT] NOT NULL,
    [InterventionClassDescriptorId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[InterventionStudy] ADD CONSTRAINT [InterventionStudy_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[InterventionStudy] ADD CONSTRAINT [InterventionStudy_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[InterventionStudy] ADD CONSTRAINT [InterventionStudy_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[InterventionStudyAppropriateGradeLevel] --
CREATE TABLE [edfi].[InterventionStudyAppropriateGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyAppropriateGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [InterventionStudyIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyAppropriateGradeLevel] ADD CONSTRAINT [InterventionStudyAppropriateGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyAppropriateSex] --
CREATE TABLE [edfi].[InterventionStudyAppropriateSex] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyAppropriateSex_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [SexDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyAppropriateSex] ADD CONSTRAINT [InterventionStudyAppropriateSex_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyEducationContent] --
CREATE TABLE [edfi].[InterventionStudyEducationContent] (
    [ContentIdentifier] [NVARCHAR](225) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyEducationContent_PK] PRIMARY KEY CLUSTERED (
        [ContentIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyEducationContent] ADD CONSTRAINT [InterventionStudyEducationContent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyInterventionEffectiveness] --
CREATE TABLE [edfi].[InterventionStudyInterventionEffectiveness] (
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [ImprovementIndex] [INT] NULL,
    [InterventionEffectivenessRatingDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyInterventionEffectiveness_PK] PRIMARY KEY CLUSTERED (
        [DiagnosisDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] ADD CONSTRAINT [InterventionStudyInterventionEffectiveness_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyLearningResourceMetadataURI] --
CREATE TABLE [edfi].[InterventionStudyLearningResourceMetadataURI] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [LearningResourceMetadataURI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyLearningResourceMetadataURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [LearningResourceMetadataURI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyLearningResourceMetadataURI] ADD CONSTRAINT [InterventionStudyLearningResourceMetadataURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyPopulationServed] --
CREATE TABLE [edfi].[InterventionStudyPopulationServed] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyPopulationServed_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyPopulationServed] ADD CONSTRAINT [InterventionStudyPopulationServed_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyStateAbbreviation] --
CREATE TABLE [edfi].[InterventionStudyStateAbbreviation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyStateAbbreviation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [StateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyStateAbbreviation] ADD CONSTRAINT [InterventionStudyStateAbbreviation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionStudyURI] --
CREATE TABLE [edfi].[InterventionStudyURI] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionStudyIdentificationCode] [NVARCHAR](60) NOT NULL,
    [URI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionStudyURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionStudyIdentificationCode] ASC,
        [URI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionStudyURI] ADD CONSTRAINT [InterventionStudyURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[InterventionURI] --
CREATE TABLE [edfi].[InterventionURI] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [URI] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [InterventionURI_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [InterventionIdentificationCode] ASC,
        [URI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[InterventionURI] ADD CONSTRAINT [InterventionURI_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [edfi].[LearningObjective] --
CREATE TABLE [edfi].[LearningObjective] (
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [Description] [NVARCHAR](1024) NULL,
    [Nomenclature] [NVARCHAR](100) NULL,
    [SuccessCriteria] [NVARCHAR](150) NULL,
    [ParentLearningObjectiveId] [NVARCHAR](60) NULL,
    [ParentNamespace] [NVARCHAR](255) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LearningObjective_PK] PRIMARY KEY CLUSTERED (
        [LearningObjectiveId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningObjective] ADD CONSTRAINT [LearningObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LearningObjective] ADD CONSTRAINT [LearningObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LearningObjective] ADD CONSTRAINT [LearningObjective_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LearningObjectiveAcademicSubject] --
CREATE TABLE [edfi].[LearningObjectiveAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningObjectiveAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningObjectiveAcademicSubject] ADD CONSTRAINT [LearningObjectiveAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningObjectiveContentStandard] --
CREATE TABLE [edfi].[LearningObjectiveContentStandard] (
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [Title] [NVARCHAR](75) NOT NULL,
    [Version] [NVARCHAR](50) NULL,
    [URI] [NVARCHAR](255) NULL,
    [PublicationDate] [DATE] NULL,
    [PublicationYear] [SMALLINT] NULL,
    [PublicationStatusDescriptorId] [INT] NULL,
    [MandatingEducationOrganizationId] [INT] NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningObjectiveContentStandard_PK] PRIMARY KEY CLUSTERED (
        [LearningObjectiveId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningObjectiveContentStandard] ADD CONSTRAINT [LearningObjectiveContentStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningObjectiveContentStandardAuthor] --
CREATE TABLE [edfi].[LearningObjectiveContentStandardAuthor] (
    [Author] [NVARCHAR](100) NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningObjectiveContentStandardAuthor_PK] PRIMARY KEY CLUSTERED (
        [Author] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningObjectiveContentStandardAuthor] ADD CONSTRAINT [LearningObjectiveContentStandardAuthor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningObjectiveGradeLevel] --
CREATE TABLE [edfi].[LearningObjectiveGradeLevel] (
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningObjectiveGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [GradeLevelDescriptorId] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningObjectiveGradeLevel] ADD CONSTRAINT [LearningObjectiveGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningObjectiveLearningStandard] --
CREATE TABLE [edfi].[LearningObjectiveLearningStandard] (
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningObjectiveLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [LearningObjectiveId] ASC,
        [LearningStandardId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningObjectiveLearningStandard] ADD CONSTRAINT [LearningObjectiveLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandard] --
CREATE TABLE [edfi].[LearningStandard] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [Description] [NVARCHAR](1024) NOT NULL,
    [LearningStandardItemCode] [NVARCHAR](60) NULL,
    [URI] [NVARCHAR](255) NULL,
    [CourseTitle] [NVARCHAR](60) NULL,
    [SuccessCriteria] [NVARCHAR](150) NULL,
    [ParentLearningStandardId] [NVARCHAR](60) NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [LearningStandardCategoryDescriptorId] [INT] NULL,
    [LearningStandardScopeDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [LearningStandard_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandard] ADD CONSTRAINT [LearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LearningStandard] ADD CONSTRAINT [LearningStandard_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LearningStandard] ADD CONSTRAINT [LearningStandard_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LearningStandardAcademicSubject] --
CREATE TABLE [edfi].[LearningStandardAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardAcademicSubject] ADD CONSTRAINT [LearningStandardAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [Title] [NVARCHAR](75) NOT NULL,
    [Version] [NVARCHAR](50) NULL,
    [URI] [NVARCHAR](255) NULL,
    [PublicationDate] [DATE] NULL,
    [PublicationYear] [SMALLINT] NULL,
    [PublicationStatusDescriptorId] [INT] NULL,
    [MandatingEducationOrganizationId] [INT] NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardContentStandard_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardContentStandard] ADD CONSTRAINT [LearningStandardContentStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardContentStandardAuthor] --
CREATE TABLE [edfi].[LearningStandardContentStandardAuthor] (
    [Author] [NVARCHAR](100) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardContentStandardAuthor_PK] PRIMARY KEY CLUSTERED (
        [Author] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardContentStandardAuthor] ADD CONSTRAINT [LearningStandardContentStandardAuthor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardEquivalenceAssociation] --
CREATE TABLE [edfi].[LearningStandardEquivalenceAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SourceLearningStandardId] [NVARCHAR](60) NOT NULL,
    [TargetLearningStandardId] [NVARCHAR](60) NOT NULL,
    [EffectiveDate] [DATE] NULL,
    [LearningStandardEquivalenceStrengthDescriptorId] [INT] NULL,
    [LearningStandardEquivalenceStrengthDescription] [NVARCHAR](255) NULL,
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
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD CONSTRAINT [LearningStandardEquivalenceAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD CONSTRAINT [LearningStandardEquivalenceAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ADD CONSTRAINT [LearningStandardEquivalenceAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [GradeLevelDescriptorId] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardGradeLevel] ADD CONSTRAINT [LearningStandardGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardIdentificationCode] --
CREATE TABLE [edfi].[LearningStandardIdentificationCode] (
    [ContentStandardName] [NVARCHAR](65) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [ContentStandardName] ASC,
        [IdentificationCode] ASC,
        [LearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardIdentificationCode] ADD CONSTRAINT [LearningStandardIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardPrerequisiteLearningStandard] --
CREATE TABLE [edfi].[LearningStandardPrerequisiteLearningStandard] (
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [PrerequisiteLearningStandardId] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LearningStandardPrerequisiteLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardId] ASC,
        [PrerequisiteLearningStandardId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LearningStandardPrerequisiteLearningStandard] ADD CONSTRAINT [LearningStandardPrerequisiteLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LearningStandardScopeDescriptor] --
CREATE TABLE [edfi].[LearningStandardScopeDescriptor] (
    [LearningStandardScopeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LearningStandardScopeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LearningStandardScopeDescriptorId] ASC
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
    [EducationOrganizationId] [INT] NOT NULL,
    [FiscalYear] [INT] NOT NULL,
    [AccountName] [NVARCHAR](100) NULL,
    [ChartOfAccountIdentifier] [NVARCHAR](50) NOT NULL,
    [ChartOfAccountEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalAccount] ADD CONSTRAINT [LocalAccount_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalAccount] ADD CONSTRAINT [LocalAccount_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalAccount] ADD CONSTRAINT [LocalAccount_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalAccountReportingTag] --
CREATE TABLE [edfi].[LocalAccountReportingTag] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalAccountReportingTag] ADD CONSTRAINT [LocalAccountReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LocalActual] --
CREATE TABLE [edfi].[LocalActual] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalActual] ADD CONSTRAINT [LocalActual_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalActual] ADD CONSTRAINT [LocalActual_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalActual] ADD CONSTRAINT [LocalActual_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalBudget] --
CREATE TABLE [edfi].[LocalBudget] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalBudget] ADD CONSTRAINT [LocalBudget_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalBudget] ADD CONSTRAINT [LocalBudget_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalBudget] ADD CONSTRAINT [LocalBudget_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalContractedStaff] --
CREATE TABLE [edfi].[LocalContractedStaff] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalContractedStaff] ADD CONSTRAINT [LocalContractedStaff_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalContractedStaff] ADD CONSTRAINT [LocalContractedStaff_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalContractedStaff] ADD CONSTRAINT [LocalContractedStaff_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [LocalEducationAgencyId] [INT] NOT NULL,
    [LocalEducationAgencyCategoryDescriptorId] [INT] NOT NULL,
    [CharterStatusDescriptorId] [INT] NULL,
    [ParentLocalEducationAgencyId] [INT] NULL,
    [EducationServiceCenterId] [INT] NULL,
    [StateEducationAgencyId] [INT] NULL,
    CONSTRAINT [LocalEducationAgency_PK] PRIMARY KEY CLUSTERED (
        [LocalEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[LocalEducationAgencyAccountability] --
CREATE TABLE [edfi].[LocalEducationAgencyAccountability] (
    [LocalEducationAgencyId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalEducationAgencyAccountability] ADD CONSTRAINT [LocalEducationAgencyAccountability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [FiscalYear] [INT] NOT NULL,
    [LocalEducationAgencyId] [INT] NOT NULL,
    [InnovativeDollarsSpent] [MONEY] NULL,
    [InnovativeDollarsSpentStrategicPriorities] [MONEY] NULL,
    [InnovativeProgramsFundsReceived] [MONEY] NULL,
    [SchoolImprovementAllocation] [MONEY] NULL,
    [SchoolImprovementReservedFundsPercentage] [DECIMAL](5, 4) NULL,
    [SupplementalEducationalServicesFundsSpent] [MONEY] NULL,
    [SupplementalEducationalServicesPerPupilExpenditure] [MONEY] NULL,
    [StateAssessmentAdministrationFunding] [DECIMAL](5, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [LocalEducationAgencyFederalFunds_PK] PRIMARY KEY CLUSTERED (
        [FiscalYear] ASC,
        [LocalEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[LocalEducationAgencyFederalFunds] ADD CONSTRAINT [LocalEducationAgencyFederalFunds_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[LocalEncumbrance] --
CREATE TABLE [edfi].[LocalEncumbrance] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalEncumbrance] ADD CONSTRAINT [LocalEncumbrance_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalEncumbrance] ADD CONSTRAINT [LocalEncumbrance_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalEncumbrance] ADD CONSTRAINT [LocalEncumbrance_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[LocalPayroll] --
CREATE TABLE [edfi].[LocalPayroll] (
    [AccountIdentifier] [NVARCHAR](50) NOT NULL,
    [AsOfDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[LocalPayroll] ADD CONSTRAINT [LocalPayroll_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[LocalPayroll] ADD CONSTRAINT [LocalPayroll_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[LocalPayroll] ADD CONSTRAINT [LocalPayroll_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[Location] --
CREATE TABLE [edfi].[Location] (
    [ClassroomIdentificationCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[Location] ADD CONSTRAINT [Location_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Location] ADD CONSTRAINT [Location_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Location] ADD CONSTRAINT [Location_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[ObjectDimension] ADD CONSTRAINT [ObjectDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ObjectDimension] ADD CONSTRAINT [ObjectDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ObjectDimension] ADD CONSTRAINT [ObjectDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[ObjectDimensionReportingTag] ADD CONSTRAINT [ObjectDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessment] --
CREATE TABLE [edfi].[ObjectiveAssessment] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [MaxRawScore] [DECIMAL](15, 5) NULL,
    [PercentOfAssessment] [DECIMAL](5, 4) NULL,
    [Nomenclature] [NVARCHAR](100) NULL,
    [Description] [NVARCHAR](1024) NULL,
    [ParentIdentificationCode] [NVARCHAR](60) NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[ObjectiveAssessment] ADD CONSTRAINT [ObjectiveAssessment_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ObjectiveAssessment] ADD CONSTRAINT [ObjectiveAssessment_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ObjectiveAssessment] ADD CONSTRAINT [ObjectiveAssessment_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ObjectiveAssessmentAssessmentItem] --
CREATE TABLE [edfi].[ObjectiveAssessmentAssessmentItem] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentItemIdentificationCode] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentAssessmentItem_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentItemIdentificationCode] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentAssessmentItem] ADD CONSTRAINT [ObjectiveAssessmentAssessmentItem_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessmentLearningStandard] --
CREATE TABLE [edfi].[ObjectiveAssessmentLearningStandard] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [LearningStandardId] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentLearningStandard] ADD CONSTRAINT [ObjectiveAssessmentLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [PerformanceLevelDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] ADD CONSTRAINT [ObjectiveAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ObjectiveAssessmentScore] --
CREATE TABLE [edfi].[ObjectiveAssessmentScore] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [MinimumScore] [NVARCHAR](35) NULL,
    [MaximumScore] [NVARCHAR](35) NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ObjectiveAssessmentScore_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ObjectiveAssessmentScore] ADD CONSTRAINT [ObjectiveAssessmentScore_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[OldEthnicityDescriptor] --
CREATE TABLE [edfi].[OldEthnicityDescriptor] (
    [OldEthnicityDescriptorId] [INT] NOT NULL,
    CONSTRAINT [OldEthnicityDescriptor_PK] PRIMARY KEY CLUSTERED (
        [OldEthnicityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[OpenStaffPosition] --
CREATE TABLE [edfi].[OpenStaffPosition] (
    [EducationOrganizationId] [INT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [StaffClassificationDescriptorId] [INT] NOT NULL,
    [PositionTitle] [NVARCHAR](100) NULL,
    [ProgramAssignmentDescriptorId] [INT] NULL,
    [DatePosted] [DATE] NOT NULL,
    [DatePostingRemoved] [DATE] NULL,
    [PostingResultDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[OpenStaffPosition] ADD CONSTRAINT [OpenStaffPosition_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[OpenStaffPosition] ADD CONSTRAINT [OpenStaffPosition_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[OpenStaffPosition] ADD CONSTRAINT [OpenStaffPosition_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[OpenStaffPositionAcademicSubject] --
CREATE TABLE [edfi].[OpenStaffPositionAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [OpenStaffPositionAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[OpenStaffPositionAcademicSubject] ADD CONSTRAINT [OpenStaffPositionAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[OpenStaffPositionInstructionalGradeLevel] --
CREATE TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [OpenStaffPositionInstructionalGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] ADD CONSTRAINT [OpenStaffPositionInstructionalGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[OperationalUnitDimension] ADD CONSTRAINT [OperationalUnitDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[OperationalUnitDimension] ADD CONSTRAINT [OperationalUnitDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[OperationalUnitDimension] ADD CONSTRAINT [OperationalUnitDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[OperationalUnitDimensionReportingTag] ADD CONSTRAINT [OperationalUnitDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[OrganizationDepartment] --
CREATE TABLE [edfi].[OrganizationDepartment] (
    [OrganizationDepartmentId] [INT] NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [ParentEducationOrganizationId] [INT] NULL,
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

-- Table [edfi].[Parent] --
CREATE TABLE [edfi].[Parent] (
    [ParentUSI] [INT] IDENTITY(1,1) NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [SexDescriptorId] [INT] NULL,
    [LoginId] [NVARCHAR](60) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [HighestCompletedLevelOfEducationDescriptorId] [INT] NULL,
    [ParentUniqueId] [NVARCHAR](32) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Parent_PK] PRIMARY KEY CLUSTERED (
        [ParentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Parent_UI_ParentUniqueId] ON [edfi].[Parent] (
    [ParentUniqueId] ASC
) INCLUDE (ParentUSI) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [edfi].[Parent] ADD CONSTRAINT [Parent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Parent] ADD CONSTRAINT [Parent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Parent] ADD CONSTRAINT [Parent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ParentAddress] --
CREATE TABLE [edfi].[ParentAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [ParentUSI] [INT] NOT NULL,
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
    CONSTRAINT [ParentAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [ParentUSI] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentAddress] ADD CONSTRAINT [ParentAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentAddressPeriod] --
CREATE TABLE [edfi].[ParentAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [ParentUSI] [INT] NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ParentAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [City] ASC,
        [ParentUSI] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentAddressPeriod] ADD CONSTRAINT [ParentAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentElectronicMail] --
CREATE TABLE [edfi].[ParentElectronicMail] (
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [ParentUSI] [INT] NOT NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ParentElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC,
        [ParentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentElectronicMail] ADD CONSTRAINT [ParentElectronicMail_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentInternationalAddress] --
CREATE TABLE [edfi].[ParentInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [ParentUSI] [INT] NOT NULL,
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
    CONSTRAINT [ParentInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [ParentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentInternationalAddress] ADD CONSTRAINT [ParentInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentLanguage] --
CREATE TABLE [edfi].[ParentLanguage] (
    [LanguageDescriptorId] [INT] NOT NULL,
    [ParentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ParentLanguage_PK] PRIMARY KEY CLUSTERED (
        [LanguageDescriptorId] ASC,
        [ParentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentLanguage] ADD CONSTRAINT [ParentLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentLanguageUse] --
CREATE TABLE [edfi].[ParentLanguageUse] (
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [ParentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ParentLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC,
        [ParentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentLanguageUse] ADD CONSTRAINT [ParentLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentOtherName] --
CREATE TABLE [edfi].[ParentOtherName] (
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [ParentUSI] [INT] NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ParentOtherName_PK] PRIMARY KEY CLUSTERED (
        [OtherNameTypeDescriptorId] ASC,
        [ParentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentOtherName] ADD CONSTRAINT [ParentOtherName_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentPersonalIdentificationDocument] --
CREATE TABLE [edfi].[ParentPersonalIdentificationDocument] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [ParentUSI] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ParentPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC,
        [ParentUSI] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentPersonalIdentificationDocument] ADD CONSTRAINT [ParentPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ParentTelephone] --
CREATE TABLE [edfi].[ParentTelephone] (
    [ParentUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ParentTelephone_PK] PRIMARY KEY CLUSTERED (
        [ParentUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ParentTelephone] ADD CONSTRAINT [ParentTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [edfi].[PerformanceBaseConversionDescriptor] --
CREATE TABLE [edfi].[PerformanceBaseConversionDescriptor] (
    [PerformanceBaseConversionDescriptorId] [INT] NOT NULL,
    CONSTRAINT [PerformanceBaseConversionDescriptor_PK] PRIMARY KEY CLUSTERED (
        [PerformanceBaseConversionDescriptorId] ASC
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
ALTER TABLE [edfi].[Person] ADD CONSTRAINT [Person_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Person] ADD CONSTRAINT [Person_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Person] ADD CONSTRAINT [Person_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [PostSecondaryInstitutionId] [INT] NULL,
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
ALTER TABLE [edfi].[PostSecondaryEvent] ADD CONSTRAINT [PostSecondaryEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[PostSecondaryEvent] ADD CONSTRAINT [PostSecondaryEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[PostSecondaryEvent] ADD CONSTRAINT [PostSecondaryEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [PostSecondaryInstitutionId] [INT] NOT NULL,
    [PostSecondaryInstitutionLevelDescriptorId] [INT] NULL,
    [AdministrativeFundingControlDescriptorId] [INT] NULL,
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
    [MediumOfInstructionDescriptorId] [INT] NOT NULL,
    [PostSecondaryInstitutionId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [PostSecondaryInstitutionMediumOfInstruction_PK] PRIMARY KEY CLUSTERED (
        [MediumOfInstructionDescriptorId] ASC,
        [PostSecondaryInstitutionId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[PostSecondaryInstitutionMediumOfInstruction] ADD CONSTRAINT [PostSecondaryInstitutionMediumOfInstruction_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[Program] ADD CONSTRAINT [Program_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Program] ADD CONSTRAINT [Program_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Program] ADD CONSTRAINT [Program_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramCharacteristicDescriptorId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramCharacteristicDescriptorId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramCharacteristic] ADD CONSTRAINT [ProgramCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[ProgramDimension] ADD CONSTRAINT [ProgramDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProgramDimension] ADD CONSTRAINT [ProgramDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProgramDimension] ADD CONSTRAINT [ProgramDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[ProgramDimensionReportingTag] ADD CONSTRAINT [ProgramDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramLearningObjective] --
CREATE TABLE [edfi].[ProgramLearningObjective] (
    [EducationOrganizationId] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramLearningObjective_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramLearningObjective] ADD CONSTRAINT [ProgramLearningObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramLearningStandard] --
CREATE TABLE [edfi].[ProgramLearningStandard] (
    [EducationOrganizationId] [INT] NOT NULL,
    [LearningStandardId] [NVARCHAR](60) NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramLearningStandard_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [LearningStandardId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramLearningStandard] ADD CONSTRAINT [ProgramLearningStandard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramService] --
CREATE TABLE [edfi].[ProgramService] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ServiceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramService_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [ServiceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramService] ADD CONSTRAINT [ProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ProgramSponsor] --
CREATE TABLE [edfi].[ProgramSponsor] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramSponsorDescriptorId] [INT] NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProgramSponsor_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramSponsorDescriptorId] ASC,
        [ProgramTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ProgramSponsor] ADD CONSTRAINT [ProgramSponsor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[ProjectDimension] ADD CONSTRAINT [ProjectDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ProjectDimension] ADD CONSTRAINT [ProjectDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ProjectDimension] ADD CONSTRAINT [ProjectDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[ProjectDimensionReportingTag] ADD CONSTRAINT [ProjectDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [GPAGivenGradingPeriod] [DECIMAL](18, 4) NULL,
    [GPACumulative] [DECIMAL](18, 4) NULL,
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
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCard] ADD CONSTRAINT [ReportCard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[ReportCard] ADD CONSTRAINT [ReportCard_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[ReportCard] ADD CONSTRAINT [ReportCard_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[ReportCardGrade] --
CREATE TABLE [edfi].[ReportCardGrade] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeTypeDescriptorId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ReportCardGrade_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [GradeTypeDescriptorId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCardGrade] ADD CONSTRAINT [ReportCardGrade_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ReportCardGradePointAverage] --
CREATE TABLE [edfi].[ReportCardGradePointAverage] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IsCumulative] [BIT] NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ReportCardGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradePointAverageTypeDescriptorId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCardGradePointAverage] ADD CONSTRAINT [ReportCardGradePointAverage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ReportCardStudentCompetencyObjective] --
CREATE TABLE [edfi].[ReportCardStudentCompetencyObjective] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveEducationOrganizationId] [INT] NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ReportCardStudentCompetencyObjective_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [Objective] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCardStudentCompetencyObjective] ADD CONSTRAINT [ReportCardStudentCompetencyObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[ReportCardStudentLearningObjective] --
CREATE TABLE [edfi].[ReportCardStudentLearningObjective] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ReportCardStudentLearningObjective_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[ReportCardStudentLearningObjective] ADD CONSTRAINT [ReportCardStudentLearningObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[RestraintEvent] ADD CONSTRAINT [RestraintEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[RestraintEvent] ADD CONSTRAINT [RestraintEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[RestraintEvent] ADD CONSTRAINT [RestraintEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[RestraintEventProgram] --
CREATE TABLE [edfi].[RestraintEventProgram] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [RestraintEventIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RestraintEventProgram_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [RestraintEventIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RestraintEventProgram] ADD CONSTRAINT [RestraintEventProgram_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[RestraintEventReason] --
CREATE TABLE [edfi].[RestraintEventReason] (
    [RestraintEventIdentifier] [NVARCHAR](36) NOT NULL,
    [RestraintEventReasonDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [RestraintEventReason_PK] PRIMARY KEY CLUSTERED (
        [RestraintEventIdentifier] ASC,
        [RestraintEventReasonDescriptorId] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[RestraintEventReason] ADD CONSTRAINT [RestraintEventReason_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [edfi].[School] --
CREATE TABLE [edfi].[School] (
    [SchoolId] [INT] NOT NULL,
    [SchoolTypeDescriptorId] [INT] NULL,
    [CharterStatusDescriptorId] [INT] NULL,
    [TitleIPartASchoolDesignationDescriptorId] [INT] NULL,
    [MagnetSpecialProgramEmphasisSchoolDescriptorId] [INT] NULL,
    [AdministrativeFundingControlDescriptorId] [INT] NULL,
    [InternetAccessDescriptorId] [INT] NULL,
    [LocalEducationAgencyId] [INT] NULL,
    [CharterApprovalAgencyTypeDescriptorId] [INT] NULL,
    [CharterApprovalSchoolYear] [SMALLINT] NULL,
    CONSTRAINT [School_PK] PRIMARY KEY CLUSTERED (
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[SchoolCategory] --
CREATE TABLE [edfi].[SchoolCategory] (
    [SchoolCategoryDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SchoolCategory_PK] PRIMARY KEY CLUSTERED (
        [SchoolCategoryDescriptorId] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SchoolCategory] ADD CONSTRAINT [SchoolCategory_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SchoolGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [GradeLevelDescriptorId] ASC,
        [SchoolId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SchoolGradeLevel] ADD CONSTRAINT [SchoolGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[SchoolYearType] ADD CONSTRAINT [SchoolYearType_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SchoolYearType] ADD CONSTRAINT [SchoolYearType_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SchoolYearType] ADD CONSTRAINT [SchoolYearType_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[Section] --
CREATE TABLE [edfi].[Section] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [SequenceOfCourse] [INT] NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [MediumOfInstructionDescriptorId] [INT] NULL,
    [PopulationServedDescriptorId] [INT] NULL,
    [AvailableCredits] [DECIMAL](9, 3) NULL,
    [AvailableCreditTypeDescriptorId] [INT] NULL,
    [AvailableCreditConversion] [DECIMAL](9, 2) NULL,
    [InstructionLanguageDescriptorId] [INT] NULL,
    [LocationSchoolId] [INT] NULL,
    [LocationClassroomIdentificationCode] [NVARCHAR](60) NULL,
    [OfficialAttendancePeriod] [BIT] NULL,
    [SectionName] [NVARCHAR](100) NULL,
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
ALTER TABLE [edfi].[Section] ADD CONSTRAINT [Section_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Section] ADD CONSTRAINT [Section_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Section] ADD CONSTRAINT [Section_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SectionAttendanceTakenEvent] --
CREATE TABLE [edfi].[SectionAttendanceTakenEvent] (
    [CalendarCode] [NVARCHAR](60) NOT NULL,
    [Date] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD CONSTRAINT [SectionAttendanceTakenEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD CONSTRAINT [SectionAttendanceTakenEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD CONSTRAINT [SectionAttendanceTakenEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SectionCharacteristic] --
CREATE TABLE [edfi].[SectionCharacteristic] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionCharacteristicDescriptorId] [INT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionCharacteristicDescriptorId] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionCharacteristic] ADD CONSTRAINT [SectionCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionClassPeriod_PK] PRIMARY KEY CLUSTERED (
        [ClassPeriodName] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionClassPeriod] ADD CONSTRAINT [SectionClassPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionCourseLevelCharacteristic] --
CREATE TABLE [edfi].[SectionCourseLevelCharacteristic] (
    [CourseLevelCharacteristicDescriptorId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionCourseLevelCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [CourseLevelCharacteristicDescriptorId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionCourseLevelCharacteristic] ADD CONSTRAINT [SectionCourseLevelCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionOfferedGradeLevel] --
CREATE TABLE [edfi].[SectionOfferedGradeLevel] (
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionOfferedGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [GradeLevelDescriptorId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionOfferedGradeLevel] ADD CONSTRAINT [SectionOfferedGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SectionProgram] --
CREATE TABLE [edfi].[SectionProgram] (
    [EducationOrganizationId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SectionProgram_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [LocalCourseCode] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SectionProgram] ADD CONSTRAINT [SectionProgram_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[Session] ADD CONSTRAINT [Session_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Session] ADD CONSTRAINT [Session_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Session] ADD CONSTRAINT [Session_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SessionAcademicWeek] --
CREATE TABLE [edfi].[SessionAcademicWeek] (
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SessionAcademicWeek] ADD CONSTRAINT [SessionAcademicWeek_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SessionGradingPeriod] --
CREATE TABLE [edfi].[SessionGradingPeriod] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [PeriodSequence] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SessionGradingPeriod_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC,
        [PeriodSequence] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SessionGradingPeriod] ADD CONSTRAINT [SessionGradingPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[SourceDimension] ADD CONSTRAINT [SourceDimension_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SourceDimension] ADD CONSTRAINT [SourceDimension_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SourceDimension] ADD CONSTRAINT [SourceDimension_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[SourceDimensionReportingTag] ADD CONSTRAINT [SourceDimensionReportingTag_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SourceSystemDescriptor] --
CREATE TABLE [edfi].[SourceSystemDescriptor] (
    [SourceSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SourceSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SourceSystemDescriptorId] ASC
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
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [SexDescriptorId] [INT] NULL,
    [BirthDate] [DATE] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [OldEthnicityDescriptorId] [INT] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [HighestCompletedLevelOfEducationDescriptorId] [INT] NULL,
    [YearsOfPriorProfessionalExperience] [DECIMAL](5, 2) NULL,
    [YearsOfPriorTeachingExperience] [DECIMAL](5, 2) NULL,
    [LoginId] [NVARCHAR](60) NULL,
    [HighlyQualifiedTeacher] [BIT] NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [StaffUniqueId] [NVARCHAR](32) NOT NULL,
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
ALTER TABLE [edfi].[Staff] ADD CONSTRAINT [Staff_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Staff] ADD CONSTRAINT [Staff_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Staff] ADD CONSTRAINT [Staff_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD CONSTRAINT [StaffAbsenceEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD CONSTRAINT [StaffAbsenceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffAbsenceEvent] ADD CONSTRAINT [StaffAbsenceEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffAddress] --
CREATE TABLE [edfi].[StaffAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
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
    CONSTRAINT [StaffAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StaffUSI] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffAddress] ADD CONSTRAINT [StaffAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffAddressPeriod] --
CREATE TABLE [edfi].[StaffAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StaffUSI] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffAddressPeriod] ADD CONSTRAINT [StaffAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffAncestryEthnicOrigin] --
CREATE TABLE [edfi].[StaffAncestryEthnicOrigin] (
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffAncestryEthnicOrigin_PK] PRIMARY KEY CLUSTERED (
        [AncestryEthnicOriginDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffAncestryEthnicOrigin] ADD CONSTRAINT [StaffAncestryEthnicOrigin_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StaffCohortAssociation] ADD CONSTRAINT [StaffCohortAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffCohortAssociation] ADD CONSTRAINT [StaffCohortAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffCohortAssociation] ADD CONSTRAINT [StaffCohortAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffCredential] --
CREATE TABLE [edfi].[StaffCredential] (
    [CredentialIdentifier] [NVARCHAR](60) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffCredential_PK] PRIMARY KEY CLUSTERED (
        [CredentialIdentifier] ASC,
        [StaffUSI] ASC,
        [StateOfIssueStateAbbreviationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffCredential] ADD CONSTRAINT [StaffCredential_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffDisciplineIncidentAssociation] --
CREATE TABLE [edfi].[StaffDisciplineIncidentAssociation] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD CONSTRAINT [StaffDisciplineIncidentAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD CONSTRAINT [StaffDisciplineIncidentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ADD CONSTRAINT [StaffDisciplineIncidentAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] --
CREATE TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] (
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_PK] PRIMARY KEY CLUSTERED (
        [DisciplineIncidentParticipationCodeDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] ADD CONSTRAINT [StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducationOrganizationAssignmentAssociation] --
CREATE TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StaffClassificationDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [PositionTitle] [NVARCHAR](100) NULL,
    [EndDate] [DATE] NULL,
    [OrderOfAssignment] [INT] NULL,
    [EmploymentEducationOrganizationId] [INT] NULL,
    [EmploymentStatusDescriptorId] [INT] NULL,
    [EmploymentHireDate] [DATE] NULL,
    [CredentialIdentifier] [NVARCHAR](60) NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
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
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD CONSTRAINT [StaffEducationOrganizationAssignmentAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD CONSTRAINT [StaffEducationOrganizationAssignmentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD CONSTRAINT [StaffEducationOrganizationAssignmentAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffEducationOrganizationContactAssociation] --
CREATE TABLE [edfi].[StaffEducationOrganizationContactAssociation] (
    [ContactTitle] [NVARCHAR](75) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [ContactTypeDescriptorId] [INT] NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationContactAssociation_PK] PRIMARY KEY CLUSTERED (
        [ContactTitle] ASC,
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ADD CONSTRAINT [StaffEducationOrganizationContactAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ADD CONSTRAINT [StaffEducationOrganizationContactAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ADD CONSTRAINT [StaffEducationOrganizationContactAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffEducationOrganizationContactAssociationAddress] --
CREATE TABLE [edfi].[StaffEducationOrganizationContactAssociationAddress] (
    [ContactTitle] [NVARCHAR](75) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [ApartmentRoomSuiteNumber] [NVARCHAR](50) NULL,
    [BuildingSiteNumber] [NVARCHAR](20) NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [NameOfCounty] [NVARCHAR](30) NULL,
    [CountyFIPSCode] [NVARCHAR](5) NULL,
    [Latitude] [NVARCHAR](20) NULL,
    [Longitude] [NVARCHAR](20) NULL,
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CongressionalDistrict] [NVARCHAR](30) NULL,
    [LocaleDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationContactAssociationAddress_PK] PRIMARY KEY CLUSTERED (
        [ContactTitle] ASC,
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationAddress] ADD CONSTRAINT [StaffEducationOrganizationContactAssociationAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducationOrganizationContactAssociationAddressPeriod] --
CREATE TABLE [edfi].[StaffEducationOrganizationContactAssociationAddressPeriod] (
    [BeginDate] [DATE] NOT NULL,
    [ContactTitle] [NVARCHAR](75) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationContactAssociationAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [ContactTitle] ASC,
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationAddressPeriod] ADD CONSTRAINT [StaffEducationOrganizationContactAssociationAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducationOrganizationContactAssociationTelephone] --
CREATE TABLE [edfi].[StaffEducationOrganizationContactAssociationTelephone] (
    [ContactTitle] [NVARCHAR](75) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffEducationOrganizationContactAssociationTelephone_PK] PRIMARY KEY CLUSTERED (
        [ContactTitle] ASC,
        [EducationOrganizationId] ASC,
        [StaffUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociationTelephone] ADD CONSTRAINT [StaffEducationOrganizationContactAssociationTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffEducationOrganizationEmploymentAssociation] --
CREATE TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EmploymentStatusDescriptorId] [INT] NOT NULL,
    [HireDate] [DATE] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [SeparationDescriptorId] [INT] NULL,
    [SeparationReasonDescriptorId] [INT] NULL,
    [Department] [NVARCHAR](60) NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
    [OfferDate] [DATE] NULL,
    [HourlyWage] [MONEY] NULL,
    [CredentialIdentifier] [NVARCHAR](60) NULL,
    [StateOfIssueStateAbbreviationDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD CONSTRAINT [StaffEducationOrganizationEmploymentAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffElectronicMail] --
CREATE TABLE [edfi].[StaffElectronicMail] (
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffElectronicMail] ADD CONSTRAINT [StaffElectronicMail_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffIdentificationCode] --
CREATE TABLE [edfi].[StaffIdentificationCode] (
    [StaffIdentificationSystemDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [StaffIdentificationSystemDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffIdentificationCode] ADD CONSTRAINT [StaffIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffIdentificationDocument] --
CREATE TABLE [edfi].[StaffIdentificationDocument] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffIdentificationDocument] ADD CONSTRAINT [StaffIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[StaffIdentificationSystemDescriptor] (
    [StaffIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StaffIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StaffIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StaffInternationalAddress] --
CREATE TABLE [edfi].[StaffInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
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
    CONSTRAINT [StaffInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffInternationalAddress] ADD CONSTRAINT [StaffInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffLanguage] --
CREATE TABLE [edfi].[StaffLanguage] (
    [LanguageDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffLanguage_PK] PRIMARY KEY CLUSTERED (
        [LanguageDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffLanguage] ADD CONSTRAINT [StaffLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffLanguageUse] --
CREATE TABLE [edfi].[StaffLanguageUse] (
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffLanguageUse] ADD CONSTRAINT [StaffLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[StaffLeave] ADD CONSTRAINT [StaffLeave_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffLeave] ADD CONSTRAINT [StaffLeave_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffLeave] ADD CONSTRAINT [StaffLeave_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffOtherName_PK] PRIMARY KEY CLUSTERED (
        [OtherNameTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffOtherName] ADD CONSTRAINT [StaffOtherName_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffPersonalIdentificationDocument] --
CREATE TABLE [edfi].[StaffPersonalIdentificationDocument] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] ADD CONSTRAINT [StaffPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffProgramAssociation] --
CREATE TABLE [edfi].[StaffProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StaffProgramAssociation] ADD CONSTRAINT [StaffProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffProgramAssociation] ADD CONSTRAINT [StaffProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffProgramAssociation] ADD CONSTRAINT [StaffProgramAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffRace] --
CREATE TABLE [edfi].[StaffRace] (
    [RaceDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffRace_PK] PRIMARY KEY CLUSTERED (
        [RaceDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffRace] ADD CONSTRAINT [StaffRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffRecognition] --
CREATE TABLE [edfi].[StaffRecognition] (
    [RecognitionTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [RecognitionDescription] [NVARCHAR](80) NULL,
    [RecognitionAwardDate] [DATE] NULL,
    [RecognitionAwardExpiresDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffRecognition_PK] PRIMARY KEY CLUSTERED (
        [RecognitionTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffRecognition] ADD CONSTRAINT [StaffRecognition_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffSchoolAssociation] --
CREATE TABLE [edfi].[StaffSchoolAssociation] (
    [ProgramAssignmentDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CalendarCode] [NVARCHAR](60) NULL,
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
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD CONSTRAINT [StaffSchoolAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD CONSTRAINT [StaffSchoolAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffSchoolAssociation] ADD CONSTRAINT [StaffSchoolAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffSchoolAssociationAcademicSubject] --
CREATE TABLE [edfi].[StaffSchoolAssociationAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [ProgramAssignmentDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffSchoolAssociationAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [ProgramAssignmentDescriptorId] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffSchoolAssociationAcademicSubject] ADD CONSTRAINT [StaffSchoolAssociationAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffSchoolAssociationGradeLevel] --
CREATE TABLE [edfi].[StaffSchoolAssociationGradeLevel] (
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [ProgramAssignmentDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffSchoolAssociationGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [GradeLevelDescriptorId] ASC,
        [ProgramAssignmentDescriptorId] ASC,
        [SchoolId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffSchoolAssociationGradeLevel] ADD CONSTRAINT [StaffSchoolAssociationGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StaffSectionAssociation] --
CREATE TABLE [edfi].[StaffSectionAssociation] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [ClassroomPositionDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [HighlyQualifiedTeacher] [BIT] NULL,
    [TeacherStudentDataLinkExclusion] [BIT] NULL,
    [PercentageContribution] [DECIMAL](5, 4) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffSectionAssociation] ADD CONSTRAINT [StaffSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StaffSectionAssociation] ADD CONSTRAINT [StaffSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StaffSectionAssociation] ADD CONSTRAINT [StaffSectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StaffTelephone] --
CREATE TABLE [edfi].[StaffTelephone] (
    [StaffUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffTelephone_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StaffTelephone] ADD CONSTRAINT [StaffTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[StaffTribalAffiliation] ADD CONSTRAINT [StaffTribalAffiliation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[StaffVisa] ADD CONSTRAINT [StaffVisa_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [StateEducationAgencyId] [INT] NOT NULL,
    CONSTRAINT [StateEducationAgency_PK] PRIMARY KEY CLUSTERED (
        [StateEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StateEducationAgencyAccountability] --
CREATE TABLE [edfi].[StateEducationAgencyAccountability] (
    [SchoolYear] [SMALLINT] NOT NULL,
    [StateEducationAgencyId] [INT] NOT NULL,
    [CTEGraduationRateInclusion] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StateEducationAgencyAccountability_PK] PRIMARY KEY CLUSTERED (
        [SchoolYear] ASC,
        [StateEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StateEducationAgencyAccountability] ADD CONSTRAINT [StateEducationAgencyAccountability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StateEducationAgencyFederalFunds] --
CREATE TABLE [edfi].[StateEducationAgencyFederalFunds] (
    [FiscalYear] [INT] NOT NULL,
    [StateEducationAgencyId] [INT] NOT NULL,
    [FederalProgramsFundingAllocation] [MONEY] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StateEducationAgencyFederalFunds_PK] PRIMARY KEY CLUSTERED (
        [FiscalYear] ASC,
        [StateEducationAgencyId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StateEducationAgencyFederalFunds] ADD CONSTRAINT [StateEducationAgencyFederalFunds_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[Student] --
CREATE TABLE [edfi].[Student] (
    [StudentUSI] [INT] IDENTITY(1,1) NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [BirthDate] [DATE] NOT NULL,
    [BirthCity] [NVARCHAR](30) NULL,
    [BirthStateAbbreviationDescriptorId] [INT] NULL,
    [BirthInternationalProvince] [NVARCHAR](150) NULL,
    [BirthCountryDescriptorId] [INT] NULL,
    [DateEnteredUS] [DATE] NULL,
    [MultipleBirthStatus] [BIT] NULL,
    [BirthSexDescriptorId] [INT] NULL,
    [CitizenshipStatusDescriptorId] [INT] NULL,
    [PersonId] [NVARCHAR](32) NULL,
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
ALTER TABLE [edfi].[Student] ADD CONSTRAINT [Student_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Student] ADD CONSTRAINT [Student_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Student] ADD CONSTRAINT [Student_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAcademicRecord] --
CREATE TABLE [edfi].[StudentAcademicRecord] (
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CumulativeEarnedCredits] [DECIMAL](9, 3) NULL,
    [CumulativeEarnedCreditTypeDescriptorId] [INT] NULL,
    [CumulativeEarnedCreditConversion] [DECIMAL](9, 2) NULL,
    [CumulativeAttemptedCredits] [DECIMAL](9, 3) NULL,
    [CumulativeAttemptedCreditTypeDescriptorId] [INT] NULL,
    [CumulativeAttemptedCreditConversion] [DECIMAL](9, 2) NULL,
    [CumulativeGradePointsEarned] [DECIMAL](18, 4) NULL,
    [CumulativeGradePointAverage] [DECIMAL](18, 4) NULL,
    [GradeValueQualifier] [NVARCHAR](80) NULL,
    [ProjectedGraduationDate] [DATE] NULL,
    [SessionEarnedCredits] [DECIMAL](9, 3) NULL,
    [SessionEarnedCreditTypeDescriptorId] [INT] NULL,
    [SessionEarnedCreditConversion] [DECIMAL](9, 2) NULL,
    [SessionAttemptedCredits] [DECIMAL](9, 3) NULL,
    [SessionAttemptedCreditTypeDescriptorId] [INT] NULL,
    [SessionAttemptedCreditConversion] [DECIMAL](9, 2) NULL,
    [SessionGradePointsEarned] [DECIMAL](18, 4) NULL,
    [SessionGradePointAverage] [DECIMAL](18, 4) NULL,
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
ALTER TABLE [edfi].[StudentAcademicRecord] ADD CONSTRAINT [StudentAcademicRecord_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAcademicRecord] ADD CONSTRAINT [StudentAcademicRecord_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAcademicRecord] ADD CONSTRAINT [StudentAcademicRecord_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAcademicRecordAcademicHonor] --
CREATE TABLE [edfi].[StudentAcademicRecordAcademicHonor] (
    [AcademicHonorCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [HonorDescription] [NVARCHAR](80) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [HonorAwardDate] [DATE] NULL,
    [HonorAwardExpiresDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordAcademicHonor_PK] PRIMARY KEY CLUSTERED (
        [AcademicHonorCategoryDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [HonorDescription] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] ADD CONSTRAINT [StudentAcademicRecordAcademicHonor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordClassRanking] --
CREATE TABLE [edfi].[StudentAcademicRecordClassRanking] (
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ClassRank] [INT] NOT NULL,
    [TotalNumberInClass] [INT] NOT NULL,
    [PercentageRanking] [INT] NULL,
    [ClassRankingDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordClassRanking_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordClassRanking] ADD CONSTRAINT [StudentAcademicRecordClassRanking_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordDiploma] --
CREATE TABLE [edfi].[StudentAcademicRecordDiploma] (
    [DiplomaAwardDate] [DATE] NOT NULL,
    [DiplomaTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [DiplomaLevelDescriptorId] [INT] NULL,
    [CTECompleter] [BIT] NULL,
    [DiplomaDescription] [NVARCHAR](80) NULL,
    [DiplomaAwardExpiresDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordDiploma_PK] PRIMARY KEY CLUSTERED (
        [DiplomaAwardDate] ASC,
        [DiplomaTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordDiploma] ADD CONSTRAINT [StudentAcademicRecordDiploma_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordGradePointAverage] --
CREATE TABLE [edfi].[StudentAcademicRecordGradePointAverage] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [IsCumulative] [BIT] NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradePointAverageTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordGradePointAverage] ADD CONSTRAINT [StudentAcademicRecordGradePointAverage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordRecognition] --
CREATE TABLE [edfi].[StudentAcademicRecordRecognition] (
    [EducationOrganizationId] [INT] NOT NULL,
    [RecognitionTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AchievementTitle] [NVARCHAR](60) NULL,
    [AchievementCategoryDescriptorId] [INT] NULL,
    [AchievementCategorySystem] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerOriginURL] [NVARCHAR](255) NULL,
    [Criteria] [NVARCHAR](150) NULL,
    [CriteriaURL] [NVARCHAR](255) NULL,
    [EvidenceStatement] [NVARCHAR](150) NULL,
    [ImageURL] [NVARCHAR](255) NULL,
    [RecognitionDescription] [NVARCHAR](80) NULL,
    [RecognitionAwardDate] [DATE] NULL,
    [RecognitionAwardExpiresDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordRecognition_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RecognitionTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordRecognition] ADD CONSTRAINT [StudentAcademicRecordRecognition_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAcademicRecordReportCard] --
CREATE TABLE [edfi].[StudentAcademicRecordReportCard] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAcademicRecordReportCard_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAcademicRecordReportCard] ADD CONSTRAINT [StudentAcademicRecordReportCard_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessment] --
CREATE TABLE [edfi].[StudentAssessment] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AdministrationDate] [DATETIME2](7) NULL,
    [AdministrationEndDate] [DATETIME2](7) NULL,
    [SerialNumber] [NVARCHAR](60) NULL,
    [AdministrationLanguageDescriptorId] [INT] NULL,
    [AdministrationEnvironmentDescriptorId] [INT] NULL,
    [RetestIndicatorDescriptorId] [INT] NULL,
    [ReasonNotTestedDescriptorId] [INT] NULL,
    [WhenAssessedGradeLevelDescriptorId] [INT] NULL,
    [EventCircumstanceDescriptorId] [INT] NULL,
    [EventDescription] [NVARCHAR](1024) NULL,
    [SchoolYear] [SMALLINT] NULL,
    [PlatformTypeDescriptorId] [INT] NULL,
    [AssessedMinutes] [INT] NULL,
    [ReportedSchoolId] [INT] NULL,
    [ReportedSchoolIdentifier] [NVARCHAR](60) NULL,
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
ALTER TABLE [edfi].[StudentAssessment] ADD CONSTRAINT [StudentAssessment_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAssessment] ADD CONSTRAINT [StudentAssessment_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAssessment] ADD CONSTRAINT [StudentAssessment_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAssessmentAccommodation] --
CREATE TABLE [edfi].[StudentAssessmentAccommodation] (
    [AccommodationDescriptorId] [INT] NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentAccommodation_PK] PRIMARY KEY CLUSTERED (
        [AccommodationDescriptorId] ASC,
        [AssessmentIdentifier] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentAccommodation] ADD CONSTRAINT [StudentAssessmentAccommodation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentEducationOrganizationAssociation] --
CREATE TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationAssociationTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD CONSTRAINT [StudentAssessmentEducationOrganizationAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD CONSTRAINT [StudentAssessmentEducationOrganizationAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ADD CONSTRAINT [StudentAssessmentEducationOrganizationAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentAssessmentItem] --
CREATE TABLE [edfi].[StudentAssessmentItem] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssessmentResponse] [NVARCHAR](255) NULL,
    [DescriptiveFeedback] [NVARCHAR](1024) NULL,
    [ResponseIndicatorDescriptorId] [INT] NULL,
    [AssessmentItemResultDescriptorId] [INT] NOT NULL,
    [RawScoreResult] [DECIMAL](15, 5) NULL,
    [TimeAssessed] [NVARCHAR](30) NULL,
    [ItemNumber] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentItem_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentItem] ADD CONSTRAINT [StudentAssessmentItem_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[StudentAssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [Namespace] ASC,
        [PerformanceLevelDescriptorId] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] ADD CONSTRAINT [StudentAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentPeriod] --
CREATE TABLE [edfi].[StudentAssessmentPeriod] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[StudentAssessmentPeriod] ADD CONSTRAINT [StudentAssessmentPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentScoreResult] --
CREATE TABLE [edfi].[StudentAssessmentScoreResult] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentScoreResult_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentScoreResult] ADD CONSTRAINT [StudentAssessmentScoreResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentStudentObjectiveAssessment] --
CREATE TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AssessedMinutes] [INT] NULL,
    [AdministrationDate] [DATETIME2](7) NULL,
    [AdministrationEndDate] [DATETIME2](7) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentStudentObjectiveAssessment_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] ADD CONSTRAINT [StudentAssessmentStudentObjectiveAssessment_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] --
CREATE TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PerformanceLevelIndicatorName] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [PerformanceLevelDescriptorId] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] ADD CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] --
CREATE TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] (
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentAssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentScoreResult_PK] PRIMARY KEY CLUSTERED (
        [AssessmentIdentifier] ASC,
        [AssessmentReportingMethodDescriptorId] ASC,
        [IdentificationCode] ASC,
        [Namespace] ASC,
        [StudentAssessmentIdentifier] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] ADD CONSTRAINT [StudentAssessmentStudentObjectiveAssessmentScoreResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StudentCohortAssociation] ADD CONSTRAINT [StudentCohortAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentCohortAssociation] ADD CONSTRAINT [StudentCohortAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentCohortAssociation] ADD CONSTRAINT [StudentCohortAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentCohortAssociationSection] --
CREATE TABLE [edfi].[StudentCohortAssociationSection] (
    [BeginDate] [DATE] NOT NULL,
    [CohortIdentifier] [NVARCHAR](36) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCohortAssociationSection_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CohortIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCohortAssociationSection] ADD CONSTRAINT [StudentCohortAssociationSection_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCompetencyObjective] --
CREATE TABLE [edfi].[StudentCompetencyObjective] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveEducationOrganizationId] [INT] NOT NULL,
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
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [Objective] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD CONSTRAINT [StudentCompetencyObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD CONSTRAINT [StudentCompetencyObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentCompetencyObjective] ADD CONSTRAINT [StudentCompetencyObjective_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] --
CREATE TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveEducationOrganizationId] [INT] NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCompetencyObjectiveGeneralStudentProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [Objective] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] ADD CONSTRAINT [StudentCompetencyObjectiveGeneralStudentProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] --
CREATE TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [Objective] [NVARCHAR](60) NOT NULL,
    [ObjectiveEducationOrganizationId] [INT] NOT NULL,
    [ObjectiveGradeLevelDescriptorId] [INT] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCompetencyObjectiveStudentSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LocalCourseCode] ASC,
        [Objective] ASC,
        [ObjectiveEducationOrganizationId] ASC,
        [ObjectiveGradeLevelDescriptorId] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] ADD CONSTRAINT [StudentCompetencyObjectiveStudentSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCTEProgramAssociation] --
CREATE TABLE [edfi].[StudentCTEProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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

-- Table [edfi].[StudentCTEProgramAssociationCTEProgram] --
CREATE TABLE [edfi].[StudentCTEProgramAssociationCTEProgram] (
    [BeginDate] [DATE] NOT NULL,
    [CareerPathwayDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CIPCode] [NVARCHAR](120) NULL,
    [PrimaryCTEProgramIndicator] [BIT] NULL,
    [CTEProgramCompletionIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCTEProgramAssociationCTEProgram_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CareerPathwayDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgram] ADD CONSTRAINT [StudentCTEProgramAssociationCTEProgram_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCTEProgramAssociationCTEProgramService] --
CREATE TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [CTEProgramServiceDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CIPCode] [NVARCHAR](120) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCTEProgramAssociationCTEProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [CTEProgramServiceDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] ADD CONSTRAINT [StudentCTEProgramAssociationCTEProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentCTEProgramAssociationService] --
CREATE TABLE [edfi].[StudentCTEProgramAssociationService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ServiceDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentCTEProgramAssociationService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [ServiceDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentCTEProgramAssociationService] ADD CONSTRAINT [StudentCTEProgramAssociationService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDisciplineIncidentAssociation] --
CREATE TABLE [edfi].[StudentDisciplineIncidentAssociation] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [StudentParticipationCodeDescriptorId] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentAssociation_PK] PRIMARY KEY CLUSTERED (
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ADD CONSTRAINT [StudentDisciplineIncidentAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ADD CONSTRAINT [StudentDisciplineIncidentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ADD CONSTRAINT [StudentDisciplineIncidentAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentDisciplineIncidentAssociationBehavior] --
CREATE TABLE [edfi].[StudentDisciplineIncidentAssociationBehavior] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BehaviorDetailedDescription] [NVARCHAR](1024) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentAssociationBehavior_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentAssociationBehavior] ADD CONSTRAINT [StudentDisciplineIncidentAssociationBehavior_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDisciplineIncidentBehaviorAssociation] --
CREATE TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] --
CREATE TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] (
    [BehaviorDescriptorId] [INT] NOT NULL,
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_PK] PRIMARY KEY CLUSTERED (
        [BehaviorDescriptorId] ASC,
        [DisciplineIncidentParticipationCodeDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] ADD CONSTRAINT [StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentDisciplineIncidentNonOffenderAssociation] --
CREATE TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] (
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] --
CREATE TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] (
    [DisciplineIncidentParticipationCodeDescriptorId] [INT] NOT NULL,
    [IncidentIdentifier] [NVARCHAR](36) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_PK] PRIMARY KEY CLUSTERED (
        [DisciplineIncidentParticipationCodeDescriptorId] ASC,
        [IncidentIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] ADD CONSTRAINT [StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [SexDescriptorId] [INT] NOT NULL,
    [ProfileThumbnail] [NVARCHAR](255) NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [OldEthnicityDescriptorId] [INT] NULL,
    [LimitedEnglishProficiencyDescriptorId] [INT] NULL,
    [LoginId] [NVARCHAR](60) NULL,
    [PrimaryLearningDeviceAwayFromSchoolDescriptorId] [INT] NULL,
    [PrimaryLearningDeviceAccessDescriptorId] [INT] NULL,
    [PrimaryLearningDeviceProviderDescriptorId] [INT] NULL,
    [InternetAccessInResidence] [BIT] NULL,
    [BarrierToInternetAccessInResidenceDescriptorId] [INT] NULL,
    [InternetAccessTypeInResidenceDescriptorId] [INT] NULL,
    [InternetPerformanceInResidenceDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD CONSTRAINT [StudentEducationOrganizationAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD CONSTRAINT [StudentEducationOrganizationAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD CONSTRAINT [StudentEducationOrganizationAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationAddress] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
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
    CONSTRAINT [StudentEducationOrganizationAssociationAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [EducationOrganizationId] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddress] ADD CONSTRAINT [StudentEducationOrganizationAssociationAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationAddressPeriod] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [City] ASC,
        [EducationOrganizationId] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAddressPeriod] ADD CONSTRAINT [StudentEducationOrganizationAssociationAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] (
    [AncestryEthnicOriginDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationAncestryEthnicOrigin_PK] PRIMARY KEY CLUSTERED (
        [AncestryEthnicOriginDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] ADD CONSTRAINT [StudentEducationOrganizationAssociationAncestryEthnicOrigin_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationCohortYear] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] (
    [CohortYearTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TermDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationCohortYear_PK] PRIMARY KEY CLUSTERED (
        [CohortYearTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] ADD CONSTRAINT [StudentEducationOrganizationAssociationCohortYear_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationDisability] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationDisability] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationDisability_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisability] ADD CONSTRAINT [StudentEducationOrganizationAssociationDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] ADD CONSTRAINT [StudentEducationOrganizationAssociationDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationElectronicMail] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationElectronicMail] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationElectronicMail] ADD CONSTRAINT [StudentEducationOrganizationAssociationElectronicMail_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationInternationalAddress] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
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
    CONSTRAINT [StudentEducationOrganizationAssociationInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationInternationalAddress] ADD CONSTRAINT [StudentEducationOrganizationAssociationInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationLanguage] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationLanguage] (
    [EducationOrganizationId] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationLanguage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [LanguageDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguage] ADD CONSTRAINT [StudentEducationOrganizationAssociationLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationLanguageUse] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationLanguageUse] (
    [EducationOrganizationId] [INT] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationLanguageUse] ADD CONSTRAINT [StudentEducationOrganizationAssociationLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationProgramParticipation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationProgramParticipation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationProgramParticipation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationProgramParticipation] ADD CONSTRAINT [StudentEducationOrganizationAssociationProgramParticipation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramCharacteristicDescriptorId] [INT] NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramCharacteristicDescriptorId] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic] ADD CONSTRAINT [StudentEducationOrganizationAssociationProgramParticipationProgramCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationRace] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationRace] (
    [EducationOrganizationId] [INT] NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationRace_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RaceDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationRace] ADD CONSTRAINT [StudentEducationOrganizationAssociationRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] (
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentCharacteristicDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentCharacteristicPeriod] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristicPeriod] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristicPeriod_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [StudentCharacteristicDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentCharacteristicPeriod] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentCharacteristicPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] (
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [AssigningOrganizationIdentificationCode] ASC,
        [EducationOrganizationId] ASC,
        [StudentIdentificationSystemDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIdentificationCode] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentIndicator] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicator] (
    [EducationOrganizationId] [INT] NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IndicatorGroup] [NVARCHAR](200) NULL,
    [Indicator] [NVARCHAR](60) NOT NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicator_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [IndicatorName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicator] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicator_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicatorPeriod_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [IndicatorName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] ADD CONSTRAINT [StudentEducationOrganizationAssociationStudentIndicatorPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationTelephone] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationTelephone] (
    [EducationOrganizationId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentEducationOrganizationAssociationTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [StudentUSI] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTelephone] ADD CONSTRAINT [StudentEducationOrganizationAssociationTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] --
CREATE TABLE [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] (
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] ADD CONSTRAINT [StudentEducationOrganizationAssociationTribalAffiliation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentEducationOrganizationResponsibilityAssociation] --
CREATE TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD CONSTRAINT [StudentEducationOrganizationResponsibilityAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD CONSTRAINT [StudentEducationOrganizationResponsibilityAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ADD CONSTRAINT [StudentEducationOrganizationResponsibilityAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentGradebookEntry] --
CREATE TABLE [edfi].[StudentGradebookEntry] (
    [GradebookEntryIdentifier] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CompetencyLevelDescriptorId] [INT] NULL,
    [DateFulfilled] [DATE] NULL,
    [TimeFulfilled] [TIME](7) NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [PointsEarned] [DECIMAL](9, 2) NULL,
    [LetterGradeEarned] [NVARCHAR](20) NULL,
    [NumericGradeEarned] [DECIMAL](9, 2) NULL,
    [SubmissionStatusDescriptorId] [INT] NULL,
    [AssignmentLateStatusDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[StudentGradebookEntry] ADD CONSTRAINT [StudentGradebookEntry_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentGradebookEntry] ADD CONSTRAINT [StudentGradebookEntry_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentGradebookEntry] ADD CONSTRAINT [StudentGradebookEntry_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentHomelessProgramAssociation] --
CREATE TABLE [edfi].[StudentHomelessProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [HomelessPrimaryNighttimeResidenceDescriptorId] [INT] NULL,
    [AwaitingFosterCare] [BIT] NULL,
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
    [EducationOrganizationId] [INT] NOT NULL,
    [HomelessProgramServiceDescriptorId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentHomelessProgramAssociationHomelessProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [HomelessProgramServiceDescriptorId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentHomelessProgramAssociationHomelessProgramService] ADD CONSTRAINT [StudentHomelessProgramAssociationHomelessProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentIdentificationDocument] --
CREATE TABLE [edfi].[StudentIdentificationDocument] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentIdentificationDocument] ADD CONSTRAINT [StudentIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentIdentificationSystemDescriptor] --
CREATE TABLE [edfi].[StudentIdentificationSystemDescriptor] (
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StudentIdentificationSystemDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StudentIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentInterventionAssociation] --
CREATE TABLE [edfi].[StudentInterventionAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CohortIdentifier] [NVARCHAR](36) NULL,
    [CohortEducationOrganizationId] [INT] NULL,
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
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD CONSTRAINT [StudentInterventionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD CONSTRAINT [StudentInterventionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentInterventionAssociation] ADD CONSTRAINT [StudentInterventionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentInterventionAssociationInterventionEffectiveness] --
CREATE TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] (
    [DiagnosisDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
    [PopulationServedDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ImprovementIndex] [INT] NULL,
    [InterventionEffectivenessRatingDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentInterventionAssociationInterventionEffectiveness_PK] PRIMARY KEY CLUSTERED (
        [DiagnosisDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [InterventionIdentificationCode] ASC,
        [PopulationServedDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] ADD CONSTRAINT [StudentInterventionAssociationInterventionEffectiveness_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentInterventionAttendanceEvent] --
CREATE TABLE [edfi].[StudentInterventionAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [InterventionIdentificationCode] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD CONSTRAINT [StudentInterventionAttendanceEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD CONSTRAINT [StudentInterventionAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD CONSTRAINT [StudentInterventionAttendanceEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentLanguageInstructionProgramAssociation] --
CREATE TABLE [edfi].[StudentLanguageInstructionProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EnglishLearnerParticipation] [BIT] NULL,
    [Dosage] [INT] NULL,
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
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [ParticipationDescriptorId] [INT] NULL,
    [ProficiencyDescriptorId] [INT] NULL,
    [ProgressDescriptorId] [INT] NULL,
    [MonitoredDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] ADD CONSTRAINT [StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] --
CREATE TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [LanguageInstructionProgramServiceDescriptorId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [LanguageInstructionProgramServiceDescriptorId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] ADD CONSTRAINT [StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentLearningObjective] --
CREATE TABLE [edfi].[StudentLearningObjective] (
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CompetencyLevelDescriptorId] [INT] NOT NULL,
    [DiagnosticStatement] [NVARCHAR](1024) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentLearningObjective_PK] PRIMARY KEY CLUSTERED (
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentLearningObjective] ADD CONSTRAINT [StudentLearningObjective_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentLearningObjective] ADD CONSTRAINT [StudentLearningObjective_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentLearningObjective] ADD CONSTRAINT [StudentLearningObjective_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentLearningObjectiveGeneralStudentProgramAssociation] --
CREATE TABLE [edfi].[StudentLearningObjectiveGeneralStudentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentLearningObjectiveGeneralStudentProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LearningObjectiveId] ASC,
        [Namespace] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentLearningObjectiveGeneralStudentProgramAssociation] ADD CONSTRAINT [StudentLearningObjectiveGeneralStudentProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentLearningObjectiveStudentSectionAssociation] --
CREATE TABLE [edfi].[StudentLearningObjectiveStudentSectionAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [GradingPeriodDescriptorId] [INT] NOT NULL,
    [GradingPeriodSchoolId] [INT] NOT NULL,
    [GradingPeriodSchoolYear] [SMALLINT] NOT NULL,
    [GradingPeriodSequence] [INT] NOT NULL,
    [LearningObjectiveId] [NVARCHAR](60) NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentLearningObjectiveStudentSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [GradingPeriodDescriptorId] ASC,
        [GradingPeriodSchoolId] ASC,
        [GradingPeriodSchoolYear] ASC,
        [GradingPeriodSequence] ASC,
        [LearningObjectiveId] ASC,
        [LocalCourseCode] ASC,
        [Namespace] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentLearningObjectiveStudentSectionAssociation] ADD CONSTRAINT [StudentLearningObjectiveStudentSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentMigrantEducationProgramAssociation] --
CREATE TABLE [edfi].[StudentMigrantEducationProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PriorityForServices] [BIT] NOT NULL,
    [LastQualifyingMove] [DATE] NOT NULL,
    [ContinuationOfServicesReasonDescriptorId] [INT] NULL,
    [USInitialEntry] [DATE] NULL,
    [USMostRecentEntry] [DATE] NULL,
    [USInitialSchoolEntry] [DATE] NULL,
    [QualifyingArrivalDate] [DATE] NULL,
    [StateResidencyDate] [DATE] NULL,
    [EligibilityExpirationDate] [DATE] NULL,
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
    [EducationOrganizationId] [INT] NOT NULL,
    [MigrantEducationProgramServiceDescriptorId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentMigrantEducationProgramAssociationMigrantEducationProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [MigrantEducationProgramServiceDescriptorId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] ADD CONSTRAINT [StudentMigrantEducationProgramAssociationMigrantEducationProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentNeglectedOrDelinquentProgramAssociation] --
CREATE TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [NeglectedOrDelinquentProgramDescriptorId] [INT] NULL,
    [ELAProgressLevelDescriptorId] [INT] NULL,
    [MathematicsProgressLevelDescriptorId] [INT] NULL,
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
    [EducationOrganizationId] [INT] NOT NULL,
    [NeglectedOrDelinquentProgramServiceDescriptorId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [NeglectedOrDelinquentProgramServiceDescriptorId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] ADD CONSTRAINT [StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentOtherName] --
CREATE TABLE [edfi].[StudentOtherName] (
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentOtherName_PK] PRIMARY KEY CLUSTERED (
        [OtherNameTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentOtherName] ADD CONSTRAINT [StudentOtherName_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentParentAssociation] --
CREATE TABLE [edfi].[StudentParentAssociation] (
    [ParentUSI] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [RelationDescriptorId] [INT] NULL,
    [PrimaryContactStatus] [BIT] NULL,
    [LivesWith] [BIT] NULL,
    [EmergencyContactStatus] [BIT] NULL,
    [ContactPriority] [INT] NULL,
    [ContactRestrictions] [NVARCHAR](250) NULL,
    [LegalGuardian] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentParentAssociation_PK] PRIMARY KEY CLUSTERED (
        [ParentUSI] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentParentAssociation] ADD CONSTRAINT [StudentParentAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentParentAssociation] ADD CONSTRAINT [StudentParentAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentParentAssociation] ADD CONSTRAINT [StudentParentAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentParticipationCodeDescriptor] --
CREATE TABLE [edfi].[StudentParticipationCodeDescriptor] (
    [StudentParticipationCodeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StudentParticipationCodeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StudentParticipationCodeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[StudentPersonalIdentificationDocument] --
CREATE TABLE [edfi].[StudentPersonalIdentificationDocument] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] ADD CONSTRAINT [StudentPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentProgramAssociation] --
CREATE TABLE [edfi].[StudentProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ServiceDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
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
        [ServiceDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentProgramAssociationService] ADD CONSTRAINT [StudentProgramAssociationService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentProgramAttendanceEvent] --
CREATE TABLE [edfi].[StudentProgramAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD CONSTRAINT [StudentProgramAttendanceEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD CONSTRAINT [StudentProgramAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD CONSTRAINT [StudentProgramAttendanceEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSchoolAssociation] --
CREATE TABLE [edfi].[StudentSchoolAssociation] (
    [EntryDate] [DATE] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimarySchool] [BIT] NULL,
    [EntryGradeLevelDescriptorId] [INT] NOT NULL,
    [EntryGradeLevelReasonDescriptorId] [INT] NULL,
    [EntryTypeDescriptorId] [INT] NULL,
    [RepeatGradeIndicator] [BIT] NULL,
    [ClassOfSchoolYear] [SMALLINT] NULL,
    [SchoolChoiceTransfer] [BIT] NULL,
    [ExitWithdrawDate] [DATE] NULL,
    [ExitWithdrawTypeDescriptorId] [INT] NULL,
    [ResidencyStatusDescriptorId] [INT] NULL,
    [GraduationPlanTypeDescriptorId] [INT] NULL,
    [EducationOrganizationId] [INT] NULL,
    [GraduationSchoolYear] [SMALLINT] NULL,
    [EmployedWhileEnrolled] [BIT] NULL,
    [CalendarCode] [NVARCHAR](60) NULL,
    [SchoolYear] [SMALLINT] NULL,
    [FullTimeEquivalency] [DECIMAL](5, 4) NULL,
    [TermCompletionIndicator] [BIT] NULL,
    [NextYearSchoolId] [INT] NULL,
    [NextYearGradeLevelDescriptorId] [INT] NULL,
    [SchoolChoice] [BIT] NULL,
    [SchoolChoiceBasisDescriptorId] [INT] NULL,
    [EnrollmentTypeDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD CONSTRAINT [StudentSchoolAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD CONSTRAINT [StudentSchoolAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSchoolAssociation] ADD CONSTRAINT [StudentSchoolAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] --
CREATE TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] (
    [AlternativeEducationOrganizationId] [INT] NOT NULL,
    [AlternativeGraduationPlanTypeDescriptorId] [INT] NOT NULL,
    [AlternativeGraduationSchoolYear] [SMALLINT] NOT NULL,
    [EntryDate] [DATE] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSchoolAssociationAlternativeGraduationPlan_PK] PRIMARY KEY CLUSTERED (
        [AlternativeEducationOrganizationId] ASC,
        [AlternativeGraduationPlanTypeDescriptorId] ASC,
        [AlternativeGraduationSchoolYear] ASC,
        [EntryDate] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] ADD CONSTRAINT [StudentSchoolAssociationAlternativeGraduationPlan_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSchoolAssociationEducationPlan] --
CREATE TABLE [edfi].[StudentSchoolAssociationEducationPlan] (
    [EducationPlanDescriptorId] [INT] NOT NULL,
    [EntryDate] [DATE] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSchoolAssociationEducationPlan_PK] PRIMARY KEY CLUSTERED (
        [EducationPlanDescriptorId] ASC,
        [EntryDate] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolAssociationEducationPlan] ADD CONSTRAINT [StudentSchoolAssociationEducationPlan_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSchoolAttendanceEvent] --
CREATE TABLE [edfi].[StudentSchoolAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AttendanceEventReason] [NVARCHAR](255) NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [EventDuration] [DECIMAL](3, 2) NULL,
    [SchoolAttendanceDuration] [INT] NULL,
    [ArrivalTime] [TIME](7) NULL,
    [DepartureTime] [TIME](7) NULL,
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
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD CONSTRAINT [StudentSchoolAttendanceEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD CONSTRAINT [StudentSchoolAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD CONSTRAINT [StudentSchoolAttendanceEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSchoolFoodServiceProgramAssociation] --
CREATE TABLE [edfi].[StudentSchoolFoodServiceProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SchoolFoodServiceProgramServiceDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
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
        [SchoolFoodServiceProgramServiceDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] ADD CONSTRAINT [StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSectionAssociation] --
CREATE TABLE [edfi].[StudentSectionAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndDate] [DATE] NULL,
    [HomeroomIndicator] [BIT] NULL,
    [RepeatIdentifierDescriptorId] [INT] NULL,
    [TeacherStudentDataLinkExclusion] [BIT] NULL,
    [AttemptStatusDescriptorId] [INT] NULL,
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
ALTER TABLE [edfi].[StudentSectionAssociation] ADD CONSTRAINT [StudentSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSectionAssociation] ADD CONSTRAINT [StudentSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSectionAssociation] ADD CONSTRAINT [StudentSectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSectionAttendanceEvent] --
CREATE TABLE [edfi].[StudentSectionAttendanceEvent] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AttendanceEventReason] [NVARCHAR](255) NULL,
    [EducationalEnvironmentDescriptorId] [INT] NULL,
    [EventDuration] [DECIMAL](3, 2) NULL,
    [SectionAttendanceDuration] [INT] NULL,
    [ArrivalTime] [TIME](7) NULL,
    [DepartureTime] [TIME](7) NULL,
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
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD CONSTRAINT [StudentSectionAttendanceEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD CONSTRAINT [StudentSectionAttendanceEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD CONSTRAINT [StudentSectionAttendanceEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[StudentSectionAttendanceEventClassPeriod] --
CREATE TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] (
    [AttendanceEventCategoryDescriptorId] [INT] NOT NULL,
    [ClassPeriodName] [NVARCHAR](60) NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSectionAttendanceEventClassPeriod_PK] PRIMARY KEY CLUSTERED (
        [AttendanceEventCategoryDescriptorId] ASC,
        [ClassPeriodName] ASC,
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
ALTER TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] ADD CONSTRAINT [StudentSectionAttendanceEventClassPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociation] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [IdeaEligibility] [BIT] NULL,
    [SpecialEducationSettingDescriptorId] [INT] NULL,
    [SpecialEducationHoursPerWeek] [DECIMAL](5, 2) NULL,
    [SchoolHoursPerWeek] [DECIMAL](5, 2) NULL,
    [MultiplyDisabled] [BIT] NULL,
    [MedicallyFragile] [BIT] NULL,
    [LastEvaluationDate] [DATE] NULL,
    [IEPReviewDate] [DATE] NULL,
    [IEPBeginDate] [DATE] NULL,
    [IEPEndDate] [DATE] NULL,
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
    [DisabilityDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationDisability_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [DisabilityDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] (
    [BeginDate] [DATE] NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryProvider] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationServiceProvider_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StaffUSI] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationServiceProvider_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SpecialEducationProgramServiceDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
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
        [SpecialEducationProgramServiceDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationSpecialEducationProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] --
CREATE TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SpecialEducationProgramServiceDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryProvider] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [SpecialEducationProgramServiceDescriptorId] ASC,
        [StaffUSI] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] ADD CONSTRAINT [StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentTitleIPartAProgramAssociation] --
CREATE TABLE [edfi].[StudentTitleIPartAProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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

-- Table [edfi].[StudentTitleIPartAProgramAssociationService] --
CREATE TABLE [edfi].[StudentTitleIPartAProgramAssociationService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [ServiceDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [PrimaryIndicator] [BIT] NULL,
    [ServiceBeginDate] [DATE] NULL,
    [ServiceEndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentTitleIPartAProgramAssociationService_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [ServiceDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociationService] ADD CONSTRAINT [StudentTitleIPartAProgramAssociationService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] --
CREATE TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramEducationOrganizationId] [INT] NOT NULL,
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
ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] ADD CONSTRAINT [StudentTitleIPartAProgramAssociationTitleIPartAProgramService_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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
ALTER TABLE [edfi].[StudentVisa] ADD CONSTRAINT [StudentVisa_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SubmissionStatusDescriptor] --
CREATE TABLE [edfi].[SubmissionStatusDescriptor] (
    [SubmissionStatusDescriptorId] [INT] NOT NULL,
    CONSTRAINT [SubmissionStatusDescriptor_PK] PRIMARY KEY CLUSTERED (
        [SubmissionStatusDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [edfi].[Survey] --
CREATE TABLE [edfi].[Survey] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NULL,
    [SurveyTitle] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SchoolId] [INT] NULL,
    [SurveyCategoryDescriptorId] [INT] NULL,
    [NumberAdministered] [INT] NULL,
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
ALTER TABLE [edfi].[Survey] ADD CONSTRAINT [Survey_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[Survey] ADD CONSTRAINT [Survey_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[Survey] ADD CONSTRAINT [Survey_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD CONSTRAINT [SurveyCourseAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD CONSTRAINT [SurveyCourseAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyCourseAssociation] ADD CONSTRAINT [SurveyCourseAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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
    [EducationOrganizationId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD CONSTRAINT [SurveyProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD CONSTRAINT [SurveyProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyProgramAssociation] ADD CONSTRAINT [SurveyProgramAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyQuestion] --
CREATE TABLE [edfi].[SurveyQuestion] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](60) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveyQuestion] ADD CONSTRAINT [SurveyQuestion_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyQuestion] ADD CONSTRAINT [SurveyQuestion_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyQuestion] ADD CONSTRAINT [SurveyQuestion_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyQuestionMatrix] --
CREATE TABLE [edfi].[SurveyQuestionMatrix] (
    [MatrixElement] [NVARCHAR](255) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](60) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [MinRawScore] [INT] NULL,
    [MaxRawScore] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionMatrix_PK] PRIMARY KEY CLUSTERED (
        [MatrixElement] ASC,
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionMatrix] ADD CONSTRAINT [SurveyQuestionMatrix_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyQuestionResponse] --
CREATE TABLE [edfi].[SurveyQuestionResponse] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](60) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [NoResponse] [BIT] NULL,
    [Comment] [NVARCHAR](1024) NULL,
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
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD CONSTRAINT [SurveyQuestionResponse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD CONSTRAINT [SurveyQuestionResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyQuestionResponse] ADD CONSTRAINT [SurveyQuestionResponse_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyQuestionResponseChoice] --
CREATE TABLE [edfi].[SurveyQuestionResponseChoice] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](60) NOT NULL,
    [SortOrder] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [NumericValue] [INT] NULL,
    [TextValue] [NVARCHAR](255) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionResponseChoice_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SortOrder] ASC,
        [SurveyIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionResponseChoice] ADD CONSTRAINT [SurveyQuestionResponseChoice_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] --
CREATE TABLE [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] (
    [MatrixElement] [NVARCHAR](255) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](60) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [NumericResponse] [INT] NULL,
    [TextResponse] [NVARCHAR](2048) NULL,
    [NoResponse] [BIT] NULL,
    [MinNumericResponse] [INT] NULL,
    [MaxNumericResponse] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionResponseSurveyQuestionMatrixElementResponse_PK] PRIMARY KEY CLUSTERED (
        [MatrixElement] ASC,
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] ADD CONSTRAINT [SurveyQuestionResponseSurveyQuestionMatrixElementResponse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyQuestionResponseValue] --
CREATE TABLE [edfi].[SurveyQuestionResponseValue] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [QuestionCode] [NVARCHAR](60) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyQuestionResponseValueIdentifier] [INT] NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [NumericResponse] [INT] NULL,
    [TextResponse] [NVARCHAR](2048) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyQuestionResponseValue_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [QuestionCode] ASC,
        [SurveyIdentifier] ASC,
        [SurveyQuestionResponseValueIdentifier] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyQuestionResponseValue] ADD CONSTRAINT [SurveyQuestionResponseValue_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveyResponse] --
CREATE TABLE [edfi].[SurveyResponse] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [ResponseDate] [DATE] NOT NULL,
    [ResponseTime] [INT] NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NULL,
    [FullName] [NVARCHAR](80) NULL,
    [Location] [NVARCHAR](75) NULL,
    [StudentUSI] [INT] NULL,
    [ParentUSI] [INT] NULL,
    [StaffUSI] [INT] NULL,
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
ALTER TABLE [edfi].[SurveyResponse] ADD CONSTRAINT [SurveyResponse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyResponse] ADD CONSTRAINT [SurveyResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyResponse] ADD CONSTRAINT [SurveyResponse_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyResponseEducationOrganizationTargetAssociation] --
CREATE TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveyResponseEducationOrganizationTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveyResponseEducationOrganizationTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveyResponseEducationOrganizationTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyResponseStaffTargetAssociation] --
CREATE TABLE [edfi].[SurveyResponseStaffTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD CONSTRAINT [SurveyResponseStaffTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD CONSTRAINT [SurveyResponseStaffTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ADD CONSTRAINT [SurveyResponseStaffTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveyResponseSurveyLevel] --
CREATE TABLE [edfi].[SurveyResponseSurveyLevel] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyLevelDescriptorId] [INT] NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [SurveyResponseSurveyLevel_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyLevelDescriptorId] ASC,
        [SurveyResponseIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [edfi].[SurveyResponseSurveyLevel] ADD CONSTRAINT [SurveyResponseSurveyLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [edfi].[SurveySection] --
CREATE TABLE [edfi].[SurveySection] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
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
ALTER TABLE [edfi].[SurveySection] ADD CONSTRAINT [SurveySection_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySection] ADD CONSTRAINT [SurveySection_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySection] ADD CONSTRAINT [SurveySection_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionAssociation] --
CREATE TABLE [edfi].[SurveySectionAssociation] (
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveySectionAssociation] ADD CONSTRAINT [SurveySectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionAssociation] ADD CONSTRAINT [SurveySectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionAssociation] ADD CONSTRAINT [SurveySectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionResponse] --
CREATE TABLE [edfi].[SurveySectionResponse] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveySectionResponse] ADD CONSTRAINT [SurveySectionResponse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionResponse] ADD CONSTRAINT [SurveySectionResponse_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionResponse] ADD CONSTRAINT [SurveySectionResponse_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] --
CREATE TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveySectionResponseEducationOrganizationTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveySectionResponseEducationOrganizationTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ADD CONSTRAINT [SurveySectionResponseEducationOrganizationTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [edfi].[SurveySectionResponseStaffTargetAssociation] --
CREATE TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
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
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD CONSTRAINT [SurveySectionResponseStaffTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD CONSTRAINT [SurveySectionResponseStaffTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ADD CONSTRAINT [SurveySectionResponseStaffTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

